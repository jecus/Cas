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
using CAS.UI.UIControls.OilControls.Model;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.OilControls
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class OilListView : BaseGridViewControl<AircraftFlight>
	{
		#region Fields

		private readonly Aircraft _parentAircraft;
		private BaseComponentCollection _enginesAndAPU = new BaseComponentCollection();
		private ICommonCollection<ATLB> _atbs;
		public  OilGraphicModel _graph;
		private AircraftFlightCollection _flights = new AircraftFlightCollection();
		public IList<ComponentWorkInRegimeParams> WorkParams { get; set; }
		public IList<ComponentOilCondition> OilConditions { get; set; }

		#endregion

		#region Constructors

		#region private OilListView()
		///<summary>
		///</summary>
		private OilListView()
		{
			InitializeComponent();
			DisableContectMenu();
		}
		#endregion

		#region public OilListView(Aircraft parentAircraft) : this()
		///<summary>
		///</summary>
		public OilListView(Aircraft parentAircraft, ICommonCollection<ATLB> atlbCollection, OilGraphicModel graph)
			: this()
		{
			SortMultiplier = 1;
			OldColumnIndex = 1;
			_parentAircraft = parentAircraft;
			_atbs = atlbCollection;
			_graph = graph;
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
			#region колонки для отображения наработок по двигателям и ВСУ

			foreach (var baseComponent in _enginesAndAPU)
			{
				if (baseComponent.BaseComponentType == BaseComponentType.Engine)
				{
					AddColumn($"{baseComponent} (Flight)", (int)(radGridView1.Width * 0.1f));
					AddColumn($"{baseComponent} (Block)", (int)(radGridView1.Width * 0.1f));
					AddColumn("UpLift", (int)(radGridView1.Width * 0.05f));
					AddColumn("Min", (int)(radGridView1.Width * 0.05f));
					AddColumn("Norm", (int)(radGridView1.Width * 0.05f));
					AddColumn("Max", (int)(radGridView1.Width * 0.05f));
					AddColumn("Consumption", (int)(radGridView1.Width * 0.05f));
					AddColumn("Engine Status", (int)(radGridView1.Width * 0.1f));
					AddColumn("Exceeding", (int)(radGridView1.Width * 0.05f));
				}

			}
			#endregion
			AddColumn("ATLB No", (int)(radGridView1.Width * 0.1f));
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
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);

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


				subItems.Add(CreateRow(item.PageNo, item.PageNo));
				subItems.Add(CreateRow(dateString, date));
				subItems.Add(CreateRow(item.FlightNumber.ToString(), item.FlightNumber));
				subItems.Add(CreateRow(route, route));
				subItems.Add(CreateRow(flightTimeString, item.FlightTime, flightTimeColor));

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
					if (baseComponent.BaseComponentType == BaseComponentType.Engine)
					{
						if (shouldFillSubItems)
						{
							subItems.Add(CreateListViewSubItem(baseComponentTimeColor, baseComponentFlightLifeLenght));
							subItems.Add(CreateListViewSubItem(Color.Black, baseComponentBlockLifeLenght));
							var cp = WorkParams.FirstOrDefault(i => i.ComponentId == baseComponent.ItemId && i.GroundAir == GroundAir.Air);
							var cc = OilConditions.FirstOrDefault(i => i.ComponentId == baseComponent.ItemId && i.FlightId == item.ItemId);

							var oilFlowMin = cp?.OilFlowMin ?? 0;
							var oilFlowNorm = cp?.OilFlowRecomended ?? 0;
							var oilFlowMax = cp?.OilFlowMax ?? 0;
							var oilAdded = cc?.OilAdded ?? 0;

							var flTime = UsefulMethods.GetDifference(new TimeSpan(0, item.LDGTime, 0),
								new TimeSpan(0, item.TakeOffTime, 0));

							var q = GlobalObjects.AircraftFlightsCore.GetAircraftFlightsByAircraftId(item.AircraftId)
								.Where(f => f.AtlbRecordType != AtlbRecordType.Maintenance &&
								            f.FlightDate.Date.AddMinutes(f.TakeOffTime) <
								            item.FlightDate.Date.AddMinutes(item.TakeOffTime))
								.OrderByDescending(i => i.FlightDate).ThenByDescending(i => i.TakeOffTime)
								.ToList();

							double spent = cc?.Spent ?? 0;
							double counter = 0;

							if (oilAdded > 0)
							{
								spent = oilAdded / flTime.TotalMinutes;
							}
							else
							{
								foreach (AircraftFlight flight in q)
								{
									counter += flight.FlightTime.TotalMinutes;
									var oil = flight.OilConditionCollection.FirstOrDefault(i => i.ComponentId == baseComponent.ItemId);
									if (oil?.OilAdded > 0)
									{
										if (counter > 0)
											spent = oil.OilAdded / (counter + item.FlightTime.TotalMinutes);
										break;
									}
									

								}
							}
							

							//var oilFlow = (spent / flTime.TotalMinutes) * 60.0;
							var oilFlow = spent * 60.0;


							var exceeding = oilFlow - oilFlowMax;
							if (oilFlow <= oilFlowMax)
								exceeding = 0;




							subItems.Add(CreateListViewSubItem(oilAdded.ToString()));
							subItems.Add(CreateListViewSubItem(oilFlowMin.ToString()));
							subItems.Add(CreateListViewSubItem(oilFlowNorm.ToString()));
							subItems.Add(CreateListViewSubItem(oilFlowMax.ToString()));
							subItems.Add(CreateListViewSubItem(oilFlow.ToString("F")));
							subItems.Add(CreateListViewSubItem(GetStatus(oilFlowMin, oilFlowNorm, oilFlowMax, oilFlow).ToString()));
							subItems.Add(CreateListViewSubItem(exceeding.ToString("F")));

							if (item.AtlbRecordType == AtlbRecordType.Flight)
							{

								if (!_graph.Limits.ContainsKey(baseComponent))
								{
									_graph.Limits.Add(baseComponent, new OilLimits()
									{
										Max = oilFlowMax,
										Min = oilFlowMin,
										Normal = oilFlowNorm
									});
								}

								if (!_graph.Graph.ContainsKey(baseComponent))
									_graph.Graph.Add(baseComponent, new Dictionary<Lifelength, double>());


								if (!_graph.Graph[baseComponent].ContainsKey(baseComponentFlightLifeLenght))
									_graph.Graph[baseComponent].Add(baseComponentFlightLifeLenght, oilFlow);
								//else throw new Exception("Такая наработка уже есть!");
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
							subItems.Add(CreateListViewSubItem(string.Empty));
						}
					}
				}

				#endregion

				subItems.Add(CreateRow(atlb?.ATLBNo ?? "AtlB deleted", atlb?.ATLBNo));
				subItems.Add(CreateRow(author, author));
			}
			else
			{
				subItems.Add(CreateRow(item.PageNo, item.PageNo));
				subItems.Add(CreateRow(dateString, date));
				subItems.Add(CreateRow(item.FlightNumber.ToString(), item.FlightNumber));
				subItems.Add(CreateRow(item.StationToId.ShortName, item.StationToId.ShortName));
				subItems.Add(CreateRow("",""));

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
						subItems.Add(CreateRow("", ""));
					}

				}

				#endregion

				subItems.Add(CreateRow(atlb?.ATLBNo, atlb?.ATLBNo));
				subItems.Add(CreateRow(author, author));
			}
			

			return subItems;
		}

		private EngineStatus GetStatus(double oilFlowMin, double oilFlowNorm, double oilFlowMax, double oilFlow)
		{
			if (oilFlow > oilFlowMax)
				return EngineStatus.AOG;
			if (oilFlow > oilFlowNorm && oilFlow <= oilFlowMax)
				return EngineStatus.Controled;
			if (oilFlow > oilFlowMin && oilFlow <= oilFlowNorm)
				return EngineStatus.Attention;

			return EngineStatus.Satisfaction;
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

		#endregion
	}

	enum EngineStatus
	{
		AOG,
		Controled,
		Attention,
		Satisfaction
	}
}
