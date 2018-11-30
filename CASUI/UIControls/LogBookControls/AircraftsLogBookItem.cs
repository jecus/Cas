using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Controls;
using Controls.AvButtonStatus;
using Controls.ExtendableList;
using Controls.SplitViewer;
using LTR.Core;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.UI.Interfaces;
using LTR.UI.Management.Dispatchering;
using LTR.UI.Properties;
using Microsoft.VisualBasic.Devices;

namespace LTR.UI.UIControls.LogBookControls
{
    /// <summary>
    /// Элемент управления для отборажения AircraftLogBook
    /// </summary>
    [ToolboxItem(false)]
    public partial class AircraftsLogBookItem : PictureBox, IExtendableItem, IReference
    {
        #region Constructors

        #region public AircraftsLogBookItem(Aircraft aircraft)

        /// <summary>
        /// Конструктор для создания AircraftsLogBookItem
        /// </summary>
        /// <param name="aircraft">ВС для отображения</param>
        public AircraftsLogBookItem(Aircraft aircraft)
        {
            this.aircraft = aircraft;
            baseDetails = new BaseDetailCollection(aircraft);
            InitializeItem();
        }
        #endregion

        #endregion

        #region Fields

        private AvButtonStatus avButtonStatusAircraft;
        private List<AircraftBaseDetailItem> listAircraftBaseDetailItem;
        private FlowLayoutPanel flowLayoutPanel;
        private Button buttonApply;
        private Button buttonCancel;

        private readonly Aircraft aircraft;
        private readonly BaseDetailCollection baseDetails;



        private readonly Color SHORT_CONTROL_COLOR = Color.Transparent;
        private readonly Color EXTENDED_CONTROL_COLOR = Color.FromArgb(255, 233, 166);
        private const int EXTENDED_HEIGHT = 130;
        private const int SHORT_HEIGHT = 54;

        #endregion

        #region Events

        #region public event EventHandler Extended;
        /// <summary>
        /// Событии вызываемое на развернутое состояние элемета управления 
        /// </summary>
        public event EventHandler Extended;
        #endregion

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested
        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;
        #endregion

        #endregion

        #region Properties

        #region private IDisplayer displayer
        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        private IDisplayer displayer;
        #endregion

        #region private DisplayingEntity entity
        /// <summary>
        /// Entity to display
        /// </summary>
        private IDisplayingEntity entity;
        #endregion

        #region private ReflectionTypes reflectionType
        private string displayerText;
        private ReflectionTypes reflectionType;
        #endregion

        #region public IDisplayer Displayer
        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }
        #endregion

