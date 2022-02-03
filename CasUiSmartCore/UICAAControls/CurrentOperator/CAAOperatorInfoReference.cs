using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.UIControls.OpepatorsControls;
using CAS.UI.UIControls.ReferenceControls;
using SmartCore.CAA;

namespace CAS.UI.UICAAControls.CurrentOperator
{
    ///<summary>
    /// ЭУ для представления главной информации об операторе
    ///</summary>
    public partial class CAAOperatorInfoReference : RichReferenceContainer
    {
        #region Fields

        private AllOperators _currentOperator;

        private const int WidthInterval = 95;
        private const int HeightInterval = 5;

        #endregion

        #region Properties
        ///<summary>
        /// Задает оператора для отображения в контроле
        ///</summary>
        public AllOperators CurrentOperator
        {
            set
            {
                if (_currentOperator != null)
                    _currentOperator.PropertyChanged -= CurrentOperatorPropertyChanged;
                _currentOperator = value;
                if (_currentOperator != null)
                    _currentOperator.PropertyChanged += CurrentOperatorPropertyChanged;
                UpdateDataForOperator();
            }
        }

        #endregion

        #region Constructor

        ///<summary>
        /// Создается контрол отбражения информации об операторе
        ///</summary>
        public CAAOperatorInfoReference()
        {
            InitializeComponent();
        }
        ///<summary>
        /// Создается контрол отбражения информации об операторе
        ///</summary>
        public CAAOperatorInfoReference(AllOperators currentOperator) : this()
        {
            _currentOperator = currentOperator;
            _currentOperator.PropertyChanged += CurrentOperatorPropertyChanged;
        }
        #endregion

        #region Methods

        #region public void UpdateDataForOperator()
        ///<summary>
        /// Отображает согласно переданному оператору
        ///</summary>
        public void UpdateDataForOperator()
        {
            if (_currentOperator == null) return;
            
            labelNameValue.Text = _currentOperator.FullName;
            labelFaxValue.Text = _currentOperator.Fax;
            labelIcaoValue.Text = _currentOperator.ICAOCode;
            labelPhoneValue.Text = _currentOperator.Phone;
            labelAddressValue.Text = _currentOperator.Address;
            labelEmailValue.Text = _currentOperator.Email;
        }

        #endregion

        #region private void LabelEmailValueLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void LabelEmailValueLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var startInfo = 
                new ProcessStartInfo("Outlook.exe"){FileName = "mailto:" + _currentOperator.Email};
            Process.Start(startInfo);
        }

        #endregion


        #region private void LabelSizeChanged(object sender, EventArgs e)

        private void LabelSizeChanged(object sender, EventArgs e)
        {
            labelIcao.Location = new Point(0, labelNameValue.Bottom + HeightInterval);
            labelIcaoValue.Location = new Point(WidthInterval, labelNameValue.Bottom + HeightInterval);
            labelAddress.Location = new Point(0, labelIcaoValue.Bottom + HeightInterval);
            labelAddressValue.Location = new Point(WidthInterval, labelIcaoValue.Bottom + HeightInterval);
            labelPhone.Location = new Point(0, labelAddressValue.Bottom + HeightInterval);
            labelPhoneValue.Location = new Point(WidthInterval, labelAddressValue.Bottom + HeightInterval);
            labelFax.Location = new Point(0, labelPhoneValue.Bottom + HeightInterval);
            labelFaxValue.Location = new Point(WidthInterval, labelPhoneValue.Bottom + HeightInterval);
            labelEmail.Location = new Point(0, labelFaxValue.Bottom + HeightInterval);
            labelEmailValue.Location = new Point(WidthInterval, labelFaxValue.Bottom + HeightInterval);
        }

        #endregion

        #region void CurrentOperatorPropertyChanged(object sender, PropertyChangedEventArgs e)
        void CurrentOperatorPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateDataForOperator();
        }
		#endregion

		#region  private void LinkLabelEditPassword_Click(object sender, EventArgs e)

		private void LinkLabelEditPassword_Click(object sender, EventArgs e)
		{
			var form = new PasswordChangeForm();
			form.ShowDialog();
		}

		#endregion


		#endregion
	}
}
