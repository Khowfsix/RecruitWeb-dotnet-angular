using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class CvHasSkillService : ICvHasSkillService
    {
        private readonly ICvHasSkillrepository _cvHasSkillrepository;
        private readonly IMapper _mapper;

        public CvHasSkillService(ICvHasSkillrepository cvHasSkillrepository, IMapper mapper)
        {
            _cvHasSkillrepository = cvHasSkillrepository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteCvHasSkillService(Guid requestId)
        {
            return await _cvHasSkillrepository.DeleteCvHasSkillService(requestId);
        }

        public async Task<IEnumerable<CvHasSkillModel>> GetAllByCvId(Guid? cvId)
        {
            var data = await _cvHasSkillrepository.GetAllByCvId(cvId);
            if (!data.IsNullOrEmpty())
            {
                List<CvHasSkillModel> cvHasSkillModels = _mapper.Map<List<CvHasSkillModel>>(data);
                return cvHasSkillModels;
            }
            return null!;
        }

        public async Task<IEnumerable<CvHasSkillModel>> GetAllCvHasSkillService(string? request)
        {
            var data = await _cvHasSkillrepository.GetAllCvHasSkillService(request);
            if (!data.IsNullOrEmpty())
            {
                List<CvHasSkillModel> cvHasSkillModels = _mapper.Map<List<CvHasSkillModel>>(data);
                return cvHasSkillModels;
            }
            return null!;
        }

        public async Task<CvHasSkillModel> SaveCvHasSkillService(CvHasSkillModel request)
        {
            var data = _mapper.Map<CvHasSkill>(request);
            var response = await _cvHasSkillrepository.SaveCvHasSkillService(data);

            return _mapper.Map<CvHasSkillModel>(response);
        }

        public async Task<bool> UpdateCvHasSkillService(CvHasSkillModel request, Guid requestId)
        {
            var data = _mapper.Map<CvHasSkill>(request);
            return await _cvHasSkillrepository.UpdateCvHasSkillService(data, requestId);
        }
    }
}