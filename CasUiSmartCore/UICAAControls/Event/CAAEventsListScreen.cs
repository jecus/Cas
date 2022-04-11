using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.Entity.Models.DTO.General;
using CAS.UI.Interfaces;
using CAS.UI.UICAAControls.Event;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using Entity.Abstractions.Filters;
using SmartCore.CAA.Event;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.SMS;

namespace CAS.UI.UIControls.SMSControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class CAAEventsListScreen : CommonListScreen
    {
        private readonly int? _operatorId;

        #region Fields

        #endregion
        
        #region Constructors

        #region public EventsListScreen()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public CAAEventsListScreen()
        {
            InitializeComponent();
            ViewedType = typeof (CAAEvent);
        }
        #endregion

        #region public EventsListScreen(Aircraft currentAircraft) : this()

        ///<summary>
        /// Создаёт экземпляр элемента управления, отображающего список событий
        ///</summary>
        ///<param name="beginGroup">Описывает своиство класса Event, по которому нужно сделать первичную группировку</param>
        public CAAEventsListScreen(Operator currentOperator, int? operatorId)
            : base(typeof(CAAEvent) )
        {
            _operatorId = operatorId;
            CurrentOperator = currentOperator;
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
            buttonDeleteSelected.Enabled = DirectivesViewer.SelectedItem != null;
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            #region Загрузка элементов
            
            if(InitialDirectiveArray == null)InitialDirectiveArray = new CommonCollection<Event>();
            InitialDirectiveArray.Clear();

            AnimatedThreadWorker.ReportProgress(0, "load events");

            try
            {
                InitialDirectiveArray.AddRange(GlobalObjects.CaaEnvironment.NewLoader.GetObjectListAll<CAAEventDTO, CAAEvent>(new Filter("OperatorId", _operatorId), true));
            }
            catch (Exception exception)
            {
                Program.Provider.Logger.Log("Error while load Events", exception);
            }

            AnimatedThreadWorker.ReportProgress(40, "load Events");

            #region Фильтрация директив

            AnimatedThreadWorker.ReportProgress(70, "filter Events");

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

        #region private void InitListView()

        protected override void InitListView(PropertyInfo beginGroup = null)
        {
            DirectivesViewer = new CAAEventsListView();
            DirectivesViewer.TabIndex = 2;
            DirectivesViewer.Location = new Point(panel1.Left, panel1.Top);
            DirectivesViewer.Dock = DockStyle.Fill;
            DirectivesViewer.ViewedType = typeof(CAAEvent);

            DirectivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

            panel1.Controls.Add(DirectivesViewer);
        }

        #endregion

        #region protected override void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

        protected override void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            var form = new CAASmsEventForm(new CAAEvent(){OperatorId = _operatorId.Value});

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
