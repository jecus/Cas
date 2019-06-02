using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Auxiliary;
using CASTerms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SmartCore;
using SmartCore.Activity;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.MaintenanceWorkscope;
using Component = SmartCore.Entities.General.Accessory.Component;
using Convert = System.Convert;

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

				foreach (var flight in flights.OrderBy(i => i.FlightDate).ThenBy(i => i.TakeOffTime).ToArray().Where(i => i.AtlbRecordType != AtlbRecordType.Maintenance))
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

        public void ExportMpd(List<MaintenanceDirective> mpds)
        {
            _package = new ExcelPackage();

            var sheetName = "MPD";

            Workbook.Worksheets.Add(sheetName);
            var workSheet = Workbook.Worksheets[sheetName];

            FillHeaderCell(workSheet.Cells[1, 1], "MPD Item", ExcelHorizontalAlignment.Center);
            workSheet.Column(1).Width=12;

            FillHeaderCell(workSheet.Cells[1, 2], "Task Card №", ExcelHorizontalAlignment.Center);
            workSheet.Column(2).Width=14;

            FillHeaderCell(workSheet.Cells[1, 3], "Maint. Manual", ExcelHorizontalAlignment.Center);
            workSheet.Column(3).Width=12;

            FillHeaderCell(workSheet.Cells[1, 4], "Category", ExcelHorizontalAlignment.Center);
            workSheet.Column(4).AutoFit();

            FillHeaderCell(workSheet.Cells[1, 5], "Work Type", ExcelHorizontalAlignment.Center);
            workSheet.Column(5).Width=12;

            FillHeaderCell(workSheet.Cells[1, 6], "Program", ExcelHorizontalAlignment.Center);
            workSheet.Column(6).Width=10;

            FillHeaderCell(workSheet.Cells[1, 7], "Description", ExcelHorizontalAlignment.Center);
            workSheet.Column(7).Width=12;

            FillHeaderCell(workSheet.Cells[1, 8], "Zone", ExcelHorizontalAlignment.Center);
            workSheet.Column(8).Width=6;

            FillHeaderCell(workSheet.Cells[1, 9], "Access", ExcelHorizontalAlignment.Center);
            workSheet.Column(9).Width=8;

            FillHeaderCell(workSheet.Cells[1, 10], "Work Area", ExcelHorizontalAlignment.Center);
            workSheet.Column(10).Width=10;

            FillHeaderCell(workSheet.Cells[1, 11], "M.H.", ExcelHorizontalAlignment.Center);
            workSheet.Column(11).Width=6;

            FillHeaderCell(workSheet.Cells[1, 12], "1st. Perf.", ExcelHorizontalAlignment.Center);
            workSheet.Column(12).Width=20;

            FillHeaderCell(workSheet.Cells[1, 13], "Rpt. Intv", ExcelHorizontalAlignment.Center);
            workSheet.Column(13).Width = 18;

            FillHeaderCell(workSheet.Cells[1, 14], "Last", ExcelHorizontalAlignment.Center);
            workSheet.Column(14).Width = 30;

            FillHeaderCell(workSheet.Cells[1, 15], "Next", ExcelHorizontalAlignment.Center);
            workSheet.Column(15).Width = 35;

            FillHeaderCell(workSheet.Cells[1, 16], "Remain/Overdue", ExcelHorizontalAlignment.Center);
            workSheet.Column(16).Width=16;

            workSheet.View.FreezePanes(2, 1);

            int currentRowPosition = 2;
            int currentColumnPosition = 1;

            foreach (var mpd in mpds.OrderBy(i => i.TaskNumberCheck))
	        {
                #region calc

                DateTime defaultDateTime = DateTimeExtend.GetCASMinDateTime();
                DateTime lastComplianceDate = defaultDateTime;
                DateTime nextComplianceDate = defaultDateTime;
                Lifelength lastComplianceLifeLength = Lifelength.Zero;

                string lastPerformanceString, firstPerformanceString = "N/A";
                
                if (mpd.LastPerformance != null)
                {
                    lastComplianceDate = mpd.LastPerformance.RecordDate;
                    lastComplianceLifeLength = mpd.LastPerformance.OnLifelength;
                }
                if (mpd.Threshold.FirstPerformanceSinceNew != null && !mpd.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                {
                    firstPerformanceString = "s/n: " + mpd.Threshold.FirstPerformanceSinceNew;
                }
                if (mpd.Threshold.FirstPerformanceSinceEffectiveDate != null &&
                    !mpd.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
                {
                    if (firstPerformanceString != "N/A") firstPerformanceString += " or ";
                    else firstPerformanceString = "";
                    firstPerformanceString += "s/e.d: " + mpd.Threshold.FirstPerformanceSinceEffectiveDate;
                }

                if (mpd.NextPerformanceDate != null && mpd.NextPerformanceDate > defaultDateTime)
                    nextComplianceDate = Convert.ToDateTime(mpd.NextPerformanceDate);

                
                if (lastComplianceDate <= defaultDateTime)
                    lastPerformanceString = "N/A";
                else
                    lastPerformanceString = SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate) + " " +
                                            lastComplianceLifeLength;
                string nextComplianceString = ((nextComplianceDate <= defaultDateTime)
                                                   ? ""
                                                   : SmartCore.Auxiliary.Convert.GetDateFormat(nextComplianceDate) + " ") +
                                              mpd.NextPerformanceSource;
                string nextRemainString = mpd.Remains != null && !mpd.Remains.IsNullOrZero()
                                              ? mpd.Remains.ToString()
                                              : "N/A";

                #endregion

                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], !string.IsNullOrEmpty(mpd.TaskNumberCheck) ? mpd.TaskNumberCheck : "N/A", ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], mpd.TaskCardNumber, ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], !string.IsNullOrEmpty(mpd.MaintenanceManual) ? mpd.MaintenanceManual.Replace("\n", " ") : "N/A", ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], mpd.Category.ShortName);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], mpd.WorkType.ToString(), ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], mpd.Program.ToString(), ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], !string.IsNullOrEmpty(mpd.Description) ? mpd.Description : "N/A", ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], mpd.Zone);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], mpd.Access);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], mpd.Workarea, ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], mpd.ManHours <= 0 ? "" : mpd.ManHours.ToString());
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], firstPerformanceString);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], mpd.Threshold.RepeatInterval.ToString());
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], lastPerformanceString);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], nextComplianceString);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], nextRemainString);
               
                currentColumnPosition = 1;
                currentRowPosition++;
            }
		}

        public void ExportActivity(List<ActivityDTO> activity)
        {
			_package = new ExcelPackage();

			var sheetName = "Activity";

			Workbook.Worksheets.Add(sheetName);
			var workSheet = Workbook.Worksheets[sheetName];

			FillHeaderCell(workSheet.Cells[1, 1], "Time", ExcelHorizontalAlignment.Center);
			workSheet.Column(1).Width = 14;

			FillHeaderCell(workSheet.Cells[1, 2], "User", ExcelHorizontalAlignment.Center);
			workSheet.Column(2).Width = 26;

			FillHeaderCell(workSheet.Cells[1, 3], "Activity Type", ExcelHorizontalAlignment.Center);
			workSheet.Column(3).Width = 14;

			FillHeaderCell(workSheet.Cells[1, 4], "Object Type", ExcelHorizontalAlignment.Center);
			workSheet.Column(4).Width = 16;

			FillHeaderCell(workSheet.Cells[1, 5], "Aircraft", ExcelHorizontalAlignment.Center);
			workSheet.Column(5).Width = 16;

			FillHeaderCell(workSheet.Cells[1, 6], "Title", ExcelHorizontalAlignment.Center);
			workSheet.Column(6).Width = 14;

			FillHeaderCell(workSheet.Cells[1, 7], "Additional Information", ExcelHorizontalAlignment.Center);
			workSheet.Column(7).Width = 12;

			workSheet.Column(6).Style.WrapText = true;

			workSheet.DefaultRowHeight = 15;
			workSheet.View.FreezePanes(2, 1);

			int currentRowPosition = 2;
			int currentColumnPosition = 1;


			foreach (var act in activity)
	        {
				FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], act.Date.ToString("HH:mm:ss"));
				FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], act.User.ToString(), ExcelHorizontalAlignment.Left);
				FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], act.Operation.ToString());
				FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], act.Type.FullName, ExcelHorizontalAlignment.Left);
				FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], act.Aircraft.ToString());
				FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], act.Title, ExcelHorizontalAlignment.Left);
				FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], act.Information);

				currentColumnPosition = 1;
				currentRowPosition++;
			}
        }
		
		#region Export Directives

		public void ExportDirective(List<Directive> directives)
        {
            _package = new ExcelPackage();

            var sheetName = "Directive";

            Workbook.Worksheets.Add(sheetName);
            var workSheet = Workbook.Worksheets[sheetName];

            FillHeaderCell(workSheet.Cells[1, 1], "AD No", ExcelHorizontalAlignment.Center);
            workSheet.Column(1).Width = 16;

            FillHeaderCell(workSheet.Cells[1, 2], "SB No", ExcelHorizontalAlignment.Center);
            workSheet.Column(2).Width = 12;

            FillHeaderCell(workSheet.Cells[1, 3], "EO No", ExcelHorizontalAlignment.Center);
            workSheet.Column(3).Width = 12;

            FillHeaderCell(workSheet.Cells[1, 4], "STC No", ExcelHorizontalAlignment.Center);
            workSheet.Column(4).Width = 12;

            FillHeaderCell(workSheet.Cells[1, 5], "Description", ExcelHorizontalAlignment.Center);
            workSheet.Column(5).Width = 15;

            FillHeaderCell(workSheet.Cells[1, 6], "Applicability", ExcelHorizontalAlignment.Center);
            workSheet.Column(6).Width = 12;

            FillHeaderCell(workSheet.Cells[1, 7], "Work Type", ExcelHorizontalAlignment.Center);
            workSheet.Column(7).Width = 10;

            FillHeaderCell(workSheet.Cells[1, 8], "Status", ExcelHorizontalAlignment.Center);
            workSheet.Column(8).Width = 10;

            FillHeaderCell(workSheet.Cells[1, 9], "Effective Date", ExcelHorizontalAlignment.Center);
            workSheet.Column(9).Width = 14;

            FillHeaderCell(workSheet.Cells[1, 10], "1st. Perf.", ExcelHorizontalAlignment.Center);
            workSheet.Column(10).Width = 12;

            FillHeaderCell(workSheet.Cells[1, 11], "Rpt. Intv", ExcelHorizontalAlignment.Center);
            workSheet.Column(11).Width = 12;

            FillHeaderCell(workSheet.Cells[1, 12], "Last", ExcelHorizontalAlignment.Center);
            workSheet.Column(12).Width = 30;

            FillHeaderCell(workSheet.Cells[1, 13], "Next", ExcelHorizontalAlignment.Center);
            workSheet.Column(13).Width = 18;

            FillHeaderCell(workSheet.Cells[1, 14], "Remain/Overdue", ExcelHorizontalAlignment.Center);
            workSheet.Column(14).Width = 12;

            FillHeaderCell(workSheet.Cells[1, 15], "ATA", ExcelHorizontalAlignment.Center);
            workSheet.Column(15).Width = 10;

            FillHeaderCell(workSheet.Cells[1, 16], "Remarks", ExcelHorizontalAlignment.Center);
            workSheet.Column(16).Width = 15;
            workSheet.Column(16).Style.WrapText = true;
            
            workSheet.DefaultRowHeight = 15;
            workSheet.View.FreezePanes(2, 1);

            int currentRowPosition = 2;
            int currentColumnPosition = 1;

            directives.Sort(new DirectiveComparer());
            
            foreach (var directive in directives)
            {
                #region MyRegion

                var lastComplianceDate = DateTimeExtend.GetCASMinDateTime();
                var nextComplianceDate = DateTimeExtend.GetCASMinDateTime();
                var lastComplianceLifeLength = Lifelength.Zero;
                var nextComplianceLifeLength = Lifelength.Null;
                var nextComplianceRemain = Lifelength.Null;
                var effDate = DateTimeExtend.GetCASMinDateTime();

                string lastPerformanceString, firstPerformanceString = "N/A";

                if (directive.LastPerformance != null &&
                    directive.LastPerformance.RecordDate > lastComplianceDate)
                {
                    lastComplianceDate = directive.LastPerformance.RecordDate;
                    lastComplianceLifeLength = directive.LastPerformance.OnLifelength;
                }

                if (directive.Threshold.FirstPerformanceSinceNew != null && !directive.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                {
                    firstPerformanceString = "s/n: " + directive.Threshold.FirstPerformanceSinceNew;
                }
                if (directive.Threshold.FirstPerformanceSinceEffectiveDate != null &&
                    !directive.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
                {
                    if (firstPerformanceString != "N/A") firstPerformanceString += " or ";
                    else firstPerformanceString = "";
                    firstPerformanceString += "s/e.d: " + directive.Threshold.FirstPerformanceSinceEffectiveDate;
                }
                var repeatInterval = directive.Threshold.RepeatInterval;

                if (nextComplianceLifeLength == null || nextComplianceLifeLength.IsNullOrZero())
                    nextComplianceLifeLength = directive.NextPerformanceSource;
                if (directive.NextPerformanceSource != null && !directive.NextPerformanceSource.IsNullOrZero() &&
                    directive.NextPerformanceSource.IsLessOrEqualByAnyParameter(nextComplianceLifeLength))
                {
                    nextComplianceLifeLength = directive.NextPerformanceSource;
                    if (directive.NextPerformanceDate != null) nextComplianceDate = (DateTime)directive.NextPerformanceDate;
                    if (directive.Remains != null) nextComplianceRemain = directive.Remains;
                }
                if (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
                    lastPerformanceString = "N/A";
                else
                    lastPerformanceString = SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate) + " " +
                                            lastComplianceLifeLength;

                var nextComplianceString = ((nextComplianceDate <= DateTimeExtend.GetCASMinDateTime())
                                                   ? ""
                                                   : SmartCore.Auxiliary.Convert.GetDateFormat(nextComplianceDate)) + " " +
                                              nextComplianceLifeLength;
                var nextRemainString = nextComplianceRemain != null && !nextComplianceRemain.IsNullOrZero()
                                              ? nextComplianceRemain.ToString()
                                              : "N/A";

                effDate = directive.Threshold.EffectiveDate;

                #endregion

                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], directive.Title + "  §: " + directive.Paragraph);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], !string.IsNullOrEmpty(directive.ServiceBulletinNo) ? directive.ServiceBulletinNo : "N/A");
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], !string.IsNullOrEmpty(directive.EngineeringOrders) ? directive.EngineeringOrders : "N/A");
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], !string.IsNullOrEmpty(directive.StcNo) ? directive.StcNo : "N/A");
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], directive.Description, ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], directive.IsApplicability ? $"APL  {directive.Applicability.TrimEnd(' ')}" : $"N/A  {directive.Applicability.TrimEnd(' ')}");
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], directive.WorkType);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], directive.Status);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], effDate > DateTimeExtend.GetCASMinDateTime() ? SmartCore.Auxiliary.Convert.GetDateFormat(effDate) : "");
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], firstPerformanceString);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], repeatInterval.ToString());
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], lastPerformanceString);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], nextComplianceString);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], nextRemainString);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], directive.ATAChapter.ToString(), ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], directive.Remarks.Replace("\r\n", " "), ExcelHorizontalAlignment.Left);
                
                currentColumnPosition = 1;
                currentRowPosition++;
            }
        }

        #endregion

        #region Export Component

        public void ExportComponent(List<BaseEntityObject> components)
        {
            _package = new ExcelPackage();

            var sheetName = "Component";

            Workbook.Worksheets.Add(sheetName);
            var workSheet = Workbook.Worksheets[sheetName];

            FillHeaderCell(workSheet.Cells[1, 1], "ATA", ExcelHorizontalAlignment.Center);
            workSheet.Column(1).Width = 12;

            FillHeaderCell(workSheet.Cells[1, 2], "Part. No", ExcelHorizontalAlignment.Center);
            workSheet.Column(2).Width = 12;

            FillHeaderCell(workSheet.Cells[1, 3], "Description", ExcelHorizontalAlignment.Center);
            workSheet.Column(3).Width = 12;

            FillHeaderCell(workSheet.Cells[1, 4], "Work Type", ExcelHorizontalAlignment.Center);
            workSheet.Column(4).Width = 12;

            FillHeaderCell(workSheet.Cells[1, 5], "Serial No", ExcelHorizontalAlignment.Center);
            workSheet.Column(5).Width = 14;

            FillHeaderCell(workSheet.Cells[1, 6], "MPD Item", ExcelHorizontalAlignment.Center);
            workSheet.Column(6).Width = 12;

            FillHeaderCell(workSheet.Cells[1, 7], "Pos. No", ExcelHorizontalAlignment.Center);
            workSheet.Column(7).Width = 12;

            FillHeaderCell(workSheet.Cells[1, 8], "M.P.", ExcelHorizontalAlignment.Center);
            workSheet.Column(8).Width = 5;

            FillHeaderCell(workSheet.Cells[1, 9], "Zone-Area", ExcelHorizontalAlignment.Center);
            workSheet.Column(9).Width = 12;

            FillHeaderCell(workSheet.Cells[1, 10], "Access", ExcelHorizontalAlignment.Center);
            workSheet.Column(10).Width = 12;

            FillHeaderCell(workSheet.Cells[1, 11], "Inst. date", ExcelHorizontalAlignment.Center);
            workSheet.Column(11).Width = 11;

            FillHeaderCell(workSheet.Cells[1, 12], "Life limit/1st. Perf", ExcelHorizontalAlignment.Center);
            workSheet.Column(12).Width = 8;

            FillHeaderCell(workSheet.Cells[1, 13], "Rpt. int.", ExcelHorizontalAlignment.Center);
            workSheet.Column(13).Width = 8;

            FillHeaderCell(workSheet.Cells[1, 14], "Next", ExcelHorizontalAlignment.Center);
            workSheet.Column(14).Width = 20;

            FillHeaderCell(workSheet.Cells[1, 15], "Remain/Overdue", ExcelHorizontalAlignment.Center);
            workSheet.Column(15).Width = 13;

            FillHeaderCell(workSheet.Cells[1, 16], "Last", ExcelHorizontalAlignment.Center);
            workSheet.Column(16).Width = 30;

            FillHeaderCell(workSheet.Cells[1, 17], "M.H.", ExcelHorizontalAlignment.Center);
            workSheet.Column(17).Width = 5;

            FillHeaderCell(workSheet.Cells[1, 18], "Remarks", ExcelHorizontalAlignment.Center);
            workSheet.Column(18).Width = 12;
            workSheet.Column(18).Style.WrapText = true;

            workSheet.DefaultRowHeight = 15;
            workSheet.View.FreezePanes(2, 1);

            int currentRowPosition = 2;
            int currentColumnPosition = 1;

            foreach (var comp in components.OfType<IAtaSorted>().OrderBy(i => i.AtaSorted.ShortName))
            {
                #region MyRegion

                DateTime? approx;
                Lifelength remains, next;
                AtaChapter ata;
                MaintenanceControlProcess maintenanceType;
                DateTime transferDate;
                Lifelength firstPerformance = Lifelength.Null,
                           lastPerformance = Lifelength.Null,
                           repeatInterval = Lifelength.Null;
                string partNumber,
                       description,
                       serialNumber,
                       position,
                       mpdString = "",
                       lastPerformanceString = "",
                       classString = "",
                       remarks,
                       workType = "",
                       zone = "",
                       access = "",
                       ndtString = "";
                double manHours,
                       costServiceable = 0,
                       costOverhaul = 0;
                if (comp is Component)
                {
                    var componentItem = (Component)comp;
                    approx = componentItem.NextPerformanceDate;
                    next = componentItem.NextPerformanceSource;
                    remains = componentItem.LLPCategories ? componentItem.LLPRemains : componentItem.Remains;
                    ata = componentItem.ATAChapter;
                    partNumber = componentItem.PartNumber;
                    description = componentItem.Model != null ? componentItem.Model.Description : componentItem.Description;
                    serialNumber = componentItem.SerialNumber;
                    position = componentItem.TransferRecords.GetLast().Position.ToUpper();
                    maintenanceType = componentItem.MaintenanceControlProcess;
                    transferDate = componentItem.TransferRecords.GetLast().TransferDate;
                    firstPerformance = componentItem.LifeLimit;
                    manHours = componentItem.ManHours;
                    remarks = componentItem.Remarks;
                }
                else
                {
                    var dd = (ComponentDirective)comp;
                    if (dd.Threshold.FirstPerformanceSinceNew != null && !dd.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                        firstPerformance = dd.Threshold.FirstPerformanceSinceNew;
                    
                    if (dd.LastPerformance != null)
                    {
                        lastPerformanceString =
                            SmartCore.Auxiliary.Convert.GetDateFormat(dd.LastPerformance.RecordDate) + " " +
                            dd.LastPerformance.OnLifelength;
                        lastPerformance = dd.LastPerformance.OnLifelength;
                    }
                    if (dd.Threshold.RepeatInterval != null && !dd.Threshold.RepeatInterval.IsNullOrZero())
                        repeatInterval = dd.Threshold.RepeatInterval;

                    approx = dd.NextPerformanceDate;
                    next = dd.NextPerformanceSource;
                    remains = dd.Remains;
                    ata = dd.AtaSorted;
                    partNumber = "    " + dd.PartNumber;
                    var desc = dd.ParentComponent.Model != null
                        ? dd.ParentComponent.Model.Description
                        : dd.ParentComponent.Description;

                    description = "    " + desc;
                    serialNumber = "    " + dd.SerialNumber;
                    position = "    " + dd.ParentComponent.TransferRecords.GetLast().Position.ToUpper();
                    transferDate = dd.ParentComponent.TransferRecords.GetLast().TransferDate;
                    maintenanceType = dd.ParentComponent.MaintenanceControlProcess;
                    manHours = dd.ManHours;
                    zone = dd.ZoneArea;
                    access = dd.AccessDirective;
                    remarks = dd.Remarks;
                    workType = dd.DirectiveType.ToString();

                    if (dd.MaintenanceDirective != null)
                        mpdString = dd.MaintenanceDirective.TaskNumberCheck;
                }

                #endregion

                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], ata.ToString(), ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], partNumber.TrimStart(' '));
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], description.TrimStart(' '), ExcelHorizontalAlignment.Left);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], workType);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], serialNumber.TrimStart(' '));
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], mpdString);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], position.TrimStart(' '));
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], maintenanceType.ShortName);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], zone);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], access);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], transferDate > DateTimeExtend.GetCASMinDateTime() ? SmartCore.Auxiliary.Convert.GetDateFormat(transferDate) : "");
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], firstPerformance.ToString());
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], repeatInterval.ToString());
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], approx == null ? "" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)approx) + " " + next);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], remains != null && !remains.IsNullOrZero() ? remains.ToString() : "");
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], lastPerformanceString);
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], manHours.ToString());
                FillCell(workSheet.Cells[currentRowPosition, currentColumnPosition++], remarks, ExcelHorizontalAlignment.Left);

                currentColumnPosition = 1;
                currentRowPosition++;
            }
        }

        #endregion

        #region private void Completed(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)

        public void Completed(object sender, RunWorkerCompletedEventArgs e)
        {
	        var sfd = new SaveFileDialog();
	        sfd.Filter = ".xlsx Files (*.xlsx)|*.xlsx";

	        if (sfd.ShowDialog() == DialogResult.OK)
	        {
		        SaveTo(sfd.FileName);
		        MessageBox.Show("File was success saved!");
	        }

	        Dispose();
        }

        #endregion

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