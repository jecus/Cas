using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.Types;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftsControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.BiWeekliesControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.StoresControls;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.TemplatesControls;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.StoresControls;
using CAS.UI.UIControls.TemplatesControls.Forms;
using CASReports.Builders;
using Controls;
using Controls.AvButtonT;
using CAS.Core.Core.Interfaces;
using CAS.UI.Appearance;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls.OpepatorsControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.OpepatorsControls;
using CAS.UI.UIControls.ReferenceControls;
using CAS.Core.ProjectTerms;
using Controls.AvMultitabControl.Auxiliary;

namespace CAS.UI.UIControls.AircraftsControls
{
    /// <summary>
    /// Отображает список ВС, относящихся к заданному эксплуатанту
    /// </summary>
    [ToolboxItem(true)]
    public class AircraftCollectionScreen : Control
    {

        #region Fields

        private DispatcheredMultitabControl dispatcheredMultitabControl;

        private AnimatedThreadWorker animatedThreadWorker;
        private AnimatedThreadWorker animatedStoresLoader;

        /// <summary>
        /// Текущий эксплуатант
        /// </summary>
        protected Operator currentOperator;

        private AircraftCollectionControl aircrafts;
        private StoreCollectionControl stores;

        private ReferenceStatusImageLinkLabel biWeeklyReportsReference;
        private OperatorInfoReference operatorInfoReference;
        private ReferenceStatusImageLinkLabel templatesReference;

        
        //private FlowLayoutPanel flowLayoutPanelRight;
        private FooterControl footerControl;
        private HeaderControl headerControl;
        private Panel mainPanel;
        private OperatorHeaderControl operatorHeaderControl;

        private readonly Icons icons = new Icons();
        private RichReferenceButton buttonAddAircraft;
        private AvButtonT buttonAddStore;
        private RichReferenceButton buttonDeleteOperator;
        private const int LEFT_COLUMN_WIDTH = 400;
        private const int BUTTON_BOTTOM_MARGIN = 10;
        private ReferenceStatusImageLinkLabel linkStock;
        private ReferenceStatusImageLinkLabel linkReport;
        //private const int AIRCRAFTS_PANEL_MAX_HEIGHT = 450;
        //private const int AIRCRAFTS_PANEL_MAX_HEIGHT = 550;

        #endregion

        #region Constructor

        #region public AircraftCollectionScreen(Operator currentOperator)

        ///<summary>
        /// Создается элемент отображения оператора
        ///</summary>
        ///<param name="currentOperator">Оператор для отображения</param>
        ///<exception cref="ArgumentNullException"></exception>
        public AircraftCollectionScreen(Operator currentOperator)
        {
            if (currentOperator == null)
                throw new ArgumentNullException("currentOperator", "Cannot display Null operator");

            this.currentOperator = currentOperator;
            InitializeComponent();
            UpdateElements(false);
        }

        #endregion

        #endregion

        #region Methods

        #region private void Reference_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void Reference_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.Cancel = true;
        }

        #endregion

        #region private void InitializeComponent()

