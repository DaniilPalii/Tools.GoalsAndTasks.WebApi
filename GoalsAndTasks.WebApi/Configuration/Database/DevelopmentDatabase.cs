#if !AZURE

using GoalsAndTasks.DataPersistence;
using Microsoft.EntityFrameworkCore;

namespace GoalsAndTasks.WebApi.Configuration.Database;

public static class DevelopmentDatabase
{
	public static void Configure(WebApplicationBuilder builder)
	{
		builder.Services.AddDbContext<DatabaseContext>(ConfigureDatabaseContext);
	}

	public static async Task MigrateAsync(WebApplication application)
	{
		await using var serviceScope = application.Services.CreateAsyncScope();
		await using var databaseContext = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();

		await databaseContext.Database.MigrateAsync();
	}

	private static void ConfigureDatabaseContext(IServiceProvider services, DbContextOptionsBuilder dbContextOptions)
	{
		var connectionString = GetConnectionString(services);

		dbContextOptions.UseSqlServer(
			connectionString,
			sqlServerOptions =>
			{
				sqlServerOptions.MigrationsAssembly(DatabaseDesign.Assembly.Name);
			});
	}

	private static string? GetConnectionString(IServiceProvider services)
	{
		var configuration = services.GetRequiredService<IConfiguration>();
		return configuration.GetConnectionString("DevelopmentDatabase");
	}
}

#endif // !AZURE
