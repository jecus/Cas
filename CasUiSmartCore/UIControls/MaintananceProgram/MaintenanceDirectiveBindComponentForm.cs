using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Relation;
using Component = SmartCore.Entities.General.Accessory.Component;
using ComponentCollection = SmartCore.Entities.Collections.ComponentCollection;

namespace CAS.UI.UIControls.MaintananceProgram
{
    /// <summary>
    /// ����� ��� �������� ������� �� � ������� ���� ������
    /// </summary>
    public partial class MaintenanceDirectiveBindComponentForm : MetroForm
    {

        #region Fields

        private CommonCollection<BaseEntityObject> _bindedItems = new CommonCollection<BaseEntityObject>();
        private CommonCollection<BaseEntityObject> _itemsForSelect = new CommonCollection<BaseEntityObject>();

		private Dictionary<Component, List<ComponentDirective>> _newBindedItems = new Dictionary<Component, List<ComponentDirective>>();
		private List<ComponentDirective> _bindedItemsToRemove = new List<ComponentDirective>();
	    private WorkItemsRelationTypeUI _selectedRelationTypeUI;

        private readonly MaintenanceDirective _maintenanceDirective;
        private readonly Aircraft _currentAircraft;

        private readonly AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

        #endregion

        #region Constructors

        #region private MaintenanceDirectiveBindDetailForm()

        /// <summary>
        /// ������� ����� ��� �������� ������� �� � ������� ���� ������
        /// </summary>
        private MaintenanceDirectiveBindComponentForm()
        {
            InitializeComponent();
        }

        #endregion

        #region public MaintenanceDirectiveBindDetailForm(MaintenanceCheck maintenanceCheck) : this()

        /// <summary>
        /// ������� ����� ��� �������� ����� � ���������� ���� ��������� ������������
        /// </summary>
        public MaintenanceDirectiveBindComponentForm(MaintenanceDirective maintenanceDirective)
            : this()
        {
            if(maintenanceDirective == null)
                throw new ArgumentNullException("maintenanceDirective", "must be not null");
            _maintenanceDirective = maintenanceDirective;
            _currentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(maintenanceDirective.ParentBaseComponent.ParentAircraftId);

			_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
        }

        #endregion

        #endregion

        #region Properties

        #endregion

        #region Methods

        #region private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listViewTasksForSelect.SetItemsArray(_itemsForSelect.ToArray());
            listViewBindedTasks.SetItemsArray(_bindedItems.ToArray());

			comboBoxRelationType.DisplayMember = "Key";
			comboBoxRelationType.ValueMember = "Value";
			comboBoxRelationType.DataSource = EnumHelper.GetDisplayValueMemberDict<WorkItemsRelationTypeUI>();

			comboBoxRelationType.SelectedIndexChanged -= ComboBoxRelationType_SelectedIndexChanged;

			_selectedRelationTypeUI = _maintenanceDirective.ItemRelations.Count == 0 
				? WorkItemsRelationTypeUI.ThisItemAffectOnAnother 
				: ItemRelationHelper.ConvertBLItemRelationToUIITem(_maintenanceDirective.WorkItemsRelationType, _maintenanceDirective.IsFirst.HasValue && _maintenanceDirective.IsFirst.Value);

	        comboBoxRelationType.SelectedValue = _selectedRelationTypeUI;

			comboBoxRelationType.SelectedIndexChanged += ComboBoxRelationType_SelectedIndexChanged;
		}
        #endregion

        #region private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            if (_maintenanceDirective == null || _currentAircraft == null)
            {
                e.Cancel = true;
                return;
            }

            if (_bindedItems == null)
                _bindedItems = new CommonCollection<BaseEntityObject>();
            _bindedItems.Clear();

            if (_itemsForSelect == null)
                _itemsForSelect = new CommonCollection<BaseEntityObject>();
            _itemsForSelect.Clear();

            _animatedThreadWorker.ReportProgress(0, "load binded tasks");

