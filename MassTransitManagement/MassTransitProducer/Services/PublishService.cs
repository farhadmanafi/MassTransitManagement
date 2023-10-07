using MassTransit;
using MassTransitContract.Models;
using MassTransitProducer.Configuration;

namespace MassTransitProducer.Services
{
    public class PublishService : IPublishService
    {
        private readonly RabbitPublishConfiguration _rabbitConfiguration;
        private readonly ISendEndpointProvider _messageSender;
        public PublishService(
            RabbitPublishConfiguration rabbitConfiguration,
            ISendEndpointProvider messageSender
            )
        {
            _rabbitConfiguration = rabbitConfiguration;
            _messageSender = messageSender;
        }
        public async Task Publish(MassTransitModel model)
        {
            var uri = new Uri($"exchange:{_rabbitConfiguration.QueueName}?type={_rabbitConfiguration.ExchangeType}");
            var endPoint = _messageSender.GetSendEndpoint(uri).Result;

            await endPoint.Send(model);
        }
    }
}
