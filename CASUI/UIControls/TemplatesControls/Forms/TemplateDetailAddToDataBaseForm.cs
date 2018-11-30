using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.Core.Types;
using CAS.Core.Types.Aircrafts;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.Core.Types.Directives.Templates;
using CAS.UI.UIControls.Auxiliary.Comparers;

namespace CAS.UI.UIControls.TemplatesControls.Forms
{
    /// <summary>
    /// ‘орма дл€ переноса шаблона агрегата (или директивы) в рабочую базу данных
    /// </summary>
    public partial class TemplateDetailAddToDataBaseForm : Form
    {

        #region Fields

        private TemplateDetail detail;
        private TemplateBaseDetailDirective directive;
        private List<Operator> operators;
        private List<Aircraft> aircrafts;
        private List<BaseDetail> baseDetails;

        #endregion

        #region Constructor

        #region public TemplateDetailAddToDataBaseForm(TemplateDetail detail)

        /// <summary>
        /// —оздает форму дл€ переноса шаблона агрегата в рабочую базу данных
        /// </summary>
        /// <param name="detail">Ўаблонный агрегат</param>
        public TemplateDetailAddToDataBaseForm(TemplateDetail detail)
        {
            this.detail = detail;
            InitializeComponent();
            comboBoxOperators.SelectedIndexChanged += comboBoxOperators_SelectedIndexChanged;
            comboBoxAircrafts.SelectedIndexChanged += comboBoxAircrafts_SelectedIndexChanged;
            UpdateComboBoxOperatorsItems();
            textBoxAmount.Text = detail.Amount.ToString();
        }

        #endregion

        #region public TemplateDetailAddToDataBaseForm(TemplateBaseDetailDirective directive)

        /// <summary>
        /// —оздает форму дл€ переноса шаблона директивы в рабочую базу данных
        /// </summary>
        /// <param name="directive">Ўаблонна€ директива</param>
        public TemplateDetailAddToDataBaseForm(TemplateBaseDetailDirective directive)
        {
            this.directive = directive;
            InitializeComponent();
            comboBoxOperators.SelectedIndexChanged += comboBoxOperators_SelectedIndexChanged;
            comboBoxAircrafts.SelectedIndexChanged += comboBoxAircrafts_SelectedIndexChanged;
            UpdateComboBoxOperatorsItems();
            textBoxAmount.Text = directive.Amount.ToString();
        }

        #endregion
        
        #endregion

        #region Methods

        #region private void UpdateComboBoxOperatorsItems()

        private void UpdateComboBoxOperatorsItems()
        {
            comboBoxOperators.Items.Clear();
            operators = new List<Operator>(OperatorCollection.Instance);
            operators.Sort(new OperatorNameComparer());
            for (int i = 0; i < OperatorCollection.Instance.Count; i++)
                comboBoxOperators.Items.Add(operators[i].Name);
            if (operators.Count > 0)
                comboBoxOperators.SelectedIndex = 0;
        }

        #endregion

        #region private void UpdateComboBoxAircraftsItems(Operator currentOperator)

        private void UpdateComboBoxAircraftsItems(Operator currentOperator)
        {
            comboBoxAircrafts.Items.Clear();
            aircrafts = new List<Aircraft>(currentOperator.AircraftCollection);
            aircrafts.Sort(new AircraftRegistrationNameComparer());
            for (int i = 0; i < currentOperator.AircraftCollection.Count; i++)
                comboBoxAircrafts.Items.Add(aircrafts[i].RegistrationNumber);

            comboBoxAircrafts.Enabled = comboBoxBaseDetails.Enabled = buttonAddTemplate.Enabled = (aircrafts.Count != 0);
            if (aircrafts.Count > 0)
                comboBoxAircrafts.SelectedIndex = 0;
        }

        #endregion

        #region private void UpdateComboBoxBaseDetailsItems(Aircraft aircraft)

        private void UpdateComboBoxBaseDetailsItems(Aircraft aircraft)
        {
            comboBoxBaseDetails.Items.Clear();
            baseDetails = new List<BaseDetail>(aircraft.BaseDetails);
            for (int i = 0; i < aircraft.BaseDetails.Length; i++)
                comboBoxBaseDetails.Items.Add(baseDetails[i]);

            comboBoxBaseDetails.Enabled = buttonAddTemplate.Enabled = (baseDetails.Count != 0);
            if (baseDetails.Count > 0)
                comboBoxBaseDetails.SelectedIndex = 0;
        }

        #endregion

        #region private void comboBoxOperators_SelectedIndexChanged(object sender, EventArgs e)

        private void comboBoxOperators_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxAircrafts.Enabled = comboBoxBaseDetails.Enabled = (comboBoxOperators.Text != "");
            UpdateComboBoxAircraftsItems(operators[comboBoxOperators.SelectedIndex]);
        }

        #endregion

        #region private void comboBoxAircrafts_SelectedIndexChanged(object sender, EventArgs e)

        private void comboBoxAircrafts_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxBaseDetails.Enabled = (comboBoxAircrafts.Text != "");
            UpdateComboBoxBaseDetailsItems(aircrafts[comboBoxAircrafts.SelectedIndex]);
        }

        #endregion

        #region private void buttonAddTemplate_Click(object sender, EventArgs e)

        private void buttonAddTemplate_Click(object sender, EventArgs e)
        {
            int amount;
            if (int.TryParse(textBoxAmount.Text, out amount))
            {
                if (detail != null)
                {
                    detail = detail.Clone();
                    detail.Amount = amount;
                    detail.TransferData(true, baseDetails[comboBoxBaseDetails.SelectedIndex].ID);
                    baseDetails[comboBoxBaseDetails.SelectedIndex].Reload(true);
                }
                else
                {
                    directive = directive.Clone();
                    directive.Amount = amount;
                    directive.TransferData(true, baseDetails[comboBoxBaseDetails.SelectedIndex].ID);
                    baseDetails[comboBoxBaseDetails.SelectedIndex].Reload(true);
                }
                Close();
            }
            else
            {
                MessageBox.Show("Invalid amout value", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        #endregion

    }
}