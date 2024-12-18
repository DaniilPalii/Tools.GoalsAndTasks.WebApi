using System.Text.Json.Serialization;
using Task = GoalsAndTasks.WebApi.TransferValues.Task;

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

[JsonSerializable(typeof(Task[]))]
internal sealed partial class AppJsonSerializerContext : JsonSerializerContext;
