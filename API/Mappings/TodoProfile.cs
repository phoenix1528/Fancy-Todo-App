using API.Commands;
using AutoMapper;
using Domain.Model;
using Shared;

namespace API.Mappings
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<Todo, TodoDto>()
                .ReverseMap();

            CreateMap<CreateTodoCommand, Todo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<EditTodoCommand, Todo>();
        }
    }
}
