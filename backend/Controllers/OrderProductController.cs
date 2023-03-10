using Luxelane.DTOs;
using Luxelane.DTOs.OrderProductDto;
using Luxelane.Models;
using Luxelane.Services.Interfaces;

namespace Luxelane.Controllers
{
    public class OrderProductController : CrudController<OrderProduct, OrderProductDTO, OutputOrderProductDTO>
    {
        public OrderProductController(ICrudService<OrderProduct, OrderProductDTO, OutputOrderProductDTO> service) : base(service)
        {
        }
    }
}