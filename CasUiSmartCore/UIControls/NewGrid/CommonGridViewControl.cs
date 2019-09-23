using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;
using CellFormattingEventArgs = Telerik.WinControls.UI.CellFormattingEventArgs;

namespace CAS.UI.UIControls.NewGrid
{
	public partial class CommonGridViewControl : UserControl
	{
		#region Fields
		private Type _viewedType;
		//заголовки списка
		protected readonly List<GridViewDataColumn> ColumnHeaderList = new List<GridViewDataColumn>();
		//коллекция выделенных элементов
		private readonly List<BaseEntityObject> _items = new List<BaseEntityObject>();
		private RadDropDownMenu _customMenu;

		protected ICommonCollection _selectedItemsList;

		#endregion

		#region Properties

		#region public Type ViewedType
		/// <summary>
		/// Тип, объекты которого будут отображаться в списке
		/// </summary>
		public Type ViewedType
		{
			get { return _viewedType; }
			set
			{
				#region Проверка типа
				if (value == null)
					throw new ArgumentNullException("value", "type must be not null");
				//Проверка, является ли переданный тип наследником BaseSmartCoreObject
				if (!value.IsSubclassOf(typeof(BaseEntityObject)))
				{
					//цикл прошел до низа иерархии и невстретил тип BaseSmartCoreObject
					//значит переданный тип не является его наследником
					throw new ArgumentNullException("value", "not inherit from " + typeof(BaseEntityObject).Name);
				}
				#endregion

				_viewedType = value;

				try
				{
					if (_selectedItemsList != null) _selectedItemsList.Clear();
					Type genericType = typeof(CommonCollection<>);
					Type genericList = genericType.MakeGenericType(_viewedType);
					_selectedItemsList = (ICommonCollection)Activator.CreateInstance(genericList);
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while building collection", ex);
					return;
				}

				try
				{
					FirstLoad();
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while building control", ex);
					return;
				}
			}
		}
		#endregion

		#region public Action MenuOpeningAction { get; set; }

		public Action MenuOpeningAction { get; set; }

		#endregion

		#region public RadDropDownMenu CustomMenu

		public RadDropDownMenu CustomMenu
		{
			get => _customMenu ?? (_customMenu = new RadDropDownMenu());
			set => _customMenu = value;
		}

		#endregion

		#region ItemsCount

		public int ItemsCount => radGridView1.Rows.Count;

		#endregion

		#region public List<T> SelectedItems
		/// <summary>
		/// Возвращает выбранные элементы
		/// </summary>
		public virtual ICommonCollection SelectedItems
		{
			get
			{
				if (_selectedItemsList == null)
					return null;

				_selectedItemsList.Clear();
				_selectedItemsList.AddRange(radGridView1.SelectedRows
					.Cast<GridViewDataRowInfo>()
					.Where(i => i.Tag != null && i.Tag is BaseEntityObject)
					.Select(i => i.Tag as BaseEntityObject)
					.ToArray());
				return _selectedItemsList;
			}
		}
		#endregion

		#region public T SelectedItem
		/// <summary>
		/// Выбранный элемент
		/// </summary>
		public virtual BaseEntityObject SelectedItem
		{
			get
			{
				if (radGridView1.CurrentRow != null)
					return (radGridView1.CurrentRow.Tag as BaseEntityObject);
				return null;
			}
		}
		#endregion

		#region public IDisplayer Displayer
		/// <summary>
		/// Displayer for displaying entity
		/// </summary>
		public IDisplayer Displayer { get; set; }

		#endregion

		#region public string DisplayerText { get; set;}
		/// <summary>
		/// Text of page's header that Reference lead to
		/// </summary>
		public string DisplayerText { get; set; }
		#endregion

		#region public IDisplayingEntity Entity

		/// <summary>
		/// Entity to display
		/// </summary>
		public IDisplayingEntity Entity { get; set; }

		#endregion

		#region public ReflectionTypes ReflectionType

		/// <summary>
		/// Type of reflection
		/// </summary>
		public ReflectionTypes ReflectionType { get; set; }

		#endregion

		#endregion

		#region Constructor

		public CommonGridViewControl()
		{
			InitializeComponent();
			SetupGridView();
		}


		#endregion


		#region private void SetupGridView()

		private void SetupGridView()
		{
			radGridView1.SelectionMode = GridViewSelectionMode.FullRowSelect;
			radGridView1.MultiSelect = true;

			radGridView1.EnableFiltering = true;
			radGridView1.MasterTemplate.ShowHeaderCellButtons = true;
			radGridView1.MasterTemplate.ShowFilteringRow = false;

			this.radGridView1.AllowSearchRow = true;
		}

		#endregion

