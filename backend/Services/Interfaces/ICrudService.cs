using Microsoft.AspNetCore.Mvc;

namespace Luxelane.Services.Interfaces
{
    public interface ICrudService<TModel, TDto>
    {
        Task<ICollection<TModel>> GetAllAsync();
        Task<TModel?> GetAsync(int id);
        Task<TModel?> CreateAsync(TDto request);
        Task<bool> DeleteAsync(int id);
        Task<ActionResult<TModel?>> UpdateAsync(int id, TDto request);

    }
}