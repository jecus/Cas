using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.MaintenanceStatusControls;
using CAS.UI.UIControls.DetailsControls;

namespace CAS.UI.UIControls.MaintenanceStatusControls
{
    /// <summary>
    /// Элемент управления для задания ограничений <see cref="MaintenanceDirective"/>
    /// </summary>
    public class MaintenanceStatusLimitationsControl : UserControl
    {
        #region Fields

        private readonly MaintenanceDirective directive;
        private readonly InfoViewer infoViewerMaxResource;
        private readonly InfoViewer infoViewerNotification;
        private readonly List<CheckBox> checkBoxs = new List<CheckBox>();
        private readonly ReferenceLinkLabel linkEditSubChecks = new ReferenceLinkLabel();
        private const int WIDTH_INTERVAL = 140;
        private readonly Size checkBoxSize = new Size(130, 36);
        //private const int CHECKS_COUNT = 4;
        private const int LEFT_MARGIN = 10;
        private const int LEFT_MARGIN_FOR_LINK = 25;
        private const int HEIGHT_INTERVAL = 10;
        private const int TOP_MARGIN = 60;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для задания ограничений <see cref="MaintenanceDirective"/>
        /// </summary>
        /// <param name="directive">Директива</param>
        public MaintenanceStatusLimitationsControl(MaintenanceDirective directive)
        {
            this.directive = directive;
            infoViewerMaxResource = new InfoViewer(directive.Limitations.Length);
            infoViewerNotification = new InfoViewer(directive.Limitations.Length);
            for (int i = 0; i < directive.Limitations.Length; i++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Font = Css.OrdinaryText.Fonts.RegularFont;
                checkBox.ForeColor = Css.OrdinaryText.Colors.ForeColor;
                checkBox.Location = new Point(LEFT_MARGIN, TOP_MARGIN + i * checkBoxSize.Height);
                checkBox.Size = checkBoxSize;
                checkBox.CheckedChanged += MaintenanceStatusLimitationsControl_CheckedChanged;
                checkBoxs.Add(checkBox);
            }
            //
            // infoViewerMaxResource
            //
            infoViewerMaxResource.Location = new Point(LEFT_MARGIN + checkBoxSize.Width, 0);
            infoViewerMaxResource.LifeLengthViewers[0].ShowHeaders = true;
            infoViewerMaxResource.LeftHeaderWidth = 0;
            infoViewerMaxResource.LabelTitle.Text = "Maintenance Intervals";
            infoViewerMaxResource.FirstLifelengthViewerLostFocusByShiftTabClicked = true;
            infoViewerMaxResource.ShowMinutes = false;
            infoViewerMaxResource.LastLifelengthViewerTabClicked += maxResourcesInfo_LastLifelengthViewerTabClicked;
            infoViewerMaxResource.FirstLifelengthViewerShiftTabClicked += maxResourcesInfo_FirstLifelengthViewerShiftTabClicked;
            //
            // infoViewerNotification
            //
            infoViewerNotification.Location = new Point(infoViewerMaxResource.Right + WIDTH_INTERVAL, 0);
            infoViewerNotification.LifeLengthViewers[0].ShowHeaders = true;
            infoViewerNotification.LeftHeaderWidth = 0;
            infoViewerNotification.LabelTitle.Text = "Notification";
            infoViewerNotification.LastLifelengthViewerLostFocusByTabClicked = true;
            infoViewerNotification.ShowMinutes = false;
            infoViewerNotification.LastLifelengthViewerTabClicked += notifyWhenRemainsInfo_LastLifelengthViewerTabClicked;
            infoViewerNotification.FirstLifelengthViewerShiftTabClicked += notifyWhenRemainsInfo_FirstLifelengthViewerShiftTabClicked;
            //
            // linkEditSubChecks
            //
            linkEditSubChecks.AutoSize = true;
            Css.SimpleLink.Adjust(linkEditSubChecks);
            linkEditSubChecks.Text = "Edit Subchecks";
            linkEditSubChecks.Location = new Point(LEFT_MARGIN_FOR_LINK, infoViewerMaxResource.Bottom + HEIGHT_INTERVAL);
            linkEditSubChecks.DisplayerRequested += linkEditSubChecks_DisplayerRequested;

            BackColor = Css.CommonAppearance.Colors.BackColor;
            AutoSize = true;
            Controls.AddRange(checkBoxs.ToArray());
            Controls.Add(infoViewerMaxResource);
            Controls.Add(infoViewerNotification);
            Controls.Add(linkEditSubChecks);
        }

