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
        public ActionResult<List<OrderWithStatus>> GetOrders()
        {
            try
            {
                var orders = _orderService.GetOrders();
                if (orders == null || !orders.Any())
                {
                    return NotFound("No orders found.");
                }
                return orders.Select(x => OrderWithStatus.FromOrder(x)).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        
        }

        [HttpGet("{id}")]
        public ActionResult<OrderWithStatus> GetOrder(int id)
        {
            try
            {
                var order = _orderService.GetOrder(id);
                if (order == null)
                {
                    return NotFound($"Order with ID {id} not found.");
                }
                return OrderWithStatus.FromOrder(order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
