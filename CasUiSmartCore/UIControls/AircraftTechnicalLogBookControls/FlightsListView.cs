using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class FlightsListView : BaseListViewControl<AircraftFlight>
    {
        #region Fields

        private readonly Aircraft _parentAircraft;
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
        public FlightsListView(Aircraft parentAircraft)
            : this()
        {
            OldColumnIndex = 0;
	        SortMultiplier = 0;
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

            var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Page No" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Flight No" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Date" };
            ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Time" };
	        ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Route" };
            ColumnHeaderList.Add(columnHeader);

            itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(AircraftFlight item)

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(AircraftFlight item)
        {
            var subItems = new ListViewItem.ListViewSubItem[5];
	        var dateString = item.FlightDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());

	        var timeString = "";
	        
			if (item.AtlbRecordType != AtlbRecordType.Maintenance)
				timeString = $"{UsefulMethods.TimeToString(TimeSpan.FromMinutes(item.OutTime))} - {UsefulMethods.TimeToString(TimeSpan.FromMinutes(item.InTime))}";

            var date = item.FlightDate.Date;
            date = date.AddMinutes(item.OutTime);

	        string route;
			if (item.AtlbRecordType != AtlbRecordType.Maintenance)
				route = item.StationFromId.ShortName + " - " + item.StationToId.ShortName;
			else route = item.StationToId.ShortName;

			subItems[0] = new ListViewItem.ListViewSubItem { Text = item.PageNo, Tag = item.PageNo };
            subItems[1] = new ListViewItem.ListViewSubItem { Text = item.FlightNumber.ToString(), Tag = item.FlightNumber };
            subItems[2] = new ListViewItem.ListViewSubItem { Text = dateString, Tag = date };
            subItems[3] = new ListViewItem.ListViewSubItem { Text = timeString, Tag = date };
            subItems[4] = new ListViewItem.ListViewSubItem { Text = route, Tag = route };

            return subItems;
        }

        #endregion

        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

        protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            if (SelectedItem != null)
            {
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.RequestedEntity = new FlightScreen(SelectedItem);
                e.DisplayerText = _parentAircraft.RegistrationNumber + ". " + SelectedItem; 
            }
        }
		#endregion

		protected override void SetGroupsToItems(int columnIndex)
		{
			itemsListView.Groups.Clear();
			foreach (ListViewItem item in ListViewItemList.OrderByDescending(i => (i.Tag as AircraftFlight).FlightDate))
			{
				string temp;

				if (item.Tag is AircraftFlight)
				{
					var flight = item.Tag as AircraftFlight;

					temp = $"{flight.FlightDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString())}";
					itemsListView.Groups.Add(temp, temp);
					item.Group = itemsListView.Groups[temp];
				}
			}
		}


	    protected override void SortItems(int columnIndex)
	    {
		    if (OldColumnIndex != columnIndex)
			    SortMultiplier = -1;
		    if (SortMultiplier == 1)
			    SortMultiplier = -1;
		    else
			    SortMultiplier = 1;
		    itemsListView.Items.Clear();
		    OldColumnIndex = columnIndex;

		    SetGroupsToItems(columnIndex);

		    List<ListViewItem> resultList = new List<ListViewItem>();

			    ListViewItemList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));

			    foreach (ListViewItem item in ListViewItemList)
			    {
				    if (item.Tag is AircraftFlight)
				    {
					    resultList.Add(item);
					}
			    }


		    itemsListView.Items.AddRange(resultList.ToArray());
		}


	    #endregion
		}
}
