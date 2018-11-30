using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using CAS.Core.Core.Exceptions;
using CAS.Core.Types;
using CAS.Core.Types.Aircrafts;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary.Comparers;

namespace CAS.UI.UIControls.TemplatesControls.Forms
{
    /// <summary>
    /// Форма для переноса шаблона базового агрегата в рабочую базу данных
    /// </summary>
    public partial class TemplateBaseDetailAddToDataBaseForm : Form
    {

        #region Fields

        private AnimatedThreadWorker animatedThreadWorker;
        private TemplateBaseDetail baseDetail;
        private List<Operator> operators;
        private List<Aircraft> aircrafts;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает форму для переноса шаблона базового агрегата в рабочую базу данных
        /// </summary>
        /// <param name="baseDetail"></param>
        public TemplateBaseDetailAddToDataBaseForm(TemplateBaseDetail baseDetail)
        {
            this.baseDetail = baseDetail;
            InitializeComponent();
            this.comboBoxOperators.SelectedIndexChanged += comboBoxOperators_SelectedIndexChanged;
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
                baseDetail =  baseDetail.Clone();
                baseDetail.Amount = amount;

                Enabled = false;
                animatedThreadWorker = new AnimatedThreadWorker(CreateBaseDetailFromTemplate, null, this);
                animatedThreadWorker.State = "Creating " + baseDetail.PartNumber;
                animatedThreadWorker.StartThread();
                
                animatedThreadWorker.WorkFinished+=FinishedCreatingBaseDetail;
                
            }
            else
            {
                MessageBox.Show("Invalid amout value", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        #endregion

        private void FinishedCreatingBaseDetail(object sender, EventArgs e)
        {
            Enabled = true;

            Boolean success = (Boolean)animatedThreadWorker.Result;
            if (success)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }



        private void CreateBaseDetailFromTemplate(Object state, out Object result)
        {
            try
            {
                Int32 [] transferedBaseDetailsIDs = Program.Presenters.DetailsPresenter.TransferTemplateBaseDetailToAircraft(baseDetail, aircrafts[comboBoxAircrafts.SelectedIndex]);
                if (transferedBaseDetailsIDs.Length == 0) throw new TransferException();
                aircrafts[comboBoxAircrafts.SelectedIndex].Reload(true);                
            }
            catch (TransferException transferException)
            {
                Program.Provider.Logger.Log(transferException.Message, transferException);
                result = false;
                return;
            }
            catch (LoadingException loadingException)
            {
                Program.Provider.Logger.Log(loadingException.Message, loadingException);
                result = false;
                return;
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while creation of baseDetail", ex);
                result = false;
                return;
            }

            result = true;
        }

        #endregion

    }
}