using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Directives;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Management;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using System;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.DirectivesControls;
using CAS.UI.UIControls.ReferenceControls;

namespace CAS.UI.UIControls.DirectivesControls
{
    /// <summary>
    /// Класс, описывающий отображение добавления директивы
    /// </summary>
    [ToolboxItem(false)]
    public class DirectiveAddingScreen : PictureBox
    {

        #region Fields
        /// <summary>
        /// Родительский объект, в который добавляется директива
        /// </summary>
        protected IDirectiveContainer currentDirectiveContainer;
        private BaseDetailDirective addedDirective;

        private HeaderControl headerControl;
        private AircraftHeaderControl aircraftHeader;
        private FooterControl footerControl;
        private Panel mainPanel;

        private ExtendableRichContainer directiveApplicabilityContainer;
        private ExtendableRichContainer generalDataAndPerformanceContainer;
        private ExtendableRichContainer attributesAndParametersContainer;

        protected DirectiveApplicabilityControl directiveApplicabilityControl;
        protected DirectiveInformationControl generalDataAndPerformanceControl;
        protected DirectiveParametersControl attributesAndParametersControl; 
        private readonly Icons icons = new Icons();
        private readonly DirectiveType directiveType;

        #endregion

        #region Constructors

        #region public DirectiveAddingScreen(IDirectiveContainer directiveContainer, DirectiveType directiveType)

        ///<summary>
        /// Создается объект, описывающий отображение добавления директивы
        ///</summary>
        /// <param name="directiveContainer">Родительский объект, в который добавляется директива</param>
        /// <param name="directiveType">Тип директивы</param>
        public DirectiveAddingScreen(IDirectiveContainer directiveContainer, DirectiveType directiveType)
        {
            if (directiveContainer == null) throw new ArgumentNullException("directiveContainer");
            currentDirectiveContainer = directiveContainer;
            this.directiveType = directiveType;
            InitializeComponent(directiveType);
            if (directiveContainer is BaseDetail)
                aircraftHeader.Aircraft = ((BaseDetail)directiveContainer).ParentAircraft;
            else
                aircraftHeader.Aircraft = (Aircraft)directiveContainer;
            ClearFields();
        }

        #endregion

        #endregion

        #region Properties

        #region public DirectiveType CurrentDirectiveType

        /// <summary>
        /// Тип директивы
        /// </summary>
        public DirectiveType CurrentDirectiveType
        {
            get
            {
                return directiveType;
            }
        }

        #endregion
        
        #endregion

        #region Methods

        #region private void InitializeComponent(DirectiveType currentDirectiveType)

        private void InitializeComponent(DirectiveType currentDirectiveType)
        {
            Dock = DockStyle.Fill;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            footerControl = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeader = new AircraftHeaderControl();
            mainPanel = new Panel();

            generalDataAndPerformanceControl = new DirectiveInformationControl(currentDirectiveType);
            attributesAndParametersControl = new DirectiveParametersControl(currentDirectiveType);

            directiveApplicabilityContainer = new ExtendableRichContainer();
            generalDataAndPerformanceContainer = new ExtendableRichContainer();
            attributesAndParametersContainer = new ExtendableRichContainer();

            aircraftHeader.OperatorClickable = true;
            aircraftHeader.AircraftClickable = true;
            //
            // headerControl
            //
            headerControl.Controls.Add(aircraftHeader);
            headerControl.ButtonReload.Icon = icons.SaveAndAdd;
            headerControl.ButtonReload.IconNotEnabled = icons.SaveAndAddGray;
            headerControl.ButtonReload.IconLayout = ImageLayout.Center;
            headerControl.ButtonReload.TextMain = "Save and";
            headerControl.ButtonReload.TextSecondary = "add another";
            headerControl.ButtonReload.Click += buttonSaveAndAdd_Click;

            headerControl.ButtonEdit.Icon = icons.Save;
            headerControl.ButtonEdit.IconNotEnabled = icons.SaveGray;
            headerControl.ButtonEdit.IconLayout = ImageLayout.Center;
            headerControl.ButtonEdit.ReflectionType = ReflectionTypes.DisplayInCurrent;
            headerControl.ButtonEdit.TextMain = "Save";
            headerControl.ButtonEdit.TextSecondary = "and Edit";
            headerControl.ButtonEdit.DisplayerRequested += buttonSaveAndEdit_DisplayerRequested;
            headerControl.TabIndex = 0;
            //
            // mainPanel
            //
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.AutoScroll = true;
            mainPanel.TabIndex = 1;
            //
            // footerControl
            //
            footerControl.TabIndex = 2;
            //
            // directiveApplicabilityContainer
            //
            directiveApplicabilityContainer.Dock = DockStyle.Top;
            directiveApplicabilityContainer.UpperLeftIcon = icons.GrayArrow;
            directiveApplicabilityContainer.Caption = "Applicability";
            directiveApplicabilityContainer.TabIndex = 0;
            //
            // generalDataAndPerformanceContainer
            //
            generalDataAndPerformanceContainer.Dock = DockStyle.Top;
            generalDataAndPerformanceContainer.UpperLeftIcon = icons.GrayArrow;
            generalDataAndPerformanceContainer.Caption = "General data and Performance";
            generalDataAndPerformanceContainer.MainControl = generalDataAndPerformanceControl;
            generalDataAndPerformanceContainer.TabIndex = 1;
            //
            // attributesAndParametersContainer
            //
            attributesAndParametersContainer.Dock = DockStyle.Top;
            attributesAndParametersContainer.UpperLeftIcon = icons.GrayArrow;
            if (currentDirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType)
                attributesAndParametersContainer.Caption = "Performance";
            else
                attributesAndParametersContainer.Caption = "Attributes and additional parameters";
            attributesAndParametersContainer.MainControl = attributesAndParametersControl;
            attributesAndParametersContainer.TabIndex = 2;

            mainPanel.Controls.Add(attributesAndParametersContainer);
            mainPanel.Controls.Add(generalDataAndPerformanceContainer);

            if (currentDirectiveContainer is Aircraft && ((Aircraft)currentDirectiveContainer).Operator.Aircrafts.Count > 1 && (currentDirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType || currentDirectiveType == DirectiveTypeCollection.Instance.SBDirectiveType))
            {
                directiveApplicabilityControl = new DirectiveApplicabilityControl((Aircraft)currentDirectiveContainer);
                directiveApplicabilityContainer.MainControl = directiveApplicabilityControl;
                mainPanel.Controls.Add(directiveApplicabilityContainer);
            }

            Controls.Add(mainPanel);
            Controls.Add(footerControl);
            Controls.Add(headerControl);
        }

