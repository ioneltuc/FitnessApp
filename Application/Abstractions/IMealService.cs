using Application.Meals.Dtos;
using Domain.Abstractions;
using Domain.Enums;
using Domain.Models.Meals;

namespace Application.Abstractions
{
    public interface IMealService
    {
        Task<IMeal> CreateMeal(MealType mealType, MealDto mealDto);

        Task DeleteMeal(int mealId);

        Task<ICollection<Meal>> GetMeals();

        Task<IMeal> GetMeal(int mealId);
    }
}