using System.Drawing;
using System.Windows.Forms;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.UI.Appearance;

namespace LTR.UI.UIControls.AircraftsControls.AircraftGeneralDataControls
{
    public partial class PowerPlantControl : PictureBox
    {

        #region Fields

        private const int HEIGHT_INTERVAL = 10;
        private const int TEXT_BOX_HEIGHT = 25;
        private const int TEXT_BOX_WIDTH = 150;
        private const int MARGIN = 20;

        private readonly Label labelEngineModel = new Label();
        private readonly Label labelManufacturer = new Label();
        private readonly Label labelPosition = new Label();
        private readonly Label labelSerialNumber = new Label();
        private readonly Label labelCompliance = new Label();
        private readonly Label labelComplianceTSN = new Label();
        private readonly Label labelComplianceCSN = new Label();
        private readonly Label labelComplianceDate = new Label();
        private readonly Label labelComplianceWorkType = new Label();
        private readonly Label labelNext = new Label();
        private readonly Label labelNextTSN = new Label();
        private readonly Label labelNextCSN = new Label();
        private readonly Label labelNextDate = new Label();
        private readonly Label labelNextRemains = new Label();
        private readonly Label labelNextWorkType = new Label();
        private readonly TextBox textBoxEngineModel = new TextBox();
        private readonly TextBox textBoxManufacturer = new TextBox();
        private readonly TextBox textBoxPosition = new TextBox();
        private readonly TextBox textBoxSerialNumber = new TextBox();
        private readonly TextBox textBoxComplianceTSN = new TextBox();
        private readonly TextBox textBoxComplianceCSN = new TextBox();
        private readonly TextBox textBoxComplianceDate = new TextBox();
        private readonly TextBox textBoxComplianceWorktype = new TextBox();
        private readonly TextBox textBoxNextTSN = new TextBox();
        private readonly TextBox textBoxNextCSN = new TextBox();
        private readonly TextBox textBoxNextDate = new TextBox();
        private readonly TextBox textBoxNextRemains = new TextBox();
        private readonly TextBox textBoxNextWorkType = new TextBox();
        private readonly DateTimePicker dateTimePickerComplianceDate = new DateTimePicker();
        private readonly DateTimePicker dateTimePickerNextDate = new DateTimePicker();

        private Engine currentEngine;

        #endregion


        #region Constructor

