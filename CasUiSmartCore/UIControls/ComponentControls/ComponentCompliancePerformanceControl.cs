using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.DocumentationControls;
using CAS.UI.UIControls.KitControls;
using CAS.UI.UIControls.MaintananceProgram;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Relation;
using TempUIExtentions;

namespace CAS.UI.UIControls.ComponentControls
{
	///<summary>
	/// ЭУ для отображения директивы детали
	///</summary>
	public partial class ComponentCompliancePerformanceControl : UserControl
	{
		#region Fields

		private readonly ComponentDirective _currentComponentDirective;
		private IBindedItem _lastBindedMpd;

		#endregion

		#region Constructor

		#region DetailCompliancePerformanceControl()
		///<summary>
		/// конструктор по умолчанию без параметров
		///</summary>
		public ComponentCompliancePerformanceControl()
		{
			InitializeComponent();
		}

		#endregion

		#region public DetailCompliancePerformanceControl(DetailDirective detailDirective) : this()

		/// <summary>
		/// Создает элемент управления, использующийся для редактирования отдельной информации Compliance/Performance
		/// </summary>
		/// <param name="componentDirective">Работа агрегата</param>
		public ComponentCompliancePerformanceControl(ComponentDirective componentDirective) : this()
		{
			_currentComponentDirective = componentDirective;
			UpdateInformation();
		}

		#endregion

		#endregion

		#region Propeties

		#region public Lifelength Interval

		/// <summary>
		/// Возвращает интервал обслуживания
		/// </summary>
		public Lifelength Interval
		{
			get
			{
				return lifelengthViewerRptInterval.Lifelength;
			}
		}

		#endregion

		#region public DetailDirective DetailDirective

		/// <summary>
		/// Возвращает работу агрегата
		/// </summary>
		public ComponentDirective ComponentDirective
		{
			get
			{
				return _currentComponentDirective;
			}
		}

		#endregion

		#region public bool isClosed { get; set; }
		///<summary>
		///</summary>
		private bool IsClosed { get; set; }

		#endregion

		#region public bool EnableExtendedControl
		///<summary>
		///</summary>
		public bool EnableExtendedControl
		{
			get { return panelExtendable.Visible; }
			set
			{
				panelExtendable.Visible = value;
				if (value == false) _mainPanel.Visible = true;
			}
		}
		#endregion

		#region public bool IsExpiry { get; set; }

		public bool IsExpiry { get; set; }

		#endregion

		#endregion

		#region Methods

		#region public void CancelAsync()
		///<summary>
		/// запрашивает отмену асинхронной операции
		///</summary>
		public void CancelAsync()
		{
			if (lookupComboboxMaintenanceDirective != null)
				lookupComboboxMaintenanceDirective.CancelAsync();
		}
		#endregion

		#region public bool GetChangeStatus()

