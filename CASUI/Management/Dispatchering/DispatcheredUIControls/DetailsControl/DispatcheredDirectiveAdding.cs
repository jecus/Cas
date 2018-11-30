using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LTR.Core;
using LTR.Core.Core.Interfaces;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.Core.Types.Dictionaries;
using LTR.Core.Types.Directives;
using LTR.UI.Appearance;
using LTR.UI.Interfaces;
using System;
using LTR.UI.UIControls.AircraftsControls;
using LTR.UI.UIControls.Auxiliary;
using LTR.UI.UIControls.DetailsControls;
using LTR.UI.UIControls.DirectivesControls;
using LTR.UI.UIControls.ReferenceControls;

namespace LTR.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl
{
    /// <summary>
    /// Класс, описывающий отображение длбавление директивы
    /// </summary>
    [ToolboxItem(false)]
    public partial class DispatcheredDirectiveAdding : PictureBox, IDisplayingEntity
    {
        #region Fields
        /// <summary>
        /// Родительский объект, в который добавляется директива
        /// </summary>
        private IDirectiveContainer parentBaseDetail;
        private DirectiveType directiveType;

        private readonly HeaderControl headerControl;
        private readonly AircraftHeaderControl aircraftHeader;
        private readonly FooterControl footerControl;
        private readonly Panel mainPanel;

        private readonly ExtendableRichContainer generalDataAndPerformanceContainer;
        private readonly ExtendableRichContainer attributesAndParametersContainer;

        private readonly DirectiveInformationControl generalDataAndPerformanceControl;
        private readonly DirectiveAttributesControl attributesAndParametersControl; 
        private readonly Icons icons = new Icons();
        #endregion

        #region Constructors
        ///<summary>
        /// Создается объект, описывающий отображение длбавление директивы
        ///</summary>
        private DispatcheredDirectiveAdding()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            footerControl = new FooterControl();
            headerControl = new HeaderControl();
            aircraftHeader = new AircraftHeaderControl();
            mainPanel = new Panel();
            
            generalDataAndPerformanceControl = new DirectiveInformationControl();
            generalDataAndPerformanceControl.Mode = DetailInformationMode.Edit;
            

            attributesAndParametersControl = new DirectiveAttributesControl();
            attributesAndParametersControl.Mode = DetailInformationMode.Edit;
            
            generalDataAndPerformanceContainer = new ExtendableRichContainer();
            attributesAndParametersContainer = new ExtendableRichContainer();
            
            aircraftHeader.AircraftClickable = true;
            //
            // headerControl
            //
            headerControl.Controls.Add(aircraftHeader);
            headerControl.TopicID = "Directive Info";
            headerControl.EditDisplayerText = "Edit Aircraft";
            headerControl.EditReflectionType = ReflectionTypes.DisplayInNew;
            headerControl.EditDisplayerRequested += new EventHandler<ReferenceEventArgs>(headerControl_EditDisplayerRequested);
            headerControl.ReloadRised += new EventHandler(headerControl_ReloadRised);
            headerControl.ButtonEdit.TextMain = "Save";
            headerControl.ButtonEdit.Icon = icons.Save;
            headerControl.ButtonReload.TextMain = "Reset";
            //
            // mainPanel
            //
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.AutoScroll = true;
            //
            // generalDataAndPerformanceContainer
            //
            generalDataAndPerformanceContainer.Dock = DockStyle.Top;
            generalDataAndPerformanceContainer.UpperLeftIcon = icons.GrayArrow;
            generalDataAndPerformanceContainer.Caption = "General data and Performance";
            generalDataAndPerformanceContainer.MainControl = generalDataAndPerformanceControl;
            //
            // attributesAndParametersContainer
            //
            attributesAndParametersContainer.Dock = DockStyle.Top;
            attributesAndParametersContainer.UpperLeftIcon = icons.GrayArrow;
            attributesAndParametersContainer.Caption = "Attributes and additional parameters";
            attributesAndParametersContainer.MainControl = attributesAndParametersControl;

