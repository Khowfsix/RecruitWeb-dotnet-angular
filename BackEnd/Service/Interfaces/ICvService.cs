using Microsoft.AspNetCore.Http;
using Service.Models;

namespace Service.Interfaces
{
    public interface ICvService
    {
        Task<IEnumerable<CvModel>> GetAllCv(string? request);

        Task<IEnumerable<CvModel>> GetAllUserCv(string userId);

        Task<CvModel> SaveCv(CvModel request);

        Task<bool> UpdateCv(CvModel request, Guid requestId);

        Task<bool> DeleteCv(Guid requestId);

        Task<IEnumerable<CvModel>> GetCvsOfCandidate(Guid candidateId);

        Task<CvModel> GetCvById(Guid requestId);

        Task<bool> UploadCvPdf(IFormFile? CvFile, Guid Cvid);
    }
}