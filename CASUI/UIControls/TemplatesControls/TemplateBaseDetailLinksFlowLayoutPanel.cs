using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.ReportFilters.Templates;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.TemplatesControls;

namespace CAS.UI.UIControls.TemplatesControls
{
    /// <summary>
    /// Элемент управления для отображения ссылок на отчеты базового агрегата
    /// </summary>
    public class TemplateBaseDetailLinksFlowLayoutPanel : FlowLayoutPanel
    {

        #region Fields

        private readonly TemplateBaseDetail currentBaseDetail;
        private readonly ReferenceStatusImageLinkLabel linkADStatus = new ReferenceStatusImageLinkLabel();
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
        public TemplateBaseDetailLinksFlowLayoutPanel(TemplateBaseDetail baseDetail)
        {
            currentBaseDetail = baseDetail;
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
            if (baseDetail != null && baseDetail.DetailType.ID == (int)DetailTypesIds.Engine)
                Controls.Add(linkLLPDiskSheetStatus);
            Controls.Add(linkSBStatus);
        }

        #endregion

        #region Methods

        #region public void UpdateInformation()
/*

        /// <summary>
        /// Обновляет информацию
        /// </summary>
        public void UpdateInformation()
        {
            BaseDetailDirective[] directives;
            directives = currentBaseDetail.ContainedDirectives;
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
            linkDiscrepancies.Status = (Statuses)currentBaseDetail.Condition;
            linkEngineeringOrders.Status = GetStatus(engineeringOrdersDirectives);
            DetailCollectionFilter filter = new DetailCollectionFilter(currentBaseDetail.ContainedDetails, new DetailFilter[] { new LLPFilter() });
            linkLLPDiskSheetStatus.Status = GetStatus(filter.GatherDetails());
            linkSBStatus.Status = GetStatus(SBStatusDirectives);
        }
*/

        #endregion

        #region private Statuses GetStatus(List<BaseDetailDirective> directives)

/*        private Statuses GetStatus(List<BaseDetailDirective> directives)
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
        }*/

        #endregion

        #region private Statuses GetStatus(Detail[] details)

/*        private Statuses GetStatus(Detail[] details)
        {
            Statuses status = Statuses.Satisfactory;
            for (int i = 0; i < details.Length; i++)
            {
                if (details[i].LimitationCondition == DirectiveConditionState.NotSatisfactory)
                    status = Statuses.NotSatisfactory;
                if ((details[i].LimitationCondition == DirectiveConditionState.Notify) && (status == Statuses.Satisfactory))
                    status = Statuses.Notify;
            }
            return status;
        }*/

        #endregion

        #region private void linkADStatus_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkADStatus_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            OnADStatusLinkDisplayRequested(e);
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
            if (currentBaseDetail is TemplateAircraftFrame)
            {
                e.DisplayerText = currentBaseDetail.ParentAircraft.Model + ". " + directiveTypeCollection.ADDirectiveType.CommonName;
                e.RequestedEntity = new DispatcheredTemplateADDirectiveListScreen(currentBaseDetail.ParentAircraft);
            }
            else
            {
                e.DisplayerText = currentBaseDetail.ParentAircraft.Model + ". " + currentBaseDetail + ". " + directiveTypeCollection.ADDirectiveType.CommonName;
                e.RequestedEntity = new DispatcheredTemplateADDirectiveListScreen(currentBaseDetail);
            }
        }

        #endregion

        #region public void OnLLPDiskSheetStatusLinkDisplayRequested(ReferenceEventArgs e)

        /// <summary>
        /// Метод, обрабатывающий событие нажатия ссылки LLP Disk Sheet Status
        /// </summary>
        /// <param name="e"></param>
        public void OnLLPDiskSheetStatusLinkDisplayRequested(ReferenceEventArgs e)
        {
/*
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = currentBaseDetail.ParentAircraft.RegistrationNumber + ". " + currentBaseDetail + ". LLP Disk Sheet Status";
            DetailCollectionFilter filter = new DetailCollectionFilter(new DetailFilter[] { new EngineLLPFilter(currentBaseDetail) });
            LLPStatusReportBuilder reportBuilder = new LLPStatusReportBuilder((Engine)currentBaseDetail);

            DispatcheredComponentStatusScreen dispatcheredComponentStatusScreen = new DispatcheredComponentStatusScreen(currentBaseDetail, filter, reportBuilder);
            dispatcheredComponentStatusScreen.StatusText = currentBaseDetail + ". LLP Disk Sheet Status";
            dispatcheredComponentStatusScreen.Status = (Statuses)currentBaseDetail.LimitationCondition;
            e.RequestedEntity = dispatcheredComponentStatusScreen;

*/

            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = currentBaseDetail.ParentAircraft.Model + ". " + currentBaseDetail + ". LLP Disk Sheet Status";
            TemplateDetailCollectionFilter filter = new TemplateDetailCollectionFilter(new TemplateDetailFilter[] { new TemplateEngineLLPFilter(currentBaseDetail) });
            DispatcheredTemplateDetailListScreen dispatcheredComponentStatusControl = new DispatcheredTemplateDetailListScreen(currentBaseDetail, filter);
            e.RequestedEntity = dispatcheredComponentStatusControl;

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
            if (currentBaseDetail is TemplateAircraftFrame)
            {
                e.DisplayerText = currentBaseDetail.ParentAircraft.Model + ". " + directiveTypeCollection.SBDirectiveType.CommonName;
                e.RequestedEntity = new DispatcheredTemplateSBDirectiveListScreen(currentBaseDetail.ParentAircraft);
            }
            else
            {
                e.DisplayerText = currentBaseDetail.ParentAircraft.Model + ". " + currentBaseDetail + ". " + directiveTypeCollection.SBDirectiveType.CommonName;
                e.RequestedEntity = new DispatcheredTemplateSBDirectiveListScreen(currentBaseDetail);
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
            linkLLPDiskSheetStatus.Enabled = enabled;
            linkSBStatus.Enabled = enabled;
        }

        #endregion

        #endregion

    }
}