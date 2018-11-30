using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using LTR.Core;
using LTR.UI.Interfaces;
using LTR.UI.Management.Dispatchering.DispatcheredUIControls;
using LTR.UI.UIControls.Auxiliary;
using LTR.UI.UIControls.OpepatorsControls;
using LTR.UI.UIControls.ReferenceControls;

namespace LTR.UI.UIControls.DirectivesControls
{
    public partial class OperatorScreen : UserControl
    {
        /// <summary>
        /// Создаёт экземпляр контрола, отображающего воздушное судно
        /// </summary>
        public OperatorScreen()
        {
            InitializeComponent();
        }

        ///<summary>
        /// Создается элемент отображения оператора
        ///</summary>
        ///<param name="currentAircraft">Воздушное судно для отображения</param>
        ///<exception cref="ArgumentNullException"></exception>
        public OperatorScreen(Aircraft currentAircraft)
            : this()
        {
            if (currentAircraft == null) throw new ArgumentNullException("currentAircraft", "Cannot display null-aircraft");
            this.currentAircraft = currentAircraft;

            UpdateHeader();
            UpdateLogBookInformation();
            UpdateBiweeklyInformation();
            UpdateDisrepanciesInformation();
        }

        private void ReferenceLogBook_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
        }

        private void ShowAllBiWeekliesReference_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredUIBiWeeklyReportCollection();
        }

        private void Reference_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredUIDiscrepancyCollection();
        }

        private void UpdateBiweeklyInformation()
        {
        }

        private void UpdateDisrepanciesInformation()
        {
        }

        private void UpdateLogBookInformation()
        {
        }

        private void UpdateOperatorInfo()
        {
            
        }

        private void UpdateHeader()
        {
            
        }

        private void mainPanel_SizeChanged(object sender, EventArgs e)
        {
            //SetWidthLimitation(Width - flowLayoutPanelRight.Width, 1000);
        }

        private void SetWidthLimitation(int width, int height)
        {
            //panelAircraftsContainer.MaximumSize = new Size(width, height);
            //if (aircrafts != null) 
            //    aircrafts.SetWidthLimitation(width, height);
        }
    }
}