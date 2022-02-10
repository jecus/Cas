
namespace CAS.UI.UICAAControls.Audit.PEL
{
    partial class AuditTeamForm
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
            System.Windows.Forms.Label label3;
            this.buttonOk = new System.Windows.Forms.Button();
            this._fromcheckRevisionListView = new CAS.UI.UICAAControls.Audit.PEL.PelPersonnelListView();
            this._tocheckRevisionListView = new CAS.UI.UICAAControls.Audit.PEL.PelPersonnelListView();
            this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
            this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.comboBoxRoles = new System.Windows.Forms.ComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.comboBoxResponsibilities = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(0, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(100, 23);
            label3.TabIndex = 0;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonOk.Location = new System.Drawing.Point(1288, 796);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 33);
            this.buttonOk.TabIndex = 328;
            this.buttonOk.Text = "OK";
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // _fromcheckRevisionListView
            // 
            this._fromcheckRevisionListView.Location = new System.Drawing.Point(5, 53);
            this._fromcheckRevisionListView.Name = "_fromcheckRevisionListView";
            this._fromcheckRevisionListView.PasteComplete = null;
            this._fromcheckRevisionListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this._fromcheckRevisionListView.Size = new System.Drawing.Size(1419, 317);
            this._fromcheckRevisionListView.SortDirection = CAS.UI.UIControls.NewGrid.SortDirection.Asc;
            this._fromcheckRevisionListView.TabIndex = 329;
            // 
            // _tocheckRevisionListView
            // 
            this._tocheckRevisionListView.Location = new System.Drawing.Point(5, 417);
            this._tocheckRevisionListView.Name = "_tocheckRevisionListView";
            this._tocheckRevisionListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this._tocheckRevisionListView.Size = new System.Drawing.Size(1419, 346);
            this._tocheckRevisionListView.SortDirection = CAS.UI.UIControls.NewGrid.SortDirection.Asc;
            this._tocheckRevisionListView.TabIndex = 330;
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
            this.ButtonAdd.Location = new System.Drawing.Point(1307, 377);
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
            this.ButtonDelete.Location = new System.Drawing.Point(1302, 770);
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
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.metroLabel6.Location = new System.Drawing.Point(640, 385);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(43, 19);
            this.metroLabel6.TabIndex = 334;
            this.metroLabel6.Text = "Roles:";
            this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxRoles
            // 
            this.comboBoxRoles.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxRoles.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxRoles.FormattingEnabled = true;
            this.comboBoxRoles.Location = new System.Drawing.Point(689, 382);
            this.comboBoxRoles.Name = "comboBoxRoles";
            this.comboBoxRoles.Size = new System.Drawing.Size(250, 22);
            this.comboBoxRoles.TabIndex = 333;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.metroLabel1.Location = new System.Drawing.Point(945, 382);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(99, 19);
            this.metroLabel1.TabIndex = 336;
            this.metroLabel1.Text = "Responsibilities:";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxResponsibilities 
            // 
            this.comboBoxResponsibilities.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxResponsibilities.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxResponsibilities.FormattingEnabled = true;
            this.comboBoxResponsibilities.Location = new System.Drawing.Point(1050, 379);
            this.comboBoxResponsibilities.Name = "comboBoxResponsibilities ";
            this.comboBoxResponsibilities.Size = new System.Drawing.Size(250, 22);
            this.comboBoxResponsibilities.TabIndex = 335;
            // 
            // AuditTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 840);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.comboBoxResponsibilities);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.comboBoxRoles);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this._tocheckRevisionListView);
            this.Controls.Add(this._fromcheckRevisionListView);
            this.Controls.Add(this.buttonOk);
            this.Name = "AuditTeamForm";
            this.Resizable = false;
            this.Text = "CheckList Revision Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckListRevisionForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.ComboBox comboBoxRoles;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ComboBox comboBoxResponsibilities;

        #endregion

        System.Windows.Forms.Label label3;

        private System.Windows.Forms.Button buttonOk;
        private CAS.UI.UICAAControls.Audit.PEL.PelPersonnelListView _fromcheckRevisionListView;
        private CAS.UI.UICAAControls.Audit.PEL.PelPersonnelListView _tocheckRevisionListView;
        private AvControls.AvButtonT.AvButtonT ButtonAdd;
        private AvControls.AvButtonT.AvButtonT ButtonDelete;
    }
}