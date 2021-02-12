using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Commands;
using API.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared;
using static API.Queries.GetTodoListQueryHandler;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly IMediator _mediator;

        public TodoController(ILogger<TodoController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoDto>> GetTodoByIdAsync(Guid id)
        {
            var query = new GetTodoByIdQuery(id);

            var todoDto = await _mediator.Send(query);

            if(todoDto == null)
            {
                return NotFound();
            }

            return Ok(todoDto);
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<TodoDto>>> GetTodoListAsync()
        {
            var todoList = await _mediator.Send(new GetTodoListQuery());

            if (!todoList.Any())
            {
                return Ok(Enumerable.Empty<TodoDto>());
            }

            return Ok(todoList);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTodoAsync(CreateTodoDto createTodoDto)
        {
            var response = await _mediator.Send(new CreateTodoCommand(createTodoDto));

            if (!response.Success)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, response);
            }

            return Ok(response);
        }
    }
}
