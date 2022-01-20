
namespace CAS.UI.UICAAControls.Audit
{
    partial class AuditForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MetroFramework.Controls.MetroLabel metroLabel2;
            MetroFramework.Controls.MetroLabel metroLabel6;
            MetroFramework.Controls.MetroLabel label14;
            this.metroTextBoxAuditNumber = new MetroFramework.Controls.MetroTextBox();
            this.comboBoxOperator = new System.Windows.Forms.ComboBox();
            this.textBoxRemarks = new MetroFramework.Controls.MetroTextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this._fromroutineAuditListView = new CAS.UI.UICAAControls.CheckList.RoutineAuditListView();
            this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
            this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
            this._toroutineAuditListView = new CAS.UI.UICAAControls.CheckList.RoutineAuditListView();
            metroLabel2 = new MetroFramework.Controls.MetroLabel();
            metroLabel6 = new MetroFramework.Controls.MetroLabel();
            label14 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroLabel2
            // 
            metroLabel2.AutoSize = true;
            metroLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            metroLabel2.Location = new System.Drawing.Point(1120, 64);
            metroLabel2.Name = "metroLabel2";
            metroLabel2.Size = new System.Drawing.Size(65, 19);
            metroLabel2.TabIndex = 82;
            metroLabel2.Text = "Audit No:";
            metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroLabel6
            // 
            metroLabel6.AutoSize = true;
            metroLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            metroLabel6.Location = new System.Drawing.Point(1120, 90);
            metroLabel6.Name = "metroLabel6";
            metroLabel6.Size = new System.Drawing.Size(123, 19);
            metroLabel6.TabIndex = 263;
            metroLabel6.Text = "Operator/Provider:";
            metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label14.Location = new System.Drawing.Point(1121, 119);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(57, 19);
            label14.TabIndex = 268;
            label14.Text = "Remark:";
            label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // metroTextBoxAuditNumber
            // 
            // 
            // 
            // 
            this.metroTextBoxAuditNumber.CustomButton.Image = null;
            this.metroTextBoxAuditNumber.CustomButton.Location = new System.Drawing.Point(233, 2);
            this.metroTextBoxAuditNumber.CustomButton.Name = "";
            this.metroTextBoxAuditNumber.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.metroTextBoxAuditNumber.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxAuditNumber.CustomButton.TabIndex = 1;
            this.metroTextBoxAuditNumber.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxAuditNumber.CustomButton.UseSelectable = true;
            this.metroTextBoxAuditNumber.CustomButton.Visible = false;
            this.metroTextBoxAuditNumber.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxAuditNumber.Lines = new string[0];
            this.metroTextBoxAuditNumber.Location = new System.Drawing.Point(1246, 63);
            this.metroTextBoxAuditNumber.MaxLength = 32767;
            this.metroTextBoxAuditNumber.Name = "metroTextBoxAuditNumber";
            this.metroTextBoxAuditNumber.PasswordChar = '\0';
            this.metroTextBoxAuditNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxAuditNumber.SelectedText = "";
            this.metroTextBoxAuditNumber.SelectionLength = 0;
            this.metroTextBoxAuditNumber.SelectionStart = 0;
            this.metroTextBoxAuditNumber.ShortcutsEnabled = true;
            this.metroTextBoxAuditNumber.Size = new System.Drawing.Size(251, 20);
            this.metroTextBoxAuditNumber.TabIndex = 83;
            this.metroTextBoxAuditNumber.UseSelectable = true;
            this.metroTextBoxAuditNumber.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxAuditNumber.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // comboBoxOperator
            // 
            this.comboBoxOperator.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxOperator.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxOperator.FormattingEnabled = true;
            this.comboBoxOperator.Location = new System.Drawing.Point(1246, 89);
            this.comboBoxOperator.Name = "comboBoxOperator";
            this.comboBoxOperator.Size = new System.Drawing.Size(250, 22);
            this.comboBoxOperator.TabIndex = 262;
            // 
            // textBoxRemarks
            // 
            // 
            // 
            // 
            this.textBoxRemarks.CustomButton.Image = null;
            this.textBoxRemarks.CustomButton.Location = new System.Drawing.Point(208, 2);
            this.textBoxRemarks.CustomButton.Name = "";
            this.textBoxRemarks.CustomButton.Size = new System.Drawing.Size(39, 39);
            this.textBoxRemarks.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxRemarks.CustomButton.TabIndex = 1;
            this.textBoxRemarks.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxRemarks.CustomButton.UseSelectable = true;
            this.textBoxRemarks.CustomButton.Visible = false;
            this.textBoxRemarks.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxRemarks.Lines = new string[0];
            this.textBoxRemarks.Location = new System.Drawing.Point(1246, 118);
            this.textBoxRemarks.MaxLength = 32767;
            this.textBoxRemarks.Multiline = true;
            this.textBoxRemarks.Name = "textBoxRemarks";
            this.textBoxRemarks.PasswordChar = '\0';
            this.textBoxRemarks.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxRemarks.SelectedText = "";
            this.textBoxRemarks.SelectionLength = 0;
            this.textBoxRemarks.SelectionStart = 0;
            this.textBoxRemarks.ShortcutsEnabled = true;
            this.textBoxRemarks.Size = new System.Drawing.Size(250, 44);
            this.textBoxRemarks.TabIndex = 269;
            this.textBoxRemarks.UseSelectable = true;
            this.textBoxRemarks.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxRemarks.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonOk.Location = new System.Drawing.Point(1338, 685);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 33);
            this.buttonOk.TabIndex = 340;
            this.buttonOk.Text = "OK";
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonCancel.Location = new System.Drawing.Point(1419, 685);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 33);
            this.buttonCancel.TabIndex = 339;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // _fromroutineAuditListView
            // 
            this._fromroutineAuditListView.ConfigurePaste = null;
            this._fromroutineAuditListView.Displayer = null;
            this._fromroutineAuditListView.DisplayerText = null;
            this._fromroutineAuditListView.EnableCustomSorting = true;
            this._fromroutineAuditListView.Entity = null;
            this._fromroutineAuditListView.IgnoreEnterPress = false;
            this._fromroutineAuditListView.Location = new System.Drawing.Point(23, 60);
            this._fromroutineAuditListView.MenuOpeningAction = null;
            this._fromroutineAuditListView.Name = "_fromroutineAuditListView";
            this._fromroutineAuditListView.OldColumnIndex = 0;
            this._fromroutineAuditListView.PasteComplete = null;
            this._fromroutineAuditListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this._fromroutineAuditListView.Size = new System.Drawing.Size(1091, 295);
            this._fromroutineAuditListView.SortDirection = CAS.UI.UIControls.NewGrid.SortDirection.Asc;
            this._fromroutineAuditListView.TabIndex = 341;
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.ActiveBackColor = System.Drawing.Color.Transparent;
            this.ButtonDelete.ActiveBackgroundImage = null;
            this.ButtonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonDelete.FontMain = new System.Drawing.Font("Verdana", 8F);
            this.ButtonDelete.FontSecondary = new System.Drawing.Font("Verdana", 8F);
            this.ButtonDelete.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.ButtonDelete.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.ButtonDelete.Icon = global::CAS.UI.Properties.Resources.DeleteIconSmall;
            this.ButtonDelete.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonDelete.IconNotEnabled = null;
            this.ButtonDelete.Location = new System.Drawing.Point(997, 696);
            this.ButtonDelete.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.NormalBackgroundImage = null;
            this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonDelete.ShowToolTip = false;
            this.ButtonDelete.Size = new System.Drawing.Size(122, 22);
            this.ButtonDelete.TabIndex = 343;
            this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.TextMain = "Delete Selected";
            this.ButtonDelete.TextSecondary = "";
            this.ButtonDelete.ToolTipText = "";
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.ActiveBackColor = System.Drawing.Color.Transparent;
            this.ButtonAdd.ActiveBackgroundImage = null;
            this.ButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonAdd.FontMain = new System.Drawing.Font("Verdana", 8F);
            this.ButtonAdd.FontSecondary = new System.Drawing.Font("Verdana", 8F);
            this.ButtonAdd.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.ButtonAdd.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.ButtonAdd.Icon = global::CAS.UI.Properties.Resources.AddIconSmall;
            this.ButtonAdd.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonAdd.IconNotEnabled = null;
            this.ButtonAdd.Location = new System.Drawing.Point(1003, 359);
            this.ButtonAdd.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.NormalBackgroundImage = null;
            this.ButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonAdd.ShowToolTip = false;
            this.ButtonAdd.Size = new System.Drawing.Size(116, 33);
            this.ButtonAdd.TabIndex = 342;
            this.ButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAdd.TextMain = "Add Selected";
            this.ButtonAdd.TextSecondary = "";
            this.ButtonAdd.ToolTipText = "";
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // _toroutineAuditListView
            // 
            this._toroutineAuditListView.ConfigurePaste = null;
            this._toroutineAuditListView.Displayer = null;
            this._toroutineAuditListView.DisplayerText = null;
            this._toroutineAuditListView.EnableCustomSorting = true;
            this._toroutineAuditListView.Entity = null;
            this._toroutineAuditListView.IgnoreEnterPress = false;
            this._toroutineAuditListView.Location = new System.Drawing.Point(23, 394);
            this._toroutineAuditListView.MenuOpeningAction = null;
            this._toroutineAuditListView.Name = "_toroutineAuditListView";
            this._toroutineAuditListView.OldColumnIndex = 0;
            this._toroutineAuditListView.PasteComplete = null;
            this._toroutineAuditListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this._toroutineAuditListView.Size = new System.Drawing.Size(1091, 295);
            this._toroutineAuditListView.SortDirection = CAS.UI.UIControls.NewGrid.SortDirection.Asc;
            this._toroutineAuditListView.TabIndex = 344;
            // 
            // AuditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1501, 730);
            this.Controls.Add(this._toroutineAuditListView);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this._fromroutineAuditListView);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxRemarks);
            this.Controls.Add(label14);
            this.Controls.Add(metroLabel6);
            this.Controls.Add(this.comboBoxOperator);
            this.Controls.Add(this.metroTextBoxAuditNumber);
            this.Controls.Add(metroLabel2);
            this.Name = "AuditForm";
            this.Resizable = false;
            this.Text = "AuditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AuditForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTextBox metroTextBoxAuditNumber;
        private System.Windows.Forms.ComboBox comboBoxOperator;
        private MetroFramework.Controls.MetroTextBox textBoxRemarks;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private CheckList.RoutineAuditListView _fromroutineAuditListView;
        private AvControls.AvButtonT.AvButtonT ButtonDelete;
        private AvControls.AvButtonT.AvButtonT ButtonAdd;
        private CheckList.RoutineAuditListView _toroutineAuditListView;
    }
}