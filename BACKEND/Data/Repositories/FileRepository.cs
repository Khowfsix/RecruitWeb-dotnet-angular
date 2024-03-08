using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Data.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly Cloudinary _cloudinary;

        public FileRepository(IOptions<CloudinarySettings> config)
        {
            var acc = new Account
                (
                    config.Value.CloudName,
                    config.Value.ApiKey,
                    config.Value.ApiSecret
                );
            _cloudinary = new Cloudinary(acc);
        }

        public async Task<IEnumerable<ImageUploadResult>> AddListFileAsync(List<IFormFile> files)
        {
            var listUploadResult = new List<ImageUploadResult>();
            foreach (IFormFile file in files)
            {
                listUploadResult.Add(await AddFileAsync(file));
            }
            return listUploadResult;
        }

        public async Task<ImageUploadResult> AddFileAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Overwrite = true
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        public async Task<IEnumerable<DeletionResult>> DeleteListFileAsync(List<string> listId)
        {
            var listResult = new List<DeletionResult>();
            foreach (string id in listId)
            {
                listResult.Add(await DeleteFileAsync(id));
            }
            return listResult;
        }

        public async Task<DeletionResult> DeleteFileAsync(string path)
        {
            string[] parts = path.Split('/');
            string publicIdWithExtension = parts[^1];
            var publicId = publicIdWithExtension.Split('.')[0];
            var deleteParams = new DeletionParams(publicId);

            var result = await _cloudinary.DestroyAsync(deleteParams);
            return result;
        }

        //private static string ConvertFileId(string path)
        //{
        //    string[] parts = path.Split('/');
        //    string publicIdWithExtension = parts[^1];
        //    var publicId = publicIdWithExtension.Split('.')[0];
        //    return publicId;
        //}
    }
}