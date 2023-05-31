using Domain.Abstractions;

namespace Domain.Models.Meals
{
    public class Lunch : Meal, IMeal
    {
        public string? FirstCourseDescription { get; set; }
        public string? SecondCourseDescription { get; set; }

        public Lunch(string name, string description, int startTakingHour, int startTakingMinutes, int calories,
            string firstCourseDescription, string secondCourseDescription) :
            base(name, description, startTakingHour, startTakingMinutes, calories)
        {
            FirstCourseDescription = firstCourseDescription;
            SecondCourseDescription = secondCourseDescription;
        }
    }
}