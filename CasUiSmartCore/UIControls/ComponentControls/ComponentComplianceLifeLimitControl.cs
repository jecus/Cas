using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CAS.UI.UIControls.DocumentationControls;
using CAS.UI.UIControls.KitControls;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using Component = SmartCore.Entities.General.Accessory.Component;

namespace CAS.UI.UIControls.ComponentControls
{
    ///<summary>
    /// ЭУ для отображения ресурса деталей
    ///</summary>
    [Designer(typeof(DetailComplianceLifeLimitControlDesigner))]
    public partial class ComponentComplianceLifeLimitControl : UserControl
    {
        #region Fields

        private Component _currentComponent;
        private readonly List<ComponentLifeLimitControlItem> _lifeLimitItems = new List<ComponentLifeLimitControlItem>();

        #endregion

        #region Constructors
       
        #region public DetailComplianceLifeLimitControl()
        ///<summary>
        ///</summary>
        public ComponentComplianceLifeLimitControl()
        {
            InitializeComponent();
        }
       
        #endregion

        #region public DetailComplianceLifeLimitControl(Detail currentDetail)

        /// <summary>
        /// Создает экземпляр отображатора информации об агрегате
        /// </summary>
        /// <param name="currentComponent">агрегат</param>
        public ComponentComplianceLifeLimitControl(Component currentComponent)
        {
            if (null == currentComponent)
                throw new ArgumentNullException("currentComponent", "Argument cannot be null");
            _currentComponent = currentComponent;
            InitializeComponent();

            UpdateInformation();
        }

        #endregion

        #endregion

        #region Propeties

        #region private double Cost

        /// <summary>
        /// Cost текущего агрегата
        /// </summary>
        private double Cost
        {
            get
            {
                double d;
                double.TryParse(textBoxCost.Text, out d);
                return d;
            }
            set
            {
                _currentComponent.CostNew = value;
                textBoxCost.Text = Math.Round(value, 2).ToString();
            }
        }

        #endregion

        #region private double CostOverhaul

        /// <summary>
        /// CostOverhaul текущего агрегата
        /// </summary>
        private double CostOverhaul
        {
            get
            {
                double d;
                double.TryParse(textBoxCostOverhaul.Text, out d);
                return d;
            }
            set
            {
                _currentComponent.CostOverhaul = value;
                textBoxCostOverhaul.Text = Math.Round(value, 2).ToString();
            }
        }

        #endregion

        #region private double CostServiceable

        /// <summary>
        /// CostServiceable текущего агрегата
        /// </summary>
        private double CostServiceable
        {
            get
            {
                double d;
                double.TryParse(textBoxCostServicible.Text, out d);
                return d;
            }
            set
            {
                _currentComponent.CostServiceable = value;
                textBoxCostServicible.Text = Math.Round(value, 2).ToString();
            }
        }

        #endregion

        #region private string Remarks

        /// <summary>
        /// Отображаемые замечания
        /// </summary>
        private string Remarks
        {
            get { return textBoxRemarks.Text; }
            set
            {
                textBoxRemarks.Text = value;
            }
        }

        #endregion

        #region private string HiddenRemarks

        /// <summary>
        /// Отображаемые замечания
        /// </summary>
        private string HiddenRemarks
        {
            get { return textBoxHiddenRemarks.Text; }
            set
            {
                textBoxHiddenRemarks.Text = value;
            }
        }

        #endregion

        #region private string KitRequered

        /// <summary>
        /// Отображаемое описание 
        /// </summary>
        private string KitRequered
        {
            get { return textBoxKitRequired.Text; }
            set
            {
                textBoxKitRequired.Text = value;
            }
        }

        #endregion

        #region private double ManHours

        /// <summary>
        /// ManHours текущего агрегата
        /// </summary>
        private double ManHours
        {
            get
            {
                double d;
                double.TryParse(textBoxManHours.Text, out d);
                return d;
            }
            set
            {
                _currentComponent.ManHours = value;
                textBoxManHours.Text = Math.Round(value, 2).ToString();
            }
        }

