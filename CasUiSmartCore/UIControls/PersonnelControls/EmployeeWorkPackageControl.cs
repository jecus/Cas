using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.FiltersControls;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;

namespace CAS.UI.UIControls.PersonnelControls
{
	public partial class EmployeeWorkPackageControl : UserControl
	{
		private Specialist _currentItem;
		private readonly AnimatedThreadWorker AnimatedThreadWorker = new AnimatedThreadWorker();
		private ICommonCollection<WorkPackage> _initialDocumentArray = new CommonCollection<WorkPackage>();
		private ICommonCollection<WorkPackage> _resultDocumentArray = new CommonCollection<WorkPackage>();
		private CommonFilterCollection _filter;

		#region public Specialist CurrentItem
		///<summary>
		///Текущая директива
		///</summary>
		public Specialist CurrentItem
		{
			set
			{
				_currentItem = value;
				if (_currentItem != null)
				{
					UpdateInformation();
				}
			}
		}

		#endregion

		#region Constructor

		public EmployeeWorkPackageControl()
		{
			InitializeComponent();
			_filter = new CommonFilterCollection(typeof(EmployeeWorkPackageFilterParams));
		}

		#endregion

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			if (_currentItem == null)
				return;

			_initialDocumentArray.Clear();
			_resultDocumentArray.Clear();

			_initialDocumentArray.AddRange(_currentItem.SpecialistWorkPackages);
			FilterItems(_initialDocumentArray, _resultDocumentArray);
			
			employeeWorkPackageListView.CurrentSpecialist = _currentItem;
			employeeWorkPackageListView.SetItemsArray(_resultDocumentArray.ToArray());
			employeeWorkPackageListView.Focus();
		}

		#endregion

		#region private void FilterItems(IEnumerable<AircraftFlight> initialCollection, ICommonCollection<AircraftFlight> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<WorkPackage> initialCollection, ICommonCollection<WorkPackage> resultCollection)
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

		#region private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			_resultDocumentArray.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(50, "filter directives");

			FilterItems(_initialDocumentArray, _resultDocumentArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#endregion

		#region private void ButtonFilter_Click(object sender, EventArgs e)

		private void ButtonFilter_Click(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filter, _initialDocumentArray);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();

				InvokeReload();
			}
		}

		#endregion

		#region Events
		/// <summary>
		/// Событие возникает при добавлени, удалении и фильтрации(Производится перегрузка EmployeeScreen)
		/// </summary>
		public event EventHandler Reload;
		public void InvokeReload()
		{
			EventHandler handler = Reload;
			if (Reload != null) handler(this, new EventArgs());

		}
		#endregion
	}
}
