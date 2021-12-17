using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.Entity.Models.DTO.General;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASReports.Builders;
using CASTerms;
using Entity.Abstractions.Filters;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Filters;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.DocumentationControls
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class DocumentationListScreen : ScreenControl
	{
		private readonly List<Filter> _filters;

		#region Fields

		private ICommonCollection<Document> _initialDocumentArray = new CommonCollection<Document>();
		private ICommonCollection<Document> _resultDocumentArray = new CommonCollection<Document>();
		private readonly BaseEntityObject _parent;
		private readonly DocumentType _docType;
		private DocumentationListView _directivesViewer;

		private RadMenuItem _toolStripMenuItemShowTaskCard;
		private RadMenuItem _toolStripMenuItemSaveAsTaskCard;
		private RadMenuSeparatorItem _toolStripSeparator1;

		private ContextMenuStrip _buttonPrintMenuStrip;
		private ToolStripMenuItem _itemPrintReportListOfDocuments;
		private ToolStripMenuItem _itemPrintReportNomenclature;
		private ToolStripMenuItem _itemPrintReportRegisterOfDocument;
		private ToolStripMenuItem _itemPrintReportWorkSchedule;

		private CommonFilterCollection _filter;


		private ListOfDocumentsReportBuilder _listOfDocumentsReportBulder;
		private NomenclatureReportBuilder _nomenclatureReportBuilder;
		private RegisterOfDocumentReportBuilder _registerOfDocumentReportBuilder;
		private WorkScheduleReportBuilder _workScheduleReportBuilder;

		#endregion

		#region Constructors

		#region public DocumentationListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public DocumentationListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public DocumentationListScreen(Aircraft currentAircraft) : this()
		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentAircraft">ВС, которому принадлежат директивы</param>
		public DocumentationListScreen(Aircraft currentAircraft, DocumentType docType = null) : this()
		{
			if (currentAircraft == null)
				throw new ArgumentNullException("currentAircraft");
			_parent = currentAircraft;
			_docType = docType;
			CurrentAircraft = currentAircraft;
			StatusTitle = "Aircraft Documentation";

			_filter = new CommonFilterCollection(typeof(Document));

			InitToolStripPrintMenuItems();
			InitToolStripMenuItems();
			InitListView();
			UpdateInformation();
		}

		#endregion

		#region public DocumentationListScreen(Operator currentOperator) : this()
		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentOperator">ВС, которому принадлежат директивы</param>
		public DocumentationListScreen(Operator currentOperator)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			_parent = currentOperator;
			aircraftHeaderControl1.Operator = currentOperator;
			StatusTitle = "Operator Documentation";
			labelTitle.Visible = false;

			_filter = new CommonFilterCollection(typeof(Document));

			InitToolStripPrintMenuItems();
			InitToolStripMenuItems();
			InitListView();
			UpdateInformation();
		}

		public DocumentationListScreen(Operator currentOperator, List<Filter> filters)
			: this(currentOperator)
		{
			_filters = filters;
		}

		#endregion

		#endregion

		#region Methods

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			_directivesViewer.SetItemsArray(_resultDocumentArray.ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;

			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			if (_parent == null) return;
			_initialDocumentArray.Clear();
			_resultDocumentArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load documents");

			try
			{
				GlobalObjects.CasEnvironment.Loader.ReloadDictionary(typeof(DocumentSubType), typeof(ServiceType), typeof(Nomenclatures), typeof(Department), typeof(Specialization));
				if (_filters == null)
				{
					if (_parent is Aircraft)
						_initialDocumentArray.AddRange(GlobalObjects.DocumentCore.GetAircraftDocuments((Aircraft)_parent, _docType).ToArray());
					if (_parent is Operator)
						_initialDocumentArray.AddRange(GlobalObjects.DocumentCore.GetOperatorDocuments((Operator)_parent).ToArray());
				}
				else
				{
					_initialDocumentArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<DocumentDTO, Document>(_filters, true));
				}
			}
			catch(Exception ex)
			{
				Program.Provider.Logger.Log("Error while load documents", ex);
			}

			AnimatedThreadWorker.ReportProgress(20, "calculation documents");

			foreach (Document document in _initialDocumentArray)
				GlobalObjects.PerformanceCalculator.GetNextPerformance(document);

			AnimatedThreadWorker.ReportProgress(70, "filter documents");
			FilterItems(_initialDocumentArray, _resultDocumentArray);

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}
		#endregion

		#region private void UpdateInformation()
		/// <summary>
		/// Происзодит обновление отображения элементов
		/// </summary>
		private void UpdateInformation()
		{
			if (CurrentAircraft != null)
			{
				labelTitle.Text = "Date as of: " +
								  SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Aircraft TSN/CSN: " +
								  GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
			}
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new DocumentationListView
			{
				TabIndex = 2,
				Location = new Point(panel1.Left, panel1.Top),
				Dock = DockStyle.Fill
			};

			_directivesViewer.AddMenuItems(_toolStripMenuItemSaveAsTaskCard,
				_toolStripMenuItemShowTaskCard);

			_directivesViewer.MenuOpeningAction = () => {
				if (_directivesViewer.SelectedItems.Count <= 0)
				{
					_toolStripMenuItemShowTaskCard.Enabled = false;
				}

				if (_directivesViewer.SelectedItems.Count == 1)
				{
					var document = _directivesViewer.SelectedItems[0];
					_toolStripMenuItemSaveAsTaskCard.Enabled = _toolStripMenuItemShowTaskCard.Enabled = document.HaveFile;
				}
			};

			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		private void InitToolStripPrintMenuItems()
		{
			_buttonPrintMenuStrip = new ContextMenuStrip();
			_itemPrintReportListOfDocuments = new ToolStripMenuItem {Text = "List of Documents"};
			_itemPrintReportNomenclature = new ToolStripMenuItem {Text = "Nomenclature"};
			_itemPrintReportRegisterOfDocument = new ToolStripMenuItem {Text = "Register of Documents" };
			_itemPrintReportWorkSchedule = new ToolStripMenuItem {Text = "Work Schedule"};

			_buttonPrintMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				_itemPrintReportListOfDocuments, _itemPrintReportNomenclature,
				_itemPrintReportRegisterOfDocument, _itemPrintReportWorkSchedule
			});

			ButtonPrintMenuStrip = _buttonPrintMenuStrip;

		}

		#region  private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_toolStripMenuItemShowTaskCard = new RadMenuItem();
			_toolStripMenuItemSaveAsTaskCard = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			
			// 
			// toolStripMenuItemShowTaskCard
			// 
			_toolStripMenuItemShowTaskCard.Text = "Show document file";
			_toolStripMenuItemShowTaskCard.Click += ShowDocumentFileItemsClick;

			// 
			// _toolStripMenuItemSaveAsTaskCard
			// 
			_toolStripMenuItemSaveAsTaskCard.Text = "Save as document file";
			_toolStripMenuItemSaveAsTaskCard.Click += _toolStripMenuItemSaveAsTaskCard_Click;
		}

		#endregion
		
		#region private void ShowDocumentFileItemsClick(object sender, EventArgs e)

		private void ShowDocumentFileItemsClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null ||
				_directivesViewer.SelectedItems.Count == 0) return;

			var document = _directivesViewer.SelectedItems[0];
			try
			{
				string message;
                var attachedFile = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<AttachedFileDTO, AttachedFile>(document.FileId);
				GlobalObjects.CasEnvironment.OpenFile(attachedFile, out message);
				if (message != "")
				{
					MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
						MessageBoxDefaultButton.Button1);
				}
			}
			catch (Exception ex)
			{
				string errorDescriptionSctring = $"Error while Open Attached File for {document}, id {document.ItemId}. \nFileId {document.AttachedFile.ItemId}";
				Program.Provider.Logger.Log(errorDescriptionSctring, ex);
			}
		}

		#endregion

		private void _toolStripMenuItemSaveAsTaskCard_Click(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null ||
				_directivesViewer.SelectedItems.Count == 0) return;

			var document = _directivesViewer.SelectedItems[0];

			try
			{
				var saveFileDialog = new SaveFileDialog();
				saveFileDialog.FileName = document.AttachedFile.FileName;
				saveFileDialog.Filter = "Pdf Files|*.pdf";

				if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
					return;

				string message;
                var attachedFile = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<AttachedFileDTO, AttachedFile>(document.FileId);
				GlobalObjects.CasEnvironment.SaveAsFile(attachedFile, saveFileDialog.FileName, out message);
				if (message != "")
				{
					MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
						MessageBoxDefaultButton.Button1);
				}
				else
				{
					MessageBox.Show("File saving was successful", (string) new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK,
						MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				string errorDescriptionSctring =
					$"Error while Save Attached File for {document}, id {document.ItemId}. \nFileId {document.AttachedFile.ItemId}";
				Program.Provider.Logger.Log(errorDescriptionSctring, ex);
			}

		}
		

		#region private void ButtonAddNonRoutineJobClick(object sender, EventArgs e)
		private void ButtonAddNonRoutineJobClick(object sender, EventArgs e)
		{
			var form = new DocumentForm(new Document(), _parent);

			if (form.ShowDialog() == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}
		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null) return;

			DialogResult confirmResult =
				MessageBox.Show(
					_directivesViewer.SelectedItem != null
						? "Do you really want to delete Document " + _directivesViewer.SelectedItem.Description + "?"
						: "Do you really want to delete selected Documents? ", "Confirm delete operation",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				int count = _directivesViewer.SelectedItems.Count;

				List<Document> selectedItems = new List<Document>();
				selectedItems.AddRange(_directivesViewer.SelectedItems.ToArray());
				GlobalObjects.NewKeeper.Delete(selectedItems.OfType<BaseEntityObject>().ToList(), true);

				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
			else
			{
				MessageBox.Show("Failed to delete Documents: Parent container is invalid", "Operation failed",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, System.EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void headerControl_ButtonPrintDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void headerControl_ButtonPrintDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;

			if (sender == _itemPrintReportListOfDocuments)
			{
				_listOfDocumentsReportBulder = new ListOfDocumentsReportBuilder(CurrentOperator, _directivesViewer.GetItemsArray());
				_listOfDocumentsReportBulder.FilterSelection = _filter;
				e.DisplayerText = aircraftHeaderControl1.Operator.Name + "." + "List of Documents";
				e.RequestedEntity = new ReportScreen(_listOfDocumentsReportBulder);
			}
			else if (sender == _itemPrintReportNomenclature)
			{
				_nomenclatureReportBuilder = new NomenclatureReportBuilder(CurrentOperator, _directivesViewer.GetItemsArray());
				_nomenclatureReportBuilder.FilterSelection = _filter;
				e.DisplayerText = aircraftHeaderControl1.Operator.Name + "." + "Nomenclature";
				e.RequestedEntity = new ReportScreen(_nomenclatureReportBuilder);
			}
			else if (sender == _itemPrintReportRegisterOfDocument)
			{
				_registerOfDocumentReportBuilder = new RegisterOfDocumentReportBuilder(CurrentOperator, _directivesViewer.GetItemsArray());
				_registerOfDocumentReportBuilder.FilterSelection = _filter;
				e.DisplayerText = aircraftHeaderControl1.Operator.Name + "." + "Register of Documents";
				e.RequestedEntity = new ReportScreen(_registerOfDocumentReportBuilder);
			}
			else
			{
				_workScheduleReportBuilder = new WorkScheduleReportBuilder(CurrentOperator, _directivesViewer.GetItemsArray());
				_workScheduleReportBuilder.FilterSelection = _filter;
				e.DisplayerText = aircraftHeaderControl1.Operator.Name + "." + "Work Schedule";
				e.RequestedEntity = new ReportScreen(_workScheduleReportBuilder);
			}
		}
		#endregion

		#region private void HeaderControlSaveButtonClick(object sender, EventArgs e)

		private void HeaderControlSaveButtonClick(object sender, EventArgs e)
		{
			var unsaved = _directivesViewer.GetItemsArray().Where(i => i.ItemId <= 0).ToList();

			try
			{
				GlobalObjects.DocumentCore.SaveDocumentsList(_parent, unsaved);
				MessageBox.Show("Saving was successful", "Message infomation", MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				headerControl.ShowSaveButton = false;
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save document", ex);
			}
		}

		#endregion
		
		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filter, _initialDocumentArray);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			_resultDocumentArray.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(50, "filter directives");

			FilterItems(_initialDocumentArray, _resultDocumentArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#endregion

		#region private void FilterItems(IEnumerable<Document> initialCollection, ICommonCollection<Document> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<Document> initialCollection, ICommonCollection<Document> resultCollection)
		{
			if (_filter == null || _filter.All(i => i.Values.Length == 0))
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
			}

			resultCollection.Clear();

			foreach (var pd in initialCollection)
			{
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
