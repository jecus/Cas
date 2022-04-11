using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.SMSControls;
using CASTerms;
using Entity.Abstractions.Filters;
using SmartCore.CAA.Event;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;

namespace CAS.UI.UICAAControls.Event
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class CAAEventTypesListScreen : CommonListScreen
    {
        private readonly int? _operatorId;

        #region Fields

        #endregion
        
        #region Constructors

        #region public CAAEventTypesListScreen()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public CAAEventTypesListScreen()
        {
            InitializeComponent();
        }
        #endregion

        #region public EventTypesListScreen(Aircraft currentAircraft) : this()
        ///<summary>
        /// Создаёт экземпляр элемента управления, отображающего список директив
        ///</summary>
        ///<param name="parent">ВС, которому принадлежат директивы</param>
        ///<param name="beginGroup">Описывает своиство класса Event, по которому нужно сделать первичную группировку</param>
        public CAAEventTypesListScreen(Operator currentOperator, int? operatorId)
            : base(typeof(CAASmsEventType))
        {

            _operatorId = operatorId;
             aircraftHeaderControl1.Operator = currentOperator;
            StatusTitle = "Event Types";
        }

        #endregion

        #endregion

        #region Methods

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;
            DirectivesViewer.SetItemsArray(InitialDirectiveArray.OfType<BaseEntityObject>());
            DirectivesViewer.Focus();

            headerControl.PrintButtonEnabled = DirectivesViewer.ItemsCount != 0;
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            #region Загрузка элементов
            
            if(InitialDirectiveArray == null)
                InitialDirectiveArray = new CommonCollection<CAASmsEventType>();
            InitialDirectiveArray.Clear();

            if (ResultDirectiveArray == null)
                ResultDirectiveArray = new CommonCollection<CAASmsEventType>();
            ResultDirectiveArray.Clear();

            AnimatedThreadWorker.ReportProgress(0, "load event types");

            try
            {
                
                InitialDirectiveArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader
                    .GetObjectListAll<CAASmsEventTypeDTO, CAASmsEventType>(new Filter("OperatorId", _operatorId)));
                
                //InitialDirectiveArray.AddRange(GlobalObjects.CaaEnvironment.GetDictionary<CAASmsEventType>()?.GetValidEntries()?.Cast<CAASmsEventType>().Where(i => i.OperatorId == _operatorId));
            }
            catch (Exception exception)
            {
                Program.Provider.Logger.Log("Error while load Event types", exception);
            }

            AnimatedThreadWorker.ReportProgress(40, "load event types");

            #region Фильтрация директив

            AnimatedThreadWorker.ReportProgress(70, "filter event types");

            FilterItems(InitialDirectiveArray, ResultDirectiveArray);

            if (AnimatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            #endregion

            AnimatedThreadWorker.ReportProgress(100, "Complete");
            #endregion
        }
        #endregion

        #region protected override void InitListView(PropertyInfo beginGroup = null)

        protected override void InitListView(PropertyInfo beginGroup = null)
        {
            DirectivesViewer = new EventTypesListView();
            DirectivesViewer.TabIndex = 2;
            DirectivesViewer.Location = new Point(panel1.Left, panel1.Top);
            DirectivesViewer.Dock = DockStyle.Fill;
            DirectivesViewer.ViewedType = typeof(CAASmsEventType);
            panel1.Controls.Add(DirectivesViewer);
        }

        #endregion

        #region protected override void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

        protected override void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            CAASmsEventTypeForm form = new CAASmsEventTypeForm(new CAASmsEventType(){OperatorId = _operatorId.Value});

            if (form.ShowDialog() == DialogResult.OK)
                AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region protected override void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        protected override void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //throw new System.NotImplementedException();
        }
        #endregion

        #endregion
    }
}
