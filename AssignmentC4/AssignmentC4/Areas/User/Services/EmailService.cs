using System.Threading.Tasks;

namespace AssignmentC4.Areas.User.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            await EmailHelper.SendEmailAsync(toEmail, subject, body);
        }
    }
}
