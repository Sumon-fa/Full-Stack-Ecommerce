namespace backend.Services
{
 using backend.DTOs;
 using backend.Models;

 public interface ICategoryService : ICrudService<Category, CategoryDTO>
 {
  Task<GetAllResultDTO<Product>> GetAllProductsByCategoryIdAsync(Guid id);
 }
}