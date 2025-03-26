using Microsoft.AspNetCore.Identity;
using ToDoWeb.Models.DTO;
using ToDoWeb.Repositories.Services;

namespace ToDoWeb.Repositories.Interface
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JwtService _jwtService;

        public UserRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, JwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        public async Task<string?> LoginAsync(LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return null;

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded) return null;

            return _jwtService.GenerateToken(user.Id, user.Email);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RegisterAsync(RegisterDTO model)
        {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errorMessages = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new Exception($"Đăng ký thất bại: {errorMessages}");
            }

            return result.Succeeded;
        }

    }
}
