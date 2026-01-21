using Microsoft.AspNetCore.Mvc;
using MiniGroceryApi.Services;

namespace MiniGroceryApi.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderRequest request)
        {
            var result = await _orderService.PlaceOrder(
                request.ProductId,
                request.Quantity
            );

            if (result == "Order placed successfully")
                return Ok(result);

            return BadRequest(result);
        }
    }

    // Simple request model kept here intentionally
    public class OrderRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
