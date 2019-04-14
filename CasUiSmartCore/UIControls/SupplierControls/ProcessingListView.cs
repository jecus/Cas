using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.StoresControls;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.SupplierControls
{
	public partial class ProcessingListView : BaseListViewControl<IBaseCoreObject>
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
			itemsListView.Columns.Clear();
			ColumnHeaderList.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.3f), Text = "To" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.3f), Text = "From" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Supplier Type" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Approved" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Date of shipment" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Date of receipt" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Reason" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Part. No" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.4f), Text = "Description" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Serial No" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Code" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Class" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Batch No" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "ID No" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "State" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Status" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Warranty" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Qty" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = 75, Text = "Supplier" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "IsPool" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "IsDangerous" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Remarks" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Signer" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(IBaseCoreObject item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(IBaseCoreObject item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();
			
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
				return subItems.ToArray();

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

				author = GlobalObjects.CasEnvironment.GetCorrector(componentItem.CorrectorId);

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

			subItems.Add(new ListViewItem.ListViewSubItem { Text = to, Tag = to });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = from, Tag = from });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = supplierType, Tag = supplierType });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = approved, Tag = approved });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = shipment.ToString(new GlobalTermsProvider()["DateFormat"].ToString()), Tag = shipment });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = receipt.ToString(new GlobalTermsProvider()["DateFormat"].ToString()), Tag = receipt });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = reason, Tag = reason });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = partNumber, Tag = partNumber });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = description, Tag = description });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = serialNumber, Tag = serialNumber });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = code, Tag = code });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = classString, Tag = classString });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = batchNumber, Tag = batchNumber });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = idNumber, Tag = idNumber });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = position.ToString().ToUpper(), Tag = position });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = status, Tag = status });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = warranty.ToString(), Tag = warranty });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = qty, Tag = qty });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = supplier, Tag = supplier });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = isPool ? "Yes" : "No", Tag = isPool });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = isDangerous ? "Yes" : "No", Tag = isDangerous });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = remarks, Tag = remarks });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });
			return subItems.ToArray();
		}

		#endregion

		#region protected override void SetGroupsToItems(int columnIndex)

		/// <summary>
		/// Возвращает название группы в списке агрегатов текущего склада, согласно тому, какого типа элемент
		/// </summary>
		protected override void SetGroupsToItems(int columnIndex)
		{
			itemsListView.Groups.Clear();
			itemsListView.Groups.AddRange(new[]
			{
				new ListViewGroup("Engines", "Engines"),
				new ListViewGroup("APU's", "APU's"),
				new ListViewGroup("Landing Gears", "Landing Gears"),
			});
			foreach (ListViewItem item in ListViewItemList.OrderBy(x => x.Text))
			{
				var temp = "";

				if (!(item.Tag is IDirective)) continue;

				var parent = (IDirective)item.Tag;

				#region Группировка по типу задачи

				if (parent is Component)
				{
					var component = (Component)parent;

					if (component.ParentBaseComponent != null)
					{
						var baseComponent = component.ParentBaseComponent;//TODO:(Evgenii Babak) заменить на использование ComponentCore 
						var tr = baseComponent.TransferRecords.GetLast();
						temp = tr.DestinationObjectType.ToString();
					}
					else
					{
						var tr = component.TransferRecords.GetLast();
						temp = tr.DestinationObjectType == SmartCoreType.Supplier ? "Customer/Vendor" : tr.DestinationObjectType.ToString();
					}
					itemsListView.Groups.Add(temp, temp);
					item.Group = itemsListView.Groups[temp];
				}
				#endregion
			}
		}

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
							itemsListView.SelectedItems[0].Tag = changedJob;

							var subs = GetListViewSubItems(SelectedItem);
							for (int i = 0; i < subs.Length; i++)
								itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;
						}
					}

					e.Cancel = true;
				}
			}
		}
		#endregion

		#region protected override void SetItemColor(ListViewItem listViewItem, IBaseCoreObject item)

		protected override void SetItemColor(ListViewItem listViewItem, IBaseCoreObject item)
		{
			if (item is Component)
			{
				var component = (Component)item;
				var transferRecord = component.TransferRecords.GetLast();

				if (transferRecord.SupplierNotify?.CalendarValue != null)
				{
					var notifyDate = transferRecord.SupplierReceiptDate.AddDays(transferRecord.SupplierNotify.CalendarValue.Value * -1);

					if(DateTime.Today >= notifyDate && DateTime.Today <= transferRecord.SupplierReceiptDate)
						listViewItem.BackColor = Color.FromArgb(Highlight.Yellow.Color);
					else if(DateTime.Today > transferRecord.SupplierReceiptDate)
						listViewItem.BackColor = Color.FromArgb(Highlight.Red.Color);

				}
			}
		}

		#endregion
	}
}
