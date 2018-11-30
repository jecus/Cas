using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary.Events;
using CAS.UI.UIControls.DetailsControls;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Store;
using Component = SmartCore.Entities.General.Accessory.Component;

namespace CAS.UI.UIControls.ComponentControls
{
    ///<summary>
    /// описывает окно для введения главной информации о компоненте 
    ///</summary>
    [Designer(typeof(ComponentAddingGeneralInformationDesigner))]
    public partial class ComponentAddingGeneralInformationControl : UserControl
    {

        #region Fields

        private Component _addedComponent;
        private object _currentAircraft;
        private bool _isStore;

        #endregion

        #region Constructor

        #region public DetailAddingGeneralInformationControl(object parent)
        /// <summary>
        /// Создает элемент управления, использующийся для задания общей информации при добавлении агрегата
        /// </summary>
        public ComponentAddingGeneralInformationControl(object parent, Component addedComponent)
        {
            if (addedComponent == null)
                throw new ArgumentNullException("addedComponent");

            _currentAircraft = parent;
            _addedComponent = addedComponent;

            _isStore = parent is Store || parent is Operator;
            InitializeComponent();
            UpdateControl();
        }
        #endregion

        #region public DetailAddingGeneralInformationControl()
        ///<summary>
        ///</summary>
        public ComponentAddingGeneralInformationControl()
        {
            InitializeComponent();
        }
        
        #endregion

        #endregion

        #region Propeties

        #region public Detail AddedDetail

        ///<summary>
        /// Задает добавляемую деталь
        ///</summary>
        public Component AddedComponent
        {
            set { _addedComponent = value; }
        }
        #endregion

        #region public Detail ParentObject

        ///<summary>
        /// Задает родительский объект для добавляемой детали
        ///</summary>
        public object ParentObject
        {
            set
            {
                if (value == null)
                    _currentAircraft = null;
                else if (value is BaseComponent)
                    _currentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(((BaseComponent) value).ParentAircraftId);
				else
                    _currentAircraft = value;

                _isStore = _currentAircraft is Store || _currentAircraft is Operator;
                UpdateControl();
            }
        }
        #endregion

        #region public string MPDItem

        /// <summary>
        /// MPD Item создаваемого агрегата
        /// </summary>
        public string MPDItem
        {
            get { return textBoxMPDItem.Text; }
            set
            {
                textBoxMPDItem.Text = value;
            }
        }

        #endregion

        #region public ATAChapter ATAChapter

        /// <summary>
        /// ATA глава создаваемого агрегата
        /// </summary>
        public AtaChapter ATAChapter
        {
            get
            {
                return comboBoxAtaChapter.ATAChapter;
            }
            set
            {
                comboBoxAtaChapter.ATAChapter = value;
            }
        }

        #endregion

        #region public MaintenanceControlProcess MaintenanceControlProcess

        /// <summary>
        /// Тип обслуживания агрегата
        /// </summary>
        public MaintenanceControlProcess MaintenanceControlProcess
        {
            get
            {
                return comboBoxMaintenenceType.SelectedItem as MaintenanceControlProcess;
            }
            set
            {
                comboBoxMaintenenceType.SelectedItem = value;
            }
        }

        #endregion

        #region public string PartNumber

        /// <summary>
        /// Партийный номер создаваемого агрегата
        /// </summary>
        public string PartNumber
        {
            get { return textBoxPartNo.Text; }
            set
            {
                textBoxPartNo.Text = value;
            }
        }

        #endregion

        #region public string Code
        /// <summary>
        /// Код создаваемого агрегата
        /// </summary>
        public string Code
        {
            get { return textBoxProductCode.Text; }
            set
            {
                textBoxProductCode.Text = value;
            }
        }

		#endregion

		#region public ComponentStorePosition State

		public ComponentStorePosition State
	    {
		    get
		    {
			    return comboBoxStorePosition.SelectedItem as ComponentStorePosition;
		    }
		    set
		    {
			    comboBoxStorePosition.SelectedItem = value;
		    }
	    }

	    #endregion

		#region public string Position

		/// <summary>
		/// Отображаемое положение 
		/// </summary>
		public string Position
		{
			get
			{
				return textBoxPosition.Text;
			}
			set
			{
				textBoxPosition.Text = value;
			}
		}

		#endregion

		#region  private Locations ComponentLocation

		/// <summary>
		/// Полка на складе
		/// </summary>
		private Locations ComponentLocation
		{
			get
			{
				var location = dictionaryComboBoxLocation.SelectedItem as Locations;
				return location ?? Locations.Unknown;
			}
			set
			{
				dictionaryComboBoxLocation.SelectedItem = value;
			}
		}

		#endregion

		#region public string SerialNumber

		/// <summary>
		/// Серийный номер создаваемого агрегата
		/// </summary>
		public string SerialNumber
        {
            get { return textBoxSerialNo.Text; }
            set
            {
                textBoxSerialNo.Text = value;
            }
        }

        #endregion

        #region public string BatchNumber

        /// <summary>
        /// Пакетный номер создаваемого агрегата
        /// </summary>
        public string BatchNumber
        {
            get { return textBoxBatchNumber.Text; }
            set
            {
                textBoxBatchNumber.Text = value;
            }
        }

