using Luxelane.DTOs.OrderDto;
using Luxelane.Models;
using Luxelane.Models.Enum;
using Luxelane.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Luxelane.Controllers
{
    public class OrderController : CrudController<Order, OrderDTO, OutputOrderDTO>
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService service) : base(service)
        {
            _orderService = service;
        }

        [HttpPatch("orderStatus/{id}")]
        public async Task<ActionResult<OutputOrderDTO>> UpdateOrderStatus(int id, [FromBody] OrderStatus newStatus)
        {
            return await _orderService.UpdateOrderStatus(id, newStatus);
        }
    }
}