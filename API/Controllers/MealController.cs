using Application.Abstractions;
using Application.Meals;
using Application.Meals.ConcreteStrategies;
using Application.Meals.Dtos;
using Domain.Abstractions;
using Domain.Enums;
using Domain.Models.Meals;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealService _mealService;
        private readonly IMealRepository _mealRepository;

        public MealController(IMealService mealService, IMealRepository mealRepository)
        {
            _mealService = mealService;
            _mealRepository = mealRepository;
        }

        [HttpPost]
        public async Task<IMeal> CreateMeal(MealType mealType, MealDto mealDto)
        {
            return await _mealService.CreateMeal(mealType, mealDto);
        }

        [HttpDelete("{id}")]
        public async Task DeleteMeal(int id)
        {
            await _mealService.DeleteMeal(id);
        }

        [HttpGet]
        public async Task<ICollection<Meal>> GetMeals()
        {
            return await _mealService.GetMeals();
        }

        [HttpGet("{id}")]
        public async Task<IMeal> GetMeal(int id)
        {
            return await _mealService.GetMeal(id);
        }

        [HttpGet("sorted")]
        public async Task<ICollection<Meal>> GetMealsSorted(SortType sortType)
        {
            switch (sortType)
            {
                case SortType.None:
                    _mealService.SetSortStrategy(new DefaultSort(_mealRepository));
                    break;

                case SortType.ByNameAsc:
                    _mealService.SetSortStrategy(new SortByName(_mealRepository));
                    break;

                case SortType.ByNameDesc:
                    _mealService.SetSortStrategy(new SortByNameDesc(_mealRepository));
                    break;

                case SortType.ByCaloriesAsc:
                    _mealService.SetSortStrategy(new SortByCalories(_mealRepository));
                    break;

                case SortType.ByCaloriesDesc:
                    _mealService.SetSortStrategy(new SortByCaloriesDesc(_mealRepository));
                    break;

                default:
                    _mealService.SetSortStrategy(new DefaultSort(_mealRepository));
                    break;
            }

            return await _mealService.GetMealsSorted();
        }
    }
}