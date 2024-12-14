using MartinCostello.OpenApi;
using Scalar.AspNetCore;

namespace GoalsAndTasks.WebApi.Infrastructure;

public static class ApiDocumentation
{
	public static void Configure(IHostApplicationBuilder builder)
	{
		builder.Services.AddOpenApi();
		EnforceAddingServerUrlToOpenApi(builder);
	}

	public static void Map(WebApplication application)
	{
		application.MapOpenApi();
		application.MapScalarApiReference(options =>
		{
			options.WithEndpointPrefix("/documentation/{documentName}");
		});
	}

	/// <summary>Fixes lack of server URL in OpenAPI when the application is hosted on Azure.</summary>
	private static void EnforceAddingServerUrlToOpenApi(IHostApplicationBuilder builder)
	{
		builder.Services.AddOpenApiExtensions(options =>
		{
			options.AddServerUrls = true;
		});

		builder.Services.AddHttpContextAccessor();
	}
}
