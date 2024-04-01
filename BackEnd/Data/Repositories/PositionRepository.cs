using Data.Entities;
using Data.Interfaces;
using Data.Paging;
using Data.Sorting;
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

        public async Task<PageResponse<Position>> GetAllPositions(bool isAdmin, PositionFilter positionFilter,
            string sortString, PageRequest pageRequest)
        {
            /*------------------------------*/
            // Finds all of position entities asynchronously in db.
            // Returns a list of it with the related entities.
            /*------------------------------*/
            var query = isAdmin ? Entities : Entities.Where(o => !o.IsDeleted);

            if (sortString != null)
            {
                var sort = new Sort<Position>(sortString);
                query = sort.getSort(query);
            }

            if (!string.IsNullOrEmpty(positionFilter.Search))
            {
                query = query
                    .Where(o => o.PositionName.ToLower().Contains(positionFilter.Search.ToLower()))
                    .Where(o => o.Description.ToLower().Contains(positionFilter.Search.ToLower()));
            }

            if (positionFilter.FromSalary.HasValue && positionFilter.ToSalary.HasValue)
            {
                query = query.Where(o => o.Salary >= positionFilter.FromSalary.Value);
                query = query.Where(o => o.Salary <= positionFilter.ToSalary.Value);
            }

            if (positionFilter.FromMaxHiringQty.HasValue && positionFilter.ToMaxHiringQty.HasValue)
            {
                query = query.Where(o => o.MaxHiringQty >= positionFilter.FromMaxHiringQty.Value);
                query = query.Where(o => o.MaxHiringQty <= positionFilter.ToMaxHiringQty.Value);
            }

            if (positionFilter.FromDate.HasValue && positionFilter.ToDate.HasValue)
            {
                query = query.Where(o => o.StartDate >= positionFilter.FromDate.Value);
                query = query.Where(o => o.EndDate <= positionFilter.ToDate.Value);
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

            return await PageResponse<Position>.CreateAsync(query, pageRequest.PageIndex, pageRequest.PageSize);
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
            foundEntity.Salary = position.Salary;
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