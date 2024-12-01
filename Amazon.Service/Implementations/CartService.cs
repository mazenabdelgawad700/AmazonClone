using Amazon.Application.Interfaces;
using Amazon.Core.Entities;
using Amazon.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Application
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task AddToCartAsync(int userId, int productId, int quantity)
        {
            await _cartRepository.AddToCartAsync(userId, productId, quantity);
        }

        public async Task ClearCartAsync(int userId)
        {
            await _cartRepository.ClearCartAsync(userId);
        }

        public async Task<Cart> GetCartByUserIdAsync(int userId)
        {
           return await _cartRepository.GetCartByUserIdAsync(userId);
        }

        public async Task RemoveFromCartAsync(int userId, int productId)
        {
            await _cartRepository.RemoveFromCartAsync(userId, productId);
        }
    }
}
