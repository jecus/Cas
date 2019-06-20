using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.General.Mail;
using SmartCore.Purchase;
using Convert = SmartCore.Auxiliary.Convert;

namespace CAS.UI.UIControls.MailControls
{
	public partial class MailChatListView : BaseGridViewControl<MailChats>
	{
		#region Constrcuctor

		public MailChatListView()
		{
			InitializeComponent();
		}

		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			AddColumn("From - To", (int)(radGridView1.Width * 0.2f));
			AddColumn("Description", (int)(radGridView1.Width * 0.2f));
			AddColumn("CreateDate", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(MailChats item)

		protected override List<CustomCell> GetListViewSubItems(MailChats item)
		{
			var operatorName = GlobalObjects.CasEnvironment.Operators[0].Name;
			var from = item.SupplierFrom != Supplier.Unknown ? item.SupplierFrom.ToString() : operatorName;
			var to = item.SupplierTo != Supplier.Unknown ? item.SupplierTo.ToString() : operatorName;

			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);
			var fromTo = $"{from} - {to}";

			return new List<CustomCell>
			{
				CreateRow(fromTo, fromTo ),
				CreateRow(item.Description, item.Description ),
				CreateRow(Convert.GetDateFormat(item.CreateDate), item.CreateDate ),
				CreateRow(author, author )
			};
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
			{
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
				e.DisplayerText = "MailListScreen";
				e.RequestedEntity = new MailListScreen(GlobalObjects.CasEnvironment.Operators[0], SelectedItem);
			}
		}

		#endregion

	}
}
