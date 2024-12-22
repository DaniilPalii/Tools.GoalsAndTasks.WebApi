namespace GoalsAndTasks.WebApi.TransferValues;

public sealed record Task(
	long Id,
	string Title,
	DateOnly? DueDate = null,
	bool IsComplete = false);
