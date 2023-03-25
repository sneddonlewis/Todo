using Microsoft.EntityFrameworkCore;
using Todo.Domain.Common;
using Todo.Domain.Entities;

namespace Todo.Persistence
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoDbContext).Assembly);

            modelBuilder.Entity<TodoItem>().HasData(new TodoItem
            {
                TodoItemId = Guid.NewGuid(),
                Title = "Gardening",
                Description = "Mow the lawn",
            });

            modelBuilder.Entity<TodoItem>().HasData(new TodoItem
            {
                TodoItemId = Guid.NewGuid(),
                Title = "Gardening",
                Description = "Sweep the pation",
            });

            modelBuilder.Entity<TodoItem>().HasData(new TodoItem
            {
                TodoItemId = Guid.NewGuid(),
                Title = "Gardening",
                Description = "Water the plants",
            });

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
