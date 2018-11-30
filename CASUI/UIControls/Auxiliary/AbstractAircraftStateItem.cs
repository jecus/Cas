using System;
using System.Drawing;
using System.Windows.Forms;
using Controls.AvButtonT;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    /// Абстрактный класс, описывающий отображение состояния ВС и краткой информации
    ///</summary>
    public abstract class AbstractAircraftStateItem : AvButtonT, IReference
    {

        #region Fields

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        #endregion
        
        #region Constructors

        #region public AircraftListItem()
        ///<summary>
        /// Создается объект отображения ВС в списке
        ///</summary>
        public AbstractAircraftStateItem()
        {
            InitializeComponent();
            Cursor = Cursors.Default;
            IconLayout = ImageLayout.Center;
        }
        #endregion

        #endregion

        #region Properties

        #region IReference Members

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

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            ReflectionType = ReflectionTypes.DisplayInNew;
            Dock = DockStyle.Left;
            Size = new Size(250, 47);
            PaddingMain = new Padding(0, 8, 0, 0);
            FontMain = new Font("Verdana", 16, GraphicsUnit.Pixel);

            ForeColorMain = Css.OrdinaryText.Colors.ForeColor;
            ForeColorSecondary = Css.OrdinaryText.Colors.ForeColor; 
            Click += AircraftStateItem_Click;
        }

        #endregion

        #region private void AircraftStateItem_Click(object sender, EventArgs e)

        private void AircraftStateItem_Click(object sender, EventArgs e)
        {
            base.OnClick(e);
            OnDisplayerRequested();
        }

        #endregion

        #region private void OnDisplayerRequested()

        private void OnDisplayerRequested()
        {
            if (DisplayerRequested != null)
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

        #endregion

        #region Events

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

    }
}