            ComponentCollection dc = null;
            try
            {
                dc = GlobalObjects.ComponentCore.GetComponents(_currentAircraft.ItemId);
				

				var baseComp = GlobalObjects.ComponentCore.GetAicraftBaseComponents(_currentAircraft.ItemId);
				var directivesIds = baseComp.SelectMany(i => i.ComponentDirectives).Select(d => d.ItemId);
				var itemsRelations = GlobalObjects.ItemsRelationsDataAccess.GetRelations(directivesIds,
					SmartCoreType.ComponentDirective.ItemId);

				if (itemsRelations.Count > 0)
				{
					foreach (var directive in baseComp.SelectMany(i => i.ComponentDirectives))
					{
						directive.ItemRelations.Clear();
						directive.ItemRelations.AddRange(itemsRelations.Where(i =>
							i.FirstItemId == directive.ItemId ||
							i.SecondItemId ==
							directive.ItemId)); //TODO:(Evgenii Babak)�� ������������ Where 
					}
				}

				dc.AddRange(baseComp);
				//����������� ������ ����������� ����� � �����������

				List<ComponentDirective> bindedDirectives = 
                    dc.SelectMany(d => d.ComponentDirectives.Where(dd => dd.ItemRelations.IsAnyRelationWith(_maintenanceDirective)))
					  .ToList();

                List<Component> bindedComponents =
                    bindedDirectives.Where(dd => dd.ParentComponent != null)
                                    .Select(dd => dd.ParentComponent)
                                    .Distinct()
                                    .ToList();

                _bindedItems.AddRange(bindedDirectives.ToArray());
                _bindedItems.AddRange(bindedComponents.ToArray());

				//����������� ������ ������������� ����� � �����������

				List<ComponentDirective> directivesForSelect =
					dc.SelectMany(d => d.ComponentDirectives.Where(dd => dd.ItemRelations.Count == 0 || !dd.ItemRelations.IsAllRelationWith(_maintenanceDirective)))
					  .ToList();

                List<Component> componentsForSelect = dc.ToList();

                _itemsForSelect.AddRange(directivesForSelect.ToArray());
                _itemsForSelect.AddRange(componentsForSelect.ToArray());
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while load Maintenance directive bing details records", ex);
            }

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            _animatedThreadWorker.ReportProgress(50, "calculation of Components");

            if(dc != null)
            {
                foreach (var component in dc)
                {
                    GlobalObjects.PerformanceCalculator.GetNextPerformance(component);
                    foreach (var dd in component.ComponentDirectives)
                    {
                        GlobalObjects.PerformanceCalculator.GetNextPerformance(dd);
                    }
                }
   
                dc.Clear();
            }

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            _animatedThreadWorker.ReportProgress(75, "calculate directives for select");

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
		
