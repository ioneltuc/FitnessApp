namespace Domain.Models.Meals
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StartTakingHour { get; set; }
        public int StartTakingMinutes { get; set; }
        public int Calories { get; set; }

        public Meal(string name, string description, int startTakingHour, int startTakingMinutes, int calories)
        {
            Name = name;
            Description = description;
            StartTakingHour = startTakingHour;
            StartTakingMinutes = startTakingMinutes;
            Calories = calories;
        }
    }
}