using AutoMapper;
using Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, CommandResponse>
    {
        public readonly ILogger<DeleteTodoCommandHandler> _logger;
        public readonly IMapper _mapper;
        public readonly ITodoRepository _repository;

        public DeleteTodoCommandHandler(ILogger<DeleteTodoCommandHandler> logger, IMapper mapper, ITodoRepository repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CommandResponse> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Handle {nameof(DeleteTodoCommand)}");

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            try
            {
                await _repository.DeleteTodoAsync(request.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new CommandResponse(ex.Message, false);
            }

            return new CommandResponse("Todo was deleted", true);
        }
    }
}
