using C42_G01_MVC_Demo.DAL.Models;
using System.Net;
using System.Net.Mail;

namespace C42_G01_MVC01_Demo.PL.Helpers
{
	public static class EmailSettings
	{
		public static void SendEmail(Email email)
		{
			var smtpServer = "smtp.elasticemail.com";
			var port = 2525;
			var fromEmail = "tito.nox99@gmail.com";
			var password = "CD4A9869B0DFEF231DAAA15ED0BBE841A1DB"; // Get this from a secure location

			using (var client = new SmtpClient(smtpServer, port))
			{
				client.EnableSsl = false; // Enable SSL for security if supported
				client.Credentials = new NetworkCredential(fromEmail, password);

				var mailMessage = new MailMessage
				{
					From = new MailAddress(fromEmail),
					Subject = email.Subject,
					Body = email.Body,
					IsBodyHtml = false // If the body is HTML, otherwise set it to false
				};
				mailMessage.To.Add(email.To);

				client.Send(mailMessage);
			}
		}

	}
}
