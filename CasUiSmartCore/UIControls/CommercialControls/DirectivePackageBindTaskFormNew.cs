using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.Entity.Models.DTO.Dictionaries;
using CAS.Entity.Models.DTO.General;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Packages;

namespace CAS.UI.UIControls.CommercialControls
{
    /// <summary>
    /// Форма для переноса шаблона ВС в рабочую базу данных
    /// </summary>
    public partial class DirectivePackageBindTaskFormNew : MetroForm
    {

        #region Fields

        private CommonCollection<BaseEntityObject> _itemsForSelect = new CommonCollection<BaseEntityObject>();

        private readonly IDirectivePackage _currentDirectivePackage;

        private readonly AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();

        #endregion

        #region Properties

        /// <summary>
        /// Возвращает список выбранных элементов
        /// </summary>
        public ICommonCollection SelectedItems
        {
            get { return listViewTasksForSelect.SelectedItems; }
        }

        #endregion

        #region Constructors

        #region private DirectivePackageBindTaskFormNew()

        /// <summary>
        /// Создает форму для переноса шаблона ВС в рабочую базу данных
        /// </summary>
        private DirectivePackageBindTaskFormNew()
        {
            InitializeComponent();
        }

        #endregion

        #region public DirectivePackageBindTaskFormNew(IDirectivePackage directivePackage) : this()

        /// <summary>
        /// Создает форму для привязки задач к выполнению чека программы обслуживания
        /// </summary>
        public DirectivePackageBindTaskFormNew(IDirectivePackage directivePackage)
            : this()
        {
            if(directivePackage == null)
                throw new ArgumentNullException("directivePackage", "must be not null");
            _currentDirectivePackage = directivePackage;

            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
        }

        #endregion

        #endregion

        #region Properties

        #endregion

        #region Methods

        #region private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listViewTasksForSelect.SetItemsArray(_itemsForSelect.ToArray());
        }
        #endregion

        #region private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            if (_currentDirectivePackage == null)
            {
                e.Cancel = true;
                return;
            }

            if (_itemsForSelect == null)
                _itemsForSelect = new CommonCollection<BaseEntityObject>();
            _itemsForSelect.Clear();

            _animatedThreadWorker.ReportProgress(0, "load binded tasks");

            try
            {
                _itemsForSelect.AddRange(GlobalObjects.DirectiveCore.GetDirectivesByDirectiveType(DirectiveType.AirworthenessDirectives.ItemId).ToArray());
                _itemsForSelect.AddRange(GlobalObjects.ComponentCore.GetComponents().ToArray());
                _itemsForSelect.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<MaintenanceDirectiveDTO, MaintenanceDirective>().ToArray());
                _itemsForSelect.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<MaintenanceCheckDTO, MaintenanceCheck>().ToArray());
                _itemsForSelect.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<NonRoutineJobDTO, NonRoutineJob>().ToArray());

                foreach (BaseDirectivePackageRecord pr in _currentDirectivePackage.PackageRecords.OfType<BaseDirectivePackageRecord>())
                {
                    _itemsForSelect.Remove(_itemsForSelect.FirstOrDefault(i => i.SmartCoreObjectType == pr.PackageItemType && i.ItemId == pr.DirectiveId));   
                }
                //Определение списка привязанных задач и компонентов
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while load Items For Select for Directive Package Form", ex);
            }

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            _animatedThreadWorker.ReportProgress(75, "calculate directives for select");

            if (_animatedThreadWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            _animatedThreadWorker.ReportProgress(100, "binding complete");
        }
        #endregion

        #region private void ButtonCloseClick(object sender, EventArgs e)

        private void ButtonCloseClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region private void ButtonAddClick(object sender, EventArgs e)

        private void ButtonAddClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }
        #endregion

        #region private void TemplateAircraftAddToDataBaseFormDeactivate(object sender, EventArgs e)

        private void TemplateAircraftAddToDataBaseFormDeactivate(object sender, EventArgs e)
        {
            StaticWaitFormProvider.WaitForm.Visible = false;
        }
        #endregion

        #region private void TemplateAircraftAddToDataBaseFormActivated(object sender, EventArgs e)
        private void TemplateAircraftAddToDataBaseFormActivated(object sender, EventArgs e)
        {
            if (StaticWaitFormProvider.IsActive)
                StaticWaitFormProvider.WaitForm.Visible = true;
        }
        #endregion

        #region private void MaintenanceCheckBindTaskFormLoad(object sender, EventArgs e)
        private void MaintenanceCheckBindTaskFormLoad(object sender, EventArgs e)
        {
            _animatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void ListViewSelectedTasksSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        
        private void ListViewSelectedTasksSelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
        {
            buttonAdd.Enabled = listViewTasksForSelect.SelectedItems.Count > 0;
        }
        #endregion

        #endregion
    }

}