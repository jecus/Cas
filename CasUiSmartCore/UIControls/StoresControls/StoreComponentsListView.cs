using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;

namespace CAS.UI.UIControls.StoresControls
{
    ///<summary>
    /// список для отображения событий системы безопасности полетов
    ///</summary>
    public partial class StoreComponentsListView : BaseGridViewControl<IBaseCoreObject>
    {
        #region public StoreDetailsListView()
        ///<summary>
        ///</summary>
        public StoreComponentsListView()
        {
            InitializeComponent();
            OldColumnIndex = 16;
            SortMultiplier = 1;
        }
        #endregion

        #region Methods

        #region protected override void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
			AddColumn("ATA", (int)(radGridView1.Width * 0.2f));
			AddColumn("Refference", (int)(radGridView1.Width * 0.2f));
			AddColumn("Part. No", (int)(radGridView1.Width * 0.2f));
			AddColumn("Alt Part. No", (int)(radGridView1.Width * 0.2f));
			AddColumn("Standart", (int)(radGridView1.Width * 0.2f));
			AddColumn("Name", (int)(radGridView1.Width * 0.2f));
			AddColumn("Description", (int)(radGridView1.Width * 0.6f));
			AddColumn("Serial No", (int)(radGridView1.Width * 0.2f));
			AddColumn("Class", (int)(radGridView1.Width * 0.2f));
			AddColumn("Batch No", (int)(radGridView1.Width * 0.2f));
			AddColumn("ID No", (int)(radGridView1.Width * 0.2f));
			AddColumn("State", (int)(radGridView1.Width * 0.2f));
			AddColumn("Status", (int)(radGridView1.Width * 0.2f));
			AddColumn("Location", (int)(radGridView1.Width * 0.2f));
			AddColumn("Facility", (int)(radGridView1.Width * 0.2f));
			AddColumn("From", (int)(radGridView1.Width * 0.2f));
			AddColumn("Inst. date", (int)(radGridView1.Width * 0.2f));
			AddColumn("Work Type", (int)(radGridView1.Width * 0.14f));
			AddColumn("Need Wp Q-ty", (int)(radGridView1.Width * 0.14f));
			AddColumn("Reserve", (int)(radGridView1.Width * 0.14f));
			AddColumn("Current", (int)(radGridView1.Width * 0.14f));
			AddColumn("Should be", (int)(radGridView1.Width * 0.14f));
			AddColumn("Qty In", (int)(radGridView1.Width * 0.14f));
			AddColumn("Unit Price", 75);
			AddColumn("Total Price", 75);
			AddColumn("Ship Price", 75);
			AddColumn("SubTotal", 75);
			AddColumn("Tax", 75);
			AddColumn("Tax1", 75);
			AddColumn("Tax2", 75);
			AddColumn("Total", 75);
			AddColumn("Currency", 75);
			AddColumn("Supplier", 75);
			AddColumn("Code", (int)(radGridView1.Width * 0.2f));
			AddColumn("Remarks", (int)(radGridView1.Width * 0.2f));
			AddColumn("Effectivity", (int)(radGridView1.Width * 0.2f));
			AddColumn("IsPool", (int)(radGridView1.Width * 0.2f));
			AddColumn("IsDangerous", (int)(radGridView1.Width * 0.2f));
			AddColumn("M.P.", (int)(radGridView1.Width * 0.14f));
			AddColumn("M.H.", 75);
			AddColumn("Life limit/1st. Perf", (int)(radGridView1.Width * 0.2f));
			AddColumn("Rpt. int.", (int)(radGridView1.Width * 0.2f));
			AddColumn("Performances", 0);
			AddColumn("Next", (int)(radGridView1.Width * 0.24f));
			AddColumn("Remain/Overdue", (int)(radGridView1.Width * 0.24f));
			AddColumn("Last", (int)(radGridView1.Width * 0.24f));
			AddColumn("Warranty", (int)(radGridView1.Width * 0.2f));
			AddColumn("Warranty Remain", (int)(radGridView1.Width * 0.2f));
			AddColumn("Kit", (int)(radGridView1.Width * 0.2f));
			AddColumn("Hidden Remarks", (int)(radGridView1.Width * 0.24f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
        }
        #endregion

        #region protected override void AddItems(IBaseCoreObject[] itemsArray)
        /// <summary>
        /// Добавляет элементы в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        //protected override void AddItems(IBaseCoreObject[] itemsArray)
        //{
        //    ColumnHeader ch = ColumnHeaderList.FirstOrDefault(h => h.Text == "Performances");
        //    if (ch == null)
        //    {
        //        base.AddItems(itemsArray);
        //        return;
        //    }
            
        //    if(itemsArray == null || itemsArray.Length == 0)
        //    {
        //        ch.Width = 0;
        //        base.AddItems(itemsArray);
        //        return;
        //    }
        //    ch.Width = itemsArray.OfType<IDirective>()
        //                         .Count(d => d.NextPerformances != null && d.NextPerformances.Count > 1) > 0 ? 100 : 0;

        //    base.AddItems(itemsArray);
        //}

		#endregion

		#region protected override void SetGroupsToItems(int columnIndex)

		/// <summary>
		/// Возвращает название группы в списке агрегатов текущего склада, согласно тому, какого типа элемент
		/// </summary>
		//protected override void SetGroupsToItems(int columnIndex)
  //      {
       //     itemsListView.Groups.Clear();
       //     itemsListView.Groups.AddRange(new[]
       //                                       {
       //                                           new ListViewGroup("Engines", "Engines"),
       //                                           new ListViewGroup("APU's", "APU's"),
       //                                           new ListViewGroup("Landing Gears", "Landing Gears"),
       //                                       });
       //     foreach (ListViewItem item in ListViewItemList.OrderBy(x => x.Text))
       //     {
       //         String temp = "";

       //         if (!(item.Tag is IDirective)) continue;

       //         IDirective parent = (IDirective)item.Tag;

       //         #region Группировка по типу задачи

       //         if (parent is ComponentDirective)
       //             parent = ((ComponentDirective) parent).ParentComponent;
       //         if (parent is BaseComponent)
       //         {
       //             if (((BaseComponent)parent).BaseComponentType == BaseComponentType.Engine)
       //                 temp = "Engines";
       //             else if (((BaseComponent)parent).BaseComponentType == BaseComponentType.Apu)
       //                 temp = "APU's";
       //             else if (((BaseComponent)parent).BaseComponentType == BaseComponentType.LandingGear)
       //                 temp = "Landing Gears";

       //             item.Group = itemsListView.Groups[temp];
       //         }
       //         else if (parent is Component)
       //         {
       //             Component component = (Component)parent;

       //                 if (component.ParentBaseComponent != null)
       //                 {
       //                     BaseComponent baseComponent = component.ParentBaseComponent;//TODO:(Evgenii Babak) заменить на использование ComponentCore 
							//temp = baseComponent + " Components";
       //                 }
       //                 else
       //                 {
	      //                  AtaChapter ata = null;

							//if (component.Product != null)
							//{
							//	ata = component.Product.ATAChapter;
							//}
	      //                  else ata = component.ATAChapter;
                            
       //                     temp = ata.ShortName + " " + ata.FullName;
       //                 }
       //                 itemsListView.Groups.Add(temp, temp);
       //             item.Group = itemsListView.Groups[temp];
       //         }
       //         #endregion
       //     }
        //}

        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(IBaseCoreObject item)

        protected override List<CustomCell> GetListViewSubItems(IBaseCoreObject item)
        {
            var subItems = new List<CustomCell>();

            DateTime? approx = null;
            AtaChapter ata;
            string maintenanceTypeString = "";
            DateTime transferDate = DateTimeExtend.GetCASMinDateTime();
	        bool isPool = false, IsDangerous = false;
            Lifelength firstPerformance = Lifelength.Null,
                       lastPerformance = Lifelength.Null,
                       remains = null,
                       next = null,
                       warranty = Lifelength.Null, warrantyRemain = Lifelength.Null, repeatInterval = Lifelength.Null;
	        string partNumber = "",
                   description = "",
                   altPartNumber = "",
                   standart = "",
                   name = "",
				   refference = "",
                   effectivity = "",
				   serialNumber = "",
                   code = "",
                   classString = "",
                   batchNumber = "",
                   idNumber = "",
                   supplier = "";
	        string status = "",
		        location = "",
		        facility = "",
		        lastPerformanceString = "",
		        kitRequieredString = "",
		        remarks = "",
		        hiddenRemarks = "",
		        workType = "",
		        timesString,
				quantityString = "",
				currentString = "",
		        shouldBeOnStockString = "",
		        from = "",
				quantityInString = "",
		        author = "",
				currency = "";
			double manHours = 0,
				   unitPrice = 0,
				   totalPrice = 0,
				   shipPrice = 0,
				   subTotal = 0,
				   tax1 = 0,
				   tax2 = 0,
				   tax3 = 0,
				   total = 0,
				   quantity = 0,
                   current = 0,
				   quantityIn = 0,
				   shouldBeOnStock = 0, needWpQuantity = 0, reserve = 0;
            int times, 
                kitCount = 0;
			string position = ComponentStorePosition.UNK.ToString();
			IDirective parent;
            if (item is NextPerformance)
            {
                NextPerformance np = (NextPerformance) item;
                parent = np.Parent;

                int index = np.Parent.NextPerformances.IndexOf(np);
                timesString = index == 0 ? np.Parent.TimesToString : "#" + (index + 1);
                times = index == 0 ? np.Parent.Times : index + 1;
            }
            else
            {
                parent = item as IDirective;
                if (parent == null)
                    return subItems;
                timesString = parent.TimesToString;
                times = parent.Times;
            }

            if (parent is Component)
            {
                Component componentItem = (Component)parent;
                author = GlobalObjects.CasEnvironment.GetCorrector(componentItem.CorrectorId);
				approx = componentItem.NextPerformanceDate;
                next = componentItem.NextPerformanceSource;
                remains = componentItem.Remains;
                ata = componentItem.Product?.ATAChapter ?? componentItem.ATAChapter;
				partNumber = componentItem.Product?.PartNumber ?? componentItem.PartNumber;
				altPartNumber = componentItem.Product?.AltPartNumber ?? componentItem.ALTPartNumber;
				standart = componentItem.Product?.Standart?.ToString() ?? componentItem.Standart?.ToString();
				refference = componentItem.Product?.Reference;
				effectivity = componentItem.Product?.IsEffectivity;
				name = componentItem.Product?.Name;
				description = componentItem.Description;
                serialNumber = componentItem.SerialNumber;
                code = componentItem.Product != null ? componentItem.Product.Code :componentItem.Code;
                classString = componentItem.GoodsClass.ToString();
                batchNumber = componentItem.BatchNumber;
                idNumber = componentItem.IdNumber;
                position = componentItem.TransferRecords.GetLast()?.State?.ToString();
                status = componentItem.ComponentStatus.ToString();
                location = componentItem.Location.ToString();
                facility = componentItem.Location.LocationsType?.ToString() ?? LocationsType.Unknown.ToString();
                maintenanceTypeString = 
                    componentItem.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.ComponentsAndParts) 
                        ? componentItem.MaintenanceControlProcess.ShortName
                        : componentItem.LifeLimit.IsNullOrZero() 
                            ? ""
                            : MaintenanceControlProcess.HT.ShortName;
                transferDate = componentItem.TransferRecords.GetLast().TransferDate;
                firstPerformance = componentItem.LifeLimit;
                warranty = componentItem.Warranty;
                warrantyRemain = componentItem.NextPerformance?.WarrantlyRemains ?? Lifelength.Null;
                kitRequieredString = componentItem.Kits.Count > 0 ? componentItem.Kits.Count + " kits" : "";
                kitCount = componentItem.Kits.Count;
                bool isComponent =
                    componentItem.GoodsClass.IsNodeOrSubNodeOf(new IDictionaryTreeItem[]
                    {
                        GoodsClass.ComponentsAndParts,
                        GoodsClass.ProductionAuxiliaryEquipment,
                    });

                quantity = isComponent && componentItem.ItemId > 0 ? 1 : componentItem.Quantity;
				quantityString = quantity.ToString();
				quantityIn = isComponent && componentItem.ItemId > 0 ? 1 : componentItem.QuantityIn;
	            quantityInString = $"{quantityIn:0.##}" + (componentItem.Measure != null ? " " + componentItem.Measure + "(s)" : "") + componentItem.Packing;
	            needWpQuantity = Math.Round(componentItem.NeedWpQuantity, 2);
	            reserve = quantity - needWpQuantity;
				shouldBeOnStock = componentItem.ShouldBeOnStock;
                shouldBeOnStockString = componentItem.ShouldBeOnStock > 0 ? "Yes" : "No";
                manHours = componentItem.ManHours;
                remarks = componentItem.Remarks;
                hiddenRemarks = componentItem.HiddenRemarks;
	            isPool = componentItem.IsPOOL;
	            IsDangerous = componentItem.IsDangerous;
	            supplier = componentItem.FromSupplier.ToString();

				if (componentItem.ProductCosts.Count > 0)
	            {
		            var productost = componentItem.ProductCosts.FirstOrDefault();
		            unitPrice = productost.UnitPrice;
					totalPrice = productost.TotalPrice;
					shipPrice = productost.ShipPrice;
					subTotal = productost.SubTotal;
					tax1 = productost.Tax;
					tax2 = productost.Tax1;
					tax3 = productost.Tax2;
					total = productost.Total;
					currency = productost.Currency.ToString();
	            }


				TransferRecord tr = componentItem.TransferRecords.GetLast();
                if (tr.FromAircraftId == 0 &&
                    tr.FromBaseComponentId == 0 &&
                    tr.FromStoreId == 0 &&
					tr.FromSupplierId == 0 &&
					tr.FromSpecialistId == 0)
                {
                    from = componentItem.Suppliers.ToString();
                }
                else
                {
                    from = DestinationHelper.FromObjectString(tr);
                }
            }
            else if (parent is ComponentDirective)
            {
                ComponentDirective dd = (ComponentDirective)parent;
                author = GlobalObjects.CasEnvironment.GetCorrector(dd.CorrectorId);
				if (dd.Threshold.FirstPerformanceSinceNew != null && !dd.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                {
                    firstPerformance = dd.Threshold.FirstPerformanceSinceNew;
                }
                if (dd.LastPerformance != null)
                {
                    lastPerformanceString =
                        SmartCore.Auxiliary.Convert.GetDateFormat(dd.LastPerformance.RecordDate) + " " +
                        dd.LastPerformance.OnLifelength;
                    lastPerformance = dd.LastPerformance.OnLifelength;
                }
                if (dd.Threshold.RepeatInterval != null && !dd.Threshold.RepeatInterval.IsNullOrZero())
                {
                    repeatInterval = dd.Threshold.RepeatInterval;
                }
                approx = dd.NextPerformanceDate;
                next = dd.NextPerformanceSource;
                remains = dd.Remains;
                ata = dd.ParentComponent.Product?.ATAChapter ?? dd.ParentComponent.ATAChapter;
                maintenanceTypeString = dd.ParentComponent.MaintenanceControlProcess.ShortName;
                warranty = dd.Threshold.Warranty;
                kitRequieredString = dd.Kits.Count > 0 ? dd.Kits.Count + " kits" : "";
                kitCount = dd.Kits.Count;
                manHours = dd.ManHours;
                remarks = dd.Remarks;
                hiddenRemarks = dd.HiddenRemarks;
                workType = dd.DirectiveType.ToString();
				position = "    " + dd.ParentComponent.TransferRecords.GetLast()?.State?.ToString();
				isPool = dd.IsPOOL;
				IsDangerous = dd.IsDangerous;
				partNumber = "    " + (dd.ParentComponent.Product?.PartNumber ?? dd.ParentComponent.PartNumber);
				altPartNumber = "    " + (dd.ParentComponent.Product?.AltPartNumber ?? dd.ParentComponent.ALTPartNumber);
				standart = dd.ParentComponent.Product?.Standart?.ToString() ?? dd.ParentComponent.Standart?.ToString();
				name = "    " + dd.ParentComponent.Product?.Name;
				description = "    " + dd.ParentComponent.Description;
				serialNumber = "    " + dd.ParentComponent.SerialNumber;
				classString = dd.ParentComponent.GoodsClass.ToString();
				warrantyRemain = dd.NextPerformance?.WarrantlyRemains ?? Lifelength.Null;
			}
            else
            {
                ata = (AtaChapter)GlobalObjects.CasEnvironment.GetDictionary<AtaChapter>().GetItemById(21);
            }

            subItems.Add(CreateRow(ata.ToString(), ata));
            subItems.Add(CreateRow(refference, refference));
            subItems.Add(CreateRow(partNumber, partNumber));
            subItems.Add(CreateRow(altPartNumber, altPartNumber));
            subItems.Add(CreateRow(standart, standart));
            subItems.Add(CreateRow(name, name));
            subItems.Add(CreateRow(description, description));
            subItems.Add(CreateRow(serialNumber, serialNumber));
            subItems.Add(CreateRow(classString, classString));
            subItems.Add(CreateRow(batchNumber, batchNumber));
            subItems.Add(CreateRow(idNumber, idNumber));
            subItems.Add(CreateRow(position.ToUpper(), position));
            subItems.Add(CreateRow(status, status));
            subItems.Add(CreateRow(location, location));
            subItems.Add(CreateRow(facility, facility));
            subItems.Add(CreateRow(from, from));
            subItems.Add(CreateRow(transferDate > DateTimeExtend.GetCASMinDateTime()
	            ? SmartCore.Auxiliary.Convert.GetDateFormat(transferDate) : "", transferDate));
            subItems.Add(CreateRow(workType, workType));
            subItems.Add(CreateRow(needWpQuantity.ToString(), needWpQuantity));
            subItems.Add(CreateRow(reserve.ToString(), reserve));
            subItems.Add(CreateRow(quantityString, quantity));
            subItems.Add(CreateRow(shouldBeOnStockString, shouldBeOnStock));
            subItems.Add(CreateRow(quantityInString, quantityIn));
            subItems.Add(CreateRow(unitPrice.ToString(), unitPrice));
            subItems.Add(CreateRow(totalPrice.ToString(), totalPrice));
            subItems.Add(CreateRow(shipPrice.ToString(), shipPrice));
            subItems.Add(CreateRow(subTotal.ToString(), subTotal));
            subItems.Add(CreateRow(tax1.ToString(), tax1));
            subItems.Add(CreateRow(tax2.ToString(), tax2));
            subItems.Add(CreateRow(tax3.ToString(), tax3));
            subItems.Add(CreateRow(total.ToString(), total));
            subItems.Add(CreateRow(currency, currency));
            subItems.Add(CreateRow(supplier, supplier));
            subItems.Add(CreateRow(code, code));
            subItems.Add(CreateRow(remarks, remarks));
            subItems.Add(CreateRow(effectivity, effectivity));
            subItems.Add(CreateRow(isPool ? "Yes" : "No", isPool));
            subItems.Add(CreateRow(IsDangerous ? "Yes" : "No", IsDangerous));
            subItems.Add(CreateRow(maintenanceTypeString, maintenanceTypeString));
            subItems.Add(CreateRow(manHours.ToString(), manHours));
            subItems.Add(CreateRow(firstPerformance.ToString(), firstPerformance));
            subItems.Add(CreateRow(repeatInterval.ToString(), repeatInterval));
            subItems.Add(CreateRow(timesString, times));
            subItems.Add(CreateRow(approx != null
	            ? SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)approx) + " " + next
	            : next != null && !next.IsNullOrZero()
		            ? next.ToString()
		            : "", approx == null ? DateTimeExtend.GetCASMinDateTime() : (DateTime)approx));
            subItems.Add(CreateRow(remains != null && !remains.IsNullOrZero()
	            ? remains.ToString()
	            : "", remains ?? Lifelength.Null));
            subItems.Add(CreateRow(lastPerformanceString, lastPerformance));
            subItems.Add(CreateRow(warranty.ToString(), warranty));
            subItems.Add(CreateRow(warrantyRemain.ToString(), warrantyRemain));
            subItems.Add(CreateRow(kitRequieredString, kitCount));
            subItems.Add(CreateRow(hiddenRemarks, hiddenRemarks));
            subItems.Add(CreateRow(author, author));

