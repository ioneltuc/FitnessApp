using Application.Abstractions;
using Application.Exercises;
using Application.Exercises.ConcreteSubscribers;

namespace Infrastructure.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly FitnessDbContext _context;

        public EmailRepository(FitnessDbContext context)
        {
            _context = context;
        }

        public async Task AddEmailAsync(MailMessage mailMessage)
        {
            if (_context.EmailsToNotify.Count() == 0)
            {
                _context.EmailsToNotify.Add(mailMessage);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveEmailAsync(MailMessage mailMessage)
        {
            if (_context.EmailsToNotify.Count() == 1)
            {
                _context.EmailsToNotify.Remove(GetEmail());
                await _context.SaveChangesAsync();
            }
        }

        public MailMessage GetEmail()
        {
            return _context.EmailsToNotify.FirstOrDefault();
        }

        public async Task<bool> IsSubscribedToEmailNotifications()
        {
            if(_context.EmailsToNotify.Count() > 0)
            {
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }
    }
}