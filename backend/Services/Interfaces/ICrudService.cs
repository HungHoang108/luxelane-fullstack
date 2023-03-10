using Microsoft.AspNetCore.Mvc;

namespace Luxelane.Services.Interfaces
{
    public interface ICrudService<TModel, TDto, TOutputDto>
    {
        Task<ICollection<TOutputDto>> GetAllAsync();
        Task<TOutputDto?> GetAsync(int id);
        Task<TOutputDto?> CreateAsync(TDto request);
        Task<bool> DeleteAsync(int id);
        Task<ActionResult<TOutputDto?>> UpdateAsync(int id, TDto request);

    }
}