            return subItems;
        }

        #endregion

        #region protected override void SortItems(int columnIndex)

        //protected override void SortItems(int columnIndex)
        //{
        //    if (OldColumnIndex != columnIndex)
        //        SortMultiplier = -1;
        //    if (SortMultiplier == 1)
        //        SortMultiplier = -1;
        //    else
        //        SortMultiplier = 1;
        //    itemsListView.Items.Clear();
        //    OldColumnIndex = columnIndex;

        //    SetGroupsToItems(columnIndex);

        //    List<ListViewItem> resultList = new List<ListViewItem>();

        //    if (columnIndex != 13)
        //    {
        //        ListViewItemList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));
        //        //добавление остальных подзадач
        //        foreach (ListViewItem item in ListViewItemList)
        //        {
        //            if (item.Tag is Component)
        //            {
        //                resultList.Add(item);
        //                Component component = (Component) item.Tag;
        //                if (component.NextPerformances != null && component.NextPerformances.Count > 1)
        //                {
        //                    //Если кол-во расчитанных выполнений больше одного
        //                    //то в результирующую коллекцию добавлются строки след. выполений
        //                    for (int i = 1; i < component.NextPerformances.Count; i++)
        //                    {
        //                        ListViewItem temp = new ListViewItem(GetListViewSubItems(component.NextPerformances[i]), null)
        //                        {
        //                            Tag = component.NextPerformances[i],
        //                            Group = item.Group
        //                        };
        //                        resultList.Add(temp);
        //                    }
        //                }
        //                //Если привязанным элементом является деталь
        //                //то в результирующий список следом за ней добавляются ее директивы
        //                var items =
        //                    ListViewItemList
        //                    .Where(lvi => lvi.Tag is ComponentDirective && ((ComponentDirective)lvi.Tag).ComponentId == component.ItemId);
        //                foreach (ListViewItem listViewItem in items)
        //                {
        //                    listViewItem.Group = item.Group;
        //                    resultList.Add(listViewItem);