        #endregion

        #region public string IdNumber

        /// <summary>
        /// Идентификационный номер создаваемого агрегата
        /// </summary>
        public string IdNumber
        {
            get { return textBoxIdNumber.Text; }
            set
            {
                textBoxIdNumber.Text = value;
            }
        }

        #endregion

        #region public string Description

        /// <summary>
        /// Описание создаваемого агрегата
        /// </summary>
        public string Description
        {
            get { return textBoxDescription.Text; }
            set
            {
                textBoxDescription.Text = value;
            }
        }

        #endregion

        #region private GoodsClass GoodsClass
        /// <summary>
        /// DetailType
        /// </summary>
        private GoodsClass GoodsClass
        {
            get
            {
                GoodsClass type =
                    comboBoxComponentType.SelectedItem as GoodsClass;
                return type ?? GoodsClass.Unknown;
            }
            set { comboBoxComponentType.SelectedItem = value ?? GoodsClass.Unknown; }
        }

        #endregion

        #region public DateTime InstallationDate
        /// <summary>
        /// Дата установки агрегата на ВС
        /// </summary>
        public DateTime InstallationDate
        {
            get { return dateTimePickerInstallationDate.Value; }
            set
            {
                dateTimePickerInstallationDate.Value = value;
            }
        }

        #endregion

        #region public DateTime ManufactureDate
        /// <summary>
        /// Дата производства компонента
        /// </summary>
        public DateTime ManufactureDate
        {
            get { return dateTimePickerManufactureDate.Value; }
            set
            {
                dateTimePickerManufactureDate.Value = value;
            }
        }

        #endregion

        #region public Lifelength ComponentTSNCSN

        /// <summary>
        /// Наработка агрегата на момент установки
        /// </summary>
        public Lifelength ComponentTCSNOnInstall
        {
            get { return lifelengthViewerComponentTCSNOnInstall.Lifelength; }
            set
            {
                lifelengthViewerComponentTCSNOnInstall.Lifelength = value;
            }
        }

        #endregion

        #region public Lifelength AircraftTSNCSN

        /// <summary>
        /// Наработка ВС на момент установки агрегата
        /// </summary>
        public Lifelength AircraftTCSNOnInstall
        {
            get { return lifelengthViewerAircraftTCSNOnInstall.Lifelength; }
            set
            {
                lifelengthViewerAircraftTCSNOnInstall.Lifelength = value;
            }
        }

        #endregion

        #region public Lifelength ComponentCurrentTSNCSN

        /// <summary>
        /// Текущая наработка агрегата
        /// </summary>
        public Lifelength ComponentCurrentTSNCSN
        {
            get { return lifelengthViewerComponentCurrentTSNCSN.Lifelength; }
            set
            {
                lifelengthViewerComponentCurrentTSNCSN.Lifelength = value;
            }
        }

        #endregion

        #region public Lifelength ComponentTCSI

        /// <summary>
        /// Наработка агрегата с момента установки
        /// </summary>
        public Lifelength ComponentTCSI
        {
            get { return lifelengthViewerComponentTCSI.Lifelength; }
            set
            {
                lifelengthViewerComponentTCSI.Lifelength = value;
            }
        }

        #endregion

        #region public bool SetCurrentComponentTSNCSN

        /// <summary>
        /// Возвращает значение, показывающее нужно ли добавлять запись ActualData на текущее число
        /// </summary>
        public bool SetCurrentComponentTSNCSN
        {
            get
            {
                return (lifelengthViewerComponentCurrentTSNCSN.Enabled && !lifelengthViewerComponentCurrentTSNCSN.Lifelength.IsNullOrZero());
            }
        }

        #endregion

        #region public bool SetActualDataToAircraft

        /// <summary>
        /// Возвращает значение, показывающее нужно ли добавлять запись ActualData к ВС
        /// </summary>
        public bool SetActualDataToAircraft
        {
            get
            {
                return lifelengthViewerAircraftTCSNOnInstall.Modified;
            }
        }

        #endregion

        #region public bool LLPMark
        /// <summary>
        /// Дата производства компонента
        /// </summary>
        public bool LLPMark
        {
            get { return checkBoxLLPMark.Checked; }
            set { checkBoxLLPMark.Checked = value;}
        }

		#endregion

		#region public bool IsPool

		public bool IsPool
	    {
		    get { return checkBoxPOOL.Checked; }
		    set { checkBoxPOOL.Checked = value; }
	    }

		#endregion

		#region public bool IsDangerous

		public bool IsDangerous
	    {
		    get { return checkBoxDangerous.Checked; }
		    set { checkBoxDangerous.Checked = value; }
	    }

	    #endregion

		#region public DateTime DateAsOf

		/// <summary>
		/// Текущая дата 
		/// </summary>
		public DateTime DateAsOf
        {
            get { return dateTimePickerDateAsOf.Value; }
            set
            {
                dateTimePickerDateAsOf.Value = value;
            }
        }

		#endregion

		#endregion

		#region Methods

