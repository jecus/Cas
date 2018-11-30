using System;
using System.Windows.Forms;
using CAS.Core.Core.Settings;
using CAS.Core.ProjectTerms;
using CAS.Core.Types;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftsControls;
using CAS.UI.UIControls.OpepatorsControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.OpepatorsControls
{
    internal class DispatcheredOperatorCollectionScreen : OperatorsCollectionScreen, IDisplayingEntity
    {

        public DispatcheredOperatorCollectionScreen()
        {
            Dock = DockStyle.Fill;
            InitComplition += DispatcheredOperatorCollectionScreen_InitComplition;
        }

        void DispatcheredOperatorCollectionScreen_InitComplition(object sender, EventArgs e)
        {
            if (OperatorCollection.Instance.Count == 1)
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

        #region public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            if (arguments.ControlType == ControlType.Trivial)
            {

                MessageBox.Show("Closing this tab can cause impossible work.", new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                arguments.Cancel = true;
            }
        }

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