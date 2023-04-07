using backend.Db;
using backend.Models;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;
using backend.Common;

namespace backend.Services
{
 public class CategoryService : CrudService<Category, CategoryDTO>, ICategoryService
 {
  public CategoryService(AppDbContext dbContext, ImageService imageService) : base(dbContext, imageService)
  {
  }

  public async Task<GetAllResultDTO<Product>> GetAllProductsByCategoryIdAsync(Guid id)
  {
   var category = await _dbContext.Categories.AsNoTracking()
         .Include(c => c.Products)
         .SingleOrDefaultAsync(c => c.Id == id);
   if (category is null)
   {
    throw ServiceException.NotFound("Category is not found");
   }
   return new GetAllResultDTO<Product>
   {
    Result = category.Products,
    ItemLength = category.Products.Count()

   };
  }


 }
}