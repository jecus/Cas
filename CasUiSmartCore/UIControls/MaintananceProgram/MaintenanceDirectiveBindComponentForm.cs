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
    /// Форма для переноса шаблона ВС в рабочую базу данных
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
        /// Создает форму для переноса шаблона ВС в рабочую базу данных
        /// </summary>
        private MaintenanceDirectiveBindComponentForm()
        {
            InitializeComponent();
        }

        #endregion

        #region public MaintenanceDirectiveBindDetailForm(MaintenanceCheck maintenanceCheck) : this()

        /// <summary>
        /// Создает форму для привязки задач к выполнению чека программы обслуживания
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
							directive.ItemId)); //TODO:(Evgenii Babak)не использовать Where 
					}
				}

				dc.AddRange(baseComp);
				//Определение списка привязанных задач и компонентов

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

				//Определение списка непривязанных задач и компонентов

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

			//коллекция элементов которые нужно добавить в список, содержащий все связные задачи
			var itemsToInsert = new CommonCollection<BaseEntityObject>();
			//Список выбранных задач по компонентам для привязки
			var selectedDirectives = listViewTasksForSelect.SelectedItems.OfType<ComponentDirective>().ToList();
			//Коллекция выбранных компонентов для привязки
			var selectedComponents = new ComponentCollection(listViewTasksForSelect.SelectedItems.OfType<Component>());

			if(selectedComponents.Count == 0 && selectedDirectives.Count == 0)
				return;
			//список уже призязанных задач по компонетам
			var bindedDirectives = listViewBindedTasks.SelectedItems.OfType<ComponentDirective>().ToList();
			//Объединенный список выбранных и привязанных компонентов
			var concatenatedDirectives = selectedDirectives.Concat(bindedDirectives);
			foreach (ComponentDirective dd in concatenatedDirectives)
			{
				if (concatenatedDirectives.Count(d => d.ComponentId == dd.ComponentId) > 1)
				{
					//проверка, не выбраны ли 2 или более задач по одному компоненту для привязки
					//т.к. MPD Item может быть привязан только к одной задаче каждого выбранного компонента
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
						//Проверка не имеет ли выбранная задача по компоненту привязки к другой задаче 
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
			//Удаление из коллекции выбранных компонентов тех компонентов, 
			//задачи по которым содержатся в коллекции selectedDirectives
			foreach (ComponentDirective directive in selectedDirectives)
				selectedComponents.RemoveById(directive.ComponentId);
			//Производится привязка выбранных задач по компонентам к выполнению данного MPD
			foreach (ComponentDirective dd in selectedDirectives.Where(d => d.ItemRelations.Count == 0))
			{
				try
				{
					//TODO:(Evgenii Babak) проверить использования свойств
					dd.MPDTaskType = _maintenanceDirective.WorkType;
					dd.FaaFormFile = _maintenanceDirective.TaskCardNumberFile;
					dd.FaaFormFileId = _maintenanceDirective.TaskCardNumberFile != null
											? _maintenanceDirective.TaskCardNumberFile.ItemId
											: -1;

					AddComponentAndDirectiveToBindedItemsCollections(dd.ParentComponent, dd, itemsToInsert, _bindedItems, _newBindedItems);
					//Удаление задачи по компоненту из элемента управления содержащего список всех задач  
					listViewTasksForSelect.RemoveItem(dd);
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while save bind task record", ex);
				}
			}

			//Производится привязка выбранных компонентов к выполнению данного MPD
			//В результате предыдущих манипуляций в коллекции выбранных компонентов
			//должны остаться компоненты у которых либо нет задач, либо не одна не была выбрана
			foreach (Component selectedComponent in selectedComponents)
			{
				if(selectedComponent.ComponentDirectives.Count == 0)
				{
					//Выбранный компонент не имеет задач.
					//Для привязки необходимо создать задачу
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
					//Выбранный компонент имеет задачи
					//Но все они привязаны к другим задачам
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
					//Выбранный компонент имеет задачи
					//Но ни одна из его задач не была выбрана для привязки 
					//Необходимо задать вопрос: создать ли овую задачу для привязки
					//или пользователь должен быбрать задачу для привязки сам из имеющихся задач по компоненту
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

			//Коллекция элементов которые нужно добавить в элемента управления содержащий список всех задач  
			var itemsToInsert = new CommonCollection<BaseEntityObject>();
			var detailDirectives = listViewBindedTasks.SelectedItems.OfType<ComponentDirective>().ToList();

            foreach (var selectedItem in detailDirectives)
            {
	            try
	            {
					//Если задача по компоненту была сохранена в бд , то добавляем в список удаляемых элементов
		            if (selectedItem.ItemId > 0)
		            {
						itemsToInsert.Add(selectedItem);
			            _bindedItemsToRemove.Add(selectedItem);
					}

					//Удаление задачи по компоненту  из коллекции содержащей все связаные задачи
					_bindedItems.Remove(selectedItem);

					//Удаление задачи по  компоненту из элемента управления содержащего список всех привязаных задач  
					listViewBindedTasks.RemoveItem(selectedItem);

					//если в коллекции содержащей все связные задачи не содержится задач по компоненту,
					//которые принадлежат тому же компоненту что и текущая задача 
					//требуется удалить компонент из коллекции содержащей все связные задачи
					if (_bindedItems.OfType<ComponentDirective>().All(x => x.ParentComponent.ItemId != selectedItem.ParentComponent.ItemId))
		            {
						_bindedItems.Remove(selectedItem.ParentComponent);
						//Удаление компонента из элемента управления содержащего список всех привязаных задач  
						listViewBindedTasks.RemoveItem(selectedItem.ParentComponent);
					}

					if (_newBindedItems.ContainsKey(selectedItem.ParentComponent))
		            {
						//Удаление задачи по компоненту из коллекции новых привязанных зачач по компоненту
						_newBindedItems[selectedItem.ParentComponent].Remove(selectedItem);
						//Если среди новых привязанных задач по компоненту не содержатся задачи по компонентам,
						//которые принадлежат тому же компоненту что и текущая задача 
						//требуется удалить компонент из словаря
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

			//Сохранение новых связанных задач
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

			//Удаление связанных задач
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

			//Если ItemsRelationTypе от Mpd не совпадает с выбранным ItemsRelationTypе в комбике, производится обновление всех ItemRelation - ов
			if (_maintenanceDirective.WorkItemsRelationType != relationType)
			{
				SaveItemRelations(selectedRelationType, _maintenanceDirective);
			}
		}

		#endregion

		#region private void AddDirectiveRecord(Detail component, DetailDirective detailDirective)

		private void AddDirectiveRecord(Component component, ComponentDirective componentDirective)
	    {
		    // Если у MPD Item есть записи о выполнении,
		    //то их нужно внести в записи о выполнении новой задачи по компоненту
		    if (_maintenanceDirective.LastPerformance != null)
		    {
			    //Получение записи об установке агрегата
			    TransferRecord tr = component.TransferRecords.GetLast();
			    //Необходимо ввести только те записи, что могли быть выполнены после установки агрегата
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

			// Добавление задачи по компоненту из коллекции содержащих все связаные задачи
			allbindedItems.Add(componentDirective);

		    //если в коллекции содержащей все связные задачи нет родительского компонента от задачи по компоненту 
		    //требуется добавить компонент в коллекцию содержащую все связные задачи
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