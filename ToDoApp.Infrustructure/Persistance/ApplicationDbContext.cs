using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>()
                        .HasOne(t => t.Category)
                        .WithMany(c => c.Tasks)
                        .HasForeignKey(t => t.CategoryId)
                        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
