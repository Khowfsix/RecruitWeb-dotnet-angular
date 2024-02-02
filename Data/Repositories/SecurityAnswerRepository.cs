using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class SecurityAnswerRepository : Repository<SecurityAnswer>, ISecurityAnswerRepository
    {
        private readonly IUnitOfWork _uow;

        public SecurityAnswerRepository(RecruitmentWebContext context,
            IUnitOfWork uow) : base(context)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<SecurityAnswer>> GetAllSecurityAnswers()
        {
            var listData = await Entities.ToListAsync();
            return listData;
        }

        public async Task<SecurityAnswer> SaveSecurityAnswer(SecurityAnswer request)
        {
            request.SecurityAnswerId = Guid.NewGuid();

            Entities.Add(request);
            _uow.SaveChanges();

            return await Task.FromResult(request);
        }

        public async Task<bool> UpdateSecurityAnswer(SecurityAnswer request, Guid requestId)
        {
            request.SecurityAnswerId = requestId;

            Entities.Update(request);
            _uow.SaveChanges();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteSecurityAnswer(Guid requestId)
        {
            var entity = await Entities.FirstOrDefaultAsync(x => x.SecurityAnswerId == requestId);
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Entities.Remove(entity);
            _uow.SaveChanges();

            return await Task.FromResult(true);
        }
    }
}