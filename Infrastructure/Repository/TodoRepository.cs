using Domain.Model;
using Domain.Repository;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ILogger<TodoRepository> _logger;
        private readonly DataContext _context;
        private IDbContextTransaction? _transaction;

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

        public async Task StartTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task EndTransactionAsync()
        {
            await _context.SaveChangesAsync();

            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
        }

        public async Task DeleteTodoAsync(Guid id)
        {
            var todoToDelete = await _context.Todos.FindAsync(id);

            if(todoToDelete == null)
            {
                throw new Exception($"Todo with Id [{id}] was not found");
            }

            _context.Remove(todoToDelete);

            await _context.SaveChangesAsync();
        }
    }
}
