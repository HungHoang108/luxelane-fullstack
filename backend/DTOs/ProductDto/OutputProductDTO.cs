namespace Luxelane.DTOs.ProductDto
{
    public class OutputProductDTO
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<string> Images { get; set; } = null!;
    }
}