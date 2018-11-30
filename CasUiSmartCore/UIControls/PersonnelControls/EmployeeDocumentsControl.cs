using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.DocumentationControls;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Personnel;
using SmartCore.Filters;

namespace CAS.UI.UIControls.PersonnelControls
{
    ///<summary>
    ///</summary>
    [Designer(typeof(EmployeeDocumentsControlDesigner))]
    public partial class EmployeeDocumentsControl : UserControl, IReference
    {
		#region Fields

		private Specialist _currentItem;
		private readonly AnimatedThreadWorker AnimatedThreadWorker = new AnimatedThreadWorker();
		private ICommonCollection<Document> _initialDocumentArray = new CommonCollection<Document>();
		private ICommonCollection<Document> _resultDocumentArray = new CommonCollection<Document>();
		private CommonFilterCollection _filter;

		private ContextMenuStrip _contextMenuStrip;
		private ToolStripMenuItem _toolStripMenuItemCopy;
		private ToolStripMenuItem _toolStripMenuItemPaste;
		private ToolStripMenuItem _toolStripMenuItemShowTaskCard;
		private ToolStripMenuItem _toolStripMenuItemSaveAsTaskCard;
		private ToolStripSeparator _toolStripSeparator1;

		#endregion

		#region Constructors

		#region public EmployeeDocumentsControl()

		///<summary>
		/// Создает объект для отображения информации о директиве
		///</summary>
		public EmployeeDocumentsControl()
        {
            InitializeComponent();
			_filter = new CommonFilterCollection(typeof(Document));
	        InitToolStripMenuItems();
			documentationListView.ContextMenuStrip = _contextMenuStrip;
		}

        #endregion

        #endregion

        #region Properties

