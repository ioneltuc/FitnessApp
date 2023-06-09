﻿using Application.Abstractions;
using Application.Exercises.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<ICollection<Exercise>> GetExercises()
        {
            return await _exerciseService.GetAllExercises();
        }

        [HttpGet("{id}")]
        public async Task<Exercise> GetExercise(int id)
        {
            return await _exerciseService.GetExerciseById(id);
        }

        [HttpPost]
        public async Task<Exercise> CreateExercise(ExerciseDto exerciseDto)
        {
            return await _exerciseService.CreateExercise(exerciseDto);
        }

        [HttpDelete("{id}")]
        public async Task DeleteExercise(int id)
        {
            await _exerciseService.DeleteExercise(id);
        }
    }
}