		/// <summary>
		/// Возвращает значение, показывающее были ли изменения в данном элементе управления
		/// </summary>
		public bool GetChangeStatus()
		{
			var manHours = ConvertDoubleValue(textBoxManHours.Text);
			var cost = ConvertDoubleValue(textBoxCost.Text);

			ComponentDirectiveThreshold threshold = new ComponentDirectiveThreshold();

			if (comboBoxWorkType.SelectedItem as ComponentRecordType ==
				ComponentRecordType.Preservation)
			{
				threshold.EffectiveDate = dateTimePickerEffDate.Value;
				threshold.FirstPerformanceSinceEffectiveDate = lifelengthViewer_FirstPerformance.Lifelength;
			}
			else
			{
				threshold.EffectiveDate = DateTimeExtend.GetCASMinDateTime();
				threshold.FirstPerformanceSinceNew = lifelengthViewer_FirstPerformance.Lifelength;
			}

			threshold.FirstNotification = lifelengthViewer_FirstNotify.Lifelength;
			threshold.RepeatInterval = lifelengthViewerRptInterval.Lifelength;
			threshold.RepeatNotification = lifelengthViewerRptNotify.Lifelength;
			threshold.Warranty = lifelengthViewerWarranty.Lifelength;
			threshold.WarrantyNotification = lifelengthViewerWarrantyNotify.Lifelength;
			_currentComponentDirective.ExpiryRemainNotify = lifelengthViewerExpiryRemain.Lifelength;
			threshold.FirstPerformanceConditionType = radio_WhicheverFirst.Checked
													  ? ThresholdConditionType.WhicheverFirst
													  : ThresholdConditionType.WhicheverLater;

			try
			{
				var bindedItemId = -1;
				var currentRelation = _currentComponentDirective.ItemRelations.SingleOrDefault();
				var bindedItemRelationType = ItemRelationHelper.ConvertBLItemRelationToUIITem(_currentComponentDirective.WorkItemsRelationType, _currentComponentDirective.IsFirst.HasValue && _currentComponentDirective.IsFirst.Value);
				if (currentRelation != null)
				{
					bindedItemId = _currentComponentDirective.IsFirst == true
						? currentRelation.SecondItemId
						: currentRelation.FirstItemId;
				}

				if (_currentComponentDirective.ManHours != manHours ||
					lookupComboboxMaintenanceDirective.SelectedItemId != bindedItemId ||
					_currentComponentDirective.MPDTaskType != comboBoxMpdTaskType.SelectedItem ||
					(WorkItemsRelationTypeUI) comboBoxRelationType.SelectedValue != bindedItemRelationType ||
					_currentComponentDirective.Cost != cost ||
					_currentComponentDirective.IsClosed != IsClosed ||
					_currentComponentDirective.IsExpiry != IsExpiry ||
					_currentComponentDirective.KitRequired != textBoxKitRequired.Text ||
					_currentComponentDirective.Remarks != textBoxRemarks.Text ||
					textBoxZoneArea.Text != _currentComponentDirective.ZoneArea ||
					textBoxAcess.Text != _currentComponentDirective.AccessDirective ||
					textBoxAAM.Text != _currentComponentDirective.AAM ||
					textBoxCMM.Text != _currentComponentDirective.CMM ||
					dateTimePickerExpiryDate.Value != _currentComponentDirective.ExpiryDate ||
					_currentComponentDirective.NDTType.ItemId != ((NDTType)comboBoxNdt.SelectedItem).ItemId ||
					_currentComponentDirective.Threshold.ToString() != threshold.ToString() ||
					_currentComponentDirective.FaaFormFile != fileControl.AttachedFile ||
					_currentComponentDirective.HiddenRemarks != textBoxHiddenRemarks.Text ||
					_currentComponentDirective.DirectiveType.ItemId != ((ComponentRecordType)comboBoxWorkType.SelectedItem).ItemId ||
					fileControl.GetChangeStatus())
				{
					return true;
				}
			}
			catch (InvalidOperationException)
			{
				ItemRelationHelper.ShowDialogIfItemLinksCountMoreThanOne($"Component {_currentComponentDirective.PartNumber}",_currentComponentDirective.ItemRelations.Count);
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while saving data", ex);
				return true;
			}
			return false;
		}

		#endregion

		#region public bool ValidateData(out string message)
		/// <summary>
		/// Возвращает значение, показывающее является ли значение элемента управления допустимым
		/// </summary>
		/// <returns></returns>
		public bool ValidateData(out string message)
		{
			var sb = new StringBuilder();
			string manHourMessage, costMessage, validateFiles;
			ValidateDoubleValue("Man Hours", textBoxManHours.Text, out manHourMessage);
			ValidateDoubleValue("Cost", textBoxCost.Text, out costMessage);

			if (!string.IsNullOrEmpty(manHourMessage))
				sb.AppendLine(manHourMessage);
			if (!string.IsNullOrEmpty(costMessage))
				sb.AppendLine(costMessage);
			if (!fileControl.ValidateData(out validateFiles))
				sb.AppendLine("FAA File: " + validateFiles);

			var selectedMpd = (MaintenanceDirective)lookupComboboxMaintenanceDirective.SelectedItem;
			
			if (selectedMpd != null)
			{
				var selectedRelationTypeUI = (WorkItemsRelationTypeUI)comboBoxRelationType.SelectedValue;
				var selectedRelationType = ItemRelationHelper.ConvertUIItemRelationToBLItem(selectedRelationTypeUI, !(selectedMpd.IsFirst.GetValueOrDefault(false)));

				if (!selectedMpd.ItemRelations.IsAllRelationWith(_currentComponentDirective) && selectedMpd.ItemRelations.Any(i => i.RelationTypeId != selectedRelationType))
				{
					sb.AppendLine($"You not able to bing this component with MPD {selectedMpd.ItemId} as {selectedRelationType},");
					sb.AppendLine($"because this MPD have link with other components as {selectedMpd.WorkItemsRelationType}");
				}
			}

			message = sb.ToString();
			if (message != "")
				return false;
			return true;
		}

