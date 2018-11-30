
using CAS.UI.UIControls.HangarControls;

namespace CAS.UI.UIControls.OpepatorsControls
{
    partial class OperatorSummaryScreen
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanelReferences = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelAircrafts = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelStores = new System.Windows.Forms.FlowLayoutPanel();
            this._aircrafts = new CAS.UI.UIControls.AircraftsControls.AircraftCollectionControl();
            this._vehicles = new CAS.UI.UIControls.AircraftsControls.VehicleCollectionControl();
            this._hangars = new HangarCollectionControl();
            this._stores = new CAS.UI.UIControls.StoresControls.StoreCollectionControl();
            this._workShops = new CAS.UI.UIControls.StoresControls.WorkShopCollectionControl();
            this._operatorInfoReference = new CAS.UI.UIControls.OpepatorsControls.OperatorInfoReference();
            this._operationalReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
            this._personnelReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
            this._purchaseReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
            this._groundEquipmentReferenceContainer = new CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer();
            this.headerControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanelReferences.SuspendLayout();
            this.flowLayoutPanelAircrafts.SuspendLayout();
            this.flowLayoutPanelStores.SuspendLayout();
            this.SuspendLayout();
            // 
            // aircraftHeaderControl1
            //
            this.aircraftHeaderControl1.ChildClickable = true;
            this.aircraftHeaderControl1.OperatorClickable = true;
            this.aircraftHeaderControl1.NextClickable = true;
            this.aircraftHeaderControl1.PrevClickable = true;
            // 
            // headerControl
            // 
            this.headerControl.Size = new System.Drawing.Size(985, 58);
            this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControl1ReloadRised);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanelReferences);
            this.panel1.Controls.Add(this.flowLayoutPanelAircrafts);
            this.panel1.Controls.Add(this.flowLayoutPanelStores);
            this.panel1.Size = new System.Drawing.Size(973, 478);
            // 
            // statusControl
            // 
            this.statusControl.MinimumSize = new System.Drawing.Size(1000, 35);
            this.statusControl.Size = new System.Drawing.Size(1000, 35);
            // 
            // flowLayoutPanelReferences
            // 
            this.flowLayoutPanelReferences.AutoScroll = true;
            //this.flowLayoutPanelReferences.AutoSize = true;
            //this.flowLayoutPanelReferences.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelReferences.Controls.Add(this._operatorInfoReference);
            this.flowLayoutPanelReferences.Controls.Add(this._operationalReferenceContainer);
            this.flowLayoutPanelReferences.Controls.Add(this._personnelReferenceContainer);
            this.flowLayoutPanelReferences.Controls.Add(this._purchaseReferenceContainer);
            this.flowLayoutPanelReferences.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.flowLayoutPanelReferences.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelReferences.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelReferences.Name = "flowLayoutPanelReferences";
            this.flowLayoutPanelReferences.MinimumSize = new System.Drawing.Size(400, 10);
            //this.flowLayoutPanelReferences.MaximumSize = new System.Drawing.Size(400, 0);
            this.flowLayoutPanelReferences.Size = new System.Drawing.Size(400, 622);
            this.flowLayoutPanelReferences.TabIndex = 0;
            this.flowLayoutPanelReferences.WrapContents = false;
            // 
            // flowLayoutPanelAircrafts
            // 
            this.flowLayoutPanelAircrafts.AutoScroll = true;
            //this.flowLayoutPanelReferences.AutoSize = true;
            //this.flowLayoutPanelReferences.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelAircrafts.Controls.Add(this._aircrafts);
            this.flowLayoutPanelAircrafts.Controls.Add(this._vehicles);
            this.flowLayoutPanelAircrafts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.flowLayoutPanelAircrafts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelAircrafts.Location = new System.Drawing.Point(400, 0);
            this.flowLayoutPanelAircrafts.Name = "flowLayoutPanelAircrafts";
            this.flowLayoutPanelAircrafts.MinimumSize = new System.Drawing.Size(400, 10);
            //this.flowLayoutPanelReferences.MaximumSize = new System.Drawing.Size(400, 0);
            this.flowLayoutPanelAircrafts.Size = new System.Drawing.Size(400, 622);
            this.flowLayoutPanelAircrafts.TabIndex = 1;
            this.flowLayoutPanelAircrafts.WrapContents = false;
            // 
            // flowLayoutPanelStores
            // 
            this.flowLayoutPanelStores.AutoScroll = true;
            //this.flowLayoutPanelReferences.AutoSize = true;
            //this.flowLayoutPanelReferences.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelStores.Controls.Add(this._hangars);
            this.flowLayoutPanelStores.Controls.Add(this._groundEquipmentReferenceContainer);
            this.flowLayoutPanelStores.Controls.Add(this._stores);
            this.flowLayoutPanelStores.Controls.Add(this._workShops);
            this.flowLayoutPanelStores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.flowLayoutPanelStores.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelStores.Location = new System.Drawing.Point(800, 0);
            this.flowLayoutPanelStores.Name = "flowLayoutPanelAircrafts";
            this.flowLayoutPanelStores.MinimumSize = new System.Drawing.Size(400, 10);
            //this.flowLayoutPanelReferences.MaximumSize = new System.Drawing.Size(400, 0);
            this.flowLayoutPanelStores.Size = new System.Drawing.Size(400, 622);
            this.flowLayoutPanelStores.TabIndex = 2;
            this.flowLayoutPanelStores.WrapContents = false;
            // 
            // operatorInfoReference
            // 
            this._operatorInfoReference.Size = new System.Drawing.Size(200, 100);
            // 
            // _operationalReferenceContainer
            // 
            this._operationalReferenceContainer.Enabled = true;
            this._operationalReferenceContainer.Extended = false;
            this._operationalReferenceContainer.AutoSize = true;
            this._operationalReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._operationalReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this._operationalReferenceContainer.Caption = "Operational";
            this._operationalReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
            this._operationalReferenceContainer.Size = new System.Drawing.Size(200, 200);
            this._operationalReferenceContainer.TabIndex = 0;
            this._operationalReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            // 
            // _personnelReferenceContainer
            // 
            this._personnelReferenceContainer.Enabled = true;
            this._personnelReferenceContainer.Extended = false;
            this._personnelReferenceContainer.AutoSize = true;
            this._personnelReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._personnelReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this._personnelReferenceContainer.Caption = "Personnel";
            this._personnelReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
            this._personnelReferenceContainer.Size = new System.Drawing.Size(200, 200);
            this._personnelReferenceContainer.TabIndex = 0;
            this._personnelReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            // 
            // _groundEquipmentReferenceContainer
            // 
            this._groundEquipmentReferenceContainer.Enabled = true;
            this._groundEquipmentReferenceContainer.Extended = false;
            this._groundEquipmentReferenceContainer.AutoSize = true;
            this._groundEquipmentReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._groundEquipmentReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this._groundEquipmentReferenceContainer.Caption = "Ground Equip.";
            this._groundEquipmentReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
            this._groundEquipmentReferenceContainer.Size = new System.Drawing.Size(200, 200);
            this._groundEquipmentReferenceContainer.TabIndex = 0;
            this._groundEquipmentReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            // 
            // _purchaseReferenceContainer
            // 
            this._purchaseReferenceContainer.Enabled = true;
            this._purchaseReferenceContainer.Extended = false;
            this._purchaseReferenceContainer.AutoSize = true;
            this._purchaseReferenceContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._purchaseReferenceContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this._purchaseReferenceContainer.Caption = "Purchase";
            this._purchaseReferenceContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
            this._purchaseReferenceContainer.Size = new System.Drawing.Size(200, 200);
            this._purchaseReferenceContainer.TabIndex = 0;
            this._purchaseReferenceContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            // 
            // _aircrafts
            // 
            this._aircrafts.AutoSize = true;
            this._aircrafts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._aircrafts.Location = new System.Drawing.Point(0, 0);
            this._aircrafts.Margin = new System.Windows.Forms.Padding(4);
            this._aircrafts.MaximumSize = new System.Drawing.Size(533, 0);
            this._aircrafts.MinimumSize = new System.Drawing.Size(67, 62);
            this._aircrafts.Name = "_aircrafts";
            this._aircrafts.Size = new System.Drawing.Size(352, 182);
            this._aircrafts.TabIndex = 1;
            // 
            // _vehicles
            // 
            this._vehicles.AutoSize = true;
            this._vehicles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._vehicles.Extended = false;
            this._vehicles.Location = new System.Drawing.Point(0, 0);
            this._vehicles.Margin = new System.Windows.Forms.Padding(4);
            this._vehicles.MaximumSize = new System.Drawing.Size(533, 0);
            this._vehicles.MinimumSize = new System.Drawing.Size(67, 62);
            this._vehicles.Name = "_vehicles";
            this._vehicles.Size = new System.Drawing.Size(352, 182);
            this._vehicles.TabIndex = 2;
            // 
            // _hangars
            // 
            this._hangars.AutoSize = true;
            this._hangars.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._hangars.Extended = true;
            this._hangars.Location = new System.Drawing.Point(0, 0);
            this._hangars.Margin = new System.Windows.Forms.Padding(4);
            this._hangars.MaximumSize = new System.Drawing.Size(533, 0);
            this._hangars.MinimumSize = new System.Drawing.Size(67, 62);
            this._hangars.Name = "_hangars";
            this._hangars.Size = new System.Drawing.Size(288, 113);
            this._hangars.TabIndex = 2;
            // 
            // _stores
            // 
            this._stores.AutoSize = true;
            this._stores.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._stores.Extended = false;
            this._stores.Location = new System.Drawing.Point(0, 0);
            this._stores.Margin = new System.Windows.Forms.Padding(4);
            this._stores.MaximumSize = new System.Drawing.Size(533, 0);
            this._stores.MinimumSize = new System.Drawing.Size(67, 62);
            this._stores.Name = "_stores";
            this._stores.Size = new System.Drawing.Size(288, 113);
            this._stores.TabIndex = 2;
            // 
            // _workShops
            // 
            this._workShops.AutoSize = true;
            this._workShops.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._workShops.Extended = false;
            this._workShops.Location = new System.Drawing.Point(0, 0);
            this._workShops.Margin = new System.Windows.Forms.Padding(4);
            this._workShops.MaximumSize = new System.Drawing.Size(533, 0);
            this._workShops.MinimumSize = new System.Drawing.Size(67, 62);
            this._workShops.Name = "_workShops";
            this._workShops.Size = new System.Drawing.Size(288, 113);
            this._workShops.TabIndex = 2;
            // 
            // DirectiveAddingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ShowTopPanelContainer = false;
            this.Name = "AircraftGeneralDataScreen";
            this.ShowAircraftStatusPanel = false;
            this.Size = new System.Drawing.Size(973, 621);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.headerControl.ResumeLayout(false);
            this.headerControl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanelReferences.ResumeLayout(false);
            this.flowLayoutPanelReferences.PerformLayout();
            this.flowLayoutPanelAircrafts.ResumeLayout(false);
            this.flowLayoutPanelAircrafts.PerformLayout();
            this.flowLayoutPanelStores.ResumeLayout(false);
            this.flowLayoutPanelStores.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelReferences;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAircrafts;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelStores;
        private CAS.UI.UIControls.AircraftsControls.AircraftCollectionControl _aircrafts;
        private CAS.UI.UIControls.AircraftsControls.VehicleCollectionControl _vehicles;
        private CAS.UI.UIControls.OpepatorsControls.OperatorInfoReference _operatorInfoReference;
        private CAS.UI.UIControls.StoresControls.StoreCollectionControl _stores;
        private HangarCollectionControl _hangars;
        private CAS.UI.UIControls.StoresControls.WorkShopCollectionControl _workShops;
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _operationalReferenceContainer;
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _personnelReferenceContainer;
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _purchaseReferenceContainer;
        private CAS.UI.UIControls.ReferenceControls.ReferenceLinkLabelCollectionContainer _groundEquipmentReferenceContainer;
    }
}
