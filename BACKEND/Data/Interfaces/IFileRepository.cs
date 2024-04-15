using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Data.Interfaces
{
    public interface IFileRepository
    {
        Task<RawUploadResult> AddFileAsync(IFormFile file);

        Task<IEnumerable<RawUploadResult>> AddListFileAsync(List<IFormFile> files);

        Task<DeletionResult> DeleteFileAsync(string publicId);

        Task<IEnumerable<DeletionResult>> DeleteListFileAsync(List<string> publicId);

        Task<IEnumerable<Resource>> GetAllFileAsync();

        Task<RawUploadResult> UpdateFileAsync(IFormFile file, string oldPublicId);
    }
}