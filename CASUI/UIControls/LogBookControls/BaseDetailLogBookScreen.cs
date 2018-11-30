using System;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Management;
using CAS.Core.Core.Interfaces;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.UIControls.AircraftsControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ReferenceControls;
using CASReports.Builders;

namespace CAS.UI.UIControls.LogBookControls
{
/*    /// <summary>
    /// Элемент управления для отображения информации о наработках базовах агрегатов
    /// </summary>
    public partial class BaseDetailLogBookScreen : UserControl
    {

        #region Fields
        /// <summary>
        /// Текущий базовый агрегат
        /// </summary>
        protected BaseDetail currentDetail;
        private readonly HeaderControl headerControl = new HeaderControl();
        private readonly FooterControl footerControl = new FooterControl();
        private readonly AircraftHeaderControl aircraftHeader;
        private readonly RichReferenceContainer logContainer = new RichReferenceContainer();
        private readonly BaseDetailLogBookControl baseDetailLogBookControl;
               

        private readonly Icons icons = new Icons();

        #endregion

        #region Constructors

        #region public BaseDetailLogBookScreen(BaseDetail currentDetail) : this(currentDetail, DateTime.Today.AddMonths(-1), DateTime.Today)

        /// <summary>
        /// Создает элемент управления для отображения информации о наработках базовах агрегатов
        /// </summary>
        /// <param name="currentDetail">Текущая деталь</param>
        public BaseDetailLogBookScreen(BaseDetail currentDetail) : this(currentDetail, currentDetail.InstallationDate < DateTime.Today.AddMonths(-1) ? DateTime.Today.AddMonths(-1) : currentDetail.InstallationDate, DateTime.Today)
        {
            
        }

        #endregion

        #region public BaseDetailLogBookScreen(BaseDetail currentDetail, DateTime startDate, DateTime endDate)

        /// <summary>
        /// Создает элемент управления для отображения информации о наработках базовах агрегатов
        /// </summary>
        /// <param name="currentDetail">Текущий агрегат</param>
        /// <param name="startDate">Дата, с которой следует отображать наработки</param>
        /// <param name="endDate">Дата, по которую следует отображать наработки</param>
        public BaseDetailLogBookScreen(BaseDetail currentDetail, DateTime startDate, DateTime endDate)
        {
            InitializeComponent();
            this.currentDetail = currentDetail;
            baseDetailLogBookControl = new BaseDetailLogBookControl(currentDetail, startDate, endDate);
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Dock = DockStyle.Fill;
            //
            // aircraftHeader 
            //
            aircraftHeader = new AircraftHeaderControl(CurrentAircraft, true);
            aircraftHeader.AircraftClickable = true;
            //aircraftHeader.ReflectionType = ReflectionTypes.DisplayInNew;
            //
            // headerControl
            //
            headerControl.Controls.Add(aircraftHeader);
            headerControl.ContextActionControl.ShowPrintButton = true;
            headerControl.ReloadRised += headerControl_ReloadRised;
            headerControl.ContextActionControl.ButtonPrint.ReflectionType = ReflectionTypes.DisplayInNew;
            headerControl.ContextActionControl.ButtonPrint.DisplayerRequested += PrintButton_DisplayerRequested;
            headerControl.ActionControl.ShowEditButton = false;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "keeping_the_aggregate_running_time_log_book_report";
            //
            // baseDetailLogBookControl
            //
            baseDetailLogBookControl.Dock = DockStyle.Fill;
            //
            // logContainer
            //
            logContainer.Dock = DockStyle.Fill;
            logContainer.tableLayoutPanel.ColumnCount = 2;
            logContainer.tableLayoutPanel.RowCount = 2;
            logContainer.Caption = GetPageName();
            logContainer.UpperLeftIcon = icons.GrayArrow;
            logContainer.tableLayoutPanel.Controls.Add(baseDetailLogBookControl, 3, 3);

            Controls.Add(logContainer);
            Controls.Add(headerControl);
            Controls.Add(footerControl);

            CheckPermission();
        }

        #endregion

        #endregion

        #region Properties

        #region public Aircraft CurrentAircraft

        /// <summary>
        /// Возвращает ВС к которому принадлежит текущий агрегат
        /// </summary>
        public Aircraft CurrentAircraft
        {
            get
            {
                return currentDetail.Parent as Aircraft;
            }
        }

        #endregion

        #region public BaseDetail CurrentDetail

        /// <summary>
        /// Возвращает текущий агрегат
        /// </summary>
        public BaseDetail CurrentDetail
        {
            get
            {
                return currentDetail;
            }
        }

        #endregion
        
        #endregion

        #region Methods

        #region private void headerControl_ReloadRised(object sender, EventArgs e)

        /// <summary>
        /// Метод, обрабатывающий события нажатия кнопки Reload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void headerControl_ReloadRised(object sender, EventArgs e)
        {
            currentDetail.Reload(true);
            baseDetailLogBookControl.UpdateControl();
            UpdateScreen();
        }

        #endregion

        #region private void UpdateScreen()

        /// <summary>
        /// Обновляет информацию на странице
        /// </summary>
        private void UpdateScreen()
        {
            aircraftHeader.Aircraft = currentDetail.Parent as Aircraft;
            CheckPermission();            
        }

        #endregion
        
        #region private void CheckPermission()

        /// <summary>
        /// ПРоверяет права доступа текущего пользователя
        /// </summary>
        private void CheckPermission()
        {
            if (currentDetail.HasPermission(Users.CurrentUser, DataEvent.Update))
            {
                baseDetailLogBookControl.ReadOnly = false;
            }
            else
            {
                baseDetailLogBookControl.ReadOnly = true;
            }
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void PrintButton_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            string reportName;
            TimeSpan hours = TimeSpan.Zero;
            int cycles = 0;
            BaseDetailLogBookReportBuilder reportBuilder = new BaseDetailLogBookReportBuilder(currentDetail);
            LifelengthIncrement[] lifelengthIncrements = baseDetailLogBookControl.DataIntervalControl.LifelengthIncrements;
            Aircraft tempAircraft = currentDetail.Parent as Aircraft;

            // Создаем название отчета и название вкладки
            e.DisplayerText = GetPageName(" Report");
            reportName = GetPageName();
            // Считаем общее количество наработок
            for (int i = 0; i < lifelengthIncrements.Length; i++)
            {
                hours += lifelengthIncrements[i].Lifelength.Hours;
                cycles += lifelengthIncrements[i].Lifelength.Cycles;
            }
            reportBuilder.ReportName = reportName;
            if (tempAircraft != null)
            {
                reportBuilder.CompanyName = tempAircraft.Operator.Name;
                reportBuilder.LogoType = tempAircraft.Operator.LogoTypeWhite;
            }
            reportBuilder.StartDate = baseDetailLogBookControl.DataIntervalControl.StartDate;
            reportBuilder.EndDate = baseDetailLogBookControl.DataIntervalControl.EndDate;
            reportBuilder.Hours = (hours.Days * 24 + hours.Hours) + ":" + hours.Minutes.ToString().PadLeft(2, '0');
            reportBuilder.Cycles = cycles;
            reportBuilder.Days = (new Date(baseDetailLogBookControl.DataIntervalControl.EndDate).ToDateTime() - new Date(baseDetailLogBookControl.DataIntervalControl.StartDate).ToDateTime()).Days + 1;
            e.RequestedEntity = new DispatcheredBaseDetailLogBookReport(lifelengthIncrements, reportBuilder);
        }

        #endregion

        #region private string GetPageName()

        /// <summary>
        /// Создает название вкладки
        /// </summary>
        /// <returns>Название вкладки</returns>
        private string GetPageName()
        {
            return GetPageName("");
        }

        #endregion

        #region private string GetPageName(string additionalString)

        /// <summary>
        /// Создает название вкладки
        /// </summary>
        /// <param name="additionalString">Дополнительная строка</param>
        /// <returns>Название вкладки</returns>
        private string GetPageName(string additionalString)
        {
            return currentDetail.ToString() + ". Log Book" + additionalString;
        }

        #endregion

        #endregion

    }*/
}