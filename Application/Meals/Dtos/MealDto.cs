namespace Application.Meals.Dtos
{
    public class MealDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StartTakingHour { get; set; }
        public int StartTakingMinutes { get; set; }
        public int Calories { get; set; }
        public string? FirstCourseDescription { get; set; }
        public string? SecondCourseDescription { get; set; }
    }
}