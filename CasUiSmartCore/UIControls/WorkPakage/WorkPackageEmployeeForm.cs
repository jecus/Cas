using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using EntityCore.DTO.Dictionaries;
using EntityCore.DTO.General;
using EntityCore.Filter;
using MetroFramework.Forms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;

namespace CAS.UI.UIControls.WorkPakage
{
	public partial class WorkPackageEmployeeForm : MetroForm
	{
		#region Fields

		private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
		private CommonCollection<Specialist> _initialDocumentArray = new CommonCollection<Specialist>();
		private CommonCollection<Specialist> _resultDocumentArray = new CommonCollection<Specialist>();
		private CommonFilterCollection _filter;
		private CommonCollection<Specialist> _wpSpecialists = new CommonCollection<Specialist>();
		private CommonCollection<WorkPackageSpecialists> _workPackageSpecialists = new CommonCollection<WorkPackageSpecialists>();
		private WorkPackage _currentWorkPackage;

		#endregion

		#region Constructor

		public WorkPackageEmployeeForm()
		{
			InitializeComponent();
		}

		public WorkPackageEmployeeForm(WorkPackage currentWorkPackage) : this()
		{
			if (currentWorkPackage == null)
				throw new ArgumentNullException("currentWorkPackage", "must be not null");

			_currentWorkPackage = currentWorkPackage;

			_filter = new CommonFilterCollection(typeof(IEmployeeWorkPackageFilterParams));

			labelWpNumber.Text = currentWorkPackage.Number;
			labelWpTitle.Text = currentWorkPackage.Title;
			textboxRemark.Text = _currentWorkPackage.EmployeesRemark;

			_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
			_animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
		}

		#endregion

		#region private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)

		private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			workPackageEmployeeListViewAll.SetItemsArray(_initialDocumentArray.ToArray());
			workPackageEmployeeListView2.SetItemsArray(_wpSpecialists.ToArray());
		}

		#endregion

		#region private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
		{
			_workPackageSpecialists.Clear();

			_initialDocumentArray.Clear();
			_wpSpecialists.Clear();

			_initialDocumentArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<SpecialistDTO,Specialist>(loadChild:true));
			var aircraftModels = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<AccessoryDescriptionDTO,AircraftModel>(new Filter("ModelingObjectTypeId", 7));

			foreach (var specialist in _initialDocumentArray)
			{
				foreach (var license in specialist.Licenses)
				{
					if (license.AircraftTypeID > 0)
						license.AircraftType = aircraftModels.FirstOrDefault(a => a.ItemId == license.AircraftTypeID);
				}
			}


			_workPackageSpecialists.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<WorkPackageSpecialistsDTO,WorkPackageSpecialists>(new Filter("WorkPackageId", _currentWorkPackage.ItemId)));

			var specialistIds = _workPackageSpecialists.Select(w => w.SpecialistId).ToArray();
			if (specialistIds.Length > 0)
				_wpSpecialists.AddRange(_initialDocumentArray.Where(s => specialistIds.Any(id => id == s.ItemId)));



		}

		#endregion

		#region private void WorkPackageEmployeeForm_Load(object sender, EventArgs e)

		private void WorkPackageEmployeeForm_Load(object sender, EventArgs e)
		{
			_animatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void buttonAdd_Click(object sender, EventArgs e)

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			if (workPackageEmployeeListViewAll.SelectedItems.Count == 0)
				return;

			foreach (var selectedItem in workPackageEmployeeListViewAll.SelectedItems)
			{
				if (_wpSpecialists.Any(s => s.ItemId == selectedItem.ItemId))
				{
					MessageBox.Show($"{selectedItem.FirstName} {selectedItem.LastName} alredy added!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
					continue;
				}

				try
				{
					var wpSpecialist = new WorkPackageSpecialists {SpecialistId = selectedItem.ItemId, WorkPackageId = _currentWorkPackage.ItemId };
					 _wpSpecialists.Add(selectedItem);
					GlobalObjects.CasEnvironment.NewKeeper.Save(wpSpecialist);
					_workPackageSpecialists.Add(wpSpecialist);
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while save bind task record", ex);
				}
			}


			workPackageEmployeeListView2.SetItemsArray(_wpSpecialists.ToArray());
		}

		#endregion

		#region private void buttonDelete_Click(object sender, EventArgs e)

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			if (workPackageEmployeeListView2.SelectedItems.Count == 0)
				return;

			foreach (var selectedItem in workPackageEmployeeListView2.SelectedItems)
			{
				try
				{
					
					var wpSpecialist = _workPackageSpecialists.First(s => s.SpecialistId == selectedItem.ItemId);
					if(wpSpecialist != null)
						GlobalObjects.CasEnvironment.NewKeeper.Delete(wpSpecialist);

					_wpSpecialists.Remove(selectedItem);
					workPackageEmployeeListView2.SetItemsArray(_wpSpecialists.ToArray());
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while save bind task record", ex);
				}
			}
		}

		#endregion

		#region private void buttonClose_Click(object sender, EventArgs e)

		private void buttonClose_Click(object sender, EventArgs e)
		{
			_currentWorkPackage.EmployeesRemark = textboxRemark.Text;

			try
			{
				GlobalObjects.CasEnvironment.NewKeeper.Save(_currentWorkPackage);
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save bind task record", ex);
			}

			this.Close();
		}

		#endregion

	}
}
