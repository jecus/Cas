using System;
using System.Windows.Forms;
using Auxiliary;
using AvControls;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    ///</summary>
    public partial class StatusControl : UserControl
    {
        #region Properties

        #region public Aircraft Aircraft

        private Aircraft _aircraft;
        ///<summary>
        /// Возвращает или задает ВС отображаемое в контроле
        ///</summary>
        public Aircraft Aircraft
        {
            get { return _aircraft; }
            set 
            {
                _aircraft = value;
                if (_aircraft!=null)
                {
                    labelDate.Text = UsefulMethods.NormalizeDate(DateTime.Now);


                    if(GlobalObjects.CasEnvironment != null)
                        labelPerformance.Text = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_aircraft).ToRepeatIntervalsFormat();
                }
            }
        }
        #endregion

        #region public Operator Operator

        private Operator _operator;
        ///<summary>
        /// Возвращает или задает ВС отображаемое в контроле
        ///</summary>
        public Operator Operator
        {
            get { return _operator; }
            set
            {
                _operator = value;
                if (_operator != null)
                {
                    labelDate.Text = UsefulMethods.NormalizeDate(DateTime.Now);
                }
            }
        }
        #endregion

        #region public ConditionState ConditionState

        private ConditionState _state;
        ///<summary>
        /// Возвращает или задает состояние текущего самолета
        ///</summary>
        public ConditionState ConditionState
        {
            get { return _state; }
            set
            {
                if (_state!=value)
                {
                    _state = value;

                    if (_state==ConditionState.NotEstimated)
                    {
                        statusImageLinkLabel1.Status = Statuses.NotActive;
                        labelStatus.Text = "Condition: Not active";
                    }
                    if (_state == ConditionState.Satisfactory)
                    {
                        statusImageLinkLabel1.Status = Statuses.Satisfactory;
                        labelStatus.Text = "Condition: Satisfactory";
                    }
                    if (_state == ConditionState.Overdue)
                    {
                        statusImageLinkLabel1.Status = Statuses.NotSatisfactory;
                        labelStatus.Text = "Condition: Overdue";
                    }
                    if (_state == ConditionState.Notify)
                    {
                        statusImageLinkLabel1.Status = Statuses.Notify;
                        labelStatus.Text = "Condition: Notify";
                    }
                }
            }
        }
        #endregion

        ///<summary>
        ///</summary>
        public string Title
        {
            get { return labelTitle.Text; }
            set { labelTitle.Text = value; }
        }

        ///<summary>
        ///</summary>
        public bool ShowStatus
        {
            set
            {
                statusImageLinkLabel1.Visible = value;
                labelStatus.Visible = value;
            }
        }
        
        
        public bool ShowOperatorAircraft
        {
            set
            {
                labelTitle.Visible = value;
                label1.Visible = value;
                label2.Visible = value;
                labelDate.Visible = value;
                labelPerformance.Visible = value;
            }
        }

        #endregion

        #region Constructor
        ///<summary>
        ///</summary>
        public StatusControl()
        {
            InitializeComponent();
        }
        #endregion
    }
}
