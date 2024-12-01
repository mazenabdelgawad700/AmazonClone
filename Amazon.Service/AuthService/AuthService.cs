using Amazon.Core.Contract.Services;
using Amazon.Core.Entities.Identity;
using Amazon.Core.Errors;
using Microsoft.AspNetCore.Identity;
using Amazon.Core.Interfaces;
using Amazon.Core.Dtos.Identity;


namespace Amazon.Service.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;

        public AuthService(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public async Task<UserDto> LoginAsync(LoginDto model)
        {
            var user = await _unitOfWork.AuthRepository.FindByEmailAsync(model.Email);
            if (user == null)
                throw new ApiExeptionResponse(404, "User not found");

            var result = await _tokenService.CheckPasswordAsync(user, model.Password);
            if (!result)
                throw new ApiExeptionResponse(401, "Invalid credentials");

            var token = await _tokenService.CreateTokenAsync(user);

            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = token
            };
        }

        public async Task<UserDto> RegisterAsync(RegisterDto model)
        {
            var existingUser = await _unitOfWork.AuthRepository.FindByEmailAsync(model.Email);
            if (existingUser != null)
                throw new ApiExeptionResponse(400, "Email already exists");

            var newUser = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email.Split('@')[0]
            };

            var result = await _unitOfWork.AuthRepository.CreateAsync(newUser, model.Password);
            if (!result.Succeeded)
                throw new ApiExeptionResponse(400, "User registration failed");
            await _unitOfWork.CompleteAsync();
            var token = await _tokenService.CreateTokenAsync(newUser);

            return new UserDto
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Token = token
            };
        }
    }

}
