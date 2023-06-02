using Application.Exercises;
using Application.Exercises.Dtos;
using Domain.Models;

namespace Application.Abstractions
{
    public interface IExerciseService
    {
        Task<ICollection<Exercise>> GetAllExercises();

        Task<Exercise> GetExerciseById(int exerciseId);

        Task<Exercise> CreateExercise(ExerciseDto exercise);

        Task DeleteExercise(int exerciseId);

        Task Subscribe(ISubscriber subscriber);

        Task Unsubscribe(ISubscriber subscriber);

        Task<bool> IsSubscribedToEmailNotifications();
    }
}