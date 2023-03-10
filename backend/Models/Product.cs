
namespace Luxelane.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; } = null!;
        public ICollection<OrderProduct> OrderProducts { get; set; } = null!;

        public List<string> Images { get; set; } = null!;
    }
}