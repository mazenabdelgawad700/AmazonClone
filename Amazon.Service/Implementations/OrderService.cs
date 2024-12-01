using AutoMapper;
using Amazon.Application.Interfaces;
using Amazon.Core.Entities;
using Amazon.Core.Interfaces;
using Microsoft.Extensions.Logging;
using Amazon.Core.Errors;
using Amazon.Core.Enums;



namespace Amazon.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        //private readonly IInventoryService _inventoryService;
        private readonly ILogger<OrderService> _logger;
        public OrderService(IOrderRepository orderRepository, ICartRepository cartRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            //_inventoryService = inventoryService;
            _logger = logger;
        }

        public Task CancelOrderAsync(int orderId)
        {
            ////  change order status to cancel and return inventory
            ///
            return Task.CompletedTask;
        }

        public async Task ChangeOrderStatusAsync(int orderId, OrderStatus orderStatus)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                throw new NotFoundException("Order not found");
            }
            order.Status = orderStatus;
            await _orderRepository.UpdateOrderAsync(order);
        }

        public async Task<Order> CreateOrderAsync(int userId)
        {
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            //// calculate tax ( next feature )
            //// get shipping address from customer details ( next feature )
            //// get shipping cost from delivery service ( future service )
            //// adding discount ( future feature )
            //// calculate total amount of order


            Order createdOrder = new Order();
            Order newOrder = new Order
            {
                UserId = userId,
                Status = OrderStatus.Pending,
                TaxAmount = 50,
                ShippingAddress = "zayed",
                ShippingCost = 15,
                OrderItems = cart.CartItems.Select(item => new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Product.Price,
                    TotalPrice = item.Quantity * item.Product.Price
                }).ToList(),
                TotalAmount = cart.CartItems.Sum(item => item.Quantity * item.Product.Price),

            };

            await _orderRepository.ExecuteInTransactionAsync(async () =>
            {

                foreach (var item in newOrder.OrderItems)
                {
                    if (!await _orderRepository.ProductExistsAsync(item.ProductId, item.Quantity))
                    {
                        throw new ServiceException("One or more products are out of stock or do not exist.");
                    }
                }

                createdOrder = await _orderRepository.CreateOrderAsync(newOrder);

                // Set OrderId for each order item
                foreach (var orderItem in createdOrder.OrderItems)
                {
                    orderItem.OrderId = createdOrder.Id;
                }
               
                await _orderRepository.UpdateOrderAsync(createdOrder);
                _logger.LogInformation("order created");
                //await _inventoryService.ProductDeduct(createdOrder);
                _logger.LogInformation("update inventory");
            });


            //// send mail with order details using events ( future service ) 

            return createdOrder;
        }

        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);
            return orders;
        }
    }
}
