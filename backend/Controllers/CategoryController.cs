using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.DTOs;
using backend.Services;
using backend.Common;

namespace backend.Controllers;

[Route("api/v1/categories")]

public class CategoryController : CrudController<Category, CategoryDTO>
{
 private readonly ICategoryService _service;

 public CategoryController(ICategoryService service) : base(service)
 {
  _service = service;
 }

 [HttpGet("{id}/products")]
 public async Task<IActionResult> GetProductsByCategoryId(Guid id)
 {
  var categoryByProducts = await _service.GetAllProductsByCategoryIdAsync(id);

  if (categoryByProducts is null)
  {
   throw ServiceException.NotFound("Product is not found");
  }

  return Ok(categoryByProducts);
 }
}
