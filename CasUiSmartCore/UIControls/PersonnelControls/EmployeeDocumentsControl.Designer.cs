using System.Threading;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using EntityCore.DTO.General;

namespace CAS.UI.UIControls.PersonnelControls
{
    partial class EmployeeDocumentsControl
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

            //dateTimePickerDateOfBirth.ValueChanged -= DateTimePickerEffDateValueChanged;

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
			this.labelBiWeeklyReport = new System.Windows.Forms.Label();
			this.textboxBiWeeklyReport = new System.Windows.Forms.TextBox();
			this.documentationListView = new CAS.UI.UIControls.DocumentationControls.DocumentationListView();
			this.buttonDelete = new AvControls.AvButtonT.AvButtonT();
			this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
			this.ButtonFilter = new AvControls.AvButtonT.AvButtonT();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// labelBiWeeklyReport
			// 
			this.labelBiWeeklyReport.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelBiWeeklyReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelBiWeeklyReport.Location = new System.Drawing.Point(0, 0);
			this.labelBiWeeklyReport.Name = "labelBiWeeklyReport";
			this.labelBiWeeklyReport.Size = new System.Drawing.Size(150, 25);
			this.labelBiWeeklyReport.TabIndex = 0;
			this.labelBiWeeklyReport.Text = "BiWeekly Report";
			// 
			// textboxBiWeeklyReport
			// 
			this.textboxBiWeeklyReport.BackColor = System.Drawing.Color.White;
			this.textboxBiWeeklyReport.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textboxBiWeeklyReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textboxBiWeeklyReport.Location = new System.Drawing.Point(0, 0);
			this.textboxBiWeeklyReport.MaxLength = 1000;
			this.textboxBiWeeklyReport.Name = "textboxBiWeeklyReport";
			this.textboxBiWeeklyReport.Size = new System.Drawing.Size(350, 22);
			this.textboxBiWeeklyReport.TabIndex = 9;
			// 
			// documentationListView
			// 
			this.documentationListView.Displayer = null;
			this.documentationListView.DisplayerText = null;
			this.documentationListView.Entity = null;
			this.documentationListView.Location = new System.Drawing.Point(4, 47);
			this.documentationListView.Margin = new System.Windows.Forms.Padding(4);
			this.documentationListView.Name = "documentationListView";
			this.documentationListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.documentationListView.Size = new System.Drawing.Size(1115, 471);
			this.documentationListView.TabIndex = 0;
			// 
			// buttonDelete
			// 
			this.buttonDelete.ActiveBackColor = System.Drawing.Color.Transparent;
			this.buttonDelete.ActiveBackgroundImage = null;
			this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
			this.buttonDelete.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.buttonDelete.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.buttonDelete.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.buttonDelete.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.buttonDelete.Icon = global::CAS.UI.Properties.Resources.DeleteIcon;
			this.buttonDelete.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonDelete.IconNotEnabled = global::CAS.UI.Properties.Resources.DeleteIconGraySmall;
			this.buttonDelete.Location = new System.Drawing.Point(1066, -3);
			this.buttonDelete.Margin = new System.Windows.Forms.Padding(5);
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.NormalBackgroundImage = null;
			this.buttonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
			this.buttonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.buttonDelete.ShowToolTip = true;
			this.buttonDelete.Size = new System.Drawing.Size(48, 46);
			this.buttonDelete.TabIndex = 34;
			this.buttonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonDelete.TextMain = "";
			this.buttonDelete.TextSecondary = "";
			this.buttonDelete.ToolTipText = "Delete";
			this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
			this.buttonDelete.Enabled = !(userType == UsetType.ReadOnly || userType == UsetType.SaveOnly);
			// 
			// ButtonAdd
			// 
			this.ButtonAdd.ActiveBackColor = System.Drawing.Color.Transparent;
			this.ButtonAdd.ActiveBackgroundImage = null;
			this.ButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ButtonAdd.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.ButtonAdd.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.ButtonAdd.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.ButtonAdd.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.ButtonAdd.Icon = global::CAS.UI.Properties.Resources.AddIcon;
			this.ButtonAdd.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.ButtonAdd.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIconGraySmall;
			this.ButtonAdd.Location = new System.Drawing.Point(1016, 0);
			this.ButtonAdd.Margin = new System.Windows.Forms.Padding(5);
			this.ButtonAdd.Name = "ButtonAdd";
			this.ButtonAdd.NormalBackgroundImage = null;
			this.ButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonAdd.ShowToolTip = true;
			this.ButtonAdd.Size = new System.Drawing.Size(39, 38);
			this.ButtonAdd.TabIndex = 33;
			this.ButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonAdd.TextMain = "";
			this.ButtonAdd.TextSecondary = "";
			this.ButtonAdd.ToolTipText = "Add Item";
			this.ButtonAdd.Click += new System.EventHandler(this.ButtonAddClick);
			this.ButtonAdd.Enabled = !(userType == UsetType.ReadOnly);
			// 
			// ButtonFilter
			// 
			this.ButtonFilter.ActiveBackColor = System.Drawing.Color.Transparent;
			this.ButtonFilter.ActiveBackgroundImage = null;
			this.ButtonFilter.Cursor = System.Windows.Forms.Cursors.Hand;
			this.ButtonFilter.FontMain = new System.Drawing.Font("Verdana", 14.25F);
			this.ButtonFilter.FontSecondary = new System.Drawing.Font("Verdana", 9.75F);
			this.ButtonFilter.ForeColorMain = System.Drawing.SystemColors.ControlText;
			this.ButtonFilter.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
			this.ButtonFilter.Icon = global::CAS.UI.Properties.Resources.ApplyFilterIcon;
			this.ButtonFilter.IconLayout = System.Windows.Forms.ImageLayout.Center;
			this.ButtonFilter.IconNotEnabled = global::CAS.UI.Properties.Resources.AddIconGraySmall;
			this.ButtonFilter.Location = new System.Drawing.Point(959, 0);
			this.ButtonFilter.Margin = new System.Windows.Forms.Padding(5);
			this.ButtonFilter.Name = "ButtonFilter";
			this.ButtonFilter.NormalBackgroundImage = null;
			this.ButtonFilter.PaddingMain = new System.Windows.Forms.Padding(0);
			this.ButtonFilter.PaddingSecondary = new System.Windows.Forms.Padding(0);
			this.ButtonFilter.ShowToolTip = true;
			this.ButtonFilter.Size = new System.Drawing.Size(42, 38);
			this.ButtonFilter.TabIndex = 35;
			this.ButtonFilter.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonFilter.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonFilter.TextMain = "";
			this.ButtonFilter.TextSecondary = "";
			this.ButtonFilter.ToolTipText = "Add Item";
			this.ButtonFilter.Click += new System.EventHandler(this.ButtonApplyFilterClick);
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox2.Location = new System.Drawing.Point(1004, -4);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(5, 50);
			this.pictureBox2.TabIndex = 36;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = global::CAS.UI.Properties.Resources.SeparatorLine1;
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pictureBox1.Location = new System.Drawing.Point(1063, -3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(5, 50);
			this.pictureBox1.TabIndex = 37;
			this.pictureBox1.TabStop = false;
			// 
			// EmployeeDocumentsControl
			// 
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.ButtonFilter);
			this.Controls.Add(this.buttonDelete);
			this.Controls.Add(this.ButtonAdd);
			this.Controls.Add(this.documentationListView);
			this.Name = "EmployeeDocumentsControl";
			this.Size = new System.Drawing.Size(1419, 528);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private Label labelBiWeeklyReport;
        private TextBox textboxBiWeeklyReport;
        private DocumentationControls.DocumentationListView documentationListView;
        private AvControls.AvButtonT.AvButtonT buttonDelete;
        private AvControls.AvButtonT.AvButtonT ButtonAdd;
		private AvControls.AvButtonT.AvButtonT ButtonFilter;
		private PictureBox pictureBox2;
		private PictureBox pictureBox1;
	}
}
