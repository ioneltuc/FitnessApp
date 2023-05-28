using Domain.Models;

namespace Application.Abstractions
{
    public interface IExerciseRepository
    {
        Task<ICollection<Exercise>> GetAllExercisesAsync();

        Task<Exercise> GetExerciseByIdAsync(int exerciseId);

        Task<Exercise> CreateExerciseAsync(Exercise exercise);

        Task DeleteExerciseAsync(int exerciseId);
    }
}