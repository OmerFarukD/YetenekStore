using Microsoft.AspNetCore.Http;

namespace YetenekStore.Service.Helpers.Cloudinary;

public interface IFileService
{
    Task<string> UploadImageAsync(IFormFile formFile, string folderName);
}