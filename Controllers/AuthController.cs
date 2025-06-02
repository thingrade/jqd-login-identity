using Microsoft.AspNetCore.Mvc;
using JqdIdentityApp.Application.DTOs;
using JqdIdentityApp.Application.Services;
using JqdIdentityApp.Application.Services.Implementations;
using JqdIdentityApp.Application.Services.Interfaces;

namespace MyIdentityApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(
            IAuthService authService,
            IUserService userService,
            ITokenService tokenService)
        {
            _authService = authService;
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto request)
        {
            var result = await _authService.RegisterUserAsync(request.Email, request.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var isValid = await _authService.CheckPasswordSignInAsync(request.Email, request.Password);

            if (!isValid)
                return Unauthorized(new { message = "Invalid credentials" });

            var user = await _userService.GetUserByEmailAsync(request.Email);
            var token = _tokenService.CreateToken(user!);

            return Ok(new { token });
        }
    }
}
