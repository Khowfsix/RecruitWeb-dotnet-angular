using Data.Entities;

namespace Data.Interfaces
{
    public interface IWorkExperienceRepository : IRepository<WorkExperience>
    {
        Task<IEnumerable<WorkExperience>> GetAllWorkExperiences();
    }
}