using Application.Abstractions;
using Application.Usr.Dtos;
using Domain.Models;

namespace Application.Usr
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUser()
        {
            return await _userRepository.GetUserAsync();
        }

        public string GetUserEmail()
        {
            return _userRepository.GetUserEmail();
        }

        public async Task<User> PatchUser(UserDto userToUpdate)
        {
            return await _userRepository.UpdateUserPatchAsync(userToUpdate);
        }
    }
}