using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var settings = _config.GetSection("EmailSettings");
        var smtpClient = new SmtpClient(settings["SmtpServer"])
        {
            Port = int.Parse(settings["SmtpPort"]),
            Credentials = new NetworkCredential(settings["SenderEmail"], settings["SenderPassword"]),
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(settings["SenderEmail"], settings["SenderName"]),
            Subject = subject,
            Body = body,
            IsBodyHtml = true,
        };
        mailMessage.To.Add(to);

        await smtpClient.SendMailAsync(mailMessage);
    }
}
