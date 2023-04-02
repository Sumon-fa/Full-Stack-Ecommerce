namespace backend.Services
{
 using CloudinaryDotNet.Actions;

 public interface IImageService
 {
  Task<ImageUploadResult> AddImageAsync(IFormFile file);
  Task<DeletionResult> DeleteImageAsync(string publicId);
 }
}