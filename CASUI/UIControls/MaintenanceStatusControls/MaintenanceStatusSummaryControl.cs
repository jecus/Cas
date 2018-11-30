using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.MaintenanceStatusControls;

namespace CAS.UI.UIControls.MaintenanceStatusControls
{
    /// <summary>
    /// Элемент управления для отображения чеков
    /// </summary>
    public class MaintenanceStatusSummaryControl : UserControl
    {
        #region Fields

        private readonly Aircraft currentAircraft;
        private readonly List<MaintenanceStatusSummaryControlRow> rows = new List<MaintenanceStatusSummaryControlRow>();
        private readonly Label labelDateAsOf = new Label();
        private readonly Label labelTSNCSN = new Label();
        private readonly ReferenceLinkLabel linkEdit = new ReferenceLinkLabel();
        //private readonly MaintenanceDirective directive;
        private const int INTERVAL = 10;
        //private const int LEFT_MARGIN = 25;
        private const int LABEL_DATE_AS_OF_LEFT_MARGIN = 50;
        private const int LABEL_DATE_AS_OF_HEIGHT = 30;
        //private const int LABEL_DATE_AS_OF_WIDTH = 30;
        private bool displayDateAsOFAndTSNCSN = true;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает новый экземпляр элемента управляения для отображения чеков
        /// </summary>
        /// <param name="currentAircraft">ВС</param>
        public MaintenanceStatusSummaryControl(Aircraft currentAircraft)
        {
            this.currentAircraft = currentAircraft;
            //this.directive = directive;
            //
            // labelDateAsOf
            //
            labelDateAsOf.AutoSize = true;
            labelDateAsOf.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDateAsOf.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDateAsOf.MinimumSize = new Size(0, LABEL_DATE_AS_OF_HEIGHT);
            labelDateAsOf.TextAlign = ContentAlignment.MiddleLeft;
            //
            // labelTSNCSN
            //
            labelTSNCSN.AutoSize = true;
            labelTSNCSN.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelTSNCSN.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelTSNCSN.MinimumSize = new Size(0, LABEL_DATE_AS_OF_HEIGHT);
            labelTSNCSN.TextAlign = ContentAlignment.MiddleLeft;
            //
            // linkEdit
            //
            linkEdit.AutoSize = true;
            Css.SimpleLink.Adjust(linkEdit);
            linkEdit.Text = "See Subchecks";
            linkEdit.DisplayerText = currentAircraft + ". Maintenance Status. Checks";
            linkEdit.ReflectionType = ReflectionTypes.DisplayInNew;
            linkEdit.Entity = new DispatcheredSubChecksCollectionScreen(currentAircraft.MaintenanceDirective);

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            //DisplayLimitations();
        }

        #endregion

        #region Properties

        #region public string LinkLabelText

        /// <summary>
        /// Возвращает или устанавливает текст ссылки
        /// </summary>
        public string LinkLabelText
        {
            get
            {
                return linkEdit.Text;
            }
            set
            {
                linkEdit.Text = value;
            }
        }

        #endregion

        #region public string LinkLabelDisplayerText

        /// <summary>
        /// Возвращает или устанавливает текст открываемой вкладки
        /// </summary>
        public string LinkLabelDisplayerText
        {
            get
            {
                return linkEdit.DisplayerText;
            }
            set
            {
                linkEdit.DisplayerText = value;
            }
        }

        #endregion

        #region public IDisplayingEntity LinkLabelRequestedEntity

        /// <summary>
        /// Возвращает или устанавливает вкладку, которую требуется открыть
        /// </summary>
        public IDisplayingEntity LinkLabelRequestedEntity
        {
            get
            {
                return linkEdit.Entity;
            }
            set
            {
                linkEdit.Entity = value;
            }
        }

        #endregion

        #region public bool DisplayDateAsOFAndTSNCSN

        /// <summary>
        /// Возвращает или устанавливает значение, показывающее, нужно ли отображать DateAsOf и TSNCSN текущего ВС
        /// </summary>
        public bool DisplayDateAsOFAndTSNCSN
        {
            get { return displayDateAsOFAndTSNCSN; }
            set { displayDateAsOFAndTSNCSN = value; }
        }

