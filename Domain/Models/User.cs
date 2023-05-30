using Domain.Enums;

namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
    }
}