using Luxelane.Models;

namespace Luxelane.DTOs
{
    public class OrderProductDTO : BaseDTO<OrderProduct>
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public override void UpdateModel(OrderProduct model)
        {
            model.ProductId = ProductId;
            model.Quantity = Quantity;
            model.OrderId = OrderId;
        }
    }
}