	    public void UpdateComponentClass(BaseComponent component)
	    {
			if(component.BaseComponentType == BaseComponentType.Engine)
				comboBoxComponentType.SelectedItem = GoodsClass.AircraftBaseComponentsEngine;
			else comboBoxComponentType.SelectedItem = GoodsClass.AircraftComponents;
		}

		#region public void UpdateControl()
		/// <summary>
		/// Обновляет контрол
		/// </summary>
		public void UpdateControl()
        {
            if (_isStore)
            {
                labelLocation.Visible = true;
                dictionaryComboBoxLocation.Visible = true;
				dictionaryComboBoxLocation.Type = typeof(Locations);
				comboBoxStorePosition.Location = textBoxPosition.Location;//new Point(103, 344);
                comboBoxStorePosition.Visible = true;
                comboBoxStorePosition.Items.Clear();
				comboBoxStorePosition.Items.AddRange(ComponentStorePosition.Items.ToArray());
				comboBoxStorePosition.SelectedIndex = 3;
				Controls.Remove(labelAircraftTSNCSN);
                Controls.Remove(lifelengthViewerAircraftTCSNOnInstall);
                Controls.Remove(labelTCSI);
                Controls.Remove(lifelengthViewerComponentTCSI);

                FormControlAttribute fca = (FormControlAttribute)
                typeof(Component)
                    .GetProperty("GoodsClass")
                    .GetCustomAttributes(typeof(FormControlAttribute), false)
                    .FirstOrDefault();
                if (fca != null)
                    comboBoxComponentType.RootNodesNames = fca.TreeDictRootNodes;
                comboBoxComponentType.Type = typeof(GoodsClass);
                comboBoxComponentType.SelectedItem = GoodsClass.AircraftComponents;
            }
            else
            {
                comboBoxComponentType.RootNodesNames = new []{ "ComponentsAndParts", "ProductionAuxiliaryEquipment" };
                comboBoxComponentType.Type = typeof(GoodsClass);
                comboBoxComponentType.SelectedItem = GoodsClass.AircraftComponents;    
            }
            comboBoxModel.Type = typeof(ComponentModel);
            comboBoxModel.SelectedItem = null;
            comboBoxModel.Focus();
            Program.MainDispatcher.ProcessControl(comboBoxModel);

            comboBoxAtaChapter.UpdateInformation();
            comboBoxMaintenenceType.Items.Clear();
            comboBoxMaintenenceType.Items.AddRange(MaintenanceControlProcess.Items.ToArray());
            comboBoxMaintenenceType.SelectedItem = MaintenanceControlProcess.OC;

            comboBoxStatus.Items.Clear();
            foreach (object o in Enum.GetValues(typeof(ComponentStatus)))
                comboBoxStatus.Items.Add(o);
            comboBoxStatus.SelectedItem = ComponentStatus.New;

            ManufactureDate = DateTime.Today;
            dateTimePickerDeliveryDate.Value = DateTime.Today;
            InstallationDate = DateTime.Today;
            DateAsOf = DateTime.Today;
		}

        #endregion

        #region public void CalculateLifeLength()

        public void CalculateLifeLength()
        {
            //изменение значения наработки агрегата на момент установки
            if (ComponentTCSNOnInstall.IsNullOrZero()) return;//разбанить поля 

            //if (ComponentCurrentTSNCSN != Lifelength.Null)
            //{
            //    Lifelength tempLifelength = new Lifelength(ComponentCurrentTSNCSN);
            //    tempLifelength.Substract(ComponentTCSNOnInstall);
            //    ComponentTCSI = tempLifelength;
            //}

            Lifelength aircraftCurrentTSN =
                GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength((Aircraft)_currentAircraft);
            Lifelength tempLifelength = null;

            //Расчитывание текущей наработки агрегата
            if (!ComponentTCSI.IsNullOrZero())
            {
                tempLifelength = new Lifelength(ComponentTCSI);
            }
            else if (!AircraftTCSNOnInstall.IsNullOrZero() && _currentAircraft is Aircraft)
            {
                tempLifelength = new Lifelength(aircraftCurrentTSN);
                tempLifelength.Substract(AircraftTCSNOnInstall);
            }

            if (tempLifelength != null && !tempLifelength.IsNullOrZero())
            {
                tempLifelength.Add(ComponentTCSNOnInstall);
                ComponentCurrentTSNCSN = tempLifelength;
            }
            else ComponentCurrentTSNCSN = Lifelength.Null;

            //расчет наработки с момента установки
            if (!ComponentTCSNOnInstall.IsNullOrZero() && !ComponentCurrentTSNCSN.IsNullOrZero())
            {
                tempLifelength = new Lifelength(ComponentCurrentTSNCSN);
                tempLifelength.Substract(ComponentTCSNOnInstall);
                ComponentTCSI = tempLifelength;
            }
            else if (!AircraftTCSNOnInstall.IsNullOrZero() && !aircraftCurrentTSN.IsNullOrZero())
            {
                tempLifelength = new Lifelength(aircraftCurrentTSN);
                tempLifelength.Substract(AircraftTCSNOnInstall);
                ComponentTCSI = tempLifelength;
            }
            else ComponentTCSI = Lifelength.Null;

            //расчет наработки самолета на момент установки
            if (!ComponentTCSI.IsNullOrZero())
            {
                tempLifelength = new Lifelength(aircraftCurrentTSN);
                tempLifelength.Substract(ComponentTCSI);
                AircraftTCSNOnInstall = tempLifelength;
            }
            else if (!ComponentCurrentTSNCSN.IsNullOrZero() && !ComponentTCSNOnInstall.IsNullOrZero())
            {
                Lifelength temp2 = new Lifelength(ComponentCurrentTSNCSN);
                temp2.Substract(ComponentTCSNOnInstall);
                tempLifelength = new Lifelength(aircraftCurrentTSN);
                tempLifelength.Substract(temp2);
                AircraftTCSNOnInstall = tempLifelength;
            }
            else AircraftTCSNOnInstall = Lifelength.Null;

        }

