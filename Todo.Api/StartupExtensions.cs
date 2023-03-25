using Microsoft.EntityFrameworkCore;
using Todo.Application;
using Todo.Infrastructure;
using Todo.Persistence;

namespace Todo.Api;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddPersistenceServices(builder.Configuration);

        builder.Services.AddControllers();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("Open", policyBuilder => policyBuilder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
        });

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors("Open");
        app.MapControllers();

        return app;
    }

    public static async Task ResetDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        try
        {
            TodoDbContext context = scope.ServiceProvider.GetService<TodoDbContext>();
            await context.Database.EnsureDeletedAsync();
            await context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            // do some logging
        }
    }
}