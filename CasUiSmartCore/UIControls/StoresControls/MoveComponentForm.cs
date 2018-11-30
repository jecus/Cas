using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary.DataGridViewElements;
using CASTerms;
using EFCore.DTO.General;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.StoresControls
{
    /// <summary>
    /// Форма для установки агрегата со склада на ВС
    /// </summary>
    public partial class MoveComponentForm : Form
    {
        #region Fields

        private Aircraft[] _aircrafts;
        private Store[] _stores;
        private Store _currentStore; //Склад, из которого была открыта данная форма _currentAircraft = null
        private Aircraft _currentAircraft;//Самолет, из которого была открыта форма _currentStore = null

        private object _currentDetail;
        private Component[] _currentComponentsList;
        private List<BaseComponent> _currentBaseDetailsList;

        private WorkPackage _currentWorkPackage;//ссылка на рбочий пакет, если перемещение осуществляется в рамках его выполнения
        #endregion

        #region Constructors

        #region private MoveDetailForm()

        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        private MoveComponentForm()
        {
            InitializeComponent();
        }

        #endregion

        #region public MoveDetailForm(Detail[] currentDetailsList, Store currentStore) : this ()
        ///<summary>
        ///</summary>
        ///<param name="currentComponentsList/param>
        ///<param name="currentStore"></param>
        public MoveComponentForm(Component[] currentComponentsList, Store currentStore) : this ()
        {
            _currentComponentsList = currentComponentsList;
            _currentStore = currentStore;
            _currentAircraft = null;
            _currentWorkPackage = null;
            
            UpdateInformation();
        }

		#endregion

		#region public MoveComponentForm(Component[] currentComponentsList, Store currentStore, WorkPackage wp)

		public MoveComponentForm(Component[] currentComponentsList, Store currentStore, WorkPackage wp) : this()
	    {
		    _currentComponentsList = currentComponentsList;
		    _currentStore = currentStore;
		    _currentAircraft = null;
		    _currentWorkPackage = wp;

		    textBoxRemarks.Text = $"Prepared by:{_currentWorkPackage.Title}";
		    UpdateInformation();
	    }

	    #endregion

		#region public MoveDetailForm(Detail[] currentDetailsList, Aircraft currentAircraft) : this ()
		///<summary>
		///</summary>
		///<param name="currentComponentsList/param>
		///<param name="currentAircraft"></param>
		public MoveComponentForm(Component[] currentComponentsList, Aircraft currentAircraft) : this ()
        {
            _currentComponentsList = currentComponentsList;
            _currentStore = null;
            _currentAircraft = currentAircraft;
            _currentWorkPackage = null;

            UpdateInformation();
        }

        #endregion

        #region public MoveDetailForm(Detail[] currentDetailsList, Aircraft currentAircraft, WorkPackage wp) : this ()
        ///<summary>
        ///</summary>
        ///<param name="currentComponentsList/param>
        ///<param name="currentAircraft"></param>
        ///<param name="wp"></param>
        public MoveComponentForm(Component[] currentComponentsList, Aircraft currentAircraft, WorkPackage wp) : this ()
        {
            _currentComponentsList = currentComponentsList;
            _currentStore = null;
            _currentAircraft = currentAircraft;
            _currentWorkPackage = wp;

            UpdateControl();
            UpdateInformation();
        }

        #endregion

        #endregion

        #region Properties
        
        #endregion

        #region Methods

        #region private List<DataGridViewRow> CheckedRows()
        private List<DataGridViewRow> CheckedRows()
        {
			return dataGridViewComponents.Rows.Cast<DataGridViewRow>()
											  .Where(row => row.Tag is Component &&
															row.Cells[0] is DataGridViewCheckBoxCell &&
															(bool)row.Cells[0].Value)
											  .ToList();
		}
        #endregion

        #region public TransferRecord GetTransferData()
        ///<summary>
        ///</summary>
        ///<returns></returns>
        public TransferRecord GetTransferData()
        {
            if (_currentWorkPackage == null) return null;
            var destinationBaseComponent = (BaseComponent)comboBoxBaseComponent.SelectedItem;
            var destinationStore = (Store)comboBoxStore.SelectedItem;

            var transferDate = dateTimePickerDate.Value;
            var remarks = textBoxRemarks.Text;

            TransferRecord transfer = null;

            foreach (DataGridViewRow row in dataGridViewComponents.Rows)
            {
                if (!(row.Tag is Component) || 
                    !(row.Cells[0] is DataGridViewCheckBoxCell) || 
                    !(bool)row.Cells[0].Value)
                    continue;

                DataGridViewNumericUpDownCell all = (DataGridViewNumericUpDownCell)row.Cells[2];
                DataGridViewNumericUpDownCell replace = (DataGridViewNumericUpDownCell)row.Cells[3];
                Component component = row.Tag as Component;
                transfer = new TransferRecord
                {
                    AttachedFile = fileControl.AttachedFile,
                    ParentComponent = component,
                    ParentId = component.ItemId,
                    FromAircraftId = component.ParentAircraftId,
                    FromStoreId = component.ParentStoreId,
                    TransferDate = transferDate,
                    StartTransferDate = transferDate,
                    Position = "",
                    BeforeReplace = ((double)all.Value) >= 1 ? (double)all.Value : 1,
                    Replaced = ((double)replace.Value) >= 1 ? (double)replace.Value : 1,
                    Remarks = remarks
                };

                if (component is BaseComponent)
                {
                    transfer.OnLifelength =
                        GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay((BaseComponent)component, transferDate);
                }
                else
                {
                    transfer.OnLifelength =
                        GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(component, transferDate);
                    transfer.FromBaseComponentId =
                        component.ParentBaseComponent != null
                            ? component.ParentBaseComponent.ItemId//TODO:(Evgenii Babak) заменить на использование ComponentCore 
							: 0;
                }
                if (radioButtonStore.Checked)
                {
                    transfer.DestinationObjectId = destinationStore.ItemId;
                    transfer.DestinationObjectType = destinationStore.SmartCoreObjectType;
                }
                else
                {
                    transfer.DestinationObjectId = destinationBaseComponent.ItemId;
                    transfer.DestinationObjectType = destinationBaseComponent.SmartCoreObjectType;
                }
            }
            return transfer;
        }

        #endregion

        #region private void UpdateControl()

        private void UpdateControl()
        {
            if(_currentWorkPackage != null)
            {
                fileControl.Visible = false;
                buttonApply.Visible = false;
            }
        }

        #endregion

        #region private void UpdateInformation()

        private void UpdateInformation()
        {

            //заполнение списка деталей, выбранных для перемещения
            if(_currentComponentsList == null || _currentComponentsList.Length == 0)
            {
                MessageBox.Show("Can't find selected details");
                return;
            }

	        var personnel = GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<SpecialistDTO, Specialist>();
			comboBoxReleased.Items.Clear();
			comboBoxReleased.Items.AddRange(personnel.ToArray());

			comboBoxRecived.Items.Clear();
			comboBoxRecived.Items.AddRange(personnel.ToArray());

			comboBoxReason.Items.Clear();
			comboBoxReason.Items.AddRange(InitialReason.Items.ToArray());
			dataGridViewComponents.Rows.Clear();

			comboBoxSupplier.Items.Clear();
			comboBoxSupplier.Items.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<SupplierDTO, Supplier>().ToArray());
	        comboBoxSupplier.SelectedIndex = 0;
	        comboBoxSupplier.Enabled = false;

	        comboBoxStaff.Items.Clear();
	        comboBoxStaff.Items.AddRange(personnel.ToArray());
	        comboBoxStaff.SelectedIndex = 0;
	        comboBoxStaff.Enabled = false;

			ReceiptDatedateTimePicker.Enabled = false;
			ReceiptDatedateTimePicker.Value = DateTime.Today;
	        NotifylifelengthViewer.Enabled = false;

			foreach (Component detail in _currentComponentsList)
            {
                var row = new DataGridViewRow { Tag = detail };

	            double replacedValue;
	            if (_currentStore != null && _currentWorkPackage != null)
					replacedValue = detail.NeedWpQuantity;
	            else
		            replacedValue = detail.Quantity <= 1 ? 1 : detail.Quantity;

				DataGridViewCell compntCell = new DataGridViewCheckBoxCell { Value = false };
                DataGridViewCell descCell = new DataGridViewTextBoxCell { Value = detail.ToString() };
                DataGridViewCell all = new DataGridViewNumericUpDownCell
                                           {
                                               Minimum = ColumnAll.Minimum,
                                               Maximum = (decimal)(detail.Quantity <= 1 ? 1 : detail.Quantity),
                                               Value = detail.Quantity <= 1 ? 1 : detail.Quantity,
											   DecimalPlaces = 2
			};
                DataGridViewCell replace = new DataGridViewNumericUpDownCell
                                               {
                                                   Minimum = ColumnReplace.Minimum,
                                                   Maximum = (decimal)(detail.Quantity <= 1 ? 1 : detail.Quantity),
                                                   Value = replacedValue,
												   DecimalPlaces = 2
				};
                
                row.Cells.AddRange(compntCell, descCell, all, replace);
                
                descCell.ReadOnly = true;
                all.ReadOnly = true;
                replace.ReadOnly = detail.Quantity <= 1;

				dataGridViewComponents.Rows.Add(row);
            }

            _stores = GlobalObjects.CasEnvironment.Stores.ToArray();
            _aircrafts = GlobalObjects.AircraftsCore.GetAllAircrafts().ToArray();
            if(_stores.Length == 0 &&
               _aircrafts.Length == 0) return;
            
            //          заполнение списка складов        //
            ///////////////////////////////////////////////
            if (_currentStore != null)
            {
                if (_stores == null || _stores.Length == 0)
                {
                    MessageBox.Show("Can't find store list");
                    return;  
                }
                if (_stores.Length == 1)
                {
                    //в системе только один склад
                    radioButtonAircraft.Checked = true;
                    radioButtonAircraft.Enabled = false;
                    radioButtonStore.Enabled = false;
                }
                else
                {
                    comboBoxStore.Items.Clear();
                    foreach (Store store in _stores)
                        if (store.ItemId != _currentStore.ItemId)
                            comboBoxStore.Items.Add(store);
                    comboBoxStore.SelectedIndex = 0;
                }
            }
            else
            {
                if (_stores == null || _stores.Length == 0)
                {
                    radioButtonAircraft.Checked = true;
                    radioButtonAircraft.Enabled = false;
                    radioButtonStore.Enabled = false;
                }
                else
                {
                    comboBoxStore.Items.Clear();
                    comboBoxStore.Items.AddRange(_stores);
                    comboBoxStore.SelectedIndex = 0;
                }
            }
            //////////////////////////////////////////////

            //заполнение списка самолетов
            if(_currentAircraft != null)
            {
                if (_aircrafts == null || _aircrafts.Length == 0)
                {
                    MessageBox.Show("Can't find aircraft list");
                    return;
                }
                
                if (_stores != null && _stores.Length > 0)
                {
                    radioButtonStore.Enabled = true;
                    radioButtonAircraft.Enabled = true;
                }
                else
                {
                    radioButtonStore.Enabled = false;
                    radioButtonAircraft.Enabled = false;
                }

                comboBoxAircraft.Items.Clear();
                comboBoxAircraft.Items.AddRange(_aircrafts);
                comboBoxAircraft.SelectedIndex = 0;
			}
            else
            {
                if (_aircrafts == null || _aircrafts.Length == 0)
                {
                    radioButtonStore.Checked = true;
                    radioButtonStore.Enabled = false;
                    radioButtonAircraft.Enabled = false;   
                }
                else
                {
                    comboBoxAircraft.Items.Clear();
                    comboBoxAircraft.Items.AddRange(_aircrafts.ToArray());
                    comboBoxAircraft.SelectedIndex = 0;
                }
            }

            if (_aircrafts != null && _aircrafts.Length != 0)
            {
                //заполнение списка базовых деталей выбранного самолета
                _currentBaseDetailsList =
                    new List<BaseComponent>(
                        GlobalObjects.ComponentCore.GetAicraftBaseComponents(((Aircraft) comboBoxAircraft.SelectedItem).ItemId));

                if (_currentBaseDetailsList.Count == 0)
                {
                    MessageBox.Show("Can't find base detail list for aircraft " +
                                    ((Aircraft) comboBoxAircraft.SelectedItem).RegistrationNumber);
                    return;
                }

                //bool haveBaseDetailsToReplace = false;
                //for (int i = 0; i < _currentDetailsList.Length; i++)
                //{
                //    //имеется ли в списке базовая деталь
                //    if (_currentDetailsList[i] is BaseDetail)
                //    {
                //        haveBaseDetailsToReplace = true;
                //        break;
                //    }
                //}
                //if (haveBaseDetailsToReplace)
                //{
                //    comboBoxBaseDetail.Items.Clear();
                //    comboBoxBaseDetail.Items.Add("Replace to aircraft (base details only)");
                //    comboBoxBaseDetail.Items.AddRange(currentBaseDetailsList.ToArray());
                //    comboBoxBaseDetail.SelectedIndex = 1;  
                //}
                //else
                //{
                    comboBoxBaseComponent.Items.Clear();
                    comboBoxBaseComponent.Items.AddRange(_currentBaseDetailsList.ToArray());
                    comboBoxBaseComponent.SelectedIndex = 0;
                //}
            }
            else
            {
                comboBoxAircraft.Enabled = false;
                comboBoxBaseComponent.Enabled = false;
            }

            if (radioButtonStore.Checked)
            {
                comboBoxStore.Enabled = true;
                comboBoxAircraft.Enabled = false;
                comboBoxBaseComponent.Enabled = false;
            }
            else
            {
                comboBoxStore.Enabled = false;
                comboBoxAircraft.Enabled = true;
                comboBoxBaseComponent.Enabled = true;
            }

	        radioButtonStore.Checked = true;
        }

        #endregion

        #region public bool ValidateData()
        /// <summary>
        /// Производит проверку о наличии всех необходимых 
        /// условий для перемещения: Проверка наличия самолета,
        /// перемещаемых деталей и базовой детали на которую перемещается агрегат 
        /// </summary>
        private bool ValidateData()
        {
            List<DataGridViewRow> checkedItems = CheckedRows();

            if (checkedItems.Count == 0)
            {
                MessageBox.Show("You don't select a component(s)", "Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

	        if (comboBoxRecived.SelectedItem == null && comboBoxReleased.SelectedItem == null)
	        {
				MessageBox.Show("You don't select a released or reseaver", "Error",
			        MessageBoxButtons.OK, MessageBoxIcon.Error);
		        return false;
			}

            foreach (DataGridViewRow item in checkedItems)
            {
                Component d = item.Tag as Component;
                if (d != null && d.TransferRecords.GetLast().TransferDate > dateTimePickerDate.Value)
                {
                    MessageBox.Show("date of the new movement below the date of the last movement of" +
                                    "\n" + d,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					dateTimePickerDate.Value = d.TransferRecords.GetLast().TransferDate;
					return false;
                }
            }
            if (radioButtonStore.Checked)
            {
                if (comboBoxStore.SelectedItem == null)
                {
                    MessageBox.Show("You don't select a store", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                } 
            }
            else if (radioButtonAircraft.Checked)
			{
                if (comboBoxAircraft.SelectedItem == null)
                {
                    MessageBox.Show("You don't select a aircraft", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
		
                if (comboBoxBaseComponent.SelectedItem == null)
                {
                    MessageBox.Show("You don't select a base detail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
			else if (radioButtonStaff.Checked)
            {
	            if (comboBoxStaff.SelectedItem == null)
	            {
					MessageBox.Show("You don't select a staff", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		            return false;
				}
            }
            else if (radioButtonSupplier.Checked)
            {
	            if (comboBoxSupplier.SelectedItem == null)
	            {
		            MessageBox.Show("You don't select a supplier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		            return false;
	            }
            }
			return true;
        }

        #endregion

        #region public void DoTransfer()
        /// <summary>
        /// Производит перемещение заданных деталей на
        /// заданный склад или самолет и базовую делать на нем
        /// </summary>
        public void DoTransfer()
        {
            Aircraft destinationAircraft = (Aircraft)comboBoxAircraft.SelectedItem;
            BaseComponent destinationBaseComponent = (BaseComponent)comboBoxBaseComponent.SelectedItem;
            Store destinationStore = (Store)comboBoxStore.SelectedItem;
            int destinationSupplierId = 0;
            int destinationStaffId = 0;
	        AttachedFile transferRecordAttachedFile = null;

	        if (comboBoxSupplier.Enabled)
		        destinationSupplierId = ((Supplier) comboBoxSupplier.SelectedItem).ItemId;
			else if(comboBoxStaff.Enabled)
		        destinationStaffId = ((Specialist)comboBoxStaff.SelectedItem).ItemId;

			if (fileControl.GetChangeStatus())
			{
				fileControl.ApplyChanges();
				transferRecordAttachedFile = fileControl.AttachedFile;
			}

			DateTime transferDate = dateTimePickerDate.Value;
			DateTime receiptDate = ReceiptDatedateTimePicker.Value;
	        var notify = NotifylifelengthViewer.Lifelength;
	        var description = textBoxDescription.Text;
	        var reason = comboBoxReason.SelectedItem as InitialReason;
	        var released = comboBoxReleased.SelectedItem as Specialist;
	        var received = comboBoxRecived.SelectedItem as Specialist;
	        var remarks = textBoxRemarks.Text;

            var checkedItems = CheckedRows();
            foreach (DataGridViewRow t in checkedItems)
            {
                var allCell = (DataGridViewNumericUpDownCell)t.Cells[2];
                var replaceCell = (DataGridViewNumericUpDownCell)t.Cells[3];
                var d = t.Tag as Component;
                if(d == null)
                    continue;
                var all = Convert.ToDouble(allCell.Value);
                var replace = Convert.ToDouble(replaceCell.Value);
                if (radioButtonStore.Checked)
                {
                    if (d is BaseComponent)
                    {
	                    var baseComponent = d as BaseComponent;
	                    var baseComponentLlOnTransferDate = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(baseComponent, transferDate);
                        GlobalObjects.ComponentCore.
                            MoveToStore(baseComponent, destinationStore, transferDate, baseComponentLlOnTransferDate, description, reason, released, received, _currentWorkPackage, transferRecordAttachedFile);
                    }
                    else
                    {
	                    var replaced = replace >= 1 ? replace : 1;
	                    var beforeReplace = all >= 1 ? all : 1;
	                    Lifelength baseComponentLlOnTransferDate;

	                    if (beforeReplace != replaced)
							baseComponentLlOnTransferDate = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(new Component {Quantity =  replaced}, transferDate);
	                    else
							baseComponentLlOnTransferDate = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(d, transferDate);

						GlobalObjects.ComponentCore.MoveToStore(d, destinationStore, transferDate,
										beforeReplace,
										replaced, baseComponentLlOnTransferDate,
										description, remarks, reason, released, received,
										_currentWorkPackage, transferRecordAttachedFile);
                    }
                }
                else if(radioButtonAircraft.Checked)
                {
                    if (d is BaseComponent)
                    {
	                    var baseComponent = d as BaseComponent;
	                    var baseComponentLlOnTransferDate = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(baseComponent, transferDate);
                        GlobalObjects.ComponentCore.
                            MoveToAircraft(baseComponent, destinationAircraft, transferDate, baseComponentLlOnTransferDate, description, reason, released, received, _currentWorkPackage, transferRecordAttachedFile);
                    }
                    else
                    {
						var replaced = replace >= 1 ? replace : 1;
						var beforeReplace = all >= 1 ? all : 1;
						Lifelength baseDetailLlOnTransferDate;

						if (beforeReplace != replaced)
							baseDetailLlOnTransferDate = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(new Component { Quantity = replaced }, transferDate);
						else
							baseDetailLlOnTransferDate = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(d, transferDate);

						GlobalObjects.ComponentCore.
                            MoveToAircraft(d, destinationBaseComponent, destinationAircraft, transferDate,
										   beforeReplace,
										   replaced,
										   baseDetailLlOnTransferDate,
										   description, reason, released, received,
										   _currentWorkPackage,  transferRecordAttachedFile);
                    }
                }
				else if (radioButtonSupplier.Checked || radioButtonStaff.Checked)
                {
					if (d is BaseComponent)
					{
						//var baseComponent = d as BaseComponent;
						//var baseComponentLlOnTransferDate = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(baseComponent, transferDate);
						//GlobalObjects.ComponentCore.
						//	MoveToProcessing(baseComponent, destinationSupplier, transferDate, baseComponentLlOnTransferDate, description, reason, released, received, _currentWorkPackage, transferRecordAttachedFile);
					}
					else
					{
						var replaced = replace >= 1 ? replace : 1;
						var beforeReplace = all >= 1 ? all : 1;
						Lifelength baseComponentLlOnTransferDate;

						if (beforeReplace != replaced)
							baseComponentLlOnTransferDate = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(new Component { Quantity = replaced }, transferDate);
						else
							baseComponentLlOnTransferDate = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(d, transferDate);

						GlobalObjects.ComponentCore.MoveToProcessing(d, destinationSupplierId, destinationStaffId, transferDate,
							beforeReplace,
							replaced, baseComponentLlOnTransferDate,
							description, remarks, reason, released, received,
							_currentWorkPackage, transferRecordAttachedFile, receiptDate, notify);
					}
				}
				else if (radioButtonStaff.Checked)
                {
	                
                }
            }    
        }
        #endregion

        #region private void ButtonOkClick(object sender, EventArgs e)

        private void ButtonOkClick(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            if (_currentWorkPackage != null)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

	        if (_currentStore != null)
	        {
				var sb = new StringBuilder();
				var checkedItems = CheckedRows();
				var i = 1;

				foreach (DataGridViewRow t in checkedItems)
				{
					var component = t.Tag as Component;
					if (component.State != ComponentStorePosition.Serviceable)
						sb.AppendLine($"{i++}) {component} ({component.State})");
				}

				if (!string.IsNullOrEmpty(sb.ToString()))
				{
					MessageBox.Show($"{sb} \n Do select serviceable component!", (string)new GlobalTermsProvider()["SystemName"],
								 MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}

			DialogResult result = MessageBox.Show("Do you really want to replace component(s) to aircraft", "Warning",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {	
				DoTransfer();//производится перемещение

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        #endregion

        #region private void ButtonApplyClick(object sender, EventArgs e)

        private void ButtonApplyClick(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            DialogResult result = MessageBox.Show("Do you really want to replace component(s) to aircraft", "Warning",
                                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {

                DoTransfer();//производится перемещение

                //очищение списка выбранных деталей
                //т.е. тех, которые были перемещены в DoTransfer
                List<DataGridViewRow> checkedItems = CheckedRows();
                foreach (DataGridViewRow item in checkedItems)
                {
                    dataGridViewComponents.Rows.Remove(item);
                }

            }
        }
        #endregion

        #region private void ButtonCancelClick(object sender, EventArgs e)

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region private void ComboBoxAircraftSelectedIndexChanged(object sender, EventArgs e)

        private void ComboBoxAircraftSelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxBaseComponent.Items.Clear();

	        var aircraft = (Aircraft) comboBoxAircraft.SelectedItem;

	        if (aircraft != null)
	        {
		        _currentBaseDetailsList = new List<BaseComponent>(GlobalObjects.ComponentCore.GetAicraftBaseComponents(aircraft.ItemId));
		        if (_currentBaseDetailsList.Count == 0)
		        {
			        MessageBox.Show("Can't find base component list for aircraft " +
			                        ((Aircraft)comboBoxAircraft.SelectedItem).RegistrationNumber);
			        return;
		        }
		        comboBoxBaseComponent.Items.Clear();
		        comboBoxBaseComponent.Items.AddRange(_currentBaseDetailsList.ToArray());
		        comboBoxBaseComponent.SelectedIndex = 0;
			}

			
        }
        #endregion

        #region private void RadioButtonStoreCheckedChanged(object sender, EventArgs e)

        private void RadioButtonStoreCheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonStore.Checked)
            {
                comboBoxStore.Enabled = true;
                comboBoxStore.SelectedIndex = 0;

                comboBoxAircraft.Enabled = false;
                comboBoxAircraft.SelectedIndex = -1;

				comboBoxBaseComponent.Enabled = false;
				comboBoxBaseComponent.SelectedIndex = -1;

				comboBoxSupplier.Enabled = false;
				comboBoxSupplier.SelectedIndex = -1;

				ReceiptDatedateTimePicker.Enabled = false;
	            NotifylifelengthViewer.Enabled = false;

	            comboBoxStaff.Enabled = false;
	            comboBoxStaff.SelectedIndex = -1;
			}

        }

        #endregion

        #region private void DateTimePickerDateValueChanged(object sender, EventArgs e)
        private void DateTimePickerDateValueChanged(object sender, EventArgs e)
        {
	        dateTimePickerDate.ValueChanged -= DateTimePickerDateValueChanged;

			if (dateTimePickerDate.Value > DateTime.Today)
                dateTimePickerDate.Value = DateTime.Today;

            List<DataGridViewRow> checkedItems = CheckedRows();

            DateTime date = new DateTime(1900, 1, 1);

            foreach (DataGridViewRow item in checkedItems)
            {
                Component d = item.Tag as Component;
                if (d != null && d.TransferRecords.GetLast().TransferDate > date)
                {
                    date = d.TransferRecords.GetLast().TransferDate;
                }
            }
            if (date > dateTimePickerDate.Value)
                dateTimePickerDate.Value = date;

			dateTimePickerDate.ValueChanged += DateTimePickerDateValueChanged;
		}
		#endregion

		#region private void radioButtonSupplier_CheckedChanged(object sender, EventArgs e)

		private void radioButtonSupplier_CheckedChanged(object sender, EventArgs e)
	    {
		    if (radioButtonSupplier.Checked)
		    {
			    comboBoxStore.Enabled = false;
			    comboBoxStore.SelectedIndex = -1;

			    comboBoxAircraft.Enabled = false;
			    comboBoxAircraft.SelectedIndex = -1;

				comboBoxBaseComponent.Enabled = false;
			    comboBoxBaseComponent.SelectedIndex = -1;

			    comboBoxStaff.Enabled = false;
			    comboBoxStaff.SelectedIndex = -1;

			    comboBoxSupplier.Enabled = true;
			    comboBoxSupplier.SelectedIndex = 0;

			    ReceiptDatedateTimePicker.Enabled = true;
			    NotifylifelengthViewer.Enabled = true;
		    }

	    }

		#endregion

	    private void radioButtonStaff_CheckedChanged(object sender, EventArgs e)
	    {
		    if (radioButtonStaff.Checked)
		    {
			    comboBoxStore.Enabled = false;
			    comboBoxStore.SelectedIndex = -1;

			    comboBoxAircraft.Enabled = false;
			    comboBoxAircraft.SelectedIndex = -1;

				comboBoxBaseComponent.Enabled = false;
				comboBoxBaseComponent.SelectedIndex = -1;

				comboBoxSupplier.Enabled = false;
				comboBoxSupplier.SelectedIndex = -1;

				comboBoxStaff.Enabled = true;
				comboBoxStaff.SelectedIndex = 0;

				ReceiptDatedateTimePicker.Enabled = true;
			    NotifylifelengthViewer.Enabled = true;
		    }
	    }

	    private void radioButtonAircraft_CheckedChanged(object sender, EventArgs e)
	    {
		    if (radioButtonAircraft.Checked)
		    {
			    comboBoxStore.Enabled = false;
			    comboBoxStore.SelectedIndex = -1;

			    comboBoxAircraft.Enabled = true;
			    comboBoxAircraft.SelectedIndex = 0;

			    comboBoxBaseComponent.Enabled = true;
			    comboBoxBaseComponent.SelectedIndex = 0;

			    comboBoxSupplier.Enabled = false;
			    comboBoxSupplier.SelectedIndex = -1;

			    comboBoxStaff.Enabled = false;
			    comboBoxStaff.SelectedIndex = -1;

			    ReceiptDatedateTimePicker.Enabled = false;
			    NotifylifelengthViewer.Enabled = false;
		    }
	    }

		#endregion

		#region Events

		#endregion


	}
}
