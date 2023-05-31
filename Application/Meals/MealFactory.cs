using Application.Meals.Dtos;
using Domain.Abstractions;
using Domain.Enums;
using Domain.Models.Meals;

namespace Application.Meals
{
    public class MealFactory
    {
        public IMeal CreateConcreteMeal(MealType mealType, MealDto mealDto)
        {
            switch (mealType)
            {
                case MealType.Breakfast:
                    return new Breakfast(
                        mealDto.Name,
                        mealDto.Description,
                        mealDto.StartTakingHour,
                        mealDto.StartTakingMinutes,
                        mealDto.Calories);

                case MealType.Lunch:
                    return new Lunch(mealDto.Name,
                        mealDto.Description,
                        mealDto.StartTakingHour,
                        mealDto.StartTakingMinutes,
                        mealDto.Calories,
                        mealDto.FirstCourseDescription,
                        mealDto.SecondCourseDescription);

                case MealType.Dinner:
                    return new Dinner(mealDto.Name,
                        mealDto.Description,
                        mealDto.StartTakingHour,
                        mealDto.StartTakingMinutes,
                        mealDto.Calories);

                default:
                    return null;
            }
        }
    }
}