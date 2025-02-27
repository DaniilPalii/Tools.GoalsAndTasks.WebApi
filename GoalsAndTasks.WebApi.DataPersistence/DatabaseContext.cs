using GoalsAndTasks.WebApi.DataPersistence.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task = GoalsAndTasks.WebApi.DataPersistence.Entities.Task;

namespace GoalsAndTasks.WebApi.DataPersistence;

public class DatabaseContext(DbContextOptions<DatabaseContext> options)
	: IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>(options)
{
	public virtual DbSet<Task> Tasks { get; set; }

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
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfiguration(new Role.EntityConfiguration());
		modelBuilder.ApplyConfiguration(new RoleClaim.EntityConfiguration());
		modelBuilder.ApplyConfiguration(new User.EntityConfiguration());
		modelBuilder.ApplyConfiguration(new UserClaim.EntityConfiguration());
		modelBuilder.ApplyConfiguration(new UserLogin.EntityConfiguration());
		modelBuilder.ApplyConfiguration(new UserRole.EntityConfiguration());
		modelBuilder.ApplyConfiguration(new UserToken.EntityConfiguration());

		modelBuilder.ApplyConfiguration(new Task.EntityConfiguration());
	}
}
