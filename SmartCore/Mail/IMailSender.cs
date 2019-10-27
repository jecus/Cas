using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Setting;

namespace SmartCore.Mail
{
	public interface IMailSender
	{
		void SendEmail(string from, string to, Stream stream = null);
	}


	public class MailSender : IMailSender
	{
		private readonly MailSettings _settings;

		public MailSender(MailSettings settings)
		{
			_settings = settings;
		}


		#region Implementation of IMailSender

		public void SendEmail(string from, string to, Stream stream = null)
		{
			var client = new SmtpClient();
			client.SendCompleted += Client_SendCompleted;

			try
			{
				var mail = new MailMessage
				{
					From = new MailAddress(from),
					To =
					{
						new MailAddress(to)
					},
					Subject = "",
					Body = ""
				};

				if (stream != null)
					mail.Attachments.Add(new Attachment(stream, "pdf"));

				client.Host = _settings.Host;
				client.Port = _settings.Port;
				client.EnableSsl = _settings.SSl;
				client.Credentials = new NetworkCredential(_settings.Mail, _settings.Password);
				client.DeliveryMethod = SmtpDeliveryMethod.Network;
				client.Send(mail);
				mail.Dispose();
			}
			catch (Exception e)
			{
				throw new Exception("Mail.Send: " + e.Message);
			}
		}

		private void Client_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
		{
			MessageBox.Show("Mail sent successful!");
		}

		#endregion
	}
}