        #region public DisplayingEntity Entity
        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        /// <summary>
        /// Type of reflection [:|||:]
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }
        #endregion

        #region public string RegistrationNumber
        /// <summary>
        /// Регистрационный номер ВС
        /// </summary>
        public string RegistrationNumber
        {
            get { return aircraft.RegistrationNumber; }
        }

        #region IScrollLayoutPanelItem Members

        public int BlocksCount
        {
            get { throw new NotImplementedException(); }
        }

        #endregion

        #endregion

        #endregion

        #region Methods

    
        #region private void InitializeItem()

        private void InitializeLocationsAndSizes()
        {
            avButtonStatusAircraft.Location = new Point(0, 0);
            flowLayoutPanel.Location = new Point(avButtonStatusAircraft.Right,avButtonStatusAircraft.Top);
        }

   

        private void InitializeItem()
        {
            Height = SHORT_HEIGHT;
            Margin = new Padding(0);
            avButtonStatusAircraft = new AvButtonStatus();
            listAircraftBaseDetailItem = new List<AircraftBaseDetailItem>();
            flowLayoutPanel = new FlowLayoutPanel();
          
       /*     ReflectionType = ReflectionTypes.DisplayInNew;
            DisplayerText = "Detail: " + aircraft.SerialNumber; //todo Ссылка на что то
            DisplayerRequested += DetailItem_DisplayerRequested;*/
            //
            // AvButtonStatusAircraft
            //
            avButtonStatusAircraft.TextMain = aircraft.RegistrationNumber;
            avButtonStatusAircraft.TextSecondary = aircraft.Model;
            avButtonStatusAircraft.Status = (Statuses)aircraft.Condition;
            //
            // flowLayoutPanel
            //
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel.AutoSize = true;
            //
            // listAircraftBaseDetailItem
            //
            foreach (BaseDetail baseDetail in baseDetails)
            {
                AircraftBaseDetailItem tempAircraftBaseDetailItem = new AircraftBaseDetailItem(baseDetail);
                listAircraftBaseDetailItem.Add(tempAircraftBaseDetailItem);
                flowLayoutPanel.Controls.Add(tempAircraftBaseDetailItem);
            }

            InitializeLocationsAndSizes();
            Controls.Add(avButtonStatusAircraft);
            Controls.Add(flowLayoutPanel);
        }


        #endregion

        /*    #region void DetailItem_DisplayerRequested(object sender, ReferenceEventArgs e)
        void DetailItem_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.RequestedEntity = new DispatcheredDetailScreen(aircraft);
        }
        #endregion*/


        #region protected void OnDisplayerRequested()
        protected void OnDisplayerRequested()
        {
            if (null != DisplayerRequested)
            {
                ReflectionTypes reflection = reflectionType;
                Keyboard k = new Keyboard();
                if (k.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent) reflection = ReflectionTypes.DisplayInNew;
                if (null != displayer)
                {
                    DisplayerRequested(this, new ReferenceEventArgs(entity, reflection, displayer, displayerText));
                }
                else
                {
                    DisplayerRequested(this, new ReferenceEventArgs(entity, reflection, displayerText));
                }
            }
        }
        #endregion

        #region protected override void OnDoubleClick(EventArgs e)
        protected override void OnDoubleClick(EventArgs e)
        {
//            OnDisplayerRequested();
            base.OnDoubleClick(e);
        }
        #endregion

        #region protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
  //          if (e.KeyCode == Keys.Enter) OnDisplayerRequested();
            base.OnPreviewKeyDown(e);
        }
        #endregion

        #region public void SetShortView()

        /// <summary>
        /// Метод сворачивает элемент управления
        /// </summary>
        public void SetShortView()
        {
            BackColor = SHORT_CONTROL_COLOR;
            foreach (AircraftBaseDetailItem aircraftBaseDetailItem in listAircraftBaseDetailItem)
            {
                aircraftBaseDetailItem.BackColor = SHORT_CONTROL_COLOR;
                aircraftBaseDetailItem.SetShortView();
            }
            if (flowLayoutPanel.Height > SHORT_HEIGHT) Height = flowLayoutPanel.Height; else Height = SHORT_HEIGHT;

        }

        #endregion

        #region public void SetExtendedView()

        /// <summary>
        /// Метод разворачивает элемент управления 
        /// </summary>
        public void SetExtendedView()
        {
            BackColor = EXTENDED_CONTROL_COLOR;
            foreach (AircraftBaseDetailItem aircraftBaseDetailItem in listAircraftBaseDetailItem)
            {
                aircraftBaseDetailItem.BackColor = SHORT_CONTROL_COLOR;
                aircraftBaseDetailItem.SetExtendedView();
            }
            if (flowLayoutPanel.Height > EXTENDED_HEIGHT) Height = flowLayoutPanel.Height; else Height = EXTENDED_HEIGHT;
            if (Extended != null) Extended(this, new EventArgs());
        }
        #endregion

        #region protected override void OnControlAdded(ControlEventArgs e)
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            e.Control.Click += Control_Click;
            e.Control.DoubleClick += Control_DoubleClick;
            e.Control.PreviewKeyDown += Control_PreviewKeyDown;
        }
        #endregion

        #region void Control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        void Control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            OnPreviewKeyDown(e);
        }
        #endregion

        #region void Control_DoubleClick(object sender, EventArgs e)

        void Control_DoubleClick(object sender, EventArgs e)
        {
            OnDoubleClick(e);
        }
        #endregion

        #region Control_Click(object sender, EventArgs e)

        void Control_Click(object sender, EventArgs e)
        {
            SetExtendedView();
        }

        #endregion

        #region protected override void OnSizeChanged(EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (flowLayoutPanel!=null)
            {
                flowLayoutPanel.MaximumSize = new Size(Width - avButtonStatusAircraft.Width,0);
                if (flowLayoutPanel.Height > SHORT_HEIGHT) Height = flowLayoutPanel.Height;
            }
        }
        #endregion

        #endregion


    }
}
