using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.ExcelExport;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Store;
using ComponentCollection = SmartCore.Entities.Collections.ComponentCollection;

namespace CAS.UI.UIControls.StoresControls
{
    ///<summary>
    /// Экран для отображения записей о неснижаемом запасе
    ///</summary>
    [ToolboxItem(false)]
    public partial class ShouldBeOnStockListScreen : CommonListScreen
    {
	    private readonly ComponentCollection _resultCollection;


		#region Fields
		private AnimatedThreadWorker _worker;
		private ExcelExportProvider _exportProvider;
		#endregion

		#region Constructors

		#region public ShouldBeOnStockScreen()
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		public ShouldBeOnStockListScreen()
        {
            InitializeComponent();
            ViewedType = typeof (StockComponentInfo);
        }
        #endregion

        #region public ShouldBeOnStockScreen(Store currentStore, PropertyInfo beginGroup = null) : base(typeof(StockDetailInfo), beginGroup)

        /// <summary>
        ///  Создаёт экземпляр элемента управления, отображающего список неснижаемого запаса на складе
        /// </summary>
        /// <param name="currentStore">Склад, которому принадлежат записи о неснижаемом запасе</param>
        /// <param name="resultCollection"></param>
        /// <param name="beginGroup">Описывает своиство класса StockDetailInfo, по которому нужно сделать первичную группировку</param>
        public ShouldBeOnStockListScreen(Store currentStore, ComponentCollection resultCollection,
	        PropertyInfo beginGroup = null)
            : base(typeof(StockComponentInfo), beginGroup)
        {
            if (currentStore == null)
                throw new ArgumentNullException("currentStore");
            _resultCollection = resultCollection;
            CurrentStore = currentStore;
            StatusTitle = "Should be on Stock";
        }

        #endregion

        #endregion

        #region Methods

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;
            DirectivesViewer.SetItemsArray(InitialDirectiveArray);

            if (CurrentStore != null)
            {
                labelTitle.Text = "Date as of: " + SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today);
            }
            DirectivesViewer.Focus();

            headerControl.PrintButtonEnabled = DirectivesViewer.ItemListView.Items.Count != 0;
            buttonDeleteSelected.Enabled = DirectivesViewer.SelectedItem != null;
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            #region Загрузка элементов
            
            if(InitialDirectiveArray == null)
                InitialDirectiveArray = new CommonCollection<StockComponentInfo>();
            InitialDirectiveArray.Clear();

            AnimatedThreadWorker.ReportProgress(0, "load records");

            try
            {
                InitialDirectiveArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<StockComponentInfoDTO, StockComponentInfo>(new Filter("StoreID", CurrentStore.ItemId), true));
			}
            catch (Exception exception)
            {
                Program.Provider.Logger.Log("Error while load records", exception);
            }

            AnimatedThreadWorker.ReportProgress(40, "Calculate records");

            try
            {
				//TODO: раньше было так я стал передавать компоненты из списка вроде быстрее но не совсем верное решение 
	            //GlobalObjects.StockCalculator.CalculateStock(InitialDirectiveArray.OfType<StockComponentInfo>(), CurrentStore);
				GlobalObjects.StockCalculator.CalculateStock(_resultCollection.ToArray(), InitialDirectiveArray.OfType<StockComponentInfo>());
            }
            catch (Exception exception)
            {
                Program.Provider.Logger.Log("Error while calculate records", exception);
            }

            #region Фильтрация директив

            AnimatedThreadWorker.ReportProgress(70, "filter records");

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
            DirectivesViewer = new ShouldBeOnStockListView(beginGroup);
            DirectivesViewer.TabIndex = 2;
            DirectivesViewer.Location = new Point(panel1.Left, panel1.Top);
            DirectivesViewer.Dock = DockStyle.Fill;
            DirectivesViewer.ViewedType = typeof(StockComponentInfo);

            DirectivesViewer.SelectedItemsChanged += DirectivesViewerSelectedItemsChanged;

            panel1.Controls.Add(DirectivesViewer);
        }

        #endregion

        #region protected override void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

        protected override void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //StockComponentInfoForm form = new StockComponentInfoForm(new StockComponentInfo(CurrentStore));

            //if (form.ShowDialog() == DialogResult.OK)
            //    AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region protected override void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        protected override void HeaderControlButtonPrintDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //throw new System.NotImplementedException();
        }
		#endregion

		#region protected override void ButtonExportDisplayerRequested(object sender, ReferenceEventArgs e)

		protected override void ButtonExportDisplayerRequested(object sender, ReferenceEventArgs e)
        {
	        _worker = new AnimatedThreadWorker();
	        _worker.DoWork += ExportActivity_Click;
	        _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
	        _worker.RunWorkerAsync();
        }

		#endregion

		private void ExportActivity_Click(object sender, EventArgs eventArgs)
		{
			_worker.ReportProgress(0, "Generate file! Please wait....");

			_exportProvider = new ExcelExportProvider();
			_exportProvider.ExportShouldBeOnStock(InitialDirectiveArray.OfType<StockComponentInfo>().ToList());
		}

		private void Worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			var sfd = new SaveFileDialog();
			sfd.Filter = ".xlsx Files (*.xlsx)|*.xlsx";

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				_exportProvider.SaveTo(sfd.FileName);
				MessageBox.Show("File was success saved!");
			}

			_exportProvider.Dispose();
		}

		#endregion
	}
}
