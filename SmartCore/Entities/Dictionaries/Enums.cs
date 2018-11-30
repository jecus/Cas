using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SmartCore.Entities.Dictionaries
{

    #region public enum ADType : short
    public enum ADType : short
    {
        Airframe = 0,
        Apliance = 1,
        None = 2,
		LandingGear = 3,
        Engine = 4,
		APU = 5

	}
	#endregion

	#region public enum FlightAircraftCode : short
	/// <summary>
	/// Код ВС на полет
	/// </summary>
	[Flags]
    public enum FlightAircraftCode : short
    {
        /// <summary>
        /// Неизвестно
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Пассажирское
        /// </summary>
        P = 1,
        /// <summary>
        /// Грузовое, не перевозящее пассажиров
        /// </summary>
        F = 2,
        /// <summary>
        /// Смешанное (перевозящее пассажиров и груз)
        /// </summary>
        M = 4,
    }
    #endregion

    #region public enum AntiIce : short
    /// <summary>
    /// Режим антифриза 
    /// </summary>
    public enum AntiIce : short
    {
        /// <summary>
        /// Включено
        /// </summary>
        On = 1,
        /// <summary>
        /// Отключено
        /// </summary>
        Off = 2,
        /// <summary>
        /// Активизируется
        /// </summary>
        BeingActivated = 3,
    }
    #endregion

    #region public enum AtlbRecordType : short
    /// <summary>
    /// Тип записи борт-журнала
    /// </summary>
    public enum AtlbRecordType : short
    {
        /// <summary>
        /// Полет
        /// </summary>
        Flight = 1,
        /// <summary>
        /// Тех. обслуживание
        /// </summary>
        Maintenance = 2,
    }
    #endregion

    #region public enum AvionicsInventoryMarkType: short
    /// <summary>
    /// Типы отметки AvionicsInventory
    /// </summary>
    public enum AvionicsInventoryMarkType : short
    {
        /// <summary>
        /// Тип отметки AvionicsInventory - обязательная
        /// </summary>
        Required = 1,
        /// <summary>
        /// Тип отметки AvionicsInventory - опциональная
        /// </summary>
        Optional = 2,
        /// <summary>
        /// Тип отметки AvionicsInventory - неизвестная
        /// </summary>
        Unknown = 3,
        /// <summary>
        /// Не включено вовсе
        /// </summary>
        None = 0
    }
    #endregion

    #region public enum Brakes: short
    /// <summary>
    /// 
    /// </summary>
    public enum Brakes : short
    {
        /// <summary>
        /// 
        /// </summary>
        Carbon = 1,
        /// <summary>
        /// 
        /// </summary>
        Steel = 2,
    }
    #endregion

    #region public enum DamageType : short

    /// <summary>
    /// Перечисления типов Damage директив
    /// </summary>
    public enum DamageType : short
    {
        Damage = 1,
        Dent = 20,
        Repair = 30,
        Scratch = 40,
    }

	#endregion

	public enum DamageClass : short
	{
		Major = 1,
		Minor = 2,
		Unknown = -1,
	}

	#region public enum ComponentStatus : short

	/// <summary>
	/// Перечисления статуса сомпонента (Новый, после Кап. ремонта, после Ремонта, после ТО )
	/// </summary>
	[Flags]
    public enum ComponentStatus : short
    {
        Unknown = 0,

        New = 1,
        
        Serviceable = 4,

        Overhaul = 16,

        Repair = 64
    }

    #endregion

    #region public enum DetectionPhase : short

    public enum DetectionPhase : short
    {
        #region PreFlight
        /// <summary>
        /// Неизвестно
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Фаза обслуживания
        /// </summary>
        Maintenance = 1,
        /// <summary>
        /// 
        /// </summary>
        Parked = 2,
        /// <summary>
        /// 
        /// </summary>
        Pushback = 3,
        /// <summary>
        /// Руление
        /// </summary>
        Taxi = 4,
        /// <summary>
        /// Старт
        /// </summary>
        Starting = 5,
        /// <summary>
        /// Включение силовых агрегатов
        /// </summary>
        RunUpPoint = 6,

        #endregion

        #region Flight
        /// <summary>
        /// Взлет
        /// </summary>
        Takeoff = 11,
        /// <summary>
        /// Набор высоты
        /// </summary>
        Climb = 12,
        /// <summary>
        /// Полет
        /// </summary>
        Cruise = 13,
        /// <summary>
        /// Снижение
        /// </summary>
        Descent = 14,
        /// <summary>
        /// Подход
        /// </summary>
        Approach = 15,
        /// <summary>
        /// Доп.Круг
        /// </summary>
        AdditionalRound = 16,
        #endregion

        #region Landing
        /// <summary>
        /// Посадка
        /// </summary>
        Landing = 21,
        /// <summary>
        /// Пробег
        /// </summary>
        Mileage = 22,
        /// <summary>
        /// Руление на посадке
        /// </summary>
        LTaxi = 23,
        /// <summary>
        /// Остановка
        /// </summary>
        Stop = 24,
        #endregion
    }
    #endregion

    #region public enum FlightCategory : short
    /// <summary>
    /// Категория Полета (Внутренний рейс, Международный рейс и т.д.)
    /// </summary>
    public enum FlightCategory : short
    {
        /// <summary>
        /// Неизветсный
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Внутренний рейс
        /// </summary>
        DomesticFlight = 1,
        /// <summary>
        /// Международный рейс
        /// </summary>
        InternationalFlight = 2,
        /// <summary>
        /// Ближнее зарубежье
        /// </summary>
        NearAbroad = 3,
    }
    #endregion

    #region public enum Gender : short
    /// <summary>
    /// Пол
    /// </summary>
    public enum Gender : short
    {
        /// <summary>
        /// Мужской
        /// </summary>
        Male = 1,
        /// <summary>
        /// Женский
        /// </summary>
        Female = 2,
        /// <summary>
        /// Не применимо
        /// </summary>
        NotApplicable = -1,

    }
    #endregion

    #region public enum GroundAir : short
    /// <summary>
    /// Описывает точку события или параметра "На Земле/В Воздухе"
    /// </summary>
    public enum GroundAir : short
    {
        /// <summary>
        /// На Земле
        /// </summary>
        Ground = 0,
        /// <summary>
        /// В воздухе
        /// </summary>
        Air = 1,
    }
    #endregion

    #region public enum LandingGearMarkType : short
    /// <summary>
    /// Положения стоек шасси 
    /// </summary>
    public enum LandingGearMarkType : short
    {
        /// <summary>
        /// Тип отметки LandingGear - Основное
        /// </summary>
        General = 1,
        /// <summary>
        /// Тип отметки LandingGear - Левое
        /// </summary>
        Left = 2,
        /// <summary>
        /// Тип отметки LandingGear - Правое
        /// </summary>
        Right = 3,
        /// <summary>
        /// Не включено вовсе
        /// </summary>
        None = 0
    }
    #endregion

    #region public enum MSG : short
    /// <summary>
    /// 
    /// </summary>
    public enum MSG : short
    {
        /// <summary>
        /// 
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// 
        /// </summary>
        MSG2 = 2,
        /// <summary>
        /// 
        /// </summary>
        MSG3 = 3,

    }
    #endregion

    #region public enum PowerLoss : short
    /// <summary>
    /// Тип потери мощности 
    /// </summary>
    public enum PowerLoss : short
    {
        /// <summary>
        /// Внезапный (меньше 5 секунд)
        /// </summary>
        Sudden = 1,
        /// <summary>
        /// Постепенный (более 5 секунд)
        /// </summary>
        Gradual = 2,
    }
    #endregion

    #region public enum RunUpCondition : short
    /// <summary>
    /// Статус запуска двигателя/ВСУ
    /// </summary>
    public enum RunUpCondition : short
    {
        /// <summary>
        /// Неизвестно
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Нормальный
        /// </summary>
        Satisfactory = 1,

        /// <summary>
        /// Неудачный
        /// </summary>
        Unsatisfactory = 2,

        /// <summary>
        /// Сбой/Авария
        /// </summary>
        Failure = 3,

    }
    #endregion

    #region public enum RunUpType : short

    public enum RunUpType : short
    {
        /// <summary>
        /// Неизветсное
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Запуск
        /// </summary>
        RunUp = 1,
        /// <summary>
        /// Холодная прокрутка
        /// </summary>
        ColdSrolling = 2,
        /// <summary>
        /// Хранение
        /// </summary>
        Preservation = 3,
    }
    #endregion

    #region public enum ShutDownType : short
    /// <summary>
    /// Тип отклюяения Двигателя/ВСУ
    /// </summary>
    public enum ShutDownType : short
    {
        /// <summary>
        /// Неивестно
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Автоматически
        /// </summary>
        Automatic = 1,

        /// <summary>
        /// Вручную
        /// </summary>
        Manual = 2,

    }
    #endregion

    #region public enum SupplierStatus : short
    /// <summary>
    /// Статус (состояние) поставщика
    /// </summary>
    public enum SupplierStatus : short
    {

        /// <summary>
        /// дилер
        /// </summary>
        Dealer = 0,

        /// <summary>
        /// Дистрибьютор
        /// </summary>
        Distributor = 1,

    }
    #endregion

    #region public enum ThrustLever : short
    /// <summary>
    /// Положение рычага
    /// </summary>
    public enum ThrustLever : short
    {
        /// <summary>
        /// Ускорение
        /// </summary>
        Accelerating = 1,
        /// <summary>
        /// Замедление
        /// </summary>
        Decelerating = 2,
        /// <summary>
        /// Не передвигался
        /// </summary>
        NoBeingMoved = 3,
    }
    #endregion

    #region public enum WeatherCondition : short
    [Flags]
    public enum WeatherCondition : short
    {
        Unknown = 0,

        Clear = 1,

        Turb = 2,

        Clouds = 4,

        RainSnow = 8
    }
	#endregion

	#region public enum WorkItemsRelationType

	public enum WorkItemsRelationType
	{
		None = 0,
		Incorrect = 1,
		CalculationDepend = 2,
		CalculationAffect = 3
	}

	#endregion

	#region public enum WorkPackageStatus : short
	/// <summary>
	/// Статус (состояние) рабочего пакета
	/// </summary>
	public enum WorkPackageStatus : short
    {
        /// <summary>
        /// Все состояния (открыт, закрыт, на исполнении)
        /// </summary>
        All = 0,
        /// <summary>
        /// Рабочий пакет открыт
        /// </summary>
        Opened = 1,

        /// <summary>
        /// Рабочий пакет отправлен на выполнение
        /// </summary>
        Published = 2,

        /// <summary>
        /// Рабочий пакет закрыт
        /// </summary>
        Closed = 3,

    }
    #endregion

    #region public enum WorkPackageRoutineTasksGrouping
    /// <summary>
    /// Группировка по Routing Task
    /// </summary>
    public enum WorkPackageRoutineTasksGrouping
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,

		/// <summary>
		/// Группировка по Zone
		/// </summary>
		Zone = 1,

		/// <summary>
		/// Группировка по Access
		/// </summary>
		Access = 2,

		/// <summary>
		/// Группировка по Program
		/// </summary>
		Program = 3,

		/// <summary>
		/// Группировка по WorkType
		/// </summary>
		[Description("Work type")]
		WorkType = 4,

		/// <summary>
		/// Группировка по ATA
		/// </summary>
		ATA = 5,

		/// <summary>
		/// Группировка по Maintenance Check
		/// </summary>
		Check = 6
    }

	#endregion

	#region public enum ProlongationWay

	public enum ProlongationWay
	{
		Unknown = -1,
		Auto = 1,
		Manually = 2
	}

	#endregion

	#region public enum AircraftEquipmetType

	public enum AircraftEquipmetType
	{
		None = 0,
		Equipmet = 1,
		TapeOfOperationApproval = 2
	}

	#endregion

	public enum SpecialistPosition : short
	{
		Unknown = -1,
		Probation = 1,
		Temporary = 2,
		Permanent = 3,
		Student = 4,
		Trainer = 5,
		Contractor = 6,
		InFullTime = 7,
		InLimitTime = 8
	}

	public enum SpecialistStatus : short
	{
		Unknown = -1,
		Dismissed = 1,
		InReserve = 2,
		Holiday = 3,
		Acting = 4,

	}

	public enum MailStatus
	{
		Opened = 0,
		Closed = 1,
		Published = 2
	}

	public enum AtlbStatus
	{
		Opened = 0,
		Closed = 1,
	}

	public enum Schedule
	{
		Unknown = -1,
		Summer = 1,
		Winter = 0
	}

	public enum FlightNumberScreenType
	{
		Schedule = 0,
		UnSchedule = 1
	}

}
