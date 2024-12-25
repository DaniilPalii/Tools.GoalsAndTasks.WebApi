using GoalsAndTasks.DataPersistence;
using Microsoft.EntityFrameworkCore;

namespace GoalsAndTasks.WebApi.Infrastructure;

public static class Database
{
	public static void Configure(WebApplicationBuilder builder)
	{
		builder.Services.AddDbContext<DatabaseContext>(ConfigureDatabaseContext);
	}

#if !PRODUCTION
	public static async Task MigrateAsync(WebApplication application)
	{
		await using var serviceScope = application.Services.CreateAsyncScope();
		await using var designDatabaseContext = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();

		await designDatabaseContext.Database.MigrateAsync();
	}
#endif

	private static void ConfigureDatabaseContext(IServiceProvider services, DbContextOptionsBuilder options)
	{
		var configuration = services.GetRequiredService<IConfiguration>();
		var connectionString = configuration.GetConnectionString("Database");

		options.UseSqlServer(
			connectionString,
			builder =>
			{
#if !PRODUCTION
				builder.MigrationsAssembly(typeof(DatabaseDesign.AssemblyMarker).Assembly);
#endif
				builder.EnableRetryOnFailure(maxRetryCount: 5);
			});
	}
}
