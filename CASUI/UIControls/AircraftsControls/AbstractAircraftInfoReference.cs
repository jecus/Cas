using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Appearance;
using CAS.UI.UIControls.ReferenceControls;

namespace CAS.UI.UIControls.AircraftsControls
{
    /// <summary>
    /// Описывается контрол отображения общей информации о воздушном судне
    /// </summary>
    public abstract class AbstractAircraftInfoReference : RichReferenceContainer
    {

        #region Fields

        /// <summary>
        /// </summary>
        protected const int LINK_TOP_MARGIN = 5;
        /// <summary>
        /// </summary>
        protected Label labelCertificateNumber;
        /// <summary>
        /// </summary>
        protected Label labelCertificateNumberValue;
        /// <summary>
        /// </summary>
        protected Label labelLineNumber;
        /// <summary>
        /// </summary>
        protected Label labelLineNumberValue;
        /// <summary>
        /// </summary>
        protected Label labelManufactureDate;
        /// <summary>
        /// </summary>
        protected Label labelManufactureDateValue;
        /// <summary>
        /// </summary>
        protected Label labelModel;
        /// <summary>
        /// </summary>
        protected Label labelModelValue;
        /// <summary>
        /// </summary>
        protected Label labelRegistrationNumber;
        /// <summary>
        /// </summary>
        protected Label labelRegistrationNumberValue;
        /// <summary>
        /// </summary>
        protected Label labelSerialNumber;
        /// <summary>
        /// </summary>
        protected Label labelSerialNumberValue;
        /// <summary>
        /// </summary>
        protected Label labelVariableNumber;
        /// <summary>
        /// </summary>
        protected Label labelVariableNumberValue;
        /// <summary>
        /// </summary>
        protected Panel panelMain;
        

        #endregion

        #region Methods
        
        #region protected void InitializeComponents()

