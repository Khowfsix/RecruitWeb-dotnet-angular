using Data.ViewModels.Certificate;

namespace Service.Interfaces
{
    public interface ICertificateService
    {
        Task<IEnumerable<CertificateViewModel>> GetAllCertificate(string? request);

        Task<CertificateViewModel> SaveCertificate(CertificateAddModel request);

        Task<bool> UpdateCertificate(CertificateUpdateModel request, Guid requestId);

        Task<bool> DeleteCertificate(Guid requestId);
    }
}