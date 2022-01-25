using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CASTerms;
using Microsoft.VisualBasic.Devices;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using Telerik.WinControls.Data;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;
using Component = SmartCore.Entities.General.Accessory.Component;

namespace CAS.UI.UIControls.NewGrid
{
	public enum SortDirection
	{
		Asc = -1,
		Desc = 1
	}
	public partial class BaseGridViewControl<T> : UserControl, IReference where T : class, IBaseCoreObject, IBaseEntityObject
	{
		#region Fields

		//заголовки списка
		protected readonly List<GridViewDataColumn> ColumnHeaderList = new List<GridViewDataColumn>();
		//коллекция выделенных элементов
		private readonly List<T> _selectedItemsList = new List<T>();
		protected readonly List<T> _items = new List<T>();


		private RadDropDownMenu _customMenu;
		private RadMenuItem _toolStripMenuItemCopy;
		private RadMenuItem _toolStripMenuItemCopyWithoutMark;
		private RadMenuItem _toolStripMenuItemPaste;
		private RadMenuItem _toolStripMenuItemDelete;
		private RadMenuSeparatorItem _separator;
		private bool _clickHeader;
		private bool _addBaseMenu = true;

		#endregion

		#region Properties

		#region public bool EnableCustomSorting

		public bool EnableCustomSorting
		{
			get => radGridView1.EnableCustomSorting;
			set => radGridView1.EnableCustomSorting = value;
		}

		#endregion

		#region public Action MenuOpeningAction { get; set; }

		public Action MenuOpeningAction { get; set; }

		#endregion

		#region public Action PasteComplete { get; set; }

		public Action<List<T>> ConfigurePaste{ get; set; }
		public Action<List<T>> PasteComplete { get; set; }

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
		public List<T> SelectedItems
		{
			get
			{
				if (_selectedItemsList == null)
					return null;

				_selectedItemsList.Clear();
				_selectedItemsList.AddRange(radGridView1.SelectedRows
					.Cast<GridViewDataRowInfo>()
					.Where(i => i.Tag != null && i.Tag is T)
					.Select(i => i.Tag as T)
					.ToArray());
				return _selectedItemsList;
			}
		}
		#endregion

