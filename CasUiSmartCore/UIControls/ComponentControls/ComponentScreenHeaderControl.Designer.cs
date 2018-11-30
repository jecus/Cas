using AvControls.StatusImageLink;

namespace CAS.UI.UIControls.ComponentControls
{
    partial class ComponentScreenHeaderControl
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
            this.labelDateAsOf = new System.Windows.Forms.Label();
            this.labelDateAsOfValue = new System.Windows.Forms.Label();
            this.imageLinkLabelComponentStatus = new StatusImageLinkLabel();
            this.labelAircraftCurrentTCSN = new System.Windows.Forms.Label();
            this.labelAircraftTCSNValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDateAsOf
            // 
            this.labelDateAsOf.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDateAsOf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDateAsOf.Location = new System.Drawing.Point(271, 3);
            this.labelDateAsOf.Name = "labelDateAsOf";
            this.labelDateAsOf.Size = new System.Drawing.Size(120, 30);
            this.labelDateAsOf.TabIndex = 2;
            this.labelDateAsOf.Text = "Date As Of:";
            this.labelDateAsOf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDateAsOfValue
            // 
            this.labelDateAsOfValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelDateAsOfValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelDateAsOfValue.Location = new System.Drawing.Point(397, 3);
            this.labelDateAsOfValue.Name = "labelDateAsOfValue";
            this.labelDateAsOfValue.Size = new System.Drawing.Size(150, 30);
            this.labelDateAsOfValue.TabIndex = 3;
            this.labelDateAsOfValue.Text = "DateAsOfValue";
            this.labelDateAsOfValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageLinkLabelComponentStatus
            // 
            this.imageLinkLabelComponentStatus.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.imageLinkLabelComponentStatus.Enabled = false;
            this.imageLinkLabelComponentStatus.ForeColor = System.Drawing.Color.DimGray;
            this.imageLinkLabelComponentStatus.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
            this.imageLinkLabelComponentStatus.ImageBackColor = System.Drawing.Color.Transparent;
            this.imageLinkLabelComponentStatus.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.imageLinkLabelComponentStatus.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.imageLinkLabelComponentStatus.LinkMouseCapturedColor = System.Drawing.Color.Empty;
            this.imageLinkLabelComponentStatus.Location = new System.Drawing.Point(3, 4);
            this.imageLinkLabelComponentStatus.Name = "imageLinkLabelComponentStatus";
            this.imageLinkLabelComponentStatus.Size = new System.Drawing.Size(250, 25);
            this.imageLinkLabelComponentStatus.TabIndex = 87;
            this.imageLinkLabelComponentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.imageLinkLabelComponentStatus.TextFont = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            // 
            // labelAircraftCurrentTCSN
            // 
            this.labelAircraftCurrentTCSN.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAircraftCurrentTCSN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAircraftCurrentTCSN.Location = new System.Drawing.Point(572, 3);
            this.labelAircraftCurrentTCSN.Name = "labelAircraftCurrentTCSN";
            this.labelAircraftCurrentTCSN.Size = new System.Drawing.Size(158, 30);
            this.labelAircraftCurrentTCSN.TabIndex = 88;
            this.labelAircraftCurrentTCSN.Text = "Aircraft TSN/CSN:";
            this.labelAircraftCurrentTCSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAircraftTCSNValue
            // 
            this.labelAircraftTCSNValue.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelAircraftTCSNValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAircraftTCSNValue.Location = new System.Drawing.Point(736, 3);
            this.labelAircraftTCSNValue.Name = "labelAircraftTCSNValue";
            this.labelAircraftTCSNValue.Size = new System.Drawing.Size(412, 30);
            this.labelAircraftTCSNValue.TabIndex = 89;
            this.labelAircraftTCSNValue.Text = "AircraftTCSNValue";
            this.labelAircraftTCSNValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DetailScreenHeaderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.labelAircraftCurrentTCSN);
            this.Controls.Add(this.labelAircraftTCSNValue);
            this.Controls.Add(this.imageLinkLabelComponentStatus);
            this.Controls.Add(this.labelDateAsOf);
            this.Controls.Add(this.labelDateAsOfValue);
            this.Name = "ComponentScreenHeaderControl";
            this.Size = new System.Drawing.Size(1165, 33);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelDateAsOf;
        private System.Windows.Forms.Label labelDateAsOfValue;
        private StatusImageLinkLabel imageLinkLabelComponentStatus;
        private System.Windows.Forms.Label labelAircraftCurrentTCSN;
        private System.Windows.Forms.Label labelAircraftTCSNValue;
    }
}
