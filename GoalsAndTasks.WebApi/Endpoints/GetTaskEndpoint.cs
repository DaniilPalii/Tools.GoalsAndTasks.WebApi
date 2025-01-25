using FastEndpoints;
using GoalsAndTasks.WebApi.DataPersistence;
using Microsoft.EntityFrameworkCore;

namespace GoalsAndTasks.WebApi.Endpoints;

public class GetTaskEndpoint : EndpointWithoutRequest<TransferValues.Task>
{
	public override void Configure()
	{
		Get("tasks/{id:long}");
		AllowAnonymous();
	}

	public override async Task HandleAsync(CancellationToken cancellationToken)
	{
		var id = Route<long>("id");

		var databaseContext = TryResolve<DatabaseContext>()!;

		var task = await databaseContext.Tasks
			.Where(task => task.Id == id)
			.FirstOrDefaultAsync(cancellationToken);

		if (task is null)
		{
			await SendNotFoundAsync(cancellationToken);
			return;
		}

		var value = new TransferValues.Task(
			Id: task.Id,
			Title: task.Title,
			StartDate: task.StartDate,
			StartTime: task.StartTime,
			DueDate: task.DueDate,
			DueTime: task.DueTime,
			IsComplete: task.IsComplete);

		await SendOkAsync(value, cancellationToken);
	}
}
