using Luxelane.Models;
using Luxelane.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Luxelane.Models
{
    public class Order : BaseModel
    {
        [NotMapped]
        public User? User { get; set; } = null!;
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }

        [Column(TypeName = "order_status")]
        public OrderStatus OrderStatus { get; set; }
    }
}