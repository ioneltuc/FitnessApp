namespace Application.Exercises.Dtos
{
    public class ExerciseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StartDoingHour { get; set; }
        public int StartDoingMinutes { get; set; }
        public int DurationInSeconds { get; set; }
    }
}