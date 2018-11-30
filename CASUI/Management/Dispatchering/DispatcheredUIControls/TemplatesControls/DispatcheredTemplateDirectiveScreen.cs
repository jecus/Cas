using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Directives.Templates;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.TemplatesControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls
{
    /// <summary>
    /// Элемент управления для отображения информации о директиве
    /// </summary>
    [ToolboxItem(false)]
    public class DispatcheredTemplateDirectiveScreen : TemplateDirectiveScreen, IDisplayingEntity
    {
        /// <summary>
        /// Отображаемая директива
        /// </summary>
        private TemplateBaseDetailDirective directive;

        ///<summary>
        /// Создается элемент управления для отображения информации о шаблонной директиве
        ///</summary>
        /// <param name="directive">Шаблонная директива для отображения</param>
        public DispatcheredTemplateDirectiveScreen(TemplateBaseDetailDirective directive) : base(directive)
        {
            if (directive == null) 
                throw new ArgumentNullException("directive");
            this.directive = directive;
            
            Dock = DockStyle.Fill;
            BackColor = Css.CommonAppearance.Colors.BackColor;
        }



        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return directive; }
            set
            {
                if (value is TemplateBaseDetailDirective)
                    directive = (TemplateBaseDetailDirective)value;
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
            if (!(obj is DispatcheredTemplateDirectiveScreen))
                return false;
            if (!(obj.ContainedData is TemplateBaseDetailDirective))
                return false;
            return directive.ID == ((TemplateBaseDetailDirective)obj.ContainedData).ID;
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
            if (generalDataAndPerformanceControl.GetChangeStatus(true) || attributesAndParametersControl.GetChangeStatus(true))
            {
                switch (MessageBox.Show("Do you want to save changes?", (string)new TermsProvider()["SystemName"],
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes:
                        arguments.Cancel = !Save(); 
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
           // double buffer;
            //arguments.Cancel |= !generalDataAndPerformanceControl.CheckManHours(out buffer);
           // arguments.Cancel |= !generalDataAndPerformanceControl.CheckLifelengthes();
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
