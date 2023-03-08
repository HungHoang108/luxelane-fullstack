using Luxelane.Models;
using Luxelane.Models.Enum;

namespace Luxelane.DTOs
{
    public class OrderDTO : BaseDTO<Order>
    {
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public OrderStatus Status { get; set; }


        public override void UpdateModel(Order model)
        {
            model.TotalPrice = TotalPrice;
            model.UserId = UserId;
            model.OrderStatus = Status;
        }
    }
}