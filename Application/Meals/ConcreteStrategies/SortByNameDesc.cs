using Application.Abstractions;
using Domain.Models.Meals;

namespace Application.Meals.ConcreteStrategies
{
    public class SortByNameDesc : ISortStrategy
    {
        private readonly IMealRepository _mealRepository;

        public SortByNameDesc(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<ICollection<Meal>> GetMealsSorted()
        {
            return await _mealRepository.GetAllMealsOrderedByNameDescAsync();
        }
    }
}