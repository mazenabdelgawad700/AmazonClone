using Amazon.Core.Dtos;
using Amazon.Core.Entities;
using Amazon.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Application.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(int userId);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task ChangeOrderStatusAsync(int orderId, OrderStatus orderStatus);
        Task CancelOrderAsync(int orderId);
    }
}
