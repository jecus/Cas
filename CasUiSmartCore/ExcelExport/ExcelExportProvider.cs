using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Auxiliary;
using CASTerms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.ExcelExport
{
	public class ExcelExportProvider
	{
		#region Fields

		private ExcelPackage _package;
		private ExcelWorkbook Workbook => _package.Workbook;

		#endregion

		#region Constructor

		public ExcelExportProvider()
		{
			
		}

		#endregion

		#region public void SaveTo(Stream stream)

		public void SaveTo(string path)
		{
			_package.SaveAs(new FileInfo(path));
		}

		#endregion

		public void ExportFlights()
		{
			_package = new ExcelPackage();
			var aircrafts = GlobalObjects.AircraftsCore.GetAllAircrafts();

			Parallel.ForEach(aircrafts, aircraft =>
			{
				if (ReportProgress != null)
					ReportProgress(aircraft.RegistrationNumber, new EventArgs());

				var baseComponents = GlobalObjects.ComponentCore.GetAicraftBaseComponents(aircraft.ItemId,
					new[] { BaseComponentType.Engine.ItemId, BaseComponentType.Apu.ItemId }).OrderByDescending(i => i.BaseComponentTypeId).ThenBy(i => i.ItemId);
				GlobalObjects.AircraftFlightsCore.LoadAircraftFlights(aircraft.ItemId);
				var flights = GlobalObjects.AircraftFlightsCore.GetAircraftFlightsByAircraftId(aircraft.ItemId);

				var counter = 1;

				//Добавляем старницу
				Workbook.Worksheets.Add(aircraft.RegistrationNumber);
				var workSheet = Workbook.Worksheets[aircraft.RegistrationNumber];

				FillHeaderCell(workSheet.Cells[4, 1], "SEQ", ExcelHorizontalAlignment.Center);
				//workSheet.Column(1).AutoFit();

				FillHeaderCell(workSheet.Cells[4, 2], "ATLB NO", ExcelHorizontalAlignment.Center);
				//workSheet.Column(2).AutoFit();

				FillHeaderCell(workSheet.Cells[4, 3], "DATE", ExcelHorizontalAlignment.Center);
				//workSheet.Column(3).AutoFit();
				workSheet.Column(3).Width = 15;

				FillHeaderCell(workSheet.Cells[4, 4], "FLT NO", ExcelHorizontalAlignment.Center);
				//workSheet.Column(4).AutoFit();

				FillHeaderCell(workSheet.Cells[4, 5], "FROM", ExcelHorizontalAlignment.Center);
				//workSheet.Column(5).AutoFit();

				FillHeaderCell(workSheet.Cells[4, 6], "TO", ExcelHorizontalAlignment.Center);
				//workSheet.Column(6).AutoFit();

				FillHeaderCell(workSheet.Cells[4, 7], "TAKE OFF", ExcelHorizontalAlignment.Center);
				//workSheet.Column(7).AutoFit();

				FillHeaderCell(workSheet.Cells[4, 8], "TOUCH DOWN", ExcelHorizontalAlignment.Center);
				//workSheet.Column(8).AutoFit();

				FillHeaderCell(workSheet.Cells[4, 9], "FLT TIME HH: MM", ExcelHorizontalAlignment.Center);
				//workSheet.Column(9).AutoFit();

				FillHeaderCell(workSheet.Cells[4, 10], "TOT A/C FH", ExcelHorizontalAlignment.Center);
				//workSheet.Column(10).AutoFit();

				FillHeaderCell(workSheet.Cells[4, 11], "TOT A/C FC", ExcelHorizontalAlignment.Center);
				//workSheet.Column(11).AutoFit();

				#region Заголовок

				var headerBaseComponent = workSheet.Cells[1, 10, 1, 11];
				headerBaseComponent.Merge = true;
				FillHeaderCell(headerBaseComponent, $"{aircraft.RegistrationNumber}", ExcelHorizontalAlignment.Center);

				headerBaseComponent = workSheet.Cells[2, 10, 2, 11];
				headerBaseComponent.Merge = true;
				FillHeaderCell(headerBaseComponent, $"{aircraft.Model}", ExcelHorizontalAlignment.Center);

				headerBaseComponent = workSheet.Cells[3, 10, 3, 11];
				headerBaseComponent.Merge = true;
				FillHeaderCell(headerBaseComponent, $"{aircraft.SerialNumber}", ExcelHorizontalAlignment.Center);

				#endregion

				var column = 12;

				foreach (var baseComponent in baseComponents)
				{
					if (baseComponent.BaseComponentType == BaseComponentType.Engine)
					{
						#region Заголовок

						headerBaseComponent = workSheet.Cells[1, column, 1, column + 3];
						headerBaseComponent.Merge = true;
						FillHeaderCell(headerBaseComponent, $"Engine {baseComponent.Position}", ExcelHorizontalAlignment.Center);

						headerBaseComponent = workSheet.Cells[2, column, 2, column + 3];
						headerBaseComponent.Merge = true;
						FillHeaderCell(headerBaseComponent, $"{baseComponent.Model}", ExcelHorizontalAlignment.Center);

						headerBaseComponent = workSheet.Cells[3, column, 3, column + 3];
						headerBaseComponent.Merge = true;
						FillHeaderCell(headerBaseComponent, $"{baseComponent.SerialNumber}", ExcelHorizontalAlignment.Center);

						#endregion


						FillHeaderCell(workSheet.Cells[4, column], $"TSN", ExcelHorizontalAlignment.Center);
						//workSheet.Column(column).AutoFit();
						column++;

						FillHeaderCell(workSheet.Cells[4, column], $"TSO", ExcelHorizontalAlignment.Center);
						//workSheet.Column(column).AutoFit();
						column++;

						FillHeaderCell(workSheet.Cells[4, column], $"CSN", ExcelHorizontalAlignment.Center);
						//workSheet.Column(column).AutoFit();
						column++;

						FillHeaderCell(workSheet.Cells[4, column], $"CSO", ExcelHorizontalAlignment.Center);
						//workSheet.Column(column).AutoFit();
						column++;
					}
					else if (baseComponent.BaseComponentType == BaseComponentType.Apu)
					{
						#region Заголовок

						headerBaseComponent = workSheet.Cells[1, column, 1, column + 3];
						headerBaseComponent.Merge = true;
						FillHeaderCell(headerBaseComponent, $"APU", ExcelHorizontalAlignment.Center);

						headerBaseComponent = workSheet.Cells[2, column, 2, column + 3];
						headerBaseComponent.Merge = true;
						FillHeaderCell(headerBaseComponent, $"{baseComponent.Model}", ExcelHorizontalAlignment.Center);

						headerBaseComponent = workSheet.Cells[3, column, 3, column + 3];
						headerBaseComponent.Merge = true;
						FillHeaderCell(headerBaseComponent, $"{baseComponent.SerialNumber}", ExcelHorizontalAlignment.Center);

						#endregion

						FillHeaderCell(workSheet.Cells[4, column], $"TSN", ExcelHorizontalAlignment.Center);
						//workSheet.Column(column).AutoFit();
						column++;
						FillHeaderCell(workSheet.Cells[4, column], $"CSN", ExcelHorizontalAlignment.Center);
						//workSheet.Column(column).AutoFit();
						column++;

						FillHeaderCell(workSheet.Cells[4, column], $"TSR", ExcelHorizontalAlignment.Center);
						//workSheet.Column(column).AutoFit();
						column++;

						FillHeaderCell(workSheet.Cells[4, column], $"CSR", ExcelHorizontalAlignment.Center);
						//workSheet.Column(column).AutoFit();
						column++;

					}

				}

				FillHeaderCell(workSheet.Cells[4, column], $"SCAT TSD", ExcelHorizontalAlignment.Center);
				//workSheet.Column(column).AutoFit();
				column++;

				FillHeaderCell(workSheet.Cells[4, column], $"SCAT CSD", ExcelHorizontalAlignment.Center);
				//workSheet.Column(column).AutoFit();
				column++;

				workSheet.View.FreezePanes(5, 1);

				int currentRowPosition = 5;
				int currentColumnPosition = 1;
				var time = new TimeSpan();

				foreach (var flight in flights.OrderBy(i => i.FlightDate).ThenBy(i => i.TakeOffTime).ToArray())
				{

					var frame = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthIncludingThisFlight(flight)
						.ToHoursMinutesAndCyclesFormat("", "");
					var hoursandCycles = frame.Split('/');

					FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], counter);
					FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], flight.PageNo);
					FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], SmartCore.Auxiliary.Convert.GetDateFormat(flight.FlightDate));
					FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], flight.FlightNumber.ToString());
					FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], flight.StationFromId.ShortName);
					FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], flight.StationToId.ShortName);
					FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], UsefulMethods.TimeToString(new TimeSpan(0, 0, flight.TakeOffTime, 0)));
					FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], UsefulMethods.TimeToString(new TimeSpan(0, 0, flight.LDGTime, 0)));
					FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], UsefulMethods.TimeToString(new TimeSpan(0, 0, flight.FlightTimeTotalMinutes, 0)));
					FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], hoursandCycles[0]);
					FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], hoursandCycles[1]);

					#region колонки для отображения наработок по двигателям и ВСУ

					foreach (var baseComponent in baseComponents)
					{
						if (flight.AtlbRecordType == AtlbRecordType.Flight)
						{
							bool shouldFillSubItems = false;

							var baseComponentFlightLifeLenght = Lifelength.Null;

							var lastKnownTransferRecBeforFlight = baseComponent.TransferRecords.GetLastKnownRecord(flight.FlightDate.Date);
							if (lastKnownTransferRecBeforFlight != null &&
								lastKnownTransferRecBeforFlight.DestinationObjectType == SmartCoreType.Aircraft &&
								lastKnownTransferRecBeforFlight.DestinationObjectId == aircraft.ItemId)
							{
								shouldFillSubItems = true;
								//var flightsWhichOccuredAfterInstallationOfBd = flights.Where(f => f.AtlbRecordType != AtlbRecordType.Maintenance && f.FlightDate.Date >= lastKnownTransferRecBeforFlight.RecordDate).ToList();

								//var perDaysFlightForBd = Lifelength.Zero;

								//foreach (var fl in flightsWhichOccuredAfterInstallationOfBd)
								//	perDaysFlightForBd.Add(fl.FlightTimeLifelength);

								baseComponentFlightLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthIncludingThisFlight(baseComponent, flight);
							}

							var baseDetailHaveOverhaulDirective = BaseDetailHaveOverhaul(baseComponent);
							var lastOverhaul = GetLastOverhaul(baseComponent);
							if (baseComponent.BaseComponentType == BaseComponentType.Engine)
							{
								if (shouldFillSubItems)
								{
									var fl = baseComponentFlightLifeLenght.ToHoursMinutesAndCyclesFormat("", "");
									hoursandCycles = frame.Split('/');
									FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], hoursandCycles[0]);
									FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], hoursandCycles[1]);

									if (baseDetailHaveOverhaulDirective)
									{
										if (lastOverhaul != null)
										{
											var sinceOverhaulFlight = baseComponentFlightLifeLenght.IsGreater(lastOverhaul.OnLifelength)
												? baseComponentFlightLifeLenght - lastOverhaul.OnLifelength
												: Lifelength.Null;

											fl = sinceOverhaulFlight.ToHoursMinutesAndCyclesFormat("", "");
											hoursandCycles = frame.Split('/');
											FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], hoursandCycles[0]);
											FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], hoursandCycles[1]);
										}
										else
										{
											FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
											FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
										}
									}
									else
									{
										FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
										FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
									}
								}
								else
								{
									FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
									FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
									if (baseDetailHaveOverhaulDirective)
									{
										FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
										FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
									}
									else
									{
										FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
										FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
									}
								}
							}
							else if (baseComponent.BaseComponentType == BaseComponentType.Apu)
							{
								if (shouldFillSubItems)
								{
									var fl = baseComponentFlightLifeLenght.ToHoursMinutesAndCyclesFormat("", "");
									hoursandCycles = frame.Split('/');
									FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], hoursandCycles[0]);
									FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], hoursandCycles[1]);
									if (baseDetailHaveOverhaulDirective)
									{
										if (lastOverhaul != null)
										{
											var sinceOverhaulFlight = baseComponentFlightLifeLenght - lastOverhaul.OnLifelength;
											fl = sinceOverhaulFlight.ToHoursMinutesAndCyclesFormat("", "");
											hoursandCycles = frame.Split('/');
											FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], hoursandCycles[0]);
											FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], hoursandCycles[1]);
										}
										else
										{
											FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
											FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
										}
									}
									else
									{
										FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
										FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
									}
								}
								else
								{
									FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
									FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
									if (baseDetailHaveOverhaulDirective)
									{
										FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
										FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
									}
									else
									{
										FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
										FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
									}

								}
							}
						}
						else
						{
							FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
							FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
							FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
							FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], "-");
						}
					}

					#endregion


					time += flight.BlockTime;

					FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], new Lifelength(0, 0, (int)time.TotalMinutes).ToHoursMinutesFormat(""));
					FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], counter++);

					currentColumnPosition = 1;
					currentRowPosition++;
				}
			});

		}

        public void ExportATLB()
        {
	        _package = new ExcelPackage();

			var sheetName = "ATLB";

            var discripancy = GlobalObjects.DiscrepanciesCore.GetDiscrepancies();

            foreach (var discrepancy in discripancy)
                discrepancy.Aircraft = GlobalObjects.AircraftsCore.GetAircraftById(discrepancy.ParentFlight.AircraftId);

            //Добавляем старницу
            Workbook.Worksheets.Add(sheetName);
            var workSheet = Workbook.Worksheets[sheetName];

            FillHeaderCell(workSheet.Cells[1, 1], "Date", ExcelHorizontalAlignment.Center);
            workSheet.Column(1).Width=10;

            FillHeaderCell(workSheet.Cells[1, 2], "Aircraft", ExcelHorizontalAlignment.Center);
            workSheet.Column(2).Width=10;

            FillHeaderCell(workSheet.Cells[1, 3], "Model", ExcelHorizontalAlignment.Center);
            workSheet.Column(3).AutoFit();

            FillHeaderCell(workSheet.Cells[1, 4], "Page №", ExcelHorizontalAlignment.Center);
            workSheet.Column(4).AutoFit();

            FillHeaderCell(workSheet.Cells[1, 5], "Description", ExcelHorizontalAlignment.Center);
            workSheet.Column(5).Width=40;

            FillHeaderCell(workSheet.Cells[1, 6], "Corr. Action", ExcelHorizontalAlignment.Center);
            workSheet.Column(6).Width=40;

            FillHeaderCell(workSheet.Cells[1, 7], "Station", ExcelHorizontalAlignment.Center);
            workSheet.Column(7).AutoFit();

            FillHeaderCell(workSheet.Cells[1, 8], "Auth. B1", ExcelHorizontalAlignment.Center);
            workSheet.Column(8).Width=20;

            FillHeaderCell(workSheet.Cells[1, 9], "ATA", ExcelHorizontalAlignment.Center);
            workSheet.Column(9).Width = 5;

            FillHeaderCell(workSheet.Cells[1, 10], "Comp. Off P/N", ExcelHorizontalAlignment.Center);
            workSheet.Column(10).Width = 15;

            FillHeaderCell(workSheet.Cells[1, 11], "Comp. Off S/N", ExcelHorizontalAlignment.Center);
            workSheet.Column(11).Width = 15;

            FillHeaderCell(workSheet.Cells[1, 12], "Comp On P/N", ExcelHorizontalAlignment.Center);
            workSheet.Column(12).Width = 15;

            FillHeaderCell(workSheet.Cells[1, 13], "Comp On S/N", ExcelHorizontalAlignment.Center);
            workSheet.Column(13).Width = 15;

            FillHeaderCell(workSheet.Cells[1, 14], "Remarks", ExcelHorizontalAlignment.Center);
            workSheet.Column(14).Width=10;

            workSheet.View.FreezePanes(2, 1);

			int currentRowPosition = 2;
            int currentColumnPosition = 1;

            foreach (var d in discripancy.OrderByDescending(i => i.ParentFlightDate))
            {
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], d.ParentFlightDate.Value.ToString(new GlobalTermsProvider()["DateFormat"].ToString()));
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], d.Aircraft.ToString(), ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], d.Model.ShortName, ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], d.ParentFlight?.PageNo, ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], d.Description, ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], d.CorrectiveActionDescription, ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], d.ParentFlight.StationToId.ShortName);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], d.CertificateOfReleaseToServiceAuthorizationB1 != null ? d.CertificateOfReleaseToServiceAuthorizationB1.ToString() : "", ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], d.ATAChapter != null ? d.ATAChapter.ToString() : "", ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], d.CorrectiveAction.PartNumberOff, ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], d.CorrectiveAction.SerialNumberOff, ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], d.CorrectiveAction.PartNumberOn, ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], d.CorrectiveAction.SerialNumberOn, ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], d.Remark, ExcelHorizontalAlignment.Left);

                currentColumnPosition = 1;
                currentRowPosition++;
            }
        }

        #region public void Dispose()

        public void Dispose()
		{
			_package.Dispose();
		}

		#endregion

		#region private void FillHeaderCell(ExcelRange workCell, object value, ExcelHorizontalAlignment align)

		private void FillHeaderCell(ExcelRange workCell, object value, ExcelHorizontalAlignment align)
		{
			workCell.Style.WrapText = true;
			workCell.Style.Fill.PatternType = ExcelFillStyle.Solid;
			workCell.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(220, 234, 246));
			workCell.Merge = true;
			workCell.Value = value;
			workCell.Style.HorizontalAlignment = align;
			workCell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
			workCell.Style.Border.BorderAround(ExcelBorderStyle.Thin);

		}

		#endregion

		#region private void FillCell(ExcelRange workCell, object value)

		private void FillCell(ExcelRange workCell, object value, ExcelHorizontalAlignment alignment = ExcelHorizontalAlignment.Center)
		{
			workCell.Value = value;
			workCell.Style.HorizontalAlignment = alignment;
			workCell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
		}

		#endregion

		#region private void WriteRow(string sheetName,int row, params object[] values)

		private void WriteRow(string sheetName,int row, params object[] values)
		{
			for (var i = 1; i <= values.Length; i++)
				Workbook.Worksheets[sheetName].SetValue(row, i, values[i - 1]);
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

		public event EventHandler ReportProgress;

        
    }
}