using Data.Entities;

namespace Data.Interfaces
{
    public interface IEducationRepository : IRepository<Education>
    {
        Task<IEnumerable<Education>> GetAllEducations();
    }
}