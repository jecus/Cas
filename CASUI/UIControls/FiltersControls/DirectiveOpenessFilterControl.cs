using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Appearance;
using CAS.UI.UIControls.FiltersControls;

namespace CAS.UI.UIControls.FiltersControls
{
    /// <summary>
    /// Класс, описывающий отображение фильтра открытости директив
    /// </summary>
    public class DirectiveOpenessFilterControl : UserControl, IFilterControl
    {
        #region Fields

        private CheckBox checkBoxClosedAppliance;
        private GroupBox groupBox1;
        private CheckBox checkBox1;
        private CheckBox checkBoxOpenAppliance;
        #endregion

        #region Constructors
        /// <summary>
        /// Создается объект отображения фильтра открытости директив
        /// </summary>
        public DirectiveOpenessFilterControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        #region public bool FilterAppliance
        ///<summary>
        /// Применимость фильтра
        ///</summary>
        public bool FilterAppliance
        {
            get
            {
                return ((!checkBox1.Checked )| (!checkBoxClosedAppliance.Checked)|(!checkBoxOpenAppliance.Checked) );
            }
            set
            {
            }
        }
        #endregion

        #region public bool ClosedAppliance
        /// <summary>
        /// Применимость закратых директив
        /// </summary>
        public bool ClosedAppliance
        {
            get { return checkBoxClosedAppliance.Checked; }
            set { checkBoxClosedAppliance.Checked = value; }
        }
        #endregion

        #region public bool OpenAppliance
        /// <summary>
        /// Применимость открытых директив
        /// </summary>
        public bool OpenAppliance
        {
            get { return checkBoxOpenAppliance.Checked; }
            set { checkBoxOpenAppliance.Checked = value; }
        }
        #endregion

        #region public bool OpenRepeatedAppliance
        /// <summary>
        /// Применимость повтрояемых директив
        /// </summary>
        public bool RepeatableAppliance
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }
        #endregion


        #endregion

        #region Methods

        #region public IFilter GetFilter()

        ///<summary>
        /// Создание фильтра по заданному состоянию
        ///</summary>
        ///<returns>Созданный фильтр</returns>
        public IFilter GetFilter()
        {
            return new DirectiveOpenessFilter(OpenAppliance, RepeatableAppliance, ClosedAppliance);
        }

        #endregion

        #region public void SetFilterParameters(IFilter filter)

        /// <summary>
        /// Задаются параметры фильтра
        /// </summary>
        /// <param name="filter">Источник параметров фильтра</param>
        public void SetFilterParameters(IFilter filter)
        {
            if (filter is DirectiveOpenessFilter)
            {
                DirectiveOpenessFilter directiveOpenessFilter = (DirectiveOpenessFilter) filter;
                OpenAppliance = directiveOpenessFilter.OpenAppliance;
                ClosedAppliance = directiveOpenessFilter.CloseAcceptance;
                RepeatableAppliance = directiveOpenessFilter.RepeatableAppliance;
            }
        }

        #endregion
        
        #region private void InitializeComponent()
        private void InitializeComponent()
        {
            checkBoxClosedAppliance = new CheckBox();
            checkBoxOpenAppliance = new CheckBox();
            groupBox1 = new GroupBox();
            checkBox1 = new CheckBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // checkBoxClosedAppliance
            // 
            checkBoxClosedAppliance.AutoSize = true;
            checkBoxClosedAppliance.Checked = true;
            checkBoxClosedAppliance.CheckState = CheckState.Checked;
            checkBoxClosedAppliance.Location = new Point(296, 22);
            checkBoxClosedAppliance.Name = "checkBoxClosedAppliance";
            checkBoxClosedAppliance.Size = new Size(65, 20);
            checkBoxClosedAppliance.TabIndex = 3;
            checkBoxClosedAppliance.Text = "Closed";
            checkBoxClosedAppliance.UseVisualStyleBackColor = true;
            // 
            // checkBoxOpenAppliance
            // 
            checkBoxOpenAppliance.AutoSize = true;
            checkBoxOpenAppliance.Checked = true;
            checkBoxOpenAppliance.CheckState = CheckState.Checked;
            checkBoxOpenAppliance.Location = new Point(22, 22);
            checkBoxOpenAppliance.Name = "checkBoxOpenAppliance";
            checkBoxOpenAppliance.Size = new Size(57, 20);
            checkBoxOpenAppliance.TabIndex = 1;
            checkBoxOpenAppliance.Text = "Open";
            checkBoxOpenAppliance.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(checkBoxOpenAppliance);
            groupBox1.Controls.Add(checkBoxClosedAppliance);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(351, 53);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Status";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(149, 22);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(91, 20);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Repeatable";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // DirectiveOpenessFilterControl
            // 
            AutoSize = true;
            BackColor = Color.Transparent;
            Controls.Add(groupBox1);
            Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Name = "DirectiveOpenessFilterControl";
            Size = new Size(351, 53);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);

        }
        #endregion

        #region protected override void OnLoad(EventArgs e)

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.UserControl.Load"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Css.OrdinaryText.Adjust(this);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;

            checkBoxOpenAppliance.FlatStyle = FlatStyle.Flat;
            checkBoxOpenAppliance.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;

            checkBox1.FlatStyle = FlatStyle.Flat;
            checkBox1.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;

            checkBoxClosedAppliance.FlatStyle = FlatStyle.Flat;
            checkBoxClosedAppliance.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
        }

        #endregion

        #region public void ClearFilter()
        /// <summary>
        /// Происходит отчистка филтра
        /// </summary>
        public void ClearFilter()
        {
            checkBoxOpenAppliance.Checked = true;
            checkBoxClosedAppliance.Checked = true;
            checkBox1.Checked = true;
        }
        #endregion

        #endregion

    }
}