		#region protected virtual void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected virtual void SetHeaders()
		{
			var properties = GetTypeProperties();

			radGridView1.Columns.Clear();
			GridViewDataColumn columnHeader;
			foreach (var propertyInfo in properties)
			{
				var attr = (ListViewDataAttribute)propertyInfo.GetCustomAttributes(typeof(ListViewDataAttribute), false)[0];
				if (propertyInfo.PropertyType == typeof(DateTime))
					columnHeader = new GridViewDateTimeColumn(attr.Title) { FormatString = "{0:dd.MM.yyyy}" };
				else columnHeader = new GridViewBrowseColumn(attr.Title);
				columnHeader.Width = attr.HeaderWidth > 1 ? (int)attr.HeaderWidth : ((int)(radGridView1.Width * attr.HeaderWidth) * 2);
				columnHeader.Tag = propertyInfo.PropertyType;

				ColumnHeaderList.Add(columnHeader);
			}
		}
		#endregion

		#region private List<PropertyInfo> GetTypeProperties()
		/// <summary>
		/// Получает свойства типа, на основе которых будут созданы колонки 
		/// </summary>
		/// <returns></returns>
		protected virtual List<PropertyInfo> GetTypeProperties()
		{
			if (_viewedType == null)
				throw new NullReferenceException("_viewedType is null");
			//определение своиств, имеющих атрибут "отображаемое в списке"
			var properties =
				_viewedType.GetProperties().Where(p => p.GetCustomAttributes(typeof(ListViewDataAttribute), false).Length != 0).ToList();

			//поиск своиств у которых задан порядок отображения
			//своиства, имеющие порядок отображения
			var orderedProperties = new Dictionary<int, PropertyInfo>();
			//своиства, НЕ имеющие порядок отображения
			var unOrderedProperties = new List<PropertyInfo>();
			foreach (var propertyInfo in properties)
			{
				var lvda = (ListViewDataAttribute)
					propertyInfo.GetCustomAttributes(typeof(ListViewDataAttribute), false).FirstOrDefault();
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

		public virtual void SetItemsArray(IEnumerable<BaseEntityObject> itemsArray)
		{
			if(itemsArray == null)
				throw new ArgumentNullException("itemsArray", "itemsArray can't be null");
			//очищение предварительной коллекции элементов
			_items.Clear();
			_items.AddRange(itemsArray);
			radGridView1.Rows.Clear();

			try
			{
				AddItems(itemsArray);
				SetItemsColor();
				SetTotalText();

				radGridView1.MasterTemplate.ExpandAllGroups();

				radGridView1.RowFormatting += RadGridView1_RowFormatting;
				radGridView1.CellFormatting += RadGridView1_CellFormatting;
				radGridView1.FilterChanged += RadGridView1_FilterChanged;

			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while deleting data", ex);
				return;
			}
		}

		private void RadGridView1_FilterChanged(object sender, GridViewCollectionChangedEventArgs e)
		{
			label1.Text = "Total: " + e.GridViewTemplate.ChildRows.Count;
		}

		private void RadGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			if (e.CellElement.Value != null)
			{
				e.CellElement.ToolTipText = e.CellElement.Value.ToString();
			}
		}

		#region public virtual void InsertItems(T[] itemsArray)
		/// <summary>
		/// Добавляет элементы в начало ListView
		/// </summary>
		/// <param name="itemsArray"></param>
		public virtual void InsertItems(List<BaseEntityObject> itemsArray)
		{
			if (itemsArray.Count == 0)
				return;

			_items.AddRange(itemsArray);

			var temp = new List<GridViewDataRowInfo>();
			foreach (var item in itemsArray)
			{
				var i = 0;
				var rowInfo = new GridViewDataRowInfo(this.radGridView1.MasterView) { AllowResize = true };
				rowInfo.Tag = item;

				foreach (var cell in GetListViewSubItems(item))
				{
					rowInfo.Cells[i].Value = cell;

					if (cell.ForeColor.HasValue)
						rowInfo.Cells[i].Style.ForeColor = cell.ForeColor.Value;

					i++;
				}
				temp.Add(rowInfo);
			}

			radGridView1.BeginUpdate();
			radGridView1.Rows.AddRange(temp.ToArray());
			radGridView1.EndUpdate();

			SetItemsColor();
			SetTotalText();
		}

		#endregion

		#region public virtual T[] GetItemsArray()
		/// <summary>
		/// Метод возвращает массив директив
		/// </summary>
		/// <returns>Массив директив</returns>
		public virtual ICommonCollection GetItemsArray()
		{
			try
			{
				Type genericType = typeof(CommonCollection<>);
				Type genericList = genericType.MakeGenericType(_viewedType);
				ICommonCollection returnDetailArray = (ICommonCollection)Activator.CreateInstance(genericList);
				if (ItemsCount > 0)
				{
					for (int i = 0; i < ItemsCount; i++)
					{
						returnDetailArray.Add(_items[i]);
					}
				}
				return returnDetailArray;
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while building collection", ex);
				return null;
			}
		}
		#endregion

		#region public CustomCell CreateRow(string text, object tag)

		public CustomCell CreateRow(string text, object tag, Color? foreColor = null)
		{
			return new CustomCell()
			{
				Text = text ?? "",
				Tag = tag,
				ForeColor = foreColor
			};
		}

		#endregion

		#region private void AddItems(T[] itemsArray)
		/// <summary>
		/// Добавляет элементы в ListView
		/// </summary>
		/// <param name="itemsArray"></param>
		private void AddItems(IEnumerable<BaseEntityObject> itemsArray)
		{
			try
			{
				var temp = new List<GridViewDataRowInfo>();
				foreach (var item in itemsArray)
				{
					var i = 0;
					var rowInfo = new GridViewDataRowInfo(this.radGridView1.MasterView){AllowResize = true};
					rowInfo.Tag = item;

					foreach (var cell in GetListViewSubItems(item))
					{
						if (cell != null)
							cell.Text = cell.Text.Replace("\n", "");

						if (rowInfo.Cells[i].ColumnInfo is GridViewDateTimeColumn)
							rowInfo.Cells[i].Value = cell.Tag;
						else
							rowInfo.Cells[i].Value = cell;

						if (cell.ForeColor.HasValue)
							rowInfo.Cells[i].Style.ForeColor = cell.ForeColor.Value;

						i++;
					}
					temp.Add(rowInfo);
				}

				radGridView1.BeginUpdate();
				radGridView1.Rows.AddRange(temp.ToArray());
				radGridView1.EndUpdate();
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log(ex);
			}
		}

		#endregion

		#region protected List<CustomCell> GetListViewSubItems(T item)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		protected virtual List<CustomCell> GetListViewSubItems(BaseEntityObject item)
		{
			var properties = GetTypeProperties();

			var subItems = new List<CustomCell>();
			foreach (var property in properties)
			{
				var value = property.GetValue(item, null);
				if (value != null)
				{
					if (property.Name == "CorrectorId")
						value = GlobalObjects.CasEnvironment.GetCorrector(item);

					string valueString;
					if (value is DateTime)
						valueString = SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)value);
					else if (value is double)
						valueString = ((double)value).ToString("F");
					else valueString = value.ToString();

					subItems.Add(new CustomCell()
					{
						Text = valueString,
						Tag = value
					});
				}
				else
				{
					subItems.Add(new CustomCell()
					{
						Text = "",
						Tag = ""
					});
				}
			}
			return subItems;
		}

