using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.EngineeringOrdersDirectives
{
    /// <summary>
    /// Элемент управления для отображения информации, показывающей модификации на самолете в результате выполнения инженерного задания
    /// </summary>
    public class EngineeringOrderDirectiveComplianceDataControl : Control
    {

        #region Fields

        private readonly EngineeringOrderDirective directive;

        private readonly Label labelOperationsPerformanceRestrictions = new Label();
        private readonly Label labelOnboardLoadableSoftwareAffected = new Label();
        private readonly Label labelInterchangeabilityAffected = new Label();
        private readonly Label labelIntermixabilityAffected = new Label();
        private readonly Label labelSparesAffected = new Label();
        private readonly Label labelLabelingAfterModification = new Label();
        private readonly Label labelSpecialToolsEquipmentGSE = new Label();
        private readonly Label labelMaintenanceCheckList = new Label();
        private readonly Label labelDTA = new Label();
        private readonly Label labelAssistanceSupport = new Label();
        private readonly Label labelFlightTest = new Label();
        private readonly Label labelEngineTest = new Label();
        private readonly Label labelWeighing = new Label();
        private readonly Label labelDoubleInspection = new Label();
        private readonly Label labelETOPS = new Label();
        private readonly Label labelChangeInWeight = new Label();
        private readonly Label labelChangeInMoment = new Label();
        private readonly Panel panelOperationsPerformanceRestrictions = new Panel();
        private readonly Panel panelOnboardLoadableSoftwareAffected = new Panel();
        private readonly Panel panelInterchangeabilityAffected = new Panel();
        private readonly Panel panelIntermixabilityAffected = new Panel();
        private readonly Panel panelSparesAffected = new Panel();
        private readonly Panel panelLabelingAfterModification = new Panel();
        private readonly Panel panelSpecialToolsEquipmentGSE = new Panel();
        private readonly Panel panelMaintenanceCheckList = new Panel();
        private readonly Panel panelDTA = new Panel();
        private readonly Panel panelAssistanceSupport = new Panel();
        private readonly Panel panelFlightTest = new Panel();
        private readonly Panel panelEngineTest = new Panel();
        private readonly Panel panelWeighing = new Panel();
        private readonly Panel panelDoubleInspection = new Panel();
        private readonly Panel panelETOPS = new Panel();
        private readonly Panel panelChangeInWeight = new Panel();
        private readonly Panel panelChangeInMoment = new Panel();
        private readonly RadioButton radioButtonOperationsPerformanceRestrictionsYes = new RadioButton();
        private readonly RadioButton radioButtonOperationsPerformanceRestrictionsNo = new RadioButton();
        private readonly RadioButton radioButtonOnboardLoadableSoftwareAffectedYes = new RadioButton();
        private readonly RadioButton radioButtonOnboardLoadableSoftwareAffectedNo = new RadioButton();
        private readonly RadioButton radioButtonInterchangeabilityAffectedYes = new RadioButton();
        private readonly RadioButton radioButtonInterchangeabilityAffectedNo = new RadioButton();
        private readonly RadioButton radioButtonIntermixabilityAffectedYes = new RadioButton();
        private readonly RadioButton radioButtonIntermixabilityAffectedNo = new RadioButton();
        private readonly RadioButton radioButtonSparesAffectedYes = new RadioButton();
        private readonly RadioButton radioButtonSparesAffectedNo = new RadioButton();
        private readonly RadioButton radioButtonLabelingAfterModificationYes = new RadioButton();
        private readonly RadioButton radioButtonLabelingAfterModificationNo = new RadioButton();
        private readonly RadioButton radioButtonSpecialToolsEquipmentGSEYes = new RadioButton();
        private readonly RadioButton radioButtonSpecialToolsEquipmentGSENo = new RadioButton();
        private readonly RadioButton radioButtonMaintenanceCheckListYes = new RadioButton();
        private readonly RadioButton radioButtonMaintenanceCheckListNo = new RadioButton();
        private readonly RadioButton radioButtonDTAYes = new RadioButton();
        private readonly RadioButton radioButtonDTANo = new RadioButton();
        private readonly RadioButton radioButtonAssistanceSupportYes = new RadioButton();
        private readonly RadioButton radioButtonAssistanceSupportNo = new RadioButton();
        private readonly RadioButton radioButtonFlightTestYes = new RadioButton();
        private readonly RadioButton radioButtonFlightTestNo = new RadioButton();
        private readonly RadioButton radioButtonEngineTestYes = new RadioButton();
        private readonly RadioButton radioButtonEngineTestNo = new RadioButton();
        private readonly RadioButton radioButtonWeighingYes = new RadioButton();
        private readonly RadioButton radioButtonWeighingNo = new RadioButton();
        private readonly RadioButton radioButtonDoubleInspectionYes = new RadioButton();
        private readonly RadioButton radioButtonDoubleInspectionNo = new RadioButton();
        private readonly RadioButton radioButtonETOPSYes = new RadioButton();
        private readonly RadioButton radioButtonETOPSNo = new RadioButton();
        private readonly RadioButton radioButtonChangeInWeightYes = new RadioButton();
        private readonly RadioButton radioButtonChangeInWeightNo = new RadioButton();
        private readonly RadioButton radioButtonChangeInMomentYes = new RadioButton();
        private readonly RadioButton radioButtonChangeInMomentNo = new RadioButton();

        private const int MARGIN = 10;
        private const int LABEL_WIDTH = 250;
        private const int LABEL_HEIGHT = 25;
        private const int RADIO_BUTTON_WIDTH = 60;
        private const int HEIGHT_INTERVAL = 20;
        private const int WIDTH_INTERVAL = 600;

        #endregion

        #region Constructors

        #region public EngineeringOrderDirectiveComplianceDataControl()

        /// <summary>
        /// Создает элемент управления для отображения информации, показывающей модификации на самолете в результате выполнения инженерного задания
        /// </summary>
        public EngineeringOrderDirectiveComplianceDataControl()
        {
            InitializeComponents();
        }

        #endregion

        #region public EngineeringOrderDirectiveComplianceDataControl(EngineeringOrderDirective directive)

        /// <summary>
        /// Создает элемент управления для отображения информации, показывающей модификации на самолете в результате выполнения инженерного задания
        /// </summary>
        /// <param name="directive">Отображаемая директива</param>
        public EngineeringOrderDirectiveComplianceDataControl(EngineeringOrderDirective directive)
        {
            if (null == directive)
                throw new ArgumentNullException("directive", "Argument cannot be null");
            this.directive = directive;
            InitializeComponents();
        }

        #endregion


        #endregion

        #region Methods

        #region private void InitializeComponents()

        private void InitializeComponents()
        {
            //
            // labelOperationsPerformanceRestrictions
            //
            labelOperationsPerformanceRestrictions.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelOperationsPerformanceRestrictions.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelOperationsPerformanceRestrictions.Location = new Point(MARGIN, MARGIN);
            labelOperationsPerformanceRestrictions.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelOperationsPerformanceRestrictions.Text = "Operations / Performance Restrictions";
            //
            // panelOperationsPerformanceRestrictions
            //
            panelOperationsPerformanceRestrictions.Location = new Point(labelOperationsPerformanceRestrictions.Right, MARGIN);
            panelOperationsPerformanceRestrictions.Size = new Size(RADIO_BUTTON_WIDTH * 2, LABEL_HEIGHT);
            //
            // radioButtonOperationsPerformanceRestrictionsYes
            //
            radioButtonOperationsPerformanceRestrictionsYes.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonOperationsPerformanceRestrictionsYes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonOperationsPerformanceRestrictionsYes.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonOperationsPerformanceRestrictionsYes.Text = "Yes";
            //
            // radioButtonOperationsPerformanceRestrictionsNo
            //
            radioButtonOperationsPerformanceRestrictionsNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonOperationsPerformanceRestrictionsNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonOperationsPerformanceRestrictionsNo.Location = new Point(radioButtonOperationsPerformanceRestrictionsYes.Right, 0);
            radioButtonOperationsPerformanceRestrictionsNo.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonOperationsPerformanceRestrictionsNo.Text = "No";
            radioButtonOperationsPerformanceRestrictionsNo.Checked = true;
            //
            // labelOnboardLoadableSoftwareAffected
            //
            labelOnboardLoadableSoftwareAffected.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelOnboardLoadableSoftwareAffected.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelOnboardLoadableSoftwareAffected.Location = new Point(MARGIN, labelOperationsPerformanceRestrictions.Bottom + HEIGHT_INTERVAL);
            labelOnboardLoadableSoftwareAffected.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelOnboardLoadableSoftwareAffected.Text = "Onboard loadable Software affected";
            //
            // panelOnboardLoadableSoftwareAffected
            //
            panelOnboardLoadableSoftwareAffected.Location = new Point(labelOnboardLoadableSoftwareAffected.Right, labelOperationsPerformanceRestrictions.Bottom + HEIGHT_INTERVAL);
            panelOnboardLoadableSoftwareAffected.Size = new Size(RADIO_BUTTON_WIDTH * 2, LABEL_HEIGHT);
            //
            // radioButtonOnboardLoadableSoftwareAffectedYes
            //
            radioButtonOnboardLoadableSoftwareAffectedYes.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonOnboardLoadableSoftwareAffectedYes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonOnboardLoadableSoftwareAffectedYes.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonOnboardLoadableSoftwareAffectedYes.Text = "Yes";
            //
            // radioButtonOnboardLoadableSoftwareAffectedNo
            //
            radioButtonOnboardLoadableSoftwareAffectedNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonOnboardLoadableSoftwareAffectedNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonOnboardLoadableSoftwareAffectedNo.Location = new Point(radioButtonOnboardLoadableSoftwareAffectedYes.Right, 0);
            radioButtonOnboardLoadableSoftwareAffectedNo.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonOnboardLoadableSoftwareAffectedNo.Text = "No";
            radioButtonOnboardLoadableSoftwareAffectedNo.Checked = true;
            //
            // labelInterchangeabilityAffected
            //
            labelInterchangeabilityAffected.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelInterchangeabilityAffected.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelInterchangeabilityAffected.Location = new Point(MARGIN, labelOnboardLoadableSoftwareAffected.Bottom + HEIGHT_INTERVAL);
            labelInterchangeabilityAffected.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelInterchangeabilityAffected.Text = "Interchangeability Affected";
            //
            // panelInterchangeabilityAffected
            //
            panelInterchangeabilityAffected.Location = new Point(labelInterchangeabilityAffected.Right, labelOnboardLoadableSoftwareAffected.Bottom + HEIGHT_INTERVAL);
            panelInterchangeabilityAffected.Size = new Size(RADIO_BUTTON_WIDTH * 2, LABEL_HEIGHT);
            //
            // radioButtonInterchangeabilityAffectedYes
            //
            radioButtonInterchangeabilityAffectedYes.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonInterchangeabilityAffectedYes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonInterchangeabilityAffectedYes.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonInterchangeabilityAffectedYes.Text = "Yes";
            //
            // radioButtonInterchangeabilityAffectedNo
            //
            radioButtonInterchangeabilityAffectedNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonInterchangeabilityAffectedNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonInterchangeabilityAffectedNo.Location = new Point(radioButtonInterchangeabilityAffectedYes.Right, 0);
            radioButtonInterchangeabilityAffectedNo.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonInterchangeabilityAffectedNo.Text = "No";
            radioButtonInterchangeabilityAffectedNo.Checked = true;
            //
            // labelIntermixabilityAffected
            //
            labelIntermixabilityAffected.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelIntermixabilityAffected.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelIntermixabilityAffected.Location = new Point(MARGIN, labelInterchangeabilityAffected.Bottom + HEIGHT_INTERVAL);
            labelIntermixabilityAffected.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelIntermixabilityAffected.Text = "Intermixability Affected";
            //
            // panelIntermixabilityAffected
            //
            panelIntermixabilityAffected.Location = new Point(labelIntermixabilityAffected.Right, labelInterchangeabilityAffected.Bottom + HEIGHT_INTERVAL);
            panelIntermixabilityAffected.Size = new Size(RADIO_BUTTON_WIDTH * 2, LABEL_HEIGHT);
            //
            // radioButtonIntermixabilityAffectedYes
            //
            radioButtonIntermixabilityAffectedYes.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonIntermixabilityAffectedYes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonIntermixabilityAffectedYes.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonIntermixabilityAffectedYes.Text = "Yes";
            //
            // radioButtonIntermixabilityAffectedNo
            //
            radioButtonIntermixabilityAffectedNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonIntermixabilityAffectedNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonIntermixabilityAffectedNo.Location = new Point(radioButtonIntermixabilityAffectedYes.Right, 0);
            radioButtonIntermixabilityAffectedNo.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonIntermixabilityAffectedNo.Text = "No";
            radioButtonIntermixabilityAffectedNo.Checked = true;
            //
            // labelSparesAffected
            //
            labelSparesAffected.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSparesAffected.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSparesAffected.Location = new Point(MARGIN, labelIntermixabilityAffected.Bottom + HEIGHT_INTERVAL);
            labelSparesAffected.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelSparesAffected.Text = "Spares Affected";
            //
            // panelSparesAffected
            //
            panelSparesAffected.Location = new Point(labelSparesAffected.Right, labelIntermixabilityAffected.Bottom + HEIGHT_INTERVAL);
            panelSparesAffected.Size = new Size(RADIO_BUTTON_WIDTH * 2, LABEL_HEIGHT);
            //
            // radioButtonSparesAffectedYes
            //
            radioButtonSparesAffectedYes.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonSparesAffectedYes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonSparesAffectedYes.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonSparesAffectedYes.Text = "Yes";
            //
            // radioButtonSparesAffectedNo
            //
            radioButtonSparesAffectedNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonSparesAffectedNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonSparesAffectedNo.Location = new Point(radioButtonSparesAffectedYes.Right, 0);
            radioButtonSparesAffectedNo.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonSparesAffectedNo.Text = "No";
            radioButtonSparesAffectedNo.Checked = true;
            //
            // labelLabelingAfterModification
            //
            labelLabelingAfterModification.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelLabelingAfterModification.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelLabelingAfterModification.Location = new Point(MARGIN, labelSparesAffected.Bottom + HEIGHT_INTERVAL);
            labelLabelingAfterModification.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelLabelingAfterModification.Text = "Labeling after Modification";
            //
            // panelLabelingAfterModification
            //
            panelLabelingAfterModification.Location = new Point(labelLabelingAfterModification.Right, labelSparesAffected.Bottom + HEIGHT_INTERVAL);
            panelLabelingAfterModification.Size = new Size(RADIO_BUTTON_WIDTH * 2, LABEL_HEIGHT);
            //
            // radioButtonLabelingAfterModificationYes
            //
            radioButtonLabelingAfterModificationYes.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonLabelingAfterModificationYes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonLabelingAfterModificationYes.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonLabelingAfterModificationYes.Text = "Yes";
            //
            // radioButtonLabelingAfterModificationNo
            //
            radioButtonLabelingAfterModificationNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonLabelingAfterModificationNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonLabelingAfterModificationNo.Location = new Point(radioButtonLabelingAfterModificationYes.Right, 0);
            radioButtonLabelingAfterModificationNo.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonLabelingAfterModificationNo.Text = "No";
            radioButtonLabelingAfterModificationNo.Checked = true;
            //
            // labelSpecialToolsEquipmentGSE
            //
            labelSpecialToolsEquipmentGSE.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSpecialToolsEquipmentGSE.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSpecialToolsEquipmentGSE.Location = new Point(MARGIN, labelLabelingAfterModification.Bottom + HEIGHT_INTERVAL);
            labelSpecialToolsEquipmentGSE.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelSpecialToolsEquipmentGSE.Text = "Special tools / Equipment / GSE";
            //
            // panelSpecialToolsEquipmentGSE
            //
            panelSpecialToolsEquipmentGSE.Location = new Point(labelSpecialToolsEquipmentGSE.Right, labelLabelingAfterModification.Bottom + HEIGHT_INTERVAL);
            panelSpecialToolsEquipmentGSE.Size = new Size(RADIO_BUTTON_WIDTH * 2, LABEL_HEIGHT);
            //
            // radioButtonSpecialToolsEquipmentGSEYes
            //
            radioButtonSpecialToolsEquipmentGSEYes.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonSpecialToolsEquipmentGSEYes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonSpecialToolsEquipmentGSEYes.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonSpecialToolsEquipmentGSEYes.Text = "Yes";
            //
            // radioButtonSpecialToolsEquipmentGSENo
            //
            radioButtonSpecialToolsEquipmentGSENo.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonSpecialToolsEquipmentGSENo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonSpecialToolsEquipmentGSENo.Location = new Point(radioButtonSpecialToolsEquipmentGSEYes.Right, 0);
            radioButtonSpecialToolsEquipmentGSENo.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonSpecialToolsEquipmentGSENo.Text = "No";
            radioButtonSpecialToolsEquipmentGSENo.Checked = true;
            //
            // labelMaintenanceCheckList
            //
            labelMaintenanceCheckList.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelMaintenanceCheckList.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelMaintenanceCheckList.Location = new Point(MARGIN, labelSpecialToolsEquipmentGSE.Bottom + HEIGHT_INTERVAL);
            labelMaintenanceCheckList.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelMaintenanceCheckList.Text = "Maintenance Check List";
            //
            // panelMaintenanceCheckList
            //
            panelMaintenanceCheckList.Location = new Point(labelMaintenanceCheckList.Right, labelSpecialToolsEquipmentGSE.Bottom + HEIGHT_INTERVAL);
            panelMaintenanceCheckList.Size = new Size(RADIO_BUTTON_WIDTH * 2, LABEL_HEIGHT);
            //
            // radioButtonMaintenanceCheckListYes
            //
            radioButtonMaintenanceCheckListYes.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonMaintenanceCheckListYes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonMaintenanceCheckListYes.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonMaintenanceCheckListYes.Text = "Yes";
            //
            // radioButtonMaintenanceCheckListNo
            //
            radioButtonMaintenanceCheckListNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonMaintenanceCheckListNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonMaintenanceCheckListNo.Location = new Point(radioButtonMaintenanceCheckListYes.Right, 0);
            radioButtonMaintenanceCheckListNo.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonMaintenanceCheckListNo.Text = "No";
            radioButtonMaintenanceCheckListNo.Checked = true;
            //
            // labelDTA
            //
            labelDTA.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDTA.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDTA.Location = new Point(MARGIN, labelMaintenanceCheckList.Bottom + HEIGHT_INTERVAL);
            labelDTA.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelDTA.Text = "DTA";
            //
            // panelDTA
            //
            panelDTA.Location = new Point(labelDTA.Right, labelMaintenanceCheckList.Bottom + HEIGHT_INTERVAL);
            panelDTA.Size = new Size(RADIO_BUTTON_WIDTH * 2, LABEL_HEIGHT);
            //
            // radioButtonDTAYes
            //
            radioButtonDTAYes.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonDTAYes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonDTAYes.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonDTAYes.Text = "Yes";
            //
            // radioButtonDTANo
            //
            radioButtonDTANo.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonDTANo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonDTANo.Location = new Point(radioButtonDTAYes.Right, 0);
            radioButtonDTANo.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonDTANo.Text = "No";
            radioButtonDTANo.Checked = true;
            //
            // labelAssistanceSupport
            //
            labelAssistanceSupport.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelAssistanceSupport.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelAssistanceSupport.Location = new Point(WIDTH_INTERVAL, MARGIN);
            labelAssistanceSupport.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelAssistanceSupport.Text = "Assistance support";
            //
            // panelAssistanceSupport
            //
            panelAssistanceSupport.Location = new Point(labelAssistanceSupport.Right, MARGIN);
            panelAssistanceSupport.Size = new Size(RADIO_BUTTON_WIDTH * 2, LABEL_HEIGHT);
            //
            // radioButtonAssistanceSupportYes
            //
            radioButtonAssistanceSupportYes.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonAssistanceSupportYes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonAssistanceSupportYes.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonAssistanceSupportYes.Text = "Yes";
            //
            // radioButtonAssistanceSupportNo
            //
            radioButtonAssistanceSupportNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonAssistanceSupportNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonAssistanceSupportNo.Location = new Point(radioButtonAssistanceSupportYes.Right, 0);
            radioButtonAssistanceSupportNo.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonAssistanceSupportNo.Text = "No";
            radioButtonAssistanceSupportNo.Checked = true;
            //
            // labelFlightTest
            //
            labelFlightTest.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelFlightTest.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelFlightTest.Location = new Point(WIDTH_INTERVAL, labelAssistanceSupport.Bottom + HEIGHT_INTERVAL);
            labelFlightTest.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelFlightTest.Text = "Flight Test";
            //
            // panelFlightTest
            //
            panelFlightTest.Location = new Point(labelFlightTest.Right, labelAssistanceSupport.Bottom + HEIGHT_INTERVAL);
            panelFlightTest.Size = new Size(RADIO_BUTTON_WIDTH * 2, LABEL_HEIGHT);
            //
            // radioButtonFlightTestYes
            //
            radioButtonFlightTestYes.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonFlightTestYes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonFlightTestYes.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonFlightTestYes.Text = "Yes";
            //
            // radioButtonFlightTestNo
            //
            radioButtonFlightTestNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonFlightTestNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonFlightTestNo.Location = new Point(radioButtonFlightTestYes.Right, 0);
            radioButtonFlightTestNo.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonFlightTestNo.Text = "No";
            radioButtonFlightTestNo.Checked = true;
            //
            // labelEngineTest
            //
            labelEngineTest.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelEngineTest.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelEngineTest.Location = new Point(WIDTH_INTERVAL, labelFlightTest.Bottom + HEIGHT_INTERVAL);
            labelEngineTest.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelEngineTest.Text = "Engine Test";
            //
            // panelEngineTest
            //
            panelEngineTest.Location = new Point(labelEngineTest.Right, labelFlightTest.Bottom + HEIGHT_INTERVAL);
            panelEngineTest.Size = new Size(RADIO_BUTTON_WIDTH * 2, LABEL_HEIGHT);
            //
            // radioButtonEngineTestYes
            //
            radioButtonEngineTestYes.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonEngineTestYes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonEngineTestYes.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonEngineTestYes.Text = "Yes";
            //
            // radioButtonEngineTestNo
            //
            radioButtonEngineTestNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonEngineTestNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonEngineTestNo.Location = new Point(radioButtonEngineTestYes.Right, 0);
            radioButtonEngineTestNo.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonEngineTestNo.Text = "No";
            radioButtonEngineTestNo.Checked = true;
            //
            // labelWeighing
            //
            labelWeighing.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelWeighing.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelWeighing.Location = new Point(WIDTH_INTERVAL, labelEngineTest.Bottom + HEIGHT_INTERVAL);
            labelWeighing.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelWeighing.Text = "Weighing";
            //
            // panelWeighing
            //
            panelWeighing.Location = new Point(labelWeighing.Right, labelEngineTest.Bottom + HEIGHT_INTERVAL);
            panelWeighing.Size = new Size(RADIO_BUTTON_WIDTH * 2, LABEL_HEIGHT);
            //
            // radioButtonWeighingYes
            //
            radioButtonWeighingYes.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonWeighingYes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonWeighingYes.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonWeighingYes.Text = "Yes";
            //
            // radioButtonWeighingNo
            //
            radioButtonWeighingNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonWeighingNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonWeighingNo.Location = new Point(radioButtonWeighingYes.Right, 0);
            radioButtonWeighingNo.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonWeighingNo.Text = "No";
            radioButtonWeighingNo.Checked = true;
            //
            // labelDoubleInspection
            //
            labelDoubleInspection.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDoubleInspection.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDoubleInspection.Location = new Point(WIDTH_INTERVAL, labelWeighing.Bottom + HEIGHT_INTERVAL);
            labelDoubleInspection.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelDoubleInspection.Text = "Double Inspection";
            //
            // panelDoubleInspection
            //
            panelDoubleInspection.Location = new Point(labelDoubleInspection.Right, labelWeighing.Bottom + HEIGHT_INTERVAL);
            panelDoubleInspection.Size = new Size(RADIO_BUTTON_WIDTH * 2, LABEL_HEIGHT);
            //
            // radioButtonDoubleInspectionYes
            //
            radioButtonDoubleInspectionYes.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonDoubleInspectionYes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonDoubleInspectionYes.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonDoubleInspectionYes.Text = "Yes";
            //
            // radioButtonDoubleInspectionNo
            //
            radioButtonDoubleInspectionNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonDoubleInspectionNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonDoubleInspectionNo.Location = new Point(radioButtonDoubleInspectionYes.Right, 0);
            radioButtonDoubleInspectionNo.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonDoubleInspectionNo.Text = "No";
            radioButtonDoubleInspectionNo.Checked = true;
            //
            // labelETOPS
            //
            labelETOPS.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelETOPS.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelETOPS.Location = new Point(WIDTH_INTERVAL, labelDoubleInspection.Bottom + HEIGHT_INTERVAL);
            labelETOPS.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelETOPS.Text = "ETOPS";
            //
            // panelETOPS
            //
            panelETOPS.Location = new Point(labelETOPS.Right, labelDoubleInspection.Bottom + HEIGHT_INTERVAL);
            panelETOPS.Size = new Size(RADIO_BUTTON_WIDTH * 2, LABEL_HEIGHT);
            //
            // radioButtonETOPSYes
            //
            radioButtonETOPSYes.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonETOPSYes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonETOPSYes.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonETOPSYes.Text = "Yes";
            //
            // radioButtonETOPSNo
            //
            radioButtonETOPSNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonETOPSNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonETOPSNo.Location = new Point(radioButtonETOPSYes.Right, 0);
            radioButtonETOPSNo.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonETOPSNo.Text = "No";
            radioButtonETOPSNo.Checked = true;
            //
            // labelChangeInWeight
            //
            labelChangeInWeight.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelChangeInWeight.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelChangeInWeight.Location = new Point(WIDTH_INTERVAL, labelETOPS.Bottom + HEIGHT_INTERVAL);
            labelChangeInWeight.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelChangeInWeight.Text = "Change in Weight";
            //
            // panelChangeInWeight
            //
            panelChangeInWeight.Location = new Point(labelChangeInWeight.Right, labelETOPS.Bottom + HEIGHT_INTERVAL);
            panelChangeInWeight.Size = new Size(RADIO_BUTTON_WIDTH * 2, LABEL_HEIGHT);
            //
            // radioButtonChangeInWeightYes
            //
            radioButtonChangeInWeightYes.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonChangeInWeightYes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonChangeInWeightYes.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonChangeInWeightYes.Text = "Yes";
            //
            // radioButtonChangeInWeightNo
            //
            radioButtonChangeInWeightNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonChangeInWeightNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonChangeInWeightNo.Location = new Point(radioButtonChangeInWeightYes.Right, 0);
            radioButtonChangeInWeightNo.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonChangeInWeightNo.Text = "No";
            radioButtonChangeInWeightNo.Checked = true;
            //
            // labelChangeInMoment
            //
            labelChangeInMoment.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelChangeInMoment.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelChangeInMoment.Location = new Point(WIDTH_INTERVAL, labelChangeInWeight.Bottom + HEIGHT_INTERVAL);
            labelChangeInMoment.Size = new Size(LABEL_WIDTH, LABEL_HEIGHT);
            labelChangeInMoment.Text = "Change in Moment";
            //
            // panelChangeInMoment
            //
            panelChangeInMoment.Location = new Point(labelChangeInMoment.Right, labelChangeInWeight.Bottom + HEIGHT_INTERVAL);
            panelChangeInMoment.Size = new Size(RADIO_BUTTON_WIDTH * 2, LABEL_HEIGHT);
            //
            // radioButtonChangeInMomentYes
            //
            radioButtonChangeInMomentYes.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonChangeInMomentYes.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonChangeInMomentYes.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonChangeInMomentYes.Text = "Yes";
            //
            // radioButtonChangeInMomentNo
            //
            radioButtonChangeInMomentNo.Font = Css.OrdinaryText.Fonts.RegularFont;
            radioButtonChangeInMomentNo.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            radioButtonChangeInMomentNo.Location = new Point(radioButtonChangeInMomentYes.Right, 0);
            radioButtonChangeInMomentNo.Size = new Size(RADIO_BUTTON_WIDTH, LABEL_HEIGHT);
            radioButtonChangeInMomentNo.Text = "No";
            radioButtonChangeInMomentNo.Checked = true;

            BackColor = Css.CommonAppearance.Colors.BackColor;
            Size = new Size(WIDTH_INTERVAL + LABEL_WIDTH + RADIO_BUTTON_WIDTH * 2 + MARGIN, 2 * MARGIN + 9 * LABEL_HEIGHT + 8 * HEIGHT_INTERVAL);
            Controls.Add(labelOperationsPerformanceRestrictions);
            Controls.Add(labelOnboardLoadableSoftwareAffected);
            Controls.Add(labelInterchangeabilityAffected);
            Controls.Add(labelIntermixabilityAffected);
            Controls.Add(labelSparesAffected);
            Controls.Add(labelLabelingAfterModification);
            Controls.Add(labelSpecialToolsEquipmentGSE);
            Controls.Add(labelMaintenanceCheckList);
            Controls.Add(labelDTA);
            Controls.Add(labelAssistanceSupport);
            Controls.Add(labelFlightTest);
            Controls.Add(labelEngineTest);
            Controls.Add(labelWeighing);
            Controls.Add(labelDoubleInspection);
            Controls.Add(labelETOPS);
            Controls.Add(labelChangeInWeight);
            Controls.Add(labelChangeInMoment);
            Controls.Add(panelOperationsPerformanceRestrictions);
            Controls.Add(panelOnboardLoadableSoftwareAffected);
            Controls.Add(panelInterchangeabilityAffected);
            Controls.Add(panelIntermixabilityAffected);
            Controls.Add(panelSparesAffected);
            Controls.Add(panelLabelingAfterModification);
            Controls.Add(panelSpecialToolsEquipmentGSE);
            Controls.Add(panelMaintenanceCheckList);
            Controls.Add(panelDTA);
            Controls.Add(panelAssistanceSupport);
            Controls.Add(panelFlightTest);
            Controls.Add(panelEngineTest);
            Controls.Add(panelWeighing);
            Controls.Add(panelDoubleInspection);
            Controls.Add(panelETOPS);
            Controls.Add(panelChangeInWeight);
            Controls.Add(panelChangeInMoment);
            panelOperationsPerformanceRestrictions.Controls.Add(radioButtonOperationsPerformanceRestrictionsYes);
            panelOperationsPerformanceRestrictions.Controls.Add(radioButtonOperationsPerformanceRestrictionsNo);
            panelOnboardLoadableSoftwareAffected.Controls.Add(radioButtonOnboardLoadableSoftwareAffectedYes);
            panelOnboardLoadableSoftwareAffected.Controls.Add(radioButtonOnboardLoadableSoftwareAffectedNo);
            panelInterchangeabilityAffected.Controls.Add(radioButtonInterchangeabilityAffectedYes);
            panelInterchangeabilityAffected.Controls.Add(radioButtonInterchangeabilityAffectedNo);
            panelIntermixabilityAffected.Controls.Add(radioButtonIntermixabilityAffectedYes);
            panelIntermixabilityAffected.Controls.Add(radioButtonIntermixabilityAffectedNo);
            panelSparesAffected.Controls.Add(radioButtonSparesAffectedYes);
            panelSparesAffected.Controls.Add(radioButtonSparesAffectedNo);
            panelLabelingAfterModification.Controls.Add(radioButtonLabelingAfterModificationYes);
            panelLabelingAfterModification.Controls.Add(radioButtonLabelingAfterModificationNo);
            panelSpecialToolsEquipmentGSE.Controls.Add(radioButtonSpecialToolsEquipmentGSEYes);
            panelSpecialToolsEquipmentGSE.Controls.Add(radioButtonSpecialToolsEquipmentGSENo);
            panelMaintenanceCheckList.Controls.Add(radioButtonMaintenanceCheckListYes);
            panelMaintenanceCheckList.Controls.Add(radioButtonMaintenanceCheckListNo);
            panelDTA.Controls.Add(radioButtonDTAYes);
            panelDTA.Controls.Add(radioButtonDTANo);
            panelAssistanceSupport.Controls.Add(radioButtonAssistanceSupportYes);
            panelAssistanceSupport.Controls.Add(radioButtonAssistanceSupportNo);
            panelFlightTest.Controls.Add(radioButtonFlightTestYes);
            panelFlightTest.Controls.Add(radioButtonFlightTestNo);
            panelEngineTest.Controls.Add(radioButtonEngineTestYes);
            panelEngineTest.Controls.Add(radioButtonEngineTestNo);
            panelWeighing.Controls.Add(radioButtonWeighingYes);
            panelWeighing.Controls.Add(radioButtonWeighingNo);
            panelDoubleInspection.Controls.Add(radioButtonDoubleInspectionYes);
            panelDoubleInspection.Controls.Add(radioButtonDoubleInspectionNo);
            panelETOPS.Controls.Add(radioButtonETOPSYes);
            panelETOPS.Controls.Add(radioButtonETOPSNo);
            panelChangeInWeight.Controls.Add(radioButtonChangeInWeightYes);
            panelChangeInWeight.Controls.Add(radioButtonChangeInWeightNo);
            panelChangeInMoment.Controls.Add(radioButtonChangeInMomentYes);
            panelChangeInMoment.Controls.Add(radioButtonChangeInMomentNo);
        }

        #endregion
        
        #region public bool GetChangeStatus(bool directiveExist)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <param name="directiveExist">Показывает, существует ли уже директива или нет</param>
        /// <returns></returns>
        public bool GetChangeStatus(bool directiveExist)
        {
            if (directiveExist)
                return(radioButtonOperationsPerformanceRestrictionsYes.Checked != directive.PerfomanceRestrictions ||
                       radioButtonOnboardLoadableSoftwareAffectedYes.Checked != directive.OnboardLoadableSoftwareAffected ||
                       radioButtonInterchangeabilityAffectedYes.Checked != directive.InterchangeabilityAffected ||
                       radioButtonIntermixabilityAffectedYes.Checked != directive.IntermixabilityAffected ||
                       radioButtonSparesAffectedYes.Checked != directive.SparesAffected ||
                       radioButtonLabelingAfterModificationYes.Checked != directive.LabelingAfterModification ||
                       radioButtonSpecialToolsEquipmentGSEYes.Checked != directive.SpecialToolsEquipmentGSE ||
                       radioButtonMaintenanceCheckListYes.Checked != directive.MaintenanceCheckList ||
                       radioButtonDTAYes.Checked != directive.DTA ||
                       radioButtonAssistanceSupportYes.Checked != directive.AssistenceSupport ||
                       radioButtonFlightTestYes.Checked != directive.FlightTest ||
                       radioButtonEngineTestYes.Checked != directive.EngineTest ||
                       radioButtonWeighingYes.Checked != directive.Weighing ||
                       radioButtonDoubleInspectionYes.Checked != directive.DoubleInspection ||
                       radioButtonETOPSYes.Checked != directive.ETOPS ||
                       radioButtonChangeInWeightYes.Checked != directive.ChangeInWeight ||
                       radioButtonChangeInMomentYes.Checked != directive.ChangeInMoment);
            else
                return (radioButtonOperationsPerformanceRestrictionsYes.Checked ||
                        radioButtonOnboardLoadableSoftwareAffectedYes.Checked ||
                        radioButtonInterchangeabilityAffectedYes.Checked ||
                        radioButtonIntermixabilityAffectedYes.Checked ||
                        radioButtonSparesAffectedYes.Checked ||
                        radioButtonLabelingAfterModificationYes.Checked ||
                        radioButtonSpecialToolsEquipmentGSEYes.Checked ||
                        radioButtonMaintenanceCheckListYes.Checked ||
                        radioButtonDTAYes.Checked ||
                        radioButtonAssistanceSupportYes.Checked ||
                        radioButtonFlightTestYes.Checked ||
                        radioButtonEngineTestYes.Checked ||
                        radioButtonWeighingYes.Checked ||
                        radioButtonDoubleInspectionYes.Checked ||
                        radioButtonETOPSYes.Checked ||
                        radioButtonChangeInWeightYes.Checked ||
                        radioButtonChangeInMomentYes.Checked);
            
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Заполняет поля для редактирования директивы
        /// </summary>
        public void UpdateInformation()
        {
            if (directive != null)
                UpdateInformation(directive);
        }

        #endregion

        #region public void UpdateInformation(EngineeringOrderDirective sourceDirective)

        /// <summary>
        /// 3аполняет поля для редактирования директивы
        /// </summary>
        /// <param name="sourceDirective"></param>
        public void UpdateInformation(EngineeringOrderDirective sourceDirective)
        {
            if (sourceDirective == null)
                throw new ArgumentNullException("sourceDirective");
            radioButtonOperationsPerformanceRestrictionsYes.Checked = sourceDirective.PerfomanceRestrictions;
            radioButtonOnboardLoadableSoftwareAffectedYes.Checked = sourceDirective.OnboardLoadableSoftwareAffected;
            radioButtonInterchangeabilityAffectedYes.Checked = sourceDirective.InterchangeabilityAffected;
            radioButtonIntermixabilityAffectedYes.Checked = sourceDirective.IntermixabilityAffected;
            radioButtonSparesAffectedYes.Checked = sourceDirective.SparesAffected;
            radioButtonLabelingAfterModificationYes.Checked = sourceDirective.LabelingAfterModification;
            radioButtonSpecialToolsEquipmentGSEYes.Checked = sourceDirective.SpecialToolsEquipmentGSE;
            radioButtonMaintenanceCheckListYes.Checked = sourceDirective.MaintenanceCheckList;
            radioButtonDTAYes.Checked = sourceDirective.DTA;
            radioButtonAssistanceSupportYes.Checked = sourceDirective.AssistenceSupport;
            radioButtonFlightTestYes.Checked = sourceDirective.FlightTest;
            radioButtonEngineTestYes.Checked = sourceDirective.EngineTest;
            radioButtonWeighingYes.Checked = sourceDirective.Weighing;
            radioButtonDoubleInspectionYes.Checked = sourceDirective.DoubleInspection;
            radioButtonETOPSYes.Checked = sourceDirective.ETOPS;
            radioButtonChangeInWeightYes.Checked = sourceDirective.ChangeInWeight;
            radioButtonChangeInMomentYes.Checked = sourceDirective.ChangeInMoment;
            

            bool permission = directive.HasPermission(Users.CurrentUser, DataEvent.Update);

            radioButtonOperationsPerformanceRestrictionsYes.Enabled = permission;
            radioButtonOperationsPerformanceRestrictionsNo.Enabled = permission;
            radioButtonOnboardLoadableSoftwareAffectedYes.Enabled = permission;
            radioButtonOnboardLoadableSoftwareAffectedNo.Enabled = permission;
            radioButtonInterchangeabilityAffectedYes.Enabled = permission;
            radioButtonInterchangeabilityAffectedNo.Enabled = permission;
            radioButtonIntermixabilityAffectedYes.Enabled = permission;
            radioButtonIntermixabilityAffectedNo.Enabled = permission;
            radioButtonSparesAffectedYes.Enabled = permission;
            radioButtonSparesAffectedNo.Enabled = permission;
            radioButtonLabelingAfterModificationYes.Enabled = permission;
            radioButtonLabelingAfterModificationNo.Enabled = permission;
            radioButtonSpecialToolsEquipmentGSEYes.Enabled = permission;
            radioButtonSpecialToolsEquipmentGSENo.Enabled = permission;
            radioButtonMaintenanceCheckListYes.Enabled = permission;
            radioButtonMaintenanceCheckListNo.Enabled = permission;
            radioButtonDTAYes.Enabled = permission;
            radioButtonDTANo.Enabled = permission;
            radioButtonAssistanceSupportYes.Enabled = permission;
            radioButtonAssistanceSupportNo.Enabled = permission;
            radioButtonFlightTestYes.Enabled = permission;
            radioButtonFlightTestNo.Enabled = permission;
            radioButtonEngineTestYes.Enabled = permission;
            radioButtonEngineTestNo.Enabled = permission;
            radioButtonWeighingYes.Enabled = permission;
            radioButtonWeighingNo.Enabled = permission;
            radioButtonDoubleInspectionYes.Enabled = permission;
            radioButtonDoubleInspectionNo.Enabled = permission;
            radioButtonETOPSYes.Enabled = permission;
            radioButtonETOPSNo.Enabled = permission;
            radioButtonChangeInWeightYes.Enabled = permission;
            radioButtonChangeInWeightNo.Enabled = permission;
            radioButtonChangeInMomentYes.Enabled = permission;
            radioButtonChangeInMomentNo.Enabled = permission;
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public void SaveData()
        {
            if (directive != null)
            {
                SaveData(directive);
            }
        }

        #endregion

        #region public void SaveData(EngineeringOrderDirective destinationDirective)

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        /// <param name="destinationDirective">Директива</param>
        public void SaveData(EngineeringOrderDirective destinationDirective)
        {
            if (destinationDirective.PerfomanceRestrictions != radioButtonOperationsPerformanceRestrictionsYes.Checked)
                destinationDirective.PerfomanceRestrictions = radioButtonOperationsPerformanceRestrictionsYes.Checked;
            if (destinationDirective.OnboardLoadableSoftwareAffected != radioButtonOnboardLoadableSoftwareAffectedYes.Checked)
                destinationDirective.OnboardLoadableSoftwareAffected = radioButtonOnboardLoadableSoftwareAffectedYes.Checked;
            if (destinationDirective.InterchangeabilityAffected  != radioButtonInterchangeabilityAffectedYes.Checked)
                destinationDirective.InterchangeabilityAffected = radioButtonInterchangeabilityAffectedYes.Checked;
            if (destinationDirective.IntermixabilityAffected != radioButtonIntermixabilityAffectedYes.Checked)
                destinationDirective.IntermixabilityAffected = radioButtonIntermixabilityAffectedYes.Checked;
            if (destinationDirective.SparesAffected != radioButtonSparesAffectedYes.Checked)
                destinationDirective.SparesAffected = radioButtonSparesAffectedYes.Checked;
            if (destinationDirective.LabelingAfterModification != radioButtonLabelingAfterModificationYes.Checked)
                destinationDirective.LabelingAfterModification = radioButtonLabelingAfterModificationYes.Checked;
            if (destinationDirective.SpecialToolsEquipmentGSE != radioButtonSpecialToolsEquipmentGSEYes.Checked)
                destinationDirective.SpecialToolsEquipmentGSE = radioButtonSpecialToolsEquipmentGSEYes.Checked;
            if (destinationDirective.MaintenanceCheckList != radioButtonMaintenanceCheckListYes.Checked)
                destinationDirective.MaintenanceCheckList = radioButtonMaintenanceCheckListYes.Checked;
            if (destinationDirective.DTA != radioButtonDTAYes.Checked)
                destinationDirective.DTA = radioButtonDTAYes.Checked;
            if (destinationDirective.AssistenceSupport != radioButtonAssistanceSupportYes.Checked)
                destinationDirective.AssistenceSupport = radioButtonAssistanceSupportYes.Checked;
            if (destinationDirective.FlightTest != radioButtonFlightTestYes.Checked)
                destinationDirective.FlightTest = radioButtonFlightTestYes.Checked;
            if (destinationDirective.EngineTest != radioButtonEngineTestYes.Checked)
                destinationDirective.EngineTest = radioButtonEngineTestYes.Checked;
            if (destinationDirective.Weighing != radioButtonWeighingYes.Checked)
                destinationDirective.Weighing = radioButtonWeighingYes.Checked;
            if (destinationDirective.DoubleInspection != radioButtonDoubleInspectionYes.Checked)
                destinationDirective.DoubleInspection = radioButtonDoubleInspectionYes.Checked;
            if (destinationDirective.ETOPS != radioButtonETOPSYes.Checked)
                destinationDirective.ETOPS = radioButtonETOPSYes.Checked;
            if (destinationDirective.ChangeInWeight != radioButtonChangeInWeightYes.Checked)
                destinationDirective.ChangeInWeight = radioButtonChangeInWeightYes.Checked;
            if (destinationDirective.ChangeInMoment != radioButtonChangeInMomentYes.Checked)
                destinationDirective.ChangeInMoment = radioButtonChangeInMomentYes.Checked;
        }
        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            radioButtonOperationsPerformanceRestrictionsNo.Checked = true;
            radioButtonOnboardLoadableSoftwareAffectedYes.Checked = true;
            radioButtonInterchangeabilityAffectedYes.Checked = true;
            radioButtonIntermixabilityAffectedYes.Checked = true;
            radioButtonSparesAffectedYes.Checked = true;
            radioButtonLabelingAfterModificationYes.Checked = true;
            radioButtonSpecialToolsEquipmentGSEYes.Checked = true;
            radioButtonMaintenanceCheckListYes.Checked = true;
            radioButtonDTAYes.Checked = true;
            radioButtonAssistanceSupportYes.Checked = true;
            radioButtonFlightTestYes.Checked = true;
            radioButtonEngineTestYes.Checked = true;
            radioButtonWeighingYes.Checked = true;
            radioButtonDoubleInspectionYes.Checked = true;
            radioButtonETOPSYes.Checked = true;
            radioButtonChangeInWeightYes.Checked = true;
            radioButtonChangeInMomentYes.Checked = true;
        }

        #endregion

        #endregion


    }
}
