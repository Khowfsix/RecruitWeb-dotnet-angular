using Service.Models;

namespace Service.Interfaces
{
    public interface ICategoryPositionService
    {
        Task<IEnumerable<CategoryPositionModel>> GetAllCategoryPositions(bool isAdmin);
        Task<CategoryPositionModel> CreateCategoryPosition(CategoryPositionModel request);
        Task<bool> UpdateCategoryPosition(CategoryPositionModel request, Guid id);
    }
}