		#endregion

		#region public void ApplyChanges(Component component)

		public void ApplyChanges(Component component)
		{
			if (component == null)
				return;

			ApplyChanges();
		}

		#endregion

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			lookupComboboxMaintenanceDirective.SelectedIndexChanged -= LookupComboboxMaintenanceDirectiveSelectedIndexChanged;
			comboBoxRelationType.SelectedIndexChanged -= ComboBoxRelationType_SelectedIndexChanged;

			extendableRichContainer.labelCaption.Text =
				_currentComponentDirective.DirectiveType.ToString();

			UpdateWorkTypes(_currentComponentDirective.ParentComponent.GoodsClass);

			comboBoxNdt.Items.Clear();
			comboBoxNdt.Items.AddRange(NDTType.Items.ToArray());
			comboBoxNdt.SelectedItem = _currentComponentDirective.NDTType;

			comboBoxMpdTaskType.Items.Clear();
			comboBoxMpdTaskType.Items.AddRange(MaintenanceDirectiveTaskType.Items.ToArray());
			comboBoxMpdTaskType.SelectedItem = _currentComponentDirective.MPDTaskType ?? MaintenanceDirectiveTaskType.Unknown;

			//GlobalObjects.PerformanceCalculator.GetNextPerformance(_currentComponentDirective);
			if (_currentComponentDirective.Condition == ConditionState.Overdue)
				imageLinkLabelStatus.Status = Statuses.NotSatisfactory;
			if (_currentComponentDirective.Condition == ConditionState.Notify)
				imageLinkLabelStatus.Status = Statuses.Notify;
			if (_currentComponentDirective.Condition == ConditionState.Satisfactory)
				imageLinkLabelStatus.Status = Statuses.Satisfactory;

			fileControl.UpdateInfo(_currentComponentDirective.FaaFormFile,
								   "Adobe PDF Files|*.pdf",
								   "This record does not contain a file proving the FAA File. Enclose PDF file to prove the compliance.",
								   "Attached file proves the FAA File.");

			documentControl1.CurrentDocument = _currentComponentDirective.Document;
			documentControl1.Added += DocumentControl1_Added;

			if (_currentComponentDirective.FaaFormFile != null)
			{
				fileControl.AttachedFile = _currentComponentDirective.FaaFormFile.FileName != ""
					? _currentComponentDirective.FaaFormFile
					: new AttachedFile { ItemId = _currentComponentDirective.FaaFormFileId };
			}

			if (Math.Abs(_currentComponentDirective.ManHours) > 0.000001)
				textBoxManHours.Text = _currentComponentDirective.ManHours.ToString();
			if (Math.Abs(_currentComponentDirective.Cost) > 0.000001)
				textBoxCost.Text = _currentComponentDirective.Cost.ToString();
			textBoxKitRequired.Text = _currentComponentDirective.Kits.Count + " kits";
			textBoxRemarks.Text = _currentComponentDirective.Remarks;
			textBoxHiddenRemarks.Text = _currentComponentDirective.HiddenRemarks;
			checkBoxClose.Checked = _currentComponentDirective.IsClosed;
			checkBoxIsExpiry.Checked = _currentComponentDirective.IsExpiry;

			textBoxZoneArea.Text = _currentComponentDirective.ZoneArea;
			textBoxAcess.Text = _currentComponentDirective.AccessDirective;
			textBoxAAM.Text = _currentComponentDirective.AAM;
			textBoxCMM.Text = _currentComponentDirective.CMM;
			if (_currentComponentDirective?.ExpiryDate != null)
				dateTimePickerExpiryDate.Value = _currentComponentDirective.ExpiryDate.Value;


			#region ItemRelationCombobox