        #endregion

        #region Properties

        #region public bool ReadOnly

        /// <summary>
        /// Задается параметр только для чтения
        /// </summary>
        public bool ReadOnly
        {
            set
            {
                infoViewerNotification.ReadOnly = value;
                infoViewerMaxResource.ReadOnly = value;
            }
        }

        #endregion

        #region public InfoViewer InfoViewerMaxResource

        /// <summary>
        /// Отображает информацию по MaxResource
        /// </summary>
        public InfoViewer InfoViewerMaxResource
        {
            get { return infoViewerMaxResource; }
        }

        #endregion
        
        #region public InfoViewer InfoViewerNotification

        /// <summary>
        /// Отображает информацию по Notification
        /// </summary>
        public InfoViewer InfoViewerNotification
        {
            get { return infoViewerNotification; }
        }

        #endregion

        #endregion

        #region Methods

        #region public void DisplayLimitations()

        /// <summary>
        /// Происходит отображение данных об ограничениях
        /// </summary>
        public void DisplayLimitations()
        {
            infoViewerMaxResource.SetVisibleItemsAmount(directive.Limitations.Length);
            infoViewerNotification.SetVisibleItemsAmount(directive.Limitations.Length);
            for (int i = 0; i < directive.Limitations.Length; i++)
            {
                MaintenanceLimitation limitation = directive.Limitations[i];
                infoViewerMaxResource.SetValue(i, limitation.SinceLastPerformanceLimitation);
                infoViewerNotification.SetValue(i, limitation.Notification);
                checkBoxs[i].Text = limitation.CheckType.FullName;
                checkBoxs[i].Checked = limitation.IsInuse;
            }

        }

        #endregion

        #region public void SaveData(MaintenanceLimitation[] limitations)

        /// <summary>
        /// Сохранение отображаемых данных
        /// </summary>
        /// <param name="limitations"></param>
        public void SaveData(MaintenanceLimitation[] limitations)
        {
            for (int i = 0; i < limitations.Length; i++)
            {
                infoViewerMaxResource.SaveData(i, limitations[i].SinceLastPerformanceLimitation);
                infoViewerNotification.SaveData(i, limitations[i].Notification);
                limitations[i].IsInuse = checkBoxs[i].Checked;
            }
        }

        #endregion

        #region private void maxResourcesInfo_LastLifelengthViewerTabClicked(int position)

        private void maxResourcesInfo_LastLifelengthViewerTabClicked(int position)
        {
            infoViewerNotification.FocusFirstElement(position);
        }

        #endregion

        #region private void maxResourcesInfo_FirstLifelengthViewerShiftTabClicked(int position)

        private void maxResourcesInfo_FirstLifelengthViewerShiftTabClicked(int position)
        {
            if (position > 0)
                infoViewerNotification.FocusLastElement(--position);   
        }

        #endregion

        #region private void notifyWhenRemainsInfo_LastLifelengthViewerTabClicked(int position)

        private void notifyWhenRemainsInfo_LastLifelengthViewerTabClicked(int position)
        {
            infoViewerMaxResource.FocusFirstElement(++position);
        }

        #endregion

        #region private void notifyWhenRemainsInfo_FirstLifelengthViewerShiftTabClicked(int position)

        private void notifyWhenRemainsInfo_FirstLifelengthViewerShiftTabClicked(int position)
        {
            infoViewerMaxResource.FocusLastElement(position);
        }

        #endregion

        #region private void MaintenanceStatusLimitationsControl_CheckedChanged(object sender, EventArgs e)

        private void MaintenanceStatusLimitationsControl_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox) sender;
            infoViewerMaxResource.LifeLengthViewers[checkBoxs.IndexOf(checkBox)].Enabled = checkBox.Checked;
            infoViewerNotification.LifeLengthViewers[checkBoxs.IndexOf(checkBox)].Enabled = checkBox.Checked;
        }

        #endregion

        #region private void linkEditSubChecks_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkEditSubChecks_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = (Aircraft)directive.Parent + ". Maintenance Status. Checks";
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.RequestedEntity = new DispatcheredSubChecksCollectionScreen(directive);
        }

        #endregion

        #endregion
    }
}
