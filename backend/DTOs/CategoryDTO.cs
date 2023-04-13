using backend.Models;
using backend.Services;
using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

public class CategoryDTO : BaseDTO<Category>
{
    [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
    public string Name { get; set; } = null!;
    [MaxNumberOfFiles(2)]
    public IFormFile File { get; set; } = null!;

    public override async Task<Category> UpdateModelAsync(Category model, ImageService imageService)
    {

        model.Name = Name;
        if (File != null)
        {
            var imageResult = await imageService.AddImageAsync(File);
            model.PictureUrl = imageResult.SecureUrl.ToString();
            model.PublicId = imageResult.PublicId;
        }

        return model;
    }
}
