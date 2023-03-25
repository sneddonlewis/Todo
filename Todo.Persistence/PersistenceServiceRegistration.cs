using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Contracts.Persistence;
using Todo.Persistence.Repositories;

namespace Todo.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("TodoConnectionString"));
            });
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ITodoItemRepository, TodoItemRepository>();
            return services;
        }
    }
}
