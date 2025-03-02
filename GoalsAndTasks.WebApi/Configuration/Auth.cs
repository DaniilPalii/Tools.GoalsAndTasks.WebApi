using GoalsAndTasks.WebApi.DataPersistence;
using GoalsAndTasks.WebApi.DataPersistence.Entities.Identity;

namespace GoalsAndTasks.WebApi.Configuration;

public static class Auth
{
	public static void Configure(WebApplicationBuilder builder)
	{
		builder.Services.AddAuthorization();
		builder.Services.AddIdentityApiEndpoints<User>()
			.AddEntityFrameworkStores<DatabaseContext>();
	}

	public static void Apply(WebApplication application)
	{
		application.MapIdentityApi<User>();
	}
}
