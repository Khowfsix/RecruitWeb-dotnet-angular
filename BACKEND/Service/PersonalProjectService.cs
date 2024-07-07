using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class PersonalProjectService : IPersonalProjectService
    {
        private readonly IPersonalProjectRepository _personalProjectRepository;
        private readonly IMapper _mapper;

        public PersonalProjectService(IPersonalProjectRepository personalProjectRepository, IMapper mapper)
        {
            _personalProjectRepository = personalProjectRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonalProjectModel>> GetAllPersonalProjects()
        {
            var data = await _personalProjectRepository.GetAllPersonalProjects();
            var modelDatas = _mapper.Map<List<PersonalProjectModel>>(data);

            return modelDatas;
        }
    }
}