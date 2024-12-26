#if AZURE

using GoalsAndTasks.DataPersistence;
using Microsoft.EntityFrameworkCore;

namespace GoalsAndTasks.WebApi.Configuration.Database;

public static class AzureDatabase
{
	public static void Configure(WebApplicationBuilder builder)
	{
		builder.Services.AddDbContext<DatabaseContext>(ConfigureDatabaseContext);
	}

	private static void ConfigureDatabaseContext(DbContextOptionsBuilder dbContextOptions)
	{
		var connectionString = GetConnectionString();

		dbContextOptions.UseSqlServer(
			connectionString,
			sqlServerOptions =>
			{
				sqlServerOptions.EnableRetryOnFailure(maxRetryCount: 10);
			});
	}

	private static string GetConnectionString()
	{
		return Environment.GetEnvironmentVariable("SQLCONNSTR_AzureDatabase")!;
	}
}

#endif // AZURE
