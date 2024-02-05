using Data.Entities;

namespace Data.Interfaces
{
    public interface IRequirementRepository : IRepository<Requirement>
    {
        Task<IEnumerable<Requirement>> GetAllRequirement();

        Task<Requirement> SaveRequirement(Requirement request);

        Task<bool> UpdateRequirement(Requirement request, Guid requestId);

        Task<bool> DeleteRequirement(Guid requestId);

        Task<List<Requirement>> GetRequirementsByPositionId(Guid positionId);
    }
}