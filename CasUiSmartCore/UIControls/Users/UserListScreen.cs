using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using EntityCore.DTO.General;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Personnel;
using SmartCore.Filters;

namespace CAS.UI.UIControls.Users
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class UserListScreen : ScreenControl
	{
		#region Fields

		private CommonCollection<User> _initial = new CommonCollection<User>();
		private CommonCollection<Specialist> _specialists = new CommonCollection<Specialist>();
		private CommonCollection<User> _result = new CommonCollection<User>();
		private UserListView _directivesViewer;

		private CommonFilterCollection _filter;


		#endregion

		#region Constructors

		#region public UserListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public UserListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public UserListScreen(Operator currentOperator) : this()

		public UserListScreen(Operator currentOperator)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");

			_filter = new CommonFilterCollection(typeof(User));
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
			_directivesViewer.SetItemsArray(_result.ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;

			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override async void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initial.Clear();
			_specialists.Clear();
			_result.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load documents");

			try
			{
				var userDto = GlobalObjects.CasEnvironment.ApiProvider.GetAllUsersAsync();
				_initial.AddRange(userDto.Select(i => new User(i)));

				_specialists.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectList<SpecialistDTO, Specialist>());
				foreach (var user in _initial)
				{
					user.Personnel = _specialists.FirstOrDefault(i => i.ItemId == user.PersonnelId) ??
					                 Specialist.Unknown;
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
			_directivesViewer = new UserListView
			{
				TabIndex = 2,
				Location = new Point(panel1.Left, panel1.Top),
				Dock = DockStyle.Fill,
				//IgnoreAutoResize = true
			};
			_directivesViewer.Specialists = _specialists;
			_directivesViewer.AnimatedThreadWorker = AnimatedThreadWorker;
			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void ButtonAddNonRoutineJobClick(object sender, EventArgs e)
		private void ButtonAddNonRoutineJobClick(object sender, EventArgs e)
		{
			var form = new UserForm(new User(), _specialists);

			if (form.ShowDialog() == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}
		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null) return;

			var confirmResult =
				MessageBox.Show(
					_directivesViewer.SelectedItem != null
						? "Do you really want to delete User " + _directivesViewer.SelectedItem.Login + "?"
						: "Do you really want to delete selected User? ", "Confirm delete operation",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				var selectedItems = new List<User>();
				selectedItems.AddRange(_directivesViewer.SelectedItems.ToArray());
				GlobalObjects.NewKeeper.Delete(selectedItems.OfType<BaseEntityObject>().ToList(), true);

				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
			else
			{
				MessageBox.Show("Failed to delete Documents: Parent container is invalid", "Operation failed",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
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
		private void FilterItems(IEnumerable<User> initialCollection, ICommonCollection<User> resultCollection)
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


		#endregion

	}
}
