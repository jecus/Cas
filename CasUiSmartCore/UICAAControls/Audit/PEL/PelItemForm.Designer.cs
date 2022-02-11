
using MetroFramework.Controls;

namespace CAS.UI.UICAAControls.Audit.PEL
{
    partial class PelItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PelItemForm));
            this.buttonOk = new System.Windows.Forms.Button();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this._fromcheckRevisionListView = new CAS.UI.UICAAControls.Audit.PEL.PelItemListView();
            this._tocheckRevisionListView = new CAS.UI.UICAAControls.Audit.PEL.AuditPelRecordListView();
            this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
            this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
            this.comboBoxPersonel = new System.Windows.Forms.ComboBox();
            this.avButtonT1 = new AvControls.AvButtonT.AvButtonT();
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
            this.buttonOk.Location = new System.Drawing.Point(1349, 799);
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
            this._fromcheckRevisionListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this._fromcheckRevisionListView.Size = new System.Drawing.Size(1419, 317);
            this._fromcheckRevisionListView.TabIndex = 329;
            // 
            // _tocheckRevisionListView
            // 
            this._tocheckRevisionListView.Location = new System.Drawing.Point(5, 417);
            this._tocheckRevisionListView.Name = "_tocheckRevisionListView";
            this._tocheckRevisionListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this._tocheckRevisionListView.Size = new System.Drawing.Size(1419, 346);
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
            this.ButtonAdd.Location = new System.Drawing.Point(1207, 357);
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
            this.metroLabel6.Location = new System.Drawing.Point(9, 388);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(61, 19);
            this.metroLabel6.TabIndex = 334;
            this.metroLabel6.Text = "Personel:";
            this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxPersonel
            // 
            this.comboBoxPersonel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxPersonel.ForeColor = System.Drawing.Color.DimGray;
            this.comboBoxPersonel.FormattingEnabled = true;
            this.comboBoxPersonel.Location = new System.Drawing.Point(76, 388);
            this.comboBoxPersonel.Name = "comboBoxPersonel";
            this.comboBoxPersonel.Size = new System.Drawing.Size(578, 22);
            this.comboBoxPersonel.TabIndex = 333;
            // 
            // avButtonT1
            // 
            this.avButtonT1.ActiveBackColor = System.Drawing.Color.Transparent;
            this.avButtonT1.ActiveBackgroundImage = null;
            this.avButtonT1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avButtonT1.FontMain = new System.Drawing.Font("Verdana", 8F);
            this.avButtonT1.FontSecondary = new System.Drawing.Font("Verdana", 8F);
            this.avButtonT1.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.avButtonT1.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.avButtonT1.Icon = global::CAS.UI.Properties.Resources.AddUser;;
            this.avButtonT1.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.avButtonT1.IconNotEnabled = null;
            this.avButtonT1.Location = new System.Drawing.Point(694, 377);
            this.avButtonT1.Margin = new System.Windows.Forms.Padding(4);
            this.avButtonT1.Name = "avButtonT1";
            this.avButtonT1.NormalBackgroundImage = null;
            this.avButtonT1.PaddingMain = new System.Windows.Forms.Padding(0);
            this.avButtonT1.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.avButtonT1.ShowToolTip = false;
            this.avButtonT1.Size = new System.Drawing.Size(116, 33);
            this.avButtonT1.TabIndex = 335;
            this.avButtonT1.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.avButtonT1.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.avButtonT1.TextMain = "Add Personel";
            this.avButtonT1.TextSecondary = "";
            this.avButtonT1.ToolTipText = "";
            this.avButtonT1.Click += AvButtonT1OnClick;
            // 
            // PelItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 840);
            this.Controls.Add(this.avButtonT1);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.comboBoxPersonel);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this._tocheckRevisionListView);
            this.Controls.Add(this._fromcheckRevisionListView);
            this.Controls.Add(this.buttonOk);
            this.Name = "PelItemForm";
            this.Resizable = false;
            this.Text = "CheckList Revision Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckListRevisionForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private AvControls.AvButtonT.AvButtonT avButtonT1;

        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.ComboBox comboBoxPersonel;


        #endregion

        System.Windows.Forms.Label label3;

        private System.Windows.Forms.Button buttonOk;
        private CAS.UI.UICAAControls.Audit.PEL.PelItemListView _fromcheckRevisionListView;
        private CAS.UI.UICAAControls.Audit.PEL.AuditPelRecordListView _tocheckRevisionListView;
        private AvControls.AvButtonT.AvButtonT ButtonAdd;
        private AvControls.AvButtonT.AvButtonT ButtonDelete;
    }
}