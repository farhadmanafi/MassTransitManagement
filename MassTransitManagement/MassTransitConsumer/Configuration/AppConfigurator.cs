using MassTransit;
using RabbitMQ.Client;
using MassTransitConsumer.Services;

namespace MassTransitConsumer.Configuration
{
    public static class AppConfigurator
    {
        public static void ConfigMassTransit(IServiceCollection serviceCollection, HostBuilderContext context)
        {
            var rabbitConfiguration = context.Configuration.GetSection("RabbitConsumeConfiguration").Get<RabbitConsumeConfiguration>();

            serviceCollection.AddMassTransit(x =>
            {
                x.AddConsumer<ConsumerService>();
                x.AddBus(context => Bus.Factory.CreateUsingRabbitMq(configure =>
                {
                    configure.Host(new Uri(rabbitConfiguration.Connection));
                    configure.ExchangeType = ExchangeType.Direct;

                    configure.ReceiveEndpoint(rabbitConfiguration.QueueName, endpointConfigurator =>
                    {
                        endpointConfigurator.UseConcurrencyLimit(rabbitConfiguration.ConcurrentMessageLimit);
                        endpointConfigurator.ConfigureConsumer<ConsumerService>(context);
                        endpointConfigurator.ConfigureConsumeTopology = rabbitConfiguration.ConfigureConsumeTopology;
                        endpointConfigurator.ExchangeType = rabbitConfiguration.ExchangeType;
                        endpointConfigurator.EnablePriority(rabbitConfiguration.MaxPriority);
                        endpointConfigurator.PrefetchCount = rabbitConfiguration.PrefetchCount;
                        //endpointConfigurator.UseMessageRetry(messageConfig => messageConfig.Interval(2, 100));
                    });
                }));

            });
        }
    }
}
