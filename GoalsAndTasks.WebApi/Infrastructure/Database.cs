using GoalsAndTasks.DataPersistence;
using Microsoft.EntityFrameworkCore;

namespace GoalsAndTasks.WebApi.Infrastructure;

public static class Database
{
	public static void Configure(WebApplicationBuilder builder)
	{
		builder.Services.AddDbContext<DatabaseContext>(ConfigureDatabaseContext);
	}

#if !AZURE
	public static async Task MigrateAsync(WebApplication application)
	{
		await using var serviceScope = application.Services.CreateAsyncScope();
		await using var databaseContext = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();

		await databaseContext.Database.MigrateAsync();
	}
#endif

	private static void ConfigureDatabaseContext(IServiceProvider services, DbContextOptionsBuilder options)
	{
		var configuration = services.GetRequiredService<IConfiguration>();
		var connectionString =
#if !AZURE
			configuration.GetConnectionString("Database");
#else
			Environment.GetEnvironmentVariable("SQLCONNSTR_Database");
#endif

		options.UseSqlServer(
			connectionString,
			builder =>
			{
#if !AZURE
				builder.MigrationsAssembly(DatabaseDesign.Assembly.Name);
#endif
				builder.EnableRetryOnFailure(maxRetryCount: 10);
			});
	}
}
