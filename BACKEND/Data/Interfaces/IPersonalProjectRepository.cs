using Data.Entities;

namespace Data.Interfaces
{
    public interface IPersonalProjectRepository : IRepository<PersonalProject>
    {
        Task<IEnumerable<PersonalProject>> GetAllPersonalProjects();
    }
}