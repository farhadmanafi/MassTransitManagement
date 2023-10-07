using MassTransit;

namespace MassTransitProducer.Configuration
{
    public static class AppConfigurator
    {
        public static void ConfigMassTransit(IServiceCollection serviceCollection, HostBuilderContext context)
        {
            var rabbitConfiguration = context.Configuration.GetSection("RabbitPublishConfiguration").Get<RabbitPublishConfiguration>();

            serviceCollection.AddSingleton(rabbitConfiguration);

            serviceCollection.AddMassTransit(configurator =>
            {
                configurator.AddBus(context => Bus.Factory.CreateUsingRabbitMq(configure =>
                {
                    configure.Host(rabbitConfiguration.Connection);

                    configure.ExchangeType = rabbitConfiguration.ExchangeType;
                }));
            });

            serviceCollection.AddMassTransitHostedService();
        }
    }
}