			comboBoxRelationType.DisplayMember = "Key";
			comboBoxRelationType.ValueMember = "Value";
			comboBoxRelationType.DataSource = EnumHelper.GetDisplayValueMemberDict<WorkItemsRelationTypeUI>();

			#endregion

			#region MaintenanceDirective

			var pareAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentComponentDirective.ParentComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
			if (pareAircraft != null)
			{
				var maintenanceScreenDisplayerText = $"{_currentComponentDirective.ParentComponent.GetParentAircraftRegNumber()}. MPD";

				lookupComboboxMaintenanceDirective.SetEditScreenControl<MaintenanceDirectiveScreen>
					(maintenanceScreenDisplayerText);
				lookupComboboxMaintenanceDirective.SetItemsScreenControl<MaintenanceDirectiveListScreen>
					(new object[] { pareAircraft }, maintenanceScreenDisplayerText);
				lookupComboboxMaintenanceDirective.LoadObjectsFunc = GlobalObjects.MaintenanceCore.GetMaintenanceDirectives;
				lookupComboboxMaintenanceDirective.FilterParam1 = pareAircraft;
				//lookupComboboxMaintenanceDirective.FilterParam2 =
				//	new ICommonFilter[] { new CommonFilter<int>(MaintenanceDirective.MaintenanceCheckProperty, FilterType.LessOrEqual, new[] { 0 }) };
			}

			#endregion

			try
			{
				var itemRelation = _currentComponentDirective.ItemRelations.SingleOrDefault();
				var mpdId = -1;
				WorkItemsRelationTypeUI relationType;
				if (itemRelation != null && (itemRelation.FirtsItemTypeId == SmartCoreType.MaintenanceDirective.ItemId ||
											 itemRelation.SecondItemTypeId == SmartCoreType.MaintenanceDirective.ItemId))
				{
					mpdId = _currentComponentDirective.IsFirst == true ? itemRelation.SecondItemId : itemRelation.FirstItemId;
					relationType = ItemRelationHelper.ConvertBLItemRelationToUIITem(_currentComponentDirective.WorkItemsRelationType, _currentComponentDirective.IsFirst.HasValue && _currentComponentDirective.IsFirst.Value);
				}
				else relationType = WorkItemsRelationTypeUI.ThisItemAffectOnAnother;

				lookupComboboxMaintenanceDirective.SelectedItemId = mpdId;
				comboBoxRelationType.SelectedValue = relationType;
				SetControlsEnable(relationType == WorkItemsRelationTypeUI.ThisItemAffectOnAnother);

			}
			catch (InvalidOperationException)
			{
				ItemRelationHelper.ShowDialogIfItemLinksCountMoreThanOne($"Component {_currentComponentDirective.PartNumber}", _currentComponentDirective.ItemRelations.Count);
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log(ex);
			}

			if (_currentComponentDirective.Threshold != null)
			{
				if (_currentComponentDirective.DirectiveTypeId == ComponentRecordType.Preservation.ItemId)
				{
					dateTimePickerEffDate.Value = _currentComponentDirective.Threshold.EffectiveDate;
					lifelengthViewer_FirstPerformance.Lifelength = _currentComponentDirective.Threshold.FirstPerformanceSinceEffectiveDate;
				}
				else
				{
					lifelengthViewer_FirstPerformance.Lifelength = _currentComponentDirective.Threshold.FirstPerformanceSinceNew;
				}
				lifelengthViewer_FirstNotify.Lifelength = _currentComponentDirective.Threshold.FirstNotification;
				lifelengthViewerRptInterval.Lifelength = _currentComponentDirective.Threshold.RepeatInterval;
				lifelengthViewerRptNotify.Lifelength = _currentComponentDirective.Threshold.RepeatNotification;
				lifelengthViewerWarranty.Lifelength = _currentComponentDirective.Threshold.Warranty;
				lifelengthViewerWarrantyNotify.Lifelength = _currentComponentDirective.Threshold.WarrantyNotification;
				lifelengthViewerExpiryRemain.Lifelength = _currentComponentDirective.ExpiryRemainNotify;

				if (_currentComponentDirective.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst)
					radio_WhicheverFirst.Checked = true;
				else radio_WhicheverLater.Checked = true;
			}
			lookupComboboxMaintenanceDirective.UpdateInformation();
			comboBoxRelationType.SelectedIndexChanged += ComboBoxRelationType_SelectedIndexChanged;
			lookupComboboxMaintenanceDirective.SelectedIndexChanged += LookupComboboxMaintenanceDirectiveSelectedIndexChanged;
		}