        public PowerPlantControl(Engine currentEngine)
        {
            this.currentEngine = currentEngine;
            InitializeComponent();
            Size = new Size(TEXT_BOX_WIDTH * 2, (TEXT_BOX_HEIGHT + HEIGHT_INTERVAL)*15);
            Margin = new Padding(10);
            //BackColor = Color.Yellow;
            //
            // labelSerialNumber
            //
            labelSerialNumber.Location = new Point(0, 0);
            labelSerialNumber.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelSerialNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSerialNumber.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelSerialNumber.Text = "Serial Number";
            labelSerialNumber.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelEngineModel
            //
            labelEngineModel.Location = new Point(0, labelSerialNumber.Bottom + HEIGHT_INTERVAL);
            labelEngineModel.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelEngineModel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelEngineModel.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelEngineModel.Text = "Engine Model";
            labelEngineModel.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelManufacturer
            //
            labelManufacturer.Location = new Point(0, labelEngineModel.Bottom + HEIGHT_INTERVAL);
            labelManufacturer.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelManufacturer.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelManufacturer.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelManufacturer.Text = "Manufacturer";
            labelManufacturer.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelPosition
            //
            labelPosition.Location = new Point(0, labelManufacturer.Bottom + HEIGHT_INTERVAL);
            labelPosition.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelPosition.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelPosition.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelPosition.Text = "Position";
            labelPosition.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelCompliance
            //
            labelCompliance.Location = new Point(0, labelPosition.Bottom + HEIGHT_INTERVAL);
            labelCompliance.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelCompliance.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelCompliance.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelCompliance.Text = "Compliance";
            labelCompliance.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelComplianceTSN
            //
            labelComplianceTSN.Location = new Point(MARGIN, labelCompliance.Bottom + HEIGHT_INTERVAL);
            labelComplianceTSN.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelComplianceTSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelComplianceTSN.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelComplianceTSN.Text = "TSN";
            labelComplianceTSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelComplianceCSN
            //
            labelComplianceCSN.Location = new Point(MARGIN, labelComplianceTSN.Bottom + HEIGHT_INTERVAL);
            labelComplianceCSN.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelComplianceCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelComplianceCSN.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelComplianceCSN.Text = "CSN";
            labelComplianceCSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelComplianceDate
            //
            labelComplianceDate.Location = new Point(MARGIN, labelComplianceCSN.Bottom + HEIGHT_INTERVAL);
            labelComplianceDate.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelComplianceDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelComplianceDate.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelComplianceDate.Text = "Date";
            labelComplianceDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelComplianceWorkType
            //
            labelComplianceWorkType.Location = new Point(MARGIN, labelComplianceDate.Bottom + HEIGHT_INTERVAL);
            labelComplianceWorkType.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelComplianceWorkType.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelComplianceWorkType.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelComplianceWorkType.Text = "Work Type";
            labelComplianceWorkType.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelNext
            //
            labelNext.Location = new Point(0, labelComplianceWorkType.Bottom + HEIGHT_INTERVAL);
            labelNext.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelNext.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNext.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            labelNext.Text = "Next";
            labelNext.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelNextTSN
            //
            labelNextTSN.Location = new Point(MARGIN, labelNext.Bottom + HEIGHT_INTERVAL);
            labelNextTSN.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelNextTSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNextTSN.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelNextTSN.Text = "TSN";
            labelNextTSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelNextCSN
            //
            labelNextCSN.Location = new Point(MARGIN, labelNextTSN.Bottom + HEIGHT_INTERVAL);
            labelNextCSN.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelNextCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNextCSN.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelNextCSN.Text = "CSN";
            labelNextCSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelNextDate
            //
            labelNextDate.Location = new Point(MARGIN, labelNextCSN.Bottom + HEIGHT_INTERVAL);
            labelNextDate.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelNextDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNextDate.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelNextDate.Text = "Date";
            labelNextDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelNextRemains
            //
            labelNextRemains.Location = new Point(MARGIN, labelNextDate.Bottom + HEIGHT_INTERVAL);
            labelNextRemains.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelNextRemains.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNextRemains.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelNextRemains.Text = "Remains";
            labelNextRemains.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelNextRemains
            //
            labelNextWorkType.Location = new Point(MARGIN, labelNextRemains.Bottom + HEIGHT_INTERVAL);
            labelNextWorkType.Font = Css.OrdinaryText.Fonts.BoldFont;
            labelNextWorkType.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelNextWorkType.Size = new Size(TEXT_BOX_WIDTH - MARGIN, TEXT_BOX_HEIGHT);
            labelNextWorkType.Text = "Work Type";
            labelNextWorkType.TextAlign = ContentAlignment.MiddleLeft;
            //
            // textBoxSerialNumber
            //
            textBoxSerialNumber.Location = new Point(TEXT_BOX_WIDTH, 0);
            textBoxSerialNumber.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxSerialNumber.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxSerialNumber.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxEngineModel
            //
            textBoxEngineModel.Location = new Point(TEXT_BOX_WIDTH, textBoxSerialNumber.Bottom + HEIGHT_INTERVAL);
            textBoxEngineModel.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxEngineModel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxEngineModel.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxManufacturer
            //
            textBoxManufacturer.Location = new Point(TEXT_BOX_WIDTH, textBoxEngineModel.Bottom + HEIGHT_INTERVAL);
            textBoxManufacturer.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxManufacturer.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxManufacturer.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxPosition
            //
            textBoxPosition.Location = new Point(TEXT_BOX_WIDTH, textBoxManufacturer.Bottom + HEIGHT_INTERVAL);
            textBoxPosition.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxPosition.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxPosition.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxComplianceTSN
            //
            textBoxComplianceTSN.Location = new Point(TEXT_BOX_WIDTH, labelCompliance.Bottom + HEIGHT_INTERVAL);
            textBoxComplianceTSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxComplianceTSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxComplianceTSN.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxComplianceCSN
            //
            textBoxComplianceCSN.Location = new Point(TEXT_BOX_WIDTH, textBoxComplianceTSN.Bottom + HEIGHT_INTERVAL);
            textBoxComplianceCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxComplianceCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxComplianceCSN.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxComplianceDate
            //
            textBoxComplianceDate.Location = new Point(TEXT_BOX_WIDTH, textBoxComplianceCSN.Bottom + HEIGHT_INTERVAL);
            textBoxComplianceDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxComplianceDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxComplianceDate.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxComplianceWorktype
            //
            textBoxComplianceWorktype.Location = new Point(TEXT_BOX_WIDTH, textBoxComplianceDate.Bottom + HEIGHT_INTERVAL);
            textBoxComplianceWorktype.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxComplianceWorktype.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxComplianceWorktype.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxNextTSN
            //
            textBoxNextTSN.Location = new Point(TEXT_BOX_WIDTH, labelNext.Bottom + HEIGHT_INTERVAL);
            textBoxNextTSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxNextTSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxNextTSN.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxNextCSN
            //
            textBoxNextCSN.Location = new Point(TEXT_BOX_WIDTH, textBoxNextTSN.Bottom + HEIGHT_INTERVAL);
            textBoxNextCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxNextCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxNextCSN.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxNextDate
            //
            textBoxNextDate.Location = new Point(TEXT_BOX_WIDTH, textBoxNextCSN.Bottom + HEIGHT_INTERVAL);
            textBoxNextDate.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxNextDate.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxNextDate.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxNextRemains
            //
            textBoxNextRemains.Location = new Point(TEXT_BOX_WIDTH, textBoxNextDate.Bottom + HEIGHT_INTERVAL);
            textBoxNextRemains.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxNextRemains.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxNextRemains.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);
            //
            // textBoxNextWorkType
            //
            textBoxNextWorkType.Location = new Point(TEXT_BOX_WIDTH, textBoxNextRemains.Bottom + HEIGHT_INTERVAL);
            textBoxNextWorkType.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxNextWorkType.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxNextWorkType.Size = new Size(TEXT_BOX_WIDTH, TEXT_BOX_HEIGHT);


