

namespace Service.Interfaces
{
    public interface IApplicationSuggestionService
    {
        Task<List<ApplicationModel>> GetSuggestion(Guid positionId);
    }
}