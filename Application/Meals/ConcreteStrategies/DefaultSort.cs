using Application.Abstractions;
using Domain.Models.Meals;

namespace Application.Meals.ConcreteStrategies
{
    public class DefaultSort : ISortStrategy
    {
        private readonly IMealRepository _mealRepository;

        public DefaultSort(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<ICollection<Meal>> GetMealsSorted()
        {
            return await _mealRepository.GetAllMealsAsync();
        }
    }
}