        #endregion

        #endregion
        
        #region Methods

        #region public void DisplayLimitations()

        /// <summary>
        /// Происходит отображение переданных ограничений
        /// </summary>
        public void DisplayLimitations()
        {
            rows.Clear();
            Controls.Clear();
            MaintenanceStatusSummaryControlRow controlTitle = new MaintenanceStatusSummaryControlRow();
            if (DisplayDateAsOFAndTSNCSN)
            {
                //
                // labelDateAsOf
                //
                labelDateAsOf.Text = "Date As Of: " + DateTime.Today.ToString(new TermsProvider()["DateFormat"].ToString());
                labelDateAsOf.Location = new Point(LABEL_DATE_AS_OF_LEFT_MARGIN, 0);
                //
                // labelTSNCSN
                //
                labelTSNCSN.Text = currentAircraft + " TSN/CSN: ";// +currentAircraft.Limitation.ResourceSinceNew.ToComplianceItemString(); todo
                labelTSNCSN.Location = new Point(LABEL_DATE_AS_OF_LEFT_MARGIN, labelDateAsOf.Bottom);
                Controls.Add(labelDateAsOf);
                Controls.Add(labelTSNCSN);
                controlTitle.Top = labelTSNCSN.Bottom;
            }
            Controls.Add(controlTitle);
            rows.Add(controlTitle);
            for (int i = 0; i < currentAircraft.MaintenanceDirective.Limitations.Length; i++)
            {
                MaintenanceLimitation limitation = currentAircraft.MaintenanceDirective.Limitations[i];
                if (!limitation.IsInuse)
                    continue;
                MaintenanceStatusSummaryControlRow controlRow = new MaintenanceStatusSummaryControlRow(limitation);
                controlRow.Top = rows[rows.Count - 1].Bottom;
                rows.Add(controlRow);
                Controls.Add(controlRow);
            }
            //
            // linkEdit
            //
            linkEdit.Location = new Point(LABEL_DATE_AS_OF_LEFT_MARGIN ,rows[rows.Count - 1].Bottom + INTERVAL);
            Controls.Add(linkEdit);
            //Size = new Size(MaintenanceStatusSummaryControlRow.DefaultSize.Width, rows.Count * MaintenanceStatusSummaryControlRow.DefaultSize.Height + labelDateAsOf.Height + labelTSNCSN.Height + linkEdit.Height + INTERVAL);
        }

        #endregion

        #endregion

    }

    /// <summary>
    /// Элемент управления для отображения строки <see cref="MaintenanceStatusSummaryControl"/> 
    /// </summary>
    public class MaintenanceStatusSummaryControlRow: Control
    {

        #region Fields

        private readonly Label labelCheck = new Label();
        private readonly Label labelInterval = new Label();
        private readonly Label labelLastCompliance = new Label();
        private readonly Label labelLastComplianceCheck = new Label();
        private readonly Label labelNextCompliance = new Label();

        private const int LEFT_MARGIN = 30;

        private const int LABEL_HEIGHT = 30;
        private const int CHECK_BOX_WIDTH = 20;
        
        #endregion

        #region Constructors

        #region public MaintenanceStatusSummaryControlRow()

        /// <summary>
        /// Создает строку-заголовок <see cref="MaintenanceStatusSummaryControl"/> 
        /// </summary>
        public MaintenanceStatusSummaryControlRow()
        {
            InitializeCommonElements(true);
            SetAppearance(Css.SmallHeader.Fonts.RegularFont, Css.SmallHeader.Colors.ForeColor);

            labelCheck.Text = "Check";
            labelInterval.Text = "Interval";
            labelLastCompliance.Text = "Last Compliance";
            labelNextCompliance.Text = "Next Compliance";
        }

        #endregion

        #region public MaintenanceStatusSummaryControlRow(MaintenanceLimitation limitation)

