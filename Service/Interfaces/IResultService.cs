using Service.Models;

namespace Service.Interfaces
{
    public interface IResultService
    {
        Task<IEnumerable<ResultModel>> GetAllResult();

        Task<ResultModel> SaveResult(ResultModel viewModel);

        Task<bool> UpdateResult(ResultModel reportModel, Guid reportModelId);

        Task<bool> DeleteResult(Guid reportModelId);
    }
}