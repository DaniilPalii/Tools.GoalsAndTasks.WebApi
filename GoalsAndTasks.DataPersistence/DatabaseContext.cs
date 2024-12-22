using Microsoft.EntityFrameworkCore;

namespace GoalsAndTasks.DataPersistence;

public class DatabaseContext : DbContext
{
	public virtual DbSet<Entities.Task> Tasks { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=localhost;Database=GoalsAndTasks;Trusted_Connection=True;TrustServerCertificate=True;");

		optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new Entities.Task.Configuration());
	}
}