        /// <summary>
        /// Создает новую строку <see cref="MaintenanceStatusSummaryControl"/> 
        /// </summary>
        public MaintenanceStatusSummaryControlRow(MaintenanceLimitation limitation)
        {
            InitializeCommonElements(false);
            SetAppearance(Css.OrdinaryText.Fonts.RegularFont, Css.OrdinaryText.Colors.ForeColor);
            
            labelCheck.Text = limitation.CheckType.FullName;
            labelInterval.Text = limitation.MaxResource.ToComplianceItemString();
            labelNextCompliance.Text = limitation.Next.ToComplianceItemString();
            MaintenancePerformance lastRecord = limitation.LastPerformance as MaintenancePerformance;
            if (lastRecord != null)
            {
                labelLastCompliance.Text =
                    lastRecord.RecordDate.ToString(new TermsProvider()["DateFormat"].ToString()) +
                    "     " + lastRecord.Lifelength.ToComplianceItemString();
                labelLastComplianceCheck.Text = (lastRecord.CheckTypeExtended == "" ? lastRecord.CheckType.ShortName : lastRecord.CheckTypeExtended) + " check";
            }
        }

        #endregion

        #endregion

        #region Properties

        #region public static new Size DefaultSize

        public static new Size DefaultSize
        {
            get
            {
                return new Size(1240, LABEL_HEIGHT);
            }
        }

        #endregion
                
        #endregion
        
        #region Methods

        #region private void InitializeCommonElements(bool headerRow)

        private void InitializeCommonElements(bool headerRow)
        {
            // 
            // labelCheck
            // 
            labelCheck.Location = new Point(LEFT_MARGIN + CHECK_BOX_WIDTH, 0);
            labelCheck.Size = new Size(120, LABEL_HEIGHT);
            labelCheck.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelInterval
            // 
            labelInterval.Location = new Point(labelCheck.Right, 0);
            labelInterval.Size = new Size(300, LABEL_HEIGHT);
            labelInterval.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelLastCompliance
            // 
            labelLastCompliance.TextAlign = ContentAlignment.MiddleCenter;

            if (headerRow)
            {
                labelLastComplianceCheck.Visible = false;
                labelLastCompliance.Size = new Size(430, LABEL_HEIGHT);
                labelLastCompliance.Location = new Point(labelInterval.Right, 0);
            }
            else
            {
                labelLastComplianceCheck.Location = new Point(labelInterval.Right, 0);
                labelLastComplianceCheck.Size = new Size(100, LABEL_HEIGHT);
                labelLastComplianceCheck.TextAlign = ContentAlignment.MiddleCenter;
                
                labelLastCompliance.Size = new Size(330, LABEL_HEIGHT);
                labelLastCompliance.Location = new Point(labelLastComplianceCheck.Right, 0);

                
            }
            // 
            // labelNextCompliance
            // 
            labelNextCompliance.Location = new Point(labelLastCompliance.Right, 0);
            labelNextCompliance.Size = new Size(400, LABEL_HEIGHT);
            labelNextCompliance.TextAlign = ContentAlignment.MiddleCenter;
            
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Size = new Size(1240, LABEL_HEIGHT);
            Controls.Add(labelCheck);
            Controls.Add(labelInterval);
            Controls.Add(labelLastComplianceCheck);
            Controls.Add(labelLastCompliance);
            Controls.Add(labelNextCompliance);
        }

        #endregion

        #region private void SetAppearance(Font font, Color color)

        private void SetAppearance(Font font, Color color)
        {
            //
            // labelCheck
            //
            labelCheck.Font = font;
            labelCheck.ForeColor = color;
            //
            // labelInterval
            //
            labelInterval.Font = font;
            labelInterval.ForeColor = color;
            //
            // labelLastCompliance
            //
            labelLastCompliance.Font = font;
            labelLastCompliance.ForeColor = color;
            //
            // labelLastComplianceCheck
            //
            labelLastComplianceCheck.Font = font;
            labelLastComplianceCheck.ForeColor = color;
            //
            // labelNext
            //
            labelNextCompliance.Font = font;
            labelNextCompliance.ForeColor = color;
        }

        #endregion
        
        #endregion

    }
}


