using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using MongoDB.Bson;
using MongoDB.Driver;
using SmartCore.Activity;
using SmartCore.AuditMongo;
using SmartCore.AuditMongo.Repository;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
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
			StatusTitle = "Users";
			
			InitListView();
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#endregion

		#region Methods

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			_directivesViewer.SetItemsArray(_result.OrderByDescending(i => i.Date).ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ListViewItemList.Count != 0;

			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initial.Clear();
			_result.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load Activities");

			try
			{
				var activity = GlobalObjects.AuditContext.AuditCollection.FindSync(new BsonDocumentFilterDefinition<AuditEntity>(new BsonDocument())).ToList();
				var users = GlobalObjects.CasEnvironment.GetAllUsers();
				foreach (var bsonElement in activity)
				{
					Enum.TryParse(bsonElement.Action, out AuditOperation myStatus);
					
					_initial.Add(new ActivityDTO()
					{
						Date = bsonElement.Date,
						User = users.FirstOrDefault(i => i.ItemId == bsonElement.UserId),
						Operation = myStatus,
						ObjectId = bsonElement.ObjectId,
						Type = SmartCoreType.GetSmartCoreTypeById(bsonElement.ObjectTypeId)
					});
				}
			}
			catch(Exception ex)
			{
				Program.Provider.Logger.Log("Error while load documents", ex);
			}

			AnimatedThreadWorker.ReportProgress(20, "calculation documents");

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
				//IgnoreAutoResize = true
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
			if (_filter == null || _filter.Count == 0)
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


		#endregion

	}
}
