using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class SecurityQuestionService : ISecurityQuestionService
    {
        private readonly ISecurityQuestionRepository _securityQuestionRepository;
        private readonly IMapper _mapper;

        public SecurityQuestionService(ISecurityQuestionRepository securityQuestionRepository, IMapper mapper)
        {
            _securityQuestionRepository = securityQuestionRepository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteSecurityQuestion(Guid requestId)
        {
            return await _securityQuestionRepository.RemoveSecurityQuestion(requestId);
        }

        public async Task<IEnumerable<SecurityQuestionModel>> GetAllSecurityQuestion()
        {
            var modelDatas = await _securityQuestionRepository.GetSecurityQuestion();
            List<SecurityQuestionModel> list = new List<SecurityQuestionModel>();
            foreach (var item in modelDatas)
            {
                list.Add(_mapper.Map<SecurityQuestionModel>(item));
            }
            return list;
        }

        public async Task<SecurityQuestionModel> SaveSecurityQuestion(SecurityQuestionModel request)
        {
            var entity = _mapper.Map<SecurityQuestion>(request);
            var response = await _securityQuestionRepository.AddSecurityQuestion(entity);
            return _mapper.Map<SecurityQuestionModel>(response);
        }

        public Task<bool> UpdateSecurityQuestion(SecurityQuestionModel request, Guid requestId)
        {
            var entity = _mapper.Map<SecurityQuestion>(request);
            return _securityQuestionRepository.UpdateSecurityQuestion(entity, requestId);
        }
    }
}