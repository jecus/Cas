using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using CAS.UI.UIControls.DocumentationControls;
using CAS.UI.UIControls.PersonnelControls.EmployeeControls;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Personnel;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PersonnelControls.EmployeeTraining
{
	public partial class EmployeeTrainingControl : UserControl
	{
		public SpecialistTraining CurrentTraining
		{
			get { return _training; }
			set { _training = value; }
		}

		private SpecialistTraining _training;

		#region Constructor

		public EmployeeTrainingControl()
		{
			InitializeComponent();
		}

		#endregion

		#region public void UpdateInformation(SpecialistTraining training, Specialist currentItem, List<Supplier> suppliers)

		public void UpdateInformation(SpecialistTraining training, List<Supplier> suppliers, List<AircraftModel> aircraftModels, IEnumerable<EmployeeLicenceGeneralControl> employeeLicenceControl)
		{
			_training = training;

			var categoryId = 0;

			foreach (var variableControl in employeeLicenceControl)
			{
				categoryId = variableControl.EmployeeLicenceTypeId;
				variableControl.LisenceChanged += VariableControl_LisenceChanged;
			}

			comboBoxAircraftModel.Items.Clear();
			comboBoxAircraftModel.Items.AddRange(aircraftModels.ToArray());
			comboBoxAircraftModel.Items.Add(AircraftModel.Unknown);

			comboBoxAircraftModel.SelectedItem = training.AircraftType;

			comboBoxSupplier.Items.Clear();
			comboBoxSupplier.Items.AddRange(suppliers.ToArray());

			comboBoxTrainingType.Items.Clear();
			comboBoxTrainingType.Items.AddRange(TrainingType.Items.ToArray());


			lookupComboboxSubject.LoadObjectsFunc = GlobalObjects.CasEnvironment.NewLoader.GetEmployeeSubject;
			lookupComboboxSubject.FilterParam1 = categoryId;
			lookupComboboxSubject.Type = typeof(EmployeeSubject);
			lookupComboboxSubject.SelectedItem = _training.EmployeeSubject;
			Program.MainDispatcher.ProcessControl(lookupComboboxSubject);

			comboBoxTrainingType.SelectedItem = _training.TrainingType;
			comboBoxSupplier.SelectedItem = _training.Supplier;
			checkBoxClose.Checked = _training.IsClosed;
			textBoxDescription.Text = _training.Description;
			textBoxCost.Text = _training.Cost.ToString();
			textBoxHiddenRemarks.Text = _training.HiddenRemark;
			textBoxManHours.Text = _training.ManHours.ToString();
			textBoxRemarks.Text = _training.Remarks;


			documentControl1.CurrentDocument = _training.Document;
			documentControl1.Added += DocumentControl1_Added;


			if (training.Threshold != null)
			{
				dateTimePickerEffDate.Value = _training.Threshold.EffectiveDate;
				lifelengthViewer_FirstPerformance.Lifelength = _training.Threshold.FirstPerformanceSinceEffectiveDate;
				lifelengthViewer_FirstNotify.Lifelength = _training.Threshold.FirstNotification;
				lifelengthViewerRptInterval.Lifelength = _training.Threshold.RepeatInterval;
				lifelengthViewerRptNotify.Lifelength = _training.Threshold.RepeatNotification;
			}
		}
		#endregion

		private void VariableControl_LisenceChanged(object sender, EventArgs e)
		{
			var selectedCategory = (EmployeeLicenceType)sender;

			lookupComboboxSubject.LoadObjectsFunc = GlobalObjects.CasEnvironment.NewLoader.GetEmployeeSubject;
			lookupComboboxSubject.FilterParam1 = selectedCategory.ItemId;
			lookupComboboxSubject.UpdateInformation();
		}

		#region private void DocumentControl1_Added(object sender, EventArgs e)

		private void DocumentControl1_Added(object sender, EventArgs e)
		{
			var newDocument = CreateNewDocument();
			var form = new DocumentForm(newDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
			{
				_training.Document = newDocument;
				documentControl1.CurrentDocument = newDocument;

			}
		}

		#endregion

		#region private Document CreateNewDocument()

		private Document CreateNewDocument()
		{
			var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Personnel Training") as DocumentSubType;
			var description = _training.Description;

			return new Document
			{
				ParentId = _training.ItemId,
				Parent = _training,
				ParentTypeId = _training.SmartCoreObjectType.ItemId,
				DocType = DocumentType.TechnicalRecords,
				DocumentSubType = docSubType,
				IsClosed = true,
				//ContractNumber = $"P/N:{partNumber} S/N:{serialNumber}",
				Description = description,
			};
		}

		#endregion

		#region public bool ValidateData(out string message)

		public bool ValidateData(out string message)
		{
			message = "";
			var sb = new StringBuilder();
			string manHourMessage, costMessage;
			ValidateDoubleValue("Man Hours", textBoxManHours.Text, out manHourMessage);
			ValidateDoubleValue("Cost", textBoxCost.Text, out costMessage);

			//if (comboBoxTrainingType.SelectedItem == null)
			//{
			//	if (message != "");
			//		sb.AppendLine("Please select Training Type");
			//}


			message = sb.ToString();
			if (message != "")
				return false;
			return true;
		}

		#endregion

		#region public bool GetChangeStatus()

		public bool GetChangeStatus()
		{
			return comboBoxSupplier.SelectedItem as Supplier != _training.Supplier ||
			       comboBoxTrainingType.SelectedItem as TrainingType != _training.TrainingType ||
			       checkBoxClose.Checked != _training.IsClosed ||
			       textBoxDescription.Text != _training.Description ||
			       textBoxCost.Text != _training.Cost.ToString() ||
			       textBoxHiddenRemarks.Text != _training.HiddenRemark ||
			       textBoxManHours.Text != _training.ManHours.ToString() ||
			       textBoxRemarks.Text != _training.Remarks;
		}

		#endregion

		#region public void ApplyChanges()

		public void ApplyChanges()
		{
			_training.Supplier = comboBoxSupplier.SelectedItem as Supplier;
			_training.TrainingType = comboBoxTrainingType.SelectedItem as TrainingType;
			_training.IsClosed = checkBoxClose.Checked;
			_training.Description = textBoxDescription.Text;
			_training.Cost = ConvertDoubleValue(textBoxCost.Text);
			_training.HiddenRemark = textBoxHiddenRemarks.Text;
			_training.ManHours = ConvertDoubleValue(textBoxManHours.Text);
			_training.Remarks = textBoxRemarks.Text;
			_training.AircraftTypeID = ((AircraftModel)comboBoxAircraftModel.SelectedItem).ItemId;
			_training.EmployeeSubject = (EmployeeSubject)lookupComboboxSubject.SelectedItem;

			_training.Threshold.EffectiveDate = dateTimePickerEffDate.Value;
			_training.Threshold.FirstPerformanceSinceEffectiveDate = lifelengthViewer_FirstPerformance.Lifelength;
			_training.Threshold.FirstNotification = lifelengthViewer_FirstNotify.Lifelength;
			_training.Threshold.RepeatInterval = lifelengthViewerRptInterval.Lifelength;
			_training.Threshold.RepeatNotification= lifelengthViewerRptNotify.Lifelength;
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

		#region Events

		private void linkLabelRemove_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (Deleted != null)
				Deleted(this, EventArgs.Empty);
		}
		public event EventHandler Deleted;

		#endregion

	}
}
