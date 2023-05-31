using Application.Abstractions;
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

        public MealController(IMealService mealService)
        {
            _mealService = mealService;
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
    }
}