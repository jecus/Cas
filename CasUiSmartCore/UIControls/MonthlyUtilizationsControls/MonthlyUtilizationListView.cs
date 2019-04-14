using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AircraftTechnicalLogBookControls;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.MonthlyUtilizationsControls
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class MouthlyUtilizationListView : BaseListViewControl<AircraftFlight>
    {
        #region Fields

        private readonly Aircraft _parentAircraft;
        private BaseComponentCollection _enginesAndAPU = new BaseComponentCollection();
        private ICommonCollection<ATLB> _atbs;
        private AircraftFlightCollection _flights = new AircraftFlightCollection();

        #endregion

        #region Constructors

        #region private MouthlyUtilizationListView()
        ///<summary>
        ///</summary>
        private MouthlyUtilizationListView()
        {
            InitializeComponent();
        }
        #endregion

        #region public MouthlyUtilizationListView(Aircraft parentAircraft) : this()
        ///<summary>
        ///</summary>
        public MouthlyUtilizationListView(Aircraft parentAircraft, ICommonCollection<ATLB> atlbCollection)
            : this()
        {
            SortMultiplier = 1;
            OldColumnIndex = 0;
            _parentAircraft = parentAircraft;
            _atbs = atlbCollection;
        }
        #endregion

        #endregion

        #region Methods

        #region public override void DisposeView()

        public override void DisposeView()
        {
            base.DisposeView();

            if(_atbs != null)
                _atbs.Clear();
        }
        #endregion

        #region protected void AddItem(AircraftFlight item)

        /// <summary>
        /// Добавляет элемент в список технических записей (AircraftFlight)
        /// </summary>
        /// <param name="item">Добавляемая техническая запись (AircraftFlight)</param>
        protected override void AddItem(AircraftFlight item)
        {
            try
            {
                ListViewItem listViewItem = new ListViewItem(GetListViewSubItems(item), null) { Tag = item, UseItemStyleForSubItems = false};
                ListViewItemList.Add(listViewItem);
                return;
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log(ex);
            }
            return;
        }
        #endregion

        #region public override void SetItemsArray(AircraftFlight[] itemsArray)
        /// <summary>
        /// Заполняет listview элементами
        /// </summary>
        /// <param name="itemsArray">Массив элементов</param>
        public override void SetItemsArray(AircraftFlight[] itemsArray)
        {
            if (itemsArray == null)
                throw new ArgumentNullException("itemsArray", "itemsArray can't be null");

            _flights.Clear();
            _flights.AddRange(itemsArray);

            _enginesAndAPU.Clear();
            _enginesAndAPU.AddRange(GlobalObjects.ComponentCore.GetAicraftBaseComponents(_parentAircraft.ItemId).
                Where(d => d.BaseComponentType == BaseComponentType.Engine || d.BaseComponentType == BaseComponentType.Apu));

            SetHeaders();

            base.SetItemsArray(itemsArray);
        }
        #endregion

        #region protected override void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
            itemsListView.Columns.Clear();
            ColumnHeaderList.Clear();

	        ColumnHeader columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Page No" };
	        ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Date" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Flight No" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Direction" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Flight time" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Block time" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Per Days (Flight)" };
            ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Per Days (Block)" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Aircraft (Flight)" };
            ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = "Aircraft (Block)" };
			ColumnHeaderList.Add(columnHeader);

			#region колонки для отображения наработок по двигателям и ВСУ

			foreach (var baseComponent in _enginesAndAPU)
            {
	            if (baseComponent.BaseComponentType == BaseComponentType.Engine)
	            {
					columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = string.Format("{0} (Flight)", baseComponent.ToString()) };
					ColumnHeaderList.Add(columnHeader);
					columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = string.Format("{0} (Block)", baseComponent.ToString()) };
					ColumnHeaderList.Add(columnHeader);
					if (baseComponent.ComponentDirectives.Count(dd => dd.DirectiveType == ComponentRecordType.Overhaul) > 0)
					{
						columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = baseComponent + " SLSV Flight" };
						ColumnHeaderList.Add(columnHeader);
						columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = baseComponent + " SLSV Block" };
						ColumnHeaderList.Add(columnHeader);
					}
				}
				else if (baseComponent.BaseComponentType == BaseComponentType.Apu)
				{
					columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = string.Format("{0}", baseComponent.ToString()) };
					ColumnHeaderList.Add(columnHeader);
					if (baseComponent.ComponentDirectives.Count(dd => dd.DirectiveType == ComponentRecordType.Overhaul) > 0)
					{
						columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.2f), Text = baseComponent + " SLSV" };
						ColumnHeaderList.Add(columnHeader);
					}
				}
				
            }
			#endregion

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "ATLB No" };
            ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Maintenance" };
	        ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Signer" };
	        ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(AircraftFlight item)

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(AircraftFlight item)
        {
			//TODO (Evgenii Babak) : Вся логика должна быть в классе Calculator
            var subItems = new List<ListViewItem.ListViewSubItem>();

	        var dateString = item.FlightDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
	        var date = item.FlightDate.Date.AddMinutes(item.OutTime);
	        var atlb = _atbs.GetItemById(item.ATLBId);
	        var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

			if (item.AtlbRecordType == AtlbRecordType.Flight)
	        {
		        
		        var route = item.StationFromId.ShortName + " - " + item.StationToId.ShortName;
		        var flightTimeString = UsefulMethods.TimeToString(new TimeSpan(0, 0, item.FlightTimeTotalMinutes, 0)) + " (" +
		                               UsefulMethods.TimePeriodToString(new TimeSpan(0, 0, item.TakeOffTime, 0),
			                               new TimeSpan(0, 0, item.LDGTime, 0)) + ")";
		        Color flightTimeColor;
		        if (item.FlightTime.TotalMinutes == item.BlockTime.TotalMinutes)
			        flightTimeColor = Color.White;
		        else
		        {
			        double persent = Math.Abs(1 - (item.FlightTime.TotalMinutes / item.BlockTime.TotalMinutes)) * 100;
			        if (persent <= 3)
				        flightTimeColor = Color.FromArgb(Highlight.Green.Color);
			        else if (persent <= 10)
				        flightTimeColor = Color.FromArgb(Highlight.Yellow.Color);
			        else flightTimeColor = Color.FromArgb(Highlight.Red.Color);
		        }
		        var perDaysFlight = Lifelength.Zero;
		        var perDaysBlock = Lifelength.Zero;
		        var flights = _flights.Where(f => f.AtlbRecordType != AtlbRecordType.Maintenance && f.FlightDate.Date.AddMinutes(f.TakeOffTime) <=
		                                          item.FlightDate.Date.AddMinutes(item.TakeOffTime)).ToList();
		        foreach (AircraftFlight aircraftFlight in flights)
		        {
			        perDaysFlight.Add(aircraftFlight.FlightTimeLifelength);
			        perDaysBlock.Add(aircraftFlight.BlockTimeLifelenght);
		        }

		        var aircraftFlightLifelenght = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthIncludingThisFlight(item);
		        var aircraftBlockLifelenght = aircraftFlightLifelenght + (perDaysBlock - perDaysFlight);


				var subItem = new ListViewItem.ListViewSubItem { Text = item.PageNo, Tag = item.PageNo };
		        subItems.Add(subItem);
				subItem = new ListViewItem.ListViewSubItem { Text = dateString, Tag = date };
		        subItems.Add(subItem);
		        subItem = new ListViewItem.ListViewSubItem { Text = item.FlightNumber.ToString(), Tag = item.FlightNumber };
		        subItems.Add(subItem);
		        subItem = new ListViewItem.ListViewSubItem { Text = route, Tag = route };
		        subItems.Add(subItem);
		        subItem = new ListViewItem.ListViewSubItem { BackColor = flightTimeColor, Text = flightTimeString, Tag = item.FlightTime };
		        subItems.Add(subItem);
		        subItem = new ListViewItem.ListViewSubItem { BackColor = flightTimeColor, Text = UsefulMethods.TimeToString(item.BlockTime), Tag = item.BlockTime };
		        subItems.Add(subItem);
		        subItem = new ListViewItem.ListViewSubItem { Text = perDaysFlight.ToHoursMinutesAndCyclesFormat("", ""), Tag = perDaysFlight };
		        subItems.Add(subItem);
		        subItem = new ListViewItem.ListViewSubItem { Text = perDaysBlock.ToHoursMinutesAndCyclesFormat("", ""), Tag = perDaysBlock };
		        subItems.Add(subItem);
		        subItem = new ListViewItem.ListViewSubItem { Text = aircraftFlightLifelenght.ToHoursMinutesAndCyclesFormat("", ""), Tag = aircraftFlightLifelenght };
		        subItems.Add(subItem);
		        subItem = new ListViewItem.ListViewSubItem { Text = aircraftBlockLifelenght.ToHoursMinutesAndCyclesFormat("", ""), Tag = aircraftBlockLifelenght };
		        subItems.Add(subItem);

		        #region колонки для отображения наработок по двигателям и ВСУ

		        foreach (BaseComponent baseComponent in _enginesAndAPU)
		        {
			        bool shouldFillSubItems = false;

			        var baseComponentFlightLifeLenght = Lifelength.Null;
			        var baseComponentBlockLifeLenght = Lifelength.Null;

			        var lastKnownTransferRecBeforFlight = baseComponent.TransferRecords.GetLastKnownRecord(item.FlightDate.Date);
			        if (lastKnownTransferRecBeforFlight != null &&
			            lastKnownTransferRecBeforFlight.DestinationObjectType == SmartCoreType.Aircraft &&
			            lastKnownTransferRecBeforFlight.DestinationObjectId == _parentAircraft.ItemId)
			        {
				        shouldFillSubItems = true;
				        var flightsWhichOccuredAfterInstallationOfBd = flights.Where(f => f.AtlbRecordType != AtlbRecordType.Maintenance && f.FlightDate.Date >= lastKnownTransferRecBeforFlight.RecordDate).ToList();

				        var perDaysFlightForBd = Lifelength.Zero;
				        var perDaysBlockForBd = Lifelength.Zero;

				        foreach (var flight in flightsWhichOccuredAfterInstallationOfBd)
				        {
					        perDaysFlightForBd.Add(flight.FlightTimeLifelength);
					        perDaysBlockForBd.Add(flight.BlockTimeLifelenght);
				        }

				        baseComponentFlightLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthIncludingThisFlight(baseComponent, item);
				        baseComponentBlockLifeLenght = baseComponentFlightLifeLenght + (perDaysBlockForBd - perDaysFlightForBd);
			        }

			        Color baseComponentTimeColor = Color.White;

			        if (shouldFillSubItems && baseComponent.BaseComponentType != BaseComponentType.Apu)
			        {
				        var baseDetailFlightWorkTime = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelength(item, baseComponent);

				        if (item.FlightTime.TotalMinutes == Convert.ToDouble(baseDetailFlightWorkTime.TotalMinutes))
					        baseComponentTimeColor = Color.White;
				        else
				        {
					        double persent = Math.Abs(1 - (Convert.ToDouble(baseDetailFlightWorkTime.TotalMinutes) / item.FlightTime.TotalMinutes)) * 100;
					        if (persent <= 3)
						        baseComponentTimeColor = Color.FromArgb(Highlight.Green.Color);
					        else if (persent <= 10)
						        baseComponentTimeColor = Color.FromArgb(Highlight.Yellow.Color);
					        else baseComponentTimeColor = Color.FromArgb(Highlight.Red.Color);
				        }
			        }
			        var baseDetailHaveOverhaulDirective = BaseDetailHaveOverhaul(baseComponent);
			        var lastOverhaul = GetLastOverhaul(baseComponent);
			        if (baseComponent.BaseComponentType == BaseComponentType.Engine)
			        {
				        if (shouldFillSubItems)
				        {
					        subItems.Add(CreateListViewSubItem(baseComponentTimeColor, baseComponentFlightLifeLenght));
					        subItems.Add(CreateListViewSubItem(Color.White, baseComponentBlockLifeLenght));
					        if (baseDetailHaveOverhaulDirective)
					        {
						        if (lastOverhaul != null)
						        {
							        var sinceOverhaulFlight = baseComponentFlightLifeLenght.IsGreater(lastOverhaul.OnLifelength)
								        ? baseComponentFlightLifeLenght - lastOverhaul.OnLifelength
								        : Lifelength.Null;

							        subItems.Add(CreateListViewSubItem(Color.White, sinceOverhaulFlight));

							        var sinceOverhaulBlock = baseComponentBlockLifeLenght.IsGreater(lastOverhaul.OnLifelength)
								        ? baseComponentBlockLifeLenght - lastOverhaul.OnLifelength
								        : Lifelength.Null;

							        subItems.Add(CreateListViewSubItem(Color.White, sinceOverhaulBlock));
						        }
						        else
						        {
							        subItems.Add(CreateListViewSubItem("N/A"));
							        subItems.Add(CreateListViewSubItem("N/A"));
						        }
					        }

				        }
				        else
				        {
					        subItems.Add(CreateListViewSubItem(string.Empty));
					        subItems.Add(CreateListViewSubItem(string.Empty));
					        if (baseDetailHaveOverhaulDirective)
					        {
						        subItems.Add(CreateListViewSubItem(string.Empty));
						        subItems.Add(CreateListViewSubItem(string.Empty));
					        }
				        }
			        }
			        else if (baseComponent.BaseComponentType == BaseComponentType.Apu)
			        {
				        if (shouldFillSubItems)
				        {
					        subItems.Add(CreateListViewSubItem(baseComponentTimeColor, baseComponentFlightLifeLenght));
					        if (baseDetailHaveOverhaulDirective)
					        {
						        if (lastOverhaul != null)
						        {
							        var sinceOverhaulFlight = baseComponentFlightLifeLenght - lastOverhaul.OnLifelength;
							        subItems.Add(CreateListViewSubItem(Color.White, sinceOverhaulFlight));
						        }
						        else subItems.Add(CreateListViewSubItem("N/A"));
					        }
				        }
				        else
				        {
					        subItems.Add(CreateListViewSubItem(string.Empty));
					        if (baseDetailHaveOverhaulDirective)
						        subItems.Add(CreateListViewSubItem(string.Empty));
				        }
			        }
		        }

		        #endregion

		        subItem = new ListViewItem.ListViewSubItem { Text = atlb?.ATLBNo ?? "AtlB deleted", Tag = atlb?.ATLBNo };
		        subItems.Add(subItem);
		        subItem = new ListViewItem.ListViewSubItem { Text = item.ListViewChecksPerformed, Tag = item.ListViewChecksPerformed };
				subItems.Add(subItem);
				subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });
			}
	        else
	        {
		        var subItem = new ListViewItem.ListViewSubItem { Text = item.PageNo, Tag = item.PageNo };
		        subItems.Add(subItem);
				subItem = new ListViewItem.ListViewSubItem { Text = dateString, Tag = date };
		        subItems.Add(subItem);
		        subItem = new ListViewItem.ListViewSubItem { Text = item.FlightNumber.ToString(), Tag = item.FlightNumber };
		        subItems.Add(subItem);
		        subItem = new ListViewItem.ListViewSubItem { Text = item.StationToId.ShortName, Tag = item.StationToId.ShortName };
		        subItems.Add(subItem);
		        subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
		        subItems.Add(subItem);
		        subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
		        subItems.Add(subItem);
		        subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
		        subItems.Add(subItem);
		        subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
		        subItems.Add(subItem);
		        subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
		        subItems.Add(subItem);
		        subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
		        subItems.Add(subItem);


				#region колонки для отображения наработок по двигателям и ВСУ

				foreach (var baseComponent in _enginesAndAPU)
				{
					if (baseComponent.BaseComponentType == BaseComponentType.Engine)
					{
						subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
						subItems.Add(subItem);
						subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
						subItems.Add(subItem);
						if (baseComponent.ComponentDirectives.Count(dd => dd.DirectiveType == ComponentRecordType.Overhaul) > 0)
						{
							subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
							subItems.Add(subItem);
							subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
							subItems.Add(subItem);
						}
					}
					else if (baseComponent.BaseComponentType == BaseComponentType.Apu)
					{
						subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
						subItems.Add(subItem);
						if (baseComponent.ComponentDirectives.Count(dd => dd.DirectiveType == ComponentRecordType.Overhaul) > 0)
						{
							subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
							subItems.Add(subItem);
						}
					}

				}

				#endregion

				subItem = new ListViewItem.ListViewSubItem { Text = atlb?.ATLBNo, Tag = atlb?.ATLBNo };
		        subItems.Add(subItem);
		        subItem = new ListViewItem.ListViewSubItem { Text = item.ListViewChecksPerformed, Tag = item.ListViewChecksPerformed };
		        subItems.Add(subItem);
		        subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });
			}
            

            return subItems.ToArray();
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

		#region private ListViewItem.ListViewSubItem CreateListViewSubItem(Color backColor, Lifelength lifelength)

		private ListViewItem.ListViewSubItem CreateListViewSubItem(Color backColor, Lifelength lifelength)
	    {
		    return new ListViewItem.ListViewSubItem
		    {
			    BackColor = backColor,
			    Text = lifelength.ToHoursMinutesAndCyclesFormat("", ""),
			    Tag = lifelength,
		    };
	    }

		#endregion

		#region private ListViewItem.ListViewSubItem CreateListViewSubItem(string text)

		private ListViewItem.ListViewSubItem CreateListViewSubItem(string text)
	    {
		    return new ListViewItem.ListViewSubItem
		    {
			    BackColor = Color.White,
			    Text = text,
			    Tag = Lifelength.Null
		    };
	    }

		#endregion

		#region private bool BaseDetailHaveOverhaul(BaseDetail baseDetail)

		private bool BaseDetailHaveOverhaul(BaseComponent baseComponent)
		{
			return baseComponent.ComponentDirectives.Any(dd => dd.DirectiveType == ComponentRecordType.Overhaul);
		}

		#endregion

		#region private DirectiveRecord GetLastOverhaul(BaseDetail baseDetail)

		private DirectiveRecord GetLastOverhaul(BaseComponent baseComponent)
		{
			return baseComponent.ComponentDirectives.Where(dd => dd.DirectiveType == ComponentRecordType.Overhaul)
									          .SelectMany(dd => dd.PerformanceRecords)
									          .OrderByDescending(dr => dr.RecordDate)
									          .FirstOrDefault();
		}

		#endregion

		#endregion
	}
}
