using Domain.Abstractions;
using Domain.Models.Meals;

namespace Application.Abstractions
{
    public interface IMealRepository
    {
        Task<IMeal> CreateMealAsync(IMeal meal);

        Task DeleteMealAsync(int mealId);

        Task<ICollection<Meal>> GetAllMealsAsync();

        Task<IMeal> GetMealByIdAsync(int mealId);
    }
}