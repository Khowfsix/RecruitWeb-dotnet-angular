using Api.ViewModels.Cv;
using Microsoft.AspNetCore.Http;

namespace Service.Interfaces
{
    public interface ICvService
    {
        Task<IEnumerable<CvViewModel>> GetAllCv(string? request);

        Task<IEnumerable<CvViewModel>> GetAllUserCv(string userId);

        Task<CvViewModel> SaveCv(CvAddModel request);

        Task<bool> UpdateCv(CvUpdateModel request, Guid requestId);

        Task<bool> DeleteCv(Guid requestId);

        Task<IEnumerable<CvViewModel>> GetCvsOfCandidate(Guid candidateId);

        Task<CvViewModel> GetCvById(Guid requestId);

        Task<bool> UploadCvPdf(IFormFile? CvFile, Guid Cvid);
    }
}