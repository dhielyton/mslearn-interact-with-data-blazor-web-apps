using BlazingPizza.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlazingPizza.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrderController : Controller
    {
       private readonly OrderService _orderService;
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<ActionResult<int>> PlaceOrder(Order order)
        {
            
            if (order == null)
            {
                return BadRequest("Order cannot be null.");
            }
            order.CreatedTime = DateTime.UtcNow;
            order.UserId = Guid.NewGuid().ToString(); 
            
            await _orderService.AddAsync(order);
            return order.OrderId;
        }
        [HttpGet]
        public ActionResult<List<Order>> GetOrders()
        {
            var orders = _orderService.GetOrders();
            if (orders == null || !orders.Any())
            {
                return NotFound("No orders found.");
            }
            return orders;
        }
    }
}
