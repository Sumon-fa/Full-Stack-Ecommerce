using backend.Models;
using backend.Services;

namespace backend.DTOs
{
 public abstract class BaseDTO<TModel> where TModel : BaseModel
 {
  public abstract Task<TModel> UpdateModelAsync(TModel model, ImageService imageService);


 }
}