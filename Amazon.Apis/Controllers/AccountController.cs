
using Amazon.Core.Contract.Services;
using Amazon.Core.Dtos.Identity;
using Amazon.Core.Errors;
using Amazon.Service.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Apis.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto model)
        {
            try
            {
                var userDto = await _authService.LoginAsync(model);
                return Ok(userDto);
            }
            catch (ApiExeptionResponse ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto model)
        {
            try
            {
                var userDto = await _authService.RegisterAsync(model);
                return Ok(new {success=true,message="registered successfully"});
            }
            catch (ApiExeptionResponse ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
        }
    }
}
