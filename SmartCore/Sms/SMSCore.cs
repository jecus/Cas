using SmartCore.Entities;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.SMS;

namespace SmartCore.Sms
{
	public class SMSCore : ISMSCore
	{
		private readonly IManipulator _manipulator;

		public SMSCore(IManipulator manipulator)
		{
			_manipulator = manipulator;
		}

		#region public void Save(SmsEventType smsEventType)
		/// <summary>
		/// Сохраняет тип события системы безопасности полетов
		/// </summary>
		/// <param name="smsEventType"></param>
		public void Save(SmsEventType smsEventType)
		{
			if (smsEventType == null) return;

			_manipulator.Save((BaseEntityObject)smsEventType);

			foreach (EventCondition eventCondition in smsEventType.EventConditions)
			{
				eventCondition.ParentId = smsEventType.ItemId;
				eventCondition.ParentType = smsEventType.SmartCoreObjectType;
				_manipulator.Save(eventCondition);
			}

			foreach (EventTypeRiskLevelChangeRecord changeRecord in smsEventType.ChangeRecords)
			{
				changeRecord.ParentEventType = smsEventType;
				_manipulator.Save(changeRecord);
			}
		}
		#endregion

		#region public void Save(Event smsEvent)
		/// <summary>
		/// Сохраняет событие системы безопасности полетов
		/// </summary>
		/// <param name="smsEvent"></param>
		public void Save(Event smsEvent)
		{
			if (smsEvent == null) return;

			_manipulator.Save((BaseEntityObject)smsEvent);

			foreach (EventCondition eventCondition in smsEvent.EventConditions)
			{
				eventCondition.ParentId = smsEvent.ItemId;
				eventCondition.ParentType = smsEvent.SmartCoreObjectType;
				_manipulator.Save(eventCondition);
			}
		}
		#endregion
	}
}