using Luxelane.Models;

namespace Luxelane.DTOs.ProductCategoryDto
{
    public class ProductCategoryDTO : BaseDTO<ProductCategory>
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public override void UpdateModel(ProductCategory model)
        {
            model.ProductId = ProductId;
            model.CategoryId = CategoryId;
        }
    }
}