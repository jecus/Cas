using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.MonthlyUtilizationsControls;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.CAA;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UICAAControls.Airacraft
{
    ///<summary>
    ///</summary>
    public partial class CAAAircraftControl : UserControl, IReference
    {
        #region public CAAAircraftControl()
        ///<summary>
        ///</summary>
        public CAAAircraftControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        #region CurrentAircraft
        private Aircraft _currentAircraft;
        ///<summary>
        ///</summary>
        public Aircraft CurrentAircraft
        {
            get { return _currentAircraft; }
            set
            {
                _currentAircraft = value;
                if (value!=null)
                {
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
			message = "";
			if (comboBoxMSG.SelectedItem == null)
			{
				message = "please select msg";
				return false;
			}
			if (dictionaryComboBoxAircraftModel.SelectedItem == null)
			{
				message = "please select Aircraft model";
				return false;
			}
			double i;
			if (Double.TryParse(comboBoxApuWorktime.Text, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture, out i))
			{
				if (i >= 0 && i <= 120)
					return true;

				message = "number must be an integer between 0 and 120";
				return false;
			}
			message = "invalid format";
			return false;
		}

		#endregion

		#region public bool GetChangeStatus()

		/// <summary>
		/// Возвращает значение, показывающее были ли изменения в данном элементе управления
		/// </summary>
		/// <returns></returns>
		public bool GetChangeStatus()
        {
            // Проверяем, изменены ли поля WestAircraft
            bool changedWestAircraftFields;

            if ((textBoxAircraftTypeCertificateNo.Text != CurrentAircraft.TypeCertificateNumber) || 
                (textBoxVariableNumber.Text != CurrentAircraft.VariableNumber || 
                (textBoxLineNumber.Text != CurrentAircraft.LineNumber)))
                changedWestAircraftFields = true;
            else
                changedWestAircraftFields = false;

            // Проверям остальные поля
            if (dictionaryComboBoxAircraftModel.SelectedItem.ItemId != CurrentAircraft.Model.ItemId ||
                dateTimePickerManufactureDate.Value != CurrentAircraft.ManufactureDate ||
                textBoxSerialNumber.Text != CurrentAircraft.SerialNumber || 
                textBoxRegistrationNumber.Text != CurrentAircraft.RegistrationNumber || 
                textBoxOwner.Text != CurrentAircraft.Owner || changedWestAircraftFields ||
                (MSG)comboBoxMSG.SelectedItem != CurrentAircraft.MSG ||
				CurrentAircraft.APUFH != (double)numericUpDownAPU.Value ||
                CurrentAircraft.OperatorId != ((CAAOperatorDTO)comboBoxOperator.SelectedItem).ItemId
                //|| !lifelengthViewerStart.Lifelength.IsEqual(GlobalObjects.ComponentCore.GetBaseComponentById(CurrentAircraft.AircraftFrameId).StartLifelength)
                )
			{
                return true;
            }
            return false;
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранаяет данные текущего ВС
        /// </summary>
        public void SaveData()
        {
			//var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(CurrentAircraft.AircraftFrameId);

			if (dictionaryComboBoxAircraftModel.SelectedItem != CurrentAircraft.Model)
                CurrentAircraft.Model = (AircraftModel)dictionaryComboBoxAircraftModel.SelectedItem;
            if (dateTimePickerManufactureDate.Value != CurrentAircraft.ManufactureDate)
                CurrentAircraft.ManufactureDate = dateTimePickerManufactureDate.Value;
	        if (textBoxSerialNumber.Text != CurrentAircraft.SerialNumber)
	        {
				CurrentAircraft.SerialNumber = textBoxSerialNumber.Text;
		        //aircraftFrame.SerialNumber = textBoxSerialNumber.Text;
	        }
            if (textBoxRegistrationNumber.Text != CurrentAircraft.RegistrationNumber)
            {
                CurrentAircraft.RegistrationNumber = textBoxRegistrationNumber.Text;
                if (DisplayerRequested != null)
                    DisplayerRequested(this, new ReferenceEventArgs(null, 
                                                              ReflectionTypes.ChangeTextOfContainingDisplayer,
                                                              CurrentAircraft.RegistrationNumber +
                                                              ". Aircraft General Data"));
            }

	        CurrentAircraft.APUFH = (double) numericUpDownAPU.Value;
			if (textBoxOwner.Text != CurrentAircraft.Owner)
                CurrentAircraft.Owner = textBoxOwner.Text;
            if (textBoxAircraftTypeCertificateNo.Text != CurrentAircraft.TypeCertificateNumber)
                CurrentAircraft.TypeCertificateNumber = textBoxAircraftTypeCertificateNo.Text;
            if (textBoxVariableNumber.Text != CurrentAircraft.VariableNumber)
                CurrentAircraft.VariableNumber = textBoxVariableNumber.Text;
            if (textBoxLineNumber.Text != CurrentAircraft.LineNumber)
                CurrentAircraft.LineNumber = textBoxLineNumber.Text;
            if (comboBoxMSG.SelectedItem != null && (MSG)comboBoxMSG.SelectedItem != CurrentAircraft.MSG)
                CurrentAircraft.MSG = (MSG)comboBoxMSG.SelectedItem;
	        if (!string.IsNullOrEmpty(comboBoxApuWorktime.Text) && double.Parse(comboBoxApuWorktime.Text,CultureInfo.InvariantCulture)!=CurrentAircraft.ApuUtizationPerFlightinMinutes)
	        {
		        short apuworktime = (short) Math.Round(double.Parse(comboBoxApuWorktime.Text, CultureInfo.InvariantCulture), 1);
		        if (apuworktime == 0)
			        CurrentAircraft.ApuUtizationPerFlightinMinutes = null;
		        else
			        CurrentAircraft.ApuUtizationPerFlightinMinutes = apuworktime;
	        }

            CurrentAircraft.OperatorId = ((AllOperators) comboBoxOperator.SelectedItem).ItemId;

			//ActualStateRecord actualStateRecord =
			//	aircraftFrame.ActualStateRecords[aircraftFrame.StartDate];
   //         if (actualStateRecord == null)
   //         {
   //             actualStateRecord = new ActualStateRecord();
   //             actualStateRecord.ComponentId = aircraftFrame.ItemId;
   //         }

   //         actualStateRecord.RecordDate = dateTimePickerStart.Value;
   //         actualStateRecord.OnLifelength = lifelengthViewerStart.Lifelength;
   //         GlobalObjects.ComponentCore.RegisterActualState(aircraftFrame, actualStateRecord);

			//aircraftFrame.StartDate = dateTimePickerStart.Value;
			//aircraftFrame.StartLifelength = lifelengthViewerStart.Lifelength;
   //         GlobalObjects.ComponentCore.Save(aircraftFrame);

            CurrentAircraft.DeliveryDate = dateTimePickerStart.Value;
        }

        #endregion

        #region private void UpdateControl()
        /// <summary>
        /// Обновляет информацию о текущем ВС
        /// </summary>
        private void UpdateControl()
        {
			dictionaryComboBoxAircraftModel.Type = typeof (AircraftModel);
            dictionaryComboBoxAircraftModel.SelectedItem = CurrentAircraft.Model;

            comboBoxMSG.Items.Clear();
            foreach (object o in Enum.GetValues(typeof(MSG)).Cast<MSG>().Where(msg => msg != MSG.Unknown))
                comboBoxMSG.Items.Add(o);
			comboBoxMSG.SelectedItem = CurrentAircraft.MSG;

			var apuFlightMinutesList =  new List<int> { 0, 20, 30, 40 };
			comboBoxApuWorktime.Items.Clear();
	        foreach (var a in apuFlightMinutesList)
		        comboBoxApuWorktime.Items.Add(a);
			comboBoxApuWorktime.SelectedItem = null;
	        if (CurrentAircraft.ApuUtizationPerFlightinMinutes != null)
		        comboBoxApuWorktime.Text = CurrentAircraft.ApuUtizationPerFlightinMinutes.ToString();
	        else
		        comboBoxApuWorktime.SelectedItem = comboBoxApuWorktime.Items[0];
            dateTimePickerManufactureDate.MaxDate = DateTime.Now;
            dateTimePickerManufactureDate.Value = CurrentAircraft.ManufactureDate;
            textBoxSerialNumber.Text = CurrentAircraft.SerialNumber;
            textBoxRegistrationNumber.Text = CurrentAircraft.RegistrationNumber;
            textBoxOwner.Text = CurrentAircraft.Owner;

            var op = GlobalObjects.CaaEnvironment.NewLoader.GetObjectList<AllOperatorsDTO, AllOperators>();
            comboBoxOperator.Items.Clear();
            comboBoxOperator.Items.AddRange(op.ToArray());
            comboBoxOperator.SelectedIndex = 0;

            textBoxAircraftTypeCertificateNo.Text = CurrentAircraft.TypeCertificateNumber;
            textBoxVariableNumber.Text = CurrentAircraft.VariableNumber;
	        numericUpDownAPU.Value = (decimal) CurrentAircraft.APUFH;
			textBoxLineNumber.Text = CurrentAircraft.LineNumber;
			lifelengthViewerToday.DateFrom = CurrentAircraft.ManufactureDate;

            if (GlobalObjects.CasEnvironment != null)
            {
                lifelengthViewerToday.Lifelength = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
                var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(CurrentAircraft.AircraftFrameId);
                dateTimePickerStart.Value = aircraftFrame.StartDate.Year > 1950
                    ? aircraftFrame.StartDate : DateTimeExtend.GetCASMinDateTime();
                lifelengthViewerStart.DateFrom = CurrentAircraft.ManufactureDate;
                if (aircraftFrame.StartLifelength != null)
                {
                    lifelengthViewerStart.Lifelength = aircraftFrame.StartLifelength;
                }
            }

			

			
			

            //CheckAircraftType();
            //CheckPermission();
        }
        #endregion

        
        #region Update Start
        private void DateTimePickerStartValueChanged(object sender, EventArgs e)
        {
            if (lifelengthViewerStart.Lifelength!=null)
            {
                lifelengthViewerStart.Lifelength.Days = 
                    (int)(dateTimePickerStart.Value - dateTimePickerManufactureDate.Value).TotalDays;
                 lifelengthViewerStart.UpdateData();
            }
        }

        private void DateTimePickerManufactureDateValueChanged(object sender, EventArgs e)
        {
            if (lifelengthViewerStart.Lifelength != null)
            {
                lifelengthViewerStart.Lifelength.Days =
                    (int)(dateTimePickerStart.Value - dateTimePickerManufactureDate.Value).TotalDays;
                lifelengthViewerStart.UpdateData();
            }
        }
		#endregion

		#region private void comboBoxApuWorktime_KeyPress(object sender, KeyPressEventArgs e)

		private void comboBoxApuWorktime_KeyPress(object sender, KeyPressEventArgs e)
	    {
		    e.Handled = (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','));
	    }

	    #endregion

		#endregion

		#region Implementation of IReference

		public IDisplayer Displayer { get; set; }
        public string DisplayerText { get; set; }
        public IDisplayingEntity Entity { get; set; }
        public ReflectionTypes ReflectionType { get; set; }

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

		#endregion
	}
}
