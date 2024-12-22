using FastEndpoints;
using GoalsAndTasks.WebApi.Infrastructure;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddFastEndpoints();
Database.Configure(builder);
Serialization.Configure(builder);
ApiReference.Configure(builder);

var application = builder.Build();

#if !PRODUCTION
await Database.MigrateAsync(application);
#endif

application.MapFastEndpoints();
ApiReference.Map(application);
application.Map("/", () => Results.Redirect("/reference/v1"));

application.Run();
