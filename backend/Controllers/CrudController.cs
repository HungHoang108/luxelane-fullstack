using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Luxelane.Controllers
{
    public class CrudController<TModel, TDto, TOutputDto> : ApicontrollerBase
        where TModel : BaseModel
        where TDto : BaseDTO<TModel>
    {
        protected readonly ICrudService<TModel, TDto, TOutputDto> _service;

        public CrudController(ICrudService<TModel, TDto, TOutputDto> service)
        {
            _service = service ?? throw new ArgumentException(nameof(service));
        }

        [HttpPost]
        public async virtual Task<IActionResult> Create(TDto request)
        {
            var item = await _service.CreateAsync(request);
            if (item is null)
            {
                return BadRequest();
            }
            return Ok(item);
        }

        [HttpGet("{id:int}")]
        public async virtual Task<ActionResult<TOutputDto?>> Get(int id)
        {
            var item = await _service.GetAsync(id);
            if (item is null)
            {
                return NotFound("Item is not found");
            }
            return item;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TOutputDto?>> Update(int id, TDto request)
        {
            var item = await _service.UpdateAsync(id, request);
            if (item is null)
            {
                return NotFound("Item is not found");
            }
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _service.DeleteAsync(id))
            {
                return Ok(new { Message = "Item is deleted " });
            }
            return NotFound("Item is not found");
        }

        [HttpGet]
        public async Task<ICollection<TOutputDto>> GetAll()
        {
            return await _service.GetAllAsync();
        }
    }
}