using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoalsAndTasks.WebApi.DataPersistence.Entities.Identity;

public class UserClaim : IdentityUserClaim<long>
{
	internal sealed class EntityConfiguration : IEntityTypeConfiguration<UserClaim>
	{
		public void Configure(EntityTypeBuilder<UserClaim> builder)
		{
			builder.ToTable("UserClaims");
		}
	}
}
