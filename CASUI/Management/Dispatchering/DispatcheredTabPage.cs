using System;
using System.ComponentModel;
using System.Windows.Forms;
using Controls.AvMultitabControl;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.Management.Dispatchering
{
    /// <summary>
    /// Implimetation of <see cref="AvTabPage"/> as <see cref="IDisplayer"/> to be dispatchered by <see cref="Dispatcher"/>
    /// </summary>
    public class DispatcheredTabPage : AvTabPage, IDisplayer
    {
        #region Fields
        private IDisplayingEntity entity;
        private bool performCloseChecking = true;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates new Instance of DispatcheredTabPage
        /// </summary>
        public DispatcheredTabPage()
        {
        }

        /// <summary>
        /// Creates new Instance of DispatcheredTabPage
        /// </summary>
        /// <param name="text">Text of page's header</param>
        public DispatcheredTabPage(string text) : base(text)
        {
        }
        #endregion

        #region Properties

        #region public IDisplayingEntity Entity
        /// <summary>
        /// Entity which is displayed
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set
            {
                if (value != null)
                {
                    Show(value);
                }
                else
                {
                    throw new NullReferenceException("Entity is null");
                }
            }
        }

        /// <summary>
        /// Perform or no checkins before closing displayer
        /// </summary>
        public bool PerformCloseChecking
        {
            get { return performCloseChecking; }
            set { performCloseChecking = value; }
        }

        #endregion

        #endregion

        #region Methods

        #region public void Show(DisplayingEntity entity)
        /// <summary>
        /// Invokes displaying of entity
        /// </summary>
        /// <param name="entity">Entity to display</param>
        public void Show(IDisplayingEntity entity)
        {
            if (entity is Control)
            {
                if (Entity is Control)
                    Controls.Remove(Entity as Control);
                this.entity = entity;
                if (Entity is Control)
                {
                    Controls.Add(Entity as Control);
                }
                Entity.Show();
                Show();
            }
        }
        #endregion

        #region public bool ContainedDataEquals(IDisplayer obj)
        /// <summary>
        /// Checks whether contained data of two displayers are equal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayer obj)
        {
            return obj.Entity.ContainedData.Equals(Entity.ContainedData);
        }
        #endregion

        #region public bool ContainedDisplayingEntityEquals(IDisplayer obj)
        /// <summary>
        /// Checks whether displaying entities have same type
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ContainedDisplayingEntityEquals(IDisplayer obj)
        {
            return obj.Entity.GetType() == entity.GetType();
        }
        #endregion

        #region protected void OnDisplayerRemoved()
        /// <summary>
        /// Raises DisplayerRemoved event <see cref="DisplayerRemoved"/>
        /// </summary>
        protected void OnDisplayerRemoved()
        {
            if (DisplayerRemoved != null)
                DisplayerRemoved.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #endregion

        /// <summary>
        /// Occurs when the current displayer is removed from control collection
        /// </summary>
        public event EventHandler DisplayerRemoved;

        /// <summary>
        /// Проверяется возможность удаление отображателя
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoved(DisplayerCancelEventArgs arguments)
        {
            if (entity != null) 
                entity.OnDisplayerRemoving(arguments);
        }

        #region public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)

        /// <summary>
        /// Действия, происходящие при деактвации отображателя
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        {
            if (entity != null)
                entity.OnDisplayerDeselecting(arguments);
        }

        #endregion
    }
}