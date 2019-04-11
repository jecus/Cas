using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class ATLBListView : BaseListViewControl<ATLB>
    {
        #region Fields

        private readonly Aircraft _parentAircraft;
        #endregion

        #region Constructors

        #region private ATLBListView()
        ///<summary>
        ///</summary>
        private ATLBListView()
        {
            InitializeComponent();
        }
        #endregion

        #region public ATLBListView(Aircraft parentAircraft) : this()
        ///<summary>
        ///</summary>
        public ATLBListView(Aircraft parentAircraft)
            : this()
        {
            OldColumnIndex = 2;
            SortMultiplier = 1;
            _parentAircraft = parentAircraft;
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
            itemsListView.Columns.Clear();
            ColumnHeaderList.Clear();

            ColumnHeader columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.15f), Text = "ATLB No" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.25f), Text = "Pages" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.3f), Text = "Date" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Author" };
            ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(ATLB item)

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(ATLB item)
        {
            var subItems = new ListViewItem.ListViewSubItem[3];

	        var flights = GlobalObjects.AircraftFlightsCore.GetAircraftFlightsByAircraftId(_parentAircraft.ItemId);

			var first = flights.GetFirstFlightInAtlb(item.ItemId);
            var last = flights.GetLastFlightInAtlb(item.ItemId);
            var pages = (first != null && first.PageNo != "" ? first.PageNo : "XXX") + " - " +
                           (last != null && last.PageNo != "" ? last.PageNo : "XXX");
            var dates = (first != null ? UsefulMethods.NormalizeDate(first.FlightDate.Date) : "YY:MM:DD") + " - " +
                           (last != null ? UsefulMethods.NormalizeDate(last.FlightDate.Date) : "YY:MM:DD");

            var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

			subItems[0] = new ListViewItem.ListViewSubItem { Text = item.ATLBNo, Tag = item.ATLBNo };
            subItems[1] = new ListViewItem.ListViewSubItem { Text = pages, Tag = pages };
            subItems[2] = new ListViewItem.ListViewSubItem { Text = dates, Tag = last != null ? last.FlightDate : DateTimeExtend.GetCASMinDateTime() };
            subItems[3] = new ListViewItem.ListViewSubItem { Text = author, Tag = author };

			return subItems;
        }

		#endregion

		#region protected override void SetGroupsToItems(int columnIndex)

	    protected override void SetGroupsToItems(int columnIndex)
	    {
		    itemsListView.Groups.Clear();
		    foreach (ListViewItem item in ListViewItemList)
		    {
			    string temp;

			    if (item.Tag is ATLB)
			    {
				    var atlb = item.Tag as ATLB;
				    temp = atlb.AtlbStatus.ToString();
				    itemsListView.Groups.Add(temp, temp);
				    item.Group = itemsListView.Groups[temp];
			    }
		    }
	    }

	    #endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            if (SelectedItem != null)
            {
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.DisplayerText = _parentAircraft.RegistrationNumber + ". ATLB No " + SelectedItem.ATLBNo;
                e.RequestedEntity = new FlightsListScreen(SelectedItem);
            }
        }
        #endregion

        #endregion
    }
}
