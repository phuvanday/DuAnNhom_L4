using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace AssignmentC4.Areas.User.Services
{
    public static class EmailHelper
    {
        public static async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential("taiptpk04158@gmail.com", "esvu qupo qryq peop");
                smtp.EnableSsl = true;

                using (var message = new MailMessage("taiptpk04158@gmail.com", toEmail, subject, body))
                {
                    message.IsBodyHtml = true;
                    await smtp.SendMailAsync(message);
                }
            }
        }
    }
}
