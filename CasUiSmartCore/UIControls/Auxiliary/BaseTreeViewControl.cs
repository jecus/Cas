using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary.Comparers;
using Microsoft.VisualBasic.Devices;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace CAS.UI.UIControls.Auxiliary
{
	///<summary>
	/// ЭУ для предствления дерева объектов определенного типа, унаследованных от <see cref="BaseEntityObject"/>
	///</summary>
	public partial class BaseTreeViewControl<T> : UserControl, IReference where T : BaseEntityObject
	{
		#region Fields
		//коллекция специальных элементов, отображаемых в списке
		private ObservableCollection<T> _itemsCollection;
		private bool _clearSearch;
		//коллекция выделенных элементов
		protected List<T> SelectedItemsList = new List<T>();
		//номер последней колонки, по которой производилась сортировка
		protected int OldColumnIndex;
		///<summary>
		///направление сортировки списка
		///</summary>
		protected int SortMultiplier = 1;
		///<summary>
		///предварительный список элементов ListView
		///</summary>
		public List<ListViewItem> ListViewItemList = new List<ListViewItem>();
		#endregion

		#region Properties

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

		#region public TreeView ItemListView
		///<summary>
		/// возвращает TreeView 
		///</summary>
		public TreeView ItemListView
		{
			get { return treeViewMain; }
		}
		#endregion

		//#region public T SourceItem
		/////<summary>
		///// Основной ресурс древовидного списка
		/////</summary>
		//public T SourceItem
		//{
		//    set
		//    {
		//        treeViewMain.Nodes.Clear();
		//        IEnumerable<T> e = new T[5];
		//    }
		//}
		//#endregion

		#endregion

		#region Constructors

		#region public BaseTreeViewControl()
		///<summary>
		/// конструктор по умолчанию для простого создания ЭУ в Дизайнере
		///</summary>
		public BaseTreeViewControl()
		{
			InitializeComponent();
		}
		#endregion
	   
		#endregion

		#region Methods
	   
		#region public void SetItemsArray(T[] itemsArray)
		/// <summary>
		/// Заполняет listview элементами
		/// </summary>
		/// <param name="itemsArray">Массив элементов</param>
		public void SetItemsArray(T[] itemsArray)
		{
			if (itemsArray == null)
				throw new ArgumentNullException("itemsArray", "itemsArray can't be null");
			//очищение предварительной коллекции элементов
			ListViewItemList.Clear();
			//очищение коллекции выбранных элементов
			SelectedItemsList.Clear();
			
			AddItems(itemsArray);
		}
		#endregion

		#region protected virtual void AddItems(T[] itemsArray)
		/// <summary>
		/// Добавляет элементы в ListView
		/// </summary>
		/// <param name="itemsArray"></param>
		protected virtual void AddItems(T[] itemsArray)
		{
			if (itemsArray.Length != 0)
			{
				int count = itemsArray.Length;
				for (int i = 0; i < count; i++)
				{
					AddItem(itemsArray[i]);
				}
				SortMultiplier = 1;
				SortItems(OldColumnIndex);
			}
		}

		#endregion

		#region protected ListViewItem AddItem(T item)
		/// <summary>
		/// Добавляет элемент в список технических записей (AbstractRecord)
		/// </summary>
		/// <param name="item">Добавляемая техническая запись (AbstractRecord)</param>
		protected ListViewItem AddItem(T item)
		{
			try
			{
				ListViewItem listViewItem = new ListViewItem(GetListViewSubItems(item),null) {Tag = item};
				ListViewItemList.Add(listViewItem);
				SetItemColor(listViewItem,item);
				return listViewItem;
			}
			catch (Exception ex)
			{

				Program.Provider.Logger.Log(ex);
			}
			return null;
		}
		#endregion

		#region protected virtual ListViewItem.ListViewSubItem[] GetItemsString(T item)

		protected virtual ListViewItem.ListViewSubItem[] GetListViewSubItems(T item)
		{
			//определение типа
			Type type = typeof(T);
			//определение своиств типа
			List<PropertyInfo> preProrerty = new List<PropertyInfo>(type.GetProperties());
			//определение своиств, имеющих атрибут "отображаемое в списке"
			List<PropertyInfo> properties =
				preProrerty.Where(p => p.GetCustomAttributes(typeof(ListViewDataAttribute), false).Length != 0).ToList();

			
			ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[properties.Count];
			for (int i = 0; i < properties.Count; i++ )
			{
				subItems[i] = new ListViewItem.ListViewSubItem
								  {
									  Text = properties[i].GetValue(item, null).ToString(),
									  Tag = properties[i].GetValue(item, null)
								  };
			}
			return subItems;
		}

		#endregion

		#region private void SortItems(int columnIndex)
		private void SortItems(int columnIndex)
		{
			if (OldColumnIndex != columnIndex)
				SortMultiplier = -1;
			if (SortMultiplier == 1)
				SortMultiplier = -1;
			else
				SortMultiplier = 1;
			SetGroupsToItems();
			ListViewItemList.Sort(new BaseListViewComparer(columnIndex,SortMultiplier));
			OldColumnIndex = columnIndex;
			//ChangeSize();
		}
		#endregion

		#region protected virtual void SetGroupsToItems()
		protected virtual void SetGroupsToItems()
		{
			
		}
		#endregion

		#region protected virtual void SetItemColor(ListViewItem listViewItem, BaseSmartCoreObject item)
		protected virtual void SetItemColor(ListViewItem listViewItem, BaseEntityObject item)
		{

		}
		#endregion

		#region private void ItemsListViewMouseClick(object sender, MouseEventArgs e)
		private void ItemsListViewMouseClick(object sender, MouseEventArgs e)
		{
			_clearSearch = true;
		}
		#endregion

		#region private void ItemsListViewColumnClick(object sender, ColumnClickEventArgs e)
		private void ItemsListViewColumnClick(object sender, ColumnClickEventArgs e)
		{
			SortItems(e.Column);
		}
		#endregion

		#region protected virtual void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		protected virtual void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
		{
			OnDisplayerRequested();
		}
		#endregion

		#region private void ItemsListViewSelectedIndexChanged(object sender, EventArgs e)
		private void ItemsListViewSelectedIndexChanged(object sender, EventArgs e)
		{
			if (SelectedItemsChanged != null)
				SelectedItemsChanged.Invoke(this, new SelectedItemsChangeEventArgs(SelectedItemsList.Count));
		}
		#endregion

		#region protected override void OnSizeChanged(EventArgs e)
		///<summary>
		///Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
		///</summary>
		///
		///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			//определение типа
			Type type = typeof(T);
			//определение своиств типа
			List<PropertyInfo> preProrerty = new List<PropertyInfo>(type.GetProperties());
			//определение своиств, имеющих атрибут "отображаемое в списке"
			List<PropertyInfo> properties =
				preProrerty.Where(p => p.GetCustomAttributes(typeof(ListViewDataAttribute), false).Length != 0).ToList();
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
				ReflectionTypes reflection = ReflectionType;
				Keyboard k = new Keyboard();
				if (k.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent) reflection = ReflectionTypes.DisplayInNew;
				ReferenceEventArgs e;
				if (null != Displayer)
				{
					e = new ReferenceEventArgs(Entity, reflection, Displayer, DisplayerText);
				}
				else
				{
					e = new ReferenceEventArgs(Entity, reflection, DisplayerText);
				}

				FillDisplayerRequestedParams(e);
				DisplayerRequested(this, e);
			}
		}

		#endregion

		#region protected virtual void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected virtual void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
		}
		#endregion

		#endregion

		#region Events

		#region public event EventHandler<ReferenceEventArgs> DisplayerRequested
		/// <summary>
		/// Событие, воздуждаемое при необходимости отобразть что-то в новой/текущей вкладке  
		/// </summary>
		public event EventHandler<ReferenceEventArgs> DisplayerRequested;

		#endregion

		#region public event EventHandler<SelectedItemsChangeEventArgs> SelectedItemsChanged;
		/// <summary>
		/// Событие возникающее при изменении массива выбранных элементов в списке элементов, которые отображаются в списке, вот!
		/// </summary>
		public event EventHandler<SelectedItemsChangeEventArgs> SelectedItemsChanged;
		#endregion

		#endregion
	}
}
