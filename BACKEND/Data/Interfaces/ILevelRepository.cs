using Data.Entities;

namespace Data.Interfaces
{
    public interface ILevelRepository : IRepository<Level>
    {
        Task<IEnumerable<Level>> GetAllLevels();

        Task<Level?> GetLevelById(Guid id);

        Task<Level> AddLevel(Level level);

        Task<bool> UpdateLevel(Level level, Guid levelId);

        //Task<bool> RemoveLevel(Guid levelId);
    }
}