using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.DirectivesControls
{
    /// <summary>
    /// Элемент управления для задания Applicability для директивы
    /// </summary>
    public class DirectiveApplicabilityControl : UserControl
    {
        
        #region Fields

        private readonly Operator currentOperator;
        private readonly Aircraft currentAircraft;
        private readonly List<CheckBox> checkBoxsAircrafts = new List<CheckBox>();
        private readonly List<ComboBox> comboBoxsWorkType = new List<ComboBox>();
        private FlowLayoutPanel flowLayoutPanelItems;
        private const int MARGIN = 10;
        private const int CHECK_BOX_HEIGHT = 25;
        private const int CHECK_BOX_WIDTH = 120;
        private const int COMBO_BOX_WIDTH = 150;
        private const int HEIGHT_INTERVAL = 15;

        private readonly string OPEN_STATUS = "Open";
        private readonly string NOT_APPLICABLE_STATUS = "Not Applicable";
        private readonly string TERMINATED_STATUS = "Terminated";
        private readonly string CLOSED_STATUS = "Closed";

        #endregion

        #region Constructor

        /// <summary>
        /// Создает эелемент управления для задания Applicability для директивы
        /// </summary>
        /// <param name="aircraft"></param>
        public DirectiveApplicabilityControl(Aircraft aircraft)
        {
            currentOperator = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == aircraft.OperatorId);
            currentAircraft = aircraft;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelItems = new FlowLayoutPanel();
            flowLayoutPanelItems.AutoSize = true;
            flowLayoutPanelItems.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelItems.MinimumSize = new Size(1200, 0);
            flowLayoutPanelItems.MaximumSize = new Size(1200, 1000);
            Controls.Add(flowLayoutPanelItems);
            ClearFields();
        }

        #endregion

        #region Properties

        #region public List<ApplicabilityItem> ApplicabilityItems

        /// <summary>
        /// Возвращает список ВС, к которым применяется директива
        /// </summary>
        public List<ApplicabilityItem> ApplicabilityItems
        {
            get
            {
                List<ApplicabilityItem> items = new List<ApplicabilityItem>();
                for (int i = 0; i < checkBoxsAircrafts.Count; i++)
                {
                    if (checkBoxsAircrafts[i].Checked)
                    {
                        ApplicabilityItem item = new ApplicabilityItem();
                        item.Aircraft = (Aircraft) checkBoxsAircrafts[i].Tag;
                        item.RecordType = GetRecordType(comboBoxsWorkType[i].Text);
                        items.Add(item);
                    }
                }
                return items;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            flowLayoutPanelItems.Controls.Clear();
            checkBoxsAircrafts.Clear();
            comboBoxsWorkType.Clear();
	        var aircrafts = GlobalObjects.AircraftsCore.GetAllAircrafts();

			for (int i = 0; i < aircrafts.Count; i++)
            {
                //
                // checkBox
                //
                CheckBox checkBox = new CheckBox();
                checkBox.Font = Css.OrdinaryText.Fonts.RegularFont;
                checkBox.ForeColor = Css.OrdinaryText.Colors.ForeColor;
                checkBox.Text = aircrafts[i].RegistrationNumber;
                checkBox.Size = new Size(CHECK_BOX_WIDTH, CHECK_BOX_HEIGHT);
                //checkBox.Location = new Point(MARGIN, MARGIN + i * (CHECK_BOX_HEIGHT + HEIGHT_INTERVAL));
                checkBox.Location = new Point(MARGIN, MARGIN);
                checkBox.Tag = aircrafts[i];
                checkBox.Checked = true;
                if (aircrafts[i].ItemId == currentAircraft.ItemId)
                    checkBox.Enabled = false;
                //
                // comboBox
                //
                ComboBox comboBox = new ComboBox();
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.Font = Css.OrdinaryText.Fonts.RegularFont;
                comboBox.ForeColor = Css.OrdinaryText.Colors.ForeColor;
                comboBox.Items.Add(OPEN_STATUS);
                comboBox.Items.Add(NOT_APPLICABLE_STATUS);
                comboBox.Items.Add(TERMINATED_STATUS);
                comboBox.Items.Add(CLOSED_STATUS);
                comboBox.Size = new Size(COMBO_BOX_WIDTH, CHECK_BOX_HEIGHT);
                //comboBox.Location = new Point(MARGIN + CHECK_BOX_WIDTH, MARGIN + i * (CHECK_BOX_HEIGHT + HEIGHT_INTERVAL));
                comboBox.Location = new Point(MARGIN + CHECK_BOX_WIDTH, MARGIN);
                comboBox.SelectedIndex = 0;

                Panel panel = new Panel();
                panel.AutoSize = true;
                panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                panel.Controls.Add(checkBox);
                panel.Controls.Add(comboBox);

                checkBoxsAircrafts.Add(checkBox);
                comboBoxsWorkType.Add(comboBox);

                flowLayoutPanelItems.Controls.Add(panel);
            }
        }

        #endregion

        #region private RecordType GetRecordType(string recordTypeName)

        private DirectiveRecordType GetRecordType(string recordTypeName)
        {
            if (recordTypeName == OPEN_STATUS)
                return null;
            else if (recordTypeName == NOT_APPLICABLE_STATUS)
                return DirectiveRecordType.NotApplicable;
            else if (recordTypeName == TERMINATED_STATUS)
                return DirectiveRecordType.Terminated;
            else
                return DirectiveRecordType.Closed;
        }

        #endregion

        #region public bool GetChangeStatus(bool directiveExist)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        public bool GetChangeStatus()
        {
            for (int i = 0; i < checkBoxsAircrafts.Count; i++)
            {
                if (!checkBoxsAircrafts[i].Checked)
                    return true;
                if (comboBoxsWorkType[i].SelectedIndex != 0)
                    return true;
            }
            return false;
        }

        #endregion

        #endregion

    }

    /// <summary>
    /// Класс для хранения ВС и статуса добавляемой директивы
    /// </summary>
    public class ApplicabilityItem
    {
        #region Fields

        private Aircraft aircraft;
        private DirectiveRecordType recordType;

        #endregion

        #region Properties

        #region public Aircraft Aircraft

        /// <summary>
        /// Возвращает или устанавливает ВС
        /// </summary>
        public Aircraft Aircraft
        {
            get { return aircraft; }
            set { aircraft = value; }
        }

        #endregion

        #region public RecordType RecordType

        /// <summary>
        /// Возвращает или устанавливает 
        /// </summary>
        public DirectiveRecordType RecordType
        {
            get { return recordType; }
            set { recordType = value; }
        }

        #endregion

        #endregion

    }
}
