using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.PersonnelControls
{
    ///<summary>
    ///</summary>
    [Designer(typeof(EmployeeGeneralInformationControlDesigner))]
    public partial class EmployeeGeneralInformationControl : UserControl, IReference
    {
        #region Fields

        private bool _logotypeChanged, _signChanged;
        private const string TransparentFilter = "PNG (*.png)|*.png";

        private Specialist _currentItem;

        #endregion

        #region Constructors

        #region public EmployeeGeneralInformationControl()

        ///<summary>
        /// Создает объект для отображения информации о директиве
        ///</summary>
        public EmployeeGeneralInformationControl()
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
                        dictionaryComboBoxOccupation.SelectedItem != _currentItem.Occupation ||
                        fileControlPassportCopy.GetChangeStatus() ||
                        fileControlResume.GetChangeStatus() ||
                        _logotypeChanged || _signChanged);
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
            if (_currentItem == null) return;

            _logotypeChanged = false;
	        _signChanged = false;

			comboBoxGender.Items.Clear();
            foreach (object o in Enum.GetValues(typeof(Gender)))
                comboBoxGender.Items.Add(o);
            dictionaryComboBoxOccupation.Type = typeof(Occupation);
            dictionaryComboBoxLocation.Type = typeof(LocationsType);

			checkedListBox1.Items.Clear();
			checkedListBox1.Items.AddRange(GlobalObjects.CasEnvironment?.GetDictionary<Occupation>().ToArray() ?? GlobalObjects.CaaEnvironment?.GetDictionary<Occupation>().ToArray());

			for (int i = 0; i < checkedListBox1.Items.Count; i++)
			{
				if(_currentItem.Combination!= null && _currentItem.Combination.Contains(checkedListBox1.Items[i].ToString()))
					checkedListBox1.SetItemChecked(i,true);
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
            dictionaryComboBoxOccupation.SelectedItem = _currentItem.Occupation;
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

	        //dateTimePickerDateOfBirth.ValueChanged += DateTimePickerEffDateValueChanged;
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


			//dateTimePickerDateOfBirth.ValueChanged -= DateTimePickerEffDateValueChanged;

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
            _currentItem.Occupation = dictionaryComboBoxOccupation.SelectedItem as Occupation;
            _currentItem.Facility = dictionaryComboBoxLocation.SelectedItem as LocationsType;
            _currentItem.Email = textBoxEmail.Text;
            _currentItem.Phone = textBoxPhone.Text;
            _currentItem.Additional = textBoxAdditional.Text;
            _currentItem.PhoneMobile = textBoxPhoneMobile.Text;
            _currentItem.Skype = textBoxSkype.Text;

	        _currentItem.Combination = "";
	        foreach (var item in checkedListBox1.CheckedItems)
	        {
		        _currentItem.Combination += $"{item} ";
	        }

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
            dictionaryComboBoxOccupation.SelectedItem = null;

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
    }

    #region internal class EmployeeGeneralInformationControlDesigner : ControlDesigner

    internal class EmployeeGeneralInformationControlDesigner : ControlDesigner
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
