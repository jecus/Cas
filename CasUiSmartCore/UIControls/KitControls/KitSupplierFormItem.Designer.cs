using MetroFramework.Controls;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.KitControls
{
	partial class KitSupplierFormItem
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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panelExtendable = new MetroFramework.Controls.MetroPanel();
			this.extendableRichContainer = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
			this.comboBoxKitSupplier = new System.Windows.Forms.ComboBox();
			this.buttonDelete = new System.Windows.Forms.Button();
			this.panelMain = new MetroFramework.Controls.MetroPanel();
			this.labelCostOverhaul = new MetroFramework.Controls.MetroLabel();
			this.numericCostOverhaul = new System.Windows.Forms.NumericUpDown();
			this.labelCostServiceable = new MetroFramework.Controls.MetroLabel();
			this.numericCostServiceable = new System.Windows.Forms.NumericUpDown();
			this.labelCoatNew = new MetroFramework.Controls.MetroLabel();
			this.numericCostNew = new System.Windows.Forms.NumericUpDown();
			this.flowLayoutPanel1.SuspendLayout();
			this.panelExtendable.SuspendLayout();
			this.panelMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericCostOverhaul)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericCostServiceable)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericCostNew)).BeginInit();
			this.SuspendLayout();
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
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(324, 122);
			this.flowLayoutPanel1.TabIndex = 68;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// panelExtendable
			// 
			this.panelExtendable.AutoSize = true;
			this.panelExtendable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelExtendable.Controls.Add(this.extendableRichContainer);
			this.panelExtendable.HorizontalScrollbarBarColor = true;
			this.panelExtendable.HorizontalScrollbarHighlightOnWheel = false;
			this.panelExtendable.HorizontalScrollbarSize = 8;
			this.panelExtendable.Location = new System.Drawing.Point(0, 0);
			this.panelExtendable.Margin = new System.Windows.Forms.Padding(0);
			this.panelExtendable.Name = "panelExtendable";
			this.panelExtendable.Size = new System.Drawing.Size(324, 40);
			this.panelExtendable.TabIndex = 36;
			this.panelExtendable.VerticalScrollbarBarColor = true;
			this.panelExtendable.VerticalScrollbarHighlightOnWheel = false;
			this.panelExtendable.VerticalScrollbarSize = 8;
			// 
			// extendableRichContainer
			// 
			this.extendableRichContainer.AfterCaptionControl = this.comboBoxKitSupplier;
			this.extendableRichContainer.AfterCaptionControl2 = this.buttonDelete;
			this.extendableRichContainer.AfterCaptionControl3 = null;
			this.extendableRichContainer.AutoSize = true;
			this.extendableRichContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.extendableRichContainer.BackColor = System.Drawing.Color.Transparent;
			this.extendableRichContainer.Caption = "";
			this.extendableRichContainer.CaptionFont = new System.Drawing.Font("Verdana", 21.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.extendableRichContainer.Condition = null;
			this.extendableRichContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
			this.extendableRichContainer.Extendable = true;
			this.extendableRichContainer.Extended = false;
			this.extendableRichContainer.Location = new System.Drawing.Point(4, 4);
			this.extendableRichContainer.MainControl = null;
			this.extendableRichContainer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.extendableRichContainer.Name = "extendableRichContainer";
			this.extendableRichContainer.Size = new System.Drawing.Size(316, 32);
			this.extendableRichContainer.TabIndex = 1;
			this.extendableRichContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrowSmall;
			this.extendableRichContainer.Extending += new System.EventHandler(this.ExtendableRichContainerExtending);
			// 
			// comboBoxKitSupplier
			// 
			this.comboBoxKitSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxKitSupplier.FormattingEnabled = true;
			this.comboBoxKitSupplier.Location = new System.Drawing.Point(30, 4);
			this.comboBoxKitSupplier.Margin = new System.Windows.Forms.Padding(4);
			this.comboBoxKitSupplier.Name = "comboBoxKitSupplier";
			this.comboBoxKitSupplier.Size = new System.Drawing.Size(239, 21);
			this.comboBoxKitSupplier.TabIndex = 0;
			this.comboBoxKitSupplier.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBoxKitSupplierDrawItem);
			this.comboBoxKitSupplier.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// buttonDelete
			// 
			this.buttonDelete.Location = new System.Drawing.Point(277, 2);
			this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.Size = new System.Drawing.Size(35, 28);
			this.buttonDelete.TabIndex = 8;
			this.buttonDelete.Text = "-";
			this.buttonDelete.UseVisualStyleBackColor = true;
			this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
			// 
			// panelMain
			// 
			this.panelMain.AutoSize = true;
			this.panelMain.Controls.Add(this.labelCostOverhaul);
			this.panelMain.Controls.Add(this.numericCostOverhaul);
			this.panelMain.Controls.Add(this.labelCostServiceable);
			this.panelMain.Controls.Add(this.numericCostServiceable);
			this.panelMain.Controls.Add(this.labelCoatNew);
			this.panelMain.Controls.Add(this.numericCostNew);
			this.panelMain.HorizontalScrollbarBarColor = true;
			this.panelMain.HorizontalScrollbarHighlightOnWheel = false;
			this.panelMain.HorizontalScrollbarSize = 8;
			this.panelMain.Location = new System.Drawing.Point(0, 40);
			this.panelMain.Margin = new System.Windows.Forms.Padding(0);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(244, 82);
			this.panelMain.TabIndex = 37;
			this.panelMain.VerticalScrollbarBarColor = true;
			this.panelMain.VerticalScrollbarHighlightOnWheel = false;
			this.panelMain.VerticalScrollbarSize = 8;
			// 
			// labelCostOverhaul
			// 
			this.labelCostOverhaul.AutoSize = true;
			this.labelCostOverhaul.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCostOverhaul.Location = new System.Drawing.Point(7, 59);
			this.labelCostOverhaul.Name = "labelCostOverhaul";
			this.labelCostOverhaul.Size = new System.Drawing.Size(62, 19);
			this.labelCostOverhaul.TabIndex = 103;
			this.labelCostOverhaul.Text = "Cost OH:";
			this.labelCostOverhaul.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericCostOverhaul
			// 
			this.numericCostOverhaul.DecimalPlaces = 2;
			this.numericCostOverhaul.Increment = new decimal(new int[] {
			1,
			0,
			0,
			131072});
			this.numericCostOverhaul.Location = new System.Drawing.Point(110, 59);
			this.numericCostOverhaul.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericCostOverhaul.Name = "numericCostOverhaul";
			this.numericCostOverhaul.Size = new System.Drawing.Size(131, 20);
			this.numericCostOverhaul.TabIndex = 100;
			// 
			// labelCostServiceable
			// 
			this.labelCostServiceable.AutoSize = true;
			this.labelCostServiceable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCostServiceable.Location = new System.Drawing.Point(7, 31);
			this.labelCostServiceable.Name = "labelCostServiceable";
			this.labelCostServiceable.Size = new System.Drawing.Size(68, 19);
			this.labelCostServiceable.TabIndex = 102;
			this.labelCostServiceable.Text = "Cost serv.:";
			this.labelCostServiceable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericCostServiceable
			// 
			this.numericCostServiceable.DecimalPlaces = 2;
			this.numericCostServiceable.Increment = new decimal(new int[] {
			1,
			0,
			0,
			131072});
			this.numericCostServiceable.Location = new System.Drawing.Point(110, 31);
			this.numericCostServiceable.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericCostServiceable.Name = "numericCostServiceable";
			this.numericCostServiceable.Size = new System.Drawing.Size(131, 20);
			this.numericCostServiceable.TabIndex = 99;
			// 
			// labelCoatNew
			// 
			this.labelCoatNew.AutoSize = true;
			this.labelCoatNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelCoatNew.Location = new System.Drawing.Point(7, 3);
			this.labelCoatNew.Name = "labelCoatNew";
			this.labelCoatNew.Size = new System.Drawing.Size(65, 19);
			this.labelCoatNew.TabIndex = 101;
			this.labelCoatNew.Text = "Cost new:";
			this.labelCoatNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// numericCostNew
			// 
			this.numericCostNew.DecimalPlaces = 2;
			this.numericCostNew.Increment = new decimal(new int[] {
			1,
			0,
			0,
			131072});
			this.numericCostNew.Location = new System.Drawing.Point(110, 3);
			this.numericCostNew.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.numericCostNew.Name = "numericCostNew";
			this.numericCostNew.Size = new System.Drawing.Size(131, 20);
			this.numericCostNew.TabIndex = 98;
			// 
			// KitSupplierFormItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "KitSupplierFormItem";
			this.Size = new System.Drawing.Size(324, 122);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.panelExtendable.ResumeLayout(false);
			this.panelExtendable.PerformLayout();
			this.panelMain.ResumeLayout(false);
			this.panelMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericCostOverhaul)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericCostServiceable)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericCostNew)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxKitSupplier;
		private ReferenceControls.ExtendableRichContainer extendableRichContainer;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private MetroPanel panelExtendable;
		private MetroPanel panelMain;
		private System.Windows.Forms.Button buttonDelete;
		private MetroLabel labelCostOverhaul;
		private System.Windows.Forms.NumericUpDown numericCostOverhaul;
		private MetroLabel labelCostServiceable;
		private System.Windows.Forms.NumericUpDown numericCostServiceable;
		private MetroLabel labelCoatNew;
		private System.Windows.Forms.NumericUpDown numericCostNew;
	}
}
