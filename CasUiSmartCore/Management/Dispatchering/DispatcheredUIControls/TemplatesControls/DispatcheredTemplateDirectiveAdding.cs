using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.Management;
using CAS.Core;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives.Templates;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.DirectivesControls;
using CAS.UI.UIControls.ReferenceControls;
using CAS.UI.UIControls.TemplatesControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls
{
    /// <summary>
    /// Класс, описывающий отображение добавления шаблонной директивы
    /// </summary>
    [ToolboxItem(false)]
    public class DispatcheredTemplateDirectiveAdding : UserControl, IDisplayingEntity
    {

        #region Fields
        /// <summary>
        /// Родительский объект, в который добавляется шаблонная директива
        /// </summary>
        private ITemplateDirectiveContainer parentBaseDetail;
        private TemplateBaseDetailDirective addedDirective;

        private readonly HeaderControl headerControl;
        private readonly TemplateAircraftHeaderControl aircraftHeader;
        private readonly FooterControl footerControl;
        private readonly Panel mainPanel;

        private readonly ExtendableRichContainer generalDataAndPerformanceContainer;
        private readonly ExtendableRichContainer attributesAndParametersContainer;

        private readonly TemplateDirectiveGeneralInformationControl generalDataAndPerformanceControl;
        private readonly TemplateDirectiveAttributesControl attributesAndParametersControl; 
        private readonly Icons icons = new Icons();
        private readonly DirectiveType directiveType;

        #endregion

        #region Constructors

        #region private DispatcheredTemplateDirectiveAdding()

        ///<summary>
        /// Создается объект, описывающий отображение добавления шаблонной директивы
        ///</summary>
        private DispatcheredTemplateDirectiveAdding()
        {
            Dock = DockStyle.Fill;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            footerControl = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeader = new TemplateAircraftHeaderControl();
            mainPanel = new Panel();

            generalDataAndPerformanceControl = new TemplateDirectiveGeneralInformationControl();
            attributesAndParametersControl = new TemplateDirectiveAttributesControl();
            
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
        
        #region public DispatcheredTemplateDirectiveAdding(TemplateBaseDetail parentBaseDetail, DirectiveType directiveType) : this()

        ///<summary>
        /// Создается объект, описывающий отображение добавления шаблонной директивы
        ///</summary>
        /// <param name="parentBaseDetail">Родительский объект, в который добавляется директива</param>
        /// <param name="directiveType">Тип директивы</param>
        public DispatcheredTemplateDirectiveAdding(TemplateBaseDetail parentBaseDetail, DirectiveType directiveType) : this()
        {
            if (parentBaseDetail == null) 
                throw new ArgumentNullException("parentBaseDetail");
            this.parentBaseDetail = parentBaseDetail;
            this.directiveType = directiveType;

            aircraftHeader.Aircraft = parentBaseDetail.ParentAircraft;
            ClearFields();
        }

        #endregion

        #region public DispatcheredTemplateDirectiveAdding(TemplateAircraft parentAircraft, DirectiveType directiveType) : this()

        ///<summary>
        /// Создается объект, описывающий отображение добавления шаблонной директивы
        ///</summary>
        /// <param name="parentAircraft">Родительский объект, в который добавляется шаблонная директива</param>
        /// <param name="directiveType">Тип директивы</param>
        public DispatcheredTemplateDirectiveAdding(TemplateAircraft parentAircraft, DirectiveType directiveType) : this()
        {
            if (parentAircraft == null) 
                throw new ArgumentNullException("parentAircraft");
            parentBaseDetail = parentAircraft;
            this.directiveType = directiveType;
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
                if (value is TemplateBaseDetail)
                    parentBaseDetail = (TemplateBaseDetail)value;
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

        #region public bool ContainedDataEquals(IDisplayingEntity obj)
        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredTemplateDirectiveAdding))
                return false;
            if (!(obj.ContainedData is TemplateBaseDetail))
                return false;
            if (parentBaseDetail == null) return false;
                
            return ((CoreType)parentBaseDetail).ID == ((TemplateBaseDetail)obj.ContainedData).ID;
        }

        /// <summary>
        /// Method call after add to IDisplayerCollectionProxy
        /// </summary>
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
                e.RequestedEntity = new DispatcheredTemplateDirectiveScreen(addedDirective);
                if (addedDirective.Parent.Parent is TemplateAircraft)
                    //e.DisplayerText = "Templates. " + ((TemplateAircraft) addedDirective.Parent.Parent).Model + ". " + CurrentDirectiveType.CommonName + ". " + addedDirective.Title;
                    e.DisplayerText = ((TemplateAircraft) addedDirective.Parent.Parent).Model + ". " + CurrentDirectiveType.CommonName + ". " + addedDirective.Title;
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
            }
        }

        #endregion

        #region private bool AddNewDirective(bool changePageName)

        private bool AddNewDirective(bool changePageName)
        {
            if (generalDataAndPerformanceControl.ATAChapter == null)
            {
                MessageBox.Show("Please select ATA chapter", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!generalDataAndPerformanceControl.CheckManHours())
                return false;
            /*if (!generalDataAndPerformanceControl.CheckAmount())
                return false;*/
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
            addedDirective = new TemplateBaseDetailDirective(parentBaseDetail);
            addedDirective.SetDirectiveType(CurrentDirectiveType);
            generalDataAndPerformanceControl.ClearFields();
            attributesAndParametersControl.ClearFields();
        }

        #endregion

        #endregion
                

    }
}