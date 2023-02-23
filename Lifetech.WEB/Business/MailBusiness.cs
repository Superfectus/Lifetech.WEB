using Lifetech.WEB.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace Lifetech.WEB.Business;

public class MailBusiness : IMailBusiness
{

    private readonly IConfiguration _configuration;
    private readonly AppDbContext _context;
    private object _unitofWork;

    public MailBusiness(IConfiguration configuration,AppDbContext context)

    {
        _context = context;
        _configuration = configuration;
    }


    public MailResponseModel SendMail(MailRequestModel mailRequestModel)
    {
        try
        {

            var frommail = "bilgi@redefine.com.tr";
            var fromName = "Lifetech Bilişim (Bilgilendirme Servisi)";
            var toBilgi = "erayal2001@gmail.com";

            MimeMessage emailMessage = new MimeMessage();
            MailboxAddress emailFrom = new MailboxAddress(fromName, frommail);
            emailMessage.From.Add(emailFrom);

            MailboxAddress emailTo = new MailboxAddress(fromName, toBilgi);
            emailMessage.To.Add(emailTo);

            var subject = mailRequestModel.Subject;
            if (subject == null)
            {
                subject = "MESAJINIZ VAR";
            }
            else
            {
                subject = mailRequestModel.Subject;
            }
            emailMessage.Subject = subject;

            var body = "<h3>Gönderenin Bilgileri: </h3>" +
               "<h4> İsim: " + mailRequestModel.Name + "</h4>" +
               "<h4> Email: " + mailRequestModel.EmailAddress + "</h4>" +
               "<h4> Telefon No: " + mailRequestModel.PhoneNumber + "</h4>" +
               "<h4> Firma Adı: " + mailRequestModel.FirmName + "</h4>" +
               "<h4> Mesaj: </h4>" + mailRequestModel.Message;
            BodyBuilder emailBodyBuilder = new BodyBuilder();
            emailBodyBuilder.HtmlBody = body;
            emailMessage.Body = emailBodyBuilder.ToMessageBody();

            MimeMessage emailMessageCustomer = new MimeMessage();
            emailMessageCustomer.From.Add(emailFrom);
            MailboxAddress emailToC = new MailboxAddress(mailRequestModel.Name, mailRequestModel.EmailAddress);
            emailMessageCustomer.To.Add(emailToC);
            subject = "YENİ MESAJINIZ VAR (WEB)";
            emailMessageCustomer.Subject = subject;
            body = "En kısa zamanda ilgili ekip arkadaşımız sizinle iletişime geçecektir. <h4>Teşekkürler!</h4> <h3> Lifetech </h3>   ";
            emailBodyBuilder.HtmlBody = body;
            emailMessageCustomer.Body = emailBodyBuilder.ToMessageBody();

            var username = _configuration.GetSection("UsernameEmail").Value;
            var password = _configuration.GetSection("Password").Value;
            var host = _configuration.GetSection("Host").Value;
            var port = 465;

            SmtpClient emailClient = new SmtpClient();
            emailClient.Connect(host, port, true);
            emailClient.Authenticate(username, password);
            emailClient.Send(emailMessage);
            emailClient.Send(emailMessageCustomer);
            emailClient.Disconnect(true);
            emailClient.Dispose();
            
         //   IActionResult add(int id)
           // {
            //_context.SaveChanges();
            // return RedirectToAction();
            //}

            var Emails = new Email            {
                Name = mailRequestModel.Name,
                From=frommail,
                To =mailRequestModel.EmailAddress,
                Subject =mailRequestModel.Subject,
                PhoneNumber=mailRequestModel.PhoneNumber,
                FirmName =mailRequestModel.FirmName ,
                Message =mailRequestModel.Message 


            };
            _context.Add(Emails);

            _context.SaveChanges();









            return new MailResponseModel { Status = true };
        }
        catch (Exception e)
        {
            return new MailResponseModel { Status = false, StatusText = e.Message };
        }

    }

    private IActionResult RedirectToAction(string v)
    {
        throw new NotImplementedException();
    }
}