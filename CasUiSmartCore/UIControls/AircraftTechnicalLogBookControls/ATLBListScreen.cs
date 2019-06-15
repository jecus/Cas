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
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class ATLBListScreen : ScreenControl
    {
        #region Fields

        private CommonCollection<ATLB> _itemsArray = new CommonCollection<ATLB>();

        private ATLBListView _directivesViewer;

        private RadDropDownMenu _contextMenuStrip;
        private RadMenuItem _toolStripMenuItemTitle;
        private RadMenuItem _toolStripMenuItemAdd;
        private RadMenuItem _toolStripMenuItemDelete;
        private RadMenuItem _toolStripMenuItemProperties;
        private RadMenuSeparatorItem _toolStripSeparator1;
        private RadMenuSeparatorItem _toolStripSeparator2;

        #endregion

        #region Constructors

        #region private ATLBListScreen()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        private ATLBListScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public ATLBListScreen(ATLB currentAtlb)  : this()
        ///<summary>
        /// Создает элемент управления для отображения списка агрегатов
        ///</summary>
        ///<param name="currentAircraft">Бортовой журнал, соержащий полеты</param>
        public ATLBListScreen(Aircraft currentAircraft)
            : this()
        {
            if (currentAircraft == null)
                throw new ArgumentNullException("currentAircraft", "Cannot display null-currentAircraft");

            CurrentAircraft = currentAircraft;
            StatusTitle = currentAircraft + " " + "Fligths";

            InitToolStripMenuItems();
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

            if (_toolStripMenuItemAdd != null) _toolStripMenuItemAdd.Dispose();
            if (_toolStripMenuItemDelete != null) _toolStripMenuItemDelete.Dispose();
            if (_toolStripMenuItemTitle != null) _toolStripMenuItemTitle.Dispose();
            if (_toolStripMenuItemProperties != null) _toolStripMenuItemProperties.Dispose();
            if (_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
            if (_toolStripSeparator2 != null) _toolStripSeparator2.Dispose();
            if(_contextMenuStrip != null) _contextMenuStrip.Dispose();

            if (_directivesViewer != null) _directivesViewer.Dispose();

            Dispose(true);
        }

        #endregion

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
                return;
			//TODO:(Evgenii Babak) создать метод для получения названия ATLB по FlightId
            var last = GlobalObjects.AircraftFlightsCore.GetLastAircraftFlight(CurrentAircraft.ItemId);
            if(last != null)
            {
                var lastAtlb = _itemsArray.GetItemById(last.ATLBId);
                labelDateAsOf.Text = lastAtlb != null ? "Current ATLB: " +  lastAtlb : ""; 
            }
            _directivesViewer.SetItemsArray(_itemsArray.ToArray());
            headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;
            _directivesViewer.Focus();
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            _itemsArray.Clear();

            AnimatedThreadWorker.ReportProgress(0, "load ATLBs");

            _itemsArray.AddRange(GlobalObjects.AircraftFlightsCore.GetATLBsByAircraftId(CurrentAircraft.ItemId, true));

#if SCAT
	        GlobalObjects.AircraftFlightsCore.LoadAircraftFlights(CurrentAircraft.ItemId);
#endif

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
                    _directivesViewer.radGridView1.BeginUpdate();
                    for (int i = 0; i < count; i++)
                    {
                        GlobalObjects.CasEnvironment.Manipulator.Delete(selectedItems[i]);
                    }
                    _directivesViewer.radGridView1.EndUpdate();
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

        #region private void InitToolStripMenuItems()

        private void InitToolStripMenuItems()
        {
            _contextMenuStrip = new RadDropDownMenu();
            _toolStripMenuItemTitle = new RadMenuItem();
            _toolStripSeparator1 = new RadMenuSeparatorItem();
            _toolStripMenuItemAdd = new RadMenuItem();
            _toolStripMenuItemDelete = new RadMenuItem();
            _toolStripSeparator2 = new RadMenuSeparatorItem();
            _toolStripMenuItemProperties = new RadMenuItem();
            // 
            // contextMenuStrip
            // 
            _contextMenuStrip.Name = "_contextMenuStrip";
            _contextMenuStrip.Size = new Size(179, 176);
            // toolStripMenuItemTitle

            _toolStripMenuItemTitle.Text = "Edit";
            _toolStripMenuItemTitle.Click += ToolStripMenuItemEditClick;
            // 
            // toolStripMenuItemAdd
            // 
            _toolStripMenuItemAdd.Text = "Add ATLB";
            _toolStripMenuItemAdd.Click += ToolStripMenuItemAddClick;
            // 
            // toolStripMenuItemDelete
            // 
            _toolStripMenuItemDelete.Text = "Delete";
            _toolStripMenuItemDelete.Click += ToolStripMenuItemDeleteClick;
            // 
            // toolStripMenuItemProperties
            // 
            _toolStripMenuItemProperties.Text = "Properties";
            _toolStripMenuItemProperties.Click += ToolStripMenuItemPropertiesClick;

            _contextMenuStrip.Items.AddRange(
	            _toolStripMenuItemTitle,
	            _toolStripSeparator1,
	            _toolStripMenuItemAdd,
	            _toolStripMenuItemDelete,
	            _toolStripSeparator2,
	            _toolStripMenuItemProperties
	            );
			
		}
        #endregion
		
        #region private void ToolStripMenuItemEditClick(object sender, EventArgs e)

        private void ToolStripMenuItemEditClick(object sender, EventArgs e)
        {
            foreach (ATLB o in _directivesViewer.SelectedItems)
            {
                ReferenceEventArgs refE = new ReferenceEventArgs
                {
                    TypeOfReflection = ReflectionTypes.DisplayInNew,
                    DisplayerText = CurrentAircraft.RegistrationNumber + ". ATLB No " + o.ATLBNo,
                    RequestedEntity = new FlightsListScreen(o)
                };
                InvokeDisplayerRequested(refE);
            }
        }

        #endregion

        #region private void ToolStripMenuItemAddClick(object sender, EventArgs e)

        private void ToolStripMenuItemAddClick(object sender, EventArgs e)
        {
            AddNew();
        }

        #endregion

        #region private void ToolStripMenuItemDeleteClick(object sender, EventArgs e)

        private void ToolStripMenuItemDeleteClick(object sender, EventArgs e)
        {
            DeleteSelected();
        }

        #endregion

        #region private void ToolStripMenuItemPropertiesClick(object sender, EventArgs e)

        private void ToolStripMenuItemPropertiesClick(object sender, EventArgs e)
        {
            //ATLBForm form = new ATLBForm(_directivesViewer.SelectedItem);
            //form.ShowDialog();

            var form = new CommonEditorForm(_directivesViewer.SelectedItem);
	        if (form.ShowDialog() == DialogResult.OK)
				AnimatedThreadWorker.RunWorkerAsync();
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
            _directivesViewer = new ATLBListView(CurrentAircraft);
            _directivesViewer.TabIndex = 2;
            _directivesViewer.CustomMenu = _contextMenuStrip;
            _directivesViewer.Location = new Point(panel1.Left, panel1.Top);
            _directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
            Controls.Add(_directivesViewer);
            panel1.Controls.Add(_directivesViewer);


            _directivesViewer.MenuOpeningAction = () =>
            {
	            if (_directivesViewer.ItemsCount <= 0)
		            return;
	            _toolStripMenuItemTitle.Enabled = _directivesViewer.ItemsCount > 0;
	            _toolStripMenuItemDelete.Enabled = _directivesViewer.ItemsCount > 0;
	            _toolStripMenuItemProperties.Enabled = _directivesViewer.ItemsCount > 0;
            };
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
            if (CurrentAircraft != null)
            {
                labelTitle.Text = "Date as of: " +
                    SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Aircraft TSN/CSN: " +
                    GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
            }
            else
            {
                labelTitle.Text = "";
                labelTitle.Status = Statuses.NotActive;
            }
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
            args.DisplayerText = CurrentAircraft.RegistrationNumber + ". ATLB List Report";
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