        #endregion

        #region public void ChangeAircraftTCSNOnInstall()
        /// <summary>
        /// Изменение значения наработки самолета на момент установки
        /// </summary>
        public void ChangeAircraftTCSNOnInstall()
        {
            //если отсутствует текущая наработка самолета установки
            //то дальнейшее расчитать нельзя
            Lifelength aircraftCurrent =
                    GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay((Aircraft)_currentAircraft, dateTimePickerDateAsOf.Value);

            if (aircraftCurrent.IsNullOrZero())
            {
                if (lifelengthViewerAircraftTCSNOnInstall.SystemCalculated)
                {
                    //если данные в наработку с момента установеи вводила система,
                    //а не пользователь, то их нужно обнулить
                    AircraftTCSNOnInstall = Lifelength.Null;
                }
                return;
            }

            if (AircraftTCSNOnInstall.IsNullOrZero() ||
                lifelengthViewerAircraftTCSNOnInstall.SystemCalculated)
            {
                //Если наработка самолета с момента установки не введена или
                //введена системой, то её надо расчитать
                Lifelength temp;
                if (!ComponentCurrentTSNCSN.IsNullOrZero() &&
                    !ComponentTCSNOnInstall.IsNullOrZero())
                {
                    //если известна текущая наработка агрегата и
                    //наработка агрегата на момент установки
                    temp = new Lifelength(ComponentCurrentTSNCSN);
                    temp.Substract(ComponentTCSNOnInstall);
                    aircraftCurrent.Substract(temp);
                    AircraftTCSNOnInstall = aircraftCurrent;
                    lifelengthViewerAircraftTCSNOnInstall.SystemCalculated = true;
                    return;
                }
                
                if (!ComponentTCSI.IsNullOrZero())
                {
                    //если известна наработка агрегата с момента установки
                    temp = new Lifelength(aircraftCurrent);
                    temp.Substract(ComponentTCSI);
                    AircraftTCSNOnInstall = temp;
                    lifelengthViewerAircraftTCSNOnInstall.SystemCalculated = true;
                    return;
                }

                //иначе, наработку высчитать нельзя
                AircraftTCSNOnInstall = Lifelength.Null;
                lifelengthViewerAircraftTCSNOnInstall.SystemCalculated = true;
            }
        }

        #endregion

        #region public void ChangeComponentTCSNOnInstall()
        /// <summary>
        /// Изменение значения наработки агрегата на момент установки
        /// </summary>
        public void ChangeComponentTCSNOnInstall()
        {
            //если отсутствует текущая наработка агрегата
            //то дальнейшее расчитать нельзя
            if (ComponentCurrentTSNCSN.IsNullOrZero())
            {
                if (lifelengthViewerComponentTCSNOnInstall.SystemCalculated)
                {
                    //если данные в наработку на момент установки вводила система,
                    //а не пользователь, то их нужно обнулить
                    ComponentTCSNOnInstall = Lifelength.Null;
                }
                return;
            }

            if (ComponentTCSNOnInstall.IsNullOrZero() ||
                lifelengthViewerComponentTCSNOnInstall.SystemCalculated)
            {
                //Если наработка агрегата на момент установки не введена или
                //введена системой, то её надо расчитать
                Lifelength temp = new Lifelength(ComponentCurrentTSNCSN);
                if (!ComponentTCSI.IsNullOrZero())
                {
                    //если известна наработка агрегата с момента установки
                    temp.Add(ComponentTCSI);
                    ComponentTCSNOnInstall = temp;
                    lifelengthViewerComponentTCSNOnInstall.SystemCalculated = true;
                    return;
                }

                Lifelength aircraftCurrent =
                    GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay((Aircraft)_currentAircraft, dateTimePickerDateAsOf.Value);

                if (!AircraftTCSNOnInstall.IsNullOrZero() &&
                    !aircraftCurrent.IsNullOrZero())
                {
                    //если известна текущая наработка самолета и
                    //наработка самолета на момент установки
                    aircraftCurrent.Substract(AircraftTCSNOnInstall);
                    temp.Substract(aircraftCurrent);
                    ComponentTCSNOnInstall = temp;
                    lifelengthViewerComponentTCSNOnInstall.SystemCalculated = true;
                    return;
                }

                //иначе, наработку высчитать нельзя
                ComponentTCSNOnInstall = Lifelength.Null;
                lifelengthViewerComponentTCSNOnInstall.SystemCalculated = true;
            }

        }

