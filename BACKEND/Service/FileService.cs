using CloudinaryDotNet.Actions;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Service.Interfaces;
using System.Net;

namespace Service
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<IEnumerable<ImageUploadResult>> AddListFileAsync(List<IFormFile> files)
        {
            return await _fileRepository.AddListFileAsync(files);
        }

        public async Task<ImageUploadResult> AddFileAsync(IFormFile file)
        {
            return await _fileRepository.AddFileAsync(file);
        }

        public async Task<IEnumerable<DeletionResult>> DeleteListFileAsync(List<string> listUrls)
        {
            return await _fileRepository.DeleteListFileAsync(listUrls);
        }

        public async Task<DeletionResult> DeleteFileAsync(string url)
        {
            var publicId = GetPublicIdFromUrl(url);
            return await _fileRepository.DeleteFileAsync(publicId);
        }

        public async Task<ImageUploadResult> UpdateFileAsync(IFormFile newFile, string oldFileUrl)
        {
            var deleteOldFile = await _fileRepository.DeleteFileAsync(oldFileUrl);
            if (deleteOldFile.StatusCode == HttpStatusCode.OK)
            {
                return await _fileRepository.AddFileAsync(newFile);
            }
            return null!;

            //return await _fileRepository.UpdateFileAsync(newFile, GetPublicIdFromUrl(oldFileUrl));
        }

        public async Task<IEnumerable<Resource>> GetAllFileAsync()
        {
            return await _fileRepository.GetAllFileAsync();
        }

        private static string GetPublicIdFromUrl(string url)
        {
            var splitBySlash = url.Split('/');
            var publicId_and_dotSomething = splitBySlash[^1];
            var publicId = publicId_and_dotSomething.Split('.')[0];
            return publicId;
        }
    }
}