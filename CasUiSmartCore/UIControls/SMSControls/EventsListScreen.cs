using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAS.Entity.Models.DTO.General;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using Entity.Abstractions.Filters;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.SMS;

namespace CAS.UI.UIControls.SMSControls
{
    ///<summary>
    ///</summary>
    [ToolboxItem(false)]
    public partial class EventsListScreen : CommonListScreen
    {
        #region Fields

        #endregion
        
        #region Constructors

        #region public EventsListScreen()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public EventsListScreen()
        {
            InitializeComponent();
            ViewedType = typeof (Event);
        }
        #endregion

        #region public EventsListScreen(Aircraft currentAircraft) : this()

        ///<summary>
        /// Создаёт экземпляр элемента управления, отображающего список событий
        ///</summary>
        ///<param name="currentAircraft">ВС, которому принадлежат события</param>
        ///<param name="beginGroup">Описывает своиство класса Event, по которому нужно сделать первичную группировку</param>
        public EventsListScreen(Aircraft currentAircraft, PropertyInfo beginGroup = null)
            : base(typeof(Event), beginGroup )
        {
            if (currentAircraft == null)
                throw new ArgumentNullException("currentAircraft");
            CurrentAircraft = currentAircraft;
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
                InitialDirectiveArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<EventDTO, Event>(new Filter("AircraftId", CurrentAircraft.ItemId), true));
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
            DirectivesViewer = new EventsListView();
            DirectivesViewer.TabIndex = 2;
            DirectivesViewer.Location = new Point(panel1.Left, panel1.Top);
            DirectivesViewer.Dock = DockStyle.Fill;
            DirectivesViewer.ViewedType = typeof(Event);

            DirectivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

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
