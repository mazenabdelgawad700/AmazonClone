
using Amazon.Application.Interfaces;
using Amazon.Core.Entities;
using Amazon.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("createOrder/{userId}")]
        public async Task<ActionResult<Order>> CreateOrder(int userId)
        {
            var createdOrder = await _orderService.CreateOrderAsync(userId);
            return Ok(createdOrder);
        }
        [HttpPost("ChangeOrderStatus")]
        public async Task<ActionResult<Order>> ChangeOrderStatus(int orderId, OrderStatus orderStatus)
        {
            await _orderService.ChangeOrderStatusAsync(orderId,orderStatus);
            return Ok();
        }

        [HttpGet("OrderByOrderId/{orderId}")]
        public async Task<ActionResult<Order>> GetOrderByOrderId(int orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpGet("OrdersByUserId/{userId}")]
        public async Task<ActionResult<Order>> GetOrdersByUserId(int userId)
        {
            var orders = await _orderService.GetOrdersByUserIdAsync(userId);
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }

    }
}
