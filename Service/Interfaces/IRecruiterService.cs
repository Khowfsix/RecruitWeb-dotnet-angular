
using Api.ViewModels.Recruiter;

namespace Service.Interfaces;

public interface IRecruiterService
{
    Task<IEnumerable<RecruiterViewModel>> GetAllRecruiter();
    Task<RecruiterViewModel?> GetRecruiterById(Guid id);
    Task<RecruiterViewModel> SaveRecruiter(RecruiterAddModel viewModel);
    Task<bool> UpdateRecruiter(RecruiterUpdateModel recruiterModel, Guid recruiterModelId);
    Task<bool> DeleteRecruiter(Guid recruiterModelId);
}