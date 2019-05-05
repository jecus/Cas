using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    /// <summary>
    /// Описывает класс товара
    /// </summary>
    
    [Serializable]
    public class GoodsClass : StaticTreeDictionary
    {

        #region public new GoodsClass Parent
        /// <summary>
        /// Родительский узел словаря
        /// </summary>
        public new GoodsClass Parent
        {
            get { return _parent as GoodsClass; }
        }
        #endregion

        #region public new GoodsClass Prev
        /// <summary>
        /// Предыдущий элемент на уровне
        /// </summary>
        public new GoodsClass Prev
        {
            get { return _prev as GoodsClass; }
        }
        #endregion

        #region public new GoodsClass Next
        /// <summary>
        /// Следующий элемент на уровне
        /// </summary>
        public new GoodsClass Next
        {
            get { return _next as GoodsClass; }
        }
        #endregion

        #region private static CommonDictionaryCollection<GoodsClass> _Items = new CommonDictionaryCollection<GoodsClass>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<GoodsClass> _Items = new CommonDictionaryCollection<GoodsClass>();
        
        #endregion

        #region private static CommonDictionaryCollection<GoodsClass> _roots = new CommonDictionaryCollection<GoodsClass>();
        /// <summary>
        /// Содержит корневые элементы
        /// </summary>
        private static CommonDictionaryCollection<GoodsClass> _roots = new CommonDictionaryCollection<GoodsClass>();

        #endregion

        /*
         * Предопределенные типы
         */
        #region  public static GoodsClass InvestmentGoods = new GoodsClass(1, "Invest. Goods", "Investment Goods", "INV");
        /// <summary>
        /// товары производственного назначения
        /// </summary>
        public static GoodsClass InvestmentGoods = new GoodsClass(1, "Invest. Goods", "Investment Goods", "INV");
        #endregion

        #region Элементы пункта "InvestmentGoods"

        #region public static GoodsClass BasicMaterialsAndComponents = new GoodsClass(2, "Basic Materials", "Basic Materials and Components", "Basic Mater. And Compnts", InvestmentGoods);
        /// <summary>
        /// Основные материалы и комплектующие
        /// </summary>
        public static GoodsClass BasicMaterialsAndComponents = new GoodsClass(2, "Basic Materials", "Basic Materials and Components", "Basic Mater. And Compnts", InvestmentGoods);
        #endregion

        #region Элементы пункта "BasicMaterialsAndComponents"

        #region public static GoodsClass Accessories = new GoodsClass(3, "Accessories", "Accessories", "Accessories", BasicMaterialsAndComponents);
        /// <summary>
        /// комплектующие
        /// </summary>
        public static GoodsClass Accessories = new GoodsClass(3, "Accessories", "Accessories", "Accessories", BasicMaterialsAndComponents);
        #endregion

        #region public static GoodsClass ComponentsAndParts = new GoodsClass(4, "Components and Parts", "Components and Parts", "Components and Parts", Accessories);
        /// <summary>
        /// Узлы и агрегаты
        /// </summary>
        public static GoodsClass ComponentsAndParts = new GoodsClass(4, "Components and Parts", "Components and Parts", "Components and Parts", Accessories);
		#endregion

		#region public static GoodsClass AircraftComponentsAndParts = new GoodsClass(5, "Aircraft", "Aircraft Components and Parts", "Aircraft Components and Parts", ComponentsAndParts);
		/// <summary>
		/// Узлы и агрегаты ВС
		/// </summary>
		public static GoodsClass AircraftComponentsAndParts = new GoodsClass(5, "Aircraft", "Aircraft Components and Parts", "Aircraft Components and Parts", ComponentsAndParts);
        #endregion

        #region public static GoodsClass AircraftBaseComponents = new GoodsClass(6, "Aircraft Base Components", "Aircraft Base Components", "Aircraft Base Components", AircraftComponentsAndParts);
        /// <summary>
        /// Основные агрегаты ВС
        /// </summary>
        public static GoodsClass AircraftBaseComponents = new GoodsClass(6, "Aircraft Base Components", "Aircraft Base Components", "Aircraft Base Components", AircraftComponentsAndParts);
        #endregion

        #region public static GoodsClass AircraftComponents = new GoodsClass(7, "Aircraft Components", "Aircraft Components", "Aircraft Components", AircraftComponentsAndParts);
        /// <summary>
        /// Простые агрегаты ВС
        /// </summary>
        public static GoodsClass AircraftComponents = new GoodsClass(7, "Aircraft Components", "Aircraft Components", "Aircraft Components", AircraftComponentsAndParts);
        #endregion

        #region public static GoodsClass AircraftComponentsAvionic = new GoodsClass(8, "Aircraft Components Avionic", "Aircraft Components Avionic", "Aircraft Components Avionic", AircraftComponents);
        /// <summary>
        /// Простые агрегаты ВС Авионика
        /// </summary>
        public static GoodsClass AircraftComponentsAvionic = new GoodsClass(8, "Avionic", "Aircraft Components-Avionic", "Aircraft Components Avionic", AircraftComponents);
        #endregion

        #region public static GoodsClass AircraftComponentsAvionicEmergency = new GoodsClass(9, "Emergency", "Aircraft Components Avionic Emergency", "Aircraft Components Avionic Emergency", AircraftComponentsAvionic)
        /// <summary>
        /// Простые агрегаты ВС Авионика Спасательная
        /// </summary>
        public static GoodsClass AircraftComponentsAvionicEmergency = new GoodsClass(9, "Avionic Emergency", "Aircraft Components Avionic Emergency", "Aircraft Components Avionic Emergency", AircraftComponentsAvionic);
		#endregion

		#region public static GoodsClass AircraftComponentsEmergency = new GoodsClass(81, "Aircraft Emergency", "Aircraft Components-Emergency", "Aircraft Components Emergency", AircraftComponents);
		/// <summary>
		/// Простые агрегаты ВС спасательные
		/// </summary>
		public static GoodsClass AircraftComponentsEmergency = new GoodsClass(81, "Aircraft Emergency", "Aircraft Components-Emergency", "Aircraft Components Emergency", AircraftComponents);
        #endregion

        #region public static GoodsClass VehicleComponentsAndParts = new GoodsClass(10, "Vehicle", "Vehicle Components and Parts", "Vehicle Components and Parts", ComponentsAndParts);
        /// <summary>
        /// Узлы и агрегаты ТС
        /// </summary>
        public static GoodsClass VehicleComponentsAndParts = new GoodsClass(10, "Vehicle", "Vehicle Components and Parts", "Vehicle Components and Parts", ComponentsAndParts);
        #endregion

        #region public static GoodsClass VehicleBaseComponents = new GoodsClass(11, "Vehicle Base Components", "Vehicle Base Components", "Vehicle Base Components", VehicleComponentsAndParts);
        /// <summary>
        /// Основные агрегаты ТС
        /// </summary>
        public static GoodsClass VehicleBaseComponents = new GoodsClass(11, "Vehicle Base Components", "Vehicle Base Components", "Vehicle Base Components", VehicleComponentsAndParts);
        #endregion

        #region public static GoodsClass VehicleComponents = new GoodsClass(12, "Vehicle Components", "Vehicle Components", "Vehicle Components", VehicleComponentsAndParts);
        /// <summary>
        /// Простые агрегаты ТС
        /// </summary>
        public static GoodsClass VehicleComponents = new GoodsClass(12, "Vehicle Components", "Vehicle Components", "Vehicle Components", VehicleComponentsAndParts);
		#endregion


		public static GoodsClass AircraftBaseComponentsEngine = new GoodsClass(91, "Engine Component", "Aircraft Engine Component", "Aircraft Engine Component", AircraftBaseComponents);
		public static GoodsClass AircraftBaseComponentsApu = new GoodsClass(92, "APU Component", "Aircraft APU Component", "Aircraft APU Component", AircraftBaseComponents);
		public static GoodsClass AircraftBaseComponentsLandingGear = new GoodsClass(93, "Landing Gear Component", "Aircraft Landing Gear Component", "Aircraft Landing Gear Component", AircraftBaseComponents);
		public static GoodsClass AircraftBaseComponentsPropeller = new GoodsClass(94, "Propeller Component", "Aircraft Propeller Component", "Aircraft Propeller Component", AircraftBaseComponents);

		#endregion


		#region public static GoodsClass CapitalGoods = new GoodsClass(13, "Capital Goods", "Capital Goods", "Capital Goods", InvestmentGoods);
		/// <summary>
		/// Капитальное имущество
		/// </summary>
		public static GoodsClass CapitalGoods = new GoodsClass(13, "Capital Goods", "Capital Goods", "Capital Goods", InvestmentGoods);
        #endregion

        #region Элементы пункта CapitalGoods

        #region public static GoodsClass AuxiliaryEquipment = new GoodsClass(14, "Auxiliary Equipment", "Auxiliary Equipment", "Auxiliary Equipment", CapitalGoods);
        /// <summary>
        /// Вспомогательное оборудование
        /// </summary>
        public static GoodsClass AuxiliaryEquipment = new GoodsClass(14, "Auxiliary Equipment", "Auxiliary Equipment", "Auxiliary Equipment", CapitalGoods);

		#endregion

		#region public static GoodsClass ProductionAuxiliaryEquipment = new GoodsClass(15, "Equipment", "Production Auxiliary Equipment", "Production Auxiliary Equipment", AuxiliaryEquipment)
		/// <summary>
		/// Производственное вспомогательное оборудование
		/// </summary>
		public static GoodsClass ProductionAuxiliaryEquipment = new GoodsClass(15, "Equipment", "Production Auxiliary Equipment", "Production Auxiliary Equipment", AuxiliaryEquipment);

        #endregion

        #region Элементы пункта Production Auxiliary Equipment

        #region public static GoodsClass ControlTestEquipment = new GoodsClass(16, "Control Test Equipment", "Production Auxiliary Control Test Equipment", "Production Auxiliary Control Test Equipment", ProductionAuxiliaryEquipment);
        /// <summary>
        /// Контрольно-проверочная аппаратура
        /// </summary>
        public static GoodsClass ControlTestEquipment = new GoodsClass(16, "Control Test Equipment", "Production Auxiliary Control Test Equipment", "Production Auxiliary Control Test Equipment", ProductionAuxiliaryEquipment);

        #endregion

        #region public static GoodsClass GroundEquipment = new GoodsClass(17, "Ground Equipment", "Production Auxiliary Ground Equipment", "Production Auxiliary Ground Equipment", ProductionAuxiliaryEquipment);
        /// <summary>
        /// Наземное оборудование
        /// </summary>
        public static GoodsClass GroundEquipment = new GoodsClass(17, "Ground Equipment", "Production Auxiliary Ground Equipment", "Production Auxiliary Ground Equipment", ProductionAuxiliaryEquipment);

		#endregion

		#region public static GoodsClass MeasuringDevices = new GoodsClass(63, "Measuring devices", "Production Auxiliary Measuring devices", "Production Auxiliary Measuring devices", ProductionAuxiliaryEquipment);

		public static GoodsClass MeasuringDevices = new GoodsClass(63, "Measuring Devices", "Production Auxiliary Measuring Devices", "Production Auxiliary Measuring Devices", ProductionAuxiliaryEquipment);


	    #endregion

		#region public static GoodsClass SpecialEquipment = new GoodsClass(54, "SpecialEquipment", "Production Auxiliary Equipment SpecialEquipment", "Production Auxiliary Equipment SpecialEquipment", ProductionAuxiliaryEquipment);
		/// <summary>
		/// Инструменты
		/// </summary>
		public static GoodsClass SpecialEquipment = new GoodsClass(54, "Special Equipment", "Production Auxiliary Equipment SpecialEquipment", "Production Auxiliary Equipment SpecialEquipment", ProductionAuxiliaryEquipment);

		#endregion

		#region public static GoodsClass Soft = new GoodsClass(52, "Soft", "Soft", "Soft", Accessories);

		public static GoodsClass Soft = new GoodsClass(52, "Soft", "Soft", "Soft", ProductionAuxiliaryEquipment);

		#endregion

		#endregion

		#region public static GoodsClass OfficeEquipment = new GoodsClass(19, "Office Equipment", "Office Equipment", "Office Equipment", AuxiliaryEquipment);
		/// <summary>
		/// Офисное оборудование
		/// </summary>
		public static GoodsClass OfficeEquipment = new GoodsClass(19, "Office Equipment", "Office Equipment", "Office Equipment", AuxiliaryEquipment);

		#endregion

		#region Элементы OfficeEquipment

		public static GoodsClass ComputerEquipment = new GoodsClass(60, "Computer equipment", "Computer Equipment", "Computer Equipment", OfficeEquipment);
		public static GoodsClass HouseholdEquipment = new GoodsClass(61, "Household equipment", "Household Equipment", "Household Equipment", OfficeEquipment);
		public static GoodsClass FurnitureEquipment = new GoodsClass(62, "Furniture", "Furniture Equipment", "Furniture Equipment", OfficeEquipment);

		#endregion

		#endregion

		#region public static GoodsClass AuxiliaryMaterials = new GoodsClass(20, "Auxiliary Materials", "Auxiliary Materials", "Auxiliary Materials", InvestmentGoods);
		/// <summary>
		/// Вспомогательные материалы
		/// </summary>
		public static GoodsClass AuxiliaryMaterials = new GoodsClass(20, "Auxiliary Materials", "Auxiliary Materials", "Auxiliary Materials", InvestmentGoods);
		#endregion

		#region public static GoodsClass Materials = new GoodsClass(21, "Materials", "Auxiliary Materials Maintenance", "Auxiliary Materials Maintenance", AuxiliaryMaterials);
		/// <summary>
		/// Материалы для ТО и Р
		/// </summary>
		public static GoodsClass MaintenanceMaterials = new GoodsClass(21, "Materials", "Auxiliary Materials Maintenance", "Auxiliary Materials Maintenance", AuxiliaryMaterials);
		#endregion

		#region Элементы пункта Maintenance

		#region public static GoodsClass KIT = new GoodsClass(22, "KIT", "Auxiliary Materials Maintenance KITs", "Auxiliary Materials Maintenance KITs", MaintenanceMaterials);
		/// <summary>
		/// КИТ
		/// </summary>
		public static GoodsClass KIT = new GoodsClass(22, "KIT", "Auxiliary Materials Maintenance KITs", "Auxiliary Materials Maintenance KITs", MaintenanceMaterials);
		#endregion

		#region public static GoodsClass FLM = new GoodsClass(23, "FLM", "Auxiliary Materials Maintenance FLM", "Auxiliary Materials Maintenance FLM", MaintenanceMaterials);
		/// <summary>
		/// ГСМ
		/// </summary>
		public static GoodsClass FLM = new GoodsClass(23, "FLM", "Auxiliary Materials Maintenance FLM", "Auxiliary Materials Maintenance FLM", MaintenanceMaterials);
		#endregion

		#region Элементы пункта FLM

		#region public static GoodsClass Fuel = new GoodsClass(24, "Fuel", "Auxiliary Materials Maintenance FLM Fuel", "Auxiliary Materials Maintenance FLM Fuel", FLM);
		/// <summary>
		/// Горючее
		/// </summary>
		public static GoodsClass Fuel = new GoodsClass(24, "Fuels", "Auxiliary Materials Maintenance FLM Fuel", "Auxiliary Materials Maintenance FLM Fuel", FLM);
		#endregion

		#region Элементы пункта Fuel

		#region public static GoodsClass AircraftFuel = new GoodsClass(25, "Aircraft Fuel", "Auxiliary Materials Maintenance FLM Fuel Aircraft", "Auxiliary Materials Maintenance FLM Fuel Aircraft", Fuel);
		/// <summary>
		/// Горючее для ВС
		/// </summary>
		public static GoodsClass AircraftFuel = new GoodsClass(25, "Aircraft Fuel", "Auxiliary Materials Maintenance FLM Fuel Aircraft", "Auxiliary Materials Maintenance FLM Fuel Aircraft", Fuel);
        #endregion

        #region public static GoodsClass VehicleFuel = new GoodsClass(26, "Vehicle Fuel", "Auxiliary Materials Maintenance FLM Fuel Vehicle", "Auxiliary Materials Maintenance FLM Fuel Vehicle", Fuel);
        /// <summary>
        /// Горючее для ТС
        /// </summary>
        public static GoodsClass VehicleFuel = new GoodsClass(26, "Vehicle Fuel", "Auxiliary Materials Maintenance FLM Fuel Vehicle", "Auxiliary Materials Maintenance FLM Fuel Vehicle", Fuel);
        #endregion

        #endregion

        #region public static GoodsClass Oil = new GoodsClass(27, "Oil", "Auxiliary Materials Maintenance FLM Oil", "Auxiliary Materials Maintenance FLM Oil", FLM);
        /// <summary>
        /// Масла
        /// </summary>
        public static GoodsClass Oil = new GoodsClass(27, "Oils", "Auxiliary Materials Maintenance FLM Oil", "Auxiliary Materials Maintenance FLM Oil", FLM);
        #endregion

        #region Элементы пункта Oil

        #region public static GoodsClass AircraftOil = new GoodsClass(28, "Aricraft Oil", "Auxiliary Materials Maintenance FLM Oil Aircraft", "Auxiliary Materials Maintenance FLM Oil Aircraft", Oil);
        /// <summary>
        /// Масла для ВС
        /// </summary>
        public static GoodsClass AircraftOil = new GoodsClass(28, "Aricraft Oil", "Auxiliary Materials Maintenance FLM Oil Aricraft", "Auxiliary Materials Maintenance FLM Oil Aircraft", Oil);
        #endregion

        #region public static GoodsClass VehicleOil = new GoodsClass(29, "Vehicle Oil", "Auxiliary Materials Maintenance FLM Oil Vehicle", "Auxiliary Materials Maintenance FLM Oil Vehicle", Oil);
        /// <summary>
        /// Масла для ТС
        /// </summary>
        public static GoodsClass VehicleOil = new GoodsClass(29, "Vehicle Oil", "Auxiliary Materials Maintenance FLM Oil Vehicle", "Auxiliary Materials Maintenance FLM Oil Vehicle", Oil);
		#endregion

		#endregion

		#region public static GoodsClass Grease = new GoodsClass(30, "Grease", "Auxiliary Materials Maintenance FLM Grease", "Auxiliary Materials Maintenance FLM Grease", FLM);
		/// <summary>
		/// Смазка
		/// </summary>
		public static GoodsClass Grease = new GoodsClass(30, "Greases", "Auxiliary Materials Maintenance FLM Grease", "Auxiliary Materials Maintenance FLM Grease", FLM);
		#endregion

		#region Элементы пункта Grease

		#region public static GoodsClass AircraftGrease = new GoodsClass(31, "Aircraft Grease", "Auxiliary Materials Maintenance FLM Grease Aircraft", "Auxiliary Materials Maintenance FLM Grease Aircraft", Grease);
		/// <summary>
		/// Смазка для ВС
		/// </summary>
		public static GoodsClass AircraftGrease = new GoodsClass(31, "Aircraft Grease", "Auxiliary Materials Maintenance FLM Grease Aircraft", "Auxiliary Materials Maintenance FLM Grease Aircraft", Grease);
		#endregion

		#region public static GoodsClass VehicleGrease = new GoodsClass(32, "Vehicle Grease", "Auxiliary Materials Maintenance FLM Grease Vehicle", "Auxiliary Materials Maintenance FLM Grease Vehicle", Grease);
		/// <summary>
		/// Смазка для ТС
		/// </summary>
		public static GoodsClass VehicleGrease = new GoodsClass(32, "Vehicle Grease", "Auxiliary Materials Maintenance FLM Grease Vehicle", "Auxiliary Materials Maintenance FLM Grease Vehicle", Grease);
		#endregion

		#region public static GoodsClass CommonGreases = new GoodsClass(78, "Common Greases", "Common Greases", "Common Greases", Grease);

		public static GoodsClass CommonGreases = new GoodsClass(78, "Common Greases", "Common Greases", "Common Greases", Grease);


		#endregion

		#endregion

		#region public static GoodsClass Hydraulic = new GoodsClass(35, "Hydraulic Fluids", "Auxiliary Materials Maintenance FLM Hydraulic", "Auxiliary Materials Maintenance FLM Hydraulic", FLM);

		public static GoodsClass Hydraulic = new GoodsClass(35, "Hydraulic Fluids", "Auxiliary Materials Maintenance FLM Hydraulic", "Auxiliary Materials Maintenance FLM Hydraulic", FLM);


		#endregion

		#region public static GoodsClass Lubricants = new GoodsClass(76, "Lubricants", "Lubricants", "Lubricants", FLM);

		public static GoodsClass Lubricants = new GoodsClass(76, "Lubricants", "Lubricants", "Lubricants", FLM);
		#endregion

		#region public static GoodsClass LubricantsOGD = new GoodsClass(90, "Lubricants (Oils, Greases, Dry Lubes", "Lubricants (Oils, Greases, Dry Lubes", "Lubricants (Oils, Greases, Dry Lubes", FLM);

		public static GoodsClass LubricantsOGD = new GoodsClass(90, "Lubricants (Oils, Greases, Dry Lubes)", "Lubricants (Oils, Greases, Dry Lubes)", "Lubricants (Oils, Greases, Dry Lubes", FLM);
		#endregion

		#region public static GoodsClass DryLubes = new GoodsClass(77, "Dry Lubes", "Dry Lubes", "Dry Lubes", FLM);

		public static GoodsClass DryLubes = new GoodsClass(77, "Dry Lubes", "Dry Lubes", "Dry Lubes", FLM);
		#endregion

		#endregion

		#region public static GoodsClass ConsumableParts = new GoodsClass(33, "Consumable Parts", "Auxiliary Materials Maintenance Consumable Parts", "Auxiliary Materials Maintenance Consumable Parts", MaintenanceMaterials);
		/// <summary>
		/// Расходные материалы
		/// </summary>
		public static GoodsClass ConsumableParts = new GoodsClass(33, "Consumable Parts", "Auxiliary Materials Maintenance Consumable Parts", "Auxiliary Materials Maintenance Consumable Parts", MaintenanceMaterials);
		#endregion

		#region Элементы пункта ConsumableParts
		public static GoodsClass Abraive = new GoodsClass(36, "Abrasive", "Auxiliary Materials Maintenance Abrasive", "Auxiliary Materials Maintenance Abrasive", ConsumableParts);
		public static GoodsClass Composite = new GoodsClass(37, "Composite", "Auxiliary Materials Maintenance Composite", "Auxiliary Materials Maintenance Composite", ConsumableParts);
		public static GoodsClass Compound = new GoodsClass(38, "Compound", "Auxiliary Materials Maintenance Compound", "Auxiliary Materials Maintenance Compound", ConsumableParts);
		public static GoodsClass Glue = new GoodsClass(39, "Glue", "Auxiliary Materials Maintenance Glue", "Auxiliary Materials Maintenance Glue", ConsumableParts);
		public static GoodsClass Lacquer = new GoodsClass(40, "Lacquers", "Auxiliary Materials Maintenance Lacquer", "Auxiliary Materials Maintenance Lacquer", ConsumableParts);
		public static GoodsClass Paint = new GoodsClass(41, "Paints", "Auxiliary Materials Maintenance Paint", "Auxiliary Materials Maintenance Paint", ConsumableParts);
		public static GoodsClass Polish = new GoodsClass(42, "Polish", "Auxiliary Materials Maintenance Polish", "Auxiliary Materials Maintenance Polish", ConsumableParts);
		public static GoodsClass Primer = new GoodsClass(43, "Primer", "Auxiliary Materials Maintenance Primer", "Auxiliary Materials Maintenance Primer", ConsumableParts);
		public static GoodsClass Adhesives = new GoodsClass(79, "Adhesives", "Adhesives", "Adhesives", ConsumableParts);
		public static GoodsClass AdhesivesCompounds = new GoodsClass(80, "Adhesives Compounds", "Adhesives Compounds", "Adhesives Compounds", ConsumableParts);
		
		public static GoodsClass Cements = new GoodsClass(81, "Cements", "Cements", "Cements", ConsumableParts);
		public static GoodsClass Disinfectants = new GoodsClass(82, "Disinfectants", "Disinfectants", "Disinfectants", ConsumableParts);
		public static GoodsClass PretreatmentForPainting = new GoodsClass(83, "Pretreatment for Painting and Sealing", "Pretreatment for Painting and Sealing", "Pretreatment for Painting and Sealing", ConsumableParts);
		public static GoodsClass Preservation = new GoodsClass(84, "Preservation", "Preservation", "Preservation", ConsumableParts);
		public static GoodsClass Sealants = new GoodsClass(85, "Sealants", "Sealants", "Sealants", ConsumableParts);
		public static GoodsClass Strippers = new GoodsClass(86, "Strippers", "Strippers", "Strippers", ConsumableParts);
		public static GoodsClass BondingAngAdhesive = new GoodsClass(95, "Bonding ang Adhesive Compounds", "Bonding ang Adhesive Compounds", "Bonding ang Adhesive Compounds", ConsumableParts);
		public static GoodsClass AdhesivesCements = new GoodsClass(96, "Adhesives, Cements, Sealants", "Adhesives, Cements, Sealants", "Adhesives, Cements, Sealants", ConsumableParts);

		#endregion

		#region public static GoodsClass Fluid = new GoodsClass(44, "Fluid", "Auxiliary Materials Maintenance Fluid", "Auxiliary Materials Maintenance Fluid", MaintenanceMaterials);

		public static GoodsClass Fluid = new GoodsClass(44, "Fluid", "Auxiliary Materials Maintenance Fluid", "Auxiliary Materials Maintenance Fluid", MaintenanceMaterials);

		#endregion

		#region Элементы пунтка Fluid
		public static GoodsClass Alcohol = new GoodsClass(45, "Alcohol", "Auxiliary Materials Maintenance Alcohol", "Auxiliary Materials Maintenance Alcohol", Fluid);
		public static GoodsClass AntiCorrosion = new GoodsClass(46, "Anti-corrosion", "Auxiliary Materials Maintenance Anti-corrosion", "Auxiliary Materials Maintenance Anti-corrosion", Fluid);
		public static GoodsClass Coolant = new GoodsClass(47, "Coolant", "Auxiliary Materials Maintenance Coolant", "Auxiliary Materials Maintenance Coolant", Fluid);
		public static GoodsClass Cleaner = new GoodsClass(48, "Cleaners", "Auxiliary Materials Maintenance Cleaner", "Auxiliary Materials Maintenance Cleaner", Fluid);	
		public static GoodsClass DeIcing = new GoodsClass(49, "De-icing", "Auxiliary Materials Maintenance De-icing", "Auxiliary Materials Maintenance De-icing", Fluid);
		public static GoodsClass Solvent = new GoodsClass(50, "Solvent", "Auxiliary Materials Maintenance Solvent", "Auxiliary Materials Maintenance Solvent", Fluid);
		public static GoodsClass CleaningAgents = new GoodsClass(87, "Cleaning Agents", "Cleaning Agents", "Cleaning Agents", Fluid);
		public static GoodsClass CleanersPolishes = new GoodsClass(88, "Cleaners, Polishes", "Cleaners, Polishes", "Cleaners, Polishes", Fluid);

		#endregion

		#region public static GoodsClass AccessoriesMaterial = new GoodsClass(55, "Accessories", "Auxiliary Materials Accessories", "Auxiliary Materials Accessories", MaintenanceMaterials);

		public static GoodsClass AccessoriesMaterial = new GoodsClass(55, "Expendables", "Auxiliary Materials Expendables", "Auxiliary Materials Expendables", MaintenanceMaterials);


		#endregion

		#region Элементы AccessoriesMaterial

		public static GoodsClass AircraftAccessories = new GoodsClass(56, "Aircraft Expendables", "Auxiliary Materials Aircraft Expendables", "Auxiliary Materials Aircraft Expendables", AccessoriesMaterial);
		public static GoodsClass EngineAccessories = new GoodsClass(57, "Engine Expendables", "Auxiliary Materials Engine Expendables", "Auxiliary Materials Engine Expendables", AccessoriesMaterial);
		public static GoodsClass LandingGearAccessories = new GoodsClass(58, "Landing gear Expendables", "Auxiliary Materials Landing Gear Expendables", "Auxiliary Materials Landing Gear Expendables", AccessoriesMaterial);
		public static GoodsClass PropellerAccessories = new GoodsClass(59, "Propeller Expendables", "Auxiliary Materials Propeller Expendables", "Auxiliary Materials Propeller Expendables", AccessoriesMaterial);

		#endregion

		#region Элементы пункта MaintenanceMaterials

		#region public static GoodsClass AntiIcingAndDeIcing = new GoodsClass(70, "Anti-Icing and De-Icing Materials", "Anti-Icing and De-Icing Materials", "Anti-Icing and De-Icing Materials", MaintenanceMaterials);

		public static GoodsClass AntiIcingAndDeIcing = new GoodsClass(70, "Anti-Icing and De-Icing Materials", "Anti-Icing and De-Icing Materials", "Anti-Icing and De-Icing Materials", MaintenanceMaterials);

		#endregion

		#region public static GoodsClass BacterialogicalProtection = new GoodsClass(71, "Bacterialogical Contamination Protection", "Bacterialogical Contamination Protection", "Bacterialogical Contamination Protection", MaintenanceMaterials);

		public static GoodsClass BacterialogicalProtection = new GoodsClass(71, "Bacterialogical Contamination Protection", "Bacterialogical Contamination Protection", "Bacterialogical Contamination Protection", MaintenanceMaterials);

		#endregion

		#region public static GoodsClass Materials = new GoodsClass(72, "Materials", "Materials", "Materials", MaintenanceMaterials);

		public static GoodsClass Materials = new GoodsClass(72, "Materials", "Materials", "Materials", MaintenanceMaterials);

		#endregion

		#region public static GoodsClass FinishingMaterials = new GoodsClass(73, "Finishing Materials", "Finishing Materials", "Finishing Materials", MaintenanceMaterials);

		public static GoodsClass FinishingMaterials = new GoodsClass(73, "Finishing Materials", "Finishing Materials", "Finishing Materials", MaintenanceMaterials);

		#endregion

		#region public static GoodsClass MiscellaneousMaterials = new GoodsClass(74, "Miscellaneous Materials", "Miscellaneous Materials", "Miscellaneous Materials", MaintenanceMaterials);

		public static GoodsClass MiscellaneousMaterials = new GoodsClass(74, "Miscellaneous Materials", "Miscellaneous Materials", "Miscellaneous Materials", MaintenanceMaterials);

		#endregion

		#region public static GoodsClass SpecialMaterials = new GoodsClass(75, "Special Materials", "Special Materials", "Special Materials", MaintenanceMaterials);

		public static GoodsClass SpecialMaterials = new GoodsClass(75, "Special Materials", "Special Materials", "Special Materials", MaintenanceMaterials);

		#endregion

		#endregion

		#endregion

		#region public static GoodsClass Tools = new GoodsClass(18, "Tools", "Production Auxiliary Equipment SpecialTools", "Production Auxiliary Equipment SpecialTools", AuxiliaryMaterials);
		/// <summary>
		/// Инструменты
		/// </summary>
		public static GoodsClass Tools = new GoodsClass(18, "Tools", "Production Auxiliary Equipment SpecialTools", "Production Auxiliary Equipment SpecialTools", AuxiliaryMaterials);

		#endregion

		#region Элементы пункта Tools

		public static GoodsClass StandartTools = new GoodsClass(64, "Standart tools", "Production Auxiliary Equipment Standart Tools", "Production Auxiliary Equipment StandartTools", Tools);
		public static GoodsClass AircraftTools = new GoodsClass(65, "Aircraft tools", "Production Auxiliary Equipment Aircraft Tools", "Production Auxiliary Equipment AircraftTools", Tools);
		public static GoodsClass EngineTools = new GoodsClass(66, "Engine tools", "Production Auxiliary Equipment Engine Tools", "Production Auxiliary Equipment EngineTools", Tools);
		public static GoodsClass SpecialTools = new GoodsClass(67, "Special tools", "Production Auxiliary Equipment Special Tools", "Production Auxiliary Equipment SpecialTools", Tools);
		public static GoodsClass CommercialTools = new GoodsClass(89, "Commercial Tools", "Production Auxiliary Equipment Commercial Tools", "Production Auxiliary Equipment CommercialTools", Tools);

		#endregion

		#region public static GoodsClass WorkMaterials = new GoodsClass(34, "Work Materials", "Auxiliary Materials Work", "Auxiliary Materials Work", AuxiliaryMaterials);
		/// <summary>
		/// Рабочие Материалы
		/// </summary>
		public static GoodsClass WorkMaterials = new GoodsClass(34, "Work Materials", "Auxiliary Materials Work", "Auxiliary Materials Work", AuxiliaryMaterials);
		#endregion

		#region public static GoodsClass AircraftComponentsSoft = new GoodsClass(51, "Soft ", "Aircraft Components-Soft ", "Aircraft Components Soft ", AircraftComponents);

		public static GoodsClass AircraftComponentsSoft = new GoodsClass(51, "Soft ", "Aircraft Components-Soft ", "Aircraft Components Soft ", AircraftComponents);


		#endregion

		#region public static GoodsClass Protection = new GoodsClass(68, "Protection items", "Production Auxiliary Protection items", "Production Auxiliary Protection items", AuxiliaryMaterials);
		/// <summary>
		/// Инструменты
		/// </summary>
		public static GoodsClass Protection = new GoodsClass(68, "Protection items", "Production Auxiliary Protection items", "Production Auxiliary Protection items", AuxiliaryMaterials);

	    #endregion


		#endregion

		#region public static GoodsClass Unknown = new GoodsClass(-1, "Unknown", "Unknown", "Unknown");
		/// <summary> 
		/// Неизвестный объект
		/// </summary>
		public static GoodsClass Unknown = new GoodsClass(-1, "Unknown", "Unknown", "Unknown");
        #endregion



        /*
         * Методы
         */

        #region public static GoodsClass GetItemById(Int32 GoodsClassId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="goodsClassId"></param>
        /// <returns></returns>
        public static GoodsClass GetItemById(Int32 goodsClassId)
        {
            foreach (GoodsClass t in _Items)
                if (t.ItemId == goodsClassId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<GoodsClass> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<GoodsClass> Items
        {
            get { return _Items; }
        }
        #endregion

        #region static public CommonDictionaryCollection<GoodsClass> Roots
        /// <summary>
        /// Возвращает список корневых элементов
        /// </summary>
        public static CommonDictionaryCollection<GoodsClass> Roots
        {
            get { return _roots; }
        }
        #endregion

        #region public IDictionaryCollection Children
        /// <summary>
        /// Дочерние элементы словаря
        /// </summary>
        public new CommonDictionaryCollection<GoodsClass> Children
        {
            get
            {
                if (_children == null)
                    _children = new CommonDictionaryCollection<GoodsClass>();
                return (CommonDictionaryCollection<GoodsClass>)_children;
            }
        }

        #endregion

        #region public override string ToString()
        /// <summary>
        /// Переводит тип директивы в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ShortName;
        }
        #endregion

        /*
         * Реализация
         */

        #region public GoodsClass()
        /// <summary>
        /// Консруктор по умолчанию
        /// </summary>
        public GoodsClass()
        {
            SmartCoreObjectType = SmartCoreType.Unknown;
        }
        #endregion

        #region private GoodsClass(Int32 ItemId, String shortName, String fullName, String commonName) : this(itemId, shortName, fullName, commonName, Unknown)

        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        private GoodsClass(Int32 itemId, String shortName, String fullName, String commonName)
            : this(itemId, shortName, fullName, commonName, null)
        {
            if(_roots.Count > 0)
            {
                _prev = _roots[_roots.Count - 1];
                _roots[_roots.Count - 1]._next = this;
            }
            _roots.Add(this);
        }
        #endregion

        #region private GoodsClass(Int32 itemId, String shortName, String fullName, String commonName, GoodsClass parent) : this()

        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        /// <param name="parent">Родительский узел</param>
        private GoodsClass(Int32 itemId, String shortName, String fullName, String commonName, GoodsClass parent) : this()
        {
            ItemId = itemId;
            ShortName = shortName;
            FullName = fullName;
            CommonName = commonName;
            _parent = parent;

            if (parent != null)
            {
                //Выставление пред. узла на данном уровне для тек. узла
                GoodsClass prevNode = parent.Children.Count > 0
                                            ? parent.Children[parent.Children.Count - 1]
                                            : null;
                _prev = prevNode;

                //Для пред. узла на данном уровне - выставление след. узла

                if (prevNode != null)
                    prevNode._next = this;

                //добавление нового дочернего узла в родительский узел
                parent.Children.Add(this);
            }
            _Items.Add(this);
        }
        #endregion
    
    }
}
