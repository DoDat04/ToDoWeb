using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoWeb.Data;
using ToDoWeb.Models.Domain;

namespace ToDoWeb.Repositories.Interface
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly AppDbContext appDbContext;

        public ToDoRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ToDoItem> CreateToDoItemAsync(ToDoItem toDoItem, string userId)
        {
            toDoItem.UserId = userId; // Gán UserId từ token
            appDbContext.ToDoItems.Add(toDoItem);
            await appDbContext.SaveChangesAsync();
            return toDoItem;
        }

        public async Task<ToDoItem?> DeleteToDoItemAsync(Guid id, string userId)
        {
            var existingToDo = await appDbContext.ToDoItems.FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
            if (existingToDo == null)
            {
                return null;
            }

            appDbContext.ToDoItems.Remove(existingToDo);
            await appDbContext.SaveChangesAsync();
            return existingToDo;
        }

        public async Task<List<ToDoItem>> GetAllToDoListAsync(string userId)
        {
            return await appDbContext.ToDoItems.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<ToDoItem?> GetToDoByIdAsync(Guid id, string userId)
        {
            // firstordefault: tự động trả về null nếu không tìm thấy
            return await appDbContext.ToDoItems
                .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
        }


        public async Task<ToDoItem?> UpdateToDoItemAsync(Guid id, ToDoItem toDoItem, string userId)
        {
            var existingToDo = await appDbContext.ToDoItems
                .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (existingToDo == null)
            {
                return null; 
            }

            existingToDo.Title = toDoItem.Title;
            existingToDo.Description = toDoItem.Description;
            existingToDo.IsCompleted = toDoItem.IsCompleted;
            existingToDo.DueDate = toDoItem.DueDate;
            existingToDo.Priority = toDoItem.Priority;

            await appDbContext.SaveChangesAsync();
            return existingToDo;
        }
    }
}
