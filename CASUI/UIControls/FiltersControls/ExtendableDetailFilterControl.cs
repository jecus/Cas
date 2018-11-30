using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.ReportFilters;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.ReferenceControls;

namespace CAS.UI.UIControls.FiltersControls
{
    /// <summary>
    /// Класс, описывающий расширяемый фильтр коллекции агрегатов
    /// </summary>
    public class ExtendableDetailFilterControl:ExtendableRichContainer
    {
        private DetailFilterControl detailFilterControl1;
        private Button buttonReloadForDate;
        private LinkLabel linkLabelLoadCurrent;
        private DateTimePicker dateTimePicker1;
        private Button buttonApplyFilter;
        private Panel panelMain;

        /// <summary>
        /// Создается расширяемый фильтр коллекции агрегатов
        /// </summary>
        public ExtendableDetailFilterControl()
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
            panelMain = new Panel();
            detailFilterControl1 = new DetailFilterControl();
            linkLabelLoadCurrent = new LinkLabel();
            dateTimePicker1 = new DateTimePicker();
            buttonApplyFilter = new Button();
            buttonReloadForDate = new Button();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.AutoSize = true;
            panelMain.Controls.Add(buttonReloadForDate);
            panelMain.Controls.Add(linkLabelLoadCurrent);
            panelMain.Controls.Add(dateTimePicker1);
            panelMain.Controls.Add(buttonApplyFilter);
            panelMain.Controls.Add(detailFilterControl1);
            panelMain.Dock = DockStyle.Top;
            panelMain.Location = new Point(49, 43);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(912, 214);
            panelMain.TabIndex = 1;
            // 
            // detailFilterControl1
            // 
            detailFilterControl1.AutoSize = true;
            detailFilterControl1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            detailFilterControl1.Dock = DockStyle.Top;
            detailFilterControl1.Location = new Point(0, 0);
            detailFilterControl1.Name = "detailFilterControl1";
            detailFilterControl1.Size = new Size(912, 158);
            detailFilterControl1.TabIndex = 0;
            // 
            // linkLabelLoadCurrent
            // 
            linkLabelLoadCurrent.AutoSize = true;
            linkLabelLoadCurrent.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            linkLabelLoadCurrent.Location = new Point(197, 195);
            linkLabelLoadCurrent.Name = "linkLabelLoadCurrent";
            linkLabelLoadCurrent.Size = new Size(60, 16);
            linkLabelLoadCurrent.TabIndex = 20;
            linkLabelLoadCurrent.TabStop = true;
            linkLabelLoadCurrent.Text = "Today: ";
            linkLabelLoadCurrent.LinkClicked += linkLabelLoadCurrent_LinkClicked;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dateTimePicker1.Location = new Point(197, 167);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 27);
            dateTimePicker1.TabIndex = 19;
            // 
            // buttonApplyFilter
            // 
            buttonApplyFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonApplyFilter.FlatAppearance.BorderColor = Color.CornflowerBlue;
            buttonApplyFilter.FlatAppearance.BorderSize = 2;
            buttonApplyFilter.FlatStyle = FlatStyle.Flat;
            buttonApplyFilter.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonApplyFilter.Location = new Point(697, 167);
            buttonApplyFilter.Name = "buttonApplyFilter";
            buttonApplyFilter.Size = new Size(126, 44);
            buttonApplyFilter.TabIndex = 18;
            buttonApplyFilter.Text = "Apply filter";
            buttonApplyFilter.UseVisualStyleBackColor = true;
            buttonApplyFilter.Click += buttonApplyFilter_Click;
            // 
            // buttonReloadForDate
            // 
            buttonReloadForDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonReloadForDate.FlatAppearance.BorderColor = Color.CornflowerBlue;
            buttonReloadForDate.FlatAppearance.BorderSize = 2;
            buttonReloadForDate.FlatStyle = FlatStyle.Flat;
            buttonReloadForDate.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonReloadForDate.Location = new Point(429, 167);
            buttonReloadForDate.Name = "buttonReloadForDate";
            buttonReloadForDate.Size = new Size(153, 44);
            buttonReloadForDate.TabIndex = 21;
            buttonReloadForDate.Text = "Reload for date";
            buttonReloadForDate.UseVisualStyleBackColor = true;
            buttonReloadForDate.Click += buttonReloadForDate_Click;
            // 
            // ExtendableDetailFilterControl
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            Caption = "Apply filter";
            MainControl = panelMain;
            Name = "ExtendableDetailFilterControl";
            Size = new Size(967, 269);
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion

        #region public DetailCollectionFilter GetDetailCollectionFilter()
        ///<summary>
        /// Создается фильтр коллекции агрегатов
        ///</summary>
        ///<returns></returns>
        public DetailCollectionFilter GetDetailCollectionFilter()
        {
            return detailFilterControl1.GetDetailCollectionFilter();
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
            if(FilterApplying != null)
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