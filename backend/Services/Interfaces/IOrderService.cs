using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Models.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Luxelane.Services.Interfaces
{
    public interface IOrderService : ICrudService<Order, OrderDTO>
    {
        Task<ActionResult<Order>> UpdateOrderStatus(int Id, OrderStatus status);
    }
}