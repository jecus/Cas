using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.DocumentationControls;
using CAS.UI.UIControls.ReferenceControls;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.OpepatorsControls
{
    ///<summary>
    /// ЭУ для представления главной информации об операторе
    ///</summary>
    public partial class OperatorInfoReference : RichReferenceContainer
    {
        #region Fields

        private Operator _currentOperator;

        private const int WidthInterval = 95;
        private const int HeightInterval = 5;

        #endregion

        #region Properties
        ///<summary>
        /// Задает оператора для отображения в контроле
        ///</summary>
        public Operator CurrentOperator
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
        public OperatorInfoReference()
        {
            InitializeComponent();
        }
        ///<summary>
        /// Создается контрол отбражения информации об операторе
        ///</summary>
        public OperatorInfoReference(Operator currentOperator) : this()
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
            
            labelNameValue.Text = _currentOperator.Name;
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
            ProcessStartInfo startInfo = 
                new ProcessStartInfo("Outlook.exe"){FileName = "mailto:" + _currentOperator.Email};
            Process.Start(startInfo);
        }

        #endregion

        #region private void LinkLabelEditOperatorInfoDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkLabelEditOperatorInfoDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = _currentOperator.Name + ". Summary";
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.RequestedEntity = new OperatorScreen(_currentOperator);
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
            linkLabelEditOperatorInfo.Location = new Point(0, labelEmailValue.Bottom + HeightInterval);
        }

        #endregion

        #region void CurrentOperatorPropertyChanged(object sender, PropertyChangedEventArgs e)
        void CurrentOperatorPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateDataForOperator();
        }
        #endregion


        #endregion
    }
}
