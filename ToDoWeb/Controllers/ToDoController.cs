using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoWeb.Models.Domain;
using ToDoWeb.Models.DTO;
using ToDoWeb.Repositories.Services;

namespace ToDoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : Controller
    {
        private readonly IToDoService service;
        private readonly IMapper mapper;

        public ToDoController(IToDoService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        private string? GetUserId()
        {
            return User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? isCompleted, [FromQuery] string? priority,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Người dùng chưa đăng nhập!");

            var toDoDomainModel = await service.GetAllToDoListAsync(userId, isCompleted, priority, pageNumber, pageSize);

            var toDoDto = mapper.Map<List<GetAllDTO>>(toDoDomainModel);
            return Ok(toDoDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Người dùng chưa đăng nhập!");

            var toDoDomainModel = await service.GetToDoByIdAsync(id, userId);
            if (toDoDomainModel == null)
            {
                return NotFound("Can not found your to do");
            }

            var toDoDto = mapper.Map<CreateToDoRequestDTO>(toDoDomainModel);
            return Ok(toDoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateToDoRequestDTO createToDoRequestDTO)
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Người dùng chưa đăng nhập!");

            var toDoDomain = mapper.Map<ToDoItem>(createToDoRequestDTO);

            toDoDomain = await service.CreateToDoItemAsync(toDoDomain, userId);

            var toDoDto = mapper.Map<CreateToDoRequestDTO>(toDoDomain);
            return Ok(toDoDto);
        }

        [HttpPost]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateToDoRequestDTO updateToDoRequestDTO)
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Người dùng chưa đăng nhập!");

            var toDoDomainModel = mapper.Map<ToDoItem>(updateToDoRequestDTO);
            
            toDoDomainModel = await service.UpdateToDoItemAsync(id, toDoDomainModel, userId);
            if (toDoDomainModel == null)
            {
                return NotFound(new { message = "Can not found to do" });
            }
            var toDoDto = mapper.Map<UpdateToDoRequestDTO>(toDoDomainModel);
            return Ok(toDoDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var userId = GetUserId();
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Người dùng chưa đăng nhập!");

            var toDoDomainModel = await service.DeleteToDoItemAsync(id, userId);
            if (toDoDomainModel == null)
            {
                return NotFound(new { message = "Can not found to do" });
            }

            return Ok(new { message = "Delete Successfully" });
        }
    }
}
