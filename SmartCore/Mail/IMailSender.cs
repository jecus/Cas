using System.Collections.Generic;
using System.IO;
using SmartCore.Entities.General.Personnel;
using SmartCore.Purchase;

namespace SmartCore.Mail
{
	public interface IMailSender
	{
		bool CheckForInternetConnection();
		void SendPurchaseEmail(List<PurchaseRequestRecord> records, string to, Specialist personnel, Stream stream = null);
		void SendQuotationEmail(List<RequestForQuotationRecord> records, string to, Specialist personnel);
		void SendPurchaseToShipper(string to, Supplier shipper, Specialist personnel, string station, Stream stream = null);
	}
}