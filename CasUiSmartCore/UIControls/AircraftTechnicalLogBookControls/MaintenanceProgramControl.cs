using SmartCore.Entities.General.Atlbs;


namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    /// <summary>
    /// Контрол выводит информацию о чеках воздушного судна
    /// </summary>
    public partial class MaintenanceProgramControl : Interfaces.EditObjectControl
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
            if (Flight != null && Flight.AircraftId > 0)
            {
                //if (Flight.Aircraft.MaintenanceDirective.Limitations[0].CheckType == MaintenanceCheckTypesCollection.Instance.
            }
            EndUpdate();
        }
        #endregion

        
    }
}

