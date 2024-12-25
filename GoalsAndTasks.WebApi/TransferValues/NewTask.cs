namespace GoalsAndTasks.WebApi.TransferValues;

public sealed record NewTask(
	string Title,
	DateOnly? StartDate,
	TimeOnly? StartTime,
	DateOnly? DueDate,
	TimeOnly? DueTime,
	bool IsComplete);
