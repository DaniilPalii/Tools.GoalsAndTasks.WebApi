using FastEndpoints;

namespace GoalsAndTasks.WebApi.Endpoints;

public class GetTasksEndpoint : EndpointWithoutRequest<List<TransferValues.Task>>
{
	public override void Configure()
	{
		Get("tasks");
		AllowAnonymous();
	}

	public override async Task HandleAsync(CancellationToken cancellationToken)
	{
		var tasks = new List<TransferValues.Task>
		{
			new(1, "Walk the dog"),
			new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
			new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
			new(4, "Clean the bathroom"),
			new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2))),
		};

		await SendOkAsync(tasks, cancellationToken);
	}
}
