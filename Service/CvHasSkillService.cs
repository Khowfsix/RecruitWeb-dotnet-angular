using AutoMapper;
using Data.Interfaces;
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

        public async Task<IEnumerable<CvHasSkillModel>> GetAllCvHasSkillService(string? request)
        {
            var data = await _cvHasSkillrepository.GetAllCvHasSkillService(request);
            List<CvHasSkillModel> cvHasSkillModels = new List<CvHasSkillModel>();
            if (data != null)
            {
                foreach (var item in data)
                {
                    var obj = _mapper.Map<CvHasSkillModel>(item);
                    cvHasSkillModels.Add(obj);
                }
                return cvHasSkillModels;
            }
            return null;
        }

        public async Task<CvHasSkillModel> SaveCvHasSkillService(CvHasSkillModel request)
        {
            var data = _mapper.Map<CvHasSkillModel>(request);
            var response = await _cvHasSkillrepository.SaveCvHasSkillService(data);

            return _mapper.Map<CvHasSkillModel>(response);
        }

        public async Task<bool> UpdateCvHasSkillService(CvHasSkillModel request, Guid requestId)
        {
            var data = _mapper.Map<CvHasSkillModel>(request);
            return await _cvHasSkillrepository.UpdateCvHasSkillService(data, requestId);
        }
    }
}