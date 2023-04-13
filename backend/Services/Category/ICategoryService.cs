using backend.DTOs;
using backend.Models;

namespace backend.Services
{
    public interface ICategoryService : ICrudService<Category, CategoryDTO>
    {
        Task<GetAllResultDTO<Product>> GetAllProductsByCategoryIdAsync(Guid id);
    }
}