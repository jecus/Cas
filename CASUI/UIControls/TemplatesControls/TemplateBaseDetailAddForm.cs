using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LTR.Core;
using LTR.Core.ProjectTerms;
using LTR.Core.Types.Aircrafts.Parts.Templates;
using LTR.UI.UIControls.Auxiliary.Comparers;

namespace LTR.UI.UIControls.TemplatesControls
{
    public partial class TemplateBaseDetailAddForm : Form
    {

        #region Fields

        private readonly TemplateBaseDetail baseDetail;
        private List<Operator> operators;
        private List<Aircraft> aircrafts;

        #endregion

        #region Constructor

        public TemplateBaseDetailAddForm(TemplateBaseDetail baseDetail)
        {
            this.baseDetail = baseDetail;
            InitializeComponent();
            UpdateComboBoxOperatorsItems();
            textBoxAmount.Text = baseDetail.Amount.ToString();
        }

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

            comboBoxAircrafts.Enabled = buttonAddTemplate.Enabled = (aircrafts.Count != 0);
            if (aircrafts.Count > 0)
                comboBoxAircrafts.SelectedIndex = 0;
        }

        #endregion

        #region private void comboBoxOperators_SelectedIndexChanged(object sender, EventArgs e)

        private void comboBoxOperators_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxAircrafts.Enabled = (comboBoxOperators.Text != "");
            UpdateComboBoxAircraftsItems(operators[comboBoxOperators.SelectedIndex]);
        }

        #endregion

        #region private void buttonAddTemplate_Click(object sender, EventArgs e)

        private void buttonAddTemplate_Click(object sender, EventArgs e)
        {
            int amount;
            if (int.TryParse(textBoxAmount.Text, out amount))
            {
                baseDetail.UserAmount = amount;
                baseDetail.TransferData(true, aircrafts[comboBoxAircrafts.SelectedIndex].ID);
                aircrafts[comboBoxAircrafts.SelectedIndex].Reload(true); //todo или сделать метод у Aircraft ReloadBaseDetails
                Close();
            }
            else
            {
                MessageBox.Show("Invalid amout value", (string)new StaticProjectTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        #endregion

    }
}