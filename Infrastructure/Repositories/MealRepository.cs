using Application.Abstractions;
using Domain.Abstractions;
using Domain.Models.Meals;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MealRepository : IMealRepository
    {
        private readonly FitnessDbContext _context;

        public MealRepository(FitnessDbContext context)
        {
            _context = context;
        }

        public async Task<IMeal> CreateMealAsync(IMeal meal)
        {
            if (meal is Breakfast)
            {
                _context.Breakfasts.Add((Breakfast)meal);
            }
            else if (meal is Lunch)
            {
                _context.Lunches.Add((Lunch)meal);
            }
            else if (meal is Dinner)
            {
                _context.Dinners.Add((Dinner)meal);
            }

            await _context.SaveChangesAsync();
            return meal;
        }

        public async Task DeleteMealAsync(int mealId)
        {
            var meal = await _context.Meals.FirstOrDefaultAsync(m => m.Id == mealId);

            if (meal == null)
            {
                return;
            }

            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Meal>> GetAllMealsAsync()
        {
            return await _context.Meals.ToListAsync();
        }

        public async Task<IMeal> GetMealByIdAsync(int mealId)
        {
            var meal = await _context.Meals.FirstOrDefaultAsync(m => m.Id == mealId);

            if (meal is Breakfast)
            {
                return (Breakfast)meal;
            }
            else if (meal is Lunch)
            {
                return (Lunch)meal;
            }
            else if (meal is Dinner)
            {
                return (Dinner)meal;
            }

            return null;
        }
    }
}