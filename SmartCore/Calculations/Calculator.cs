using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using SmartCore.AircraftFlights;
using SmartCore.Aircrafts;
using SmartCore.Analyst;
using SmartCore.Auxiliary;
using SmartCore.Component;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Quality;
using Convert = System.Convert;

namespace SmartCore.Calculations
{

	/// <summary>
	/// Калькулятор системы Cas
	/// </summary>
	//TODO (Evgenii Babak): Нужно произвести рефакторинг и вынести методы в отдельные классы
	//TODO (Evgenii Babak): нужно заменить название метода GetFlightsLifelength на GetOpeningFlightLifelength или GetClosingFlightLifelength
	//TODO (Evgenii Babak): рассмотреть код и избавиться от повторений
	public class Calculator : ICalculator
    {
		/*
         * Связь с ядром
         */

	    private readonly ICasEnvironment _environment;
	    private readonly IComponentCore _componentCore;
		private readonly IAircraftFlightCore _aircraftFlightCore;
		private readonly IAircraftsCore _aircraftsCore;

		#region public Calculator(ICasEnvironment casEnvironment)
		/// <summary>
		/// Создает калькулятор для ядра
		/// </summary>
		public Calculator(ICasEnvironment environment, IComponentCore componentCore,
			IAircraftFlightCore aircraftFlightCore, IAircraftsCore aircraftsCore)
        {
	        _environment = environment;
	        _componentCore = componentCore;
			_aircraftFlightCore = aircraftFlightCore;
			_aircraftsCore = aircraftsCore;
        }

		#endregion

		/*
         * Работа с калькулятором
         */

		#region private void Init()
		/// <summary>
		/// Загружает все данные из базы, необходимые для расчета состояния агрегатов и воздушных судов
		/// </summary>
		private void Init()
        {
            // Загружаем математический аппарат единажды
            if (_mathLoaded) return;

            // Вызываем метод загрузки мат аппарата
            LoadCalculator();

            // Ставим флаг о том, что математичесский аппарат загружен
            _mathLoaded = true;
        }
        #endregion

        #region public void Reset()
        /// <summary>
        /// Сбрасывает калькулятор - при следующем обращении к калькулятору, он будет занового загружен
        /// </summary>
        public void Reset()
        {
            _mathLoaded = false;
        }
        #endregion

        #region public void InitAsync(BackgroundWorker backgroundWorker, LoadingState loadingState)
        /// <summary>
        /// Загружает все данные из базы, необходимые для расчета состояния агрегатов и воздушных судов
        /// </summary>
        public void InitAsync(BackgroundWorker backgroundWorker, LoadingState loadingState)
        {
            // для математического аппарата необходимо загрузить 
            // 1) полеты всех воздушных судов
            // 2) актуальные состояния базовых агрегатов
            // 3) данные о перемещениях transfer records 
            // 4) директивы базовых агрегатов

            // 0)
            if (backgroundWorker == null) return;

            if (loadingState == null)
                loadingState = new LoadingState();
            loadingState.MaxPersentage = 4;


            loadingState.CurrentPersentage = 0;
            loadingState.CurrentPersentageDescription = "Load Flights";
            backgroundWorker.ReportProgress(1, loadingState);
			// 1)
			//TODO :(Evgenii Babak) Надо просмотреть концепцию загрузки данных здесь
			//_aircraftFlightCore.LoadAllFlights();

            if (backgroundWorker.CancellationPending)
            {
                return;
            }

            loadingState.CurrentPersentage = 1;
            loadingState.CurrentPersentageDescription = "Load Actual States";
            backgroundWorker.ReportProgress(1, loadingState);
			// 2) 
			//TODO :(Evgenii Babak) Надо просмотреть концепцию загрузки данных здесь
			_componentCore.LoadBaseComponentsActualStateRecords();

            if (backgroundWorker.CancellationPending)
            {
                return;
            }

            loadingState.CurrentPersentage = 2;
            loadingState.CurrentPersentageDescription = "Load Transfer Records";
            backgroundWorker.ReportProgress(1, loadingState);
			// 3)
			//TODO :(Evgenii Babak) Надо просмотреть концепцию загрузки данных здесь
			//_componentCore.LoadBaseComponentsTransferRecords();

            if (backgroundWorker.CancellationPending)
            {
                return;
            }

            loadingState.CurrentPersentage = 3;
            loadingState.CurrentPersentageDescription = "Load Detail Directives";
            backgroundWorker.ReportProgress(1, loadingState);
			// 4) 
			//TODO :(Evgenii Babak) Надо просмотреть концепцию загрузки данных здесь
			_componentCore.LoadBaseComponentsDirectives();

            if (backgroundWorker.CancellationPending)
            {
                return;
            }

            loadingState.CurrentPersentage = 4;
            loadingState.CurrentPersentageDescription = "Complete";
            backgroundWorker.ReportProgress(1, loadingState);

            _mathLoaded = true;
        }
        #endregion

        /*
         * Расчет дат
         */

        #region public DateTime GetMaxDate(DateTime dateTime1, DateTime dateTime2)

        /// <summary>
        /// Возвращает максимальную дату из двух переданных дат
        /// </summary>
        /// <param name="dateTime1"></param>
        /// <param name="dateTime2"></param>
        /// <returns></returns>
        public DateTime GetMaxDate(DateTime dateTime1, DateTime dateTime2)
        {
            return GetMaxDate(new[]{dateTime1, dateTime2});
        }

		#endregion

		#region private DateTime GetMaxDate(DateTime[] dateTimes)

		/// <summary>
		/// Возвращает максимальную дату из массива переданных дат
		/// </summary>
		/// <param name="dateTimes"></param>
		/// <returns></returns>
		private DateTime GetMaxDate(DateTime[] dateTimes)
        {
            return dateTimes.Max();
        }

        #endregion

        #region public DateTime GetManufactureDate(BaseSmartCoreObject source)

        /// <summary>
        /// Возвращает дату производства базового агрегата, агрегата или самолета
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public DateTime GetManufactureDate(BaseEntityObject source)
        {
	        return getManufactureDate(source);
        }

		#endregion

		#region private DateTime getManufactureDate(BaseEntityObject source)

		/// <summary>
		/// Возвращает дату производства базового агрегата, агрегата или самолета
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		private DateTime getManufactureDate(BaseEntityObject source)
		{
			if (source == null) return DateTimeExtend.GetCASMinDateTime();
			if (source is Aircraft) return ((Aircraft)source).ManufactureDate;
			if (source is BaseComponent) return ((BaseComponent)source).ManufactureDate;
			if (source is Entities.General.Accessory.Component) return ((Entities.General.Accessory.Component)source).ManufactureDate;
			return DateTimeExtend.GetCASMinDateTime();
		}

		#endregion

