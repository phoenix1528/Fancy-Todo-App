using Domain.Model;
using Domain.Repository;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ILogger<TodoRepository> _logger;
        private readonly DataContext _context;

        public TodoRepository(ILogger<TodoRepository> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task CreateTodoAsync(Todo todo)
        {
            try
            {
                _context.Todos.Add(todo);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An Unexpected Error occured");
                throw;
            }
        }

        public async Task<Todo> GetTodoByIdAsync(Guid id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<IEnumerable<Todo>> GetTodoListAsync()
        {
            return await _context.Todos.ToListAsync();
        }
    }
}
