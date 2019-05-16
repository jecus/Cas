using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class AllATLBListScreen : ScreenControl
    {
        #region Fields

        private CommonCollection<ATLB> _itemsArray = new CommonCollection<ATLB>();

        private ATLBListView _directivesViewer;

        private ContextMenuStrip _contextMenuStrip;
        private ToolStripMenuItem _toolStripMenuItemTitle;
       
        private ToolStripMenuItem _toolStripMenuItemProperties;
        private ToolStripSeparator _toolStripSeparator1;
        private ToolStripSeparator _toolStripSeparator2;

		#endregion

		#region Constructors

		#region private AllATLBListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private AllATLBListScreen()
        {
            InitializeComponent();
        }
		#endregion

		#region public AllATLBListScreen(ATLB currentAtlb)  : this()
		///<summary>
		/// Создает элемент управления для отображения списка агрегатов
		///</summary>
		///<param name="currentOperator">Бортовой журнал, соержащий полеты</param>
		public AllATLBListScreen(Operator oper)
            : this()
        {
            if (oper == null)
                throw new ArgumentNullException("currentOperator", "Cannot display null-currentOperator");

            CurrentOperator = oper;
            StatusTitle = "ATLBEvent";

            InitListView();
            UpdateInformation();
        }

		#endregion

		#region public ATLBListScreen(ATLB currentAtlb)  : this()
		///<summary>
		/// Создает элемент управления для отображения списка агрегатов
		///</summary>
		///<param name="currentAircraft">Бортовой журнал, соержащий полеты</param>
		public AllATLBListScreen(Aircraft currentAircraft)
			: this()
		{
			if (currentAircraft == null)
				throw new ArgumentNullException("currentAircraft", "Cannot display null-currentAircraft");

			CurrentAircraft = currentAircraft;
			StatusTitle = currentAircraft + " " + "Fligths";

			InitListView();
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

            _itemsArray.Clear();
            _itemsArray = null;

            
            if (_toolStripMenuItemTitle != null) _toolStripMenuItemTitle.Dispose();
            if (_toolStripMenuItemProperties != null) _toolStripMenuItemProperties.Dispose();
            if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
            if (_toolStripSeparator2 != null) _toolStripSeparator2.Dispose();
            if(_contextMenuStrip != null) _contextMenuStrip.Dispose();

            if (_directivesViewer != null) _directivesViewer.DisposeView();

            Dispose(true);
        }

        #endregion

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
                return;
			_directivesViewer.SetItemsArray(_itemsArray.ToArray());
            headerControl.PrintButtonEnabled = _directivesViewer.ListViewItemList.Count != 0;
            _directivesViewer.Focus();
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            _itemsArray.Clear();

            AnimatedThreadWorker.ReportProgress(0, "load ATLBs");

			//         var aircrafts = GlobalObjects.AircraftsCore.GetAllAircrafts();
			//         foreach (var aircraft in aircrafts)
			//         {
			//	_itemsArray.AddRange(GlobalObjects.AircraftFlightsCore.GetATLBsByAircraftId(aircraft.ItemId, true, true));
			//}

			_itemsArray.AddRange(GlobalObjects.AircraftFlightsCore.GetATLBsByAircraftId(CurrentAircraft.ItemId, true, true));

			AnimatedThreadWorker.ReportProgress(40, "filter ATLBs");

            AnimatedThreadWorker.ReportProgress(70, "filter ATLBs");

            AnimatedThreadWorker.ReportProgress(100, "Complete");
        }
        #endregion

        #region private void AddNew()
        private void AddNew()
        {
            ATLB newATLB = new ATLB(CurrentAircraft);
            CommonEditorForm form = new CommonEditorForm(newATLB);
            form.ShowDialog();
            if (newATLB.ItemId > 0)
            {
                AnimatedThreadWorker.RunWorkerAsync();
            }
        }
        #endregion

        #region private void DeleteSelected()
        private void DeleteSelected()
        {
            if (_directivesViewer.SelectedItems == null)
                return;
            DialogResult confirmResult = MessageBox.Show(_directivesViewer.SelectedItem != null
                        ? "Do you really want to delete ATLB " + _directivesViewer.SelectedItem.ATLBNo + "?"
                        : "Do you really want to delete selected ATLBs? ", "Confirm delete operation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (confirmResult == DialogResult.Yes)
            {
                int count = _directivesViewer.SelectedItems.Count;
                try
                {

                    List<ATLB> selectedItems = new List<ATLB>(_directivesViewer.SelectedItems);
                    _directivesViewer.ItemListView.BeginUpdate();
                    for (int i = 0; i < count; i++)
                    {
                        GlobalObjects.CasEnvironment.Manipulator.Delete(selectedItems[i]);
                    }
                    _directivesViewer.ItemListView.EndUpdate();
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex);
                    return;
                }
                AnimatedThreadWorker.RunWorkerAsync();
            }
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            DeleteSelected();
        }

        #endregion

        #region private void InitListView()

        private void InitListView()
        {
            _directivesViewer = new ATLBListView(CurrentAircraft, true);
            _directivesViewer.TabIndex = 2;
            _directivesViewer.ContextMenuStrip = _contextMenuStrip;
            _directivesViewer.Location = new Point(panel1.Left, panel1.Top);
            _directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.IgnoreAutoResize = true;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
            Controls.Add(_directivesViewer);
            panel1.Controls.Add(_directivesViewer);
        }

        #endregion

        #region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            headerControl.EditButtonEnabled = _directivesViewer.SelectedItems.Count > 0;
            headerControl.PrintButtonEnabled = _directivesViewer.SelectedItems.Count > 0;
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

        #region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            ReferenceEventArgs args = new ReferenceEventArgs();
            args.TypeOfReflection = ReflectionTypes.DisplayInNew;
            args.DisplayerText = ". ATLB List Report";
            //args.RequestedEntity = new DispatcheredATLBReport(new ATLBBuilder(ATLBFlightsViewer.SelectedItem));
            e.Cancel = true;
        }
        #endregion

        #region private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            AddNew();
            e.Cancel = true;
        }

        #endregion

        #endregion
    }
}
