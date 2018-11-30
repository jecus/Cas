using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;
using SmartCore.Filters;

namespace CAS.UI.UIControls.PersonnelControls
{
	public partial class EmployeeFlightControl : UserControl
	{
		private readonly AnimatedThreadWorker AnimatedThreadWorker = new AnimatedThreadWorker();
		private ICommonCollection<AircraftFlight> _initialDocumentArray = new CommonCollection<AircraftFlight>();
		private ICommonCollection<AircraftFlight> _resultDocumentArray = new CommonCollection<AircraftFlight>();
		private CommonFilterCollection _filter;
		private Specialist _currentItem;
		private bool _firstLoad = true;

		#region Properties

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

		#endregion

		#region Constuctor

		public EmployeeFlightControl()
		{
			InitializeComponent();
			_filter = new CommonFilterCollection(typeof(IEmployeeFlightFilterParams));
		}

		#endregion

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			if (_currentItem == null)
				return;

			_initialDocumentArray.Clear();
			_resultDocumentArray.Clear();

			if (_firstLoad)
			{
				_firstLoad = false;
				if (_currentItem.EmployeeFlights.Count > 0)
				{
					dateTimePickerDateFrom.Value = _currentItem.EmployeeFlights.FirstOrDefault().RecordDate;
					dateTimePickerDateTo.Value = _currentItem.EmployeeFlights.LastOrDefault().RecordDate;
				}
			}

			foreach (var t in _currentItem.EmployeeFlights)
			{
				if (t.FlightDate >= dateTimePickerDateFrom.Value &&
					t.FlightDate <= dateTimePickerDateTo.Value)
					_initialDocumentArray.Add(t);
			}

			//_initialDocumentArray.AddRange(_currentItem.EmployeeFlights.ToArray());

			FilterItems(_initialDocumentArray, _resultDocumentArray);

			employeeFlightListView.Flights = new AircraftFlightCollection(_initialDocumentArray.ToArray());
			employeeFlightListView.SetItemsArray(_resultDocumentArray.ToArray());
			employeeFlightListView.Focus();
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

		#region private void FilterItems(IEnumerable<AircraftFlight> initialCollection, ICommonCollection<AircraftFlight> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<AircraftFlight> initialCollection, ICommonCollection<AircraftFlight> resultCollection)
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

		#region private void buttonOK_Click(object sender, EventArgs e)

		private void buttonOK_Click(object sender, EventArgs e)
		{
			InvokeReload();
		}

		#endregion
	}
}