        //                    ComponentDirective componentDirective = (ComponentDirective)listViewItem.Tag;
        //                    if (componentDirective.NextPerformances == null || componentDirective.NextPerformances.Count <= 1) continue;
        //                    //Если кол-во расчитанных выполнений больше одного
        //                    //то в результирующую коллекцию добавлются строки след. выполений
        //                    for (int i = 1; i < componentDirective.NextPerformances.Count; i++)
        //                    {
        //                        ListViewItem temp = new ListViewItem(GetListViewSubItems(componentDirective.NextPerformances[i]), null)
        //                        {
        //                            Tag = componentDirective.NextPerformances[i],
        //                            Group = item.Group
        //                        };
        //                        resultList.Add(temp);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        foreach (ListViewItem item in ListViewItemList)
        //        {
        //            if (item.Tag is Component)
        //            {
        //                //Если привязанным элементом является деталь
        //                //то в результирующий список следом за ней добавляются ее директивы
        //                resultList.Add(item);
        //                Component component = (Component)item.Tag;
        //                if (component.NextPerformances != null && component.NextPerformances.Count > 1)
        //                {
        //                    //Если кол-во расчитанных выполнений больше одного
        //                    //то в результирующую коллекцию добавлются строки след. выполений
        //                    for (int i = 1; i < component.NextPerformances.Count; i++)
        //                    {
        //                        ListViewItem temp = new ListViewItem(GetListViewSubItems(component.NextPerformances[i]), null)
        //                        {
        //                            Tag = component.NextPerformances[i],
        //                            Group = item.Group
        //                        };
        //                        resultList.Add(temp);
        //                    }
        //                }
        //                var items =
        //                    ListViewItemList
        //                    .Where(lvi => lvi.Tag is ComponentDirective && ((ComponentDirective)lvi.Tag).ComponentId == component.ItemId);
        //                foreach (ListViewItem listViewItem in items)
        //                {
        //                    listViewItem.Group = item.Group;
        //                    resultList.Add(listViewItem);

