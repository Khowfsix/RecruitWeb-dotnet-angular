using Data.CustomModel.Position;
using Data.Entities;
using Data.Interfaces;
using Data.Sorting;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public PositionRepository(RecruitmentWebContext context, IUnitOfWork unitOfWork) : base(context) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PositionAllMinMaxRange> GetAllMinMaxRange()
        {
            /*------------------------------*/
            // Returns all min max range of number field in database.
            /*------------------------------*/
            var result = new PositionAllMinMaxRange();

            var highestMaxSalary = await Entities.OrderByDescending(p => p.MaxSalary).FirstOrDefaultAsync();
            result.HighestMaxSalary = highestMaxSalary is not null ? highestMaxSalary.MaxSalary is not null ? (int)(highestMaxSalary.MaxSalary.Value) : 0 : 0;

            var lowestMaxSalary = await Entities.OrderBy(p => p.MaxSalary).FirstOrDefaultAsync();
            result.LowestMaxSalary = lowestMaxSalary is not null ? lowestMaxSalary.MaxSalary is not null ? (int)(lowestMaxSalary.MaxSalary.Value) : 0 : 0;

            var highestMinSalary = await Entities.OrderByDescending(p => p.MinSalary).FirstOrDefaultAsync();
            result.HighestMinSalary = highestMinSalary is not null ? highestMinSalary.MinSalary is not null ? (int)(highestMinSalary.MinSalary.Value) : 0 : 0;

            var lowestMinSalary = await Entities.OrderBy(p => p.MinSalary).FirstOrDefaultAsync();
            result.LowestMinSalary = lowestMinSalary is not null ? lowestMinSalary.MinSalary is not null ? (int)(lowestMinSalary.MinSalary.Value) : 0 : 0;

            var highestMaxHiringQty = await Entities.OrderByDescending(p => p.MaxHiringQty).FirstOrDefaultAsync();
            result.HighestMaxHiringQty = highestMaxHiringQty is not null ? (int)(highestMaxHiringQty.MaxHiringQty) : 0;

            var lowestMaxHiringQty = await Entities.OrderBy(p => p.MaxHiringQty).FirstOrDefaultAsync();
            result.LowestMaxHiringQty = lowestMaxHiringQty is not null ? (int)(lowestMaxHiringQty.MaxHiringQty) : 0;

            return result is not null ? result : null!;
        }


        public async Task<Position> AddPosition(Position position)
        {
            position.PositionId = Guid.NewGuid();

            Entities.Add(position);
            _unitOfWork.SaveChanges();

            return await Task.FromResult(position);
        }

        public async Task<List<Position>> GetAllPositions(PositionFilter positionFilter, string sortString)
        {
            /*------------------------------*/
            // Finds all of position entities asynchronously in db.
            // Returns a list of it with the related entities.
            /*------------------------------*/

            var query = Entities.Select(o => o);

            if (sortString != null)
            {
                var sort = new Sort<Position>(sortString);
                query = sort.getSort(query);
            }

            if (!string.IsNullOrEmpty(positionFilter.Search))
            {
                query = query
                    .Where(o => o.PositionName!.ToLower().Contains(positionFilter.Search.ToLower())
                    || o.Description!.ToLower().Contains(positionFilter.Search.ToLower()));
            }


            if (positionFilter.UserId.HasValue)
            {
                query = query.Include(e => e.Recruiter).Where(e => e.Recruiter.UserId.Equals(positionFilter.UserId.Value.ToString()));
            }

            if (positionFilter.FromSalary.HasValue && positionFilter.ToSalary.HasValue)
            {
               
                    //query = query.Where(e => 
                    //(e.MinSalary == null && e.MaxSalary!.Value >= positionFilter.FromSalary.Value) || 
                    //(e.MaxSalary == null && positionFilter.ToSalary.Value >= e.MinSalary!.Value) || 
                    //(e.MinSalary == null && e.MaxSalary == null) ||
                    //(positionFilter.FromSalary.Value <= e.MinSalary!.Value && e.MaxSalary!.Value <= positionFilter.ToSalary.Value)
                    //)

                query = query.Where(e =>
                    (e.MinSalary == null && e.MaxSalary == null)
                    || (positionFilter.FromSalary <= e.MaxSalary && e.MaxSalary <= positionFilter.ToSalary)
                    || (positionFilter.FromSalary <= e.MinSalary && e.MinSalary <= positionFilter.ToSalary)
                    //|| (positionFilter.FromSalary <= e.MinSalary && e.MaxSalary <= positionFilter.ToSalary)
                    //|| (positionFilter.FromSalary >= e.MinSalary && e.MaxSalary >= positionFilter.ToSalary)
                );
                if (!positionFilter.NegotiatedSalary)
                {
                    query = query.Where(e => e.MinSalary != null && e.MaxSalary != null 
                    );
                }
            }

            if (positionFilter.FromMaxHiringQty.HasValue && positionFilter.ToMaxHiringQty.HasValue)
            {
                query = query.Where(o => o.MaxHiringQty >= positionFilter.FromMaxHiringQty.Value);
                query = query.Where(o => o.MaxHiringQty <= positionFilter.ToMaxHiringQty.Value);
            }

            if (positionFilter.FromDate.HasValue && positionFilter.ToDate.HasValue)
            {
                //query = query.Where(o => o.StartDate >= positionFilter.FromDate.Value);
                //query = query.Where(o => o.EndDate <= positionFilter.ToDate.Value);
                query = query.Where(o => !((o.StartDate > positionFilter.ToDate) || (o.EndDate < positionFilter.FromDate)));
            }

            if (positionFilter.CategoryPositionIds != null && positionFilter.CategoryPositionIds.Count > 0)
            {
                query = query.Where(o => positionFilter.CategoryPositionIds.Contains(o.CategoryPositionId));
            }

            if (positionFilter.CompanyIds != null && positionFilter.CompanyIds.Count > 0)
            {
                query = query.Where(o => positionFilter.CompanyIds.Contains(o.CompanyId));
            }

            if (positionFilter.LanguageIds != null && positionFilter.LanguageIds.Count > 0)
            {
                query = query.Where(o => positionFilter.LanguageIds.Any(id => o.LanguageId == id));
            }

            query = query
                .Include(o => o.Requirements)
                .Include(o => o.Company)
                .Include(o => o.Language)
                .Include(o => o.Recruiter);

            var result = await query.ToListAsync();

            return result;
        }
        public async Task<List<Position>> GetAllByRecruiterId(Guid recruiterId)
        {
            var positionListWithName = await Entities
                .Where(o => o.RecruiterId.Equals(recruiterId))
                .Include(o => o.Requirements)
                .Include(o => o.Company)
                .Include(o => o.Language)
                .Include(o => o.Recruiter)
                .Include(o => o.CategoryPosition)
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
                .Where(o => o.Recruiter.UserId.Equals(userId))
                .Include(o => o.Requirements)
                .Include(o => o.Company)
                .Include(o => o.Language)
                .Include(o => o.Recruiter)
                .Include(o => o.CategoryPosition)
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
                .Include(o => o.CategoryPosition)
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
                .Include(o => o.CategoryPosition)
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
            //if (await Entities.AnyAsync(l => l.PositionId.Equals(positionId)) is false)
            //    return await Task.FromResult(false);

            var foundEntity = Entities.Find(positionId);

            if (foundEntity == null)
                return await Task.FromResult(false);

            foundEntity.ImageURL = position.ImageURL;
            foundEntity.PositionName = position.PositionName;
            foundEntity.Description = position.Description;
            foundEntity.MaxSalary = position.MaxSalary;
            foundEntity.MinSalary = position.MinSalary;
            foundEntity.MaxHiringQty = position.MaxHiringQty;
            foundEntity.StartDate = position.StartDate;
            foundEntity.EndDate = position.EndDate;
            foundEntity.LanguageId = position.LanguageId;
            foundEntity.CategoryPositionId = position.CategoryPositionId;

            Entities.Update(foundEntity);
            _unitOfWork.SaveChanges();

            return await Task.FromResult(true);
        }
    }
}