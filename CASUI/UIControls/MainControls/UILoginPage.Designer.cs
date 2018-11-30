using System;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using ReferenceUILoginControl=CAS.UI.Management.Dispatchering.ReferenceUILoginControl;

namespace CAS.UI.UIControls.MainControls
{
    internal partial class UILoginPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label labelCodeName;
            System.Windows.Forms.Label labelName;
          
            
            this.panelDescription = new System.Windows.Forms.Panel();
            this.panelBottomContentContainer = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelLoginControlContainer = new System.Windows.Forms.Panel();
            this.referenceLoginControl = new ReferenceUILoginControl();
            this.pictureBoxBottomAircraft = new System.Windows.Forms.PictureBox();
            this.panelSplitterContainer = new System.Windows.Forms.Panel();
            this.panelBottomAircraftContainer = new System.Windows.Forms.Panel();
            this.pictureBoxSplitter = new System.Windows.Forms.PictureBox();
            this.pictureBoxTopAircraft = new System.Windows.Forms.PictureBox();
            this.copyrightControlWide1 = new CAS.UI.UIControls.Auxiliary.CopyrightControl();
            labelCodeName = new System.Windows.Forms.Label();
            labelName = new System.Windows.Forms.Label();

        
            
            this.panelDescription.SuspendLayout();
            this.panelBottomContentContainer.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelLoginControlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomAircraft)).BeginInit();
            this.panelSplitterContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopAircraft)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCodeName
            // 
            labelCodeName.AutoSize = true;
            labelCodeName.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            labelCodeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(117)))), ((int)(((byte)(193)))));
            labelCodeName.Location = new System.Drawing.Point(3, 0);
            labelCodeName.Name = "labelCodeName";
            labelCodeName.Size = new System.Drawing.Size(153, 78);
            labelCodeName.TabIndex = 0;
            labelCodeName.Text = "CAS";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(117)))), ((int)(((byte)(193)))));
            labelName.Location = new System.Drawing.Point(15, 78);
            labelName.Name = "labelName";
            labelName.Size = new System.Drawing.Size(175, 87);
            labelName.TabIndex = 1;
            labelName.Text = new TermsProvider()["SystemName"].ToString().Replace(" ", Environment.NewLine);
            // 
            // panelDescription
            // 
            this.panelDescription.Controls.Add(labelName);
            this.panelDescription.Controls.Add(labelCodeName);
         
            this.panelDescription.Location = new System.Drawing.Point(593, 44);
            this.panelDescription.Name = "panelDescription";
            this.panelDescription.Size = new System.Drawing.Size(241, 179);
            this.panelDescription.TabIndex = 4;
            // 
            // panelBottomContentContainer
            // 
            this.panelBottomContentContainer.BackgroundImage = global::CAS.UI.Properties.Resources.LoginPageBackground;
            this.panelBottomContentContainer.Controls.Add(this.tableLayoutPanel2);
            this.panelBottomContentContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomContentContainer.Location = new System.Drawing.Point(0, 239);
            this.panelBottomContentContainer.Name = "panelBottomContentContainer";
            this.panelBottomContentContainer.Size = new System.Drawing.Size(1021, 358);
            this.panelBottomContentContainer.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize, 0));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tableLayoutPanel2.Controls.Add(this.panelLoginControlContainer, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelBottomAircraftContainer, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelSplitterContainer, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1021, 358);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panelLoginControlContainer
            // 
            this.panelLoginControlContainer.Controls.Add(this.referenceLoginControl);
            this.panelLoginControlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoginControlContainer.Location = new System.Drawing.Point(332, 3);
            this.panelLoginControlContainer.Name = "panelLoginControlContainer";
            this.panelLoginControlContainer.Size = new System.Drawing.Size(686, 352);
            this.panelLoginControlContainer.TabIndex = 1;
            // 
            // referenceLoginControl
            // 
            this.referenceLoginControl.BackColor = System.Drawing.Color.Transparent;
            this.referenceLoginControl.Displayer = null;
            this.referenceLoginControl.DisplayerText = null;
            this.referenceLoginControl.Entity = null;
            this.referenceLoginControl.Location = new System.Drawing.Point(0, 35);
            this.referenceLoginControl.Name = "referenceLoginControl";
            this.referenceLoginControl.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
            this.referenceLoginControl.Size = new System.Drawing.Size(434, 317);
            this.referenceLoginControl.TabIndex = 0;
            this.referenceLoginControl.Connected += dispatcheredLoginControl_Connected;
            this.referenceLoginControl.ExitClicked += dispatcheredLoginControl_ExitClicked;
            // 
            // pictureBoxBottomAircraft
            // 
            this.pictureBoxBottomAircraft.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxBottomAircraft.Image = global::CAS.UI.Properties.Resources.LoginPageBottomAircraft;
            this.pictureBoxBottomAircraft.Location = new System.Drawing.Point(99, 3);
            this.pictureBoxBottomAircraft.Name = "pictureBoxBottomAircraft";
            this.pictureBoxBottomAircraft.Size = new System.Drawing.Size(167, 352);
            this.pictureBoxBottomAircraft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxBottomAircraft.TabIndex = 3;
            this.pictureBoxBottomAircraft.TabStop = false;
            // 
            // panelBottomAircraftContainer
            // 
            this.panelBottomAircraftContainer.Controls.Add(this.pictureBoxBottomAircraft);
            this.panelBottomAircraftContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomAircraftContainer.Location = new System.Drawing.Point(272, 3);
            this.panelBottomAircraftContainer.Name = "panelSplitterContainer";
            this.panelBottomAircraftContainer.TabIndex = 4;
            // 
            // panelSplitterContainer
            // 
            this.panelSplitterContainer.Controls.Add(this.pictureBoxSplitter);
            this.panelSplitterContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSplitterContainer.Location = new System.Drawing.Point(272, 3);
            this.panelSplitterContainer.Name = "panelSplitterContainer";
            this.panelSplitterContainer.Size = new System.Drawing.Size(54, 352);
            this.panelSplitterContainer.TabIndex = 4;
            // 
            // pictureBoxSplitter
            // 
            this.pictureBoxSplitter.BackColor = System.Drawing.Color.White;
            this.pictureBoxSplitter.Location = new System.Drawing.Point(28, 84);
            this.pictureBoxSplitter.Name = "pictureBoxSplitter";
            this.pictureBoxSplitter.Size = new System.Drawing.Size(2, 186);
            this.pictureBoxSplitter.TabIndex = 0;
            this.pictureBoxSplitter.TabStop = false;
            // 
            // pictureBoxTopAircraft
            // 
            this.pictureBoxTopAircraft.Image = global::CAS.UI.Properties.Resources.LoginPageTopAircraft;
            this.pictureBoxTopAircraft.Location = new System.Drawing.Point(205, 0);
            this.pictureBoxTopAircraft.Name = "pictureBoxTopAircraft";
            this.pictureBoxTopAircraft.Size = new System.Drawing.Size(341, 368);
            this.pictureBoxTopAircraft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxTopAircraft.TabIndex = 3;
            this.pictureBoxTopAircraft.TabStop = false;
            // 
            // copyrightControlWide1
            // 
            this.copyrightControlWide1.BackColor = System.Drawing.Color.Transparent;
            this.copyrightControlWide1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.copyrightControlWide1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(93)))), ((int)(((byte)(152)))));
            this.copyrightControlWide1.Location = new System.Drawing.Point(0, 597);
            this.copyrightControlWide1.Name = "copyrightControlWide1";
            this.copyrightControlWide1.Size = new System.Drawing.Size(1021, 40);
            this.copyrightControlWide1.TabIndex = 5;
            // 
            // UILoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelDescription);
            this.Controls.Add(this.panelBottomContentContainer);
            this.Controls.Add(this.pictureBoxTopAircraft);
            this.Controls.Add(this.copyrightControlWide1);
            this.Name = "UILoginPage";
            this.Size = new System.Drawing.Size(1021, 637);
            this.panelDescription.ResumeLayout(false);
            this.panelDescription.PerformLayout();
            this.panelBottomContentContainer.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panelLoginControlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomAircraft)).EndInit();
            this.panelSplitterContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopAircraft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panelBottomContentContainer;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panelLoginControlContainer;
        private ReferenceUILoginControl referenceLoginControl;
        private PictureBox pictureBoxTopAircraft;
        private Panel panelDescription;
        private PictureBox pictureBoxBottomAircraft;
        private Panel panelBottomAircraftContainer;
        private Panel panelSplitterContainer;
        private PictureBox pictureBoxSplitter;
        private Auxiliary.CopyrightControl copyrightControlWide1;
    }
}