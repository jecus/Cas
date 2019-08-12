using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace CAS.UI.UIControls.Auxiliary
{
	/// <summary>
	/// Форма для переноса шаблона ВС в рабочую базу данных
	/// </summary>
	public partial class CommonDeletingForm : MetroForm
	{
		#region Fields
		/// <summary>
		/// Колекция объектов, в которых будет производится удаление
		/// </summary>
		private readonly ICommonCollection _deletingObjects;
		/// <summary>
		/// Колекция удаленных объектов
		/// </summary>
		private readonly ICommonCollection _deletedObjects = new CommonCollection<BaseEntityObject>();
		private readonly Type _type;

		private readonly List<ColumnHeader> _columnHeaderList = new List<ColumnHeader>();

		private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
		
		#endregion

		#region Constructors

		#region private CommonDeletingForm()

		/// <summary>
		/// Создает форму для переноса шаблона ВС в рабочую базу данных
		/// </summary>
		private CommonDeletingForm()
		{
			InitializeComponent();
		}

		#endregion

		#region public CommonDeletingForm(BaseSmartCoreObject editingObjects) : this()
		/// <summary>
		/// Создает форму для редактирования переданного объекта
		/// </summary>
		public CommonDeletingForm(Type type, ICommonCollection editingObjects) : this()
		{
			if(editingObjects == null)
				throw new ArgumentNullException("editingObjects", "can not be null");
			_deletingObjects = editingObjects;
			_type = type;

			SetHeaders();

			_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
			_animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;

			_animatedThreadWorker.RunWorkerAsync();
		}

		#endregion
	 
		#endregion

		#region Properties

		///<summary>
		/// Возвращает коллекцию удаленных объектов или null
		///</summary>
		public ICommonCollection DeletedObjects
		{
			get { return _deletedObjects; }
		}
		#endregion

		#region Methods

		#region private void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		private void SetHeaders()
		{
			List<PropertyInfo> properties = GetTypeProperties();
			int sum = 0;
			_columnHeaderList.Clear();
			ColumnHeader columnHeader;
			foreach (PropertyInfo propertyInfo in properties)
			{
				FormControlAttribute attr =
					(FormControlAttribute)propertyInfo.GetCustomAttributes(typeof(FormControlAttribute), false)[0];
				columnHeader = new ColumnHeader();
				columnHeader.Width = attr.Width;
				columnHeader.Text = attr.Title;
				columnHeader.Tag = propertyInfo.PropertyType;
				_columnHeaderList.Add(columnHeader);
				if(sum + attr.Width > listViewMain.Width && 
				   sum + attr.Width <= listViewMain.MaximumSize.Width)
				{
					sum += attr.Width;
					listViewMain.Width = sum;
				}
			}
			listViewMain.Columns.AddRange(_columnHeaderList.ToArray());
		}
		#endregion

		#region private List<PropertyInfo> GetTypeProperties()

		private List<PropertyInfo> GetTypeProperties()
		{
			if (_type == null) return new List<PropertyInfo>();
			//определение своиств, имеющих атрибут "отображаемое в списке"
			List<PropertyInfo> properties =
				_type.GetProperties().Where(p => p.GetCustomAttributes(typeof(FormControlAttribute), false).Length != 0).ToList();

			//поиск своиств у которых задан порядок отображения
			//своиства, имеющие порядок отображения
			Dictionary<int, PropertyInfo> orderedProperties = new Dictionary<int, PropertyInfo>();
			//своиства, НЕ имеющие порядок отображения
			List<PropertyInfo> unOrderedProperties = new List<PropertyInfo>();
			foreach (PropertyInfo propertyInfo in properties)
			{
				FormControlAttribute lvda = (FormControlAttribute)
					propertyInfo.GetCustomAttributes(typeof(FormControlAttribute), false).FirstOrDefault();
				if (lvda.Order > 0) orderedProperties.Add(lvda.Order, propertyInfo);
				else unOrderedProperties.Add(propertyInfo);
			}

			var ordered = orderedProperties.OrderBy(p => p.Key).ToList();

			properties.Clear();
			properties.AddRange(ordered.Select(keyValuePair => keyValuePair.Value));
			properties.AddRange(unOrderedProperties);

			return properties;

		}
		#endregion

		#region protected virtual ListViewItem.ListViewSubItem[] GetItemsString(BaseSmartCoreObject item)

		protected virtual ListViewItem.ListViewSubItem[] GetListViewSubItems(BaseEntityObject item)
		{
			List<PropertyInfo> properties = GetTypeProperties();

			ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[properties.Count];
			for (int i = 0; i < properties.Count; i++)
			{
				object value = properties[i].GetValue(item, null);
				if (value != null)
				{
					string valueString;
					if (value is DateTime)
						valueString = SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)value);
					else valueString = value.ToString();


					subItems[i] = new ListViewItem.ListViewSubItem
					{
						Text = valueString,
						Tag = value
					};
				}
				else
				{
					subItems[i] = new ListViewItem.ListViewSubItem
					{
						Text = "",
						Tag = ""
					};
				}
			}
			return subItems;
		}

		#endregion

		#region private bool ValidateData(out string message)
		/// <summary>
		/// Возвращает значение, показывающее является ли значение элемента управления допустимым
		/// </summary>
		/// <returns></returns>
		private bool ValidateData(out string message)
		{
			message = "";
			return true;
		}

		#endregion

		#region private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
		private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Text = string.Format("{0}s Deleting Form", _type.Name);

			listViewMain.Items.Clear();

			if (_deletingObjects == null) return;

			foreach (BaseEntityObject o in _deletingObjects)
			{
				ListViewItem listViewItem = new ListViewItem(GetListViewSubItems(o), null) { Tag = o };
				listViewMain.Items.Add(listViewItem);
			}
		}
		#endregion

		#region private void BackgroundWorkerRunWorkerCreateCompleted(object sender, RunWorkerCompletedEventArgs e)
		private void BackgroundWorkerRunWorkerCreateCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}
		#endregion

		#region private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
		private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
		{
			_animatedThreadWorker.ReportProgress(0, "load templates");

			_animatedThreadWorker.ReportProgress(100, "binding complete");
		}
		#endregion

		#region private void AnimatedThreadWorkerDoCreate(object sender, DoWorkEventArgs e)
		private void AnimatedThreadWorkerDoCreate(object sender, DoWorkEventArgs e)
		{
			_animatedThreadWorker.ReportProgress(0, "Create aircraft from template");

			foreach (BaseEntityObject directive in _deletedObjects)
			{
				try
				{
					if(directive is Aircraft)
						GlobalObjects.AircraftsCore.DeleteAircraft(directive.ItemId);
					else
						GlobalObjects.CasEnvironment.Manipulator.Delete(directive);
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while deleting data", ex);
					return;
				}
			}
			_animatedThreadWorker.ReportProgress(100, "Create Complete");
		}
		#endregion

		#region private void buttonCancel_Click(object sender, EventArgs e)

		private void ButtonCancelClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion

		#region private void ButtonCreateAircraftClick(object sender, EventArgs e)

		private void ButtonCreateAircraftClick(object sender, EventArgs e)
		{
			if (listViewMain.SelectedItems.Count == 0) return;

			string message;
			if (!ValidateData(out message))
			{
				message += "\nAbort operation";
				MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
								MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			string typeName = _type.Name;

			DialogResult confirmResult =
				MessageBox.Show(listViewMain.SelectedItems.Count == 1
						? "Do you really want to delete " + typeName + " " + listViewMain.SelectedItems[0].Tag + "?"
						: "Do you really want to delete selected " + typeName + "s?", "Confirm delete operation",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

			if (confirmResult == DialogResult.Yes)
			{
				_deletedObjects.Clear();

				foreach (ListViewItem directive in listViewMain.SelectedItems)
				{
					_deletedObjects.Add((BaseEntityObject)directive.Tag);
				}

				_animatedThreadWorker.DoWork -= AnimatedThreadWorkerDoLoad;
				_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoCreate;
				_animatedThreadWorker.RunWorkerCompleted -= BackgroundWorkerRunWorkerLoadCompleted;
				_animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerCreateCompleted;
				_animatedThreadWorker.RunWorkerAsync();
			}
		}
		#endregion

		#region private void ListViewMainSelectedIndexChanged(object sender, EventArgs e)
		private void ListViewMainSelectedIndexChanged(object sender, EventArgs e)
		{
			buttonDelete.Enabled = listViewMain.SelectedItems.Count > 0;
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

		#endregion
	}
}