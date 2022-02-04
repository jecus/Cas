using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAA.Entity.Models;
using CAS.Entity.Models.DTO.Dictionaries;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.NewGrid;
using CAS.UI.UIControls.PersonnelControls;
using CAS.UI.UIControls.PurchaseControls;
using CASTerms;
using Entity.Abstractions.Filters;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.Auxiliary.CAA
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class CAACommonListScreen : ScreenControl
	{
		#region Fields

		protected Type ViewedType;
        private readonly List<Filter> _filters;
        protected CommonGridViewControl DirectivesViewer;

		protected ICommonCollection InitialDirectiveArray;
		protected ICommonCollection ResultDirectiveArray;
        
		private CommonFilterCollection _filter;

		protected RadMenuItem _toolStripMenuItemOpen;
		protected RadMenuItem _toolStripMenuItemShowTaskCard;
		protected RadMenuSeparatorItem _toolStripSeparatorOpenOperation;
		protected RadMenuItem _toolStripMenuItemHighlight;

        private bool _showOpenOperationContextMenu = true;
        private bool _showEditOperationContextMenu = true;
        private bool _showQuotationOperationContextMenu = true;

		#endregion

		#region Properties

        public int OperatorId { get; set; } = -1;
		public bool ShowOpenOperationContextMenu
		{
			get { return _showOpenOperationContextMenu; }
			set { _showOpenOperationContextMenu = value; }
		}

        public bool ShowEditOperationContextMenu
		{
			get { return _showEditOperationContextMenu; }
			set { _showEditOperationContextMenu = value; }
		}


		public bool ShowQuotationOperationContextMenu
		{
			get { return _showQuotationOperationContextMenu; }
			set { _showQuotationOperationContextMenu = value; }
		}

		#endregion

		#region Constructors

		#region protected CommonListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		protected CAACommonListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public CommonListScreen(Type viewedType): this()

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список объектов
		///</summary>
		///<param name="viewedType">Тип, объекты которого будут отображаться в списке</param>
		///<param name="beginGroup"></param>
		public CAACommonListScreen(Type viewedType, List<Filter> filters = null, PropertyInfo beginGroup = null)
			: this()
		{
			if (viewedType == null)
				throw new ArgumentNullException("viewedType");

			ViewedType = viewedType;
            _filters = filters;
            aircraftHeaderControl1.Operator = GlobalObjects.CaaEnvironment.Operators[0];
			StatusTitle = ViewedType.Name;

			_filter = new CommonFilterCollection(viewedType);

			PreInitToolStripMenuItems();
			InitToolStripMenuItems();
			PostInitToolStripMenuItems();

			InitListView(beginGroup);
			UpdateInformation();
		}
		#endregion

		#endregion

		#region Methods

		#region public override void DisposeScreen()
		public override void DisposeScreen()
		{
			if (AnimatedThreadWorker.IsBusy)
				AnimatedThreadWorker.CancelAsync();

			AnimatedThreadWorker.Dispose();

			if(InitialDirectiveArray != null)
				InitialDirectiveArray.Clear();
			InitialDirectiveArray = null;

			if (ResultDirectiveArray != null)
				ResultDirectiveArray.Clear();
			ResultDirectiveArray = null;


			if (DirectivesViewer != null) DirectivesViewer.Dispose();

			Dispose(true);
		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if(e.Cancelled)
				return;
            DirectivesViewer.SetItemsArray(ResultDirectiveArray.OfType<BaseEntityObject>());


			headerControl.PrintButtonEnabled = DirectivesViewer.ItemsCount != 0;
			buttonDeleteSelected.Enabled = DirectivesViewer.SelectedItem != null;
			if (ViewedType.IsSubclassOf(typeof(StaticDictionary)))
			{
				buttonAddNew.Enabled = false;
				buttonDeleteSelected.Enabled = false;
			}
        }
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			#region Загрузка элементов
			InitialDirectiveArray.Clear();
			
			if(ResultDirectiveArray != null)
				ResultDirectiveArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load directives");

			if(ViewedType.IsSubclassOf(typeof(StaticDictionary)))
			{
				PropertyInfo p = ViewedType.GetProperty("Items");

				ConstructorInfo ci = ViewedType.GetConstructor(new Type[0]);
				StaticDictionary instance = (StaticDictionary)ci.Invoke(null);

				InitialDirectiveArray.AddRange((IDictionaryCollection)p.GetValue(instance, null));
				InitialDirectiveArray.RemoveById(-1);
			}
			else
            {
                var dto = (CAADtoAttribute)ViewedType.GetCustomAttributes(typeof(CAADtoAttribute), false).FirstOrDefault();
				var res = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList(dto.Type, ViewedType, loadChild: true, filter: _filters);
				InitialDirectiveArray.AddRange((IEnumerable<IBaseEntityObject>)res);
            }

			AnimatedThreadWorker.ReportProgress(40, "filter directives");

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(70, "filter directives");

			FilterItems(InitialDirectiveArray, ResultDirectiveArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
			#endregion
			
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		protected void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			ResultDirectiveArray.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(70, "filter directives");

			FilterItems(InitialDirectiveArray, ResultDirectiveArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}
		#endregion

		#region public override void OnInitCompletion(object sender)
		/// <summary>
		/// Метод, вызывается после добавления содежимого на отображатель(вкладку)
		/// </summary>
		/// <returns></returns>
		public override void OnInitCompletion(object sender)
		{
			AnimatedThreadWorker.RunWorkerAsync();

			base.OnInitCompletion(sender);
		}
		#endregion

		#region  protected virtual void PreInitToolStripMenuItems()

		protected virtual void PreInitToolStripMenuItems()
		{
		}

		#endregion

		#region protected virtual void PostInitToolStripMenuItems()

		protected virtual void PostInitToolStripMenuItems()
		{

		}

		#endregion

		#region private void InitToolStripMenuItems(Aircraft aircraft)

		private void InitToolStripMenuItems()
		{
			#region OpenOperation

			if (_showOpenOperationContextMenu)
			{
				_toolStripMenuItemOpen = new RadMenuItem();
				_toolStripMenuItemShowTaskCard = new RadMenuItem();
				_toolStripSeparatorOpenOperation = new RadMenuSeparatorItem();

				// 
				// toolStripMenuItemView
				// 
				_toolStripMenuItemOpen.Text = "Open";
				_toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
				// 
				// _toolStripMenuItemShowTaskCard
				// 
				_toolStripMenuItemShowTaskCard.Text = "Show Task Card";
				_toolStripMenuItemShowTaskCard.Click += ToolStripMenuItemShowTaskCardClick;
			}

			#endregion
        }

		#endregion

		#region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

		private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
		{
			OpenItem();
		}

		#endregion

		#region  protected virtual void Open()

		protected virtual void OpenItem()
		{

		}

		#endregion

		#region private void ToolStripMenuItemShowTaskCardClick(object sender, EventArgs e)

		private void ToolStripMenuItemShowTaskCardClick(object sender, EventArgs e)
		{
			ShowTaskCard();
		}

		#endregion

		#region protected virtual void ShowTaskCard()

		protected virtual void ShowTaskCard()
		{

		}

		#endregion

        #region protected virtual void CreateWorkPakage()

		protected virtual void CreateWorkPakage()
		{

		}

		#endregion

		#region protected virtual void AddToWorkPackage(WorkPackage wp)

		protected virtual void AddToWorkPackage(WorkPackage wp)
		{

		}

		#endregion

		#region protected virtual void InitListView(PropertyInfo beginGroup = null)

		protected virtual void InitListView(PropertyInfo beginGroup = null)
		{
			DirectivesViewer = new CommonGridViewControl()
									{
										ViewedType = ViewedType,
										TabIndex = 2,
										Location = new Point(panel1.Left, panel1.Top),
										Dock = DockStyle.Fill
									};
			
			DirectivesViewer.MenuOpeningAction = () =>
			{
				if (DirectivesViewer.SelectedItems.Count <= 0)
					return;

                if (_showOpenOperationContextMenu && DirectivesViewer.SelectedItem is NonRoutineJob)
				{
					var nrj = DirectivesViewer.SelectedItem as NonRoutineJob;
					if (nrj.AttachedFile == null)
						_toolStripMenuItemShowTaskCard.Enabled = false;
					else _toolStripMenuItemShowTaskCard.Enabled = true;
				}
			};

			DirectivesViewer.AddMenuItems(new RadMenuItemBase[]{_toolStripMenuItemOpen,
				_toolStripMenuItemShowTaskCard,
				_toolStripSeparatorOpenOperation,
				_toolStripMenuItemHighlight});

			DirectivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			panel1.Controls.Add(DirectivesViewer);
		}

		#endregion

		#region protected void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

		protected void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			if (DirectivesViewer.SelectedItems.Count > 0)
			{
				buttonDeleteSelected.Enabled = !ViewedType.IsSubclassOf(typeof(StaticDictionary));
				headerControl.EditButtonEnabled = true;
			}
			else
			{
				headerControl.EditButtonEnabled = false;
				buttonDeleteSelected.Enabled = false;
			}
		}

		#endregion

		#region private void UpdateInformation()
		/// <summary>
		/// Происзодит обновление отображения элементов
		/// </summary>
		private void UpdateInformation()
		{
            try
			{
				if (InitialDirectiveArray != null) InitialDirectiveArray.Clear();
				if (ResultDirectiveArray != null) ResultDirectiveArray.Clear();
				Type genericType = typeof(CommonCollection<>);
				Type genericList = genericType.MakeGenericType(ViewedType);
				InitialDirectiveArray = (ICommonCollection)Activator.CreateInstance(genericList);
				ResultDirectiveArray = (ICommonCollection)Activator.CreateInstance(genericList);
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while building collection", ex);
			}
		}
		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			headerControl.ShowSaveButton = false;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region protected virtual HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		/// <summary>
		/// Реагирует на нажатие кнопки печати отчета
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			//if (DirectivesViewer.ItemsCount == 0)
			//{
			//	MessageBox.Show("0 directives");
			//}
			//e.DisplayerText = "Request For Quotation Report";
			//e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			//e.RequestedEntity = new ReportScreen(new ForecastListReportBuilder(_currentForecast.ForecastDatas[0]));
		}
		#endregion

		#region private void HeaderControlSaveButtonClick(object sender, System.EventArgs e)

		private void HeaderControlSaveButtonClick(object sender, EventArgs e)
		{
			var unsaved = DirectivesViewer.GetItemsArray().Cast<BaseEntityObject>().Where(o => o.ItemId <= 0).ToList();

			try
			{
				foreach (BaseEntityObject entityObject in unsaved)
				{
					GlobalObjects.CaaEnvironment.NewKeeper.Save(entityObject,true);
				}

				MessageBox.Show("Saving was successful", "Message infomation", MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				headerControl.ShowSaveButton = unsaved.Count(i => i.ItemId <= 0) > 0;
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save directive from directives list", ex);
			}

		}

		#endregion

		#region #region protected virtual ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

		protected virtual void ButtonExportDisplayerRequested(object sender, ReferenceEventArgs e)
		{

		}

		#endregion

		#region protected virtual ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		/// <summary>
		/// Реагирует на нажатие кнопки добавления нового элемента
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			try
			{
				Form form;

				if (ViewedType.Name == typeof(AircraftWorkerCategory).Name)
				{
					form = new AircraftWorkerCategoryForm(new AircraftWorkerCategory());
				}
                else if(ViewedType.Name == typeof(Product).Name)
				{
					form = new ProductForm(new Product());   
				}
				else if (ViewedType.Name == typeof(ComponentModel).Name)
				{
					form = new ModelForm(new ComponentModel());
				}
				else if (ViewedType.Name == typeof(GoodStandart).Name)
				{
					form = new GoodStandardForm(new GoodStandart());
				}
				else
				{
					ConstructorInfo ci = ViewedType.GetConstructor(new Type[0]);
					BaseEntityObject item = (BaseEntityObject)ci.Invoke(null);

                    if (item is IOperatable oper)
                        oper.OperatorId = OperatorId;

					form = new CommonEditorForm(item);
				}

				if (form.ShowDialog(this) == DialogResult.OK)
				{
					AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
					AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
					AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

					AnimatedThreadWorker.RunWorkerAsync();
				}
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while building new object", ex);
			}
		}

		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			CommonFilterForm form = new CommonFilterForm(_filter, InitialDirectiveArray);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (DirectivesViewer.SelectedItems == null ||
				DirectivesViewer.SelectedItems.Count == 0) return;

			string typeName = ViewedType.Name;

			DialogResult confirmResult =
				MessageBox.Show(DirectivesViewer.SelectedItems.Count == 1
						? "Do you really want to delete " + typeName + " " + DirectivesViewer.SelectedItems[0] + "?"
						: "Do you really want to delete selected " + typeName + "s?", "Confirm delete operation",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				DirectivesViewer.radGridView1.BeginUpdate();
				GlobalObjects.NewKeeper.Delete(DirectivesViewer.SelectedItems.OfType<BaseEntityObject>().ToList(), true);
				DirectivesViewer.radGridView1.EndUpdate();

				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region protected void FilterItems(PrimaryDirectiveCollection primaryDirectives)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		protected void FilterItems(ICommonCollection initialCollection, ICommonCollection resultCollection)
		{
			if (_filter == null || _filter.All(i => i.Values.Length == 0))
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
			}

			resultCollection.Clear();

			foreach (BaseEntityObject pd in initialCollection)
			{
				//if (pd.MaintenanceCheck != null && pd.MaintenanceCheck.Name == "2C")
				//{
				//    pd.MaintenanceCheck.ToString();
				//}
				if (_filter.FilterTypeAnd)
				{
					bool acceptable = true;
					foreach (ICommonFilter filter in _filter)
					{
						acceptable = filter.Acceptable(pd); if (!acceptable) break;
					}
					if (acceptable) resultCollection.Add(pd);
				}
				else
				{
					bool acceptable = true;
					foreach (ICommonFilter filter in _filter)
					{
						if (filter.Values == null || filter.Values.Length == 0)
							continue;
						acceptable = filter.Acceptable(pd); if (acceptable) break;
					}
					if (acceptable) resultCollection.Add(pd);
				}
			}
		}
		#endregion

		#endregion
	}
}
