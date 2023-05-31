using Application.Abstractions;
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
    }
}