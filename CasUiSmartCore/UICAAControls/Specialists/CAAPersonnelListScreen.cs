

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.Entity.Models.DTO.Dictionaries;
using CAS.Entity.Models.DTO.General;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using Entity.Abstractions;
using Entity.Abstractions.Filters;
using SmartCore.CAA.Operators;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;
using SmartCore.Filters;
using Telerik.WinControls.UI;
using FilterType = Entity.Abstractions.Attributte.FilterType;

namespace CAS.UI.UICAAControls.Specialists
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class CAAPersonnelListScreen : ScreenControl
	{
		#region Fields

		private Operator _currentOperator;
        private readonly int _operatorId;
        private readonly bool _licenseView;

        private CommonCollection<Specialist> _initialDocumentArray = new CommonCollection<Specialist>();
		private CommonCollection<Specialist> _resultDocumentArray = new CommonCollection<Specialist>();
		private CommonFilterCollection _filter;

		private BaseGridViewControl<Specialist> _directivesViewer;

		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuItemStatus;
		private RadMenuItem _toolStripMenuItemHighlight;
		private RadMenuSeparatorItem _toolStripSeparator1;

		#endregion

		#region Properties

		#endregion

		#region Constructors

		#region public CAAPersonnelListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public CAAPersonnelListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public PersonnelListScreen(Operator currentOperator)

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentOperator">ВС, которому принадлежат директивы</param>>
		public CAAPersonnelListScreen(Operator currentOperator, int operatorId, bool licenseView = false)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			aircraftHeaderControl1.Operator = currentOperator;
			_currentOperator = currentOperator;
            _operatorId = operatorId;
            _licenseView = licenseView;
            statusControl.ShowStatus = false;
			labelTitle.Visible = false;

			if (_licenseView)
				_filter = new CommonFilterCollection(typeof(ICAAEmployeeFilterParams));
			else _filter = new CommonFilterCollection(typeof(IEmployeeFilterParams));

			InitToolStripMenuItems();
			InitListView();
			UpdateInformation();
		}

		#endregion

		#endregion

		#region Methods

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			_directivesViewer.SetItemsArray(_resultDocumentArray.ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;
			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialDocumentArray.Clear();
			_resultDocumentArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load directives");
			GlobalObjects.CaaEnvironment.NewLoader.ReloadDictionary(typeof(Occupation), typeof(LocationsType), typeof(Department));
            if (_operatorId == -1)
            {
                _initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader
                    .GetObjectListAll<CAASpecialistDTO, Specialist>(loadChild: true));
			}
            else
            {
                _initialDocumentArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader
                    .GetObjectListAll<CAASpecialistDTO, Specialist>(new Filter("OperatorId", _operatorId),
                        loadChild: true));
			}

			var aircraftModels = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<AccessoryDescriptionDTO, AircraftModel>(new Filter("ModelingObjectTypeId", 7));


			if (_licenseView)
			{
				
				var ids = _initialDocumentArray.SelectMany(i => i.Licenses).Select(i => i.ItemId);
				var specIds = _initialDocumentArray.Select(i => i.ItemId);
				if (ids.Any())
				{
					var caaLicense = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CAASpecialistCustomDTO, SpecialistCAA>(new Filter("SpecialistLicenseId", FilterType.In,ids));
	                var caaLicenseDetails = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<SpecialistLicenseDetailDTO, SpecialistLicenseDetail>(new Filter("SpecialistLicenseId", FilterType.In,ids));
	                var specialistLicenseRating = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<SpecialistLicenseRatingDTO, SpecialistLicenseRating>(new Filter("SpecialistLicenseId", FilterType.In,ids));
	                var specialistLicenseRemark = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<SpecialistLicenseRemarkDTO, SpecialistLicenseRemark>(new Filter("SpecialistLicenseId", FilterType.In,ids));
	                var specialistInstrumentRating = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<SpecialistInstrumentRatingDTO, SpecialistInstrumentRating>(new Filter("SpecialistLicenseId", FilterType.In,ids));

	                var medicalRecords = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<CAASpecialistMedicalRecordDTO, SpecialistMedicalRecord>(new Filter("SpecialistId", FilterType.In, specIds));
	                
	                var det = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<SpecialistLicenseDetailDTO, SpecialistLicenseDetail>(new Filter("SpecialistId", FilterType.In,specIds), loadChild:true);
	                var remarks = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<SpecialistLicenseRemarkDTO, SpecialistLicenseRemark>(new Filter("SpecialistId", FilterType.In,specIds), loadChild:true);


	                foreach (var specialist in _initialDocumentArray)
	                {
		                var list = new List<ConditionState>();
		                
		                specialist.MedicalRecord = medicalRecords.FirstOrDefault(i => i.SpecialistId == specialist.ItemId);
		                if (specialist.MedicalRecord != null)
		                {
			                GlobalObjects.CaaEnvironment.CaaPerformanceRepository.CalcRemain(specialist.MedicalRecord, specialist.MedicalRecord.IssueDate,specialist.MedicalRecord.NotifyLifelength, specialist.MedicalRecord.RepeatLifelength);
			                
			                if(!specialist.MedicalRecord.RepeatLifelength.IsNullOrZero())
								specialist.MedicalRecord.ValidToDate = specialist.MedicalRecord.IssueDate.AddDays(specialist.MedicalRecord.RepeatLifelength.Days.Value);
			                list.Add(specialist.MedicalRecord.Condition);
		                }
		                
		                specialist.LicenseDetails = new CommonCollection<SpecialistLicenseDetail>(det.Where(i => i.SpecialistId == specialist.ItemId));
		                specialist.LicenseRemark = new CommonCollection<SpecialistLicenseRemark>(remarks.Where(i => i.SpecialistId == specialist.ItemId));
		                
		                foreach (var license in specialist.Licenses)
		                {
			                license.CaaLicense = new CommonCollection<SpecialistCAA>(caaLicense.Where(i => i.SpecialistLicenseId == license.ItemId));
			                foreach (var caa in license.CaaLicense)
			                {
				                if (!license.IsValidTo)
				                {
					                caa.Condition = ConditionState.UNK;
					                caa.Remain = Lifelength.Null;
					                continue;
				                }
				                
				                if (caa.CaaType == CaaType.Other)
					                GlobalObjects.CaaEnvironment.CaaPerformanceRepository.CalcRemain(caa, caa.ValidToDate, caa.NotifyLifelength);
				                else GlobalObjects.CaaEnvironment.CaaPerformanceRepository.CalcRemain(caa, license.ValidToDate, license.NotifyLifelength);
			                }
			                
			                if(license.CaaLicense.Any(i => i.CaaType == CaaType.Other)) 
				                list.Add(license.CaaLicense.FirstOrDefault(i => i.CaaType == CaaType.Other)?.Condition);
			                if(license.CaaLicense.Any(i => i.CaaType == CaaType.Licence)) 
								list.Add(license.CaaLicense.FirstOrDefault(i => i.CaaType == CaaType.Licence)?.Condition);
			                
			                license.LicenseDetails = new CommonCollection<SpecialistLicenseDetail>(caaLicenseDetails.Where(i => i.SpecialistLicenseId == license.ItemId));
			                license.LicenseRatings = new CommonCollection<SpecialistLicenseRating>(specialistLicenseRating.Where(i => i.SpecialistLicenseId == license.ItemId));
			                license.LicenseRemark = new CommonCollection<SpecialistLicenseRemark>(specialistLicenseRemark.Where(i => i.SpecialistLicenseId == license.ItemId));
			                license.SpecialistInstrumentRatings = new CommonCollection<SpecialistInstrumentRating>(specialistInstrumentRating.Where(i => i.SpecialistLicenseId == license.ItemId));
		                }
		                
		                if (list.Any(i => i.ItemId == ConditionState.Overdue.ItemId))
			                specialist.Condition = ConditionState.Overdue;
		                else if (list.Any(i => i.ItemId == ConditionState.Notify.ItemId))
			                specialist.Condition = ConditionState.Notify;
		                else specialist.Condition = ConditionState.NotEstimated;

		                if (specialist.Condition == ConditionState.Overdue && specialist.Settings.StatusId != OperatorStatus.Limiting.ItemId)
		                {
			                specialist.Settings.StatusId = OperatorStatus.Limiting.ItemId;
			                GlobalObjects.CaaEnvironment.NewKeeper.Save(specialist, saveCorrector:false);
		                }
		                else if (specialist.Condition != ConditionState.Overdue && specialist.Settings.StatusId == OperatorStatus.Limiting.ItemId)
		                {
		                    specialist.Settings.StatusId = OperatorStatus.Valid.ItemId;
                            GlobalObjects.CaaEnvironment.NewKeeper.Save(specialist, saveCorrector:false);
		                }
		                else if (specialist.Settings.StatusId == OperatorStatus.Unknown.ItemId)
		                {
			                specialist.Settings.StatusId = OperatorStatus.Valid.ItemId;
			                GlobalObjects.CaaEnvironment.NewKeeper.Save(specialist, saveCorrector:false);
		                }
		                //
		                
	                }
				}


				var res =  _initialDocumentArray.Where(i => i.PersonnelCategory != PersonnelCategory.UNK).ToArray();
				_initialDocumentArray.Clear();
				_initialDocumentArray.AddRange(res);
			}

			foreach (var specialist in _initialDocumentArray)
			{
				foreach (var training in specialist.SpecialistTrainings)
				{
					if (training.AircraftTypeID > 0)
						training.AircraftType = aircraftModels.FirstOrDefault(a => a.ItemId == training.AircraftTypeID);
				}
				foreach (var license in specialist.Licenses)
				{
					if (license.AircraftTypeID > 0)
						license.AircraftType = aircraftModels.FirstOrDefault(a => a.ItemId == license.AircraftTypeID);
				}
			}

			AnimatedThreadWorker.ReportProgress(40, "filter directives");

			AnimatedThreadWorker.ReportProgress(70, "filter directives");

			FilterItems(_initialDocumentArray, _resultDocumentArray);

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}
		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_toolStripMenuItemOpen = new RadMenuItem();
			_toolStripMenuItemStatus = new RadMenuItem();
			_toolStripMenuItemHighlight = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemOpen.Text = "Open";
			_toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemStatus.Text = "License Status";
			_toolStripMenuItemStatus.Items.Clear();

			foreach (var status in OperatorStatus.Items)	
			{
				RadMenuItem item = new RadMenuItem(status.FullName);
				item.Click += ChangeStatus;
				item.Tag = status;
				_toolStripMenuItemStatus.Items.Add(item);
			}
			// 
			// toolStripMenuItemHighlight
			// 
			_toolStripMenuItemHighlight.Text = "Highlight";
			
			_toolStripMenuItemHighlight.Items.Clear();

			foreach (Highlight highlight in Highlight.HighlightList)
			{
				if (highlight == Highlight.Blue || highlight == Highlight.Yellow || highlight == Highlight.Red)
					continue;
				RadMenuItem item = new RadMenuItem(highlight.FullName);
				item.Click += HighlightItemClick;
				item.Tag = highlight;
				_toolStripMenuItemHighlight.Items.Add(item);
			}
		}

		private void ChangeStatus(object sender, EventArgs e)
		{
			var status = (OperatorStatus)((RadMenuItem)sender).Tag;
			foreach (var item in _directivesViewer.SelectedItems)
			{
				item.Settings.StatusId = status.ItemId;
				if(GlobalObjects.CasEnvironment != null)
					GlobalObjects.CasEnvironment.NewKeeper.Save(item);
				else GlobalObjects.CaaEnvironment.NewKeeper.Save(item);
			}
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion


		#region private void HighlightItemClick(object sender, EventArgs e)

		private void HighlightItemClick(object sender, EventArgs e)
		{
			for (int i = 0; i < _directivesViewer.SelectedItems.Count; i++)
			{
				Highlight highLight = (Highlight)((RadMenuItem)sender).Tag;
				foreach (GridViewCellInfo cell in _directivesViewer.radGridView1.SelectedRows[i].Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.BackColor = Color.FromArgb(highLight.Color);
				}
			}
		}

		#endregion

		#region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

		private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
		{
            ReferenceEventArgs refE = new ReferenceEventArgs
            {
                TypeOfReflection = ReflectionTypes.DisplayInNew,
                DisplayerText = "Employee",
                RequestedEntity = new CAAEmployeeScreen(_directivesViewer.SelectedItem, _operatorId)
            };
            InvokeDisplayerRequested(refE);
		}

		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null ||
				_directivesViewer.SelectedItems.Count == 0) return;

			string typeName = nameof(Specialist);

			DialogResult confirmResult =
				MessageBox.Show(_directivesViewer.SelectedItems.Count == 1
						? "Do you really want to delete " + typeName + " " + _directivesViewer.SelectedItems[0] + "?"
						: "Do you really want to delete selected " + typeName + "s?", "Confirm delete operation",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				_directivesViewer.radGridView1.BeginUpdate();
				GlobalObjects.NewKeeper.Delete(_directivesViewer.SelectedItems.OfType<BaseEntityObject>().ToList(), true);
				_directivesViewer.radGridView1.EndUpdate();
				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			if(_licenseView)
				_directivesViewer = new CAAPersonneLicenselListView(){OperatorId = _operatorId};
			else _directivesViewer = new CAAPersonnelListView(){OperatorId = _operatorId};
			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems(_toolStripMenuItemOpen,
				_toolStripSeparator1,
				_toolStripMenuItemHighlight,
				_toolStripMenuItemStatus);

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
				if (_directivesViewer.SelectedItems.Count == 1)
				{


					_toolStripMenuItemStatus.Enabled = GlobalObjects.CaaEnvironment.IdentityUser.CAAUserType == CAAUserType.CAAAdmin;
					_toolStripMenuItemOpen.Enabled = true;
				}
			};


			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

		private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			headerControl.EditButtonEnabled = _directivesViewer.SelectedItems.Count > 0;
		}

		#endregion

		#region private void UpdateInformation()
		/// <summary>
		/// Происзодит обновление отображения элементов
		/// </summary>
		private void UpdateInformation()
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.DisplayerText = "New Employee";
			var newSpec = new Specialist {Status = SpecialistStatus.Unknown, Position = SpecialistPosition.Unknown, Education = Education.UNK, Citizenship = Citizenship.UNK, IsCAA = _operatorId == -1};
			e.RequestedEntity = new CAAEmployeeScreen(newSpec, _operatorId);
		}

		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filter, _initialDocumentArray);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void FilterItems(IEnumerable<Specialist> initialCollection, ICommonCollection<Specialist> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<Specialist> initialCollection, ICommonCollection<Specialist> resultCollection)
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

		#endregion
	}
}
