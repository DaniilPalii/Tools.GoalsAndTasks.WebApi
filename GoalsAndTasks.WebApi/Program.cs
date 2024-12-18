using FastEndpoints;
using GoalsAndTasks.WebApi.Infrastructure;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddFastEndpoints();
Serialization.Configure(builder);
ApiReference.Configure(builder);

var application = builder.Build();

application.MapFastEndpoints();
ApiReference.Map(application);

application.Run();
