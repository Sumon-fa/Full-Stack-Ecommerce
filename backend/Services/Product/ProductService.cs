using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Db;
using backend.Models;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;


namespace backend.Services;

public class ProductService : CrudService<Product, ProductDTO>
{
 private readonly ImageService _imageService;
 public ProductService(AppDbContext dbContext, ImageService imageService) : base(dbContext, imageService)
 {
  _imageService = imageService;
 }
 /*public override async Task<ICollection<Product>> GetAllAsync(FilterDTO filter)
 {

  var query = _dbContext.Products.AsQueryable();


  if (!string.IsNullOrEmpty(filter.Category))
  {
   query = query.Where(p => p.Category.Name == filter.Category);
  }

  if (filter.MinPrice.HasValue)
  {
   query = query.Where(p => p.Price >= filter.MinPrice.Value);
  }

  if (filter.MaxPrice.HasValue)
  {
   query = query.Where(p => p.Price <= filter.MaxPrice.Value);
  }
  if (!string.IsNullOrEmpty(filter.SearchKeyWord))
  {
   query = query.Where(p => p.Name.ToLower().Contains(filter.SearchKeyWord.ToLower()));
  }
  return await query.AsNoTracking()
      .ToListAsync();
 }*/

}
/* return await query.AsNoTracking().Include(p => p.Category)
      .Skip((filter.Page - 1) * filter.PageSize)
      .Take(filter.PageSize)
      .ToListAsync();*/