        #endregion

        #region public AbstractDetail CurrentDetail

        /// <summary>
        /// Задает или возвращает отображаемый агрегат
        /// </summary>
        public Component CurrentComponent
        {
            get { return _currentComponent; }
            set
            {
                _currentComponent = value;
                if (value != null) UpdateInformation();
            }
        }

        #endregion

        #region private Lifelength LifeLimit
        /// <summary>
        /// Ограничения срока службы агрегата
        /// </summary>
        private Lifelength LifeLimit
        {
            get
            {
                if (_lifeLimitItems == null || _lifeLimitItems.Count == 0)
                    return Lifelength.Null;
                
                foreach (ComponentLifeLimitControlItem item in _lifeLimitItems)
                    if (item.IsMainLimit) return item.LifeLimit;
                
                return Lifelength.Null;
            }
        }

        #endregion

        #region private Lifelength LifeLimitNotify
        /// <summary>
        /// После приближения текущей наработки к данной систему уведомляет пользователя о подходе к ограничению срока службы
        /// </summary>
        private Lifelength LifeLimitNotify
        {
            get
            {
                if (_lifeLimitItems == null || _lifeLimitItems.Count == 0)
                    return Lifelength.Null;
                foreach (ComponentLifeLimitControlItem item in _lifeLimitItems)
                    if (item.IsMainLimit) return item.LifeLimitNotify;
                return Lifelength.Null;
            }
        }

        #endregion

        #region private DetailLLPDataCollection CurrentLLPLifeLimit
        /// <summary>
        /// 
        /// </summary>
        private ComponentLLPDataCollection CurrentLLPLifeLimit
        {
            get
            {
                ComponentLLPDataCollection result = new ComponentLLPDataCollection();
                if (_lifeLimitItems != null && _lifeLimitItems.Count != 0)
                {
                    foreach (ComponentLifeLimitControlItem t in _lifeLimitItems)
                    {
                        result.Add(t.LLPData);
                    }
                }
                return result;
            }
        }

        #endregion

        #region public DateTime ManufactureDate
        ///<summary>
        /// Задает дату производства детали
        ///</summary>
        public DateTime ManufactureDate
        {
            set
            {
                _currentComponent.ManufactureDate = value;
                lifelengthTCSNOnInstall.Lifelength = 
                    GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength((BaseEntityObject)_currentComponent); 
            }
        }
        #endregion

        #endregion

        #region Methods

        #region public void ShowLifeLimit(bool llpMark, Aircraft parent)

