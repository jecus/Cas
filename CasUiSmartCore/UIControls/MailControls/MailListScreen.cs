using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Mail;
using SmartCore.Filters;
using SmartCore.Purchase;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.MailControls
{
	public partial class MailListScreen : ScreenControl
	{
		private MailRecords _mailRecord;

		#region Fields

		private ICommonCollection<MailRecords> _initialDocumentArray = new CommonCollection<MailRecords>();
		private ICommonCollection<MailRecords> _resultDocumentArray = new CommonCollection<MailRecords>();
		private MailListView _directivesViewer;
		private CommonFilterCollection _filter;

		private readonly MailChats _mailChat;

		private RadDropDownMenu _contextMenuStrip;
		private RadMenuItem _toolStripMenuItemReply;
		private RadMenuItem _toolStripMenuItemAdd;
		private RadMenuItem _toolStripMenuItemDelete;
		private RadMenuItem _toolStripMenuItemPublish;
		private RadMenuItem _toolStripMenuItemClose;

		#endregion

		#region Constructor

		public MailListScreen()
		{
			InitializeComponent();
		}

		public MailListScreen(Operator currentOperator, MailChats mailChat) : this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator", "Cannot display null-currentOperator");

			aircraftHeaderControl1.Operator = currentOperator;
			_filter = new CommonFilterCollection(typeof(MailRecords));
			_mailChat = mailChat;


			var operatorName = GlobalObjects.CasEnvironment.Operators[0].Name;
			var from = _mailChat.SupplierFrom != Supplier.Unknown ? _mailChat.SupplierFrom.ToString() : operatorName;
			var to = _mailChat.SupplierTo != Supplier.Unknown ? _mailChat.SupplierTo.ToString() : operatorName;
			labelFromTo.Text = $"From - To: {from} - {to}";
			labelDescription.Text = $"Description: {_mailChat.Description}";

			InitToolStripMenuItems();
			InitListView();

			AnimatedThreadWorker.RunWorkerAsync();
		}

		public MailListScreen(Operator currentOperator, MailRecords mailRecord) : this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator", "Cannot display null-currentOperator");

			aircraftHeaderControl1.Operator = currentOperator;
			_filter = new CommonFilterCollection(typeof(MailRecords));

			_mailChat = new MailChats();
			_mailRecord = mailRecord;

			InitToolStripMenuItems();
			InitListView();

			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			_directivesViewer.SetItemsArray(_resultDocumentArray.ToArray());
			_directivesViewer.Focus();
		}

		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)

		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialDocumentArray.Clear();
			_resultDocumentArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load mail");

			try
			{
				_initialDocumentArray.AddRange(GlobalObjects.CasEnvironment.Loader.GetObjectListAll<MailRecords>(new CommonFilter<int>(MailRecords.MailChatIdProperty, _mailChat.ItemId),true).ToArray());
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while load inbox mail", ex);
			}

			AnimatedThreadWorker.ReportProgress(70, "filter mail");
			FilterItems(_initialDocumentArray, _resultDocumentArray);

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new MailListView();
			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.CustomMenu = _contextMenuStrip;
			Controls.Add(_directivesViewer);

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItem == null)
				{
					_toolStripMenuItemReply.Enabled = false;
					_toolStripMenuItemDelete.Enabled = _directivesViewer.SelectedItems.Count > 0;
					_toolStripMenuItemPublish.Enabled = false;
					_toolStripMenuItemClose.Enabled = false;
				}
				else
				{
					_toolStripMenuItemReply.Enabled = _mailChat.ItemId > 0;
					_toolStripMenuItemDelete.Enabled = true;

					_toolStripMenuItemPublish.Enabled = _directivesViewer.SelectedItem.Status != MailStatus.Published;
					_toolStripMenuItemClose.Enabled = _directivesViewer.SelectedItem.Status != MailStatus.Closed;

				}
			};

			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_contextMenuStrip = new RadDropDownMenu();
			_toolStripMenuItemReply = new RadMenuItem();
			_toolStripMenuItemDelete = new RadMenuItem();
			_toolStripMenuItemPublish = new RadMenuItem();
			_toolStripMenuItemClose = new RadMenuItem();

			// 
			// contextMenuStrip
			// 
			_contextMenuStrip.Name = "_contextMenuStrip";
			_contextMenuStrip.Size = new Size(179, 176);
			// 
			// toolStripMenuItemPaste
			// 
			_toolStripMenuItemReply.Text = "Reply";
			_toolStripMenuItemReply.Click += _toolStripMenuItemReply_Click;

			_toolStripMenuItemDelete.Text = "Delete";
			_toolStripMenuItemDelete.Click += _toolStripMenuItemDelete_Click;
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemPublish.Text = "Publish";
			_toolStripMenuItemPublish.Click += ToolStripMenuItemPublishClick;
			// 
			// toolStripMenuItemClose
			// 
			_toolStripMenuItemClose.Text = "Close";
			_toolStripMenuItemClose.Click += ToolStripMenuItemCloseClick;


			_contextMenuStrip.Items.AddRange(
				_toolStripMenuItemReply,
				new RadMenuSeparatorItem(), 
				_toolStripMenuItemPublish,
				_toolStripMenuItemClose,
				new RadMenuSeparatorItem(),
				_toolStripMenuItemDelete
			);
		}

		#endregion

		#region private void ToolStripMenuItemCloseClick(object sender, EventArgs e)

		private void ToolStripMenuItemCloseClick(object sender, EventArgs e)
		{
			var mail = _directivesViewer.SelectedItem;
			mail.ClosingDate = DateTime.Today;
			mail.Status = MailStatus.Closed;

			try
			{
				GlobalObjects.CasEnvironment.NewKeeper.Save(mail);
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save document", ex);
			}

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void ToolStripMenuItemPublishClick(object sender, EventArgs e)

		private void ToolStripMenuItemPublishClick(object sender, EventArgs e)
		{
			var mail = _directivesViewer.SelectedItem;
			mail.PublishingDate = DateTime.Today;
			mail.Status = MailStatus.Published;

			try
			{
				GlobalObjects.CasEnvironment.NewKeeper.Save(mail);
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save document", ex);
			}

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void _toolStripMenuItemReply_Click(object sender, EventArgs e)

		private void _toolStripMenuItemReply_Click(object sender, EventArgs e)
		{
			if(_directivesViewer.SelectedItem == null)
				return;

			var newMailRecord = new MailRecords
			{
				DocClass = _directivesViewer.SelectedItem.DocClass.Equals(DocumentClass.Outbox) ? DocumentClass.Inbox : DocumentClass.Outbox,
				ParentId = _directivesViewer.SelectedItem.ItemId,
				MailChatId = _mailChat.ItemId,
				ReferenceNumber = _directivesViewer.SelectedItem.MailNumber,
				Supplier = _mailChat.SupplierFrom != Supplier.Unknown ? _mailChat.SupplierFrom : _mailChat.SupplierTo
			};

			var form = new MailForm(newMailRecord);

			if (form.ShowDialog() == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}

		}

		#endregion

		#region private void _toolStripMenuItemDelete_Click(object sender, EventArgs e)

		private void _toolStripMenuItemDelete_Click(object sender, EventArgs e)
		{
			DeleteMail();
		}

		#endregion

		#region private void ButtonAddClick(object sender, EventArgs e)

		private void ButtonAddClick(object sender, EventArgs e)
		{
			if (_mailRecord == null)
			{
				var supplier = _mailChat.SupplierFrom != Supplier.Unknown ? _mailChat.SupplierFrom : _mailChat.SupplierTo;
				var docClass = _mailChat.SupplierFrom != Supplier.Unknown ? DocumentClass.Inbox : DocumentClass.Outbox;
				_mailRecord = new MailRecords
				{
					MailChatId = _mailChat.ItemId,
					Supplier = supplier,
					DocClass = docClass
				};
			}

			
			var form = new MailForm(_mailRecord);

			if (form.ShowDialog() == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
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

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			DeleteMail();
		}

		#endregion

		#region private void FilterItems(IEnumerable<Document> initialCollection, ICommonCollection<Document> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<MailRecords> initialCollection, ICommonCollection<MailRecords> resultCollection)
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

		#region private void DeleteMail()

		private void DeleteMail()
		{
			if (_directivesViewer.SelectedItems == null) return;

			var confirmResult =
				MessageBox.Show(
					_directivesViewer.SelectedItem != null
						? "Do you really want to delete Mail " + _directivesViewer.SelectedItem.Title + "?"
						: "Do you really want to delete selected Mail? ", "Confirm delete operation",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				var selectedItems = new List<MailRecords>();
				selectedItems.AddRange(_directivesViewer.SelectedItems.ToArray());
				GlobalObjects.CasEnvironment.NewKeeper.Delete(selectedItems.OfType<BaseEntityObject>().ToList(), true);

				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
			else
			{
				MessageBox.Show("Failed to delete Mail: Parent container is invalid", "Operation failed",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion
	}
}
