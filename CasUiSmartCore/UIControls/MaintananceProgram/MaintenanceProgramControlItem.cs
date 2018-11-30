using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SmartCore.Calculations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CAS.UI.UIControls.MaintananceProgram
{
    ///<summary>
    ///</summary>
    public partial class MaintenanceProgramControlItem : UserControl
    {
        #region Field

        private readonly List<MaintenanceCheck> _maintenanceCheckItems;
        /// <summary>
        /// Это поле указывает ресурс самого минимального чека
        /// </summary>
        private readonly int _minCheckResource;
        /// <summary>
        /// Это поле указывает минимльный ресурс вышестоящего типа чеков
        /// если это самый вышестоящий тип то ставится -1
        /// </summary>
        private readonly int _upperCheckTypeMinResource;
        ///<summary>
        /// являются чеки плановыми, или это чеки по программе хранения
        ///</summary>
        private readonly bool _schedule;
        ///<summary>
        /// Указывает нужно ли группировать чеки по части порогового значения
        ///</summary>
        private readonly bool _grouping;
        ///<summary>
        /// Часть порогового значения, по которой будет выполнятся расчет и/или группировка чеков
        ///</summary>
        private readonly LifelengthSubResource _subResource;

        private int _countColumns;
        private int _min;
        int _max;

        #endregion

        #region Properties

        #endregion

        #region Constructors

        #region public MaintenanceScheduleItem()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public MaintenanceProgramControlItem()
        {
            InitializeComponent();
        }
        #endregion

        #region public MaintenanceScheduleItem(List<MaintenanceCheck> maintenanceLiminationItems, bool schedule, int upperCheckTypeMinResource) : this()

        ///<summary>
        ///</summary>
        ///<param name="maintenanceLiminationItems"></param>
        ///<param name="minCheckResource"></param>
        ///<param name="schedule">являются чеки плановыми, или это чеки по программе хранения</param>
        ///<param name="upperCheckTypeMinResource">минимльный ресурс вышестоящего типа чеков</param>
        ///<param name="grouping">Указывает нужно ли группировать чеки по части порогового значения</param>
        ///<param name="subResource">Часть порогового значения, по которой будет выполнятся расчет и/или группировка чеков</param>
        public MaintenanceProgramControlItem(List<MaintenanceCheck> maintenanceLiminationItems, 
                                             int minCheckResource,
                                             bool schedule,
                                             bool grouping,
                                             LifelengthSubResource subResource,
                                             int upperCheckTypeMinResource) : this()
        {
            _maintenanceCheckItems = maintenanceLiminationItems;
            _minCheckResource = minCheckResource;
            _schedule = schedule;
            _grouping = grouping;
            _upperCheckTypeMinResource = upperCheckTypeMinResource;
            _subResource = subResource;

            UpdateInformation();
        }
        #endregion

        #endregion

        #region private void UpdateInformation()
        ///<summary>
        /// Генерирует сетку программы обслуживания
        ///</summary>
        private void UpdateInformation()
        {
            listViewProgramChecks.Columns.Clear();
            labelCheckType.Text = _maintenanceCheckItems[0].CheckType.FullName;
            
            //Если отсутствуют чеки программы - выход из метода
            if (_maintenanceCheckItems.Count == 0)
                return;
            if (_maintenanceCheckItems.Any(item => Convert.ToInt32(item.Interval.GetSubresource(_subResource)) == 0))
                return;

            SetHeaders();

            GenerateRows();

            listViewProgramChecks.Height = (listViewProgramChecks.Items.Count * 18) + 50;
            
            Height = (listViewProgramChecks.Items.Count * 18) + 80;
        }
        #endregion

        #region private void SetHeaders()
        /// <summary>
        /// Выставляет колонки в списке чеков текущей программы обслуживания
        /// </summary>
        private void SetHeaders()
        {
            _min = Convert.ToInt32(_maintenanceCheckItems[0].Interval.GetSubresource(_subResource));

            foreach (MaintenanceCheck liminationItem in _maintenanceCheckItems)
            {
                _min = Math.Min(Convert.ToInt32(liminationItem.Interval.GetSubresource(_subResource)), _min);
                _max = Math.Max(Convert.ToInt32(liminationItem.Interval.GetSubresource(_subResource)), _max);
            }

            ColumnHeader column = new ColumnHeader {Text = "Name", TextAlign = HorizontalAlignment.Right, Width = 50};
            listViewProgramChecks.Columns.Add(column);
            column = new ColumnHeader {Text = "Interval", TextAlign = HorizontalAlignment.Left, Width = 130};
            listViewProgramChecks.Columns.Add(column);
            column = new ColumnHeader {Text = "Cost", TextAlign = HorizontalAlignment.Left, Width = 50};
            listViewProgramChecks.Columns.Add(column);
            column = new ColumnHeader {Text = "ManHours", TextAlign = HorizontalAlignment.Left, Width = 64};
            listViewProgramChecks.Columns.Add(column);

            if(_grouping)
            {
                //Определение кол-ва колонок списка
                if (_upperCheckTypeMinResource == -1)
                {
                    //Если это самая вышестоящий тип чеков
                    //то делится максимальный на минимальный интервал
                    _countColumns = _max / _min;
                }
                else
                {
                    //Если это самая НЕ вышестоящий тип чеков
                    //то делится минимальный ресурс вышестоящего типа на минимальный интервал
                    _countColumns = _upperCheckTypeMinResource / _min;
                }
                MaintenanceCheckCollection mcc = new MaintenanceCheckCollection(_maintenanceCheckItems);
                MaintenanceCheck mc = mcc.GetMinStepCheck(_maintenanceCheckItems[0].Schedule);
                if(mc == null)
                    return;
                MSG msg = mc.ParentAircraft != null && mc.ParentAircraft.MaintenanceProgramChangeRecords.Count > 0
                                  ? mc.ParentAircraft.MaintenanceProgramChangeRecords.GetLast().MSG
                                  : MSG.MSG2;
                if(msg < MSG.MSG3)
                {
                    for (int i = 1; i <= _countColumns; i++)
                    {
                        //ColumnHeader viewColumn = new ColumnHeader
                        //                              {
                        //                                  Text = i + " [" + (i*_min) + "]",
                        //                                  TextAlign = HorizontalAlignment.Center,
                        //                                  Width = 65
                        //
                        //                              };
                        //listViewProgramChecks.Columns.Add(viewColumn);
                        ColumnHeader viewColumn;
                        //выполняется проверка, достаточно ли расчитано "след.выполнений"
                        //что бы заполнить их данными названия колонок
                        if (mc.NextPerformances.Count >= i)
                        {
                            //Если кол-во расчитанных выполнений достаточно для заполнения
                            //названия тек. колонки, то название колонки берется из ресурса "след. выполнения"
                            int performanceSource =
                                    Convert.ToInt32(mc.NextPerformances[i - 1].PerformanceSource.GetSubresource(mc.Resource));
                            MaintenanceNextPerformance mnp = mc.NextPerformances[i - 1] as MaintenanceNextPerformance;
                            if(mnp != null)
                            {
                                string checkName = mnp.PerformanceGroup != null ? mnp.PerformanceGroup.GetGroupName() : i.ToString();
                                viewColumn = new ColumnHeader
                                {
                                    Text = checkName + " [" + performanceSource + "]",
                                    TextAlign = HorizontalAlignment.Center,
                                    Width = 85
                                };    
                            }
                            else
                            {
                                viewColumn = new ColumnHeader
                                {
                                    Text = i + " [" + performanceSource + "]",
                                    TextAlign = HorizontalAlignment.Center,
                                    Width = 85
                                };     
                            }
                        }
                        else
                        {
                            //Если кол-во расчитанных выполнений недостаточно
                            //то название колонки расчитывается на освоне ресурса последнего выполнения 
                            //данного чека и номера тек. колонки
                            viewColumn = new ColumnHeader
                            {
                                Text = i + " [" + (i * _min) + "]",
                                TextAlign = HorizontalAlignment.Center,
                                Width = 85
                            };
                        }
                        listViewProgramChecks.Columns.Add(viewColumn);
                    }
                }
                else
                {
                    MaintenanceCheckComplianceGroup mccg = mcc.GetLastComplianceCheckGroup(mc.Schedule, mc.ParentAircraftId,
                                                                                           mc.Grouping, mc.Resource);
                    if(mccg == null)
                    {
                        for (int i = 1; i <= _countColumns; i++)
                        {
                            MaintenanceNextPerformance mnp = mc.NextPerformances[i - 1] as MaintenanceNextPerformance;
                            string checkName = mnp != null && mnp.PerformanceGroup != null 
                                ? mnp.PerformanceGroup.GetGroupName() 
                                : "";
                            ColumnHeader viewColumn = new ColumnHeader
                                                          {
                                                              Text = checkName + " [" + (i * _min) + "]",
                                                              TextAlign = HorizontalAlignment.Center,
                                                              Width = 65
                                                          };
                            listViewProgramChecks.Columns.Add(viewColumn);
                        }                                
                    }
                    else
                    {
                        MaintenanceCheck mic = mccg.GetMinIntervalCheck();
                        for (int i = 1; i <= _countColumns; i++)
                        {
                            ColumnHeader viewColumn;
                            //выполняется проверка, достаточно ли расчитано "след.выполнений"
                            //что бы заполнить их данными названия колонок
                            if (mic.NextPerformances.Count >= i)
                            {
                                //Если кол-во расчитанных выполнений достаточно для заполнения
                                //названия тек. колонки, то название колонки берется из ресурса "след. выполнения"
                                MaintenanceNextPerformance mnp = mc.NextPerformances[i - 1] as MaintenanceNextPerformance;
                                string checkName = mnp != null && mnp.PerformanceGroup != null
                                    ? mnp.PerformanceGroup.GetGroupName()
                                    : "";
                                int performanceSource =
                                    Convert.ToInt32(mic.NextPerformances[i - 1].PerformanceSource.GetSubresource(mic.Resource));
                                viewColumn = new ColumnHeader
                                {
                                    Text = checkName + " [" + performanceSource + "]",
                                    TextAlign = HorizontalAlignment.Center,
                                    Width = 85
                                };
                            }
                            else
                            {
                                //Если кол-во расчитанных выполнений недостаточно
                                //то название колонки расчитывается на освоне ресурса последнего выполнения 
                                //данного чека и номера тек. колонки
                                int lastPerformaceSource =
                                    Convert.ToInt32(mic.LastPerformance.CalculatedPerformanceSource.GetSubresource(mic.Resource));
                                if (lastPerformaceSource == 0)
                                    lastPerformaceSource = 
                                    Convert.ToInt32(mic.LastPerformance.OnLifelength.GetSubresource(mic.Resource));
                        
                                viewColumn = new ColumnHeader
                                {
                                    Text = " [" + (lastPerformaceSource + i * _min) + "]",
                                    TextAlign = HorizontalAlignment.Center,
                                    Width = 85
                                };    
                            }
                            listViewProgramChecks.Columns.Add(viewColumn);
                        } 
                    }
                }
                mcc.Clear();
            }
            else
            {
                _countColumns = 2;
                //Если чеки НЕ группируются по части порогового значения
                //то выводится ресурс пред. и след. выполнения
                column = new ColumnHeader { Text = "Last", TextAlign = HorizontalAlignment.Left, Width = 100 };
                listViewProgramChecks.Columns.Add(column);
                column = new ColumnHeader { Text = "Next", TextAlign = HorizontalAlignment.Left, Width = 100 };
                listViewProgramChecks.Columns.Add(column);    
            }                                                                                                                                                 
        }
        #endregion

        #region private void GenerateRows()
        private void GenerateRows()
        {
            listViewProgramChecks.Items.Clear();
            if (_grouping)
            {
                MaintenanceCheckCollection mcc = new MaintenanceCheckCollection(_maintenanceCheckItems);
                MaintenanceCheck mc = mcc.GetMinStepCheck(_maintenanceCheckItems[0].Schedule);
                if (mc == null)
                    return;
                MSG msg = mc.ParentAircraft != null && mc.ParentAircraft.MaintenanceProgramChangeRecords.Count > 0
                                  ? mc.ParentAircraft.MaintenanceProgramChangeRecords.GetLast().MSG
                                  : MSG.MSG2;
                if (msg < MSG.MSG3)
                {
                    MaintenanceCheckComplianceGroup mccg =
                        mcc.GetLastComplianceCheckGroup(mc.Schedule, mc.ParentAircraftId,
                                                        mc.Grouping, mc.Resource);

                    int lastPerformanceGroupNum = mccg != null
                        ? mccg.LastComplianceGroupNum
                        : 0;
                    int countMinStepInMinCheck = Convert.ToInt32(mc.Interval.GetSubresource(mc.Resource)) / _minCheckResource;
                    foreach (MaintenanceCheck t in _maintenanceCheckItems)
                    {
                        ListViewItem listViewItem = new ListViewItem { Text = t.Name };

                        listViewItem.SubItems.Add(t.Interval.ToRepeatIntervalsFormat());
                        listViewItem.SubItems.Add(t.Cost.ToString());
                        listViewItem.SubItems.Add(t.ManHours.ToString());

                        for (int j = 1; j <= _countColumns; j++)
                        {
                            MaintenanceNextPerformance mnp =
                                t.GetPergormanceGroupByGroupNum(lastPerformanceGroupNum + j * countMinStepInMinCheck);
                            listViewItem.SubItems.Add(mnp != null ? "X" : "");
                        }
                        listViewProgramChecks.Items.Add(listViewItem);
                    }
                }
                else
                {
                    MaintenanceCheckComplianceGroup mccg =
                        mcc.GetLastComplianceCheckGroup(mc.Schedule, mc.ParentAircraftId,
                                                        mc.Grouping, mc.Resource);

                    int lastPerformanceGroupNum = mccg != null
                        ? mccg.LastComplianceGroupNum
                        : 0;
                    int countMinStepInMinCheck = Convert.ToInt32(mc.Interval.GetSubresource(mc.Resource)) / _minCheckResource;
                    foreach (MaintenanceCheck t in _maintenanceCheckItems)
                    {
                        ListViewItem listViewItem = new ListViewItem {Text = t.Name};

                        listViewItem.SubItems.Add(t.Interval.ToRepeatIntervalsFormat());
                        listViewItem.SubItems.Add(t.Cost.ToString());
                        listViewItem.SubItems.Add(t.ManHours.ToString());

                        for (int j = 1; j <= _countColumns; j++)
                        {
                            MaintenanceNextPerformance mnp =
                                t.GetPergormanceGroupWhereCheckIsSeniorByGroupNum(lastPerformanceGroupNum + j * countMinStepInMinCheck);
                            listViewItem.SubItems.Add(mnp != null ? "X" : "");
                        }
                        listViewProgramChecks.Items.Add(listViewItem);
                    }
                }
                mcc.Clear();
            }
            else
            {
                foreach (MaintenanceCheck t in _maintenanceCheckItems)
                {
                    ListViewItem listViewItem = new ListViewItem {Text = t.Name};

                    listViewItem.SubItems.Add(t.Interval.ToRepeatIntervalsFormat());
                    listViewItem.SubItems.Add(t.Cost.ToString());
                    listViewItem.SubItems.Add(t.ManHours.ToString());

                    Lifelength lastPerformance = t.LastPerformance != null
                        ? new Lifelength(t.LastPerformance.OnLifelength)
                        : Lifelength.Null;
                    int? last = lastPerformance.GetSubresource(_subResource);

                    listViewItem.SubItems.Add(last != null ? lastPerformance.ToString(_subResource, true) : "");

                    if (t.Schedule == _schedule)
                    {
                        Lifelength nextPerformance = lastPerformance + t.Interval;
                        int? next = nextPerformance.GetSubresource(_subResource);
                        listViewItem.SubItems.Add(next != null ? nextPerformance.ToString(_subResource, true) : "");
                    }
                    else
                    {
                        listViewItem.SubItems.Add("N/A");
                    }
                    listViewProgramChecks.Items.Add(listViewItem);
                }
            }
        }
        #endregion
    }
}
