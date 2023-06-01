using Domain.Models;

namespace Application.Usr
{
    public interface IUserServiceUsAdapter
    {
        Task<User> GetUser();
    }
}