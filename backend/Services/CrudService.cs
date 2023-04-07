using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.DTOs;
using backend.Db;
using backend.Common;
using System.Reflection;

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

  public async Task<GetAllResultDTO<TModel>> GetAllAsync(FilterDTO filter)
  {
   var query = _dbContext.Set<TModel>().AsQueryable();




   if (!string.IsNullOrWhiteSpace(filter.SearchKeyWord))
   {
    query = query.Where(x => EF.Functions.Like(
        EF.Property<string>(x, "Name"),
        $"%{filter.SearchKeyWord}%"));
   }
   var result = await query.AsNoTracking().Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize).ToListAsync();



   if (result is null)
   {
    throw ServiceException.NotFound("item is not found");
   }

   return new GetAllResultDTO<TModel>
   {
    Result = result,
    ItemLength = query.Count()

   };
  }
 }
}