        #endregion

        #region public void ChangeCurrentComponentTSN()
        /// <summary>
        /// Изменение значения наработки агрегата на текущий момент
        /// </summary>
        public void ChangeCurrentComponentTSN()
        {
            //если отсутствует наработка агрегата на момент установки
            //то дальнейшее расчитать нельзя
            if(ComponentTCSNOnInstall.IsNullOrZero())
            {
                if (lifelengthViewerComponentCurrentTSNCSN.SystemCalculated)
                {
                    //если данные в текущую наработку вводила система,
                    //а не пользователь, то их нужно обнулить
                    ComponentCurrentTSNCSN = Lifelength.Null;
                }
                return;
            }
            
            if(ComponentCurrentTSNCSN.IsNullOrZero() || 
                lifelengthViewerComponentCurrentTSNCSN.SystemCalculated)
            {
                //Если текущая наработка агрегата не введена или
                //введена системой, то её надо расчитать
                Lifelength temp = new Lifelength(ComponentTCSNOnInstall);
                if(!ComponentTCSI.IsNullOrZero())
                {
                    //если известна наработка агрегата с момента установки
                    temp.Add(ComponentTCSI);
                    temp.Resemble(ComponentTCSNOnInstall);
                    ComponentCurrentTSNCSN = temp;
                    lifelengthViewerComponentCurrentTSNCSN.SystemCalculated = true;
                    return;
                }

                if (_isStore) return;
                Lifelength aircraftCurrent = 
                    GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay((Aircraft)_currentAircraft,dateTimePickerDateAsOf.Value);
                
                if(!AircraftTCSNOnInstall.IsNullOrZero() &&
                   !aircraftCurrent.IsNullOrZero())
                {
                    //если известна текущая наработка самолета и
                    //наработка самолета на момент установки
                    aircraftCurrent.Substract(AircraftTCSNOnInstall);
                    temp.Substract(aircraftCurrent);
                    temp.Resemble(ComponentTCSNOnInstall);
                    ComponentCurrentTSNCSN = temp;
                    lifelengthViewerComponentCurrentTSNCSN.SystemCalculated = true;
                    return;
                }

                //иначе, наработку высчитать нельзя
                ComponentCurrentTSNCSN = Lifelength.Null;
                lifelengthViewerComponentCurrentTSNCSN.SystemCalculated = true;
            }

        }

        #endregion

        #region public void ChangeComponentTSNSinseInstall()
        /// <summary>
        /// Изменение значения наработки агрегата с момента установки
        /// </summary>
        public void ChangeComponentTSNSinseInstall()
        {
            if(_isStore) return;
            //если отсутствует наработка агрегата на момент установки
            //то дальнейшее расчитать нельзя
            Lifelength aircraftCurrent =
                    GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay((Aircraft)_currentAircraft, dateTimePickerDateAsOf.Value);

            if ((aircraftCurrent.IsNullOrZero() && AircraftTCSNOnInstall.IsNullOrZero()) ||
                (ComponentCurrentTSNCSN.IsNullOrZero() && ComponentTCSNOnInstall.IsNullOrZero()))
            {
                if (lifelengthViewerComponentTCSI.SystemCalculated)
                {
                    //если данные в наработку с момента установеи вводила система,
                    //а не пользователь, то их нужно обнулить
                    ComponentTCSI = Lifelength.Null;
                }
                return;
            }

            if (ComponentTCSI.IsNullOrZero() ||
                lifelengthViewerComponentTCSI.SystemCalculated)
            {
                //Если наработка агрегата с момента установки не введена или
                //введена системой, то её надо расчитать
                Lifelength temp;
                if (!aircraftCurrent.IsNullOrZero() &&
                    !AircraftTCSNOnInstall.IsNullOrZero())
                {
                    //если известна текущая наработка самолета и
                    //наработка самолета на момент установки
                    temp = new Lifelength(aircraftCurrent);
                    temp.Substract(AircraftTCSNOnInstall);
                    ComponentTCSI = temp;
                    lifelengthViewerComponentCurrentTSNCSN.SystemCalculated = true;
                    return;
                }

                if (!ComponentCurrentTSNCSN.IsNullOrZero() && 
                    !ComponentTCSNOnInstall.IsNullOrZero())
                {
                    //если известна текущая наработка агрегата и
                    //наработка агрегата на момент установки
                    temp = new Lifelength(ComponentCurrentTSNCSN);
                    temp.Substract(ComponentTCSNOnInstall);
                    ComponentTCSI = temp;
                    lifelengthViewerComponentCurrentTSNCSN.SystemCalculated = true;
                    return;
                }
                //иначе, наработку высчитать нельзя
                ComponentTCSI = Lifelength.Null;
                lifelengthViewerComponentCurrentTSNCSN.SystemCalculated = true;
            }
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            return (comboBoxModel.SelectedItem != null ||
                    (comboBoxStatus.SelectedItem is ComponentStatus && (ComponentStatus)comboBoxStatus.SelectedItem != ComponentStatus.New) ||
                    textBoxManufacturer.Text != "" ||
                    MPDItem != "" ||
                    ATAChapter != null ||
                    MaintenanceControlProcess != MaintenanceControlProcess.UNK ||
                    Description != "" ||
                    PartNumber != "" ||
                    Code != "" ||
                    Position != "" ||
                    SerialNumber != "" || BatchNumber != "" || IdNumber != "" ||
                    dateTimePickerDeliveryDate.Value != DateTime.Today ||
                    InstallationDate != DateTime.Today ||
                    lifelengthViewerComponentTCSNOnInstall.Modified ||
                    lifelengthViewerAircraftTCSNOnInstall.Modified ||
                    DateAsOf != DateTime.Today ||
                    lifelengthViewerComponentCurrentTSNCSN.Modified ||
                    lifelengthViewerComponentTCSI.Modified);
        }

