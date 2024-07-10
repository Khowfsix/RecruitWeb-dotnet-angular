using Service.Models;

namespace Service.Interfaces
{
    public interface IWorkExperienceService
    {
        Task<IEnumerable<WorkExperienceModel>> GetAllWorkExperiences();
    }
}