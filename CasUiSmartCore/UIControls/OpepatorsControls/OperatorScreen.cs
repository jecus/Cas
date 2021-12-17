using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.OpepatorsControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class OperatorScreen : ScreenControl
    {
        #region Fields

        /// <summary>
        /// Текущий эксплуатант
        /// </summary>
        private Operator CurrentOperator;

        #endregion

        #region Constructors
     
        #region public OperatorScreen()
        ///<summary>
        ///</summary>
        public OperatorScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public OperatorScreen(Operator currentOperator)
        ///<summary>
        /// Создаёт экземпляр элемента управления, отображающего список директив
        ///</summary>
        ///<param name="currentOperator">ВС, которому принадлежат директивы</param>
        public OperatorScreen(Operator currentOperator) : this()
        {
            if (currentOperator == null)
                throw new ArgumentNullException("currentOperator");
            aircraftHeaderControl1.Operator = currentOperator;
            CurrentOperator = currentOperator;
            statusControl.ShowStatus = false;
            UpdateInformation();
        }

        #endregion

        #endregion

        #region Methods

        #region private void UpdateInformation()
        /// <summary>
        /// Происзодит обновление отображения элементов
        /// </summary>
        private void UpdateInformation()
        {
            if(CurrentOperator == null)return;

            OperatorControl.CurrentOperator = CurrentOperator;
        }

        #endregion

        #region private bool Save()

        private bool Save()
        {
            if (OperatorControl.OperatorName == "")
            {
                MessageBox.Show("Please fill operator name", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (OperatorControl.GetChangeStatus())
            {
                OperatorControl.SaveData();

                try
                {
                        GlobalObjects.NewKeeper.Save(CurrentOperator);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while saving data", ex);
                    return false;
                }

                MessageBox.Show("Saving was successful", "Message infomation", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            }
            return true;
        }

        #endregion

        #region private void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //if (currentAircraft != null)
            //    e.DisplayerText = currentAircraft.RegistrationNumber + ". " + ReportText + " Report";
            //else if (currentBaseDetail != null)
            //    e.DisplayerText = currentBaseDetail + ". " + ReportText + " Report";
            //else
            //    e.DisplayerText = ReportText + " Report";
            //e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            //_reportBuilder.DateAsOf = DateTime.Today.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            //if (currentAircraft != null)
            //{
            //    /*
            //                    reportBuilder.LifelengthAircraftSinceNew = CurrentAircraft.Limitation.ResourceSinceNew;
            //                    reportBuilder.LifelengthAircraftSinceOverhaul = CurrentAircraft.Limitation.ResourceSinceOverhaul;
            //    */

            //    if (true)
            //        _reportBuilder.IsFiltered = true;
            //    _reportBuilder.ReportedAircraft = CurrentAircraft;

            //    e.RequestedEntity = new DispatcheredOutOfPhaseItemListReport((OutOfPhaseItem[])_directivesViewer.GetItemsArray(), _reportBuilder);
            //}
            //else
            //{
            //    if (currentBaseDetail != null)
            //    {
            //        /*    CurrentAircraft.DateAsOf = filterSelection.DateSelected;
            //        CurrentAircraft.ProvideCurrentData = false;*/
            //        //todo

            //        //reportBuilder.LifelengthAircraftSinceNew = CurrentAircraft.Limitation.ResourceSinceNew;
            //        _reportBuilder.LifelengthAircraftSinceNew =
            //            GlobalObjects.CasEnvironment.Calculator.GetClosingFlightLifelength(CurrentAircraft, dateSelected);
            //        //reportBuilder.LifelengthAircraftSinceOverhaul = CurrentAircraft.Limitation.ResourceSinceOverhaul;


            //        if (true)
            //            _reportBuilder.IsFiltered = true;
            //        _reportBuilder.ReportedBaseDetail = currentBaseDetail;
            //        e.RequestedEntity =
            //            new DispatcheredOutOfPhaseItemListReport((OutOfPhaseItem[])_directivesViewer.GetItemsArray(), _reportBuilder);
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //    }
            //}
        }

        #endregion

        #region private void HeaderControl1ReloadRised(object sender, EventArgs e)

        private void HeaderControl1ReloadRised(object sender, EventArgs e)
        {
            if (OperatorControl.GetChangeStatus())
            {
                if (MessageBox.Show("All unsaved data will be lost. Are you sure you want to continue?", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    OperatorControl.UpdateInformation();
                }
            }
            else
            {
                OperatorControl.UpdateInformation();
            }
        }

        #endregion

        #region private void HeaderControlSaveClicked(object sender, EventArgs e)

        private void HeaderControlSaveClicked(object sender, EventArgs e)
        {
           if (Save())
              UpdateInformation();
        }

        #endregion

        #region private void buttonDeleteOperator_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonDeleteOperator_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete current operator?", "Confirm deleting", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {

                try
                {
                    //OperatorCollection.Instance.Remove(currentOperator);
                    MessageBox.Show("Operator was deleted successfully", "Operator deleted",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex); e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion

        #endregion

        #region Events

        #endregion
    }
}
