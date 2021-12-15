using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.ComponentControls;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using TempUIExtentions;

namespace CAS.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    ///<summary>
    ///</summary>
    public sealed partial class BaseComponentEditorControl : UserControl
    {
        #region Fields
        private BaseComponent _currentBaseComponent;
        private Aircraft _currentAircraft;
        #endregion

        #region Constructor

        ///<summary>
        ///</summary>
        public BaseComponentEditorControl()
        {
            InitializeComponent();
            linkViewInfo.DisplayerRequested += LinkViewInfoDisplayerRequested;
        }

		#region public BaseComponentEditorControl(BaseComponent baseComponent, Aircraft aircraft) : this()
		///<summary>
		///</summary>
		public BaseComponentEditorControl(BaseComponent baseComponent, Aircraft aircraft) : this()
        {
            if(baseComponent == null)
                throw new ArgumentNullException("baseComponent", "can not be null");
            if(aircraft == null)
                throw new ArgumentNullException("aircraft", "can not be null");
            if(aircraft.ItemId <= 0)
                throw  new ArgumentException("can not add component on not exist aircraft", "aircraft");

            _currentBaseComponent = baseComponent;
            _currentAircraft = aircraft;
            UpdateControl();
        }
        #endregion

        #endregion

        #region Properties

        #region public BaseDetail CurrentBaseDetail
        ///<summary>
        ///</summary>
        public BaseComponent CurrentBaseComponent
        {
            get { return _currentBaseComponent; }
            set
            {
                _currentBaseComponent = value;
                if (value != null)
                {
                    labelCaption.Text = "Position #" + _currentBaseComponent.PositionNumber;
                    if(_currentBaseComponent.ItemId > 0)
                        linkViewInfo.DisplayerText = $"{_currentBaseComponent.GetParentAircraftRegNumber()}. Base Component {_currentBaseComponent.SerialNumber}";
					UpdateControl();
                }
            }
        }
        #endregion

        #endregion

        #region Methods

        #region public bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        public bool ValidateData(out string message)
        {
            if (_currentBaseComponent == null)
            {
                message = "";
                return true;
            }
            if (dateTimePickerManufactureDate.Value > DateTime.Now)
                dateTimePickerManufactureDate.Value = DateTime.Now;

            #region Поиск проверочного значения даты-времени
            //поиск минимального значения даты-времени среди значений
            //даты установки или даты начала отсчета наработки
            DateTime checkedDate = dateTimePickerInstallation.Value;
            message = $@"Installation Date:{dateTimePickerInstallation.Value}";
            if (dateTimePickerStart.Value < checkedDate)
            {
                checkedDate = dateTimePickerStart.Value;
                message = $@"the date of the origin of use:{dateTimePickerStart.Value}";
            }
            #endregion

            if (dateTimePickerManufactureDate.Value > checkedDate)
            {
                message = $@"For Component {_currentBaseComponent} 
                                         \nManufacture date {dateTimePickerManufactureDate.Value} must be less than {message}";
                dateTimePickerManufactureDate.Focus();
                return false;
            }

            if (_currentBaseComponent.ItemId > 0)
            {
                TransferRecord record = _currentBaseComponent.TransferRecords.GetLast();

                if (record.FromAircraftId != 0 ||
                    record.FromBaseComponentId != 0 ||
                    record.FromStoreId != 0)
                {
                    // Деталь была перемещена откуда - то,
                    // Ограничением будет дата начала перемещения
                    if (dateTimePickerInstallation.Value < record.StartTransferDate)
                    {
                        message = $@"For Component {_currentBaseComponent} 
                                                \nInstallation date {dateTimePickerInstallation.Value} must be grather than {message}";
                        dateTimePickerInstallation.Focus();
                        dateTimePickerInstallation.ForeColor = Color.Blue;
                        return false;
                    }
                }   
            }

            return true;
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            if (_currentBaseComponent == null)
                return false;

            TransferRecord lastTransfer = _currentBaseComponent.TransferRecords.GetLast();
            ActualStateRecord acr = lastTransfer != null
                                        ? _currentBaseComponent.ActualStateRecords[lastTransfer.TransferDate]
                                        : null;
	        return ((comboBoxEngineModel.SelectedItem?.ItemId != _currentBaseComponent.Model?.ItemId) ||
	                (textBoxManufacturer.Text != _currentBaseComponent.Manufacturer) ||
	                (textBoxPosition.Text != _currentBaseComponent.PositionNumber) ||
	                (textBoxSerialNumber.Text != _currentBaseComponent.SerialNumber) ||
	                (textBoxPartialNumber.Text != _currentBaseComponent.PartNumber) ||
	                (dateTimePickerManufactureDate.Value != _currentBaseComponent.ManufactureDate) ||
	                (!lifelengthViewerStart.Lifelength.IsEqual(_currentBaseComponent.StartLifelength)) ||
	                (dateTimePickerStart.Value != _currentBaseComponent.StartDate) ||
	                (!lifelengthViewerLifeLimit.Lifelength.IsEqual(_currentBaseComponent.LifeLimit)) ||
	                (!lifelengthViewerWarranty.Lifelength.IsEqual(_currentBaseComponent.Warranty)) ||
	                (lastTransfer != null
		                ? (lastTransfer.Position != textBoxPosition.Text)
		                : (textBoxPosition.Text != "")) ||
	                (lastTransfer != null
		                ? (lastTransfer.TransferDate != dateTimePickerInstallation.Value)
		                : (dateTimePickerInstallation.Value != DateTimeExtend.GetCASMinDateTime())));

        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные текущего базового агрегата
        /// </summary>
        public void SaveData()
        {
            if (_currentBaseComponent == null)
                return;
	        if ( comboBoxEngineModel.SelectedItem != null && comboBoxEngineModel.SelectedItem != _currentBaseComponent?.Model)
	        {
		        var d = comboBoxEngineModel.SelectedItem as ComponentModel;
				_currentBaseComponent.Model = d;
		        _currentBaseComponent.Description = d.FullName;
	        }
                
            if (textBoxManufacturer.Text != _currentBaseComponent.Manufacturer)
                _currentBaseComponent.Manufacturer = textBoxManufacturer.Text;
            _currentBaseComponent.ManufactureDate = dateTimePickerManufactureDate.Value;
            if (textBoxSerialNumber.Text != _currentBaseComponent.SerialNumber)
                _currentBaseComponent.SerialNumber = textBoxSerialNumber.Text;

            _currentBaseComponent.PartNumber = textBoxPartialNumber.Text;
            _currentBaseComponent.LifeLimit = lifelengthViewerLifeLimit.Lifelength;
            _currentBaseComponent.Warranty = lifelengthViewerWarranty.Lifelength;

            if(_currentBaseComponent.ItemId > 0)
            {
                #region Актуальное состояние на стартовую дату

                ActualStateRecord actualStateRecord = _currentBaseComponent.ActualStateRecords[_currentBaseComponent.StartDate];
                if (actualStateRecord == null)
                {
                    actualStateRecord = new ActualStateRecord();
                    actualStateRecord.ComponentId = _currentBaseComponent.ItemId;
                }

                actualStateRecord.RecordDate = dateTimePickerStart.Value;
                actualStateRecord.OnLifelength = lifelengthViewerStart.Lifelength;
                GlobalObjects.ComponentCore.RegisterActualState(_currentBaseComponent, actualStateRecord);
                
                #endregion

                _currentBaseComponent.StartDate = dateTimePickerStart.Value;
                _currentBaseComponent.StartLifelength = lifelengthViewerStart.Lifelength;

                TransferRecord record = _currentBaseComponent.TransferRecords.GetLast();
                ActualStateRecord actual = _currentBaseComponent.ActualStateRecords[record.TransferDate];
                if (record.Position != textBoxPosition.Text ||
                    record.TransferDate != dateTimePickerInstallation.Value ||
                    (actual != null
                         ? !actual.OnLifelength.IsEqual(lifelengthViewerInstallation.Lifelength)
                         : !lifelengthViewerInstallation.Lifelength.IsNullOrZero()))
                {

                    record.Position = textBoxPosition.Text;
                    if (actual != null)
                    {
                        if (record.TransferDate >= dateTimePickerInstallation.Value)
                        {
                            //Дата установки изменена на более раннюю
                            actual.OnLifelength = lifelengthViewerInstallation.Lifelength;
                            actual.RecordDate = dateTimePickerInstallation.Value;
                            GlobalObjects.CasEnvironment.NewKeeper.Save(actual);
                        }
                        else if (record.TransferDate < dateTimePickerInstallation.Value)
                        {
                            _currentBaseComponent.ActualStateRecords.Remove(actual);
                            actual.OnLifelength = lifelengthViewerInstallation.Lifelength;
                            actual.RecordDate = dateTimePickerInstallation.Value;
                            GlobalObjects.ComponentCore.RegisterActualState(_currentBaseComponent, actual);
                        }   
                    }
                    else
                    {
                        actual = new ActualStateRecord();
                        actual.ComponentId = _currentBaseComponent.ItemId;
                        actual.RecordDate = dateTimePickerInstallation.Value;
                        actual.OnLifelength = lifelengthViewerInstallation.Lifelength;
                        GlobalObjects.ComponentCore.RegisterActualState(_currentBaseComponent, actual);   
                    }
                    record.TransferDate = dateTimePickerInstallation.Value;
                    GlobalObjects.CasEnvironment.NewKeeper.Save(record);
                }

                //GlobalObjects.CasEnvironment.Keeper.Save(_currentBaseDetail.TransferRecords.GetLast());
                GlobalObjects.ComponentCore.Save(_currentBaseComponent);
                
            }
            else
            {
                _currentBaseComponent.StartDate = dateTimePickerStart.Value;
                _currentBaseComponent.StartLifelength = lifelengthViewerStart.Lifelength;

                GlobalObjects.ComponentCore.
                    AddBaseComponent(_currentBaseComponent,_currentAircraft,dateTimePickerInstallation.Value,
                                  textBoxPosition.Text,lifelengthViewerInstallation.Lifelength,true,false);
                ActualStateRecord actualStateRecord = _currentBaseComponent.ActualStateRecords[_currentBaseComponent.StartDate];
                if (actualStateRecord == null)
                {
                    actualStateRecord = new ActualStateRecord();
                    actualStateRecord.ComponentId = _currentBaseComponent.ItemId;
                }

                actualStateRecord.RecordDate = dateTimePickerInstallation.Value;
                actualStateRecord.OnLifelength = lifelengthViewerInstallation.Lifelength;
                GlobalObjects.ComponentCore.RegisterActualState(_currentBaseComponent, actualStateRecord);

            }
        }

        #endregion

        #region private void UpdateControl()

        /// <summary>
        /// Обновляет информацию о базовом агрегате текущего ВС
        /// </summary>
        private void UpdateControl()
        {
            if (_currentBaseComponent == null)
                return;
            
            comboBoxEngineModel.LoadObjectsFunc = GlobalObjects.CasEnvironment.GetComponentModels;
            comboBoxEngineModel.FilterParam1 = 6;
            comboBoxEngineModel.Type = typeof (ComponentModel);
            lifelengthViewerInstallation.MinLifelength = Lifelength.Zero;
            dateTimePickerInstallation.ValueChanged -= DateTimePickerManufactureDateValueChanged;
            dateTimePickerManufactureDate.ValueChanged -= DateTimePickerManufactureDateValueChanged;
            dateTimePickerStart.ValueChanged -= DateTimePickerManufactureDateValueChanged;
            comboBoxEngineModel.SelectedIndexChanged -= comboBoxEngineModel_SelectedIndexChanged;

            labelEngineModel.Text = _currentBaseComponent.BaseComponentType.ShortName + " Model";

            if (_currentBaseComponent.ItemId <= 0)
            {
                linkViewInfo.Visible = false;
                textBoxSerialNumber.Text = "Please, enter serial number";
                comboBoxEngineModel.SelectedItem = null;
                textBoxManufacturer.Text = "Please, enter manufacturer";
                textBoxPosition.Text = "Please, enter position";
                textBoxTSNCSN.Text = "";
            }
            else
            {
                textBoxSerialNumber.Text = _currentBaseComponent.SerialNumber;
                comboBoxEngineModel.SelectedItem = _currentBaseComponent.Model;
                textBoxManufacturer.Text = _currentBaseComponent.Manufacturer;
                textBoxPosition.Text = _currentBaseComponent.PositionNumber;
                textBoxTSNCSN.Text = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentBaseComponent).ToString();
                
            }

            textBoxPartialNumber.Text = _currentBaseComponent.PartNumber;

            dateTimePickerManufactureDate.Value = 
                _currentBaseComponent.ManufactureDate < dateTimePickerManufactureDate.MinDate 
                    ? dateTimePickerManufactureDate.MinDate 
                    : _currentBaseComponent.ManufactureDate;

            if (_currentBaseComponent.StartLifelength != null)
            {
                lifelengthViewerStart.Lifelength = _currentBaseComponent.StartLifelength;
            }
            if (_currentBaseComponent.StartDate.Year > 1950)
            {
                dateTimePickerStart.Value = _currentBaseComponent.StartDate;
            }
            else
            {
                dateTimePickerStart.Value = DateTimeExtend.GetCASMinDateTime();
            }
            if (_currentBaseComponent.LifeLimit != null)
            {
                lifelengthViewerLifeLimit.Lifelength = _currentBaseComponent.LifeLimit;
            }
            if (_currentBaseComponent.Warranty != null)
            {
                lifelengthViewerWarranty.Lifelength = _currentBaseComponent.Warranty;
            }

	        var lastTransferRecord = _currentBaseComponent.TransferRecords.GetLast();
			if (lastTransferRecord != null)
            {
                lifelengthViewerInstallation.Lifelength = lastTransferRecord.OnLifelength;
				dateTimePickerInstallation.Value = lastTransferRecord.TransferDate;
            }

            dateTimePickerInstallation.ValueChanged += DateTimePickerManufactureDateValueChanged;
            dateTimePickerManufactureDate.ValueChanged += DateTimePickerManufactureDateValueChanged;
            dateTimePickerStart.ValueChanged += DateTimePickerManufactureDateValueChanged;
            comboBoxEngineModel.SelectedIndexChanged += comboBoxEngineModel_SelectedIndexChanged;
        }

        #endregion

        #region private void linkViewInfo_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkViewInfoDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new ComponentScreenNew(_currentBaseComponent);
        }

        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if(_currentBaseComponent.ItemId > 0)
            {
                if (MessageBox.Show("Do you really want to delete this detail?", 
                                    "Deleting confirmation", 
                                    MessageBoxButtons.YesNo, 
                                    MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {   
                    return;
                }

                //todo : произвести необходимые проверки

                GlobalObjects.ComponentCore.DeleteBaseComponent(_currentBaseComponent);
            }
            if (Deleted != null)
                Deleted(this, EventArgs.Empty); 
        }
        #endregion

        #region private void DateTimePickerManufactureDateValueChanged(object sender, EventArgs e)

        private void DateTimePickerManufactureDateValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = sender as DateTimePicker;
           
            if (dtp == null)return;

            if (dtp.Value > DateTime.Now)
                dtp.Value = DateTime.Now;

            Lifelength lifelength = lifelengthViewerInstallation.Lifelength;
            lifelengthViewerInstallation.Lifelength = new Lifelength
                                                          {
                                                              Hours = lifelength.Hours,
                                                              Cycles = lifelength.Cycles,
                                                              Days =
                                                                  (dateTimePickerInstallation.Value -
                                                                   dateTimePickerManufactureDate.Value).Days
                                                          };
        }
        #endregion

        #region private void comboBoxEngineModel_SelectedIndexChanged(object sender, EventArgs e)

        private void comboBoxEngineModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComponentModel dm = comboBoxEngineModel.SelectedItem as ComponentModel;
            if (dm != null)
            {
                textBoxManufacturer.Text = dm.Manufacturer;
                textBoxPartialNumber.Text = dm.PartNumber;

                textBoxManufacturer.ReadOnly = true;
                textBoxPartialNumber.ReadOnly = true;
            }
            else
            {
                textBoxManufacturer.ReadOnly = false;
                textBoxPartialNumber.ReadOnly = false;
            }
        }

        #endregion

        #endregion

        #region Events
        /// <summary>
        /// Событие, сигнализирующее об удалении связной базовой детали
        /// </summary>
        public event EventHandler Deleted;

        #endregion

       

    }
}
