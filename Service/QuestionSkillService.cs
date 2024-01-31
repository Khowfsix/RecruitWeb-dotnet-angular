using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class QuestionSkillService : IQuestionSkillService
    {
        private readonly IQuestionSkillRepository _questionSkillRepository;
        private readonly IMapper _mapper;

        public QuestionSkillService(IQuestionSkillRepository questionSkillRepository, IMapper mapper)
        {
            _questionSkillRepository = questionSkillRepository;
            _mapper = mapper;
        }

        public async Task<QuestionSkillModel> AddQuestionSkill(QuestionSkillModel questionSkill)
        {
            var entity = _mapper.Map<QuestionSkill>(questionSkill);
            var response = await _questionSkillRepository.AddQuestionSkill(entity);
            return _mapper.Map<QuestionSkillModel>(response);
        }

        public async Task<List<QuestionSkillModel>> GetAllQuestionSkills()
        {
            var entities = await _questionSkillRepository.GetAllQuestionSkills();
            List<QuestionSkillModel> models = new List<QuestionSkillModel>();
            foreach (var item in entities)
            {
                models.Add(_mapper.Map<QuestionSkillModel>(item));
            }
            return models;
        }

        public async Task<bool> RemoveQuestionSkill(Guid id)
        {
            return await _questionSkillRepository.RemoveQuestionSkill(id);
        }

        public async Task<bool> UpdateQuestionSkill(QuestionSkillModel questionSkill, Guid id)
        {
            var entity = _mapper.Map<QuestionSkill>(questionSkill);
            return await _questionSkillRepository.UpdateQuestionSkill(entity, id);
        }
    }
}