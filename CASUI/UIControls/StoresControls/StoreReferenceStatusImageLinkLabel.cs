using System;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using Controls;
using Controls.StatusImageLink;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.StoresControls
{
    ///<summary>
    /// Класс, описывающий отображение ссылки на Склад
    ///</summary>
    public class StoreReferenceStatusImageLinkLabel : StatusImageLinkLabel, IReference
    {

        #region Fields

        private readonly Store currentStore;

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        #endregion

        #region Constructor

        /// <summary>
        /// Создается новый объект отображения Склада
        /// </summary>
        /// <param name="currentItem">Отображаемый объект</param>
        public StoreReferenceStatusImageLinkLabel(Store currentItem)
        {
            if (currentItem == null) 
                throw new ArgumentNullException("currentItem");
            currentStore = currentItem;
            Css.ImageLink.Adjust(this);
            UpdateInformation();
        }

        #endregion

        #region Properties

        #region public Store Store

        /// <summary>
        /// Возвраает Склад
        /// </summary>
        public Store Store
        {
            get { return currentStore; }
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
                 Store store = currentStore;
                //if (aircraft.ConditionState == DirectiveConditionState.NotSatisfactory)
                  //  Status = Statuses.NotSatisfactory;
                //else if (aircraft.ConditionState == DirectiveConditionState.Notify)
                  //  Status = Statuses.Notify;
                //else
                    Status = Statuses.Satisfactory;
                Text = store.StoreId.ToString();
            
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
