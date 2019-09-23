using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.NewGrid;
using CAS.UI.UIControls.StoresControls;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Purchase;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.SupplierControls
{
	public partial class ProcessingListView : BaseGridViewControl<IBaseEntityObject>
	{
		#region public ProcessingListView()

		public ProcessingListView()
		{
			InitializeComponent();
		}

		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			AddColumn("To", (int)(radGridView1.Width * 0.6f));
			AddColumn("From", (int)(radGridView1.Width * 0.6f));
			AddColumn("Supplier Type", (int)(radGridView1.Width * 0.2f));
			AddColumn("Approved", (int)(radGridView1.Width * 0.2f));
			AddDateColumn("Date of shipment", (int)(radGridView1.Width * 0.4f));
			AddDateColumn("Date of receipt", (int)(radGridView1.Width * 0.4f));
			AddColumn("Reason", (int)(radGridView1.Width * 0.2f));
			AddColumn("Part. No", (int)(radGridView1.Width * 0.2f));
			AddColumn("Description", (int)(radGridView1.Width * 0.8f));
			AddColumn("Serial No", (int)(radGridView1.Width * 0.2f));
			AddColumn("Code", (int)(radGridView1.Width * 0.4f));
			AddColumn("Class", (int)(radGridView1.Width * 0.4f));
			AddColumn("Batch No", (int)(radGridView1.Width * 0.4f));
			AddColumn("ID No", (int)(radGridView1.Width * 0.4f));
			AddColumn("State", (int)(radGridView1.Width * 0.4f));
			AddColumn("Status", (int)(radGridView1.Width * 0.4f));
			AddColumn("Warranty", (int)(radGridView1.Width * 0.4f));
			AddColumn("Qty", (int)(radGridView1.Width * 0.2f));
			AddColumn("Supplier", 75);
			AddColumn("IsPool", (int)(radGridView1.Width * 0.2f));
			AddColumn("IsDangerous", (int)(radGridView1.Width * 0.2f));
			AddColumn("Remarks", (int)(radGridView1.Width * 0.4f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}

		#endregion

		#region protected override List<CustomCell> GetListViewSubItems(IBaseCoreObject item)

		protected override List<CustomCell> GetListViewSubItems(IBaseEntityObject item)
		{
			var subItems = new List<CustomCell>();
			
			string from = "", to = "", supplierType = "", approved = "", reason = "",
				partNumber = "", description = "", serialNumber = "",
				code = "", classString = "", batchNumber = "", qty = "",
				idNumber = "", status = "", supplier = "", remarks = "";
			DateTime shipment = DateTimeExtend.GetCASMinDateTime(), receipt = DateTimeExtend.GetCASMinDateTime();
			var position = ComponentStorePosition.UNK;
			var warranty = Lifelength.Null;
			bool isPool = false, isDangerous = false;


			var parent = item as IDirective;
			if (parent == null)
				return subItems;

			string author = "";

			if (parent is Component)
			{
				var componentItem = (Component)parent;
				var transferRecord = componentItem.TransferRecords.GetLast();

				if (transferRecord.FromAircraft != null)
					from = "Aircraft: " + transferRecord.FromAircraft;
				else if (transferRecord.FromStore != null)
					from = "Store: " + transferRecord.FromStore;
				if (transferRecord.FromBaseComponent != null)
				{
					if (from != "") from += " ";
					from += "Base Component:" + transferRecord.FromBaseComponent;
				}

				if (transferRecord.DestinationObject != null)
					to = transferRecord.DestinationObject.ToString();


				supplierType = transferRecord.DestinationObjectType == SmartCoreType.Supplier ? (transferRecord.DestinationObject as Supplier).SupplierClass.ToString() : componentItem.FromSupplier.SupplierClass.ToString();

				author = GlobalObjects.CasEnvironment.GetCorrector(componentItem);

				approved = componentItem.FromSupplier.Approved ? "Yes" : "No";
				shipment = transferRecord.TransferDate;
				receipt = transferRecord.SupplierReceiptDate >= DateTimeExtend.GetCASMinDateTime() ? transferRecord.SupplierReceiptDate : DateTimeExtend.GetCASMinDateTime();
				reason = transferRecord.Reason.ToString();
				partNumber = componentItem.Product?.PartNumber ?? componentItem.PartNumber;
				description = componentItem.Description;
				serialNumber = componentItem.SerialNumber;
				code = componentItem.Product != null ? componentItem.Product.Code : componentItem.Code;
				classString = componentItem.GoodsClass.ToString();
				batchNumber = componentItem.BatchNumber;
				idNumber = componentItem.IdNumber;
				position = componentItem.TransferRecords.GetLast().State;
				status = componentItem.ComponentStatus.ToString();
				warranty = componentItem.Warranty;
				qty = $"{componentItem.Quantity:0.##}" + (componentItem.Measure != null ? " " + componentItem.Measure + "(s)" : "");
				supplier = componentItem.FromSupplier.ToString();
				isPool = componentItem.IsPOOL;
				isDangerous = componentItem.IsDangerous;
				remarks = componentItem.Remarks;
			}

			subItems.Add(CreateRow(to, to ));
			subItems.Add(CreateRow(from, from ));
			subItems.Add(CreateRow(supplierType, supplierType ));
			subItems.Add(CreateRow(approved, approved ));
			subItems.Add(CreateRow(shipment.ToString(new GlobalTermsProvider()["DateFormat"].ToString()), shipment ));
			subItems.Add(CreateRow(receipt.ToString(new GlobalTermsProvider()["DateFormat"].ToString()), receipt ));
			subItems.Add(CreateRow(reason, reason ));
			subItems.Add(CreateRow(partNumber, partNumber ));
			subItems.Add(CreateRow(description, description ));
			subItems.Add(CreateRow(serialNumber, serialNumber ));
			subItems.Add(CreateRow(code, code ));
			subItems.Add(CreateRow(classString, classString ));
			subItems.Add(CreateRow(batchNumber, batchNumber ));
			subItems.Add(CreateRow(idNumber, idNumber ));
			subItems.Add(CreateRow(position.ToString().ToUpper(), position ));
			subItems.Add(CreateRow(status, status ));
			subItems.Add(CreateRow(warranty.ToString(), warranty ));
			subItems.Add(CreateRow(qty, qty ));
			subItems.Add(CreateRow(supplier, supplier ));
			subItems.Add(CreateRow(isPool ? "Yes" : "No", isPool ));
			subItems.Add(CreateRow(isDangerous ? "Yes" : "No", isDangerous ));
			subItems.Add(CreateRow(remarks, remarks ));
			subItems.Add(CreateRow(author, author ));

			return subItems;
		}

		#endregion

		#region protected override void SetGroupsToItems(int columnIndex)

		/// <summary>
		/// Возвращает название группы в списке агрегатов текущего склада, согласно тому, какого типа элемент
		/// </summary>
		//protected override void SetGroupsToItems(int columnIndex)
		//{
		//	itemsListView.Groups.Clear();
		//	itemsListView.Groups.AddRange(new[]
		//	{
		//		new ListViewGroup("Engines", "Engines"),
		//		new ListViewGroup("APU's", "APU's"),
		//		new ListViewGroup("Landing Gears", "Landing Gears"),
		//	});
		//	foreach (ListViewItem item in ListViewItemList.OrderBy(x => x.Text))
		//	{
		//		var temp = "";

		//		if (!(item.Tag is IDirective)) continue;

		//		var parent = (IDirective)item.Tag;

		//		#region Группировка по типу задачи

		//		if (parent is Component)
		//		{
		//			var component = (Component)parent;

		//			if (component.ParentBaseComponent != null)
		//			{
		//				var baseComponent = component.ParentBaseComponent;//TODO:(Evgenii Babak) заменить на использование ComponentCore 
		//				var tr = baseComponent.TransferRecords.GetLast();
		//				temp = tr.DestinationObjectType.ToString();
		//			}
		//			else
		//			{
		//				var tr = component.TransferRecords.GetLast();
		//				temp = tr.DestinationObjectType == SmartCoreType.Supplier ? "Customer/Vendor" : tr.DestinationObjectType.ToString();
		//			}
		//			itemsListView.Groups.Add(temp, temp);
		//			item.Group = itemsListView.Groups[temp];
		//		}
		//		#endregion
		//	}
		//}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
			{
				var dp = ScreenAndFormManager.GetEditScreenOrForm((BaseEntityObject)SelectedItem);
				if (dp.DisplayerType == DisplayerType.Screen)
					e.SetParameters(dp);
				else
				{
					if (dp.Form.ShowDialog() == DialogResult.OK)
					{
						if (dp.Form is ConsumablePartAndKitForm)
						{
							var changedJob = ((ConsumablePartAndKitForm)dp.Form)._consumablePart;
							radGridView1.SelectedRows[0].Tag = changedJob;

							var subs = GetListViewSubItems(SelectedItem);
							for (int i = 0; i < subs.Count; i++)
								radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
						}
					}

					e.Cancel = true;
				}
			}
		}
		#endregion

		#region protected override void SetItemColor(GridViewRowInfo listViewItem, IBaseCoreObject item)

		protected override void SetItemColor(GridViewRowInfo listViewItem, IBaseEntityObject item)
		{
			if (item is Component)
			{
				var component = (Component)item;
				var transferRecord = component.TransferRecords.GetLast();

				if (transferRecord.SupplierNotify?.CalendarValue != null)
				{
					var notifyDate = transferRecord.SupplierReceiptDate.AddDays(transferRecord.SupplierNotify.CalendarValue.Value * -1);

					if (DateTime.Today >= notifyDate && DateTime.Today <= transferRecord.SupplierReceiptDate)
					{
						foreach (GridViewCellInfo cell in listViewItem.Cells)
						{
							cell.Style.CustomizeFill = true;
							cell.Style.BackColor = Color.FromArgb(Highlight.Yellow.Color);
						}
					}
					else if (DateTime.Today > transferRecord.SupplierReceiptDate)
					{
						foreach (GridViewCellInfo cell in listViewItem.Cells)
						{
							cell.Style.CustomizeFill = true;
							cell.Style.BackColor = Color.FromArgb(Highlight.Red.Color);
						}
					}
				}
			}
		}

		#endregion
	}
}
