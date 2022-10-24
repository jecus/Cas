using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CAA.Entity.Models.DTO;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CASTerms;
using SmartCore.CAA;
using SmartCore.CAA.Specialists;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UICAAControls.Specialists
{
    ///<summary>
    ///</summary>
    [Designer(typeof(CAAEmployeeGeneralInformationControl))]
    public partial class CAAEmployeeGeneralInformationControl : UserControl, IReference
    {
        #region Fields

        private bool _logotypeChanged, _signChanged,_stampChanged;
        private const string TransparentFilter = "PNG (*.png)|*.png";

        private Specialist _currentItem;
        public int OperatorId { get; set; }
        #endregion

        #region Constructors

        #region public EmployeeGeneralInformationControl()

        ///<summary>
        /// Создает объект для отображения информации о директиве
        ///</summary>
        public CAAEmployeeGeneralInformationControl()
        {
            InitializeComponent();
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

        #region public DateTime DateOfBirth
        /// <summary>
        /// Дата Рождения
        /// </summary>
        public DateTime DateOfBirth
        {
            get
            {
                return dateTimePickerDateOfBirth.Value;
            }
            set
            {
                if (_currentItem == null || _currentItem.ItemId <= 0)
                    dateTimePickerDateOfBirth.Value = DateTime.Today;
                else if(value < dateTimePickerDateOfBirth.MinDate)
                    dateTimePickerDateOfBirth.Value = dateTimePickerDateOfBirth.MinDate;
                else if(value > dateTimePickerDateOfBirth.MaxDate)
                    dateTimePickerDateOfBirth.Value = dateTimePickerDateOfBirth.MaxDate;
                else dateTimePickerDateOfBirth.Value = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public bool GetChangeStatus(bool directiveExist)
        ///<summary>
        ///Возвращает значение, показывающее были ли изменения в данном элементе управления
        ///</summary>
        ///<param name="directiveExist">Показывает, существует ли уже директива или нет</param>
        ///<returns></returns>
        public bool GetChangeStatus(bool directiveExist)
        {
            if (directiveExist)
                return (
                        textBoxFirstName.Text != _currentItem.FirstName ||
                        textBoxLastName.Text != _currentItem.LastName ||
                        textBoxShortName.Text != _currentItem.ShortName ||
                        (FamilyStatus)comboBoxfamilyStatus.SelectedItem != _currentItem.FamilyStatus ||
                        (Education)comboBoxEducation.SelectedItem != _currentItem.Education ||
                        (Citizenship)comboBoxNationality.SelectedItem != _currentItem.Citizenship ||
                        (SpecialistPosition)comboBoxPosition.SelectedItem != _currentItem.Position ||
                        (SpecialistStatus)comboBoxStatus.SelectedItem != _currentItem.Status ||
                        DateOfBirth != _currentItem.DateOfBirth ||
						textBoxNationality.Text != _currentItem.Nationality ||
						textboxAddress.Text != _currentItem.Address ||
                        textBoxInformation.Text != _currentItem.Information ||
                        textBoxEmail.Text != _currentItem.Email ||
                        textBoxPhone.Text != _currentItem.Phone ||
                        textBoxAdditional.Text != _currentItem.Additional ||
                        textBoxPhoneMobile.Text != _currentItem.PhoneMobile ||
                        textBoxSkype.Text != _currentItem.Skype ||
                        (Gender)comboBoxGender.SelectedItem != _currentItem.Gender ||
                        (Occupation)comboBoxOccupation.SelectedItem != _currentItem.Occupation ||
                        fileControlPassportCopy.GetChangeStatus() ||
                        fileControlResume.GetChangeStatus() ||
                        _logotypeChanged || _signChanged || _stampChanged);
            return (textBoxFirstName.Text != "" ||
                    textBoxLastName.Text != "" ||
                    comboBoxGender.SelectedItem != null);
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
            if (comboBoxGender.SelectedItem == null)
            {
                if (message != "") message += "\n ";
                message += "Please select Sex";
            }
			if (comboBoxStatus.SelectedItem == null)
            {
                if (message != "") message += "\n ";
                message += "Please select Status";
            }
			if (comboBoxPosition.SelectedItem == null)
			{
				if (message != "") message += "\n ";
				message += "Please select Position";
			}
			if (comboBoxfamilyStatus.SelectedItem == null)
			{
				if (message != "") message += "\n ";
				message += "Please select Family Status";
			}
			if (comboBoxEducation.SelectedItem == null)
			{
				if (message != "") message += "\n ";
				message += "Please select Education";
			}
			if (comboBoxNationality.SelectedItem == null)
			{
				if (message != "") message += "\n ";
				message += "Please select Citizenship";
			}
			if (textBoxFirstName.Text == "")
            {
                if (message != "") message += "\n ";
                message += "You should enter First Name";
            }

            if (textBoxLastName.Text == "")
            {
                if (message != "") message += "\n ";
                message += "You should enter Last Name";
            }

            string validateFiles;

            if (!fileControlPassportCopy.ValidateData(out validateFiles))
            {
                if (message != "") message += "\n ";
                message += "Characteristic Copy File: " + validateFiles;
            }

            if (!fileControlResume.ValidateData(out validateFiles))
            {
                if (message != "") message += "\n ";
                message += "Resume File: " + validateFiles;
            }

            if (message != "")
                return false;
            return true;
        }

        #endregion

        #region private void UpdateInformation()

        /// <summary>
        /// Заполняет поля для редактирования директивы
        /// </summary>
        private void UpdateInformation()
        {
            this.radioButtonCAA.CheckedChanged -= new System.EventHandler(this.radioButtonCAA_CheckedChanged);
            this.radioButtonOperator.CheckedChanged -= new System.EventHandler(this.radioButtonCAA_CheckedChanged);
            if (_currentItem == null) return;

            _logotypeChanged = false;
	        _signChanged = false;
	        _stampChanged = false;

			comboBoxGender.Items.Clear();
            foreach (object o in Enum.GetValues(typeof(Gender)))
                comboBoxGender.Items.Add(o);
            dictionaryComboBoxLocation.Type = typeof(LocationsType);


            if (OperatorId > 0)
            {
                comboBoxOperator.Items.AddRange(GlobalObjects.CaaEnvironment.AllOperators.ToArray());
                comboBoxOperator.SelectedItem = GlobalObjects.CaaEnvironment.AllOperators.FirstOrDefault(i => i.ItemId == OperatorId);
                radioButtonCAA.Checked = false;
                radioButtonOperator.Checked = true;

                radioButtonOperator.Enabled = false;
                radioButtonCAA.Enabled = false;
                radioButtonOperator.Enabled = false;
            }
            else
            {
                comboBoxOperator.Items.Clear();
                if (!_currentItem.IsCAA)
                {
                    comboBoxOperator.Items.AddRange(GlobalObjects.CaaEnvironment.AllOperators.ToArray());
                    comboBoxOperator.SelectedItem = GlobalObjects.CaaEnvironment.AllOperators.FirstOrDefault(i => i.ItemId == _currentItem.OperatorId);
                    radioButtonCAA.Checked = false;
                    radioButtonOperator.Checked = true;
                    comboBoxOperator.Enabled = true;
                }
                else
                {
                    comboBoxOperator.Items.Add(AllOperators.Unknown);
                    comboBoxOperator.SelectedItem = AllOperators.Unknown;
                    radioButtonCAA.Checked = true;
                    radioButtonOperator.Checked = false;
                    comboBoxOperator.Enabled = false;
                }
            }

            



			// checkedListBox1.Items.Clear();
			// checkedListBox1.Items.AddRange(GlobalObjects.CaaEnvironment?.GetDictionary<Occupation>().ToArray());
			//
			// for (int i = 0; i < checkedListBox1.Items.Count; i++)
			// {
			// 	if(_currentItem.Combination!= null && _currentItem.Combination.Contains(checkedListBox1.Items[i].ToString()))
			// 		checkedListBox1.SetItemChecked(i,true);
			// }
			
			
			checkedListBoxQualification.Items.Clear();
			checkedListBoxQualification.Items.AddRange(SpecialistQualification.Items.ToArray());
			for (int i = 0; i < checkedListBoxQualification.Items.Count; i++)
			{
				if(_currentItem.Qualification!= null && _currentItem.Qualification.Contains(checkedListBoxQualification.Items[i].ToString()))
					checkedListBoxQualification.SetItemChecked(i,true);
			}

			comboBoxPosition.Items.Clear();
	        foreach (var o in Enum.GetValues(typeof(SpecialistPosition)))
		        comboBoxPosition.Items.Add(o);

			comboBoxStatus.Items.Clear();
	        foreach (var o in Enum.GetValues(typeof(SpecialistStatus)))
				comboBoxStatus.Items.Add(o);

			comboBoxfamilyStatus.Items.Clear();
	        foreach (var o in FamilyStatus.Items)
		        comboBoxfamilyStatus.Items.Add(o);

			comboBoxEducation.Items.Clear();
			foreach (var o in Education.Items)
				comboBoxEducation.Items.Add(o);

			comboBoxNationality.Items.Clear();
	        foreach (var o in Citizenship.Items)
		        comboBoxNationality.Items.Add(o);


			textBoxFirstName.Text = _currentItem.FirstName;
            textBoxLastName.Text = _currentItem.LastName;
	        textBoxShortName.Text = _currentItem.ShortName;
            comboBoxfamilyStatus.SelectedItem = _currentItem.FamilyStatus;
            comboBoxEducation.SelectedItem = _currentItem.Education;
            comboBoxNationality.SelectedItem = _currentItem.Citizenship;
			comboBoxStatus.SelectedItem = _currentItem.Status;
            DateOfBirth = _currentItem.DateOfBirth;
			textBoxNationality.Text = _currentItem.Nationality;
			textboxAddress.Text = _currentItem.Address;
            textBoxInformation.Text = _currentItem.Information;
            comboBoxGender.SelectedItem = _currentItem.Gender;
	        comboBoxPosition.SelectedItem = _currentItem.Position;
	        dictionaryComboBoxLocation.SelectedItem = _currentItem.Facility;
            textBoxEmail.Text = _currentItem.Email;
            textBoxPhone.Text = _currentItem.Phone;
			textBoxAdditional.Text = _currentItem.Additional;
            textBoxPhoneMobile.Text = _currentItem.PhoneMobile;
            textBoxSkype.Text = _currentItem.Skype;

            fileControlPassportCopy.UpdateInfo(_currentItem.PassportCopyFile, 
                                     "Adobe PDF Files|*.pdf",
                                     "This record does not contain a file proving the Characteristic",
                                     "Attached file proves the Passport.");
            fileControlResume.UpdateInfo(_currentItem.ResumeFile, 
                                     "Adobe PDF Files|*.pdf",
                                     "This record does not contain a file proving the Resume",
                                     "Attached file proves the Resume.");

            _pictureBoxTransparentLogotype.BackgroundImage = _currentItem.PhotoImage;
	        pictureBoxSign.BackgroundImage = _currentItem.SignImage;
	        pictureBoxStamp.BackgroundImage = _currentItem.StampImage;

            //dateTimePickerDateOfBirth.ValueChanged += DateTimePickerEffDateValueChanged;
            this.radioButtonCAA.CheckedChanged += new System.EventHandler(this.radioButtonCAA_CheckedChanged);
            this.radioButtonOperator.CheckedChanged += new System.EventHandler(this.radioButtonCAA_CheckedChanged);
        }
        
        
        
        private void ComboBoxOperatorOnSelectedIndexChanged(object sender, EventArgs e)
        {
	        var op = comboBoxOperator.SelectedItem as AllOperators;

	        var items = GlobalObjects.CaaEnvironment?.GetDictionary<Occupation>().Cast<Occupation>().Where(i => i.OperatorId == op.ItemId).OrderBy(i => i.FullName).ToList();
	        items.Add(Occupation.Unknown);
	        comboBoxOccupation.Items.Clear();
	        comboBoxOccupation.Items.AddRange(items.ToArray());
	        comboBoxOccupation.SelectedItem = _currentItem.Occupation;
	        checkedListBox1.Items.Clear();
	        checkedListBox1.Items.AddRange(items.ToArray());

	        var comb = new List<string>();
	        if (_currentItem.Combination.Contains(","))
		        comb = _currentItem.Combination.Split(',').ToList();
	        else comb.Add(_currentItem.Combination);
	        
	        for (int i = 0; i < checkedListBox1.Items.Count; i++)
	        {
		        if(_currentItem.Combination!= null && comb.Any(c => c.Equals(checkedListBox1.Items[i].ToString())))
			        checkedListBox1.SetItemChecked(i,true);
	        }
        }

        #endregion

        #region public void ApplyChanges()

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public void ApplyChanges()
        {

            if (_currentItem.FirstName != textBoxFirstName.Text || _currentItem.LastName != textBoxLastName.Text)
            {
                string caption = _currentItem.FirstName + " " + _currentItem.LastName;
                if (DisplayerRequested != null)
                    DisplayerRequested(this,
                                       new ReferenceEventArgs(null,
                                                              ReflectionTypes.ChangeTextOfContainingDisplayer,
                                                              caption));
            }

            if (_logotypeChanged)
                _currentItem.PhotoImage = _pictureBoxTransparentLogotype.BackgroundImage;
            _logotypeChanged = false;

	        if (_signChanged)
		        _currentItem.SignImage = pictureBoxSign.BackgroundImage;
	        _signChanged = false;
	        
	        if (_stampChanged)
		        _currentItem.StampImage = pictureBoxStamp.BackgroundImage;
	        _stampChanged = false;
	        
	        


			//dateTimePickerDateOfBirth.ValueChanged -= DateTimePickerEffDateValueChanged;

            _currentItem.IsCAA = radioButtonCAA.Checked;
            _currentItem.OperatorId = ((AllOperators) comboBoxOperator.SelectedItem).ItemId;
			_currentItem.FirstName = textBoxFirstName.Text;
	        _currentItem.ShortName = textBoxShortName.Text;
            _currentItem.LastName = textBoxLastName.Text;
            _currentItem.FamilyStatus = (FamilyStatus)comboBoxfamilyStatus.SelectedItem;
            _currentItem.Education = (Education)comboBoxEducation.SelectedItem;
            _currentItem.Citizenship = (Citizenship)comboBoxNationality.SelectedItem;
            _currentItem.DateOfBirth = DateOfBirth;
			_currentItem.Nationality = textBoxNationality.Text;
			_currentItem.Address = textboxAddress.Text;
            _currentItem.Information = textBoxInformation.Text;
            _currentItem.Gender = (Gender)comboBoxGender.SelectedItem;
	        _currentItem.Position = (SpecialistPosition) comboBoxPosition.SelectedItem;
	        _currentItem.Status = (SpecialistStatus)comboBoxStatus.SelectedItem;
            _currentItem.Occupation = comboBoxOccupation.SelectedItem as Occupation;
            _currentItem.Facility = dictionaryComboBoxLocation.SelectedItem as LocationsType;
            _currentItem.Email = textBoxEmail.Text;
            _currentItem.Phone = textBoxPhone.Text;
            _currentItem.Additional = textBoxAdditional.Text;
            _currentItem.PhoneMobile = textBoxPhoneMobile.Text;
            _currentItem.Skype = textBoxSkype.Text;

	        _currentItem.Combination = "";
	        foreach (var item in checkedListBox1.CheckedItems)
		        _currentItem.Combination += $"{item},";
	        
	        
	        
	        _currentItem.Qualification = "";
	        foreach (var item in checkedListBoxQualification.CheckedItems)
		        _currentItem.Qualification += $"{item} ";

	        if(fileControlPassportCopy.GetChangeStatus())
            {
                fileControlPassportCopy.ApplyChanges();
                _currentItem.PassportCopyFile = fileControlPassportCopy.AttachedFile;    
            }

            if (fileControlResume.GetChangeStatus())
            {
                fileControlResume.ApplyChanges();
                _currentItem.ResumeFile = fileControlResume.AttachedFile;
            }
        }
        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            DateOfBirth = DateTime.Today;
            textBoxNationality.Text = "";
            textboxAddress.Text = "";
            textBoxInformation.Text = "";
            textBoxEmail.Text = "";
            textBoxPhone.Text = "";
			textBoxAdditional.Text = "";
            textBoxPhoneMobile.Text = "";
            textBoxSkype.Text = "";
            comboBoxGender.SelectedItem = null;
            comboBoxOccupation.SelectedItem = null;

            fileControlPassportCopy.AttachedFile = null;
            fileControlResume.AttachedFile = null;
        }

        #endregion

        #region private void OpenFile(PictureBox pictureBox, ref bool changed, string filter)

        private void OpenFile(PictureBox pictureBox, ref bool changed, string filter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = filter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image logotype = Image.FromFile(dialog.FileName);
                Stream stream = dialog.OpenFile();
                long size = stream.Length;
                stream.Close();
                if (size > 2097152 || logotype.Width > 2000 || logotype.Height > 2000)
                {
                    MessageBox.Show("Logotype shouldn't exceed 2000x2000 px and 2048 Kb", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                pictureBox.BackgroundImage = logotype;
                changed = true;
            }
        }

        #endregion

        #region private void PictureBoxLogotypeClick(object sender, EventArgs e)

        private void PictureBoxLogotypeClick(object sender, EventArgs e)
        {
            if (sender == _pictureBoxTransparentLogotype)
                OpenFile(_pictureBoxTransparentLogotype, ref _logotypeChanged, TransparentFilter);
        }

		#endregion

		#region private void PictureBoxLogotypeClick(object sender, EventArgs e)

		private void PictureBoxLogotypeSignClick(object sender, EventArgs e)
		{
			if (sender == pictureBoxSign)
				OpenFile(pictureBoxSign, ref _signChanged, TransparentFilter);
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

        private void radioButtonCAA_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxOperator.Items.Clear();
            
            if (!radioButtonCAA.Checked)
            {
                comboBoxOperator.Items.AddRange(GlobalObjects.CaaEnvironment.AllOperators.ToArray());
                comboBoxOperator.SelectedItem = GlobalObjects.CaaEnvironment.AllOperators.FirstOrDefault();
                comboBoxOperator.Enabled = true;
            }
            else
            {
                comboBoxOperator.Items.Add(AllOperators.Unknown);
                comboBoxOperator.SelectedItem = AllOperators.Unknown;
                comboBoxOperator.Enabled = false;
            }
        }
        
        
        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

        #region Events
        /////<summary>
        ///// Возникает во время изменения эффективной даты 
        /////</summary>
        //[Category("Flight data")]
        //[Description("Возникает во время изменения эффективной даты")]
        //public event DateChangedEventHandler EffDateChanget;

        /////<summary>
        ///// Сигнализирует об изменени эффективной даты
        /////</summary>
        /////<param name="e"></param>
        //private void InvokeEffDateChanget(DateTime e)
        //{
        //    DateChangedEventHandler handler = EffDateChanget;
        //    if (handler != null) handler(new DateChangedEventArgs(e));
        //}
        #endregion

        private void pictureBoxStampClick(object sender, EventArgs e)
        {
	        if (sender == pictureBoxStamp)
		        OpenFile(pictureBoxStamp, ref _stampChanged, TransparentFilter);
        }
    }

    #region internal class EmployeeGeneralInformationControlDesigner : ControlDesigner

    internal class CAAEmployeeGeneralInformationControlDesigner : ControlDesigner
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
