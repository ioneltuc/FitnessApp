using Application.Abstractions;
using Application.Exercises.ConcreteSubscribers;
using Application.Exercises.Dtos;
using Domain.Models;

namespace Application.Exercises
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IEmailRepository _emailRepository;
        private List<ISubscriber> _subscribers;
        private ExerciseBuilder _exerciseBuilder;
        public ExerciseService(IExerciseRepository exerciseRepository, IEmailRepository emailRepository)
        {
            _exerciseRepository = exerciseRepository;
            _emailRepository = emailRepository;
            _subscribers = new List<ISubscriber>();
            _exerciseBuilder = new ExerciseBuilder();
        }

        public async Task<Exercise> CreateExercise(ExerciseDto exerciseDto)
        {
            Exercise exercise = _exerciseBuilder
                .Name(exerciseDto.Name)
                .Description(exerciseDto.Description)
                .StartDoingHour(exerciseDto.StartDoingHour)
                .StartDoingMinutes(exerciseDto.StartDoingMinutes)
                .DurationInSeconds(exerciseDto.DurationInSeconds)
                .Build();

            NotifySubscribers(exerciseDto);

            return await _exerciseRepository.CreateExerciseAsync(exercise);
        }

        public async Task DeleteExercise(int exerciseId)
        {
            await _exerciseRepository.DeleteExerciseAsync(exerciseId);
        }

        public async Task<ICollection<Exercise>> GetAllExercises()
        {
            return await _exerciseRepository.GetAllExercisesAsync();
        }

        public async Task<Exercise> GetExerciseById(int exerciseId)
        {
            return await _exerciseRepository.GetExerciseByIdAsync(exerciseId);
        }

        public async Task Subscribe(ISubscriber subscriber)
        {
            if (subscriber is MailMessage)
            {
                await _emailRepository.AddEmailAsync((MailMessage)subscriber);
            }
        }

        public async Task Unsubscribe(ISubscriber subscriber)
        {
            if (subscriber is MailMessage)
            {
                await _emailRepository.RemoveEmailAsync((MailMessage)subscriber);
            }
        }

        private void NotifySubscribers(ExerciseDto exerciseDto)
        {
            ISubscriber email = _emailRepository.GetEmail();

            if (email != null)
            {
                _subscribers.Add(email);
            }

            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(exerciseDto);
            }
        }

        public async Task<bool> IsSubscribedToEmailNotifications()
        {
            return await _emailRepository.IsSubscribedToEmailNotifications();
        }
    }
}