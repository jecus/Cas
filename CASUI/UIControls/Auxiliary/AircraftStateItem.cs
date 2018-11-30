using System;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Management;
using CAS.Core.Types.Dictionaries;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Класс, описывающий отображение состояния ВС и краткой информации
    /// </summary>
    public class AircraftStateItem : AbstractAircraftStateItem
    {

        #region Fields

        private Aircraft currentItem;
        private readonly Icons icons = new Icons();

        #endregion

        #region Constructors

        #region public AircraftStateItem()

        ///<summary>
        /// Создается класс, описывающий отображение состояния ВС и краткой информации
        ///</summary>
        public AircraftStateItem()
        {
        }

        #endregion

        #region public AircraftStateItem(Aircraft currentItem)

        /// <summary>
        /// Создается новый объект отображения ВС
        /// </summary>
        /// <param name="currentItem">Отображаемый объект</param>
        public AircraftStateItem(Aircraft currentItem)
        {
            if (currentItem == null) throw new ArgumentNullException("currentItem");
                CurrentItem = currentItem;
        }

        #endregion

        #endregion

        #region Properties

        #region public Aircraft CurrentItem
        ///<summary>
        /// Текущее ВС
        ///</summary>
        public Aircraft CurrentItem
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
                if (currentItem.ConditionState == DirectiveConditionState.NotSatisfactory)
                {
                    Icon = icons.RedArrow;
                }
                else if (currentItem.ConditionState == DirectiveConditionState.Notify)
                {
                    Icon = icons.OrangeArrow;
                }
                else
                {
                    Icon = icons.GreenArrow;
                }
                TextMain = currentItem.RegistrationNumber;
                TextSecondary = currentItem.Model;
            }
        }

        #endregion

        #endregion


    }
}
