using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftsControls;
using CAS.UI.UIControls.AircraftsControls;
using CAS.UI.UIControls.TemplatesControls.Forms;

namespace CAS.UI.UIControls.TemplatesControls
{
    /// <summary>
    /// Элемент управления для отображения общей информации о шаблонном ВС
    /// </summary>
    public class TemplateAircraftInfoReference : AbstractAircraftInfoReference
    {

        #region Fields

        private readonly TemplateAircraft currentAircraft;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения общей информации о шаблонном ВС
        /// </summary>
        /// <param name="aircraft"></param>
        public TemplateAircraftInfoReference(TemplateAircraft aircraft)
        {
            currentAircraft = aircraft;
            InitializeComponents();
        }

        #endregion

        #region Methods

        #region public override void UpdateData()

        ///<summary>
        /// Обновляет информацию о шаблонном ВС
        ///</summary>
        public override void UpdateData()
        {
            labelModelValue.Text = currentAircraft.Model;
            labelCertificateNumberValue.Text = currentAircraft.TypeCertificateNumber;
            labelLineNumberValue.Text = currentAircraft.LineNumber;
            labelVariableNumberValue.Text = currentAircraft.VariableNumber;
            
            labelCertificateNumber.Top = labelModel.Bottom;
            labelCertificateNumberValue.Top = labelModelValue.Bottom;
            labelLineNumber.Top = labelCertificateNumber.Bottom;
            labelLineNumberValue.Top = labelCertificateNumberValue.Bottom;
            labelVariableNumber.Top = labelLineNumber.Bottom;
            labelVariableNumberValue.Top = labelLineNumberValue.Bottom;
            labelRegistrationNumber.Visible = labelRegistrationNumberValue.Visible = false;
            labelSerialNumber.Visible = labelSerialNumberValue.Visible = false;
            labelManufactureDate.Visible = labelManufactureDateValue.Visible = false;
        }

        #endregion

        #region private void buttonAddTemplate_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonAddTemplate_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            TemplateAircraftAddToDataBaseForm form = new TemplateAircraftAddToDataBaseForm(currentAircraft);
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.ScreensToOpening == ScreensToOpening.OpenAircraftScreen)
                {
                    e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                    e.DisplayerText = form.Operator.Name;
                    e.RequestedEntity = new DispatcheredAircraftCollectionScreen(form.Operator);
                }
                else if (form.ScreensToOpening == ScreensToOpening.EditAircraftGeneralData)
                {
                    e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                    e.DisplayerText = form.Operator.Name;
                    e.RequestedEntity = new DispatcheredAircraftCollectionScreen(form.Operator);
                }
                else
                    e.Cancel = true;
            }
            else
                e.Cancel = true;
        }

        #endregion

        #endregion

    }
}
