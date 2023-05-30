using Application.Abstractions;
using Application.Exercises.Dtos;
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

        public async Task<Exercise> CreateExercise(ExerciseDto exerciseDto)
        {
            var exerciseBuilder = new ExerciseBuilder();

            Exercise exercise = exerciseBuilder
                .Name(exerciseDto.Name)
                .Description(exerciseDto.Description)
                .StartDoingHour(exerciseDto.StartDoingHour)
                .StartDoingMinutes(exerciseDto.StartDoingMinutes)
                .DurationInSeconds(exerciseDto.DurationInSeconds)
                .Build();

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