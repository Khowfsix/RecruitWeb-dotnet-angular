using Service.Models;

namespace Service.Interfaces
{
    public interface IEducationService
    {
        Task<IEnumerable<EducationModel>> GetAllEducations();
    }
}