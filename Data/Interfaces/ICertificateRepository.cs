using Data.Entities;

namespace Data.Interfaces
{
    public interface ICertificateRepository
    {
        Task<IEnumerable<Certificate>> GetAllCertificate(string? request);

        Task<Certificate> SaveCertificate(Certificate request);

        Task<bool> UpdateCertificate(Certificate request, Guid requestId);

        Task<bool> DeleteCertificate(Guid requestId);

        Task<IEnumerable<Certificate>> GetForeignKey(Guid requestId);
    }
}