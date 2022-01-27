
namespace CAS.UI.UICAAControls.RoutineAudit
{
    partial class RoutineAuditForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
            this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
            this._tocheckListView = new CAS.UI.UICAAControls.CheckList.CheckListView();
            this._fromcheckListView = new CAS.UI.UICAAControls.CheckList.CheckListView();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.metroTextBoxDescription = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBoxRemark = new MetroFramework.Controls.MetroTextBox();
            this.comboBoxProgramType = new System.Windows.Forms.ComboBox();
            this.comboBoxObject = new System.Windows.Forms.ComboBox();
            this.metroTextBoxTitle = new MetroFramework.Controls.MetroTextBox();
            label1 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Verdana", 9F);
            label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label1.Location = new System.Drawing.Point(1043, 94);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(98, 14);
            label1.TabIndex = 341;
            label1.Text = "Program Type:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Verdana", 9F);
            label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label4.Location = new System.Drawing.Point(1043, 152);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(82, 14);
            label4.TabIndex = 345;
            label4.Text = "Description:";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Verdana", 9F);
            label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label5.Location = new System.Drawing.Point(1043, 253);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(59, 14);
            label5.TabIndex = 347;
            label5.Text = "Remark:";
            label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Verdana", 9F);
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label3.Location = new System.Drawing.Point(1043, 123);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(53, 14);
            label3.TabIndex = 343;
            label3.Text = "Object:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Verdana", 9F);
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label2.Location = new System.Drawing.Point(1044, 69);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(45, 14);
            label2.TabIndex = 351;
            label2.Text = "Code:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.ButtonDelete.Location = new System.Drawing.Point(915, 688);
            this.ButtonDelete.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.NormalBackgroundImage = null;
            this.ButtonDelete.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonDelete.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonDelete.ShowToolTip = false;
            this.ButtonDelete.Size = new System.Drawing.Size(122, 22);
            this.ButtonDelete.TabIndex = 336;
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
            this.ButtonAdd.Location = new System.Drawing.Point(921, 351);
            this.ButtonAdd.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.NormalBackgroundImage = null;
            this.ButtonAdd.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonAdd.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonAdd.ShowToolTip = false;
            this.ButtonAdd.Size = new System.Drawing.Size(116, 33);
            this.ButtonAdd.TabIndex = 335;
            this.ButtonAdd.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAdd.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonAdd.TextMain = "Add Selected";
            this.ButtonAdd.TextSecondary = "";
            this.ButtonAdd.ToolTipText = "";
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // _tocheckListView
            // 
            this._tocheckListView.AuditId = null;
            this._tocheckListView.ColumnIndexes = null;
            this._tocheckListView.ConfigurePaste = null;
            this._tocheckListView.Displayer = null;
            this._tocheckListView.DisplayerText = null;
            this._tocheckListView.EnableCustomSorting = true;
            this._tocheckListView.Entity = null;
            this._tocheckListView.IgnoreEnterPress = false;
            this._tocheckListView.IsAuditCheck = false;
            this._tocheckListView.Location = new System.Drawing.Point(8, 391);
            this._tocheckListView.MenuOpeningAction = null;
            this._tocheckListView.Name = "_tocheckListView";
            this._tocheckListView.OldColumnIndex = 0;
            this._tocheckListView.PasteComplete = null;
            this._tocheckListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this._tocheckListView.Size = new System.Drawing.Size(1029, 290);
            this._tocheckListView.SortDirection = CAS.UI.UIControls.NewGrid.SortDirection.Asc;
            this._tocheckListView.TabIndex = 334;
            // 
            // _fromcheckListView
            // 
            this._fromcheckListView.AuditId = null;
            this._fromcheckListView.ColumnIndexes = null;
            this._fromcheckListView.ConfigurePaste = null;
            this._fromcheckListView.Displayer = null;
            this._fromcheckListView.DisplayerText = null;
            this._fromcheckListView.EnableCustomSorting = true;
            this._fromcheckListView.Entity = null;
            this._fromcheckListView.IgnoreEnterPress = false;
            this._fromcheckListView.IsAuditCheck = false;
            this._fromcheckListView.Location = new System.Drawing.Point(8, 63);
            this._fromcheckListView.MenuOpeningAction = null;
            this._fromcheckListView.Name = "_fromcheckListView";
            this._fromcheckListView.OldColumnIndex = 0;
            this._fromcheckListView.PasteComplete = null;
            this._fromcheckListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this._fromcheckListView.Size = new System.Drawing.Size(1029, 290);
            this._fromcheckListView.SortDirection = CAS.UI.UIControls.NewGrid.SortDirection.Asc;
            this._fromcheckListView.TabIndex = 333;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonOk.Location = new System.Drawing.Point(1331, 688);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 33);
            this.buttonOk.TabIndex = 338;
            this.buttonOk.Text = "OK";
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonCancel.Location = new System.Drawing.Point(1412, 688);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 33);
            this.buttonCancel.TabIndex = 337;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // metroTextBoxDescription
            // 
            // 
            // 
            // 
            this.metroTextBoxDescription.CustomButton.Image = null;
            this.metroTextBoxDescription.CustomButton.Location = new System.Drawing.Point(253, 1);
            this.metroTextBoxDescription.CustomButton.Name = "";
            this.metroTextBoxDescription.CustomButton.Size = new System.Drawing.Size(93, 93);
            this.metroTextBoxDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxDescription.CustomButton.TabIndex = 1;
            this.metroTextBoxDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxDescription.CustomButton.UseSelectable = true;
            this.metroTextBoxDescription.CustomButton.Visible = false;
            this.metroTextBoxDescription.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxDescription.Lines = new string[0];
            this.metroTextBoxDescription.Location = new System.Drawing.Point(1146, 150);
            this.metroTextBoxDescription.MaxLength = 32767;
            this.metroTextBoxDescription.Multiline = true;
            this.metroTextBoxDescription.Name = "metroTextBoxDescription";
            this.metroTextBoxDescription.PasswordChar = '\0';
            this.metroTextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxDescription.SelectedText = "";
            this.metroTextBoxDescription.SelectionLength = 0;
            this.metroTextBoxDescription.SelectionStart = 0;
            this.metroTextBoxDescription.ShortcutsEnabled = true;
            this.metroTextBoxDescription.Size = new System.Drawing.Size(347, 95);
            this.metroTextBoxDescription.TabIndex = 346;
            this.metroTextBoxDescription.UseSelectable = true;
            this.metroTextBoxDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTextBoxRemark
            // 
            // 
            // 
            // 
            this.metroTextBoxRemark.CustomButton.Image = null;
            this.metroTextBoxRemark.CustomButton.Location = new System.Drawing.Point(253, 1);
            this.metroTextBoxRemark.CustomButton.Name = "";
            this.metroTextBoxRemark.CustomButton.Size = new System.Drawing.Size(93, 93);
            this.metroTextBoxRemark.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxRemark.CustomButton.TabIndex = 1;
            this.metroTextBoxRemark.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxRemark.CustomButton.UseSelectable = true;
            this.metroTextBoxRemark.CustomButton.Visible = false;
            this.metroTextBoxRemark.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxRemark.Lines = new string[0];
            this.metroTextBoxRemark.Location = new System.Drawing.Point(1146, 251);
            this.metroTextBoxRemark.MaxLength = 32767;
            this.metroTextBoxRemark.Multiline = true;
            this.metroTextBoxRemark.Name = "metroTextBoxRemark";
            this.metroTextBoxRemark.PasswordChar = '\0';
            this.metroTextBoxRemark.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxRemark.SelectedText = "";
            this.metroTextBoxRemark.SelectionLength = 0;
            this.metroTextBoxRemark.SelectionStart = 0;
            this.metroTextBoxRemark.ShortcutsEnabled = true;
            this.metroTextBoxRemark.Size = new System.Drawing.Size(347, 95);
            this.metroTextBoxRemark.TabIndex = 348;
            this.metroTextBoxRemark.UseSelectable = true;
            this.metroTextBoxRemark.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxRemark.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // comboBoxProgramType
            // 
            this.comboBoxProgramType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxProgramType.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxProgramType.FormattingEnabled = true;
            this.comboBoxProgramType.Location = new System.Drawing.Point(1146, 94);
            this.comboBoxProgramType.Name = "comboBoxProgramType";
            this.comboBoxProgramType.Size = new System.Drawing.Size(347, 22);
            this.comboBoxProgramType.TabIndex = 349;
            // 
            // comboBoxObject
            // 
            this.comboBoxObject.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxObject.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxObject.FormattingEnabled = true;
            this.comboBoxObject.Location = new System.Drawing.Point(1146, 119);
            this.comboBoxObject.Name = "comboBoxObject";
            this.comboBoxObject.Size = new System.Drawing.Size(347, 22);
            this.comboBoxObject.TabIndex = 350;
            // 
            // metroTextBoxTitle
            // 
            // 
            // 
            // 
            this.metroTextBoxTitle.CustomButton.Image = null;
            this.metroTextBoxTitle.CustomButton.Location = new System.Drawing.Point(327, 1);
            this.metroTextBoxTitle.CustomButton.Name = "";
            this.metroTextBoxTitle.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.metroTextBoxTitle.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxTitle.CustomButton.TabIndex = 1;
            this.metroTextBoxTitle.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxTitle.CustomButton.UseSelectable = true;
            this.metroTextBoxTitle.CustomButton.Visible = false;
            this.metroTextBoxTitle.ForeColor = System.Drawing.Color.DimGray;
            this.metroTextBoxTitle.Lines = new string[0];
            this.metroTextBoxTitle.Location = new System.Drawing.Point(1147, 67);
            this.metroTextBoxTitle.MaxLength = 32767;
            this.metroTextBoxTitle.Multiline = true;
            this.metroTextBoxTitle.Name = "metroTextBoxTitle";
            this.metroTextBoxTitle.PasswordChar = '\0';
            this.metroTextBoxTitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxTitle.SelectedText = "";
            this.metroTextBoxTitle.SelectionLength = 0;
            this.metroTextBoxTitle.SelectionStart = 0;
            this.metroTextBoxTitle.ShortcutsEnabled = true;
            this.metroTextBoxTitle.Size = new System.Drawing.Size(347, 21);
            this.metroTextBoxTitle.TabIndex = 352;
            this.metroTextBoxTitle.UseSelectable = true;
            this.metroTextBoxTitle.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxTitle.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // RoutineAuditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1501, 730);
            this.Controls.Add(this.metroTextBoxTitle);
            this.Controls.Add(label2);
            this.Controls.Add(this.comboBoxObject);
            this.Controls.Add(this.comboBoxProgramType);
            this.Controls.Add(this.metroTextBoxRemark);
            this.Controls.Add(label5);
            this.Controls.Add(this.metroTextBoxDescription);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this._tocheckListView);
            this.Controls.Add(this._fromcheckListView);
            this.Name = "RoutineAuditForm";
            this.Resizable = false;
            this.Text = "RoutineAuditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoutineAuditForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AvControls.AvButtonT.AvButtonT ButtonDelete;
        private AvControls.AvButtonT.AvButtonT ButtonAdd;
        private CheckList.CheckListView _tocheckListView;
        private CheckList.CheckListView _fromcheckListView;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private MetroFramework.Controls.MetroTextBox metroTextBoxDescription;
        private MetroFramework.Controls.MetroTextBox metroTextBoxRemark;
        private System.Windows.Forms.ComboBox comboBoxProgramType;
        private System.Windows.Forms.ComboBox comboBoxObject;
        private MetroFramework.Controls.MetroTextBox metroTextBoxTitle;
    }
}