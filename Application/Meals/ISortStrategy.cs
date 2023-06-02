using Domain.Models.Meals;

namespace Application.Meals
{
    public interface ISortStrategy
    {
        Task<ICollection<Meal>> GetMealsSorted();
    }
}