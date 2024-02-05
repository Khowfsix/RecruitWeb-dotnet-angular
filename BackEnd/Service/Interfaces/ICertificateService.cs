using Service.Models;

namespace Service.Interfaces
{
    public interface ICertificateService
    {
        Task<IEnumerable<CertificateModel>> GetAllCertificate(string? request);

        Task<CertificateModel> SaveCertificate(CertificateModel request);

        Task<bool> UpdateCertificate(CertificateModel request, Guid requestId);

        Task<bool> DeleteCertificate(Guid requestId);
    }
}