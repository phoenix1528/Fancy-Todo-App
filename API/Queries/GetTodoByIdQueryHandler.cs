using Microsoft.Extensions.Logging;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Repository;
using Shared;
using AutoMapper;
using Domain.Model;

namespace API.Queries
{
    public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, TodoDto>
    {
        private readonly ILogger<GetTodoByIdQueryHandler> _logger;
        private readonly ITodoRepository _repository;
        private readonly IMapper _mapper;

        public GetTodoByIdQueryHandler(ITodoRepository repository, ILogger<GetTodoByIdQueryHandler> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TodoDto> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            _logger.LogDebug($"Handle {nameof(GetTodoByIdQuery)}");

            var todo = await _repository.GetTodoByIdAsync(request.Id);
            if (todo == null)
            {
                _logger.LogError("No todo with id [{TodoId}] could be found.", request.Id);
                return null;
            }

            return _mapper.Map<TodoDto>(todo);
        }
    }
}
