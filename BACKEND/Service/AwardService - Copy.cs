using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class AwardService : IAwardService
    {
        private readonly IAwardRepository _awardRepository;
        private readonly IMapper _mapper;

        public AwardService(IAwardRepository awardRepository, IMapper mapper)
        {
            _awardRepository = awardRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AwardModel>> GetAllAwards()
        {
            var data = await _awardRepository.GetAllAwards();
            var modelDatas = _mapper.Map<List<AwardModel>>(data);

            return modelDatas;
        }
    }
}