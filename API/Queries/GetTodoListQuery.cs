using MediatR;
using Shared;
using System.Collections.Generic;

namespace API.Queries
{
    public class GetTodoListQuery : IRequest<IEnumerable<TodoDto>> { }
}
