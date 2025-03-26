using System.ComponentModel.DataAnnotations;

namespace ToDoWeb.Models.DTO
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
