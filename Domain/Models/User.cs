using Domain.Enums;

namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
    }
}