using System.ComponentModel.DataAnnotations.Schema;

namespace Luxelane.Models
{
    public class ProductCategory : BaseModel
    {
        [NotMapped]
        public Product? Product { get; set; }
        public int ProductId { get; set; }
        [NotMapped]
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
    }
}