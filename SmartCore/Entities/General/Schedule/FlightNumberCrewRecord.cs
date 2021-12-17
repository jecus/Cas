using System;
using System.Reflection;
using CAS.Entity.Models.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Schedule
{

    /// <summary>
    /// �����, ��������� ��������� ����� ������� �� ����������� ����
    /// </summary>
    [Table("FlightNumberCrewRecords", "dbo", "ItemId")]
    [Dto(typeof(FlightNumberCrewRecordDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
    public class FlightNumberCrewRecord : BaseEntityObject
    {
        private static Type _thisType;
        /*
        *  ��������
        */

        #region public Int32 FlightNumberId { get; set; }
        /// <summary>
		/// ������������� �����
		/// </summary>
        [TableColumnAttribute("FlightNumberId")]
        [ParentAttribute]
        public FlightNumber FlightNumber { get; set; }

        public static PropertyInfo FlightNumberIdProperty
        {
            get { return GetCurrentType().GetProperty("FlightNumber"); }
        }

		#endregion

        #region public Int32 Specialization { get; set; }
        /// <summary>
        /// ������������� ��������� 
        /// </summary>
        [TableColumnAttribute("SpecializationId")]
        [FormControl("Occupation")]
        [ListViewData(250f, "Occupation")]
        [NotNull]
        public Specialization Specialization { get; set; }
        #endregion

        #region public Int32 Count { get; set; }
        /// <summary>
        /// ���������� ������������ ������ ���������, ��������� ��� �����
        /// </summary>
        [TableColumnAttribute("Count")]
        [FormControl("Count")]
        [ListViewData(100f, "Count")]
        [MinMaxValue(1,10)]
        public Int32 Count { get; set; }
        #endregion

        /*
		*  ������ 
		*/

        #region public FlightNumberCrewRecord()
        /// <summary>
        /// ������� "������" ������ � ��������� ����� ������� �� ����������� ����
        /// </summary>
        public FlightNumberCrewRecord()
        {
            Count = 1;
            SmartCoreObjectType = SmartCoreType.FlightNumberCrewRecord;
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// ����������� ��� �������
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "";
        }
        #endregion   

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(FlightNumberCrewRecord));
        }
		#endregion

		public FlightNumberCrewRecord GetCopyUnsaved(bool marked = true)
		{
			var record = (FlightNumberCrewRecord)MemberwiseClone();
			record.ItemId = -1;
			record.UnSetEvents();

			return record;
		}
	}
}
