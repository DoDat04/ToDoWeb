using System.Text.Json.Serialization;
using ToDoWeb.Converter;
using ToDoWeb.Models.Domain;

namespace ToDoWeb.Models.DTO
{
    public class UpdateToDoRequestDTO
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        public bool IsCompleted { get; set; } = false;

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? DueDate { get; set; }

        public PriorityLevel Priority { get; set; }
    }
}
