using AutoMapper;
using Domain.Model;
using Domain.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands
{
    public class EditTodoCommandHandler
    {
        public readonly ILogger<EditTodoCommandHandler> _logger;
        public readonly IMapper _mapper;
        public readonly ITodoRepository _repository;

        public CreateTodoCommandHandler(ILogger<EditTodoCommandHandler> logger, IMapper mapper, ITodoRepository repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CommandResponse> Handle(EditTodoCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Handle {nameof(EditTodoCommand)}");

            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            try
            {
                var todo = _mapper.Map<Todo>(request);

                await _repository.UpdateTodoAsync(todo);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Database operation failed");
                return new CommandResponse("ERROR: Database operation failed", false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected Error occured.");
                return new CommandResponse("An unexpected Error occured.", false);
            }

            return new CommandResponse("Todo was created", true);
        }
    }
}
