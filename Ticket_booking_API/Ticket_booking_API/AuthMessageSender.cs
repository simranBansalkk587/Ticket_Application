using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Ticket_booking_API.Repository.IRepository;

namespace Ticket_booking_API
{
  public class AuthMessageSender : IEmailSender
  {
    public AuthMessageSender(IOptions<EmailSetting> emailSettings)
    {
      _emailSettings = emailSettings.Value;
    }

    public EmailSetting _emailSettings { get; }

    //public Task SendEmailAsync(string email, string subject, string message)
    //{

    //  Execute(email, subject, message).Wait();
    //  return Task.FromResult(0);
    //}

    
    public Task Execute(string email, string Subject, string message)
    {
      Execute(email, Subject, message).Wait();
      return Task.FromResult(0);
    }

    public async Task SendEmailAsync(string email, string subject, string message)
    {
      try
      {
        string toEmail = string.IsNullOrEmpty(email)
                         ? _emailSettings.ToEmail
                         : email;
        MailMessage mail = new MailMessage()
        {
          From = new MailAddress(_emailSettings.UsernameEmail, "Muhammad Hassan Tariq")
        };
        mail.To.Add(new MailAddress(toEmail));
        mail.CC.Add(new MailAddress(_emailSettings.CcEmail));

        mail.Subject = "Personal Management System - " + subject;
        mail.Body = message;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        using (SmtpClient smtp = new SmtpClient(_emailSettings.SecondaryDomain, _emailSettings.PrimaryPort))
        {
          smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
          smtp.EnableSsl = true;
          await smtp.SendMailAsync(mail);
        }
      }
      catch (Exception ex)
      {
        //do something here
      }
    }
  }
  }