            Controls.Add(labelEngineModel);
            Controls.Add(labelManufacturer);
            Controls.Add(labelPosition);
            Controls.Add(labelSerialNumber);
            Controls.Add(labelCompliance);
            Controls.Add(labelComplianceTSN);
            Controls.Add(labelComplianceCSN);
            Controls.Add(labelComplianceDate);
            Controls.Add(labelComplianceWorkType);
            Controls.Add(labelNext);
            Controls.Add(labelNextTSN);
            Controls.Add(labelNextCSN);
            Controls.Add(labelNextDate);
            Controls.Add(labelNextRemains);
            Controls.Add(labelNextWorkType);
            Controls.Add(textBoxEngineModel);
            Controls.Add(textBoxManufacturer);
            Controls.Add(textBoxPosition);
            Controls.Add(textBoxSerialNumber);
            Controls.Add(textBoxComplianceTSN);
            Controls.Add(textBoxComplianceCSN);
            Controls.Add(textBoxComplianceDate);
            Controls.Add(textBoxComplianceWorktype);
            Controls.Add(textBoxNextTSN);
            Controls.Add(textBoxNextCSN);
            Controls.Add(textBoxNextDate);
            Controls.Add(textBoxNextRemains);
            Controls.Add(textBoxNextWorkType);

            UpdateControl();

        }

        #endregion

        #region private void UpdateControl()

        /// <summary>
        /// Обновляет информацию о двигателях текущего ВС
        /// </summary>
        private void UpdateControl()
        {
            textBoxSerialNumber.Text = currentEngine.SerialNumber;
            textBoxEngineModel.Text = currentEngine.Model;
            textBoxManufacturer.Text = currentEngine.Manufacturer;
            textBoxPosition.Text = currentEngine.PositionNumber;
            textBoxComplianceTSN.Text = "Пока нет"; //todo 
            textBoxComplianceCSN.Text = "Пока нет"; //todo
            textBoxComplianceDate.Text = "Не знаю";
            textBoxComplianceWorktype.Text = "Не знаю";
            textBoxNextTSN.Text = "Не знаю";
            textBoxNextCSN.Text = "Не знаю";
            textBoxNextDate.Text = "Не знаю";
            textBoxNextRemains.Text = "Не знаю";
            textBoxNextWorkType.Text = "Не знаю";
        }

        #endregion


    }
}
