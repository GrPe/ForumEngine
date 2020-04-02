using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace ForumEngine.Data.Mocks
{
    public class EmailSenderMock : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
