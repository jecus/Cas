using CASTerms;
using EntityCore.DTO.General;

namespace CAS.UI.UIControls.OpepatorsControls
{
    partial class OperatorScreen
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
	        var userType = GlobalObjects.CasEnvironment.IdentityUser.UserType;
			this.OperatorControl = new OperatorControl(new SmartCore.Entities.General.Operator());
            this._buttonDeleteOperator = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.headerControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(952, 447);
            this.panel1.Controls.Add(this.OperatorControl);
            // 
            // headerControl
            // 
            this.headerControl.ShowPrintButton = true;
            this.headerControl.ShowSaveButton = true;
            this.headerControl.Size = new System.Drawing.Size(959, 58);
            this.headerControl.ReloadButtonClick += new System.EventHandler(this.HeaderControl1ReloadRised);
            this.headerControl.SaveButtonClick += new System.EventHandler(this.HeaderControlSaveClicked);
            this.headerControl.PrintButtonDisplayerRequested += new System.EventHandler<CAS.UI.Interfaces.ReferenceEventArgs>(this.ButtonPrintDisplayerRequested);
            // 
            // aircraftHeaderControl1
            // 
            this.aircraftHeaderControl1.ChildClickable = true;
            this.aircraftHeaderControl1.OperatorClickable = true;
            this.aircraftHeaderControl1.NextClickable = true;
            this.aircraftHeaderControl1.PrevClickable = true;
            //
            // panelTopContainer
            //
            this.panelTopContainer.Controls.Add(this._buttonDeleteOperator);
            this.panelTopContainer.Size = new System.Drawing.Size(1138, 62);
            // 
            // statusControl
            // 
            this.statusControl.MaximumSize = new System.Drawing.Size(1000, 35);
            this.statusControl.Size = new System.Drawing.Size(950, 35);
            // 
            // buttonDeleteOperator
            // 
            _buttonDeleteOperator.Anchor = System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top;
            _buttonDeleteOperator.BackColor = System.Drawing.Color.Transparent;
            _buttonDeleteOperator.FontMain = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            _buttonDeleteOperator.FontSecondary = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            _buttonDeleteOperator.ForeColorMain = System.Drawing.Color.FromArgb(49, 82, 128);
            _buttonDeleteOperator.ForeColorSecondary = System.Drawing.Color.FromArgb(49, 82, 128);
            _buttonDeleteOperator.Location = new System.Drawing.Point(960, 0);
            _buttonDeleteOperator.Icon = CAS.UI.Properties.Resources.DeleteIcon;
            _buttonDeleteOperator.IconNotEnabled = CAS.UI.Properties.Resources.DeleteIcon_gray;
            _buttonDeleteOperator.IconLayout = System.Windows.Forms.ImageLayout.Center;
            _buttonDeleteOperator.PaddingMain = new System.Windows.Forms.Padding(3, 0, 0, 0);
            _buttonDeleteOperator.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.CloseSelected;
            _buttonDeleteOperator.Size = new System.Drawing.Size(160, 50);
            _buttonDeleteOperator.TabIndex = 16;
            _buttonDeleteOperator.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            _buttonDeleteOperator.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
            _buttonDeleteOperator.TextMain = "Delete";
            _buttonDeleteOperator.TextSecondary = "operator";
            _buttonDeleteOperator.DisplayerRequested += buttonDeleteOperator_DisplayerRequested;
            _buttonDeleteOperator.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);
			// 
			// NonRoutineJobsListScreen
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "NonRoutineJobsListScreen";
            this.ShowTopPanelContainer = true;
            this.ShowAircraftStatusPanel = false;
            this.Size = new System.Drawing.Size(952, 590);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.headerControl.ResumeLayout(false);
            this.headerControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OperatorControl OperatorControl;
        private CAS.UI.Management.Dispatchering.RichReferenceButton _buttonDeleteOperator;
    }
}
