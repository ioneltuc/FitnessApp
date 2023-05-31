using Domain.Abstractions;

namespace Domain.Models.Meals
{
    public class Dinner : Meal, IMeal
    {
        public Dinner(string name, string description, int startTakingHour, int startTakingMinutes, int calories) : 
            base(name, description, startTakingHour, startTakingMinutes, calories)
        {
        }
    }
}