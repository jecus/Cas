using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PurchaseControls
{
    /// <summary>
    /// Управляет созданием и отображением начальных, котировочных и закупочных актов
    /// </summary>
    public class PurchaseManager
    {



		#region public static void ComposeInitialOrder(IBaseCoreObject[] itemsForComposeQuotation, BaseEntityObject parent, Control owner = null)
		/// <summary>
		/// Создает Первоначальный заказ
		/// </summary>
		//TODO:найти метод по коду и удалить все пункты меню!!!!!!!! (PurchaseManager.ComposeInitialOrder)
		public static void ComposeInitialOrder(IBaseCoreObject[] itemsForOrder,
                                               BaseEntityObject parent,
                                               Control owner = null)
        {
            //if (itemsForOrder == null || itemsForOrder.Length == 0
            //    || parent == null)
            //    return;

            //List<KeyValuePair<Product, double>> quotationList;

            //if (!TransformToProducts(itemsForOrder, out quotationList, owner))
            //    return;

            //InitialOrderComposeForm composeForm = new InitialOrderComposeForm(parent, quotationList.Select(l => l.Key));

            //if (composeForm.ShowDialog(owner) != DialogResult.OK) return;
            //try
            //{
            //    string message;
            //    InitialOrder rqst =
            //        GlobalObjects.PurchaseCore.AddInitialOrder(composeForm.ResultRecords, parent, out message);
            //    if (rqst == null)
            //    {
            //        MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //    ReferenceEventArgs refArgs = new ReferenceEventArgs();
            //    refArgs.TypeOfReflection = ReflectionTypes.DisplayInNew;
            //    refArgs.DisplayerText = rqst.Title;
            //    refArgs.RequestedEntity = new InitionalOrderScreen(rqst);
            //    Program.MainDispatcher.DisplayerRequest(refArgs);
            //}
            //catch (Exception ex)
            //{
            //    Program.Provider.Logger.Log("error while create Initial order", ex);
            //}
        }
		#endregion

		#region public static void ComposeInitialOrder(KeyValuePair<IBaseEntityObject, NextPerformance>[] itemsForOrder, BaseEntityObject parent, Control owner = null)
		/// <summary>
		/// Создает Первоначальный заказ
		/// </summary>
		//TODO:найти метод по коду и удалить все пункты меню!!!!!!!! (PurchaseManager.ComposeInitialOrder)
		public static void ComposeInitialOrder(NextPerformance[] itemsForOrder,
                                               BaseEntityObject parent,
                                               Control owner = null)
        {
            //ComposeInitialOrder(itemsForOrder.Select(n => new KeyValuePair<IBaseEntityObject, NextPerformance>(n.Parent, n)).ToArray(), 
            //                    parent, 
            //                    owner);
        }
		#endregion


		#region public static void ComposeQuotationOrder(IBaseCoreObject[] itemsForComposeQuotation, BaseEntityObject parent, Control owner = null)
		//TODO:найти метод по коду и удалить все пункты меню!!!!!!!! (PurchaseManager.ComposeQuotationOrder)
		public static void ComposeQuotationOrder(IBaseCoreObject[] itemsForComposeQuotation, BaseEntityObject parent, Control owner = null)
        {
            //if(itemsForComposeQuotation == null || itemsForComposeQuotation.Length == 0
            //    || parent == null)
            //    return;

            //List<KeyValuePair<Product, double>> quotationList;

            //if (!TransformToProducts(itemsForComposeQuotation, out quotationList, owner)) 
            //    return;
            //QuotationOrderComposeForm composeForm = new QuotationOrderComposeForm(quotationList.Select(l => l.Key));
            //if (composeForm.ShowDialog(owner) != DialogResult.OK) 
            //    return;

            //IEnumerable<IGrouping<Supplier, RequestForQuotationRecord>> groupedQuotations =
            //    composeForm.ResultRecord.GroupBy(r => r.ToSupplier);

            //List<RequestForQuotation> composedQuotations = new List<RequestForQuotation>();
            //foreach (IGrouping<Supplier, RequestForQuotationRecord> grouping in groupedQuotations)
            //{
            //    try
            //    {
            //        string message;
            //        RequestForQuotation rqst =
            //            GlobalObjects.PurchaseCore.AddQuotationOrder(grouping.Select(g => g), grouping.Key, parent, out message);
            //        if (rqst == null)
            //        {
            //            MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
            //                MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            continue;
            //        }
            //        composedQuotations.Add(rqst);
            //    }
            //    catch (Exception ex)
            //    {
            //        Program.Provider.Logger.Log("error while create Quotaion order", ex);
            //    }    
            //}

            //foreach (RequestForQuotation quotation in composedQuotations)
            //{
            //    try
            //    {
            //        ReferenceEventArgs refArgs = new ReferenceEventArgs
            //        {
            //            TypeOfReflection = ReflectionTypes.DisplayInNew,
            //            DisplayerText = quotation.Title,
            //            RequestedEntity = new RequestForQuotationScreen(quotation)
            //        };
            //        Program.MainDispatcher.DisplayerRequest(refArgs);
            //    }
            //    catch (Exception ex)
            //    {
            //        Program.Provider.Logger.Log("error while create Quotaion order", ex);
            //    }
            //}
        }
		#endregion

		#region public static void AddToQuotationOrder(RequestForQuotation wp, IBaseCoreObject[] itemsForComposeQuotation, Control owner = null)
		/// <summary>
		/// Добавляет элемент в указанный котировочный акт
		/// </summary>
		/// <param name="quotation">Акт, в который будут добавлены элементы</param>
		/// <param name="itemsForComposeQuotation">Элементы, из которых будут формироватся элементы для котировочного акта</param>
		/// <param name="owner">ЭУ из которого производится запрос о добавлении элементов</param>
		//TODO:найти метод по коду и удалить все пункты меню!!!!!!!! (PurchaseManager.AddToQuotationOrder)
		public static void AddToQuotationOrder(RequestForQuotation quotation, IBaseCoreObject[] itemsForComposeQuotation, Control owner = null)
        {
            //if (quotation == null || itemsForComposeQuotation == null || itemsForComposeQuotation.Length == 0)
            //    return;

            //if (MessageBox.Show("Add item to Quotation Order: " + quotation.Title + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
            //    DialogResult.Yes)
            //{
            //    //Список комплектующих закупочного акта
            //    var quotationList = new List<KeyValuePair<Product, double>>();
            //    //все выбранные элементы
            //    var allSelected = new List<IBaseCoreObject>();
            //    foreach (IBaseCoreObject coreObject in itemsForComposeQuotation)
            //    {
            //        if (coreObject is NextPerformance)
            //            allSelected.Add(((NextPerformance)coreObject).Parent);
            //        else if (coreObject is AbstractPerformanceRecord)
            //            allSelected.Add(((AbstractPerformanceRecord)coreObject).Parent);
            //        else allSelected.Add(coreObject);
            //    }
            //    //определение задач по компонентам
            //    var componentDirectives = allSelected.OfType<ComponentDirective>().ToList();
            //    //определение задач по компонентам имеющих КИТы
            //    var componentDirectivesWithKits = componentDirectives.Where(dd => dd.Kits.Count > 0).ToList();
            //    //определение компонентов имеющих киты 
            //    var componentsWithKits = allSelected.OfType<Component>().Where(d => d.Kits.Count > 0).ToList();
            //    componentsWithKits.AddRange(componentDirectives.Select(dd => dd.ParentComponent).Where(d => d.Kits.Count > 0));
            //    componentsWithKits = componentsWithKits.Distinct().ToList();
            //    //определение компонентов имеющих киты 
            //    var componentsWithoutKits = allSelected.OfType<Component>().Where(d => d.Kits.Count == 0).ToList();
            //    componentsWithoutKits.AddRange(componentDirectives.Select(dd => dd.ParentComponent).Where(d => d.Kits.Count == 0));
            //    componentsWithoutKits = componentsWithoutKits.Distinct().ToList();
            //    //для формирования списка комплектующих закупочного ордера
            //    if (componentsWithKits.Count > 0 || componentDirectivesWithKits.Count > 0)
            //    {
            //        var form = new SelectAccessoryForm(componentsWithKits, componentDirectivesWithKits);
            //        if (form.ShowDialog() == DialogResult.OK)
            //        {
            //            quotationList.AddRange(form.Accessories);
            //        }
            //        //удаление деталей с КИТами из списка выбранных компонентов
            //        foreach (Component detailWithKit in componentsWithKits)
            //            allSelected.Remove(detailWithKit);
            //        //удаление деталей с КИТами из списка выбранных компонентов
            //        foreach (ComponentDirective detailDirective in componentDirectivesWithKits)
            //            allSelected.Remove(detailDirective);
            //    }
            //    if (componentsWithoutKits.Count > 0)
            //    {
            //        string message = "";
            //        foreach (Component d in componentsWithoutKits)
            //        {
            //            if (d.Model == null && !GlobalObjects.KitsCore.SetStandartAndProduct(d, ""))
            //            {
            //                string m = $"For Component P/N:{d.PartNumber} can not determinate Product. \nDeterminate product Manualy?";
            //                DialogResult res =
            //                    MessageBox.Show(m, (string)new GlobalTermsProvider()["SystemName"],
            //                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //                if (res == DialogResult.Yes)
            //                {
            //                    //Создание формы для формирования нового продукта
            //                    ComponentModel dm = new ComponentModel
            //                    {
            //                        BatchNumber = d.BatchNumber,
            //                        CostNew = d.CostNew,
            //                        CostOverhaul = d.CostOverhaul,
            //                        CostServiceable = d.CostServiceable,
            //                        Description = d.Description,
            //                        GoodsClass = d.GoodsClass,
            //                        ManufactureReg = d.ManufactureRegion,
            //                        Manufacturer = d.Manufacturer,
            //                        Measure = d.Measure,
            //                        PartNumber = d.PartNumber,
            //                        Remarks = d.Remarks,
            //                        SerialNumber = d.SerialNumber,
            //                        SupplierRelations = d.SupplierRelations
            //                    };
            //                    //Создание формы для формирования нового продукта
            //                    CommonEditorForm accessoryDescriptionForm =
            //                        new CommonEditorForm(dm);

            //                    if (accessoryDescriptionForm.ShowDialog(owner) == DialogResult.OK)
            //                    {
            //                        d.Model = accessoryDescriptionForm.CurrentObject as ComponentModel;

            //                        if (d.Product == null)
            //                        {
            //                            message += $"For Component P/N:{d.PartNumber} can not determinate Model.";
            //                            message += "\nAbort operation";
            //                            MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
            //                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                            return;
            //                        }

            //                        GlobalObjects.CasEnvironment.Manipulator.Save(d);
            //                    }
            //                    else
            //                    {
            //                        message += $"For Component P/N:{d.PartNumber} can not determinate Product.";
            //                        message += "\nAbort operation";
            //                        MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
            //                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                        return;
            //                    }
            //                }
            //                else
            //                {
            //                    message += $"For Component P/N:{d.PartNumber} can not determinate Product.";
            //                    message += "\nAbort operation";
            //                    MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
            //                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    return;
            //                }
            //            }
            //        }
            //        quotationList.AddRange(componentsWithoutKits.Select(d => new KeyValuePair<Product, double>(d.Product, 1)));
            //        //удаление деталей без КИТов из списка выбранных компонентов
            //        foreach (Component detailWothoutKits in componentsWithoutKits)
            //            allSelected.Remove(detailWothoutKits);
            //    }
            //    foreach (IBaseCoreObject item in allSelected)
            //    {
            //        List<AccessoryRequired> ars = new List<AccessoryRequired>();
            //        if (item is AccessoryRequired)
            //        {
            //            AccessoryRequired ar = (AccessoryRequired)item;
            //            ars.Add(ar);
            //        }
            //        else if (item is IKitRequired)
            //        {
            //            ars.AddRange(((IKitRequired)item).Kits);
            //        }
            //        else if (item is Product)
            //        {
            //            Product p = item as Product;
            //            quotationList.Add(new KeyValuePair<Product, double>(p, 1));
            //        }
            //        string message = "";
            //        foreach (AccessoryRequired kit in ars)
            //        {
            //            if (kit.Product == null && !GlobalObjects.KitsCore.SetStandartAndProduct(kit, ""))
            //            {
            //                string m = $"For KIT P/N:{kit.PartNumber} can not determinate Product. \nDeterminate product Manualy?";
            //                DialogResult res =
            //                    MessageBox.Show(m, (string)new GlobalTermsProvider()["SystemName"],
            //                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //                if (res == DialogResult.Yes)
            //                {
            //                    //Создание формы для формирования нового продукта
            //                    //Создание формы для формирования нового продукта
            //                    Product p = new Product
            //                    {
            //                        BatchNumber = kit.BatchNumber,
            //                        CostNew = kit.CostNew,
            //                        CostOverhaul = kit.CostOverhaul,
            //                        CostServiceable = kit.CostServiceable,
            //                        Description = kit.Description,
            //                        GoodsClass = kit.GoodsClass,
            //                        Manufacturer = kit.Manufacturer,
            //                        Measure = kit.Measure,
            //                        PartNumber = kit.PartNumber,
            //                        Remarks = kit.Remarks,
            //                        SerialNumber = kit.SerialNumber,
            //                        SupplierRelations = kit.SupplierRelations
            //                    };
            //                    //Создание формы для формирования нового продукта
            //                    ProductForm accessoryDescriptionForm =
            //                        new ProductForm(p);

            //                    if (accessoryDescriptionForm.ShowDialog(owner) == DialogResult.OK)
            //                    {
            //                        kit.Product = accessoryDescriptionForm.CurrentObject as Product;

            //                        if (kit.Product == null)
            //                        {
            //                            message += $"For KIT P/N:{kit.PartNumber} can not determinate Product.";
            //                            message += "\nAbort operation";
            //                            MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
            //                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                            return;
            //                        }

            //                        GlobalObjects.CasEnvironment.Manipulator.Save(kit);
            //                    }
            //                    else
            //                    {
            //                        message += $"For KIT P/N:{kit.PartNumber} can not determinate Product.";
            //                        message += "\nAbort operation";
            //                        MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
            //                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                        return;
            //                    }
            //                }
            //                else
            //                {
            //                    message += $"For KIT P/N:{kit.PartNumber} can not determinate Product.";
            //                    message += "\nAbort operation";
            //                    MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
            //                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    return;
            //                }
            //            }
            //        }
            //        quotationList.AddRange(ars.Select(d => new KeyValuePair<Product, double>(d.Product, d.Quantity)));
            //    }
            //    if (quotationList.Count == 0)
            //    {
            //        MessageBox.Show("Selected item as not contain kits." + Environment.NewLine + "Abort operation",
            //                        new GlobalTermsProvider()["SystemName"].ToString());
            //        return;
            //    }
            //    try
            //    {
            //        string message;

            //        if (!GlobalObjects.PurchaseCore.AddToQuotationOrder(quotationList, quotation.ItemId, out message))
            //        {
            //            MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
            //                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            return;
            //        }

            //        if (MessageBox.Show("Items added successfully. Open Quotation Order?", (string)new GlobalTermsProvider()["SystemName"],
            //                             MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
            //                            == DialogResult.Yes)
            //        {
            //            ReferenceEventArgs refArgs = new ReferenceEventArgs();
            //            refArgs.TypeOfReflection = ReflectionTypes.DisplayInNew;
            //            refArgs.DisplayerText = quotation.Title;
            //            refArgs.RequestedEntity = new RequestForQuotationScreen(quotation);
            //            Program.MainDispatcher.DisplayerRequest(refArgs);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Program.Provider.Logger.Log("error while create Work Package", ex);
            //    }
            //}
        }

        #endregion

    }

    #region public class ScheduleDirectiveProduct
    /// <summary>
    /// Описывает планирование расходника на определенное выполнение определенной задачи 
    /// </summary>
    public class ScheduleDirectiveProduct
    {
        public IDirective Directive { get; private set; }
        public NextPerformance Performance { get; private set; }
        public Product Product { get; private set; }
        public double Quantity { get; private set; }

        public ScheduleDirectiveProduct(IDirective directive,
                                        NextPerformance performance,
                                        Product product,
                                        double quantity)
        {
            Directive = directive;
            Performance = performance;
            Product = product;
            Quantity = quantity;
        }
    }
    #endregion
}
