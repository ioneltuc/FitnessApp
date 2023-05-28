using Application.Abstractions;
using Domain.Models;

namespace Application.Exercises
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<Exercise> CreateExercise(Exercise exercise)
        {
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
    }
}