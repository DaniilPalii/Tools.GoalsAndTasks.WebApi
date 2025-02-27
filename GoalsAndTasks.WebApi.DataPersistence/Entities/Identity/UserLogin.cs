using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoalsAndTasks.WebApi.DataPersistence.Entities.Identity;

public class UserLogin : IdentityUserLogin<long>
{
	internal sealed class EntityConfiguration : IEntityTypeConfiguration<UserLogin>
	{
		public void Configure(EntityTypeBuilder<UserLogin> builder)
		{
			builder.ToTable("UserLogins");
		}
	}
}
