using Data.Entities;

namespace Data.Interfaces
{
    public interface ICategoryPositionRepository : IRepository<CategoryPosition>
    {
        Task<IEnumerable<CategoryPosition>> GetAllCategoryPositions();

        Task<CategoryPosition?> GetCategoryPositionById(Guid id);

        Task<CategoryPosition> AddCategoryPosition(CategoryPosition categoryPosition);

        Task<bool> UpdateCategoryPosition(CategoryPosition categoryPosition, Guid categoryPositionId);

        //Task<bool> RemoveCategoryPosition(Guid categoryPositionId);
    }
}