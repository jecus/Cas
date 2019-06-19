using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.ComplianceControls;
using CAS.UI.UIControls.NewGrid;
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
			AddColumn("Date", (int)(radGridView1.Width * 0.2f));
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
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
        }
        #endregion

        #region protected override void SetItemColor(ListViewItem listViewItem, TransferRecord item)
        //protected override void SetItemColor(ListViewItem listViewItem, TransferRecord item)
        //{
        //    if (!item.PODR && !item.DODR)
        //    {
        //        //запись НЕподтверждена НИ отправителем, НИ получателем
        //        listViewItem.BackColor = Color.FromArgb(Highlight.Yellow.Color);
        //    }

        //    if (!item.PODR && item.DODR)
        //    {
        //        //запись НЕподтверждена отправителем, но подтверждена получателем
        //        listViewItem.BackColor = Color.FromArgb(Highlight.Green.Color);
        //    }

        //    if(item.PODR && !item.DODR)
        //    {
        //        //запись подтверждена отправителем, но НЕподтверждена получателем
        //        listViewItem.BackColor = Color.FromArgb(Highlight.Red.Color);
        //    }
        //}
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
	        var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

	        CreateRow(item.TransferDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString()), item.TransferDate );
	        CreateRow(fromTo, fromTo );
			CreateRow(quantity, item.ParentComponent.QuantityIn );
			CreateRow(item.ParentComponent.ATAChapter.ToString(), item.ParentComponent.ATAChapter );
	        CreateRow(item.GoodsClass.ToString(), item.GoodsClass );
			
	        if (IsStore)
	        {
		        CreateRow(descriptionOn, descriptionOn );
		        CreateRow(descriptionOff, descriptionOff );
	        }
	        else
	        {
		        CreateRow(descriptionOff, descriptionOff );
				CreateRow(descriptionOn, descriptionOn );
	        }

	        CreateRow(item.Reason.ToString(), item.Reason );
			CreateRow(item.Description, item.Description );
			CreateRow(item.Remarks, item.Remarks );
			CreateRow(released, released );
			CreateRow(received, received );
			CreateRow(item.ParentComponent.FromSupplier.ToString(), item.ParentComponent.FromSupplier );
			CreateRow(fromSupplierReciveDate, item.ParentComponent.FromSupplierReciveDate );
			CreateRow(author, author );

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
