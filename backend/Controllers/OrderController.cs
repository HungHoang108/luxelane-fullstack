using Luxelane.DTOs;
using Luxelane.Models;
using Luxelane.Services.Interfaces;

namespace Luxelane.Controllers
{
    public class OrderController : CrudController<Order, OrderDTO>
    {
        public OrderController(ICrudService<Order, OrderDTO> service) : base(service)
        {
        }
    }
}