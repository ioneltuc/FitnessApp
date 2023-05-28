using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly FitnessDbContext _context;

        public ExerciseRepository(FitnessDbContext context)
        {
            _context = context;
        }

        public async Task<Exercise> CreateExerciseAsync(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
            return exercise;
        }

        public async Task DeleteExerciseAsync(int exerciseId)
        {
            var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == exerciseId);

            if (exercise == null)
            {
                return;
            }

            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Exercise>> GetAllExercisesAsync()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise> GetExerciseByIdAsync(int exerciseId)
        {
            return await _context.Exercises.FirstOrDefaultAsync(e => e.Id == exerciseId);
        }
    }
}