using MassTransitContract.Models;
using MassTransitProducer.Services;
using Microsoft.AspNetCore.Mvc;

namespace MassTransitProducer.Controllers
{
    public class MassTransitPublishController : Controller
    {
        private readonly IPublishService _publishService;

        public MassTransitPublishController(IPublishService publishService)
        {
            _publishService = publishService;
        }

        [HttpPost]
        public async Task PublishModel(MassTransitModel model)
        {
            await _publishService.Publish(model);
        }
    }
}
