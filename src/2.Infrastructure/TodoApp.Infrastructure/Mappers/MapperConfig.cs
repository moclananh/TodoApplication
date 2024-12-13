using AutoMapper;
using TodoApp.Domain.Models.Entities;
using TodoApp.Domain.Models.Enums;
using TodoApp.Infrastructure.Dtos.TodoDtos;
using TodoApp.Infrastructure.Dtos.UserDtos;

namespace TodoApp.Infrastructure.Mappers
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<LoginVm, User>().ReverseMap();

            CreateMap<TodoVm, Todo>()
              .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<TodoStatus>(src.Status)));  // Ensure mapping from string to enum

            CreateMap<Todo, TodoVm>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));  // Ensure mapping from enum to string
        }
    }
}
