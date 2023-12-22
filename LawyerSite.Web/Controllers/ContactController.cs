using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System;
using System.Threading.Tasks;

namespace LawyerSite.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task SendEmail(SendEmailRequestModel requestModel)
        {
            try
            {
                string emailAddress = "cdupartners8@gmail.com";
                string password = "123456tT.";
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587; 
                smtpClient.Credentials = new NetworkCredential(emailAddress, password);
                smtpClient.EnableSsl = true; 

                string body = $"Isim Soyisim : {requestModel.Name} {requestModel.Surname} \n Telefon Numarasi: {requestModel.PhoneNumber} \n Email Adresi: {requestModel.Email} \n \n \n Kullanici Mesaji \n {requestModel.Body}";


                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(emailAddress); 
                //mailMessage.To.Add("cduhukuk@gmail.com"); 
                //mailMessage.To.Add("furkanemrealtintas@gmail.com"); 
                mailMessage.To.Add("avtayfunuzulmez@gmail.com");

                mailMessage.Subject = "Web sitesinden email gonderildi !"; 
                mailMessage.Body = body; 

                smtpClient.Send(mailMessage);
                Console.WriteLine("E-posta başarıyla gönderildi!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderilirken bir hata oluştu: " + ex.Message);
            }

        }
    }
    public class SendEmailRequestModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public string PhoneNumber;
    }
}
