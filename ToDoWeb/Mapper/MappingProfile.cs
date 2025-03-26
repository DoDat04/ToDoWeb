using AutoMapper;
using ToDoWeb.Models.Domain;
using ToDoWeb.Models.DTO;

namespace ToDoWeb.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDoItem, CreateToDoRequestDTO>().ReverseMap();
            CreateMap<ToDoItem, UpdateToDoRequestDTO>().ReverseMap();
            CreateMap<ToDoItem, GetAllDTO>().ReverseMap();
        }        
    }
}
