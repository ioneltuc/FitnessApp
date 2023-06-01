using Domain.Enums;

namespace Application.Usr.Dtos
{
    public class UserDto
    {
        public string? Nickname { get; set; }
        public string? Email { get; set; }
        public int? Age { get; set; }
        public Gender? Gender { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
    }
}