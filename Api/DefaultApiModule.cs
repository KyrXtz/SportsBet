namespace SportsBet.Api;

public class DefaultApiModule : Module
{
	protected override void Load(ContainerBuilder builder)
	{
		var assemblies = AppDomain.CurrentDomain.GetAssemblies();

		var configuration = MediatRConfigurationBuilder
			.Create(assemblies)
			.WithAllOpenGenericHandlerTypesRegistered()
			.Build();

		builder.RegisterMediatR(configuration);
	}
}