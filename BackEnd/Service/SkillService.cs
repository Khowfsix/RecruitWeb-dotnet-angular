using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public SkillService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SkillModel>> GetAllSkills(string? request)
        {
            var entities = await _skillRepository.GetAllSkills(request);
            if (entities != null)
            {
                List<SkillModel> models = new List<SkillModel>();
                foreach (var item in entities)
                {
                    models.Add(_mapper.Map<SkillModel>(item));
                }
                return models;
            }
            return null!;
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