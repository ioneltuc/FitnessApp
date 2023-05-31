using Application.Exercises.ConcreteSubscribers;

namespace Application.Abstractions
{
    public interface IEmailRepository
    {
        Task AddEmailAsync(MailMessage mailMessage);

        Task RemoveEmailAsync(MailMessage mailMessage);

        MailMessage GetEmail();
    }
}