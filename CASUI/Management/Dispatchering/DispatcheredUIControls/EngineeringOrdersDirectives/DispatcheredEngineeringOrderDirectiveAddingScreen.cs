using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Directives;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.EngineeringOrdersDirectives;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.EngineeringOrdersDirectives
{
    /// <summary>
    /// Элемент упраления для добавления новой директивы <see cref="EngineeringOrderDirective"/>
    /// </summary>
    [ToolboxItem(false)]
    public class DispatcheredEngineeringOrderDirectiveAddingScreen : EngineeringOrderDirectiveAddingScreen, IDisplayingEntity
    {

        #region Fields

        private BaseDetail parentBaseDetail;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает Элемент упраления для добавления новой директивы <see cref="EngineeringOrderDirective"/>
        /// </summary>
        public DispatcheredEngineeringOrderDirectiveAddingScreen(BaseDetail parentBaseDetail) : base(parentBaseDetail)
        {
            this.parentBaseDetail = parentBaseDetail;
            Dock = DockStyle.Fill;
        }

        #endregion
        
        #region Properties

        #region public object ContainedData
        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return parentBaseDetail; }
            set
            {
                if (value is BaseDetail)
                    parentBaseDetail = (BaseDetail)value;
            }
        }
        #endregion

       /* #region public DirectiveType CurrentDirectiveType

        /// <summary>
        /// Тип директивы
        /// </summary>
        public DirectiveType CurrentDirectiveType
        {
            get
            {
                return directiveType;
            }
        }

        #endregion*/
        
        #endregion

        #region Methods

        #region public bool ContainedDataEquals(IDisplayingEntity obj)
        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredEngineeringOrderDirectiveAddingScreen))
                return false;
            if (!(obj.ContainedData is BaseDetail))
                return false;
            if (parentBaseDetail == null) return false;
                
            return parentBaseDetail.ID == ((BaseDetail)obj.ContainedData).ID;
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
            if (GetChangeStatus())
            {
                switch (MessageBox.Show("Do you want to save changes?", (string)new TermsProvider()["SystemName"],
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes:
                        if (!AddNewDirective(false))
                            arguments.Cancel = true;
                        break;
                    case DialogResult.Cancel:
                        arguments.Cancel = true;
                        break;
                }
            }
        }

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

        #endregion
                

    }
}