using FastEndpoints;
using GoalsAndTasks.WebApi.Infrastructure;
using GoalsAndTasks.WebApi.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

#if AZURE
AzureDatabase.Configure(builder);
#else
DevDatabase.Configure(builder);
#endif

builder.Services.AddFastEndpoints();
Serialization.Configure(builder);
ApiReference.Configure(builder);

var application = builder.Build();

#if !AZURE
await DevDatabase.MigrateAsync(application);
#endif

application.MapFastEndpoints();
ApiReference.Map(application);
application.Map("/", () => Results.Redirect("/reference/v1"));

application.Run();
