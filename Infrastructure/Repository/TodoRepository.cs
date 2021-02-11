using Domain.Model;
using Domain.Repository;
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

        public async Task<Todo> GetTodoByIdAsync(Guid id)
        {
            return await _context.Todos.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Todo>> GetTodoListAsync()
        {
            return await _context.Todos.ToListAsync().ConfigureAwait(false);
        }
    }
}
