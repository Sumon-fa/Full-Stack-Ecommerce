using backend.Models;
using backend.Services;

namespace backend.DTOs
{
 public class ProductDTO : BaseDTO<Product>
 {
  public string Name { get; set; } = null!;
  public string Description { get; set; } = null!;
  public float Price { get; set; }
  public IFormFile File { get; set; } = null!;
  public Guid CategoryId { get; set; }

  public override async Task<Product> UpdateModelAsync(Product model, ImageService imageService)
  {
   model.Price = Price;
   model.Name = Name;
   model.Description = Description;
   model.CategoryId = CategoryId;

   if (File != null)
   {
    var imageResult = await imageService.AddImageAsync(File);
    model.PictureUrl = imageResult.SecureUrl.ToString();
    model.PublicId = imageResult.PublicId;
   }

   return model;
  }
 }
}