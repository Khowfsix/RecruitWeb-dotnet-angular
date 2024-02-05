namespace Service;

using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Service.Interfaces;
using Service.Models;

public class RecruiterService : IRecruiterService
{
    private readonly IRecruiterRepository _recruiterRepository;
    private readonly IMapper _mapper;

    public RecruiterService(IRecruiterRepository recruiterRepository, IMapper mapper)
    {
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

    async Task<RecruiterModel?> IRecruiterService.GetRecruiterById(Guid id)
    {
        var data = await _recruiterRepository.GetRecruiterById(id);
        return _mapper.Map<RecruiterModel>(data);
    }
}