using AutoMapper;
using Data.CustomModel.Interviewer;
using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using Service.Interfaces;
using Service.Models;

namespace Service;

public class InterviewerService : IInterviewerService
{
    private readonly UserManager<WebUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IInterviewerRepository _interviewerRepository;
    private readonly IMapper _mapper;

    public InterviewerService(IInterviewerRepository interviewerRepository, IMapper mapper, UserManager<WebUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager; 
        _interviewerRepository = interviewerRepository;
        _mapper = mapper;
    }

    public async Task<InterviewerModel> SaveInterviewer(InterviewerModel addModel)
    {
        var data = _mapper.Map<Interviewer>(addModel);
        var response = await _interviewerRepository.SaveInterviewer(data);
        string role = "Interviewer";
        var userExist = await _userManager.FindByIdAsync(addModel.UserId);
        if (userExist == null)
        {
            return null;
        }
        if (await _roleManager.RoleExistsAsync(role))
        {
            await _userManager.AddToRoleAsync(userExist, role);
        }
        else
        {
            return null;
        }
        return _mapper.Map<InterviewerModel>(response);
    }

    public async Task<bool> DeleteInterviewer(Guid interviewerModelId)
    {
        if (!await _interviewerRepository.DeleteInterviewer(interviewerModelId))
        {
            return await Task.FromResult(false);
        }
        var foundInterviewer = await _interviewerRepository.GetInterviewerById(interviewerModelId);
        if (foundInterviewer == null)
        {
            return await Task.FromResult(false);
        }
        string role = "Interviewer";
        var userExist = await _userManager.FindByIdAsync(foundInterviewer.UserId);
        if (userExist == null)
        {
            return await Task.FromResult(false);
        }
        if (await _roleManager.RoleExistsAsync(role))
        {
            await _userManager.RemoveFromRoleAsync(userExist, role);
            return await Task.FromResult(true);
        }
        else
        {
            return await Task.FromResult(false);
        }
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