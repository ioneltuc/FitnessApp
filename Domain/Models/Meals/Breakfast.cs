using Domain.Abstractions;

namespace Domain.Models.Meals
{
    public class Breakfast : Meal, IMeal
    {
        public Breakfast(string name, string description, int startTakingHour, int startTakingMinutes, int calories) :
            base(name, description, startTakingHour, startTakingMinutes, calories)
        {
        }
    }
}