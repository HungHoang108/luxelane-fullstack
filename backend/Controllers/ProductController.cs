using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Services.Interfaces;

namespace Luxelane.Controllers
{
    public class ProductController : CrudController<Product, ProductDTO>
    {
        public ProductController(ICrudService<Product, ProductDTO> service) : base(service)
        {
        }
    }
}