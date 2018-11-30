using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CAS.Core.Types.ReportFilters;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.ReferenceControls;

namespace CAS.UI.UIControls.ReferenceControls
{
    /// <summary>
    /// Класс, описывающий расширяемый фильтр коллекции директив
    /// </summary>
    public class ExtendableDirectiveFilterControl : ExtendableRichContainer
    {
        private DirectiveFilterControl directiveFilterControl1;
        private Button buttonReloadForDate;
        private LinkLabel linkLabelLoadCurrent;
        private DateTimePicker dateTimePicker1;
        private Button buttonApplyFilter;
        private System.Windows.Forms.Panel panelMain;

        /// <summary>
        /// Создается расширяемый фильтр коллекции директив
        /// </summary>
        public ExtendableDirectiveFilterControl()
        {
            InitializeComponent();
            Initialize();

        }

        #region public DateTime SelectedDate
        /// <summary>
        /// Дата выбранная для загрузки 
        /// </summary>
        public DateTime SelectedDate
        {
            get
            {
                return dateTimePicker1.Value;
            }
            set
            {
                dateTimePicker1.Value = value;
            }
        }
        #endregion

        #region Methods

        #region private void Initialize()
        private void Initialize()
        {
            linkLabelLoadCurrent.Text = "Today: " + DateTime.Now.ToShortDateString();
        }
        #endregion

        #region private void InitializeComponent()
        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.buttonReloadForDate = new System.Windows.Forms.Button();
            this.linkLabelLoadCurrent = new System.Windows.Forms.LinkLabel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonApplyFilter = new System.Windows.Forms.Button();
            this.directiveFilterControl1 = new DirectiveFilterControl();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.Controls.Add(this.buttonReloadForDate);
            this.panelMain.Controls.Add(this.linkLabelLoadCurrent);
            this.panelMain.Controls.Add(this.dateTimePicker1);
            this.panelMain.Controls.Add(this.buttonApplyFilter);
            this.panelMain.Controls.Add(this.directiveFilterControl1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(49, 43);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(912, 173);
            this.panelMain.TabIndex = 1;
            // 
            // buttonReloadForDate
            // 
            this.buttonReloadForDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReloadForDate.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.buttonReloadForDate.FlatAppearance.BorderSize = 2;
            this.buttonReloadForDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReloadForDate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReloadForDate.Location = new System.Drawing.Point(432, 126);
            this.buttonReloadForDate.Name = "buttonReloadForDate";
            this.buttonReloadForDate.Size = new System.Drawing.Size(153, 44);
            this.buttonReloadForDate.TabIndex = 21;
            this.buttonReloadForDate.Text = "Reload for date";
            this.buttonReloadForDate.UseVisualStyleBackColor = true;
            this.buttonReloadForDate.Click += new System.EventHandler(this.buttonReloadForDate_Click);
            // 
            // linkLabelLoadCurrent
            // 
            this.linkLabelLoadCurrent.AutoSize = true;
            this.linkLabelLoadCurrent.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkLabelLoadCurrent.Location = new System.Drawing.Point(200, 154);
            this.linkLabelLoadCurrent.Name = "linkLabelLoadCurrent";
            this.linkLabelLoadCurrent.Size = new System.Drawing.Size(60, 16);
            this.linkLabelLoadCurrent.TabIndex = 20;
            this.linkLabelLoadCurrent.TabStop = true;
            this.linkLabelLoadCurrent.Text = "Today: ";
            this.linkLabelLoadCurrent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLoadCurrent_LinkClicked);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Location = new System.Drawing.Point(200, 126);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 27);
            this.dateTimePicker1.TabIndex = 19;
            // 
            // buttonApplyFilter
            // 
            this.buttonApplyFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApplyFilter.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.buttonApplyFilter.FlatAppearance.BorderSize = 2;
            this.buttonApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApplyFilter.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonApplyFilter.Location = new System.Drawing.Point(700, 126);
            this.buttonApplyFilter.Name = "buttonApplyFilter";
            this.buttonApplyFilter.Size = new System.Drawing.Size(126, 44);
            this.buttonApplyFilter.TabIndex = 18;
            this.buttonApplyFilter.Text = "Apply filter";
            this.buttonApplyFilter.UseVisualStyleBackColor = true;
            this.buttonApplyFilter.Click += new System.EventHandler(this.buttonApplyFilter_Click);
            // 
            // directiveFilterControl1
            // 
            this.directiveFilterControl1.AutoSize = true;
            this.directiveFilterControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.directiveFilterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.directiveFilterControl1.Location = new System.Drawing.Point(0, 0);
            this.directiveFilterControl1.Name = "directiveFilterControl1";
            this.directiveFilterControl1.Size = new System.Drawing.Size(912, 120);
            this.directiveFilterControl1.TabIndex = 0;
            // 
            // ExtendableDirectiveFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Caption = "Apply filter";
            this.MainControl = this.panelMain;
            this.Name = "ExtendableDirectiveFilterControl";
            this.Size = new System.Drawing.Size(967, 228);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region public DirectiveCollectionFilter GetDirectiveCollectionFilter()
        ///<summary>
        /// Создается фильтр коллекции директив
        ///</summary>
        ///<returns></returns>
        public DirectiveCollectionFilter GetDirectiveCollectionFilter()
        {
            return directiveFilterControl1.GetDirectiveCollectionFilter();
        }
        #endregion

        #region private void buttonApplyFilter_Click(object sender, EventArgs e)
        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            OnFilterApplying();
        }
        #endregion

        #region private void linkLabelLoadCurrent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void linkLabelLoadCurrent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }
        #endregion

        #region protected virtual void OnFilterApplying()
        /// <summary>
        /// Метод вызова события FilterApplying
        /// </summary>
        protected virtual void OnFilterApplying()
        {
            if (FilterApplying != null)
                FilterApplying(this, new EventArgs());
        }
        #endregion

        #region private void buttonReloadForDate_Click(object sender, EventArgs e)
        private void buttonReloadForDate_Click(object sender, EventArgs e)
        {
            OnReloadForDate();
        }
        #endregion

        #region protected virtual void OnReloadForDate()
        /// <summary>
        /// Вызывается событие ReloadForDateRequested
        /// </summary>
        protected virtual void OnReloadForDate()
        {
            if (ReloadForDateRequested != null)
                ReloadForDateRequested(this, new EventArgs());
        }
        #endregion

        #endregion

        /// <summary>
        /// События применения фильтра
        /// </summary>
        public event EventHandler FilterApplying;

        /// <summary>
        /// Событие запроса загрузки данных на заданное число
        /// </summary>
        public event EventHandler ReloadForDateRequested;
    }
}