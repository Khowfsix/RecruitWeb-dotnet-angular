using Data.Entities;
using Data.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CertificateRepository : Repository<Certificate>, ICertificateRepository
    {
        private readonly IUnitOfWork _uow;

        public CertificateRepository(RecruitmentWebContext context, IUnitOfWork uow) : base(context)
        {
            _uow = uow;
        }

        public async Task<bool> DeleteCertificate(Guid requestId)
        {
            try
            {
                var certificate = GetById(requestId);
                if (certificate == null)
                    return await Task.FromResult(false);

                Entities.Remove(certificate);
                _uow.SaveChanges();

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Certificate>> GetAllCertificate(string? request)
        {
            try
            {
                var listData = new List<Certificate>();
                if (string.IsNullOrEmpty(request))
                {
                    listData = await Entities.ToListAsync();
                }
                else
                {
                    listData = await Entities
                        .Where(rp => rp.CertificateName!.Contains(request))
                        .ToListAsync();
                }
                return listData;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Certificate>> GetForeignKey(Guid requestId)
        {
            var data = await Entities
                //.Where(x => x.Cvid == requestId)
                .ToListAsync();

            return data;
        }

        public async Task<Certificate> SaveCertificate(Certificate request)
        {
            try
            {
                request.CertificateId = Guid.NewGuid();

                Entities.Add(request);
                _uow.SaveChanges();

                return await Task.FromResult(request);
            }
            catch (Exception)
            {
                return null!;
            }
        }

        public async Task<bool> UpdateCertificate(Certificate request, Guid requestId)
        {
            try
            {
                request.CertificateId = requestId;
                Entities.Update(request);
                _uow.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}