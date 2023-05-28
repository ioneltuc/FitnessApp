using Domain.Models;

namespace Application.Abstractions
{
    public interface IExerciseService
    {
        Task<ICollection<Exercise>> GetAllExercises();

        Task<Exercise> GetExerciseById(int exerciseId);

        Task<Exercise> CreateExercise(Exercise exercise);

        Task DeleteExercise(int exerciseId);
    }
}