        ///<summary>
        ///</summary>
        ///<param name="llpMark"></param>
        ///<param name="parent"></param>
        public void InitLifeLimit(bool llpMark, Aircraft parent)
        {
            foreach (ComponentLifeLimitControlItem item in _lifeLimitItems)
                flowLayoutPanelLifeLimit.Controls.Remove(item);
            _lifeLimitItems.Clear();
            
            if (llpMark && parent != null)
            {
                //деталь является вращающимся элементом двигателя
                //поиск номера модели самолета в строке название модели самолета
                if (int.Parse(parent.Model.Series) >= 300)
                {
                    //модель самолета выше модели 737-300
                    List<LLPLifeLimitCategory> list =
                        GlobalObjects.CasEnvironment.GetDictionary<LLPLifeLimitCategory>()
                            .OfType<LLPLifeLimitCategory>()
                            .Where(llp => llp.AircraftModel == parent.Model)
                            .ToList();
                    
                    if (list.Count == 0)
                    {
                        //если список категорий ресурса вращающихся деталей на данном самолете пуст
                        //добавление ресурса по умолчанию
                        ComponentLifeLimitControlItem newControl = new ComponentLifeLimitControlItem();
                        _lifeLimitItems.Add(newControl);
                        flowLayoutPanelLifeLimit.Controls.Remove(panelWarranty);
                        flowLayoutPanelLifeLimit.Controls.Add(newControl);
                        flowLayoutPanelLifeLimit.Controls.Add(panelWarranty);
                    }
                    else
                    {
                        //LINQ запрос для сортировки записей по дате;
                        List<LLPLifeLimitCategory> sortrecords = (from record in list
                                                                  orderby record.GetChar() ascending
                                                                  select record).ToList();

                        flowLayoutPanelLifeLimit.Controls.Remove(panelWarranty);
                        for (int i = 0; i < sortrecords.Count; i++)
                        {
                            ComponentLifeLimitControlItem newControl;
                            if (i != 0)
                            {
                                newControl = new ComponentLifeLimitControlItem();
                                newControl.IsMainLimit = true;
                            }
                            else newControl = new ComponentLifeLimitControlItem();


                            _lifeLimitItems.Add(newControl);
                            flowLayoutPanelLifeLimit.Controls.Add(newControl);
                        }
                        flowLayoutPanelLifeLimit.Controls.Add(panelWarranty);
                    }
                }
                else
                {
                    //модель самолета ниже 737-300
                    ComponentLifeLimitControlItem newControl = new ComponentLifeLimitControlItem();
                    _lifeLimitItems.Add(newControl);
                    flowLayoutPanelLifeLimit.Controls.Remove(panelWarranty);
                    flowLayoutPanelLifeLimit.Controls.Add(newControl);
                    flowLayoutPanelLifeLimit.Controls.Add(panelWarranty);
                }
            }
            else
            {
                //деталь не является вращающеися деталью двигателя, 
                //или не установлена на самолет
                ComponentLifeLimitControlItem newControl = new ComponentLifeLimitControlItem();
                _lifeLimitItems.Add(newControl);
                flowLayoutPanelLifeLimit.Controls.Remove(panelWarranty);
                flowLayoutPanelLifeLimit.Controls.Add(newControl);
                flowLayoutPanelLifeLimit.Controls.Add(panelWarranty);
            }
        }
        #endregion

        #region public bool GetChangeStatus(Detail detail)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        public bool GetChangeStatus(Component component)
        {
            try
            {
                if (!GlobalObjects.CasEnvironment.Calculator.IsEqual(Cost, component.Cost) ||
                    !GlobalObjects.CasEnvironment.Calculator.IsEqual(CostOverhaul, component.CostOverhaul) ||
                    !GlobalObjects.CasEnvironment.Calculator.IsEqual(CostServiceable, component.CostServiceable) ||
                    !GlobalObjects.CasEnvironment.Calculator.IsEqual(ManHours, component.ManHours) ||
                    KitRequered != component.KitRequired ||
                    Remarks != component.Remarks ||
                    HiddenRemarks != component.HiddenRemarks ||
                    !LifeLimit.IsEqual(component.LifeLimit) ||
                    !LifeLimitNotify.IsEqual(component.LifeLimitNotify) ||
                    !lifelengthViewerWarranty.Lifelength.IsEqual(component.Warranty) ||
                    !lifelengthViewerWarrantyNotify.Lifelength.IsEqual(component.WarrantyNotify) ||
                    (component is BaseComponent
                        ? component.LLPMark && ((BaseComponent)component).LLPCategories && CurrentLLPLifeLimit.ToString() != component.LLPData.ToString()
                        : component.LLPMark && component.LLPCategories && CurrentLLPLifeLimit.ToString() != component.LLPData.ToString()) ||
                    fileControl.GetChangeStatus())
                    return true;
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
                return true;
            }
            return false;

        }

        #endregion

        #region private void UpdateInformation()

