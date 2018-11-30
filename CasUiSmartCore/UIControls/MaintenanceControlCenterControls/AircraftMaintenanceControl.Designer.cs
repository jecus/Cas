namespace CAS.UI.UIControls.MaintenanceControlCenterControls
{
    partial class AircraftMaintenanceControl
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
            if (disposing)
            {
                if (backgroundWorker.IsBusy)
                {
                    backgroundWorker.CancelAsync();
                }
                backgroundWorker.DoWork -= BackgroundWorkerDoWork;
                backgroundWorker.ProgressChanged -= BackgroundWorkerProgressChanged;
                backgroundWorker.RunWorkerCompleted -= BackgroundWorkerRunWorkerCompleted;
            }
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
            this.extendableRichContainer = new CAS.UI.UIControls.ReferenceControls.ExtendableRichContainer();
            this.avButtonReload = new AvControls.AvButtonT.AvButtonT();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelExtendable = new System.Windows.Forms.Panel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanelLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lifelengthViewer2 = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lifelengthViewer1 = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
            this.labelOldMEL = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelMELComponentChange = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label36 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.panel16 = new System.Windows.Forms.Panel();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.panelDiscrepancies = new System.Windows.Forms.FlowLayoutPanel();
            this.discrepancyControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.DiscrepancyControl();
            this.discrepancyControl2 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.DiscrepancyControl();
            this.panelAdd = new System.Windows.Forms.Panel();
            this.linkLabelAddNew = new System.Windows.Forms.LinkLabel();
            this.label21 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dateTimePicker20 = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.dateTimePicker21 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker22 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker23 = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.dateTimePicker24 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker25 = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.dateTimePicker26 = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimePicker13 = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimePicker14 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker15 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker16 = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.dateTimePicker17 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker18 = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.dateTimePicker19 = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker5 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker6 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker8 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker9 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker10 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker11 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker12 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker7 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerOut = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePickerIn = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.fuelControl1 = new CAS.UI.UIControls.AircraftTechnicalLogBookControls.FuelControl();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelExtendable.SuspendLayout();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.flowLayoutPanelLeft.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panelDiscrepancies.SuspendLayout();
            this.panelAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // extendableRichContainer
            // 
            this.extendableRichContainer.AfterCaptionControl = this.avButtonReload;
            this.extendableRichContainer.AfterCaptionControl2 = null;
            this.extendableRichContainer.AfterCaptionControl3 = null;
            this.extendableRichContainer.AutoSize = true;
            this.extendableRichContainer.BackColor = System.Drawing.Color.Transparent;
            this.extendableRichContainer.Caption = "Directive Performance";
            this.extendableRichContainer.CaptionFont = new System.Drawing.Font("Verdana", 21.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.extendableRichContainer.Condition = null;
            this.extendableRichContainer.DescriptionTextColor = System.Drawing.Color.DimGray;
            this.extendableRichContainer.Extendable = true;
            this.extendableRichContainer.Extended = false;
            this.extendableRichContainer.Location = new System.Drawing.Point(0, 5);
            this.extendableRichContainer.MainControl = null;
            this.extendableRichContainer.Margin = new System.Windows.Forms.Padding(5);
            this.extendableRichContainer.Name = "extendableRichContainer";
            this.extendableRichContainer.Size = new System.Drawing.Size(346, 50);
            this.extendableRichContainer.TabIndex = 0;
            this.extendableRichContainer.UpperLeftIcon = global::CAS.UI.Properties.Resources.GrayArrow;
            this.extendableRichContainer.Extending += new System.EventHandler(this.ExtendableRichContainerExtending);
            // 
            // avButtonReload
            // 
            this.avButtonReload.ActiveBackColor = System.Drawing.Color.Transparent;
            this.avButtonReload.ActiveBackgroundImage = null;
            this.avButtonReload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avButtonReload.FontMain = new System.Drawing.Font("Verdana", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Pixel);
            this.avButtonReload.FontSecondary = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.avButtonReload.ForeColorMain = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(82)))), ((int)(((byte)(128)))));
            this.avButtonReload.ForeColorSecondary = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.avButtonReload.Icon = global::CAS.UI.Properties.Resources.ReloadIcon;
            this.avButtonReload.IconLayout = System.Windows.Forms.ImageLayout.Center;
            this.avButtonReload.IconNotEnabled = global::CAS.UI.Properties.Resources.ReloadIcon_gray;
            this.avButtonReload.Location = new System.Drawing.Point(298, 0);
            this.avButtonReload.Margin = new System.Windows.Forms.Padding(0);
            this.avButtonReload.Name = "avButtonReload";
            this.avButtonReload.NormalBackgroundImage = null;
            this.avButtonReload.PaddingMain = new System.Windows.Forms.Padding(0);
            this.avButtonReload.PaddingSecondary = new System.Windows.Forms.Padding(0);
            this.avButtonReload.ShowToolTip = true;
            this.avButtonReload.Size = new System.Drawing.Size(48, 50);
            this.avButtonReload.TabIndex = 12;
            this.avButtonReload.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            this.avButtonReload.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
            this.avButtonReload.TextMain = "";
            this.avButtonReload.TextSecondary = "";
            this.avButtonReload.ToolTipText = "Refresh";
            this.avButtonReload.Click += new System.EventHandler(this.AvButtonReloadClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.panelExtendable);
            this.flowLayoutPanel1.Controls.Add(this.splitContainerMain);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1532, 859);
            this.flowLayoutPanel1.TabIndex = 67;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panelExtendable
            // 
            this.panelExtendable.Controls.Add(this.extendableRichContainer);
            this.panelExtendable.Location = new System.Drawing.Point(4, 4);
            this.panelExtendable.Margin = new System.Windows.Forms.Padding(4);
            this.panelExtendable.Name = "panelExtendable";
            this.panelExtendable.Size = new System.Drawing.Size(1524, 57);
            this.panelExtendable.TabIndex = 36;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.IsSplitterFixed = true;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 65);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.flowLayoutPanelLeft);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.AutoScroll = true;
            this.splitContainerMain.Panel2.Controls.Add(this.panelDiscrepancies);
            this.splitContainerMain.Panel2.Controls.Add(this.label21);
            this.splitContainerMain.Panel2.Controls.Add(this.label16);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker20);
            this.splitContainerMain.Panel2.Controls.Add(this.label17);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker21);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker22);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker23);
            this.splitContainerMain.Panel2.Controls.Add(this.label18);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker24);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker25);
            this.splitContainerMain.Panel2.Controls.Add(this.label19);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker26);
            this.splitContainerMain.Panel2.Controls.Add(this.label20);
            this.splitContainerMain.Panel2.Controls.Add(this.label11);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker13);
            this.splitContainerMain.Panel2.Controls.Add(this.label12);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker14);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker15);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker16);
            this.splitContainerMain.Panel2.Controls.Add(this.label13);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker17);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker18);
            this.splitContainerMain.Panel2.Controls.Add(this.label14);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker19);
            this.splitContainerMain.Panel2.Controls.Add(this.label15);
            this.splitContainerMain.Panel2.Controls.Add(this.label4);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker5);
            this.splitContainerMain.Panel2.Controls.Add(this.label5);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker6);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker8);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker9);
            this.splitContainerMain.Panel2.Controls.Add(this.label6);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker10);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker11);
            this.splitContainerMain.Panel2.Controls.Add(this.label7);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker12);
            this.splitContainerMain.Panel2.Controls.Add(this.label10);
            this.splitContainerMain.Panel2.Controls.Add(this.label3);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker7);
            this.splitContainerMain.Panel2.Controls.Add(this.label2);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker2);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker3);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker4);
            this.splitContainerMain.Panel2.Controls.Add(this.label1);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePicker1);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePickerOut);
            this.splitContainerMain.Panel2.Controls.Add(this.label8);
            this.splitContainerMain.Panel2.Controls.Add(this.dateTimePickerIn);
            this.splitContainerMain.Panel2.Controls.Add(this.label9);
            this.splitContainerMain.Size = new System.Drawing.Size(1524, 794);
            this.splitContainerMain.SplitterDistance = 634;
            this.splitContainerMain.TabIndex = 1;
            // 
            // flowLayoutPanelLeft
            // 
            this.flowLayoutPanelLeft.Controls.Add(this.panel2);
            this.flowLayoutPanelLeft.Controls.Add(this.panel1);
            this.flowLayoutPanelLeft.Controls.Add(this.panel3);
            this.flowLayoutPanelLeft.Controls.Add(this.panel10);
            this.flowLayoutPanelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelLeft.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelLeft.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelLeft.Name = "flowLayoutPanelLeft";
            this.flowLayoutPanelLeft.Size = new System.Drawing.Size(634, 794);
            this.flowLayoutPanelLeft.TabIndex = 0;
            this.flowLayoutPanelLeft.WrapContents = false;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.lifelengthViewer2);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 116);
            this.panel2.TabIndex = 8;
            // 
            // lifelengthViewer2
            // 
            this.lifelengthViewer2.AutoSize = true;
            this.lifelengthViewer2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthViewer2.CalendarApplicable = false;
            this.lifelengthViewer2.CyclesApplicable = false;
            this.lifelengthViewer2.EnabledCalendar = true;
            this.lifelengthViewer2.EnabledCycle = true;
            this.lifelengthViewer2.EnabledHours = true;
            this.lifelengthViewer2.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewer2.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewer2.HeaderCalendar = "Calendar";
            this.lifelengthViewer2.HeaderCycles = "Cycles";
            this.lifelengthViewer2.HeaderHours = "Hours";
            this.lifelengthViewer2.HoursApplicable = false;
            this.lifelengthViewer2.LeftHeader = "Remain";
            this.lifelengthViewer2.Location = new System.Drawing.Point(7, 55);
            this.lifelengthViewer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lifelengthViewer2.Modified = false;
            this.lifelengthViewer2.Name = "lifelengthViewer2";
            this.lifelengthViewer2.ReadOnly = false;
            this.lifelengthViewer2.ShowCalendar = true;
            this.lifelengthViewer2.ShowMinutes = true;
            this.lifelengthViewer2.Size = new System.Drawing.Size(539, 59);
            this.lifelengthViewer2.SystemCalculated = true;
            this.lifelengthViewer2.TabIndex = 7;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.Location = new System.Drawing.Point(0, 0);
            this.label23.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(544, 25);
            this.label23.TabIndex = 2;
            this.label23.Text = "MEL CAT:A Not Operate";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(387, 28);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(160, 22);
            this.textBox3.TabIndex = 6;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label24.Location = new System.Drawing.Point(287, 26);
            this.label24.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(92, 25);
            this.label24.TabIndex = 5;
            this.label24.Text = "S/N OFF:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(103, 28);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(160, 22);
            this.textBox4.TabIndex = 4;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label25.Location = new System.Drawing.Point(3, 26);
            this.label25.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(92, 25);
            this.label25.TabIndex = 3;
            this.label25.Text = "P/N OFF:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.lifelengthViewer1);
            this.panel1.Controls.Add(this.labelOldMEL);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.labelMELComponentChange);
            this.panel1.Location = new System.Drawing.Point(3, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 116);
            this.panel1.TabIndex = 4;
            // 
            // lifelengthViewer1
            // 
            this.lifelengthViewer1.AutoSize = true;
            this.lifelengthViewer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lifelengthViewer1.CalendarApplicable = false;
            this.lifelengthViewer1.CyclesApplicable = false;
            this.lifelengthViewer1.EnabledCalendar = true;
            this.lifelengthViewer1.EnabledCycle = true;
            this.lifelengthViewer1.EnabledHours = true;
            this.lifelengthViewer1.FieldsBackColor = System.Drawing.SystemColors.Window;
            this.lifelengthViewer1.ForeColor = System.Drawing.Color.DimGray;
            this.lifelengthViewer1.HeaderCalendar = "Calendar";
            this.lifelengthViewer1.HeaderCycles = "Cycles";
            this.lifelengthViewer1.HeaderHours = "Hours";
            this.lifelengthViewer1.HoursApplicable = false;
            this.lifelengthViewer1.LeftHeader = "Remain";
            this.lifelengthViewer1.Location = new System.Drawing.Point(7, 55);
            this.lifelengthViewer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lifelengthViewer1.Modified = false;
            this.lifelengthViewer1.Name = "lifelengthViewer1";
            this.lifelengthViewer1.ReadOnly = false;
            this.lifelengthViewer1.ShowCalendar = true;
            this.lifelengthViewer1.ShowMinutes = true;
            this.lifelengthViewer1.Size = new System.Drawing.Size(539, 59);
            this.lifelengthViewer1.SystemCalculated = true;
            this.lifelengthViewer1.TabIndex = 7;
            // 
            // labelOldMEL
            // 
            this.labelOldMEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOldMEL.Location = new System.Drawing.Point(0, 0);
            this.labelOldMEL.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelOldMEL.Name = "labelOldMEL";
            this.labelOldMEL.Size = new System.Drawing.Size(544, 25);
            this.labelOldMEL.TabIndex = 2;
            this.labelOldMEL.Text = "Old MEL CAT:A Not Operate";
            this.labelOldMEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(387, 28);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(160, 22);
            this.textBox2.TabIndex = 6;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label22.Location = new System.Drawing.Point(287, 26);
            this.label22.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(92, 25);
            this.label22.TabIndex = 5;
            this.label22.Text = "S/N OFF:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(103, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 22);
            this.textBox1.TabIndex = 4;
            // 
            // labelMELComponentChange
            // 
            this.labelMELComponentChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMELComponentChange.Location = new System.Drawing.Point(3, 26);
            this.labelMELComponentChange.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelMELComponentChange.Name = "labelMELComponentChange";
            this.labelMELComponentChange.Size = new System.Drawing.Size(92, 25);
            this.labelMELComponentChange.TabIndex = 3;
            this.labelMELComponentChange.Text = "P/N OFF:";
            this.labelMELComponentChange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel3.Controls.Add(this.label26);
            this.panel3.Controls.Add(this.flowLayoutPanel2);
            this.panel3.Location = new System.Drawing.Point(0, 244);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(549, 245);
            this.panel3.TabIndex = 8;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label26.Location = new System.Drawing.Point(0, 0);
            this.label26.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(544, 25);
            this.label26.TabIndex = 2;
            this.label26.Text = "Work Package: 1A Check Date: 21.05.14 Completed: 70%";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.panel4);
            this.flowLayoutPanel2.Controls.Add(this.panel5);
            this.flowLayoutPanel2.Controls.Add(this.panel6);
            this.flowLayoutPanel2.Controls.Add(this.panel7);
            this.flowLayoutPanel2.Controls.Add(this.panel8);
            this.flowLayoutPanel2.Controls.Add(this.panel9);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 28);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(545, 217);
            this.flowLayoutPanel2.TabIndex = 9;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.textBox5);
            this.panel4.Controls.Add(this.label28);
            this.panel4.Controls.Add(this.label27);
            this.panel4.Controls.Add(this.checkBox1);
            this.panel4.Controls.Add(this.label29);
            this.panel4.Controls.Add(this.label30);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(536, 56);
            this.panel4.TabIndex = 0;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(29, 31);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(430, 22);
            this.textBox5.TabIndex = 16;
            this.textBox5.Text = "AD: 2010-15-08";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label28.Location = new System.Drawing.Point(-1, 33);
            this.label28.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(22, 17);
            this.label28.TabIndex = 15;
            this.label28.Text = "1:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label27.Location = new System.Drawing.Point(469, 6);
            this.label27.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(62, 17);
            this.label27.TabIndex = 14;
            this.label27.Text = "Closed:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(488, 35);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label29.Location = new System.Drawing.Point(26, 2);
            this.label29.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(433, 25);
            this.label29.TabIndex = 10;
            this.label29.Text = "Description:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label30.Location = new System.Drawing.Point(-2, 6);
            this.label30.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(28, 17);
            this.label30.TabIndex = 8;
            this.label30.Text = "№:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Controls.Add(this.textBox6);
            this.panel5.Controls.Add(this.label31);
            this.panel5.Controls.Add(this.checkBox2);
            this.panel5.Location = new System.Drawing.Point(3, 65);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(509, 25);
            this.panel5.TabIndex = 17;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(29, 0);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(430, 22);
            this.textBox6.TabIndex = 16;
            this.textBox6.Text = "AD: 2010-15-08";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label31.Location = new System.Drawing.Point(-1, 2);
            this.label31.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(22, 17);
            this.label31.TabIndex = 15;
            this.label31.Text = "2:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(488, 4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(18, 17);
            this.checkBox2.TabIndex = 13;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.Controls.Add(this.textBox7);
            this.panel6.Controls.Add(this.label32);
            this.panel6.Controls.Add(this.checkBox3);
            this.panel6.Location = new System.Drawing.Point(3, 96);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(509, 25);
            this.panel6.TabIndex = 18;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(29, 0);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(430, 22);
            this.textBox7.TabIndex = 16;
            this.textBox7.Text = "AD: 2010-15-08";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label32.Location = new System.Drawing.Point(-1, 2);
            this.label32.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(22, 17);
            this.label32.TabIndex = 15;
            this.label32.Text = "3:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(488, 4);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(18, 17);
            this.checkBox3.TabIndex = 13;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.Controls.Add(this.textBox8);
            this.panel7.Controls.Add(this.label33);
            this.panel7.Controls.Add(this.checkBox4);
            this.panel7.Location = new System.Drawing.Point(3, 127);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(509, 25);
            this.panel7.TabIndex = 19;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(29, 0);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(430, 22);
            this.textBox8.TabIndex = 16;
            this.textBox8.Text = "AD: 2010-15-08";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label33.Location = new System.Drawing.Point(-1, 2);
            this.label33.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(22, 17);
            this.label33.TabIndex = 15;
            this.label33.Text = "4:";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(488, 4);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(18, 17);
            this.checkBox4.TabIndex = 13;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.AutoSize = true;
            this.panel8.Controls.Add(this.textBox9);
            this.panel8.Controls.Add(this.label34);
            this.panel8.Controls.Add(this.checkBox5);
            this.panel8.Location = new System.Drawing.Point(3, 158);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(509, 25);
            this.panel8.TabIndex = 20;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(29, 0);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(430, 22);
            this.textBox9.TabIndex = 16;
            this.textBox9.Text = "AD: 2010-15-08";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label34.Location = new System.Drawing.Point(-1, 2);
            this.label34.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(22, 17);
            this.label34.TabIndex = 15;
            this.label34.Text = "5:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(488, 4);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(18, 17);
            this.checkBox5.TabIndex = 13;
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.AutoSize = true;
            this.panel9.Controls.Add(this.textBox10);
            this.panel9.Controls.Add(this.label35);
            this.panel9.Controls.Add(this.checkBox6);
            this.panel9.Location = new System.Drawing.Point(3, 189);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(509, 25);
            this.panel9.TabIndex = 21;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(29, 0);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(430, 22);
            this.textBox10.TabIndex = 16;
            this.textBox10.Text = "AD: 2010-15-08";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label35.Location = new System.Drawing.Point(-1, 2);
            this.label35.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(22, 17);
            this.label35.TabIndex = 15;
            this.label35.Text = "6:";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Location = new System.Drawing.Point(488, 4);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(18, 17);
            this.checkBox6.TabIndex = 13;
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.AutoSize = true;
            this.panel10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel10.Controls.Add(this.label36);
            this.panel10.Controls.Add(this.flowLayoutPanel3);
            this.panel10.Location = new System.Drawing.Point(0, 489);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(549, 245);
            this.panel10.TabIndex = 9;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label36.Location = new System.Drawing.Point(0, 0);
            this.label36.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(544, 25);
            this.label36.TabIndex = 2;
            this.label36.Text = "Work Package: DY Check Date: 21.05.14 Completed: 0%";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.Controls.Add(this.panel11);
            this.flowLayoutPanel3.Controls.Add(this.panel12);
            this.flowLayoutPanel3.Controls.Add(this.panel13);
            this.flowLayoutPanel3.Controls.Add(this.panel14);
            this.flowLayoutPanel3.Controls.Add(this.panel15);
            this.flowLayoutPanel3.Controls.Add(this.panel16);
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 28);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(545, 217);
            this.flowLayoutPanel3.TabIndex = 9;
            this.flowLayoutPanel3.WrapContents = false;
            // 
            // panel11
            // 
            this.panel11.AutoSize = true;
            this.panel11.Controls.Add(this.textBox11);
            this.panel11.Controls.Add(this.label37);
            this.panel11.Controls.Add(this.label38);
            this.panel11.Controls.Add(this.checkBox7);
            this.panel11.Controls.Add(this.label39);
            this.panel11.Controls.Add(this.label40);
            this.panel11.Location = new System.Drawing.Point(3, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(536, 56);
            this.panel11.TabIndex = 0;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(29, 31);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(430, 22);
            this.textBox11.TabIndex = 16;
            this.textBox11.Text = "AD: 2010-15-08";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label37.Location = new System.Drawing.Point(-1, 33);
            this.label37.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(22, 17);
            this.label37.TabIndex = 15;
            this.label37.Text = "1:";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label38.Location = new System.Drawing.Point(469, 6);
            this.label38.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(62, 17);
            this.label38.TabIndex = 14;
            this.label38.Text = "Closed:";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(488, 35);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(18, 17);
            this.checkBox7.TabIndex = 13;
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label39.Location = new System.Drawing.Point(26, 2);
            this.label39.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(433, 25);
            this.label39.TabIndex = 10;
            this.label39.Text = "Description:";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label40.Location = new System.Drawing.Point(-2, 6);
            this.label40.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(28, 17);
            this.label40.TabIndex = 8;
            this.label40.Text = "№:";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel12
            // 
            this.panel12.AutoSize = true;
            this.panel12.Controls.Add(this.textBox12);
            this.panel12.Controls.Add(this.label41);
            this.panel12.Controls.Add(this.checkBox8);
            this.panel12.Location = new System.Drawing.Point(3, 65);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(509, 25);
            this.panel12.TabIndex = 17;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(29, 0);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(430, 22);
            this.textBox12.TabIndex = 16;
            this.textBox12.Text = "AD: 2010-15-08";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label41.Location = new System.Drawing.Point(-1, 2);
            this.label41.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(22, 17);
            this.label41.TabIndex = 15;
            this.label41.Text = "2:";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(488, 4);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(18, 17);
            this.checkBox8.TabIndex = 13;
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // panel13
            // 
            this.panel13.AutoSize = true;
            this.panel13.Controls.Add(this.textBox13);
            this.panel13.Controls.Add(this.label42);
            this.panel13.Controls.Add(this.checkBox9);
            this.panel13.Location = new System.Drawing.Point(3, 96);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(509, 25);
            this.panel13.TabIndex = 18;
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(29, 0);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(430, 22);
            this.textBox13.TabIndex = 16;
            this.textBox13.Text = "AD: 2010-15-08";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label42.Location = new System.Drawing.Point(-1, 2);
            this.label42.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(22, 17);
            this.label42.TabIndex = 15;
            this.label42.Text = "3:";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(488, 4);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(18, 17);
            this.checkBox9.TabIndex = 13;
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // panel14
            // 
            this.panel14.AutoSize = true;
            this.panel14.Controls.Add(this.textBox14);
            this.panel14.Controls.Add(this.label43);
            this.panel14.Controls.Add(this.checkBox10);
            this.panel14.Location = new System.Drawing.Point(3, 127);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(509, 25);
            this.panel14.TabIndex = 19;
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(29, 0);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(430, 22);
            this.textBox14.TabIndex = 16;
            this.textBox14.Text = "AD: 2010-15-08";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label43.Location = new System.Drawing.Point(-1, 2);
            this.label43.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(22, 17);
            this.label43.TabIndex = 15;
            this.label43.Text = "4:";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(488, 4);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(18, 17);
            this.checkBox10.TabIndex = 13;
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // panel15
            // 
            this.panel15.AutoSize = true;
            this.panel15.Controls.Add(this.textBox15);
            this.panel15.Controls.Add(this.label44);
            this.panel15.Controls.Add(this.checkBox11);
            this.panel15.Location = new System.Drawing.Point(3, 158);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(509, 25);
            this.panel15.TabIndex = 20;
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(29, 0);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(430, 22);
            this.textBox15.TabIndex = 16;
            this.textBox15.Text = "AD: 2010-15-08";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label44.Location = new System.Drawing.Point(-1, 2);
            this.label44.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(22, 17);
            this.label44.TabIndex = 15;
            this.label44.Text = "5:";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(488, 4);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(18, 17);
            this.checkBox11.TabIndex = 13;
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // panel16
            // 
            this.panel16.AutoSize = true;
            this.panel16.Controls.Add(this.textBox16);
            this.panel16.Controls.Add(this.label45);
            this.panel16.Controls.Add(this.checkBox12);
            this.panel16.Location = new System.Drawing.Point(3, 189);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(509, 25);
            this.panel16.TabIndex = 21;
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(29, 0);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(430, 22);
            this.textBox16.TabIndex = 16;
            this.textBox16.Text = "AD: 2010-15-08";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label45.Location = new System.Drawing.Point(-1, 2);
            this.label45.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(22, 17);
            this.label45.TabIndex = 15;
            this.label45.Text = "6:";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(488, 4);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(18, 17);
            this.checkBox12.TabIndex = 13;
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // panelDiscrepancies
            // 
            this.panelDiscrepancies.AutoSize = true;
            this.panelDiscrepancies.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelDiscrepancies.Controls.Add(this.discrepancyControl1);
            this.panelDiscrepancies.Controls.Add(this.discrepancyControl2);
            this.panelDiscrepancies.Controls.Add(this.panelAdd);
            this.panelDiscrepancies.Controls.Add(this.fuelControl1);
            this.panelDiscrepancies.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelDiscrepancies.Location = new System.Drawing.Point(0, 148);
            this.panelDiscrepancies.Margin = new System.Windows.Forms.Padding(4);
            this.panelDiscrepancies.Name = "panelDiscrepancies";
            this.panelDiscrepancies.Size = new System.Drawing.Size(1333, 357);
            this.panelDiscrepancies.TabIndex = 0;
            // 
            // discrepancyControl1
            // 
            this.discrepancyControl1.AttachedObject = null;
            this.discrepancyControl1.AutoSize = true;
            this.discrepancyControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.discrepancyControl1.Discrepancy = null;
            this.discrepancyControl1.EditEnabled = true;
            this.discrepancyControl1.EnableExtendedControl = true;
            this.discrepancyControl1.Extended = false;
            this.discrepancyControl1.FlightVisible = false;
            this.discrepancyControl1.Index = 1;
            this.discrepancyControl1.Location = new System.Drawing.Point(5, 5);
            this.discrepancyControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.discrepancyControl1.Name = "discrepancyControl1";
            this.discrepancyControl1.RTSDate = new System.DateTime(2012, 12, 26, 0, 0, 0, 0);
            this.discrepancyControl1.Size = new System.Drawing.Size(596, 53);
            this.discrepancyControl1.Station = "DBX";
            this.discrepancyControl1.TabIndex = 119;
            // 
            // discrepancyControl2
            // 
            this.discrepancyControl2.AttachedObject = null;
            this.discrepancyControl2.AutoSize = true;
            this.discrepancyControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.discrepancyControl2.Discrepancy = null;
            this.discrepancyControl2.EditEnabled = true;
            this.discrepancyControl2.EnableExtendedControl = true;
            this.discrepancyControl2.Extended = false;
            this.discrepancyControl2.FlightVisible = false;
            this.discrepancyControl2.Index = 1;
            this.discrepancyControl2.Location = new System.Drawing.Point(5, 68);
            this.discrepancyControl2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.discrepancyControl2.Name = "discrepancyControl2";
            this.discrepancyControl2.RTSDate = new System.DateTime(2012, 12, 26, 0, 0, 0, 0);
            this.discrepancyControl2.Size = new System.Drawing.Size(596, 53);
            this.discrepancyControl2.Station = "DBX";
            this.discrepancyControl2.TabIndex = 120;
            // 
            // panelAdd
            // 
            this.panelAdd.Controls.Add(this.linkLabelAddNew);
            this.panelAdd.Location = new System.Drawing.Point(4, 130);
            this.panelAdd.Margin = new System.Windows.Forms.Padding(4);
            this.panelAdd.Name = "panelAdd";
            this.panelAdd.Size = new System.Drawing.Size(1325, 37);
            this.panelAdd.TabIndex = 2;
            // 
            // linkLabelAddNew
            // 
            this.linkLabelAddNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLabelAddNew.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
            this.linkLabelAddNew.Location = new System.Drawing.Point(609, 4);
            this.linkLabelAddNew.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelAddNew.Name = "linkLabelAddNew";
            this.linkLabelAddNew.Size = new System.Drawing.Size(93, 28);
            this.linkLabelAddNew.TabIndex = 1;
            this.linkLabelAddNew.TabStop = true;
            this.linkLabelAddNew.Text = "Add new";
            this.linkLabelAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label21.Location = new System.Drawing.Point(468, 127);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(129, 17);
            this.label21.TabIndex = 118;
            this.label21.Text = "DISCREPANCIES";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(917, 0);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 17);
            this.label16.TabIndex = 116;
            this.label16.Text = "UAFM";
            // 
            // dateTimePicker20
            // 
            this.dateTimePicker20.CustomFormat = "HH:mm";
            this.dateTimePicker20.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker20.Location = new System.Drawing.Point(909, 92);
            this.dateTimePicker20.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker20.Name = "dateTimePicker20";
            this.dateTimePicker20.ShowUpDown = true;
            this.dateTimePicker20.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker20.TabIndex = 114;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(802, 96);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 17);
            this.label17.TabIndex = 115;
            this.label17.Text = "F:";
            // 
            // dateTimePicker21
            // 
            this.dateTimePicker21.CustomFormat = "HH:mm";
            this.dateTimePicker21.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker21.Location = new System.Drawing.Point(988, 66);
            this.dateTimePicker21.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker21.Name = "dateTimePicker21";
            this.dateTimePicker21.ShowUpDown = true;
            this.dateTimePicker21.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker21.TabIndex = 113;
            // 
            // dateTimePicker22
            // 
            this.dateTimePicker22.CustomFormat = "HH:mm";
            this.dateTimePicker22.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker22.Location = new System.Drawing.Point(830, 66);
            this.dateTimePicker22.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker22.Name = "dateTimePicker22";
            this.dateTimePicker22.ShowUpDown = true;
            this.dateTimePicker22.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker22.TabIndex = 110;
            // 
            // dateTimePicker23
            // 
            this.dateTimePicker23.CustomFormat = "HH:mm";
            this.dateTimePicker23.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker23.Location = new System.Drawing.Point(909, 66);
            this.dateTimePicker23.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker23.Name = "dateTimePicker23";
            this.dateTimePicker23.ShowUpDown = true;
            this.dateTimePicker23.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker23.TabIndex = 111;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(802, 70);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 17);
            this.label18.TabIndex = 112;
            this.label18.Text = "E:";
            // 
            // dateTimePicker24
            // 
            this.dateTimePicker24.CustomFormat = "HH:mm";
            this.dateTimePicker24.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker24.Location = new System.Drawing.Point(988, 40);
            this.dateTimePicker24.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker24.Name = "dateTimePicker24";
            this.dateTimePicker24.ShowUpDown = true;
            this.dateTimePicker24.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker24.TabIndex = 109;
            // 
            // dateTimePicker25
            // 
            this.dateTimePicker25.CustomFormat = "HH:mm";
            this.dateTimePicker25.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker25.Location = new System.Drawing.Point(830, 40);
            this.dateTimePicker25.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker25.Name = "dateTimePicker25";
            this.dateTimePicker25.ShowUpDown = true;
            this.dateTimePicker25.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker25.TabIndex = 105;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label19.Location = new System.Drawing.Point(636, 21);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(81, 17);
            this.label19.TabIndex = 107;
            this.label19.Text = "Departure";
            // 
            // dateTimePicker26
            // 
            this.dateTimePicker26.CustomFormat = "HH:mm";
            this.dateTimePicker26.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker26.Location = new System.Drawing.Point(909, 40);
            this.dateTimePicker26.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker26.Name = "dateTimePicker26";
            this.dateTimePicker26.ShowUpDown = true;
            this.dateTimePicker26.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker26.TabIndex = 106;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(802, 44);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(21, 17);
            this.label20.TabIndex = 108;
            this.label20.Text = "S:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(651, 0);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 17);
            this.label11.TabIndex = 104;
            this.label11.Text = "UAFO";
            // 
            // dateTimePicker13
            // 
            this.dateTimePicker13.CustomFormat = "HH:mm";
            this.dateTimePicker13.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker13.Location = new System.Drawing.Point(643, 92);
            this.dateTimePicker13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker13.Name = "dateTimePicker13";
            this.dateTimePicker13.ShowUpDown = true;
            this.dateTimePicker13.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker13.TabIndex = 102;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(536, 96);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 17);
            this.label12.TabIndex = 103;
            this.label12.Text = "F:";
            // 
            // dateTimePicker14
            // 
            this.dateTimePicker14.CustomFormat = "HH:mm";
            this.dateTimePicker14.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker14.Location = new System.Drawing.Point(722, 66);
            this.dateTimePicker14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker14.Name = "dateTimePicker14";
            this.dateTimePicker14.ShowUpDown = true;
            this.dateTimePicker14.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker14.TabIndex = 101;
            // 
            // dateTimePicker15
            // 
            this.dateTimePicker15.CustomFormat = "HH:mm";
            this.dateTimePicker15.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker15.Location = new System.Drawing.Point(564, 66);
            this.dateTimePicker15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker15.Name = "dateTimePicker15";
            this.dateTimePicker15.ShowUpDown = true;
            this.dateTimePicker15.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker15.TabIndex = 98;
            // 
            // dateTimePicker16
            // 
            this.dateTimePicker16.CustomFormat = "HH:mm";
            this.dateTimePicker16.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker16.Location = new System.Drawing.Point(643, 66);
            this.dateTimePicker16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker16.Name = "dateTimePicker16";
            this.dateTimePicker16.ShowUpDown = true;
            this.dateTimePicker16.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker16.TabIndex = 99;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(536, 70);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 17);
            this.label13.TabIndex = 100;
            this.label13.Text = "E:";
            // 
            // dateTimePicker17
            // 
            this.dateTimePicker17.CustomFormat = "HH:mm";
            this.dateTimePicker17.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker17.Location = new System.Drawing.Point(722, 40);
            this.dateTimePicker17.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker17.Name = "dateTimePicker17";
            this.dateTimePicker17.ShowUpDown = true;
            this.dateTimePicker17.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker17.TabIndex = 97;
            // 
            // dateTimePicker18
            // 
            this.dateTimePicker18.CustomFormat = "HH:mm";
            this.dateTimePicker18.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker18.Location = new System.Drawing.Point(564, 40);
            this.dateTimePicker18.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker18.Name = "dateTimePicker18";
            this.dateTimePicker18.ShowUpDown = true;
            this.dateTimePicker18.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker18.TabIndex = 93;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(911, 21);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 17);
            this.label14.TabIndex = 95;
            this.label14.Text = "Airrival";
            // 
            // dateTimePicker19
            // 
            this.dateTimePicker19.CustomFormat = "HH:mm";
            this.dateTimePicker19.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker19.Location = new System.Drawing.Point(643, 40);
            this.dateTimePicker19.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker19.Name = "dateTimePicker19";
            this.dateTimePicker19.ShowUpDown = true;
            this.dateTimePicker19.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker19.TabIndex = 94;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(536, 44);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 17);
            this.label15.TabIndex = 96;
            this.label15.Text = "S:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(385, 1);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 92;
            this.label4.Text = "UAFO";
            // 
            // dateTimePicker5
            // 
            this.dateTimePicker5.CustomFormat = "HH:mm";
            this.dateTimePicker5.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker5.Location = new System.Drawing.Point(377, 93);
            this.dateTimePicker5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker5.Name = "dateTimePicker5";
            this.dateTimePicker5.ShowUpDown = true;
            this.dateTimePicker5.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker5.TabIndex = 90;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(270, 97);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 17);
            this.label5.TabIndex = 91;
            this.label5.Text = "F:";
            // 
            // dateTimePicker6
            // 
            this.dateTimePicker6.CustomFormat = "HH:mm";
            this.dateTimePicker6.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker6.Location = new System.Drawing.Point(456, 67);
            this.dateTimePicker6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker6.Name = "dateTimePicker6";
            this.dateTimePicker6.ShowUpDown = true;
            this.dateTimePicker6.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker6.TabIndex = 89;
            // 
            // dateTimePicker8
            // 
            this.dateTimePicker8.CustomFormat = "HH:mm";
            this.dateTimePicker8.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker8.Location = new System.Drawing.Point(298, 67);
            this.dateTimePicker8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker8.Name = "dateTimePicker8";
            this.dateTimePicker8.ShowUpDown = true;
            this.dateTimePicker8.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker8.TabIndex = 86;
            // 
            // dateTimePicker9
            // 
            this.dateTimePicker9.CustomFormat = "HH:mm";
            this.dateTimePicker9.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker9.Location = new System.Drawing.Point(377, 67);
            this.dateTimePicker9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker9.Name = "dateTimePicker9";
            this.dateTimePicker9.ShowUpDown = true;
            this.dateTimePicker9.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker9.TabIndex = 87;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 71);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 17);
            this.label6.TabIndex = 88;
            this.label6.Text = "E:";
            // 
            // dateTimePicker10
            // 
            this.dateTimePicker10.CustomFormat = "HH:mm";
            this.dateTimePicker10.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker10.Location = new System.Drawing.Point(456, 41);
            this.dateTimePicker10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker10.Name = "dateTimePicker10";
            this.dateTimePicker10.ShowUpDown = true;
            this.dateTimePicker10.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker10.TabIndex = 85;
            // 
            // dateTimePicker11
            // 
            this.dateTimePicker11.CustomFormat = "HH:mm";
            this.dateTimePicker11.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker11.Location = new System.Drawing.Point(298, 41);
            this.dateTimePicker11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker11.Name = "dateTimePicker11";
            this.dateTimePicker11.ShowUpDown = true;
            this.dateTimePicker11.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker11.TabIndex = 81;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(105, 21);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 17);
            this.label7.TabIndex = 83;
            this.label7.Text = "Departure";
            // 
            // dateTimePicker12
            // 
            this.dateTimePicker12.CustomFormat = "HH:mm";
            this.dateTimePicker12.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker12.Location = new System.Drawing.Point(377, 41);
            this.dateTimePicker12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker12.Name = "dateTimePicker12";
            this.dateTimePicker12.ShowUpDown = true;
            this.dateTimePicker12.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker12.TabIndex = 82;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(270, 45);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 17);
            this.label10.TabIndex = 84;
            this.label10.Text = "S:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(119, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 80;
            this.label3.Text = "UAFM";
            // 
            // dateTimePicker7
            // 
            this.dateTimePicker7.CustomFormat = "HH:mm";
            this.dateTimePicker7.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker7.Location = new System.Drawing.Point(111, 92);
            this.dateTimePicker7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker7.Name = "dateTimePicker7";
            this.dateTimePicker7.ShowUpDown = true;
            this.dateTimePicker7.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker7.TabIndex = 78;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 17);
            this.label2.TabIndex = 79;
            this.label2.Text = "F:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "HH:mm";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(190, 66);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker2.TabIndex = 76;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CustomFormat = "HH:mm";
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(32, 66);
            this.dateTimePicker3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.ShowUpDown = true;
            this.dateTimePicker3.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker3.TabIndex = 73;
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.CustomFormat = "HH:mm";
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker4.Location = new System.Drawing.Point(111, 66);
            this.dateTimePicker4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.ShowUpDown = true;
            this.dateTimePicker4.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker4.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 75;
            this.label1.Text = "E:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "HH:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(190, 40);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(73, 22);
            this.dateTimePicker1.TabIndex = 72;
            // 
            // dateTimePickerOut
            // 
            this.dateTimePickerOut.CustomFormat = "HH:mm";
            this.dateTimePickerOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerOut.Location = new System.Drawing.Point(32, 40);
            this.dateTimePickerOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerOut.Name = "dateTimePickerOut";
            this.dateTimePickerOut.ShowUpDown = true;
            this.dateTimePickerOut.Size = new System.Drawing.Size(73, 22);
            this.dateTimePickerOut.TabIndex = 68;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(382, 21);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 17);
            this.label8.TabIndex = 70;
            this.label8.Text = "Arrival";
            // 
            // dateTimePickerIn
            // 
            this.dateTimePickerIn.CustomFormat = "HH:mm";
            this.dateTimePickerIn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerIn.Location = new System.Drawing.Point(111, 40);
            this.dateTimePickerIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerIn.Name = "dateTimePickerIn";
            this.dateTimePickerIn.ShowUpDown = true;
            this.dateTimePickerIn.Size = new System.Drawing.Size(73, 22);
            this.dateTimePickerIn.TabIndex = 69;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 44);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 17);
            this.label9.TabIndex = 71;
            this.label9.Text = "S:";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerDoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorkerProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerRunWorkerCompleted);
            // 
            // fuelControl1
            // 
            this.fuelControl1.AttachedObject = null;
            this.fuelControl1.Location = new System.Drawing.Point(5, 176);
            this.fuelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.fuelControl1.Name = "fuelControl1";
            this.fuelControl1.Size = new System.Drawing.Size(885, 176);
            this.fuelControl1.TabIndex = 119;
            // 
            // AircraftMaintenanceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "AircraftMaintenanceControl";
            this.Size = new System.Drawing.Size(1532, 859);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelExtendable.ResumeLayout(false);
            this.panelExtendable.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.Panel2.PerformLayout();
            this.splitContainerMain.ResumeLayout(false);
            this.flowLayoutPanelLeft.ResumeLayout(false);
            this.flowLayoutPanelLeft.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panelDiscrepancies.ResumeLayout(false);
            this.panelDiscrepancies.PerformLayout();
            this.panelAdd.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReferenceControls.ExtendableRichContainer extendableRichContainer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelExtendable;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dateTimePicker20;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dateTimePicker21;
        private System.Windows.Forms.DateTimePicker dateTimePicker22;
        private System.Windows.Forms.DateTimePicker dateTimePicker23;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dateTimePicker24;
        private System.Windows.Forms.DateTimePicker dateTimePicker25;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker dateTimePicker26;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimePicker13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePicker14;
        private System.Windows.Forms.DateTimePicker dateTimePicker15;
        private System.Windows.Forms.DateTimePicker dateTimePicker16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dateTimePicker17;
        private System.Windows.Forms.DateTimePicker dateTimePicker18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dateTimePicker19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker6;
        private System.Windows.Forms.DateTimePicker dateTimePicker8;
        private System.Windows.Forms.DateTimePicker dateTimePicker9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker10;
        private System.Windows.Forms.DateTimePicker dateTimePicker11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePickerOut;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerIn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.FlowLayoutPanel panelDiscrepancies;
        private System.Windows.Forms.Panel panelAdd;
        private System.Windows.Forms.LinkLabel linkLabelAddNew;
        private AvControls.AvButtonT.AvButtonT avButtonReload;
        private AircraftTechnicalLogBookControls.DiscrepancyControl discrepancyControl1;
        private AircraftTechnicalLogBookControls.DiscrepancyControl discrepancyControl2;
        private System.Windows.Forms.Label labelOldMEL;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelLeft;
        private System.Windows.Forms.Panel panel2;
        private Auxiliary.LifelengthViewer lifelengthViewer2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel panel1;
        private Auxiliary.LifelengthViewer lifelengthViewer1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelMELComponentChange;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.CheckBox checkBox12;
        private AircraftTechnicalLogBookControls.FuelControl fuelControl1;
    }
}
