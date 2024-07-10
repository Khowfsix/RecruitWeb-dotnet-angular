using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using Service.Models;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<WebUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(
            UserManager<WebUser> userManager,
            IMapper mapper
        )
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            var data = await _userManager.Users.ToListAsync();
            if (!data.IsNullOrEmpty())
            {
                var listData = _mapper.Map<List<UserModel>>(data);
                return listData;
            }
            return null!;
        }
    }
}