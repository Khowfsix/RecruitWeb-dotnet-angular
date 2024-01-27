using AutoMapper;
using Data.Interfaces;
using Data.Models;
using Data.ViewModels.BlackList;
using Service.Interfaces;

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

        public async Task<IEnumerable<BlacklistViewModel>> GetAllBlackLists()
        {
            var data = await _blacklistRepository.GetAllBlackLists();
            return data.Select(item => _mapper.Map<BlacklistViewModel>(item)).ToList();
        }

        public async Task<BlacklistViewModel> SaveBlackList(BlackListAddModel request)
        {
            var data = _mapper.Map<BlacklistModel>(request);
            var response = await _blacklistRepository.SaveBlackList(data);

            return _mapper.Map<BlacklistViewModel>(response);
        }

        public async Task<bool> UpdateBlackList(BlackListUpdateModel request, Guid requestId)
        {
            var data = _mapper.Map<BlacklistModel>(request);
            return await _blacklistRepository.UpdateBlackList(data, requestId);
        }
    }
}