		#endregion

		#region public void ApplyChanges(Detail detail)

		public void ApplyChanges(Component component)
	    {
		    component.Model = comboBoxModel.SelectedItem as ComponentModel;
		    component.ComponentStatus = comboBoxStatus.SelectedItem is ComponentStatus
			    ? (ComponentStatus) comboBoxStatus.SelectedItem
			    : ComponentStatus.New;
		    component.Manufacturer = textBoxManufacturer.Text;
		    component.MPDItem = MPDItem;
		    component.ATAChapter = ATAChapter;
		    component.Description = Description;
		    component.DeliveryDate = dateTimePickerDeliveryDate.Value;
		    component.PartNumber = PartNumber;
		    component.Code = Code;
		    component.SerialNumber = SerialNumber;
		    component.BatchNumber = BatchNumber;
		    component.IdNumber = IdNumber;
		    component.ManufactureDate = ManufactureDate;
		    component.MaintenanceControlProcess = MaintenanceControlProcess;
		    component.LLPMark = checkBoxLLPMark.Checked;
		    component.Location = ComponentLocation;
		    component.GoodsClass = GoodsClass;
		    component.IsDangerous = IsDangerous;
		    component.IsPOOL = IsPool;
	    }
		#endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            comboBoxAtaChapter.ClearValue();
            comboBoxModel.SelectedItem = null;
            comboBoxStatus.SelectedItem = ComponentStatus.New;
            textBoxPosition.Text = "";
            MPDItem = "";
            Description = "";
            PartNumber = "";
            SerialNumber = "";
            BatchNumber = "";
            IdNumber = "";
			Code = "";
	        textBoxALTPN.Text = "";
			ManufactureDate = DateTime.Today;
            dateTimePickerDeliveryDate.Value = DateTime.Today;
            InstallationDate = DateTime.Today;
            ComponentTCSNOnInstall = Lifelength.Null;
            lifelengthViewerComponentTCSNOnInstall.Modified = false;
            comboBoxMaintenenceType.SelectedItem = MaintenanceControlProcess.OC;
            if (!_isStore)
            {
                //AircraftTSNCSN = GlobalObjects.CasEnvironment.Calculator.GetLifelength()
                lifelengthViewerAircraftTCSNOnInstall.Modified = false;
            }
            DateAsOf = DateTime.Today;
            // ComponentCurrentTSNCSN = Lifelength.Null;
            //  lifelengthViewerComponentCurrentTSNCSN.Modified = false;
            //   ComponentTCSI = Lifelength.Null;
            // lifelengthViewerComponentTCSI.Modified = false;
        }

        #endregion

        #region private void DateTimePickerInstallationDateValueChanged(object sender, EventArgs e)

        private void DateTimePickerInstallationDateValueChanged(object sender, EventArgs e)
        {
            if (!lifelengthViewerAircraftTCSNOnInstall.Modified)
            {
                if (!_isStore)
                {
                    if (InstallationDate <= DateTime.Today)
                    {
                        AircraftTCSNOnInstall = GlobalObjects.CasEnvironment.Calculator.
                            GetFlightLifelengthOnEndOfDay((Aircraft) _currentAircraft, InstallationDate);
                    }
                    else
                    {
                        AircraftTCSNOnInstall = GlobalObjects.CasEnvironment.Calculator.
                            GetFlightLifelengthOnEndOfDay((Aircraft)_currentAircraft, DateTime.Today);
                    }
                    lifelengthViewerAircraftTCSNOnInstall.Modified = false;
                    lifelengthViewerAircraftTCSNOnInstall.SystemCalculated = true;
                }
            }

            Lifelength onInstall = new Lifelength(ComponentTCSNOnInstall);
            onInstall.Days = (int)(InstallationDate - ManufactureDate).TotalDays;

            ComponentTCSNOnInstall = onInstall;
            lifelengthViewerComponentTCSNOnInstall.SystemCalculated = true;
        }

        #endregion

        #region private void LifelengthViewerComponentCurrentTsncsnLifelengthChanged(object sender, EventArgs e)

