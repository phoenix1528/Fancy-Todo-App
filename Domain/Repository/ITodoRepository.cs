using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface ITodoRepository
    {
        Task<Todo> GetTodoByIdAsync(Guid id);
        Task<IEnumerable<Todo>> GetTodoListAsync();
        Task CreateTodoAsync(Todo todo);
    }
}
