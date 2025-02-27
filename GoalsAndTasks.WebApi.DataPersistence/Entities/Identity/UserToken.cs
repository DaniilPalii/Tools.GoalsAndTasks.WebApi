using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoalsAndTasks.WebApi.DataPersistence.Entities.Identity;

public class UserToken : IdentityUserToken<long>
{
	internal sealed class EntityConfiguration : IEntityTypeConfiguration<UserToken>
	{
		public void Configure(EntityTypeBuilder<UserToken> builder)
		{
			builder.ToTable("UserTokens");
		}
	}
}
