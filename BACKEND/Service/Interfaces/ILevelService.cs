using Service.Models;

namespace Service.Interfaces
{
    public interface ILevelService
    {
        Task<IEnumerable<LevelModel>> GetAllLevels(bool isAdmin);
        Task<LevelModel> CreateLevel(LevelModel request);
    }
}