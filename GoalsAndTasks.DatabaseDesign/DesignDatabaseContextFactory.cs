using GoalsAndTasks.DataPersistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GoalsAndTasks.DatabaseDesign;

public sealed class DesignDatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
	public DatabaseContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

		optionsBuilder.UseSqlServer(
			builder => builder.MigrationsAssembly(typeof(DatabaseDesign.AssemblyMarker).Assembly));

		return new(optionsBuilder.Options);
	}
}
