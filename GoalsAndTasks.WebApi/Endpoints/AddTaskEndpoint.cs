using FastEndpoints;
using GoalsAndTasks.WebApi.DataPersistence;

namespace GoalsAndTasks.WebApi.Endpoints;

public class AddTaskEndpoint : Endpoint<TransferValues.NewTask, TransferValues.Task>
{
	public override void Configure()
	{
		Post("tasks");
		AllowAnonymous();
	}

	public override async Task HandleAsync(TransferValues.NewTask task, CancellationToken cancellationToken)
	{
		var databaseContext = TryResolve<DatabaseContext>()!;

		var addedTaskEntry = databaseContext.Tasks.Add(new()
		{
			Title = task.Title,
			StartDate = task.StartDate,
			StartTime = task.StartTime,
			DueDate = task.DueDate,
			DueTime = task.DueTime,
			IsComplete = task.IsComplete,
		});

		await databaseContext.SaveChangesAsync(cancellationToken);

		var addedTask = new TransferValues.Task(
			Id: addedTaskEntry.Entity.Id,
			Title: addedTaskEntry.Entity.Title,
			StartDate: addedTaskEntry.Entity.StartDate,
			StartTime: addedTaskEntry.Entity.StartTime,
			DueDate: addedTaskEntry.Entity.DueDate,
			DueTime: addedTaskEntry.Entity.DueTime,
			IsComplete: addedTaskEntry.Entity.IsComplete);

		await SendOkAsync(addedTask, cancellationToken);
	}
}