        /// <summary>
        /// Заполняет поля для редактирования агрегата
        /// </summary>
        private void UpdateInformation()
        {
            if (_currentComponent == null)
                throw new ArgumentNullException("_current" + "Detail","must be not null");
            
            lifelengthViewerWarranty.Lifelength = _currentComponent.Warranty;
            lifelengthViewerWarrantyNotify.Lifelength = _currentComponent.WarrantyNotify;
            var d = _currentComponent;
	        var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_currentComponent.ParentAircraftId);//TODO:(Evgenii Babak) надо пересмотреть тюк из aiercraft тут исползуется только Model

            if (d.LLPMark && d.LLPCategories && parentAircraft != null)
            {
	            lifelengthTCSNOnInstall.Visible = false;

				//деталь является вращающимся элементом двигателя
				//поиск номера модели самолета в строке название модели самолета
				var pattern = @"(?<=\-\s*)\d+";
                //читается так:
                // ?<= -то, что должео идти перед искомой подстрокой
                // \- - тире
                // \s - пустое место(пробел); * -0 или более раз
                // \d - десятичная цифра; + -1 или более раз
                // из строки Boeing 737-300d - должно извлечь - 300
                var m = Regex.Match(parentAircraft.Model.ToString(), pattern);
				//TODO:Разобраться почему именно юольше 30
				//if (m.Success && int.Parse(m.Value) >= 30)
    //            {
                    //модель самолета выше модели 737-300
                    var list = GlobalObjects.CasEnvironment.GetDictionary<LLPLifeLimitCategory>()
                            .OfType<LLPLifeLimitCategory>()
                            .Where(llp => llp.AircraftModel.ItemId == parentAircraft.Model.ItemId)
                            .ToList();
                    if (list.Count == 0)
                    {
                        //если список категорий ресурса вращающихся деталей на данном самолете пуст
                        //добавление ресурса по умолчанию
                        var newControl = new ComponentLifeLimitControlItem(d);
                        _lifeLimitItems.Add(newControl);
                        flowLayoutPanelLifeLimit.Controls.Remove(panelWarranty);
                        flowLayoutPanelLifeLimit.Controls.Add(newControl);
                        flowLayoutPanelLifeLimit.Controls.Add(panelWarranty);
                    }
	            else
	            {
		            //LINQ запрос для сортировки записей по дате;
		            var sortrecords = (from record in list
			            orderby record.GetChar() ascending
			            select record).ToList();

		            //if (d.ChangeLLPCategoryRecords.Count == 0)
		            //{
			           // if (d.ParentBaseComponent != null)
			           // {
				          //  var lastBaseComponentLL = d.ParentBaseComponent.ChangeLLPCategoryRecords.GetLast();
				          //  if (lastBaseComponentLL != null)
				          //  {
					         //   d.ChangeLLPCategoryRecords.Add(new ComponentLLPCategoryChangeRecord
					         //   {
						        //    ParentId = d.ItemId,
						        //    ToCategory = lastBaseComponentLL.ToCategory ?? LLPLifeLimitCategory.Unknown,
						        //    RecordDate = lastBaseComponentLL.RecordDate,
						        //    OnLifelength = Lifelength.Zero
					         //   });
					         //   GlobalObjects.CasEnvironment.Keeper.Save(d.ChangeLLPCategoryRecords[0]);
				          //  }
			           // }
		            //}

		            if (d.ChangeLLPCategoryRecords.Count != 0)
		            {
			            flowLayoutPanelLifeLimit.Controls.Remove(panelWarranty);
			            //TODO:Вынести расчет LLp в Calculator (1785 строка)
			            foreach (var t in sortrecords)
			            {
				            var llpData = d.LLPData.GetItemByCatagory(t);
				            if (llpData == null)
				            {
					            llpData = new ComponentLLPCategoryData
					            {
						            LLPLifeLimit = d.LifeLimit,
						            ParentCategory = t,
						            ComponentId = d.ItemId
					            };
					            d.LLPData.Add(llpData);
					            GlobalObjects.NewKeeper.Save(llpData);
				            }

				            var lastRecord = d.ChangeLLPCategoryRecords.GetLast();
				            var selectedCategory = lastRecord?.ToCategory;

				            if (selectedCategory != null)
				            {
					            if (selectedCategory.ItemId == t.ItemId)
					            {
						            if (llpData.LLPCurrent != null)
						            {
							            if (!llpData.LLPCurrent.IsEqual(llpData.LLPTemp))
							            {
								            llpData.LLPTemp = new Lifelength(llpData.LLPCurrent);
								            GlobalObjects.NewKeeper.Save(llpData);
							            }
									}
					            }
				            }
			            }

			            //TODO: такой же цикл сверху, сделано для того что бы сначала расчитать LLPCurrent а тут уже посчитать Remain вынести все расчеты в Calculator!
			            foreach (var category in sortrecords)
			            {
				            var llpData = d.LLPData.GetItemByCatagory(category);
				            GlobalObjects.CasEnvironment.Calculator.CalculateLifeLimit(llpData, sortrecords, d.LLPData);
				            var newControl = new ComponentLifeLimitControlItem(llpData,
					            llpData.ParentCategory == d.ChangeLLPCategoryRecords.GetLast().ToCategory);
				            _lifeLimitItems.Add(newControl);
				            flowLayoutPanelLifeLimit.Controls.Add(newControl);
			            }

			            flowLayoutPanelLifeLimit.Controls.Add(panelWarranty);
		            }
	            }
            }
            else
            {
                //деталь не является вращающеися деталью двигателя, 
                //или не установлена на самолет
                ComponentLifeLimitControlItem newControl = new ComponentLifeLimitControlItem(d);
                _lifeLimitItems.Add(newControl);
                flowLayoutPanelLifeLimit.Controls.Remove(panelWarranty);
                flowLayoutPanelLifeLimit.Controls.Add(newControl);
                flowLayoutPanelLifeLimit.Controls.Add(panelWarranty);

	            lifelengthTCSNOnInstall.Lifelength = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength((BaseEntityObject)_currentComponent);
			}

