using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ReferenceControls;
using CASTerms;

namespace CAS.UI.UIControls.DirectivesControls
{
    /// <summary>
    /// Класс, описывающий отображение добавления директивы
    /// </summary>
    [ToolboxItem(false)]
    public class DamageDirectiveAddingScreen : UserControl
    {

        #region Fields
        /// <summary>
        /// Родительский объект, в который добавляется директива
        /// </summary>
        protected IDirectiveContainer parentBaseDetail;
        private BaseDetailDirective addedDirective;

        private readonly HeaderControl headerControl;
        private readonly AircraftHeaderControl aircraftHeader;
        private readonly FooterControl footerControl;
        private readonly Panel mainPanel;

        private readonly ExtendableRichContainer generalDataAndPerformanceContainer;

        protected readonly DamageDirectiveGeneralInformationControl generalDataAndPerformanceControl;
        private readonly Icons icons = new Icons();

        #endregion

        #region Constructors

        #region private DamageDirectiveAddingScreen()

        ///<summary>
        /// Создается объект, описывающий отображение добавления директивы
        ///</summary>
        private DamageDirectiveAddingScreen()
        {
            Dock = DockStyle.Fill;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            footerControl = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeader = new AircraftHeaderControl();
            mainPanel = new Panel();

            generalDataAndPerformanceControl = new DamageDirectiveGeneralInformationControl();
            
            generalDataAndPerformanceContainer = new ExtendableRichContainer();

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
            // generalDataAndPerformanceContainer
            //
            generalDataAndPerformanceContainer.Dock = DockStyle.Top;
            generalDataAndPerformanceContainer.UpperLeftIcon = icons.GrayArrow;
            generalDataAndPerformanceContainer.Caption = "General data and Performance";
            generalDataAndPerformanceContainer.MainControl = generalDataAndPerformanceControl;
            generalDataAndPerformanceContainer.TabIndex = 0;

            mainPanel.Controls.Add(generalDataAndPerformanceContainer);

            Controls.Add(mainPanel);
            Controls.Add(footerControl);
            Controls.Add(headerControl);
        }

        #endregion

        #region public DamageDirectiveAddingScreen(BaseDetail parentBaseDetail) : this()

        ///<summary>
        /// Создается объект, описывающий отображение добавления директивы
        ///</summary>
        /// <param name="parentBaseDetail">Родительский объект, в который добавляется директива</param>
        public DamageDirectiveAddingScreen(BaseDetail parentBaseDetail) : this()
        {
            if (parentBaseDetail == null) throw new ArgumentNullException("parentBaseDetail");
            this.parentBaseDetail = parentBaseDetail;

            aircraftHeader.Aircraft = parentBaseDetail.ParentAircraft;
            ClearFields();
        }

        #endregion

        #region public DamageDirectiveAddingScreen(Aircraft parentAircraft) : this()

        ///<summary>
        /// Создается объект, описывающий отображение добавления директивы
        ///</summary>
        /// <param name="parentAircraft">Родительский объект, в который добавляется директива</param>
        public DamageDirectiveAddingScreen(Aircraft parentAircraft) : this()
        {
            if (parentAircraft == null) throw new ArgumentNullException("parentAircraft");
            parentBaseDetail = parentAircraft;
            aircraftHeader.Aircraft = parentAircraft;
            ClearFields();
        }

        #endregion

        #endregion

        #region Methods

        #region private void buttonSaveAndEdit_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonSaveAndEdit_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (AddNewDirective(true))
            {
                e.RequestedEntity = new DispatcheredDamageDirectiveScreen(addedDirective);
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
                generalDataAndPerformanceControl.TextBoxDescription.Focus();
            }
        }

        #endregion

        #region protected bool AddNewDirective(bool changePageName)

        protected bool AddNewDirective(bool changePageName)
        {
            if (generalDataAndPerformanceControl.Description == "")
            {
                MessageBox.Show("You should enter Title", new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (generalDataAndPerformanceControl.RepeatInterval == null)
            {
                MessageBox.Show("You should enter Repeat Interval", new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!generalDataAndPerformanceControl.SaveData(addedDirective, changePageName))
                return false;
            addedDirective.FirstPerformSinceNew = new Lifelength(generalDataAndPerformanceControl.RepeatInterval);
            if (parentBaseDetail is Aircraft)
                addedDirective.EffectivityDate = ((Aircraft)parentBaseDetail).ManufactureDate;
            else
                addedDirective.EffectivityDate = ((BaseDetail)parentBaseDetail).ParentAircraft.ManufactureDate;
            addedDirective.PerformSinceEffectivityDate = true;
            addedDirective.RepeatedlyPerform = true;
            parentBaseDetail.Add(addedDirective);
/*            if (addedDirective.DirectiveType == DirectiveTypeCollection.Instance.SBDirectiveType)
            {
                if (generalDataAndPerformanceControl.Supersedes != "")
                {
                    BaseDetailDirective directive = GetSBDirectiveByTitle(generalDataAndPerformanceControl.Supersedes);
                    if (directive != null)
                    {
                        directive.SupersededBy = currentDirective.Title;
                        directive.Save();
                        DetailRecord record = new DetailRecord();
                        record.RecordType = RecordTypesCollection.Instance.DirectiveSupersedingRecordType;
                        directive.AddRecord(record);
                    }
                }
                if (generalDataAndPerformanceControl.SupersededBy != "")
                {
                    BaseDetailDirective directive =
                        GetSBDirectiveByTitle(generalDataAndPerformanceControl.SupersededBy);
                    if (directive != null)
                    {
                        directive.Supersedes = currentDirective.Title;
                        directive.Save();
                        DetailRecord record = new DetailRecord();
                        record.RecordType = RecordTypesCollection.Instance.DirectiveSupersedingRecordType;
                        currentDirective.AddRecord(record);
                    }
                }
            }*/
            return true;
        }

        #endregion

        #region private void ClearFields()

        private void ClearFields()
        {
            addedDirective = new BaseDetailDirectiveProxy(parentBaseDetail);
            addedDirective.SetDirectiveType(DirectiveTypeCollection.Instance.DamageRequiringInspectionDirectiveType);
            generalDataAndPerformanceControl.ClearFields();
        }

        #endregion

        #endregion
                

    }
}