        private void LifelengthViewerComponentCurrentTsncsnLifelengthChanged(object sender, EventArgs e)
        {
            //изменение значения текущей наработки агрегата
            lifelengthViewerComponentCurrentTSNCSN.SystemCalculated = false;

            if (ComponentCurrentTSNCSN.IsGreater(ComponentTCSNOnInstall) == false) return;

            if(!lifelengthViewerComponentTCSNOnInstall.SystemCalculated)
            {
                ChangeComponentTSNSinseInstall();
                ChangeAircraftTCSNOnInstall();

                return;
            }

            if(!lifelengthViewerComponentTCSI.SystemCalculated)
            {
                ChangeComponentTCSNOnInstall();
                ChangeAircraftTCSNOnInstall();

                return;
            }

            if(!lifelengthViewerAircraftTCSNOnInstall.SystemCalculated)
            {
                ChangeComponentTSNSinseInstall();
                ChangeAircraftTCSNOnInstall();
            }
        }

        #endregion

        #region private void LifelengthViewerComponentTcsiLifelengthChanged(object sender, EventArgs e)

        private void LifelengthViewerComponentTcsiLifelengthChanged(object sender, EventArgs e)
        {
            //изменение значения наработки агрегата с момента установки
            lifelengthViewerComponentTCSI.SystemCalculated = false;

            if (!lifelengthViewerComponentCurrentTSNCSN.SystemCalculated)
            {
                ChangeComponentTCSNOnInstall();
                ChangeAircraftTCSNOnInstall();

                return;
            }

            if (!lifelengthViewerComponentTCSNOnInstall.SystemCalculated)
            {
                //значение наработки компонента на момент установки 
                //введено пользователем

                ChangeCurrentComponentTSN();//пересчет текущего значения наработки агрегата 
                ChangeAircraftTCSNOnInstall();//пересчет значения наработки самолета на момент установки агрегата

                return;
            }

            if (!lifelengthViewerAircraftTCSNOnInstall.SystemCalculated)
            {
                //значение наработки самолета на момент установки агрегата 
                //введено пользователем
                ChangeCurrentComponentTSN();
                ChangeComponentTCSNOnInstall();
            }
        }

        #endregion

        #region private void LifelengthViewerComponentTsncsnLifelengthChanged(object sender, EventArgs e)

        private void LifelengthViewerComponentTsncsnLifelengthChanged(object sender, EventArgs e)
        {
            //изменение значения наработки агрегата на момент установки
            lifelengthViewerComponentTCSNOnInstall.SystemCalculated = false;

            if (!lifelengthViewerComponentCurrentTSNCSN.SystemCalculated)//текущая наработка
            {
                ChangeAircraftTCSNOnInstall();
                ChangeComponentTSNSinseInstall();
                
                return;
            }

            if (!lifelengthViewerComponentTCSI.SystemCalculated)
            {
                //значение наработки компонента с момента установки 
                //введено пользователем

                ChangeCurrentComponentTSN();//пересчет текущего значения наработки агрегата 
                ChangeAircraftTCSNOnInstall();//пересчет значения наработки самолета на момент установки агрегата

                return;
            }

            //if (!lifelengthViewerAircraftTCSNOnInstall.SystemCalculated)
            //{
                //значение наработки самолета на момент установки агрегата 
                //введено пользователем

                ChangeComponentTSNSinseInstall();
                ChangeCurrentComponentTSN();
            //}

        }

        #endregion

        #region private void DateTimePickerManufactureDateValueChanged(object sender, EventArgs e)

        private void DateTimePickerManufactureDateValueChanged(object sender, EventArgs e)
        {
            Lifelength onInstall = new Lifelength(ComponentTCSNOnInstall);
            onInstall.Days = (int)(InstallationDate - ManufactureDate).TotalDays;

            ComponentTCSNOnInstall = onInstall;
            lifelengthViewerComponentTCSNOnInstall.SystemCalculated = true;

            InvokeManufactureDateChanged(dateTimePickerManufactureDate.Value);
        }

        #endregion

        #region private void LifelengthViewerAircraftTcsnOnInstallLifelengthChanged(object sender, EventArgs e)

        private void LifelengthViewerAircraftTcsnOnInstallLifelengthChanged(object sender, EventArgs e)
        {
            //изменение значения наработки самолета на момент установки агрегата
            lifelengthViewerAircraftTCSNOnInstall.SystemCalculated = false;

            if (!lifelengthViewerComponentTCSNOnInstall.SystemCalculated)//наработка на момент установки
            {
                ChangeComponentTSNSinseInstall();
                ChangeCurrentComponentTSN();

                return;
            }

            if (!lifelengthViewerComponentCurrentTSNCSN.SystemCalculated)
            {
                ChangeComponentTCSNOnInstall();
                ChangeComponentTSNSinseInstall();
                
                return;
            }

            if (!lifelengthViewerComponentTCSI.SystemCalculated)
            {
                //значение наработки самолета на момент установки агрегата 
                //введено пользователем

                ChangeCurrentComponentTSN();
                ChangeComponentTCSNOnInstall();
            }

        }

        #endregion

        #region private void DictionaryComboProductSelectedIndexChanged(object sender, EventArgs e)
        private void DictionaryComboProductSelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBoxStandart.SelectedIndexChanged -= ComboBoxStandartSelectedIndexChanged;