            fileControl.UpdateInfo(_currentComponent.FaaFormFile,
                                   "Adobe PDF Files|*.pdf",
                                   "This record does not contain a file proving the origin of the detail. Enclose PDF file to prove the origin.",
                                   "Attached file proves the origin of the detail.");
            if (Math.Abs(_currentComponent.CostNew) > 0.000001)
                Cost = _currentComponent.CostNew;
            if (Math.Abs(_currentComponent.CostOverhaul) > 0.000001)
                CostOverhaul = _currentComponent.CostOverhaul;
            if (Math.Abs(_currentComponent.CostServiceable) > 0.000001)
                CostServiceable = _currentComponent.CostServiceable;
            if (Math.Abs(_currentComponent.ManHours) > 0.000001)
                ManHours = _currentComponent.ManHours;
            KitRequered = _currentComponent.KitRequired;
            Remarks = _currentComponent.Remarks;
            HiddenRemarks = _currentComponent.HiddenRemarks;

			documentControl1.CurrentDocument = _currentComponent.DocumentCRS;
			documentControl1.Added += DocumentControl1_Added;
		}

		#endregion

		#region private void DocumentControl1_Added(object sender, EventArgs e)

		private void DocumentControl1_Added(object sender, EventArgs e)
	    {
		    var newDocument = CreateNewDocument();
		    var form = new DocumentForm(newDocument, false);
		    if (form.ShowDialog() == DialogResult.OK)
		    {
			    _currentComponent.DocumentCRS = newDocument;
			    documentControl1.CurrentDocument = newDocument;

		    }
	    }

		#endregion

		#region private Document CreateNewDocument()

