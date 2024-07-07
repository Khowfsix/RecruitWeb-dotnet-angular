using AutoMapper;
using Data.Interfaces;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;

        public EducationService(IEducationRepository educationRepository, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EducationModel>> GetAllEducations()
        {
            var data = await _educationRepository.GetAllEducations();
            var modelDatas = _mapper.Map<List<EducationModel>>(data);

            return modelDatas;
        }
    }
}