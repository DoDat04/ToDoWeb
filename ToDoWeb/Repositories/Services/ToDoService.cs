using AutoMapper;
using ToDoWeb.Models.Domain;
using ToDoWeb.Repositories.Interface;

namespace ToDoWeb.Repositories.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository toDoRepository;
        private readonly IMapper mapper;

        public ToDoService(IToDoRepository toDoRepository, IMapper mapper)
        {
            this.toDoRepository = toDoRepository;
            this.mapper = mapper;
        }
        public async Task<ToDoItem> CreateToDoItemAsync(ToDoItem toDoItem, string userId)
        {
            return await toDoRepository.CreateToDoItemAsync(toDoItem, userId);
        }

        public async Task<ToDoItem?> DeleteToDoItemAsync(Guid id, string userId)
        {
            return await toDoRepository.DeleteToDoItemAsync(id, userId);
        }

        public async Task<List<ToDoItem>> GetAllToDoListAsync(string userId)
        {
            return await toDoRepository.GetAllToDoListAsync(userId);
        }

        public async Task<ToDoItem?> GetToDoByIdAsync(Guid id, string userId)
        {
            return await toDoRepository.GetToDoByIdAsync(id, userId);
        }

        public async Task<ToDoItem?> UpdateToDoItemAsync(Guid id, ToDoItem toDoItem, string userId)
        {
            return await toDoRepository.UpdateToDoItemAsync(id, toDoItem, userId);
        }
    }
}
