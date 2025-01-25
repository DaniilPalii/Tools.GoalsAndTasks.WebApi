namespace GoalsAndTasks.WebApi.Configuration;

public static class Cors
{
	public static void ConfigureAnyOrigin(WebApplicationBuilder builder)
	{
		builder.Services.AddCors(
			options => options.AddDefaultPolicy(
				policy => policy.AllowAnyOrigin()));
	}

	public static void ConfigureSpecificOrigins(WebApplicationBuilder builder)
	{
		var origins = builder.Configuration
			.GetSection("Cors:AllowedOrigins")
			.Get<string[]>()!;

		builder.Services.AddCors(
			options => options.AddDefaultPolicy(
				policy => policy.WithOrigins(origins)));
	}

	public static void Apply(WebApplication application)
	{
		application.UseCors();
	}
}