		#endregion

		#region private void DocumentControl1_Added(object sender, EventArgs e)

		private void DocumentControl1_Added(object sender, EventArgs e)
		{
			var newDocument = CreateNewDocument();

			var form = new DocumentForm(newDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
			{
				_currentComponentDirective.Document = newDocument;
				documentControl1.CurrentDocument = newDocument;

			}
		}

		#endregion

		#region private Document CreateNewDocument()

		private Document CreateNewDocument()
		{
			var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Component CRS Form") as DocumentSubType;
			var partNumber = _currentComponentDirective.ParentComponent.PartNumber;
			var serialNumber = _currentComponentDirective.ParentComponent.SerialNumber;
			var description = _currentComponentDirective.ParentComponent.Description;

			return new Document
			{
				ParentId = _currentComponentDirective.ItemId,
				Parent = _currentComponentDirective,
				ParentTypeId = _currentComponentDirective.SmartCoreObjectType.ItemId,
				DocType = DocumentType.TechnicalRecords,
				DocumentSubType = docSubType,
				IsClosed = true,
				ContractNumber = $"P/N:{partNumber} S/N:{serialNumber}",
				Description = $"{description} WorkType:{_currentComponentDirective.DirectiveType}",
				ParentAircraftId = _currentComponentDirective.ParentComponent.ParentAircraftId
			};
		}

		#endregion

		#region  public void UpdateWorkTypes(GoodsClass detailType)
		///<summary>
		/// Изменяет доступные типы задач для переданного типа компонентов
		///</summary>
		///<param name="goodsClass">Тип компонента, для которого нужно определить типы задач</param>
		public void UpdateWorkTypes(GoodsClass goodsClass)
		{
			comboBoxWorkType.Items.Clear();

			foreach (var t in ComponentRecordType.Items.OrderBy(x => x.FullName))
			{
				comboBoxWorkType.Items.Add(t);
				if (_currentComponentDirective.DirectiveType == t)
					comboBoxWorkType.SelectedItem = t;
			}
			if (comboBoxWorkType.SelectedItem == null)
				comboBoxWorkType.SelectedIndex = 0;
		}

		#endregion

		#region public void ApplyChanges()

		public void ApplyChanges()
		{
			var manHours = ConvertDoubleValue(textBoxManHours.Text);
			var cost = ConvertDoubleValue(textBoxCost.Text);

			_currentComponentDirective.DirectiveTypeId = ((ComponentRecordType) comboBoxWorkType.SelectedItem).ItemId;
			_currentComponentDirective.ManHours = manHours;
			_currentComponentDirective.Cost = cost;
			_currentComponentDirective.IsClosed = IsClosed;
			_currentComponentDirective.IsExpiry = IsExpiry;
			_currentComponentDirective.KitRequired = textBoxKitRequired.Text;
			_currentComponentDirective.Remarks = textBoxRemarks.Text;
			_currentComponentDirective.HiddenRemarks = textBoxHiddenRemarks.Text;
			 _currentComponentDirective.ZoneArea = textBoxZoneArea.Text;
			_currentComponentDirective.AccessDirective = textBoxAcess.Text;
			_currentComponentDirective.AAM = textBoxAAM.Text;
			_currentComponentDirective.CMM = textBoxCMM.Text;
			_currentComponentDirective.ExpiryDate = dateTimePickerExpiryDate.Value;
			_currentComponentDirective.MPDTaskType = ((MaintenanceDirectiveTaskType) comboBoxMpdTaskType.SelectedItem);
			_currentComponentDirective.NDTType = comboBoxNdt.SelectedItem as NDTType;

			var threshold = new ComponentDirectiveThreshold();

			if (_currentComponentDirective.DirectiveTypeId == ComponentRecordType.Preservation.ItemId)
			{
				threshold.EffectiveDate = dateTimePickerEffDate.Value;
				threshold.FirstPerformanceSinceNew.Reset();
				threshold.FirstPerformanceSinceEffectiveDate = lifelengthViewer_FirstPerformance.Lifelength;
			}
			else
			{
				threshold.EffectiveDate = new DateTime(1950, 1, 1);
				threshold.FirstPerformanceSinceNew = lifelengthViewer_FirstPerformance.Lifelength;
				threshold.FirstPerformanceSinceEffectiveDate.Reset();
			}

			threshold.FirstNotification = lifelengthViewer_FirstNotify.Lifelength;
			threshold.RepeatInterval = lifelengthViewerRptInterval.Lifelength;
			threshold.RepeatNotification = lifelengthViewerRptNotify.Lifelength;
			threshold.Warranty = lifelengthViewerWarranty.Lifelength;
			threshold.WarrantyNotification = lifelengthViewerWarrantyNotify.Lifelength;
			_currentComponentDirective.ExpiryRemainNotify = lifelengthViewerExpiryRemain.Lifelength;
			threshold.FirstPerformanceConditionType = radio_WhicheverFirst.Checked
				? ThresholdConditionType.WhicheverFirst
				: ThresholdConditionType.WhicheverLater;

			if (fileControl.GetChangeStatus())
			{
				fileControl.ApplyChanges();
				_currentComponentDirective.FaaFormFile = fileControl.AttachedFile;
			}
			if (_currentComponentDirective.Threshold.ToString() != threshold.ToString())
				_currentComponentDirective.Threshold = threshold;
		}

		#endregion

		#region public bool SaveData()

		/// <summary>
		/// Сохраняет работу агрегата
		/// </summary>
		/// <returns></returns>
		public void SaveData()
		{
			try
			{
				GlobalObjects.CasEnvironment.NewKeeper.Save(_currentComponentDirective);

				var currentRelatedItem = lookupComboboxMaintenanceDirective.SelectedItem as MaintenanceDirective;
				var selectedRelationType = (WorkItemsRelationTypeUI)comboBoxRelationType.SelectedValue;
				var itemsRelation = _currentComponentDirective.ItemRelations.SingleOrDefault();

				if (currentRelatedItem != null)
				{
					ChangeItemRelations(ref itemsRelation, currentRelatedItem, selectedRelationType);
					if (itemsRelation != null)
						GlobalObjects.CasEnvironment.NewKeeper.Save(itemsRelation);
				}
				else
				{
					if (itemsRelation != null && itemsRelation.ItemId > 0)
					{
						DeleteItemRelation(itemsRelation);
						GlobalObjects.CasEnvironment.NewKeeper.Save(itemsRelation);
					}
				}
			}
			catch (InvalidOperationException)
			{
				ItemRelationHelper.ShowDialogIfItemLinksCountMoreThanOne($"Component {_currentComponentDirective.PartNumber}", _currentComponentDirective.ItemRelations.Count);
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while saving data", ex);
			}
		}

		#endregion

		#region public void SaveData(Component component)

		public void SaveData(Component component)
		{
			try
			{
				GlobalObjects.ComponentCore.AddComponentDirective(component, _currentComponentDirective);

				var currentRelatedItem = lookupComboboxMaintenanceDirective.SelectedItem as MaintenanceDirective;
				var selectedRelationType = (WorkItemsRelationTypeUI)comboBoxRelationType.SelectedValue;
				var itemsRelation = _currentComponentDirective.ItemRelations.SingleOrDefault();

				if (currentRelatedItem != null)
				{
					ChangeItemRelations(ref itemsRelation, currentRelatedItem, selectedRelationType);
				}
				else
				{
					if (itemsRelation != null && itemsRelation.ItemId > 0)
					{
						DeleteItemRelation(itemsRelation);
						GlobalObjects.CasEnvironment.NewKeeper.Save(itemsRelation);
					}
				}
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while saving data", ex);
			}
		}

		#endregion

		#region private void ComboBoxWorkTypeSelectedIndexChanged(object sender, EventArgs e)

		private void ComboBoxWorkTypeSelectedIndexChanged(object sender, EventArgs e)
		{
			ComponentRecordType drt = comboBoxWorkType.SelectedItem as ComponentRecordType;
			if (drt == null || drt != ComponentRecordType.Preservation)
			{
				labelEffectivityDate.Visible = false;
				dateTimePickerEffDate.Visible = false;
				lifelengthViewer_FirstPerformance.LeftHeader = "Perform at:";
			}
			else
			{
				labelEffectivityDate.Visible = true;
				dateTimePickerEffDate.Visible = true;
				lifelengthViewer_FirstPerformance.LeftHeader = "Since Cons. Date:";
			}
		}
		#endregion

		#region private void LinkLabelClearLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

		private void LinkLabelClearLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (MessageBox.Show("Do you really want to delete performance limitation for this detail?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				if (Deleted != null)
					Deleted(this, EventArgs.Empty);
			}
		}

		#endregion

		#region private bool ValidateDoubleValue(string paramName, string checkedString)

		/// <summary>
		/// Проверяет значение ManHours
		/// </summary>
		/// <param name="paramName"></param>
		/// <param name="checkedString">Строковое значение value</param>
		/// <returns>Возвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
		private void ValidateDoubleValue(string paramName, string checkedString, out string message)
		{
			message = "";
			double value;
			if (checkedString != "" && double.TryParse(checkedString, NumberStyles.Float, new NumberFormatInfo(), out value) == false)
			{
				message = paramName + ". Invalid value";
			}
		}

		#endregion

		#region private double ConvertDoubleValue(string checkedString)

		private double ConvertDoubleValue(string checkedString)
		{
			return checkedString == "" ? 0 : double.Parse(checkedString, NumberStyles.Float, new NumberFormatInfo());
		}

		#endregion

		#region private void LinkLabelJobCardLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

		private void LinkLabelJobCardLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			/* MaintenanceJobCardForm form;
			 if (currentDetailDirective.JobCard == null)
				 form = new MaintenanceJobCardForm(currentDetailDirective);
			 else
				 form = new MaintenanceJobCardForm(currentDetailDirective.JobCard);
			 form.ShowDialog();*/
		}

