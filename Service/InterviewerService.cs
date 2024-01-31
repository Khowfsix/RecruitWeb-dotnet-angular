using AutoMapper;
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

    public async Task<IEnumerable<InterviewerModel?>> GetInterviewersInDepartment(Guid departmentId)
    {
        var entityDatas = await _interviewerRepository.GetAllInterviewer();

        if (!entityDatas.IsNullOrEmpty())
        {
            var filteredDatas = entityDatas.Where(item => item.DepartmentId.Equals(departmentId));
            List<InterviewerModel> datas = _mapper.Map<List<InterviewerModel>>(filteredDatas);

            return _mapper.Map<List<InterviewerModel>>(datas);
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