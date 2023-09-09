using Module = Autofac.Module;

namespace SportsBet.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAutoMapper(typeof(DefaultInfrastructureModule).Assembly);
            
            RegisterContext<AppDbContext>(builder);
            
            builder.RegisterGeneric(typeof(EfRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();
            
            builder.RegisterType<MediatorHandler>()
                .As<IMediatorHandler>()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(FeedQueuePublisher<>))
                .As(typeof(IFeedQueuePublisher<>))
                .SingleInstance();

            builder
                .RegisterType<InfrastructureMetrics>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder
                .RegisterType<EventCodesRetrievalService>()
                .As<IEventCodesRetrievalService>()
                .SingleInstance();

            builder
                .RegisterType<SerializationService>()
                .As<ISerializationService>()
                .SingleInstance();

            builder.Register(componentContext =>
            {
                var configuration = componentContext.Resolve<IConfiguration>();

                return new SqlDistributedSynchronizationProvider(configuration.GetSection(nameof(SqlConnectionSettings)).Get<SqlConnectionSettings>().ConnectionString);
            })
            .As<IDistributedLockProvider>().
            SingleInstance();
            
            builder
                .RegisterDecorator(typeof(HttpRepositoryMetricsDecorator), typeof(IHttpRepository));
            builder
                .RegisterGenericDecorator(typeof(EfRepositoryMetricsDecorator<>), typeof(IRepository<>));
            builder
                .RegisterGenericDecorator(typeof(PublisherMetricsDecorator<>), typeof(IFeedQueuePublisher<>));
        }

        private void RegisterContext<TContext>(ContainerBuilder builder)
            where TContext : DbContext
        {
            builder.Register(componentContext =>
                {
                    var serviceProvider = componentContext.Resolve<IServiceProvider>();
                    var configuration = componentContext.Resolve<IConfiguration>();
                    var dbContextOptions = new DbContextOptions<AppDbContext>(new Dictionary<Type, IDbContextOptionsExtension>());

                    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>(dbContextOptions)
                        .UseApplicationServiceProvider(serviceProvider)
                        .EnableSensitiveDataLogging()
                        .UseSqlServer(configuration.GetSection(nameof(SqlConnectionSettings)).Get<SqlConnectionSettings>().ConnectionString,
                            serverOptions =>
                                serverOptions.EnableRetryOnFailure(5,
                                    TimeSpan.FromSeconds(30),
                                    null));

                    return optionsBuilder.Options;
                })
                .As<DbContextOptions<TContext>>()
                .InstancePerLifetimeScope();

            builder.Register(context => context.Resolve<DbContextOptions<TContext>>())
                .As<DbContextOptions>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TContext>()
                .AsSelf()
                .InstancePerLifetimeScope();
        }
    }
}
