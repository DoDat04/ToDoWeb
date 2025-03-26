using Microsoft.AspNetCore.Mvc;
using ToDoWeb.Models.Domain;

namespace ToDoWeb.Repositories.Interface
{
    public interface IToDoRepository
    {
        Task<List<ToDoItem>> GetAllToDoListAsync(string userId);
        Task<ToDoItem?> GetToDoByIdAsync(Guid id, string userId);
        Task<ToDoItem> CreateToDoItemAsync(ToDoItem toDoItem, string userId);
        Task<ToDoItem?> UpdateToDoItemAsync(Guid id, ToDoItem toDoItem, string userId);
        Task<ToDoItem?> DeleteToDoItemAsync(Guid id, string userId);
    }
}
