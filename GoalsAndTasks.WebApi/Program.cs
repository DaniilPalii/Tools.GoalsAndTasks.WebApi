using GoalsAndTasks.WebApi.Configuration;
using GoalsAndTasks.WebApi.Configuration.Database;

var builder = WebApplication.CreateBuilder(args);
{
	Endpoints.Configure(builder);
	Serialization.Configure(builder);
	ApiReference.Configure(builder);
	Auth.Configure(builder);

#if AZURE
	AzureDatabase.Configure(builder);
	Cors.ConfigureSpecificOrigins(builder);
#else
	DevelopmentDatabase.Configure(builder);
	Cors.ConfigureAnyOrigin(builder);
#endif
}

var application = builder.Build();
{
	Endpoints.Map(application);
	ApiReference.Map(application);
	Cors.Apply(application);
	Auth.Apply(application);

#if !AZURE
	await DevelopmentDatabase.MigrateAsync(application);
#endif
}

application.Run();
