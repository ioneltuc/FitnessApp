﻿using Application.Usr.Dtos;
using Domain.Models;

namespace Application.Abstractions
{
    public interface IUserRepository
    {
        Task<User> UpdateUserPatchAsync(UserDto userToUpdate);

        string GetUserEmail();
    }
}