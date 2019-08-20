using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Entities.General.Templates;


namespace CAS.UI.UIControls.TemplatesControls.Forms
{
    partial class TemplateAircraftAddToDataBaseForm
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
			this.labelTemplate = new System.Windows.Forms.Label();
			this.comboBoxTemplates = new System.Windows.Forms.ComboBox();
			this.buttonCreateAircraft = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.splitContainerMain = new System.Windows.Forms.SplitContainer();
			this.treeViewTemplate = new System.Windows.Forms.TreeView();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelTemplate
			// 
			this.labelTemplate.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.labelTemplate.Location = new System.Drawing.Point(12, 65);
			this.labelTemplate.Name = "labelTemplate";
			this.labelTemplate.Size = new System.Drawing.Size(100, 23);
			this.labelTemplate.TabIndex = 3;
			this.labelTemplate.Text = "Template";
			this.labelTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxTemplates
			// 
			this.comboBoxTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTemplates.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxTemplates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.comboBoxTemplates.Location = new System.Drawing.Point(117, 63);
			this.comboBoxTemplates.Name = "comboBoxTemplates";
			this.comboBoxTemplates.Size = new System.Drawing.Size(379, 25);
			this.comboBoxTemplates.TabIndex = 1;
			this.comboBoxTemplates.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTemplatesSelectedIndexChanged);
			// 
			// buttonCreateAircraft
			// 
			this.buttonCreateAircraft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCreateAircraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCreateAircraft.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCreateAircraft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCreateAircraft.Location = new System.Drawing.Point(838, 686);
			this.buttonCreateAircraft.Name = "buttonCreateAircraft";
			this.buttonCreateAircraft.Size = new System.Drawing.Size(75, 33);
			this.buttonCreateAircraft.TabIndex = 12;
			this.buttonCreateAircraft.Text = "Create Aircraft";
			this.buttonCreateAircraft.Click += new System.EventHandler(this.ButtonCreateAircraftClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.buttonCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.buttonCancel.Location = new System.Drawing.Point(919, 686);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 33);
			this.buttonCancel.TabIndex = 13;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// splitContainerMain
			// 
			this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainerMain.Location = new System.Drawing.Point(15, 95);
			this.splitContainerMain.Name = "splitContainerMain";
			// 
			// splitContainerMain.Panel1
			// 
			this.splitContainerMain.Panel1.Controls.Add(this.treeViewTemplate);
			// 
			// splitContainerMain.Panel2
			// 
			this.splitContainerMain.Panel2.AutoScroll = true;
			this.splitContainerMain.Size = new System.Drawing.Size(979, 585);
			this.splitContainerMain.SplitterDistance = 480;
			this.splitContainerMain.TabIndex = 14;
			// 
			// treeViewTemplate
			// 
			this.treeViewTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewTemplate.Location = new System.Drawing.Point(0, 0);
			this.treeViewTemplate.Name = "treeViewTemplate";
			this.treeViewTemplate.Size = new System.Drawing.Size(480, 585);
			this.treeViewTemplate.TabIndex = 0;
			this.treeViewTemplate.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeViewTemplateBeforeSelect);
			this.treeViewTemplate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewTemplateAfterSelect);
			// 
			// TemplateAircraftAddToDataBaseForm
			// 
			this.AcceptButton = this.buttonCreateAircraft;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(1006, 723);
			this.Controls.Add(this.splitContainerMain);
			this.Controls.Add(this.labelTemplate);
			this.Controls.Add(this.comboBoxTemplates);
			this.Controls.Add(this.buttonCreateAircraft);
			this.Controls.Add(this.buttonCancel);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(860, 640);
			this.Name = "TemplateAircraftAddToDataBaseForm";
			this.ShowIcon = false;
			this.Text = "CAS. Add template Aircraft to operator";
			this.Activated += new System.EventHandler(this.TemplateAircraftAddToDataBaseForm_Activated);
			this.Deactivate += new System.EventHandler(this.TemplateAircraftAddToDataBaseForm_Deactivate);
			this.splitContainerMain.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
			this.splitContainerMain.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainerMain;
        private TreeView treeViewTemplate;
        private Label labelTemplate;
        private ComboBox comboBoxTemplates;
        private Button buttonCreateAircraft;
        private Button buttonCancel;
    }
}