
using CAS.UI.UIControls.NewGrid;

namespace CAS.UI.UICAAControls.CheckList
{
    partial class CheckListEditionRevisionEditForm
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this._fromcheckRevisionListView = new CAS.UI.UICAAControls.CheckList.CheckListRevisionView();
            this._tocheckRevisionListView = new CAS.UI.UICAAControls.CheckList.CheckListRevisionView();
            this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
            this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
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
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonCancel.Location = new System.Drawing.Point(1369, 796);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 33);
            this.buttonCancel.TabIndex = 327;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // _fromcheckRevisionListView
            // 
            this._fromcheckRevisionListView.Location = new System.Drawing.Point(5, 53);
            this._fromcheckRevisionListView.Name = "_fromcheckRevisionListView";
            this._fromcheckRevisionListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this._fromcheckRevisionListView.Size = new System.Drawing.Size(1419, 306);
            this._fromcheckRevisionListView.TabIndex = 329;
            this._fromcheckRevisionListView.Visible = true;
            // 
            // _tocheckRevisionListView
            // 

            this._tocheckRevisionListView.Location = new System.Drawing.Point(5, 406);
            this._tocheckRevisionListView.Name = "_tocheckRevisionListView";
            this._tocheckRevisionListView.OldColumnIndex = 0;
            this._tocheckRevisionListView.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this._tocheckRevisionListView.Size = new System.Drawing.Size(1419, 346);
            this._tocheckRevisionListView.TabIndex = 330;
            this._tocheckRevisionListView.Visible = true;
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
            this.ButtonAdd.Location = new System.Drawing.Point(1308, 366);
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
            // CheckListEditionRevisionEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 840);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this._tocheckRevisionListView);
            this.Controls.Add(this._fromcheckRevisionListView);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Name = "CheckListEditionRevisionEditForm";
            this.Resizable = false;
            this.Text = "CheckList Revision Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckListRevisionForm_FormClosing);
            this.ResumeLayout(false);
        }

        #endregion

        System.Windows.Forms.Label label3;

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private CAS.UI.UICAAControls.CheckList.CheckListRevisionView _fromcheckRevisionListView;
        private CAS.UI.UICAAControls.CheckList.CheckListRevisionView _tocheckRevisionListView;
        private AvControls.AvButtonT.AvButtonT ButtonAdd;
        private AvControls.AvButtonT.AvButtonT ButtonDelete;
    }
}