        #endregion

        #region private void buttonSaveAndEdit_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonSaveAndEdit_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (AddNewDirective(true))
            {
                e.RequestedEntity = new DispatcheredDirectiveScreen(addedDirective);
                if (addedDirective.Parent.Parent is Aircraft)
                    e.DisplayerText = ((Aircraft)addedDirective.Parent.Parent).RegistrationNumber + ". " + addedDirective.DirectiveType.CommonName + ". " + addedDirective.Title;
            }
            else
                e.Cancel = true;
        }

        #endregion

        #region private void buttonSaveAndAdd_Click(object sender, EventArgs e)

        private void buttonSaveAndAdd_Click(object sender, EventArgs e)
        {
            if (AddNewDirective(false))
            {
                MessageBox.Show("Directive added successfully", new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                generalDataAndPerformanceControl.ComboBoxATAChapter.Focus();
            }
        }

        #endregion

        #region protected bool AddNewDirective(bool changePageName)

        protected bool AddNewDirective(bool changePageName)
        {
            double d;
            if (generalDataAndPerformanceControl.ATAChapter == null)
            {
                MessageBox.Show("Please select ATA chapter", (string) new TermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!generalDataAndPerformanceControl.CheckManHours(out d) ||
                !generalDataAndPerformanceControl.CheckCost(out d) ||
                !generalDataAndPerformanceControl.CheckLifelengthes())
            {
                return false;
            }
            try
            {
                if (currentDirectiveContainer is Aircraft && directiveApplicabilityControl != null)
                {
                    List<ApplicabilityItem> items = directiveApplicabilityControl.ApplicabilityItems;
                    for (int i = 0; i < items.Count; i++)
                    {
                        BaseDetailDirective directive;
                        if (items[i].Aircraft.ID == ((Aircraft) currentDirectiveContainer).ID)
                            directive = addedDirective;
                        else
                        {
                            directive = new BaseDetailDirectiveProxy();
                            directive.SetDirectiveType(CurrentDirectiveType);
                        }
                        generalDataAndPerformanceControl.SaveData(directive, changePageName);
                        attributesAndParametersControl.SaveData(directive);
                        items[i].Aircraft.Add(directive);
                       // generalDataAndPerformanceControl.SaveData(directive, changePageName);
                        if (items[i].RecordType == RecordTypesCollection.Instance.DirectiveNotApplicableRecordType)
                            directive.AddRecord(RecordTypesCollection.Instance.DirectiveNotApplicableRecordType, "");
                        else if (items[i].RecordType == RecordTypesCollection.Instance.DirectiveTerminatingType)
                            directive.AddRecord(RecordTypesCollection.Instance.DirectiveTerminatingType, "");
                        else if (items[i].RecordType == RecordTypesCollection.Instance.DirectiveClosingRecordType)
                            directive.AddRecord(RecordTypesCollection.Instance.DirectiveClosingRecordType, "");
                        if (addedDirective.DirectiveType == DirectiveTypeCollection.Instance.SBDirectiveType || addedDirective.DirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType)
                        {
                            if (generalDataAndPerformanceControl.Supersedes != "" && directive == addedDirective)//todo убрать
                            {
                                BaseDetailDirective supersedesDirective = GetDirectiveByTitle(generalDataAndPerformanceControl.Supersedes, directive);
                                if (supersedesDirective != null)
                                {
                                    if (directive.Paragraph == "" && supersedesDirective.Paragraph == "")
                                    {
                                        supersedesDirective.SupersededBy = directive.Title;
                                        supersedesDirective.Save();
                                    }
                                    DirectiveRecord record = new DirectiveRecord();
                                    record.RecordType = RecordTypesCollection.Instance.DirectiveSupersedingRecordType;
                                    supersedesDirective.AddRecord(record);
                                }
                            }
                            if (generalDataAndPerformanceControl.SupersededBy != "")
                            {
                                BaseDetailDirective supersededByDirective = null;
                                if (directive == addedDirective)//todo убрать
                                {
                                    supersededByDirective = GetDirectiveByTitle(generalDataAndPerformanceControl.SupersededBy, directive);
                                    if (supersededByDirective != null)
                                    {
                                        if (directive.Paragraph == "" && supersededByDirective.Paragraph == "")
                                        {
                                            supersededByDirective.Supersedes = directive.Title;
                                            supersededByDirective.Save();
                                        }
                                    }
                                }
                                DirectiveRecord record = new DirectiveRecord();
                                record.RecordType = RecordTypesCollection.Instance.DirectiveSupersedingRecordType;
                                directive.AddRecord(record);
                            }
                        }
                    }
                }
                else
                {
                    generalDataAndPerformanceControl.SaveData(addedDirective, changePageName);
                    attributesAndParametersControl.SaveData(addedDirective);
                    currentDirectiveContainer.Add(addedDirective);
                    if (addedDirective.DirectiveType == DirectiveTypeCollection.Instance.SBDirectiveType || addedDirective.DirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType)
                    {
                        if (generalDataAndPerformanceControl.Supersedes != "")
                        {
                            BaseDetailDirective directive = GetDirectiveByTitle(generalDataAndPerformanceControl.Supersedes, addedDirective);
                            if (directive != null)
                            {
                                directive.SupersededBy = addedDirective.Title;
                                directive.Save();
                                DirectiveRecord record = new DirectiveRecord();
                                record.RecordType = RecordTypesCollection.Instance.DirectiveSupersedingRecordType;
                                directive.AddRecord(record);
                            }
                        }
                        if (generalDataAndPerformanceControl.SupersededBy != "")
                        {
                            BaseDetailDirective directive = GetDirectiveByTitle(generalDataAndPerformanceControl.SupersededBy, addedDirective);
                            if (directive != null)
                            {
                                if (addedDirective.Paragraph == "" && directive.Paragraph == "")
                                    directive.Supersedes = addedDirective.Title;
                                directive.Save();
                                DirectiveRecord record = new DirectiveRecord();
                                record.RecordType = RecordTypesCollection.Instance.DirectiveSupersedingRecordType;
                                addedDirective.AddRecord(record);
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return false;
            }
            return true;
        }

        #endregion

        #region private void ClearFields()

        private void ClearFields()
        {
            addedDirective = new BaseDetailDirectiveProxy(currentDirectiveContainer);
            addedDirective.SetDirectiveType(CurrentDirectiveType);
            if (directiveApplicabilityControl != null)
                directiveApplicabilityControl.ClearFields();
            generalDataAndPerformanceControl.ClearFields();
            attributesAndParametersControl.ClearFields(CurrentDirectiveType);
        }

        #endregion

        #region private static BaseDetailDirective GetDirectiveByTitle(string title, BaseDetailDirective directive)

        private static BaseDetailDirective GetDirectiveByTitle(string title, BaseDetailDirective directive)
        {
            DirectiveFilter directiveFilter;
            if (directive.DirectiveType == DirectiveTypeCollection.Instance.SBDirectiveType)
                directiveFilter = new SBStatusFilter();
            else if (directive.DirectiveType == DirectiveTypeCollection.Instance.ADDirectiveType)
                directiveFilter = new ADStatusFilter();
            else
                return null;
            DirectiveCollectionFilter filter = new DirectiveCollectionFilter(((BaseDetail)directive.Parent).ContainedDirectives, new DirectiveFilter[] { directiveFilter });
            BaseDetailDirective[] directives = filter.GatherDirectives();
            for (int i = 0; i < directives.Length; i++)
            {
                if (directives[i].Title == title)
                    return directives[i];
            }
            return null;
        }

        #endregion
        
        #endregion
                

    }
}