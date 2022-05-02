using System.ComponentModel;
using CAS.UI.UICAAControls.CAAEducation;
using CAS.UI.UIControls.NewGrid;

namespace CAS.UI.UICAAControls.Specialists
{
    partial class CAAEmployeeTraining
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this._managmentListView = new CAS.UI.UICAAControls.CAAEducation.EducationManagmentListView();
            this.listViewCompliance = new CAS.UI.UICAAControls.CAAEducation.EducationComplianceListView();
            this.labelSkype = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _managmentListView
            // 
            this._managmentListView.ColumnIndexes = null;
            this._managmentListView.ConfigurePaste = null;
            this._managmentListView.CurrentOperator = null;
            this._managmentListView.DisableEdit = false;
            this._managmentListView.Displayer = null;
            this._managmentListView.DisplayerText = null;
            this._managmentListView.EnableCustomSorting = true;
            this._managmentListView.Entity = null;
            this._managmentListView.IgnoreEnterPress = false;
            this._managmentListView.Location = new System.Drawing.Point(0, 0);
            this._managmentListView.MenuOpeningAction = null;
            this._managmentListView.Name = "_managmentListView";
            this._managmentListView.OldColumnIndex = 0;
            this._managmentListView.OperatorId = 0;
            this._managmentListView.PasteComplete = null;
            this._managmentListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this._managmentListView.Size = new System.Drawing.Size(1300, 522);
            this._managmentListView.SortDirection = CAS.UI.UIControls.NewGrid.SortDirection.Asc;
            this._managmentListView.TabIndex = 0;
            // 
            // listViewCompliance
            // 
            this.listViewCompliance.ColumnIndexes = null;
            this.listViewCompliance.ConfigurePaste = null;
            this.listViewCompliance.Displayer = null;
            this.listViewCompliance.DisplayerText = null;
            this.listViewCompliance.EnableCustomSorting = true;
            this.listViewCompliance.Entity = null;
            this.listViewCompliance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.listViewCompliance.IgnoreEnterPress = false;
            this.listViewCompliance.Location = new System.Drawing.Point(3, 572);
            this.listViewCompliance.MenuOpeningAction = null;
            this.listViewCompliance.Name = "listViewCompliance";
            this.listViewCompliance.OldColumnIndex = 2;
            this.listViewCompliance.PasteComplete = null;
            this.listViewCompliance.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.listViewCompliance.Size = new System.Drawing.Size(1040, 315);
            this.listViewCompliance.SortDirection = CAS.UI.UIControls.NewGrid.SortDirection.Asc;
            this.listViewCompliance.TabIndex = 1;
            // 
            // labelSkype
            // 
            this.labelSkype.AutoSize = true;
            this.labelSkype.Font = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelSkype.ForeColor = System.Drawing.Color.DimGray;
            this.labelSkype.Location = new System.Drawing.Point(3, 535);
            this.labelSkype.Name = "labelSkype";
            this.labelSkype.Size = new System.Drawing.Size(181, 34);
            this.labelSkype.TabIndex = 60;
            this.labelSkype.Text = "Compliance";
            // 
            // CAAEmployeeTraining
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelSkype);
            this.Controls.Add(this.listViewCompliance);
            this.Controls.Add(this._managmentListView);
            this.Name = "CAAEmployeeTraining";
            this.Size = new System.Drawing.Size(1046, 890);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private EducationManagmentListView _managmentListView;


        #endregion

        public CAS.UI.UICAAControls.CAAEducation.EducationComplianceListView listViewCompliance;
        private System.Windows.Forms.Label labelSkype;
    }
}