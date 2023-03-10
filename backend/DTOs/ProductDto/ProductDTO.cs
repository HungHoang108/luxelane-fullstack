using Luxelane.Models;

namespace Luxelane.DTOs
{
    public class ProductDTO : BaseDTO<Product>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<string> Images { get; set; } = null!;

        public override void UpdateModel(Product model)
        {
            model.Name = Name;
            model.Description = Description;
            model.Price = Price;
            model.Quantity = Quantity;
            model.Images = Images;
        }
    }
}