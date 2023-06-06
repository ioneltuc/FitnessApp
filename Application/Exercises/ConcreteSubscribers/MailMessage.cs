using Application.Exercises.Dtos;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Application.Exercises.ConcreteSubscribers
{
    public class MailMessage : ISubscriber
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public MailMessage()
        {
        }

        public MailMessage(string email)
        {
            Email = email;
        }

        public async Task Update(ExerciseDto exerciseDto)
        {
            var email = new MimeMessage();

            try
            {
                email.Sender = MailboxAddress.Parse("TucFitness");
                email.To.Add(MailboxAddress.Parse(Email));

                email.Subject = "New fitness exercise added";

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = "<b>A new fitness exercise was added in your app - TucFitness</b><br>" +
                    $"<b>Name:</b> {exerciseDto.Name}<br>" +
                    $"<b>Description:</b> {exerciseDto.Description}<br>" +
                    $"<b>Start doing time:</b> {exerciseDto.StartDoingHour}:{exerciseDto.StartDoingMinutes}<br>" +
                    $"<b>Duration:</b> {exerciseDto.DurationInSeconds} seconds";
                email.Body = bodyBuilder.ToMessageBody();

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    smtp.Authenticate("iontuc21@gmail.com", "");
                    await smtp.SendAsync(email);
                    smtp.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}