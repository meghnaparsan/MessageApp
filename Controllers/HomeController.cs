using MessageApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MessageApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult SendSMS()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendSMS(SMSForm sms)
        {
            if (ModelState.IsValid)
            {
                string accountSid = _config["AppVariables:AccountSID"];
                string authToken = _config["AppVariables:AuthToken"];

                TwilioClient.Init(accountSid, authToken);

                var to = new PhoneNumber("+91" + sms.Number);

                var message = MessageResource.Create(
                    to,
                    from: new PhoneNumber(_config["AppVariables:PhoneNumber"]), 
                    body: $"This Message is from " + sms.Name + ". " + sms.Message);


                ViewBag.Message = "Message Sent";
                return View("Confirm");
            }
            else
            {
                return View();
            }
        }

        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task <ActionResult> SendEmail(EmailForm email)
        {
            if (ModelState.IsValid)
            {
                var apiKey = _config ["AppVariables:ApiKey"];
                var client = new SendGridClient (apiKey);
                var from = new EmailAddress (_config["AppVariables:SenderEmail"]);
                var to = new EmailAddress (_config["AppVariables:ReceiverEmail"]);
                var subject = "From SendGrid";
                var plainContent = email.Message;
                var htmlContent = $"<strong>{email.Message}</strong>";
                var message = MailHelper.CreateSingleEmail (
                    from: from,
                    to: to,
                    subject: subject,
                    plainTextContent: plainContent,
                    htmlContent: htmlContent
                );

                var response = await client.SendEmailAsync(message);
                Console.WriteLine (response.StatusCode);
                ViewBag.Message = "Email Sent";
                return View("Confirm");
            }
            else
            {
                return View();
            }
        }
    }
}
