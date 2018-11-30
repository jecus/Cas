using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CASReports.Builders;


namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    /// <summary>
    /// Элемент управления для отображения информации о шасси ВС
    /// </summary>
    public partial class LandingGearsControl : PictureBox
    {

        #region Fields

        private const int MARGIN = 30;
        private const int TOP_MARGIN = 20;
        private const int BOTTOM_MARGIN = 20;
        //private Detail[] details;
        private readonly Aircraft currentAircraft;
        private readonly List<LandingGearControl> landingGears = new List<LandingGearControl>();
        private DateTime dateAsOf;
        private readonly Panel mainPanel = new Panel();
        private readonly ReferenceLinkLabel linkLandingGearStatus = new ReferenceLinkLabel();

        #endregion
        
        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения информации о шасси ВС
        /// </summary>
        /// <param name="aircraft">ВС</param>
        /// <param name="dateAsOf">Дата, на которую загружаются данные</param>
        public LandingGearsControl(Aircraft aircraft, DateTime dateAsOf)
        {
            currentAircraft = aircraft;
            //DetailCollectionFilter collectionFilter = new DetailCollectionFilter(currentAircraft.ContainedDetails, new DetailFilter[] { new LandingGearsFilter(true, true, true) });
          //  details = collectionFilter.GatherDetails();
            if (aircraft.LandingGears.Length > 0) 
                Size = new Size((LandingGearControl.StandartSize.Width)*3 + MARGIN*2,LandingGearControl.StandartSize.Height + TOP_MARGIN + BOTTOM_MARGIN);
            else
                Size = new Size(0,0);
            this.dateAsOf = dateAsOf;
            //
            // mainPanel
            //
            mainPanel.AutoSize = true;
            mainPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainPanel.SizeChanged += mainPanel_SizeChanged;
            //
            // linkLandingGearStatus
            //
            linkLandingGearStatus.AutoSize = true;
            linkLandingGearStatus.Font = Css.SimpleLink.Fonts.Font;
            linkLandingGearStatus.LinkColor = Css.SimpleLink.Colors.LinkColor;
            linkLandingGearStatus.Text = "View Landing Gear Status";
            linkLandingGearStatus.TextAlign = ContentAlignment.MiddleLeft;
            linkLandingGearStatus.ReflectionType = ReflectionTypes.DisplayInNew;
            linkLandingGearStatus.DisplayerRequested += linkLandingGearStatus_DisplayerRequested;
            
            Controls.Add(mainPanel);
            Controls.Add(linkLandingGearStatus);

            UpdateControl();
        }

        #endregion

        #region Properties

        #region public DateTime DateAsOf

        /// <summary>
        /// Возвращает или устанавливает дату DateAsOf
        /// </summary>
        public DateTime DateAsOf
        {
            get
            {
                return dateAsOf;
            }
            set
            {
                dateAsOf = value;
                UpdateDateAsOf();
            }
        }

        #endregion

        #endregion
        
        #region Methods

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            for (int i = 0; i < landingGears.Count; i++)
            {
                if (landingGears[i].GetChangeStatus())
                    return true;
            }
            return false;
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные двигателей текущего ВС
        /// </summary>
        public void SaveData()
        {
            for (int i =0; i < landingGears.Count; i++)
            {
                landingGears[i].SaveData();
            }
        }

        #endregion

        #region public void UpdateControl()

        /// <summary>
        /// Обновляет информацию о двигателях текущего ВС
        /// </summary>
        public void UpdateControl()
        {
            List<GearAssembly> gearAssemblies = new List<GearAssembly>(currentAircraft.LandingGears);
            gearAssemblies.Sort(new LandingGearPositionSerialNumberComparer());
            
            mainPanel.Controls.Clear();
            landingGears.Clear();
            for (int i = 0; i < gearAssemblies.Count; i++)
            {
                if (i == 0)
                {
                    landingGears.Add(new LandingGearControl(gearAssemblies[i], DateAsOf, true));
                    landingGears[i].Location = new Point(0, TOP_MARGIN);
                }
                else
                {
                    landingGears.Add(new LandingGearControl(gearAssemblies[i], DateAsOf, false));
                    landingGears[i].Location = new Point(landingGears[i - 1].Right + MARGIN, TOP_MARGIN);
                }
            }
            mainPanel.Controls.AddRange(landingGears.ToArray());
        }

        #endregion

        #region private void UpdateDateAsOf()

        private void UpdateDateAsOf()
        {
            for (int i = 0; i < landingGears.Count; i++)
            {
                landingGears[i].DateAsOf = dateAsOf;
            }
        }

        #endregion

        #region private void mainPanel_SizeChanged(object sender, EventArgs e)

        private void mainPanel_SizeChanged(object sender, EventArgs e)
        {
            linkLandingGearStatus.Location = new Point(0, mainPanel.Bottom);
        }

        #endregion

        #region private void linkLandingGearStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkLandingGearStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = currentAircraft.RegistrationNumber + ". Component Status";
            e.RequestedEntity = new DispatcheredComponentStatusScreen(currentAircraft, new DetailCollectionFilter(new DetailFilter[] { new AllDetailFilter() }), new DetailCollectionFilter(new DetailFilter[] { new LandingGearsFilter(true, true, true, true) }), new LandingGearStatusReportBuilder(currentAircraft));
        }

        #endregion

        #endregion


    }
}
