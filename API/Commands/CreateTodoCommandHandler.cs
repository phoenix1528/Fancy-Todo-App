using AutoMapper;
using Domain.Model;
using Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, CommandResponse>
    {
        public readonly ILogger<CreateTodoCommandHandler> _logger;
        public readonly IMapper _mapper;
        public readonly ITodoRepository _repository;

        public CreateTodoCommandHandler(ILogger<CreateTodoCommandHandler> logger, IMapper mapper, ITodoRepository repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CommandResponse> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Handle {nameof(CreateTodoCommand)}");

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            try
            {
                var todo = _mapper.Map<Todo>(request);

                await _repository.CreateTodoAsync(todo);
            }
            catch (TodoValidationException ex)
            {
                _logger.LogError(ex, "Todo could not be created because the validation failed");
                return new CommandResponse("ERROR: Todo could not be created because the validation failed.", false);            
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Could not create todo.");
                return new CommandResponse("ERROR: Could not create todo.", false);
            }

            return new CommandResponse("Todo was created", true);
        }
    }
}
