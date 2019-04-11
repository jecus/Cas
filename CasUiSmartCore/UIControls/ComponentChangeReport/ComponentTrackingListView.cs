using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ComplianceControls;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.ComponentChangeReport
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class ComponentTrackingListView : BaseListViewControl<TransferRecord>
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
            itemsListView.Columns.Clear();
            ColumnHeaderList.Clear();

            ColumnHeader columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Date" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "From: => To:" };
            ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Qty:" };
			ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "ATA:" };
	        ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Class:" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Off" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "On" };
            ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Reason" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Description" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Remark" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Released" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Received" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "ReceivedForm" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "ReceivedDate" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Author" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
        #endregion

        #region protected override void SetItemColor(ListViewItem listViewItem, TransferRecord item)
        protected override void SetItemColor(ListViewItem listViewItem, TransferRecord item)
        {
            if (!item.PODR && !item.DODR)
            {
                //запись НЕподтверждена НИ отправителем, НИ получателем
                listViewItem.BackColor = Color.FromArgb(Highlight.Yellow.Color);
            }

            if (!item.PODR && item.DODR)
            {
                //запись НЕподтверждена отправителем, но подтверждена получателем
                listViewItem.BackColor = Color.FromArgb(Highlight.Green.Color);
            }

            if(item.PODR && !item.DODR)
            {
                //запись подтверждена отправителем, но НЕподтверждена получателем
                listViewItem.BackColor = Color.FromArgb(Highlight.Red.Color);
            }
        }
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(TransferRecord item)

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(TransferRecord item)
        {
            var subItems = new List<ListViewItem.ListViewSubItem>();

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
	        var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

			var subItem = new ListViewItem.ListViewSubItem { Text = item.TransferDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString()), Tag = item.TransferDate };
            subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = fromTo, Tag = fromTo };
            subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = quantity, Tag = item.ParentComponent.QuantityIn };
			subItems.Add(subItem);
	        subItem = new ListViewItem.ListViewSubItem { Text = item.ParentComponent.ATAChapter.ToString(), Tag = item.ParentComponent.ATAChapter };
	        subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.GoodsClass.ToString(), Tag = item.GoodsClass };
			subItems.Add(subItem);

	        if (IsStore)
	        {
				subItem = new ListViewItem.ListViewSubItem { Text = descriptionOn, Tag = descriptionOn };
				subItems.Add(subItem);
				subItem = new ListViewItem.ListViewSubItem { Text = descriptionOff, Tag = descriptionOff };
				subItems.Add(subItem);
			}
	        else
	        {
				subItem = new ListViewItem.ListViewSubItem { Text = descriptionOff, Tag = descriptionOff };
				subItems.Add(subItem);
				subItem = new ListViewItem.ListViewSubItem { Text = descriptionOn, Tag = descriptionOn };
				subItems.Add(subItem);
			}


			subItem = new ListViewItem.ListViewSubItem { Text = item.Reason.ToString(), Tag = item.Reason };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Description, Tag = item.Description };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.Remarks, Tag = item.Remarks };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = released, Tag = released };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = received, Tag = received };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = item.ParentComponent.FromSupplier.ToString(), Tag = item.ParentComponent.FromSupplier };
			subItems.Add(subItem);
			subItem = new ListViewItem.ListViewSubItem { Text = fromSupplierReciveDate, Tag = item.ParentComponent.FromSupplierReciveDate };
			subItems.Add(subItem);
			subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });

			return subItems.ToArray();
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
