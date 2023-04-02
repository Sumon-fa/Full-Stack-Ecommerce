using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.DTOs;
using backend.Db;
using backend.Common;

namespace backend.Services
{
 public class CrudService<TModel, TDto> : ICrudService<TModel, TDto>
 where TModel : BaseModel, new()
 where TDto : BaseDTO<TModel>
 {
  protected readonly AppDbContext _dbContext;
  private readonly ImageService _imageService;

  public CrudService(AppDbContext dbContext, ImageService imageService)
  {
   _dbContext = dbContext;
   _imageService = imageService;
  }

  public async Task<TModel?> CreateAsync(TDto request)
  {

   var item = new TModel();
   await request.UpdateModelAsync(item, _imageService);

   _dbContext.Add(item);
   await _dbContext.SaveChangesAsync();
   return item;
  }

  public virtual async Task<TModel?> GetAsync(Guid id)
  {
   var result = await _dbContext.Set<TModel>().FindAsync(id);
   if (result is null)
   {
    throw ServiceException.NotFound("item is not found");
   }

   return result;
  }


  public async Task<TModel?> UpdateAsync(Guid id, TDto request)
  {
   var item = await GetAsync(id);
   if (item is null)
   {
    throw ServiceException.NotFound("item is not found");
   }
   await request.UpdateModelAsync(item, _imageService);
   await _dbContext.SaveChangesAsync();
   return item;
  }

  public async Task<bool> DeleteAsync(Guid id)
  {
   var item = await GetAsync(id);
   if (item is null)
   {
    return false;
   }
   var publicIdProperty = typeof(TModel).GetProperty("PublicId");


   if (publicIdProperty is not null)
   {
    var publicIdValue = publicIdProperty.GetValue(item);
    if (publicIdValue is not null)
    {
     await _imageService.DeleteImageAsync((string)publicIdValue);
    }


   }
   _dbContext.Remove(item);
   await _dbContext.SaveChangesAsync();
   return true;
  }

  public virtual async Task<ICollection<TModel>> GetAllAsync(FilterDTO filter)
  {
   var query = _dbContext.Set<TModel>().AsNoTracking().AsQueryable();
   if (filter.Sort.Trim().Length > 0)
   {
    if (query.GetType().GetProperty(filter.Sort) != null)
    {
     query.OrderBy(e => e.GetType().GetProperty(filter.Sort));

    }
    query.Take(filter.Limit).Skip(filter.Skip);
   }
   var result = await query.ToListAsync();
   if (result is null)
   {
    throw ServiceException.NotFound("item is not found");
   }

   return result;
  }
 }
}