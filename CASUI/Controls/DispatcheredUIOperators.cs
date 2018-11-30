using System;
using LTR.UI.Interfaces;
using LTR.UI.Management.Dispatchering;

namespace LTR.UI.Controls
{
    public class DispatcheredUIOperators : UIOperators, IDisplayingEntity
    {
        private ReferenceButton referenceButton1;
    
        public object ContainedData
        {
            get { return Collection; }
            set { throw new NotImplementedException(); }
        }

        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            return Collection.Equals(obj.ContainedData);
        }

        private void InitializeComponent()
        {
            this.referenceButton1 = new LTR.UI.Management.Dispatchering.ReferenceButton();
            this.SuspendLayout();
            // 
            // referenceButton1
            // 
            this.referenceButton1.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(200)))), ((int)(((byte)(40)))));
            this.referenceButton1.BackColor = System.Drawing.Color.White;
            this.referenceButton1.CurrentBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.referenceButton1.CurrentColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(223)))), ((int)(((byte)(254)))));
            this.referenceButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.referenceButton1.Displayer = null;
            this.referenceButton1.DisplayerText = null;
            this.referenceButton1.Entity = null;
            this.referenceButton1.ExtendedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.referenceButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.referenceButton1.FlatAppearance.BorderSize = 2;
            this.referenceButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.referenceButton1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.referenceButton1.Hoverable = true;
            this.referenceButton1.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.referenceButton1.Location = new System.Drawing.Point(4, 219);
            this.referenceButton1.Name = "referenceButton1";
            this.referenceButton1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(223)))), ((int)(((byte)(254)))));
            this.referenceButton1.Padding = new System.Windows.Forms.Padding(2);
            this.referenceButton1.ReflectionType = LTR.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            this.referenceButton1.Selected = false;
            this.referenceButton1.Size = new System.Drawing.Size(194, 54);
            this.referenceButton1.TabIndex = 8;
            this.referenceButton1.Text = "referenceButton1";
            this.referenceButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.referenceButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.referenceButton1.UseVisualStyleBackColor = true;
            this.referenceButton1.Click += new System.EventHandler(this.referenceButton1_Click);
            // 
            // DispatcheredUIOperators
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.Controls.Add(this.referenceButton1);
            this.Name = "DispatcheredUIOperators";
            this.Controls.SetChildIndex(this.referenceButton1, 0);
            this.ResumeLayout(false);

        }

        private void referenceButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
