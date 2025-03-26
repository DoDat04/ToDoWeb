using Microsoft.AspNetCore.Identity;

namespace ToDoWeb.Models.Domain
{
    public enum PriorityLevel
    {
        Easy,
        Medium,
        Hard
    }

    public class ToDoItem
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsCompleted { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.Date;

        public DateTime? DueDate { get; set; }

        public PriorityLevel Priority { get; set; }

        public string? UserId { get; set; } = string.Empty;
        public IdentityUser User { get; set; } = null!;
    }
}