        #region public Specialist CurrentItem
        ///<summary>
        ///Текущая директива
        ///</summary>
        public Specialist CurrentItem
        {
            set
            {
                _currentItem = value;
                if (_currentItem != null)
                {
                    UpdateInformation();
                }
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public void CancelAsync()
        /// <summary>
        /// Запрашивает отмену асинхронной операции
        /// </summary>
        public void CancelAsync()
        {
        }
        #endregion

        #region public bool GetChangeStatus()
        ///<summary>
        ///Возвращает значение, показывающее были ли изменения в данном элементе управления
        ///</summary>
        ///<returns></returns>
        public bool GetChangeStatus()
        {
            if (_initialDocumentArray.Count != _currentItem.EmployeeDocuments.Count)
                return true;
            return false;
        }

        #endregion

        #region public bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        public bool ValidateData(out string message)
        {
            message = "";
            return true;
        }

        #endregion

        #region private void UpdateInformation()

        /// <summary>
        /// Заполняет поля для редактирования директивы
        /// </summary>
        private void UpdateInformation()
        {
            if (_currentItem == null)
                return;

			_initialDocumentArray.Clear();
			_resultDocumentArray.Clear();

			_initialDocumentArray.AddRange(_currentItem.EmployeeDocuments.ToArray());

            foreach (Document document in _initialDocumentArray)
                GlobalObjects.PerformanceCalculator.GetNextPerformance(document);

			FilterItems(_initialDocumentArray, _resultDocumentArray);

			documentationListView.SetItemsArray(_resultDocumentArray.ToArray());

            documentationListView.Focus();
        }

        #endregion

        #region public void ApplyChanges()

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public void ApplyChanges()
        {
            foreach (Document document in _resultDocumentArray)
            {
                document.Parent = _currentItem;
                document.ParentId = _currentItem.ItemId;
                document.ParentTypeId = _currentItem.SmartCoreObjectType.ItemId;
            }
        }
		#endregion

		#region public void SaveData()

		public void SaveData()
	    {
		    var unsaved = documentationListView.GetItemsArray().Where(i => i.ItemId <= 0).ToList();

		    try
		    {
			    GlobalObjects.DocumentCore.SaveDocumentsList(_currentItem, unsaved);
		    }
		    catch (Exception ex)
		    {
			    Program.Provider.Logger.Log("Error while save document", ex);
		    }
	    }

	    #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
			_resultDocumentArray.Clear();

            documentationListView.ItemListView.Clear();
        }

		#endregion

		#region private void InitToolStripMenuItems()

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
			if (documentationListView.SelectedItems == null ||
				documentationListView.SelectedItems.Count == 0) return;

			var document = documentationListView.SelectedItems[0];
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

		#region private void _toolStripMenuItemSaveAsTaskCard_Click(object sender, EventArgs e)

		private void _toolStripMenuItemSaveAsTaskCard_Click(object sender, EventArgs e)
	    {
		    if (documentationListView.SelectedItems == null ||
		        documentationListView.SelectedItems.Count == 0) return;

		    var document = documentationListView.SelectedItems[0];

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
				    MessageBox.Show("File saving was successful", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK,
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

		#endregion

		#region private void ContextMenuStripOpen(object sender, CancelEventArgs e)

		private void ContextMenuStripOpen(object sender, CancelEventArgs e)
		{
			if (documentationListView.SelectedItems.Count <= 0)
			{
				_toolStripMenuItemShowTaskCard.Enabled = false;
			}

			if (documentationListView.SelectedItems.Count == 1)
			{
				var document = documentationListView.SelectedItems[0];
				_toolStripMenuItemSaveAsTaskCard.Enabled = _toolStripMenuItemShowTaskCard.Enabled = document.AttachedFile != null;
			}
		}

		#endregion

		#region private void ButtonAddClick(object sender, EventArgs e)
		private void ButtonAddClick(object sender, EventArgs e)
        {
            var form = new DocumentForm(new Document(), _currentItem);

            if (form.ShowDialog() == DialogResult.OK)
            {
                InvokeReload();
            }
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (documentationListView.SelectedItems == null) return;

            DialogResult confirmResult =
                MessageBox.Show(
                    documentationListView.SelectedItem != null
                        ? "Do you really want to delete Document " + documentationListView.SelectedItem.Description + "?"
                        : "Do you really want to delete selected Documents? ", "Confirm delete operation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirmResult == DialogResult.Yes)
            {
                int count = documentationListView.SelectedItems.Count;

                List<Document> selectedItems = new List<Document>();
                selectedItems.AddRange(documentationListView.SelectedItems.ToArray());
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

                InvokeReload();
            }
            else
            {
                MessageBox.Show("Failed to delete Documents: Parent container is invalid", "Operation failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
	    {
		    var form = new CommonFilterForm(_filter, _initialDocumentArray);

		    if (form.ShowDialog(this) == DialogResult.OK)
		    {
			    AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			    AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

			    AnimatedThreadWorker.RunWorkerAsync();

			    InvokeReload();
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

		#region private void CopyToClipboard()
		private void CopyToClipboard()
		{
			// регистрация формата данных либо получаем его, если он уже зарегистрирован
			var format = DataFormats.GetFormat(typeof(Document[]).FullName);

			if (documentationListView.SelectedItems == null || documentationListView.SelectedItems.Count == 0)
				return;

			var pds = new List<Document>();
			foreach (var document in documentationListView.SelectedItems)
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
				var documents = (Document[])Clipboard.GetData(format);
				if (documents == null)
					return;

				var objectsToPaste = new List<Document>();
				foreach (var document in documents)
				{
					document.Parent = _currentItem;
					document.ParentId = _currentItem.ItemId;
					_initialDocumentArray.Add(document);
					document.ContractNumber += " Copy";
					objectsToPaste.Add(document);
				}

				if (objectsToPaste.Count > 0)
				{
					documentationListView.InsertItems(objectsToPaste.ToArray());
				}

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

		#endregion

		#region IReference Members

		/// <summary>
		/// Displayer for displaying entity
		/// </summary>
		public IDisplayer Displayer { get; set; }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText { get; set; }

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity { get; set; }

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType { get; set; }

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

		#endregion

		#region Events
		/// <summary>
		/// Событие возникает при добавлени, удалении и фильтрации(Производится перегрузка EmployeeScreen)
		/// </summary>
		public event EventHandler Reload;
		public void InvokeReload()
		{
			EventHandler handler = Reload;
			if (Reload != null) handler(this, new EventArgs());

		}
		#endregion
	}

	#region internal class EmployeeDocumentsControlDesigner : ControlDesigner

	internal class EmployeeDocumentsControlDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("CurrentItem");
            properties.Remove("DateOfBirth");
            properties.Remove("DateOfIssue");
            properties.Remove("ExpirationDate");
        }
    }
    #endregion
}
