
using CAS.UI.UICAAControls.CheckList.EditionRevision.Safa;

namespace CAS.UI.UICAAControls.CheckList.EditionRevision.Icao
{
    partial class CheckListIcaoRevisionForm
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
            System.Windows.Forms.Label metroLabel1;
            System.Windows.Forms.Label label17;
            System.Windows.Forms.Label label19;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckListIcaoRevisionForm));
            this.checkBoxRevisionValidTo = new System.Windows.Forms.CheckBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this._fromcheckListView = new CAS.UI.UICAAControls.CheckList.CheckListICAOView();
            this._tocheckListView = new CAS.UI.UICAAControls.CheckList.CheckListICAOView();
            this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
            this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
            this.metroTextSource = new MetroFramework.Controls.MetroTextBox();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.checkBoxSource = new System.Windows.Forms.CheckBox();
            this.checkBoxLevel = new System.Windows.Forms.CheckBox();
            this.checkBoxMH = new System.Windows.Forms.CheckBox();
            this.metroTextBoxMH = new MetroFramework.Controls.MetroTextBox();
            this.comboBoxRevision = new System.Windows.Forms.ComboBox();
            metroLabel1 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            metroLabel1.AutoSize = true;
            metroLabel1.Font = new System.Drawing.Font("Verdana", 9F);
            metroLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            metroLabel1.Location = new System.Drawing.Point(1065, 65);
            metroLabel1.Name = "metroLabel1";
            metroLabel1.Size = new System.Drawing.Size(55, 14);
            metroLabel1.TabIndex = 310;
            metroLabel1.Text = "Source:";
            metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new System.Drawing.Font("Verdana", 9F);
            label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label17.Location = new System.Drawing.Point(1065, 145);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(45, 14);
            label17.TabIndex = 336;
            label17.Text = "Level:";
            label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new System.Drawing.Font("Verdana", 9F);
            label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label19.Location = new System.Drawing.Point(1065, 177);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(31, 14);
            label19.TabIndex = 347;
            label19.Text = "MH:";
            label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(0, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(100, 23);
            label3.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Verdana", 9F);
            label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label4.Location = new System.Drawing.Point(1064, 114);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(64, 14);
            label4.TabIndex = 352;
            label4.Text = "Revision:";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxRevisionValidTo
            // 
            this.checkBoxRevisionValidTo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxRevisionValidTo.Font = new System.Drawing.Font("Verdana", 9F);
            this.checkBoxRevisionValidTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.checkBoxRevisionValidTo.Location = new System.Drawing.Point(1038, 114);
            this.checkBoxRevisionValidTo.Name = "checkBoxRevisionValidTo";
            this.checkBoxRevisionValidTo.Size = new System.Drawing.Size(18, 16);
            this.checkBoxRevisionValidTo.TabIndex = 326;
            this.checkBoxRevisionValidTo.CheckedChanged += new System.EventHandler(this.checkBoxRevisionValidTo_CheckedChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonOk.Location = new System.Drawing.Point(1359, 759);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 33);
            this.buttonOk.TabIndex = 328;
            this.buttonOk.Text = "OK";
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonCancel.Location = new System.Drawing.Point(1440, 759);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 33);
            this.buttonCancel.TabIndex = 327;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // _fromcheckListView
            // 
            this._fromcheckListView.AuditId = null;
            this._fromcheckListView.ColumnIndexes = ((System.Collections.Generic.List<string>)(resources.GetObject("_fromcheckListView.ColumnIndexes")));
            this._fromcheckListView.ConfigurePaste = null;
            this._fromcheckListView.Displayer = null;
            this._fromcheckListView.DisplayerText = null;
            this._fromcheckListView.EnableCustomSorting = true;
            this._fromcheckListView.Entity = null;
            this._fromcheckListView.IgnoreEnterPress = false;
            this._fromcheckListView.IsAuditCheck = false;
            this._fromcheckListView.IsRevision = false;
            this._fromcheckListView.Location = new System.Drawing.Point(5, 53);
            this._fromcheckListView.MenuOpeningAction = null;
            this._fromcheckListView.Name = "_fromcheckListView";
            this._fromcheckListView.OldColumnIndex = 0;
            this._fromcheckListView.PasteComplete = null;
            this._fromcheckListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this._fromcheckListView.Size = new System.Drawing.Size(1029, 306);
            this._fromcheckListView.SortDirection = CAS.UI.UIControls.NewGrid.SortDirection.Desc;
            this._fromcheckListView.TabIndex = 329;
            // 
            // _tocheckListView
            // 
            this._tocheckListView.AuditId = null;
            this._tocheckListView.ColumnIndexes = ((System.Collections.Generic.List<string>)(resources.GetObject("_tocheckListView.ColumnIndexes")));
            this._tocheckListView.ConfigurePaste = null;
            this._tocheckListView.Displayer = null;
            this._tocheckListView.DisplayerText = null;
            this._tocheckListView.EnableCustomSorting = true;
            this._tocheckListView.Entity = null;
            this._tocheckListView.IgnoreEnterPress = false;
            this._tocheckListView.IsAuditCheck = false;
            this._tocheckListView.IsRevision = false;
            this._tocheckListView.Location = new System.Drawing.Point(5, 406);
            this._tocheckListView.MenuOpeningAction = null;
            this._tocheckListView.Name = "_tocheckListView";
            this._tocheckListView.OldColumnIndex = 0;
            this._tocheckListView.PasteComplete = null;
            this._tocheckListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this._tocheckListView.Size = new System.Drawing.Size(1029, 346);
            this._tocheckListView.SortDirection = CAS.UI.UIControls.NewGrid.SortDirection.Desc;
            this._tocheckListView.TabIndex = 330;
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
            this.ButtonAdd.Location = new System.Drawing.Point(918, 366);
            this.ButtonAdd.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.NormalBackgroundImage = null;
            this.ButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonAdd.ShowToolTip = false;
            this.ButtonAdd.Size = new System.Drawing.Size(116, 33);
            this.ButtonAdd.TabIndex = 331;
            this.ButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAdd.TextMain = "Add Selected";
            this.ButtonAdd.TextSecondary = "";
            this.ButtonAdd.ToolTipText = "";
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
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
            this.ButtonDelete.Location = new System.Drawing.Point(912, 770);
            this.ButtonDelete.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.NormalBackgroundImage = null;
            this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonDelete.ShowToolTip = false;
            this.ButtonDelete.Size = new System.Drawing.Size(122, 22);
            this.ButtonDelete.TabIndex = 332;
            this.ButtonDelete.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.TextMain = "Delete Selected";
            this.ButtonDelete.TextSecondary = "";
            this.ButtonDelete.ToolTipText = "";
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // metroTextSource
            // 
            // 
            // 
            // 
            this.metroTextSource.CustomButton.Image = null;
            this.metroTextSource.CustomButton.Location = new System.Drawing.Point(309, 1);
            this.metroTextSource.CustomButton.Name = "";
            this.metroTextSource.CustomButton.Size = new System.Drawing.Size(37, 37);
            this.metroTextSource.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextSource.CustomButton.TabIndex = 1;
            this.metroTextSource.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextSource.CustomButton.UseSelectable = true;
            this.metroTextSource.CustomButton.Visible = false;
            this.metroTextSource.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextSource.Lines = new string[0];
            this.metroTextSource.Location = new System.Drawing.Point(1168, 53);
            this.metroTextSource.MaxLength = 32767;
            this.metroTextSource.Multiline = true;
            this.metroTextSource.Name = "metroTextSource";
            this.metroTextSource.PasswordChar = '\0';
            this.metroTextSource.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextSource.SelectedText = "";
            this.metroTextSource.SelectionLength = 0;
            this.metroTextSource.SelectionStart = 0;
            this.metroTextSource.ShortcutsEnabled = true;
            this.metroTextSource.Size = new System.Drawing.Size(347, 39);
            this.metroTextSource.TabIndex = 335;
            this.metroTextSource.UseSelectable = true;
            this.metroTextSource.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextSource.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxLevel.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Location = new System.Drawing.Point(1169, 137);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(121, 22);
            this.comboBoxLevel.TabIndex = 337;
            // 
            // checkBoxSource
            // 
            this.checkBoxSource.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxSource.Font = new System.Drawing.Font("Verdana", 9F);
            this.checkBoxSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.checkBoxSource.Location = new System.Drawing.Point(1039, 65);
            this.checkBoxSource.Name = "checkBoxSource";
            this.checkBoxSource.Size = new System.Drawing.Size(18, 16);
            this.checkBoxSource.TabIndex = 338;
            this.checkBoxSource.CheckedChanged += new System.EventHandler(this.checkBoxSource_CheckedChanged);
            // 
            // checkBoxLevel
            // 
            this.checkBoxLevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxLevel.Font = new System.Drawing.Font("Verdana", 9F);
            this.checkBoxLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.checkBoxLevel.Location = new System.Drawing.Point(1038, 145);
            this.checkBoxLevel.Name = "checkBoxLevel";
            this.checkBoxLevel.Size = new System.Drawing.Size(18, 16);
            this.checkBoxLevel.TabIndex = 344;
            this.checkBoxLevel.CheckedChanged += new System.EventHandler(this.checkBoxLevel_CheckedChanged);
            // 
            // checkBoxMH
            // 
            this.checkBoxMH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxMH.Font = new System.Drawing.Font("Verdana", 9F);
            this.checkBoxMH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.checkBoxMH.Location = new System.Drawing.Point(1038, 177);
            this.checkBoxMH.Name = "checkBoxMH";
            this.checkBoxMH.Size = new System.Drawing.Size(18, 16);
            this.checkBoxMH.TabIndex = 350;
            this.checkBoxMH.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // metroTextBoxMH
            // 
            // 
            // 
            // 
            this.metroTextBoxMH.CustomButton.Image = null;
            this.metroTextBoxMH.CustomButton.Location = new System.Drawing.Point(101, 1);
            this.metroTextBoxMH.CustomButton.Name = "";
            this.metroTextBoxMH.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.metroTextBoxMH.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxMH.CustomButton.TabIndex = 1;
            this.metroTextBoxMH.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxMH.CustomButton.UseSelectable = true;
            this.metroTextBoxMH.CustomButton.Visible = false;
            this.metroTextBoxMH.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxMH.Lines = new string[0];
            this.metroTextBoxMH.Location = new System.Drawing.Point(1168, 170);
            this.metroTextBoxMH.MaxLength = 32767;
            this.metroTextBoxMH.Multiline = true;
            this.metroTextBoxMH.Name = "metroTextBoxMH";
            this.metroTextBoxMH.PasswordChar = '\0';
            this.metroTextBoxMH.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxMH.SelectedText = "";
            this.metroTextBoxMH.SelectionLength = 0;
            this.metroTextBoxMH.SelectionStart = 0;
            this.metroTextBoxMH.ShortcutsEnabled = true;
            this.metroTextBoxMH.Size = new System.Drawing.Size(121, 21);
            this.metroTextBoxMH.TabIndex = 351;
            this.metroTextBoxMH.UseSelectable = true;
            this.metroTextBoxMH.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxMH.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // comboBoxRevision
            // 
            this.comboBoxRevision.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxRevision.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxRevision.FormattingEnabled = true;
            this.comboBoxRevision.Location = new System.Drawing.Point(1168, 106);
            this.comboBoxRevision.Name = "comboBoxRevision";
            this.comboBoxRevision.Size = new System.Drawing.Size(121, 22);
            this.comboBoxRevision.TabIndex = 353;
            // 
            // CheckListIcaoRevisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 803);
            this.Controls.Add(this.comboBoxRevision);
            this.Controls.Add(label4);
            this.Controls.Add(this.metroTextBoxMH);
            this.Controls.Add(this.checkBoxMH);
            this.Controls.Add(label19);
            this.Controls.Add(this.checkBoxLevel);
            this.Controls.Add(this.checkBoxSource);
            this.Controls.Add(this.comboBoxLevel);
            this.Controls.Add(label17);
            this.Controls.Add(this.metroTextSource);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this._tocheckListView);
            this.Controls.Add(this._fromcheckListView);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.checkBoxRevisionValidTo);
            this.Controls.Add(metroLabel1);
            this.MaximizeBox = false;
            this.Name = "CheckListIcaoRevisionForm";
            this.Resizable = false;
            this.Text = "CheckList Revision Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckListRevisionForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboBoxRevision;

        #endregion

        System.Windows.Forms.Label metroLabel1;
        System.Windows.Forms.Label label3;

        private System.Windows.Forms.CheckBox checkBoxRevisionValidTo;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private CAS.UI.UICAAControls.CheckList.CheckListICAOView _fromcheckListView;
        private CAS.UI.UICAAControls.CheckList.CheckListICAOView _tocheckListView;
        private AvControls.AvButtonT.AvButtonT ButtonAdd;
        private AvControls.AvButtonT.AvButtonT ButtonDelete;
        private MetroFramework.Controls.MetroTextBox metroTextSource;
        private System.Windows.Forms.ComboBox comboBoxLevel;
        private System.Windows.Forms.CheckBox checkBoxSource;
        private System.Windows.Forms.CheckBox checkBoxLevel;
        private System.Windows.Forms.CheckBox checkBoxMH;
        private MetroFramework.Controls.MetroTextBox metroTextBoxMH;
    }
}