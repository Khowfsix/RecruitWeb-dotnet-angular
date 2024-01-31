using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class RequirementService : IRequirementService
    {
        private readonly IRequirementRepository _reportRepository;
        private readonly IMapper _mapper;

        public RequirementService(IRequirementRepository reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public async Task<RequirementModel> SaveRequirement(RequirementModel reportModel)
        {
            var entity = _mapper.Map<Requirement>(reportModel);
            var response = await _reportRepository.SaveRequirement(entity);
            return _mapper.Map<RequirementModel>(response);
        }

        public async Task<bool> DeleteRequirement(Guid reportModelId)
        {
            return await _reportRepository.DeleteRequirement(reportModelId);
        }

        public async Task<IEnumerable<RequirementModel>> GetAllRequirement()
        {
            var entities = await _reportRepository.GetAllRequirement();
            List<RequirementModel> models = new List<RequirementModel>();
            foreach (var item in entities)
            {
                models.Add(_mapper.Map<RequirementModel>(item));
            }
            return models;
        }

        public async Task<bool> UpdateRequirement(RequirementModel reportModel, Guid reportModelId)
        {
            var entity = _mapper.Map<Requirement>(reportModel);
            return await _reportRepository.UpdateRequirement(entity, reportModelId);
        }
    }
}