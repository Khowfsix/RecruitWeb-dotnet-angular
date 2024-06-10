using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class LevelRepository : Repository<Level>, ILevelRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public LevelRepository(RecruitmentWebContext context,
            IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Level> AddLevel(Level level)
        {
            try
            {
                level.LevelId = Guid.NewGuid();

                Entities.Add(level);
                _unitOfWork.SaveChanges();

                return await Task.FromResult(level);
            }
            catch (Exception)
            {
                return null!;
            }
        }

        public async Task<IEnumerable<Level>> GetAllLevels()
        {
            /*------------------------------*/
            // Finds all of level entities asynchronously in db.
            // Returns a list of it with the related entities.
            /*------------------------------*/
            var levelListWithName = await Entities
                .ToListAsync();

            return levelListWithName;
        }

        public async Task<Level?> GetLevelById(Guid id)
        {
            /*------------------------------*/
            // Finds the first level entity that has the id asynchronously in db.
            // Returns it with the related entities if found. Otherwise, return null
            /*------------------------------*/
            var level = await Entities
                .Where(p => p.LevelId == id)
                .Include(o => o.Positions)
                .FirstOrDefaultAsync();

            /*------------------------------*/
            // Returns mapped model of the found level. If level is not found, return null.
            /*------------------------------*/
            return level is not null ? level : null;
        }

        //public async Task<bool> RemovePosition(Guid levelId)
        //{
        //    try
        //    {
        //        /*------------------------------*/
        //        // Finds asynchronously and removes entity with matched id in db.
        //        var level = await Entities.FindAsync(levelId);

        //        if (level == null)
        //        {
        //            return await Task.FromResult(false);
        //            //throw new ArgumentNullException(nameof(level));
        //        }

        //        level.IsDeleted = true;
        //        Entities.Update(level);

        //        _unitOfWork.SaveChanges();
        //        return await Task.FromResult(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public async Task<bool> UpdateLevel(Level level, Guid levelId)
        {
            /*------------------------------*/
            // If id is not found in db, return false. Else, update in db and return true.
            if (await Entities.AnyAsync(l => l.LevelId.Equals(levelId)) is false)
                return await Task.FromResult(false);

            Entities.Update(level);
            _unitOfWork.SaveChanges();

            return await Task.FromResult(true);
        }
    }
}