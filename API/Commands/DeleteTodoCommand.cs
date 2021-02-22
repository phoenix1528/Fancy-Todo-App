using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Commands
{
    public class DeleteTodoCommand : IRequest<CommandResponse>
    {
        public Guid Id { get; private set; }

        public DeleteTodoCommand(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException(nameof(id));
            }

            Id = id;
        }
    }
}
