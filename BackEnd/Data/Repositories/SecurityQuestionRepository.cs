using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class SecurityQuestionRepository : Repository<SecurityQuestion>, ISecurityQuestionRepository
    {
        private readonly IUnitOfWork _uow;

        public SecurityQuestionRepository
            (RecruitmentWebContext context,
            IUnitOfWork uow) : base(context)
        {
            _uow = uow;
        }

        public async Task<SecurityQuestion> AddSecurityQuestion(SecurityQuestion request)
        {
            request.SecurityQuestionId = Guid.NewGuid();

            Entities.Add(request);
            _uow.SaveChanges();

            return await Task.FromResult(request);
        }

        public async Task<List<SecurityQuestion>> GetSecurityQuestion()
        {
            var listData = await Entities.ToListAsync();
            return listData;
        }

        public async Task<bool> RemoveSecurityQuestion(Guid requestId)
        {
            var data = GetById(requestId);
            if (data != null)
            {
                Entities.Remove(data);
                _uow.SaveChanges();
                return await Task.FromResult(true);
            }
            throw new ArgumentNullException(nameof(data));
        }

        public async Task<bool> UpdateSecurityQuestion(SecurityQuestion request, Guid requestId)
        {
            request.SecurityQuestionId = requestId;

            Entities.Update(request);
            _uow.SaveChanges();

            return await Task.FromResult(true);
        }
    }
}