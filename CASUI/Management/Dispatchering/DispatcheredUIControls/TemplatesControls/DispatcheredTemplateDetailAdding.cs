using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.Core;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.TemplatesControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.TemplatesControls
{
    /// <summary>
    /// Класс, описываюший отображение добавления агрегата
    /// </summary>
    [ToolboxItem(false)]
    public class DispatcheredTemplateDetailAdding : TemplateDetailAdding, IDisplayingEntity
    {

        #region Fields

        /// <summary>
        /// Базовый агрегат дял которого будет происходить добавление агрегата
        /// </summary>
        private ITemplateDetailContainer parentDetail;

        #endregion

        #region Constructor

        ///<summary>
        /// Создается элемент отображения добавления шаблонного агрегата
        ///</summary>
        /// <param name="parentDetail">Базовый агрегат для которго добавляется шаблонный агрегат</param>
        public DispatcheredTemplateDetailAdding(ITemplateDetailContainer parentDetail) : base(parentDetail)
        {
            
        }

        #endregion

        #region Properties

        #region public object ContainedData

        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return parentDetail; }
            set
            {
                if (value is TemplateBaseDetail)
                    parentDetail = (TemplateBaseDetail)value;
            }
        }

        #endregion

        #endregion

        #region public bool ContainedDataEquals(IDisplayingEntity obj)
        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredTemplateDetailAdding))
                return false;
            if (!(obj.ContainedData is TemplateBaseDetail))
                return false;
            if (!(parentDetail is CoreType)) return false;
            return ((CoreType)parentDetail).ID == ((TemplateBaseDetail)obj.ContainedData).ID;
        }

        /// <summary>
        /// Method call after add to IDisplayerCollectionProxy
        /// </summary>

        /// <returns></returns>
        public void OnInitCompletion(object sender)
        {
            if (InitComplition != null)
                InitComplition(sender, new EventArgs());

        }
        #endregion

        #region public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            if (generalInformationControl.GetChangeStatus(addedDetail) || limitationControl.GetChangeStatusOfNewDetail() || parametersControl.GetChangeStatus(addedDetail))
            {
                switch (MessageBox.Show("Do you want to save changes?", (string)new TermsProvider()["SystemName"],
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes:
                        if (!AddNewDetail(false))
                            arguments.Cancel = true;
                        break;
                    case DialogResult.Cancel:
                        arguments.Cancel = true;
                        break;
                }
            }
        }

        #endregion

        #region public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)

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

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;
        #endregion
    }
}