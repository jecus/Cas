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
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Relation;

namespace CAS.UI.UIControls.MaintananceProgram
{
    /// <summary>
    /// ����� ��� �������� ������� �� � ������� ���� ������
    /// </summary>
    public partial class MaintenanceDirectiveBindADForm : MetroForm
    {

        #region Fields

        private List<Directive> _bindedItems = new List<Directive>();
        private List<Directive> _itemsForSelect = new List<Directive>();

        private List<Directive> _bindedItemsToRemove = new List<Directive>();
        private List<Directive> _newBindedItems = new List<Directive>();

	    private WorkItemsRelationTypeUI _selectedRelationTypeUI;

        private readonly MaintenanceDirective _directive;
        private readonly Aircraft _currentAircraft;

        private readonly AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

		#endregion

		#region Constructors

		#region private MaintenanceDirectiveBindADForm()

		/// <summary>
		/// ������� ����� ��� �������� ������� �� � ������� ���� ������
		/// </summary>
		private MaintenanceDirectiveBindADForm()
        {
            InitializeComponent();
        }

		#endregion

		#region public MaintenanceDirectiveBindADForm(Directive directive) : this()

		/// <summary>
		/// ������� ����� ��� �������� ����� � ���������� ���� ��������� ������������
		/// </summary>
		public MaintenanceDirectiveBindADForm(MaintenanceDirective directive)
            : this()
        {
            if(directive == null)
                throw new ArgumentNullException("directive", "must be not null");
            _directive = directive;
            _currentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(directive.ParentBaseComponent.ParentAircraftId);

			_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
        }

        #endregion

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

			_selectedRelationTypeUI = _directive.ItemRelations.Count == 0 
				? WorkItemsRelationTypeUI.ThisItemAffectOnAnother 
				: ItemRelationHelper.ConvertBLItemRelationToUIITem(_directive.WorkItemsRelationType, _directive.IsFirst.HasValue && _directive.IsFirst.Value);

	        comboBoxRelationType.SelectedValue = _selectedRelationTypeUI;

			comboBoxRelationType.SelectedIndexChanged += ComboBoxRelationType_SelectedIndexChanged;
		}
        #endregion

        #region private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            if (_directive == null || _currentAircraft == null)
            {
                e.Cancel = true;
                return;
            }

            if (_bindedItems == null)
	            _bindedItems = new List<Directive>();
            _bindedItems.Clear();

            if (_itemsForSelect == null)
	            _itemsForSelect = new List<Directive>();
            _itemsForSelect.Clear();

            _animatedThreadWorker.ReportProgress(0, "load binded tasks");

