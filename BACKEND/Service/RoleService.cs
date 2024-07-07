using AutoMapper;
using Data.CustomModel.Application;
using Data.Entities;
using Data.Enums;
using Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(
            IRoleRepository roleRepository,
            IMapper mapper
        )
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleModel>> GetAllRoles()
        {
            var data = await _roleRepository.GetAllRoles();
            if (!data.IsNullOrEmpty())
            {
                List<RoleModel> listData = _mapper.Map<List<RoleModel>>(data);
                return listData;
            }
            return null!;
        }

        public async Task<RoleModel?> GetRoleById(string roleId)
        {
            var entityData = await _roleRepository.GetRoleById(roleId);
            if (entityData != null)
            {
                var data = _mapper.Map<RoleModel>(entityData);
                return data;
            }
            return null!;
        }
     
        public async Task<RoleModel> SaveRole(RoleModel roleModel)
        {
            var data = _mapper.Map<IdentityRole>(roleModel); 
            var response = await _roleRepository.SaveRole(data);
            return _mapper.Map<RoleModel>(roleModel);
        }

        public async Task<bool> UpdateRole(RoleModel roleModel, string roleId)
        {
            var data = _mapper.Map<IdentityRole>(roleModel);
            return await _roleRepository.UpdateRole(data, roleId);
        }
    }
}