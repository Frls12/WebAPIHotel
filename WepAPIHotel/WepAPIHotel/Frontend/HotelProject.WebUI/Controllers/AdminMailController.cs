using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotalierAdmin", "kmlsnr12@gmail.com"); // mail kimden olacagı
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail); // kime olacagı
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder(); // mesajın içerigi
            bodyBuilder.TextBody = model.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject= model.Subject; // Mesajın başlıgı

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("kmlsnr12@gmail.com", "ojlczhgnzkivzjen");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            return View();
        }
    }
}
