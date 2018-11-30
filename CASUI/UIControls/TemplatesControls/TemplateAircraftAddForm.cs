using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LTR.Core;
using LTR.Core.ProjectTerms;
using LTR.Core.Types.Aircrafts;
using LTR.UI.UIControls.Auxiliary.Comparers;

namespace LTR.UI.UIControls.TemplatesControls
{
    public partial class TemplateAircraftAddForm : Form
    {

        #region Fields

        private readonly TemplateAircraft aircraft;
        private List<Operator> operators;

        #endregion

        #region Constructor

        public TemplateAircraftAddForm(TemplateAircraft aircraft)
        {
            this.aircraft = aircraft;
            InitializeComponent();
            UpdateComboBoxItems();
            textBoxAmount.Text = aircraft.Amount.ToString();
        }

        #endregion

        #region Methods

        #region private void UpdateComboBoxItems()

        private void UpdateComboBoxItems()
        {
            comboBoxOperators.Items.Clear();
            operators = new List<Operator>(OperatorCollection.Instance);
            operators.Sort(new OperatorNameComparer());
            for (int i = 0; i < OperatorCollection.Instance.Count; i++)
            {
                comboBoxOperators.Items.Add(operators[i].Name);
            }

            buttonAddTemplate.Enabled = (operators.Count != 0);
            if (operators.Count > 0)
                comboBoxOperators.SelectedIndex = 0;
        }

        #endregion

        #region private void buttonAddTemplate_Click(object sender, EventArgs e)

        private void buttonAddTemplate_Click(object sender, EventArgs e)
        {
            int amount;
            if (int.TryParse(textBoxAmount.Text, out amount))
            {
                aircraft.UserAmount = amount;
                aircraft.TransferData(true, operators[comboBoxOperators.SelectedIndex].ID );
                operators[comboBoxOperators.SelectedIndex].AircraftCollection.Reload(true);
                Close();
            }
            else
            {
                MessageBox.Show("Invalid amout value", (string) new StaticProjectTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        #endregion

    }
}