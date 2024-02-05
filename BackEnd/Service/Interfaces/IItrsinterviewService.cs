using Service.Models;

namespace Service.Interfaces;

public interface IItrsinterviewService
{
    Task<IEnumerable<ItrsinterviewModel>> GetAllItrsinterview();

    Task<ItrsinterviewModel?> GetItrsinterviewById(Guid id);

    Task<ItrsinterviewModel?> SaveItrsinterview(ItrsinterviewModel viewModel, Guid interviewerId);

    Task<bool> UpdateItrsinterview(ItrsinterviewModel itrsinterviewModel, Guid itrsinterviewModelId, Guid interviewerId);

    Task<bool> DeleteItrsinterview(Guid itrsinterviewModelId);
}