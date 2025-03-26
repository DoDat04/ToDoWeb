using ToDoWeb.Models.DTO;
using Microsoft.AspNetCore.Identity;

namespace ToDoWeb.Repositories.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDTO model);
        Task<string?> LoginAsync(LoginDTO model);
        Task LogoutAsync();
    }
}
