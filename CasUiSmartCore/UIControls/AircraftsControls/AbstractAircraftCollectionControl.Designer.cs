using System.Drawing;
using System.Windows.Forms;

namespace CAS.UI.UIControls.AircraftsControls
{
    partial class AbstractAircraftCollectionControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.aircraftsListStatistics = new CAS.UI.UIControls.ReferenceControls.ObjectsListStatistics();
            this.flowLayoutPanelAircrafts = new System.Windows.Forms.FlowLayoutPanel();
            // 
            // aircraftsListStatistics
            // 
            this.aircraftsListStatistics.Amount = 0;
            this.aircraftsListStatistics.AutoSize = true;
            this.aircraftsListStatistics.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.aircraftsListStatistics.Caption = "Aircrafts";
            this.aircraftsListStatistics.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.aircraftsListStatistics.Location = new System.Drawing.Point(0, 30);//todo верхний отступ, раньше был 60
            this.aircraftsListStatistics.Name = "storesListStatistics";
            this.aircraftsListStatistics.Size = new System.Drawing.Size(145, 70);
            this.aircraftsListStatistics.UpperLeftIcon = icons.GrayArrow;
            // 
            // flowLayoutPanelAircrafts
            // 
            this.flowLayoutPanelAircrafts.AutoSize = true;
            this.flowLayoutPanelAircrafts.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelAircrafts.MaximumSize = new Size(WIDTH, 600);
            this.flowLayoutPanelAircrafts.MinimumSize = new Size(WIDTH, 0);
            this.flowLayoutPanelAircrafts.Name = "flowLayoutPanelAircrafts";
            this.flowLayoutPanelAircrafts.Size = new System.Drawing.Size(100, 100);
            this.flowLayoutPanelAircrafts.TabIndex = 8;
            // 
            // AbstractAircraftCollectionControl
            // 
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flowLayoutPanelAircrafts);
            this.Controls.Add(this.aircraftsListStatistics);
        }

        #endregion

        protected ReferenceControls.ObjectsListStatistics aircraftsListStatistics;
        protected System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAircrafts;

    }
}