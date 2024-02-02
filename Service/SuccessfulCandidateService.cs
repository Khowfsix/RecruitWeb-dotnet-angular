using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class SuccessfulCandidateService : ISuccessfulCandidateService
    {
        private readonly ISuccessfulCadidateRepository _successfulCadidateRepository;
        private readonly IMapper _mapper;

        public SuccessfulCandidateService(ISuccessfulCadidateRepository successfulCadidateRepository, IMapper mapper)
        {
            _successfulCadidateRepository = successfulCadidateRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SuccessfulCadidateModel>> GetAllSuccessfulCadidates(string? request)
        {
            var entities = await _successfulCadidateRepository.GetAllSuccessfulCadidates(request);
            if (entities != null)
            {
                List<SuccessfulCadidateModel> list = new List<SuccessfulCadidateModel>();
                foreach (var item in entities)
                {
                    list.Add(_mapper.Map<SuccessfulCadidateModel>(item));
                }
                return list;
            }
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<SuccessfulCadidateModel> SaveSuccessfulCadidate(SuccessfulCadidateModel request)
        {
            var entity = _mapper.Map<SuccessfulCadidate>(request);
            var response = await _successfulCadidateRepository.SaveSuccessfulCadidate(entity);
            return _mapper.Map<SuccessfulCadidateModel>(response);
        }

        public async Task<bool> UpdateSuccessfulCadidate(SuccessfulCadidateModel request, Guid requestId)
        {
            var entity = _mapper.Map<SuccessfulCadidate>(request);
            return await _successfulCadidateRepository.UpdateSuccessfulCadidate(entity, requestId);
        }

        public async Task<bool> DeleteSuccessfulCadidate(Guid requestId)
        {
            return await _successfulCadidateRepository.DeleteSuccessfulCadidate(requestId);
        }
    }
}