using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.ComponentChangeControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DiscrepanciesControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.EngineeringOrdersDirectives;
using CASReports.Builders;
using Controls;

namespace CAS.UI.UIControls.DetailsControls
{

    /// <summary>
    /// Элемент управления для отображения ссылок на отчеты базового агрегата
    /// </summary>
    public class BaseDetailLinksFlowLayoutPanel : FlowLayoutPanel
    {

        #region Fields

        private readonly BaseDetail baseDetail;
        private readonly ReferenceStatusImageLinkLabel linkADStatus = new ReferenceStatusImageLinkLabel();
        private readonly ReferenceStatusImageLinkLabel linkDiscrepancies = new ReferenceStatusImageLinkLabel();
        private readonly ReferenceStatusImageLinkLabel linkEngineeringOrders = new ReferenceStatusImageLinkLabel();
        private readonly ReferenceStatusImageLinkLabel linkSBStatus = new ReferenceStatusImageLinkLabel();
        private readonly ReferenceStatusImageLinkLabel linkLLPDiskSheetStatus = new ReferenceStatusImageLinkLabel();

        private readonly DirectiveTypeCollection directiveTypeCollection = DirectiveTypeCollection.Instance;
        private readonly Padding IMAGE_LINK_LABEL_MARGIN = new Padding(5);
        private readonly Padding ITEM_PADDING = new Padding(1);

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения ссылок на отчеты базового агрегата
        /// </summary>
        public BaseDetailLinksFlowLayoutPanel(BaseDetail baseDetail)
        {
            this.baseDetail = baseDetail;
            //
            // linkADStatus
            //
            linkADStatus.Text = "AD Status";
            linkADStatus.Margin = IMAGE_LINK_LABEL_MARGIN;
            linkADStatus.Enabled = true;
            linkADStatus.Margin = ITEM_PADDING;
            linkADStatus.ReflectionType = ReflectionTypes.DisplayInNew;
            linkADStatus.DisplayerRequested += linkADStatus_DisplayerRequested;
            Css.ImageLink.Adjust(linkADStatus);
            //
            // linkDiscrepancies
            //
            linkDiscrepancies.Text = "Discrepancies";
            linkDiscrepancies.Margin = IMAGE_LINK_LABEL_MARGIN;
            linkDiscrepancies.Enabled = true;
            linkDiscrepancies.Margin = ITEM_PADDING;
            Css.ImageLink.Adjust(linkDiscrepancies);
            linkDiscrepancies.ReflectionType = ReflectionTypes.DisplayInNew;
            linkDiscrepancies.DisplayerRequested += linkDiscrepancies_DisplayerRequested;
            //
            // linkEngineeringOrders
            //
            linkEngineeringOrders.Text = "Engineering Orders";
            linkEngineeringOrders.Margin = IMAGE_LINK_LABEL_MARGIN;
            linkEngineeringOrders.Enabled = true;
            linkEngineeringOrders.Margin = ITEM_PADDING;
            linkEngineeringOrders.ReflectionType = ReflectionTypes.DisplayInNew;
            linkEngineeringOrders.DisplayerRequested += linkEngineeringOrders_DisplayerRequested;
            Css.ImageLink.Adjust(linkEngineeringOrders);
            //
            // linkLLPDiskSheetStatus
            //
            linkLLPDiskSheetStatus.Text = "LLP Disk Sheet Status";
            linkLLPDiskSheetStatus.Margin = IMAGE_LINK_LABEL_MARGIN;
            linkLLPDiskSheetStatus.Enabled = true;
            linkLLPDiskSheetStatus.Margin = ITEM_PADDING;
            linkLLPDiskSheetStatus.ReflectionType = ReflectionTypes.DisplayInNew;
            linkLLPDiskSheetStatus.DisplayerRequested += linkLLPDiskSheetStatus_DisplayerRequested;
            Css.ImageLink.Adjust(linkLLPDiskSheetStatus);
            //
            // linkSBStatus
            //
            linkSBStatus.Text = "SB Status";
            linkSBStatus.Margin = IMAGE_LINK_LABEL_MARGIN;
            linkSBStatus.Enabled = true;
            linkSBStatus.Margin = ITEM_PADDING;
            linkSBStatus.DisplayerRequested += linkSBStatus_DisplayerRequested;
            Css.ImageLink.Adjust(linkSBStatus);
            
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Size = new Size(500, 100);
            Controls.Add(linkADStatus);
            Controls.Add(linkEngineeringOrders);
            Controls.Add(linkDiscrepancies);
            if (baseDetail != null && baseDetail.DetailType.ID == (int)DetailTypesIds.Engine)
                Controls.Add(linkLLPDiskSheetStatus);
            Controls.Add(linkSBStatus);
        }

