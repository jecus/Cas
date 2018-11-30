using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.UIControls.AircraftsControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftsControls
{
    /// <summary>
    /// Класс описывающий отображение <see cref="BaseDetailControl"/>, управляемое Dispatcher ом
    /// </summary>
    public class DispatcheredAircraftBaseDetailInfoControl : BaseDetailControl
    {

        #region Constructors

        #region public DispatcheredAircraftBaseDetailInfoControl(BaseDetail item)
        /// <summary>
        /// Создается элемент - отображение <see cref="BaseDetailControl"/>, управляемое Dispatcher ом
        /// </summary>
        /// <param name="item">Отображаемый элемент</param>
        public DispatcheredAircraftBaseDetailInfoControl(BaseDetail item) : base(item)
        {
            InitializeControl();
        }
        #endregion

        #region public DispatcheredAircraftBaseDetailInfoControl(APU apu)
        /// <summary>
        /// Создается элемент - отображение <see cref="BaseDetailControl"/>, управляемое Dispatcher ом
        /// </summary>
        /// <param name="apu">Отображаемый элемент</param>
        public DispatcheredAircraftBaseDetailInfoControl(APU apu) : base(apu)
        {
            InitializeControl();
        }
        #endregion

        #region public DispatcheredAircraftBaseDetailInfoControl(Engine engine)
        /// <summary>
        /// Создается элемент - отображение <see cref="BaseDetailControl"/>, управляемое Dispatcher ом
        /// </summary>
        /// <param name="engine">Отображаемый элемент</param>
        public DispatcheredAircraftBaseDetailInfoControl(Engine engine) : base(engine)
        {
            InitializeControl();
        }
        #endregion

        #region public DispatcheredAircraftBaseDetailInfoControl(Engine engine, int engineNumber)
        /// <summary>
        /// Создается элемент - отображение <see cref="BaseDetailControl"/>, управляемое Dispatcher ом
        /// </summary>
        /// <param name="engine">Отображаемый элемент</param>
        /// <param name="engineNumber"></param>
        public DispatcheredAircraftBaseDetailInfoControl(Engine engine, int engineNumber) : base(engine)
        {
            InitializeControl();
        }
        #endregion

        #region public DispatcheredAircraftBaseDetailInfoControl(AircraftFrame aircraftFrame)
        /// <summary>
        /// Создается элемент - отображение <see cref="BaseDetailControl"/>, управляемое Dispatcher ом
        /// </summary>
        /// <param name="aircraftFrame">Отображаемый элемент</param>
        public DispatcheredAircraftBaseDetailInfoControl(AircraftFrame aircraftFrame) : base(aircraftFrame)
        {
            InitializeControl();
        }
        #endregion

        #endregion

        private void InitializeControl()
        {
            //baseDetailButton.Click += aircraftButton_Click;
            //aircraftButton.DisplayerRequested += aircraftButton_DisplayerRequested;
        }

/*        private void aircraftButton_Click(object sender, EventArgs e)
        {
            string newTabText = aircraftButton.Text + ": " + currentBaseDetail.SerialNumber;
            ReferenceEventArgs eventArgs = new ReferenceEventArgs(
                new DispathceredBaseDetailContainedDetailView(currentBaseDetail), ReflectionTypes.DisplayInNew, newTabText);
            OnDisplayerReauested(eventArgs);
        }*/
    }
}
