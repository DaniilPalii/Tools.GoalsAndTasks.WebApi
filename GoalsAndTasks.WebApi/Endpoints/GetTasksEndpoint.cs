using FastEndpoints;
using GoalsAndTasks.DataPersistence;
using Microsoft.EntityFrameworkCore;

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
		var databaseContext = TryResolve<DatabaseContext>()!;

		var tasks = await databaseContext.Tasks
			.ToListAsync(cancellationToken);

		var values = tasks
			.Select(task => new TransferValues.Task(
				task.Id,
				task.Title,
				task.DueDate,
				task.IsComplete))
			.ToList();

		await SendOkAsync(values, cancellationToken);
	}
}
