using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoalsAndTasks.WebApi.DataPersistence.Entities.Identity;

public class UserRole : IdentityUserRole<long>
{
	internal sealed class EntityConfiguration : IEntityTypeConfiguration<UserRole>
	{
		public void Configure(EntityTypeBuilder<UserRole> builder)
		{
			builder.ToTable("UserRoles");
		}
	}
}
