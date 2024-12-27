using Microsoft.EntityFrameworkCore;

namespace GoalsAndTasks.WebApi.DataPersistence;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
	public virtual DbSet<Entities.Task> Tasks { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

#if DEBUG
		optionsBuilder.EnableSensitiveDataLogging();
		optionsBuilder.EnableDetailedErrors();
#endif
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new Entities.Task.Configuration());
	}
}
