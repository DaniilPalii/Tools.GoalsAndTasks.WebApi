using GoalsAndTasks.WebApi.DataPersistence;
using GoalsAndTasks.WebApi.DataPersistence.Entities.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace GoalsAndTasks.WebApi.Configuration;

public static class Auth
{
	public static void Configure(WebApplicationBuilder builder)
	{
		builder.Services.AddAuthorization();

		builder.Services
			.AddIdentityApiEndpoints<User>(options =>
			{
				options.User.RequireUniqueEmail = true;
				options.SignIn.RequireConfirmedEmail = true;

				options.Password.RequiredLength = 20;
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireNonAlphanumeric = false;
			})
			.AddEntityFrameworkStores<DatabaseContext>();

		builder.Services.AddTransient<IEmailSender, EmailSender>();
		builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

		builder.Services.ConfigureApplicationCookie(o => {
			o.ExpireTimeSpan = TimeSpan.FromDays(5);
			o.SlidingExpiration = true;
		});
	}

	public static void Apply(WebApplication application)
	{
		application.MapGroup("/auth").MapIdentityApi<User>();
	}
}
