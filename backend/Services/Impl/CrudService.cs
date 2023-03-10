using Luxelane.Db;
using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Luxelane.Services.Impl
{
    public class CrudService<TModel, TDto> : ICrudService<TModel, TDto>
        where TModel : BaseModel, new()
        where TDto : BaseDTO<TModel>
    {

        protected readonly DataContext _context;

        public CrudService(DataContext context)
        {
            _context = context;

        }

        public async Task<TModel?> CreateAsync(TDto request)
        {
            var item = new TModel();
            request.UpdateModel(item);
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetAsync(id);
            if (item is null)
            {
                return false;
            }
            _context.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<ICollection<TModel>> GetAllAsync()
        {
            return await _context.Set<TModel>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<TModel?> GetAsync(int id)
        {
            return await _context.Set<TModel>().FindAsync(id);
        }

        public async Task<ActionResult<TModel?>> UpdateAsync(int id, TDto request)
        {
            var item = await GetAsync(id);
            if (item is null)
            {
                return new StatusCodeResult(404);

            }
            request.UpdateModel(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}