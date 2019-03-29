using System;
using CAS.UI.Management;
using SmartCore.Entities.General.Store;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Класс, описывающий отображение состояния ВС и краткой информации
    /// </summary>
    public class StoreStateItem : AbstractAircraftStateItem
    {

        #region Fields

        private Store currentItem;
        private readonly Icons icons = new Icons();

        #endregion

        #region Constructors

        #region public StoreStateItem()

        ///<summary>
        /// Создается класс, описывающий отображение состояния ВС и краткой информации
        ///</summary>
        public StoreStateItem()
        {
        }

        #endregion

        #region public StoreStateItem(Store currentItem)

        /// <summary>
        /// Создается новый объект отображения ВС
        /// </summary>
        /// <param name="currentItem">Отображаемый объект</param>
        public StoreStateItem(Store currentItem)
        {
            if (currentItem == null) throw new ArgumentNullException("currentItem");
                CurrentItem = currentItem;
        }

        #endregion

        #endregion

        #region Properties

        #region public Store CurrentItem
        ///<summary>
        /// Текущее ВС
        ///</summary>
        public Store CurrentItem
        {
            get { return currentItem; }
            set
            {
                currentItem = value;
                UpdateInformation();
            }
        }
        #endregion

        #endregion

        #region Methods

        #region private void UpdateInformation()

        ///<summary>
        /// Обновляется отображаемая информация
        ///</summary>
        private void UpdateInformation()
        {
            if (currentItem != null)
            {
                /*if (currentItem == DirectiveConditionState.NotSatisfactory)
                {
                    Icon = icons.RedArrow;
                }
                else if (currentItem.ConditionState == DirectiveConditionState.Notify)
                {
                    Icon = icons.OrangeArrow;
                }
                else
                {*/
                    Icon = icons.GreenArrow;
                //}
                TextMain = currentItem.Name;
                TextSecondary = currentItem.Location;
            }
        }

        #endregion

        #endregion


    }
}
