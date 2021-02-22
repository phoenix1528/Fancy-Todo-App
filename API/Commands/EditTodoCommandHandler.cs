using AutoMapper;
using Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands
{
    public class EditTodoCommandHandler : IRequestHandler<EditTodoCommand, CommandResponse>
    {
        public readonly ILogger<EditTodoCommandHandler> _logger;
        public readonly IMapper _mapper;
        public readonly ITodoRepository _repository;

        public EditTodoCommandHandler(ILogger<EditTodoCommandHandler> logger, IMapper mapper, ITodoRepository repository)
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
                await _repository.StartTransactionAsync();

                var todoToUpdate = await _repository.GetTodoByIdAsync(request.Id);

                _mapper.Map(request, todoToUpdate);

                await _repository.EndTransactionAsync();
            }
            catch (TodoValidationException ex)
            {
                _logger.LogError(ex, "Input validation failed, todo could not be created.");
                return new CommandResponse("Input validation failed, todo could not be created.", false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected Error occured.");
                return new CommandResponse("An unexpected Error occured.", false);
            }

            return new CommandResponse("Todo was edited", true);
        }
    }
}
