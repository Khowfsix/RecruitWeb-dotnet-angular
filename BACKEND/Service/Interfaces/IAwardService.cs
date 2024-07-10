using Service.Models;

namespace Service.Interfaces
{
    public interface IAwardService
    {
        Task<IEnumerable<AwardModel>> GetAllAwards();
    }
}