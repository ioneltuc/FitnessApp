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
        private readonly IUserRepository _userRepository;
        private readonly MailMessage _mailMessage;

        public NotificationController(IExerciseService exerciseService, IUserRepository userRepository)
        {
            _exerciseService = exerciseService;
            _userRepository = userRepository;
            _mailMessage = new MailMessage(_userRepository.GetUserEmail());
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