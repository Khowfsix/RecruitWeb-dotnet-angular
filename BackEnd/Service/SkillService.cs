using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public async Task<SkillModel> GetSkillById(Guid id)
        {
            var data = await _skillRepository.GetSkillById(id);
            return _mapper.Map<SkillModel>(data);
        }

        public SkillService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SkillModel>> GetAllSkills(bool isAdmin, string? request)
        {
            var entities = await _skillRepository.GetAllSkills(request);
            var models = _mapper.Map<List<SkillModel>>(entities);
            
            return !isAdmin ? models.Where(o => !o.IsDeleted).ToList() : models;
        }

        public async Task<SkillModel> SaveSkill(SkillModel request)
        {
            var entity = _mapper.Map<Skill>(request);
            var response = await _skillRepository.SaveSkill(entity);
            return _mapper.Map<SkillModel>(response);
        }

        public async Task<bool> UpdateSkill(SkillModel request, Guid requestId)
        {
            var entity = _mapper.Map<Skill>(request);
            return await _skillRepository.UpdateSkill(entity, requestId);
        }

        public async Task<bool> DeleteSkill(Guid requestId)
        {
            return await _skillRepository.DeleteSkill(requestId);
        }
    }
}