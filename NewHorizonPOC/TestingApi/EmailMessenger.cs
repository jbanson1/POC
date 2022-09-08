using System.Net.Mail;
using FluentEmail.Smtp;
using FluentEmail.Core;
using System.Threading.Tasks;
using System;
using System.Text;
using FluentEmail.Razor;

namespace TestingApi
{
    public class EmailMessenger
    {

        public async void Send()
        {
            var sender = new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                //Port = 475
                PickupDirectoryLocation = @"C:\Demos\test.txt"
            });

            var email = await Email
        .From("jdotbans@gmail.com")
        .To("jbansdrive@gmail.com", "Joseph")
        .Subject("Hi Joe!")
        .Body("Fluent email looks great!")
        .SendAsync();
        }

        //static async Task main(string[] args)
        //{

        //    var sender = new SmtpSender(() => new SmtpClient("localhost")
        //    {
        //        EnableSsl = false,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        Port = 475
        //        //PickupDirectoryLocation = @"C:\Demos"
        //    });

        //    Email.DefaultSender = sender;
        //    Email.DefaultRenderer = new RazorRenderer();

        //    StringBuilder template = new();
        //    template.AppendLine("Dear @Model.firstName,");
        //    template.AppendLine("@Model.LastName");

        //    var email = await Email
        //        .From("jdotbans@timco.com")
        //        .To("test@test.com", "sue")
        //        .Subject("New Horizon Healthcare Services")
        //        .UsingTemplate(template.ToString(), new {firstName = "Joe", lastName = "Bans"})
        //        //.Body("Thanks for buying shit")
        //        .SendAsync();

        //        MailMessage newMail = new MailMessage();
        //        // use the Gmail SMTP Host
        //        SmtpClient client = new SmtpClient("smtp.gmail.com");

        //        // Follow the RFS 5321 Email Standard
        //        newMail.From = new MailAddress("jdotbans@gmail.com", "Joseph Banson");

        //        newMail.To.Add("jdotbans@gmail.com");// declare the email subject

        //        newMail.Subject = "My First Email"; // use HTML for the email body

        //        newMail.IsBodyHtml = true; newMail.Body = "<h1> This is my first Templated Email in C# </h1>";

        //        // enable SSL for encryption across channels
        //        client.EnableSsl = true;
        //        // Port 465 for SSL communication
        //        client.Port = 465;
        //        // Provide authentication information with Gmail SMTP server to authenticate your sender account
        //        client.Credentials = new System.Net.NetworkCredential("jdotbans@gmail.com", "Intake2007.");

        //        client.Send(newMail); // Send the constructed mail
        //        Console.WriteLine("Email Sent");

        // }
    }
}
