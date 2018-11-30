using System;
using CAS.Core.Core.Interfaces;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using Controls;
using Controls.StatusImageLink;

namespace CAS.UI.UIControls.AircraftsControls
{
    ///<summary>
    /// Класс, описывающий отображение ссылки на ВС
    ///</summary>
    public class AircraftReferenceStatusImageLinkLabel : StatusImageLinkLabel, IReference
    {

        #region Fields

        private readonly IAircraft currentAircraft;

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        #endregion

        #region Constructor

        /// <summary>
        /// Создается новый объект отображения ВС
        /// </summary>
        /// <param name="currentItem">Отображаемый объект</param>
        public AircraftReferenceStatusImageLinkLabel(IAircraft currentItem)
        {
            if (currentItem == null) 
                throw new ArgumentNullException("currentItem");
            currentAircraft = currentItem;
            Css.ImageLink.Adjust(this);
            UpdateInformation();
        }

        #endregion

        #region Properties

        #region public IAircraft Aircraft

        /// <summary>
        /// Возвраает ВС
        /// </summary>
        public IAircraft Aircraft
        {
            get { return currentAircraft; }
        }

        #endregion

        #region public IDisplayer Displayer

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        #endregion

        #region public string DisplayerText

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }

        #endregion

        #region public IDisplayingEntity Entity

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        #endregion

        #region public ReflectionTypes ReflectionType

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        #endregion
        
        #endregion

        #region Methods

        #region public void UpdateInformation()

        /// <summary>
        /// Обновляет данные
        /// </summary>
        public void UpdateInformation()
        {
            if (currentAircraft is Aircraft)
            {
                Aircraft aircraft = (Aircraft) currentAircraft;
                if (aircraft.ConditionState == DirectiveConditionState.NotSatisfactory)
                    Status = Statuses.NotSatisfactory;
                else if (aircraft.ConditionState == DirectiveConditionState.Notify)
                    Status = Statuses.Notify;
                else
                    Status = Statuses.Satisfactory;
                Text = aircraft.RegistrationNumber;
            }
            else
            {
                TemplateAircraft aircraft = (TemplateAircraft)currentAircraft;
                Status = Statuses.Satisfactory;
                Text = aircraft.Model;
            }
            
        }

        #endregion

        #region protected void OnDisplayerRequested()
        /// <summary>
        /// Вызывается событие DisplayerRequested
        /// </summary>
        protected void OnDisplayerRequested()
        {
            if (null != DisplayerRequested)
            {
                if (null != displayer)
                {
                    DisplayerRequested(this, new ReferenceEventArgs(entity, reflectionType, displayer, displayerText));
                }
                else
                {
                    DisplayerRequested(this, new ReferenceEventArgs(entity, reflectionType, displayerText));
                }
            }
        }
        #endregion

        #region protected override void OnClick(EventArgs e)

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Click"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnClick(EventArgs e)
        {
            OnDisplayerRequested();
            base.OnClick(e);
        }

        #endregion

        /// <summary>
        /// </summary>
        public void DisplayRequested()
        {
            OnDisplayerRequested();
        }

        #endregion

        #region Events

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

        #endregion

    }
}
