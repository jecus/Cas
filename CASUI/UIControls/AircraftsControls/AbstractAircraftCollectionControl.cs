using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Management;

namespace CAS.UI.UIControls.AircraftsControls
{
    /// <summary>
    /// Отображает список IAircraft
    /// </summary>
    [ToolboxItem(false)]
    public abstract partial class AbstractAircraftCollectionControl : UserControl
    {

        #region Fields

        private readonly Icons icons = new Icons();
        private const int WIDTH = 400;

        #endregion
        
        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображеия списка ВС, относящихся к заданному эксплуатанту
        /// </summary>
        public AbstractAircraftCollectionControl()
        {
            InitializeComponent();
            Width = WIDTH;
        }

        #endregion

        #region Properties

        #region public int TopMargin

        /// <summary>
        /// Возвращает или устанавливает верхний отступ
        /// </summary>
        public int TopMargin
        {
            get
            {
                return aircraftsListStatistics.Top;
            }
            set
            {
                aircraftsListStatistics.Top = value;
                flowLayoutPanelAircrafts.Top = value + 76;//todo убрать циферку
            }
        }

        #endregion

        #region public int DefaultWidth

        /// <summary>
        /// Возвращает ширину по умолчанию
        /// </summary>
        public int DefaultWidth
        {
            get
            {
                return WIDTH;
            }
        }

        #endregion


        #endregion

        #region Methods

        #region public abstract void FillUIElementsFromCollection();
        /// <summary>
        /// Заполняет графический элемент из бизнес коллекции
        /// </summary>
        public abstract void FillUIElementsFromCollection();

        #endregion

        #region public void ReloadItems()

        /// <summary>
        /// Обновляются элементы
        /// </summary>
        public void ReloadItems()
        {
            FillUIElementsFromCollection();
        }

        #endregion

        #endregion
    }
}