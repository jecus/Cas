using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.SMSControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class EventTypesListScreen : CommonListScreen
    {
        #region Fields

        #endregion
        
        #region Constructors

        #region public EventTypesListScreen()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public EventTypesListScreen()
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
        public EventTypesListScreen(BaseEntityObject parent, PropertyInfo beginGroup = null)
            : base(typeof(SmsEventType), beginGroup)
        {
            if (parent == null)
                throw new ArgumentNullException("parent");
            if (parent is Aircraft)
                CurrentAircraft = (Aircraft)parent;
            else aircraftHeaderControl1.Operator = GlobalObjects.CasEnvironment.Operators[0];
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

            if (CurrentAircraft != null)
            {
                labelTitle.Text = "Date as of: " +
                    SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today) + " Aircraft TSN/CSN: " +
                    GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
            }
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
                InitialDirectiveArray = new CommonCollection<SmsEventType>();
            InitialDirectiveArray.Clear();

            if (ResultDirectiveArray == null)
                ResultDirectiveArray = new CommonCollection<SmsEventType>();
            ResultDirectiveArray.Clear();

            AnimatedThreadWorker.ReportProgress(0, "load event types");

            try
            {
                InitialDirectiveArray.AddRange(GlobalObjects.CasEnvironment.GetDictionary<SmsEventType>().GetValidEntries());
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
            DirectivesViewer.ViewedType = typeof(SmsEventType);
            panel1.Controls.Add(DirectivesViewer);
        }

        #endregion

        #region protected override void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

        protected override void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            SmsEventTypeForm form = new SmsEventTypeForm(new SmsEventType());

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
