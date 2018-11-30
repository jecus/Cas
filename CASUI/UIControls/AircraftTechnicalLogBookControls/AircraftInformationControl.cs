using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CAS.Core.Types.ATLBs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    /// <summary>
    /// Контрол выводит информацию о воздушном судне
    /// </summary>
    public partial class AircraftInformationControl : CAS.UI.Interfaces.EditObjectControl
    {

        #region public AircraftFlight Flight
        /// <summary>
        /// Полет, с которым связан контрол
        /// </summary>
        public AircraftFlight Flight
        {
            get { return AttachedObject as AircraftFlight; }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public AircraftInformationControl()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public AircraftInformationControl()
        {
            InitializeComponent();
        }
        #endregion 
        
        /*
         * Перегружаемые методы
         */

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {
            BeginUpdate();
            if (Flight != null && Flight.Aircraft != null)
            {
                textCompany.Text = Flight.Aircraft.Operator.Name + ", " + Flight.Aircraft.Operator.ICAOCode;
                textAircraft.Text = Flight.Aircraft.RegistrationNumber;
                textModel.Text = Flight.Aircraft.Model;
            }
            else
            {
                textCompany.Text = textAircraft.Text = textModel.Text = "";
            }
            EndUpdate();
        }
        #endregion


    }
}