		private Document CreateNewDocument()
	    {
		    var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Component CRS Form") as DocumentSubType;
		    var partNumber = _currentComponent.PartNumber;
		    var serialNumber = _currentComponent.SerialNumber;
		    var description = _currentComponent.Description;

		    return new Document
		    {
			    Parent = _currentComponent,
			    ParentId = _currentComponent.ItemId,
			    ParentTypeId = _currentComponent.SmartCoreObjectType.ItemId,
			    DocType = DocumentType.TechnicalRecords,
			    DocumentSubType = docSubType,
			    IsClosed = true,
			    ContractNumber = $"P/N:{partNumber} S/N:{serialNumber}",
			    Description = description,
				ParentAircraftId = CurrentComponent.ParentAircraftId
		    };
	    }

	    #endregion

		#region public void ApplyChanges(Detail detail)

		public void ApplyChanges(Component component)
	    {
		    component.CostNew = Cost;
		    component.CostOverhaul = CostOverhaul;
		    component.CostServiceable = CostServiceable;
		    component.Remarks = Remarks;
		    component.HiddenRemarks = HiddenRemarks;
		    component.ManHours = ManHours;
		    component.KitRequired = KitRequered;
		    component.LifeLimit = LifeLimit;
		    component.LifeLimitNotify = LifeLimitNotify;
		    component.Warranty = lifelengthViewerWarranty.Lifelength;
		    component.WarrantyNotify = lifelengthViewerWarrantyNotify.Lifelength;
		    if (fileControl.GetChangeStatus())
		    {
			    fileControl.ApplyChanges();
			    component.FaaFormFile = fileControl.AttachedFile;
		    }

			if (component is BaseComponent)
			{
				if (component.LLPMark && ((BaseComponent)component).LLPCategories)
					component.LLPData = CurrentLLPLifeLimit;
			}
			else
			{
				if (component.LLPMark && component.LLPCategories)
					component.LLPData = CurrentLLPLifeLimit;
			}
		}

	    #endregion

        #region public void SaveData(Detail detail)
        /// <summary>
        /// Сохранаяет данные заданного агрегата
        /// </summary>
        public void SaveData(Component component)
        {
            // Сохраняем данные
            try
            {
				if (component is BaseComponent)
                {
	                if (component.LLPMark && ((BaseComponent) component).LLPCategories)
	                {
						component.LLPData = CurrentLLPLifeLimit;
		                var performance = component.ChangeLLPCategoryRecords.GetLast();
		                var data = component.LLPData.GetItemByCatagory(performance.ToCategory);
		                if (data != null)
			                component.LifeLimit = data.LLPLifeLimit;
					}                        
                    GlobalObjects.ComponentCore.Save(component);
                }
                else
                {
	                if (component.LLPMark && component.LLPCategories)
	                {
						component.LLPData = CurrentLLPLifeLimit;
		                var performance = component.ChangeLLPCategoryRecords.GetLast();
		                var data = component.LLPData.GetItemByCatagory(performance.ToCategory);
		                if (data != null)
			                component.LifeLimit = data.LLPLifeLimit;
					}
                    GlobalObjects.ComponentCore.Save(component);
                }
            }
            catch (ArgumentException argumentException)
            {
                MessageBox.Show(
	                $"{argumentException.Message}",
                    new GlobalTermsProvider()["SystemName"].ToString(),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex);
            }
        }

        #endregion

        #region private void LinkLabelEditKitLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        private void LinkLabelEditKitLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_currentComponent != null)
            {
                Component d = _currentComponent;
               
                KitForm dlg = new KitForm((IKitRequired)d);
                if (dlg.ShowDialog() == DialogResult.OK)
                    textBoxKitRequired.Text = d.Kits.Count + " EA";
            }
        }
		#endregion

		#endregion
    }

    #region internal class DetailComplianceLifeLimitControlDesigner : ControlDesigner

    internal class DetailComplianceLifeLimitControlDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("ManufactureDate");
            properties.Remove("InstallationDate");
        }
    }
    #endregion
}
