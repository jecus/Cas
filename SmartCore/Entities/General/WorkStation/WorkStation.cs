using System;
using CAS.Entity.Models.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.WorkShop
{

    /// <summary>
    /// ����� ��������� �����������
    /// </summary>
    [Serializable]
    [Table("WorkStations", "dbo", "ItemId")]
	[Condition("IsDeleted", "0")]
    [Dto(typeof(WorkStationsDTO))]
    public class WorkStation: BaseEntityObject// IComparable<Store>
    {

        /*
         * ��������
         */

        #region public String Name { get; set; }
        
        /// <summary>
        /// �������� �����������
        /// </summary>
        [TableColumn("StoreName")]
        [FormControl(300,"Name")]
        [NotNull]
        public string Name { get; set; }

        #endregion

        #region public String Location { get; set; }
        
        /// <summary>
        /// ������������ �����������
        /// </summary>
        [TableColumn("Location")]
        [FormControl(300, "Location")]
        [NotNull]
        public string Location { get; set; }

        #endregion

        #region public Int32 OperatorId { get; set; }
       
        /// <summary>
        /// ��������, �������� ����������� �����
        /// </summary>
        [TableColumn("OperatorId")] 
        public int OperatorId { get; set; }

        #endregion

        [TableColumn("Adress")]
        [FormControl(300, "Adress:", 3)]
        public string Adress { get; set; }

        [TableColumn("Phone")]
        [FormControl(300, "Phone:")]
        public string Phone { get; set; }

        [TableColumn("Email")]
        [FormControl(300, "Email:")]
        public string Email { get; set; }

        [TableColumn("Contact")]
        [FormControl(300, "Contact:")]
        public string Contact { get; set; }

        #region public String Remarks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Remarks")] 
        [FormControl(200, "Remarks",5)]
        public string Remarks { get; set; }

        #endregion
        
        /*
         * ��������������, ����������� ����
         */

        #region public Operator Operator { get; set; }
        /// <summary>
        /// ��������, �������� ����������� �����
        /// </summary>
        public Operator Operator { get; set; }
        #endregion

        /*
         * ������
         */

        #region public WorkStation()
        /// <summary>
        /// ������� ����������� ��� �������������� ����������
        /// </summary>
        public WorkStation()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.WorkStation;
        }
        #endregion

        #region public override string ToString()

        /// <summary>
        /// �������������� ��� �������� �������
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name + (Location != "" ? ", " + Location : "");
        }
        #endregion

        #region public int CompareTo(WorkShop y)

        public int CompareTo(WorkShop y)
        {
            return ItemId.CompareTo(y.ItemId);
        }

        #endregion

    }

}

