using Luxelane.DTOs;
using Luxelane.DTOs.ProductDto;
using Luxelane.Models;
using Luxelane.Services.Interfaces;

namespace Luxelane.Controllers
{
    public class ProductController : CrudController<Product, ProductDTO, OutputProductDTO>
    {
        public ProductController(ICrudService<Product, ProductDTO, OutputProductDTO> service) : base(service)
        {
        }
    }
}