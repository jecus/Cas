namespace CAS.UI
{
    partial class FindForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
           
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label Loca;
            System.Windows.Forms.Label label1;
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelSize = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            this.labelClass = new System.Windows.Forms.Label();
            this.pictureBoxShowControl = new System.Windows.Forms.PictureBox();
            this.treeViewControl = new System.Windows.Forms.TreeView();
            this.timerRefr = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxUpdate = new System.Windows.Forms.CheckBox();
            this.checkBoxZoom = new System.Windows.Forms.CheckBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            Loca = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowControl)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            groupBox1.Controls.Add(this.textBoxName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(this.labelSize);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(this.labelLocation);
            groupBox1.Controls.Add(Loca);
            groupBox1.Controls.Add(this.labelClass);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(12, 445);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(200, 105);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(50, 77);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(144, 20);
            this.textBoxName.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 80);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(38, 13);
            label2.TabIndex = 6;
            label2.Text = "Name:";
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSize.Location = new System.Drawing.Point(42, 58);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(11, 13);
            this.labelSize.TabIndex = 5;
            this.labelSize.Text = ".";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 58);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(30, 13);
            label3.TabIndex = 4;
            label3.Text = "Size:";
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLocation.Location = new System.Drawing.Point(63, 37);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(11, 13);
            this.labelLocation.TabIndex = 3;
            this.labelLocation.Text = ".";
            // 
            // Loca
            // 
            Loca.AutoSize = true;
            Loca.Location = new System.Drawing.Point(6, 37);
            Loca.Name = "Loca";
            Loca.Size = new System.Drawing.Size(51, 13);
            Loca.TabIndex = 2;
            Loca.Text = "Location:";
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelClass.Location = new System.Drawing.Point(42, 16);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(11, 13);
            this.labelClass.TabIndex = 1;
            this.labelClass.Text = ".";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(35, 13);
            label1.TabIndex = 0;
            label1.Text = "Class:";
            // 
            // pictureBoxShowControl
            // 
            this.pictureBoxShowControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxShowControl.Location = new System.Drawing.Point(12, 285);
            this.pictureBoxShowControl.Name = "pictureBoxShowControl";
            this.pictureBoxShowControl.Size = new System.Drawing.Size(201, 161);
            this.pictureBoxShowControl.TabIndex = 1;
            this.pictureBoxShowControl.TabStop = false;
            // 
            // treeViewControl
            // 
            this.treeViewControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewControl.Location = new System.Drawing.Point(12, 27);
            this.treeViewControl.Name = "treeViewControl";
            this.treeViewControl.Size = new System.Drawing.Size(201, 241);
            this.treeViewControl.TabIndex = 2;
            this.treeViewControl.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewControlAfterSelect);
            // 
            // timerRefr
            // 
            this.timerRefr.Enabled = true;
            this.timerRefr.Tick += new System.EventHandler(this.TimerRefrTick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // checkBoxUpdate
            // 
            this.checkBoxUpdate.AutoSize = true;
            this.checkBoxUpdate.Location = new System.Drawing.Point(78, 4);
            this.checkBoxUpdate.Name = "checkBoxUpdate";
            this.checkBoxUpdate.Size = new System.Drawing.Size(94, 17);
            this.checkBoxUpdate.TabIndex = 5;
            this.checkBoxUpdate.Text = "update screen";
            this.checkBoxUpdate.UseVisualStyleBackColor = true;
            // 
            // checkBoxZoom
            // 
            this.checkBoxZoom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxZoom.AutoSize = true;
            this.checkBoxZoom.Location = new System.Drawing.Point(87, 268);
            this.checkBoxZoom.Name = "checkBoxZoom";
            this.checkBoxZoom.Size = new System.Drawing.Size(51, 17);
            this.checkBoxZoom.TabIndex = 6;
            this.checkBoxZoom.Text = "zoom";
            this.checkBoxZoom.UseVisualStyleBackColor = true;
            this.checkBoxZoom.CheckedChanged += new System.EventHandler(this.CheckBoxZoomCheckedChanged);
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 562);
            this.Controls.Add(this.checkBoxZoom);
            this.Controls.Add(this.checkBoxUpdate);
            this.Controls.Add(this.button1);
            this.Controls.Add(groupBox1);
            this.Controls.Add(this.treeViewControl);
            this.Controls.Add(this.pictureBoxShowControl);
            this.Name = "FindForm";
            this.Text = "FindForm";
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Load += new System.EventHandler(this.FindFormLoad);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShowControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxShowControl;
        private System.Windows.Forms.TreeView treeViewControl;
        private System.Windows.Forms.Label labelClass;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.Timer timerRefr;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.CheckBox checkBoxUpdate;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.CheckBox checkBoxZoom;
    }
}

