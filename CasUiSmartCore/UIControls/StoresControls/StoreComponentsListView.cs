using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
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
    public partial class StoreComponentsListView : BaseListViewControl<IBaseCoreObject>
    {
        #region public StoreDetailsListView()
        ///<summary>
        ///</summary>
        public StoreComponentsListView()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        #region protected override void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
            itemsListView.Columns.Clear();
            ColumnHeaderList.Clear();

            ColumnHeader columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "ATA" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Part. No" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Alt Part. No" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Standart" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Name" };
            ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.3f), Text = "Description" };
            ColumnHeaderList.Add(columnHeader);
            //4
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Serial No" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Code" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Class" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Batch No" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "ID No" };
            ColumnHeaderList.Add(columnHeader);
            //5
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "State" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Status" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Location" };
            ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Facility" };
			ColumnHeaderList.Add(columnHeader);
			//6
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.07f), Text = "M.P." };
            ColumnHeaderList.Add(columnHeader);
            //7
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "From" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Inst. date" };
            ColumnHeaderList.Add(columnHeader);
            //6
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.07f), Text = "Work Type" };
            ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = 75, Text = "M.H." };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.07f), Text = "Need Wp Q-ty" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.07f), Text = "Reserve" };
			ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Life limit/1st. Perf" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Rpt. int." };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 0, Text = "Performances" };
            ColumnHeaderList.Add(columnHeader);
            //9
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Next" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Remain/Overdue" };
            ColumnHeaderList.Add(columnHeader);
            //11
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Last" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Warranty" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Kit" };
            ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.07f), Text = "Current" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.07f), Text = "Should be" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.07f), Text = "Qty In" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = 75, Text = "Unit Price" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 75, Text = "Total Price" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 75, Text = "Ship Price" };
            ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = 75, Text = "SubTotal" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = 75, Text = "Tax" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = 75, Text = "Tax1" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = 75, Text = "Tax2" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = 75, Text = "Total" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = 75, Text = "Currency" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = 75, Text = "Supplier" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Remarks" };
            ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "IsPool" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "IsDangerous" };
			ColumnHeaderList.Add(columnHeader);
			//19
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Hidden Remarks" };
            ColumnHeaderList.Add(columnHeader);

            itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
        #endregion

        #region protected override void AddItems(IBaseCoreObject[] itemsArray)
        /// <summary>
        /// Добавляет элементы в ListView
        /// </summary>
        /// <param name="itemsArray"></param>
        protected override void AddItems(IBaseCoreObject[] itemsArray)
        {
            ColumnHeader ch = ColumnHeaderList.FirstOrDefault(h => h.Text == "Performances");
            if (ch == null)
            {
                base.AddItems(itemsArray);
                return;
            }
            
            if(itemsArray == null || itemsArray.Length == 0)
            {
                ch.Width = 0;
                base.AddItems(itemsArray);
                return;
            }
            ch.Width = itemsArray.OfType<IDirective>()
                                 .Count(d => d.NextPerformances != null && d.NextPerformances.Count > 1) > 0 ? 100 : 0;

            base.AddItems(itemsArray);
        }

		#endregion

		#region protected override void SetGroupsToItems(int columnIndex)

		/// <summary>
		/// Возвращает название группы в списке агрегатов текущего склада, согласно тому, какого типа элемент
		/// </summary>
		protected override void SetGroupsToItems(int columnIndex)
        {
            itemsListView.Groups.Clear();
            itemsListView.Groups.AddRange(new[]
                                              {
                                                  new ListViewGroup("Engines", "Engines"),
                                                  new ListViewGroup("APU's", "APU's"),
                                                  new ListViewGroup("Landing Gears", "Landing Gears"),
                                              });
            foreach (ListViewItem item in ListViewItemList.OrderBy(x => x.Text))
            {
                String temp = "";

                if (!(item.Tag is IDirective)) continue;

                IDirective parent = (IDirective)item.Tag;

                #region Группировка по типу задачи

                if (parent is ComponentDirective)
                    parent = ((ComponentDirective) parent).ParentComponent;
                if (parent is BaseComponent)
                {
                    if (((BaseComponent)parent).BaseComponentType == BaseComponentType.Engine)
                        temp = "Engines";
                    else if (((BaseComponent)parent).BaseComponentType == BaseComponentType.Apu)
                        temp = "APU's";
                    else if (((BaseComponent)parent).BaseComponentType == BaseComponentType.LandingGear)
                        temp = "Landing Gears";

                    item.Group = itemsListView.Groups[temp];
                }
                else if (parent is Component)
                {
                    Component component = (Component)parent;

                        if (component.ParentBaseComponent != null)
                        {
                            BaseComponent baseComponent = component.ParentBaseComponent;//TODO:(Evgenii Babak) заменить на использование ComponentCore 
							temp = baseComponent + " Components";
                        }
                        else
                        {
	                        AtaChapter ata = null;

							if (component.Product != null)
							{
								ata = component.Product.ATAChapter;
							}
	                        else ata = component.ATAChapter;
                            
                            temp = ata.ShortName + " " + ata.FullName;
                        }
                        itemsListView.Groups.Add(temp, temp);
                    item.Group = itemsListView.Groups[temp];
                }
                #endregion
            }
        }

        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(IBaseCoreObject item)

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(IBaseCoreObject item)
        {
            var subItems = new List<ListViewItem.ListViewSubItem>();

            DateTime? approx = null;
            AtaChapter ata;
            string maintenanceTypeString = "";
            DateTime transferDate = DateTimeExtend.GetCASMinDateTime();
	        bool isPool = false, IsDangerous = false;
            Lifelength firstPerformance = Lifelength.Null,
                       lastPerformance = Lifelength.Null,
                       remains = null,
                       next = null,
                       warranty = Lifelength.Null, repeatInterval = Lifelength.Null;
	        string partNumber = "",
                   description = "",
                   altPartNumber = "",
                   standart = "",
                   name = "",
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
			var position = ComponentStorePosition.UNK;
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
                    return subItems.ToArray();
                timesString = parent.TimesToString;
                times = parent.Times;
            }

            if (parent is Component)
            {
                Component componentItem = (Component)parent;
                approx = componentItem.NextPerformanceDate;
                next = componentItem.NextPerformanceSource;
                remains = componentItem.Remains;
                ata = componentItem.Product?.ATAChapter ?? componentItem.ATAChapter;
				partNumber = componentItem.Product?.PartNumber ?? componentItem.PartNumber;
				altPartNumber = componentItem.Product?.AltPartNumber ?? componentItem.ALTPartNumber;
				standart = componentItem.Product?.Standart?.ToString() ?? componentItem.Standart?.ToString();
				name = componentItem.Product?.Name;
				description = componentItem.Description;
                serialNumber = componentItem.SerialNumber;
                code = componentItem.Product != null ? componentItem.Product.Code :componentItem.Code;
                classString = componentItem.GoodsClass.ToString();
                batchNumber = componentItem.BatchNumber;
                idNumber = componentItem.IdNumber;
                position = componentItem.TransferRecords.GetLast().State;
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
	            quantityInString = $"{quantityIn:0.##}" + (componentItem.Measure != null ? " " + componentItem.Measure + "(s)" : "");
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
				description = "    " + dd.ParentComponent.Description;
                maintenanceTypeString = dd.ParentComponent.MaintenanceControlProcess.ShortName;
                warranty = dd.Threshold.Warranty;
                kitRequieredString = dd.Kits.Count > 0 ? dd.Kits.Count + " kits" : "";
                kitCount = dd.Kits.Count;
                manHours = dd.ManHours;
                remarks = dd.Remarks;
                hiddenRemarks = dd.HiddenRemarks;
                workType = dd.DirectiveType.ToString();
				position = dd.ParentComponent.TransferRecords.GetLast().State;
				isPool = dd.IsPOOL;
				IsDangerous = dd.IsDangerous;
			}
            else
            {
                ata = (AtaChapter)GlobalObjects.CasEnvironment.GetDictionary<AtaChapter>().GetItemById(21);
            }

            subItems.Add(new ListViewItem.ListViewSubItem { Text = ata.ToString(), Tag = ata } ); 
            subItems.Add(new ListViewItem.ListViewSubItem { Text = partNumber, Tag = partNumber } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = altPartNumber, Tag = altPartNumber } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = standart, Tag = standart } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = name, Tag = name } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = description, Tag = description } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = serialNumber, Tag = serialNumber } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = code, Tag = code });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = classString, Tag = classString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = batchNumber, Tag = batchNumber });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = idNumber, Tag = idNumber });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = position?.ToString().ToUpper(), Tag = position } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = status, Tag = status });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = location, Tag = location });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = facility, Tag = facility });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = maintenanceTypeString, Tag = maintenanceTypeString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = from, Tag = from });
            subItems.Add(new ListViewItem.ListViewSubItem
            {
                Text = transferDate > DateTimeExtend.GetCASMinDateTime()
					? SmartCore.Auxiliary.Convert.GetDateFormat(transferDate) : "",
                Tag = transferDate
            });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = workType, Tag = workType });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = manHours.ToString(), Tag = manHours } );
            


			subItems.Add(new ListViewItem.ListViewSubItem { Text = needWpQuantity.ToString(), Tag = needWpQuantity });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = reserve.ToString(), Tag = reserve });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = firstPerformance.ToString(), Tag = firstPerformance });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = repeatInterval.ToString(), Tag = repeatInterval });

            subItems.Add(new ListViewItem.ListViewSubItem { Text = timesString, Tag = times });

            subItems.Add(new ListViewItem.ListViewSubItem
            {
                Text = approx != null 
                    ? SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)approx) + " " + next
                    : next != null && !next.IsNullOrZero()
                        ? next.ToString()
                        : "",
                Tag = approx == null ? DateTimeExtend.GetCASMinDateTime() : (DateTime)approx
            } );
            subItems.Add(new ListViewItem.ListViewSubItem
            {
                Text = remains != null && !remains.IsNullOrZero()
                                       ? remains.ToString()
                                       : "",
                Tag = remains ?? Lifelength.Null
            } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = lastPerformanceString, Tag = lastPerformance } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = warranty.ToString(), Tag = warranty } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = kitRequieredString, Tag = kitCount });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = quantityString, Tag = quantity });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = shouldBeOnStockString, Tag = shouldBeOnStock });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = quantityInString, Tag = quantityIn });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = unitPrice.ToString(), Tag = unitPrice } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = totalPrice.ToString(), Tag = totalPrice } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = shipPrice.ToString(), Tag = shipPrice } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = subTotal.ToString(), Tag = subTotal } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = tax1.ToString(), Tag = tax1 } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = tax2.ToString(), Tag = tax2 } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = tax3.ToString(), Tag = tax3 } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = total.ToString(), Tag = total } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = currency, Tag = currency } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = supplier, Tag = supplier } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = remarks, Tag = remarks } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = isPool ? "Yes" : "No", Tag = isPool } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = IsDangerous ? "Yes" : "No", Tag = IsDangerous } );
            subItems.Add(new ListViewItem.ListViewSubItem { Text = hiddenRemarks, Tag = hiddenRemarks } );

            return subItems.ToArray();
        }

        #endregion

        #region protected override void SortItems(int columnIndex)

        protected override void SortItems(int columnIndex)
        {
            if (OldColumnIndex != columnIndex)
                SortMultiplier = -1;
            if (SortMultiplier == 1)
                SortMultiplier = -1;
            else
                SortMultiplier = 1;
            itemsListView.Items.Clear();
            OldColumnIndex = columnIndex;

            SetGroupsToItems(columnIndex);

            List<ListViewItem> resultList = new List<ListViewItem>();

            if (columnIndex != 13)
            {
                ListViewItemList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));
                //добавление остальных подзадач
                foreach (ListViewItem item in ListViewItemList)
                {
                    if (item.Tag is Component)
                    {
                        resultList.Add(item);
                        Component component = (Component) item.Tag;
                        if (component.NextPerformances != null && component.NextPerformances.Count > 1)
                        {
                            //Если кол-во расчитанных выполнений больше одного
                            //то в результирующую коллекцию добавлются строки след. выполений
                            for (int i = 1; i < component.NextPerformances.Count; i++)
                            {
                                ListViewItem temp = new ListViewItem(GetListViewSubItems(component.NextPerformances[i]), null)
                                {
                                    Tag = component.NextPerformances[i],
                                    Group = item.Group
                                };
                                resultList.Add(temp);
                            }
                        }
                        //Если привязанным элементом является деталь
                        //то в результирующий список следом за ней добавляются ее директивы
                        IEnumerable<ListViewItem> items =
                            ListViewItemList
                            .Where(lvi => lvi.Tag is ComponentDirective && ((ComponentDirective)lvi.Tag).ComponentId == component.ItemId);
                        foreach (ListViewItem listViewItem in items)
                        {
                            listViewItem.Group = item.Group;
                            resultList.Add(listViewItem);

                            ComponentDirective componentDirective = (ComponentDirective)listViewItem.Tag;
                            if (componentDirective.NextPerformances == null || componentDirective.NextPerformances.Count <= 1) continue;
                            //Если кол-во расчитанных выполнений больше одного
                            //то в результирующую коллекцию добавлются строки след. выполений
                            for (int i = 1; i < componentDirective.NextPerformances.Count; i++)
                            {
                                ListViewItem temp = new ListViewItem(GetListViewSubItems(componentDirective.NextPerformances[i]), null)
                                {
                                    Tag = componentDirective.NextPerformances[i],
                                    Group = item.Group
                                };
                                resultList.Add(temp);
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (ListViewItem item in ListViewItemList)
                {
                    if (item.Tag is Component)
                    {
                        //Если привязанным элементом является деталь
                        //то в результирующий список следом за ней добавляются ее директивы
                        resultList.Add(item);
                        Component component = (Component)item.Tag;
                        if (component.NextPerformances != null && component.NextPerformances.Count > 1)
                        {
                            //Если кол-во расчитанных выполнений больше одного
                            //то в результирующую коллекцию добавлются строки след. выполений
                            for (int i = 1; i < component.NextPerformances.Count; i++)
                            {
                                ListViewItem temp = new ListViewItem(GetListViewSubItems(component.NextPerformances[i]), null)
                                {
                                    Tag = component.NextPerformances[i],
                                    Group = item.Group
                                };
                                resultList.Add(temp);
                            }
                        }
                        IEnumerable<ListViewItem> items =
                            ListViewItemList
                            .Where(lvi => lvi.Tag is ComponentDirective && ((ComponentDirective)lvi.Tag).ComponentId == component.ItemId);
                        foreach (ListViewItem listViewItem in items)
                        {
                            listViewItem.Group = item.Group;
                            resultList.Add(listViewItem);

                            ComponentDirective componentDirective = (ComponentDirective)listViewItem.Tag;
                            if (componentDirective.NextPerformances == null || componentDirective.NextPerformances.Count <= 1) continue;
                            //Если кол-во расчитанных выполнений больше одного
                            //то в результирующую коллекцию добавлются строки след. выполений
                            for (int i = 1; i < componentDirective.NextPerformances.Count; i++)
                            {
                                ListViewItem temp = new ListViewItem(GetListViewSubItems(componentDirective.NextPerformances[i]), null)
                                {
                                    Tag = componentDirective.NextPerformances[i],
                                    Group = item.Group
                                };
                                resultList.Add(temp);
                            }
                        }
                    }
                }

                resultList.Sort(new DirectiveListViewComparer(columnIndex, SortMultiplier));
                itemsListView.Groups.Clear();
                foreach (ListViewItem item in resultList)
                {
                    DateTime date = DateTimeExtend.GetCASMinDateTime();
                    if (item.Tag is NextPerformance)
                    {
                        NextPerformance np = (NextPerformance)item.Tag;
                        if (np.PerformanceDate != null)
                            date = np.PerformanceDate.Value.Date;
                    }
                    else if(item.Tag is IDirective)
                    {
                        IDirective np = (IDirective)item.Tag;
                        if (np.NextPerformanceDate != null)
                            date = np.NextPerformanceDate.Value.Date;    
                    }

                    string temp = date.Date > DateTimeExtend.GetCASMinDateTime().Date ? SmartCore.Auxiliary.Convert.GetDateFormat(date.Date) : "";
                    itemsListView.Groups.Add(temp, temp);
                    item.Group = itemsListView.Groups[temp];
                }

            }
            itemsListView.Items.AddRange(resultList.ToArray());
        }

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
							itemsListView.SelectedItems[0].Tag = changedJob;

							var subs = GetListViewSubItems(SelectedItem);
							for (int i = 0; i < subs.Length; i++)
								itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;
						}
					}

					e.Cancel = true;
				}
			}
        }
        #endregion

        #region protected override void SetItemColor(ListViewItem listViewItem, IBaseCoreObject item)
        protected override void SetItemColor(ListViewItem listViewItem, IBaseCoreObject item)
        {
            if (item is NextPerformance)
            {
                listViewItem.ForeColor = Color.Gray;
                if (((NextPerformance)item).BlockedByPackage != null)
                {
                    listViewItem.BackColor = Color.FromArgb(Highlight.Grey.Color);
                    listViewItem.ToolTipText = "This performance is involved on Work Package:" + ((NextPerformance)item).BlockedByPackage.Title;
                }
            }
            else if (item is IDirective)
            {
                listViewItem.ForeColor = Color.Black;
                if (item is Component)
                {
                    Component component = (Component) item;
                    if (component.Condition == ConditionState.NotEstimated)
                        listViewItem.BackColor = Color.FromArgb(Highlight.Blue.Color);
                    if (component.Current == component.ShouldBeOnStock && component.ShouldBeOnStock > 0||
                        component.Condition == ConditionState.Notify)
                        listViewItem.BackColor = Color.FromArgb(Highlight.Yellow.Color);   
                    if (component.Current < component.ShouldBeOnStock ||
                        component.Condition == ConditionState.Overdue)
                        listViewItem.BackColor = Color.FromArgb(Highlight.Red.Color); 
                }
                else if (item is ComponentDirective)
                {
                    ComponentDirective comp = (ComponentDirective)item;
                    if (comp.Condition == ConditionState.NotEstimated)
                        listViewItem.BackColor = Color.FromArgb(Highlight.Blue.Color);
                    if (comp.Condition == ConditionState.Notify)
                        listViewItem.BackColor = Color.FromArgb(Highlight.Yellow.Color);
                    if (comp.Condition == ConditionState.Overdue)
                        listViewItem.BackColor = Color.FromArgb(Highlight.Red.Color);
                }

                IDirective dir = item as IDirective;
                if (dir.NextPerformances.Count > 0 && dir.NextPerformances[0].BlockedByPackage != null)
                {
                    listViewItem.BackColor = Color.FromArgb(Highlight.Grey.Color);
                    listViewItem.ToolTipText = "This performance is involved on Work Package:" + dir.NextPerformances[0].BlockedByPackage.Title;
                }
            }
        }
        #endregion

        #endregion
    }
}
