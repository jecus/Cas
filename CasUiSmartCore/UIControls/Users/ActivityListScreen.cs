﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.Entity.Models.DTO.General;
using CAS.UI.ExcelExport;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using Entity.Abstractions.Filters;
using MongoDB.Driver;
using SmartCore.Activity;
using SmartCore.AuditMongo.Repository;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;

namespace CAS.UI.UIControls.Users
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class ActivityListScreen : ScreenControl
	{
		#region Fields

		private CommonCollection<ActivityDTO> _initial = new CommonCollection<ActivityDTO>();
		private CommonCollection<ActivityDTO> _result = new CommonCollection<ActivityDTO>();
		private ActivityListView _directivesViewer;

		private CommonFilterCollection _filter;
		private AnimatedThreadWorker _worker;
		private ExcelExportProvider _exportProvider;

		#endregion

		#region Constructors

		#region public ActivityListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public ActivityListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public ActivityListScreen(Operator currentOperator) : this()

		public ActivityListScreen(Operator currentOperator)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");

			_filter = new CommonFilterCollection(typeof(ActivityDTO));
			aircraftHeaderControl1.Operator = currentOperator;
			StatusTitle = "Activity";

			UpdateInformation();

			InitListView();
			AnimatedThreadWorker.RunWorkerAsync();
		}



		#endregion

		#endregion

		#region Methods

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			var date = DateTime.Now;
			dateTimePickerDateFrom.Value = new DateTime(date.Year, date.Month, date.Day, 0, 0, 1).AddDays(-7);
			dateTimePickerDateTo.Value = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			_directivesViewer.SetItemsArray(_result.OrderByDescending(i => i.Date).ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;

			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override async void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initial.Clear();
			_result.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load Activities");

			try
			{
				var activity = GlobalObjects.AuditContext.AuditCollection
					.FindSync(i => i.Date >= dateTimePickerDateFrom.Value && i.Date <= dateTimePickerDateTo.Value)
					.ToList();

				var users =  GlobalObjects.CasEnvironment.ApiProvider.GetAllUsersAsync();

				foreach (var bsonElement in activity)
				{
					Enum.TryParse(bsonElement.Action, out AuditOperation myStatus);
					var userr = users.FirstOrDefault(i => i.ItemId == bsonElement.UserId);
					_initial.Add(new ActivityDTO()
					{
						Date = bsonElement.Date,
						User = userr!= null ? new User(userr): new User(){Name = $"Deleted User with Id:{bsonElement.UserId}"},
						Operation = myStatus,
						ObjectId = bsonElement.ObjectId,
						Type = SmartCoreType.GetSmartCoreTypeById(bsonElement.ObjectTypeId),
						Information = bsonElement.AdditionalParameters?.Count > 0 ? string.Join(",", bsonElement.AdditionalParameters.Select(i => i.Value.ToString())) : ""
					});
				}

				AnimatedThreadWorker.ReportProgress(50 , "load Parents");
				foreach (var obj in _initial.GroupBy(i => i.Type?.ItemId))
				{
					if (obj.Key == SmartCoreType.WorkPackage.ItemId)
					{
						var ids = obj.Select(i => i.ObjectId);
						var wps = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<WorkPackageDTO, WorkPackage>(new Filter("ItemId", ids), getDeleted:true);
						foreach (var dto in obj)
						{
							var wp = wps.FirstOrDefault(i => i.ItemId == dto.ObjectId);
							if(wp == null)
								continue;
							dto.Aircraft = GlobalObjects.AircraftsCore.GetAircraftById(wp.ParentId);
							dto.Title = wp.Title;
						}
					}
					else if (obj.Key == SmartCoreType.WorkPackageRecord.ItemId)
					{
						var ids = obj.Select(i => i.ObjectId);
						var wpr = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<WorkPackageRecordDTO, WorkPackageRecord>(new Filter("ItemId", ids), getDeleted: true);
						var wpIds = wpr.Select(i => i.WorkPakageId);
						var wps = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<WorkPackageDTO, WorkPackage>(new Filter("ItemId", wpIds), getDeleted: true);
						foreach (var dto in obj)
						{
							var wp = wps.FirstOrDefault(i => i.ItemId == dto.ObjectId);
							if (wp == null)
								continue;
							dto.Aircraft = GlobalObjects.AircraftsCore.GetAircraftById(wp.ParentId);
							dto.Title = wp.Title;
						}
					}
					else if (obj.Key == SmartCoreType.MaintenanceDirective.ItemId)
					{
						var ids = obj.Select(i => i.ObjectId);
						var mpds = GlobalObjects.CasEnvironment.Loader.GetObjectList<MaintenanceDirective>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, ids.ToArray()), getDeleted: true);
						foreach (var dto in obj)
						{
							var mpd = mpds.FirstOrDefault(i => i.ItemId == dto.ObjectId);
							if (mpd == null)
								continue;
							dto.Aircraft = GlobalObjects.AircraftsCore.GetAircraftById(mpd.ParentBaseComponent.ParentAircraftId);
							dto.Title = mpd.Title;
						}
					}
					else if (obj.Key == SmartCoreType.Directive.ItemId)
					{
						var ids = obj.Select(i => i.ObjectId);
						var directives = GlobalObjects.CasEnvironment.Loader.GetObjectList<Directive>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, ids.ToArray()), getDeleted: true);
						foreach (var dto in obj)
						{
							var directive = directives.FirstOrDefault(i => i.ItemId == dto.ObjectId);
							if (directive == null)
								continue;
							dto.Aircraft = GlobalObjects.AircraftsCore.GetAircraftById(directive.ParentBaseComponent.ParentAircraftId);
							dto.Title = directive.Title;
						}
					}
					else if (obj.Key == SmartCoreType.DirectiveRecord.ItemId)
					{
						var ids = obj.Select(i => i.ObjectId);
						var directiveRecords = GlobalObjects.CasEnvironment.Loader.GetObjectList<DirectiveRecord>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, ids.ToArray()), getDeleted: true);
						var directiveIds = directiveRecords.Select(i => i.ParentId);
						var directives = GlobalObjects.CasEnvironment.Loader.GetObjectList<Directive>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, directiveIds.ToArray()), getDeleted: true);
						foreach (var dto in obj)
						{
							var directive = directives.FirstOrDefault(i => i.ItemId == dto.ObjectId);
							if (directive == null)
								continue;
							dto.Aircraft = GlobalObjects.AircraftsCore.GetAircraftById(directive.ParentBaseComponent.ParentAircraftId);
							dto.Title = directive.Title;
						}
					}
					else if (obj.Key == SmartCoreType.BaseComponent.ItemId)
					{
						var ids = obj.Select(i => i.ObjectId);
						var baseComponents = GlobalObjects.CasEnvironment.Loader.GetObjectList<BaseComponent>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, ids.ToArray()), getDeleted: true);
						foreach (var dto in obj)
						{
							var baseComponent = baseComponents.FirstOrDefault(i => i.ItemId == dto.ObjectId);
							if (baseComponent == null)
								continue;
							dto.Aircraft = GlobalObjects.AircraftsCore.GetAircraftById(baseComponent.ParentAircraftId);
							dto.Title = baseComponent.SerialNumber;
						}
					}
					else if (obj.Key == SmartCoreType.Component.ItemId)
					{
						var ids = obj.Select(i => i.ObjectId);
						var components = GlobalObjects.CasEnvironment.Loader.GetObjectList<SmartCore.Entities.General.Accessory.Component>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, ids.ToArray()), getDeleted: true);
						foreach (var dto in obj)
						{
							var component = components.FirstOrDefault(i => i.ItemId == dto.ObjectId);
							if (component == null)
								continue;
							dto.Aircraft = GlobalObjects.AircraftsCore.GetAircraftById(component.ParentAircraftId);
							dto.Title = component.SerialNumber;
						}
					}
					else if (obj.Key == SmartCoreType.ComponentDirective.ItemId)
					{
						var ids = obj.Select(i => i.ObjectId);
						var componentDirectives = GlobalObjects.CasEnvironment.Loader.GetObjectList<ComponentDirective>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, ids.ToArray()), getDeleted: true);
						var componentIds = componentDirectives.Select(i => i.ComponentId);
						var components = GlobalObjects.CasEnvironment.Loader.GetObjectList<SmartCore.Entities.General.Accessory.Component>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, componentIds.ToArray()), getDeleted: true);
						foreach (var dto in obj)
						{
							var component = components.FirstOrDefault(i => i.ItemId == dto.ObjectId);
							if (component == null)
								continue;
							dto.Aircraft = GlobalObjects.AircraftsCore.GetAircraftById(component.ParentAircraftId);
							dto.Title = component.SerialNumber;
						}
					}
					else if (obj.Key == SmartCoreType.AircraftFlight.ItemId)
					{
						var ids = obj.Select(i => i.ObjectId);
						var flights = GlobalObjects.CasEnvironment.Loader.GetObjectList<AircraftFlight>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, ids.ToArray()), getDeleted: true);
						foreach (var dto in obj)
						{
							var flight = flights.FirstOrDefault(i => i.ItemId == dto.ObjectId);
							if (flight == null)
								continue;
							dto.Aircraft = GlobalObjects.AircraftsCore.GetAircraftById(flight.AircraftId);
							dto.Title = flight.ToString();
						}
					}
					else if (obj.Key == SmartCoreType.Discrepancy.ItemId)
					{
						var ids = obj.Select(i => i.ObjectId);
						var discrepancies = GlobalObjects.CasEnvironment.Loader.GetObjectList<Discrepancy>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, ids.ToArray()), getDeleted: true);
						var flIds = discrepancies.Select(i => i.FlightId);
						var flights = GlobalObjects.CasEnvironment.Loader.GetObjectList<AircraftFlight>(new CommonFilter<int>(BaseEntityObject.ItemIdProperty, FilterType.In, flIds.ToArray()), getDeleted: true);
						foreach (var dto in obj)
						{
							var flight = flights.FirstOrDefault(i => i.ItemId == dto.ObjectId);
							if (flight == null)
								continue;
							dto.Aircraft = GlobalObjects.AircraftsCore.GetAircraftById(flight.AircraftId);
							dto.Title = flight.ToString();
						}
					}
				}
			}
			catch(Exception ex)
			{
				Program.Provider.Logger.Log("Error while load documents", ex);
			}

			AnimatedThreadWorker.ReportProgress(70, "filter documents");
			FilterItems(_initial, _result);

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}
		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new ActivityListView
			{
				TabIndex = 2,
				Location = new Point(panel1.Left, panel1.Top),
				Dock = DockStyle.Fill,
			};

			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, System.EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filter, _initial);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			_result.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(50, "filter directives");

			FilterItems(_initial, _result);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#endregion

		#region private void FilterItems(IEnumerable<Document> initialCollection, ICommonCollection<Document> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<ActivityDTO> initialCollection, ICommonCollection<ActivityDTO> resultCollection)
		{
			if (_filter == null || _filter.All(i => i.Values.Length == 0))
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
			}

			resultCollection.Clear();

			foreach (var pd in initialCollection)
			{
				if (_filter.FilterTypeAnd)
				{
					bool acceptable = true;
					foreach (ICommonFilter filter in _filter)
					{
						acceptable = filter.Acceptable(pd); if (!acceptable) break;
					}
					if (acceptable) resultCollection.Add(pd);
				}
				else
				{
					bool acceptable = true;
					foreach (ICommonFilter filter in _filter)
					{
						if (filter.Values == null || filter.Values.Length == 0)
							continue;
						acceptable = filter.Acceptable(pd); if (acceptable) break;
					}
					if (acceptable) resultCollection.Add(pd);
				}
			}
		}
		#endregion

		#region private void ButtonOkClick(object sender, EventArgs e)

		private void ButtonOkClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		private void ExportActivity_Click(object sender, EventArgs eventArgs)
		{
			_worker = new AnimatedThreadWorker();
			_worker.DoWork += ExportActivityWork;
			_worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
			_worker.RunWorkerAsync();
		}

		private void ExportActivityWork(object sender, DoWorkEventArgs e)
		{
			_worker.ReportProgress(0, "load Activity");
			_worker.ReportProgress(0, "Generate file! Please wait....");

			_exportProvider = new ExcelExportProvider();
			_exportProvider.ExportActivity(_result.ToList());
		}

		private void Worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			var sfd = new SaveFileDialog();
			sfd.Filter = ".xlsx Files (*.xlsx)|*.xlsx";

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				_exportProvider.SaveTo(sfd.FileName);
				MessageBox.Show("File was success saved!");
			}

			_exportProvider.Dispose();
		}


		#endregion


	}
}