            ComponentModel accessoryDescription;
            if ((accessoryDescription = comboBoxModel.SelectedItem as ComponentModel) != null)
            {
                comboBoxComponentType.SelectedItem = accessoryDescription.GoodsClass;

                comboBoxComponentType.Enabled = false;

                comboBoxAtaChapter.ATAChapter = accessoryDescription.ATAChapter;
                comboBoxAtaChapter.Enabled = false;
                //comboBoxMeasure.Enabled = false;
                //comboBoxStandart.Enabled = false;
                textBoxPartNo.ReadOnly = true;
                textBoxDescription.ReadOnly = true;
                //textBoxProductCode.ReadOnly = true;
                //dataGridViewControlSuppliers.ReadOnly = true;
                //textBoxRemarks.ReadOnly = true;

                //comboBoxMeasure.SelectedItem = accessoryDescription.Measure;
                //comboBoxStandart.SelectedItem = accessoryDescription.Standart;
                textBoxPartNo.Text = accessoryDescription.PartNumber;
                textBoxDescription.Text = accessoryDescription.Description;
                //textBoxProductCode.Text = accessoryDescription.Code;
                textBoxManufacturer.Text = accessoryDescription.Manufacturer;
                //dataGridViewControlSuppliers.SetItemsArray(accessoryDescription.SupplierRelations);
                //textBoxRemarks.Text = accessoryDescription.Remarks;
            }
            else
            {
                comboBoxComponentType.Enabled = true;
                comboBoxAtaChapter.Enabled = true;
                textBoxPartNo.ReadOnly = false;
                textBoxDescription.ReadOnly = false;
                //textBoxProductCode.ReadOnly = false;
                //dataGridViewControlSuppliers.ReadOnly = false;
                //textBoxRemarks.ReadOnly = false;
                //numericCostNew.ReadOnly = false;
                //numericCostServiceable.ReadOnly = false;
                //numericCostOverhaul.ReadOnly = false;
            }

            //comboBoxStandart.SelectedIndexChanged += ComboBoxStandartSelectedIndexChanged;
        }
        #endregion

        #region private void CheckBoxLLPMarkCheckedChanged(object sender, EventArgs e)
        private void CheckBoxLLPMarkCheckedChanged(object sender, EventArgs e)
        {
            _addedComponent.LLPMark = checkBoxLLPMark.Checked;
			//TODO: разобраться с этим кодом
            //if (LLPMarkChecked != null) LLPMarkChecked(this, e);
        }
        #endregion

        #region private void ComboBoxComponentTypeSelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxComponentTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            GoodsClass dt = comboBoxComponentType.SelectedItem as GoodsClass;
            if (dt == null)
                labelQuantity.Visible = numericUpDownQuantity.Visible = false;
            else if (dt.IsNodeOrSubNodeOf(GoodsClass.AircraftComponentsEmergency))
                labelQuantity.Visible = numericUpDownQuantity.Visible = true;
            else labelQuantity.Visible = numericUpDownQuantity.Visible = false;

            InvokeComponentTypeChanged(dt ?? GoodsClass.Unknown);
        }
        #endregion

        #endregion

        #region  Events
        ///<summary>
        ///</summary>
        public event EventHandler LLPMarkChecked;

        #region public event ValueChangedEventHandler ComponentTypeChanged
        ///<summary>
        /// Сигнализирует о смене типа компонента
        ///</summary>
        private void InvokeComponentTypeChanged(GoodsClass value)
        {
            ValueChangedEventHandler handler = ComponentTypeChanged;
            if (handler != null) handler(new ValueChangedEventArgs(value));
        }
        ///<summary>
        /// Событие оповещающее о смене типа компонента
        ///</summary>
        [Category("Component data")]
        [Description("Возникает при изменении типа компонента")]
        public event ValueChangedEventHandler ComponentTypeChanged;
        #endregion

        #region public event DateChangedEventHandler ManufactureDateChanged
        ///<summary>
        /// Сигнализирует о смене даты производства компонента
        ///</summary>
        private void InvokeManufactureDateChanged(DateTime value)
        {
            DateChangedEventHandler handler = ManufactureDateChanged;
            if (handler != null) handler(new DateChangedEventArgs(value));
        }
        ///<summary>
        /// Событие оповещающее о смене даты производства компонента
        ///</summary>
        [Category("Component data")]
        [Description("Возникает при изменении даты производства компонента")]
        public event DateChangedEventHandler ManufactureDateChanged;
		#endregion

		#region public event DateChangedEventHandler InstallationDateChanged
		/////<summary>
		///// Сигнализирует о смене даты установки компонента
		/////</summary>
		//private void InvokeInstallationDateChanged(DateTime value)
		//{
		//    DateChangedEventHandler handler = InstallationDateChanged;
		//    if (handler != null) handler(new DateChangedEventArgs(value));
		//}
		/////<summary>
		///// Событие оповещающее о смене даты установки компонента
		/////</summary>
		//[Category("Component data")]
		//[Description("Возникает при изменении даты производства компонента")]
		//public event DateChangedEventHandler InstallationDateChanged;
		#endregion

		#endregion
	}
}
