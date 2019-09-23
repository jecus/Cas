using System.Collections.Generic;
using System.Drawing;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.ComplianceControls;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.ComponentChangeReport
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class ComponentTrackingListView : BaseGridViewControl<TransferRecord>
	{
		public bool IsStore { get; set; }

		#region Constructors

		#region public ComponentsChangeListView()
		///<summary>
		///</summary>
		public ComponentTrackingListView()
		{
			InitializeComponent();

			SortMultiplier = 1;
		}
		#endregion

		#endregion

		#region Methods

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddDateColumn("Date", (int)(radGridView1.Width * 0.2f));
			AddColumn("From: => To:", (int)(radGridView1.Width * 0.4f));
			AddColumn("Qty", (int)(radGridView1.Width * 0.2f));
			AddColumn("ATA:", (int)(radGridView1.Width * 0.2f));
			AddColumn("Class:", (int)(radGridView1.Width * 0.2f));
			AddColumn("Off", (int)(radGridView1.Width * 0.4f));
			AddColumn("On", (int)(radGridView1.Width * 0.4f));
			AddColumn("Reason", (int)(radGridView1.Width * 0.16f));
			AddColumn("Description", (int)(radGridView1.Width * 0.4f));
			AddColumn("Remark", (int)(radGridView1.Width * 0.16f));
			AddColumn("Released", (int)(radGridView1.Width * 0.16f));
			AddColumn("Received", (int)(radGridView1.Width * 0.16f));
			AddColumn("ReceivedForm", (int)(radGridView1.Width * 0.16f));
			AddColumn("ReceivedDate", (int)(radGridView1.Width * 0.16f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override void SetItemColor(GridViewRowInfo listViewItem, BaseEntityObject item)

		protected override void SetItemColor(GridViewRowInfo listViewItem, TransferRecord item)
		{

			if (!item.PODR && !item.DODR)
			{
				//запись НЕподтверждена НИ отправителем, НИ получателем
				foreach (GridViewCellInfo cell in listViewItem.Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.BackColor = Color.FromArgb(Highlight.Yellow.Color);
				}
			}

			if (!item.PODR && item.DODR)
			{
				//запись НЕподтверждена отправителем, но подтверждена получателем
				foreach (GridViewCellInfo cell in listViewItem.Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.BackColor = Color.FromArgb(Highlight.Green.Color);
				}
			}

			if (item.PODR && !item.DODR)
			{
				//запись подтверждена отправителем, но НЕподтверждена получателем
				foreach (GridViewCellInfo cell in listViewItem.Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.BackColor = Color.FromArgb(Highlight.Red.Color);
				}
			}
		}

		#endregion


		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(TransferRecord item)

		protected override List<CustomCell> GetListViewSubItems(TransferRecord item)
		{
			var subItems = new List<CustomCell>();

			var component = item.ParentComponent;
			string descriptionOn = "", descriptionOff = "";

			var fromSupplierReciveDate = item.ParentComponent.FromSupplierReciveDate >= DateTimeExtend.GetCASMinDateTime() ? item.ParentComponent.FromSupplierReciveDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString()) : "";

			string fromTo = "";
			if (item.FromAircraft != null)
			{
				fromTo = "Aircraft: " + item.FromAircraft;
			}
			if (item.FromStore != null)
			{
				fromTo = "Store: " + item.FromStore;
				descriptionOn = component.Description + " " +
					item.Position
					+ " P/N:" + component.PartNumber + " S/N: " + component.SerialNumber;
			} 
			if (item.FromBaseComponent != null)
			{
				if(fromTo != "" ) fromTo += " ";
				fromTo += "Base Component:" + item.FromBaseComponent;
				descriptionOff = component.Description + " " +
					item.Position
					+ " P/N:" + component.PartNumber + " S/N: " + component.SerialNumber;
			}
			if (item.FromSupplier != null)
			{
				fromTo = "Supplier: " + item.FromSupplier;
				descriptionOff = component.Description + " " +
								item.Position
								+ " P/N:" + component.PartNumber + " S/N: " + component.SerialNumber;
			}
			if (item.FromSpecialist != null)
			{
				fromTo = "Employee: " + item.FromSpecialist;
				descriptionOff = component.Description + " " +
								item.Position
								+ " P/N:" + component.PartNumber + " S/N: " + component.SerialNumber;
			}

			if (item.FromAircraft == null && item.FromBaseComponent == null && item.FromStore == null && item.FromSupplier == null && item.FromSpecialist == null)
			{
				if (IsStore)
				{
					descriptionOff = component.Description + " " +
					item.Position
					+ " P/N:" + component.PartNumber + " S/N: " + component.SerialNumber;
				}
				else
				{
					descriptionOn = component.Description + " " +
					item.Position
					+ " P/N:" + component.PartNumber + " S/N: " + component.SerialNumber;
				}
			}

			if (item.DestinationObject != null)
			{
				if (fromTo != "") fromTo += " ";
				fromTo += "=> " + DestinationHelper.GetDestinationObjectString(item);   
			}
			
			string quantity;

			if (item.ParentComponent is BaseComponent)
				quantity = $"{1:0.##}" + (item.ParentComponent.Measure != null ? " " + item.ParentComponent.Measure + "(s)" : "");
			else quantity = $"{item.ParentComponent.QuantityIn:0.##}" + (item.ParentComponent.Measure != null ? " " + item.ParentComponent.Measure + "(s)" : "");

			var released = item.ReleasedSpecialist?.ToString() ?? "";
			var received = item.ReceivedSpecialist?.ToString() ?? "";
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);

			subItems.Add(CreateRow(item.TransferDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString()), item.TransferDate ));
			subItems.Add(CreateRow(fromTo, fromTo));
			subItems.Add(CreateRow(quantity, item.ParentComponent.QuantityIn));
			subItems.Add(CreateRow(item.ParentComponent.ATAChapter.ToString(), item.ParentComponent.ATAChapter));
			subItems.Add(CreateRow(item.GoodsClass.ToString(), item.GoodsClass));
			
			if (IsStore)
			{
				subItems.Add(CreateRow(descriptionOn, descriptionOn));
				subItems.Add(CreateRow(descriptionOff, descriptionOff));
			}
			else
			{
				subItems.Add(CreateRow(descriptionOff, descriptionOff));
				subItems.Add(CreateRow(descriptionOn, descriptionOn));
			}

			subItems.Add(CreateRow(item.Reason.ToString(), item.Reason));
			subItems.Add(CreateRow(item.Description, item.Description ));
			subItems.Add(CreateRow(item.Remarks, item.Remarks));
			subItems.Add(CreateRow(released, released));
			subItems.Add(CreateRow(received, received));
			subItems.Add(CreateRow(item.ParentComponent.FromSupplier.ToString(), item.ParentComponent.FromSupplier));
			subItems.Add(CreateRow(fromSupplierReciveDate, item.ParentComponent.FromSupplierReciveDate));
			subItems.Add(CreateRow(author, author));

			return subItems;
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
			{
				e.Cancel = true;
				TransferRecordForm form = new TransferRecordForm(SelectedItem.ParentComponent, SelectedItem);
				form.ShowDialog();
			}
		}
		#endregion


		#endregion
	}
}
