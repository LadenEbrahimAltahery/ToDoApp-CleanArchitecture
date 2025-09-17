using Microsoft.EntityFrameworkCore;
using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Entities;
using ToDoApp.Infrastructure.Persistence;

namespace ToDoApp.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories
                                 .Include(c => c.Tasks)
                                 .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories
                                 .Include(c => c.Tasks)
                                 .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Category entity)
        {
            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Categories.FindAsync(id);
            if (entity != null)
            {
                _context.Categories.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
