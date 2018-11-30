using System;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.OpepatorsControls;
using CASTerms;
using SmartCore.Entities.Collections;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.OpepatorsControls
{
    internal class DispatcheredOperatorCollectionScreen : OperatorsCollectionScreen, IDisplayingEntity
    {
        #region Implementation of IDisplayingEntity

        public void DisposeScreen()
        {
            Dispose(true);
        }

        #endregion
        
        public DispatcheredOperatorCollectionScreen()
        {
            Dock = DockStyle.Fill;
            InitComplition += DispatcheredOperatorCollectionScreenInitComplition;
        }

        void DispatcheredOperatorCollectionScreenInitComplition(object sender, EventArgs e)
        {
            if (GlobalObjects.CasEnvironment.Operators.Count == 1)
                operatorCollectionControl.OpenAircraftsScreen();
        }

        public object ContainedData
        {
            get
            {
                return Operators;
            }
            set
            {
                if (!(value is OperatorCollection)) throw new ArgumentException("Argument must be of type OperatorCollection");
                Operators = value as OperatorCollection;
            }
        }

        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredOperatorCollectionScreen)) return false;

            DispatcheredOperatorCollectionScreen collection = obj as DispatcheredOperatorCollectionScreen;
            return (collection.ContainedData == ContainedData);
        }

        /// <summary>
        /// Method call after add to IDisplayerCollectionProxy
        /// </summary>
        /// <returns></returns>
        public void OnInitCompletion(object sender)
        {
            if (InitComplition!=null) 
                InitComplition(sender,new EventArgs());
        }

        #region  public event EventHandler DisplayerRemoving
        /// <summary>
        /// Событие, оповещающее об удаленни содержимого (вкладку)
        /// </summary>
        public event EventHandler<EntityCancelEventArgs> EntityRemoving;

        #endregion

        #region public event EventHandler DisplayerRemoved
        /// <summary>
        /// Возникает после удаления содержимого
        /// </summary>
        public event EventHandler EntityRemoved;

        #endregion

        #region public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            if (arguments.ControlType == ControlType.Trivial)
            {

                MessageBox.Show("Closing this tab can cause impossible work.", new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                arguments.Cancel = true;
            }
        }

        #region public void OnDisplayerRemoved()
        /// <summary>
        /// Возбуждает событие после удаления отображаемого объекта
        /// </summary>
        public void OnDisplayerRemoved()
        {

        }

        #endregion

        /// <summary>
        /// Действия, происходящие при деактивации вкладки, содержащей данную сущность
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        {
            
        }

        /// <summary>
        /// Метод меняюший состояние конторола [:|||:]
        /// </summary>
        /// <param name="isEnbaled">состояние</param>
        public void SetEnabled(bool isEnbaled)
        {
            SetEnbaledToControls(isEnbaled);
        }

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;

        #endregion
        
    }
}