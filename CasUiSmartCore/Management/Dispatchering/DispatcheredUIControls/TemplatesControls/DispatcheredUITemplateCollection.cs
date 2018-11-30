using System.Windows.Forms;
using LTR.UI.Interfaces;
using LTR.UI.UIControls.TemplatesControls;

namespace LTR.UI.Management.Dispatchering.DispatcheredUIControls.TemplatesControls
{
    /// <summary>
    /// Элемент управления для отображения коллекций шаблонов
    /// </summary>
    public partial class DispatcheredUITemplateCollection : UITemplateCollection, IDisplayingEntity
    {
        /// <summary>
        /// Создает элемент управления для отображения коллекций шаблонов
        /// </summary>
        public DispatcheredUITemplateCollection()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #region IDisplayingEntity Members
        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return this; }
            set { }
        }

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (obj is DispatcheredUITemplateCollection)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
        }
        #endregion
    }
}