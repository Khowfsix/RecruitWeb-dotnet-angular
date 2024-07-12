using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryQuestionRepository _categoryQuestionRepository;

        public QuestionService(IQuestionRepository questionRepository,
            IMapper mapper,
            ICategoryQuestionRepository categoryQuestionRepository)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
            _categoryQuestionRepository = categoryQuestionRepository;
        }

        public async Task<QuestionModel> AddQuestion(QuestionModel model)
        {
            var entity = _mapper.Map<Question>(model);
            var response = await _questionRepository.AddQuestion(entity);
            return _mapper.Map<QuestionModel>(response);
        }

        public async IAsyncEnumerable<Task> AddQuestion(IAsyncEnumerable<QuestionModel> models)
        {
            await foreach (QuestionModel model in models)
            {
                var entity = _mapper.Map<Question>(model);
                yield return _questionRepository.AddQuestion(entity);
            }
        }

        public async Task<List<QuestionModel>> GetAllLanguageQuestions()
        {
            try
            {
                string cateQuestion = "Language skill";
                Guid id = await _categoryQuestionRepository.GetIdCategoryQuestion(cateQuestion);
                var entityDatas = await _questionRepository.GetListQuestions(id);
                List<QuestionModel> models = new();
                foreach (var item in entityDatas)
                {
                    models.Add(_mapper.Map<QuestionModel>(item));
                }
                return models;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<QuestionModel>> GetAllSoftSkillQuestions()
        {
            try
            {
                String cateQuestion = "Soft skill";
                Guid id = await _categoryQuestionRepository.GetIdCategoryQuestion(cateQuestion);
                var entities = await _questionRepository.GetListQuestions(id);
                List<QuestionModel> models = new();
                foreach (var item in entities)
                {
                    models.Add(_mapper.Map<QuestionModel>(item));
                }
                return models;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<QuestionModel>> GetAllTechnologyQuestions()
        {
            try
            {
                String cateQuestion = "Expertise";
                Guid id = await _categoryQuestionRepository.GetIdCategoryQuestion(cateQuestion);
                var entities = await _questionRepository.GetListQuestions(id);
                List<QuestionModel> models = new();
                foreach (var item in entities)
                {
                    models.Add(_mapper.Map<QuestionModel>(item));
                }
                return models;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public IQuestionRepository Get_questionRepository()
        {
            return _questionRepository;
        }

        public async Task<List<QuestionModel>> GetAllQuestions(string? query, Guid? questionId)
        {
            var models = new List<QuestionModel>();
            if (questionId != null)
            {
                var quest = await _questionRepository.GetQuestion(questionId);
                var response = _mapper.Map<QuestionModel>(quest);
                //var list = new List<QuestionModel>();
                models.Add(response);
                return models;
            }
            else if (query != null)
            {
                var modelDatas = new List<QuestionModel>();
                var quest = await _questionRepository.GetQuestionsByName(query);
                if (query != null || questionId != null)
                {
                    //List<QuestionModel> list = new List<QuestionModel>();
                    foreach (var item in quest)
                    {
                        models.Add(_mapper.Map<QuestionModel>(item));
                    }
                    return models;
                }
            }
            else
            {
                var modelDatas = await _questionRepository.GetAllQuestions();
                //List<QuestionModel> list = new List<QuestionModel>();
                foreach (var item in modelDatas)
                {
                    models.Add(_mapper.Map<QuestionModel>(item));
                }
                return models;
            }
            return models;
        }

        public async Task<QuestionModel> GetQuestion(Guid id)
        {
            var data = await _questionRepository.GetQuestion(id);
            return _mapper.Map<QuestionModel>(data);
        }

        public async Task<bool> RemoveQuestion(Guid id)
        {
            return await _questionRepository.RemoveQuestion(id);
        }

        public async Task<bool> UpdateQuestion(QuestionModel model, Guid id)
        {
            var entity = _mapper.Map<Question>(model);
            return await _questionRepository.UpdateQuestion(entity, id);
        }
    }
}