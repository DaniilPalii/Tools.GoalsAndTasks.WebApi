using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoalsAndTasks.DataPersistence.Entities;

public class Task
{
	public long Id { get; set; }

	public required string Title { get; set; }

	public DateOnly? DueDate { get; set; }

	public bool IsComplete { get; set; }

	internal sealed class Configuration : IEntityTypeConfiguration<Task>
	{
		public void Configure(EntityTypeBuilder<Task> builder)
		{
			builder.HasKey(task => task.Id);

			builder.Property(task => task.Title)
				.HasMaxLength(255);
		}
	}
}
