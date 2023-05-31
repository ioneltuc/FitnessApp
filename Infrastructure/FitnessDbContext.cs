using Application.Exercises.ConcreteSubscribers;
using Domain.Models;
using Domain.Models.Meals;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class FitnessDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Breakfast> Breakfasts { get; set; }
        public DbSet<Lunch> Lunches { get; set; }
        public DbSet<Dinner> Dinners { get; set; }
        public DbSet<MailMessage> EmailsToNotify { get; set; }

        public FitnessDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}