        //                    ComponentDirective componentDirective = (ComponentDirective)listViewItem.Tag;
        //                    if (componentDirective.NextPerformances == null || componentDirective.NextPerformances.Count <= 1) continue;
        //                    //Если кол-во расчитанных выполнений больше одного
        //                    //то в результирующую коллекцию добавлются строки след. выполений
        //                    for (int i = 1; i < componentDirective.NextPerformances.Count; i++)
        //                    {
        //                        ListViewItem temp = new ListViewItem(GetListViewSubItems(componentDirective.NextPerformances[i]), null)
        //                        {
        //                            Tag = componentDirective.NextPerformances[i],
        //                            Group = item.Group
        //                        };
        //                        resultList.Add(temp);
        //                    }
        //                }
        //            }
        //        }

        //        resultList.Sort(new DirectiveListViewComparer(columnIndex, SortMultiplier));
        //        itemsListView.Groups.Clear();
        //        foreach (ListViewItem item in resultList)
        //        {
        //            DateTime date = DateTimeExtend.GetCASMinDateTime();
        //            if (item.Tag is NextPerformance)
        //            {
        //                NextPerformance np = (NextPerformance)item.Tag;
        //                if (np.PerformanceDate != null)
        //                    date = np.PerformanceDate.Value.Date;
        //            }
        //            else if(item.Tag is IDirective)
        //            {
        //                IDirective np = (IDirective)item.Tag;
        //                if (np.NextPerformanceDate != null)
        //                    date = np.NextPerformanceDate.Value.Date;    
        //            }

