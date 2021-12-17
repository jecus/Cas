using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.PersonnelControls
{
	///<summary>
	///</summary>
	[ToolboxItem(false)]
	public partial class SpecializationsListScreen : ScreenControl
	{
		#region Fields

		private Operator _currentOperator;

		private CommonDictionaryCollection<Specialization> _itemsArray = new CommonDictionaryCollection<Specialization>();

		private SpecializationListView _directivesViewer;

		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuItemHighlight;
		private RadMenuSeparatorItem _toolStripSeparator1;

		#endregion

		#region Properties

		#endregion

		#region Constructors

		#region public SpecializationsListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public SpecializationsListScreen()
		{
			InitializeComponent();
		}
		#endregion

		#region public SpecializationsListScreen(Operator currentOperator)

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список директив
		///</summary>
		///<param name="currentOperator">ВС, которому принадлежат директивы</param>>
		public SpecializationsListScreen(Operator currentOperator)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			aircraftHeaderControl1.Operator = currentOperator;
			_currentOperator = currentOperator;
			statusControl.ShowStatus = false;
			labelTitle.Visible = false;
			buttonApplyFilter.Visible = false;

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
			_directivesViewer.SetItemsArray(_itemsArray.ToArray());
			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;
			_directivesViewer.Focus();
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_itemsArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load directives");

			_itemsArray.AddRange(GlobalObjects.CasEnvironment.GetDictionary<Specialization>());

			AnimatedThreadWorker.ReportProgress(40, "filter directives");

			AnimatedThreadWorker.ReportProgress(70, "filter directives");

			//FilterItems(_itemsArray);

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}
		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_toolStripMenuItemOpen = new RadMenuItem();
			_toolStripMenuItemHighlight = new RadMenuItem();
			_toolStripSeparator1 = new RadMenuSeparatorItem();
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemOpen.Text = "Open";
			_toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
			// 
			// toolStripMenuItemHighlight
			// 
			_toolStripMenuItemHighlight.Text = "Highlight";
			
			_toolStripMenuItemHighlight.Items.Clear();

			foreach (Highlight highlight in Highlight.HighlightList)
			{
				if (highlight == Highlight.Blue || highlight == Highlight.Yellow || highlight == Highlight.Red)
					continue;
				var item = new RadMenuItem(highlight.FullName);
				item.Click += HighlightItemClick;
				item.Tag = highlight;
				_toolStripMenuItemHighlight.Items.Add(item);
			}
		}
		#endregion

		#region private void HighlightItemClick(object sender, EventArgs e)

		private void HighlightItemClick(object sender, EventArgs e)
		{
			for (int i = 0; i < _directivesViewer.SelectedItems.Count; i++)
			{
				var highLight = (Highlight)((RadMenuItem)sender).Tag;
				foreach (GridViewCellInfo cell in _directivesViewer.radGridView1.SelectedRows[i].Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.BackColor = Color.FromArgb(highLight.Color);
				}
			}
		}

		#endregion

		#region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

		private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
		{
			
		}

		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)
		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null || 
				_directivesViewer.SelectedItems.Count == 0) return;

			DialogResult confirmResult =
				MessageBox.Show(_directivesViewer.SelectedItems.Count == 1
						? "Do you really want to delete specialization " + _directivesViewer.SelectedItems[0].FullName + "?"
						: "Do you really want to delete selected specializations? ", "Confirm delete operation",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				_directivesViewer.radGridView1.BeginUpdate();
				GlobalObjects.NewKeeper.Delete(_directivesViewer.SelectedItems.OfType<BaseEntityObject>().ToList(), true);
				_directivesViewer.radGridView1.EndUpdate();
				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new SpecializationListView();
			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
			Controls.Add(_directivesViewer);
			//события 
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

			_directivesViewer.AddMenuItems(_toolStripMenuItemOpen,
				_toolStripSeparator1,
				_toolStripMenuItemHighlight);

			_directivesViewer.MenuOpeningAction = () =>
			{
				if (_directivesViewer.SelectedItems.Count <= 0)
					return;
				if (_directivesViewer.SelectedItems.Count == 1)
				{
					_toolStripMenuItemOpen.Enabled = true;
				}
			};

			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

		private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			headerControl.EditButtonEnabled = _directivesViewer.SelectedItems.Count > 0;
		}

		#endregion

		#region private void UpdateInformation()
		/// <summary>
		/// Происзодит обновление отображения элементов
		/// </summary>
		private void UpdateInformation()
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			CommonEditorForm form = new CommonEditorForm(new Specialization());

			if (form.ShowDialog() == DialogResult.OK) 
				AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			//_filterSelection.PageTitle = (_currentAircraft != null
			//    ? CurrentAircraft.RegistrationNumber
			//    : _currentBaseDetail.Description)
			//    + " " + _currentPrimaryDirectiveType.CommonName;
			//_filterSelection.SetFilterParameters(_additionalFilter);
			//_filterSelection.Show();
			//_filterSelection.BringToFront();
			//_filterSelection.ApplyFilter -= FilterSelectionApplyFilter;
			//_filterSelection.ApplyFilter += FilterSelectionApplyFilter;
		}

		#endregion

		#endregion
	}
}
