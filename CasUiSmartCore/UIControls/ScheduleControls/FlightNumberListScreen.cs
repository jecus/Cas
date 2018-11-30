﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.ScheduleControls.Trip;
using CASTerms;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Auxiliary;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Schedule;
using SmartCore.Filters;

namespace CAS.UI.UIControls.ScheduleControls
{
    ///<summary>
    /// Экран для отображения записей о неснижаемом запасе
    ///</summary>
    [ToolboxItem(false)]
    public partial class FlightNumberListScreen : ScreenControl
	{
		#region Fields

		private CommonCollection<FlightNumber> _initialFlightsArray = new CommonCollection<FlightNumber>();
		private CommonCollection<FlightNumber> _resultFlightsArray = new CommonCollection<FlightNumber>();

		private CommonCollection<FlightNumberPeriod> _initialPeriodArray = new CommonCollection<FlightNumberPeriod>();
		private CommonCollection<FlightNumberPeriod> _resultPeriodArray = new CommonCollection<FlightNumberPeriod>();

		private List<IFlightNumberParams> _result = new List<IFlightNumberParams>();

		private FlightNumberListView _directivesViewer;
		private CommonFilterCollection _filter;

		private bool firstLoad;
		private bool filterPeriod;

		private FlightNumberScreenType _screenType;

		private ContextMenuStrip _contextMenuStrip;
		private ToolStripMenuItem _toolStripMenuItemCreateTrip;
		private ToolStripMenuItem _toolStripMenuItemCopy;
		private ToolStripMenuItem _toolStripMenuItemPaste;
		private ToolStripSeparator _toolStripSeparator1;

		#endregion

		#region Constructors

		#region public FlightNumberListScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public FlightNumberListScreen()
        {
            InitializeComponent();
        }
		#endregion

		#region public FlightNumberListScreen(Store currentStore, PropertyInfo beginGroup = null) : this()

		///<summary>
		/// Создаёт экземпляр элемента управления, отображающего список неснижаемого запаса на складе
		///</summary>
		///<param name="currentOperator">Склад, которому принадлежат записи о неснижаемом запасе</param>
		///<param name="screenType"></param>
		public FlightNumberListScreen(Operator currentOperator, FlightNumberScreenType screenType) : this()
		{
            if (currentOperator == null)
                throw new ArgumentNullException("currentOperator");
            aircraftHeaderControl1.Operator = currentOperator;
            StatusTitle = "Flights";
			statusControl.ShowStatus = false;
			labelTitle.Visible = false;
			_screenType = screenType;

			_filter = new CommonFilterCollection(typeof(IFlightFilterParams));
			firstLoad = true;

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
            if (e.Cancelled)
                return;

	        if (firstLoad)
	        {
		        if (_initialPeriodArray.Count > 0)
		        {
			        dateTimePickerDateFrom.Value = _initialPeriodArray.Min(f => f.DepartureDate);
			        dateTimePickerDateTo.Value = _initialPeriodArray.Max(f => f.ArrivalDate);
		        }
		        else
		        {
			        dateTimePickerDateFrom.Value = DateTimeExtend.GetCASMinDateTime();
			        dateTimePickerDateTo.Value = DateTime.Today;
		        }
	        }

	        firstLoad = false;
	        filterPeriod = false;

			foreach (var flightNumber in _resultFlightsArray.OrderBy(f => f.FlightNo.FullName))
	        {
		        var periods = _resultPeriodArray.Where(f => f.FlightNumberId == flightNumber.ItemId);
		        if (periods.Any())
		        {
					_result.Add(flightNumber);
			        foreach (var period in periods)
			        {
				        _result.Add(period);
			        }
				}	
	        }

			_directivesViewer.SetItemsArray(_result.ToArray());
	        _directivesViewer.Focus();

            headerControl.PrintButtonEnabled = _directivesViewer.ItemListView.Items.Count != 0;
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
			#region Загрузка элементов

			_initialFlightsArray.Clear();
	        _resultFlightsArray.Clear();
	        _result.Clear();
	        _resultPeriodArray.Clear();
	        _initialPeriodArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load records");

            try
            {
				var flightTypes = new List<int>();
	            if (_screenType == FlightNumberScreenType.Schedule)
		            flightTypes.AddRange(FlightType.Items.Where(i => i.ItemId == FlightType.Schedule.ItemId).Select(i => i.ItemId));
				else flightTypes.AddRange(FlightType.Items.Where(i => i.ItemId != FlightType.Schedule.ItemId).Select(i => i.ItemId));

	            CommonFilter<int> filter;
				if(isAllRadioButton.Checked)
					filter = new CommonFilter<int>(FlightNumberPeriod.ScheduleProperty, FilterType.In, new []{0,1, -1});
				else if(isWinterRadioButton.Checked)
					filter = new CommonFilter<int>(FlightNumberPeriod.ScheduleProperty, 0);
				else filter = new CommonFilter<int>(FlightNumberPeriod.ScheduleProperty, 1);

				
	            _initialFlightsArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<FlightNumberDTO, FlightNumber>(new Filter("FlightType", flightTypes), true));
	            
	            var ids = _initialFlightsArray.Select(f => f.ItemId);

				var periods = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<FlightNumberPeriodDTO, FlightNumberPeriod>(new Filter("FlightNumberId", ids), true);
	            
				if (filterPeriod)
	            {
		            _initialPeriodArray.AddRange(periods.Where(t => t.DepartureDate >= dateTimePickerDateFrom.Value &&
		                                                            t.ArrivalDate <= dateTimePickerDateTo.Value));
				}
	            else _initialPeriodArray.AddRange(periods);

	            foreach (var period in _initialPeriodArray)
		            period.FlightNum = _initialFlightsArray.FirstOrDefault(f => f.ItemId == period.FlightNumberId);
            }
            catch (Exception exception)
            {
                Program.Provider.Logger.Log("Error while load records", exception);
            }

