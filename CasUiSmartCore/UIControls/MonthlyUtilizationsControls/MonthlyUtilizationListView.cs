using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AircraftTechnicalLogBookControls;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.NewGrid;
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
	public partial class MouthlyUtilizationListView : BaseGridViewControl<AircraftFlight>
	{
		#region Fields

		private readonly Aircraft _parentAircraft;
		private BaseComponentCollection _enginesAndAPU = new BaseComponentCollection();
		private ICommonCollection<ATLB> _atbs;
		private AircraftFlightCollection _flights = new AircraftFlightCollection();
		public IList<ComponentWorkInRegimeParams> WorkParams { get; set; }
		public IList<ComponentOilCondition> OilConditions { get; set; }
		public IList<RunUp> RunUps { get; set; }

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
			SortMultiplier = 0;
			OldColumnIndex = 1;
			_parentAircraft = parentAircraft;
			_atbs = atlbCollection;
		}

		#endregion

		#endregion

		#region Methods

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

			radGridView1.Columns.Clear();
			ColumnHeaderList.Clear();
			SetHeaders();
			radGridView1.Columns.AddRange(ColumnHeaderList.ToArray());

			base.SetItemsArray(itemsArray);
		}
		#endregion

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("Page No", (int)(radGridView1.Width * 0.1f));
			AddDateColumn("Date", (int)(radGridView1.Width * 0.1f));
			AddColumn("Flight No", (int)(radGridView1.Width * 0.1f));
			AddColumn("Direction", (int)(radGridView1.Width * 0.1f));
			AddColumn("Flight time", (int)(radGridView1.Width * 0.1f));
			AddColumn("Block time", (int)(radGridView1.Width * 0.1f));
			AddColumn("Per Days (Flight)", (int)(radGridView1.Width * 0.1f));
			AddColumn("Per Days (Block)", (int)(radGridView1.Width * 0.1f));
			AddColumn("Aircraft (Flight)", (int)(radGridView1.Width * 0.1f));
			AddColumn("Aircraft (Block)", (int)(radGridView1.Width * 0.1f));

			#region колонки для отображения наработок по двигателям и ВСУ

			foreach (var baseComponent in _enginesAndAPU)
			{
				if (baseComponent.BaseComponentType == BaseComponentType.Engine)
				{
					AddColumn($"{baseComponent} (Flight)", (int)(radGridView1.Width * 0.1f));
					AddColumn($"{baseComponent} (Block)", (int)(radGridView1.Width * 0.1f));
					AddColumn("UpLift", (int)(radGridView1.Width * 0.1f));
					AddColumn("Min", (int)(radGridView1.Width * 0.1f));
					AddColumn("Norm", (int)(radGridView1.Width * 0.1f));
					AddColumn("Max", (int)(radGridView1.Width * 0.1f));
					AddColumn("Oil Flow", (int)(radGridView1.Width * 0.1f));
					AddColumn("Exceeding", (int)(radGridView1.Width * 0.1f));

					if (baseComponent.ComponentDirectives.Count(dd => dd.DirectiveType == ComponentRecordType.Overhaul) > 0)
					{
						AddColumn(baseComponent + " SLSV Flight", (int)(radGridView1.Width * 0.1f));
						AddColumn(baseComponent + " SLSV Block", (int)(radGridView1.Width * 0.1f));
					}
				}
				//else if (baseComponent.BaseComponentType == BaseComponentType.Apu)
				//{
				//	AddColumn($"{baseComponent}", (int)(radGridView1.Width * 0.1f));
				//	if (baseComponent.ComponentDirectives.Count(dd => dd.DirectiveType == ComponentRecordType.Overhaul) > 0)
				//		AddColumn(baseComponent + " SLSV", (int)(radGridView1.Width * 0.1f));
				//}
				
			}
			#endregion
			AddColumn("ATLB No", (int)(radGridView1.Width * 0.1f));
			AddColumn("Maintenance", (int)(radGridView1.Width * 0.1f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.1f));
		}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(AircraftFlight item)

		protected override List<CustomCell> GetListViewSubItems(AircraftFlight item)
		{

			//TODO (Evgenii Babak) : Вся логика должна быть в классе Calculator
			var subItems = new List<CustomCell>();

			var dateString = item.FlightDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
			var date = item.FlightDate.Date.AddMinutes(item.OutTime);
			var atlb = _atbs.GetItemById(item.ATLBId);
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

			if (item.AtlbRecordType == AtlbRecordType.Flight)
			{
				
				var route = item.StationFromId.ShortName + " - " + item.StationToId.ShortName;
				var flightTimeString = UsefulMethods.TimeToString(new TimeSpan(0, 0, item.FlightTimeTotalMinutes, 0));
				Color flightTimeColor;
				if (item.FlightTime.TotalMinutes == item.BlockTime.TotalMinutes)
					flightTimeColor = Color.Black;
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


				subItems.Add(CreateRow(item.PageNo, item.PageNo));
				subItems.Add(CreateRow(dateString, date));
				subItems.Add(CreateRow(item.FlightNumber.ToString(), item.FlightNumber));
				subItems.Add(CreateRow(route, route));
				subItems.Add(CreateRow(flightTimeString, item.FlightTime, flightTimeColor));
				subItems.Add(CreateRow(UsefulMethods.TimeToString(item.BlockTime), item.BlockTime, flightTimeColor));
				subItems.Add(CreateRow(perDaysFlight.ToHoursMinutesAndCyclesFormat("", ""), perDaysFlight));
				subItems.Add(CreateRow(perDaysBlock.ToHoursMinutesAndCyclesFormat("", ""), perDaysBlock));
				subItems.Add(CreateRow(aircraftFlightLifelenght.ToHoursMinutesAndCyclesFormat("", ""), aircraftFlightLifelenght));
				subItems.Add(CreateRow(aircraftBlockLifelenght.ToHoursMinutesAndCyclesFormat("", ""), aircraftFlightLifelenght));

				#region колонки для отображения наработок по двигателям и ВСУ

				foreach (BaseComponent baseComponent in _enginesAndAPU.Where(i => i.BaseComponentType == BaseComponentType.Engine))
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

					Color baseComponentTimeColor = Color.Black;

					//if (shouldFillSubItems && baseComponent.BaseComponentType != BaseComponentType.Apu)
					//{
					//	var baseDetailFlightWorkTime = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelength(item, baseComponent);

					//	if (item.FlightTime.TotalMinutes == Convert.ToDouble(baseDetailFlightWorkTime.TotalMinutes))
					//		baseComponentTimeColor = Color.Black;
					//	else
					//	{
					//		double persent = Math.Abs(1 - (Convert.ToDouble(baseDetailFlightWorkTime.TotalMinutes) / item.FlightTime.TotalMinutes)) * 100;
					//		if (persent <= 3)
					//			baseComponentTimeColor = Color.FromArgb(Highlight.Green.Color);
					//		else if (persent <= 10)
					//			baseComponentTimeColor = Color.FromArgb(Highlight.Yellow.Color);
					//		else baseComponentTimeColor = Color.FromArgb(Highlight.Red.Color);
					//	}
					//}
					var baseDetailHaveOverhaulDirective = BaseDetailHaveOverhaul(baseComponent);
					var lastOverhaul = GetLastOverhaul(baseComponent);
					if (baseComponent.BaseComponentType == BaseComponentType.Engine)
					{
						if (shouldFillSubItems)
						{
							subItems.Add(CreateListViewSubItem(baseComponentTimeColor, baseComponentFlightLifeLenght));
							subItems.Add(CreateListViewSubItem(Color.Black, baseComponentBlockLifeLenght));
							var cp = WorkParams.FirstOrDefault(i => i.ComponentId == baseComponent.ItemId);
							var cc = OilConditions.FirstOrDefault(i => i.ComponentId == baseComponent.ItemId && i.FlightId == item.ItemId);
							var workRegime = RunUps.FirstOrDefault(i => i.BaseComponentId == baseComponent.ItemId && i.FlightId == item.ItemId);

							

							var oilFlowMin = cp?.OilFlowMin ?? 0;
							var oilFlowNorm = cp?.OilFlowRecomended ?? 0;
							var oilFlowMax = cp?.OilFlowMax ?? 0;
							var oilAdded = cc?.OilAdded ?? 0;
							var oilFlow = (cc?.Spent / workRegime?.TotalMinutes) * 60.0 ?? 0;
							var exceeding = oilFlowMax - oilFlow;



							subItems.Add(CreateListViewSubItem(oilAdded.ToString()));
							subItems.Add(CreateListViewSubItem(oilFlowMin.ToString()));
							subItems.Add(CreateListViewSubItem(oilFlowNorm.ToString()));
							subItems.Add(CreateListViewSubItem(oilFlowMax.ToString()));
							subItems.Add(CreateListViewSubItem(oilFlow.ToString()));
							subItems.Add(CreateListViewSubItem(exceeding.ToString()));

							if (baseDetailHaveOverhaulDirective)
							{
								if (lastOverhaul != null)
								{
									var sinceOverhaulFlight = baseComponentFlightLifeLenght.IsGreater(lastOverhaul.OnLifelength)
										? baseComponentFlightLifeLenght - lastOverhaul.OnLifelength
										: Lifelength.Null;

									subItems.Add(CreateListViewSubItem(Color.Black, sinceOverhaulFlight));

									var sinceOverhaulBlock = baseComponentBlockLifeLenght.IsGreater(lastOverhaul.OnLifelength)
										? baseComponentBlockLifeLenght - lastOverhaul.OnLifelength
										: Lifelength.Null;

									subItems.Add(CreateListViewSubItem(Color.Black, sinceOverhaulBlock));
								}
								else
								{
									subItems.Add(CreateListViewSubItem("N/A"));
									subItems.Add(CreateListViewSubItem("N/A"));
									subItems.Add(CreateListViewSubItem("N/A"));
									subItems.Add(CreateListViewSubItem("N/A"));
									subItems.Add(CreateListViewSubItem("N/A"));
									subItems.Add(CreateListViewSubItem("N/A"));
									subItems.Add(CreateListViewSubItem("N/A"));
									subItems.Add(CreateListViewSubItem("N/A"));
								}
							}

						}
						else
						{
							subItems.Add(CreateListViewSubItem(string.Empty));
							subItems.Add(CreateListViewSubItem(string.Empty));
							subItems.Add(CreateListViewSubItem(string.Empty));
							subItems.Add(CreateListViewSubItem(string.Empty));
							subItems.Add(CreateListViewSubItem(string.Empty));
							subItems.Add(CreateListViewSubItem(string.Empty));
							subItems.Add(CreateListViewSubItem(string.Empty));
							subItems.Add(CreateListViewSubItem(string.Empty));
							if (baseDetailHaveOverhaulDirective)
							{
								subItems.Add(CreateListViewSubItem(string.Empty));
								subItems.Add(CreateListViewSubItem(string.Empty));
								subItems.Add(CreateListViewSubItem(string.Empty));
								subItems.Add(CreateListViewSubItem(string.Empty));
								subItems.Add(CreateListViewSubItem(string.Empty));
								subItems.Add(CreateListViewSubItem(string.Empty));
								subItems.Add(CreateListViewSubItem(string.Empty));
								subItems.Add(CreateListViewSubItem(string.Empty));
							}
						}
					}
					//else if (baseComponent.BaseComponentType == BaseComponentType.Apu)
					//{
					//	if (shouldFillSubItems)
					//	{
					//		subItems.Add(CreateListViewSubItem(baseComponentTimeColor, baseComponentFlightLifeLenght));
					//		if (baseDetailHaveOverhaulDirective)
					//		{
					//			if (lastOverhaul != null)
					//			{
					//				var sinceOverhaulFlight = baseComponentFlightLifeLenght - lastOverhaul.OnLifelength;
					//				subItems.Add(CreateListViewSubItem(Color.Black, sinceOverhaulFlight));
					//			}
					//			else subItems.Add(CreateListViewSubItem("N/A"));
					//		}
					//	}
					//	else
					//	{
					//		subItems.Add(CreateListViewSubItem(string.Empty));
					//		if (baseDetailHaveOverhaulDirective)
					//			subItems.Add(CreateListViewSubItem(string.Empty));
					//	}
					//}
				}

				#endregion

				subItems.Add(CreateRow(atlb?.ATLBNo ?? "AtlB deleted", atlb?.ATLBNo));
				subItems.Add(CreateRow(item.ListViewChecksPerformed, item.ListViewChecksPerformed));
				subItems.Add(CreateRow(author, author));
			}
			else
			{
				subItems.Add(CreateRow(item.PageNo, item.PageNo));
				subItems.Add(CreateRow(dateString, date));
				subItems.Add(CreateRow(item.FlightNumber.ToString(), item.FlightNumber));
				subItems.Add(CreateRow(item.StationToId.ShortName, item.StationToId.ShortName));
				subItems.Add(CreateRow("",""));
				subItems.Add(CreateRow("", ""));
				subItems.Add(CreateRow("", ""));
				subItems.Add(CreateRow("", ""));
				subItems.Add(CreateRow("", ""));
				subItems.Add(CreateRow("", ""));


				#region колонки для отображения наработок по двигателям и ВСУ

				foreach (var baseComponent in _enginesAndAPU)
				{

					
					if (baseComponent.BaseComponentType == BaseComponentType.Engine)
					{
						subItems.Add(CreateRow("", ""));
						subItems.Add(CreateRow("", ""));
						subItems.Add(CreateRow("", ""));
						subItems.Add(CreateRow("", ""));
						subItems.Add(CreateRow("", ""));
						subItems.Add(CreateRow("", ""));
						subItems.Add(CreateRow("", ""));
						subItems.Add(CreateRow("", ""));
						if (baseComponent.ComponentDirectives.Count(dd => dd.DirectiveType == ComponentRecordType.Overhaul) > 0)
						{
							subItems.Add(CreateRow("", ""));
							subItems.Add(CreateRow("", ""));
							subItems.Add(CreateRow("", ""));
							subItems.Add(CreateRow("", ""));
							subItems.Add(CreateRow("", ""));
							subItems.Add(CreateRow("", ""));
							subItems.Add(CreateRow("", ""));
							subItems.Add(CreateRow("", ""));
						}
					}
					//else if (baseComponent.BaseComponentType == BaseComponentType.Apu)
					//{
					//	subItems.Add(CreateRow("", ""));
					//	if (baseComponent.ComponentDirectives.Count(dd => dd.DirectiveType == ComponentRecordType.Overhaul) > 0)
					//		subItems.Add(CreateRow("", ""));
					//}

				}

				#endregion

				subItems.Add(CreateRow(atlb?.ATLBNo, atlb?.ATLBNo));
				subItems.Add(CreateRow(item.ListViewChecksPerformed, item.ListViewChecksPerformed));
				subItems.Add(CreateRow(author, author));
			}
			

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

		#region private CustomCell CreateListViewSubItem(Color backColor, Lifelength lifelength)

		private CustomCell CreateListViewSubItem(Color backColor, Lifelength lifelength)
		{
			return new CustomCell
			{
				Text = lifelength.ToHoursMinutesAndCyclesFormat("", ""),
				Tag = lifelength,
			};
		}

		#endregion

		#region private CustomCell CreateListViewSubItem(string text)

		private CustomCell CreateListViewSubItem(string text)
		{
			return new CustomCell
			{
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

		#region Overrides of BaseListViewControl<AircraftFlight>


		protected override void CustomSort(int ColumnIndex)
		{
			if (OldColumnIndex != ColumnIndex)
				SortMultiplier = -1;
			if (SortMultiplier == 1)
				SortMultiplier = -1;
			else
				SortMultiplier = 1;

			OldColumnIndex = ColumnIndex;
			var resultList = new List<AircraftFlight>();
			var list = radGridView1.Rows.Select(i => i).ToList();
			list.Sort(new GridViewDataRowInfoComparer(ColumnIndex, SortMultiplier));

			resultList.AddRange(list.Select(i => i.Tag as AircraftFlight));

			SetItemsArray(resultList.ToArray());


		}

		#endregion

		#endregion
	}
}
