using System;
using CAS.Entity.Models.DTO.Dictionaries;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.Dictionaries
{

	/// <summary>
	/// Класс, описывает аэропорт
	/// </summary>
	[Table("Airports", "Dictionaries", "ItemId")]
	[Dto(typeof(AirportDTO))]
	[DictionaryCollection(typeof(CommonDictionaryCollection<Airport>))]
	[Serializable]
	public class Airport : AbstractDictionary
	{
		#region public Airport()

		public Airport()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.Airport;
		}

			#endregion

		#region public String ShortName { get; set; }

		/// <summary>
		/// Сокращенное название (4-х буквенное обозначение)
		/// </summary>
		[TableColumn("ShortName")]
		[FormControl("Index", Enabled = true, Order = 2)]
		[ListViewData(100f, "Index", 2)]
		[NotNull]
		public override String ShortName { get; set; }

		#endregion

		#region public String FullName { get; set; }

		/// <summary>
		/// Полное название
		/// </summary>
		[TableColumn("FullName")]
		[FormControl("Name", Enabled = true, Order = 1)]
		[ListViewData(200f, "Name", 1)]
		[NotNull]
		public override String FullName { get; set; }
		#endregion

		#region public override string CommonName { get; set; }
		/// <summary>
		/// Общее имя 
		/// </summary>
		public override string CommonName
		{
			get { return FullName; }
			set { FullName = value; }
		}
		#endregion

		#region public override string Category { get; set; }
		/// <summary>
		/// категория записи
		/// </summary>
		public override string Category
		{
			get { return FullName; }
			set { FullName = value; }
		}
		#endregion

		#region public int Altitude { get; set; }
		/// <summary>
		/// Высота над уровнем моря
		/// </summary>
		[TableColumn("Altitude")]
		[FormControl("Altitude")]
		[ListViewData(100f, "Altitude")]
		[MinMaxValue(-1000, 8848)]
		public int Altitude { get; set; }

		#endregion

		#region public Int32 TimeBeginning { get; set; }
		/// <summary>
		/// Начало работы аэропорта
		/// </summary>
		[TableColumnAttribute("TimeBeginning")]
		public Int32 TimeBeginning { get; set; }
		#endregion

		#region public Int32 TimeEnd { get; set; }
		/// <summary>
		/// Конец работы аэропорта
		/// </summary>
		[TableColumnAttribute("TimeEnd")]
		public Int32 TimeEnd { get; set; }
		#endregion

		#region public TimeSpan TimeSpanTimeBeginning
		/// <summary>
		/// Время начала работы аэропорта
		/// </summary>
		[FormControl("Start time")]
		[ListViewData(100f, "Start time")]
		public TimeSpan TimeSpanTimeBeginning
		{
			get
			{
				TimeSpan time = new TimeSpan(TimeBeginning / 60, TimeBeginning - (TimeBeginning / 60) * 60, 0);
				return time;
			}
			set { TimeBeginning = Convert.ToInt32(value.TotalMinutes); }
		}
		#endregion

		#region public TimeSpan TimeSpanTimeEnd
		/// <summary>
		/// Время закрытия аэропорта
		/// </summary>
		[ListViewData(100f, "End time")]
		[FormControl("End time")]
		public TimeSpan TimeSpanTimeEnd
		{
			get
			{
				TimeSpan time = new TimeSpan(TimeEnd / 60, TimeEnd - (TimeEnd / 60) * 60, 0);
				return time;
			}
			set { TimeEnd = Convert.ToInt32(value.TotalMinutes); }
		}
		#endregion

		#region public override void SetProperties(AbstractDictionary dictionary)
		public override void SetProperties(AbstractDictionary dictionary)
		{
			if (dictionary is Airport)
				SetProperties((Airport)dictionary);
		}
		#endregion

		#region public void SetProperties(Airport dictionary)
		public void SetProperties(Airport dictionary)
		{
			FullName = dictionary.FullName;
			ShortName = dictionary.ShortName;
			CommonName = dictionary.CommonName;
			Category = dictionary.Category;
			Altitude = dictionary.Altitude;
			TimeBeginning = dictionary.TimeBeginning;
			TimeEnd = dictionary.TimeEnd;
		}
		#endregion

		#region  public override string ToString()

		/// <summary>
		/// Возвращает комбинацию полей ShortName+" "+ FullName;
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return ShortName + " " + FullName;
		}

		#endregion

	}
}