			_animatedThreadWorker.ReportProgress(100, "binding complete");
        }
		#endregion

		#region private void ButtonCloseClick(object sender, EventArgs e)

		private void ButtonCloseClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

		#endregion

		#region private void ButtonAddClick(object sender, EventArgs e)

		private void ButtonAddClick(object sender, EventArgs e)
		{
			if (listViewTasksForSelect.SelectedItems.Count == 0)
				return;

			if (_maintenanceDirective.IsFirst == null)
			{
				_maintenanceDirective.NormalizeItemRelations();
				comboBoxRelationType.SelectedValue = ItemRelationHelper.ConvertBLItemRelationToUIITem(_maintenanceDirective.WorkItemsRelationType, false);
			}

			//��������� ��������� ������� ����� �������� � ������, ���������� ��� ������� ������
			var itemsToInsert = new CommonCollection<BaseEntityObject>();
			//������ ��������� ����� �� ����������� ��� ��������
			var selectedDirectives = listViewTasksForSelect.SelectedItems.OfType<ComponentDirective>().ToList();
			//��������� ��������� ����������� ��� ��������
			var selectedComponents = new ComponentCollection(listViewTasksForSelect.SelectedItems.OfType<Component>());

			if(selectedComponents.Count == 0 && selectedDirectives.Count == 0)
				return;
			//������ ��� ����������� ����� �� ����������
			var bindedDirectives = listViewBindedTasks.SelectedItems.OfType<ComponentDirective>().ToList();
			//������������ ������ ��������� � ����������� �����������
			var concatenatedDirectives = selectedDirectives.Concat(bindedDirectives);
			foreach (ComponentDirective dd in concatenatedDirectives)
			{
				if (concatenatedDirectives.Count(d => d.ComponentId == dd.ComponentId) > 1)
				{
					//��������, �� ������� �� 2 ��� ����� ����� �� ������ ���������� ��� ��������
					//�.�. MPD Item ����� ���� �������� ������ � ����� ������ ������� ���������� ����������
					string parentComponent;
					if (dd.ParentComponent != null)
						parentComponent = dd.ParentComponent.SerialNumber;
					else parentComponent = "Component ID: " + dd.ComponentId;

					MessageBox.Show("the MPD Item can not be bound to two or more tasks of a one component:" +
									"\n" + parentComponent,
									(string)new GlobalTermsProvider()["SystemName"],
									MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}

				try
				{
					var singleItemRelation = dd.ItemRelations.SingleOrDefault();
					if (singleItemRelation != null &&
						!CheckThatItemHaveRelationsOnlyWithProvidedItem(dd.IsFirst.HasValue && dd.IsFirst.Value,
																		singleItemRelation, _maintenanceDirective.ItemId,
																		SmartCoreType.MaintenanceDirective.ItemId))
					{
						//�������� �� ����� �� ��������� ������ �� ���������� �������� � ������ ������ 
						string parentComponent;
						if (dd.ParentComponent != null)
							parentComponent = dd.ParentComponent.SerialNumber;
						else parentComponent = "Component ID: " + dd.ComponentId;

						MessageBox.Show("You can not select a task: " +
										"\n" + parentComponent + " " + dd.DirectiveType +
										"\n" + "because task already has a binding",
							(string) new GlobalTermsProvider()["SystemName"],
							MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
				}
				catch (InvalidOperationException)
				{
					ItemRelationHelper.ShowDialogIfItemLinksCountMoreThanOne($"Component {dd.PartNumber}", dd.ItemRelations.Count);
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log(ex);
				}
			}
			//�������� �� ��������� ��������� ����������� ��� �����������, 
			//������ �� ������� ���������� � ��������� selectedDirectives
			foreach (ComponentDirective directive in selectedDirectives)
				selectedComponents.RemoveById(directive.ComponentId);
			//������������ �������� ��������� ����� �� ����������� � ���������� ������� MPD
			foreach (ComponentDirective dd in selectedDirectives.Where(d => d.ItemRelations.Count == 0))
			{
				try
				{
					//TODO:(Evgenii Babak) ��������� ������������� �������
					dd.MPDTaskType = _maintenanceDirective.WorkType;
					dd.FaaFormFile = _maintenanceDirective.TaskCardNumberFile;
					dd.FaaFormFileId = _maintenanceDirective.TaskCardNumberFile != null
											? _maintenanceDirective.TaskCardNumberFile.ItemId
											: -1;

					AddComponentAndDirectiveToBindedItemsCollections(dd.ParentComponent, dd, itemsToInsert, _bindedItems, _newBindedItems);
					//�������� ������ �� ���������� �� �������� ���������� ����������� ������ ���� �����  
					listViewTasksForSelect.RemoveItem(dd);
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while save bind task record", ex);
				}
			}

			//������������ �������� ��������� ����������� � ���������� ������� MPD
			//� ���������� ���������� ����������� � ��������� ��������� �����������
			//������ �������� ���������� � ������� ���� ��� �����, ���� �� ���� �� ���� �������
			foreach (Component selectedComponent in selectedComponents)
			{
				if(selectedComponent.ComponentDirectives.Count == 0)
				{
					//��������� ��������� �� ����� �����.
					//��� �������� ���������� ������� ������
					if(MessageBox.Show("Component:" +
									   "\n" + selectedComponent +
									   "\n" + "has no directives!" +
									   "\n" +
									   "\n" + "Create and save directive for this MPD Item?",
									   (string)new GlobalTermsProvider()["SystemName"],
									   MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
									   != DialogResult.Yes)
					{
						continue;
					}
				}
				else if (selectedComponent.ComponentDirectives.All(dd => dd.ItemRelations.Any(i => !CheckThatItemHaveRelationsOnlyWithProvidedItem(dd.IsFirst.HasValue && dd.IsFirst.Value,
																																				i,
																																				_maintenanceDirective.ItemId,
																																				SmartCoreType.MaintenanceDirective.ItemId))))

				{
					//��������� ��������� ����� ������
					//�� ��� ��� ��������� � ������ �������
					if (MessageBox.Show("Component:" +
									   "\n" + selectedComponent +
									   "\n" + "has directives, but they are bound to other tasks" +
									   "\n" +
									   "\n" + "Create and save directive for this MPD Item?",
									   (string)new GlobalTermsProvider()["SystemName"],
									   MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
									   != DialogResult.Yes)
					{
						continue;
					}
				}
				else if(selectedComponent.ComponentDirectives.Count > 0)
				{
					//��������� ��������� ����� ������
					//�� �� ���� �� ��� ����� �� ���� ������� ��� �������� 
					//���������� ������ ������: ������� �� ���� ������ ��� ��������
					//��� ������������ ������ ������� ������ ��� �������� ��� �� ��������� ����� �� ����������
					if(MessageBox.Show("Component:" +
									   "\n" + selectedComponent +
									   "\n" + "has a tasks, but none of them is selected for binding!" +
									   "\n" +
									   "\n" + "Create and save directive for this MPD Item, or You choose task to bind yourself" +
									   "\n" +
									   "\n" + "Yes - Create and Save directive" +
									   "\n" + "No - You choose task to bind yourself",
									   (string)new GlobalTermsProvider()["SystemName"],
									   MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
									   != DialogResult.Yes)
					{
						continue;
					}
				}

				try
				{
					var neComponentDirective = new ComponentDirective();

					neComponentDirective.DirectiveType = (ComponentRecordType)ComponentRecordType.Items.GetByShortName(_maintenanceDirective.WorkType.ShortName);

					neComponentDirective.ManHours = _maintenanceDirective.ManHours;
					neComponentDirective.Cost = _maintenanceDirective.Cost;
					neComponentDirective.Kits.Clear();
					neComponentDirective.Kits.AddRange(_maintenanceDirective.Kits.ToArray());
					neComponentDirective.Remarks = _maintenanceDirective.Remarks;
					neComponentDirective.HiddenRemarks = _maintenanceDirective.HiddenRemarks;
					neComponentDirective.MPDTaskType = _maintenanceDirective.WorkType;
					neComponentDirective.FaaFormFile = _maintenanceDirective.TaskCardNumberFile;
					neComponentDirective.FaaFormFileId = _maintenanceDirective.TaskCardNumberFile != null
														   ? _maintenanceDirective.TaskCardNumberFile.ItemId
														   : -1;
					neComponentDirective.ComponentId = selectedComponent.ItemId;
					neComponentDirective.ParentComponent = selectedComponent;

					MaintenanceDirectiveThreshold mdt = _maintenanceDirective.Threshold;
					ComponentDirectiveThreshold ddt = neComponentDirective.Threshold;

					ddt.FirstPerformanceSinceNew = mdt.FirstPerformanceSinceNew;
					ddt.FirstNotification = mdt.FirstNotification;
					ddt.RepeatInterval = mdt.RepeatInterval;
					ddt.RepeatNotification = mdt.RepeatNotification;
					ddt.FirstPerformanceConditionType = mdt.FirstPerformanceConditionType;


					AddComponentAndDirectiveToBindedItemsCollections(selectedComponent, neComponentDirective, itemsToInsert, _bindedItems, _newBindedItems);
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while save bind task record", ex);
				}
			}

			listViewBindedTasks.InsertItems(itemsToInsert);
		}
		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)

		private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (listViewBindedTasks.SelectedItems.Count == 0)
                return;

			//��������� ��������� ������� ����� �������� � �������� ���������� ���������� ������ ���� �����  
			var itemsToInsert = new CommonCollection<BaseEntityObject>();
			var detailDirectives = listViewBindedTasks.SelectedItems.OfType<ComponentDirective>().ToList();

            foreach (var selectedItem in detailDirectives)
            {
	            try
	            {
					//���� ������ �� ���������� ���� ��������� � �� , �� ��������� � ������ ��������� ���������
		            if (selectedItem.ItemId > 0)
		            {
						itemsToInsert.Add(selectedItem);
			            _bindedItemsToRemove.Add(selectedItem);
					}

					//�������� ������ �� ����������  �� ��������� ���������� ��� �������� ������
					_bindedItems.Remove(selectedItem);

					//�������� ������ ��  ���������� �� �������� ���������� ����������� ������ ���� ���������� �����  
					listViewBindedTasks.RemoveItem(selectedItem);

					//���� � ��������� ���������� ��� ������� ������ �� ���������� ����� �� ����������,
					//������� ����������� ���� �� ���������� ��� � ������� ������ 
					//��������� ������� ��������� �� ��������� ���������� ��� ������� ������
					if (_bindedItems.OfType<ComponentDirective>().All(x => x.ParentComponent.ItemId != selectedItem.ParentComponent.ItemId))
		            {
						_bindedItems.Remove(selectedItem.ParentComponent);
						//�������� ���������� �� �������� ���������� ����������� ������ ���� ���������� �����  
						listViewBindedTasks.RemoveItem(selectedItem.ParentComponent);
					}

					if (_newBindedItems.ContainsKey(selectedItem.ParentComponent))
		            {
						//�������� ������ �� ���������� �� ��������� ����� ����������� ����� �� ����������
						_newBindedItems[selectedItem.ParentComponent].Remove(selectedItem);
						//���� ����� ����� ����������� ����� �� ���������� �� ���������� ������ �� �����������,
						//������� ����������� ���� �� ���������� ��� � ������� ������ 
						//��������� ������� ��������� �� �������
						if (_newBindedItems[selectedItem.ParentComponent].Count == 0)
							_newBindedItems.Remove(selectedItem.ParentComponent);
					}
	            }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while delete bind task record", ex);
                }
			}

			listViewTasksForSelect.InsertItems(itemsToInsert);
		}
		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
	    {
		    if (GetChangeStatus())
		    {
			    try
			    {
					DialogResult = DialogResult.OK;
					Save();
					Close();
			    }
			    catch (Exception ex)
			    {
				    Program.Provider.Logger.Log("Error while saving data", ex);
			    }
		    }
	    }

	    #endregion

		#region private bool GetChangeStatus()

		private bool GetChangeStatus()
	    {
		    var selectedRelatioType = (WorkItemsRelationTypeUI) comboBoxRelationType.SelectedValue;
		    if (_selectedRelationTypeUI != selectedRelatioType || _newBindedItems.Count > 0 || _bindedItemsToRemove.Count > 0)
			    return true;

		    return false;
	    }

		#endregion

		#region private void Save()

		private void Save()
	    {
			var selectedRelationType = (WorkItemsRelationTypeUI)comboBoxRelationType.SelectedValue;
			var relationType = ItemRelationHelper.ConvertUIItemRelationToBLItem(selectedRelationType, _maintenanceDirective.IsFirst);

			//���������� ����� ��������� �����
			foreach (var newItem in _newBindedItems)
		    {
			    foreach (var detailDirective in newItem.Value)
			    {
				    if (detailDirective.ItemId <= 0)
				    {
					    var component = newItem.Key;
					    GlobalObjects.ComponentCore.AddComponentDirective(component, detailDirective);
					    AddDirectiveRecord(component, detailDirective);
				    }

				    var itemRelation = CreateItemRelation(detailDirective, selectedRelationType);
				    itemRelation.AdditionalInformation.Component = detailDirective.PartNumber;
				    itemRelation.AdditionalInformation.Mpd = _maintenanceDirective.TaskCardNumber;
					GlobalObjects.NewKeeper.Save(itemRelation);

					_maintenanceDirective.ItemRelations.Add(itemRelation);
				    detailDirective.ItemRelations.Add(itemRelation);
			    }
		    }

			//�������� ��������� �����
			var mpdItemRelations = new List<ItemsRelation>(_maintenanceDirective.ItemRelations);
		    foreach (var detailDirective in _bindedItemsToRemove)
		    {
			    var itemsRelationsToDelete = mpdItemRelations.GetRelationsWith(detailDirective);
			    foreach (var itemsRelationToDelete in itemsRelationsToDelete)
			    {
				    itemsRelationToDelete.IsDeleted = true;
				    itemsRelationToDelete.AdditionalInformation = null;
					GlobalObjects.NewKeeper.Delete(itemsRelationToDelete);

				    _maintenanceDirective.ItemRelations.Remove(itemsRelationToDelete);
				    detailDirective.ItemRelations.Remove(itemsRelationToDelete);
			    }
		    }

			//���� ItemsRelationTyp� �� Mpd �� ��������� � ��������� ItemsRelationTyp� � �������, ������������ ���������� ���� ItemRelation - ��
			if (_maintenanceDirective.WorkItemsRelationType != relationType)
			{
				SaveItemRelations(selectedRelationType, _maintenanceDirective);
			}
		}

		#endregion

		#region private void AddDirectiveRecord(Detail component, DetailDirective detailDirective)

		private void AddDirectiveRecord(Component component, ComponentDirective componentDirective)
	    {
		    // ���� � MPD Item ���� ������ � ����������,
		    //�� �� ����� ������ � ������ � ���������� ����� ������ �� ����������
		    if (_maintenanceDirective.LastPerformance != null)
		    {
			    //��������� ������ �� ��������� ��������
			    TransferRecord tr = component.TransferRecords.GetLast();
			    //���������� ������ ������ �� ������, ��� ����� ���� ��������� ����� ��������� ��������
			    var performanceRecords = _maintenanceDirective.PerformanceRecords.Where(dr => dr.RecordDate >= tr.TransferDate);

			    foreach (DirectiveRecord performanceRecord in performanceRecords)
			    {
				    var newPerformance = new DirectiveRecord(performanceRecord);
				    newPerformance.MaintenanceDirectiveRecordId = performanceRecord.ItemId;
				    newPerformance.OnLifelength =
					    GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(component, newPerformance.RecordDate);

				    GlobalObjects.PerformanceCore.RegisterPerformance(componentDirective, newPerformance, registerPerformanceForBindedItems : false);
			    }
		    }
	    }

		#endregion

		#region private void FillCollections(ICommonCollection<BaseEntityObject> itemsToInsert, Detail component, DetailDirective detailDirective)

		private void AddComponentAndDirectiveToBindedItemsCollections(Component component, ComponentDirective componentDirective,
																	  ICommonCollection<BaseEntityObject> itemsToInsert,
																	  ICommonCollection<BaseEntityObject> allbindedItems,
																	  Dictionary<Component, List<ComponentDirective>> newBindedItems)
	    {
		    itemsToInsert.Add(componentDirective);

			// ���������� ������ �� ���������� �� ��������� ���������� ��� �������� ������
			allbindedItems.Add(componentDirective);

		    //���� � ��������� ���������� ��� ������� ������ ��� ������������� ���������� �� ������ �� ���������� 
		    //��������� �������� ��������� � ��������� ���������� ��� ������� ������
		    if (allbindedItems.OfType<Component>().All(i => i.ItemId != component.ItemId))
		    {
			    itemsToInsert.Add(component);
				allbindedItems.Add(component);
		    }

		    if (newBindedItems.ContainsKey(component))
			    newBindedItems[component].Add(componentDirective);
		    else
			    newBindedItems.Add(component, new List<ComponentDirective> {componentDirective});
	    }

	    #endregion

		#region private void SaveItemRelations()

		private void SaveItemRelations(WorkItemsRelationTypeUI relationTypeUI, IBindedItem currentItem)
	    {
		    foreach (var itemRelation in currentItem.ItemRelations)
		    {
				itemRelation.RelationTypeId = ItemRelationHelper.ConvertUIItemRelationToBLItem(relationTypeUI, currentItem.IsFirst);
			    GlobalObjects.NewKeeper.Save(itemRelation);
		    }
	    }

		#endregion

		#region private ItemsRelation CreateItemRelation(DetailDirective dd)

		private ItemsRelation CreateItemRelation(ComponentDirective dd, WorkItemsRelationTypeUI relationTypeUI)
	    {
		    var itemRelation = new ItemsRelation();
			var relationType = ItemRelationHelper.ConvertUIItemRelationToBLItem(relationTypeUI, _maintenanceDirective.IsFirst);

			if (_maintenanceDirective.IsFirst == true)
			    itemRelation.FillParameters(_maintenanceDirective, dd, relationType);
		    else
			    itemRelation.FillParameters(dd, _maintenanceDirective, relationType);

		    return itemRelation;
	    }

	    #endregion

		#region private bool CheckThatItemHaveRelationsOnlyWithProvidedItem(bool checkedItemIsFirst, ItemsRelation itemRelationFromCheckedItem, int providedItemId, int providedItemTypeId)

		private bool CheckThatItemHaveRelationsOnlyWithProvidedItem(bool checkedItemIsFirst,
		    ItemsRelation itemRelationFromCheckedItem, int providedItemId, int providedItemTypeId)
	    {
		    if (checkedItemIsFirst)
		    {
			    if (itemRelationFromCheckedItem.SecondItemId != providedItemId ||
			        itemRelationFromCheckedItem.SecondItemTypeId != providedItemTypeId)
				    return false;
		    }
		    else
		    {
			    if (itemRelationFromCheckedItem.FirstItemId != providedItemId ||
			        itemRelationFromCheckedItem.FirtsItemTypeId != providedItemTypeId)
				    return false;
		    }
		    return true;
	    }

	    #endregion

        #region private void TemplateAircraftAddToDataBaseForm_Deactivate(object sender, EventArgs e)

        private void TemplateAircraftAddToDataBaseForm_Deactivate(object sender, EventArgs e)
        {
            StaticWaitFormProvider.WaitForm.Visible = false;
        }
        #endregion

        #region private void TemplateAircraftAddToDataBaseForm_Activated(object sender, EventArgs e)
        private void TemplateAircraftAddToDataBaseForm_Activated(object sender, EventArgs e)
        {
            if (StaticWaitFormProvider.IsActive)
                StaticWaitFormProvider.WaitForm.Visible = true;
        }
        #endregion

        #region private void MaintenanceCheckBindTaskFormLoad(object sender, EventArgs e)
        private void MaintenanceCheckBindTaskFormLoad(object sender, EventArgs e)
        {
            _animatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void ListViewSelectedTasksSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        
        private void ListViewSelectedTasksSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            buttonAdd.Enabled = listViewTasksForSelect.SelectedItems.Count > 0;
        }
        #endregion

        #region private void ListViewBindedTasksSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void ListViewBindedTasksSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            buttonDelete.Enabled = listViewBindedTasks.SelectedItems.Count > 0;
        }
		#endregion

		#region private void ComboBoxRelationType_SelectedIndexChanged(object sender, EventArgs e)

		private void ComboBoxRelationType_SelectedIndexChanged(object sender, EventArgs e)
	    {
		    var selectedItem = (WorkItemsRelationTypeUI) comboBoxRelationType.SelectedValue;
			if (selectedItem == WorkItemsRelationTypeUI.Incorrect)
			{
				comboBoxRelationType.SelectedIndex = 1;
			} 
	    }

		#endregion

		#endregion
	}

}