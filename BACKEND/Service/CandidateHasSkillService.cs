using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class CandidateHasSkillService : ICandidateHasSkillService
    {
        private readonly ICandidateHasSkillrepository _candidateHasSkillrepository;
        private readonly IMapper _mapper;

        public CandidateHasSkillService(ICandidateHasSkillrepository candidateHasSkillrepository, IMapper mapper)
        {
            _candidateHasSkillrepository = candidateHasSkillrepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CandidateHasSkillModel>> GetAllByCandidateId(Guid? candidateId)
        {
            var data = await _candidateHasSkillrepository.GetAllByCandidateId(candidateId);
            if (!data.IsNullOrEmpty())
            {
                List<CandidateHasSkillModel> candidateHasSkillModels = _mapper.Map<List<CandidateHasSkillModel>>(data);
                return candidateHasSkillModels;
            }
            return null!;
        }
    }
}