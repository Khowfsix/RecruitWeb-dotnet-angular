using Data.Entities;
using Service.Models;

namespace Service.Interfaces
{
    public interface IPersonalProjectService
    {
        Task<IEnumerable<PersonalProjectModel>> GetAllPersonalProjects();
    }
}