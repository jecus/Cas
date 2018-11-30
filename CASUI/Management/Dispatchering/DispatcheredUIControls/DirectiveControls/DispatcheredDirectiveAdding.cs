using System.ComponentModel;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Directives;
using CAS.UI.Management;
using CAS.Core;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using System;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.DirectivesControls;
using CAS.UI.UIControls.ReferenceControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls
{
    /// <summary>
    /// Класс, описывающий отображение добавления директивы
    /// </summary>
    [ToolboxItem(false)]
    public class DispatcheredDirectiveAdding : PictureBox, IDisplayingEntity
    {

        #region Fields
        /// <summary>
        /// Родительский объект, в который добавляется директива
        /// </summary>
        private IDirectiveContainer parentBaseDetail;
        private BaseDetailDirective addedDirective;

        private HeaderControl headerControl;
        private AircraftHeaderControl aircraftHeader;
        private FooterControl footerControl;
        private Panel mainPanel;

        private ExtendableRichContainer generalDataAndPerformanceContainer;
        private ExtendableRichContainer attributesAndParametersContainer;

        private DirectiveInformationControl generalDataAndPerformanceControl;
        private DirectiveParametersControl attributesAndParametersControl; 
        private readonly Icons icons = new Icons();
        private readonly DirectiveType directiveType;

        #endregion

        #region Constructors

        #region public DispatcheredDirectiveAdding(BaseDetail parentBaseDetail, DirectiveType directiveType) : this()

        ///<summary>
        /// Создается объект, описывающий отображение добавления директивы
        ///</summary>
        /// <param name="parentBaseDetail">Родительский объект, в который добавляется директива</param>
        /// <param name="directiveType">Тип директивы</param>
        public DispatcheredDirectiveAdding(BaseDetail parentBaseDetail, DirectiveType directiveType)
        {
            if (parentBaseDetail == null) throw new ArgumentNullException("parentBaseDetail");
            this.parentBaseDetail = parentBaseDetail;
            this.directiveType = directiveType;
            InitializeComponent(directiveType);
            aircraftHeader.Aircraft = parentBaseDetail.ParentAircraft;
            ClearFields();
        }

        #endregion

        #region public DispatcheredDirectiveAdding(Aircraft parentAircraft, DirectiveType directiveType) : this()

        ///<summary>
        /// Создается объект, описывающий отображение добавления директивы
        ///</summary>
        /// <param name="parentAircraft">Родительский объект, в который добавляется директива</param>
        /// <param name="directiveType">Тип директивы</param>
        public DispatcheredDirectiveAdding(Aircraft parentAircraft, DirectiveType directiveType)
        {
            if (parentAircraft == null) throw new ArgumentNullException("parentAircraft");
            parentBaseDetail = parentAircraft;
            this.directiveType = directiveType;
            InitializeComponent(directiveType);
            aircraftHeader.Aircraft = parentAircraft;
            ClearFields();
        }

        #endregion

        #endregion

        #region Properties

        #region public object ContainedData
        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return parentBaseDetail; }
            set
            {
                if (value is BaseDetail)
                    parentBaseDetail = (BaseDetail)value;
            }
        }
        #endregion

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

        #region private void InitializeComponent(DirectiveType directiveType)

        private void InitializeComponent(DirectiveType directiveType)
        {
            Dock = DockStyle.Fill;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            footerControl = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeader = new AircraftHeaderControl();
            mainPanel = new Panel();

            generalDataAndPerformanceControl = new DirectiveInformationControl(directiveType);
            attributesAndParametersControl = new DirectiveParametersControl(directiveType);

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
            // generalDataAndPerformanceContainer
            //
            generalDataAndPerformanceContainer.Dock = DockStyle.Top;
            generalDataAndPerformanceContainer.UpperLeftIcon = icons.GrayArrow;
            generalDataAndPerformanceContainer.Caption = "General data and Performance";
            generalDataAndPerformanceContainer.MainControl = generalDataAndPerformanceControl;
            generalDataAndPerformanceContainer.TabIndex = 0;
            //
            // attributesAndParametersContainer
            //
            attributesAndParametersContainer.Dock = DockStyle.Top;
            attributesAndParametersContainer.UpperLeftIcon = icons.GrayArrow;
            if (directiveType == DirectiveTypeCollection.Instance.ADDirectiveType)
                attributesAndParametersContainer.Caption = "Performance";
            else
                attributesAndParametersContainer.Caption = "Attributes and additional parameters";
            attributesAndParametersContainer.MainControl = attributesAndParametersControl;
            attributesAndParametersContainer.TabIndex = 1;

            mainPanel.Controls.Add(attributesAndParametersContainer);
            mainPanel.Controls.Add(generalDataAndPerformanceContainer);

            Controls.Add(mainPanel);
            Controls.Add(footerControl);
            Controls.Add(headerControl);
        }

        #endregion

        #region public bool ContainedDataEquals(IDisplayingEntity obj)
        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredDetailAdding))
                return false;
            if (!(obj.ContainedData is BaseDetail))
                return false;
            if (parentBaseDetail == null) return false;
                
            return ((CoreType)parentBaseDetail).ID == ((BaseDetail)obj.ContainedData).ID;
        }

        /// <summary>
        /// Method call after add to IDisplayerCollectionProxy
        /// </summary>

        /// <returns></returns>
        public void OnInitCompletion(object sender)
        {
            if (InitComplition != null)
                InitComplition(sender, new EventArgs());

        }
        #endregion

        #region public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            if (generalDataAndPerformanceControl.GetChangeStatus(false) || attributesAndParametersControl.GetChangeStatus(false))
            {
                switch (MessageBox.Show("Do you want to save changes?", (string)new TermsProvider()["SystemName"],
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes:
                        if (!AddNewDirective(false))
                            arguments.Cancel = true;
                        break;
                    case DialogResult.Cancel:
                        arguments.Cancel = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Действия, происходящие при деактивации вкладки, содержащей данную сущность
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        {
            
        }

        public void SetEnabled(bool isEnbaled)
        {
            
        }

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;
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

        #region private bool AddNewDirective(bool changePageName)

        private bool AddNewDirective(bool changePageName)
        {
            double d;
            if (generalDataAndPerformanceControl.ATAChapter == null)
            {
                MessageBox.Show("Please select ATA chapter", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!generalDataAndPerformanceControl.CheckManHours(out d) || !generalDataAndPerformanceControl.CheckCost(out d) || !generalDataAndPerformanceControl.CheckLifelengthes())
            {
                return false;
            }
            else
            {
                generalDataAndPerformanceControl.SaveData(addedDirective, changePageName);
                attributesAndParametersControl.SaveData(addedDirective);
                parentBaseDetail.Add(addedDirective);
                return true;
            }
        }

        #endregion

        #region private void ClearFields()

        private void ClearFields()
        {
            addedDirective = new BaseDetailDirectiveProxy(parentBaseDetail);
            addedDirective.SetDirectiveType(CurrentDirectiveType);
            generalDataAndPerformanceControl.ClearFields();
            attributesAndParametersControl.ClearFields(CurrentDirectiveType);
        }

        #endregion

        #endregion
                

    }
}