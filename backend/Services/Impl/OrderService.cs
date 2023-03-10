using Luxelane.Db;
using Luxelane.DTOs.OrderDto;
using Luxelane.Models;
using Luxelane.Models.Enum;
using Luxelane.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Luxelane.Services.Impl
{
    public class OrderService : CrudService<Order, OrderDTO>, IOrderService
    {
        public OrderService(DataContext context) : base(context)
        {
        }

        public async Task<ActionResult<Order>> UpdateOrderStatus(int Id, OrderStatus newStatus)
        {
            var order = await GetAsync(Id);
            if (order is null)
            {
                return new StatusCodeResult(404);
            }
            order.OrderStatus = newStatus;
            await _context.SaveChangesAsync();
            return order;
        }
    }
}