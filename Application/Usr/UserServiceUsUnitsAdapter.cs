using Domain.Models;

namespace Application.Usr
{
    public class UserServiceUsUnitsAdapter : IUserServiceUsAdapter
    {
        private UserService _userService;

        public UserServiceUsUnitsAdapter(UserService userService)
        {
            _userService = userService;
        }

        public async Task<User> GetUser()
        {
            var user = await _userService.GetUser();
            user.Weight = Math.Round(user.Weight * 2.20462262185, 2);
            user.Height = Math.Round(user.Height * 0.032808399, 2);

            return user;
        }
    }
}