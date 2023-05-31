using Domain.Models;
using Domain.Models.Meals;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class FitnessDbContext : DbContext
    {
        public FitnessDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Breakfast> Breakfasts { get; set; }
        public DbSet<Lunch> Lunches { get; set; }
        public DbSet<Dinner> Dinners { get; set; }
    }
}