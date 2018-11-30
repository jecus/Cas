using System;
using System.Windows.Forms;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Store;

namespace CAS.UI.UIControls.ComponentControls
{
    /// <summary>
    /// Форма для добавления новой детали
    /// </summary>
    public partial class ComponentAddingScreen : ScreenControl
    {
        #region Fields

        private BaseComponent _parentBaseComponent;
        private Component _addedComponent;
        private readonly bool _isStore;
        private readonly BaseEntityObject _destinationObject;

        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        private ComponentAddingScreen()
        {
            InitializeComponent();
        }

        ///<summary>
        /// Конструктор, созжающий элемент для привязки детали к определенному родителю
        ///</summary>
        ///<param name="parent">Родитель добавляемого компонента</param>
        ///<exception cref="ArgumentNullException"></exception>
        public ComponentAddingScreen(BaseEntityObject parent) : this()
        {
            if (parent == null)
                throw new ArgumentNullException("parent");

            _addedComponent = new Component { ManufactureDate = DateTime.Today };
            _destinationObject = parent;

            if (parent is BaseComponent)
            {
                _parentBaseComponent = (BaseComponent)parent;
	            var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_parentBaseComponent.ParentAircraftId);
                CurrentAircraft = parentAircraft;
				_addedComponent.ParentBaseComponent = _parentBaseComponent;
                _addedComponent.ParentAircraftId = parentAircraft.ItemId;
	            _addedComponent.LLPCategories = _parentBaseComponent.LLPCategories;
            }
            else if (parent is Aircraft)
            {
                _parentBaseComponent = GlobalObjects.ComponentCore.GetBaseComponentById(((Aircraft)parent).AircraftFrameId);
                CurrentAircraft = (Aircraft) parent;
                _addedComponent.ParentBaseComponent = _parentBaseComponent;
				_addedComponent.ParentAircraftId = ((Aircraft)parent).ItemId;
            }
            else if (parent is Store)
            {
                extendableRichContainerBaseDetail.Visible = false;
                _addedComponent.ParentBaseComponent = null;
                CurrentStore = (Store) parent;
                _isStore = true;
            }
            else if (parent is Operator)
            {
                extendableRichContainerBaseDetail.Visible = false;
                _addedComponent.ParentBaseComponent = null;
                _addedComponent.ParentOperator = (Operator)parent;
                aircraftHeaderControl1.Operator = (Operator)parent;
                _isStore = true;
            }

            UpdateInformation();
        }
        #endregion

        #region

        #region public override void DisposeScreen()
        public override void DisposeScreen()
        {
            GeneralInformationControl.Dispose();

            CompliancePerformanceListControl.CancelAsync();

            Dispose(true);
        }
        #endregion

        #region public override void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public override void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
			if (_addedComponent != null && _addedComponent.ItemId <= 0 && GeneralInformationControl.GetChangeStatus())
            {
	            switch (MessageBox.Show("Do you want to save changes?", (string)new GlobalTermsProvider()["SystemName"],
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes:
		                string message;
		                if (!ValidateData(out message))
		                {
							message += "\nAbort operation";
							MessageBox.Show(message, new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							arguments.Cancel = true;
						}
		                else
		                {
			                AddNewDetail();
		                }
						break;
                    case DialogResult.Cancel:
                        arguments.Cancel = true;
                        break;
                }
            }
            base.OnDisplayerRemoving(arguments);
        }

        #endregion

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            if (_parentBaseComponent != null)
                addNewComponentControl1.CurrentParent = _parentBaseComponent;

            GeneralInformationControl.AddedComponent = _addedComponent;
            GeneralInformationControl.ParentObject = _destinationObject;
	        if (_parentBaseComponent != null)
				GeneralInformationControl.UpdateComponentClass(_parentBaseComponent);
            CompliancePerformanceListControl.CurrentComponent = _addedComponent;
        }
		#endregion

		private void AddNewComponentControl1OnCheckedChanged(object sender, EventArgs eventArgs)
		{
			GeneralInformationControl.UpdateComponentClass(sender as BaseComponent);
		}

		#region private void HeaderControlSaveButtonDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void HeaderControlSaveButtonDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
        {
	        try
	        {
				string message;
				if (!ValidateData(out message))
				{
					message += "\nAbort operation";
					MessageBox.Show(message, new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					e.Cancel = true;
					return;
				}

				AddNewDetail();
				var dp = ScreenAndFormManager.GetComponentScreen(_addedComponent);
		        e.SetParameters(dp);
		        e.TypeOfReflection = ReflectionTypes.DisplayInNewWithCloseCurrent;
	        }
	        catch (Exception ex)
	        {
				Program.Provider.Logger.Log("Error while saving data", ex);
				e.Cancel = true;
			}
        }
        #endregion

        #region private void HeaderControlSaveButton2Click(object sender, System.EventArgs e)

        private void HeaderControlSaveButton2Click(object sender, EventArgs e)
        {
	        try
	        {
				string message;
				if (!ValidateData(out message))
				{
					message += "\nAbort operation";
					MessageBox.Show(message, new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}

				AddNewDetail();
		        if (MessageBox.Show("Component added successfully" + "\nClear Fields before add new component?",
			        new GlobalTermsProvider()["SystemName"].ToString(),
			        MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
		        {
					ClearFields();
		        }
				_addedComponent = new Component { ManufactureDate = DateTime.Today };
			}
	        catch (Exception ex)
	        {
				Program.Provider.Logger.Log("Error while saving data", ex);
			}
            
        }
		#endregion

		#region private bool ValidateData(out string message)

		private bool ValidateData(out string message)
	    {
		    message = "";
		    if (!_isStore && addNewComponentControl1.BaseComponentAddTo == null)
			    message += "Please choose base component";

		    if (GeneralInformationControl.PartNumber == "")
			    GetMessage(ref message, "Part Number");
		    if (GeneralInformationControl.SerialNumber == "" && GeneralInformationControl.BatchNumber == "")
			    GetMessage(ref message, "Serial or Batch Number");
		    if (GeneralInformationControl.ATAChapter == null || GeneralInformationControl.ATAChapter.ItemId <= 0)
			    GetMessage(ref message, "ATA Chapter");
		    if (GeneralInformationControl.InstallationDate > DateTime.Now)
			    GetMessage(ref message, "Installation date must be less than current date");
		    if (GeneralInformationControl.ManufactureDate > DateTime.Now)
			    GetMessage(ref message, "Manufacture date must be less than current date");
		    if (GeneralInformationControl.ManufactureDate > GeneralInformationControl.InstallationDate)
			    GetMessage(ref message, "Manufacture date must be less than Installation date");

		    return string.IsNullOrEmpty(message);
	    }

		#endregion

		#region private void AddNewDetail()

		private void AddNewDetail()
		{
			GeneralInformationControl.ApplyChanges(_addedComponent);
			CompliancePerformanceListControl.ApplyChanges(_addedComponent);

            if (_isStore)
            {
                if(_destinationObject is Store)
                    GlobalObjects.ComponentCore.AddComponent(_addedComponent, (Store)_destinationObject, 
                                                                          GeneralInformationControl.InstallationDate,
                                                                          GeneralInformationControl.Position, GeneralInformationControl.State, GeneralInformationControl.ComponentTCSNOnInstall,
																		  GeneralInformationControl.ComponentCurrentTSNCSN, GeneralInformationControl.DateAsOf, true);
                if (_destinationObject is Operator)
                    GlobalObjects.ComponentCore.AddComponent(_addedComponent, (Operator)_destinationObject,
                                                                          GeneralInformationControl.InstallationDate,
                                                                          GeneralInformationControl.Position, GeneralInformationControl.State, GeneralInformationControl.ComponentTCSNOnInstall,
																		  GeneralInformationControl.ComponentCurrentTSNCSN, GeneralInformationControl.DateAsOf, true);
            }
            else
            {
                _parentBaseComponent = addNewComponentControl1.BaseComponentAddTo;
                GlobalObjects.ComponentCore.AddComponent(_addedComponent, _parentBaseComponent, GeneralInformationControl.InstallationDate,
                                                                      GeneralInformationControl.Position, GeneralInformationControl.State, GeneralInformationControl.ComponentTCSNOnInstall, 
																	  GeneralInformationControl.ComponentCurrentTSNCSN, GeneralInformationControl.DateAsOf,
																	  true);
            }
        }

        #endregion

        #region private static void GetMessage(ref string message, string field)
        /// <summary>
        /// Метод, предназначенный для формирования сообщения для MessageBox
        /// </summary>
        private static void GetMessage(ref string message, string field)
        {
            if (message == "")
                message += "Please fill " + field;
            else if (message == "Please choose base component")
                message += " and fill " + field;
            else
                message += ", " + field;
        }

        #endregion

        #region private void ClearFields()

        private void ClearFields()
        {
            GeneralInformationControl.ClearFields();
            CompliancePerformanceListControl.ClearFields();
        }
        #endregion

        #region private void GeneralInformationControlLLPMarkChecked(object sender, EventArgs e)
        private void GeneralInformationControlLLPMarkChecked(object sender, EventArgs e)
        {
            CompliancePerformanceListControl.UpdateInformation();
        }
        #endregion

        #region private void GeneralDataAndPerformanceControlComponentTypeChanged(Auxiliary.Events.ValueChangedEventArgs e)
        private void GeneralDataAndPerformanceControlComponentTypeChanged(Auxiliary.Events.ValueChangedEventArgs e)
        {
            CompliancePerformanceListControl.ChangeDirectivesTasksForComponentType(e.Value as GoodsClass ?? GoodsClass.Unknown);
        }
        #endregion

        #region private void GeneralInformationControlManufactureDateChanged(Auxiliary.Events.DateChangedEventArgs e)
        private void GeneralInformationControlManufactureDateChanged(Auxiliary.Events.DateChangedEventArgs e)
        {
            CompliancePerformanceListControl.ComponentManufactureDateChanged(e.Date);
        }
        #endregion

        #endregion
    }
}
