using System;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.LogBookControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.LogBookControls
{
/*
    /// <summary>
    /// Элемент управления для отображения информации о наработках базовах агрегатов
    /// </summary>
    public partial class DispatcheredBaseDetailLogBookScreen : BaseDetailLogBookScreen, IDisplayingEntity
    {

        #region Constructors

        #region public DispatcheredBaseDetailLogBookScreen(BaseDetail currentDetail): base(currentDetail)

        public DispatcheredBaseDetailLogBookScreen(BaseDetail currentDetail): base(currentDetail)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #endregion
        
        #region public DispatcheredBaseDetailLogBookScreen(BaseDetail currentDetail, DateTime startDate, DateTime endDate): base(currentDetail, startDate, endDate)

        /// <summary>
        /// Создает элемент управления для отображения информации о наработках базовах агрегатов
        /// </summary>
        /// <param name="currentDetail">Текущий агрегат</param>
        /// <param name="startDate">Дата, с которой следует отображать наработки</param>
        /// <param name="endDate">Дата, по которую следует отображать наработки</param>
        public DispatcheredBaseDetailLogBookScreen(BaseDetail currentDetail, DateTime startDate, DateTime endDate): base(currentDetail, startDate, endDate)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #endregion

        #endregion
        
        #region IDisplayingEntity Members
        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return currentDetail; }
            set
            {
                if (value is BaseDetail)
                    currentDetail = value as BaseDetail;
            }
        }

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredBaseDetailLogBookScreen)) return false;
            if (!(obj.ContainedData is BaseDetail)) return false;

            return (currentDetail.ID == ((BaseDetail)obj.ContainedData).ID);
        }

        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
        }

        /// <summary>
        /// Действия, происходящие при деактивации вкладки, содержащей данную сущность
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        {
            
        }

        #endregion
    }
*/
}