            List<Directive> directives = new List<Directive>();
            try
            {
	            directives.AddRange(GlobalObjects.DirectiveCore.GetDirectives(_currentAircraft, DirectiveType.AirworthenessDirectives));

				var directivesIds = _directive.ItemRelations.Select(d => d.RelationTypeId == WorkItemsRelationType.CalculationAffect ? d.FirstItemId : d.SecondItemId);


				//����������� ������ ����������� ����� � �����������
				var bindedDirectives = 
                    directives.Where(dd => directivesIds.Contains(dd.ItemId))
					  .ToList();
				_bindedItems.AddRange(bindedDirectives.ToArray());

                //����������� ������ ������������� ����� � �����������

				var directivesForSelect =
					directives.Where(dd => dd.ItemRelations.Count == 0 || !dd.ItemRelations.IsAllRelationWith(_directive)).ToList();

                _itemsForSelect.AddRange(directivesForSelect.ToArray());
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

            if(directives != null)
            {
                foreach (var dir in directives)
	                GlobalObjects.PerformanceCalculator.GetNextPerformance(dir);
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

			if (listViewTasksForSelect.SelectedItems.Count > 1)
			{
				MessageBox.Show($"Please select one directive. Because you can only bind one directive.",
					(string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if (listViewBindedTasks.ItemsCount > 0)
			{
				MessageBox.Show($"Directive alredy binded for this MPD. If you want bind MPD please remove current binded directive.",
					(string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			var itemRelations = GlobalObjects.ItemsRelationsDataAccess.CheckRelations(listViewTasksForSelect.SelectedItems.First(), _directive);
			if (itemRelations.Count > 0)
			{
				ItemRelationHelper.ShowDialogIfItemHaveLinkWithAnotherItem($"AD {listViewTasksForSelect.SelectedItems.First().Title}","MPD","AD");
				return;
			}

			if (_directive.IsFirst == null)
			{
				_directive.NormalizeItemRelations();
				comboBoxRelationType.SelectedValue = ItemRelationHelper.ConvertBLItemRelationToUIITem(_directive.WorkItemsRelationType, false);
			}
			//������ ��������� ����� �� ����������� ��� ��������
			var selectedDirectives = listViewTasksForSelect.SelectedItems.ToList();

			//������ ��� ����������� ����� �� ����������
			var bindedDirectives = listViewBindedTasks.GetItemsArray().ToList();
			var concatenatedDirectives = selectedDirectives.Concat(bindedDirectives);

			listViewTasksForSelect.RemoveItems(selectedDirectives);
			listViewBindedTasks.SetItemsArray(concatenatedDirectives.ToArray());

			_newBindedItems.AddRange(selectedDirectives);

		}
		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)

		private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (listViewBindedTasks.SelectedItems.Count == 0)
                return;

            var selectedDirectives = listViewBindedTasks.SelectedItems.ToList();

            listViewBindedTasks.RemoveItems(selectedDirectives);
			listViewTasksForSelect.InsertItems(selectedDirectives.ToArray());
			

			_bindedItemsToRemove.AddRange(selectedDirectives);
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
			var relationType = ItemRelationHelper.ConvertUIItemRelationToBLItem(selectedRelationType, _directive.IsFirst);

			//���������� ����� ��������� �����
			foreach (var newItem in _newBindedItems)
		    {
			    var itemRelation = CreateItemRelation(newItem, selectedRelationType);
			    itemRelation.AdditionalInformation.Ad = newItem.Title;
			    itemRelation.AdditionalInformation.Mpd = _directive.Title;
				GlobalObjects.NewKeeper.Save(itemRelation);
		    }

			//�������� ��������� �����
			var mpdItemRelations = new List<ItemsRelation>(_directive.ItemRelations);
		    foreach (var detailDirective in _bindedItemsToRemove)
		    {
			    var itemsRelationsToDelete = mpdItemRelations.GetRelationsWith(detailDirective);
			    foreach (var itemsRelationToDelete in itemsRelationsToDelete)
			    {
				    itemsRelationToDelete.IsDeleted = true;
				    itemsRelationToDelete.AdditionalInformation = null;
					GlobalObjects.NewKeeper.Delete(itemsRelationToDelete);

				    _directive.ItemRelations.Remove(itemsRelationToDelete);
				    detailDirective.ItemRelations.Remove(itemsRelationToDelete);
			    }
		    }

			//���� ItemsRelationTyp� �� Mpd �� ��������� � ��������� ItemsRelationTyp� � �������, ������������ ���������� ���� ItemRelation - ��
			if (_directive.WorkItemsRelationType != relationType)
			{
				SaveItemRelations(selectedRelationType, _directive);
			}
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

		#region private ItemsRelation CreateItemRelation(DetailDirective mpd)

		private ItemsRelation CreateItemRelation(Directive mpd, WorkItemsRelationTypeUI relationTypeUI)
	    {
		    var itemRelation = new ItemsRelation();
			var relationType = ItemRelationHelper.ConvertUIItemRelationToBLItem(relationTypeUI, _directive.IsFirst);

			if (_directive.IsFirst == true)
			    itemRelation.FillParameters(_directive, mpd, relationType);
		    else
			    itemRelation.FillParameters(mpd, _directive, relationType);

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