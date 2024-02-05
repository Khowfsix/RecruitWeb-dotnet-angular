using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RequirementRepository : Repository<Requirement>, IRequirementRepository
    {
        private readonly IUnitOfWork _uow;

        public RequirementRepository(RecruitmentWebContext context,
            IUnitOfWork uow) : base(context)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Requirement>> GetAllRequirement()
        {
            var listData = await Entities.ToListAsync();
            return listData;
        }

        public async Task<Requirement> SaveRequirement(Requirement request)
        {
            request.RequirementId = Guid.NewGuid();

            Entities.Add(request);
            _uow.SaveChanges();

            return await Task.FromResult(request);
        }

        public async Task<bool> UpdateRequirement(Requirement request, Guid requestId)
        {
            request.RequirementId = requestId;

            Entities.Update(request);
            _uow.SaveChanges();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteRequirement(Guid requestId)
        {
            var entity = await Entities.FirstOrDefaultAsync(x => x.RequirementId == requestId);
            if (entity is null or { IsDeleted: true })
            {
                return await Task.FromResult(false);
            }
            entity.IsDeleted = true;
            Entities.Update(entity);
            _uow.SaveChanges();

            return await Task.FromResult(true);
        }

        public async Task<List<Requirement>> GetRequirementsByPositionId(Guid positionId)
        {
            var requirementList = Entities.AsAsyncEnumerable();
            List<Requirement> result = new();
            await foreach (var requirement in requirementList)
            {
                if (requirement.PositionId == positionId)
                {
                    result.Add(requirement);
                }
            }
            return result;
        }
    }
}