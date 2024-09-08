using Microsoft.AspNetCore.Mvc;
using RabbitMqApi.Handlers;

namespace RabbitMqApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class MessageController(IMessageHandler handler) : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            handler.HandleGet();
            return new OkObjectResult("Message posted");
        }


    }
}
