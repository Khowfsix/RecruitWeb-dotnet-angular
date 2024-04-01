namespace Service.Interfaces;

using Service.Models;

public interface IRecruiterService
{
    Task<IEnumerable<RecruiterModel>> GetAllRecruiter();

    Task<RecruiterModel?> GetRecruiterById(Guid id);

    Task<RecruiterModel> SaveRecruiter(RecruiterModel viewModel);

    Task<bool> UpdateRecruiter(RecruiterModel recruiterModel, Guid recruiterModelId);

    Task<bool> DeleteRecruiter(Guid recruiterModelId);

    Task<RecruiterModel> GetRecruiterByUserId(string userId);
}