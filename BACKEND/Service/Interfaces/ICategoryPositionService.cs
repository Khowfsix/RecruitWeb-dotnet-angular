using Service.Models;

namespace Service.Interfaces
{
    public interface ICategoryPositionService
    {
        Task<IEnumerable<CategoryPositionModel>> GetAllCategoryPositions();
    }
}