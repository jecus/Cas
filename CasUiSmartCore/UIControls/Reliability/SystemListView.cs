using System;
using System.Collections.Generic;
using System.Linq;
using CAS.UI.Helpers;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.Reliability
{
	public partial class SystemListView : BaseGridViewControl<TransferRecord>
	{
		public SystemListView()
		{
			InitializeComponent();
		}

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddDateColumn("Date", (int)(radGridView1.Width * 0.2f));
			AddColumn("From: => To:", (int)(radGridView1.Width * 0.4f));
			AddColumn("Off", (int)(radGridView1.Width * 0.6f));
			AddColumn("On", (int)(radGridView1.Width * 0.6f));
			AddColumn("ATA", (int)(radGridView1.Width * 0.2f));
			AddColumn("Class", (int)(radGridView1.Width * 0.2f));
			AddColumn("Description", (int)(radGridView1.Width * 0.4f));
			AddColumn("Reason", (int)(radGridView1.Width * 0.4f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
		}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(TransferRecord item)

		protected override List<CustomCell> GetListViewSubItems(TransferRecord item)
		{
			var subItems = new List<CustomCell>();
			string on, off,  ata, goodClass, reason = "", description = "", fromTo = "";
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);
			if (item.IsReplaceComponentRemoved)
			{
				off = item.ReplaceComponent.ToString();
				on = item.ParentComponent.ToString();

				ata = item.ReplaceComponent.ATAChapter.ToString();
				goodClass = item.ReplaceComponent.GoodsClass.ToString();

				var tr = item.ReplaceComponent.TransferRecords.LastOrDefault(x => x.TransferDate.Date.Equals(item.TransferDate.Date));
				if (tr?.DestinationObject != null)
				{
					reason = tr.Reason.ToString();
					description = tr.Description;

					var from = "";
					if (tr.FromAircraft != null)
						from = "Aircraft: " + tr.FromAircraft;
					if (tr.FromStore != null)
						from = "Store: " + tr.FromStore;
					if (tr.FromBaseComponent != null)
					{
						if (from != "") from += " ";
						from += "Base Component:" + tr.FromBaseComponent;
					}

					fromTo += $"{from} => {DestinationHelper.GetDestinationObjectString(tr)}";
				}
					
			}
			else
			{
				on = item.ReplaceComponent.ToString();
				off = item.ParentComponent.ToString();

				ata = item.ParentComponent.ATAChapter.ToString();
				goodClass = item.ParentComponent.GoodsClass.ToString();

				var tr = item.ReplaceComponent.TransferRecords.FirstOrDefault(x => x.TransferDate.Date.Equals(item.TransferDate.Date));
				if (tr != null)
				{
					reason = tr.Reason.ToString();
					description = tr.Description;
				}

				var from = "";
				if (item.FromAircraft != null)
					from = "Aircraft: " + item.FromAircraft;
				if (item.FromStore != null)
					from = "Store: " + item.FromStore;
				if (item.FromBaseComponent != null)
				{
					if (from != "") from += " ";
					from += "Base Component:" + item.FromBaseComponent;
				}
				fromTo += $"{from} => {DestinationHelper.GetDestinationObjectString(item)}";
			}
			
			subItems.Add(CreateRow(item.TransferDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString()), item.TransferDate ));
			subItems.Add(CreateRow(fromTo, fromTo ));
			subItems.Add(CreateRow(off, off ));
			subItems.Add(CreateRow(on, on ));
			subItems.Add(CreateRow(ata, ata ));
			subItems.Add(CreateRow(goodClass, goodClass ));
			subItems.Add(CreateRow(description, description ));
			subItems.Add(CreateRow(reason, reason ));
			subItems.Add(CreateRow(author, author ));
			
			return subItems;
		}

		#endregion

		#region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)

		protected override void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			
		}

		#endregion
	}
}
