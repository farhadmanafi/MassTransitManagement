using MassTransit;
using MassTransitContract.Models;
using Newtonsoft.Json;

namespace MassTransitConsumer.Services
{
    public class ConsumerService : IConsumer<MassTransitModel>
    {
        public async Task Consume(ConsumeContext<MassTransitModel> context)
        {
            var massTransitBody = JsonConvert.DeserializeObject<MassTransitBody>(context.Message.Body);
            
            //Send to db or ecs

            await Task.CompletedTask;
        }
    }
}
