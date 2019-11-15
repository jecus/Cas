using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using EntityCore.DTO.General;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Setting;
using SmartCore.Entities.NewLoader;
using SmartCore.Purchase;

namespace SmartCore.Mail
{
	public interface IMailSender
	{
		bool CheckForInternetConnection();
		void SendPurchaseEmail(List<PurchaseRequestRecord> records, string to, Specialist personnel, Stream stream = null);
		void SendQuotationEmail(List<RequestForQuotationRecord> records, string to, Specialist personnel);
	}


	public class MailSender : IMailSender
	{
		private readonly MailSettings _settings;

		public MailSender(INewLoader loader)
		{
			_settings = loader.GetObject<SettingDTO, Settings>()?.GlobalSetting.MailSettings; 
		}

		#region Implementation of IMailSender

		public void SendPurchaseEmail(List<PurchaseRequestRecord> records, string to, Specialist personnel, Stream stream = null)
		{
			sendMessage(to, "", "", stream);
		}

		public void SendQuotationEmail(List<RequestForQuotationRecord> records, string to, Specialist personnel)
		{
			sendMessage(to, GenerateQuotationTemplate(records, personnel), "");
		}

		private void sendMessage(string toMail, string body , string subject, Stream stream = null)
		{
			var client = new SmtpClient();
			try
			{
				var mail = new MailMessage
				{
					From = new MailAddress(_settings.Mail),
					To =
					{
						new MailAddress("evgenii.babak@gmail.com")
					},
					Subject = subject,
					IsBodyHtml = true,
					Body = body
				};

				if (stream != null)
					mail.Attachments.Add(new Attachment(stream, "Order.pdf"));

				client.Host = _settings.Host;
				client.Port = _settings.Port;
				client.EnableSsl = _settings.SSl;
				client.Credentials = new NetworkCredential(_settings.Mail, _settings.Password);
				client.DeliveryMethod = SmtpDeliveryMethod.Network;
				client.Send(mail);
			}
			catch (Exception e)
			{
				throw new Exception("Mail.Send: " + e.Message);
			}
		}

		public bool CheckForInternetConnection()
		{
			try
			{
				using (var client = new WebClient())
				using (client.OpenRead("http://google.com/generate_204"))
					return true;
			}
			catch
			{
				return false;
			}
		}

		#endregion

		private string GenerateQuotationTemplate(List<RequestForQuotationRecord> orderRecords, Specialist specialist)
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
					<td>{record.Quantity:F1}</td> 
					<td>{record.ParentInitialRecord.Priority}</td>
					</tr>";
			}

			var personnel = specialist.FirstName + " " + specialist.LastName;
			var specialization = specialist.Specialization.ToString();
			
			var placeholders = new Dictionary<string,string>
			{
				["{Data}"] = data,
				["{Personnel}"] = personnel,
				["{Specialization}"] = specialization,
			};

			return placeholders.Aggregate(_quotationTemplate, (current, placeholder) => current.Replace(placeholder.Key, placeholder.Value));
		}

		private static string _quotationTemplate => @"
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