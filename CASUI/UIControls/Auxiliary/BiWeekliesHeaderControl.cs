using System.Drawing;
using CAS.UI.Management;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.BiWeekliesControls;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// Элемент управления для перехода к коллекции BiWeekly отчетов
    ///</summary>
    public class BiWeekliesHeaderControl : AbstractOperatorHeaderControl
    {

        #region Fields

        private readonly Icons icons = new Icons();

        #endregion
        
        #region Constructors

        #region public BiWeekliesHeaderControl()

        ///<summary>
        /// Создается новый объект для перехода к коллекции BiWeekly отчетов
        ///</summary>
        public BiWeekliesHeaderControl()
        {
            UpdateOperatorInfo("BiWeekly Reports", icons.BiWeeklyReports);
            OperatorClickable = false;
        }

        #endregion

        #region public BiWeekliesHeaderControl(bool biWeekliesClickable)

        ///<summary>
        /// Создается новый объект для перехода к коллекции BiWeekly отчетов
        ///</summary>
        public BiWeekliesHeaderControl(bool biWeekliesClickable)
        {
            UpdateOperatorInfo("BiWeekly Reports", icons.BiWeeklyReports);
            OperatorClickable = biWeekliesClickable;
        }

        #endregion

        #region public BiWeekliesHeaderControl(string caption, Image logotype)

        ///<summary>
        /// Создается новый объект для перехода к коллекции BiWeekly отчетов
        ///</summary>
        public BiWeekliesHeaderControl(string caption, Image logotype)
        {
            UpdateOperatorInfo(caption, logotype);
            OperatorClickable = false;
        }

        #endregion

        #endregion

        #region Methods

        #region protected override void logotypeButton_DisplayerRequested(object sender, ReferenceEventArgs e)

        protected override void logotypeButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (OperatorClickable)
            {
                e.DisplayerText = "BiWeekly Reports";
                e.RequestedEntity = new DispatcheredBiWeekliesCollectionScreen();
            }
            else
                e.Cancel = true;
        }

        #endregion

        #endregion

    }
}
