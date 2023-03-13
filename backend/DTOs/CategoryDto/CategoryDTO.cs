using Luxelane.Models;

namespace Luxelane.DTOs.CategoryDto
{
    public class CategoryDTO : BaseDTO<Category>
    {
        public string Name { get; set; } = null!;
        public string Image { get; set; }  = null!;

        public override void UpdateModel(Category model)
        {
            model.Name = Name;
            model.Image = Image;
        }
    }
}