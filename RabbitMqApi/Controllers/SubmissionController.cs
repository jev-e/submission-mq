using Microsoft.AspNetCore.Mvc;
using RabbitMqApi.Handlers;
using RabbitMqApi.Model;

namespace RabbitMqApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class SubmissionController(ISubmissionHandler handler) : Controller
    {
        [HttpPost]
        public IActionResult NewSubmission([FromBody] NewSubmissionRequest submissionRequest)
        {
            handler.HandleNewSubmission(submissionRequest);
            return new CreatedResult();
        }
    }
}
