using MartinCostello.OpenApi;
using Scalar.AspNetCore;

namespace GoalsAndTasks.WebApi.Configuration;

public static class ApiReference
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
			options.WithEndpointPrefix("/reference/{documentName}");
		});

		application.Map("/", () => Results.Redirect("/reference/v1"));
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
