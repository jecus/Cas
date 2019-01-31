using System.Threading;
using AvControls.AvButtonT;

namespace CAS.UI.UIControls.Auxiliary
{
    partial class ComplianceControl
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
            if (backgroundWorker.IsBusy)
                backgroundWorker.CancelAsync();

			//while (backgroundWorker.IsBusy)
			//{
			//    Thread.Sleep(500);
			//}
			backgroundWorker.Dispose();
			backgroundWorker.DoWork -= BackgroundWorkerDoWork;
            backgroundWorker.ProgressChanged -= BackgroundWorkerProgressChanged;
            backgroundWorker.RunWorkerCompleted -= BackgroundWorkerRunWorkerCompleted;
            backgroundWorker.Dispose();

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
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.ButtonRegisterActualState = new AvControls.AvButtonT.AvButtonT();
            this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
            this.ButtonEdit = new AvControls.AvButtonT.AvButtonT();
            this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
            this.listViewCompliance = new System.Windows.Forms.ListView();
            this.extendableRichContainer1 = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainer.Controls.Add(this.ButtonRegisterActualState);
            this.panelContainer.Controls.Add(this.ButtonDelete);
            this.panelContainer.Controls.Add(this.ButtonEdit);
            this.panelContainer.Controls.Add(this.ButtonAdd);
            this.panelContainer.Controls.Add(this.listViewCompliance);
            this.panelContainer.Location = new System.Drawing.Point(4, 60);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(4);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1127, 224);
            this.panelContainer.TabIndex = 1;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerDoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorkerProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerRunWorkerCompleted);
            
            // 
            // ButtonRegisterActualState
            // 
            this.ButtonRegisterActualState.ActiveBackColor = System.Drawing.Color.Transparent;
            this.ButtonRegisterActualState.ActiveBackgroundImage = null;
            this.ButtonRegisterActualState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonRegisterActualState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonRegisterActualState.FontMain = new System.Drawing.Font("Verdana", 14.25F);
            this.ButtonRegisterActualState.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.ButtonRegisterActualState.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.ButtonRegisterActualState.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.ButtonRegisterActualState.Icon = global::CAS.UI.Properties.Resources.AddIcon;
            this.ButtonRegisterActualState.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonRegisterActualState.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIcon_gray;
            this.ButtonRegisterActualState.Location = new System.Drawing.Point(497, 154);
            this.ButtonRegisterActualState.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonRegisterActualState.Name = "ButtonRegisterActualState";
            this.ButtonRegisterActualState.NormalBackgroundImage = null;
            this.ButtonRegisterActualState.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonRegisterActualState.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonRegisterActualState.ShowToolTip = false;
            this.ButtonRegisterActualState.Size = new System.Drawing.Size(194, 66);
            this.ButtonRegisterActualState.TabIndex = 10;
            this.ButtonRegisterActualState.TextAlignMain = System.Drawing.ContentAlignment.BottomLeft;
            this.ButtonRegisterActualState.TextAlignSecondary = System.Drawing.ContentAlignment.TopCenter;
            this.ButtonRegisterActualState.TextMain = "Register";
            this.ButtonRegisterActualState.TextSecondary = "Actual State";
            this.ButtonRegisterActualState.ToolTipText = "";
            this.ButtonRegisterActualState.Visible = false;
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.ActiveBackColor = System.Drawing.Color.Transparent;
            this.ButtonDelete.ActiveBackgroundImage = null;
            this.ButtonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDelete.Enabled = false;
            this.ButtonDelete.FontMain = new System.Drawing.Font("Verdana", 14.25F);
            this.ButtonDelete.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.ButtonDelete.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.ButtonDelete.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.ButtonDelete.Icon = global::CAS.UI.Properties.Resources.DeleteIcon;
            this.ButtonDelete.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonDelete.IconNotEnabled = global::CAS.UI.Properties.Resources.DeleteIcon_gray;
            this.ButtonDelete.Location = new System.Drawing.Point(316, 154);
            this.ButtonDelete.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.NormalBackgroundImage = null;
            this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonDelete.ShowToolTip = false;
            this.ButtonDelete.Size = new System.Drawing.Size(172, 66);
            this.ButtonDelete.TabIndex = 8;
            this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.TextMain = "Delete";
            this.ButtonDelete.TextSecondary = "";
            this.ButtonDelete.ToolTipText = "";
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.ActiveBackColor = System.Drawing.Color.Transparent;
            this.ButtonEdit.ActiveBackgroundImage = null;
            this.ButtonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonEdit.Enabled = false;
            this.ButtonEdit.FontMain = new System.Drawing.Font("Verdana", 14.25F);
            this.ButtonEdit.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.ButtonEdit.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.ButtonEdit.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.ButtonEdit.Icon = global::CAS.UI.Properties.Resources.EditIcon;
            this.ButtonEdit.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonEdit.IconNotEnabled = global::CAS.UI.Properties.Resources.EditIcon_gray;
            this.ButtonEdit.Location = new System.Drawing.Point(157, 154);
            this.ButtonEdit.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.NormalBackgroundImage = null;
            this.ButtonEdit.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonEdit.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonEdit.ShowToolTip = false;
            this.ButtonEdit.Size = new System.Drawing.Size(151, 66);
            this.ButtonEdit.TabIndex = 7;
            this.ButtonEdit.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonEdit.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonEdit.TextMain = "Edit";
            this.ButtonEdit.TextSecondary = "";
            this.ButtonEdit.ToolTipText = "";
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.ActiveBackColor = System.Drawing.Color.Transparent;
            this.ButtonAdd.ActiveBackgroundImage = null;
            this.ButtonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAdd.FontMain = new System.Drawing.Font("Verdana", 14.25F);
            this.ButtonAdd.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.ButtonAdd.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.ButtonAdd.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.ButtonAdd.Icon = global::CAS.UI.Properties.Resources.AddIcon;
            this.ButtonAdd.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonAdd.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIcon_gray;
            this.ButtonAdd.Location = new System.Drawing.Point(4, 154);
            this.ButtonAdd.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.NormalBackgroundImage = null;
            this.ButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonAdd.ShowToolTip = false;
            this.ButtonAdd.Size = new System.Drawing.Size(145, 66);
            this.ButtonAdd.TabIndex = 6;
            this.ButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAdd.TextMain = "Add";
            this.ButtonAdd.TextSecondary = "";
            this.ButtonAdd.ToolTipText = "";
            // 
            // listViewCompliance
            // 
            this.listViewCompliance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewCompliance.FullRowSelect = true;
            this.listViewCompliance.GridLines = true;
            this.listViewCompliance.Location = new System.Drawing.Point(0, 0);
            this.listViewCompliance.Margin = new System.Windows.Forms.Padding(4);
            this.listViewCompliance.Name = "listViewCompliance";
            this.listViewCompliance.Size = new System.Drawing.Size(1125, 146);
            this.listViewCompliance.TabIndex = 0;
            this.listViewCompliance.UseCompatibleStateImageBehavior = false;
            this.listViewCompliance.View = System.Windows.Forms.View.Details;
            this.listViewCompliance.SelectedIndexChanged += new System.EventHandler(this.ListViewComplainceSelectedIndexChanged);
            // 
            // extendableRichContainer1
            // 
            this.extendableRichContainer1.AfterCaptionControl = null;
            this.extendableRichContainer1.AfterCaptionControl2 = null;
            this.extendableRichContainer1.AfterCaptionControl3 = null;
            this.extendableRichContainer1.AutoSize = true;
            this.extendableRichContainer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.extendableRichContainer1.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainer1.Caption = "Compliаnce";
            this.extendableRichContainer1.CaptionFont = new System.Drawing.Font("Verdana", 27.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainer1.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainer1.Extendable = true;
            this.extendableRichContainer1.Extended = true;
            this.extendableRichContainer1.Location = new System.Drawing.Point(0, 4);
            this.extendableRichContainer1.MainControl = null;
            this.extendableRichContainer1.Margin = new System.Windows.Forms.Padding(5);
            this.extendableRichContainer1.Name = "extendableRichContainer1";
            this.extendableRichContainer1.Size = new System.Drawing.Size(225, 42);
            this.extendableRichContainer1.TabIndex = 0;
            this.extendableRichContainer1.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainer1.Extending += new System.EventHandler(this.ExtendableRichContainer1Extending);
            // 
            // ComplianceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.extendableRichContainer1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ComplianceControl";
            this.Size = new System.Drawing.Size(1135, 288);
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.ComponentModel.BackgroundWorker backgroundWorker;
        public CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer extendableRichContainer1;
        public System.Windows.Forms.ListView listViewCompliance;
        public AvButtonT ButtonAdd;
        public AvButtonT ButtonEdit;
        public AvButtonT ButtonDelete;
        public System.Windows.Forms.Panel panelContainer;
        public AvButtonT ButtonRegisterActualState;
    }
}