        private void InitializeComponent()
        {
            ((DispatcheredAircraftCollectionScreen)this).InitComplition += AircraftCollectionScreen_InitComplition;
            mainPanel = new Panel();
            biWeeklyReportsReference = new ReferenceStatusImageLinkLabel();
            operatorInfoReference = new OperatorInfoReference(currentOperator);
            headerControl = new HeaderControl();
            operatorHeaderControl = new OperatorHeaderControl(currentOperator);
            footerControl = new FooterControl();
            templatesReference = new ReferenceStatusImageLinkLabel();
            buttonAddAircraft = new RichReferenceButton();
            buttonAddStore = new AvButtonT();
            buttonDeleteOperator = new RichReferenceButton();
            aircrafts = new AircraftCollectionControl(currentOperator.Aircrafts);
            stores = new StoreCollectionControl(currentOperator.Stores);
            linkStock = new ReferenceStatusImageLinkLabel();
            linkReport = new ReferenceStatusImageLinkLabel();
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 58);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1000, 547);
            mainPanel.TabIndex = 11;
            mainPanel.AutoScroll = true;
            mainPanel.SizeChanged += mainPanel_SizeChanged;
            // 
            // operatorInfoReference
            // 
            operatorInfoReference.Location = new Point(0, 20);
            // 
            // biWeeklyReportsReference
            // 
            biWeeklyReportsReference.Location = new Point(0,200);
            biWeeklyReportsReference.Text = "BiWeekly Reports";
            biWeeklyReportsReference.Enabled = true;
            biWeeklyReportsReference.ReflectionType = ReflectionTypes.DisplayInNew;
            biWeeklyReportsReference.DisplayerRequested += biWeeklyReportsReference_DisplayerRequested;
            Css.ImageLink.Adjust(biWeeklyReportsReference);
            //
            // templatesReference
            //
            templatesReference.Location = new Point(0, 225);
            templatesReference.Text = "Templates";
            templatesReference.Enabled = true;
            templatesReference.ReflectionType = ReflectionTypes.DisplayInNew;
            templatesReference.DisplayerRequested += templatesReference_DisplayerRequested;
            Css.ImageLink.Adjust(templatesReference);
             // 
            // headerControl
            // 
            headerControl.Controls.Add(operatorHeaderControl);
            if (currentOperator.HasPermission(Users.CurrentUser, DataEvent.Update))
            {
                headerControl.ActionControl.ButtonEdit.TextMain = "Edit";
                headerControl.ActionControl.ButtonEdit.Icon = icons.Edit;
                headerControl.ActionControl.ButtonEdit.IconNotEnabled = icons.EditGray;
            }
            else
            {
                headerControl.ActionControl.ButtonEdit.TextMain = "View";
                headerControl.ActionControl.ButtonEdit.Icon = icons.View;
            }
            headerControl.ActionControl.ButtonEdit.DisplayerText = currentOperator.Name + ". Summary";
            headerControl.EditDisplayerRequested += headerControl_EditDisplayerRequested;
            headerControl.ReloadRised += headerControl_ReloadRised;
            headerControl.ContextActionControl.ButtonHelp.TopicID = "aircrafts_of_the_operator";
            // 
            // footerControl
            // 
            footerControl.AutoSize = true;
            footerControl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            footerControl.BackColor = Color.Transparent;
            footerControl.Dock = DockStyle.Bottom;
            footerControl.Margin = new Padding(0);
            footerControl.Name = "footerControl";
            footerControl.TabIndex = 113;
            //
            // aircrafts
            //
            aircrafts.Location = new Point(LEFT_COLUMN_WIDTH, 0);
            aircrafts.TaskStart += aircrafts_TaskStart;
            aircrafts.TaskEnd += aircrafts_TaskEnd;
            aircrafts.SizeChanged += aircrafts_SizeChanged;
            aircrafts.AutoSizeMode=AutoSizeMode.GrowAndShrink;
            //
            // buttonAddAircraft
            //
            buttonAddAircraft.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddAircraft.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddAircraft.Icon = icons.Add;
            buttonAddAircraft.IconNotEnabled = icons.AddGray;
            buttonAddAircraft.Width = 200;
            buttonAddAircraft.TextMain = "Add Aircraft";
            buttonAddAircraft.DisplayerRequested += buttonAddAircraft_DisplayerRequested;
            buttonAddAircraft.Enabled = (currentOperator.AircraftCollection.HasPermission(Users.CurrentUser, DataEvent.Create));
            //
            // stores
            //
            stores.Location = new Point(aircrafts.Right, 0);
            stores.TaskStart += stores_TaskStart;
            stores.TaskEnd += stores_TaskEnd;
            stores.Location = new Point(LEFT_COLUMN_WIDTH + aircrafts.DefaultWidth, 0);
            stores.SizeChanged += stores_SizeChanged;
            stores.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //
            // buttonAddStore
            //
            buttonAddStore.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAddStore.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAddStore.Icon = icons.Add;
            buttonAddStore.IconNotEnabled = icons.AddGray;
            buttonAddStore.Location = new Point(buttonAddAircraft.Right, stores.Bottom);
            buttonAddStore.Width = 200;
            buttonAddStore.TextMain = "Add Store";
            buttonAddStore.Click += buttonAddStore_Click;
            buttonAddStore.Enabled = (currentOperator.AircraftCollection.HasPermission(Users.CurrentUser, DataEvent.Create)); //todo если что            
            // 
            // buttonDeleteOperator
            // 
            buttonDeleteOperator.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteOperator.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDeleteOperator.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteOperator.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDeleteOperator.Icon = icons.Delete;
            buttonDeleteOperator.IconNotEnabled = icons.DeleteGray;
            buttonDeleteOperator.IconLayout = ImageLayout.Center;
            buttonDeleteOperator.PaddingMain = new Padding(3, 0, 0, 0);
            buttonDeleteOperator.ReflectionType = ReflectionTypes.CloseSelected;
            buttonDeleteOperator.Size = new Size(140, 50);
            buttonDeleteOperator.TabIndex = 16;
            buttonDeleteOperator.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonDeleteOperator.TextAlignSecondary = ContentAlignment.TopLeft;
            buttonDeleteOperator.TextMain = "Delete";
            buttonDeleteOperator.TextSecondary = "operator";
            buttonDeleteOperator.DisplayerRequested += buttonDeleteOperator_DisplayerRequested;
            buttonDeleteOperator.Visible = (currentOperator.HasPermission(Users.CurrentUser, DataEvent.Remove));
            //
            // linkStock
            //
            linkStock.Text = "Stock General Report";
            linkStock.Enabled = true;
            linkStock.Status = Statuses.NotActive;
            linkStock.ReflectionType = ReflectionTypes.DisplayInNew;
            linkStock.DisplayerRequested += linkStock_DisplayerRequested;
            Css.ImageLink.Adjust(linkStock);
            //
            // linkReport
            //
            linkReport.Text = "Air Fleet Brief Report";
            linkReport.Enabled = true;
            linkReport.Status = Statuses.NotActive;
            linkReport.ReflectionType = ReflectionTypes.DisplayInNew;
            linkReport.DisplayerRequested += linkReport_DisplayerRequested;
            Css.ImageLink.Adjust(linkReport);
            // 
            // AircraftCollectionScreen
            // 
            BackColor = Css.CommonAppearance.Colors.BackColor;
            mainPanel.Controls.Add(operatorInfoReference);
            mainPanel.Controls.Add(biWeeklyReportsReference);
            mainPanel.Controls.Add(templatesReference);

            mainPanel.Controls.Add(buttonDeleteOperator);
            mainPanel.Controls.Add(linkStock);
            mainPanel.Controls.Add(linkReport);
            mainPanel.Controls.Add(buttonAddStore);
            mainPanel.Controls.Add(buttonAddAircraft);
            //mainPanel.Controls.Add(flowLayoutPanelRight);
            mainPanel.Controls.Add(stores);
            mainPanel.Controls.Add(aircrafts);

            Controls.Add(mainPanel);
            Controls.Add(headerControl);
            Controls.Add(footerControl);
        }
        #endregion

        #region private void templatesReference_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void templatesReference_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "Templates";
            e.RequestedEntity = new DispatcheredTemplateAircraftCollectionScreen();
        }

        #endregion
        
        #region private void biWeeklyReportsReference_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void biWeeklyReportsReference_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.DisplayerText = "BiWeekly Reports";
            e.RequestedEntity = new DispatcheredBiWeekliesCollectionScreen();
        }

        #endregion
        
        #region private void aircrafts_SizeChanged(object sender, EventArgs e)

        private void aircrafts_SizeChanged(object sender, EventArgs e)
        {
            linkReport.Location = new Point(aircrafts.Left+5, aircrafts.Bottom);
        }

        #endregion

        #region private void stores_SizeChanged(object sender, EventArgs e)

        private void stores_SizeChanged(object sender, EventArgs e)
        {
            linkStock.Location = new Point(stores.Left+5, stores.Bottom);
        }

        #endregion

        #region private void mainPanel_SizeChanged(object sender, EventArgs e)

        private void mainPanel_SizeChanged(object sender, EventArgs e)
        {
            buttonAddAircraft.Location = new Point(0, mainPanel.Bottom - footerControl.Height - buttonAddAircraft.Height - BUTTON_BOTTOM_MARGIN);
            buttonAddStore.Location = new Point(buttonAddAircraft.Right, mainPanel.Bottom - footerControl.Height - buttonAddAircraft.Height - BUTTON_BOTTOM_MARGIN);
            buttonDeleteOperator.Location = new Point(mainPanel.Right - buttonDeleteOperator.Width, mainPanel.Bottom - footerControl.Height - buttonAddAircraft.Height - BUTTON_BOTTOM_MARGIN);
        }

        #endregion

        #region private void headerControl_EditDisplayerRequested(object sender, ReferenceEventArgs e)

        private void headerControl_EditDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.RequestedEntity = new DispatcheredOperatorScreen(currentOperator);
        }

        #endregion

        #region private void headerControl_ReloadRised(object sender, EventArgs e)

        private void headerControl_ReloadRised(object sender, EventArgs e)
        {
            UpdateElements();
        }

        #endregion

        #region private void UpdateElements()

        private void UpdateElements()
        {
            UpdateElements(true);
        }

        #endregion

        #region private void UpdateElements(bool reloadOperator)

        private void UpdateElements(bool reloadOperator)
        {

            if (reloadOperator)
            {
                currentOperator.Reloaded -= currentOperator_Reloaded;

                dispatcheredMultitabControl.SetEnabledToAllEntityes(false);
                animatedThreadWorker = new AnimatedThreadWorker(BackgroundReloadAircrafts,this);
                animatedThreadWorker.State = "Reciving data";
                animatedThreadWorker.WorkFinished += animatedThreadWorker_WorkFinished;
                animatedThreadWorker.StartThread();
            }
            else 
                FinishedUpdateAircrafts();
        }

        #endregion

        #region void animatedThreadWorker_WorkFinished(object sender, EventArgs e)

        void animatedThreadWorker_WorkFinished(object sender, EventArgs e)
        {
            FinishedUpdateAircrafts();
            dispatcheredMultitabControl.SetEnabledToAllEntityes(true);
            currentOperator.Reloaded += currentOperator_Reloaded;

        }

        #endregion
        
        #region private void BackgroundReloadAircrafts()

        private void BackgroundReloadAircrafts()
        {
            try
            {
                currentOperator.Reload(true);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }
        }

        #endregion
        
        #region private void FinishedUpdateAircrafts()

        private void FinishedUpdateAircrafts()
        {
            operatorHeaderControl.Operator = currentOperator;
            operatorInfoReference.UpdateDataForOperator();
            aircrafts.ReloadItems();
            stores.ReloadItems(); 
        }

        #endregion

        #region private void buttonAddAircraft_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonAddAircraft_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayFewPages;

            TemplateAircraftAddToDataBaseForm form = new TemplateAircraftAddToDataBaseForm();
            DialogResult formResult = form.ShowDialog();

            if (formResult == DialogResult.OK)
            {
                if (form.ScreensToOpening == ScreensToOpening.OpenAircraftScreen)
                {
                    e.RequestedDisplayingObject = new DisplayingObject[]
                        {
                            new DisplayingObject(new DispatcheredAircraftCollectionScreen(form.Operator),
                                                 form.Operator.Name),
                            new DisplayingObject(new DispatcheredAircraftScreen(form.TransferedAircraft),
                                                 form.Operator.Name + ". " + form.TransferedAircraft.RegistrationNumber)
                        };
                }
                else if (form.ScreensToOpening == ScreensToOpening.EditAircraftGeneralData)
                {
                    e.RequestedDisplayingObject = new DisplayingObject[]
                        {
                            new DisplayingObject(new DispatcheredAircraftCollectionScreen(form.Operator),
                                                 form.Operator.Name),
                            new DisplayingObject(new DispatcheredAircraftScreen(form.TransferedAircraft),
                                                 form.Operator.Name + ". " + form.TransferedAircraft.RegistrationNumber),
                            new DisplayingObject(new DispatcheredAircraftGeneralDataScreen(form.TransferedAircraft),
                                                 form.TransferedAircraft.RegistrationNumber + ". Aircraft General Data")
                        };
                }
                else 
                {
                    e.Cancel = true;
                }
                aircrafts.FillUIElementsFromCollection();
            } 
            else
            {
                e.Cancel = true;
            }
            
        }


        #endregion

        #region private void linkStock_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkStock_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (animatedStoresLoader == null)
            {
                dispatcheredMultitabControl.SetEnabledToAllEntityes(false);
                e.Cancel = true;

                animatedStoresLoader = new AnimatedThreadWorker(
                    delegate
                    {
                        Program.Presenters.StoresPresenter.LoadAllStoresForOperator(currentOperator);
                    },
                    this);
                animatedStoresLoader.State = "Loading Stock";
                animatedStoresLoader.WorkFinished += 
                    delegate
                    {
                        dispatcheredMultitabControl.SetEnabledToAllEntityes(true);
                        linkStock.DisplayRequested();
                    };
                animatedStoresLoader.StartThread();
            }
            else
            {
                e.DisplayerText = String.Format("{0}. Stock", currentOperator.Name);
                e.RequestedEntity = new DispatcheredStoreScreen(currentOperator);
            }
        }

        #endregion


        #region private void linkReport_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void linkReport_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.DisplayerText = "Air International. Air Fleet.";
            e.RequestedEntity = new DispatcheredAirFleetReport(new AirFleetBuilder(aircrafts.Collection));
        }

        #endregion

        #region private void buttonAddStore_Click(object sender, EventArgs e)

        private void buttonAddStore_Click(object sender, EventArgs e)
        {
            StoreForm form = new StoreForm(currentOperator);
            if (form.ShowDialog() == DialogResult.OK)
            {
                stores.FillUIElementsFromCollection();
            }
        }

        #endregion
        
        #region private void buttonDeleteOperator_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void buttonDeleteOperator_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to delete current operator?",
                    "Confirm deleting " + currentOperator.Name, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                try
                {
                    OperatorCollection.Instance.Remove(currentOperator);
                    MessageBox.Show("Operator was deleted successfully", (string)new TermsProvider()["SystemName"],
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex);
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region private void AircraftCollection_Changed(object sender, EventArgs e)

        private void AircraftCollection_Changed(object sender, EventArgs e)
        {
            UpdateElements(false);
        }

        #endregion

        #region private void SetEnabled(bool isEnabled)

        protected virtual void SetEnabledToControls(bool isEnabled)
        {
            aircrafts.SetEnabledToAircraftButtons(isEnabled);
            stores.SetEnabledToAircraftButtons(isEnabled);
            biWeeklyReportsReference.Enabled = isEnabled;
            operatorInfoReference.Enabled = isEnabled;
            templatesReference.Enabled = isEnabled;
            buttonAddAircraft.Enabled = isEnabled;
            buttonAddStore.Enabled = isEnabled;
            linkStock.Enabled = isEnabled;
            linkReport.Enabled = isEnabled;
            buttonDeleteOperator.Enabled = isEnabled;
            headerControl.ActionControl.ButtonReload.Enabled = isEnabled;
            headerControl.ActionControl.ButtonEdit.Enabled = isEnabled;
            headerControl.ContextActionControl.ButtonClose.Enabled = isEnabled;
            headerControl.ContextActionControl.ButtonHelp.Enabled = isEnabled;
            operatorHeaderControl.PreviousButton.Enabled = isEnabled;
            operatorHeaderControl.NextButton.Enabled = isEnabled;
        }

        #endregion

        #region void aircrafts_TaskEnd(object sender, EventArgs e)

        void aircrafts_TaskEnd(object sender, EventArgs e)
        {
            dispatcheredMultitabControl.SetEnabledToAllEntityes(true);
        }

        #endregion

        #region void aircrafts_TaskStart(object sender, EventArgs e)

        void aircrafts_TaskStart(object sender, EventArgs e)
        {
            dispatcheredMultitabControl.SetEnabledToAllEntityes(false);
        }

        #endregion

        #region void AircraftCollectionScreen_InitComplition(object sender, EventArgs e)

        void AircraftCollectionScreen_InitComplition(object sender, EventArgs e)
        {
            dispatcheredMultitabControl = (DispatcheredMultitabControl) sender;
            dispatcheredMultitabControl.Closed += dispatcheredMultitabControl_Closed;
            currentOperator.Reloaded -= currentOperator_Reloaded;
            currentOperator.Reloaded += currentOperator_Reloaded;
        }


        #endregion

        #region private void stores_TaskEnd(object sender, EventArgs e)

        private void stores_TaskEnd(object sender, EventArgs e)
        {
            dispatcheredMultitabControl.SetEnabledToAllEntityes(true);
        }

        #endregion
        
        #region private void stores_TaskStart(object sender, EventArgs e)

        private void stores_TaskStart(object sender, EventArgs e)
        {
            dispatcheredMultitabControl.SetEnabledToAllEntityes(false);
        }

        #endregion

        #region void currentOperator_Reloaded(object sender, EventArgs e)

        void currentOperator_Reloaded(object sender, EventArgs e)
        {
            if (InvokeRequired) Invoke(new InvokeRequiredDelegate(FinishedUpdateAircrafts));
        }

        #endregion

        #region void dispatcheredMultitabControl_Closed(object sender, AvMultitabControlEventArgs e)

        void dispatcheredMultitabControl_Closed(object sender, AvMultitabControlEventArgs e)
        {
            if (e.TabPage == Parent)
                currentOperator.Reloaded -= currentOperator_Reloaded;

        }

        #endregion


        private delegate void InvokeRequiredDelegate();
        #endregion


    }
}