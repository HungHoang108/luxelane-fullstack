using Luxelane.DTOs.OrderDto;
using Luxelane.Models;
using Luxelane.Models.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Luxelane.Services.Interfaces
{
    public interface IOrderService : ICrudService<Order, OrderDTO, OutputOrderDTO>
    {
        Task<ActionResult<OutputOrderDTO>> UpdateOrderStatus(int Id, OrderStatus status);
    }
}