        /// <summary>
        /// Peter component designer generated code.
        /// Required method for Peter Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        protected void InitializeComponents()
        {
            panelMain = new Panel();
            labelModel = new Label();
            labelRegistrationNumber = new Label();
            labelSerialNumber = new Label();
            labelCertificateNumber = new Label();
            labelLineNumber = new Label();
            labelManufactureDate = new Label();
            labelVariableNumber = new Label();
            labelModelValue = new Label();
            labelRegistrationNumberValue = new Label();
            labelSerialNumberValue = new Label();
            labelCertificateNumberValue = new Label();
            labelLineNumberValue = new Label();
            labelManufactureDateValue = new Label();
            labelVariableNumberValue = new Label();
            // 
            // panelMain
            // 
            panelMain.AutoSize = true;
            panelMain.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelMain.Controls.Add(labelModel);
            panelMain.Controls.Add(labelRegistrationNumber);
            panelMain.Controls.Add(labelSerialNumber);
            panelMain.Controls.Add(labelCertificateNumber);
            panelMain.Controls.Add(labelLineNumber);
            panelMain.Controls.Add(labelManufactureDate);
            panelMain.Controls.Add(labelVariableNumber);
            panelMain.Controls.Add(labelModelValue);
            panelMain.Controls.Add(labelRegistrationNumberValue);
            panelMain.Controls.Add(labelSerialNumberValue);
            panelMain.Controls.Add(labelCertificateNumberValue);
            panelMain.Controls.Add(labelLineNumberValue);
            panelMain.Controls.Add(labelManufactureDateValue);
            panelMain.Controls.Add(labelVariableNumberValue);
            panelMain.TabIndex = 1;
            // 
            // labelModel
            // 
            labelModel.AutoSize = true;
            Css.OrdinaryText.Adjust(labelModel);
            labelModel.Location = new Point(3, 0);
            labelModel.MaximumSize = new Size(300, 0);
            labelModel.Name = "labelModel";
            labelModel.Size = new Size(46, 18);
            labelModel.TabIndex = 4;
            labelModel.Text = "Model";
            // 
            // labelRegistrationNumber
            // 
            labelRegistrationNumber.AutoSize = true;
            Css.OrdinaryText.Adjust(labelRegistrationNumber);
            labelRegistrationNumber.Location = new Point(3, labelModel.Bottom);
            labelRegistrationNumber.MaximumSize = new Size(300, 0);
            labelRegistrationNumber.Name = "labelRegistrationNumber";
            labelRegistrationNumber.Size = new Size(111, 18);
            labelRegistrationNumber.TabIndex = 4;
            labelRegistrationNumber.Text = "Registration No.";
            // 
            // labelSerialNumber
            // 
            labelSerialNumber.AutoSize = true;
            Css.OrdinaryText.Adjust(labelSerialNumber);
            labelSerialNumber.Location = new Point(3, labelRegistrationNumber.Bottom);
            labelSerialNumber.MaximumSize = new Size(300, 0);
            labelSerialNumber.Name = "labelSerialNumber";
            labelSerialNumber.Size = new Size(69, 18);
            labelSerialNumber.TabIndex = 4;
            labelSerialNumber.Text = "Serial No.";
            // 
            // labelManufactureDate
            // 
            labelManufactureDate.AutoSize = true;
            Css.OrdinaryText.Adjust(labelManufactureDate);
            labelManufactureDate.Location = new Point(3, labelSerialNumber.Bottom);
            labelManufactureDate.MaximumSize = new Size(300, 0);
            labelManufactureDate.Name = "labelManufactureDate";
            labelManufactureDate.Size = new Size(98, 18);
            labelManufactureDate.TabIndex = 4;
            labelManufactureDate.Text = "Manufactured";
            // 
            // labelCertificateNumber
            // 
            labelCertificateNumber.AutoSize = true;
            Css.OrdinaryText.Adjust(labelCertificateNumber);
            labelCertificateNumber.Location = new Point(3, labelManufactureDate.Bottom);
            labelCertificateNumber.MaximumSize = new Size(300, 0);
            labelCertificateNumber.Name = "labelCertificateNumber";
            labelCertificateNumber.Size = new Size(100, 18);
            labelCertificateNumber.TabIndex = 4;
            labelCertificateNumber.Text = "Certificate No.";
            // 
            // labelLineNumber
            // 
            labelLineNumber.AutoSize = true;
            Css.OrdinaryText.Adjust(labelLineNumber);
            labelLineNumber.Location = new Point(3, labelCertificateNumber.Bottom);
            labelLineNumber.MaximumSize = new Size(300, 0);
            labelLineNumber.Name = "labelLineNumber";
            labelLineNumber.Size = new Size(61, 18);
            labelLineNumber.TabIndex = 4;
            labelLineNumber.Text = "Line No.";
            // 
            // labelVariableNumber
            // 
            labelVariableNumber.AutoSize = true;
            Css.OrdinaryText.Adjust(labelVariableNumber);
            labelVariableNumber.Location = new Point(3, labelLineNumber.Bottom);
            labelVariableNumber.MaximumSize = new Size(300, 0);
            labelVariableNumber.Name = "labelVariableNumber";
            labelVariableNumber.Size = new Size(86, 18);
            labelVariableNumber.TabIndex = 4;
            labelVariableNumber.Text = "Variable No.";
            // 
            // labelModelValue
            // 
            labelModelValue.AutoSize = true;
            Css.OrdinaryText.Adjust(labelModelValue);
            labelModelValue.Location = new Point(140, 0);
            labelModelValue.Name = "labelModelValue";
            labelModelValue.Size = new Size(0, 13);
            labelModelValue.TabIndex = 5;
            // 
            // labelRegistrationNumberValue
            // 
            labelRegistrationNumberValue.AutoSize = true;
            Css.OrdinaryText.Adjust(labelRegistrationNumberValue);
            labelRegistrationNumberValue.Location = new Point(140, labelModelValue.Bottom);
            labelRegistrationNumberValue.Name = "labelRegistrationNumberValue";
            labelRegistrationNumberValue.Size = new Size(0, 13);
            labelRegistrationNumberValue.TabIndex = 6;
            // 
            // labelSerialNumberValue
            // 
            labelSerialNumberValue.AutoSize = true;
            Css.OrdinaryText.Adjust(labelSerialNumberValue);
            labelSerialNumberValue.Location = new Point(140, labelRegistrationNumberValue.Bottom);
            labelSerialNumberValue.Name = "labelSerialNumberValue";
            labelSerialNumberValue.Size = new Size(0, 13);
            labelSerialNumberValue.TabIndex = 7;
            // 
            // labelManufactureDateValue
            // 
            labelManufactureDateValue.AutoSize = true;
            Css.OrdinaryText.Adjust(labelManufactureDateValue);
            labelManufactureDateValue.Location = new Point(140, labelSerialNumberValue.Bottom);
            labelManufactureDateValue.Name = "labelManufactureDateValue";
            labelManufactureDateValue.Size = new Size(0, 13);
            labelManufactureDateValue.TabIndex = 10;
            // 
            // labelCertificateNumberValue
            // 
            labelCertificateNumberValue.AutoSize = true;
            Css.OrdinaryText.Adjust(labelCertificateNumberValue);
            labelCertificateNumberValue.Location = new Point(140, labelManufactureDateValue.Bottom);
            labelCertificateNumberValue.Name = "labelCertificateNumberValue";
            labelCertificateNumberValue.Size = new Size(0, 13);
            labelCertificateNumberValue.TabIndex = 8;
            // 
            // labelLineNumberValue
            // 
            labelLineNumberValue.AutoSize = true;
            Css.OrdinaryText.Adjust(labelLineNumberValue);
            labelLineNumberValue.Location = new Point(140, labelCertificateNumberValue.Bottom);
            labelLineNumberValue.Name = "labelLineNumberValue";
            labelLineNumberValue.Size = new Size(0, 13);
            labelLineNumberValue.TabIndex = 9;
            // 
            // labelVariableNumberValue
            // 
            labelVariableNumberValue.AutoSize = true;
            Css.OrdinaryText.Adjust(labelVariableNumberValue);
            labelVariableNumberValue.Location = new Point(140, labelLineNumberValue.Bottom);
            labelVariableNumberValue.Name = "labelVariableNumberValue";
            labelVariableNumberValue.Size = new Size(0, 13);
            labelVariableNumberValue.TabIndex = 11;
            // 
            // AbstractAircraftInfoReference
            // 
            //AutoScaleDimensions = new SizeF(6F, 13F);
            MainControl = panelMain;
            //Name = "AbstractAircraftInfoReference";
            //panelMain.ResumeLayout(false);
            //panelMain.PerformLayout();
            //ResumeLayout(false);
            //PerformLayout();
        }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// Абновление данных графического элемента
        /// </summary>
        public abstract void UpdateData();

        #endregion
        
        #endregion

    }
}