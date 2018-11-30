using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Directives;
using CAS.Core.Types.Directives.Templates;
using CAS.UI.Appearance;
using CAS.UI.UIControls.DetailsControls;

namespace CAS.UI.UIControls.TemplatesControls
{
    /// <summary>
    /// Элемент управления для задания ограничений <see cref="TemplateMaintenanceDirective"/>
    /// </summary>
    public class TemplateMaintenanceLimitationsControl : UserControl
    {
        
        #region Fields

        private readonly TemplateMaintenanceDirective currentMaintenanceDirective;
        private readonly InfoViewer infoViewerMaxResource;
        private readonly InfoViewer infoViewerNotification;
        private readonly List<CheckBox> checkBoxs = new List<CheckBox>();
        private const int WIDTH_INTERVAL = 140;
        private readonly Size checkBoxSize = new Size(130, 36);
        //private const int CHECKS_COUNT = 4;
        private const int LEFT_MARGIN = 10;
        private const int TOP_MARGIN = 60;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для задания ограничений <see cref="TemplateMaintenanceDirective"/>
        /// </summary>
        /// <param name="currentMaintenanceDirective">Maintenance Directive</param>
        public TemplateMaintenanceLimitationsControl(TemplateMaintenanceDirective currentMaintenanceDirective)
        {
            this.currentMaintenanceDirective = currentMaintenanceDirective;
            infoViewerMaxResource = new InfoViewer(currentMaintenanceDirective.Limitations.Length);
            infoViewerNotification = new InfoViewer(currentMaintenanceDirective.Limitations.Length);
            for (int i = 0; i < currentMaintenanceDirective.Limitations.Length; i++ )
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
            infoViewerMaxResource.ShowMinutes = false;
            infoViewerMaxResource.LeftHeaderWidth = 0;
            infoViewerMaxResource.LabelTitle.Text = "Maintenance Intervals";
            infoViewerMaxResource.FirstLifelengthViewerLostFocusByShiftTabClicked = true;
            infoViewerMaxResource.LastLifelengthViewerTabClicked += maxResourcesInfo_LastLifelengthViewerTabClicked;
            infoViewerMaxResource.FirstLifelengthViewerShiftTabClicked += maxResourcesInfo_FirstLifelengthViewerShiftTabClicked;
            //
            // infoViewerNotification
            //
            infoViewerNotification.Location = new Point(infoViewerMaxResource.Right + WIDTH_INTERVAL, 0);
            infoViewerNotification.LifeLengthViewers[0].ShowHeaders = true;
            infoViewerNotification.ShowMinutes = false;
            infoViewerNotification.LeftHeaderWidth = 0;
            infoViewerNotification.LabelTitle.Text = "Notification";
            infoViewerNotification.LastLifelengthViewerLostFocusByTabClicked = true;
            infoViewerNotification.LastLifelengthViewerTabClicked += notifyWhenRemainsInfo_LastLifelengthViewerTabClicked;
            infoViewerNotification.FirstLifelengthViewerShiftTabClicked += notifyWhenRemainsInfo_FirstLifelengthViewerShiftTabClicked;

            BackColor = Css.CommonAppearance.Colors.BackColor;
            AutoSize = true;
            Controls.AddRange(checkBoxs.ToArray());
            Controls.Add(infoViewerMaxResource);
            Controls.Add(infoViewerNotification);
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

        #region public void UpdateInformation()

        /// <summary>
        /// Происходит отображение данных об ограничениях
        /// </summary>
        public void UpdateInformation()
        {
            infoViewerMaxResource.SetVisibleItemsAmount(currentMaintenanceDirective.Limitations.Length);
            infoViewerNotification.SetVisibleItemsAmount(currentMaintenanceDirective.Limitations.Length);
            for (int i = 0; i < currentMaintenanceDirective.Limitations.Length; i++)
            {
                TemplateMaintenanceLimitation limitation = currentMaintenanceDirective.Limitations[i];
                infoViewerMaxResource.SetValue(i, limitation.MaxResources);
                infoViewerNotification.SetValue(i, limitation.Notification);
                checkBoxs[i].Text = limitation.CheckType.FullName;
                checkBoxs[i].Checked = limitation.IsInuse;
            }
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохранение отображаемых данных
        /// </summary>
        public void SaveData()
        {
            for (int i = 0; i < currentMaintenanceDirective.Limitations.Length; i++)
            {
                infoViewerMaxResource.SaveData(i, currentMaintenanceDirective.Limitations[i].MaxResources);
                infoViewerNotification.SaveData(i, currentMaintenanceDirective.Limitations[i].Notification);
                currentMaintenanceDirective.Limitations[i].IsInuse = checkBoxs[i].Checked;
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
            if (position < currentMaintenanceDirective.Limitations.Length)
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

        #endregion
    }
}