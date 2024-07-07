using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class WorkExperienceService : IWorkExperienceService
    {
        private readonly IWorkExperienceRepository _workExperienceRepository;
        private readonly IMapper _mapper;

        public WorkExperienceService(IWorkExperienceRepository workExperienceRepository, IMapper mapper)
        {
            _workExperienceRepository = workExperienceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WorkExperienceModel>> GetAllWorkExperiences()
        {
            var data = await _workExperienceRepository.GetAllWorkExperiences();
            var modelDatas = _mapper.Map<List<WorkExperienceModel>>(data);

            return modelDatas;
        }
    }
}