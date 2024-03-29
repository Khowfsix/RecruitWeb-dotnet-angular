using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository = null!;
        private readonly IMapper _mapper;

        public LanguageService(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<LanguageModel> AddLanguage(LanguageModel createdLanguage)
        {
            var entityData = _mapper.Map<Language>(createdLanguage);
            var response = await _languageRepository.AddLanguage(entityData);
            return _mapper.Map<LanguageModel>(response);
        }

        public async Task<bool> RemoveLanguage(Guid id)
        {
            return await _languageRepository.RemoveLanguage(id);
        }

        public async Task<List<LanguageModel>> GetAllLanguages(bool isAdmin)
        {
            var entityDatas = await _languageRepository.GetAllLanguages();
            var listModelDatas = _mapper.Map<List<LanguageModel>>(entityDatas);
            if (!isAdmin)
                return listModelDatas.Where(o => o.IsDeleted == false).ToList();
            return listModelDatas;
        }

        public async Task<LanguageModel> GetLanguage(Guid id)
        {
            var entityData = await _languageRepository.GetLanguage(id);
            var modelDatas = _mapper.Map<LanguageModel>(entityData);
            return modelDatas;
        }

        public async Task<List<LanguageModel>> GetLanguage(bool isAdmin, string name)
        {
            var entityDatas = await _languageRepository.GetLanguage(name);
            var modelDatas = _mapper.Map<List<LanguageModel>>(entityDatas);
            if (!isAdmin)
                return modelDatas.Where(o => !o.IsDeleted).ToList();
            return modelDatas;
        }

        public async Task<bool> UpdateLanguage(LanguageModel createdLanguage, Guid id)
        {
            var data = _mapper.Map<Language>(createdLanguage);
            return await _languageRepository.UpdateLanguage(data, id);
        }
    }
}