using Microsoft.AspNetCore.Mvc;
using ToDoWeb.Models.DTO;
using ToDoWeb.Repositories.Services;

namespace ToDoWeb.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            try
            {
                var result = await _authService.RegisterAsync(model);
                return Ok("Đăng ký thành công!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var token = await _authService.LoginAsync(model);
            if (token == null) return Unauthorized("Sai thông tin đăng nhập!");

            return Ok(new
            {
                Message = "Đăng nhập thành công!",
                Token = token
            });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return Ok(new { message = "Đăng xuất thành công!" });
        }

    }
}
