using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public PositionRepository(RecruitmentWebContext context,
            IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Position> AddPosition(Position position)
        {
            position.PositionId = Guid.NewGuid();

            Entities.Add(position);
            _unitOfWork.SaveChanges();

            return await Task.FromResult(position);
        }
        public async Task<List<Position>> GetAllPositions()
        {
            /*------------------------------*/
            // Finds all of position entities asynchronously in db.
            // Returns a list of it with the related entities.
            /*------------------------------*/
            var positionListWithName = await Entities
                .Include(o => o.Requirements)
                .Include(o => o.Company)
                .Include(o => o.Language)
                .Include(o => o.Recruiter)
                .ToListAsync();

            return positionListWithName;
        }

        public async Task<List<Position>> GetAllPositionsByUserId(String userId)
        {
            /*------------------------------*/
            // Finds all of position entities asynchronously in db.
            // Returns a list of it with the related entities.
            /*------------------------------*/
            var positionListWithName = await Entities
                .Include(o => o.Requirements)
                .Include(o => o.Company)
                .Include(o => o.Language)
                .Include(o => o.Recruiter)
                .Where(o => o.Recruiter.UserId.Equals(userId))
                .ToListAsync();

            return positionListWithName;
        }

        public async Task<Position?> GetPositionById(Guid id)
        {
            /*------------------------------*/
            // Finds the first position entity that has the id asynchronously in db.
            // Returns it with the related entities if found. Otherwise, return null
            /*------------------------------*/
            var position = await Entities
                .Where(p => p.PositionId == id)
                .Include(o => o.Requirements)
                .Include(o => o.Company)
                .Include(o => o.Language)
                .Include(o => o.Recruiter)
                .FirstOrDefaultAsync();

            /*------------------------------*/
            // Returns mapped model of the found position. If position is not found, return null.
            /*------------------------------*/
            return position is not null ? position : null;
        }

        public async Task<List<Position>> GetPositionByName(string name)
        {
            /*------------------------------*/
            // Finds all of position entities that contain name parameter asynchronously in db.
            // Returns a list of it with the related entities if matched.
            /*------------------------------*/

            var positionList = await Entities
                .Where(p => p.PositionName!.ToLower()
                                          .Contains(name.ToLower().Trim()))
                .Include(o => o.Requirements)
                .Include(o => o.Company)
                .Include(o => o.Language)
                .Include(o => o.Recruiter)
                .ToListAsync();

            return positionList;
        }

        public async Task<bool> RemovePosition(Guid positionId)
        {
            try
            {
                /*------------------------------*/
                // Finds asynchronously and removes entity with matched id in db.
                var position = await Entities.FindAsync(positionId);

                if (position == null)
                {
                    return await Task.FromResult(false);
                    //throw new ArgumentNullException(nameof(position));
                }

                position.IsDeleted = true;
                Entities.Update(position);

                _unitOfWork.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdatePosition(Position position, Guid positionId)
        {
            /*------------------------------*/
            // If id is not found in db, return false. Else, update in db and return true.
            if (await Entities.AnyAsync(l => l.PositionId.Equals(positionId)) is false)
                return await Task.FromResult(false);

            Entities.Update(position);
            _unitOfWork.SaveChanges();

            return await Task.FromResult(true);
        }
    }
}