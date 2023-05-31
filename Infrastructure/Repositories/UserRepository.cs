using Application.Abstractions;
using Application.Usr.Dtos;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FitnessDbContext _context;

        public UserRepository(FitnessDbContext context)
        {
            _context = context;
        }

        public async Task<User> UpdateUserPatchAsync(UserDto userToUpdate)
        {
            var user = await _context.Users.FirstAsync();

            if (userToUpdate.Nickname != null)
                user.Nickname = userToUpdate.Nickname;

            if (userToUpdate.Email != null)
                user.Email = userToUpdate.Email;

            if (userToUpdate.Age != null)
                user.Age = (int)userToUpdate.Age;

            if (userToUpdate.Gender != null)
                user.Gender = (Domain.Enums.Gender)userToUpdate.Gender;

            if (userToUpdate.Height != null)
                user.Height = (int)userToUpdate.Height;

            if (userToUpdate.Weight != null)
                user.Weight = (int)userToUpdate.Weight;

            await _context.SaveChangesAsync();
            return user;
        }

        public string GetUserEmail()
        {
            var user = _context.Users.FirstOrDefault();
            var email = user.Email;
            return email;
        }
    }
}