namespace GoalsAndTasks.WebApi.TransferValues;

public sealed record Task(
	long Id,
	string Title,
	DateOnly? StartDate,
	TimeOnly? StartTime,
	DateOnly? DueDate,
	TimeOnly? DueTime,
	bool IsComplete);
