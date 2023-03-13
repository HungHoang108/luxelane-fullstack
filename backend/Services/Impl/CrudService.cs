using AutoMapper;
using Luxelane.Db;
using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Luxelane.Services.Impl
{
    public class CrudService<TModel, TDto, TOutputDto> : ICrudService<TModel, TDto, TOutputDto>
        where TModel : BaseModel, new()
        where TDto : BaseDTO<TModel>
        where TOutputDto : class
    {

        protected readonly DataContext _context;
        protected readonly IMapper _mapper;

        public CrudService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TOutputDto?> CreateAsync(TDto request)
        {
            var model = _mapper.Map<TModel>(request);
            // var item = new TModel();
            request.UpdateModel(model);
            _context.Add(model);
            await _context.SaveChangesAsync();
            var result = _mapper.Map<TOutputDto>(model);
            return result;
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
        public virtual async Task<ICollection<TOutputDto>> GetAllAsync(int page = 1, int pageSize = 10)
        {
            var models = await _context.Set<TModel>().AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
            return _mapper.Map<ICollection<TOutputDto>>(models);
        }

        public virtual async Task<TOutputDto?> GetAsync(int id)
        {
            var item = await _context.Set<TModel>().FindAsync(id);
            var result = _mapper.Map<TOutputDto>(item);
            return result;
        }

        public async Task<ActionResult<TOutputDto?>> UpdateAsync(int id, TDto request)
        {
            var item = await GetAsync(id);
            if (item is null)
            {
                return new StatusCodeResult(404);
            }
            var itemModel = _mapper.Map<TModel>(item);

            request.UpdateModel(itemModel);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}