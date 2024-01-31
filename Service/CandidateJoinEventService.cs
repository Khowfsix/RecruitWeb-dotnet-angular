using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class CandidateJoinEventService : ICandidateJoinEventService
    {
        private readonly ICandidateJoinEventRepository _candidateJoinEventRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public CandidateJoinEventService(ICandidateJoinEventRepository candidateJoinEventRepository,
            IEventRepository eventRepository,
            IMapper mapper)
        {
            _candidateJoinEventRepository = candidateJoinEventRepository;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteCandidateJoinEvent(Guid requestId)
        {
            return await _candidateJoinEventRepository.DeleteCandidateJoinEvent(requestId);
        }

        public async Task<IEnumerable<CandidateJoinEventModel>> GetAllCandidateJoinEvents()
        {
            var data = await _candidateJoinEventRepository.GetAllCandidateJoinEvents();
            if (!data.IsNullOrEmpty())
            {
                List<CandidateJoinEventModel> listData = _mapper.Map<List<CandidateJoinEventModel>>(data);
                return listData;
            }
            return null!;
        }

        public async Task<CandidateJoinEventModel> SaveCandidateJoinEvent(CandidateJoinEventModel request)
        {
            var data = _mapper.Map<CandidateJoinEvent>(request);
            var response = await _candidateJoinEventRepository.SaveCandidateJoinEvent(data);

            return _mapper.Map<CandidateJoinEventModel>(response);
        }

        public async Task<bool> UpdateCandidateJoinEvent(CandidateJoinEventModel request, Guid requestId)
        {
            var data = _mapper.Map<CandidateJoinEvent>(request);
            return await _candidateJoinEventRepository.UpdateCandidateJoinEvent(data, requestId);
        }

        public async Task<IEnumerable<CandidateJoinEventModel>> JoinEventDetail(Guid id)
        {
            var data = await _candidateJoinEventRepository.JoinEventDetail(id);
            var result = _mapper.Map<List<CandidateJoinEventModel>>(data);
            return result;
        }

        public async Task<IEnumerable<CandidateJoinEventModel>> GetCandidatesSortedByJoinEventCount()
        {
            var candidateJoinEvents = await _candidateJoinEventRepository.GetAllCandidateJoinEvents();

            var candidateJoinEventModels = candidateJoinEvents
                .GroupBy(cje => cje.CandidateId)
                .Select(group => new CandidateJoinEventModel
                {
                    CandidateId = group.Key,
                    JoinEventCount = group.Count(),
                })
                .OrderBy(cjeModel => cjeModel.CandidateId) // Sorting by CandidateId as required.
                .ToList();

            return candidateJoinEventModels;
        }
    }
}