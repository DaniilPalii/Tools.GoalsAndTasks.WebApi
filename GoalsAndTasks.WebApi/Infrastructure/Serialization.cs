using System.Text.Json.Serialization;

namespace GoalsAndTasks.WebApi.Infrastructure;

internal static class Serialization
{
	public static void Configure(IHostApplicationBuilder builder)
	{
		builder.Services.ConfigureHttpJsonOptions(options =>
		{
			options.SerializerOptions.TypeInfoResolverChain.Insert(index: 0, AppJsonSerializerContext.Default);
		});
	}
}

[JsonSerializable(typeof(Todo[]))]
internal sealed partial class AppJsonSerializerContext : JsonSerializerContext
{ }
