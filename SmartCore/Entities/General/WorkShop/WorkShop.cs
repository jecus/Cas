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
    [Table("WorkShops", "dbo", "ItemId")]
    [Dto(typeof(WorkShopDTO))]
	[Condition("IsDeleted", "0")]
    public class WorkShop: BaseEntityObject// IComparable<Store>
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
        public String Name { get; set; }

        #endregion

        #region public String Location { get; set; }
        
        /// <summary>
        /// ������������ �����������
        /// </summary>
        [TableColumn("Location")]
        [FormControl(300, "Location")]
        [NotNull]
        public String Location { get; set; }

        #endregion

        #region public Int32 OperatorId { get; set; }
       
        /// <summary>
        /// ��������, �������� ����������� �����
        /// </summary>
        [TableColumn("OperatorId")] 
        public Int32 OperatorId { get; set; }

        #endregion

        #region public String Remarks { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Remarks")] 
        [FormControl(200, "Remarks",5)]
        public String Remarks { get; set; }

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

        #region public WorkShop()
        /// <summary>
        /// ������� ����������� ��� �������������� ����������
        /// </summary>
        public WorkShop()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.WorkShop;
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

