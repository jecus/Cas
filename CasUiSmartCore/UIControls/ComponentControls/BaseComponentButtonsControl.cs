using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AvControls;
using CAS.UI.UIControls.DetailsControls;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.ComponentControls
{
    ///<summary>
    ///</summary>
    public partial class BaseComponentButtonsControl : UserControl
    {
        #region Fields

        private Aircraft _currentAircraft;
        private BaseComponentControl _frameControl;
        private BaseComponentControl _apuControl;
        private readonly List<BaseComponentControl> _framesApus = new List<BaseComponentControl>();
        private readonly List<BaseComponentControl> _enginesControls = new List<BaseComponentControl>();
        private readonly List<BaseComponentControl> _landingGearsControls = new List<BaseComponentControl>();
        private readonly List<BaseComponentControl> _propellersControls = new List<BaseComponentControl>();
        private readonly List<BaseComponentControl> _allControls = new List<BaseComponentControl>();
        
        #endregion

        #region Constructors

        #region public BaseDetailButtonsControl()
        ///<summary>
        ///</summary>
        public BaseComponentButtonsControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public BaseDetailButtonsControl(Aircraft aircraft) : this()
        ///<summary>
        ///</summary>
        public BaseComponentButtonsControl(Aircraft aircraft)
            : this()
        {
            if (aircraft == null)
                throw new ArgumentNullException("aircraft", "can not be null");
            if (aircraft.ItemId <= 0)
                throw new ArgumentException("can't get details on not exist aircraft", "aircraft");

            _currentAircraft = aircraft;

            UpdateControl();
        }
        #endregion
       
        #endregion

        #region Properties

        #region Aircraft
        ///<summary>
        /// Возвращает или задает ВС, базовые агрегаты которого необходиио отобразить
        ///</summary>
        public Aircraft Aircraft
        {
            get { return _currentAircraft; }
            set
            {
                _currentAircraft = value;
                if (_currentAircraft != null)
                {
                    if(InvokeRequired)
                       BeginInvoke(new Action(UpdateControl));
                    else UpdateControl();
                }
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void UpdateControl()
        /// <summary>
        /// Обновляет информацию о двигателях текущего ВС
        /// </summary>
        private void UpdateControl()
        {
            flowLayoutPanelMain.Controls.Clear();
            if (_frameControl != null)_frameControl.Dispose();
            if (_apuControl != null) _apuControl.Dispose();
           
            foreach (BaseComponentControl c in _enginesControls)
                c.Dispose();
            _enginesControls.Clear();

            foreach (BaseComponentControl c in _landingGearsControls)
                c.Dispose();
            _landingGearsControls.Clear();

            foreach (BaseComponentControl c in _propellersControls)
                c.Dispose();
            _propellersControls.Clear();

            _allControls.Clear();
            ContainerFrameApus.Reset();
            ContainerEngines.Reset();
            ContainerPropellers.Reset();
            ContainerLG.Reset();

            var baseDetails = GlobalObjects.ComponentCore.GetAicraftBaseComponents(_currentAircraft.ItemId);
            var frame = 
                baseDetails.Where(bd => bd.BaseComponentType.ItemId == BaseComponentType.Frame.ItemId).FirstOrDefault();
            var apu =
                baseDetails.Where(bd => bd.BaseComponentType.ItemId == BaseComponentType.Apu.ItemId).FirstOrDefault();
            var engines = 
                baseDetails.Where(bd => bd.BaseComponentType.ItemId == BaseComponentType.Engine.ItemId).ToArray();
            var propellers =
                baseDetails.Where(bd => bd.BaseComponentType.ItemId == BaseComponentType.Propeller.ItemId).ToArray();
            var landingGears =
                baseDetails.Where(bd => bd.BaseComponentType.ItemId == BaseComponentType.LandingGear.ItemId).ToArray();

            _frameControl = new BaseComponentControl(frame);

            flowLayoutPanelMain.Controls.Add(_frameControl);
            _frameControl.UpdateBaseDetailCondition();
            _frameControl.TabIndex = 1;
            _frameControl.Tag = frame;

            _apuControl = new BaseComponentControl(apu);

            flowLayoutPanelMain.Controls.Add(_apuControl);
            _apuControl.UpdateBaseDetailCondition();
            _apuControl.TabIndex = 2;
            _apuControl.Tag = apu;

            #region Engines Buttons

            //Определение необходимости расштряемого контейнера для кнопок двигателей);
            if (engines.Length > 0) flowLayoutPanelMain.Controls.Add(ContainerEngines);
            if (engines.Length > 2)
            {
                ContainerEngines.EnableExtendedControl = true;
                ContainerEngines.Extended = false;
            }
            else ContainerEngines.EnableExtendedControl = false;

            for (int i = 0; i < engines.Length; i++)
            {
                BaseComponentControl baseComponentControl = new BaseComponentControl(engines[i]);
                _enginesControls.Add(baseComponentControl);
                ContainerEngines.AddButton(baseComponentControl);
                baseComponentControl.UpdateBaseDetailCondition();
                baseComponentControl.Name = "Engine" + i;
                baseComponentControl.TabIndex = 3 + i;
                baseComponentControl.Tag = engines[i];
            }
            //Определение статуса расширяемого контейнера (если он был добавлен)
            if (_enginesControls.Count > 2)
            {
                ConditionState cond = ConditionState.NotEstimated;
                foreach (BaseComponentControl engineControl in _enginesControls)
                {
                    if (engineControl.BaseComponentCondition == ConditionState.NotEstimated &&
                        cond == ConditionState.NotEstimated)
                        cond = ConditionState.NotEstimated;

                    if (engineControl.BaseComponentCondition == ConditionState.Satisfactory &&
                        cond != ConditionState.Notify)
                        cond = ConditionState.Satisfactory;

                    if (engineControl.BaseComponentCondition == ConditionState.Notify &&
                        cond != ConditionState.Satisfactory)
                        cond = ConditionState.Notify;

                    if (engineControl.BaseComponentCondition == ConditionState.Overdue)
                    {
                        cond = ConditionState.Overdue;
                        break;
                    }
                }
                ContainerEngines.Condition = cond;
            }

            #endregion

            #region Propellers Buttons
            //Определение необходимости расширяемого контейнера для кнопок винтов
            if (propellers.Length > 0) flowLayoutPanelMain.Controls.Add(ContainerPropellers);
            if (propellers.Length > 2)
            {
                ContainerPropellers.EnableExtendedControl = true;
                ContainerPropellers.Extended = false;
            }
            else ContainerPropellers.EnableExtendedControl = false;

            for (int i = 0; i < propellers.Length; i++)
            {
                BaseComponentControl baseComponentControl = new BaseComponentControl(propellers[i]);

                _propellersControls.Add(baseComponentControl);
                ContainerPropellers.AddButton(baseComponentControl);

                baseComponentControl.UpdateBaseDetailCondition();
                baseComponentControl.Name = "Propeller" + i;
                baseComponentControl.TabIndex = 3 + i;
            }
            //Определение статуса расширяемого контейнера (если он был добавлен)
            if (_propellersControls.Count > 2)
            {
                ConditionState cond = ConditionState.NotEstimated;
                foreach (BaseComponentControl engineControl in _propellersControls)
                {
                    if (engineControl.BaseComponentCondition == ConditionState.NotEstimated &&
                        cond == ConditionState.NotEstimated)
                        cond = ConditionState.NotEstimated;

                    if (engineControl.BaseComponentCondition == ConditionState.Satisfactory &&
                        cond != ConditionState.Notify)
                        cond = ConditionState.Satisfactory;

                    if (engineControl.BaseComponentCondition == ConditionState.Notify &&
                        cond != ConditionState.Satisfactory)
                        cond = ConditionState.Notify;

                    if (engineControl.BaseComponentCondition == ConditionState.Overdue)
                    {
                        cond = ConditionState.Overdue;
                        break;
                    }
                }
                ContainerPropellers.Condition = cond;
            }

            #endregion

            #region Landing gears Buttons

            if (landingGears.Length > 0) flowLayoutPanelMain.Controls.Add(ContainerLG);
            if (landingGears.Length > 3)
            {
                ContainerLG.EnableExtendedControl = true;
                ContainerLG.Extended = false;
            }
            else ContainerLG.EnableExtendedControl = false;
            
            for (int i = 0; i < landingGears.Length; i++)
            {
                BaseComponentControl baseComponentControl = new BaseComponentControl(landingGears[i]);

                _landingGearsControls.Add(baseComponentControl);
                ContainerLG.AddButton(baseComponentControl);

                baseComponentControl.UpdateBaseDetailCondition();
                baseComponentControl.Name = "LG" + i;
                baseComponentControl.TabIndex = 2 + engines.Length + propellers.Length + i;
                baseComponentControl.Tag = landingGears[i];
            }

            //Определение статуса расширяемого контейнера (если он был добавлен)
            if (_landingGearsControls.Count > 3)
            {
                ConditionState cond = ConditionState.NotEstimated;
                foreach (BaseComponentControl landingGearControl in _landingGearsControls)
                {
                    if (landingGearControl.BaseComponentCondition == ConditionState.NotEstimated &&
                        cond == ConditionState.NotEstimated)
                        cond = ConditionState.NotEstimated;

                    if (landingGearControl.BaseComponentCondition == ConditionState.Satisfactory &&
                        cond != ConditionState.Notify)
                        cond = ConditionState.Satisfactory;

                    if (landingGearControl.BaseComponentCondition == ConditionState.Notify &&
                        cond != ConditionState.Satisfactory)
                        cond = ConditionState.Notify;

                    if (landingGearControl.BaseComponentCondition == ConditionState.Overdue)
                    {
                        cond = ConditionState.Overdue;
                        break;
                    }
                }
                ContainerLG.Condition = cond;
            }
            #endregion
        }

        #endregion

        #region  public BaseDetailControl GetByBaseDetail(BaseDetail baseDetail)
        ///<summary>
        /// Возвращает контрол отображающий информацию о переданной Базовой детали
        ///</summary>
        ///<param name="baseComponentазовая деталь, ЭУ которой требуется найти</param>
        ///<returns>объект <see cref="BaseComponentControl"/> отображающий информацию о Базовой детали или null</returns>
        public BaseComponentControl GetByBaseDetail(BaseComponent baseComponent)
        {
            return _allControls.FirstOrDefault(c => c.BaseComponent == baseComponent);
        }
        #endregion

        #region public void Reset()
        /// <summary>
        /// Возвращает контрол к изначальному состоянию
        /// </summary>
        public void Reset()
        {
            flowLayoutPanelMain.Controls.Clear();

            foreach (BaseComponentControl c in _framesApus)
                c.Dispose();
            _framesApus.Clear();

            foreach (BaseComponentControl c in _enginesControls)
                c.Dispose();
            _enginesControls.Clear();

            foreach (BaseComponentControl c in _landingGearsControls)
                c.Dispose();
            _landingGearsControls.Clear();

            foreach (BaseComponentControl c in _propellersControls)
                c.Dispose();
            _propellersControls.Clear();

            _allControls.Clear();

            ContainerFrameApus.Reset();
            ContainerFrameApus.EnableExtendedControl = false;
            ContainerFrameApus.Visible = false;
            ContainerEngines.Reset();
            ContainerEngines.EnableExtendedControl = false;
            ContainerEngines.Visible = false;
            ContainerPropellers.Reset();
            ContainerPropellers.EnableExtendedControl = false;
            ContainerPropellers.Visible = false;
            ContainerLG.Reset();
            ContainerLG.EnableExtendedControl = false;
            ContainerLG.Visible = false;

            flowLayoutPanelMain.Controls.AddRange(new []{ContainerFrameApus, ContainerEngines, ContainerPropellers, ContainerLG});
        }
        #endregion

        #region public void Add(BaseDetailControl button)
        /// <summary>
        /// Добавляет кнопку на контрол
        /// </summary>
        public void Add(BaseComponent baseComponent)
        {
            if (baseComponent == null ||
                _allControls.FirstOrDefault(c => c.BaseComponent.ItemId == baseComponent.ItemId) != null)
                return;

            BaseComponentControl button = new BaseComponentControl(baseComponent) {Tag = baseComponent};
            button.StatusChanged += ButtonStatusChanged;
            button.ComponentMovedTo += ButtonOnComponentMovedTo;
            _allControls.Add(button);

            BaseComponentType dt = baseComponent.BaseComponentType;

            #region Frame and APUs Buttons
            if (dt == BaseComponentType.Frame || dt == BaseComponentType.Apu)
            {
                _framesApus.Add(button);

                if (ContainerFrameApus.Visible == false)
                    ContainerFrameApus.Visible = true;
                if (_framesApus.Count > 2)
                {
                    ContainerFrameApus.EnableExtendedControl = true;
                    ContainerFrameApus.Extended = false;
                }
                else ContainerFrameApus.EnableExtendedControl = false;

                ContainerFrameApus.AddButton(button);

                button.Name = "FrameApu" + _framesApus.Count;
                button.TabIndex = _framesApus.Count;
            }
            #endregion

            #region Engines Buttons

            if (dt == BaseComponentType.Engine)
            {
                _enginesControls.Add(button);
                if (ContainerEngines.Visible == false)
                    ContainerEngines.Visible = true;
                //Определение необходимости расштряемого контейнера для кнопок двигателей);
                if (_enginesControls.Count > 2)
                {
                    ContainerEngines.EnableExtendedControl = true;
                    ContainerEngines.Extended = false;
                }
                else ContainerEngines.EnableExtendedControl = false;

                ContainerEngines.AddButton(button);

                button.Name = "Engine" + _enginesControls.Count;
                button.TabIndex = _enginesControls.Count;
            }
            #endregion

            #region Propellers Buttons

            if(dt == BaseComponentType.Propeller)
            {
                _propellersControls.Add(button);

                if (ContainerPropellers.Visible == false)
                    ContainerPropellers.Visible = true;
                //Определение необходимости расширяемого контейнера для кнопок винтов
                if (_propellersControls.Count > 2)
                {
                    ContainerPropellers.EnableExtendedControl = true;
                    ContainerPropellers.Extended = false;
                }
                else ContainerPropellers.EnableExtendedControl = false;

                ContainerPropellers.AddButton(button);

                button.Name = "Propeller" + _propellersControls.Count;
                button.TabIndex = _propellersControls.Count;
            }
            #endregion

            #region Landing gears Buttons

            if (dt == BaseComponentType.LandingGear)
            {
                _landingGearsControls.Add(button);

                if (ContainerLG.Visible == false)
                    ContainerLG.Visible = true;
                //Определение необходимости расширяемого контейнера для кнопок винтов
                if (_landingGearsControls.Count > 3)
                {
                    ContainerLG.EnableExtendedControl = true;
                    ContainerLG.Extended = false;
                }
                else ContainerLG.EnableExtendedControl = false;

                ContainerLG.AddButton(button);

                button.Name = "LG" + _landingGearsControls.Count;
                button.TabIndex = _landingGearsControls.Count;    
            }
            #endregion
        }

	    #endregion

        #region public void CheckContainers()
        /// <summary>
        /// Проверяет кол-во контролов в каждом контейнере и скрывает пустые контейнеры
        /// </summary>
        public void CheckContainers()
        {
            if (_framesApus.Count == 0) ContainerFrameApus.Visible = false;
            if (_enginesControls.Count == 0) ContainerEngines.Visible = false;
            if (_propellersControls.Count == 0) ContainerPropellers.Visible = false;
            if (_landingGearsControls.Count == 0) ContainerLG.Visible = false;
        }
        #endregion

        #region private void ButtonStatusChanged(object sender, AvControls.StatusImageLink.StatusEventArgs e)

        private void ButtonStatusChanged(object sender, AvControls.StatusImageLink.StatusEventArgs e)
        {
            BaseComponentControl bdc = sender as BaseComponentControl;
            if (bdc == null) return;
            ReferenceControls.ReferenceControlCollectionContainer container = null;

            if (_framesApus.Contains(bdc))
                container = ContainerFrameApus;
            if (_enginesControls.Contains(bdc))
                container = ContainerEngines;
            if (_propellersControls.Contains(bdc))
                container = ContainerPropellers;
            if (_landingGearsControls.Contains(bdc))
                container = ContainerLG;

            if (container == null)return;

            if (e.ControlStatus == Statuses.NotActive &&
                container.Condition == ConditionState.NotEstimated)
                container.Condition = ConditionState.NotEstimated;

            if (e.ControlStatus == Statuses.Satisfactory &&
                container.Condition != ConditionState.Notify &&
                container.Condition != ConditionState.Overdue)
                container.Condition = ConditionState.Satisfactory;

            if (e.ControlStatus == Statuses.Notify &&
                container.Condition != ConditionState.Satisfactory &&
                container.Condition != ConditionState.Overdue)
                container.Condition = ConditionState.Notify;

            if (e.ControlStatus == Statuses.NotSatisfactory)
                container.Condition = ConditionState.Overdue;
        }
		#endregion

		private void ButtonOnComponentMovedTo(object sender, EventArgs eventArgs)
		{
			InvokeComponentMovedTo();
		}

	    public event EventHandler ComponentMovedTo;

	    private void InvokeComponentMovedTo()
	    {
		    if (ComponentMovedTo == null) return;
		    ComponentMovedTo(this, EventArgs.Empty);
	    }

		#endregion
	}
}
