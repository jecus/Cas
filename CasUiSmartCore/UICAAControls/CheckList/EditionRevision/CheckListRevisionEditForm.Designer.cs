
using CAS.UI.UIControls.NewGrid;

namespace CAS.UI.UICAAControls.CheckList
{
    partial class CheckListRevisionEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckListRevisionEditForm));
            this.buttonOk = new System.Windows.Forms.Button();
            this._fromcheckListView = new CAS.UI.UICAAControls.CheckList.CheckListView();
            this._tocheckListView = new CAS.UI.UICAAControls.CheckList.CheckListView();
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
            this.buttonOk.Location = new System.Drawing.Point(1440, 758);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 33);
            this.buttonOk.TabIndex = 328;
            this.buttonOk.Text = "OK";
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
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
            this._fromcheckListView.Size = new System.Drawing.Size(1510, 306);
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
            this._tocheckListView.Size = new System.Drawing.Size(1510, 346);
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
            this.ButtonAdd.Location = new System.Drawing.Point(1399, 366);
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
            this.ButtonDelete.Location = new System.Drawing.Point(1311, 757);
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
            // CheckListRevisionEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1518, 803);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this._tocheckListView);
            this.Controls.Add(this._fromcheckListView);
            this.Controls.Add(this.buttonOk);
            this.Name = "CheckListRevisionEditForm";
            this.Resizable = false;
            this.Text = "CheckList Revision Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckListRevisionForm_FormClosing);
            this.ResumeLayout(false);
        }

        #endregion

        System.Windows.Forms.Label label3;

        private System.Windows.Forms.Button buttonOk;
        private CAS.UI.UICAAControls.CheckList.CheckListView _fromcheckListView;
        private CAS.UI.UICAAControls.CheckList.CheckListView _tocheckListView;
        private AvControls.AvButtonT.AvButtonT ButtonAdd;
        private AvControls.AvButtonT.AvButtonT ButtonDelete;
    }
}