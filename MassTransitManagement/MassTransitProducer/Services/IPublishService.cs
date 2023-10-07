using MassTransitContract.Models;

namespace MassTransitProducer.Services
{
    public interface IPublishService
    {
        Task Publish(MassTransitModel model);
    }
}
