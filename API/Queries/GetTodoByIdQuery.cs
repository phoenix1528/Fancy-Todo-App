using MediatR;
using Shared;
using System;

namespace API.Queries
{
    public class GetTodoByIdQuery : IRequest<TodoDto>
    {
        public Guid Id { get; private set; }

        public GetTodoByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
