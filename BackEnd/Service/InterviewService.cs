using AutoMapper;
using Data.Entities;
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
        var data = await this.GetInterviewsByInterviewer(interviewerId);
        if (data == null || data.Count() == 0)
            return null;
        data.OrderByDescending(o => o.MeetingDate);
        var result = _mapper.Map<InterviewModel>(data.First());
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
        var interviewData = _mapper.Map<Interview>(interviewModel);

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

    public async Task<IEnumerable<InterviewModel>> GetInterviewsByCompany(Guid requestId)
    {
        var data = await _interviewRepository.GetAllInterview();
        if (!data.IsNullOrEmpty())
        {
            var filteredDatas = data.Where(i => i.Application.Position.Company.CompanyId.Equals(requestId));
            List<InterviewModel> result = _mapper.Map<List<InterviewModel>>(filteredDatas);
            return result;
        }
        return null!;
    }

    public async Task<IEnumerable<InterviewModel>> GetAllInterview(string status)
    {
        var data = await _interviewRepository.GetAllInterview();
        if (!data.IsNullOrEmpty())
        {
            var filteredDatas = data.Where(i => (
                i.Company_Status!.Contains(status) ||
                i.Candidate_Status!.Contains(status)
            ));
            List<InterviewModel> result = _mapper.Map<List<InterviewModel>>(filteredDatas);
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

    public async Task<bool> UpdateStatusInterview(Guid interviewId, string? Candidate_Status, string? Company_Status)
    {
        var oldData = await _interviewRepository.GetInterviewById_NoInclude(interviewId);

        if (!string.IsNullOrEmpty(Candidate_Status))
        {
            oldData!.Candidate_Status = Candidate_Status!;
        }

        if (!string.IsNullOrEmpty(Company_Status))
        {
            oldData!.Company_Status = Company_Status!;
        }

        #region old status

        //if (data.Company_Status == "Pending")
        //{
        //    if (newStatus.Equals("Rejected"))
        //    {
        //        // Do nothing
        //    }
        //    else if (newStatus.Equals("Accepted"))
        //    {
        //        data.Candidate_Status = "Passing";
        //    }
        //}
        //else if (newStatus.Equals("Accepted"))
        //{
        //    // Do nothing
        //}
        //else
        //{
        //    // newStatus == "Rejected"
        //    //Do nothing
        //}

        #endregion old status

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