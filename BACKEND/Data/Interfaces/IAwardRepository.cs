using Data.Entities;

namespace Data.Interfaces
{
    public interface IAwardRepository : IRepository<Award>
    {
        Task<IEnumerable<Award>> GetAllAwards();
    }
}