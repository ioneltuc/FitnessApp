using Application.Exercises.Dtos;

namespace Application.Exercises
{
    public interface ISubscriber
    {
        void Update(ExerciseDto exerciseDto);
    }
}