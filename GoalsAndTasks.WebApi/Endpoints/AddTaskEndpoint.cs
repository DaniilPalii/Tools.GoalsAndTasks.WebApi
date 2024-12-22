using FastEndpoints;
using GoalsAndTasks.DataPersistence;

namespace GoalsAndTasks.WebApi.Endpoints;

public class AddTaskEndpoint : Endpoint<TransferValues.Task>
{
	public override void Configure()
	{
		Post("tasks");
		AllowAnonymous();
	}

	public override async Task HandleAsync(TransferValues.Task task, CancellationToken cancellationToken)
	{
		var databaseContext = TryResolve<DatabaseContext>()!;

		databaseContext.Tasks.Add(new()
		{
			Title = task.Title,
			DueDate = task.DueDate,
			IsComplete = task.IsComplete,
		});

		await databaseContext.SaveChangesAsync(cancellationToken);

		await SendOkAsync(cancellationToken);
	}
}
