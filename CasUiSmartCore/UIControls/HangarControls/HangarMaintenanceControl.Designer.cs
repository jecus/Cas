using CASTerms;
using Entity.Abstractions;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.HangarControls
{
	partial class HangarMaintenanceControl
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
			if (disposing)
			{
				if (backgroundWorker.IsBusy)
				{
					backgroundWorker.CancelAsync();
				}
				backgroundWorker.DoWork -= BackgroundWorkerDoWork;
				backgroundWorker.ProgressChanged -= BackgroundWorkerProgressChanged;
				backgroundWorker.RunWorkerCompleted -= BackgroundWorkerRunWorkerCompleted;
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
			var userType = GlobalObjects.CasEnvironment?.IdentityUser.UserType ?? GlobalObjects.CaaEnvironment?.IdentityUser.UserType;;
			this.extendableRichContainer = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.avButtonReload = new AvControls.AvButtonT.AvButtonT();
			this.buttonDelete = new AvControls.AvButtonT.AvButtonT();
			this.labelProcess = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panelExtendable = new System.Windows.Forms.Panel();
			this.panelMain = new System.Windows.Forms.Panel();
			this.textBoxCustomer = new System.Windows.Forms.TextBox();
			this.labelCustomer = new System.Windows.Forms.Label();
			this.labelDateOut = new System.Windows.Forms.Label();
			this.dateTimePickerDateOut = new System.Windows.Forms.DateTimePicker();
			this.labelDateIn = new System.Windows.Forms.Label();
			this.dateTimePickerDateIn = new System.Windows.Forms.DateTimePicker();
			this.labelSelectWorkPackage = new System.Windows.Forms.Label();
			this.comboBoxWorkPackage = new System.Windows.Forms.ComboBox();
			this.hangarWorkPackageView = new CAS.UI.UIControls.HangarControls.HangarWorkPackageViewControl();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.flowLayoutPanel1.SuspendLayout();
			this.panelExtendable.SuspendLayout();
			this.panelMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// extendableRichContainer
			// 
			this.extendableRichContainer.AfterCaptionControl = this.avButtonReload;
			this.extendableRichContainer.AfterCaptionControl2 = this.buttonDelete;
			this.extendableRichContainer.AfterCaptionControl3 = this.labelProcess;
			this.extendableRichContainer.AutoSize = true;
			this.extendableRichContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainer.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainer.Caption = "Directive Performance";
			this.extendableRichContainer.CaptionFont = new System.Drawing.Font("Verdana", 21.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainer.Condition = null;
			this.extendableRichContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainer.Extendable = true;
			this.extendableRichContainer.Extended = false;
			this.extendableRichContainer.Location = new System.Drawing.Point(0, 5);
			this.extendableRichContainer.MainControl = null;
			this.extendableRichContainer.Margin = new System.Windows.Forms.Padding(5);
			this.extendableRichContainer.Name = "extendableRichContainer";
			this.extendableRichContainer.Size = new System.Drawing.Size(400, 50);
			this.extendableRichContainer.TabIndex = 0;
			this.extendableRichContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
			this.extendableRichContainer.Extending += new System.EventHandler(this.ExtendableRichContainerExtending);
			// 
			// avButtonReload
			// 
			this.avButtonReload.ActiveBackColor = System.Drawing.Color.Transparent;
			this.avButtonReload.ActiveBackgroundImage = null;
			this.avButtonReload.Cursor = System.Windows.Forms.Cursors.Hand;
			this.avButtonReload.FontMain = new System.Drawing.Font("Verdana", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel);
			this.avButtonReload.FontSecondary = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.avButtonReload.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.avButtonReload.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.avButtonReload.Icon = global::CAS.UI.Properties.Resources.ReloadIcon;
			this.avButtonReload.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.avButtonReload.IconNotEnabled = global::CAS.UI.Properties.Resources.ReloadIcon_gray;
			this.avButtonReload.Location = new System.Drawing.Point(298, 0);
			this.avButtonReload.Margin = new System.Windows.Forms.Padding(0);
			this.avButtonReload.Name = "avButtonReload";
			this.avButtonReload.NormalBackgroundImage = null;
			this.avButtonReload.PaddingMain = new System.Windows.Forms.Padding(0);
			this.avButtonReload.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.avButtonReload.ShowToolTip = true;
			this.avButtonReload.Size = new System.Drawing.Size(48, 50);
			this.avButtonReload.TabIndex = 12;
			this.avButtonReload.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.avButtonReload.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
			this.avButtonReload.TextMain = "";
			this.avButtonReload.TextSecondary = "";
			this.avButtonReload.ToolTipText = "Refresh";
			this.avButtonReload.Click += new System.EventHandler(this.AvButtonReloadClick);
			// 
			// buttonDelete
			// 
			this.buttonDelete.ActiveBackColor = System.Drawing.Color.Transparent;
			this.buttonDelete.ActiveBackgroundImage = null;
			this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonDelete.FontMain = new System.Drawing.Font("Verdana", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel);
			this.buttonDelete.FontSecondary = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonDelete.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
			this.buttonDelete.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.buttonDelete.Icon = global::CAS.UI.Properties.Resources.DeleteIcon;
			this.buttonDelete.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonDelete.IconNotEnabled = global::CAS.UI.Properties.Resources.DeleteIcon_gray;
			this.buttonDelete.Location = new System.Drawing.Point(346, 0);
			this.buttonDelete.Margin = new System.Windows.Forms.Padding(0);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.NormalBackgroundImage = null;
			this.buttonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonDelete.ShowToolTip = true;
			this.buttonDelete.Size = new System.Drawing.Size(48, 50);
			this.buttonDelete.TabIndex = 13;
			this.buttonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
			this.buttonDelete.TextMain = "";
			this.buttonDelete.TextSecondary = "";
			this.buttonDelete.ToolTipText = "Delete";
			this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
			this.buttonDelete.Enabled = !(userType == UserType.ReadOnly || userType == UserType.SaveOnly);
			// 
			// labelProcess
			// 
			this.labelProcess.AutoSize = true;
			this.labelProcess.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelProcess.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelProcess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelProcess.Location = new System.Drawing.Point(397, 0);
			this.labelProcess.Name = "labelProcess";
			this.labelProcess.Size = new System.Drawing.Size(1, 50);
			this.labelProcess.TabIndex = 3;
			this.labelProcess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.flowLayoutPanel1.Controls.Add(this.panelExtendable);
			this.flowLayoutPanel1.Controls.Add(this.panelMain);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(1535, 853);
			this.flowLayoutPanel1.TabIndex = 67;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// panelExtendable
			// 
			this.panelExtendable.Controls.Add(this.extendableRichContainer);
			this.panelExtendable.Location = new System.Drawing.Point(4, 4);
			this.panelExtendable.Margin = new System.Windows.Forms.Padding(4);
			this.panelExtendable.Name = "panelExtendable";
			this.panelExtendable.Size = new System.Drawing.Size(1524, 57);
			this.panelExtendable.TabIndex = 36;
			// 
			// panelMain
			// 
			this.panelMain.AutoSize = true;
			this.panelMain.Controls.Add(this.numericUpDown1);
			this.panelMain.Controls.Add(this.label1);
			this.panelMain.Controls.Add(this.textBoxCustomer);
			this.panelMain.Controls.Add(this.labelCustomer);
			this.panelMain.Controls.Add(this.labelDateOut);
			this.panelMain.Controls.Add(this.dateTimePickerDateOut);
			this.panelMain.Controls.Add(this.labelDateIn);
			this.panelMain.Controls.Add(this.dateTimePickerDateIn);
			this.panelMain.Controls.Add(this.labelSelectWorkPackage);
			this.panelMain.Controls.Add(this.comboBoxWorkPackage);
			this.panelMain.Controls.Add(this.hangarWorkPackageView);
			this.panelMain.Location = new System.Drawing.Point(3, 68);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(1529, 782);
			this.panelMain.TabIndex = 37;
			// 
			// textBoxCustomer
			// 
			this.textBoxCustomer.Font = new System.Drawing.Font("Verdana", 9F);
			this.textBoxCustomer.Location = new System.Drawing.Point(781, 3);
			this.textBoxCustomer.Name = "textBoxCustomer";
			this.textBoxCustomer.Size = new System.Drawing.Size(387, 26);
			this.textBoxCustomer.TabIndex = 73;
			// 
			// labelCustomer
			// 
			this.labelCustomer.AutoSize = true;
			this.labelCustomer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCustomer.Location = new System.Drawing.Point(644, 6);
			this.labelCustomer.Name = "labelCustomer";
			this.labelCustomer.Size = new System.Drawing.Size(89, 18);
			this.labelCustomer.TabIndex = 72;
			this.labelCustomer.Text = "Customer:";
			// 
			// labelDateOut
			// 
			this.labelDateOut.AutoSize = true;
			this.labelDateOut.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDateOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDateOut.Location = new System.Drawing.Point(644, 41);
			this.labelDateOut.Name = "labelDateOut";
			this.labelDateOut.Size = new System.Drawing.Size(82, 18);
			this.labelDateOut.TabIndex = 70;
			this.labelDateOut.Text = "Date Out:";
			// 
			// dateTimePickerDateOut
			// 
			this.dateTimePickerDateOut.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerDateOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerDateOut.Location = new System.Drawing.Point(781, 35);
			this.dateTimePickerDateOut.Name = "dateTimePickerDateOut";
			this.dateTimePickerDateOut.Size = new System.Drawing.Size(387, 26);
			this.dateTimePickerDateOut.TabIndex = 71;
			// 
			// labelDateIn
			// 
			this.labelDateIn.AutoSize = true;
			this.labelDateIn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelDateIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelDateIn.Location = new System.Drawing.Point(3, 41);
			this.labelDateIn.Name = "labelDateIn";
			this.labelDateIn.Size = new System.Drawing.Size(69, 18);
			this.labelDateIn.TabIndex = 68;
			this.labelDateIn.Text = "Date In:";
			// 
			// dateTimePickerDateIn
			// 
			this.dateTimePickerDateIn.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dateTimePickerDateIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.dateTimePickerDateIn.Location = new System.Drawing.Point(226, 35);
			this.dateTimePickerDateIn.Name = "dateTimePickerDateIn";
			this.dateTimePickerDateIn.Size = new System.Drawing.Size(387, 26);
			this.dateTimePickerDateIn.TabIndex = 69;
			// 
			// labelSelectWorkPackage
			// 
			this.labelSelectWorkPackage.AutoSize = true;
			this.labelSelectWorkPackage.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelSelectWorkPackage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSelectWorkPackage.Location = new System.Drawing.Point(2, 6);
			this.labelSelectWorkPackage.Name = "labelSelectWorkPackage";
			this.labelSelectWorkPackage.Size = new System.Drawing.Size(172, 18);
			this.labelSelectWorkPackage.TabIndex = 2;
			this.labelSelectWorkPackage.Text = "Select Work Package:";
			// 
			// comboBoxWorkPackage
			// 
			this.comboBoxWorkPackage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxWorkPackage.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.comboBoxWorkPackage.FormattingEnabled = true;
			this.comboBoxWorkPackage.Location = new System.Drawing.Point(226, 3);
			this.comboBoxWorkPackage.Name = "comboBoxWorkPackage";
			this.comboBoxWorkPackage.Size = new System.Drawing.Size(387, 26);
			this.comboBoxWorkPackage.TabIndex = 1;
			this.comboBoxWorkPackage.SelectedIndexChanged += new System.EventHandler(this.ComboBoxWorkPackageSelectedIndexChanged);
			this.comboBoxWorkPackage.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// hangarWorkPackageView
			// 
			this.hangarWorkPackageView.Displayer = null;
			this.hangarWorkPackageView.DisplayerText = null;
			this.hangarWorkPackageView.Entity = null;
			this.hangarWorkPackageView.Location = new System.Drawing.Point(1, 81);
			this.hangarWorkPackageView.Margin = new System.Windows.Forms.Padding(4);
			this.hangarWorkPackageView.Name = "hangarWorkPackageView";
			this.hangarWorkPackageView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.hangarWorkPackageView.ShowAddNew = false;
			this.hangarWorkPackageView.ShowDelete = false;
			this.hangarWorkPackageView.Size = new System.Drawing.Size(1524, 697);
			this.hangarWorkPackageView.TabIndex = 38;
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.WorkerReportsProgress = true;
			this.backgroundWorker.WorkerSupportsCancellation = true;
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerDoWork);
			this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorkerProgressChanged);
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerRunWorkerCompleted);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label1.Location = new System.Drawing.Point(1193, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(117, 18);
			this.label1.TabIndex = 74;
			this.label1.Text = "Completed %:";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.DecimalPlaces = 2;
			this.numericUpDown1.Font = new System.Drawing.Font("Verdana", 9F);
			this.numericUpDown1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.numericUpDown1.Location = new System.Drawing.Point(1348, 3);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(120, 26);
			this.numericUpDown1.TabIndex = 75;
			// 
			// HangarMaintenanceControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "HangarMaintenanceControl";
			this.Size = new System.Drawing.Size(1535, 853);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.panelExtendable.ResumeLayout(false);
			this.panelExtendable.PerformLayout();
			this.panelMain.ResumeLayout(false);
			this.panelMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ReferenceControls.ExtendableRichContainer extendableRichContainer;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Panel panelExtendable;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private AvControls.AvButtonT.AvButtonT avButtonReload;
		private System.Windows.Forms.Panel panelMain;
		private System.Windows.Forms.Label labelSelectWorkPackage;
		private System.Windows.Forms.ComboBox comboBoxWorkPackage;
		private AvControls.AvButtonT.AvButtonT buttonDelete;
		private System.Windows.Forms.Label labelProcess;
		private HangarWorkPackageViewControl hangarWorkPackageView;
		private System.Windows.Forms.TextBox textBoxCustomer;
		private System.Windows.Forms.Label labelCustomer;
		private System.Windows.Forms.Label labelDateOut;
		private System.Windows.Forms.DateTimePicker dateTimePickerDateOut;
		private System.Windows.Forms.Label labelDateIn;
		private System.Windows.Forms.DateTimePicker dateTimePickerDateIn;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label1;
	}
}
