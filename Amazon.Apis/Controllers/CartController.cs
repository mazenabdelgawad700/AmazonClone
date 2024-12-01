using AutoMapper;
using Amazon.Application.Interfaces;
using Amazon.Application.Services;
using Amazon.Core.Entities;
using Amazon.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;
        public CartController(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetCartByUserIdAsync(int id)
        {
            var product = await _cartService.GetCartByUserIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


        [HttpPost("AddToCart")]
        public async Task<ActionResult> AddToCartAsync(int userId, int productId, int quantity)
        {
            await _cartService.AddToCartAsync(userId, productId, quantity);
            return Ok();
        }

        [HttpDelete("ClearCart/{userId}")]
        public async Task<ActionResult> ClearCartAsync(int userId)
        {
            await _cartService.ClearCartAsync(userId);
            return Ok();
        }
        [HttpPut("RemoveCartItem")]
        public async Task<ActionResult> RemoveFromCartAsync(int userId, int productId)
        {
            await _cartService.RemoveFromCartAsync(userId, productId);
            return Ok();
        }
    }
}