		#endregion

		#region private void LinkLabelEditKitLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		private void LinkLabelEditKitLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			KitForm dlg = new KitForm(_currentComponentDirective);
			if (dlg.ShowDialog() == DialogResult.OK)
				textBoxKitRequired.Text = _currentComponentDirective.Kits.Count + " kits";
		}
		#endregion

		#region private void ExtendableRichContainerExtending(object sender, EventArgs e)
		private void ExtendableRichContainerExtending(object sender, EventArgs e)
		{
			_mainPanel.Visible = extendableRichContainer.Extended;
		}
		#endregion

		#region private void CheckBoxCloseCheckedChanged(object sender, EventArgs e)
		private void CheckBoxCloseCheckedChanged(object sender, EventArgs e)
		{
			IsClosed = checkBoxClose.Checked;
		}
		#endregion

		#region private void checkBoxIsExpiry_CheckedChanged(object sender, EventArgs e)

		private void checkBoxIsExpiry_CheckedChanged(object sender, EventArgs e)
		{
			IsExpiry = checkBoxIsExpiry.Checked;
		}

		#endregion
		

		#region private void LookupComboboxMaintenanceDirectiveSelectedIndexChanged(object sender, EventArgs e)
		private void LookupComboboxMaintenanceDirectiveSelectedIndexChanged(object sender, EventArgs e)
		{
			if (lookupComboboxMaintenanceDirective.SelectedItem != null)
			{
				var bindedItem = (MaintenanceDirective)lookupComboboxMaintenanceDirective.SelectedItem;
				var itemRelations = GlobalObjects.ItemsRelationsDataAccess.CheckRelations(bindedItem, _currentComponentDirective);

				if (_lastBindedMpd == null)
					_lastBindedMpd = bindedItem;
				comboBoxMpdTaskType.SelectedItem = bindedItem.WorkType;

				bindedItem.ItemRelations.Clear();

				if (itemRelations.Count > 0)
				{
					//TODO:(Evgenii Babak) фикс очень кривой нужно вычислять WorkItemsRelationType с помощью метода расширения для коллекции relation - ов
					bindedItem.ItemRelations.AddRange(itemRelations);

					if (bindedItem.ItemRelations.IsAllRelationWith(SmartCoreType.ComponentDirective))
					{
						comboBoxRelationType.SelectedValue = ItemRelationHelper.ConvertBLItemRelationToUIITem(bindedItem.WorkItemsRelationType, !(bindedItem.IsFirst.HasValue && bindedItem.IsFirst.Value));
					}
					else ItemRelationHelper.ShowDialogIfItemHaveLinkWithAnotherItem($"MPD {bindedItem.MPDNumber}", "AD", "Component");
				}
				else
				{
					var selectedItem = (WorkItemsRelationTypeUI)comboBoxRelationType.SelectedValue;
					SetControlsEnable(selectedItem == WorkItemsRelationTypeUI.ThisItemAffectOnAnother);
				}
			}
			else
			{
				SetControlsEnable(true);
			}
		}
		#endregion

		#region private void ChangeItemRelations(ref ItemsRelation itemsRelation, MaintenanceDirective relatedItem, WorkItemsRelationTypeUI relationTypeUI)

		private void ChangeItemRelations(ref ItemsRelation itemsRelation, MaintenanceDirective relatedItem, WorkItemsRelationTypeUI relationTypeUI)
		{
			if (relatedItem.ItemRelations.Count == 0 ||
				relatedItem.ItemRelations.IsAllRelationWith(SmartCoreType.ComponentDirective))
			{
				if (itemsRelation == null)
				{
					itemsRelation = new ItemsRelation();
					_currentComponentDirective.ItemRelations.Add(itemsRelation);
				}
				else _lastBindedMpd.ItemRelations.Remove(itemsRelation);

				itemsRelation.FillParameters(_currentComponentDirective, relatedItem);
				if (!RelateditemContainsLinkOnCurrentItem(_currentComponentDirective, relatedItem))
					relatedItem.ItemRelations.Add(itemsRelation);

				itemsRelation.RelationTypeId = ItemRelationHelper.ConvertUIItemRelationToBLItem(relationTypeUI,_currentComponentDirective.IsFirst);
			}
			else ItemRelationHelper.ShowDialogIfItemHaveLinkWithAnotherItem($"MPD {relatedItem.MPDNumber}", "AD", "Component");
		}

		#endregion

		#region private bool RelateditemContainsLinkOnCurrentItem(IBindedItem thisItem, IBindedItem anotherItem)

		private bool RelateditemContainsLinkOnCurrentItem(IBindedItem thisItem, IBindedItem anotherItem)
		{
			return
				anotherItem.ItemRelations.Any(
					itemsRelation =>
						itemsRelation.FirstItemId == anotherItem.ItemId &&
						itemsRelation.FirtsItemTypeId == thisItem.SmartCoreObjectType.ItemId ||
						itemsRelation.SecondItemId == anotherItem.ItemId &&
						itemsRelation.SecondItemTypeId == thisItem.SmartCoreObjectType.ItemId);
		}

		#endregion

		#region private void DeleteItemRelation(ItemsRelation itemsRelation)

		private void DeleteItemRelation(ItemsRelation itemsRelation)
		{
			itemsRelation.IsDeleted = true;
			if(_lastBindedMpd != null)
				_lastBindedMpd.ItemRelations.Remove(itemsRelation);
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
			SetControlsEnable(selectedItem == WorkItemsRelationTypeUI.ThisItemAffectOnAnother);
		}

		#endregion

		private void SetControlsEnable(bool enable)
		{
			radio_WhicheverFirst.Checked = enable;

			lifelengthViewer_FirstPerformance.Enabled = enable;
			lifelengthViewer_FirstNotify.Enabled = enable;
			lifelengthViewerRptInterval.Enabled = enable;
			lifelengthViewerRptNotify.Enabled = enable;
			lifelengthViewerWarranty.Enabled = enable;
			lifelengthViewerWarrantyNotify.Enabled = enable;
			radio_WhicheverFirst.Enabled = enable;
			radio_WhicheverLater.Enabled = enable;
		}


		#endregion

		#region Events
		/// <summary>
		/// Возникает при удалении задачи у компонента
		/// </summary>
		public event EventHandler Deleted;

		#endregion

		
	}
}
