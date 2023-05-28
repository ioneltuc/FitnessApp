using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class FitnessDbContext : DbContext
    {
        public FitnessDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Exercise> Exercises { get; set; }
    }
}