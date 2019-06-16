using System.Collections.Generic;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class ATLBListView : BaseGridViewControl<ATLB>
    {
        #region Fields

        private readonly Aircraft _parentAircraft;
        private readonly bool _showDefects;

        #endregion

        #region Constructors

        #region private ATLBListView()
        ///<summary>
        ///</summary>
        public ATLBListView()
        {
            InitializeComponent();

            OldColumnIndex = 2;
            SortMultiplier = 1;
		}

        

        #endregion

        #region public ATLBListView(Aircraft parentAircraft) : this()
        ///<summary>
        ///</summary>
        public ATLBListView(Aircraft parentAircraft, bool showDefects = false)
            : this()
        {
            OldColumnIndex = 3;
            SortMultiplier = 1;
            _parentAircraft = parentAircraft;
            _showDefects = showDefects;
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
	        AddColumn("Status", (int)(radGridView1.Width * 0.30f));
	        AddColumn("ATLB No", (int)(radGridView1.Width * 0.30f));
	        AddColumn("Pages", (int)(radGridView1.Width * 0.50f));
	        AddColumn("Date", (int)(radGridView1.Width * 0.6f));
	        AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
        }
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(ATLB item)

        protected override List<CustomCell> GetListViewSubItems(ATLB item)
        {
            AircraftFlightCollection flights;
            AircraftFlight first;
            AircraftFlight last;

			if (_parentAircraft != null)
            {
				flights = GlobalObjects.AircraftFlightsCore.GetAircraftFlightsByAircraftId(_parentAircraft.ItemId);
	            first = flights.GetFirstFlightInAtlb(item.ItemId);
	            last = flights.GetLastFlightInAtlb(item.ItemId);
			}
            else
            {
	            first = GlobalObjects.AircraftFlightsCore.GetFirstFlight(item.ItemId);
				last = GlobalObjects.AircraftFlightsCore.GetLastFlight(item.ItemId);
			}
			
            var pages = (first != null && first.PageNo != "" ? first.PageNo : "XXX") + " - " +
                           (last != null && last.PageNo != "" ? last.PageNo : "XXX");
            var dates = (first != null ? UsefulMethods.NormalizeDate(first.FlightDate.Date) : "YY:MM:DD") + " - " +
                           (last != null ? UsefulMethods.NormalizeDate(last.FlightDate.Date) : "YY:MM:DD");

            var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

            return new List<CustomCell>()
            {
	            CreateRow(item.AtlbStatus.ToString(), item.AtlbStatus),
	            CreateRow(item.ATLBNo, item.ATLBNo),
	            CreateRow(pages, pages),
	            CreateRow(dates, last != null ? last.FlightDate : DateTimeExtend.GetCASMinDateTime()),
	            CreateRow(author, author)
            };
        }

		#endregion

		#region protected override void SetGroupsToItems(int columnIndex)

		#region Overrides of BaseGridViewControl<ATLB>

		protected override void GroupingItems()
		{
			Grouping("Status");
		}

		#endregion

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            if (SelectedItem != null)
            {
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.DisplayerText = _parentAircraft.RegistrationNumber + ". ATLB No " + SelectedItem.ATLBNo;
                e.RequestedEntity = new FlightsListScreen(SelectedItem, _showDefects);
            }
        }
        #endregion

        #endregion
    }
}
