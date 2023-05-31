using Application.Usr.Dtos;
using Domain.Models;

namespace Application.Abstractions
{
    public interface IUserService
    {
        Task<User> PatchUser(UserDto userToUpdate);
    }
}