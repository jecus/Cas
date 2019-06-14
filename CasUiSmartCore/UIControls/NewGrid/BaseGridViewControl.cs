using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CASTerms;
using Microsoft.VisualBasic.Devices;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.NewGrid
{
	public partial class BaseGridViewControl<T> : UserControl where T : class, IBaseCoreObject
	{
		#region Fields

		//заголовки списка
		protected readonly List<GridViewDataColumn> ColumnHeaderList = new List<GridViewDataColumn>();
		//коллекция выделенных элементов
		private readonly List<T> _selectedItemsList = new List<T>();
		private readonly List<T> _items = new List<T>();
		private RadDropDownMenu _customMenu;

		#endregion

		#region Properties

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

		#endregion

		#region Constructor

		public BaseGridViewControl()
		{
			InitializeComponent();
			radGridView1.SelectionMode = GridViewSelectionMode.FullRowSelect;
			radGridView1.MultiSelect = true;
			FirstLoad();
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
				columnHeader = new GridViewBrowseColumn(attr.Title);
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

		#endregion

		#region private List<PropertyInfo> GetTypeProperties()
		/// <summary>
		/// Получает свойства типа, на основе которых будут созданы колонки 
		/// </summary>
		/// <returns></returns>
		private List<PropertyInfo> GetTypeProperties()
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
				AddItems(itemsArray);
				SetItemsColor();
				SetTotalText();

				radGridView1.RowFormatting += RadGridView1_RowFormatting;

			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while deleting data", ex);
				return;
			}
		}

		#region public virtual void InsertItems(T[] itemsArray)
		/// <summary>
		/// Добавляет элементы в начало ListView
		/// </summary>
		/// <param name="itemsArray"></param>
		public virtual void InsertItems(T[] itemsArray)
		{
			if (itemsArray.Length == 0)
				return;

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
		public virtual T[] GetItemsArray()
		{
			return _items.ToArray();
		}
		#endregion

		#region public CustomCell CreateRow(string text, object tag)

		public CustomCell CreateRow(string text, object tag, Color? foreColor = null)
		{
			return new CustomCell()
			{
				Text = text,
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
						rowInfo.Cells[i].Value = cell;

						if(cell.ForeColor.HasValue)
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
						value = GlobalObjects.CasEnvironment.GetCorrector((int)value);

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

		public void ExportToExcel()
		{
			using (var ms = new System.IO.MemoryStream())
			{
				var exporter = new Telerik.WinControls.Export.GridViewSpreadExport(radGridView1);
				var renderer = new Telerik.WinControls.Export.SpreadExportRenderer();
				 exporter.RunExport(ms, renderer);

				 var sfd = new SaveFileDialog {Filter = ".xlsx Files (*.xlsx)|*.xlsx"};

				 if (sfd.ShowDialog() == DialogResult.OK)
				{
					using (var fileStream = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
					{
						ms.WriteTo(fileStream);
					}
					MessageBox.Show("File was success saved!");
				}
			}
		}

		//Events

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
					if (SelectedItem != null)
					{
						if(DisplayerRequested != null)
							OnDisplayerRequested();
						else RadGridView1_DoubleClick(sender, e);
					}
					break;
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
