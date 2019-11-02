using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Setting;
using SmartCore.Purchase;

namespace SmartCore.Mail
{
	public interface IMailSender
	{
		void SendEmail(List<PurchaseRequestRecord> @from, string to, Specialist personnel, Stream stream = null);
	}


	public class MailSender : IMailSender
	{
		private readonly MailSettings _settings;
		
		public MailSender(MailSettings settings)
		{
			_settings = settings;
		}
		
		#region Implementation of IMailSender

		public void SendEmail(List<PurchaseRequestRecord> orderRecords, string to, Specialist personnel,
			Stream stream = null)
		{
			var client = new SmtpClient();
			client.SendCompleted += Client_SendCompleted;

			try
			{
				var mail = new MailMessage
				{
					From = new MailAddress(_settings.Mail),
					To =
					{
						new MailAddress(to)
					},
					Subject = "",
					IsBodyHtml = true,
					Body = GeneratePurchaseTemplate(orderRecords, personnel)

				};

				if (stream != null)
					mail.Attachments.Add(new Attachment(stream, "Order.pdf"));

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

		private string GeneratePurchaseTemplate(List<PurchaseRequestRecord> orderRecords, Specialist specialist)
		{
			var data = "";
			foreach (var record in orderRecords)
			{
				var destination = record.ParentInitialRecord.DestinationObject is Aircraft
					? ((Aircraft)record.ParentInitialRecord.DestinationObject).Model.ShortName
					: "";

				data += $@"<tr><td> {destination}</td>
					<td>{record.Product.Name}</td>
					<td>{record.Product.PartNumber}</td>
					<td>{record.Quantity.ToString("F1")}</td> 
					<td>{record.ParentInitialRecord.Priority}</td>
					</tr>";
			}

			var personnel = specialist.FirstName + " " + specialist.LastName;
			var specialization = specialist.Specialization.ToString();

			return _purchaseTemplate.Replace("{Data}", data).Replace("{Personnel}", personnel).Replace("{Specialization}", specialization);
		}

		private static string _purchaseTemplate => @"
			<p><em>Dear Colleagues,</em></p>
				<p>&nbsp;</p>
			<p><em>Please quote:</em></p>				
		<table style=""width:100%; text-align:center;"" border=""1px"" >
		<tbody>
		<tr>
		<td width=""20%""><strong><em>A/C</em></strong></td>
		<td width=""26%""><strong><em>DESCRIPTION</em></strong></td>
		<td width=""23%""><strong><em>P/N</em></strong></td>
		<td width=""12%""><strong><em>Q-TY</em></strong></td>
		<td width=""23%""><strong><em>PRIORITY</em></strong></td>
		</tr>
		{Data}
		</tbody>
		</table>
			<p>&nbsp;</p>
		<p><em>Best regards,</em></p>
		<p><em>{Personnel}</em></p>
			<p>&nbsp;</p>
		<p><em>{Specialization}</em></p>";
	}
}