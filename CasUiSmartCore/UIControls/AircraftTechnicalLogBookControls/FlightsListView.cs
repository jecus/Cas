using System;
using System.Collections.Generic;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class FlightsListView : BaseGridViewControl<AircraftFlight>
    {
        #region Fields

        private readonly Aircraft _parentAircraft;
        private readonly bool _allView;

        #endregion

        #region Constructors

        #region private FlightsListView()
        ///<summary>
        ///</summary>
        private FlightsListView()
        {
            InitializeComponent();
        }
        #endregion

        #region public FlightsListView(Aircraft parentAircraft) : this()
        ///<summary>
        ///</summary>
        public FlightsListView(Aircraft parentAircraft, bool allView = false)
            : this()
        {
            OldColumnIndex = 0;
	        SortMultiplier = 1;
            _parentAircraft = parentAircraft;
			_allView = allView;
        }
        #endregion

        #endregion

        #region Methods

        #region protected override void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
	        AddColumn("Page No", (int)(radGridView1.Width * 0.20f));
	        AddColumn("Flight No", (int)(radGridView1.Width * 0.20f));
	        AddDateColumn("Date", (int)(radGridView1.Width * 0.20f));
	        AddColumn("Time", (int)(radGridView1.Width * 0.20f));
	        AddColumn("Route", (int)(radGridView1.Width * 0.20f));
	        AddColumn("Signer", (int)(radGridView1.Width * 0.20f));
        }
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(AircraftFlight item)

        protected override List<CustomCell> GetListViewSubItems(AircraftFlight item)
        {
	        var dateString = item.FlightDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());

	        var timeString = "";
	        
			if (item.AtlbRecordType != AtlbRecordType.Maintenance)
				timeString = $"{UsefulMethods.TimeToString(TimeSpan.FromMinutes(item.OutTime))} - {UsefulMethods.TimeToString(TimeSpan.FromMinutes(item.InTime))}";

            var date = item.FlightDate.Date;
            date = date.AddMinutes(item.OutTime);
            var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

			string route;
			if (item.AtlbRecordType != AtlbRecordType.Maintenance)
				route = item.StationFromId.ShortName + " - " + item.StationToId.ShortName;
			else route = item.StationToId.ShortName;


			return new List<CustomCell>()
			{
				CreateRow(item.PageNo, item.PageNo),
				CreateRow(item.FlightNumber.ToString(), item.FlightNumber),
				CreateRow(dateString, item.FlightDate.Date),
				CreateRow(timeString, timeString),
				CreateRow(route, route),
				CreateRow(author, author),
			};
        }

        #endregion

        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

        protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            if (SelectedItem != null)
            {
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.RequestedEntity = new FlightScreen(SelectedItem, true, _allView);
                e.DisplayerText = _parentAircraft.RegistrationNumber + ". " + SelectedItem; 
            }
        }
		#endregion

		protected override void GroupingItems()
		{
			Grouping("Date");
		}

		#endregion
	}
}
