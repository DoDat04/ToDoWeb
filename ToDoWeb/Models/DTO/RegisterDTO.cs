using System.ComponentModel.DataAnnotations;

namespace ToDoWeb.Models.DTO
{
    public class RegisterDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
