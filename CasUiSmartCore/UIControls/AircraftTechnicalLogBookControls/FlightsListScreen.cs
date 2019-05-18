using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AircraftTechnicalLogBookControls.AircraftFlightLight;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ScheduleControls.Trip;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class FlightsListScreen : ScreenControl
    {
        #region Fields

        private readonly ATLB _currentATLB;
        private readonly bool _allView;
        private AircraftFlightCollection _itemsArray = new AircraftFlightCollection();

        private FlightsListView _directivesViewer;

        private ContextMenuStrip _contextMenuStrip;
        private ToolStripMenuItem _toolStripMenuItemOpen;
        private ToolStripMenuItem _toolStripMenuItemOpenLight;
        private ToolStripMenuItem _toolStripMenuItemDelete;
        private ToolStripMenuItem _toolStripMenuItemHighlight;
        private ToolStripSeparator _toolStripSeparator1;
        private ToolStripSeparator _toolStripSeparator2;
        private ToolStripSeparator _toolStripSeparator4;

        #endregion

        #region Constructors

        #region private FlightsListScreen()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        private FlightsListScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public FlightsListScreen(ATLB currentAtlb) : this()
        ///<summary>
        /// Создает элемент управления для отображения списка агрегатов
        ///</summary>
        ///<param name="currentAtlb">Бортовой журнал, соержащий полеты</param>
        public FlightsListScreen(ATLB currentAtlb, bool allView = false)
            : this()
        {
            if (currentAtlb == null)
                throw new ArgumentNullException("currentAtlb", "Cannot display null-currentAtlb");
            _currentATLB = currentAtlb;
			_allView = allView;

            CurrentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(currentAtlb.ParentAircraftId);
            StatusTitle = currentAtlb + " " + "Fligths";

            InitToolStripMenuItems();
            InitListView();

			if(allView)
				UpdateControls();
        }

		#endregion

		#endregion

		#region Methods

		#region private void UpdateControls()

		private void UpdateControls()
		{
			buttonAddTripFlight.Enabled = false;
			buttonAddNew.Enabled = false;
			buttonAddNewLight.Enabled = false;
			buttonDeleteSelected.Enabled = false;
		}

		#endregion

		#region public override void DisposeScreen()
		public override void DisposeScreen()
        {
            if (AnimatedThreadWorker.IsBusy)
                AnimatedThreadWorker.CancelAsync();
            AnimatedThreadWorker.Dispose();

            _itemsArray.Clear();
            _itemsArray = null;

            if(_toolStripMenuItemOpen != null) _toolStripMenuItemOpen.Dispose();
            if(_toolStripMenuItemDelete != null) _toolStripMenuItemDelete.Dispose();
            if(_toolStripMenuItemHighlight != null) _toolStripMenuItemHighlight.Dispose();
            if(_toolStripSeparator1 != null) _toolStripSeparator1.Dispose();
            if(_toolStripSeparator2 != null) _toolStripSeparator2.Dispose();
            if(_toolStripSeparator4 != null) _toolStripSeparator4.Dispose();
            if(_contextMenuStrip != null) _contextMenuStrip.Dispose();

            if (_directivesViewer != null) _directivesViewer.DisposeView();

            Dispose(true);
        }

        #endregion

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateTitle();
            _directivesViewer.SetItemsArray(_itemsArray.ToArray());
            headerControl.PrintButtonEnabled = _directivesViewer.ListViewItemList.Count != 0;
            _directivesViewer.Focus();
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            _itemsArray.Clear();

            AnimatedThreadWorker.ReportProgress(0, "load Fligths");

	        GlobalObjects.AircraftFlightsCore.LoadAircraftFlights(CurrentAircraft.ItemId);

			_currentATLB.AircraftFlightsCollection = GlobalObjects.AircraftFlightsCore.GetFlightsByAtlb(CurrentAircraft.ItemId, _currentATLB.ItemId);
            foreach (AircraftFlight flight in _currentATLB.AircraftFlightsCollection)
                flight.ParentATLB = _currentATLB;
            
            AnimatedThreadWorker.ReportProgress(40, "filter Fligths");

            _itemsArray.AddRange(_currentATLB.AircraftFlightsCollection.ToArray());

            AnimatedThreadWorker.ReportProgress(70, "filter Fligths");

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

        #region private void InitToolStripMenuItems()

        private void InitToolStripMenuItems()
        {
            _contextMenuStrip = new ContextMenuStrip();
            _toolStripMenuItemOpen = new ToolStripMenuItem();
            _toolStripMenuItemOpenLight = new ToolStripMenuItem();
            _toolStripMenuItemDelete = new ToolStripMenuItem();
            _toolStripMenuItemHighlight = new ToolStripMenuItem();
            _toolStripSeparator1 = new ToolStripSeparator();
            _toolStripSeparator2 = new ToolStripSeparator();
            _toolStripSeparator4 = new ToolStripSeparator();
            // 
            // contextMenuStrip
            // 
            _contextMenuStrip.Name = "_contextMenuStrip";
            _contextMenuStrip.Size = new Size(179, 176);
            // 
            // toolStripMenuItemView
            // 
            _toolStripMenuItemOpen.Text = "Open Full";
            _toolStripMenuItemOpen.Click += ToolStripMenuItemOpenClick;
			// 
			// _toolStripMenuItemOpenLight
			// 
			_toolStripMenuItemOpenLight.Text = "Open Light";
	        _toolStripMenuItemOpenLight.Click += ToolStripMenuItemOpenLightClick;
            // 
            // toolStripMenuItemHighlight
            // 
            _toolStripMenuItemHighlight.Text = "Highlight";
            // 
            // toolStripMenuItemDelete
            // 
            _toolStripMenuItemDelete.Text = "Delete";
            _toolStripMenuItemDelete.Click += ButtonDeleteClick;

            _contextMenuStrip.Items.Clear();
            _toolStripMenuItemHighlight.DropDownItems.Clear();

            foreach (Highlight highlight in Highlight.HighlightList)
            {
                if (highlight == Highlight.Blue || highlight == Highlight.Yellow || highlight == Highlight.Red)
                    continue;
                ToolStripMenuItem item = new ToolStripMenuItem(highlight.FullName);
                item.Click += HighlightItemClick;
                item.Tag = highlight;
                _toolStripMenuItemHighlight.DropDownItems.Add(item);
            }
            _contextMenuStrip.Items.AddRange(new ToolStripItem[]
                                                {
                                                    _toolStripMenuItemOpen,
                                                    _toolStripMenuItemOpenLight,
                                                    _toolStripSeparator1,
                                                    _toolStripMenuItemHighlight,
                                                    _toolStripSeparator2,
                                                    _toolStripMenuItemDelete
                                                });
            _contextMenuStrip.Opening += ContextMenuStripOpen;
        }
        #endregion

        #region private void ContextMenuStripOpen(object sender,CancelEventArgs e)
        /// <summary>
        /// Проверка на выделение 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStripOpen(object sender, CancelEventArgs e)
        {
            if (_directivesViewer.SelectedItems.Count <= 0)
                e.Cancel = true;
            if (_directivesViewer.SelectedItems.Count == 1)
            {
                _toolStripMenuItemOpen.Enabled = true;
            }
        }

        #endregion

        #region private void HighlightItemClick(object sender, EventArgs e)

        private void HighlightItemClick(object sender, EventArgs e)
        {
            for (int i = 0; i < _directivesViewer.SelectedItems.Count; i++)
            {
                Highlight highLight = (Highlight)((ToolStripMenuItem)sender).Tag;

                _directivesViewer.SelectedItems[i].Highlight = highLight;
                _directivesViewer.ItemListView.SelectedItems[i].BackColor = Color.FromArgb(highLight.Color);
            }
        }

        #endregion

        #region private void ToolStripMenuItemOpenClick(object sender, EventArgs e)

        private void ToolStripMenuItemOpenClick(object sender, EventArgs e)
        {
            foreach (AircraftFlight o in _directivesViewer.SelectedItems)
            {
                ReferenceEventArgs refE = new ReferenceEventArgs
                                              {
                                                  TypeOfReflection = ReflectionTypes.DisplayInNew,
                                                  DisplayerText = CurrentAircraft.RegistrationNumber + ". " + o,
                                                  RequestedEntity = new FlightScreen(o)
                                              };
                InvokeDisplayerRequested(refE);
            }
        }

		#endregion

		#region private void ToolStripMenuItemOpenLightClick(object sender, EventArgs e)

		private void ToolStripMenuItemOpenLightClick(object sender, EventArgs e)
	    {
		    foreach (AircraftFlight o in _directivesViewer.SelectedItems)
		    {
			    ReferenceEventArgs refE = new ReferenceEventArgs
			    {
				    TypeOfReflection = ReflectionTypes.DisplayInNew,
				    DisplayerText = CurrentAircraft.RegistrationNumber + ". " + o,
				    RequestedEntity = new FlightScreenLight(o)
			    };
			    InvokeDisplayerRequested(refE);
		    }
	    }

	    #endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)

		private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (_directivesViewer.SelectedItems == null)
                return;
            DialogResult confirmResult = MessageBox.Show(_directivesViewer.SelectedItem != null
                        ? "Do you really want to delete aircraft flight " + _directivesViewer.SelectedItem.FlightNumber + "?"
                        : "Do you really want to delete selected aircraft flights? ", "Confirm delete operation",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (confirmResult == DialogResult.Yes)
            {
                int count = _directivesViewer.SelectedItems.Count;
                try
                {
                    List<AircraftFlight> selectedItems = new List<AircraftFlight>(_directivesViewer.SelectedItems);
                    _directivesViewer.ItemListView.BeginUpdate();
                    for (int i = 0; i < count; i++)
                    {
                        GlobalObjects.AircraftFlightsCore.Delete(selectedItems[i]);
                    }
					GlobalObjects.CasEnvironment.Calculator.ResetMath(CurrentAircraft);
                    _directivesViewer.ItemListView.EndUpdate(); 
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex);
                    return;
                }
            }
            AnimatedThreadWorker.RunWorkerAsync();
        }

        #endregion

        #region private void InitListView()

        private void InitListView()
        {
            _directivesViewer = new FlightsListView(CurrentAircraft, _allView);
            _directivesViewer.TabIndex = 2;
            _directivesViewer.ContextMenuStrip = _contextMenuStrip;
            _directivesViewer.Location = new Point(panel1.Left, panel1.Top);
            _directivesViewer.Dock = DockStyle.Fill;
            _directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;
            Controls.Add(_directivesViewer);
            panel1.Controls.Add(_directivesViewer);
        }

        #endregion

        #region private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

        private void DirectivesViewerSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            headerControl.EditButtonEnabled = _directivesViewer.SelectedItems.Count > 0;
        }

        #endregion

        #region private void UpdateTitle()
        private void UpdateTitle()
        {
            if (CurrentAircraft != null)
            {
                labelTitle.Text = "Date as of: " +
                    SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Aircraft TSN/CSN: " +
                    GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);

                labelDateAsOf.Text = "ATLB: " + _currentATLB.ATLBNo;
            }
            else
            {
                labelTitle.Text = "";
                labelTitle.Status = Statuses.NotActive;
            }
   
        }
        #endregion

        #region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

        private void HeaderControlButtonReloadClick(object sender, EventArgs e)
        {
            AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void HeaderControlButtonEditClick(object sender, EventArgs e)
        private void HeaderControlButtonEditClick(object sender, EventArgs e)
        {
            CommonEditorForm dlg = new CommonEditorForm(_currentATLB);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                UpdateTitle();
            }
        }
        #endregion

        #region private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        private void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            ReferenceEventArgs args = new ReferenceEventArgs();
            args.TypeOfReflection = ReflectionTypes.DisplayInNew;
	        var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentATLB.ParentAircraftId);
			args.DisplayerText = aircraft.RegistrationNumber + ". ATLB No " + _currentATLB.ATLBNo + ". Report";
            //args.RequestedEntity = new DispatcheredATLBReport(new ATLBBuilder(ATLBFlightsViewer.SelectedItem));
            e.Cancel = true;
        }
        #endregion

        #region private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
        {
			var form = new FlightForm(_currentATLB, CurrentAircraft);
	        if (form.ShowDialog() == DialogResult.OK)
	        {
		        AnimatedThreadWorker.RunWorkerAsync();
	        }
		}

		#endregion

		private void ButtonAddTripClick(object sender, EventArgs e)
		{
			var form = new TrackFlightForm(_currentATLB, CurrentAircraft);
			if (form.ShowDialog() == DialogResult.OK)
				AnimatedThreadWorker.RunWorkerAsync();
		}

	    private void ButtonAddLightDisplayerRequested(object sender, ReferenceEventArgs e)
	    {
		    e.DisplayerText = CurrentAircraft.RegistrationNumber + ". New Flight";
		    e.RequestedEntity = new FlightScreenLight(_currentATLB, CurrentAircraft, AtlbRecordType.Maintenance);
	    }

	    private void ButtonAddFullDisplayerRequested(object sender, ReferenceEventArgs e)
	    {
		    e.RequestedEntity = new FlightScreen(_currentATLB, CurrentAircraft, _allView, _allView);
		    e.DisplayerText = CurrentAircraft.RegistrationNumber + ". New Flight";
	    }

		#endregion
	}
}
