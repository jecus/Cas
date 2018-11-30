using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Controls.AvButtonT;
using LTR.Core;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.Core.Types.Dictionaries;
using LTR.UI.Appearance;

namespace LTR.UI.UIControls.LogBookControls
{
    public partial class AircraftsLogBookControl : UserControl
    {
        #region Constructor
        /// <summary>
        /// Создает элемент управления для отображения журнала
        /// </summary>
        public AircraftsLogBookControl(Aircraft aircraft)
        {
            currentAircraft = aircraft;
            Initialize();

            foreach (BaseDetail bd in currentAircraft.BaseDetails)
            {
                listBox1.Items.Add(bd.DateOfAdding.ToString()+"  "+ currentAircraft.BaseDetails[0].RepresentingDetailID);
            }
        }
        #endregion

        #region Methods
        private void Initialize()
        {
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.label1 = new Label();
            this.label2 = new Label();

            this.listBox1 = new ListBox();
            avbutton = new AvButtonT();

            this.linkLabel1 = new LinkLabel();
            this.linkLabel2 = new LinkLabel();
            this.label3 = new Label();
            this.buttonApply = new Button();
            this.dateTimePicker1 = new DateTimePicker();
            this.dateTimePicker2 = new DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(
                new ColumnStyle(SizeType.AutoSize, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(
                new ColumnStyle(SizeType.AutoSize, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(
                new ColumnStyle(SizeType.AutoSize, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(
                new ColumnStyle(SizeType.AutoSize, 159F));
            this.tableLayoutPanel1.ColumnStyles.Add(
                new ColumnStyle(SizeType.AutoSize, 149F));
            this.tableLayoutPanel1.ColumnStyles.Add(
                new ColumnStyle(SizeType.AutoSize, 122F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.linkLabel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.linkLabel2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonApply, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker2, 4, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            this.tableLayoutPanel1.Location = new Point(24, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(
                new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(
                new RowStyle(SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new Size(599, 66);
            this.tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            //
            // avbutton
            //
            avbutton.AutoSize = true;
            avbutton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            avbutton.BorderStyle = BorderStyle.FixedSingle;
            avbutton.Dock = DockStyle.Top;
            avbutton.Location = new Point(100,100);
            avbutton.Name = "avbutton";
            avbutton.TextMain = "testButton";
            avbutton.TextSecondary = "text";
            // 
            // listBox1
            // 
            listBox1.BackColor = Css.CommonAppearance.Colors.BackColor;
            listBox1.BorderStyle = BorderStyle.None;
            listBox1.Dock = DockStyle.Top;
            listBox1.Font = Css.OrdinaryText.Fonts.RegularFont;
            listBox1.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 100);
            listBox1.Name = "listBox1";
            listBox1.Padding = new Padding(0, 15, 0, 0);
            listBox1.Size = new Size(398, 147);
            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            label1.ForeColor = Css.SmallHeader.Colors.ForeColor;
            label1.Font = Css.SmallHeader.Fonts.RegularFont;
            this.label1.Location = new Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Interval";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            label2.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            label2.Font = Css.OrdinaryText.Fonts.RegularFont;
            this.label2.Location = new Point(78, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start date:";
            // 
            // linkLabel1
            // 
            Css.SimpleLink.Adjust(linkLabel1);
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new Point(78, 33);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new Size(73, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Current month";

            // 
            // linkLabel2
            // 
            Css.SimpleLink.Adjust(linkLabel2);
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new Point(159, 33);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new Size(121, 13);
            this.linkLabel2.TabIndex = 4;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Since last known record";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            label3.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            label3.Font = Css.OrdinaryText.Fonts.RegularFont;
            this.label3.Location = new Point(309, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "End date:";
            // 
            // buttonApply
            // 
            buttonApply.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            buttonApply.Font = Css.OrdinaryText.Fonts.RegularFont;
            this.buttonApply.Location = new Point(517, 3);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new Size(100, 25);
            this.buttonApply.TabIndex = 7;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new Point(159, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new Size(144, 20);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new Point(368, 3);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new Size(143, 20);
            this.dateTimePicker2.TabIndex = 9;
            // 
            // AircraftsLogBookControl
            // 
            this.AutoSize = true;
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(listBox1);
            Controls.Add(this.tableLayoutPanel1);
            Controls.Add(avbutton);


            this.Dock = DockStyle.Top;
            this.Name = "AircraftsLogBookControl";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion


        #region Fields
        private Aircraft currentAircraft;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.ListBox listBox1;

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private AvButtonT avbutton;
        #endregion

    }
}
