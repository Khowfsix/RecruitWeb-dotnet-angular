using AutoMapper;
using Data.CustomModel.Interviewer;
using Data.Entities;
using Data.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Service.Models;

namespace Service;

public class InterviewerService : IInterviewerService
{
    private readonly IInterviewerRepository _interviewerRepository;
    private readonly IMapper _mapper;

    public InterviewerService(IInterviewerRepository interviewerRepository, IMapper mapper)
    {
        _interviewerRepository = interviewerRepository;
        _mapper = mapper;
    }

    public async Task<InterviewerModel> SaveInterviewer(InterviewerModel addModel)
    {
        var data = _mapper.Map<Interviewer>(addModel);
        var response = await _interviewerRepository.SaveInterviewer(data);
        return _mapper.Map<InterviewerModel>(response);
    }

    public async Task<bool> DeleteInterviewer(Guid interviewerModelId)
    {
        return await _interviewerRepository.DeleteInterviewer(interviewerModelId);
    }

    public async Task<IEnumerable<InterviewerModel>> GetAllInterviewer()
    {
        var data = await _interviewerRepository.GetAllInterviewer();
        return data.Select(item => _mapper.Map<InterviewerModel>(item)).ToList();
    }

    public async Task<IEnumerable<InterviewerModel?>> GetInterviewersInCompany(Guid companyId, InterviewerFilter interviewerFilter, string sortString)
    {
        var entityDatas = await _interviewerRepository.GetInterviewersInCompany(companyId, interviewerFilter, sortString);

        if (!entityDatas.IsNullOrEmpty())
        {
            var models = _mapper.Map<List<InterviewerModel>>(entityDatas);
            return models;
        }
        return null!;
    }

    public async Task<bool> UpdateInterviewer(InterviewerModel interviewerModel, Guid interviewerModelId)
    {
        var data = _mapper.Map<Interviewer>(interviewerModel);
        return await _interviewerRepository.UpdateInterviewer(data, interviewerModelId);
    }

    public async Task<InterviewerModel?> GetInterviewerById(Guid id)
    {
        var data = await _interviewerRepository.GetInterviewerById(id);
        var result = _mapper.Map<InterviewerModel>(data);
        return result;
    }
}