using System.Windows.Forms;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    partial class InteriorConfigurationControl
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSeatingEconomy = new System.Windows.Forms.Label();
            this.labelGalleys = new System.Windows.Forms.Label();
            this.labelLavatory = new System.Windows.Forms.Label();
            this.labelCockpitSeating = new System.Windows.Forms.Label();
            this.textBoxGalleys = new System.Windows.Forms.TextBox();
            this.textBoxLavatory = new System.Windows.Forms.TextBox();
            this.textBoxCockpitSeating = new System.Windows.Forms.TextBox();
            this.labelOven = new System.Windows.Forms.Label();
            this.labelBoiler = new System.Windows.Forms.Label();
            this.labelAirStairDoors = new System.Windows.Forms.Label();
            this.textBoxOven = new System.Windows.Forms.TextBox();
            this.textBoxBoiler = new System.Windows.Forms.TextBox();
            this.textBoxAirStairDoors = new System.Windows.Forms.TextBox();
            this.numericUpDownSeatingEconomy = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSeatingBusiness = new System.Windows.Forms.NumericUpDown();
            this.labelSeatingBusiness = new System.Windows.Forms.Label();
            this.numericUpDownSeatingFirst = new System.Windows.Forms.NumericUpDown();
            this.labelSeatingFirst = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeatingEconomy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeatingBusiness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeatingFirst)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSeatingEconomy
            // 
            this.labelSeatingEconomy.AutoSize = true;
            this.labelSeatingEconomy.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelSeatingEconomy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelSeatingEconomy.Location = new System.Drawing.Point(10, 114);
            this.labelSeatingEconomy.Name = "labelSeatingEconomy";
            this.labelSeatingEconomy.Size = new System.Drawing.Size(130, 17);
            this.labelSeatingEconomy.TabIndex = 3;
            this.labelSeatingEconomy.Text = "Seating Economy";
            this.labelSeatingEconomy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelGalleys
            // 
            this.labelGalleys.AutoSize = true;
            this.labelGalleys.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelGalleys.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelGalleys.Location = new System.Drawing.Point(10, 42);
            this.labelGalleys.Name = "labelGalleys";
            this.labelGalleys.Size = new System.Drawing.Size(57, 17);
            this.labelGalleys.TabIndex = 1;
            this.labelGalleys.Text = "Galleys";
            this.labelGalleys.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLavatory
            // 
            this.labelLavatory.AutoSize = true;
            this.labelLavatory.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelLavatory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelLavatory.Location = new System.Drawing.Point(10, 78);
            this.labelLavatory.Name = "labelLavatory";
            this.labelLavatory.Size = new System.Drawing.Size(69, 17);
            this.labelLavatory.TabIndex = 2;
            this.labelLavatory.Text = "Lavatory";
            this.labelLavatory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCockpitSeating
            // 
            this.labelCockpitSeating.AutoSize = true;
            this.labelCockpitSeating.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelCockpitSeating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelCockpitSeating.Location = new System.Drawing.Point(10, 6);
            this.labelCockpitSeating.Name = "labelCockpitSeating";
            this.labelCockpitSeating.Size = new System.Drawing.Size(118, 17);
            this.labelCockpitSeating.TabIndex = 0;
            this.labelCockpitSeating.Text = "Cockpit Seating";
            this.labelCockpitSeating.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxGalleys
            // 
            this.textBoxGalleys.BackColor = System.Drawing.Color.White;
            this.textBoxGalleys.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxGalleys.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxGalleys.Location = new System.Drawing.Point(149, 39);
            this.textBoxGalleys.Name = "textBoxGalleys";
            this.textBoxGalleys.Size = new System.Drawing.Size(190, 25);
            this.textBoxGalleys.TabIndex = 5;
            // 
            // textBoxLavatory
            // 
            this.textBoxLavatory.BackColor = System.Drawing.Color.White;
            this.textBoxLavatory.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxLavatory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxLavatory.Location = new System.Drawing.Point(149, 75);
            this.textBoxLavatory.Name = "textBoxLavatory";
            this.textBoxLavatory.Size = new System.Drawing.Size(190, 25);
            this.textBoxLavatory.TabIndex = 6;
            // 
            // textBoxCockpitSeating
            // 
            this.textBoxCockpitSeating.BackColor = System.Drawing.Color.White;
            this.textBoxCockpitSeating.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxCockpitSeating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxCockpitSeating.Location = new System.Drawing.Point(149, 3);
            this.textBoxCockpitSeating.Name = "textBoxCockpitSeating";
            this.textBoxCockpitSeating.Size = new System.Drawing.Size(190, 25);
            this.textBoxCockpitSeating.TabIndex = 4;
            // 
            // labelOven
            // 
            this.labelOven.AutoSize = true;
            this.labelOven.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelOven.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelOven.Location = new System.Drawing.Point(345, 6);
            this.labelOven.Name = "labelOven";
            this.labelOven.Size = new System.Drawing.Size(44, 17);
            this.labelOven.TabIndex = 8;
            this.labelOven.Text = "Oven";
            this.labelOven.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBoiler
            // 
            this.labelBoiler.AutoSize = true;
            this.labelBoiler.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelBoiler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelBoiler.Location = new System.Drawing.Point(345, 42);
            this.labelBoiler.Name = "labelBoiler";
            this.labelBoiler.Size = new System.Drawing.Size(47, 17);
            this.labelBoiler.TabIndex = 9;
            this.labelBoiler.Text = "Boiler";
            this.labelBoiler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAirStairDoors
            // 
            this.labelAirStairDoors.AutoSize = true;
            this.labelAirStairDoors.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelAirStairDoors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelAirStairDoors.Location = new System.Drawing.Point(345, 78);
            this.labelAirStairDoors.Name = "labelAirStairDoors";
            this.labelAirStairDoors.Size = new System.Drawing.Size(113, 17);
            this.labelAirStairDoors.TabIndex = 10;
            this.labelAirStairDoors.Text = "Air Stair Doors";
            this.labelAirStairDoors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxOven
            // 
            this.textBoxOven.BackColor = System.Drawing.Color.White;
            this.textBoxOven.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxOven.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxOven.Location = new System.Drawing.Point(484, 3);
            this.textBoxOven.Name = "textBoxOven";
            this.textBoxOven.Size = new System.Drawing.Size(190, 25);
            this.textBoxOven.TabIndex = 11;
            // 
            // textBoxBoiler
            // 
            this.textBoxBoiler.BackColor = System.Drawing.Color.White;
            this.textBoxBoiler.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxBoiler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxBoiler.Location = new System.Drawing.Point(484, 39);
            this.textBoxBoiler.Name = "textBoxBoiler";
            this.textBoxBoiler.Size = new System.Drawing.Size(190, 25);
            this.textBoxBoiler.TabIndex = 12;
            // 
            // textBoxAirStairDoors
            // 
            this.textBoxAirStairDoors.BackColor = System.Drawing.Color.White;
            this.textBoxAirStairDoors.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxAirStairDoors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.textBoxAirStairDoors.Location = new System.Drawing.Point(484, 75);
            this.textBoxAirStairDoors.Name = "textBoxAirStairDoors";
            this.textBoxAirStairDoors.Size = new System.Drawing.Size(190, 25);
            this.textBoxAirStairDoors.TabIndex = 13;
            // 
            // numericUpDownSeatingEconomy
            // 
            this.numericUpDownSeatingEconomy.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownSeatingEconomy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.numericUpDownSeatingEconomy.Location = new System.Drawing.Point(149, 112);
            this.numericUpDownSeatingEconomy.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownSeatingEconomy.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownSeatingEconomy.Name = "numericUpDownSeatingEconomy";
            this.numericUpDownSeatingEconomy.Size = new System.Drawing.Size(190, 25);
            this.numericUpDownSeatingEconomy.TabIndex = 29;
            // 
            // numericUpDownSeatingBusiness
            // 
            this.numericUpDownSeatingBusiness.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownSeatingBusiness.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.numericUpDownSeatingBusiness.Location = new System.Drawing.Point(484, 112);
            this.numericUpDownSeatingBusiness.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownSeatingBusiness.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownSeatingBusiness.Name = "numericUpDownSeatingBusiness";
            this.numericUpDownSeatingBusiness.Size = new System.Drawing.Size(190, 25);
            this.numericUpDownSeatingBusiness.TabIndex = 31;
            // 
            // labelSeatingBusiness
            // 
            this.labelSeatingBusiness.AutoSize = true;
            this.labelSeatingBusiness.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelSeatingBusiness.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelSeatingBusiness.Location = new System.Drawing.Point(345, 114);
            this.labelSeatingBusiness.Name = "labelSeatingBusiness";
            this.labelSeatingBusiness.Size = new System.Drawing.Size(129, 17);
            this.labelSeatingBusiness.TabIndex = 30;
            this.labelSeatingBusiness.Text = "Seating Business";
            this.labelSeatingBusiness.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownSeatingFirst
            // 
            this.numericUpDownSeatingFirst.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.numericUpDownSeatingFirst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.numericUpDownSeatingFirst.Location = new System.Drawing.Point(149, 150);
            this.numericUpDownSeatingFirst.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownSeatingFirst.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownSeatingFirst.Name = "numericUpDownSeatingFirst";
            this.numericUpDownSeatingFirst.Size = new System.Drawing.Size(190, 25);
            this.numericUpDownSeatingFirst.TabIndex = 33;
            // 
            // labelSeatingFirst
            // 
            this.labelSeatingFirst.AutoSize = true;
            this.labelSeatingFirst.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelSeatingFirst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.labelSeatingFirst.Location = new System.Drawing.Point(10, 152);
            this.labelSeatingFirst.Name = "labelSeatingFirst";
            this.labelSeatingFirst.Size = new System.Drawing.Size(97, 17);
            this.labelSeatingFirst.TabIndex = 32;
            this.labelSeatingFirst.Text = "Seating First";
            this.labelSeatingFirst.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InteriorConfigurationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownSeatingFirst);
            this.Controls.Add(this.labelSeatingFirst);
            this.Controls.Add(this.numericUpDownSeatingBusiness);
            this.Controls.Add(this.labelSeatingBusiness);
            this.Controls.Add(this.numericUpDownSeatingEconomy);
            this.Controls.Add(this.labelOven);
            this.Controls.Add(this.labelBoiler);
            this.Controls.Add(this.labelAirStairDoors);
            this.Controls.Add(this.textBoxOven);
            this.Controls.Add(this.textBoxBoiler);
            this.Controls.Add(this.textBoxAirStairDoors);
            this.Controls.Add(this.labelCockpitSeating);
            this.Controls.Add(this.labelGalleys);
            this.Controls.Add(this.labelLavatory);
            this.Controls.Add(this.labelSeatingEconomy);
            this.Controls.Add(this.textBoxCockpitSeating);
            this.Controls.Add(this.textBoxGalleys);
            this.Controls.Add(this.textBoxLavatory);
            this.Name = "InteriorConfigurationControl";
            this.Size = new System.Drawing.Size(687, 189);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeatingEconomy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeatingBusiness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSeatingFirst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private  Label labelSeatingEconomy = new Label();
        private  Label labelGalleys = new Label();
        private  Label labelLavatory = new Label();
        private Label labelCockpitSeating = new Label();
        private  TextBox textBoxGalleys = new TextBox();
        private  TextBox textBoxLavatory = new TextBox();
        private  TextBox textBoxCockpitSeating = new TextBox();
        #endregion
        private Label labelOven;
        private Label labelBoiler;
        private Label labelAirStairDoors;
        private TextBox textBoxOven;
        private TextBox textBoxBoiler;
        private TextBox textBoxAirStairDoors;
        private NumericUpDown numericUpDownSeatingEconomy;
        private NumericUpDown numericUpDownSeatingBusiness;
        private Label labelSeatingBusiness;
        private NumericUpDown numericUpDownSeatingFirst;
        private Label labelSeatingFirst;
    }
}
