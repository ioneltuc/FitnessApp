using Domain.Models;

namespace Application.Exercises
{
    public class ExerciseBuilder
    {
        private readonly Exercise _exercise = new Exercise();

        public ExerciseBuilder Name(string name)
        {
            _exercise.Name = name;
            return this;
        }

        public ExerciseBuilder Description(string description)
        {
            _exercise.Description = description;
            return this;
        }

        public ExerciseBuilder StartDoingHour(int startDoingHour)
        {
            _exercise.StartDoingHour = startDoingHour;
            return this;
        }

        public ExerciseBuilder StartDoingMinutes(int startDoingMinutes)
        {
            _exercise.StartDoingMinutes = startDoingMinutes;
            return this;
        }

        public ExerciseBuilder DurationInSeconds(int durationInSeconds)
        {
            _exercise.DurationInSeconds = durationInSeconds;
            return this;
        }

        public Exercise Build()
        {
            return _exercise;
        }
    }
}