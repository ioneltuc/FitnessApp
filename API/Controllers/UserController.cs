using Application.Abstractions;
using Application.Usr;
using Application.Usr.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPatch]
        public async Task<User> PatchUser(UserDto userToUpdate)
        {
            return await _userService.PatchUser(userToUpdate);
        }

        [HttpGet]
        public async Task<User> GetUser()
        {
            return await _userService.GetUser();
        }

        [HttpGet("usunits")]
        public async Task<User> GetUserUsUnits()
        {
            var userServiceAdapter = new UserServiceUsUnitsAdapter((UserService)_userService);
            return await userServiceAdapter.GetUser();
        }
    }
}