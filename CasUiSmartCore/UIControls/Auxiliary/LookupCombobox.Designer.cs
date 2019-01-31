using System.Threading;
using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary
{
    partial class LookupCombobox
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
            if (TypeItemsCollection != null)
            {
                TypeItemsCollection.CollectionChanged -= DictionaryCollectionChanged;
            }

            if (backgroundWorker.IsBusy)
                backgroundWorker.CancelAsync();
            backgroundWorker.Dispose();
			//while (backgroundWorker.IsBusy)
			//{
			//    Thread.Sleep(500);
			//}

			backgroundWorker.DoWork -= BackgroundWorkerDoWork;
            backgroundWorker.ProgressChanged -= BackgroundWorkerProgressChanged;
            backgroundWorker.RunWorkerCompleted -= BackgroundWorkerRunWorkerCompleted;
            backgroundWorker.Dispose();

            if (disposing)
            {
                comboBoxReason.SelectedIndexChanged -= ComboBoxReasonSelectedIndexChanged;
                comboBoxReason.TextUpdate -= ComboBoxReasonTextUpdate;
                richReferenceButtonCreate.Click -= ButtonCreateClick;
                richReferenceButtonEdit.Click -= ButtonEditClick;
                richReferenceButtonViewList.Click -= ButtonViewListClick;
                richReferenceButtonReload.Click -= ButtonReloadClick;

                this.SelectedIndexChanged = null;
            }
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
            this.comboBoxReason = new System.Windows.Forms.ComboBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.richReferenceButtonCreate = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.richReferenceButtonEdit = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.richReferenceButtonViewList = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.richReferenceButtonReload = new CAS.UI.Management.Dispatchering.RichReferenceButton();
            this.SuspendLayout();
            // 
            // comboBoxReason
            // 
            this.comboBoxReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxReason.FormattingEnabled = true;
            this.comboBoxReason.Location = new System.Drawing.Point(0, 0);
            this.comboBoxReason.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxReason.Name = "comboBoxReason";
            this.comboBoxReason.Size = new System.Drawing.Size(113, 21);
            this.comboBoxReason.TabIndex = 0;
            this.comboBoxReason.SelectedIndexChanged += new System.EventHandler(this.ComboBoxReasonSelectedIndexChanged);
            this.comboBoxReason.TextUpdate +=new System.EventHandler(ComboBoxReasonTextUpdate);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerDoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorkerProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerRunWorkerCompleted);
            
            // 
            // richReferenceButtonCreate
            // 
            this.richReferenceButtonCreate.ActiveBackColor = System.Drawing.Color.Transparent;
            this.richReferenceButtonCreate.ActiveBackgroundImage = null;
            this.richReferenceButtonCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.richReferenceButtonCreate.Displayer = null;
            this.richReferenceButtonCreate.DisplayerText = "";
            this.richReferenceButtonCreate.Dock = System.Windows.Forms.DockStyle.Right;
            this.richReferenceButtonCreate.Entity = null;
            this.richReferenceButtonCreate.FontMain = new System.Drawing.Font("Verdana", 14.25F);
            this.richReferenceButtonCreate.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.richReferenceButtonCreate.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.richReferenceButtonCreate.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.richReferenceButtonCreate.Icon = global::CAS.UI.Properties.Resources.AddIcon;
            this.richReferenceButtonCreate.IconLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.richReferenceButtonCreate.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIcon_gray;
            this.richReferenceButtonCreate.Location = new System.Drawing.Point(113, 0);
            this.richReferenceButtonCreate.Margin = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonCreate.Name = "richReferenceButtonCreate";
            this.richReferenceButtonCreate.NormalBackgroundImage = null;
            this.richReferenceButtonCreate.PaddingMain = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonCreate.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonCreate.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.richReferenceButtonCreate.ShowToolTip = true;
            this.richReferenceButtonCreate.Size = new System.Drawing.Size(20, 20);
            this.richReferenceButtonCreate.TabIndex = 1;
            this.richReferenceButtonCreate.TabStop = false;
            this.richReferenceButtonCreate.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.richReferenceButtonCreate.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.richReferenceButtonCreate.TextMain = "";
            this.richReferenceButtonCreate.TextSecondary = "";
            this.richReferenceButtonCreate.ToolTipText = "Add new";
            this.richReferenceButtonCreate.Click += new System.EventHandler(this.ButtonCreateClick);
            // 
            // richReferenceButtonEdit
            // 
            this.richReferenceButtonEdit.ActiveBackColor = System.Drawing.Color.Transparent;
            this.richReferenceButtonEdit.ActiveBackgroundImage = null;
            this.richReferenceButtonEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.richReferenceButtonEdit.Displayer = null;
            this.richReferenceButtonEdit.DisplayerText = "";
            this.richReferenceButtonEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.richReferenceButtonEdit.Entity = null;
            this.richReferenceButtonEdit.FontMain = new System.Drawing.Font("Verdana", 14.25F);
            this.richReferenceButtonEdit.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.richReferenceButtonEdit.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.richReferenceButtonEdit.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.richReferenceButtonEdit.Icon = global::CAS.UI.Properties.Resources.EditIcon;
            this.richReferenceButtonEdit.IconLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.richReferenceButtonEdit.IconNotEnabled = global::CAS.UI.Properties.Resources.EditIcon_gray;
            this.richReferenceButtonEdit.Location = new System.Drawing.Point(133, 0);
            this.richReferenceButtonEdit.Margin = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonEdit.Name = "richReferenceButtonEdit";
            this.richReferenceButtonEdit.NormalBackgroundImage = null;
            this.richReferenceButtonEdit.PaddingMain = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonEdit.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonEdit.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.richReferenceButtonEdit.ShowToolTip = true;
            this.richReferenceButtonEdit.Size = new System.Drawing.Size(20, 20);
            this.richReferenceButtonEdit.TabIndex = 2;
            this.richReferenceButtonEdit.TabStop = false;
            this.richReferenceButtonEdit.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.richReferenceButtonEdit.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.richReferenceButtonEdit.TextMain = "";
            this.richReferenceButtonEdit.TextSecondary = "";
            this.richReferenceButtonEdit.ToolTipText = "Edit selected";
            this.richReferenceButtonEdit.Click += new System.EventHandler(this.ButtonEditClick);
            // 
            // richReferenceButtonViewList
            // 
            this.richReferenceButtonViewList.ActiveBackColor = System.Drawing.Color.Transparent;
            this.richReferenceButtonViewList.ActiveBackgroundImage = null;
            this.richReferenceButtonViewList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.richReferenceButtonViewList.Displayer = null;
            this.richReferenceButtonViewList.DisplayerText = "";
            this.richReferenceButtonViewList.Dock = System.Windows.Forms.DockStyle.Right;
            this.richReferenceButtonViewList.Entity = null;
            this.richReferenceButtonViewList.FontMain = new System.Drawing.Font("Verdana", 14.25F);
            this.richReferenceButtonViewList.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.richReferenceButtonViewList.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.richReferenceButtonViewList.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.richReferenceButtonViewList.Icon = global::CAS.UI.Properties.Resources.viewListIcon;
            this.richReferenceButtonViewList.IconLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.richReferenceButtonViewList.IconNotEnabled = global::CAS.UI.Properties.Resources.viewListIcon_gray;
            this.richReferenceButtonViewList.Location = new System.Drawing.Point(153, 0);
            this.richReferenceButtonViewList.Margin = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonViewList.Name = "richReferenceButtonViewList";
            this.richReferenceButtonViewList.NormalBackgroundImage = null;
            this.richReferenceButtonViewList.PaddingMain = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonViewList.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonViewList.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.richReferenceButtonViewList.ShowToolTip = true;
            this.richReferenceButtonViewList.Size = new System.Drawing.Size(20, 20);
            this.richReferenceButtonViewList.TabIndex = 2;
            this.richReferenceButtonViewList.TabStop = false;
            this.richReferenceButtonViewList.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.richReferenceButtonViewList.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.richReferenceButtonViewList.TextMain = "";
            this.richReferenceButtonViewList.TextSecondary = "";
            this.richReferenceButtonViewList.ToolTipText = "View items list";
            this.richReferenceButtonViewList.Click += new System.EventHandler(this.ButtonViewListClick);
            // 
            // richReferenceButtonReload
            // 
            this.richReferenceButtonReload.ActiveBackColor = System.Drawing.Color.Transparent;
            this.richReferenceButtonReload.ActiveBackgroundImage = null;
            this.richReferenceButtonReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.richReferenceButtonReload.Displayer = null;
            this.richReferenceButtonReload.DisplayerText = "";
            this.richReferenceButtonReload.Dock = System.Windows.Forms.DockStyle.Right;
            this.richReferenceButtonReload.Entity = null;
            this.richReferenceButtonReload.FontMain = new System.Drawing.Font("Verdana", 14.25F);
            this.richReferenceButtonReload.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
            this.richReferenceButtonReload.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.richReferenceButtonReload.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.richReferenceButtonReload.Icon = global::CAS.UI.Properties.Resources.ReloadIcon;
            this.richReferenceButtonReload.IconLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.richReferenceButtonReload.IconNotEnabled = global::CAS.UI.Properties.Resources.ReloadIcon_gray;
            this.richReferenceButtonReload.Location = new System.Drawing.Point(173, 0);
            this.richReferenceButtonReload.Margin = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonReload.Name = "richReferenceButtonReload";
            this.richReferenceButtonReload.NormalBackgroundImage = null;
            this.richReferenceButtonReload.PaddingMain = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonReload.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.richReferenceButtonReload.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.richReferenceButtonReload.ShowToolTip = true;
            this.richReferenceButtonReload.Size = new System.Drawing.Size(20, 20);
            this.richReferenceButtonReload.TabIndex = 2;
            this.richReferenceButtonReload.TabStop = false;
            this.richReferenceButtonReload.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.richReferenceButtonReload.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.richReferenceButtonReload.TextMain = "";
            this.richReferenceButtonReload.TextSecondary = "";
            this.richReferenceButtonReload.ToolTipText = "Refresh";
            this.richReferenceButtonReload.Click += new System.EventHandler(this.ButtonReloadClick);
            // 
            // LookupCombobox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richReferenceButtonCreate);
            this.Controls.Add(this.richReferenceButtonEdit);
            this.Controls.Add(this.richReferenceButtonViewList);
            this.Controls.Add(this.richReferenceButtonReload);
            this.Controls.Add(this.comboBoxReason);
            this.Name = "LookupCombobox";
            this.Size = new System.Drawing.Size(193, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ComboBox comboBoxReason;
        private Management.Dispatchering.RichReferenceButton richReferenceButtonReload;
        private Management.Dispatchering.RichReferenceButton richReferenceButtonViewList;
        private Management.Dispatchering.RichReferenceButton richReferenceButtonEdit;
        private Management.Dispatchering.RichReferenceButton richReferenceButtonCreate;
    }
}