        #endregion

        #region Methods

        #region public void UpdateInformation()

        /// <summary>
        /// Обновляет информацию
        /// </summary>
        public void UpdateInformation()
        {
            BaseDetailDirective[] directives;
            directives = baseDetail.ContainedDirectives;
            List<BaseDetailDirective> ADDirectives = new List<BaseDetailDirective>();
            List<BaseDetailDirective> engineeringOrdersDirectives = new List<BaseDetailDirective>();
            List<BaseDetailDirective> SBStatusDirectives = new List<BaseDetailDirective>();
            for (int i = 0; i < directives.Length; i++)
            {
                switch (directives[i].DirectiveType.ID)
                {
                    case (int)DirectiveTypeID.ADDirectiveTypeID:
                        ADDirectives.Add(directives[i]);
                        break;
                    case (int)DirectiveTypeID.EngeneeringOrdersDirectiveTypeID:
                        engineeringOrdersDirectives.Add(directives[i]);
                        break;
                    case (int)DirectiveTypeID.SBDirectiveTypeID:
                        SBStatusDirectives.Add(directives[i]);
                        break;
                }
            }
            linkADStatus.Status = GetStatus(ADDirectives);
            linkDiscrepancies.Status = (Statuses)baseDetail.ConditionState;
            linkEngineeringOrders.Status = GetStatus(engineeringOrdersDirectives);
            DetailCollectionFilter filter = new DetailCollectionFilter(baseDetail.ContainedDetails, new DetailFilter[] { new LLPFilter() });
            linkLLPDiskSheetStatus.Status = GetStatus(filter.GatherDetails());
            linkSBStatus.Status = GetStatus(SBStatusDirectives);
        }

        #endregion

        #region private Statuses GetStatus(List<BaseDetailDirective> directives)

        private Statuses GetStatus(List<BaseDetailDirective> directives)
        {
            Statuses status = Statuses.Satisfactory;
            for (int i = 0; i < directives.Count; i++)
            {
                if (directives[i].Condition == DirectiveConditionState.NotSatisfactory)
                    status = Statuses.NotSatisfactory;
                if ((directives[i].Condition == DirectiveConditionState.Notify) && (status == Statuses.Satisfactory))
                    status = Statuses.Notify;
            }
            return status;
        }

        #endregion

        #region private Statuses GetStatus(Detail[] details)

        private Statuses GetStatus(Detail[] details)
        {

            Statuses status = Statuses.Satisfactory;
            for (int i = 0; i < details.Length; i++)
            {
                if (details[i].ConditionState == DirectiveConditionState.NotSatisfactory)
                    status = Statuses.NotSatisfactory;
                if ((details[i].ConditionState == DirectiveConditionState.Notify) && (status == Statuses.Satisfactory))
                    status = Statuses.Notify;
            }
            return status; 
        }

        #endregion

        #region private void linkADStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkADStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            OnADStatusLinkDisplayRequested(e);
        }

        #endregion

