using GoalsAndTasks.DataPersistence;
using Microsoft.EntityFrameworkCore;

#if !PRODUCTION
using GoalsAndTasks.DatabaseDesign;
#endif

namespace GoalsAndTasks.WebApi.Infrastructure;

public static class Database
{
	public static void Configure(WebApplicationBuilder builder)
	{
		builder.Services.AddDbContext<DatabaseContext>();

#if !PRODUCTION
		builder.Services.AddDbContext<DesignDatabaseContext>();
#endif
	}

#if !PRODUCTION
	public static async Task MigrateAsync(WebApplication application)
	{
		await using var serviceScope = application.Services.CreateAsyncScope();
		await using var designDatabaseContext = serviceScope.ServiceProvider
			.GetRequiredService<DesignDatabaseContext>();

		await designDatabaseContext.Database.MigrateAsync();
	}
#endif

}
