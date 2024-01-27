using Data.Entities;
using Data.Models;
using Data.ViewModels.Requirement;

namespace Data.Interfaces
{
    public interface IRequirementRepository : IRepository<Requirement>
    {
        Task<IEnumerable<RequirementModel>> GetAllRequirement();
        Task<RequirementModel> SaveRequirement(RequirementModel request);
        Task<bool> UpdateRequirement(RequirementModel request, Guid requestId);
        Task<bool> DeleteRequirement(Guid requestId);
        Task<List<RequirementModel>> GetRequirementsByPositionId(Guid positionId);
    }
}
