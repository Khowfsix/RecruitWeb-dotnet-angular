using Data.Models;
using Data.ViewModels.Requirement;

namespace Service.Interfaces
{
    public interface IRequirementService
    {
        Task<IEnumerable<RequirementViewModel>> GetAllRequirement();
        Task<RequirementViewModel> SaveRequirement(RequirementAddModel viewModel);
        Task<bool> UpdateRequirement(RequirementUpdateModel reportModel, Guid reportModelId);
        Task<bool> DeleteRequirement(Guid reportModelId);
    }
}
