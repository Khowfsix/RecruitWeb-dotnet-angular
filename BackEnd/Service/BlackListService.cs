using AutoMapper;
using Data.Entities;
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

        public async Task<IEnumerable<BlacklistModel>> GetAllBlackLists(bool isAdmin)
        {
            var data = await _blacklistRepository.GetAllBlackLists();
            return isAdmin ? _mapper.Map<List<BlacklistModel>>(data) : _mapper.Map<List<BlacklistModel>>(data.Where(o => !o.IsDeleted));
        }

        public async Task<BlacklistModel> SaveBlackList(BlacklistModel request)
        {
            var data = _mapper.Map<BlackList>(request);
            var response = await _blacklistRepository.SaveBlackList(data);

            return _mapper.Map<BlacklistModel>(response);
        }

        public async Task<bool> UpdateBlackList(BlacklistModel request, Guid requestId)
        {
            var data = _mapper.Map<BlackList>(request);
            return await _blacklistRepository.UpdateBlackList(data, requestId);
        }
    }
}