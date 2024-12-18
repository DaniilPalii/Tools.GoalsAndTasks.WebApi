namespace GoalsAndTasks.WebApi.TransferValues;

public sealed record Task(
	long Id,
	string Title,
	DateOnly? DueBy = null,
	bool IsComplete = false);
