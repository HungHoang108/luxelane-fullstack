using Luxelane.Models;
using Luxelane.Models.Enum;

namespace Luxelane.DTOs.OrderDto
{
    public class OutputOrderDTO
    {
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = null!;
        public OrderStatus OrderStatus { get; set; }

    }
}