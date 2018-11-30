using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.DetailsControls
{

    ///<summary>
    /// Элемент управления, использующийся для задания информации Compliance/Performance при добавлении агрегата
    ///</summary>
    public class DetailCompliancePerformanceListControl : UserControl
    {
        
        #region Fields

        private readonly AbstractDetail currentDetail;
        private readonly Aircraft currentAircraft;
        private FlowLayoutPanel flowLayoutPanelPerformances;
        private List<DetailAddCompliancePerformanceControl> addedPerformances;
        private List<DetailCompliancePerformanceControl> existPrformances;
        private LinkLabel linkLabelAddNew;

        private const int FLOW_LAYOUT_PANEL_WIDTH = 1200;
        
        #endregion

        #region Constructor

        #region public DetailCompliancePerformanceControl()

        /// <summary>
        /// Создает элемент управления, использующийся для задания информации Compliance/Performance при добавлении агрегата
        /// </summary>
        public DetailCompliancePerformanceListControl(Aircraft aircraft)
        {
            currentAircraft = aircraft;
            InitializeComponent();
            ClearFields();
        }

        #endregion

        #region public DetailCompliancePerformanceListControl(AbstractDetail currentDetail)

        /// <summary>
        /// Создает элемент управления, использующийся для редактирования Compliance/Performance
        /// </summary>
        public DetailCompliancePerformanceListControl(AbstractDetail detail)
        {
            currentDetail = detail;
            if (detail is BaseDetail)
                currentAircraft = ((BaseDetail)detail).ParentAircraft;
            else
                currentAircraft = (Aircraft)detail.Parent.Parent;
            InitializeComponent();
            UpdateInformation();
        }

        #endregion

        #endregion

        #region Propeties
/*
        #region public string MPDItem

        /// <summary>
        /// MPD Item создаваемого агрегата
        /// </summary>
        public string MPDItem
        {
            get { return textBoxMPDItem.Text; }
            set
            {
                textBoxMPDItem.Text = value;
            }
        }

        #endregion

        #region public ATAChapter ATAChapter

        /// <summary>
        /// ATA глава создаваемого агрегата
        /// </summary>
        public ATAChapter ATAChapter
        {
            get
            {
                return comboBoxAtaChapter.ATAChapter;
            }
            set
            {
                comboBoxAtaChapter.ATAChapter = value;
            }
        }

        #endregion

        #region public string PartNumber

        /// <summary>
        /// Партийный номер создаваемого агрегата
        /// </summary>
        public string PartNumber
        {
            get { return textBoxPartNo.Text; }
            set
            {
                textBoxPartNo.Text = value;
            }
        }

        #endregion

        #region public string SerialNumber

        /// <summary>
        /// Серийный номер создаваемого агрегата
        /// </summary>
        public string SerialNumber
        {
            get { return textBoxSerialNo.Text; }
            set
            {
                textBoxSerialNo.Text = value;
            }
        }

        #endregion

        #region public string Description

        /// <summary>
        /// Описание создаваемого агрегата
        /// </summary>
        public string Description
        {
            get { return textBoxDescription.Text; }
            set
            {
                textBoxDescription.Text = value;
            }
        }

        #endregion

        #region public string Remarks

        /// <summary>
        /// Замечания к создаваемому агрегату
        /// </summary>
        public string Remarks
        {
            get { return textBoxRemarks.Text; }
            set
            {
                textBoxRemarks.Text = value;
            }
        }

        #endregion*/

        #endregion

        #region Methods

        #region private void InitializeComponent()

        /// <summary>
        /// Инициализирует элементы управления
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanelPerformances = new FlowLayoutPanel();
            addedPerformances = new List<DetailAddCompliancePerformanceControl>();
            existPrformances = new List<DetailCompliancePerformanceControl>();
            linkLabelAddNew = new LinkLabel();
            //
            // linkLabelAddNew
            //
            linkLabelAddNew.Font = Css.SimpleLink.Fonts.Font;
            linkLabelAddNew.LinkColor = Css.SimpleLink.Colors.LinkColor;
            linkLabelAddNew.Text = "Add new";
            linkLabelAddNew.LinkClicked += linkLabelAddNew_LinkClicked;
            //
            // flowLayoutPanelPerformances
            //
            flowLayoutPanelPerformances.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelPerformances.MinimumSize = new Size(FLOW_LAYOUT_PANEL_WIDTH, 0);
            flowLayoutPanelPerformances.MaximumSize = new Size(FLOW_LAYOUT_PANEL_WIDTH, 10000);
            flowLayoutPanelPerformances.AutoSize = true;
            flowLayoutPanelPerformances.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            
            // 
            // DetailGeneralInformationControl
            //
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(flowLayoutPanelPerformances);

        }


        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Обновляет данные
        /// </summary>
        public void UpdateInformation()
        {
            flowLayoutPanelPerformances.Controls.Clear();
            existPrformances.Clear();
            addedPerformances.Clear();
            List<DetailDirective> detailDirectives = new List<DetailDirective>(currentDetail.GetDetailDirectives());
            for (int i = 0; i < detailDirectives.Count; i++)
            {
                DetailCompliancePerformanceControl compliancePerformanceControl = new DetailCompliancePerformanceControl(detailDirectives[i]);
                compliancePerformanceControl.Deleted += compliancePerformanceControl_Deleted;
                existPrformances.Add(compliancePerformanceControl);
                flowLayoutPanelPerformances.Controls.Add(compliancePerformanceControl);
            }
            if (currentDetail != null && currentDetail.InUse)
                flowLayoutPanelPerformances.Controls.Add(linkLabelAddNew);
        }

        #endregion

        #region public bool SaveData()

        /// <summary>
        /// Сохраняет данные
        /// </summary>
        /// <returns></returns>
        public bool SaveData()
        {
            return SaveData(currentDetail);
        }

        #endregion

        #region public bool SaveData(AbstractDetail detail)

        /// <summary>
        /// Сохранаяет данные заданного агрегата
        /// </summary>
        /// <param name="detail">Агрегат</param>
        public bool SaveData(AbstractDetail detail)
        {
            for (int i = 0; i < existPrformances.Count; i++)
            {
                if (!existPrformances[i].SaveData())
                    return false;
            }
            for (int i = 0; i < addedPerformances.Count; i++)
            {
                if (addedPerformances[i].Interval != Lifelength.NullLifelength)
                {
                    DetailDirective detailDirective = addedPerformances[i].GetDetailDirective();
                    detail.AddDetailDirective(detailDirective);
                    if (addedPerformances[i].AddActualStateRecordToDetail)
                    {
                        ActualStateRecord record = new ActualStateRecord(addedPerformances[i].ComponentLastPerformance);
                        record.RecordDate = addedPerformances[i].RecordDate;
                        detail.AddRecord(record);
                    }
                    if (addedPerformances[i].AddActualStateRecordToAircraft)
                    {
                        ActualStateRecord record = new ActualStateRecord(addedPerformances[i].AircraftLastPerformance);
                        record.RecordDate = addedPerformances[i].RecordDate;
                        if (detail is BaseDetail)
                            ((BaseDetail)detail).ParentAircraft.AddRecord(record);
                        else
                            ((Aircraft)detail.Parent.Parent).AddRecord(record);
                    }
                }
            }
            if (currentDetail != null)
                UpdateInformation();
            return true;
        }

        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает поля
        /// </summary>
        public void ClearFields()
        {
            flowLayoutPanelPerformances.Controls.Clear();
            addedPerformances.Clear();
            DetailAddCompliancePerformanceControl control = new DetailAddCompliancePerformanceControl(currentAircraft);
            addedPerformances.Add(control);
            flowLayoutPanelPerformances.Controls.Add(control);
            if (currentDetail != null && currentDetail.InUse)
                flowLayoutPanelPerformances.Controls.Add(linkLabelAddNew);
        }

        #endregion

        #region private void compliancePerformanceControl_Deleted(object sender, EventArgs e)

        private void compliancePerformanceControl_Deleted(object sender, EventArgs e)
        {
            DetailCompliancePerformanceControl control = (DetailCompliancePerformanceControl) sender;
            DetailDirective directive = control.DetailDirective;
            existPrformances.Remove(control);
            flowLayoutPanelPerformances.Controls.Remove(control);
            try
            {
                currentDetail.RemoveDetailDirective(directive);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while removing data", ex);
            }
        }

        #endregion

        #region private void linkLabelAddNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void linkLabelAddNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DetailAddCompliancePerformanceControl performance = new DetailAddCompliancePerformanceControl(currentAircraft);
            addedPerformances.Add(performance);
            flowLayoutPanelPerformances.Controls.Remove(linkLabelAddNew);
            flowLayoutPanelPerformances.Controls.Add(performance);
            flowLayoutPanelPerformances.Controls.Add(linkLabelAddNew);
        }

        #endregion
        
        #endregion

    }
}