		#region public DateTime GetStartDate(IDirective directive)
		public DateTime GetStartDate(IDirective directive)
        {
            if (directive == null || directive.Threshold == null) return DateTimeExtend.GetCASMinDateTime();

            DateTime? sinceNew = null;
            DateTime? sinceEffDate = null;

            if (directive.Threshold.FirstPerformanceSinceEffectiveDate != null &&
               !directive.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
            {
                sinceEffDate = directive.Threshold.EffectiveDate;
            }
            if (directive.Threshold.FirstPerformanceSinceNew != null &&
               !directive.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
            {
                sinceNew = getManufactureDate(directive.LifeLengthParent);
            }

            if (sinceNew != null && sinceEffDate != null)
            {
                if (directive.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst)
                {
                    return sinceNew < sinceEffDate ? sinceNew.Value : sinceEffDate.Value;
                }
                return sinceNew > sinceEffDate ? sinceNew.Value : sinceEffDate.Value;
            }
            if (sinceNew != null) return sinceNew.Value;
            if (sinceEffDate != null) return sinceEffDate.Value;
            return DateTimeExtend.GetCASMinDateTime();
        }
		#endregion

		//TODO: прототип альтернативного расчета приблизительной даты выполнения. Требуется доработать 
		#region private DateTime? GetApproximateDate(BaseEntityObject source, Lifelength lifelength, ThresholdConditionType conditionType = ThresholdConditionType.WhicheverFirst)

		private DateTime? GetApproximateDate(BaseEntityObject source, 
                                             Lifelength lifelength,
                                             Lifelength current,
                                             ThresholdConditionType conditionType = ThresholdConditionType.WhicheverFirst)
        {
            if (source == null)
                return null;
            if (lifelength == null || lifelength.IsNullOrZero())
                return getManufactureDate(source);
            if (current == null || current.IsNullOrZero())
                return null;

            #region

            //DateTime manufactureDate = GetManufactureDate(source);
            //if(conditionType == ThresholdConditionType.WhicheverFirst)
            //{
            //    DateTime date;
            //    for (date = DateTime.Today; date > manufactureDate; date = date.AddDays(-1))
            //    {
            //        Lifelength lastDetailLifelengthLessThanReq = GetLifelength(source, date);
            //        lastDetailLifelengthLessThanReq.Resemble(lifelength);
            //        //Если найденная наработка больше искомой хотя бы по одному параметру
            //        //то поиск продолжается
            //        if (lastDetailLifelengthLessThanReq.IsGreaterByAnyParameter(lifelength))
            //            continue;
            //        //Если найденная наработка меньше искомой по всем параметрам
            //        //то нужно произвести дополнительный поиск наработки, которая
            //        //будет меньше найденной хотя бы по одному параметру
            //        //Это нужно для того что бы определить: 
            //        //введена ли найденная наработка актуальным состоянием или же 
            //        //не находится ли деталь на дату найденной наработки в простое (на складе или остановленном ВС)
            //        //Найденная наработка будет использоваться как нижняя граница поиска
            //        DateTime firstDetailLifelengthLessThanReqDate;
            //        Lifelength firstDetailLifelengthLessThanReq = Lifelength.Null;
            //        for (firstDetailLifelengthLessThanReqDate = date;
            //             firstDetailLifelengthLessThanReqDate > manufactureDate;
            //             firstDetailLifelengthLessThanReqDate = firstDetailLifelengthLessThanReqDate.AddDays(-1))
            //        {
            //            firstDetailLifelengthLessThanReq = GetLifelength(source, firstDetailLifelengthLessThanReqDate);
            //            firstDetailLifelengthLessThanReq.Resemble(lifelength);

            //            if (firstDetailLifelengthLessThanReq.IsLessByAnyParameter(lastDetailLifelengthLessThanReq))
            //            {
            //                firstDetailLifelengthLessThanReqDate.AddDays(1);
            //                firstDetailLifelengthLessThanReq = GetLifelength(source, firstDetailLifelengthLessThanReqDate);
            //                firstDetailLifelengthLessThanReq.Resemble(lifelength);
            //                break;
            //            }
            //        }
            //        //Найденная в начале цикла наработка меньше искомой по всем параметрам
            //        //значит, наработка на пред. шаге была больше хотя бы по одному параметру
            //        //и эту наработку (на пред. шаге) надо использовать как верхнюю границу поиска
            //        DateTime firstDetailLifelengthGratherThanReqDate = date.AddDays(1);
            //        Lifelength firstDetailLifelengthGratherThanReq = GetLifelength(source, firstDetailLifelengthGratherThanReqDate);
            //        firstDetailLifelengthGratherThanReq.Resemble(lifelength);

            //        if (firstDetailLifelengthLessThanReq.IsNullOrZero() &&
            //            firstDetailLifelengthGratherThanReq.IsNullOrZero())
            //        {
            //            return null;
            //        }
            //        if(!firstDetailLifelengthLessThanReq.IsNullOrZero() &&
            //           firstDetailLifelengthGratherThanReq.IsNullOrZero())
            //        {
            //            //Имеется нижний предел, но нет верхнего.
            //            //Возможно, наработка введена актуальным состоянием
                        
            //            //Надо произвести цикличное добавление значения средней утилизации
            //            //пока наработка не станет больше хотя бы по одному параметру
            //            //выше искомой
            //            AverageUtilization au = GetAverageUtillization(source as IDirective);
            //            if (au == null)
            //                return null;
            //            int i = 1;
            //            //firstDetailLifelengthLessThanReqDate = firstDetailLifelengthLessThanReqDate.AddDays(1);
            //            for (firstDetailLifelengthLessThanReqDate = firstDetailLifelengthLessThanReqDate.AddDays(1);
            //                 firstDetailLifelengthLessThanReqDate < firstDetailLifelengthGratherThanReqDate;
            //                 firstDetailLifelengthLessThanReqDate = firstDetailLifelengthLessThanReqDate.AddDays(1))
            //            {
            //                int totalMinutes = Convert.ToInt32(au.HoursPerDay * 60 * i);
            //                int cycles = Convert.ToInt32(au.CyclesPerDay * i);
            //                int days = i;

            //                Lifelength res = firstDetailLifelengthLessThanReq + new Lifelength(days, cycles, totalMinutes);
            //                res.Resemble(lifelength);
            //                if (res.IsGreaterByAnyParameter(lifelength))
            //                    return firstDetailLifelengthLessThanReqDate;

            //                i++;
            //                firstDetailLifelengthLessThanReqDate = firstDetailLifelengthLessThanReqDate.AddDays(1);
            //            }
            //        }
            //        else if (firstDetailLifelengthLessThanReq.IsNullOrZero() &&
            //                 !firstDetailLifelengthGratherThanReq.IsNullOrZero())
            //        {
            //            //Имеется верхний предел, но нет нижнего.

            //            //Надо произвести цикличное вычитание значения средней утилизации
            //            //пока наработка не станет строго меньше искомой
            //            //и взять пред значение даты (пока хотя бы один параметр был больше искомой наработки)
            //            AverageUtilization au = GetAverageUtillization(source as IDirective);
            //            if (au == null)
            //                return null;
            //            int i = 1;
            //            //firstDetailLifelengthGratherThanReqDate = firstDetailLifelengthGratherThanReqDate.AddDays(-1);
            //            for (firstDetailLifelengthGratherThanReqDate = firstDetailLifelengthGratherThanReqDate.AddDays(0);
            //                 firstDetailLifelengthGratherThanReqDate > firstDetailLifelengthLessThanReqDate;
            //                 firstDetailLifelengthGratherThanReqDate = firstDetailLifelengthGratherThanReqDate.AddDays(-1))
            //            {
            //                int totalMinutes = Convert.ToInt32(au.HoursPerDay * 60 * i);
            //                int cycles = Convert.ToInt32(au.CyclesPerDay * i);
            //                int days = i;

            //                Lifelength res = firstDetailLifelengthGratherThanReq - new Lifelength(days, cycles, totalMinutes);
            //                res.Resemble(lifelength);
            //                if (res.IsLess(lifelength))
            //                    return firstDetailLifelengthGratherThanReqDate;
            //                i++;
            //                firstDetailLifelengthGratherThanReqDate = firstDetailLifelengthGratherThanReqDate.AddDays(-1);
            //            }    
            //        }
            //        else if (!firstDetailLifelengthLessThanReq.IsNullOrZero() &&
            //                 !firstDetailLifelengthGratherThanReq.IsNullOrZero())
            //        {
            //            //Имеется верхний и нижний предел.

            //            //Надо произвести цикличное вычитание значения средней утилизации
            //            //пока наработка не станет строго меньше искомой
            //            //и взять пред значение даты (пока хотя бы один параметр был больше искомой наработки)
            //            AverageUtilization au = GetAverageUtillization(source as IDirective);
            //            if (au == null)
            //                return null;
            //            int i = 1;
            //            //firstDetailLifelengthGratherThanReqDate = firstDetailLifelengthGratherThanReqDate.AddDays(-1);
            //            for (firstDetailLifelengthLessThanReqDate = firstDetailLifelengthLessThanReqDate.AddDays(0);
            //                 firstDetailLifelengthLessThanReqDate < firstDetailLifelengthGratherThanReqDate;
            //                 firstDetailLifelengthLessThanReqDate = firstDetailLifelengthLessThanReqDate.AddDays(1))
            //            {
            //                int totalMinutes = Convert.ToInt32(au.HoursPerDay * 60 * i);
            //                int cycles = Convert.ToInt32(au.CyclesPerDay * i);
            //                int days = i;

            //                Lifelength res = firstDetailLifelengthLessThanReq + new Lifelength(days, cycles, totalMinutes);
            //                res.Resemble(lifelength);
            //                if (res.IsGreaterByAnyParameter(lifelength))
            //                    return firstDetailLifelengthLessThanReqDate;

            //                i++;
            //                firstDetailLifelengthLessThanReqDate = firstDetailLifelengthLessThanReqDate.AddDays(1);
            //            }
            //        }
            //        break;
            //    }
            //}
            //else
            //{
            //    DateTime date;
            //    for (date = DateTime.Today; date > manufactureDate; date = date.AddDays(-1))
            //    {
            //        Lifelength lastDetailLifelengthLessThanReq = GetLifelength(source, date);
            //        lastDetailLifelengthLessThanReq.Resemble(lifelength);
            //        //Если найденная наработка больше искомой хотя бы по одному параметру
            //        //то поиск продолжается
            //        if (lastDetailLifelengthLessThanReq.IsGreater(lifelength))
            //            continue;
            //        //Если найденная наработка меньше искомой по всем параметрам
            //        //то нужно произвести дополнительный поиск наработки, которая
            //        //будет меньше найденной хотя бы по одному параметру
            //        //Это нужно для того что бы определить: 
            //        //введена ли найденная наработка актуальным состоянием или же 
            //        //не находится ли деталь на дату найденной наработки в простое (на складе или остановленном ВС)
            //        //Найденная наработка будет использоваться как нижняя граница поиска
            //        DateTime firstDetailLifelengthLessThanReqDate;
            //        Lifelength firstDetailLifelengthLessThanReq = Lifelength.Null;
            //        for (firstDetailLifelengthLessThanReqDate = date;
            //             firstDetailLifelengthLessThanReqDate > manufactureDate;
            //             firstDetailLifelengthLessThanReqDate = firstDetailLifelengthLessThanReqDate.AddDays(-1))
            //        {
            //            firstDetailLifelengthLessThanReq = GetLifelength(source, firstDetailLifelengthLessThanReqDate);
            //            firstDetailLifelengthLessThanReq.Resemble(lifelength);

            //            if (firstDetailLifelengthLessThanReq.IsLess(lastDetailLifelengthLessThanReq))
            //            {
            //                firstDetailLifelengthLessThanReqDate.AddDays(1);
            //                firstDetailLifelengthLessThanReq = GetLifelength(source, firstDetailLifelengthLessThanReqDate);
            //                firstDetailLifelengthLessThanReq.Resemble(lifelength);
            //                break;
            //            }
            //        }
            //        //Найденная в начале цикла наработка меньше искомой по всем параметрам
            //        //значит, наработка на пред. шаге была больше хотя бы по одному параметру
            //        //и эту наработку (на пред. шаге) надо использовать как верхнюю границу поиска
            //        DateTime firstDetailLifelengthGratherThanReqDate = date.AddDays(1);
            //        Lifelength firstDetailLifelengthGratherThanReq = GetLifelength(source, firstDetailLifelengthGratherThanReqDate);
            //        firstDetailLifelengthGratherThanReq.Resemble(lifelength);

            //        if (firstDetailLifelengthLessThanReq.IsNullOrZero() &&
            //            firstDetailLifelengthGratherThanReq.IsNullOrZero())
            //        {
            //            return null;
            //        }
            //        if (!firstDetailLifelengthLessThanReq.IsNullOrZero() &&
            //           firstDetailLifelengthGratherThanReq.IsNullOrZero())
            //        {
            //            //Имеется нижний предел, но нет верхнего.
            //            //Возможно, наработка введена актуальным состоянием

            //            //Надо произвести цикличное добавление значения средней утилизации
            //            //пока наработка не станет больше хотя бы по одному параметру
            //            //выше искомой
            //            AverageUtilization au = GetAverageUtillization(source as IDirective);
            //            if (au == null)
            //                return null;
            //            int i = 1;
            //            //firstDetailLifelengthLessThanReqDate = firstDetailLifelengthLessThanReqDate.AddDays(1);
            //            for (firstDetailLifelengthLessThanReqDate = firstDetailLifelengthLessThanReqDate.AddDays(1);
            //                 firstDetailLifelengthLessThanReqDate < firstDetailLifelengthGratherThanReqDate;
            //                 firstDetailLifelengthLessThanReqDate = firstDetailLifelengthLessThanReqDate.AddDays(1))
            //            {
            //                int totalMinutes = Convert.ToInt32(au.HoursPerDay * 60 * i);
            //                int cycles = Convert.ToInt32(au.CyclesPerDay * i);
            //                int days = i;

            //                Lifelength res = firstDetailLifelengthLessThanReq + new Lifelength(days, cycles, totalMinutes);
            //                res.Resemble(lifelength);
            //                if (res.IsGreater(lifelength))
            //                    return firstDetailLifelengthLessThanReqDate;

            //                i++;
            //                firstDetailLifelengthLessThanReqDate = firstDetailLifelengthLessThanReqDate.AddDays(1);
            //            }
            //        }
            //        else if (firstDetailLifelengthLessThanReq.IsNullOrZero() &&
            //                 !firstDetailLifelengthGratherThanReq.IsNullOrZero())
            //        {
            //            //Имеется верхний предел, но нет нижнего.

            //            //Надо произвести цикличное вычитание значения средней утилизации
            //            //пока наработка не станет строго меньше искомой
            //            //и взять пред значение даты (пока хотя бы один параметр был больше искомой наработки)
            //            AverageUtilization au = GetAverageUtillization(source as IDirective);
            //            if (au == null)
            //                return null;
            //            int i = 1;
            //            //firstDetailLifelengthGratherThanReqDate = firstDetailLifelengthGratherThanReqDate.AddDays(-1);
            //            for (firstDetailLifelengthGratherThanReqDate = firstDetailLifelengthGratherThanReqDate.AddDays(0);
            //                 firstDetailLifelengthGratherThanReqDate > firstDetailLifelengthLessThanReqDate;
            //                 firstDetailLifelengthGratherThanReqDate = firstDetailLifelengthGratherThanReqDate.AddDays(-1))
            //            {
            //                int totalMinutes = Convert.ToInt32(au.HoursPerDay * 60 * i);
            //                int cycles = Convert.ToInt32(au.CyclesPerDay * i);
            //                int days = i;

            //                Lifelength res = firstDetailLifelengthGratherThanReq - new Lifelength(days, cycles, totalMinutes);
            //                res.Resemble(lifelength);
            //                if (res.IsLessByAnyParameter(lifelength))
            //                    return firstDetailLifelengthGratherThanReqDate;
            //                i++;
            //                firstDetailLifelengthGratherThanReqDate = firstDetailLifelengthGratherThanReqDate.AddDays(-1);
            //            }
            //        }
            //        else if (!firstDetailLifelengthLessThanReq.IsNullOrZero() &&
            //                 !firstDetailLifelengthGratherThanReq.IsNullOrZero())
            //        {
            //            //Имеется верхний и нижний предел.

            //            //Надо произвести цикличное вычитание значения средней утилизации
            //            //пока наработка не станет строго меньше искомой
            //            //и взять пред значение даты (пока хотя бы один параметр был больше искомой наработки)
            //            AverageUtilization au = GetAverageUtillization(source as IDirective);
            //            if (au == null)
            //                return null;
            //            int i = 1;
            //            //firstDetailLifelengthGratherThanReqDate = firstDetailLifelengthGratherThanReqDate.AddDays(-1);
            //            for (firstDetailLifelengthLessThanReqDate = firstDetailLifelengthLessThanReqDate.AddDays(0);
            //                 firstDetailLifelengthLessThanReqDate < firstDetailLifelengthGratherThanReqDate;
            //                 firstDetailLifelengthLessThanReqDate = firstDetailLifelengthLessThanReqDate.AddDays(1))
            //            {
            //                int totalMinutes = Convert.ToInt32(au.HoursPerDay * 60 * i);
            //                int cycles = Convert.ToInt32(au.CyclesPerDay * i);
            //                int days = i;

            //                Lifelength res = firstDetailLifelengthLessThanReq + new Lifelength(days, cycles, totalMinutes);
            //                res.Resemble(lifelength);
            //                if (res.IsGreater(lifelength))
            //                    return firstDetailLifelengthLessThanReqDate;

            //                i++;
            //                firstDetailLifelengthLessThanReqDate = firstDetailLifelengthLessThanReqDate.AddDays(1);
            //            }
            //        }
            //        break;
            //    }
            //}
            #endregion

            DateTime manufactureDate = getManufactureDate(source);
            DateTime lowerDate = manufactureDate;
            DateTime upperLimit = DateTime.Today;

            //int difference = (DateTime.Today - lowerDate).Days;
            //if (conditionType == ThresholdConditionType.WhicheverFirst)
            //{
            //    //расчет ведется по формуле Nn+1 = (M - Nn)*(K - KNn)/(KM - KNn), где:
            //    //M - верхняя граница даты
            //    //KM - наработка на верхнюю дату
            //    //N - нижняя граница даты
            //    //KN - наработка на нижнюю дату
            //    //K - искомая наработка
            //    Lifelength kn = GetLifelength(source, lowerDate);
            //    kn.Resemble(lifelength);
            //    Lifelength km = GetLifelength(source, upperLimit);
            //    km.Resemble(lifelength);

            //    AverageUtilization auFact = 
            //        new AverageUtilization(Convert.ToInt32(km.Cycles / difference), 
            //                               Convert.ToInt32(km.Hours / difference), 
            //                               UtilizationInterval.Dayly);
            //    if (auFact == null)
            //        return null;
            //    for (; ; )
            //    {
            //        lowerDate = (DateTime.Today - lowerDate).Days * (lifelength - kn) / (km - kn);
            //        break;
            //    }
            //}
            return null;
        }
		#endregion

		/*
         * Подсчет ресурсов
         */

		#region public Lifelength GetCurrentFlightLifelength(BaseSmartCoreObject source, ForecastData forecastData = null)

		/// <summary>
		/// Возвращает текущую наработку для базового агрегата, агрегата или самолета
		/// </summary>
		/// <param name="source"></param>
		/// <param name="forecastData"></param>
		/// <returns></returns>
		public Lifelength GetCurrentFlightLifelength(BaseEntityObject source, ForecastData forecastData = null)
        {
            if (source == null) return Lifelength.Null;
            if (forecastData == null) return getFlightLifelengthOnEndOfDay(source, DateTime.Today);
            if (forecastData.ForecastDate <= DateTime.Today) return getFlightLifelengthOnEndOfDay(source, forecastData.ForecastDate);
            
            var res = getFlightLifelengthOnEndOfDay(source, DateTime.Today); 
            res += AnalystHelper.GetUtilization(forecastData.AverageUtilization,(forecastData.ForecastDate - DateTime.Today).Days);
            return res;
        }

		#endregion

		#region public Lifelength GetFlightLifelengthOnEndOfDay(BaseSmartCoreObject source, DateTime effDate)

		/// <summary>
		/// Возвращает текущую наработку для базового агрегата, агрегата или самолета
		/// </summary>
		/// <param name="source"></param>
		/// <param name="effDate"></param>
		/// <returns></returns>
		public Lifelength GetFlightLifelengthOnEndOfDay(BaseEntityObject source, DateTime effDate)
		{
			return getFlightLifelengthOnEndOfDay(source, effDate);
		}

		#endregion

		#region private Lifelength getFlightLifelengthOnEndOfDay(BaseEntityObject source, DateTime effDate)

		/// <summary>
		/// Возвращает текущую наработку для базового агрегата, агрегата или самолета
		/// </summary>
		/// <param name="source"></param>
		/// <param name="effDate"></param>
		/// <returns></returns>
		private Lifelength getFlightLifelengthOnEndOfDay(BaseEntityObject source, DateTime effDate)
		{
			//if (source == null)
			//    return Lifelength.Null;
			if (source is Operator || source == null)
			{
				if (effDate.Date <= DateTimeExtend.GetCASMinDateTime()) return Lifelength.Zero;
				// вычисляем результат
				var res = new Lifelength { Days = GetDays(DateTimeExtend.GetCASMinDateTime(), effDate.Date) };
				return res;
			}
			if (source is Aircraft) return getFlightLifelengthOnEndOfDay((Aircraft)source, effDate);
			if (source is BaseComponent) return getFlightLifelengthOnEndOfDay((BaseComponent)source, effDate);
			if (source is Entities.General.Accessory.Component) return getFlightLifelengthOnEndOfDay((Entities.General.Accessory.Component)source, effDate);
			return Lifelength.Null;
		}

		#endregion

		#region public Lifelength GetFlightLifelengthOnStartOfDay(BaseSmartCoreObject source, DateTime effDate)

		/// <summary>
		/// Возвращает текущую наработку для базового агрегата, агрегата или самолета
		/// </summary>
		/// <param name="source"></param>
		/// <param name="effDate"></param>
		/// <returns></returns>
		public Lifelength GetFlightLifelengthOnStartOfDay(BaseEntityObject source, DateTime effDate)
		{
			return getFlightLifelengthOnStartOfDay(source, effDate);
		}

		#endregion

		#region private Lifelength getFlightLifelengthOnStartOfDay(BaseEntityObject source, DateTime effDate)

		/// <summary>
		/// Возвращает текущую наработку для базового агрегата, агрегата или самолета
		/// </summary>
		/// <param name="source"></param>
		/// <param name="effDate"></param>
		/// <returns></returns>
		private Lifelength getFlightLifelengthOnStartOfDay(BaseEntityObject source, DateTime effDate)
		{
			if (source == null) return Lifelength.Null;
			if (source is Operator)
			{
				if (effDate.Date <= DateTimeExtend.GetCASMinDateTime()) return Lifelength.Zero;
				// вычисляем результат
				var res = new Lifelength { Days = GetDays(DateTimeExtend.GetCASMinDateTime(), effDate.Date) };
				return res;
			}
			if (source is Aircraft) return getFlightLifelengthOnStartOfDay((Aircraft)source, effDate);
			if (source is BaseComponent) return getFlightLifelengthOnStartOfDay((BaseComponent)source, effDate);
			//TODO:(Evgenii Babak) выяснить почему берется наработка на конец дня и не делается cast к Component
			if (source is Entities.General.Accessory.Component) return getFlightLifelengthOnEndOfDay(source, effDate);
			return Lifelength.Null;
		}

		#endregion

		#region public Lifelength GetFlightLifelengthOnStartOfDay(BaseSmartCoreObject source, ForecastData forecastData = null)

		/// <summary>
		/// Возвращает текущую наработку для базового агрегата, агрегата или самолета
		/// </summary>
		/// <param name="source"></param>
		/// <param name="forecastData"></param>
		/// <returns></returns>
		public Lifelength GetFlightLifelengthOnStartOfDay(BaseEntityObject source, ForecastData forecastData = null)
        {
            //if (source == null) return Lifelength.Null;
            if (source == null)
                return new Lifelength { Days = GetDays(DateTimeExtend.GetCASMinDateTime(), DateTime.Today) };

            if (forecastData == null) return getFlightLifelengthOnStartOfDay(source, DateTime.Today);
            if (forecastData.ForecastDate <= DateTime.Today) return getFlightLifelengthOnStartOfDay(source, forecastData.ForecastDate);

            var res = getFlightLifelengthOnStartOfDay(source, DateTime.Today);
            res += AnalystHelper.GetUtilization(forecastData.AverageUtilization, (forecastData.ForecastDate - DateTime.Today).Days);
            return res;
        }

		#endregion


		// Воздушное судно

		#region private Lifelength getFlightsLifelengthByPeriod(Aircraft aircraft, DateTime dateFrom, DateTime dateTo)
		/// <summary>
		/// Возвращает суммарный налет воздушного судна за указанный период
		/// </summary>
		/// <param name="aircraft"></param>
		/// <param name="dateFrom"></param>
		/// <param name="dateTo"></param>
		/// <returns></returns>
		private Lifelength getFlightsLifelengthByPeriod(Aircraft aircraft, DateTime dateFrom, DateTime dateTo)
        {
            dateFrom = dateFrom.Date;
            dateTo = dateTo.Date;

			var flights = _aircraftFlightCore.GetAircraftFlightsByAircraftId(aircraft.ItemId);

			var aircraftFrame = _componentCore.GetBaseComponentById(aircraft.AircraftFrameId);
			// пробегаемся по всем полетам
			var res = getFlightLifelengthByPeriod(flights, aircraftFrame, dateFrom, dateTo);

            res.Days = GetDays(dateFrom, dateTo);
            return res;
        }
		#endregion

		#region public Lifelength GetFlightLifelengthOnStartOfDay(Aircraft aircraft, DateTime date)
		/// <summary>
		/// Возвращает налет воздушного судна на начало дня (без учета совершенных полетов)
		/// </summary>
		/// <param name="aircraft"></param>
		/// <param name="date"></param>
		/// <returns></returns>
		public Lifelength GetFlightLifelengthOnStartOfDay(Aircraft aircraft, DateTime date)
		{
			return getFlightLifelengthOnStartOfDay(aircraft, date);
		}

		#endregion

		#region private Lifelength getFlightLifelengthOnStartOfDay(Aircraft aircraft, DateTime date)
		/// <summary>
		/// Возвращает налет воздушного судна на начало дня (без учета совершенных полетов)
		/// </summary>
		/// <param name="aircraft"></param>
		/// <param name="date"></param>
		/// <returns></returns>
		private Lifelength getFlightLifelengthOnStartOfDay(Aircraft aircraft, DateTime date)
		{
			Init();

			// ресурс на момент производства равен нулю 
			date = date.Date;
			if (date <= aircraft.ManufactureDate) return Lifelength.Zero;

			var aircraftFrame = _componentCore.GetBaseComponentById(aircraft.AircraftFrameId);
			// если наработка уже подсчитанна - возвращаем ее
			var saved = aircraftFrame.LifelengthCalculated.GetLifelengthOnStartOfDay(date);
			if (saved != null) return new Lifelength(saved);

			// вычисляем результат
			Lifelength res;

			// если на указанную дату было задано актуальное состояние - оно и будет является налетом воздушного судна на начало дня
			var actual = aircraftFrame.ActualStateRecords.GetLastKnownRecord(date);
			if (actual != null && actual.RecordDate.Date == date)
			{
				res = new Lifelength(actual.OnLifelength);

				// Если мы не имеем один из параметров актуального состояния - берем его из наработки на предыдущий день
				if (res.Cycles == null || res.TotalMinutes == null)
					res.CompleteNullParameters(getFlightLifelengthOnEndOfDay(aircraft, actual.RecordDate.Date.AddDays(-1)));

				// Выставляем правильный календарь
				res.Days = GetDays(aircraft.ManufactureDate, date);
			}
			else
			{
				// если актуальных состояние вообще не задано либо задано но на давнюю дату то 
				// налет вс на начало дня равен налету вс на конец предыдущего дня
				res = getFlightLifelengthOnEndOfDay(aircraft, date.AddDays(-1));
			}

			// сохраняем в кэш и возвращаем результат
			aircraftFrame.LifelengthCalculated.SetLifelengthOnStartOfDay(date, res);
			return new Lifelength(res);
		}

		#endregion

		#region public Lifelength GetFlightLifelengthOnEndOfDay(Aircraft aircraft, DateTime date)
		/// <summary>
		/// Возвращает налет воздушного судна на конец дня (учитывая совершенные полеты)
		/// </summary>
		/// <param name="aircraft"></param>
		/// <param name="date"></param>
		/// <returns></returns>
		public Lifelength GetFlightLifelengthOnEndOfDay(Aircraft aircraft, DateTime date)
		{                                                                        
			return getFlightLifelengthOnEndOfDay(aircraft, date);
		}

		#endregion

		#region private Lifelength getFlightLifelengthOnEndOfDay(Aircraft aircraft, DateTime date)
		/// <summary>
		/// Возвращает налет воздушного судна на конец дня (учитывая совершенные полеты)
		/// </summary>
		/// <param name="aircraft"></param>
		/// <param name="date"></param>
		/// <returns></returns>
		private Lifelength getFlightLifelengthOnEndOfDay(Aircraft aircraft, DateTime date)
		{
			Init();

			// если склад то свойство aircraft пусто, а наработка равна нулю
			if (aircraft == null) return Lifelength.Zero;

			// раньше производства равен нулю 
			date = date.Date;
			if (date < aircraft.ManufactureDate) return Lifelength.Zero;

			var aircraftFrame = _componentCore.GetBaseComponentById(aircraft.AircraftFrameId);
			// если наработка уже подсчитана - возвращаем ее
			//Lifelength saved = aircraft.Frame.LifelengthCalculated[date];
			var saved = aircraftFrame.LifelengthCalculated.GetLifelengthOnEndOfDay(date);
			if (saved != null) return new Lifelength(saved);
			// вычисляем результат

			// получаем последнее Actual State на заданную дату 
			// получаем на него Opening Lifelength и затем прибавляем все сделанные полеты за интервал
			var actual = aircraftFrame.ActualStateRecords.GetLastKnownRecord(date);
			var res = (actual == null) ? Lifelength.Zero : getFlightLifelengthOnStartOfDay(aircraft, actual.RecordDate.Date);
			var startDate = (actual == null) ? aircraft.ManufactureDate : actual.RecordDate.Date;
			res.Add(getFlightsLifelengthByPeriod(aircraft, startDate, date)); // opening сейчас учитывает все полеты от start date

			//TODO (Evgenii Babak) : Посмотреть почему добавляем + 1 день
			// календарь
			res.Days = GetDays(aircraft.ManufactureDate, date) + 1;

			// сохраняем результат в динамическом массиве и возвращаем результат
			aircraftFrame.LifelengthCalculated.SetLifelengthOnEndOfDay(date, res);
			return new Lifelength(res);
		}

		#endregion

		#region public Lifelength GetFlightLifelengthForPeriod(Aircraft aircraft, DateTime fromDate, DateTime toDate)
		/// <summary>
		/// Возвращает налет воздушного судна за заданный интервал
		/// </summary>
		/// <param name="aircraft"></param>
		/// <param name="fromDate"></param>
		/// <param name="toDate"></param>
		/// <returns></returns>
		public Lifelength GetFlightLifelengthForPeriod(Aircraft aircraft, DateTime fromDate, DateTime toDate)
		{
			return getFlightLifelengthForPeriod(aircraft, fromDate, toDate);
		}
		#endregion

		#region private Lifelength getFlightLifelengthForPeriod(Aircraft aircraft, DateTime fromDate, DateTime toDate)
		/// <summary>
		/// Возвращает налет воздушного судна за заданный интервал
		/// </summary>
		/// <param name="aircraft"></param>
		/// <param name="fromDate"></param>
		/// <param name="toDate"></param>
		/// <returns></returns>
		private Lifelength getFlightLifelengthForPeriod(Aircraft aircraft, DateTime fromDate, DateTime toDate)
		{
			// Налет воздушного судна между двумя датами равен разности налета на заданные даты
			var res = getFlightLifelengthOnEndOfDay(aircraft, toDate);
			res.Substract(getFlightLifelengthOnEndOfDay(aircraft, fromDate));
			res.Days = Convert.ToInt32((toDate.Date.Ticks - fromDate.Date.Ticks) / TimeSpan.TicksPerDay);
			return res;
		}
		#endregion

		#region public Lifelength GetFlightLifelengthIncludingThisFlight(AircraftFlight flight)
		/// <summary> 
		/// Возвращает налет воздушного судна после завершения указанного полета
		/// </summary>
		/// <param name="flight"></param>
		/// <returns></returns>
		public Lifelength GetFlightLifelengthIncludingThisFlight(AircraftFlight flight)
        {
            var aircraft = _aircraftsCore.GetAircraftById(flight.AircraftId);
            if (aircraft == null) throw new Exception($"Flight {flight.ItemId} has no aircraft related");

            // Если это был последний полет за указанный день возвращаем налет вс на конец дня
            if (flight.LDGTime < flight.TakeOffTime) return getFlightLifelengthOnEndOfDay(aircraft, flight.FlightDate);

            // Сначала получаем налет воздушного судна на заданную дату 
            var initial = getFlightLifelengthOnStartOfDay(aircraft, flight.FlightDate);

            // Пробегаемся по всем полетам, которые идут до этого полета
            foreach (var t in _aircraftFlightCore.GetAircraftFlightsByAircraftId(aircraft.ItemId).Where(f => f.AtlbRecordType != AtlbRecordType.Maintenance))
            {
                if (t.FlightDate.Date == flight.FlightDate.Date)
                    initial.Add(t.FlightTimeLifelength);

                // возвращаемся если дошли до заданного полета
                if (t.ItemId == flight.ItemId) break;
            }

            // Календарь
            initial.Days = GetDays(aircraft.ManufactureDate, flight.FlightDate);

            // initial хранит в себе налет вс на начало соответсвующего дня + все полеты по заданный включительно
            return initial;
        }
		#endregion

		#region public Lifelength GetCurrentFlightLifelength(Aircraft aircraft)
		/// <summary>
		/// Возвращает текущий налет воздушного судна
		/// </summary>
		/// <param name="aircraft"></param>
		/// <returns></returns>
		public Lifelength GetCurrentFlightLifelength(Aircraft aircraft)
        {
            return getFlightLifelengthOnEndOfDay(aircraft, DateTime.Today);
        }
		#endregion

		#region private Lifelength getBlocksLifelengthByPeriod(Aircraft aircraft, DateTime dateFrom, DateTime dateTo)
		/// <summary>
		/// Возвращает суммарный налет воздушного судна за указанный период
		/// </summary>
		/// <param name="aircraft"></param>
		/// <param name="dateFrom"></param>
		/// <param name="dateTo"></param>
		/// <returns></returns>
		private Lifelength getBlocksLifelengthByPeriod(Aircraft aircraft, DateTime dateFrom, DateTime dateTo)
		{
			dateFrom = dateFrom.Date;
			dateTo = dateTo.Date;

			var flights = _aircraftFlightCore.GetAircraftFlightsByAircraftId(aircraft.ItemId);
			var aircraftFrame = _componentCore.GetBaseComponentById(aircraft.AircraftFrameId);
			// пробегаемся по всем полетам
			var res = getBlockLifelengthForPeriod(flights, aircraftFrame, dateFrom, dateTo);

			res.Days = GetDays(dateFrom, dateTo);
			return res;
		}
		#endregion

		#region private Lifelength GetBlockLifelengthOnEndOfDay(Aircraft aircraft, DateTime date)
		/// <summary>
		/// Возвращает налет воздушного судна на конец дня (учитывая совершенные полеты)
		/// </summary>
		/// <param name="aircraft"></param>
		/// <param name="date"></param>
		/// <returns></returns>
		private Lifelength getBlockLifelengthOnEndOfDay(Aircraft aircraft, DateTime date)
		{
			Init();

			// если склад то свойство aircraft пусто, а наработка равна нулю
			if (aircraft == null) return Lifelength.Zero;

			// раньше производства равен нулю 
			date = date.Date;
			if (date < aircraft.ManufactureDate) return Lifelength.Zero;

			// вычисляем результат

			var aircraftFrame = _componentCore.GetBaseComponentById(aircraft.AircraftFrameId);
			// получаем последнее Actual State на заданную дату 
			// получаем на него Opening Lifelength и затем прибавляем все сделанные полеты за интервал
			var actual = aircraftFrame.ActualStateRecords.GetLastKnownRecord(date);
			var res = (actual == null) ? Lifelength.Zero : getFlightLifelengthOnStartOfDay(aircraft, actual.RecordDate.Date);
			var startDate = (actual == null) ? aircraft.ManufactureDate : actual.RecordDate.Date;
			res.Add(getBlocksLifelengthByPeriod(aircraft, startDate, date)); // opening сейчас учитывает все полеты от start date

			// календарь
			//TODO (Evgenii Babak) : Посмотреть почему добавляем + 1 день
			res.Days = GetDays(aircraft.ManufactureDate, date) + 1;

			return new Lifelength(res);
		}

		#endregion

		// Базовый агрегат

		#region public Lifelength GetFlightLifelengthIncludingThisFlight(BaseComponent baseComponent, AircraftFlight flight)

		/// <summary> 
		/// Возвращает налет базового агрегата после совершенного полета
		/// </summary>
		/// <param name="baseComponent"></param>
		/// <param name="flight"></param>
		/// <returns></returns>
		public Lifelength GetFlightLifelengthIncludingThisFlight(BaseComponent baseComponent, AircraftFlight flight)
        {
            if (baseComponent == null) throw new Exception($"Flight {flight.ItemId} has no base component related");
            var aircraft = _aircraftsCore.GetAircraftById(baseComponent.ParentAircraftId);
			if (aircraft == null) throw new Exception($"Flight {flight.ItemId} has no aircraft related");

            // Если это был последний полет за указанный день возвращаем налет вс на конец дня
            if (flight.LDGTime < flight.TakeOffTime) return getFlightLifelengthOnEndOfDay(baseComponent, flight.FlightDate);

            // Сначала получаем налет базовой детали, полученный днем ранее
            var initial = getFlightLifelengthOnEndOfDay(baseComponent, flight.FlightDate.Date.AddDays(-1));
			//TODO:(Evgenii Babak) Заметка для бага 598. Требуется учитывать актуальное состояние в этом методе для разрешения бага
			//без учета актуального состояния initial будет LifeLenght.Zero если даты полета и установки базового агрегата совпадают
			//требуется стори для изменения подхода в расчете наработки бд. Нужно избавиться от вычитания одного дня
			var flights = _aircraftFlightCore.GetAircraftFlightsOnDate(aircraft.ItemId, flight.FlightDate.Date).Where(f => f.AtlbRecordType != AtlbRecordType.Maintenance);

			// Пробегаемся по всем полетам, которые идут до этого полета
			foreach (var t in flights)
            {
				var add = getFlightLifelength(t, baseComponent);
	            if (baseComponent.BaseComponentType == BaseComponentType.Apu)
	            {
		            initial.Add(new Lifelength(0, 1, (int?)(t.FlightTimeLifelength.TotalMinutes * aircraft.APUFH)));
	            }
				else initial.Add(add);

				// возвращаемся если дошли до заданного полета
				if (t.ItemId == flight.ItemId) break;
            }

            // Календарь
            initial.Days = GetDays(baseComponent.ManufactureDate, flight.FlightDate);

            // initial хранит в себе налет вс на начало соответсвующего дня + все полеты по заданный включительно
            return initial;
        }
		#endregion

		#region public Lifelength GetFlightLifelengthOnStartOfDay(BaseComponent baseComponent, DateTime date)

		/// <summary>
		/// Возвращает наработку базового агрегата на начало дня - без учета полетов воздушного судна и перемещений
		/// </summary>
		/// <param name="baseComponent"></param>
		/// <param name="date"></param>
		/// <returns></returns>
		public Lifelength GetFlightLifelengthOnStartOfDay(BaseComponent baseComponent, DateTime date)
		{
			return getFlightLifelengthOnStartOfDay(baseComponent, date);
		}

		#endregion

		#region private Lifelength getFlightLifelengthOnStartOfDay(BaseComponent baseComponent, DateTime date)

		/// <summary>
		/// Возвращает наработку базового агрегата на начало дня - без учета полетов воздушного судна и перемещений
		/// </summary>
		/// <param name="baseComponent"></param>
		/// <param name="date"></param>
		/// <returns></returns>
		private Lifelength getFlightLifelengthOnStartOfDay(BaseComponent baseComponent, DateTime date)
		{
			Init();

			// если base component - frame - возвращаем налет самого воздушного судна
			if (baseComponent.BaseComponentType == BaseComponentType.Frame)
			{
				var parentAircraft = _aircraftsCore.GetAircraftById(baseComponent.ParentAircraftId);
				return getFlightLifelengthOnStartOfDay(parentAircraft, date);
			}

			// ресурс на момент производства равен нулю
			date = date.Date;
			if (date <= baseComponent.ManufactureDate) return Lifelength.Zero;

			// если наработка уже подсчитана - возвращаем ее
			var saved = baseComponent.LifelengthCalculated.GetLifelengthOnStartOfDay(date);
			if (saved != null) return new Lifelength(saved);

			//TODO:(Evgenii Babak) избавиться от неявной рекурсии
			// вычисляем результат
			var res = getFlightLifelengthOnEndOfDay(baseComponent, date.AddDays(-1));

			return new Lifelength(res);
		}

		#endregion

		#region public Lifelength GetFlightLifelengthOnStartOfDay(BaseComponent baseComponent, DateTime date, FlightRegime flightRegime)

		/// <summary>
		/// Возвращает работу базового агрегата на начало дня в заданном режиме. (только для Engine, Propellers, APU)
		/// </summary>
		/// <param name="baseComponent">базовый агрегат></param>
		/// <param name="date">Дата, на начало которой необходимо вернуть наработку</param>
		/// <param name="flightRegime">режим работы агрегата</param>
		/// <returns></returns>
		public Lifelength GetFlightLifelengthOnStartOfDay(BaseComponent baseComponent, DateTime date, FlightRegime flightRegime)
        {
            //наработка по режимам работы расчитывается только для Двигателей, Пропеллеров и ВСУ
            //по другим типам деталей наработка по режимам не ведется
            if( baseComponent.BaseComponentType != BaseComponentType.Apu &&
                baseComponent.BaseComponentType != BaseComponentType.Engine &&
                baseComponent.BaseComponentType != BaseComponentType.Propeller)
            {
                return getFlightLifelengthOnStartOfDay(baseComponent, date);
            }

            if (flightRegime == null)
                flightRegime = FlightRegime.UNK;
            if (flightRegime == FlightRegime.UNK)
            {
                //при режиме UNK возвращается наработка базовой детали во всех режимах
                return getFlightLifelengthOnStartOfDay(baseComponent, date);
            }

            // ресурс на момент производства равен нулю
            date = date.Date;
            if (date <= baseComponent.ManufactureDate) return Lifelength.Zero;

            // если наработка уже подсчитана - возвращаем ее
            var saved = baseComponent.LifelengthCalculated.GetLifelengthOnStartOfDay(date, flightRegime);
            if (saved != null) return new Lifelength(saved);

            // вычисляем результат
            var res = getFlightLifelengthOnEndOfDay(baseComponent, date.AddDays(-1), flightRegime);

            return new Lifelength(res);
        }

		#endregion

		#region public Lifelength GetCurrentFlightLifelength(BaseComponent baseComponent)
		/// <summary>
		/// Возвращает текущую наработку базового агрегата
		/// </summary>
		/// <param name="baseComponent"></param>
		/// <returns></returns>
		public Lifelength GetCurrentFlightLifelength(BaseComponent baseComponent)
        {
            return getFlightLifelengthOnEndOfDay(baseComponent, DateTime.Today);
        }
		#endregion

		#region public Lifelength GetFlightLifelengthOnEndOfDay(BaseComponent baseComponent, DateTime effectiveDate)
		/// <summary>
		/// Возваращает наработку базового агрегата на конец заданной даты
		/// </summary>
		/// <param name="baseComponent"></param>
		/// <param name="effectiveDate"></param>
		/// <returns></returns>
		public Lifelength GetFlightLifelengthOnEndOfDay(BaseComponent baseComponent, DateTime effectiveDate)
		{
			return getFlightLifelengthOnEndOfDay(baseComponent, effectiveDate);
		}
		#endregion

		#region private Lifelength getFlightLifelengthOnEndOfDay(BaseComponent baseComponent, DateTime effectiveDate)
		/// <summary>
		/// Возваращает наработку базового агрегата на конец заданной даты
		/// </summary>
		/// <param name="baseComponent"></param>
		/// <param name="effectiveDate"></param>
		/// <returns></returns>
		private Lifelength getFlightLifelengthOnEndOfDay(BaseComponent baseComponent, DateTime effectiveDate)
		{
			if (baseComponent == null) return Lifelength.Null;
			// Сначала загружаем математический аппарат
			Init();

			//if (baseDetail.ToString() == "APU S/N 44344")
			//{

			//}
			// Если это Frame воздушного судна, то возвращаем налет самого воздушного судна
			if (baseComponent.BaseComponentType == BaseComponentType.Frame)
			{
				var parentAircraft = _aircraftsCore.GetAircraftById(baseComponent.ParentAircraftId);
				return getFlightLifelengthOnEndOfDay(parentAircraft, effectiveDate);
			}

			// Возвращаем ноль на все, что раньше даты производства
			if (effectiveDate < baseComponent.ManufactureDate) return Lifelength.Zero;

			// Наработка базового агрегата на заданную дату считается 
			// от момента последнего актуального состояния и дальше суммируя налеты ВС между перемещениями базового агрегата
			var res = Lifelength.Zero;

			var actualState = baseComponent.ActualStateRecords.GetLastKnownRecord(effectiveDate);
			
			var llpRecord = baseComponent.ChangeLLPCategoryRecords.GetLast();

			if (llpRecord != null && actualState != null)
			{
				//if (llpRecord.RecordDate > actualState.RecordDate)
					//res = new Lifelength(llpRecord.OnLifelength);
				res = new Lifelength(actualState.OnLifelength);
			}
			else if (llpRecord != null)
				res = new Lifelength(llpRecord.OnLifelength);
			else if(actualState != null)
				res = new Lifelength(actualState.OnLifelength);

			//var res = (actualState != null) ? new Lifelength(actualState.OnLifelength) : Lifelength.Zero;
			// Если мы не имеем один из параметров актуального состояния - берем его из наработки на предыдущий день
			if (actualState != null && (actualState.OnLifelength.Cycles == null || actualState.OnLifelength.TotalMinutes == null))
				res.CompleteNullParameters(getFlightLifelengthOnEndOfDay(baseComponent, actualState.RecordDate.Date.AddDays(-1)));
			var transfers = (actualState != null) ? baseComponent.TransferRecords.GetRecords(actualState.RecordDate.Date, effectiveDate) : baseComponent.TransferRecords.GetRecords(effectiveDate);

			// Суммируем интервалы между перемещениями
			if (transfers != null)
				for (int i = 0; i < transfers.Length; i++)
				{
					var a = transfers[i].DestinationObjectType == SmartCoreType.Aircraft ? _aircraftsCore.GetAircraftById(transfers[i].DestinationObjectId) : null;
					if (a == null) continue; // агрегат был помещен на склад, а склады не содержатся в коллекции воздушных судов

					// в середине цикла берем дату перемещения, а в начале берем дату актуального состояния 
					var dateFrom = i > 0 || actualState == null ? transfers[i].TransferDate : actualState.RecordDate.Date;
					// в конце берем дату dateTo, а в середине цикла дату следующего перемещения
					var dateTo = i < transfers.Length - 1 ? transfers[i + 1].TransferDate : effectiveDate;

					//если дата установки и dateTo одинаковы
					if ((dateFrom == dateTo) && (dateTo == transfers[i].TransferDate))
						continue;
					// суммируем 
					//Lifelength delta = GetLifelength(a, dateFrom, dateTo);
#if KAC
                    Lifelength delta;
                    Lifelength period = GetLifelength(a, dateFrom, dateTo);
                    if (baseDetail.BaseDetailType == BaseDetailType.Apu && a.RegistrationNumber != "EX-37401")
                    {
                        delta = new Lifelength(period.Days, period.Cycles, Convert.ToInt32(period.Cycles*60*1.3));
                    }
                    else delta = period;

#else
					var delta = Lifelength.Zero;
					var flights = _aircraftFlightCore.GetAircraftFlightsByAircraftId(a.ItemId);
					if (baseComponent.BaseComponentType == BaseComponentType.LandingGear)
						delta = getFlightLifelengthForPeriod(a, dateFrom, dateTo);
					else if (baseComponent.BaseComponentType == BaseComponentType.Propeller || baseComponent.BaseComponentType == BaseComponentType.Engine)
					{

						var bdFlightLL = getFlightLifelengthByPeriod(flights, baseComponent, dateFrom, dateTo);
						var aircraftFlightLL = getFlightLifelengthForPeriod(a, dateFrom, dateTo);

						if (aircraftFlightLL.Cycles.HasValue && bdFlightLL.Cycles.HasValue && ((float)bdFlightLL.Cycles / (float)aircraftFlightLL.Cycles < 0.95) ||
							aircraftFlightLL.Hours.HasValue && bdFlightLL.Hours.HasValue && ((float)bdFlightLL.Hours / (float)aircraftFlightLL.Hours < 0.95))
							delta = aircraftFlightLL;
						else delta = bdFlightLL;
					}
					else delta = getFlightLifelengthByPeriod(flights, baseComponent, dateFrom, dateTo);
#endif
					res.Add(delta);
				}

			//
			res.Days = GetDays(baseComponent.ManufactureDate, effectiveDate); // +1 т.к. вторая граница интервала включительно

			// Сохраняем результат
			baseComponent.LifelengthCalculated.SetLifelengthOnEndOfDay(effectiveDate, res);
			//
			return new Lifelength(res);
		}
		#endregion

		#region public Lifelength GetFlightLifelength(BaseComponent baseComponent, DateTime fromDate, DateTime toDate)
		/// <summary>
		/// Возвращает наработку базового агрегата за указанный интервал
		/// </summary>
		/// <param name="baseComponent"></param>
		/// <param name="fromDate"></param>
		/// <param name="toDate"></param>
		/// <returns></returns>
		public Lifelength GetFlightLifelengthForPeriod(BaseComponent baseComponent, DateTime fromDate, DateTime toDate)
		{
			return getFlightLifelengthForPeriod(baseComponent, fromDate, toDate);
		}
		#endregion

		#region private Lifelength getFlightLifelengthForPeriod(BaseComponent baseComponent, DateTime fromDate, DateTime toDate)
		/// <summary>
		/// Возвращает наработку базового агрегата за указанный интервал
		/// </summary>
		/// <param name="baseComponent"></param>
		/// <param name="fromDate"></param>
		/// <param name="toDate"></param>
		/// <returns></returns>
		private Lifelength getFlightLifelengthForPeriod(BaseComponent baseComponent, DateTime fromDate, DateTime toDate)
		{
			var res = getFlightLifelengthOnEndOfDay(baseComponent, toDate);
			res.Substract(getFlightLifelengthOnEndOfDay(baseComponent, fromDate));
			res.Days = Convert.ToInt32((toDate.Date.Ticks - fromDate.Date.Ticks) / TimeSpan.TicksPerDay);
			return res;
		}
		#endregion

		#region public Lifelength GetFlightLifelengthForPeriod(BaseComponent baseComponent, DateTime fromDate, DateTime toDate, FlightRegime flightRegime)

		/// <summary>
		/// Возвращает наработку базового агрегата в указанном режиме за указанный интервал 
		/// <br/>Только для Engine, Propellers, APU
		/// <br/>Для остальных типов базовых агрегатов вернет полную наработку
		/// </summary>
		/// <param name="baseComponent">базовый агрегат></param>
		/// <param name="fromDate">дата начала инетвала</param>
		/// <param name="toDate">дата окончания интервала</param>
		/// <param name="flightRegime">режим работв агрегата</param>
		/// <returns>наработка или Lifelength.Null в случае неверных параметров</returns>
		public Lifelength GetFlightLifelengthForPeriod(BaseComponent baseComponent, DateTime fromDate, DateTime toDate, FlightRegime flightRegime)
        {
            if (baseComponent == null) return Lifelength.Null;

            if (baseComponent.BaseComponentType != BaseComponentType.Apu &&
                baseComponent.BaseComponentType != BaseComponentType.Engine &&
                baseComponent.BaseComponentType != BaseComponentType.Propeller)
            {
                return getFlightLifelengthForPeriod(baseComponent, fromDate, toDate);
            }

            if (flightRegime == null)
                flightRegime = FlightRegime.UNK;
            if (flightRegime == FlightRegime.UNK)
            {
                //при режиме UNK возвращается наработка базовой детали во всех режимах
                return getFlightLifelengthForPeriod(baseComponent, fromDate, toDate);
            }

            var res = getFlightLifelengthOnEndOfDay(baseComponent, toDate, flightRegime);
            res.Substract(getFlightLifelengthOnEndOfDay(baseComponent, fromDate, flightRegime));
            res.Days = Convert.ToInt32((toDate.Date.Ticks - fromDate.Date.Ticks) / TimeSpan.TicksPerDay);
            return res;
        }
		#endregion

		#region private Lifelength getFlightLifelengthOnEndOfDay(BaseComponent baseComponent, DateTime effectiveDate, FlightRegime flightRegime)

		/// <summary>
		/// Возваращает работу базового агрегата в заданном режиме на конец заданной даты 
		/// <br/>(только для Engine, Propellers, APU)
		/// <br/>для агретатов другого типа вернет полную наработку
		/// </summary>
		/// <param name="baseComponent">базовый агрегат></param>
		/// <param name="effectiveDate">дата, на которую необходимо вернуть наработку</param>
		/// <param name="flightRegime">режим работы агрегата</param>
		/// <returns></returns>
		private Lifelength getFlightLifelengthOnEndOfDay(BaseComponent baseComponent, DateTime effectiveDate, FlightRegime flightRegime)
		{
			if (baseComponent == null) return Lifelength.Null;
			//наработка по режимам работы расчитывается только для Двигателей, Пропеллеров и ВСУ
			//по другим типам деталей наработка по режимам не ведется
			if (baseComponent.BaseComponentType != BaseComponentType.Apu &&
				baseComponent.BaseComponentType != BaseComponentType.Engine &&
				baseComponent.BaseComponentType != BaseComponentType.Propeller)
			{
				return getFlightLifelengthOnStartOfDay(baseComponent, effectiveDate);
			}

			if (flightRegime == null)
				flightRegime = FlightRegime.UNK;
			if (flightRegime == FlightRegime.UNK)
			{
				//при режиме UNK возвращается наработка базовой детали во всех режимах
				return getFlightLifelengthOnStartOfDay(baseComponent, effectiveDate);
			}

			// Загрузка математического аппарата
			Init();
			// Возвращает ноль на все, что раньше даты производства
			if (effectiveDate < baseComponent.ManufactureDate) return Lifelength.Zero;

			// Наработка базового агрегата на заданную дату считается 
			// от момента последнего актуального состояния и дальше суммируя налеты ВС между перемещениями базового агрегата

			var actualState = baseComponent.ActualStateRecords.GetLastKnownRecord(effectiveDate, flightRegime);
			var res = (actualState != null) ? new Lifelength(actualState.OnLifelength) : Lifelength.Zero;
			// Если мы не имеем один из параметров актуального состояния - берем его из наработки на предыдущий день
			if (actualState != null && (actualState.OnLifelength.Cycles == null || actualState.OnLifelength.TotalMinutes == null))
				res.CompleteNullParameters(getFlightLifelengthOnEndOfDay(baseComponent, actualState.RecordDate.Date.AddDays(-1), flightRegime));
			var transfers = (actualState != null) ? baseComponent.TransferRecords.GetRecords(actualState.RecordDate.Date, effectiveDate) : baseComponent.TransferRecords.GetRecords(effectiveDate);

			// Суммирование наработки между перемещениями
			if (transfers != null)
				for (int i = 0; i < transfers.Length; i++)
				{
					var a = transfers[i].DestinationObjectType == SmartCoreType.Aircraft ? _aircraftsCore.GetAircraftById(transfers[i].DestinationObjectId) : null;
					if (a == null) continue; // агрегат был помещен на склад, а склады не содержатся в коллекции воздушных судов

					// в середине цикла берем дату перемещения, а в начале берем дату актуального состояния 
					var dateFrom = i > 0 || actualState == null ? transfers[i].TransferDate : actualState.RecordDate.Date;
					// в конце берем дату dateTo, а в середине цикла дату следующего перемещения
					var dateTo = i < transfers.Length - 1 ? transfers[i + 1].TransferDate : effectiveDate;

					//если дата установки и dateTo одинаковы
					if ((dateFrom == dateTo) && (dateTo == transfers[i].TransferDate))
						continue;

					var flights = _aircraftFlightCore.GetAircraftFlightsByAircraftId(a.ItemId);

					// суммируем 
					var delta = getFlightLifelengthForPeriod(flights, baseComponent, dateFrom, dateTo, flightRegime);
					res.Add(delta);
				}

			//
			res.Days = GetDays(baseComponent.ManufactureDate, effectiveDate); // +1 т.к. вторая граница интервала включительно

			// Сохраняем результат
			baseComponent.LifelengthCalculated.SetClosingLifelength(effectiveDate, flightRegime, res);
			//
			return new Lifelength(res);
		}
		#endregion

		#region public Lifelength GetFlightLifelength(AircraftFlight flight, BaseComponent bd)

		/// <summary>
		/// возвращает наработку Базового агрегата за данный полет
		/// Применимо для любых типов Базовых агрегатов 
		/// </summary>
		/// <param name="bd"></param>
		/// <param name="flight"></param>
		/// <returns></returns>
		public Lifelength GetFlightLifelength(AircraftFlight flight, BaseComponent bd)
		{
			return getFlightLifelength(flight, bd);
		}
		#endregion

		#region private Lifelength getFlightLifelength(AircraftFlight flight, BaseComponent bd)
		/// <summary>
		/// возвращает наработку Базового агрегата за данный полет
		/// Применимо для любых типов Базовых агрегатов 
		/// </summary>
		/// <param name="bd"></param>
		/// <returns></returns>
		private Lifelength getFlightLifelength(AircraftFlight flight, BaseComponent bd)
		{
			if (bd == null)
				return Lifelength.Zero;

			if ((bd.BaseComponentType == BaseComponentType.Frame || bd.BaseComponentType == BaseComponentType.LandingGear))
			{
				if (flight.AtlbRecordType == AtlbRecordType.Flight && flight.CancelReason == null)
					return flight.FlightTimeLifelength;

				return Lifelength.Zero;
			}

			if (bd.BaseComponentType != BaseComponentType.Engine &&
				bd.BaseComponentType != BaseComponentType.Apu &&
				bd.BaseComponentType != BaseComponentType.Propeller &&
				flight.RunupsCollection.Count == 0)
				return Lifelength.Zero;

			var res = Lifelength.Zero;
			List<RunUp> runs = null;

			if (bd.BaseComponentType == BaseComponentType.Engine || bd.BaseComponentType == BaseComponentType.Apu)
				runs = flight.RunupsCollection.GetByBaseComponent(bd).ToList();
			else if (bd.BaseComponentType == BaseComponentType.Propeller)
				runs = flight.RunupsCollection.Where(r => r.BaseComponent.BaseComponentType == BaseComponentType.Engine &&
													r.BaseComponent.Position.Trim() == bd.Position.Trim()).ToList();

			if (runs != null)
			{
				if (runs.Count == 0 && bd.BaseComponentType != BaseComponentType.Apu)
					return flight.FlightTimeLifelength;
				if (runs.Count == 0 && bd.BaseComponentType == BaseComponentType.Apu)
				{
					var parentAircraft = _aircraftsCore.GetAircraftById(bd.ParentAircraftId);
					if (parentAircraft.ApuUtizationPerFlightinMinutes != null)
						return new Lifelength(null, 1, parentAircraft.ApuUtizationPerFlightinMinutes);
				}
#if KAC
                if (bd.BaseDetailType == BaseDetailType.Apu)
                {
                    Lifelength period = FlightTimeLifelength;
                    Lifelength delta = ParentAircraft.RegistrationNumber == "EX-37401"
                        ? period
                        : new Lifelength(period.Days, period.Cycles, Convert.ToInt32(period.Cycles * 60 * 1.3));
                    return delta;
                }
#endif
				foreach (var t in runs)
					res.Add(t.Lifelength);

			}
			return res;
		}
		#endregion

		#region  public Lifelength GetFlightLifelength(AircraftFlight flight, BaseComponent bd, FlightRegime flightRegime)

		/// <summary>
		/// возвращает работу детали в заданном режиме за данный полет, если есть ссответствующие данные о работе. 
		/// Применимо только Для Engine и APU
		/// </summary>
		/// <param name="bd"></param>
		/// <param name="flightRegime"></param>
		/// <param name="flight"></param>
		/// <returns></returns>
		public Lifelength GetFlightLifelength(AircraftFlight flight, BaseComponent bd, FlightRegime flightRegime)
		{
			if (flightRegime == null)
				flightRegime = FlightRegime.UNK;
			if (flightRegime == FlightRegime.UNK)
				return getFlightLifelength(flight, bd);

			var res = Lifelength.Zero;
			if (bd == null || !(bd.BaseComponentType == BaseComponentType.Engine ||
								bd.BaseComponentType == BaseComponentType.Apu ||
								bd.BaseComponentType == BaseComponentType.Propeller ||
								flight.PowerUnitTimeInRegimeCollection.Count > 0)) return res;

			List<EngineTimeInRegime> ptrs = null;
			if (bd.BaseComponentType == BaseComponentType.Engine
				|| bd.BaseComponentType == BaseComponentType.Apu)
			{
				ptrs = flight.PowerUnitTimeInRegimeCollection.Where(r => r.BaseComponentId == bd.ItemId
																&& r.FlightRegime == flightRegime).ToList();
			}
			else if (bd.BaseComponentType == BaseComponentType.Propeller)
			{
				ptrs = flight.PowerUnitTimeInRegimeCollection.Where(r => r.BaseComponent.BaseComponentType == BaseComponentType.Engine
																&& r.FlightRegime == flightRegime
																&& r.BaseComponent.Position.Trim() == bd.Position.Trim()).ToList();
			}
			if (ptrs != null)
			{
				foreach (EngineTimeInRegime t in ptrs)
					res.Add(LifelengthSubResource.Minutes, (int)t.TimeInRegime.TotalMinutes);
			}
			return res;
		}
		#endregion

		// Агрегат

		#region public Lifelength GetCurrentFlightLifelength(Component component)
		/// <summary> 
		/// Возвращает текущую наработку агрегата
		/// </summary>
		/// <param name="component"></param>
		/// <returns></returns>
		public Lifelength GetCurrentFlightLifelength(Entities.General.Accessory.Component component)
        {
            if (component is BaseComponent) 
                return getFlightLifelengthOnEndOfDay((BaseComponent) component, DateTime.Today);
            
            return getFlightLifelengthOnEndOfDay(component, DateTime.Today);
        }
		#endregion

		#region public Lifelength GetFlightLifelengthOnEndOfDay(Component component, DateTime effectiveDate)
		/// <summary>
		/// Возвращает наработку агрегата на конец дня
		/// </summary>
		/// <param name="component"></param>
		/// <param name="effectiveDate"></param>
		/// <returns></returns>
		public Lifelength GetFlightLifelengthOnEndOfDay(Entities.General.Accessory.Component component, DateTime effectiveDate)
		{
			return getFlightLifelengthOnEndOfDay(component, effectiveDate);
		}
		#endregion

		#region private Lifelength getFlightLifelengthOnEndOfDay(Component component, DateTime effectiveDate)
		/// <summary>
		/// Возвращает наработку агрегата на конец дня
		/// </summary>
		/// <param name="component"></param>
		/// <param name="effectiveDate"></param>
		/// <returns></returns>
		private Lifelength getFlightLifelengthOnEndOfDay(Entities.General.Accessory.Component component, DateTime effectiveDate)
		{
			//загружаем математический аппарат
			Init();

			// Возвращаем ноль на все, что раньше даты производства
			if (effectiveDate < component.ManufactureDate) return Lifelength.Zero;

			// Наработка обычного агрегата на заданную дату считается 
			// от момента последнего актуального состояния и дальше суммируя наработки базовых агрегатов, на которых был установлен агрегат.

			var actualState = component.ActualStateRecords.GetLastKnownRecord(effectiveDate);
			var res = (actualState != null) ? new Lifelength(actualState.OnLifelength) : Lifelength.Zero;
			// Если мы не имеем один из параметров актуального состояния - берем его из наработки на предыдущий день
			if (actualState != null && (actualState.OnLifelength.Cycles == null || actualState.OnLifelength.TotalMinutes == null))
				res.CompleteNullParameters(getFlightLifelengthOnEndOfDay(component, actualState.RecordDate.Date.AddDays(-1)));
			var transfers = (actualState != null) ? component.TransferRecords.GetRecords(actualState.RecordDate.Date, effectiveDate) : component.TransferRecords.GetRecords(effectiveDate);
			//объекты для расчета данных по LLP категориям
			component.LLPData.Reset();
			var llpChangeRecords = (component.LLPMark && component.LLPCategories) ? component.ChangeLLPCategoryRecords.GetRecords(effectiveDate) : null;
			var llpDateFrom = (component.LLPMark && component.LLPCategories && llpChangeRecords != null && llpChangeRecords.Length > 0)
									   ? llpChangeRecords[0].RecordDate
									   : DateTime.MinValue;
			var llpDateTo = (component.LLPMark && component.LLPCategories && llpChangeRecords != null && llpChangeRecords.Length > 1)
									   ? llpChangeRecords[1].RecordDate
									   : effectiveDate;
			int currentLLPCheckRecordNum = 0;

			#region Новый код расчета наработки по llp

			if (transfers != null)
			{
				for (int i = 0; i < transfers.Length; i++)
				{
					//BaseDetail bd = BaseDetails.GetBaseDetailByRepresentingDetailId(transfers[i].DestinationObjectID);
					var bd = _componentCore.GetBaseComponentById(transfers[i].DestinationObjectId);
					if (bd == null) continue; // такое возможно если базовый агрегат был удален...

					// в середине цикла берем дату перемещения, а в начале берем дату актуального состояния 
					var dateFrom = i > 0 || actualState == null ? transfers[i].TransferDate : actualState.RecordDate.Date;
					// в конце берем дату dateTo, а в середине цикла дату следующего перемещения
					var dateTo = i < transfers.Length - 1 ? transfers[i + 1].TransferDate : effectiveDate;
					// суммируем 
					var delta = getFlightLifelengthForPeriod(bd, dateFrom, dateTo);
					res.Add(delta);

					//расчет данных по LLP КАТЕГОРИЯМ
					if (llpChangeRecords == null || llpChangeRecords.Length == 0) continue;

					for (; ; )
					{
						var lastRecord = component.ChangeLLPCategoryRecords.GetLast();
						//Поиск Категории на которую был совершен переход
						var cat = llpChangeRecords[currentLLPCheckRecordNum].ToCategory;
						//Поиск последнего до эффективной даты известного актуального состояния по категории, на которую был совершен переход
						var llpCategoryActualState = cat != null
							? component.ActualStateRecords.GetLastKnownRecord(effectiveDate, cat.CategoryType)
							: null;
						var data = component.LLPData.GetItemByCatagory(cat);

						if (data == null)
							break;

						if (llpDateTo < dateTo)
						{
							if (llpCategoryActualState != null)
							{
								//Актуальное состояние есть

								//дата актуального состояния ниже даты следующей записи о смене LLP категории
								//(или даты на которую расчитывается наработка)
								if (llpCategoryActualState.RecordDate.Date < llpDateTo)
								{
									//добавляется наработка агрегата между датой актуального состояния
									//и датой следующей записи о смене LLP категории
									//(или даты на которую расчитывается наработка)
									if (llpCategoryActualState.RecordDate.Date < dateFrom)
									{
										data.LLPCurrent += getFlightLifelengthForPeriod(bd, dateFrom, llpDateTo);
									}
									else
									{
										//Дата начала отсчета наработки смещается на дату актуального состояния 
										llpDateFrom = llpCategoryActualState.RecordDate.Date;
										//Наработка отсчитывается от наработки актуального состояния
										data.LLPCurrent = new Lifelength(llpCategoryActualState.OnLifelength);
										data.LLPCurrent += getFlightLifelengthForPeriod(bd, llpDateFrom, llpDateTo);
									}
									llpDateFrom = llpDateTo;
									currentLLPCheckRecordNum++;
									llpDateTo = llpChangeRecords.Length > currentLLPCheckRecordNum + 1
													? llpChangeRecords[currentLLPCheckRecordNum + 1].RecordDate
													: effectiveDate;
								}
								else
								{
									//Дата актуального состояния выше даты след. записис о смене LLP Категории
									//Наработка отсчитывается от наработки актуального состояния
									data.LLPCurrent = new Lifelength(llpCategoryActualState.OnLifelength);
									llpDateFrom = llpDateTo;
									currentLLPCheckRecordNum++;
									llpDateTo = llpChangeRecords.Length > currentLLPCheckRecordNum + 1
													? llpChangeRecords[currentLLPCheckRecordNum + 1].RecordDate
													: effectiveDate;
									if (llpCategoryActualState.RecordDate.Date > dateTo)
									{
										//Дата актуального состояния выше чем дата след. перемещения
										break;
									}
								}
							}
							else
							{
								data.LLPCurrent += getFlightLifelengthForPeriod(bd, llpDateFrom, llpDateTo);
								llpDateFrom = llpDateTo;
								currentLLPCheckRecordNum++;
								llpDateTo = llpChangeRecords.Length > currentLLPCheckRecordNum + 1
												? llpChangeRecords[currentLLPCheckRecordNum + 1].RecordDate
												: effectiveDate;
							}
						}
						else
						{
							if (llpCategoryActualState != null)
							{
								//Актуальное состояние есть
								if (llpCategoryActualState.RecordDate.Date < dateTo)
								{
									if (llpCategoryActualState.RecordDate.Date < dateFrom)
									{
										data.LLPCurrent += getFlightLifelengthForPeriod(bd, dateFrom, dateTo);
									}
									else
									{
										//Дата начала отсчета наработки смещается на дату актуального состояния 
										llpDateFrom = llpCategoryActualState.RecordDate.Date;
										//Наработка отсчитывается от наработки актуального состояния
										data.LLPCurrent = new Lifelength(llpCategoryActualState.OnLifelength);
										data.LLPCurrent += getFlightLifelengthForPeriod(bd, llpDateFrom, dateTo);
									}
									llpDateFrom = dateTo;
									currentLLPCheckRecordNum++;
									break;
								}
								if (llpCategoryActualState.RecordDate.Date < llpDateTo)
								{
									//Дата актуального состояния между датой след перемещения компонента
									//и датой след. записи о смене llp категории

									//Дата начала отсчета наработки смещается на дату актуального состояния 
									llpDateFrom = llpCategoryActualState.RecordDate.Date;
									break;
								}
								//Дата актуального состояния выше чем дата след. записи о смене llp категории
								//Наработка отсчитывается от наработки актуального состояния
								data.LLPCurrent = new Lifelength(llpCategoryActualState.OnLifelength);
								llpDateFrom = dateTo;
								break;
							}
							data.LLPCurrent += getFlightLifelengthForPeriod(bd, llpDateFrom, dateTo);
							llpDateFrom = dateTo;
							break;
						}
					}
				}
			}
			else
			{
				//расчет данных по LLP КАТЕГОРИЯМ
				if (llpChangeRecords != null && llpChangeRecords.Length != 0)
				{
					for (int i = 0; i < llpChangeRecords.Length; i++)
					{
						// в середине цикла берем дату изменения, а в начале берем дату производства 
						llpDateFrom = i > 0 ? llpChangeRecords[i].RecordDate : component.ManufactureDate;
						// в конце берем дату effectiveDate, а в середине цикла дату следующего перемещения
						llpDateTo = i < llpChangeRecords.Length - 1 ? llpChangeRecords[i + 1].RecordDate : effectiveDate;
						// суммируем 
						var data = component.LLPData.GetItemByCatagory(llpChangeRecords[i].ToCategory);
						if (data != null) data.LLPLifelength.Days += GetDays(llpDateFrom, llpDateTo) + 1;
					}
				}
			}

			#endregion

			//
			res.Days = GetDays(component.ManufactureDate, effectiveDate);

			//TODO:LLP расчитывается в ComponentComplianceLifeLimitControl(начиная с 498 строки)
			//component.ParentAircraftId - если Агрегат открыт не со склада
			if (component.ParentAircraftId > 0 && component.LLPMark && component.LLPCategories)
			{
				var aircraft = _aircraftsCore.GetAircraftById(component.ParentAircraftId);
				var lifeLimitCategories = _environment.GetDictionary<LLPLifeLimitCategory>()
					.OfType<LLPLifeLimitCategory>()
					.Where(llp => llp.AircraftModel?.ItemId == aircraft.Model?.ItemId).OrderBy(i => i.GetChar())
					.ToList();


				if (component.ChangeLLPCategoryRecords.Count == 0)
				{
					if (component.ParentBaseComponent != null)
					{
						var lastBaseComponentLL = component.ParentBaseComponent.ChangeLLPCategoryRecords.GetLast();
						if (lastBaseComponentLL != null)
						{
							component.ChangeLLPCategoryRecords.Add(new ComponentLLPCategoryChangeRecord
							{
								ParentId = component.ItemId,
								ToCategory = lastBaseComponentLL.ToCategory ?? LLPLifeLimitCategory.Unknown,
								RecordDate = lastBaseComponentLL.RecordDate,
								OnLifelength = Lifelength.Zero
							});
							_environment.NewKeeper.Save(component.ChangeLLPCategoryRecords[0]);
						}
					}
				}

				foreach (var t in lifeLimitCategories)
				{
					var llpData = component.LLPData.GetItemByCatagory(t);
					if (llpData == null)
					{
						llpData = new ComponentLLPCategoryData
						{
							LLPLifeLimit = component.LifeLimit,
							ParentCategory = t,
							ComponentId = component.ItemId
						};
						component.LLPData.Add(llpData);
						_environment.NewKeeper.Save(llpData);
					}

					var lastRecord = component.ChangeLLPCategoryRecords.GetLast();
					var selectedCategory = lastRecord?.ToCategory;

					if (selectedCategory != null)
					{
						if (component.StartDate < llpData.FromDate && llpData.LLPLifeLengthForDate.Cycles.HasValue && llpData.LLPLifeLengthForDate.Cycles != 0 && llpData.LLPCurrent != null)
							llpData.LLPCurrent += llpData.LLPLifeLengthForDate;

						
						if (llpData.LLPCurrent != null)
						{
							if (!llpData.LLPCurrent.IsEqual(llpData.LLPTemp))
							{
								llpData.LLPTemp = new Lifelength(llpData.LLPCurrent);
								//TODO: нет LLPTemp на WCF сервисе(ComponentLLPCategoryDataDTO) РАЗОБРАТЬСЯ!!!!!!!!!!!!!!!!!!!!!!!!!!
								//_environment.NewKeeper.Save(llpData, writeAudit: false);
							}
						}

						if (selectedCategory.ItemId == t.ItemId)
						{
							if (!lastRecord.OnLifelength.IsEqual(llpData.LLPLifeLengthForDate))
							{
								lastRecord.OnLifelength = new Lifelength(llpData.LLPLifeLengthForDate);
								_environment.NewKeeper.Save(lastRecord);
							}
						}
					}

				}

				foreach (var data in component.LLPData)
				{
					double hours = 1, cycles = 1, days = 1;
					foreach (var categoryData in component.LLPData)
					{
						var llp = categoryData.LLPCurrent ?? categoryData.LLPTemp;

						if (categoryData.LLPLifeLimit?.Hours != null && llp?.Hours != null &&
						    categoryData.LLPLifeLimit?.Hours != 0)
						{
							hours -= (double)llp?.Hours / (double)categoryData.LLPLifeLimit.Hours;
						}
						if (categoryData.LLPLifeLimit?.Cycles != null && llp?.Cycles != null &&
						    categoryData.LLPLifeLimit?.Cycles != 0)
						{
							cycles -= (double)llp?.Cycles / (double)categoryData.LLPLifeLimit.Cycles;
						}
						if (categoryData.LLPLifeLimit?.Days != null && llp?.Days != null &&
						    categoryData.LLPLifeLimit?.Days != 0)
						{
							days -= (double)llp?.Days / (double)categoryData.LLPLifeLimit.Days;
						}
					}
					data.Remain = Lifelength.Null;
					if (data.LLPLifeLimit?.Hours != null)
						data.Remain.Hours = (int)(hours * (double)data.LLPLifeLimit.Hours);
					if (data.LLPLifeLimit?.Cycles != null)
						data.Remain.Cycles = (int)(cycles * (double)data.LLPLifeLimit.Cycles);
					if (data.LLPLifeLimit?.Days != null)
						data.Remain.Days = (int)(days * (double)data.LLPLifeLimit.Days);

					if(data.LLPLifeLimit != null)
						data.Remain.Resemble(data.LLPLifeLimit);
				}

			}

			return new Lifelength(res);
		}
		#endregion

		//AircraftFlights

		#region public double GetTotalHours(AircraftFlightCollection flights)

		public double GetTotalHours(AircraftFlightCollection flights)
		{
			return flights.Where(ItWasRealFlight)
						  .Sum(aircraftFlight => aircraftFlight.FlightTime.TotalHours);
		}

		#endregion

		#region public int GetTotalCycles(AircraftFlightCollection flights)

		public int GetTotalCycles(AircraftFlightCollection flights)
		{
			return (int) flights.Where(ItWasRealFlight)
						        .Sum(aircraftFlight => aircraftFlight.FlightTimeLifelength.Cycles);
		}

		#endregion

		#region private Lifelength getFlightLifelengthByPeriod(AircraftFlightCollection flights, BaseComponent bd, DateTime dateFrom, DateTime dateTo)

		/// <summary>
		/// возвращает наработку детали за указанный период, если есть соответствующие данные в полетах.
		/// <br/>
		/// Для Engine и APU наработка расчитывается по Runup-ам
		/// <br/>
		/// Для Propellers наработка насчитывается по RunUp-ам двигателей, имеющих туже позицию
		/// <br/> 
		/// Для Frame и LG наработка расчитывается по полетам, имеющим ATLBRecordType = Flight и CancelReason = "N/A"
		/// </summary>
		/// <param name="flights"></param>
		/// <param name="bd">Базовая деталь, для которой необходимо расчитать наработку</param>
		/// <param name="dateFrom">Начало интервала</param>
		/// <param name="dateTo">Конец интервала</param>
		/// <returns></returns>
		private Lifelength getFlightLifelengthByPeriod(AircraftFlightCollection flights, BaseComponent bd, DateTime dateFrom, DateTime dateTo)
		{
			var res = Lifelength.Zero;
			if (bd == null) return res;

			foreach (var flight in flights.Where(f => f.AtlbRecordType != AtlbRecordType.Maintenance))
			{
				if (flight.FlightDate.Date >= dateFrom && flight.FlightDate.Date <= dateTo)
				{
					if (bd.BaseComponentType == BaseComponentType.Apu)
					{
						var aircraft = _aircraftsCore.GetAircraftById(bd.ParentAircraftId);
						res.Add(new Lifelength(0, 1, (int?)(flight.FlightTimeLifelength.TotalMinutes * aircraft.APUFH)));
					}
					else res.Add(getFlightLifelength(flight, bd));
				}
			}
			return res;
		}
		#endregion

		#region private Lifelength getBlockLifelengthForPeriod(AircraftFlightCollection flights, BaseComponent bd, DateTime dateFrom, DateTime dateTo)

		private Lifelength getBlockLifelengthForPeriod(AircraftFlightCollection flights, BaseComponent bd, DateTime dateFrom, DateTime dateTo)
		{
			var res = Lifelength.Zero;
			if (bd == null) return res;

			foreach (var flight in flights)
			{
				if (flight.FlightDate.Date >= dateFrom && flight.FlightDate.Date <= dateTo)
				{
					//При расчете Блокнаработки для планера и шасси (Frame и LandingGear) учитываются только те записи в бортжурнале,
					//что были внесены для рейсов(НЕ ЯВЛЯЮТСЯ записями о произведении технического обслуживания),
					//и рейсы были НЕ ОТМЕНЕНЫ(CancelReason == null).

					//Если запись не является рейсом или рейс был отменен,
					//то его нельзя использовать для расчета Блокнаработки(времененного промежутка между In - Out) планера и шасси (Frame и LandingGear).

					//Так же Блокнаработка расчитывается для всех Базовых Агрегатов если рейс состоялся.

					//Так же Блокнаработка расчитывается для Engine, APU, Propeller вне зависимости от типа записи бортжурнала,
					//и вне зависимости от того состоялся рейс или нет.
					if (!ItWasRealFlight(flight) &&
						(bd.BaseComponentType == BaseComponentType.Frame || bd.BaseComponentType == BaseComponentType.LandingGear))
					{
						continue;
					}
					res.Add(flight.BlockTimeLifelenght);
				}
			}
			return res;
		}

		#endregion

		#region private Lifelength getFlightLifelengthForPeriod(AircraftFlightCollection flights, BaseComponent bd, DateTime dateFrom, DateTime dateTo, FlightRegime flightRegime)

		/// <summary>
		/// возвращает наработку детали за указанный период в указанном режиме, если есть соответствующие данные в полетах.
		/// <br/>
		/// Для Engine, Propellers и APU наработка расчитывается по Runup-ам
		/// </summary>
		/// <param name="flights">Коллекция полетов</param>
		/// <param name="bd">Базовый агрегат</param>
		/// <param name="dateFrom">Начало интервала</param>
		/// <param name="dateTo">Конец интервала</param>
		/// <param name="flightRegime">режим работы</param>
		/// <returns>наработка в заданном режиме или Lifelength.Zero</returns>
		/// <exception cref="ArgumentNullException">если базовая деталь равна null</exception>
		/// <exception cref="ArgumentNullException">если FlightRegime равен null</exception>
		/// <exception cref="ArgumentException">если FlightRegime равен Unknown</exception>
		private Lifelength getFlightLifelengthForPeriod(AircraftFlightCollection flights, BaseComponent bd, DateTime dateFrom, DateTime dateTo, FlightRegime flightRegime)
		{
			var res = Lifelength.Zero;
			if (bd == null)
				throw new ArgumentNullException(nameof(bd), "Can not be null");

			if (flightRegime == null)
				throw new ArgumentNullException(nameof(flightRegime), "Can not be null");
			if (flightRegime == FlightRegime.UNK)
				throw new ArgumentException("FlightRegime should not be Unknown", nameof(flightRegime));

			foreach (var flight in flights)
			{
				if (flight.FlightDate.Date >= dateFrom && flight.FlightDate.Date <= dateTo)
				{
					//полет попадает и интервал
					if ((bd.BaseComponentType == BaseComponentType.Engine || bd.BaseComponentType == BaseComponentType.Apu)
						&& flight.PowerUnitTimeInRegimeCollection.Count > 0)
					{
						//Если деталь является силовым агрегатом 
						//и в полете есть данные о работе силовых агрегатов в разл. режимах

						//1. Отыскать работу именно для этого силового агрегата в заданном режиме
						List<EngineTimeInRegime> pwts =
							flight.PowerUnitTimeInRegimeCollection.Where(r => r.BaseComponentId == bd.ItemId &&
																		 r.FlightRegime == flightRegime).ToList();
						//2. Суммировать наработку по пускам (если таковые есть)
						foreach (EngineTimeInRegime pwt in pwts)
							res.Add(LifelengthSubResource.Minutes, (int)pwt.TimeInRegime.TotalMinutes);
					}
					else if (bd.BaseComponentType == BaseComponentType.Propeller && flight.RunupsCollection.Count > 0)
					{
						List<EngineTimeInRegime> pwts =
							flight.PowerUnitTimeInRegimeCollection.Where(r => r.BaseComponent.BaseComponentType == BaseComponentType.Engine &&
																	r.FlightRegime == flightRegime &&
																	r.BaseComponent.Position.Trim() == bd.Position.Trim()).ToList();
						//2. Суммировать наработку по пускам (если таковые есть)
						foreach (EngineTimeInRegime pwt in pwts)
							res.Add(LifelengthSubResource.Minutes, (int)pwt.TimeInRegime.TotalMinutes);
					}
				}
			}
			return res;
		}
		#endregion

		#region internal bool ItWasRealFlight(AircraftFlight flight)

		internal bool ItWasRealFlight(AircraftFlight flight)
		{
			return flight.AtlbRecordType == AtlbRecordType.Flight && flight.CancelReason == null;
		}

		#endregion

		// Директивы 

		// Вспомогательные - которые могут пригодиться в интерфейсе

		/*
         * Калькуляция наработки для записей о выполнении задачи
         */

		#region public Lifelength GetFlightLifelengthOnEndOfDay(DirectiveRecord record)
		/// <summary>
		/// Получает наработку агрегата / воздушного судна на момент выполнения работы
		/// </summary>
		/// <param name="record"></param>
		/// <returns></returns>
		public Lifelength GetFlightLifelengthOnEndOfDay(DirectiveRecord record)
        {

            object parent = record.Parent;
            if (parent == null) throw new Exception($"1537: Performance record {record.RecordType} ({record.ItemId}:{record.ParentId}) referst to null object");

            //
            var date = record.RecordDate;

            // Обрабатываем объекты
            if (parent is ComponentDirective)
            {
                // Запись принадлежит работе по агрегату
                // Агрегат / Базовый агрегат
                var componentDirective = parent as ComponentDirective;
                if (componentDirective.ParentComponent.IsBaseComponent) return getFlightLifelengthOnEndOfDay((BaseComponent)componentDirective.ParentComponent, date);
                if (!componentDirective.ParentComponent.IsBaseComponent) return getFlightLifelengthOnEndOfDay(componentDirective.ParentComponent, date);
                throw new Exception($"1543: Can not get parent object for component directive {componentDirective.ItemId}");
            }
            if (parent is Directive)
            {
                var directive = parent as Directive;
                var bd = directive.ParentBaseComponent;
                if (bd == null) throw new Exception($"1550: Parent object for directive {directive.ItemId} is set to null");
                return getFlightLifelengthOnEndOfDay(bd, date);
            }
            if (parent is MaintenanceDirective)
            {
                var directive = parent as MaintenanceDirective;
                var a = directive.ParentBaseComponent;
                if (a == null) throw new Exception($"1550: Parent object for directive {directive.ItemId} is set to null");
                return getFlightLifelengthOnEndOfDay(a, date);
            }
            if (parent is Procedure)
            {
                var p = parent as Procedure;
                var op = p.ParentOperator;
                if (op == null) throw new Exception($"1550: Parent object for directive {p.ItemId} is set to null");
                return getFlightLifelengthOnEndOfDay(op, date);
            }
            throw new Exception($"1545: Can not recognize parent object {parent.GetType()} for record {record.RecordType} ({record.ItemId}:{record.ParentId})");
        }
		#endregion

		#region public Lifelength GetFlightLifelengthOnEndOfDay(TransferRecord record)
		/// <summary>
		/// Получает наработку агрегата / базового агрегата на момент его перемещения 
		/// </summary>
		/// <param name="record"></param>
		/// <returns></returns>
		public Lifelength GetFlightLifelengthOnEndOfDay(TransferRecord record)
        {
            if (record.ParentComponent != null)
            {
                return record.ParentComponent is BaseComponent
                           ? getFlightLifelengthOnEndOfDay((BaseComponent) record.ParentComponent, record.TransferDate)
                           : getFlightLifelengthOnEndOfDay(record.ParentComponent, record.TransferDate);
            }
            throw new Exception($"Transfer record {record.ItemId} for {record.ParentId} has no parent");
        }

		#endregion

		/*
         * Расчет выполнения задачи
         */

        /*
         * Реализация
         */

        #region private Boolean _MathLoaded;
        /// <summary>
        /// Загружены ли данные, необходимые для математичесского аппарата
        /// </summary>
        private Boolean _mathLoaded;
		#endregion

		/*
         * Обнуление данных
         */

		#region internal void ResetMath(BaseComponent baseComponent)
		/// <summary>
		/// Обнуляет математический аппарат для базового агрегата 
		/// </summary>
		/// <param name="baseComponent"></param>
		public void ResetMath(BaseComponent baseComponent)
        {
            if(baseComponent.LifelengthCalculated != null)
                baseComponent.LifelengthCalculated.Clear();
            else baseComponent.LifelengthCalculated = new LifelengthCollection(baseComponent.ManufactureDate);
        }
		#endregion

		#region public void ResetMath(Aircraft aircraft)

		/// <summary>
		/// Обнуляет математический аппарат воздушного судна
		/// </summary>
		/// <param name="aircraft"></param>
		public void ResetMath(Aircraft aircraft)
        {
            foreach (BaseComponent baseComponent in _componentCore.GetAicraftBaseComponents(aircraft.ItemId))
                ResetMath(baseComponent);
        }
        #endregion

        /*
         * Дополнительно
         */

        #region public bool IsEqual(double x,double y)
        /// <summary>
        /// Сравнивает два числа типа double с эпсилон равное 0.0001
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsEqual(double x, double y)
        {
            double eps = 0.0001;
            if (Math.Abs(x - y) < eps) return true;
            return false;
        }

        #endregion

        #region public static Int32 GetDays(DateTime dateFrom, DateTime dateTo)
        /// <summary>
        /// Возвращает количество дней между двумя датами 
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public static Int32 GetDays(DateTime dateFrom, DateTime dateTo)
        {
            return Convert.ToInt32((dateTo.Date.Ticks - dateFrom.Date.Ticks) / TimeSpan.TicksPerDay);
        }
        #endregion

        /*
         *  Maintenance
         */

		#region public void LoadCalculator()

		/// <summary>
		/// Загружает данные для математиеского аппарата
		/// </summary>
		public void LoadCalculator()
		{
			// для математического аппарата необходимо загрузить 
			// 1) полеты всех воздушных судов
			// 2) актуальные состояния базовых агрегатов
			// 3) данные о перемещениях transfer records 
			// 4) директивы базовых агрегатов

			// 1)
			//_aircraftFlightCore.LoadAllFlights();

			// 2) 
			_componentCore.LoadBaseComponentsActualStateRecords();

			// 3)
			_componentCore.LoadBaseComponentsTransferRecords();

			// 4) 
			_componentCore.LoadBaseComponentsDirectives();
		}

		#endregion

	}
}
