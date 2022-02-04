using System;
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
using CAS.UI.UIControls.Users;
using CASTerms;
using Entity.Abstractions.Filters;
using MongoDB.Driver;
using SmartCore.Activity;
using SmartCore.AuditMongo;
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

namespace CAS.UI.UICAAControls.Activity
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class CAAActivityListScreen : ScreenControl
	{
        private readonly int _operatorId;

        #region Fields

		private CommonCollection<ActivityDTO> _initial = new CommonCollection<ActivityDTO>();
		private CommonCollection<ActivityDTO> _result = new CommonCollection<ActivityDTO>();
		private CAAActivityListView _directivesViewer;

		private CommonFilterCollection _filter;
		private AnimatedThreadWorker _worker;
		private ExcelExportProvider _exportProvider;

		#endregion

		#region Constructors

		#region public ActivityListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public CAAActivityListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public ActivityListScreen(Operator currentOperator) : this()

		public CAAActivityListScreen(Operator currentOperator, int operatorId)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
            _operatorId = operatorId;

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
			dateTimePickerDateFrom.Value = new DateTime(date.Year, date.Month, date.Day, 0, 0, 1).AddDays(-3);
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
                List<AuditEntity> activity = new List<AuditEntity>();
                if (_operatorId > 0)
                {
                    activity = GlobalObjects.AuditContext.AuditCollection
                        .FindSync(i => i.Date >= dateTimePickerDateFrom.Value && i.Date <= dateTimePickerDateTo.Value && i.OperatorId == _operatorId)
                        .ToList();
				}
                else
                {
                    activity = GlobalObjects.AuditContext.AuditCollection
                        .FindSync(i => i.Date >= dateTimePickerDateFrom.Value && i.Date <= dateTimePickerDateTo.Value)
                        .ToList();
				}


                
				var users =  GlobalObjects.CaaEnvironment.ApiProvider.GetAllUsersAsync();

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
			_directivesViewer = new CAAActivityListView
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
