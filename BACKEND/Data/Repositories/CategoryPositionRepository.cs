using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CategoryPositionRepository : Repository<CategoryPosition>, ICategoryPositionRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryPositionRepository(RecruitmentWebContext context,
            IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryPosition> AddCategoryPosition(CategoryPosition categoryPosition)
        {
            categoryPosition.CategoryPositionId = Guid.NewGuid();

            Entities.Add(categoryPosition);
            _unitOfWork.SaveChanges();

            return await Task.FromResult(categoryPosition);
        }
        public async Task<IEnumerable<CategoryPosition>> GetAllCategoryPositions()
        {
            /*------------------------------*/
            // Finds all of categoryPosition entities asynchronously in db.
            // Returns a list of it with the related entities.
            /*------------------------------*/
            var categoryPositionListWithName = await Entities
                .Include(o => o.Positions)
                .ToListAsync();

            return categoryPositionListWithName;
        }

        public async Task<CategoryPosition?> GetCategoryPositionById(Guid id)
        {
            /*------------------------------*/
            // Finds the first categoryPosition entity that has the id asynchronously in db.
            // Returns it with the related entities if found. Otherwise, return null
            /*------------------------------*/
            var categoryPosition = await Entities
                .Where(p => p.CategoryPositionId == id)
                .Include(o => o.Positions)
                .FirstOrDefaultAsync();

            /*------------------------------*/
            // Returns mapped model of the found categoryPosition. If categoryPosition is not found, return null.
            /*------------------------------*/
            return categoryPosition is not null ? categoryPosition : null;
        }

        //public async Task<bool> RemovePosition(Guid categoryPositionId)
        //{
        //    try
        //    {
        //        /*------------------------------*/
        //        // Finds asynchronously and removes entity with matched id in db.
        //        var categoryPosition = await Entities.FindAsync(categoryPositionId);

        //        if (categoryPosition == null)
        //        {
        //            return await Task.FromResult(false);
        //            //throw new ArgumentNullException(nameof(categoryPosition));
        //        }

        //        categoryPosition.IsDeleted = true;
        //        Entities.Update(categoryPosition);

        //        _unitOfWork.SaveChanges();
        //        return await Task.FromResult(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public async Task<bool> UpdateCategoryPosition(CategoryPosition categoryPosition, Guid categoryPositionId)
        {
            /*------------------------------*/
            // If id is not found in db, return false. Else, update in db and return true.
            if (await Entities.AnyAsync(l => l.CategoryPositionId.Equals(categoryPositionId)) is false)
                return await Task.FromResult(false);

            Entities.Update(categoryPosition);
            _unitOfWork.SaveChanges();

            return await Task.FromResult(true);
        }
    }
}