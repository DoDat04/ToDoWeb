using Microsoft.AspNetCore.Identity;
using ToDoWeb.Models.DTO;

namespace ToDoWeb.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<bool> RegisterAsync(RegisterDTO model);
        Task<string?> LoginAsync(LoginDTO model);
        Task LogoutAsync();
    }
}
