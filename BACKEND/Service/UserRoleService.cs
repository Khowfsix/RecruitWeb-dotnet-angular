using AutoMapper;
using Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;

        public UserRoleService(
            IUserRoleRepository userRoleRepository,
            IMapper mapper
        )
        {
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserRoleModel>> GetAllUserRoles()
        {
            var data = await _userRoleRepository.GetAllUserRoles();
            if (!data.IsNullOrEmpty())
            {
                var listData = _mapper.Map<List<UserRoleModel>>(data);
                return listData;
            }
            return null!;
        }

        public async Task<UserRoleModel> SaveUserRole(UserRoleModel userRoleModel)
        {
            var data = _mapper.Map<IdentityUserRole<string>>(userRoleModel); 
            var response = await _userRoleRepository.SaveUserRole(data);
            return _mapper.Map<UserRoleModel>(response);
        }

        public async Task<bool> DeleteUserRole(UserRoleModel userRoleModel)
        {
            var userRole = _mapper.Map<IdentityUserRole<string>>(userRoleModel);
            return await _userRoleRepository.DeleteUserRole(userRole);
        }
    }
}