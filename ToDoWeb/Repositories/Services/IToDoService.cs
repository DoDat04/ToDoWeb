using ToDoWeb.Models.Domain;

namespace ToDoWeb.Repositories.Services
{
    public interface IToDoService
    {
        Task<List<ToDoItem>> GetAllToDoListAsync(string userId);
        Task<ToDoItem?> GetToDoByIdAsync(Guid id, string userId);
        Task<ToDoItem> CreateToDoItemAsync(ToDoItem toDoItem, string userId);
        Task<ToDoItem?> UpdateToDoItemAsync(Guid id, ToDoItem toDoItem, string userId);
        Task<ToDoItem?> DeleteToDoItemAsync(Guid id, string userId);
    }
}
