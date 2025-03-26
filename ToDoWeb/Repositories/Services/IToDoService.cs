using ToDoWeb.Models.Domain;

namespace ToDoWeb.Repositories.Services
{
    public interface IToDoService
    {
        Task<List<ToDoItem>> GetAllToDoListAsync(string userId, string? isCompleted = null, string? priority = null, int pageNumber = 1, int pageSize = 1000);
        Task<ToDoItem?> GetToDoByIdAsync(Guid id, string userId);
        Task<ToDoItem> CreateToDoItemAsync(ToDoItem toDoItem, string userId);
        Task<ToDoItem?> UpdateToDoItemAsync(Guid id, ToDoItem toDoItem, string userId);
        Task<ToDoItem?> DeleteToDoItemAsync(Guid id, string userId);
    }
}