        //            string temp = date.Date > DateTimeExtend.GetCASMinDateTime().Date ? SmartCore.Auxiliary.Convert.GetDateFormat(date.Date) : "";
        //            itemsListView.Groups.Add(temp, temp);
        //            item.Group = itemsListView.Groups[temp];
        //        }

        //    }
        //    itemsListView.Items.AddRange(resultList.ToArray());
        //}

        #endregion

        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

        protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            if (SelectedItem != null)
	        {
		        var dp = ScreenAndFormManager.GetEditScreenOrForm((BaseEntityObject) SelectedItem);
		        if (dp.DisplayerType == DisplayerType.Screen)
			        e.SetParameters(dp);
		        else
				{
					if (dp.Form.ShowDialog() == DialogResult.OK)
					{
						if (dp.Form is ConsumablePartAndKitForm)
						{
							var changedJob = ((ConsumablePartAndKitForm)dp.Form)._consumablePart;
							radGridView1.SelectedRows[0].Tag = changedJob;

							var subs = GetListViewSubItems(SelectedItem);
							for (int i = 0; i < subs.Count; i++)
								radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
						}
					}

					e.Cancel = true;
				}
			}
        }
        #endregion

        #region protected override void SetItemColor(ListViewItem listViewItem, IBaseCoreObject item)
		//TODO COLOR!
      //  protected override void SetItemColor(ListViewItem listViewItem, IBaseCoreObject item)
      //  {
      //      if (item is NextPerformance)
      //      {
      //          listViewItem.ForeColor = Color.Gray;
      //          if (((NextPerformance)item).BlockedByPackage != null)
      //          {
      //              listViewItem.BackColor = Color.FromArgb(Highlight.Grey.Color);
      //              listViewItem.ToolTipText = "This performance is involved on Work Package:" + ((NextPerformance)item).BlockedByPackage.Title;
      //          }
      //      }
      //      else if (item is IDirective)
      //      {
      //          listViewItem.ForeColor = Color.Black;
      //          if (item is Component)
      //          {
      //              Component component = (Component) item;
      //              if (component.Condition == ConditionState.NotEstimated)
      //                  listViewItem.BackColor = Color.FromArgb(Highlight.Blue.Color);
      //              if (/*component.Current == component.ShouldBeOnStock && component.ShouldBeOnStock > 0 ||*/
						//component.Condition == ConditionState.Notify)
      //                  listViewItem.BackColor = Color.FromArgb(Highlight.Yellow.Color);   
      //              if (/*component.Current < component.ShouldBeOnStock ||*/
      //                  component.Condition == ConditionState.Overdue)
      //                  listViewItem.BackColor = Color.FromArgb(Highlight.Red.Color); 
      //          }
      //          else if (item is ComponentDirective)
      //          {
      //              ComponentDirective comp = (ComponentDirective)item;
      //              if (comp.Condition == ConditionState.NotEstimated)
      //                  listViewItem.BackColor = Color.FromArgb(Highlight.Blue.Color);
      //              if (comp.Condition == ConditionState.Notify)
      //                  listViewItem.BackColor = Color.FromArgb(Highlight.Yellow.Color);
      //              if (comp.Condition == ConditionState.Overdue)
      //                  listViewItem.BackColor = Color.FromArgb(Highlight.Red.Color);
      //          }

      //          IDirective dir = item as IDirective;
      //          if (dir.NextPerformances.Count > 0 && dir.NextPerformances[0].BlockedByPackage != null)
      //          {
      //              listViewItem.BackColor = Color.FromArgb(Highlight.Grey.Color);
      //              listViewItem.ToolTipText = "This performance is involved on Work Package:" + dir.NextPerformances[0].BlockedByPackage.Title;
      //          }
      //      }
      //  }
        #endregion

        #endregion
    }
}
