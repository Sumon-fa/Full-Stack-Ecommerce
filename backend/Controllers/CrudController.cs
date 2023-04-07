using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using backend.Common;

namespace backend.Controllers
{
 public abstract class CrudController<TModel, TDto> : ApiControllerBase
     where TModel : BaseModel
     where TDto : BaseDTO<TModel>
 {
  private readonly ICrudService<TModel, TDto> _service;

  public CrudController(ICrudService<TModel, TDto> service)
  {
   _service = service ?? throw new ArgumentNullException(nameof(service));
  }

  [Authorize]
  [HttpPost]
  [Consumes("multipart/form-data")]
  public virtual async Task<ActionResult<TModel?>> CreateAsync([FromForm] TDto request)
  {
   var item = await _service.CreateAsync(request);
   if (item is null)
   {
    throw ServiceException.BadRequest("data is not valid");
   }

   return Ok(item);
  }

  [HttpGet("{id:Guid}")]
  public async Task<ActionResult<TModel?>> GetActionAsync(Guid id)
  {
   var item = await _service.GetAsync(id);

   return Ok(item);
  }

  [Authorize]
  [HttpPut("{id:Guid}")]
  [Consumes("multipart/form-data")]
  public async Task<IActionResult> UpdateAsync(Guid id, [FromForm] TDto request)
  {
   var item = await _service.UpdateAsync(id, request);

   return Ok(item);
  }

  [Authorize]
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteAsync(Guid id)
  {
   if (!await _service.DeleteAsync(id))
   {
    throw ServiceException.NotFound("item is not found");
   }
   return Ok(new { Message = "success!" });
  }

  [HttpGet]
  public async Task<IActionResult> GetAllAsync([FromQuery] FilterDTO filter)
  {
   return Ok(await _service.GetAllAsync(filter));
  }
 }
}