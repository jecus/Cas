using System.Windows.Forms;
using LTR.Core.Types.Aircrafts.Parts;

namespace LTR.UI.UIControls.AircraftsControls
{
    /// <summary>
    /// Класс, предназначенный для отображения информации о двигателе ВС
    /// </summary>
    public partial class UIAircraftEngineReports : UserControl
    {
        
        #region Constructor

        /// <summary>
        /// Создает новый объект для отображения двигателя ВС
        /// </summary>
        /// <param name="engine"></param>
        public UIAircraftEngineReports(Engine engine)
        {
            InitializeComponent();
            currentEngine = engine;
            label1.Text += " " + engine.SerialNumber;
        }

        #endregion
        
        #region Fields

        private readonly Engine currentEngine;

        #endregion

        #region Properties

        #region public Engine CurrentEngine

        /// <summary>
        /// Возвращает отображаемый двигатель
        /// </summary>
        public Engine CurrentEngine
        {
            get { return currentEngine; }
        }

        #endregion

        #endregion

    }
}