		#region public T SelectedItem
		/// <summary>
		/// Выбранный элемент
		/// </summary>
		public T SelectedItem
		{
			get
			{
				if (radGridView1.CurrentRow != null)
					return (radGridView1.CurrentRow.Tag as T);
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

		public bool IgnoreEnterPress { get; set; }

		public SortDirection SortDirection { get; set; }

		public int OldColumnIndex { get; set; }
		public List<string> ColumnIndexes { get; set; }

		#endregion

		#region Constructor

		public BaseGridViewControl()
		{
			InitializeComponent();
			SetupGridView();
			InitListView();
			FirstLoad();
		}

		#endregion

		#region private void InitListView()

		public void DisableContectMenu()
		{
			_customMenu.Items.Remove(_toolStripMenuItemCopy);
			_customMenu.Items.Remove(_toolStripMenuItemCopyWithoutMark);
			_customMenu.Items.Remove(_toolStripMenuItemDelete);
			_customMenu.Items.Remove(_toolStripMenuItemPaste);
			_customMenu.Items.Remove(_separator);
			_addBaseMenu = false;
		}

		public void AddMenuItems(params RadMenuItemBase[] items)
		{
			_customMenu.Items.Clear();
			_customMenu.Items.AddRange(items);

			if (!_addBaseMenu)
				return;

			
			_customMenu.Items.AddRange(_toolStripMenuItemDelete,
				new RadMenuSeparatorItem(),
				_toolStripMenuItemCopyWithoutMark,
				_toolStripMenuItemCopy,
				_toolStripMenuItemPaste
			);
		}

		private void InitListView()
		{
			_customMenu = new RadDropDownMenu();
			_toolStripMenuItemDelete = new RadMenuItem();
			_separator = new RadMenuSeparatorItem();
			_toolStripMenuItemCopy = new RadMenuItem();
			_toolStripMenuItemCopyWithoutMark = new RadMenuItem();
			_toolStripMenuItemPaste = new RadMenuItem();

			// 
			// toolStripMenuItemDelete
			// 
			_toolStripMenuItemDelete.Text = "Delete";
			_toolStripMenuItemDelete.Click += ButtonDeleteClick;

			// 
			// toolStripMenuItemCopy
			// 
			_toolStripMenuItemCopy.Text = "Copy";
			_toolStripMenuItemCopy.Click += CopyItemsClick;
			// 
			// toolStripMenuItemCopy
			// 
			_toolStripMenuItemCopyWithoutMark.Text = "Copy without mark";
			_toolStripMenuItemCopyWithoutMark.Click += CopyWithoutMarkItemsClick;

			// 
			// toolStripMenuItemPaste
			// 
			_toolStripMenuItemPaste.Text = "Paste";
			_toolStripMenuItemPaste.Click += PasteItemsClick;

			_customMenu.Items.AddRange(new RadMenuSeparatorItem(),
				_toolStripMenuItemDelete,
				_separator,
				_toolStripMenuItemCopyWithoutMark,
				_toolStripMenuItemCopy,
				_toolStripMenuItemPaste 
			);


        }

        public virtual void PasteItemsClick(object sender, EventArgs e)
		{
			GetFromClipboard();
		}

		public virtual void CopyItemsClick(object sender, EventArgs e)
		{
			CopyToClipboard();
		}
		
		public virtual void CopyWithoutMarkItemsClick(object sender, EventArgs e)
		{
			CopyToClipboard(false);
		}

		public virtual void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (this.SelectedItems == null) return;

			var confirmResult = MessageBox.Show($"Do you really want to delete  {SelectedItems.Count} item(s)?", "Confirm delete operation",
														MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				var deletedItems = SelectedItems.OfType<BaseEntityObject>().ToList();
				foreach (var item in deletedItems)
					item.IsDeleted = true;

				if (deletedItems.Any(i => i is Component))
				{
					var components = deletedItems.Where(i => i is Component && !(i is BaseComponent)).Cast<Component>();
					var deleteCD = components.SelectMany(i => i.ComponentDirectives);
					if (components.Any())
					{
						GlobalObjects.NewKeeper.BulkUpdate(components.Cast<BaseEntityObject>().ToList());
						foreach (var item in components)
							radGridView1.Rows.Remove(radGridView1.Rows.FirstOrDefault(i => (i.Tag as BaseEntityObject).ItemId == item.ItemId));
					}

					if (deleteCD.Any())
					{
						GlobalObjects.NewKeeper.BulkUpdate(deleteCD.Cast<BaseEntityObject>().ToList()); 
						foreach (var item in deleteCD)
							radGridView1.Rows.Remove(radGridView1.Rows.FirstOrDefault(i => (i.Tag as BaseEntityObject).ItemId == item.ItemId));
					}
				}
				else
				{
					GlobalObjects.NewKeeper.BulkUpdate(deletedItems);
					foreach (var item in deletedItems)
						radGridView1.Rows.Remove(radGridView1.Rows.FirstOrDefault(i => (i.Tag as BaseEntityObject).ItemId == item.ItemId));
				}
				
				
			}
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
			EnableCustomSorting = true;
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
				if(propertyInfo.PropertyType == typeof(DateTime))
					columnHeader = new GridViewDateTimeColumn(attr.Title){ FormatString = "{0:dd.MM.yyyy}" };
				else columnHeader = new GridViewBrowseColumn(attr.Title);
				columnHeader.Width = attr.HeaderWidth > 1 ? (int)attr.HeaderWidth : (int)(radGridView1.Width * attr.HeaderWidth);
				columnHeader.Tag = propertyInfo.PropertyType;

				ColumnHeaderList.Add(columnHeader);
			}
		}
		#endregion

		#region public void AddColumn(string title, int? size = null)

		public void AddColumn(string title, int? size = null)
		{
			var col = new GridViewBrowseColumn(title);

			if (size.HasValue)
				col.Width = size.Value;
			else col.AutoSizeMode = BestFitColumnMode.DisplayedCells;

			ColumnHeaderList.Add(col);

		}

		public void AddDateColumn(string title, int? size = null)
		{
			var col = new GridViewDateTimeColumn(title)
			{
				FormatString = "{0:dd.MM.yyyy}"
			};

			if (size.HasValue)
				col.Width = size.Value;
			else col.AutoSizeMode = BestFitColumnMode.DisplayedCells;

			ColumnHeaderList.Add(col);

		}

		#endregion