        #region private void linkDiscrepancies_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkDiscrepancies_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            OnDiscrepanciesLinkDisplayRequested(e);
        }

        #endregion

        #region private void linkEngineeringOrders_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkEngineeringOrders_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            OnEngineeringOrdersLinkDisplayRequested(e);
        }

        #endregion

        #region private void linkLLPDiskSheetStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkLLPDiskSheetStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            OnLLPDiskSheetStatusLinkDisplayRequested(e);
        }

        #endregion

        #region private void linkSBStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkSBStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            OnSBStatusLinkDisplayRequested(e);
        }

        #endregion

        #region public void OnADStatusLinkDisplayRequested(ReferenceEventArgs e)

        /// <summary>
        /// Метод, обрабатывающий событие нажатия ссылки AD Status 
        /// </summary>
        /// <param name="e"></param>
        public void OnADStatusLinkDisplayRequested(ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            if (baseDetail is AircraftFrame)
            {
                e.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". " + directiveTypeCollection.ADDirectiveType.CommonName;
                e.RequestedEntity = new DispatcheredADStatusView(baseDetail.ParentAircraft);
            }
            else
            {
                e.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". " + baseDetail + ". " + directiveTypeCollection.ADDirectiveType.CommonName;
                e.RequestedEntity = new DispatcheredADStatusView(baseDetail);
            }
        }

        #endregion

        #region public void OnDiscrepanciesLinkDisplayRequested(ReferenceEventArgs e)

        /// <summary>
        /// Метод, обрабатывающий событие нажатия ссылки Discrepancies
        /// </summary>
        /// <param name="e"></param>
        public void OnDiscrepanciesLinkDisplayRequested(ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            if (baseDetail is AircraftFrame)
                e.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". Aircraft Frame SN " + baseDetail.SerialNumber + ". Discrepancies";
            else
                e.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". " + baseDetail + ". Discrepancies";
            e.RequestedEntity = new DispatcheredDiscrepanciesScreen(baseDetail);
        }

        #endregion

        #region public void OnEnginereengOrdersLinkDisplayRequested(ReferenceEventArgs e)

        /// <summary>
        /// Метод, обрабатывающий событие нажатия ссылки Engineering Orders
        /// </summary>
        /// <param name="e"></param>
        public void OnEngineeringOrdersLinkDisplayRequested(ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            if (baseDetail is AircraftFrame)
                e.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". " + directiveTypeCollection.EngineeringOrdersDirectiveType.CommonName;
            else
                e.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". " + baseDetail + ". " + directiveTypeCollection.EngineeringOrdersDirectiveType.CommonName;
            e.RequestedEntity = new DispatcheredEngeneeringOrdersDirectiveListScreen(baseDetail);//, new DirectiveCollectionFilter(baseDetail.ContainedDirectives, new DirectiveFilter[1] { new EngeneeringOrderFilter() }));
        }

        #endregion

        #region public void OnLLPDiskSheetStatusLinkDisplayRequested(ReferenceEventArgs e)

        /// <summary>
        /// Метод, обрабатывающий событие нажатия ссылки LLP Disk Sheet Status
        /// </summary>
        /// <param name="e"></param>
        public void OnLLPDiskSheetStatusLinkDisplayRequested(ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". " + baseDetail + ". LLP Disk Sheet Status";
            DetailCollectionFilter filter = new DetailCollectionFilter(new DetailFilter[] { new EngineLLPFilter(baseDetail) });
            LLPStatusReportBuilder reportBuilder = new LLPStatusReportBuilder((Engine)baseDetail);

            DispatcheredComponentStatusScreen dispatcheredComponentStatusScreen = new DispatcheredComponentStatusScreen(baseDetail, filter, reportBuilder);
            dispatcheredComponentStatusScreen.StatusText = baseDetail + ". LLP Disk Sheet Status";
            dispatcheredComponentStatusScreen.Status = Statuses.Satisfactory;//(Statuses)baseDetail.LimitationCondition;todo
            e.RequestedEntity = dispatcheredComponentStatusScreen;
        }

        #endregion

        #region public void OnSBStatusLinkDisplayRequested(ReferenceEventArgs e)

        /// <summary>
        /// Метод, обрабатывающий событие нажатия ссылки SB Status
        /// </summary>
        /// <param name="e"></param>
        public void OnSBStatusLinkDisplayRequested(ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            if (baseDetail is AircraftFrame)
            {
                e.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". " + directiveTypeCollection.SBDirectiveType.CommonName;
                e.RequestedEntity = new DispatcheredSBStatusView(baseDetail.ParentAircraft);
            }
            else
            {
                e.DisplayerText = baseDetail.ParentAircraft.RegistrationNumber + ". " + baseDetail + ". " + directiveTypeCollection.SBDirectiveType.CommonName;
                e.RequestedEntity = new DispatcheredSBStatusView(baseDetail);
            }
        }

        #endregion

        #region public void SetEnabled(bool enabled)

        /// <summary>
        /// Задает свойство Enabled ссылкам
        /// </summary>
        /// <param name="enabled"></param>
        public void SetEnabled(bool enabled)
        {
            linkADStatus.Enabled = enabled;
            linkDiscrepancies.Enabled = enabled;
            linkEngineeringOrders.Enabled = enabled;
            linkLLPDiskSheetStatus.Enabled = enabled;
            linkSBStatus.Enabled = enabled;
        }

        #endregion

        #endregion

    }
}