		#endregion

		#region private void SetItemsColor()
		private void SetItemsColor()
		{
			foreach (var item in radGridView1.Rows)
				SetItemColor(item, (BaseEntityObject)item.Tag);
		}
		#endregion

		#region protected virtual void SetItemColor(GridViewRowInfo listViewItem, T item)
		protected virtual void SetItemColor(GridViewRowInfo listViewItem, BaseEntityObject item)
		{
			var imd = item as IDirective;
			if (imd == null) return;

			foreach (GridViewCellInfo cell in listViewItem.Cells)
			{
				cell.Style.CustomizeFill = true;

				if (imd.NextPerformanceIsBlocked)
				{
					cell.Style.BackColor = Color.FromArgb(Highlight.Grey.Color);
					//cell.Style.ToolTipText = "This performance is involved on Work Package:" + imd.NextPerformances[0].BlockedByPackage.Title;
				}
				else
				{
					if (imd.Condition == ConditionState.Overdue)
						cell.Style.BackColor = Color.FromArgb(Highlight.Red.Color);
					if (imd.Condition == ConditionState.Notify)
						cell.Style.BackColor = Color.FromArgb(Highlight.Yellow.Color);
					if (imd.Condition == ConditionState.NotEstimated)
						cell.Style.BackColor = Color.FromArgb(Highlight.Blue.Color);
				}
			}
		}
		#endregion

		#region private void SetTotalText()
		/// <summary>
		/// Устанавивает информацию об общем количестве элементов в нижней панели
		/// </summary>
		private void SetTotalText()
		{
			label1.Text = "Total: " + radGridView1.Rows.Count;
		}

		#endregion

		#region private void Load()

		private void FirstLoad()
		{
			try
			{
				SetHeaders();
				radGridView1.Columns.AddRange(ColumnHeaderList.ToArray());
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while building control", ex);
				return;
			}
		}

		#endregion

		//Events
		#region private void RadGridView1_GroupSummaryEvaluate(object sender, Telerik.WinControls.UI.GroupSummaryEvaluationEventArgs e)

