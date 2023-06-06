using Application.Exercises.Dtos;

namespace Application.Exercises
{
    public interface ISubscriber
    {
        Task Update(ExerciseDto exerciseDto);
    }
}