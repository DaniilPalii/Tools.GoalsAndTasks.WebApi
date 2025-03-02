using FastEndpoints;

namespace GoalsAndTasks.WebApi.Configuration;

public static class Endpoints
{
	public static void Configure(WebApplicationBuilder builder)
	{
		builder.Services.AddFastEndpoints();
	}

	public static void Map(WebApplication application)
	{
		application.MapFastEndpoints();
	}
}
