using Scalar.AspNetCore;

namespace GoalsAndTasks.WebApi.Infrastructure;

public static class ApiDocumentation
{
	public static void Configure(IHostApplicationBuilder builder)
	{
		builder.Services.AddOpenApi();
	}

	public static void Map(WebApplication application)
	{
		application.MapOpenApi();

		application.MapScalarApiReference(options =>
		{
			options.WithEndpointPrefix("/documentation/{documentName}");
		});
	}
}
