using FastEndpoints;
using GoalsAndTasks.WebApi.Configuration;
using GoalsAndTasks.WebApi.Configuration.Database;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
Serialization.Configure(builder);
ApiReference.Configure(builder);

#if AZURE
{
	AzureDatabase.Configure(builder);
	Cors.ConfigureSpecificOrigins(builder);
}
#else
{
	DevelopmentDatabase.Configure(builder);
	Cors.ConfigureAnyOrigin(builder);
}
#endif

var application = builder.Build();
application.MapFastEndpoints();
ApiReference.Map(application);
Cors.Apply(application);

#if !AZURE
{
	await DevelopmentDatabase.MigrateAsync(application);
}
#endif

application.Run();
