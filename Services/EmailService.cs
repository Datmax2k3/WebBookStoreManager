using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;
using WebBookStoreManage.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebBookStoreManage.Services
{
    public class EmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendEmailAsync(string recipientEmail, string subject, string messageBody)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_smtpSettings.Sender, _smtpSettings.Sender));
            message.To.Add(new MailboxAddress(recipientEmail, recipientEmail));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = messageBody
            };
            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            try
            {
                Console.WriteLine("Connecting to SMTP server...");
                await client.ConnectAsync(_smtpSettings.SmtpServer, _smtpSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                Console.WriteLine("Connected to SMTP server");

                Console.WriteLine("Authenticating...");
                await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
                Console.WriteLine("Authenticated");

                Console.WriteLine("Sending email...");
                await client.SendAsync(message);
                Console.WriteLine("Email sent");

                await client.DisconnectAsync(true);
                Console.WriteLine("Disconnected from SMTP server");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while sending email: {ex.Message}");
            }
        }
    }
}

