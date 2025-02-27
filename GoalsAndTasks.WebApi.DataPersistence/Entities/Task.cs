using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoalsAndTasks.WebApi.DataPersistence.Entities;

public class Task
{
	public long Id { get; set; }

	public required string Title { get; set; }

	public DateOnly? StartDate { get; set; }

	public TimeOnly? StartTime { get; set; }

	public DateOnly? DueDate { get; set; }

	public TimeOnly? DueTime { get; set; }

	public bool IsComplete { get; set; }

	internal sealed class EntityConfiguration : IEntityTypeConfiguration<Task>
	{
		public void Configure(EntityTypeBuilder<Task> builder)
		{
			builder.HasKey(task => task.Id);

			builder.Property(task => task.Title)
				.HasMaxLength(255);
		}
	}
}
