using AutoMapper;
using Data.Interfaces;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class BlacklistService : IBlacklistService
    {
        private readonly IBlacklistRepository _blacklistRepository;
        private readonly IMapper _mapper;

        public BlacklistService(IBlacklistRepository blacklistRepository, IMapper mapper)
        {
            _blacklistRepository = blacklistRepository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteBlackList(Guid requestId)
        {
            return await _blacklistRepository.DeleteBlackList(requestId);
        }

        public async Task<IEnumerable<BlacklistModel>> GetAllBlackLists()
        {
            var data = await _blacklistRepository.GetAllBlackLists();
            return data.Select(item => _mapper.Map<BlacklistModel>(item)).ToList();
        }

        public async Task<BlacklistModel> SaveBlackList(BlacklistModel request)
        {
            var data = _mapper.Map<BlacklistModel>(request);
            var response = await _blacklistRepository.SaveBlackList(data);

            return _mapper.Map<BlacklistModel>(response);
        }

        public async Task<bool> UpdateBlackList(BlacklistModel request, Guid requestId)
        {
            var data = _mapper.Map<BlacklistModel>(request);
            return await _blacklistRepository.UpdateBlackList(data, requestId);
        }
    }
}