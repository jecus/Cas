using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Directives;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.DirectivesControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls
{
    public class DispatcheredOutOffPhaseReferenceScreen : OutOffPhaseReferenceScreen, IDisplayingEntity
    {
        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения <see cref="EngineeringOrderDirective"/>
        /// </summary>
        /// <param name="directive">Сама дирктива</param>
        public DispatcheredOutOffPhaseReferenceScreen(BaseDetailDirective directive)
            : base(directive)
        {
            Dock = DockStyle.Fill;
        }

        #endregion


        #region IDisplayingEntity Members

        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return directive; }
            set
            {
                if (value is BaseDetailDirective)
                    directive = (BaseDetailDirective)value;
            }
        }



        #region public bool ContainedDataEquals(IDisplayingEntity obj)
        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        bool IDisplayingEntity.ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredOutOffPhaseReferenceScreen))
                return false;
            if (!(obj.ContainedData is BaseDetailDirective))
                return false;
            return directive.ID == ((BaseDetailDirective)obj.ContainedData).ID;
        }

        public void OnInitCompletion(object sender)
        {
        }

        #endregion

        #region public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)

        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            if (GetChangeStatus())
            {
                switch (MessageBox.Show("Do you want to save changes?", (string)new TermsProvider()["SystemName"],
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes:
                        //arguments.Cancel = !Save(); 
                        SaveData();
                        break;
                    case DialogResult.Cancel:
                        arguments.Cancel = true;
                        break;
                }
            }
        }

        #endregion

        /// <summary>
        /// Действия, происходящие при деактивации вкладки, содержащей данную сущность
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        {
        }

        public void SetEnabled(bool isEnbaled)
        {

        }

        public event EventHandler InitComplition;

        #endregion
    }
}
