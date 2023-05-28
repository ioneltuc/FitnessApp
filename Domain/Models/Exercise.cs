namespace Domain.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StartDoingHour { get; set; }
        public int StartDoingMinutes { get; set; }
        public int DurationInSeconds { get; set; }
    }
}