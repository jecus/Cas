using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UICAAControls.CAAEducation.CoursePackage;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.CAA.CAAEducation;
using SmartCore.CAA.CAAWP;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Personnel;
using SmartCore.Filters;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using Filter = Entity.Abstractions.Filters.Filter;

namespace CAS.UI.UICAAControls.CAAEducation
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class EducationManagmentListScreen : ScreenControl
	{
		private readonly Operator _currentOperator;
		private readonly int _operatorId;

        #region Fields
        private CommonCollection<SmartCore.CAA.CAAWP.CoursePackage> _openPubWorkPackages = new CommonCollection<SmartCore.CAA.CAAWP.CoursePackage>();
		private CommonCollection<CAAEducationManagment> _initialDocumentArray = new CommonCollection<CAAEducationManagment>();
		private CommonCollection<CAAEducationManagment> _resultDocumentArray = new CommonCollection<CAAEducationManagment>();
		private CommonFilterCollection _filter;

		private EducationManagmentListView _directivesViewer;

		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuSeparatorItem _toolStripSeparator1;
		private RadMenuItem _toolStripMenuItemComposeWorkPackage;
		private RadMenuItem _toolStripMenuItemsWorkPackages;
		private RadMenuItem _toolStripMenuItemsWShowWP;
		private DateTime? _toDate;
		private string _schedule;

		#endregion


		#region Constructors

		#region public RoutineAuditListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public EducationManagmentListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public RoutineAuditListScreen(Operator currentOperator)

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentOperator">ВС, которому принадлежат директивы</param>>
		public EducationManagmentListScreen(Operator currentOperator, int operatorId)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			_currentOperator = currentOperator;
			_operatorId = operatorId;
            aircraftHeaderControl1.Operator = currentOperator;
            statusControl.ShowStatus = false;
			labelTitle.Visible = false;

			_filter = new CommonFilterCollection(typeof(ICAAEducationManagmentFilter));

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
			
			
			if (_toolStripMenuItemsWorkPackages != null)
			{
				foreach (var item in _toolStripMenuItemsWorkPackages.Items)
					item.Click -= AddToWorkPackageItemClick;
				_toolStripMenuItemsWorkPackages.Items.Clear();

				foreach (var workPackage in _openPubWorkPackages)
				{
					var item = new RadMenuItem($"{workPackage.Title}");
					item.Click += AddToWorkPackageItemClick;
					item.Tag = workPackage;
					_toolStripMenuItemsWorkPackages.Items.Add(item);
				}
			}

			if (_toDate.HasValue)
			{
				labelTitle.Visible = true;
				labelTitle.Text = $"Schedule Period : {_schedule}";
			}
			else
			{
				labelTitle.Visible = false;
			}
			

			_toolStripMenuItemComposeWorkPackage.Visibility = 
					_toolStripMenuItemsWorkPackages.Visibility =
						_toolStripMenuItemsWShowWP.Visibility  = _toDate.HasValue ? ElementVisibility.Collapsed : ElementVisibility.Visible;

		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			var temp = new CommonCollection<CAAEducationManagment>();
			_initialDocumentArray.Clear();
			_resultDocumentArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load directives");

			var specialists = new List<Specialist>();
			var educations = new List<SmartCore.CAA.CAAEducation.CAAEducation>();
			var records = new List<CAAEducationRecord>();

			var occupation = new List<Occupation>();
			if(OperatorId == -1)
				occupation = GlobalObjects.CaaEnvironment?.GetDictionary<Occupation>().ToArray().Cast<Occupation>().ToList();
			else occupation = GlobalObjects.CaaEnvironment?.GetDictionary<Occupation>().ToArray().Cast<Occupation>().Where(i => i.OperatorId == OperatorId).ToList();
			educations.AddRange(GlobalObjects.CaaEnvironment.NewLoader
					.GetObjectListAll<EducationDTO, SmartCore.CAA.CAAEducation.CAAEducation>(new Filter("OperatorId", _operatorId),loadChild:true));
				specialists.AddRange(GlobalObjects.CaaEnvironment.NewLoader
					.GetObjectListAll<CAASpecialistDTO, Specialist>(new Filter("OperatorId", _operatorId)));
				records.AddRange(GlobalObjects.CaaEnvironment.NewLoader
					.GetObjectListAll<EducationRecordsDTO, CAAEducationRecord>(new Filter("OperatorId", _operatorId)));
			

			foreach (var specialist in specialists)
			{
				FillCollection(educations, specialist.Occupation, specialist,records, false);
				
				if(string.IsNullOrEmpty(specialist.Combination))
					continue;
				
				var comb = new List<string>();
				if (specialist.Combination.Contains(","))
					comb = specialist.Combination.Split(',').ToList();
				else comb.Add(specialist.Combination);
				
				foreach (Occupation dict in occupation.Where(i => !i.FullName.Equals(specialist.Occupation.FullName) && comb.Contains(i.FullName) ))
				{
					if(dict.OperatorId == specialist.OperatorId)
						FillCollection(educations, dict, specialist,records);
				}
			}
			
			
			AnimatedThreadWorker.ReportProgress(40, "filter directives");

			
			if(_openPubWorkPackages == null)
				_openPubWorkPackages = new CommonCollection<SmartCore.CAA.CAAWP.CoursePackage>();
			
			_openPubWorkPackages.Clear();
			
			if (_operatorId == -1)
			{
				_openPubWorkPackages.AddRange(GlobalObjects.CaaEnvironment.NewLoader
					.GetObjectListAll<CoursePackageDTO, SmartCore.CAA.CAAWP.CoursePackage>(new List<Filter>()
					{
						new Filter("Status", 0)
					}));
			}
			else
			{
				_openPubWorkPackages.AddRange(GlobalObjects.CaaEnvironment.NewLoader
					.GetObjectListAll<CoursePackageDTO, SmartCore.CAA.CAAWP.CoursePackage>(
						new List<Filter>()
						{
							new Filter("Status", 0),
							new Filter("OperatorId", _operatorId)
						}
					));
			}
			
			

			if (_toDate.HasValue)
			{
				temp.AddRange(_initialDocumentArray.ToArray());
				_initialDocumentArray.Clear();
				

				foreach (var t in temp)
				{
					if (t.Record.Settings.NextCompliances != null && t.Record.Settings.NextCompliances.Any())
					{
						foreach (var next in t.Record.Settings.NextCompliances)
						{
							var newItem = t.DeepClone();
							newItem.Record.Settings.NextCompliance = next;
							_initialDocumentArray.Add(newItem);
						}
					}
					else
					{
						var newItem = t.DeepClone();
						newItem.Record.Settings.NextCompliance = new NextCompliance();
						_initialDocumentArray.Add(t);
					}
				}
			}
			
			
			FilterItems(_initialDocumentArray, _resultDocumentArray);

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}


		private void FillCollection(List<SmartCore.CAA.CAAEducation.CAAEducation> education,
			Occupation occupation,
			Specialist specialist, List<CAAEducationRecord> records, bool isCombination = true)
		{
			var educations = education.Where(i => i.OccupationId == occupation.ItemId);
			if (educations.Any())
			{
				foreach (var ed in educations)
				{
					var rec = records.FirstOrDefault(i => i.OccupationId == occupation.ItemId 
					                                    && i.EducationId == ed.ItemId
					                                    && i.PriorityId == ed.Priority.ItemId && i.SpecialistId == specialist.ItemId);

					
					if(rec != null)
						rec.Education = ed;
					
					EducationCalculator.CalculateEducation(rec, _toDate);
					var item = new CAAEducationManagment()
					{
						Specialist = specialist,
						Occupation = occupation,
						Education = ed,
						IsCombination = isCombination,
						Record = rec
					};
					_initialDocumentArray.Add(item);
				}
			}
			else
			{
				var item = new CAAEducationManagment()
				{
					Specialist = specialist,
					Occupation = occupation,
					IsCombination = isCombination
				};
				_initialDocumentArray.Add(item);
			}
		}
		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_toolStripMenuItemOpen = new RadMenuItem();
			_toolStripMenuItemComposeWorkPackage = new RadMenuItem();
			_toolStripMenuItemsWorkPackages = new RadMenuItem();
			_toolStripMenuItemsWShowWP = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
            // 
            // toolStripMenuItemView
            // 
            _toolStripMenuItemOpen.Text = "Open";
            _toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
            //
            // toolStripMenuItemComposeWorkPackage
            //
            _toolStripMenuItemComposeWorkPackage.Text = "Compose a Course package";
            _toolStripMenuItemComposeWorkPackage.Click += ButtonCreateWorkPakageClick;
            //
            // _toolStripMenuItemsWorkPackages
            //
            _toolStripMenuItemsWorkPackages.Text = "Add to Course package";
            //
            // _toolStripMenuItemsWShowWP
            //
            _toolStripMenuItemsWShowWP.Text = "Show Title";
            _toolStripMenuItemsWShowWP.Click += _toolStripMenuItemsWShowWP_Click; ;
		}
		

        #endregion


        private void AddToWorkPackageItemClick(object sender, EventArgs e)
        {
	        if (_directivesViewer.SelectedItems.Count <= 0) return;
	        
	        var wp = (SmartCore.CAA.CAAWP.CoursePackage)((RadMenuItem)sender).Tag;
	        var items = _directivesViewer.SelectedItems;

	        var first = items.FirstOrDefault();
	        if(!items.All(i => i.Education?.Task.ItemId == first.Education?.TaskId))
	        {
		        MessageBox.Show("Not all educations has equality Task!", (string)new GlobalTermsProvider()["SystemName"],
			        MessageBoxButtons.OK, MessageBoxIcon.Error);
		        return;
	        }

	        if (!wp.Settings.TaskId.HasValue)
	        {
		        wp.Settings.TaskId = first.Education.TaskId;
		        GlobalObjects.NewKeeper.Save(wp);
	        }
	        
	        // if (!items.All(i => i.Education?.TaskId == wp.Settings.TaskId))
	        // {
		       //  MessageBox.Show("Not all educations has equality Task!", (string)new GlobalTermsProvider()["SystemName"],
			      //   MessageBoxButtons.OK, MessageBoxIcon.Error);
		       //  return;
	        // }
	        
	        foreach (var item in items)
	        {
		        if (item.Record == null)
		        {
			        item.Record = new CAAEducationRecord()
			        {
				        EducationId = item.Education.ItemId,
				        OccupationId = item.Occupation.ItemId,
				        SpecialistId = item.Specialist.ItemId,
				        OperatorId = item.Specialist.OperatorId,
				        PriorityId = item.Education.Priority.ItemId,
				        Settings = new CAAEducationRecordSettings()
				        {
					        IsCombination = item.IsCombination,
					        BlockedWpId = wp.ItemId
				        }
			        };
		        }
		        else item.Record.Settings.BlockedWpId = wp.ItemId;
		        
		        GlobalObjects.NewKeeper.Save(item.Record);
		        GlobalObjects.NewKeeper.Save(new CourseRecord()
		        {
			        ObjectId = item.Record.ItemId,
			        WorkPackageId = wp.ItemId,
			        SpecialistId =  item.Specialist.ItemId,
			        Parent = item,
		        });
			        
	        }
		        
	        _directivesViewer.UpdateItemColor();
		        
		        
	        //Добавление нового рабочего пакета в коллекцию открытых рабочих пакетов
	        _openPubWorkPackages.Add(wp);
	        //Создание пункта в меню открытых рабочих пакетов
	        var raditem = new RadMenuItem(wp.Title);
	        raditem.Click += AddToWorkPackageItemClick;
	        raditem.Tag = wp;
	        _toolStripMenuItemsWorkPackages.Items.Add(raditem);


	        if (MessageBox.Show("Items added successfully. Open work package?", (string)new GlobalTermsProvider()["SystemName"],
		            MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
	            == DialogResult.Yes)
	        {
		        var refE = new ReferenceEventArgs();
		        refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
		        refE.DisplayerText =$"WP:{wp.Title}";
		        refE.RequestedEntity = new CourseRecordListScreen(CurrentOperator, wp);
		        InvokeDisplayerRequested(refE);
	        }
	       
        }
        
        private void _toolStripMenuItemsWShowWP_Click(object sender, EventArgs e)
        {
	        if (_directivesViewer.SelectedItems.Count <= 0) return;

	        if(_directivesViewer.SelectedItem.Record?.Settings.BlockedWpId == null)
		        return;


	        var wp = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<CoursePackageDTO, SmartCore.CAA.CAAWP.CoursePackage>(_directivesViewer.SelectedItem.Record.Settings.BlockedWpId.Value);
	        
	        var res = $"{wp.Title} - {wp.Settings.Number}";
	        MessageBox.Show(res, "",
		        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void ButtonCreateWorkPakageClick(object sender, EventArgs e)
        {
	        if (_directivesViewer.SelectedItems.Count <= 0) return;

	        var items = _directivesViewer.SelectedItems;

	        var first = items.FirstOrDefault();
	        if (!items.All(i => i.Education?.Task.ItemId == first.Education?.Task.ItemId))
	        {
		        MessageBox.Show("Not all educations has equality Task!", (string)new GlobalTermsProvider()["SystemName"],
			        MessageBoxButtons.OK, MessageBoxIcon.Error);
		        return;
	        }

	        if (MessageBox.Show("Create and save a Work Package?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
	        {
		        var wp = new SmartCore.CAA.CAAWP.CoursePackage();
		        wp.OperatorId = _operatorId;
		        wp.Settings.OpeningDate = DateTime.Now;
		        wp.Settings.CreateDate = DateTime.Now;
		        wp.Settings.Author = GlobalObjects.CaaEnvironment.IdentityUser.ItemId;
		        wp.Settings.Number = $"{GlobalObjects.CaaEnvironment.ObtainId()}";
		        wp.Settings.TaskId = first.Education?.Task.ItemId;
		        wp.Title = $"{first.Education?.Task.FullName} - {DateTime.Now:d}";
		        
		        GlobalObjects.NewKeeper.Save(wp);
		        
		        foreach (var item in items)
		        {
			        if (item.Record == null)
			        {
				        item.Record = new CAAEducationRecord()
				        {
					        EducationId = item.Education.ItemId,
					        OccupationId = item.Occupation.ItemId,
					        SpecialistId = item.Specialist.ItemId,
					        OperatorId = item.Specialist.OperatorId,
					        PriorityId = item.Education.Priority.ItemId,
					        Settings = new CAAEducationRecordSettings()
					        {
						        IsCombination = item.IsCombination,
						        BlockedWpId = wp.ItemId
					        }
				        };
			        }
			        else item.Record.Settings.BlockedWpId = wp.ItemId;
			        
			        GlobalObjects.NewKeeper.Save(item.Record);
			        GlobalObjects.NewKeeper.Save(new CourseRecord()
			        {
				        ObjectId = item.Record.ItemId,
				        WorkPackageId = wp.ItemId,
				        SpecialistId =  item.Specialist.ItemId,
				        Parent = item,
			        });
			        
		        }
		        
		        _directivesViewer.UpdateItemColor();
		        
		        
		        //Добавление нового рабочего пакета в коллекцию открытых рабочих пакетов
		        _openPubWorkPackages.Add(wp);
		        //Создание пункта в меню открытых рабочих пакетов
		        var raditem = new RadMenuItem(wp.Title);
		        raditem.Click += AddToWorkPackageItemClick;
		        raditem.Tag = wp;
		        _toolStripMenuItemsWorkPackages.Items.Add(raditem);


		        if (MessageBox.Show("Items added successfully. Open work package?", (string)new GlobalTermsProvider()["SystemName"],
			            MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
		            == DialogResult.Yes)
		        {
			        var refE = new ReferenceEventArgs();
			        refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
			        refE.DisplayerText =$"WP:{wp.Title}";
			        refE.RequestedEntity = new CourseRecordListScreen(CurrentOperator, wp);
			        InvokeDisplayerRequested(refE);
		        }
	        }
        }

        private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
        {
	        if (_directivesViewer.SelectedItem.Occupation != null && _directivesViewer.SelectedItem.Education != null)
	        {
		        var refE = new ReferenceEventArgs();
		        refE.TypeOfReflection = ReflectionTypes.DisplayInNew;
		        refE.DisplayerText =_directivesViewer.SelectedItem.Education?.Task?.FullName;
		        refE.RequestedEntity = new EducationScreen(CurrentOperator, _directivesViewer.SelectedItem);
		        InvokeDisplayerRequested(refE);
	        }
        }
        

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
            _directivesViewer.ButtonDeleteClick(sender, e);
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new EducationManagmentListView(AnimatedThreadWorker);
			_directivesViewer.OperatorId = _operatorId;
			_directivesViewer.CurrentOperator = _currentOperator;
			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems(_toolStripMenuItemOpen,
				_toolStripSeparator1,
				_toolStripMenuItemComposeWorkPackage,
				_toolStripMenuItemsWorkPackages,
				_toolStripMenuItemsWShowWP
				);
			
			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
				if (_directivesViewer.SelectedItems.Count == 1)
				{
					_toolStripMenuItemsWShowWP.Enabled = _directivesViewer.SelectedItem?.Record?.Settings?.BlockedWpId!= null;
					_toolStripMenuItemOpen.Enabled = true;
				}
			};
			
			_directivesViewer.DisableDeleteContext();
			_directivesViewer.DisableCopyPaste();


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
		private void FilterItems(IEnumerable<CAAEducationManagment> initialCollection, ICommonCollection<CAAEducationManagment> resultCollection)
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

		private void Radio_ByNameOnCheckedChanged(object sender, EventArgs e)
		{
			if(_directivesViewer == null)
				return;
			
			if (radio_ByName.Checked)
			{
				_directivesViewer.radGridView1.GroupDescriptors.Clear();
				var descriptor = new GroupDescriptor();
				foreach (var colName in new List<string>{ "Last Name", "First Name"  })
					descriptor.GroupNames.Add(colName,  ListSortDirection.Ascending);
				_directivesViewer.radGridView1.GroupDescriptors.Add(descriptor);
			}
			else if (radio_Non.Checked)
			{
				_directivesViewer.radGridView1.GroupDescriptors.Clear();
			}
			else
			{
				_directivesViewer.radGridView1.GroupDescriptors.Clear();
				var descriptor = new GroupDescriptor();
				foreach (var colName in new List<string>{ "Code", "CodeName", "SubTaskCode","SubTaskName","Description","Level" })
					descriptor.GroupNames.Add(colName,  ListSortDirection.Ascending);
				_directivesViewer.radGridView1.GroupDescriptors.Add(descriptor);
			}
		}

		private void ForecastMenuClick(object sender, EventArgs e)
		{
			_toDate = DateTime.Now;
			_schedule = (string)sender;
			switch ((string)sender)
			{
				case "1 Month":
					_toDate = _toDate.Value.AddMonths(1);
					break;
				case "3 Month":
					_toDate = _toDate.Value.AddMonths(3);
					break;
				case "6 Month":
					_toDate = _toDate.Value.AddMonths(6);
					break;
				case "1 Year":
					_toDate = _toDate.Value.AddYears(1);
					break;
				case "2 Year":
					_toDate = _toDate.Value.AddYears(2);
					break;
				case "3 Year":
					_toDate = _toDate.Value.AddYears(3);
					break;
				case "4 Year":
					_toDate = _toDate.Value.AddYears(4);
					break;
				case "5 Year":
					_toDate = _toDate.Value.AddYears(5);
					break;
				case "None":
					_toDate = null;
					break;
			}

			AnimatedThreadWorker.RunWorkerAsync();
		}
	}
}
