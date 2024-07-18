namespace Service;

using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Service.Interfaces;
using Service.Models;

public class RecruiterService : IRecruiterService
{
    private readonly UserManager<WebUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    private readonly ICompanyRepository _companyRepository;
    private readonly IRecruiterRepository _recruiterRepository;
    private readonly IMapper _mapper;

    public RecruiterService(ICompanyRepository companyRepository, UserManager<WebUser> userManager, RoleManager<IdentityRole> roleManager, IRecruiterRepository recruiterRepository, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _userManager = userManager;
        _roleManager = roleManager;
        _recruiterRepository = recruiterRepository;
        _mapper = mapper;
    }

    public async Task<RecruiterModel> SaveRecruiter(RecruiterModel recruiterModel)
    {
        var entity = _mapper.Map<Recruiter>(recruiterModel);
        var response = await _recruiterRepository.SaveRecruiter(entity);
        return _mapper.Map<RecruiterModel>(response);
    }

    public async Task<bool> DeleteRecruiter(Guid recruiterModelId)
    {
        return await _recruiterRepository.DeleteRecruiter(recruiterModelId);
    }

    public async Task<IEnumerable<RecruiterModel>> GetAllRecruiter()
    {
        var entities = await _recruiterRepository.GetAllRecruiter();
        List<RecruiterModel> models = new List<RecruiterModel>();
        foreach (var item in entities)
        {
            models.Add(_mapper.Map<RecruiterModel>(item));
        }
        return models;
    }

    public async Task<bool> UpdateRecruiter(RecruiterModel recruiterModel, Guid recruiterModelId)
    {
        var entity = _mapper.Map<Recruiter>(recruiterModel);
        return await _recruiterRepository.UpdateRecruiter(entity, recruiterModelId);
    }

    public async Task<bool> UpdateStatus(bool isActived, bool isDeleted, Guid requestId)
    {
        var foundRecruiter = await this.GetRecruiterById(requestId);
        string role = "Recruiter";
        var userExist = await _userManager.FindByIdAsync(foundRecruiter.UserId);
        if (userExist == null)
        {
            return await Task.FromResult(false);
        }
        if (!await _roleManager.RoleExistsAsync(role))
        {
            return await Task.FromResult(false);
        }

        if (isActived && !isDeleted)
        {
            await _userManager.AddToRoleAsync(userExist, role);

            var foundCompany = await _companyRepository.GetCompanyById(foundRecruiter.CompanyId);
            if (foundCompany == null)
            {
                return await Task.FromResult(false);
            }
            if (!foundCompany.IsActived)
            {
                return await Task.FromResult(false);
            }

        }
       
        return await _recruiterRepository.UpdateStatus(isActived, isDeleted, requestId);
    }

    public async Task<RecruiterModel?> GetRecruiterById(Guid id)
    {
        var data = await _recruiterRepository.GetRecruiterById(id);
        return _mapper.Map<RecruiterModel>(data);
    }

    public async Task<RecruiterModel> GetRecruiterByUserId(string userId)
    {
        var data = await _recruiterRepository.GetRecruiterByUserId(userId);
        return _mapper.Map<RecruiterModel>(data);
    }

    public async Task<RecruiterModel> GetNotDeletedRecruiterByUserId(string userId)
    {
        var data = await _recruiterRepository.GetNotDeletedRecruiterByUserId(userId);
        return _mapper.Map<RecruiterModel>(data);
    }
}