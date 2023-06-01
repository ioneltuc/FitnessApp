using Application.Abstractions;
using Application.Exercises.ConcreteSubscribers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;
        private readonly IUserService _userService;
        private readonly MailMessage _mailMessage;

        public NotificationController(IExerciseService exerciseService, IUserService userService)
        {
            _exerciseService = exerciseService;
            _userService = userService;
            _mailMessage = new MailMessage(_userService.GetUserEmail());
        }

        [HttpPost("email")]
        public async Task SubscribeForEmailNotifications()
        {
            await _exerciseService.Subscribe(_mailMessage);
        }

        [HttpDelete("email")]
        public async Task UnubscribeFromEmailNotifications()
        {
            await _exerciseService.Unsubscribe(_mailMessage);
        }
    }
}