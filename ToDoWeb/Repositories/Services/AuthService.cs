using Microsoft.AspNetCore.Identity;
using ToDoWeb.Models.DTO;
using ToDoWeb.Repositories.Interface;

namespace ToDoWeb.Repositories.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string?> LoginAsync(LoginDTO model)
        {
            return await _userRepository.LoginAsync(model);
        }

        public async Task LogoutAsync()
        {
            await _userRepository.LogoutAsync();
        }

        public async Task<bool> RegisterAsync(RegisterDTO model)
        {
            return await _userRepository.RegisterAsync(model);
        }


    }
}
