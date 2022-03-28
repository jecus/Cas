using System.Windows.Forms;
using CAS.UI.UIControls.NewGrid;
using SmartCore.CAA.FindingLevel;

namespace CAS.UI.UICAAControls.CheckList.CheckListAudit
{
    partial class CheckListAuditRootCaseForm
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.ButtonDelete = new AvControls.AvButtonT.AvButtonT();
            this.ButtonAdd = new AvControls.AvButtonT.AvButtonT();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.ButtonWf = new AvControls.AvButtonT.AvButtonT();
            this.avButtonWfTracking = new AvControls.AvButtonT.AvButtonT();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            metroLabel1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            labelSourceText = new System.Windows.Forms.Label();
            labelEditorText = new System.Windows.Forms.Label();
            labelRevisionText = new System.Windows.Forms.Label();
            labelLevelText = new System.Windows.Forms.Label();
            _from = new BaseGridViewControl<RootCause>();
            _to = new BaseGridViewControl<RootCause>();
            
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
            this.ButtonDelete.Location = new System.Drawing.Point(997, 746);
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
            this.ButtonAdd.Location = new System.Drawing.Point(1003, 409);
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
            // _fromroutineAuditListView
            // 
            this._from.Location = new System.Drawing.Point(23, 110);
            this._from.Name = "_from";
            this._from.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this._from.Size = new System.Drawing.Size(1091, 295);
            this._from.TabIndex = 341;
            