            AnimatedThreadWorker.ReportProgress(40, "Calculate records");

            #region Фильтрация директив

            AnimatedThreadWorker.ReportProgress(70, "filter records");

            FilterItems(_initialFlightsArray, _resultFlightsArray);
            FilterItems(_initialPeriodArray, _resultPeriodArray);

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

		#region protected override void InitListView(PropertyInfo beginGroup = null)

		private void InitListView()
        {
	        _directivesViewer = new FlightNumberListView(_screenType);
	        _directivesViewer.TabIndex = 2;
	        _directivesViewer.IgnoreAutoResize = true;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
	        _directivesViewer.Dock = DockStyle.Fill;
	        _directivesViewer.ContextMenuStrip = _contextMenuStrip;
			_directivesViewer.IgnoreAutoResize = true;

			//_directivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

            panel1.Controls.Add(_directivesViewer);
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

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_contextMenuStrip = new ContextMenuStrip();
			_toolStripMenuItemCreateTrip = new ToolStripMenuItem();
			_toolStripMenuItemCopy = new ToolStripMenuItem();
			_toolStripMenuItemPaste = new ToolStripMenuItem();
			_toolStripSeparator1 = new ToolStripSeparator();

			// 
			// contextMenuStrip
			// 
			_contextMenuStrip.Name = "_contextMenuStrip";
			_contextMenuStrip.Size = new Size(179, 176);
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemCreateTrip.Text = "Create Trip";
			_toolStripMenuItemCreateTrip.Click += ToolStripMenuItemCreateTripClick;

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

			_contextMenuStrip.Items.Clear();
			_contextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				_toolStripMenuItemCreateTrip,
				_toolStripSeparator1,
				_toolStripMenuItemCopy,
				_toolStripMenuItemPaste
			});
			_contextMenuStrip.Opening += ContextMenuStripOpen;
		}

		#endregion

		#region private void ToolStripMenuItemCreateTripClick(object sender, EventArgs e)

		private void ToolStripMenuItemCreateTripClick(object sender, EventArgs e)
		{
			if (!_directivesViewer.SelectedItems.All(p => p is FlightNumberPeriod))
			{
				MessageBox.Show("Please select only perods!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
				return;
			}

			var form = new TrackForm(_directivesViewer.SelectedItems);
			form.ShowDialog();
		}

		#endregion

		#region private void ContextMenuStripOpen(object sender, CancelEventArgs e)

		private void ContextMenuStripOpen(object sender, CancelEventArgs e)
		{
			if (_directivesViewer.SelectedItems.All(i => i is FlightNumber))
				_toolStripMenuItemCopy.Enabled = true;
			else _toolStripMenuItemCopy.Enabled = false;
		}

		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void HeaderControlSaveButtonClick(object sender, EventArgs e)

		private void HeaderControlSaveButtonClick(object sender, EventArgs e)
		{
			var unsaved = _directivesViewer.GetItemsArray().Where(i => i.ItemId <= 0).ToList();

			try
			{
				string errorMessage = "";

				foreach (var flightNumber in unsaved)
				{
					if(flightNumber is FlightNumber)
						GlobalObjects.AircraftFlightsCore.Save(flightNumber as FlightNumber);
				}

				if (string.IsNullOrEmpty(errorMessage))
				{
					MessageBox.Show("Saving was successful", "Message infomation", MessageBoxButtons.OK,
						MessageBoxIcon.Information);

					headerControl.ShowSaveButton = false;
				}
				else
				{
					MessageBox.Show(errorMessage, "Message warning", MessageBoxButtons.OK,
						MessageBoxIcon.Warning);

					headerControl.ShowSaveButton = true;
				}
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
			var form = new CommonFilterForm(_filter, _initialFlightsArray);

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
			_resultFlightsArray.Clear();
			_resultPeriodArray.Clear();
			_result.Clear();

			#region Фильтрация директив
			AnimatedThreadWorker.ReportProgress(50, "filter directives");

			FilterItems(_initialFlightsArray, _resultFlightsArray);
			FilterItems(_initialPeriodArray, _resultPeriodArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#endregion

		#region private void FilterItems(IEnumerable<FlightNumber> initialCollection, ICommonCollection<FlightNumber> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<FlightNumber> initialCollection, ICommonCollection<FlightNumber> resultCollection)
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

		#region private void FilterItems(IEnumerable<FlightNumber> initialCollection, ICommonCollection<FlightNumber> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<FlightNumberPeriod> initialCollection, ICommonCollection<FlightNumberPeriod> resultCollection)
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

		#region private void ButtonDeleteClick(object sender, EventArgs e)

		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null ||
			    _directivesViewer.SelectedItems.Count == 0) return;

			string typeName = typeof(FlightNumber).Name;

			DialogResult confirmResult =
				MessageBox.Show(_directivesViewer.SelectedItems.Count == 1
						? "Do you really want to delete " + typeName + " " + _directivesViewer.SelectedItems[0] + "?"
						: "Do you really want to delete selected " + typeName + "s?", "Confirm delete operation",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				_directivesViewer.ItemListView.BeginUpdate();
				foreach (var directive in _directivesViewer.SelectedItems)
				{
					try
					{
						GlobalObjects.CasEnvironment.NewKeeper.Delete(directive as BaseEntityObject, true);
					}
					catch (Exception ex)
					{
						Program.Provider.Logger.Log("Error while deleting data", ex);
						return;
					}
				}
				_directivesViewer.ItemListView.EndUpdate();
				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = aircraftHeaderControl1.Operator.Name;
			e.DisplayerText += ".Flight.New Flight";
			e.RequestedEntity = new FlightNumberScreen(new FlightNumber
			{
				DistanceMeasure = Measure.Kilometres,
			}, _screenType);
		}

		#endregion

		#region private void ButtonOkClick(object sender, EventArgs e)

		private void ButtonOkClick(object sender, EventArgs e)
		{
			filterPeriod = true;

			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void LinkTripDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkTripDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "Track";
			e.RequestedEntity = new FlightTrackListScreen(CurrentOperator, _screenType);
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
		}

		#endregion

		#region private void RadioButtonOnClick(object sender, EventArgs eventArgs)

		private void RadioButtonOnClick(object sender, EventArgs eventArgs)
		{
			firstLoad = true;
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void CopyItemsClick(object sender, EventArgs e)

		private void CopyItemsClick(object sender, EventArgs e)
		{
			CopyToClipboard();
		}

		#endregion

		#region private void PasteItemsClick(object sender, EventArgs e)

		private void PasteItemsClick(object sender, EventArgs e)
		{
			GetFromClipboard();
		}

		#endregion

		/*
         *  Копировать - Вставить - Вырезать
         */

		#region private void CopyToClipboard()
		private void CopyToClipboard()
		{
			// регистрация формата данных либо получаем его, если он уже зарегистрирован
			DataFormats.Format format = DataFormats.GetFormat(typeof(FlightNumber[]).FullName);

			if (_directivesViewer.SelectedItems == null || _directivesViewer.SelectedItems.Count == 0)
				return;

			//List<Directive> pds = _directivesViewer.SelectedItems;
			List<FlightNumber> pds = new List<FlightNumber>();
			var selectedItems = _directivesViewer.SelectedItems.ToArray();
			foreach (FlightNumber directive in selectedItems)
			{
				pds.Add(directive.GetCopyUnsaved());
			}

			if (pds.Count <= 0)
				return;

			//todo:(EvgeniiBabak) Нужен другой способ проверки сереализуемости объекта
			using (System.IO.MemoryStream mem = new System.IO.MemoryStream())
			{
				BinaryFormatter bin = new BinaryFormatter();
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
				var format = typeof(FlightNumber[]).FullName;

				if (string.IsNullOrEmpty(format))
					return;
				if (!Clipboard.ContainsData(format))
					return;
				var flightNumbers = (FlightNumber[])Clipboard.GetData(format);
				if (flightNumbers == null)
					return;

				var objectsToPaste = new List<IFlightNumberParams>();
				foreach (var flightNumber in flightNumbers)
				{
					flightNumber.FlightNo.FullName += " Copy";
					flightNumber.Description += " Copy";
					_result.Add(flightNumber);

					foreach (var period in flightNumber.FlightNumberPeriod)
					{
						period.FlightNum = flightNumber;
						_result.Add(period);
					}
					
					objectsToPaste.AddRange(flightNumber.FlightNumberPeriod.ToArray());
					objectsToPaste.Add(flightNumber);
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


		#endregion

	}
}
