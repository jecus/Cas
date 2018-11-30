using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CAS.UI.UIControls.MaintananceProgram
{
    ///<summary>
    ///</summary>
    public partial class MaintenanceProgramControl : UserControl
    {

        #region Fields

        private List<MaintenanceCheckType> _currentCheckType;


        private List<MaintenanceCheck> _liminationItems;
        ///<summary>
        /// являются чеки плановыми, или это чеки по программе хранения
        ///</summary>
        private bool _schedule;
        ///<summary>
        /// Указывает нужно ли группировать чеки по части порогового значения
        ///</summary>
        private bool _grouping;
        ///<summary>
        /// Часть порогового значения, по которой будет выполнятся расчет и/или группировка чеков
        ///</summary>
        private LifelengthSubResource _subResource;

        #endregion

        #region Properties

        #region public bool EnableExtendedControl
        ///<summary>
        /// Возвращает или задает видимости ли панель расширения
        ///</summary>
        public bool EnableExtendedControl
        {
            get { return panelExtendable.Visible; }
            set
            {
                panelExtendable.Visible = value;
                if (value == false)
                {
                    flowLayoutPanelContainer.Visible = true;
                }
            }
        }
        #endregion

        #region public bool Extended
        ///<summary>
        /// Возвращает или задает значение Показывается ли элемент развернутым
        ///</summary>
        public bool Extended
        {
            get { return flowLayoutPanelContainer.Visible; }
            set { flowLayoutPanelContainer.Visible = value; }
        }
        #endregion

        #endregion

        #region public MaintenanceScheduleViewer()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public MaintenanceProgramControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public MaintenanceScheduleViewer(IEnumerable<MaintenanceCheck> programChecks, bool schedule, bool grouping, LifelengthSubResource subResource) : this()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        ///<param name="programChecks">Чеки из которых будет составлена программа обслуживания</param>
        ///<param name="schedule">являются чеки плановыми, или это чеки по программе хранения</param>
        ///<param name="grouping">Указывает нужно ли группировать чеки по части порогового значения</param>
        ///<param name="subResource">Часть порогового значения, по которой будет выполнятся расчет и/или группировка чеков</param>
        public MaintenanceProgramControl(IEnumerable<MaintenanceCheck> programChecks, bool schedule, bool grouping, LifelengthSubResource subResource)
            : this()
        {
            _schedule = schedule;
            _grouping = grouping;
            _subResource = subResource;
            _liminationItems =
                    programChecks.Where(i => i.Schedule == _schedule && i.Grouping == _grouping)
                                 .OrderBy(i => i.Interval.GetSubresource(_subResource))
                                 .ToList();
            UpdateInformation();
        }
        #endregion

        #region Methods

        #region public void SetParameters(IEnumerable<MaintenanceCheck> programChecks, bool schedule, bool grouping, LifelengthSubResource subResource)
        ///<summary>
        /// Выставляет параметры контрола
        ///</summary>
        ///<param name="programChecks">Чеки из которых будет составлена программа обслуживания</param>
        ///<param name="schedule">являются чеки плановыми, или это чеки по программе хранения</param>
        ///<param name="grouping">Указывает нужно ли группировать чеки по части порогового значения</param>
        ///<param name="subResource">Часть порогового значения, по которой будет выполнятся расчет и/или группировка чеков</param>
        public void SetParameters(IEnumerable<MaintenanceCheck> programChecks, bool schedule, bool grouping, LifelengthSubResource subResource)
        {
            _schedule = schedule;
            _grouping = grouping;
            _subResource = subResource;
            _liminationItems =
                    programChecks.Where(i => i.Schedule == _schedule && i.Grouping == _grouping)
                                 .OrderBy(i => i.Interval.GetSubresource(_subResource))
                                 .ToList();
            UpdateInformation();
        }
        #endregion

        #region private void UpdateInformation()
        /// <summary>
        /// Генерирует таблицы для представления чеков
        /// </summary>
        private void UpdateInformation()
        {
            if (_liminationItems == null || _liminationItems.Count == 0)
            {
                Visible = false;
                return;
            }
            extendableRichContainer.Caption = (_schedule ? "Schedule " : "Store ") +
                                              _subResource +
                                              (_grouping ? " (Group)" : "");

            flowLayoutPanelContainer.Controls.Clear();
            
            FillCurrentCheckType(_schedule);

            //для каждого типа чеков состоявляется собственная программа выполнения
            for (int i = 0; i < _currentCheckType.Count; i++)
            {
                MaintenanceCheckType nextCheckType = i == _currentCheckType.Count - 1
                                                         ? MaintenanceCheckType.Unknown
                                                         : _currentCheckType[i + 1];
                AddMaintenanceProgram(_currentCheckType[i], nextCheckType, _schedule, _grouping, _subResource);
            }

            Height = flowLayoutPanelContainer.Controls.Cast<Control>().Sum(control => control.Height) + 10;
            flowLayoutPanelContainer.Height = Height;

        }
        #endregion

        #region private void AddMaintenanceProgram(MaintenanceCheckType typeItem, int nextCheckId, bool schedule)

        /// <summary>
        /// Добавляет программу обслуживания для чеков заданного типа (A,B,C и т.д.)
        /// </summary>
        /// <param name="currentCheckType">Тип чека, для которого составляется программа</param>
        /// <param name="nextCheckType">Тип вышестоящего чека</param>
        /// <param name="schedule">являются чеки плановыми или входят в программу по хранению</param>
        /// <param name="grouping">Указывает нужно ли группировать чеки по части порогового значения</param>
        /// <param name="subResource">Часть порогового значения, по которой будет выполнятся расчет и/или группировка чеков</param>
        private void AddMaintenanceProgram(MaintenanceCheckType currentCheckType, 
                                           MaintenanceCheckType nextCheckType, 
                                           bool schedule, bool grouping,
                                           LifelengthSubResource subResource)
        {
            //Ресурс выполнения
            int nextCheckResource = -1;
            List<MaintenanceCheck> currentTypeChecks = new List<MaintenanceCheck>();
            foreach (MaintenanceCheck liminationItem in _liminationItems)
            {
                if (liminationItem.CheckType.ItemId == currentCheckType.ItemId)
                {
                    currentTypeChecks.Add(liminationItem);
                }
                else if (nextCheckResource == -1 && nextCheckType != MaintenanceCheckType.Unknown && liminationItem.CheckType == nextCheckType)
                {
                    if (liminationItem.Interval.GetSubresource(subResource) != null)
                    {
                        nextCheckResource = nextCheckResource == -1 
                            ? Convert.ToInt32(liminationItem.Interval.GetSubresource(subResource)) 
                            : Math.Min(Convert.ToInt32(liminationItem.Interval.GetSubresource(subResource)), nextCheckResource);
                    }
                }
            }
            MaintenanceProgramControlItem maintenanceScheduleItem = 
                new MaintenanceProgramControlItem(currentTypeChecks, 
                                                  Convert.ToInt32(_liminationItems[0].Interval.GetSubresource(_subResource)), 
                                                  schedule, 
                                                  grouping, 
                                                  subResource, 
                                                  nextCheckResource);
            
            flowLayoutPanelContainer.Controls.Add(maintenanceScheduleItem);
        }
        #endregion

        #region private void FillCurrentCheckType(bool schedule)
        private void FillCurrentCheckType(bool schedule)
        {
            _currentCheckType = new List<MaintenanceCheckType>();

            var v = from liminationItem in _liminationItems
                    where liminationItem.Schedule == schedule
                    group liminationItem by liminationItem.CheckType.FullName
                        into fileGroup
                        orderby fileGroup.Key
                        select fileGroup;
            foreach (IGrouping<string, MaintenanceCheck> grouping in v)
            {
                foreach (MaintenanceCheck liminationItem in grouping)
                {
                    _currentCheckType.Add(liminationItem.CheckType);
                    break;
                }
            }
        }
        #endregion

        #region private void ExtendableRichContainerExtending(object sender, EventArgs e)

        private void ExtendableRichContainerExtending(object sender, EventArgs e)
        {
            flowLayoutPanelContainer.Visible = !flowLayoutPanelContainer.Visible;
        }
        #endregion

        #endregion
    }
}
