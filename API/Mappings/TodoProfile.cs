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
        }
    }
}