            mainPanel.Controls.Add(attributesAndParametersContainer);
            mainPanel.Controls.Add(generalDataAndPerformanceContainer);

            Controls.Add(mainPanel);
            Controls.Add(footerControl);
            Controls.Add(headerControl);
        }

        ///<summary>
        /// Создается объект, описывающий отображение длбавление директивы
        ///</summary>
        /// <param name="parentBaseDetail">Родительский объект, в который добавляется директива</param>
        public DispatcheredDirectiveAdding(BaseDetail parentBaseDetail)
            : this()
        {
            if (parentBaseDetail == null) throw new ArgumentNullException("parentBaseDetail");
            this.parentBaseDetail = parentBaseDetail;


            aircraftHeader.Aircraft = parentBaseDetail.ParentAircraft;
            aircraftHeader.AircraftClickable = true;
            aircraftHeader.OperatorClickable = true;
        }

        ///<summary>
        /// Создается объект, описывающий отображение длбавление директивы
        ///</summary>
        /// <param name="parentBaseDetail">Родительский объект, в который добавляется директива</param>
        public DispatcheredDirectiveAdding(BaseDetail parentBaseDetail, DirectiveType directiveType)
            : this()
        {
            if (parentBaseDetail == null) throw new ArgumentNullException("parentBaseDetail");
            this.parentBaseDetail = parentBaseDetail;
            this.directiveType = directiveType;
            generalDataAndPerformanceControl.CurrentType = directiveType;

            aircraftHeader.Aircraft = parentBaseDetail.ParentAircraft;
            aircraftHeader.AircraftClickable = true;
            aircraftHeader.OperatorClickable = true;
        }

        ///<summary>
        /// Создается объект, описывающий отображение длбавление директивы
        ///</summary>
        /// <param name="parentAircraft">Родительский объект, в который добавляется директива</param>
        public DispatcheredDirectiveAdding(Aircraft parentAircraft)
            : this()
        {
            if (parentAircraft == null) throw new ArgumentNullException("parentAircraft");
            this.parentBaseDetail = parentAircraft;
            aircraftHeader.Aircraft = parentAircraft;
            aircraftHeader.AircraftClickable = false;
            aircraftHeader.OperatorClickable = true;
        }
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
                if (generalDataAndPerformanceControl != null) return generalDataAndPerformanceControl.CurrentType;
                return null;
            }
            set
            {
                if (generalDataAndPerformanceControl != null)
                    generalDataAndPerformanceControl.CurrentType = value;
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
            if (!(obj is DispatcheredDetailAdding))
                return false;
            if (!(obj.ContainedData is BaseDetail))
                return false;
            if (parentBaseDetail == null) return false;
                
            return ((CoreType)parentBaseDetail).ID == ((BaseDetail)obj.ContainedData).ID;
        }
        #endregion

        #region public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
        }
        #endregion

        #endregion

        #region Events
        void headerControl_ReloadRised(object sender, EventArgs e)
        {
            BaseDetailDirective emptyDetail = new BaseDetailDirective();
            generalDataAndPerformanceControl.UpdateDisplayedData(emptyDetail);
            attributesAndParametersControl.UpdateDisplayedData(emptyDetail);
        }

        void headerControl_EditDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.Cancel = true;
            BaseDetailDirective addedDirective = new BaseDetailDirective();
            
            generalDataAndPerformanceControl.UpdateDirectiveData(addedDirective);
            attributesAndParametersControl.UpdateDirectiveData(addedDirective);

            parentBaseDetail.AddDirective(addedDirective);
            
            DialogResult result = MessageBox.Show("Close current page?", "Directive added successfully", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
                e.TypeOfReflection = ReflectionTypes.CloseSelected;
            }
        }
        #endregion


    }
}
