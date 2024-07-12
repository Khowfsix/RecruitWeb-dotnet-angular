using AutoMapper;
using Data.Interfaces;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class QuestionLanguageService : IQuestionLanguageService
    {
        private readonly IQuestionLanguageRepository _questionLanguageRepository;
        private readonly IMapper _mapper;

        public QuestionLanguageService(IQuestionLanguageRepository questionLanguageRepository, IMapper mapper)
        {
            _questionLanguageRepository = questionLanguageRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionLanguageModel>> GetAllQuestionLanguages()
        {
            var data = await _questionLanguageRepository.GetAllQuestionLanguages();
            var modelDatas = _mapper.Map<List<QuestionLanguageModel>>(data);

            return modelDatas;
        }

        //public async Task<IEnumerable>
    }
}