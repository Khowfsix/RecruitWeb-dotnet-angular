using AutoMapper;
using Data.CustomModel.Interviewer;
using Data.Entities;
using Data.Enums;
using Data.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Service.Models;

namespace Service;

public class InterviewService : IInterviewService
{
    private readonly IInterviewRepository _interviewRepository;
    private readonly IItrsinterviewRepository _itrsinterviewRepository;
    private readonly IRoundRepository _roundRepository;
    private readonly IMapper _mapper;

    public InterviewService(IInterviewRepository interviewRepository,
        IRoundRepository roundRepository,
        IItrsinterviewRepository itrsinterviewRepository,
        IMapper mapper)
    {
        _interviewRepository = interviewRepository;
        _itrsinterviewRepository = itrsinterviewRepository;
        _roundRepository = roundRepository;
        _mapper = mapper;
    }
    public async Task<InterviewModel> GetLastInterviewByInterviewerId(Guid interviewerId)
    {
        var data = await _interviewRepository.GetLastInterviewOfInterviewer(interviewerId);
        if (data == null)
            return null;
        var result = _mapper.Map<InterviewModel>(data);
        return result;
    }

    public async Task<InterviewModel?> GetInterviewById(Guid id)
    {
        var data = await _interviewRepository.GetInterviewById(id);
        var result = _mapper.Map<InterviewModel>(data);
        return result;
    }

    public async Task<InterviewModel> SaveInterview(InterviewModel interviewModel)
    {
        interviewModel.Candidate_Status = (int?)EInterviewCandidateStatus.NOT_START;
        interviewModel.Company_Status = (int?)EInterviewCompanyStatus.PENDING;
        var interviewData = _mapper.Map<Interview>(interviewModel);

        var foundInterviews = await this.GetInterviewsByInterviewer(interviewData.InterviewerId);
        if (foundInterviews != null && foundInterviews
            .Any(e =>
                interviewData.MeetingDate == e.MeetingDate
                && !(interviewData.EndTime < e.StartTime || interviewData.StartTime > e.EndTime)
            )
        )
        {
            return null;
        }

        var response = await _interviewRepository.SaveInterview(interviewData);
        return _mapper.Map<InterviewModel>(response);
    }

    public async Task<bool> DeleteInterview(Guid interviewModelId)
    {
        var thisInterview = await GetInterviewById_noInclude(interviewModelId);
        var response = await _interviewRepository.DeleteInterview(interviewModelId);
        return response;
    }

    public async Task<bool> UpdateInterview(InterviewModel interviewModel, Guid interviewModelId)
    {
        var foundInterview = await this.GetInterviewById(interviewModelId);
        if (foundInterview != null)
            return await Task.FromResult(false);
        if (foundInterview!.Company_Status != (int?)EInterviewCompanyStatus.PENDING)
            return await Task.FromResult(false);

        var foundInterviews = await this.GetInterviewsByInterviewer(interviewModel.InterviewerId);
        if (foundInterviews != null && foundInterviews
            .Any(e =>
                interviewModel.MeetingDate == e.MeetingDate
                && !(interviewModel.EndTime < e.StartTime || interviewModel.StartTime > e.EndTime)
            )
        )
        {
            return await Task.FromResult(false);
        }

        var data = _mapper.Map<Interview>(interviewModel);
        return await _interviewRepository.UpdateInterview(data, interviewModelId);
    }

    public async Task<IEnumerable<InterviewModel>> GetInterviewsByPositon(Guid requestId)
    {
        var data = await _interviewRepository.GetAllInterview();
        if (!data.IsNullOrEmpty())
        {
            List<InterviewModel> result = _mapper.Map<List<InterviewModel>>(data);
            return result;
        }
        return null!;
    }

#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
    public async Task<IEnumerable<InterviewModel>> GetInterviewsByCompanyId(Guid requestId, InterviewFilter interviewFilter, string sortString)
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
    {
        var data = await _interviewRepository.GetInterviewsByCompanyId(requestId, interviewFilter, sortString);
        if (!data.IsNullOrEmpty())
        {
            List<InterviewModel> result = _mapper.Map<List<InterviewModel>>(data);
            return result;
        }
        return null!;
    }

    public async Task<IEnumerable<InterviewModel>> GetAllInterview(int? status)
    {
        var data = await _interviewRepository.GetAllInterview();
        if (!data.IsNullOrEmpty())
        {
            var result = _mapper.Map<List<InterviewModel>>(data);

            if (status.HasValue)
            {
                var filteredDatas = result.Where(i => (
                   i.Company_Status! == status ||
                   i.Candidate_Status! == status
                ));
               return filteredDatas;
            }
            return result;
        }
        return null!;
    }

    public async Task<IEnumerable<InterviewModel>> GetInterviewsByInterviewer(Guid requestId)
    {
        var data = await _interviewRepository.GetInterviewOfInterviewer(requestId);
        if (!data.IsNullOrEmpty())
        {
            List<InterviewModel> result = _mapper.Map<List<InterviewModel>>(data);
            return result!;
        }
        return null!;
    }

    public async Task<bool> UpdateStatusInterview(Guid interviewId, int? Candidate_Status, int? Company_Status)
    {
        var oldData = await _interviewRepository.GetInterviewById_NoInclude(interviewId);

        if (Candidate_Status.HasValue)
        {
            if (oldData!.Candidate_Status!.Value >= Candidate_Status.Value)
                return await Task.FromResult(false);
            oldData!.Candidate_Status = Candidate_Status!;
        }

        if (Company_Status.HasValue)
        {
            if (oldData!.Company_Status!.Value >= Company_Status.Value)
                return await Task.FromResult(false);
            oldData!.Company_Status = Company_Status!;
        }

        return await _interviewRepository.UpdateInterview(oldData!, interviewId);
    }

    public async Task<InterviewModel?> GetInterviewById_noInclude(Guid id)
    {
        var entityData = await _interviewRepository.GetInterviewById_NoInclude(id);
        return _mapper.Map<InterviewModel?>(entityData);
    }

    //todo: interview result question
    public async Task<InterviewModel?> PostQuestionIntoInterview(InterviewResultQuestion_Model request)
    {
        var thisInterview = await _interviewRepository.GetInterviewById_NoInclude(request.InterviewId);
        if (thisInterview == null) return null!;

        thisInterview.Notes = request.Notes;
        var updateInterview = await _interviewRepository.UpdateInterview(thisInterview, request.InterviewId);

        foreach (var item in request.Rounds)
        {
            var newRound = _mapper.Map<Round>(item);
            var respInsertRounds = await _roundRepository.SaveRound(newRound);

            if (respInsertRounds == null)
            {
                return null!;
            }
        }

        if (updateInterview != true)
        {
            return null!;
        }

        return _mapper.Map<InterviewModel>(thisInterview);
    }
}