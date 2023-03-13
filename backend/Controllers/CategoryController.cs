using Luxelane.DTOs.CategoryDto;
using Luxelane.Models;
using Luxelane.Services.Interfaces;

namespace Luxelane.Controllers
{
    public class CategoryController : CrudController<Category, CategoryDTO, OutputCategoryDTO>
    {
        public CategoryController(ICrudService<Category, CategoryDTO, OutputCategoryDTO> service) : base(service)
        {
        }
    }
}