		private void RadGridView1_GroupSummaryEvaluate(object sender, GroupSummaryEvaluationEventArgs e)
		{
			if (e.Value is DateTime)
				e.FormatString = $"{((DateTime)e.Value):dd.MM.yyyy}";
			else e.FormatString = e.Value.ToString();
		}

		#endregion


		#region private void RadGridView1_ContextMenuOpening(object sender, Telerik.WinControls.UI.ContextMenuOpeningEventArgs e)

		private void RadGridView1_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
		{
			var cellElement = e.ContextMenuProvider as GridCellElement;
			if (cellElement == null || cellElement.RowInfo is GridViewFilteringRowInfo || cellElement.RowInfo is GridViewTableHeaderRowInfo)
				return;

			MenuOpeningAction?.Invoke();
			e.ContextMenu = _customMenu;
		}

		#endregion

		#region private void RadGridView1_RowFormatting(object sender, RowFormattingEventArgs e)

		//Колхоз но по другому не знаю как сделать что бы при выделении цвет менял
		public void RadGridView1_RowFormatting(object sender, RowFormattingEventArgs e)
		{
			if (e.RowElement.IsSelected)
			{
				foreach (GridViewCellInfo gridViewCellInfo in e.RowElement.RowInfo.Cells)
					gridViewCellInfo.Style.CustomizeFill = false;
			}
			else SetItemColor(e.RowElement.RowInfo, (BaseEntityObject)e.RowElement.RowInfo.Tag);
		}

		#endregion

		#region private void RadGridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)

		private void RadGridView1_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyData)
			{
				case Keys.Enter:
					if (SelectedItem != null)
					{
						if(DisplayerRequested != null)
							OnDisplayerRequested();
						else RadGridView1_DoubleClick(sender, e);
					}
					break;
				case Keys.Escape: radGridView1.FilterDescriptors.Clear(); break;
				default:
					break;
			}
		}

		#endregion

		#region public event EventHandler<ReferenceEventArgs> DisplayerRequested
		/// <summary>
		/// Событие, воздуждаемое при необходимости отобразть что-то в новой/текущей вкладке  
		/// </summary>
		public event EventHandler<ReferenceEventArgs> DisplayerRequested;

		#endregion

		#region private void RadGridView1_DoubleClick(object sender, System.EventArgs e)

		protected  virtual void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			OnDisplayerRequested();
		}

		#endregion

		#region protected void OnDisplayerRequested()
		/// <summary>
		/// Метод, возбуждающий событие DisplayerRequested
		/// </summary>
		protected void OnDisplayerRequested()
		{
			if (SelectedItem == null)
				return;

			var form = ScreenAndFormManager.GetEditForm(SelectedItem);
			if (form == null)
				return;

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				var subs = GetListViewSubItems(SelectedItem);
				for (int i = 0; i < subs.Count; i++)
					radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
			}
		}

		#endregion

		#region public event EventHandler<SelectedItemsChangeEventArgs> SelectedItemsChanged;
		/// <summary>
		/// Событие возникающее при изменении массива выбранных элементов в списке.
		/// </summary>
		public event EventHandler<SelectedItemsChangeEventArgs> SelectedItemsChanged;
		#endregion

		#region private void RadGridView1_SelectionChanged(object sender, System.EventArgs e)

		private void RadGridView1_SelectionChanged(object sender, EventArgs e)
		{
			if (SelectedItemsChanged != null)
				SelectedItemsChanged.Invoke(this, new SelectedItemsChangeEventArgs(_selectedItemsList.Count));
		}

		#endregion

		#region protected virtual void FillDisplayerRequestedParams(ReferenceEventArgs e)

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected virtual void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			e.DisplayerText = _viewedType.Name;
			e.RequestedEntity = new CommonListScreen(_viewedType);
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
		}
		#endregion

		#region Export

		private void RadButton1_Click(object sender, EventArgs e)
		{
			var sfd = new SaveFileDialog();
			sfd.Filter = ".xlsx Files (*.xlsx)|*.xlsx";

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				var spreadStreamExport = new GridViewSpreadStreamExport(radGridView1);
				spreadStreamExport.ExportVisualSettings = true;
				spreadStreamExport.FreezeHeaderRow = true;
				spreadStreamExport.CellFormatting += SpreadStreamExport_CellFormatting;
				spreadStreamExport.RunExport(sfd.FileName, new SpreadStreamExportRenderer());
			}

		}

		private void SpreadStreamExport_CellFormatting(object sender, SpreadStreamCellFormattingEventArgs e)
		{
			e.CellStyleInfo.LeftBorder = Color.Black;
			e.CellStyleInfo.RightBorder = Color.Black;
			e.CellStyleInfo.BottomBorder = Color.Black;
			e.CellStyleInfo.TopBorder = Color.Black;
		}

		#endregion
	}
}
