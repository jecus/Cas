using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.DocumentationControls;
using CASTerms;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.PurchaseControls
{
	public partial class ModelForm : CommonEditorForm
	{
		#region Fields

		private readonly ComponentModel _currentModel;

		#endregion

		#region Constructor

		public ModelForm()
		{
			InitializeComponent();
		}

		public ModelForm(ComponentModel currentModel) : this()
		{
			_currentModel = currentModel;
			if (_currentModel.ItemId <= 0)
			{
				documentControl1.Enabled = false;
				UpdateInformation();
			}
			else
			{
				Task.Run(() =>
				{
					DoLoad();
				}).ContinueWith(task => UpdateInformation(), TaskScheduler.FromCurrentSynchronizationContext());
			}
            
        }

        #endregion

        private void DoLoad()
        {
            var links = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<DocumentDTO, Document>(new List<Filter>()
            {
                new Filter("ParentID",_currentModel.ItemId),
                new Filter("ParentTypeId",_currentModel.SmartCoreObjectType.ItemId)
            }, true);

            _currentModel.Document = links.FirstOrDefault();
        }
        #region private void UpdateInformation()

        private void UpdateInformation()
		{
			comboBoxAtaChapter.UpdateInformation();
			comboBoxAtaChapter.ATAChapter = _currentModel.ATAChapter;

			if(_currentModel.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.ProductionAuxiliaryEquipment))
				comboBoxDetailClass.RootNodesNames = new[] { "ComponentsAndParts", "ProductionAuxiliaryEquipment" };
			else comboBoxDetailClass.RootNodesNames = new[] { "ComponentsAndParts"};
			comboBoxDetailClass.Type = typeof(GoodsClass);
			comboBoxDetailClass.SelectedItem = _currentModel.GoodsClass;

			comboBoxAccessoryStandard.Type = typeof(GoodStandart);
			Program.MainDispatcher.ProcessControl(comboBoxAccessoryStandard);
			comboBoxAccessoryStandard.SelectedItem = _currentModel.Standart;

			comboBoxManufRegion.Items.AddRange(ManufactureRegion.Items.ToArray());
			comboBoxManufRegion.SelectedItem = _currentModel.ManufactureReg;

			dataGridViewControlSuppliers.ViewedTypeProperties.AddRange(new[]
			{
				KitSuppliersRelation.SupplierProperty,
			});
			dataGridViewControlSuppliers.ViewedType = typeof(KitSuppliersRelation);
			dataGridViewControlSuppliers.SetItemsArray((ICommonCollection) _currentModel.SupplierRelations);

			fileControlImage.UpdateInfo(_currentModel.ImageFile,
				"Image Files|*.jpg;*.jpeg;*.png",
				"This record does not contain a image. Enclose Image file to prove the compliance.",
				"Attached file proves the Image.");

            textBoxFullName.Text = _currentModel.FullName;
			textBoxShortName.Text = _currentModel.ShortName;

			if (_currentModel.Name.EndsWith("Copy"))
				_currentModel.Name = _currentModel.Name.Replace("Copy", "");

			textBoxName.Text = _currentModel.Name;
			textBoxDesigner.Text = _currentModel.Designer;
			textBoxPartNumber.Text = _currentModel.PartNumber;
			textBoxAltPartNum.Text = _currentModel.AltPartNumber;
			textBoxDescription.Text = _currentModel.Description;
			textBoxDescRus.Text = _currentModel.DescRus;
			textBoxHts.Text = _currentModel.HTS;
			textBoxRemarks.Text = _currentModel.Remarks;
			textBoxManufacturer.Text = _currentModel.Manufacturer;
			textBoxProductCode.Text = _currentModel.Code;
			textBoxSeries.Text = _currentModel.Series;

			checkBoxDangerous.Checked = _currentModel.IsDangerous;

			documentControl1.CurrentDocument = _currentModel.Document;
			documentControl1.Added += DocumentControl1_Added;
		}

		#endregion

		#region private void DocumentControl1_Added(object sender, EventArgs e)

		private void DocumentControl1_Added(object sender, EventArgs e)
		{
			var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("CMM") as DocumentSubType;
			var dep = GlobalObjects.CasEnvironment.GetDictionary<Department>().GetByFullName("Planning") as Department;
			var spec = GlobalObjects.CasEnvironment.GetDictionary<Specialization>().GetByFullName("Maintenance Data Librarian") as Specialization;
			var nomen = GlobalObjects.CasEnvironment.GetDictionary<Nomenclatures>().GetByFullName("e-library") as Nomenclatures;
			var location = GlobalObjects.CasEnvironment.GetDictionary<Locations>().GetByFullName("e-Server CIT") as Locations;
			var newDocument = new Document
			{
				Parent = _currentModel,
				ParentId = _currentModel.ItemId,
				ParentTypeId = _currentModel.SmartCoreObjectType.ItemId,
				DocType = DocumentType.TechnicalPublication,
				DocumentSubType = docSubType,
				Department = dep,
				ResponsibleOccupation = spec,
				Nomenсlature = nomen,
				Location = location
			};

			var form = new DocumentForm(newDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
			{
				_currentModel.Document = newDocument;
				documentControl1.CurrentDocument = newDocument;

			}
		}

		#endregion

		#region protected override bool GetChangeStatus()
		///<summary>
		///</summary>
		///<returns></returns>
		protected override bool GetChangeStatus()
		{
			if (textBoxFullName.Text != _currentModel.FullName
				|| textBoxShortName.Text != _currentModel.ShortName
				|| textBoxName.Text != _currentModel.Name
				|| textBoxDesigner.Text != _currentModel.Designer
				|| textBoxPartNumber.Text != _currentModel.PartNumber
				|| textBoxAltPartNum.Text != _currentModel.AltPartNumber
				|| textBoxDescription.Text != _currentModel.Description
				|| textBoxDescRus.Text != _currentModel.DescRus
				|| textBoxHts.Text != _currentModel.HTS
				|| textBoxRemarks.Text != _currentModel.Remarks
				|| textBoxManufacturer.Text != _currentModel.Manufacturer
				|| textBoxProductCode.Text != _currentModel.Code
				|| textBoxSeries.Text != _currentModel.Series
				|| comboBoxManufRegion.SelectedItem != _currentModel.ManufactureReg
				|| comboBoxAccessoryStandard.SelectedItem != _currentModel.Standart
				|| comboBoxAtaChapter.ATAChapter != _currentModel.ATAChapter
				|| (comboBoxDetailClass.SelectedItem != _currentModel.GoodsClass)
				|| (checkBoxDangerous.Checked != _currentModel.IsDangerous)
				|| dataGridViewControlSuppliers.GetChangeStatus()
				|| fileControlImage.GetChangeStatus())
				return true;

			if (_currentModel.SupplierRelations.Any(sr => sr.ItemId < 0))
				return true;
			return false;
		}
		#endregion

		#region protected override void SetFormControls()

		protected override void SetFormControls()
		{

		}

		#endregion

		#region protected override public ValidateData(out string message)
		/// <summary>
		/// Возвращает значение, показывающее является ли значение элемента управления допустимым
		/// </summary>
		/// <returns></returns>
		protected override bool ValidateData(out string message)
		{
			message = "";

			string validateFiles;
			if (!fileControlImage.ValidateData(out validateFiles))
			{
				if (message != "") message += "\n ";
				message += "Image File: " + validateFiles;
			}

			if (textBoxPartNumber.Text == "" &&
				comboBoxAccessoryStandard.Text == "" &&
				comboBoxAccessoryStandard.SelectedItem == null)
			{
				if (message != "") message += "\n ";
				message += "Not set Standart or Part Number";
				return false;
			}
			if (textBoxName.Text == "")
			{
				if (message != "") message += "\n ";
				message += "Not set Name";
				return false;
			}
			if (textBoxManufacturer.Text == ""
				&& dataGridViewControlSuppliers.Count == 0)
			{
				if (message != "") message += "\n ";
				message += "Not set Manufacturer or Suppliers";
				return false;
			}

			string m;
			if (!dataGridViewControlSuppliers.ValidateData(out m))
			{
				if (message != "") message += "\n ";
				message += m;
				return false;
			}

			return true;
		}

		#endregion

		#region protected override bool ApplyChanges()
		///<summary>
		///</summary>
		///<returns></returns>
		protected override void ApplyChanges()
		{
			_currentModel.GoodsClass = comboBoxDetailClass.SelectedItem as GoodsClass;
			_currentModel.Standart = comboBoxAccessoryStandard.SelectedItem as GoodStandart;
			_currentModel.ATAChapter = comboBoxAtaChapter.ATAChapter;
			_currentModel.IsDangerous = checkBoxDangerous.Checked;
			_currentModel.ManufactureReg = comboBoxManufRegion.SelectedItem as ManufactureRegion;

			_currentModel.PartNumber = string.IsNullOrEmpty(textBoxPartNumber.Text) ? "N/A" : textBoxPartNumber.Text;
			_currentModel.AltPartNumber = string.IsNullOrEmpty(textBoxAltPartNum.Text) ? "N/A" : textBoxAltPartNum.Text;
			_currentModel.FullName = textBoxFullName.Text;
			_currentModel.ShortName = textBoxShortName.Text;
			_currentModel.Name = textBoxName.Text;
			_currentModel.Designer = textBoxDesigner.Text;
			_currentModel.Description = textBoxDescription.Text;
			_currentModel.DescRus = textBoxDescRus.Text;
			_currentModel.HTS = textBoxHts.Text;
			_currentModel.Remarks = textBoxRemarks.Text;
			_currentModel.Manufacturer = textBoxManufacturer.Text;
			_currentModel.Code = textBoxProductCode.Text;
			_currentModel.Series = textBoxSeries.Text;

			dataGridViewControlSuppliers.ApplyChanges();

			fileControlImage.ApplyChanges();
			_currentModel.ImageFile = fileControlImage.AttachedFile;

            _currentModel.SupplierRelations.Clear();
			_currentModel.SupplierRelations.AddRange(dataGridViewControlSuppliers.GetItemsArray());
		}
		#endregion

		#region protected override void AbortChanges()
		protected override void AbortChanges()
		{
			try
			{
				if (_currentModel.ItemId <= 0)
				{
					foreach (KitSuppliersRelation relation in _currentModel.SupplierRelations)
					{
						GlobalObjects.CasEnvironment.Manipulator.Delete(relation, false);
					}
				}
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save consumable part", ex);
			}
		}
		#endregion

		#region protected override void Save()
		protected override void Save()
		{
			try
			{
				GlobalObjects.CasEnvironment.Manipulator.Save(_currentModel);

				foreach (KitSuppliersRelation ksr in _currentModel.SupplierRelations)
				{
					if (ksr.SupplierId != 0)
					{
						ksr.KitId = _currentModel.ItemId;
						ksr.ParentTypeId = _currentModel.SmartCoreObjectType.ItemId;

						try
						{
							GlobalObjects.CasEnvironment.NewKeeper.Save(ksr);
						}
						catch (Exception ex)
						{
							Program.Provider.Logger.Log("Error while saving data", ex);
							return;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while saving data", ex);
			}
		}
		#endregion
	}
}
