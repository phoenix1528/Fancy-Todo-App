using AutoMapper;
using Domain.Model;
using Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries
{
    public class GetTodoListQueryHandler : IRequestHandler<GetTodoListQuery, IEnumerable<TodoDto>>
    {
        private readonly ILogger<GetTodoListQueryHandler> _logger;
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper;

        public GetTodoListQueryHandler(ITodoRepository repository, ILogger<GetTodoListQueryHandler> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<TodoDto>> Handle(GetTodoListQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            _logger.LogDebug($"Handle {nameof(GetTodoByIdQuery)}");

            var todoList = await _repository.GetTodoListAsync().ConfigureAwait(false);
            if (!todoList.Any())
            {
                _logger.LogError("No todos could be found.");
                return Enumerable.Empty<TodoDto>();
            }

            return _mapper.Map<IEnumerable<TodoDto>>(todoList);
        }
    }
}
