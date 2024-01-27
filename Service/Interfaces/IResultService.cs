using Data.Models;
using Data.ViewModels.Result;

namespace Service.Interfaces
{
    public interface IResultService
    {
        Task<IEnumerable<ResultViewModel>> GetAllResult();
        Task<ResultViewModel> SaveResult(ResultAddModel viewModel);
        Task<bool> UpdateResult(ResultUpdateModel reportModel, Guid reportModelId);
        Task<bool> DeleteResult(Guid reportModelId);
    }
}
