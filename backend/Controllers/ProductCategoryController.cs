using Luxelane.DTOs.ProductCategoryDto;
using Luxelane.Models;
using Luxelane.Services.Interfaces;

namespace Luxelane.Controllers
{
    // public class ProductCategoryController : CrudController<ProductCategory, ProductCategoryDTO, ProductCategoryDTO>
    // {
    //     // public ProductCategoryController(ICrudService<ProductCategory, ProductCategoryDTO, ProductCategoryDTO> service) : base(service)
    //     // {
    //     // }

    //     //         public class ProductCategoryController : CrudController<ProductCategory, ProductCategoryDTO, OutputProductCategoryDTO>
    //     // {
    //     //     public ProductCategoryController(ICrudService<ProductCategory, ProductCategoryDTO, OutputProductCategoryDTO> service) : base(service)
    //     //     {
    //     //     }
    //     // }
    // }
    public class ProductCategoryController : CrudController<ProductCategory, ProductCategoryDTO, OutputProductCategoryDTO>
    {
        public ProductCategoryController(ICrudService<ProductCategory, ProductCategoryDTO, OutputProductCategoryDTO> service) : base(service)
        {
        }
    }
}