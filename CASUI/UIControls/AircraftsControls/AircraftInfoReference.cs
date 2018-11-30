using System;
using System.Drawing;
using CAS.Core.Types.Aircrafts;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftsControls;

namespace CAS.UI.UIControls.AircraftsControls
{
    ///<summary>
    /// Графический элемент управления показывющий информацию о ВС
    ///</summary>
    public class AircraftInfoReference : AbstractAircraftInfoReference
    {

        #region Fields

        private readonly Aircraft currentAircraft;
        private readonly ReferenceLinkLabel linkAircraftGeneralData;

        #endregion

        #region Constructor

        /// <summary>
        /// Создается контрол отображения общей информации о воздушном судне
        /// </summary>
        public AircraftInfoReference(Aircraft aircraft)
        {
            currentAircraft = aircraft;
            InitializeComponents();
            //
            // linkAircraftGeneralData
            //
            linkAircraftGeneralData = new ReferenceLinkLabel();
            linkAircraftGeneralData.AutoSize = true;
            Css.SimpleLink.Adjust(linkAircraftGeneralData);
            linkAircraftGeneralData.Location = new Point(3, 140);
            linkAircraftGeneralData.Text = "Aircraft General Data";
            linkAircraftGeneralData.Size = new Size(150, 13);
            linkAircraftGeneralData.TabIndex = 12;
            linkAircraftGeneralData.DisplayerRequested += linkAircraftGeneralData_DisplayerRequested;
            panelMain.Controls.Add(linkAircraftGeneralData);

        }

        #endregion

        #region Methods

        #region public override void UpdateData()

        ///<summary>
        /// Обновляет информацию о ВС
        ///</summary>
        public override void UpdateData()
        {
            labelModelValue.Text = currentAircraft.Model;
            labelRegistrationNumberValue.Text = currentAircraft.RegistrationNumber;
            labelSerialNumberValue.Text = currentAircraft.SerialNumber;
            labelManufactureDateValue.Text = currentAircraft.ManufactureDate.ToString(new TermsProvider()["DateFormat"].ToString());
            if (currentAircraft.Type == AircraftType.West )
            {
                if (currentAircraft is AircraftProxy)
                {
                    AircraftProxy aircraftProxy = (AircraftProxy) currentAircraft;
                    labelCertificateNumberValue.Text = aircraftProxy.TypeCertificateNumber;
                    labelLineNumberValue.Text = aircraftProxy.LineNumber;
                    labelVariableNumberValue.Text = aircraftProxy.VariableNumber;
                }
                else
                {
                    WestAircraft westAircraft = (WestAircraft) currentAircraft;
                    labelCertificateNumberValue.Text = westAircraft.TypeCertificateNumber;
                    labelLineNumberValue.Text = westAircraft.LineNumber;
                    labelVariableNumberValue.Text = westAircraft.VariableNumber;

                }
                labelCertificateNumber.Visible = true;
                labelLineNumber.Visible = true;
                labelVariableNumber.Visible = true;
                linkAircraftGeneralData.Top = labelVariableNumber.Bottom + LINK_TOP_MARGIN;
            }
            else
            {
                labelCertificateNumber.Visible = false;
                labelLineNumber.Visible = false;
                labelVariableNumber.Visible = false;
                linkAircraftGeneralData.Top = labelManufactureDate.Bottom + LINK_TOP_MARGIN;
            }
        }

        #endregion

        #region private void linkAircraftGeneralData_DisplayerRequested(object sender, ReferenceEventArgs e)

        protected void linkAircraftGeneralData_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". Aircraft General Data";
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.RequestedEntity = new DispatcheredAircraftGeneralDataScreen(currentAircraft);;
        }

        #endregion

        #region protected override void OnEnabledChanged(EventArgs e)

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            linkAircraftGeneralData.Enabled = Enabled;
        }

        #endregion

        #endregion

    }
}
