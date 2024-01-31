using Service.Models;

namespace Service.Interfaces
{
    public interface IRequirementService
    {
        Task<IEnumerable<RequirementModel>> GetAllRequirement();
        Task<RequirementModel> SaveRequirement(RequirementModel viewModel);
        Task<bool> UpdateRequirement(RequirementModel reportModel, Guid reportModelId);
        Task<bool> DeleteRequirement(Guid reportModelId);
    }
}
