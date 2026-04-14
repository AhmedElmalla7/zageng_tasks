using Microsoft.AspNetCore.Mvc;
using Task_Feedback_API.Models;

namespace Task_Feedback_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        public FeedbackController(IConfiguration config , ILogger<FeedbackController> logger)
        {
            _config = config; 
            _logger = logger;
        }

        [HttpPost]
        public IActionResult PostFeedback( /*[FromQuery] int rate ,*/ FeedbackRequest request)
        {
            var systemName = _config["SystemSettings:SystemName"];

            _logger.LogInformation("Feedback received from user : {UserName}", request.UserName);

            if(request.Rate < 3)
            {
                _logger.LogWarning("User {UserName} is not satisfied with the service",request.UserName);
            }

            var message = $"Feedback received for {systemName} . Thank you, {request.UserName}";

            return Ok(message);
        }

    }
}
