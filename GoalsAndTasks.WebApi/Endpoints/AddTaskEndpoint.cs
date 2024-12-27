using FastEndpoints;
using GoalsAndTasks.WebApi.DataPersistence;

namespace GoalsAndTasks.WebApi.Endpoints;

public class AddTaskEndpoint : Endpoint<TransferValues.NewTask>
{
	public override void Configure()
	{
		Post("tasks");
		AllowAnonymous();
	}

	public override async Task HandleAsync(TransferValues.NewTask task, CancellationToken cancellationToken)
	{
		var databaseContext = TryResolve<DatabaseContext>()!;

		databaseContext.Tasks.Add(new()
		{
			Title = task.Title,
			StartDate = task.StartDate,
			StartTime = task.StartTime,
			DueDate = task.DueDate,
			DueTime = task.DueTime,
			IsComplete = task.IsComplete,
		});

		await databaseContext.SaveChangesAsync(cancellationToken);

		await SendOkAsync(cancellationToken);
	}
}
