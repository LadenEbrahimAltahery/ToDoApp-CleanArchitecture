using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Entities;
using ToDoApp.Infrastructure.Persistence;

namespace ToDoApp.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TaskItem entity)
        {
            await _context.Tasks.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _context.Tasks
                                 .Include(t => t.Category)
                                 .ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _context.Tasks
                                 .Include(t => t.Category)
                                 .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(TaskItem entity)
        {
            _context.Tasks.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Tasks.FindAsync(id);
            if (entity != null)
            {
                _context.Tasks.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
