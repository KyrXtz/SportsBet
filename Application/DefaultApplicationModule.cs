using Module = Autofac.Module;

namespace SportsBet.Application
{
    public class DefaultApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            builder
                .RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(typeof(IThreadSafetyGuard<>));

            builder
                .RegisterGeneric(typeof(ErroredCommandBehavior<,>))
                .As(typeof(IPipelineBehavior<,>));
            builder
                .RegisterGeneric(typeof(LoggingBehavior<,>))
                .As(typeof(IPipelineBehavior<,>));
            builder
                .RegisterGeneric(typeof(ValidatorBehavior<,>))
                .As(typeof(IPipelineBehavior<,>));
            builder
                .RegisterGeneric(typeof(ThreadSafetyBehavior<,>))
                .As(typeof(IPipelineBehavior<,>));
            builder
                .RegisterGeneric(typeof(CommandMetricsBehavior<,>))
                .As(typeof(IPipelineBehavior<,>));
            builder
                .RegisterGeneric(typeof(QueryMetricsBehavior<,>))
                .As(typeof(IPipelineBehavior<,>));
            builder
                .RegisterType<ApplicationMetrics>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder
                .RegisterGenericDecorator(typeof(EventLoggingDecorator<>), typeof(INotificationHandler<>));
            builder
                .RegisterGenericDecorator(typeof(IntegrationEventOutboxItemDecorator<>), typeof(INotificationHandler<>));
        }
    }
}
