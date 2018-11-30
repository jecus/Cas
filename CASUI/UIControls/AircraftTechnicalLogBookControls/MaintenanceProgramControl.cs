using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CAS.Core.Types.ATLBs;
using CAS.Core.Types.Directives;
using CAS.Core.Types.Dictionaries;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    /// <summary>
    /// Контрол выводит информацию о чеках воздушного судна
    /// </summary>
    public partial class MaintenanceProgramControl : CAS.UI.Interfaces.EditObjectControl
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

        #region public MaintenanceProgramControl()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public MaintenanceProgramControl()
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
                //if (Flight.Aircraft.MaintenanceDirective.Limitations[0].CheckType == MaintenanceCheckTypesCollection.Instance.
            }
            else
            {
            }
            EndUpdate();
        }
        #endregion

        
    }
}

