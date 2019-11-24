using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ComponentControls;
using CAS.UI.UIControls.ForecastControls;
using CAS.UI.UIControls.MonthlyUtilizationsControls;
using CAS.UI.UIControls.WorkPakage;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.AircraftsControls
{
    ///<summary>
    /// Контрол для представления коллекции ВС и кнопок для манипуляции с ней
    ///</summary>
    public partial class VehicleCollectionControl : UserControl
    {
        #region Fields

        private WaitForm waitForm;
        private AnimatedThreadWorker animatedThreadWorker;
        private CommonCollection<Vehicle> _itemsCollection;
        private List<ReferenceStatusImageLinkLabel> _controlItems;
        //private const int HEIGHT = 520;

        #endregion


        public bool Extended
        {
            get { return extendableRichContainer.Extended; }
            set { extendableRichContainer.Extended = value; }
        }

        #region Constructors
        ///<summary>
        /// Простой конструктор по умолчанию
        ///</summary>
        public VehicleCollectionControl()
        {
            InitializeComponent();
        }

        ///<summary>
        /// Cоздается графический элемент на основе данной коллекции
        ///</summary>
        ///<param name="vehiclesCollection">Данная бизнес коллекция</param>
        public VehicleCollectionControl(CommonCollection<Vehicle> vehiclesCollection)
        {

            waitForm = StaticWaitFormProvider.WaitForm;
            _itemsCollection = vehiclesCollection;
            FillUiElementsFromCollection();
        }
        #endregion

        #region Properties

        #region public CommonCollection<Vehicle> VehicleCollection
        /// <summary>
        /// Возвращает или задает коллекцию ТС
        /// </summary>
        public CommonCollection<Vehicle> VehiclesCollection
        {
            get { return _itemsCollection; }
            set
            {
                _itemsCollection = value;
                FillUiElementsFromCollection();
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public void FillUiElementsFromCollection()
        /// <summary>
        /// Заполняет графический элемент из бизнес коллекции
        /// </summary>
        public void FillUiElementsFromCollection()
        {
            if (_itemsCollection == null) return;
            int count = _itemsCollection.Count;
            _controlItems = new List<ReferenceStatusImageLinkLabel>();
            flowLayoutPanelAircrafts.Controls.Clear();
            for (int i = 0; i < count; i++)
            {
                ReferenceStatusImageLinkLabel tempLabel = new ReferenceStatusImageLinkLabel
                                                              {
                                                                  ActiveLinkColor = Color.FromArgb(62, 155, 246),
                                                                  AutoSize = true,
                                                                  AutoSizeMode = AutoSizeMode.GrowAndShrink,
                                                                  //Font = new Font("Verdana", 14F, FontStyle.Regular, GraphicsUnit.Pixel),
                                                                  HoveredLinkColor = Color.FromArgb(62, 155, 246),
                                                                  LinkColor = Color.FromArgb(62, 155, 246),
                                                                  MaximumSize = new Size(250,20),
                                                                  Size = new Size(250, 20),
                                                                  Tag = _itemsCollection[i],
                                                                  Text = _itemsCollection[i].RegistrationNumber + " " + 
                                                                         _itemsCollection[i].Model.ShortName,
                                                                  TextAlign = ContentAlignment.MiddleLeft,
                                                                  TextFont = new Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Pixel, 204),
            
                                                                  Enabled = true,
                                                                  Status = Statuses.Satisfactory
                                                              };
                //Css.ImageLink.Adjust(tempLabel);
                if (GlobalObjects.CasEnvironment.Operators.Count == 1)
                    tempLabel.DisplayerText = _itemsCollection[i].RegistrationNumber;
                else
                    tempLabel.DisplayerText = _itemsCollection[i].Operator.Name + ". " + _itemsCollection[i].RegistrationNumber;
                tempLabel.DisplayerRequested += TempButtonDisplayerRequested;
                _controlItems.Add(tempLabel);
            }
            //extendableRichContainer.Caption = _controlItems.Count + " Aircrafts";
            _controlItems.Sort(new Comparison<ReferenceStatusImageLinkLabel>((x,y)=> string.Compare(x.Text,y.Text)));
            linkGroundEquipment.Enabled = linkForecastScreen.Enabled = linkWorkPackages.Enabled = true;
            flowLayoutPanelAircrafts.Controls.AddRange(_controlItems.ToArray());
            flowLayoutPanelAircrafts.Controls.Add(linkGroundEquipment);
            flowLayoutPanelAircrafts.Controls.Add(linkForecastScreen);
            flowLayoutPanelAircrafts.Controls.Add(linkWorkPackages);
            flowLayoutPanelAircrafts.Controls.Add(panelButtons);
        }

        #endregion

        #region private void TempButtonDisplayerRequested(object sender, ReferenceEventArgs e)

        private void TempButtonDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            Vehicle vehicle = ((ReferenceStatusImageLinkLabel)sender).Tag as Vehicle;
            if (vehicle == null)
            {
                e.Cancel = true;
                return;
            }

            e.Cancel = true;
            CommonEditorForm editorForm = new CommonEditorForm(vehicle);
            editorForm.ShowDialog();

            //Keyboard k = new Keyboard();
            //if (k.ShiftKeyDown && e.TypeOfReflection == ReflectionTypes.DisplayInCurrent) e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            ////e.RequestedEntity = new DispatcheredAircraftScreen(aircraft);
            //e.RequestedEntity = new AircraftScreen(aircraft);
        }

        #endregion

        #region private void linkReport_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkReportDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //e.Cancel = true;
            Operator op = GlobalObjects.CasEnvironment.Operators[0];
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = op.Name +  " Ground Equipment";
            e.RequestedEntity = new ComponentsListScreen(op, null);
        }

        #endregion

        #region private void LinkForecastAllAircraftDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkForecastAllAircraftDisplayerRequested(object sender, ReferenceEventArgs e)
        {

            #region --Проверка--
            foreach (var item in GlobalObjects.AircraftsCore.GetAllAircrafts())
            {
				var averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(item);

				if (averageUtilization == null || averageUtilization.CyclesPerMonth == 0 || averageUtilization.HoursPerMonth == 0)
                {
                    if (MessageBox.Show("Average Utilization for aircraft " + item.RegistrationNumber + " is not set. Do you want to set it?", "", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                    {
                        AverageUtilizationForm form = new AverageUtilizationForm(item);
                        form.ShowDialog();
                    }
                }

				averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(item);
				if (averageUtilization == null || averageUtilization.CyclesPerMonth == 0 || averageUtilization.HoursPerMonth == 0)
                {
                    MessageBox.Show(
                        "Average Utilization for aircraft " + item.RegistrationNumber + " is not set. Abort operation",
                        "", MessageBoxButtons.OK);
                    e.Cancel = true;
                    return;
                }
            }
            #endregion

            List<Aircraft> tempArray = new List<Aircraft>();
            ForecastFilterAircraft temp = new ForecastFilterAircraft();
            temp.ShowDialog();
            if (temp.FilteAircraft != null)
            {
                tempArray.AddRange(temp.FilteAircraft.ToArray());
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show("not selected item");
                return;

            }
            e.DisplayerText = "All Aircraft Forecast";
            e.RequestedEntity = new AirFleetForecastListScreen(tempArray);

        }

        #endregion

        #region private void LinkAllWorkPackagesDisplayerRequested(object sender, ReferenceEventArgs e)

        private void LinkAllWorkPackagesDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "All Work packages";
            e.RequestedEntity = new AirFleetWorkPackageListScreen(GlobalObjects.CasEnvironment.Operators[0]);
        }

        #endregion

        #region private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)

        private void animatedThreadWorker_WorkFinished(object sender, EventArgs e)
        {
            //animatedThreadWorker.StopThread();
            //animatedThreadWorker = null;
            //dispatcheredMultitabControl.SetEnabledToAllEntityes(true);
            //UpdateHeader();
            //ShowDetails();
        }

        #endregion

        #region private void BackgroundAircraftLoad(object sender)

        private void BackgroundAircraftLoad(object sender)
        {
            waitForm.Visible = true;
            waitForm.Show();
            StaticWaitFormProvider.IsActive = true;

            try
            {
                //tempAircraft = GlobalObjects.CasEnvironment.Aircrafts.GetItemById(tempAircraft.ItemId);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }
        }

        #endregion

        #region private void SetEnabledToAircraftButtons(bool isEnabled)
        /// <summary>
        /// Изменяет свойство Enabled у кнопок
        /// </summary>
        /// <param name="isEnabled"></param>
        public void SetEnabledToAircraftButtons(bool isEnabled)
        {
            foreach (ReferenceStatusImageLinkLabel t in _controlItems)
            {
                t.Enabled = isEnabled;
            }
        }

        #endregion

        #region private void ReferenceButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
        
        private void ReferenceButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            //e.TypeOfReflection = ReflectionTypes.DisplayFewPages;

            //TemplateAircraftAddToDataBaseForm form =
            //    new TemplateAircraftAddToDataBaseForm(GlobalObjects.CasEnvironment.Operators[0]);
            //DialogResult formResult = form.ShowDialog();

            //if (formResult == DialogResult.OK)
            //{
            //    _itemsCollection.Add(form.TransferedAircraft);
            //    FillUiElementsFromCollection();

            //    e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            //    e.DisplayerText = form.TransferedAircraft.RegistrationNumber;
            //    //e.RequestedEntity = new DispatcheredAircraftScreen(form.TransferedAircraft);
            //    e.RequestedEntity = new AircraftScreen(form.TransferedAircraft);
            //}
            //else
            //{
            //    e.Cancel = true;
            //}

            //StoreForm form = new StoreForm(GlobalObjects.CasEnvironment.Operators[0]);
            CommonEditorForm form = new CommonEditorForm(new Vehicle
            {
                Operator = GlobalObjects.CasEnvironment.Operators[0],
                OperatorId = GlobalObjects.CasEnvironment.Operators[0].ItemId
            });
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.CurrentObject as Vehicle == null)
                {
                    e.Cancel = true;
                    return;
                }
                Vehicle s = form.CurrentObject as Vehicle;

                _itemsCollection.Add(s);
                FillUiElementsFromCollection();

                e.Cancel = true;

                //e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                //e.DisplayerText = s.Name;
                //e.RequestedEntity = new StoreScreen(s);
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            CommonCollection<Vehicle> vehicles = new CommonCollection<Vehicle>();
            foreach (ReferenceStatusImageLinkLabel item in _controlItems)
            {
                vehicles.Add((Vehicle)item.Tag);
            }
            CommonDeletingForm cdf = new CommonDeletingForm(typeof(Vehicle), vehicles);
            if (cdf.ShowDialog() == DialogResult.OK)
            {
                if (cdf.DeletedObjects.Count == 0)
                {
                    return;
                }

                foreach (BaseEntityObject o in cdf.DeletedObjects)
                {
                    Vehicle s = o as Vehicle;
                    if (s != null) _itemsCollection.Remove(s);
                }
                FillUiElementsFromCollection();
            }
        }
        #endregion

        #region private void ExtendableRichContainerExtending(object sender, EventArgs e)
        private void ExtendableRichContainerExtending(object sender, EventArgs e)
        {
            flowLayoutPanelAircrafts.Visible = extendableRichContainer.Extended;
        }
        #endregion

        #endregion

        #region Events
        /// <summary>
        /// Событие оповещающее о начале работы в другом потоке
        /// </summary>
        public event EventHandler TaskStart;

        /// <summary>
        /// Событие оповещающее о конце работы в другом потоке
        /// </summary>
        public event EventHandler TaskEnd;

        #endregion
    }
}
