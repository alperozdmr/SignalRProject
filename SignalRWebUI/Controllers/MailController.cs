using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;

namespace SignalRWebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreateMailDto var)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("SignalR Rezervasyon", "alozdemir23@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", var.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = var.Body; ;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = var.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("alozdemir23@gmail.com", "yyfy vmjh rsla hwgl");

            client.Send(mimeMessage);
            client.Disconnect(true);

            return RedirectToAction("Index", "Category");
        }
    }
}
