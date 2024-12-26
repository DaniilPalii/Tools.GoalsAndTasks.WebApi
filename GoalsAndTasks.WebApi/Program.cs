using FastEndpoints;
using GoalsAndTasks.WebApi.Configuration;
using GoalsAndTasks.WebApi.Configuration.Database;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
Serialization.Configure(builder);
ApiReference.Configure(builder);

#if AZURE
AzureDatabase.Configure(builder);
#else
DevelopmentDatabase.Configure(builder);
#endif

var application = builder.Build();
application.MapFastEndpoints();
ApiReference.Map(application);
application.MapGet("env", () => application.Environment.EnvironmentName);

#if !AZURE
await DevelopmentDatabase.MigrateAsync(application);
#endif

application.Run();
