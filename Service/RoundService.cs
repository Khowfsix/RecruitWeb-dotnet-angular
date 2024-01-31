using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class RoundService : IRoundService
    {
        private readonly IRoundRepository _roundRepository;
        private readonly IMapper _mapper;

        public RoundService(IRoundRepository roundRepository, IMapper mapper)
        {
            _roundRepository = roundRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoundModel>> GetAllRounds(string? interviewId)
        {
            var entities = await _roundRepository.GetAllRounds(interviewId);
            if (entities != null)
            {
                List<RoundModel> models = new List<RoundModel>();
                foreach (var item in entities)
                {
                    models.Add(_mapper.Map<RoundModel>(item));
                }
                return models;
            }
            return null;
        }

        public async Task<RoundModel> SaveRound(RoundModel roundModel)
        {
            var entity = _mapper.Map<Round>(roundModel);
            var response = await _roundRepository.SaveRound(entity);
            return _mapper.Map<RoundModel>(response);
        }

        public async Task<bool> UpdateRound(RoundModel roundModel, Guid roundId)
        {
            var entity = _mapper.Map<Round>(roundModel);
            return await _roundRepository.UpdateRound(entity, roundId);
        }

        public async Task<bool> DeleteRound(Guid roundId)
        {
            return await _roundRepository.DeleteRound(roundId);
        }

        public async Task<IEnumerable<RoundModel>> GetRoundsOfInterview(Guid interviewId)
        {
            var entities = await _roundRepository.GetAllRounds(null);
            if (entities != null)
            {
                List<RoundModel> models = new List<RoundModel>();
                foreach (var item in entities)
                {
                    if (item.InterviewId.Equals(interviewId))
                    {
                        models.Add(_mapper.Map<RoundModel>(item));
                    }
                }
                return models;
            }
            return null;
        }
    }
}