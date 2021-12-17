using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.ComponentControls
{
    ///<summary>
    ///Форма отображает детали, котрые были удалены с 
    ///самолета или базовой детали
    ///</summary>
    public partial class TransferedComponentForm : MetroForm
    {
        #region Fields

        private ComponentCollection _removedComponents;
        private TransferRecordCollection _removedTransfers;
        private ComponentCollection _waitremovedConfirmComponents;
        private TransferRecordCollection _waitRemovedTransfers;
        private ComponentCollection _installedComponents;
        private TransferRecordCollection _installedTransfers;

        private SmartCoreType _parentType;
        
        #endregion

        #region Constructors

        #region public TransferedDetailForm()
        ///<summary>
        ///Конструктор создающий пустую форму
        ///</summary>
        public TransferedComponentForm()
        {
            InitializeComponent();
        }
        #endregion

        #region public TransferedDetailForm(Detail[] removedDetails, TransferRecord[] removedTransfers)
        ///<summary>
        ///Конструктор заполняющий всю необходимую информацию о переданном объекте
        ///</summary>
        public TransferedComponentForm(IEnumerable<Component> removedDetails, IEnumerable<TransferRecord> removedTransfers, 
                                    IEnumerable<Component> waitRemoveDetails, IEnumerable<TransferRecord> waitRemoveTransfers,
                                    IEnumerable<Component> installedDetails, IEnumerable<TransferRecord> installedTransfers,
									SmartCoreType parentType) : this()
        {
            _removedComponents = new ComponentCollection();
            _removedComponents.AddRange(removedDetails);
            _removedTransfers = new TransferRecordCollection();
            _removedTransfers.AddRange(removedTransfers);

            _waitremovedConfirmComponents = new ComponentCollection();
            _waitremovedConfirmComponents.AddRange(waitRemoveDetails);
            _waitRemovedTransfers = new TransferRecordCollection();
            _waitRemovedTransfers.AddRange(waitRemoveTransfers);

            _installedComponents = new ComponentCollection();
            _installedComponents.AddRange(installedDetails);
            _installedTransfers = new TransferRecordCollection();
            _installedTransfers.AddRange(installedTransfers);

            _parentType = parentType;

            UpdateInformation();
        }

        #endregion

        #endregion

        #region Properties
        #endregion

        #region Methods

        #region public void UpdateInformation()
        ///<summary>
        ///обновление информации в контроле
        ///</summary>
        public void UpdateInformation()
        {
            if(_parentType != null)
            {
                if(_parentType == SmartCoreType.Aircraft)
                {
                    ButtonAdd.TextMain = "Add to aircraft ";
                    ButtonAdd.TextSecondary = "components";

                    ButtonDelete.TextMain = "Delete from aircraft ";
                    ButtonDelete.TextSecondary = "components";   
                }

                if (_parentType == SmartCoreType.Store)
                {
                    ButtonAdd.TextMain = "Add to store ";
                    ButtonAdd.TextSecondary = "components";

                    ButtonDelete.TextMain = "Delete from store ";
                    ButtonDelete.TextSecondary = "components";
                }

	            if (_parentType == SmartCoreType.Supplier)
	            {
					ButtonAdd.TextMain = "Add to supplier ";
		            ButtonAdd.TextSecondary = "components";

		            ButtonDelete.TextMain = "Delete from supplier ";
		            ButtonDelete.TextSecondary = "components";
				}

	            if (_parentType == SmartCoreType.Employee)
	            {
		            ButtonAdd.TextMain = "Add to employee ";
		            ButtonAdd.TextSecondary = "components";

		            ButtonDelete.TextMain = "Delete from employee ";
		            ButtonDelete.TextSecondary = "components";
	            }
			}
            listViewTransferedDetails.Items.Clear();

            if (((_removedComponents.Count == 0 && _removedTransfers.Count == 0) 
                 || _removedComponents.Count != _removedTransfers.Count) &&
                 ((_waitremovedConfirmComponents.Count == 0 && _waitRemovedTransfers.Count == 0)
                 || _waitremovedConfirmComponents.Count != _waitRemovedTransfers.Count) && 
                ((_installedComponents.Count == 0 && _installedTransfers.Count == 0) 
                 ||_installedComponents.Count != _installedTransfers.Count)) return;
            
            if((_installedComponents.Count > 0 && _removedComponents.Count > 0) ||
               (_waitremovedConfirmComponents.Count > 0 && _removedComponents.Count > 0 ) ||
               (_waitremovedConfirmComponents.Count > 0 && _installedComponents.Count > 0))
            {
                Text = "Transfered Details";
                ButtonDelete.Enabled = true;
                ButtonCancel.Enabled = true;
                ButtonAdd.Enabled = true;
                listViewTransferedDetails.ShowGroups = true;
            }
            else if(_waitremovedConfirmComponents.Count > 0)
            {
                Text = "Wait remove confirm";
                ButtonDelete.Enabled = false;
                ButtonCancel.Enabled = true;
                ButtonAdd.Enabled = false;
                listViewTransferedDetails.ShowGroups = false;  
            }
            else if (_removedComponents.Count > 0 )
            {
                Text = "Last removed details";
                ButtonDelete.Enabled = true;
                ButtonCancel.Enabled = false;
                ButtonAdd.Enabled = false;
                listViewTransferedDetails.ShowGroups = false;
            }
            else if(_installedComponents.Count > 0)
            {
                Text = "Last installed details";
                ButtonDelete.Enabled = false;
                ButtonCancel.Enabled = false;
                ButtonAdd.Enabled = true;
                listViewTransferedDetails.ShowGroups = false;
            }

            string[] subs;
            ListViewItem newItem;
            string lastDestination, currentDestination;
            TransferRecord record;

            for (int i = 0; i < _waitremovedConfirmComponents.Count; i++)
            {
                record = _waitRemovedTransfers.GetRecordByComponentId(_waitremovedConfirmComponents[i].ItemId);
                DestinationHelper.GetPreviosAndCurrentDestination(record, out lastDestination, out currentDestination);

                subs = new []
                               {
                                   _waitremovedConfirmComponents[i].Description + " P/N:" + _waitremovedConfirmComponents[i].PartNumber + " S/N:" +
                                   _waitremovedConfirmComponents[i].SerialNumber,
                                   "From " + lastDestination + " to " + currentDestination,
                                   record.TransferDate.ToString(),
                               };

                newItem = new ListViewItem(subs);
                newItem.Tag = _waitremovedConfirmComponents[i];
                newItem.Group = listViewTransferedDetails.Groups[2];
                listViewTransferedDetails.Items.Add(newItem);
            }

            for (int i = 0; i < _removedComponents.Count; i++)
            {
                record = _removedTransfers.GetRecordByComponentId(_removedComponents[i].ItemId);
				DestinationHelper.GetPreviosAndCurrentDestination(record, out lastDestination, out currentDestination);

                subs = new []
                               {
                                   _removedComponents[i].Description + " P/N:" + _removedComponents[i].PartNumber + " S/N:" +
                                   _removedComponents[i].SerialNumber,
                                   "From " + lastDestination + " to " + currentDestination,
                                   record.TransferDate.ToString(),
                               };

                newItem = new ListViewItem(subs);
                newItem.Tag = _removedComponents[i];
                newItem.Group = listViewTransferedDetails.Groups[0];
                listViewTransferedDetails.Items.Add(newItem);
            }

            for (int i = 0; i < _installedComponents.Count; i++)
            {
                record = _installedTransfers.GetRecordByComponentId(_installedComponents[i].ItemId);
				DestinationHelper.GetPreviosAndCurrentDestination(record, out lastDestination, out currentDestination);

                subs = new []
                               {
                                   _installedComponents[i].Description + " P/N:" + _installedComponents[i].PartNumber + " S/N:" +
                                   _installedComponents[i].SerialNumber,
                                   "From " + lastDestination + " to " + currentDestination,
                                   record.TransferDate.ToString(),
                               };

                newItem = new ListViewItem(subs);
                newItem.Tag = _installedComponents[i];
                newItem.Group = listViewTransferedDetails.Groups[1];
                listViewTransferedDetails.Items.Add(newItem);
            }
        }
        
        #endregion

        #region private void ButtonAdd_Click(object sender, EventArgs e)
       
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (listViewTransferedDetails.SelectedItems.Count == 0) return;

            ComponentCollection installedComponents = new ComponentCollection();
            ComponentCollection removedComponents = new ComponentCollection(_removedComponents.ToArray());
            List<ReplaceComponentFormItem> replaceDetailFormItems;

            foreach (ListViewItem item in listViewTransferedDetails.SelectedItems)
            {
                if (item.Group == listViewTransferedDetails.Groups[1])
                {
                    Component component = (Component)item.Tag;
                    installedComponents.Add(component);

                    //detail.TransferRecords.Last.DODR = true;

                    ////увеличение необходимого кол-ва деталей родительского компонента
                    ////сохранение родительского компонента
                    //detail.ParentBaseDetail.ComponentCount++;
                    //GlobalObjects.CasEnvironment.Keeper.Save(detail.ParentBaseDetail);

                    //GlobalObjects.CasEnvironment.Keeper.Save(detail.TransferRecords.Last);
                    //_installedDetails.Remove(detail);
                    //TransferRecord record = _installedTransfers.GetTransferRecordByDetailID(detail.DetailId);
                    //if (record != null) _installedTransfers.Remove(record);
                }
            }

            if(installedComponents.Count == 0) return;
            replaceDetailFormItems = new List<ReplaceComponentFormItem>();
 
            foreach (Component item in installedComponents)
            {
                var newItem = new ReplaceComponentFormItem(item, null, _parentType);
                replaceDetailFormItems.Add(newItem);

	            if (item is BaseComponent)
			        newItem.comboBoxReplaceByDetail.Items.AddRange(_waitremovedConfirmComponents.Where(i => i is BaseComponent).ToArray());
	            if (item is Component)
		            newItem.comboBoxReplaceByDetail.Items.AddRange(_waitremovedConfirmComponents.Where(i => i is Component).ToArray());

				if (removedComponents.Count == 0)
                {
                    newItem.UpdateInformation(true);
                    continue;
                }

                foreach (Component removedItem in removedComponents)
                {
                    //проверка по сходству ID
                    //проверка по сходству названия
                    if (removedItem.ItemId == item.ItemId ||
                        removedItem.Description.ToUpper() == item.Description.ToUpper())
                    {
                        //Если ID идентичны, то эта деталь сначала была перемещена куда-то,
                        //а потом обратно на самолет

                        //если название идентично, значит эта могла быть направлена на самолет
                        //для замены снятой
                        newItem.ReplacedByComponent = removedItem;
                        newItem.ReplacedByDetailTransfer =
                            _removedTransfers.GetRecordByComponentId(removedItem.ItemId);

                        //удаление элемента из коллекции, что бы он не попал в результат дважды
                        removedComponents.Remove(removedItem);
                        break;
                    }
                }
                newItem.UpdateInformation(true);
            }
            
            var form = new ReplaceComponentForm(_installedComponents, _removedComponents, replaceDetailFormItems.ToArray(), _parentType);
			form.UpdateLabels(true);

            TopMost = false; //что бы данное онко не перекрывало окно диалога
            form.ShowDialog();
            TopMost = true;

            //return;

            //Если изменения не были произведены, то просто возвращаемся из данной функции
            if (form.DialogResult == DialogResult.Cancel) return;
            //иначе производится замена/перемещение компонентов
            var replacedItems = new List<ReplaceComponentFormItem>(form.GetReplacedItems());
            foreach (ReplaceComponentFormItem replacedItem in replacedItems)
            {
				if(!replacedItem.ConfirmTransfer)
					continue;

                if (replacedItem.ParentComponent != null)
                {
                    if(replacedItem.ParentComponent.IsBaseComponent)
                    {
                        BaseComponent bd =
                            GlobalObjects.CasEnvironment.BaseComponents.
                            GetItemById(replacedItem.ParentComponent.ItemId);

                        ActualStateRecord actual =
                        bd.ActualStateRecords[bd.TransferRecords.GetLast().StartTransferDate];

                        if(actual != null)
                        {
                            actual.RecordDate = replacedItem.ConfirmDate;
							//TODO:(Evgenii Babak) пересмотреть подход, наработка считается на начало дня, а в метод передаем DateTime.Now(может быть и концом дня)
							actual.OnLifelength = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(bd, replacedItem.ConfirmDate);
							GlobalObjects.NewKeeper.Save(actual);    
                        }
                        else
                        {
                            actual = new ActualStateRecord
                            {
                                ComponentId = bd.ItemId,
                                RecordDate = DateTime.Now,
								//TODO:(Evgenii Babak) пересмотреть подход, наработка считается на начало дня, а в метод передаем DateTime.Now(может быть и концом дня)
								OnLifelength = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(bd, replacedItem.ConfirmDate)
							};
                            GlobalObjects.ComponentCore.RegisterActualState(bd, actual);     
                        }

                        bd.TransferRecords.GetLast().DODR = true;
                        bd.TransferRecords.GetLast().PreConfirmTransfer = true;
                        bd.TransferRecords.GetLast().TransferDate = replacedItem.ConfirmDate;
                        GlobalObjects.NewKeeper.Save(bd.TransferRecords.GetLast());
                    }
                    else
                    {
                        ActualStateRecord actual =
                        replacedItem.ParentComponent.ActualStateRecords[replacedItem.ParentComponent.TransferRecords.GetLast().StartTransferDate];

                        if(actual != null)
                        {
                            actual.RecordDate = replacedItem.ConfirmDate;
							//TODO:(Evgenii Babak) пересмотреть подход, наработка считается на начало дня, а в метод передаем DateTime.Now(может быть и началом дня)
							actual.OnLifelength = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(replacedItem.ParentComponent, DateTime.Now);
							GlobalObjects.NewKeeper.Save(actual);   
                        }
                        else
                        {
                            actual = new ActualStateRecord
                            {
                                ComponentId = replacedItem.ParentComponent.ItemId,
                                RecordDate = DateTime.Now,
								//TODO:(Evgenii Babak) пересмотреть подход, наработка считается на начало дня, а в метод передаем DateTime.Now(может быть и началом дня)
								OnLifelength = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(replacedItem.ParentComponent, DateTime.Now)
							};
                            GlobalObjects.ComponentCore.RegisterActualState(replacedItem.ParentComponent, actual);     
                        }

	                    if (replacedItem.ReplacedByComponent != null && replacedItem.ReplacedByComponent.ComponentDirectives.Count > 0)
	                    {
		                    foreach (var directive in replacedItem.ReplacedByComponent.ComponentDirectives)
		                    {
			                    var newDirective = directive.GetCopyUnsaved();
			                    newDirective.ComponentId = replacedItem.ParentComponent.ItemId;
			                    newDirective.ParentComponent = replacedItem.ParentComponent;
								GlobalObjects.NewKeeper.Save(newDirective);
		                    }
	                    }


                        replacedItem.ParentComponent.TransferRecords.GetLast().DODR = true;
                        replacedItem.ParentComponent.TransferRecords.GetLast().PreConfirmTransfer = true;
                        replacedItem.ParentComponent.TransferRecords.GetLast().TransferDate =
                            replacedItem.ConfirmDate;
                        //увеличение необходимого кол-ва деталей родительского компонента
                        //сохранение родительского компонента
                        if (replacedItem.ParentComponent.ParentBaseComponent != null)
                        {
                            replacedItem.ParentComponent.ParentBaseComponent.ComponentCount++;
                            GlobalObjects.ComponentCore.Save(replacedItem.ParentComponent.ParentBaseComponent);//TODO:(Evgenii Babak) заменить на использование ComponentCore 
                        }
                        GlobalObjects.NewKeeper.Save(replacedItem.ParentComponent.TransferRecords.GetLast());
                    }
                    _installedComponents.Remove(replacedItem.ParentComponent);
                    TransferRecord record = _installedTransfers.GetRecordByComponentId(replacedItem.ParentComponent.ItemId);
	                if (record != null)
	                {
		                _installedTransfers.Remove(record);

						if (replacedItem.ReplacedByComponent != null)
						{
							record.ReplaceComponentId = replacedItem.ReplacedByComponent.ItemId;
							record.IsReplaceComponentRemoved = true;
							GlobalObjects.NewKeeper.Save(record);
						}
					}
                }

                if (replacedItem.ReplacedByComponent != null)
                {
                    TransferRecord record = _removedTransfers.GetRecordByComponentId(replacedItem.ReplacedByComponent.ItemId);
                    if (record != null)
                    {
                        _removedTransfers.Remove(record);
                        record.PODR = true;
                        GlobalObjects.NewKeeper.Save(record);

                        BaseComponent from = GlobalObjects.ComponentCore.GetBaseComponentById(record.FromBaseComponentId);
                        //уменьшение необходимого кол-ва деталей родительского компонента
                        //сохранение родительского компонента
                        if (from != null)
                        {
                            from.ComponentCount--;
                            GlobalObjects.ComponentCore.Save(from);
                        }

                        _removedComponents.Remove(replacedItem.ReplacedByComponent);
                    }
                }
            }
      
            //создание события ButtonAddClick
            InvokeButtonAddClick();

            UpdateInformation();
        }
        #endregion

        #region private void ButtonDelete_Click(object sender, EventArgs e)

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (listViewTransferedDetails.SelectedItems.Count == 0) return;

            ComponentCollection removedComponents = new ComponentCollection();
            ComponentCollection installedComponents = new ComponentCollection(_installedComponents.ToArray());
            List<ReplaceComponentFormItem> replaceDetailFormItems;

            foreach (ListViewItem item in listViewTransferedDetails.SelectedItems)
            {
                if (item.Group == listViewTransferedDetails.Groups[0])
                {
                    Component component = (Component)item.Tag;
                    removedComponents.Add(component);
                }
            }

            if (removedComponents.Count == 0) return;

            replaceDetailFormItems = new List<ReplaceComponentFormItem>();         
            foreach (Component item in removedComponents)
            {
                var newItem = new ReplaceComponentFormItem(item, null,
                  _removedTransfers.GetRecordByComponentId(item.ItemId), null, _parentType);
                replaceDetailFormItems.Add(newItem);

                if (installedComponents.Count == 0)
                {
                    newItem.UpdateInformation(false);
                    continue;
                }

                foreach (Component installedItem in installedComponents)
                {
                    //проверка по сходству ID
                    //проверка по сходству названия
                    if (installedItem.ItemId == item.ItemId ||
                        installedItem.Description.ToUpper() == item.Description.ToUpper())
                    {
                        //Если ID идентичны, то эта деталь сначала была перемещена куда-то,
                        //а потом обратно на самолет

                        //если название идентично, значит эта могла быть направлена на самолет
                        //для замены снятой
                        newItem.ReplacedByComponent = installedItem;
                        newItem.ReplacedByDetailTransfer = installedItem.TransferRecords.GetLast();

                        //удаление элемента из коллекции, что бы он не попал в результат дважды
                        installedComponents.Remove(installedItem);
                        break;
                    }
                }
                newItem.UpdateInformation(false);
            }

            var form = new ReplaceComponentForm(_removedComponents, _installedComponents, replaceDetailFormItems.ToArray(), _parentType);
			form.UpdateLabels(false);

			TopMost = false; //что бы данное онко не перекрывало окно диалога
            form.ShowDialog();
            TopMost = true;
            //Если изменения не были произведены, то просто возвращаемся из данной функции
            if (form.DialogResult == DialogResult.Cancel) return;
            //иначе производится замена/перемещение компонентов
            List<ReplaceComponentFormItem> replacedItems = new List<ReplaceComponentFormItem>(form.GetReplacedItems());
            foreach (ReplaceComponentFormItem replacedItem in replacedItems)
            {
                if(replacedItem.ParentComponent != null)
                {
                    TransferRecord record = _removedTransfers.GetRecordByComponentId(replacedItem.ParentComponent.ItemId);
                    record.PODR = true;

	                if (replacedItem.ReplacedByComponent != null)
	                {
		                record.ReplaceComponentId = replacedItem.ReplacedByComponent.ItemId;
						record.IsReplaceComponentRemoved = false;
					}

					GlobalObjects.NewKeeper.Save(record);

                    BaseComponent from = GlobalObjects.ComponentCore.GetBaseComponentById(record.FromBaseComponentId);
                    //уменьшение необходимого кол-ва деталей родительского компонента
                    //сохранение родительского компонента
                    if(from != null)
                    {
                        from.ComponentCount--;
                        GlobalObjects.ComponentCore.Save(from);
                    }
                    _removedComponents.Remove(replacedItem.ParentComponent);
                    _removedTransfers.Remove(record);

				}

                if (replacedItem.ReplacedByComponent != null)
                {
                    ActualStateRecord actual =
                            replacedItem.ReplacedByComponent.ActualStateRecords[replacedItem.ReplacedByComponent.TransferRecords.GetLast().StartTransferDate];

                    actual.RecordDate = replacedItem.ReplacedByDate;
                    actual.OnLifelength = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(replacedItem.ReplacedByComponent, DateTime.Now);//TODO:(Evgenii Babak) пересмотреть подход, наработка считается на начало дня, а в метод передаем DateTime.Now(может быть и началом дня)
					GlobalObjects.NewKeeper.Save(actual);

                    replacedItem.ReplacedByComponent.TransferRecords.GetLast().DODR = true;
                    replacedItem.ReplacedByComponent.TransferRecords.GetLast().TransferDate =
                        replacedItem.ReplacedByDate;
                    //увеличение необходимого кол-ва деталей родительского компонента
                    //сохранение родительского компонента
                    if(replacedItem.ReplacedByComponent.ParentBaseComponent != null)
                    {
                        replacedItem.ReplacedByComponent.ParentBaseComponent.ComponentCount++;
                        GlobalObjects.ComponentCore.Save(replacedItem.ReplacedByComponent.ParentBaseComponent); 
                    }
                    GlobalObjects.NewKeeper.Save(replacedItem.ReplacedByComponent.TransferRecords.GetLast());
                    _installedComponents.Remove(replacedItem.ReplacedByComponent);
                    TransferRecord record = _installedTransfers.GetRecordByComponentId(replacedItem.ReplacedByComponent.ItemId);
                    if (record != null) _installedTransfers.Remove(record);

                }
            }
            InvokeButtonDeleteClick();

            UpdateInformation();
        }
        #endregion

        #region private void ButtonCancel_Click(object sender, EventArgs e)
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (listViewTransferedDetails.SelectedItems.Count == 0) return;

            ComponentCollection waitRemovedComponents = new ComponentCollection();

            foreach (ListViewItem item in listViewTransferedDetails.SelectedItems)
            {
                if (item.Group == listViewTransferedDetails.Groups[2])
                {
                    Component component = (Component)item.Tag;
                    waitRemovedComponents.Add(component);
                }
            }

            if (waitRemovedComponents.Count == 0) return;

            bool updateParentScreen = false;
            foreach (Component detail in waitRemovedComponents)
            {
                TransferRecord record = _waitRemovedTransfers.GetRecordByComponentId(detail.ItemId);
                if(record.DODR != true)
                {
                    GlobalObjects.TransferRecordCore.Delete(record);
                    _waitRemovedTransfers.Remove(_waitRemovedTransfers.GetItemById(record.ItemId));
                    _waitremovedConfirmComponents.Remove(_waitremovedConfirmComponents.GetItemById(detail.ItemId));
                    updateParentScreen = true;
                }
            }
            if (updateParentScreen) InvokeButtonCancelClick();

            UpdateInformation();
            
        }
        #endregion

        #region private void ListViewTransferedDetailsMouseClick(object sender, MouseEventArgs e)

        private void ListViewTransferedDetailsMouseClick(object sender, MouseEventArgs e)
        {
            ButtonAdd.Enabled = false;
            ButtonDelete.Enabled = false;
            ButtonCancel.Enabled = false;
            if (listViewTransferedDetails.SelectedItems.Count == 0) return;

            foreach (ListViewItem item in listViewTransferedDetails.SelectedItems)
            {
                if (item.Group == listViewTransferedDetails.Groups[0]) ButtonDelete.Enabled = true;
                if (item.Group == listViewTransferedDetails.Groups[1]) ButtonAdd.Enabled = true;
                if (item.Group == listViewTransferedDetails.Groups[2]) ButtonCancel.Enabled = true;
            }
        }
        #endregion

        #endregion

        #region Events

        ///<summary>
        ///</summary>
        public event EventHandler ButtonAddClick;

        //функция, которая создает событие ButtonAddClick;
        private void InvokeButtonAddClick()
        {
            EventHandler click = ButtonAddClick;
            if (click != null) click(this, new EventArgs());
        }

        ///<summary>
        ///</summary>
        public event EventHandler ButtonCancelClick;

        //функция, которая создает событие ButtonAddClick;
        private void InvokeButtonCancelClick()
        {
            EventHandler click = ButtonCancelClick;
            if (click != null) click(this, new EventArgs());
        }

        ///<summary>
        ///</summary>
        public event EventHandler ButtonDeleteClick;

        //функция, которая создает событие ButtonDeleteClick;
        private void InvokeButtonDeleteClick()
        {
            EventHandler click = ButtonDeleteClick;
            if (click != null) click(this, new EventArgs());
        }

        #endregion
    }
}
