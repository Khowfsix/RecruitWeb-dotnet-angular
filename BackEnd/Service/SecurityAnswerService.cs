using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Service.Interfaces;

namespace Service
{
    public class SecurityAnswerService : ISecurityAnswerService
    {
        private readonly ISecurityAnswerRepository _reportRepository;
        private readonly IMapper _mapper;

        public SecurityAnswerService(ISecurityAnswerRepository reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public async Task<SecurityAnswerModel> SaveSecurityAnswer(SecurityAnswerModel reportModel)
        {
            var entity = _mapper.Map<SecurityAnswer>(reportModel);
            var response = await _reportRepository.SaveSecurityAnswer(entity);
            return _mapper.Map<SecurityAnswerModel>(response);
        }

        public async Task<bool> DeleteSecurityAnswer(Guid reportModelId)
        {
            return await _reportRepository.DeleteSecurityAnswer(reportModelId);
        }

        public async Task<IEnumerable<SecurityAnswerModel>> GetAllSecurityAnswers()
        {
            var modelDatas = await _reportRepository.GetAllSecurityAnswers();
            List<SecurityAnswerModel> list = new List<SecurityAnswerModel>();
            foreach (var item in modelDatas)
            {
                list.Add(_mapper.Map<SecurityAnswerModel>(item));
            }
            return list;
        }

        public async Task<bool> UpdateSecurityAnswer(SecurityAnswerModel reportModel, Guid reportModelId)
        {
            var entity = _mapper.Map<SecurityAnswer>(reportModel);
            return await _reportRepository.UpdateSecurityAnswer(entity, reportModelId);
        }
    }
}