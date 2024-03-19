using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
    {
        private readonly IUnitOfWork _uow;

        public RefreshTokenRepository(RecruitmentWebContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _uow = unitOfWork;
        }

        public Task<bool> DeleteRefreshToken(int id)
        {
            try
            {
                var delEntity = GetById(id);
                if (delEntity != null)
                {
                    Entities.Remove(delEntity);
                }
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _uow.RollbackTransaction();
                return Task.FromResult(false);
            }
        }

        public async Task<RefreshToken> CreateRefreshToken(RefreshToken refreshToken)
        {
            try
            {
                int newId = (Entities
                    .OrderBy(e => e.Id)
                    .Select(x => x.Id)
                    .LastOrDefault() + 1) % (Int32.MaxValue);
                var deleteRF = await DeleteRefreshToken(newId);
                if (deleteRF)
                {
                    refreshToken.Id = newId;

                    Entities.Add(refreshToken);
                    _uow.SaveChanges();
                    return refreshToken;
                }
                return null!;
            }
            catch (Exception)
            {
                return null!;
            }
        }

        public Task<RefreshToken> GetRefreshToken(string refreshToken)
        {
            try
            {
                var response = Entities.Where(x => x.Token == refreshToken).FirstOrDefault();
                return response != null ?
                    Task.FromResult(response) : null!;
            }
            catch (Exception)
            {
                return null!;
            }
        }

        public Task<RefreshToken> UpdateRefreshToken(RefreshToken refreshToken, int id)
        {
            try
            {
                var entity = Entities
                    .AsNoTracking()
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                if (entity == null)
                {
                    return null!;
                }

                refreshToken.Id = id;
                Entities.Update(refreshToken);
                _uow.SaveChanges();
                return Task.FromResult(refreshToken);
            }
            catch (Exception)
            {
                return null!;
            }
        }
    }
}
