using Service.Models;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllUsers();
    }
}