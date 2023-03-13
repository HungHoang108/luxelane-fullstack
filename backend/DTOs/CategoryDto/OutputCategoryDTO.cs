using Luxelane.DTOs.ProductCategoryDto;
using Luxelane.Models;

namespace Luxelane.DTOs.CategoryDto
{
    public class OutputCategoryDTO
    {
        public string Name { get; set; } = null!;
        public string Image { get; set; }  = null!;
        public ICollection<OutputProductCategoryDTO> ProductCategories { get; set; } = null!;

    }
}