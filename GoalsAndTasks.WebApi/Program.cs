using GoalsAndTasks.WebApi.Infrastructure;

var builder = WebApplication.CreateSlimBuilder(args);

Serialization.Configure(builder);
ApiReference.Configure(builder);

var application = builder.Build();

ApiReference.Map(application);

var sampleTodos = new Todo[]
{
    new(1, "Walk the dog"),
    new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
    new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
    new(4, "Clean the bathroom"),
    new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2))),
};

var todosApi = application.MapGroup("/todos");
todosApi.MapGet("/", () => sampleTodos);
todosApi.MapGet("/{id}", (int id) =>
    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

application.Run();

public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);
