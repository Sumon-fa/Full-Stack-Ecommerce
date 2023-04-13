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
        Task<GetAllResultDTO<TModel>> GetAllAsync(FilterDTO filter);
    }

}