		#region private List<PropertyInfo> GetTypeProperties()
		/// <summary>
		/// Получает свойства типа, на основе которых будут созданы колонки 
		/// </summary>
		/// <returns></returns>
		protected virtual List<PropertyInfo> GetTypeProperties()
		{
			//определение типа
			var type = typeof(T);
			//определение своиств, имеющих атрибут "отображаемое в списке"
			var properties =
				type.GetProperties().Where(p => p.GetCustomAttributes(typeof(ListViewDataAttribute), false).Length != 0).ToList();

			//поиск своиств у которых задан порядок отображения
			//своиства, имеющие порядок отображения
			var orderedProperties = new Dictionary<int, PropertyInfo>();
			//своиства, НЕ имеющие порядок отображения
			var unOrderedProperties = new List<PropertyInfo>();
			foreach (var propertyInfo in properties)
			{
				var lvda = (ListViewDataAttribute)
					propertyInfo.GetCustomAttributes(typeof(ListViewDataAttribute), false).First();
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

		#region public virtual void SetItemsArray(T[] itemsArray)

		public virtual void SetItemsArray(T[] itemsArray)
		{
			if(itemsArray == null)
				throw new ArgumentNullException("itemsArray", "itemsArray can't be null");
			//очищение предварительной коллекции элементов
			_items.Clear();
			_items.AddRange(itemsArray);
			radGridView1.Rows.Clear();

			try
			{
				if (!CheckHeders())
				{
					radGridView1.Columns.Clear();
					radGridView1.Columns.AddRange(ColumnHeaderList.ToArray());
				}

				this.radGridView1.GroupDescriptors.Clear();
				AddItems(itemsArray);
				UpdateItemColor();
				SetTotalText();
				GroupingItems();

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

		private bool CheckHeders()
		{
			for (int i = 0; i < ColumnHeaderList.Count; i++)
			{
				if(!ColumnHeaderList[i].HeaderText.Equals(radGridView1.Columns[i].HeaderText))
					return false;
			}

			return true;
		}

		private void RadGridView1_FilterChanged(object sender, GridViewCollectionChangedEventArgs e)
		{
			labelTotal.Text = "Total: " + e.GridViewTemplate.ChildRows.Count;
		}


		private void RadGridView1_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
		{
			if (e.CellElement.Value != null)
			{
				e.CellElement.ToolTipText = e.CellElement.Value.ToString();
			}
		}

		#endregion

		#region public virtual void InsertItems(T[] itemsArray)
		/// <summary>
		/// Добавляет элементы в начало ListView
		/// </summary>
		/// <param name="itemsArray"></param>
		public virtual void InsertItems(T[] itemsArray)
		{
			if (itemsArray.Length == 0)
				return;

			_items.InsertRange(0,itemsArray);

			var temp = new List<GridViewDataRowInfo>();
			foreach (var item in itemsArray)
			{
				var i = 0;
				var rowInfo = new GridViewDataRowInfo(this.radGridView1.MasterView) { AllowResize = true };
				rowInfo.Tag = item;

				foreach (var cell in GetListViewSubItems(item))
				{
					if(cell != null)
						cell.Text = cell.Text.Replace("\n", "");

					if (rowInfo.Cells[i].ColumnInfo is GridViewDateTimeColumn)
						rowInfo.Cells[i].Value = cell.Tag;
					else
						rowInfo.Cells[i].Value = cell;

					rowInfo.Cells[i].Tag = cell;

					if (cell.ForeColor.HasValue)
						rowInfo.Cells[i].Style.ForeColor = cell.ForeColor.Value;

					i++;
				}
				temp.Add(rowInfo);

				SetItemColor(rowInfo, (T)rowInfo.Tag);
				radGridView1.Rows.Insert(0, rowInfo);
			}

			//radGridView1.BeginUpdate();
			//radGridView1.Rows.AddRange(temp.ToArray());
			//radGridView1.EndUpdate();

			//UpdateItemColor();
			SetTotalText();
		}

		#endregion

		#region public virtual T[] GetItemsArray()
		/// <summary>
		/// Метод возвращает массив директив
		/// </summary>
		/// <returns>Массив директив</returns>
		public virtual T[] GetItemsArray()
		{
			return _items.ToArray();
		}
		#endregion

		#region public virtual void RemoveItems(T[] items)
		/// <summary>
		/// Метод возвращает массив директив
		/// </summary>
		/// <returns>Массив директив</returns>
		public virtual void RemoveItems(IEnumerable<T> items)
		{
			foreach (var item in items)
			{
				_items.Remove(item);
				radGridView1.Rows.Remove(radGridView1.Rows.FirstOrDefault(i => i.Tag == item));
			}
			
			SetTotalText();
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
		private void AddItems(T[] itemsArray)
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
						if(cell != null)
							cell.Text = cell.Text.Replace("\n", "");
						
						if (rowInfo.Cells[i].ColumnInfo is GridViewDateTimeColumn)
							rowInfo.Cells[i].Value = cell.Tag;
						else
							rowInfo.Cells[i].Value = cell;

						rowInfo.Cells[i].Tag = cell;

						if(cell.ForeColor.HasValue)
							rowInfo.Cells[i].Style.ForeColor = cell.ForeColor.Value;

						i++;
					}
					temp.Add(rowInfo);
				}


				if(EnableCustomSorting)
					SortingItems(temp);

				radGridView1.Rows.AddRange(temp.ToArray());
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
		protected virtual List<CustomCell> GetListViewSubItems(T item)
		{
			var properties = GetTypeProperties();

			var subItems = new List<CustomCell>();
			foreach (var property in properties)
			{
				var value = property.GetValue(item, null);
				if (value != null)
				{
					if (property.Name == "CorrectorId")
						value = GlobalObjects.CasEnvironment?.GetCorrector(item) ?? GlobalObjects.CaaEnvironment?.GetCorrector(item);

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

		#region public void UpdateItemColor()
		public void UpdateItemColor()
		{
			foreach (var item in radGridView1.Rows)
				SetItemColor(item, (T)item.Tag);
		}
		#endregion

		#region protected virtual void SetItemColor(GridViewRowInfo listViewItem, T item)
		protected virtual void SetItemColor(GridViewRowInfo listViewItem, T item)
		{
			var imd = item as IDirective;
			if (imd == null) return;

			foreach (GridViewCellInfo cell in listViewItem.Cells)
			{
				cell.Style.CustomizeFill = true;
				cell.Style.BackColor = Color.White;
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

		#region protected virtual void SetTotalText()
		/// <summary>
		/// Устанавивает информацию об общем количестве элементов в нижней панели
		/// </summary>
		protected virtual void SetTotalText()
		{
			labelTotal.Text = "Total: " + radGridView1.Rows.Count;
		}

		#endregion

		#region private void Load()

		private void FirstLoad()
		{
			try
			{
				ColumnHeaderList.Clear();
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

		#region Sorting

		private void SortingItems(List<GridViewDataRowInfo> temp)
		{
            if (ColumnIndexes!=null && ColumnIndexes.Any())
            {
                temp.Sort(new CodeComparer(Convert.ToInt32(SortDirection)));

            }
			else  temp.Sort(new GridViewDataRowInfoComparer(OldColumnIndex, Convert.ToInt32(SortDirection)));
		}


		protected virtual void CustomSort(int ColumnIndex)
		{

		}


		private void RadGridView1_CustomSorting(object sender, Telerik.WinControls.UI.GridViewCustomSortingEventArgs e)
		{
			if (ColumnIndexes!=null && ColumnIndexes.Any())
            {
                e.SortResult = new CodeComparer(Convert.ToInt32(SortDirection)).Compare(e.Row1, e.Row2);

            }
            else
				e.SortResult = new GridViewDataRowInfoComparer(OldColumnIndex, Convert.ToInt32(SortDirection)).Compare(e.Row1, e.Row2);
        }

		#endregion

		#region protected virtual void GroupingItems()

		protected virtual void GroupingItems()
		{
			Grouping();
		}

		#endregion

		#region public void Grouping(string colName = null)

		public void Grouping(string colName = null)
		{
			if (string.IsNullOrEmpty(colName))
				return;

			var radSortOrder = SortDirection == 0 ? ListSortDirection.Ascending : ListSortDirection.Descending;

			var descriptor = new GroupDescriptor();
			descriptor.GroupNames.Add(colName, radSortOrder);
			this.radGridView1.GroupDescriptors.Add(descriptor);
		}

		#endregion


		//Events

		#region private void RadGridView1_GroupSummaryEvaluate(object sender, Telerik.WinControls.UI.GroupSummaryEvaluationEventArgs e)

		private void RadGridView1_GroupSummaryEvaluate(object sender, GroupSummaryEvaluationEventArgs e)
		{
			if (e.Value is DateTime)
				e.FormatString = $"{((DateTime) e.Value):dd.MM.yyyy}";
			else e.FormatString = e.Value.ToString();
		}

		#endregion

		#region private void RadGridView1_ContextMenuOpening(object sender, Telerik.WinControls.UI.ContextMenuOpeningEventArgs e)

		private void RadGridView1_ContextMenuOpening(object sender, ContextMenuOpeningEventArgs e)
		{
			var cellElement = e.ContextMenuProvider as GridCellElement;
			if (cellElement == null || cellElement.RowInfo is GridViewFilteringRowInfo || cellElement.RowInfo is GridViewTableHeaderRowInfo)
				return;

			if(!_customMenu.Items.Any())
				e.Cancel = true;


			if (SelectedItems.Count <= 0)
			{
				_toolStripMenuItemPaste.Enabled = false;
				_toolStripMenuItemCopy.Enabled = false;
				_toolStripMenuItemDelete.Enabled = false;
			}
			else
			{
				_toolStripMenuItemPaste.Enabled = true;
				_toolStripMenuItemCopy.Enabled = true;
				_toolStripMenuItemDelete.Enabled = true;
			}

			if (SelectedItem is ComponentDirective)
				_toolStripMenuItemCopy.Enabled = _toolStripMenuItemPaste.Enabled = false;

			MenuOpeningAction?.Invoke();

			e.ContextMenu = _customMenu;
		}

		#endregion

		#region private void RadGridView1_RowFormatting(object sender, RowFormattingEventArgs e)

		//Колхоз но по другому не знаю как сделать что бы при выделении цвет менял
		private void RadGridView1_RowFormatting(object sender, RowFormattingEventArgs e)
		{
			if (e.RowElement.IsSelected)
			{
				foreach (GridViewCellInfo gridViewCellInfo in e.RowElement.RowInfo.Cells)
					gridViewCellInfo.Style.CustomizeFill = false;
			}
			else SetItemColor(e.RowElement.RowInfo, (T)e.RowElement.RowInfo.Tag);
		}

		#endregion

		#region private void RadGridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)

		private void RadGridView1_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyData)
			{
				case Keys.Enter:
					if (!IgnoreEnterPress && SelectedItem != null)
					{
						if(DisplayerRequested != null)
							OnDisplayerRequested();
						else RadGridView1_DoubleClick(sender, e);
					}
					break;
				case Keys.Escape: radGridView1.FilterDescriptors.Clear();break;
				case Keys.E: radGridView1.MasterTemplate.ExpandAllGroups(); break;
				case Keys.C: radGridView1.MasterTemplate.CollapseAllGroups(); break;
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

		protected void RadGridView1_DoubleClickBase(object sender, EventArgs e)
		{
			if(!_clickHeader)
				RadGridView1_DoubleClick(sender, e);
		}

		protected  virtual void RadGridView1_DoubleClick(object sender, EventArgs e)
		{
			OnDisplayerRequested();
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

		#region protected void OnDisplayerRequested()
		/// <summary>
		/// Метод, возбуждающий событие DisplayerRequested
		/// </summary>
		protected void OnDisplayerRequested()
		{
			if(SelectedItem == null)
				return;

			if (null != DisplayerRequested)
			{
				var reflection = ReflectionType;
				var k = new Keyboard();
				if (k.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent)
					reflection = ReflectionTypes.DisplayInNew;
				var e = null != Displayer ? new ReferenceEventArgs(Entity, reflection, Displayer, DisplayerText) : new ReferenceEventArgs(Entity, reflection, DisplayerText);
				try
				{
					FillDisplayerRequestedParams(e);
					DisplayerRequested(this, e);
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while opening record", ex);
				}
			}
		}

		#endregion

		#region protected virtual void FillDisplayerRequestedParams(ReferenceEventArgs e)

		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected virtual void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
		}
		#endregion

		#region private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)

		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			if (e.ColumnIndex > -1 && e.RowIndex == -1 && sender is GridHeaderCellElement &&
			    ((GridHeaderCellElement) sender).ZIndex != 0)
			{
				_clickHeader = true;
				if (!EnableCustomSorting)
				{
					OldColumnIndex = e.ColumnIndex;
					CustomSort(e.ColumnIndex);
				}
				else
				{
					if (OldColumnIndex != e.ColumnIndex)
						SortDirection = SortDirection.Asc;
					if (SortDirection == SortDirection.Desc)
						SortDirection = SortDirection.Asc;
					else
						SortDirection = SortDirection.Desc;

					OldColumnIndex = e.ColumnIndex;
				}
			}
			else _clickHeader = false;

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
				spreadStreamExport.RunExport(sfd.FileName,  new SpreadStreamExportRenderer());
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

		#region Copy/Paste
		
		public void CopyToClipboard(bool marked = true)
		{
			// регистрация формата данных либо получаем его, если он уже зарегистрирован
			try
			{
				if (SelectedItems == null || SelectedItems.Count == 0)
					return;

				var list = new List<T>();
				foreach (var obj in SelectedItems)
				{
					if (obj is Component newComponent)
					{
						list.Add(newComponent.GetCopyUnsaved(marked) as T);
					}
					else
					{
						var method = typeof(T).GetMethods().FirstOrDefault(i => i.Name == "GetCopyUnsaved");
						list.Add((T)method.Invoke(obj, new object[]{marked}));
					}
				}

				
				//todo:(EvgeniiBabak) Нужен другой способ проверки сереализуемости объекта
				using (MemoryStream mem = new MemoryStream())
				{
					BinaryFormatter bin = new BinaryFormatter();
					try
					{
						bin.Serialize(mem, list);
					}
					catch (Exception ex)
					{
						MessageBox.Show("Объект не может быть сериализован. \n" + ex);
						return;
					}
				}


				if (list.Count == 0)
					return;

				// копирование в буфер обмена
				IDataObject dataObj = new DataObject();
				dataObj.SetData(nameof(T), false, list);
				Clipboard.SetDataObject(dataObj, false);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error while copying new object(s). \n" + ex);
				Program.Provider.Logger.Log(ex);
			}
		}

        public void GetFromClipboard()
		{
			try
			{
				if (string.IsNullOrEmpty(nameof(T)))
					return;
				if (!Clipboard.ContainsData(nameof(T)))
					return;
				var pds = (List<T>)Clipboard.GetData(nameof(T));
				if (pds == null)
					return;

				ConfigurePaste?.Invoke(pds.Cast<T>().ToList());

				var objectToPaste = new List<T>();
				if (pds.Count > 0)
				{
					if (pds.Any(i => i is Component))
					{
						var components = pds.Where(i => i is Component && !(i is BaseComponent)).Cast<BaseEntityObject>().ToList();

						if(components.Count == 0)
							return;

						GlobalObjects.NewKeeper.BulkInsert(components);
						objectToPaste.AddRange(components.Cast<T>());
					}
					else
					{
						GlobalObjects.NewKeeper.BulkInsert(pds.Cast<BaseEntityObject>().ToList());
						objectToPaste.AddRange(pds);
					}
					
				}

				PasteComplete?.Invoke(pds.Cast<T>().ToList());

				//TODO:Вообще лучше так не делать а выносить в PasteComplete такие штуки но пока в качестве универсальной запоатки пойдет
				foreach (var pd in pds)
				{
					if(pd is IDirective directive)
						GlobalObjects.PerformanceCalculator.GetNextPerformance(directive);
					if (pd is Component component)
					{
						objectToPaste.Remove(pd);

						foreach (var cd in component.ComponentDirectives)
							cd.ComponentId = component.ItemId;


						if (component.ComponentDirectives.Count > 0)
							objectToPaste.AddRange(component.ComponentDirectives.Cast<T>());

						objectToPaste.Add(component as T);
					}
				}

				if (objectToPaste.Any(i => i is ComponentDirective))
					GlobalObjects.NewKeeper.BulkInsert(objectToPaste.Where(i => i is ComponentDirective).Cast<BaseEntityObject>().ToList());


				InsertItems(objectToPaste.ToArray());
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error while inserting new object(s). \n" + ex);
				Program.Provider.Logger.Log(ex);
			}
			finally
			{
				Clipboard.Clear();
			}
		}

		#endregion
	}


	public class CustomCell
	{
		public string Text { get; set; }
		public object Tag { get; set; }
		public Color? ForeColor { get; set; }

		#region Overrides of Object

		public override string ToString()
		{
			return Text;
		}

		#endregion
	}
}
