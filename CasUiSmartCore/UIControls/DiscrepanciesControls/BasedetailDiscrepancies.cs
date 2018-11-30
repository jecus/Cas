using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Core.Interfaces;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.ReportFilters;

namespace CAS.UI.UIControls.DiscrepanciesControls
{
    /// <summary>
    /// Класс - отображение отклонений для базового агрегата
    /// </summary>
    public partial class BasedetailDiscrepancies : UserControl
    {
        #region Fields

        private IDetailDirectiveContainer directiveContainer;
        private DirectivesDiscrepanciesSettings[] displayedDiscrepanciesSettings;

        private DirectiveFilter discrepanciesFilter = new DiscrepanciesFilter();
        private DirectiveCollectionFilter additionalFilter = null;
        private bool showComponentDiscrepancies = true;

        #endregion

        #region Constructors

        /// <summary>
        /// Создается отображение отклонений для базового агрегата
        /// </summary>
        public BasedetailDiscrepancies()
        {
            InitializeComponent();
            BackColor = Color.Transparent;
            Margin = new Padding(0, 20, 0, 10);
            Dock = DockStyle.Top;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        /// <summary>
        /// Создается отображение отклонений для заданного
        /// </summary>
        /// <param name="directiveContainer"></param>
        public BasedetailDiscrepancies(IDetailDirectiveContainer directiveContainer):this()
        {
            DirectiveContainer = directiveContainer;
        }

        /// <summary>
        /// Создается отображение отклонений для заданного
        /// </summary>
        /// <param name="directiveContainer"></param>
        /// <param name="showComponentDiscrepancies"></param>
        public BasedetailDiscrepancies(IDetailDirectiveContainer directiveContainer, bool showComponentDiscrepancies):this()
        {
            this.showComponentDiscrepancies = showComponentDiscrepancies;
            DirectiveContainer = directiveContainer;
        }

        #endregion

        #region Properties

        #region public IDetailDirectiveContainer DirectiveContainer

        /// <summary>
        /// Объект, для которого отображаются отклонения
        /// </summary>
        public IDetailDirectiveContainer DirectiveContainer
        {
            get { return directiveContainer; }
            set
            {
                bool containerChanged = directiveContainer != value;
                directiveContainer = value;
                if (containerChanged)
                    DisplayElements();
                else                
                    UpdateElements();
            }
        }

        #endregion

        /// <summary>
        /// Фильтр выборки отклонений
        /// </summary>
        public DirectiveFilter DiscrepanciesFilter
        {
            get { return discrepanciesFilter; }
            set { discrepanciesFilter = value; }
        }

        /// <summary>
        /// Подсчитывается количество отклонений
        /// </summary>
        public int Count
        {
            get
            {
                int count = componentDiscrepancies1.Count;
                for (int i = 0; i < displayedDiscrepanciesSettings.Length; i++)
                {
                    DirectivesDiscrepanciesSettings setting = displayedDiscrepanciesSettings[i];
                    count += setting.AssociatedControl.Count;
                }
                return count;
            }
        }

        /// <summary>
        /// Дополнительный фильтр
        /// </summary>
        public DirectiveCollectionFilter AdditionalFilter
        {
            get { return additionalFilter; }
        }

        /// <summary>
        /// Отображать ли отклонения агрегатов
        /// </summary>
        public bool ShowComponentDiscrepancies
        {
            get { return showComponentDiscrepancies; }
            set { showComponentDiscrepancies = value; }
        }

        /// <summary>
        /// Настройки отображаемых объектов
        /// </summary>
        public DirectivesDiscrepanciesSettings[] DisplayedDiscrepanciesSettings
        {
            get { return displayedDiscrepanciesSettings; }
        }

        /// <summary>
        /// Элемент отображения отклонений по агрегатам
        /// </summary>
        public ComponentDiscrepancies ComponentDiscrepancies
        {
            get
            {
                if (componentDiscrepancies1.Count > 0)
                    return componentDiscrepancies1;
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DirectivesDiscrepanciesControl[] DirectivesDiscrepancies
        {
            get
            {
                List <DirectivesDiscrepanciesControl> controls = new List<DirectivesDiscrepanciesControl>(displayedDiscrepanciesSettings.Length);
                for (int i = 0; i < displayedDiscrepanciesSettings.Length; i++)
                {
                    DirectivesDiscrepanciesSettings setting = displayedDiscrepanciesSettings[i];
                    if (setting.AssociatedControl.Count > 0)
                        controls.Add(setting.AssociatedControl);
                }
                return controls.ToArray();
            }
        }

        /// <summary>
        /// Заголовок 
        /// </summary>
        public string Caption
        {
            get
            {
                return richReferenceContainer1.Caption;
            }
        }
        #endregion  

        #region Methods

        #region public static DirectivesDiscrepanciesSettings[] CreateBaseDetailSettings(DirectiveFilter discrepanciesFilter, DirectiveCollectionFilter additionalFilter)

        /// <summary>
        /// Создается коллекция настроек элементов отображения отклонений базового агрегата
        /// </summary>
        /// <param name="discrepanciesFilter"></param>
        /// <param name="additionalFilter"></param>
        /// <returns></returns>
        public static DirectivesDiscrepanciesSettings[] CreateBaseDetailSettings(DirectiveFilter discrepanciesFilter, DirectiveCollectionFilter additionalFilter)
        {
            return new DirectivesDiscrepanciesSettings[]
                {
                    new DirectivesDiscrepanciesSettings("AD Status", new ADStatusFilter(), discrepanciesFilter,
                                                        additionalFilter),
                    new DirectivesDiscrepanciesSettings("Engineering Orders", new EngeneeringOrderFilter(),
                                                        discrepanciesFilter, additionalFilter),
                    new DirectivesDiscrepanciesSettings("SB Status", new SBStatusFilter(), discrepanciesFilter,
                                                        additionalFilter)
                };
        }

        #endregion

        #region public static DirectivesDiscrepanciesSettings[] CreateBaseDetailSettings(DirectiveFilter discrepanciesFilter, DirectiveCollectionFilter additionalFilter)

        /// <summary>
        /// Создается коллекция настроек элементов отображения отклонений базового агрегата
        /// </summary>
        /// <param name="discrepanciesFilter"></param>
        /// <param name="additionalFilter"></param>
        /// <returns></returns>
        public static DirectivesDiscrepanciesSettings[] CreateAircraftSettings(DirectiveFilter discrepanciesFilter, DirectiveCollectionFilter additionalFilter)
        {
            return new DirectivesDiscrepanciesSettings[]
                {
                    new DirectivesDiscrepanciesSettings("AD Status", new ADStatusFilter(), discrepanciesFilter,
                                                        additionalFilter),
                    new DirectivesDiscrepanciesSettings("Aging Program", new AgingProgramFilter(), discrepanciesFilter, additionalFilter), 
                    new DirectivesDiscrepanciesSettings("CPCP Status", new CPCPFilter(), discrepanciesFilter, additionalFilter), 
                    new DirectivesDiscrepanciesSettings("Deferred Items", new DeferredItemsFilter(), discrepanciesFilter, additionalFilter), 
                    new DirectivesDiscrepanciesSettings("Engineering Orders", new EngeneeringOrderFilter(),
                                                        discrepanciesFilter, additionalFilter),
                    new DirectivesDiscrepanciesSettings("Modification Status", new ModificationFilter(), discrepanciesFilter, additionalFilter), 
                    new DirectivesDiscrepanciesSettings("Out Off Phase Items", new OutOffPhaseFilter(), discrepanciesFilter, additionalFilter), 
                    new DirectivesDiscrepanciesSettings("Repair Status", new RepairFilter(), discrepanciesFilter, additionalFilter), 
                    new DirectivesDiscrepanciesSettings("SB Status", new SBStatusFilter(), discrepanciesFilter,
                                                        additionalFilter),
                    new DirectivesDiscrepanciesSettings("SSID Status", new SSIDStatusFilter(), discrepanciesFilter, additionalFilter)
                };
        }

        #endregion

        #region public void UpdateElements()

        /// <summary>
        /// Обновление отображаемых отклонений
        /// </summary>
        public void UpdateElements()
        {
            if (displayedDiscrepanciesSettings == null)
                return;
            for (int i = 0; i < displayedDiscrepanciesSettings.Length; i++)
            {
                DirectivesDiscrepanciesSettings setting = displayedDiscrepanciesSettings[i];
                setting.AdditionalFilter = additionalFilter;
                setting.DiscrepanciesFilter = discrepanciesFilter;
                setting.DirectiveContainer = directiveContainer;
                setting.AdjustControl();
                setting.AssociatedControl.ShowDirectives();
            }
            UpdateComponentDiscrepancies();
        }

        #endregion

        #region public void DisplayElements()

        /// <summary>
        /// Отобразить элементы отображений отклонений
        /// </summary>
        public void DisplayElements()
        {
            panel1.Controls.Clear();
            if (directiveContainer is Aircraft)
                displayedDiscrepanciesSettings = CreateAircraftSettings(discrepanciesFilter, additionalFilter);
            else
                displayedDiscrepanciesSettings = CreateBaseDetailSettings(discrepanciesFilter, additionalFilter);
            if (displayedDiscrepanciesSettings == null)
                return;
            DirectivesDiscrepanciesSettings setting = null;
            for (int i = displayedDiscrepanciesSettings.Length - 1; i >= 0; i--)
            {
                setting = displayedDiscrepanciesSettings[i];
                setting.DirectiveContainer = directiveContainer;
                setting.AssociatedControl = setting.CreateControl();
                panel1.Controls.Add(setting.AssociatedControl);
            }
            UpdateComponentDiscrepancies();
            SetCaption();
        }
        #endregion

        #region private void SetCaption()

        private void SetCaption()
        {
            Visible = Count > 0;
            if (directiveContainer is Aircraft)
            {
                richReferenceContainer1.Caption = "Aircraft " + ((Aircraft) directiveContainer).RegistrationNumber +
                                                  " Discrepancies. ( " + Count + " items)";
                return;
            }
            if (directiveContainer is BaseDetail)
            {
                richReferenceContainer1.Caption = ((BaseDetail) directiveContainer).DetailType.FullName + " " +
                                                  directiveContainer.SerialNumber + " Discrepancies. ( " + Count +
                                                  " items)";
                return;
            }
            richReferenceContainer1.Caption = directiveContainer.SerialNumber + " Discrepancies. ( " + Count + " items)";
        }

        #endregion

        #region private void UpdateComponentDiscrepancies()

        private void UpdateComponentDiscrepancies()
        {
            if (showComponentDiscrepancies)
            {
                panel1.Controls.Add(componentDiscrepancies1);
                componentDiscrepancies1.DetailSource = directiveContainer;
                componentDiscrepancies1.DiscrepanciesFilter = discrepanciesFilter;
                componentDiscrepancies1.ShowDetails();
            }
            else
                panel1.Controls.Remove(componentDiscrepancies1);
        }

        #endregion

        #endregion

        #region Classes

        /// <summary>
        /// Настройки отклонений директив
        /// </summary>
        public class DirectivesDiscrepanciesSettings
        {
            private string caption;
            private DirectiveFilter selectionFilter;
            private DirectiveFilter discrepanciesFilter;
            private DirectiveCollectionFilter additionalFilter;
            private IDirectiveContainer directiveContainer;
            private DirectivesDiscrepanciesControl associatedControl;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="caption"></param>
            /// <param name="selectionFilter"></param>
            /// <param name="discrepanciesFilter"></param>
            /// <param name="additionalFilter"></param>
            public DirectivesDiscrepanciesSettings(string caption, DirectiveFilter selectionFilter, DirectiveFilter discrepanciesFilter, DirectiveCollectionFilter additionalFilter) : this(caption, selectionFilter, discrepanciesFilter, additionalFilter, null)
            {
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="caption"></param>
            /// <param name="selectionFilter"></param>
            /// <param name="discrepanciesFilter"></param>
            /// <param name="additionalFilter"></param>
            /// <param name="directiveContainer"></param>
            public DirectivesDiscrepanciesSettings(string caption, DirectiveFilter selectionFilter, DirectiveFilter discrepanciesFilter, DirectiveCollectionFilter additionalFilter, IDirectiveContainer directiveContainer)
            {
                this.caption = caption;
                this.directiveContainer = directiveContainer;
                this.selectionFilter = selectionFilter;
                this.discrepanciesFilter = discrepanciesFilter;
                this.additionalFilter = additionalFilter;
            }

            /// <summary>
            /// Заголовок элемента
            /// </summary>
            public string Caption
            {
                get { return caption; }
                set { caption = value; }
            }
            /// <summary>
            /// Элемент управления, связанный с данными настройками
            /// </summary>
            public DirectivesDiscrepanciesControl AssociatedControl
            {
                get { return associatedControl; }
                set { associatedControl = value; }
            }

            /// <summary>
            /// Фильтр выборки
            /// </summary>
            public DirectiveFilter SelectionFilter
            {
                get { return selectionFilter; }
                set { selectionFilter = value; }
            }

            /// <summary>
            /// Фильтр отклонений
            /// </summary>
            public DirectiveFilter DiscrepanciesFilter
            {
                get { return discrepanciesFilter; }
                set { discrepanciesFilter = value; }
            }

            /// <summary>
            /// Дополнительный фильтр
            /// </summary>
            public DirectiveCollectionFilter AdditionalFilter
            {
                get { return additionalFilter; }
                set { additionalFilter = value; }
            }

            /// <summary>
            /// Источник данных
            /// </summary>
            public IDirectiveContainer DirectiveContainer
            {
                get { return directiveContainer; }
                set { 
                    directiveContainer = value; }
            }

            /// <summary>
            /// Применяются настроки для элемента
            /// </summary>
            public DirectivesDiscrepanciesControl CreateControl()
            {
                DirectivesDiscrepanciesControl control = new DirectivesDiscrepanciesControl();
                AdjustControl(control);
                return control;
            }

            /// <summary>
            /// Настроить элемент управления
            /// </summary>
            /// <param name="control"></param>
            public void AdjustControl(DirectivesDiscrepanciesControl control)
            {
                if (control == null)
                    return;
                control.AdditionalFilter = additionalFilter;
                control.AutoSize = true;
                control.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                control.Dock = DockStyle.Top;
                control.BackColor = Color.Transparent;
                control.Caption = caption;
                control.DirectiveSelectionFilter = selectionFilter;
                control.DiscrepanciesFilter = discrepanciesFilter;
                control.DirectiveContainer = directiveContainer;
            }

            /// <summary>
            /// Настроить элемент управления
            /// </summary>
            public void AdjustControl()
            {
                AdjustControl(associatedControl);
            }
        }

        #endregion

    }
}
