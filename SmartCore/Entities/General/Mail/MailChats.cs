using System;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Purchase;

namespace SmartCore.Entities.General.Mail
{
	[Table("MailChats", "dbo", "ItemId")]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class MailChats : BaseEntityObject
	{
		#region public Supplier SupplierFrom { get; set; }

		private Supplier _supplierFrom;

		[Child]
		[TableColumn("SupplierFromId")]
		[FormControl("From:", Order = 1)]
		[Filter("From:", Order = 1)]
		public Supplier SupplierFrom
		{
			get { return _supplierFrom ?? Supplier.Unknown; }
			set { _supplierFrom = value; }
		}

		#endregion

		#region public Supplier SupplierTo { get; set; }

		private Supplier _supplierTo;

		[Child]
		[TableColumn("SupplierToId")]
		[FormControl("To:", Order = 2)]
		[Filter("To:", Order = 2)]
		public Supplier SupplierTo
		{
			get { return _supplierTo ?? Supplier.Unknown; }
			set { _supplierTo = value; }
		}

		#endregion

		#region public DateTime CreateDate { get; set; }

		[TableColumn("CreateDate")]
		[FormControl("Create Date:", Order = 4)]
		[Filter("Create Date:", Order = 4)]
		[ListViewData(0.2f, "CreateDate", 3)]
		public DateTime CreateDate { get; set; }

		#endregion

		#region public string Description { get; set; }

		[TableColumn("Description")]
		[FormControl("Description:", Order = 3)]
		[Filter("Description:", Order = 3)]
		[ListViewData(0.3f, "Description", 2)]
		public string Description { get; set; }

		#endregion

		public MailChats()
        {
            ItemId = -1;
			SmartCoreObjectType = SmartCoreType.MailChats;
			CreateDate = DateTime.Today;
		}
	}
}