            // 
            // _toroutineAuditListView
            // 
            this._to.Location = new System.Drawing.Point(23, 444);
            this._to.Name = "_to";
            this._to.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this._to.Size = new System.Drawing.Size(1091, 295);
            this._to.TabIndex = 344;
            
            
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            metroLabel1.AutoSize = true;
            metroLabel1.Font = new System.Drawing.Font("Verdana", 9F);
            metroLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            metroLabel1.Location = new System.Drawing.Point(5, 65);
            metroLabel1.Name = "metroLabel1";
            metroLabel1.Size = new System.Drawing.Size(55, 14);
            metroLabel1.TabIndex = 16;
            metroLabel1.Text = "Source:";
            metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Verdana", 9F);
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label2.Location = new System.Drawing.Point(5, 90);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(49, 14);
            label2.TabIndex = 324;
            label2.Text = "Editor:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Verdana", 9F);
            label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label3.Location = new System.Drawing.Point(117, 90);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(64, 14);
            label3.TabIndex = 326;
            label3.Text = "Revision:";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Verdana", 9F);
            label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            label4.Location = new System.Drawing.Point(264, 90);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(45, 14);
            label4.TabIndex = 331;
            label4.Text = "Level:";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelSourceText
            // 
            labelSourceText.AutoSize = true;
            labelSourceText.Font = new System.Drawing.Font("Verdana", 9F);
            labelSourceText.ForeColor = System.Drawing.Color.Black;
            labelSourceText.Location = new System.Drawing.Point(63, 65);
            labelSourceText.Name = "labelSourceText";
            labelSourceText.Size = new System.Drawing.Size(50, 14);
            labelSourceText.TabIndex = 323;
            labelSourceText.Text = "Source";
            labelSourceText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelEditorText
            // 
            labelEditorText.AutoSize = true;
            labelEditorText.Font = new System.Drawing.Font("Verdana", 9F);
            labelEditorText.ForeColor = System.Drawing.Color.Black;
            labelEditorText.Location = new System.Drawing.Point(63, 90);
            labelEditorText.Name = "labelEditorText";
            labelEditorText.Size = new System.Drawing.Size(44, 14);
            labelEditorText.TabIndex = 325;
            labelEditorText.Text = "Editor";
            labelEditorText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRevisionText
            // 
            labelRevisionText.AutoSize = true;
            labelRevisionText.Font = new System.Drawing.Font("Verdana", 9F);
            labelRevisionText.ForeColor = System.Drawing.Color.Black;
            labelRevisionText.Location = new System.Drawing.Point(185, 90);
            labelRevisionText.Name = "labelRevisionText";
            labelRevisionText.Size = new System.Drawing.Size(59, 14);
            labelRevisionText.TabIndex = 327;
            labelRevisionText.Text = "Revision";
            labelRevisionText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelLevelText
            // 
            labelLevelText.AutoSize = true;
            labelLevelText.Font = new System.Drawing.Font("Verdana", 9F);
            labelLevelText.ForeColor = System.Drawing.Color.Black;
            labelLevelText.Location = new System.Drawing.Point(315, 90);
            labelLevelText.Name = "labelLevelText";
            labelLevelText.Size = new System.Drawing.Size(40, 14);
            labelLevelText.TabIndex = 332;
            labelLevelText.Text = "Level";
            labelLevelText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonOk.Location = new System.Drawing.Point(1158, 781);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 33);
            this.buttonOk.TabIndex = 299;
            this.buttonOk.Text = "OK";
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.buttonCancel.Location = new System.Drawing.Point(1239, 781);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 33);
            this.buttonCancel.TabIndex = 298;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ButtonWf
            // 
            this.ButtonWf.ActiveBackColor = System.Drawing.Color.Transparent;
            this.ButtonWf.ActiveBackgroundImage = null;
            this.ButtonWf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonWf.FontMain = new System.Drawing.Font("Verdana", 8F);
            this.ButtonWf.FontSecondary = new System.Drawing.Font("Verdana", 8F);
            this.ButtonWf.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.ButtonWf.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.ButtonWf.Icon = global::CAS.UI.Properties.Resources.GreenArrow;
            this.ButtonWf.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.ButtonWf.IconNotEnabled = null;
            this.ButtonWf.Location = new System.Drawing.Point(1120, 126);
            this.ButtonWf.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonWf.Name = "ButtonWf";
            this.ButtonWf.NormalBackgroundImage = null;
            this.ButtonWf.PaddingMain = new System.Windows.Forms.Padding(0);
            this.ButtonWf.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.ButtonWf.ShowToolTip = false;
            this.ButtonWf.Size = new System.Drawing.Size(169, 33);
            this.ButtonWf.TabIndex = 365;
            this.ButtonWf.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonWf.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonWf.TextMain = "Workflow Comments";
            this.ButtonWf.TextSecondary = "";
            this.ButtonWf.ToolTipText = "";
            this.ButtonWf.Click += new System.EventHandler(this.ButtonWf_Click);
            // 
            // avButtonWfTracking
            // 
            this.avButtonWfTracking.ActiveBackColor = System.Drawing.Color.Transparent;
            this.avButtonWfTracking.ActiveBackgroundImage = null;
            this.avButtonWfTracking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avButtonWfTracking.FontMain = new System.Drawing.Font("Verdana", 8F);
            this.avButtonWfTracking.FontSecondary = new System.Drawing.Font("Verdana", 8F);
            this.avButtonWfTracking.ForeColorMain = System.Drawing.SystemColors.ControlText;
            this.avButtonWfTracking.ForeColorSecondary = System.Drawing.SystemColors.ControlText;
            this.avButtonWfTracking.Icon = global::CAS.UI.Properties.Resources.RedArrow;
            this.avButtonWfTracking.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.avButtonWfTracking.IconNotEnabled = null;
            this.avButtonWfTracking.Location = new System.Drawing.Point(1120, 167);
            this.avButtonWfTracking.Margin = new System.Windows.Forms.Padding(4);
            this.avButtonWfTracking.Name = "avButtonWfTracking";
            this.avButtonWfTracking.NormalBackgroundImage = null;
            this.avButtonWfTracking.PaddingMain = new System.Windows.Forms.Padding(0);
            this.avButtonWfTracking.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.avButtonWfTracking.ShowToolTip = false;
            this.avButtonWfTracking.Size = new System.Drawing.Size(297, 33);
            this.avButtonWfTracking.TabIndex = 366;
            this.avButtonWfTracking.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.avButtonWfTracking.TextAlignSecondary = System.Drawing.ContentAlignment.MiddleLeft;
            this.avButtonWfTracking.TextMain = "WorkflowTracking";
            this.avButtonWfTracking.TextSecondary = "";
            this.avButtonWfTracking.ToolTipText = "";
            this.avButtonWfTracking.Click += new System.EventHandler(this.avButtonWfTracking_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.button1.Location = new System.Drawing.Point(946, 781);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 33);
            this.button1.TabIndex = 367;
            this.button1.Text = "Accept";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.button2.Location = new System.Drawing.Point(1052, 781);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 33);
            this.button2.TabIndex = 368;
            this.button2.Text = "Reject";
            // 
            // CheckListAuditRootCaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 819);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.avButtonWfTracking);
            this.Controls.Add(this.ButtonWf);
            this.Controls.Add(labelLevelText);
            this.Controls.Add(label4);
            this.Controls.Add(labelRevisionText);
            this.Controls.Add(label3);
            this.Controls.Add(labelEditorText);
            this.Controls.Add(label2);
            this.Controls.Add(labelSourceText);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(metroLabel1);
            this.Controls.Add(_from);
            this.Controls.Add(_to);
            this.Controls.Add(ButtonDelete);
            this.Controls.Add(ButtonAdd);
            this.MaximizeBox = false;
            this.Name = "CheckListAuditRootCaseForm";
            this.Resizable = false;
            this.Text = "Roote Cause Analysis";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Button button1;

        private AvControls.AvButtonT.AvButtonT avButtonWfTracking;

        private AvControls.AvButtonT.AvButtonT ButtonWf;

        #endregion
        
        System.Windows.Forms.Label labelSourceText;
        System.Windows.Forms.Label labelEditorText;
        System.Windows.Forms.Label labelRevisionText;
        System.Windows.Forms.Label labelLevelText;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private BaseGridViewControl<RootCause> _from;
        private BaseGridViewControl<RootCause> _to;
        private AvControls.AvButtonT.AvButtonT ButtonDelete;
        private AvControls.AvButtonT.AvButtonT ButtonAdd;
    }
}