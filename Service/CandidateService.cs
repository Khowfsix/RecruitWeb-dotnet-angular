using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;

        public CandidateService(ICandidateRepository candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteCandidate(Guid requestId)
        {
            return await _candidateRepository.DeleteCandidate(requestId);
        }

        public async Task<IEnumerable<CandidateModel>> GetAllCandidates()
        {
            var data = await _candidateRepository.GetAllCandidates();
            if (!data.IsNullOrEmpty())
                return _mapper.Map<IEnumerable<CandidateModel>>(data);
            return null!;
        }

        public async Task<CandidateModel> SaveCandidate(CandidateModel request)
        {
            var data = _mapper.Map<Candidate>(request);
            var response = await _candidateRepository.SaveCandidate(data);

            return _mapper.Map<CandidateModel>(response);
        }

        public async Task<bool> UpdateCandidate(CandidateModel request, Guid requestId)
        {
            var data = _mapper.Map<Candidate>(request);
            return await _candidateRepository.UpdateCandidate(data, requestId);
        }

        public async Task<ProfileModel?> GetProfile(Guid candidateId)
        {
            var data = await _candidateRepository.GetProfile(candidateId);
            return _mapper.Map<ProfileModel>(data);
        }

        public async Task<CandidateModel> FindById(Guid id)
        {
            var model = await _candidateRepository.FindById(id);
            var viewmodel = _mapper.Map<CandidateModel>(model);
            return viewmodel;
        }

        public async Task<CandidateModel> GetCandidateByUserId(string id)
        {
            var candidateModel = await _candidateRepository.GetCandidateByUserId(id);
            var candidateVM = _mapper.Map<CandidateModel>(candidateModel);
            if (candidateVM != null)
                return candidateVM;
            else
            {
                return null!;
            }
        }
    }
}