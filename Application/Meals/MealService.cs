using Application.Abstractions;
using Application.Meals.Dtos;
using Domain.Abstractions;
using Domain.Enums;
using Domain.Models.Meals;

namespace Application.Meals
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;
        private ISortStrategy _sortStrategy;

        public MealService(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<IMeal> CreateMeal(MealType mealType, MealDto mealDto)
        {
            var mealFactory = new MealFactory();

            IMeal meal = mealFactory.CreateConcreteMeal(mealType, mealDto);

            return await _mealRepository.CreateMealAsync(meal);
        }

        public async Task DeleteMeal(int mealId)
        {
            await _mealRepository.DeleteMealAsync(mealId);
        }

        public async Task<ICollection<Meal>> GetMeals()
        {
            return await _mealRepository.GetAllMealsAsync();
        }

        public async Task<IMeal> GetMeal(int mealId)
        {
            return await _mealRepository.GetMealByIdAsync(mealId);
        }

        public void SetSortStrategy(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public async Task<ICollection<Meal>> GetMealsSorted()
        {
            return await _sortStrategy.GetMealsSorted();
        }
    }
}