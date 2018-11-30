﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASReports.Builders;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Filters;

namespace CAS.UI.UIControls.DocumentationControls
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class DocumentationListScreen : ScreenControl
	{
		#region Fields

		private ICommonCollection<Document> _initialDocumentArray = new CommonCollection<Document>();
		private ICommonCollection<Document> _resultDocumentArray = new CommonCollection<Document>();
		private readonly BaseEntityObject _parent;
		private DocumentationListView _directivesViewer;

		private ContextMenuStrip _contextMenuStrip;
		private ToolStripMenuItem _toolStripMenuItemCopy;
		private ToolStripMenuItem _toolStripMenuItemPaste;
		private ToolStripMenuItem _toolStripMenuItemShowTaskCard;
		private ToolStripMenuItem _toolStripMenuItemSaveAsTaskCard;
		private ToolStripSeparator _toolStripSeparator1;

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
		public DocumentationListScreen(Aircraft currentAircraft) : this()
		{
			if (currentAircraft == null)
				throw new ArgumentNullException("currentAircraft");
			_parent = currentAircraft;
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

		#endregion

		#endregion

		#region Methods

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			_directivesViewer.SetItemsArray(_resultDocumentArray.ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ListViewItemList.Count != 0;

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
				if (_parent is Aircraft)
					_initialDocumentArray.AddRange(GlobalObjects.DocumentCore.GetAircraftDocuments((Aircraft)_parent).ToArray());
				if (_parent is Operator)
					_initialDocumentArray.AddRange(GlobalObjects.DocumentCore.GetOperatorDocuments((Operator)_parent).ToArray());
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
				Dock = DockStyle.Fill, IgnoreAutoResize = true
			};

			_directivesViewer.ContextMenuStrip = _contextMenuStrip;
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
			_contextMenuStrip = new ContextMenuStrip();
			_toolStripMenuItemCopy = new ToolStripMenuItem();
			_toolStripMenuItemPaste = new ToolStripMenuItem();
			_toolStripMenuItemShowTaskCard = new ToolStripMenuItem();
			_toolStripMenuItemSaveAsTaskCard = new ToolStripMenuItem();
			_toolStripSeparator1 = new ToolStripSeparator();

			// 
			// contextMenuStrip
			// 
			_contextMenuStrip.Name = "_contextMenuStrip";
			_contextMenuStrip.Size = new Size(179, 176);

			// 
			// toolStripMenuItemCopy
			// 
			_toolStripMenuItemCopy.Text = "Copy";
			_toolStripMenuItemCopy.Click += CopyItemsClick;

			// 
			// toolStripMenuItemPaste
			// 
			_toolStripMenuItemPaste.Text = "Paste";
			_toolStripMenuItemPaste.Click += PasteItemsClick;

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

			_contextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				_toolStripMenuItemSaveAsTaskCard,
				_toolStripMenuItemShowTaskCard,
				_toolStripSeparator1,
				_toolStripMenuItemCopy,
				_toolStripMenuItemPaste
			});

			_contextMenuStrip.Opening += ContextMenuStripOpen;
		}

		#endregion

		#region  private void PasteItemsClick(object sender, EventArgs e)

		private void PasteItemsClick(object sender, EventArgs e)
		{
			GetFromClipboard();
		}

		#endregion

		#region private void CopyItemsClick(object sender, EventArgs e)

		private void CopyItemsClick(object sender, EventArgs e)
		{
			CopyToClipboard();

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
				GlobalObjects.CasEnvironment.OpenFile(document.AttachedFile, out message);
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
				GlobalObjects.CasEnvironment.SaveAsFile(document.AttachedFile, saveFileDialog.FileName, out message);
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

		#region private void ContextMenuStripOpen(object sender, CancelEventArgs e)

		private void ContextMenuStripOpen(object sender, CancelEventArgs e)
	    {
		    if (_directivesViewer.SelectedItems.Count <= 0)
		    {
			    _toolStripMenuItemShowTaskCard.Enabled = false;
			}

		    if (_directivesViewer.SelectedItems.Count == 1)
		    {
			    var document = _directivesViewer.SelectedItems[0];
			    _toolStripMenuItemSaveAsTaskCard.Enabled = _toolStripMenuItemShowTaskCard.Enabled = document.AttachedFile != null;
		    }
	    }

		#endregion

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
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        GlobalObjects.CasEnvironment.NewKeeper.Delete(selectedItems[i]);
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while deleting data", ex);
                        return;
                    }
                }

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

		#region private void CopyToClipboard()
		private void CopyToClipboard()
		{
			// регистрация формата данных либо получаем его, если он уже зарегистрирован
			var format = DataFormats.GetFormat(typeof(Document[]).FullName);

			if (_directivesViewer.SelectedItems == null || _directivesViewer.SelectedItems.Count == 0)
				return;

			var pds = new List<Document>();
			foreach (var document in _directivesViewer.SelectedItems)
			{
				pds.Add(document.GetCopyUnsaved());
			}

			if (pds.Count <= 0)
				return;

			//todo:(EvgeniiBabak) Нужен другой способ проверки сереализуемости объекта
			using (var mem = new System.IO.MemoryStream())
			{
				var bin = new BinaryFormatter();
				try
				{
					bin.Serialize(mem, pds);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Объект не может быть сериализован. \n" + ex);
					return;
				}
			}
			// копирование в буфер обмена
			IDataObject dataObj = new DataObject();
			dataObj.SetData(format.Name, false, pds.ToArray());
			Clipboard.SetDataObject(dataObj, false);

			pds.Clear();
		}
		#endregion

		#region private void GetFromClipboard()

		private void GetFromClipboard()
		{
			try
			{
				var format = typeof(Document[]).FullName;

				if (string.IsNullOrEmpty(format))
					return;
				if (!Clipboard.ContainsData(format))
					return;
				var documents = (Document[]) Clipboard.GetData(format);
				if (documents == null)
					return;

				var objectsToPaste = new List<Document>();
				foreach (var document in documents)
				{
					document.Parent = _parent;
					document.ParentId = _parent.ItemId;
					_initialDocumentArray.Add(document);
					document.ContractNumber += " Copy";
					objectsToPaste.Add(document);
				}

				if (objectsToPaste.Count > 0)
				{
					_directivesViewer.InsertItems(objectsToPaste.ToArray());

					headerControl.ShowSaveButton = true;
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show("Error while inserting new object(s). \n" + ex);
				headerControl.ShowSaveButton = false;
				Program.Provider.Logger.Log(ex);
			}
			finally
			{
				Clipboard.Clear();
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
			if (_filter == null || _filter.Count == 0)
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
