using backend.DTOs;
using backend.Models;

namespace backend.Services
{
 public interface ICrudService<TModel, TDto>
     where TModel : BaseModel
     where TDto : BaseDTO<TModel>
 {
  Task<TModel?> CreateAsync(TDto request);
  Task<TModel?> GetAsync(Guid id);
  Task<TModel?> UpdateAsync(Guid id, TDto request);
  Task<bool> DeleteAsync(Guid id);
  Task<ICollection<TModel>> GetAllAsync(FilterDTO filter);
 }

 public class QueryOptions
 {
  public string Sort { get; set; } = string.Empty;
  public string Search { get; set; } = string.Empty;
  public SortBy SortBy { get; set; }
  public int Limit { get; set; } = 3;
  public int Skip { get; set; } = 0;
 }

 public enum SortBy
 {
  ASC,
  DESC
 }
}