using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.SMS;

namespace SmartCore.Sms
{
	public interface ISMSCore
	{
		void Save(SmsEventType smsEventType);

		void Save(Event smsEvent);
	}
}