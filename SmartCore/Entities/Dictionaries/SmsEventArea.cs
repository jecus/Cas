using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    /// <summary>
    /// Описывает область события системы безопасности полетов
    /// </summary>
    public class SmsEventArea : StaticTreeDictionary
    {

        #region public new SmsEventArea Parent
        /// <summary>
        /// Родительский узел словаря
        /// </summary>
        public new SmsEventArea Parent
        {
            get { return _parent as SmsEventArea; }
        }
        #endregion

        #region public new SmsEventArea Prev
        /// <summary>
        /// Предыдущий элемент на уровне
        /// </summary>
        public new SmsEventArea Prev
        {
            get { return _prev as SmsEventArea; }
        }
        #endregion

        #region public new SmsEventArea Next
        /// <summary>
        /// Следующий элемент на уровне
        /// </summary>
        public new SmsEventArea Next
        {
            get { return _next as SmsEventArea; }
        }
        #endregion

        #region private static CommonDictionaryCollection<SmsEventArea> _Items = new CommonDictionaryCollection<SmsEventArea>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<SmsEventArea> _Items = new CommonDictionaryCollection<SmsEventArea>();
        
        #endregion

        #region private static CommonDictionaryCollection<SmsEventArea> _roots = new CommonDictionaryCollection<SmsEventArea>();
        /// <summary>
        /// Содержит корневые элементы
        /// </summary>
        private static CommonDictionaryCollection<SmsEventArea> _roots = new CommonDictionaryCollection<SmsEventArea>();

        #endregion

        /*
         * Предопределенные типы
         */

        #region public static SmsEventArea Maintenance = new SmsEventArea(12, "Maint.", "Maintenance", "MNT");
        /// <summary>
        /// Техническое обслуживание
        /// </summary>
        public static SmsEventArea Maintenance = new SmsEventArea(12, "Maint.", "Maintenance", "MNT");
        #endregion

        #region public static SmsEventArea MntWwDaR = new SmsEventArea(121, "Work with docs./recs.", "Work with documentation and records", "Docs and Records", Maintenance);
        /// <summary>
        /// Организация работы с документацией и архивами
        /// </summary>
        public static SmsEventArea MntWwDaR = new SmsEventArea(121, "Work with docs./recs.", "Work with documentation and records", "Docs and Records", Maintenance);
        #endregion

        #region Элементы пункта "Организация работы с документацией и архивами"

        #region public static SmsEventArea MntWwDaRTechLibLackUpd = new SmsEventArea(1211, "Lack of updates technical libraries materials", "Lack of updates technical libraries materials", "Lack of updates technical libraries materials", MntWwDaR);
        /// <summary>
        /// отсутствие обновления материалов технических библиотек
        /// </summary>
        public static SmsEventArea MntWwDaRTechLibLackUpd = new SmsEventArea(1211, "Lack of updates technical libraries materials", "Lack of updates technical libraries materials", "Lack of updates technical libraries materials", MntWwDaR);
        #endregion

        #region public static SmsEventArea MntWwDaRNonRegMntDefects = new SmsEventArea(1212, "Non-registr. of defects of mnt", "Non-registration of defects of maintenance and work performed", "Non-registration of defects of maintenance", MntWwDaR);
        /// <summary>
        /// отсутствие регистрации дефектов технического обслуживания и выполненной работы
        /// </summary>
        public static SmsEventArea MntWwDaRNonRegMntDefects = new SmsEventArea(1212, "Non-registr. of defects of mnt", "Non-registration of defects of maintenance and work performed", "Non-registration of defects of maintenance", MntWwDaR);
        #endregion

        #region public static SmsEventArea MntWwDaRLackOfLoggingDataMeasure = new SmsEventArea(1213, "Lack of logging data of control characteristics", "Lack of logging data of control characteristics", "Lack of logging data of control characteristics", MntWwDaR);
        /// <summary>
        /// отсутствие регистрации данных контроля характеристик и работы систем для анализа тенденций
        /// </summary>
        public static SmsEventArea MntWwDaRLackOfLoggingDataMeasure = new SmsEventArea(1213, "Lack of logging data of control characteristics", "Lack of logging data of control characteristics", "Lack of logging data of control characteristics", MntWwDaR);
        #endregion

        #region public static SmsEventArea MntWwDaRNotDocCorpGoals = new SmsEventArea(1214, "Not documented corporate goals", "Not documented corporate goals", "Not documented corporate goals", MntWwDaR);
        /// <summary>
        /// корпоративные цели, задачи и политика в области безопасности полетов документально не оформлены или нераспространены
        /// </summary>
        public static SmsEventArea MntWwDaRNotDocCorpGoals = new SmsEventArea(1214, "Not documented corporate goals", "Not documented corporate goals", "Not documented corporate goals", MntWwDaR);
        #endregion

        #region public static SmsEventArea MntWwDaRLackRegStaffTrain = new SmsEventArea(1215, "Lack of registration records of staff training", "Lack of registration records of staff training", "Lack of registration records of staff training", MntWwDaR);
        /// <summary>
        /// отсутствие регистрации записей о профессиональной подготовке персонала, аттестациях и сроках переподготовки
        /// </summary>
        public static SmsEventArea MntWwDaRLackRegStaffTrain = new SmsEventArea(1215, "Lack of registration records of staff training", "Lack of registration records of staff training", "Lack of registration records of staff training", MntWwDaR);
        #endregion

        #region public static SmsEventArea MntWwDaRLackOfRegForms = new SmsEventArea(1216, "Lack of registration forms for the units", "Lack of registration forms for the units", "Lack of registration forms for the units", MntWwDaR);
        /// <summary>
        /// отсутствие регистрации формуляров на агрегаты, данных о наработке 
        /// </summary>
        public static SmsEventArea MntWwDaRLackOfRegForms = new SmsEventArea(1216, "Lack of registration forms for the units", "Lack of registration forms for the units", "Lack of registration forms for the units", MntWwDaR);
        #endregion

        #endregion

        #region public static SmsEventArea MntErrInMnt = new SmsEventArea(122, "Err. in mnt.", "Errors in maintenance", "Errors in Maintenance", Maintenance);
        /// <summary>
        /// Ошибки в техническом обслуживании
        /// </summary>
        public static SmsEventArea MntErrInMnt = new SmsEventArea(122, "Err. in mnt.", "Errors in maintenance", "Errors in Maintenance", Maintenance);
        #endregion

        #region Элементы пункта "Ошибки в техническом обслуживании"

        #region public static SmsEventArea MntErrInMntReqInfo = new SmsEventArea(1221, "Req. info.", "Required information", "Required information", MntErrInMnt);
        /// <summary>
        /// требующаяся для производства работы информация
        /// </summary>
        public static SmsEventArea MntErrInMntReqInfo = new SmsEventArea(1221, "Req. info.", "Required information", "Required information", MntErrInMnt);
        #endregion

        #region Элементы пункта "Необходимая информация"

        #region public static SmsEventArea MntErrInMntReqInfoUnderstand = new SmsEventArea(12211, "Understand-y.", "Understandability", "Understandability", MntErrInMntReqInfo);
        /// <summary>
        /// Понятность требующейся для производства работы информации
        /// </summary>
        public static SmsEventArea MntErrInMntReqInfoUnderstand = new SmsEventArea(12211, "Understand-y.", "Understandability", "Understandability", MntErrInMntReqInfo);
        #endregion

        #region public static SmsEventArea MntErrInMntReqInfoIllustClarity = new SmsEventArea(12212, "Illust. Clar./Material. Compl.", "Clarity of illustration, Completeness of the material", "Clarity of illustration, Completeness of the material", MntErrInMntReqInfo);
        /// <summary>
        /// Ясность иллюстраций, полнота материала
        /// </summary>
        public static SmsEventArea MntErrInMntReqInfoIllustClarity = new SmsEventArea(12212, "Illust. Clar./Material. Compl.", "Clarity of illustration, Completeness of the material", "Clarity of illustration, Completeness of the material", MntErrInMntReqInfo);
        #endregion

        #region public static SmsEventArea MntErrInMntReqInfoAvailability = new SmsEventArea(12213, "Availability/Accessibility", "Availability and accessibility", "Availability and accessibility", MntErrInMntReqInfo);
        /// <summary>
        /// наличие и доступность
        /// </summary>
        public static SmsEventArea MntErrInMntReqInfoAvailability = new SmsEventArea(12213, "Availability/Accessibility", "Availability and accessibility", "Availability and accessibility", MntErrInMntReqInfo);
        #endregion

        #region public static SmsEventArea MntErrInMntReqInfoAccuracy = new SmsEventArea(12214, "Accuracy", "Accuracy, validity and compliance with the latest requirements", "Accuracy, validity", MntErrInMntReqInfo);
        /// <summary>
        /// точность, действительность и соответствие последним требованиям
        /// </summary>
        public static SmsEventArea MntErrInMntReqInfoAccuracy = new SmsEventArea(12214, "Accuracy", "Accuracy, validity and compliance with the latest requirements", "Accuracy, validity", MntErrInMntReqInfo);
        #endregion

        #region public static SmsEventArea MntErrInMntReqInfoAbsConfInterpr = new SmsEventArea(12215, "Absence confl. interpr.", "Absence of conflicting interpretations", "Absence of conflicting interpretations.", MntErrInMntReqInfo);
        /// <summary>
        /// отсутствие противоречивых толкований
        /// </summary>
        public static SmsEventArea MntErrInMntReqInfoAbsConfInterpr = new SmsEventArea(12215, "Absence confl. interpr.", "Absence of conflicting interpretations", "Absence of conflicting interpretations.", MntErrInMntReqInfo);
        #endregion

        #endregion

        #region public static SmsEventArea MntErrInMntReqTools = new SmsEventArea(1222, "Req. tools and equip.", "Required tools and equipment", "Tools and equipment", MntErrInMnt);
        /// <summary>
        /// требующиеся инструменты и оборудование;
        /// </summary>
        public static SmsEventArea MntErrInMntReqTools = new SmsEventArea(1222, "Req. tools and equip.", "Required tools and equipment", "Tools and equipment", MntErrInMnt);
        #endregion

        #region Элементы пункта "Требуемое оборудование"

        #region public static SmsEventArea MntErrInMntReqToolsInsecurity = new SmsEventArea(12221, "Insecurity", "Insecurity for maintenance engineers", "Insecurity", MntErrInMntReqTools);
        /// <summary>
        /// небезопасность для использования инженерами по техническому обслуживанию
        /// </summary>
        public static SmsEventArea MntErrInMntReqToolsInsecurity = new SmsEventArea(12221, "Insecurity", "Insecurity for maintenance engineers", "Insecurity", MntErrInMntReqTools);
        #endregion

        #region public static SmsEventArea MntErrInMntReqToolsFailure = new SmsEventArea(12222, "Failure", "Uncertainty, failure or deterioration", "Uncertainty/Failure/Deterioration", MntErrInMntReqTools);
        /// <summary>
        /// ненадежность, неисправность или изношенность
        /// </summary>
        public static SmsEventArea MntErrInMntReqToolsFailure = new SmsEventArea(12222, "Failure", "Uncertainty, failure or deterioration", "Uncertainty/Failure/Deterioration", MntErrInMntReqTools);
        #endregion

        #region public static SmsEventArea MntErrInMntReqToolsInconvenientLocation = new SmsEventArea(12223, "Inconvenient Location", "Inconvenient location of the controls or indicators", "Inconvenient Location", MntErrInMntReqTools);
        /// <summary>
        /// неудобное расположение элементов управления или индикаторов
        /// </summary>
        public static SmsEventArea MntErrInMntReqToolsInconvenientLocation = new SmsEventArea(12223, "Inconvenient Location", "Inconvenient location of the controls or indicators", "Inconvenient Location", MntErrInMntReqTools);
        #endregion

        #region public static SmsEventArea MntErrInMntReqToolsLackOfRegulation = new SmsEventArea(12224, "Lack of regulation", "lack of regulation or incorrect meter readings", "Lack of regulation", MntErrInMntReqTools);
        /// <summary>
        /// неотрегулированность или неправильные показания измерительных приборов
        /// </summary>
        public static SmsEventArea MntErrInMntReqToolsLackOfRegulation = new SmsEventArea(12224, "Lack of regulation", "lack of regulation or incorrect meter readings", "Lack of regulation", MntErrInMntReqTools);
        #endregion

        #region public static SmsEventArea MntErrInMntReqToolsUnfitness = new SmsEventArea(12225, "Unfitness", "Unfitness for work performed", "Unfitness for work performed", MntErrInMntReqTools);
        /// <summary>
        /// непригодность для выполняемых работ
        /// </summary>
        public static SmsEventArea MntErrInMntReqToolsUnfitness = new SmsEventArea(12225, "Unfitness", "Unfitness for work performed", "Unfitness for work performed", MntErrInMntReqTools);
        #endregion

        #region public static SmsEventArea MntErrInMntReqToolsUnavailable = new SmsEventArea(12226, "Unavailable", "Unavailable", "Unavailable", MntErrInMntReqTools);
        /// <summary>
        /// отсутствие в наличии
        /// </summary>
        public static SmsEventArea MntErrInMntReqToolsUnavailable = new SmsEventArea(12226, "Unavailable", "Unavailable", "Unavailable", MntErrInMntReqTools);
        #endregion

        #region public static SmsEventArea MntErrInMntReqToolsCantUseInCond = new SmsEventArea(12227, "Can not use", "Can not be used in these conditions", "Can not be used in these conditions", MntErrInMntReqTools);
        /// <summary>
        /// невозможность использования в данных условиях
        /// </summary>
        public static SmsEventArea MntErrInMntReqToolsCantUseInCond = new SmsEventArea(12227, "Can not use", "Can not be used in these conditions", "Can not be used in these conditions", MntErrInMntReqTools);
        #endregion

        #region public static SmsEventArea MntErrInMntReqToolsNoInstructions = new SmsEventArea(12228, "No Instructions", "No instructions for use", "No instructions for use", MntErrInMntReqTools);
        /// <summary>
        /// отсутствие инструкций по использованию
        /// </summary>
        public static SmsEventArea MntErrInMntReqToolsNoInstructions = new SmsEventArea(12228, "No Instructions", "No instructions for use", "No instructions for use", MntErrInMntReqTools);
        #endregion

        #region public static SmsEventArea MntErrInMntReqToolsExcessiveComplexity = new SmsEventArea(12229, "Excessive complexity", "the excessive complexity of use", "the excessive complexity of use", MntErrInMntReqTools);
        /// <summary>
        /// излишняя сложность в использовании.
        /// </summary>
        public static SmsEventArea MntErrInMntReqToolsExcessiveComplexity = new SmsEventArea(12229, "Excessive complexity", "the excessive complexity of use", "the excessive complexity of use", MntErrInMntReqTools);
        #endregion

        #endregion

        #region public static SmsEventArea MntErrInMntAcStcLim = new SmsEventArea(1223, "AC. struct. limits", "Structural limitations of aircraft", "AC Structural limitations", MntErrInMnt);
        /// <summary>
        /// конструктивные ограничения воздушного судна
        /// </summary>
        public static SmsEventArea MntErrInMntAcStcLim = new SmsEventArea(1223, "AC. struct. limits", "Structural limitations of aircraft", "AC Structural limitations", MntErrInMnt);
        #endregion

        #region Элементы пункта "Конструктивные ограничения"

        #region public static SmsEventArea MntErrInMntAcStcLimComplOfInstall = new SmsEventArea(12231, "The complexity of the installation", "The complexity of the installation or testing procedures", "The complexity of the installation or testing procedures", MntErrInMntAcStcLim);
        /// <summary>
        /// сложность установки или процедур испытаний
        /// </summary>
        public static SmsEventArea MntErrInMntAcStcLimComplOfInstall = new SmsEventArea(12231, "The complexity of the installation", "The complexity of the installation or testing procedures", "The complexity of the installation or testing procedures", MntErrInMntAcStcLim);
        #endregion

        #region public static SmsEventArea MntErrInMntAcStcLimSizeOrWeight = new SmsEventArea(12232, "Size or weight", "Size or weight of the unit;", "Size or weight of the unit;", MntErrInMntAcStcLim);
        /// <summary>
        /// размеры или вес агрегата
        /// </summary>
        public static SmsEventArea MntErrInMntAcStcLimSizeOrWeight = new SmsEventArea(12232, "Size or weight", "Size or weight of the unit;", "Size or weight of the unit;", MntErrInMntAcStcLim);
        #endregion

        #region public static SmsEventArea MntErrInMntAcStcLimLackOfAccess = new SmsEventArea(12233, "Lack of access", "Lack of access", "Lack of access", MntErrInMntAcStcLim);
        /// <summary>
        /// затрудненный доступ
        /// </summary>
        public static SmsEventArea MntErrInMntAcStcLimLackOfAccess = new SmsEventArea(12233, "Lack of access", "Lack of access", "Lack of access", MntErrInMntAcStcLim);
        #endregion

        #region public static SmsEventArea MntErrInMntAcStcLimChangingTheConfig = new SmsEventArea(12234, "Changing the configuration", "Changing the configuration", "Changing the configuration", MntErrInMntAcStcLim);
        /// <summary>
        /// изменяющиеся конфигурации
        /// </summary>
        public static SmsEventArea MntErrInMntAcStcLimChangingTheConfig = new SmsEventArea(12234, "Changing the configuration", "Changing the configuration", "Changing the configuration", MntErrInMntAcStcLim);
        #endregion

        #region public static SmsEventArea MntErrInMntAcStcLimIncorrectLabeling = new SmsEventArea(12235, "Incorrect labeling", "Lack of or incorrect labeling of parts and components", "Lack of or incorrect labeling of parts and components", MntErrInMntAcStcLim);
        /// <summary>
        /// отсутствие или неправильная маркировка деталей и узлов
        /// </summary>
        public static SmsEventArea MntErrInMntAcStcLimIncorrectLabeling = new SmsEventArea(12235, "Incorrect labeling", "Lack of or incorrect labeling of parts and components", "Lack of or incorrect labeling of parts and components", MntErrInMntAcStcLim);
        #endregion

        #region public static SmsEventArea MntErrInMntAcStcLimHighRiskOfIncorrectInstall = new SmsEventArea(12236, "High risk of incorrect installation", "High risk of incorrect installation", "High risk of incorrect installation", MntErrInMntAcStcLim);
        /// <summary>
        /// большая вероятность неправильной установки
        /// </summary>
        public static SmsEventArea MntErrInMntAcStcLimHighRiskOfIncorrectInstall = new SmsEventArea(12236, "High risk of incorrect installation", "High risk of incorrect installation", "High risk of incorrect installation", MntErrInMntAcStcLim);
        #endregion

        #endregion

        #region public static SmsEventArea MntErrInMntReqsOfWork = new SmsEventArea(1224, "Work or task req-s", "Work or task requiments", "Work or task requiments", MntErrInMnt);
        /// <summary>
        /// требования работы или задания
        /// </summary>
        public static SmsEventArea MntErrInMntReqsOfWork = new SmsEventArea(1224, "Work or task req-s", "Work or task requiments", "Work or task requiments", MntErrInMnt);
        #endregion

        #region Элементы пункта "Требования работы или задания"

        #region public static SmsEventArea MntErrInMntReqsOfWorkMonotonousOps = new SmsEventArea(12241, "Repetitive or monotonous operations", "Repetitive or monotonous operations", "Repetitive or monotonous operations", MntErrInMntReqsOfWork);
        /// <summary>
        /// повторяющиеся или монотонные операции
        /// </summary>
        public static SmsEventArea MntErrInMntReqsOfWorkMonotonousOps = new SmsEventArea(12241, "Repetitive or monotonous operations", "Repetitive or monotonous operations", "Repetitive or monotonous operations", MntErrInMntReqsOfWork);
        #endregion

        #region public static SmsEventArea MntErrInMntReqsOfWorkDifficultTask = new SmsEventArea(12242, "Difficult or incomprehensible task", "Difficult or incomprehensible task", "Difficult or incomprehensible task", MntErrInMntReqsOfWork);
        /// <summary>
        /// сложное или непонятное задание
        /// </summary>
        public static SmsEventArea MntErrInMntReqsOfWorkDifficultTask = new SmsEventArea(12242, "Difficult or incomprehensible task", "Difficult or incomprehensible task", "Difficult or incomprehensible task", MntErrInMntReqsOfWork);
        #endregion

        #region public static SmsEventArea MntErrInMntReqsOfWorkNewOrModifiedTask = new SmsEventArea(12243, "New or modified job", "New or modified job", "New or modified job", MntErrInMntReqsOfWork);
        /// <summary>
        /// новое или измененное задание
        /// </summary>
        public static SmsEventArea MntErrInMntReqsOfWorkNewOrModifiedTask = new SmsEventArea(12243, "New or modified job", "New or modified job", "New or modified job", MntErrInMntReqsOfWork);
        #endregion

        #region public static SmsEventArea MntErrInMntReqsOfWorkPerfTaskWhenChangAircraft = new SmsEventArea(12244, "Perform task when changing aircraft model", "The need to perform different tasks or procedures when changing model aircraft or the work area", "Perform task when changing aircraft model", MntErrInMntReqsOfWork);
        /// <summary>
        /// необходимость выполнения разных задач или процедур при изменении моделей воздушных судов
        /// </summary>
        public static SmsEventArea MntErrInMntReqsOfWorkPerfTaskWhenChangAircraft = new SmsEventArea(12244, "Perform task when changing aircraft model", "The need to perform different tasks or procedures when changing model aircraft or the work area", "Perform task when changing aircraft model", MntErrInMntReqsOfWork);
        #endregion

        #endregion

        #region public static SmsEventArea MntErrInMntReqsOfKnowl = new SmsEventArea(1225, "Reqs. of knowl.", "Requirements for technical knowledge or skills", "Knowledge or skills", MntErrInMnt);
        /// <summary>
        /// Технические знания/навыки
        /// </summary>
        public static SmsEventArea MntErrInMntReqsOfKnowl = new SmsEventArea(1225, "Reqs. of knowl.", "Requirements for technical knowledge or skills", "Knowledge or skills", MntErrInMnt);
        #endregion 

        #region Элементы пункта "Технические знания/навыки"

        #region public static SmsEventArea MntErrInMntReqsOfKnowlSkillsShortage = new SmsEventArea(12251, "Skills shortage", "Skills shortage, problems with memory elements tasks", "Skills shortage, problems with memory elements tasks", MntErrInMntReqsOfKnowl);
        /// <summary>
        /// нехватка навыков, несмотря на пройденную подготовку
        /// </summary>
        public static SmsEventArea MntErrInMntReqsOfKnowlSkillsShortage = new SmsEventArea(12251, "Skills shortage", "Skills shortage, problems with memory elements tasks", "Skills shortage, problems with memory elements tasks", MntErrInMntReqsOfKnowl);
        #endregion 

        #region public static SmsEventArea MntErrInMntReqsOfKnowlKnowlShortage = new SmsEventArea(12252, "Knowledge shortage", "Shortage of required knowledge due to lack of training or practice", "Shortage of required knowledge due to lack of training or practice", MntErrInMntReqsOfKnowl);
        /// <summary>
        /// нехватка требующихся знаний вследствие недостаточной подготовки или практики
        /// </summary>
        public static SmsEventArea MntErrInMntReqsOfKnowlKnowlShortage = new SmsEventArea(12252, "Knowledge shortage", "Shortage of required knowledge due to lack of training or practice", "Shortage of required knowledge due to lack of training or practice", MntErrInMntReqsOfKnowl);
        #endregion 

        #region public static SmsEventArea MntErrInMntReqsOfKnowlPoorPlaning = new SmsEventArea(12253, "Poor planning of the job", "Poor planning of the job", "Poor planning of the job", MntErrInMntReqsOfKnowl);
        /// <summary>
        /// неэффективное планирование выполнения задания
        /// </summary>
        public static SmsEventArea MntErrInMntReqsOfKnowlPoorPlaning = new SmsEventArea(12253, "Poor planning of the job", "Poor planning of the job", "Poor planning of the job", MntErrInMntReqsOfKnowl);
        #endregion 

        #region public static SmsEventArea MntErrInMntReqsOfKnowInsufficientKnowlOfTheProc = new SmsEventArea(12254, "Insufficient knowledge of the processes", "Insufficient knowledge of the processes used by the operator", "Insufficient knowledge of the processes used by the operator", MntErrInMntReqsOfKnowl);
        /// <summary>
        /// недостаточное знание используемых эксплуатантом процессов
        /// </summary>
        public static SmsEventArea MntErrInMntReqsOfKnowInsufficientKnowlOfTheProc = new SmsEventArea(12254, "Insufficient knowledge of the processes", "Insufficient knowledge of the processes used by the operator", "Insufficient knowledge of the processes used by the operator", MntErrInMntReqsOfKnowl);
        #endregion 

        #region public static SmsEventArea MntErrInMntReqsOfKnowlInsufficientKnowlOfAircraftSystems = new SmsEventArea(12255, "Insufficient knowledge of aircraft systems", "Insufficient knowledge of aircraft systems", "Insufficient knowledge of aircraft systems", MntErrInMntReqsOfKnowl);
        /// <summary>
        /// недостаточное знание систем воздушного судна
        /// </summary>
        public static SmsEventArea MntErrInMntReqsOfKnowlInsufficientKnowlOfAircraftSystems = new SmsEventArea(12255, "Insufficient knowledge of aircraft systems", "Insufficient knowledge of aircraft systems", "Insufficient knowledge of aircraft systems", MntErrInMntReqsOfKnowl);
        #endregion 

        #endregion

        #region public static SmsEventArea MntErrInMntFactAffPerf = new SmsEventArea(1226, "Fact. affect the perf.", "The factors affecting the efficiency of the worker", "Factors affect the performance", MntErrInMnt);
        /// <summary>
        /// факторы, влияющие на работоспособность отдельного работника
        /// </summary>
        public static SmsEventArea MntErrInMntFactAffPerf = new SmsEventArea(1226, "Fact. affect the perf.", "The factors affecting the efficiency of the worker", "Factors affect the performance", MntErrInMnt);
        #endregion

        #region Элементы пункта "факторы, влияющие на работоспособность отдельного работника"

        #region public static SmsEventArea MntErrInMntFactAffPerfPhysCond = new SmsEventArea(12261, "Physical condition", "Physical condition, previous illness or injury", "Physical condition, previous illness or injury", MntErrInMntFactAffPerf);
        /// <summary>
        /// физическое состояние, прежние болезни или травмы
        /// </summary>
        public static SmsEventArea MntErrInMntFactAffPerfPhysCond = new SmsEventArea(12261, "Physical condition", "Physical condition, previous illness or injury", "Physical condition, previous illness or injury", MntErrInMntFactAffPerf);
        #endregion

        #region public static SmsEventArea MntErrInMntFactAffPerfFatigue = new SmsEventArea(12262, "Fatigue", "Fatigue due to saturation of the job", "Fatigue due to saturation of the job", MntErrInMntFactAffPerf);
        /// <summary>
        /// усталость вследствие насыщенности задания
        /// </summary>
        public static SmsEventArea MntErrInMntFactAffPerfFatigue = new SmsEventArea(12262, "Fatigue", "Fatigue due to saturation of the job", "Fatigue due to saturation of the job", MntErrInMntFactAffPerf);
        #endregion

        #region public static SmsEventArea MntErrInMntFactAffPerfLackOfTime = new SmsEventArea(12263, "Lack of time", "Lack of time due to the intensity of the work", "Lack of time due to the intensity of the work", MntErrInMntFactAffPerf);
        /// <summary>
        /// нехватка времени вследствие интенсивности работы
        /// </summary>
        public static SmsEventArea MntErrInMntFactAffPerfLackOfTime = new SmsEventArea(12263, "Lack of time", "Lack of time due to the intensity of the work", "Lack of time due to the intensity of the work", MntErrInMntFactAffPerf);
        #endregion

        #region public static SmsEventArea MntErrInMntFactAffPerfPressFromColleagues = new SmsEventArea(12264, "Pressure from his colleague", "Pressure from his colleague", "Pressure from his colleague", MntErrInMntFactAffPerf);
        /// <summary>
        /// давление со стороны сослуживцев
        /// </summary>
        public static SmsEventArea MntErrInMntFactAffPerfPressFromColleagues = new SmsEventArea(12264, "Pressure from his colleague", "Pressure from his colleague", "Pressure from his colleague", MntErrInMntFactAffPerf);
        #endregion

        #region public static SmsEventArea MntErrInMntFactAffPerfExcSelfConfidence = new SmsEventArea(12265, "Self-complacency, excessive self-confidence", "Self-complacency, excessive self-confidence", "Self-complacency, excessive self-confidence", MntErrInMntFactAffPerf);
        /// <summary>
        /// самоуспокоенность, опасное чувство непогрешимости или излишней самоуверенности
        /// </summary>
        public static SmsEventArea MntErrInMntFactAffPerfExcSelfConfidence = new SmsEventArea(12265, "Self-complacency, excessive self-confidence", "Self-complacency, excessive self-confidence", "Self-complacency, excessive self-confidence", MntErrInMntFactAffPerf);
        #endregion

        #region public static SmsEventArea MntErrInMntFactAffPerfBodySizeOrPhysStrength = new SmsEventArea(12266, "Body size or physical strength", "Body size or physical strength", "Body size or physical strength", MntErrInMntFactAffPerf);
        /// <summary>
        /// размеры тела или физическая сила
        /// </summary>
        public static SmsEventArea MntErrInMntFactAffPerfBodySizeOrPhysStrength = new SmsEventArea(12266, "Body size or physical strength", "Body size or physical strength", "Body size or physical strength", MntErrInMntFactAffPerf);
        #endregion

        #region public static SmsEventArea MntErrInMntFactAffPerfPersonalEvents = new SmsEventArea(12267, "Events of a personal nature", "Events of a personal nature", "Events of a personal nature", MntErrInMntFactAffPerf);
        /// <summary>
        /// события личного характера
        /// </summary>
        public static SmsEventArea MntErrInMntFactAffPerfPersonalEvents = new SmsEventArea(12267, "Events of a personal nature", "Events of a personal nature", "Events of a personal nature", MntErrInMntFactAffPerf);
        #endregion

        #region public static SmsEventArea MntErrInMntFactAffPerfDistractionsInTheWorkplace = new SmsEventArea(12268, "Distractions in the workplace", "Distractions in the workplace", "Distractions in the workplace", MntErrInMntFactAffPerf);
        /// <summary>
        /// отвлекающие факторы на рабочем месте
        /// </summary>
        public static SmsEventArea MntErrInMntFactAffPerfDistractionsInTheWorkplace = new SmsEventArea(12268, "Distractions in the workplace", "Distractions in the workplace", "Distractions in the workplace", MntErrInMntFactAffPerf);
        #endregion

        #endregion

        #region public static SmsEventArea MntErrInMntFactEnv = new SmsEventArea(1227, "Fact. of env./workpl.", "Factors of environmental or workplace", "Environmental factors", MntErrInMnt);
        /// <summary>
        /// Окружающая среда/условия работы
        /// </summary>
        public static SmsEventArea MntErrInMntFactEnv = new SmsEventArea(1227, "Fact. of env./workpl.", "Factors of environmental or workplace", "Environmental factors", MntErrInMnt);
        #endregion

        #region Элементы пункта "Окружающая среда/условия работы"

        #region public static SmsEventArea MntErrInMntFactEnvLoudNoise = new SmsEventArea(12271, "Loud noise", "Loud noise", "Loud noise", MntErrInMntFactEnv);
        /// <summary>
        /// сильный шум
        /// </summary>
        public static SmsEventArea MntErrInMntFactEnvLoudNoise = new SmsEventArea(12271, "Loud noise", "Loud noise", "Loud noise", MntErrInMntFactEnv);
        #endregion

        #region public static SmsEventArea MntErrInMntFactEnvHighTempt = new SmsEventArea(12272, "High temperature", "High temperature", "High temperature", MntErrInMntFactEnv);
        /// <summary>
        /// высокая температура
        /// </summary>
        public static SmsEventArea MntErrInMntFactEnvHighTempt = new SmsEventArea(12272, "High temperature", "High temperature", "High temperature", MntErrInMntFactEnv);
        #endregion

        #region public static SmsEventArea MntErrInMntFactEnvLowTempt = new SmsEventArea(12273, "Low temperature", "Long periods of low temperature", "Long periods of low temperature", MntErrInMntFactEnv);
        /// <summary>
        /// длительные периоды низкой температуры
        /// </summary>
        public static SmsEventArea MntErrInMntFactEnvLowTempt = new SmsEventArea(12273, "Low temperature", "Long periods of low temperature", "Long periods of low temperature", MntErrInMntFactEnv);
        #endregion

        #region public static SmsEventArea MntErrInMntFactEnvMoistOrRain = new SmsEventArea(12274, "Moisture or rain", "Moisture or rain", "Moisture or rain", MntErrInMntFactEnv);
        /// <summary>
        /// влага или дождь
        /// </summary>
        public static SmsEventArea MntErrInMntFactEnvMoistOrRain = new SmsEventArea(12274, "Moisture or rain", "Moisture or rain", "Moisture or rain", MntErrInMntFactEnv);
        #endregion

        #region public static SmsEventArea MntErrInMntFactEnvPrecipication = new SmsEventArea(12275, "Precipication", "Precipitation deteriorating visibility or make it necessary to wear special volume clothes ", "Precipitation", MntErrInMntFactEnv);
        /// <summary>
        /// осадки, ухудшающие видимость или вызывающие необходимость ношения специальной объемной одежды
        /// </summary>
        public static SmsEventArea MntErrInMntFactEnvPrecipication = new SmsEventArea(12275, "Precipication", "Precipitation deteriorating visibility or make it necessary to wear special volume clothes ", "Precipitation", MntErrInMntFactEnv);
        #endregion

        #region public static SmsEventArea MntErrInMntFactEnvPoorLighting = new SmsEventArea(12276, "Poor lighting", "Poor lighting, lack of reading the instructions and labels, visual or performing the task", "Poor lighting", MntErrInMntFactEnv);
        /// <summary>
        /// плохая освещенность
        /// </summary>
        public static SmsEventArea MntErrInMntFactEnvPoorLighting = new SmsEventArea(12276, "Poor lighting", "Poor lighting, lack of reading the instructions and labels, visual or performing the task", "Poor lighting", MntErrInMntFactEnv);
        #endregion

        #region public static SmsEventArea MntErrInMntFactEnvStrongWind = new SmsEventArea(12277, "Strong wind", "Strong wind, making communication difficult, irritating the eyes, ears, nose, and throat", "Strong wind", MntErrInMntFactEnv);
        /// <summary>
        /// сильный ветер, затрудняющий общение, раздражающий глаза, уши, нос и глотку
        /// </summary>
        public static SmsEventArea MntErrInMntFactEnvStrongWind = new SmsEventArea(12277, "Strong wind", "Strong wind, making communication difficult, irritating the eyes, ears, nose, and throat", "Strong wind", MntErrInMntFactEnv);
        #endregion

        #region public static SmsEventArea MntErrInMntFactEnvVibration = new SmsEventArea(12278, "Vibration", "Vibration, difficult to read instruments and causing fatigue in his hands", "Vibration", MntErrInMntFactEnv);
        /// <summary>
        /// вибрация, затрудняющая считывание показаний приборов и вызывающая усталость в руках
        /// </summary>
        public static SmsEventArea MntErrInMntFactEnvVibration = new SmsEventArea(12278, "Vibration", "Vibration, difficult to read instruments and causing fatigue in his hands", "Vibration", MntErrInMntFactEnv);
        #endregion

        #region public static SmsEventArea MntErrInMntFactEnvDirt = new SmsEventArea(12279, "Dirt", "Dirt", "Dirt", MntErrInMntFactEnv);
        /// <summary>
        /// загрязненность, затрудняющая визуальный осмотр, делающая поверхности скользкими или ограничивающая имеющееся рабочее пространство
        /// </summary>
        public static SmsEventArea MntErrInMntFactEnvDirt = new SmsEventArea(12279, "Dirt", "Dirt", "Dirt", MntErrInMntFactEnv);
        #endregion

        #region public static SmsEventArea MntErrInMntFactEnvToxicSubstances = new SmsEventArea(122710, "Hazardous or toxic substances", "Hazardous or toxic substances", "Hazardous or toxic substances", MntErrInMntFactEnv);
        /// <summary>
        /// опасные или токсичные вещества
        /// </summary>
        public static SmsEventArea MntErrInMntFactEnvToxicSubstances = new SmsEventArea(122710, "Hazardous or toxic substances", "Hazardous or toxic substances", "Hazardous or toxic substances", MntErrInMntFactEnv);
        #endregion

        #region public static SmsEventArea MntErrInMntFactEnvInsuffSourOfSuppl = new SmsEventArea(122711, "Insufficient sources of electric power", "Insufficient or insufficiently labeled sources of electric power", "Insufficient sources of electric power", MntErrInMntFactEnv);
        /// <summary>
        /// недостаточно защищенные или недостаточно маркированные источники электропитания
        /// </summary>
        public static SmsEventArea MntErrInMntFactEnvInsuffSourOfSuppl = new SmsEventArea(122711, "Insufficient sources of electric power", "Insufficient or insufficiently labeled sources of electric power", "Insufficient sources of electric power", MntErrInMntFactEnv);
        #endregion

        #region public static SmsEventArea MntErrInMntFactEnvIneffectVent = new SmsEventArea(122712, "Ineffective ventilation", "Ineffective ventilation", "Ineffective ventilation", MntErrInMntFactEnv);
        /// <summary>
        /// неэффективная вентиляция, вызывающая дискомфорт или усталость
        /// </summary>
        public static SmsEventArea MntErrInMntFactEnvIneffectVent = new SmsEventArea(122712, "Ineffective ventilation", "Ineffective ventilation", "Ineffective ventilation", MntErrInMntFactEnv);
        #endregion

        #region public static SmsEventArea MntErrInMntFactEnvInefficOrgWorkpl = new SmsEventArea(122713, "Inefficiently organized workplace", "Crowded or inefficiently organized workplace", "Inefficiently organized workplace", MntErrInMntFactEnv);
        /// <summary>
        /// многолюдное или неэффективно организованное рабочее место
        /// </summary>
        public static SmsEventArea MntErrInMntFactEnvInefficOrgWorkpl = new SmsEventArea(122713, "Inefficiently organized workplace", "Crowded or inefficiently organized workplace", "Inefficiently organized workplace", MntErrInMntFactEnv);
        #endregion

        #endregion

        #region public static SmsEventArea MntErrInMntFactOrg = new SmsEventArea(1228, "Org. factors", "Organization factors", "Organizationsl factors", MntErrInMnt);
        /// <summary>
        /// организационные факторы, например, обстановка в организации
        /// </summary>
        public static SmsEventArea MntErrInMntFactOrg = new SmsEventArea(1228, "Org. factors", "Organization factors", "Organizationsl factors", MntErrInMnt);
        #endregion

        #region Элементы пункта "организационные факторы"

        #region public static SmsEventArea MntErrInMntFactOrgSupportQual = new SmsEventArea(12281, "Support quality", "Quality of the technical support organization", "Support quality", MntErrInMntFactOrg);
        /// <summary>
        /// качество поддержки со стороны технических организаций
        /// </summary>
        public static SmsEventArea MntErrInMntFactOrgSupportQual = new SmsEventArea(12281, "Support quality", "Quality of the technical support organization", "Support quality", MntErrInMntFactOrg);
        #endregion

        #region public static SmsEventArea MntErrInMntFactOrgCompnInconsPolicy = new SmsEventArea(12282, "Inconsistent policies of the company", "Unfairly or inconsistently applied policy of the company", "Inconsistent policies of the company", MntErrInMntFactOrg);
        /// <summary>
        /// несправедливо или непоследовательно применяемая политика компании
        /// </summary>
        public static SmsEventArea MntErrInMntFactOrgCompnInconsPolicy = new SmsEventArea(12282, "Inconsistent policies of the company", "Unfairly or inconsistently applied policy of the company", "Inconsistent policies of the company", MntErrInMntFactOrg);
        #endregion

        #region public static SmsEventArea MntErrInMntFactOrgIncorrectBusinessProc = new SmsEventArea(12283, "Incorrect business processes", "Company's business processes, inadequate inspections, outdated regulations", "Incorrect business processes", MntErrInMntFactOrg);
        /// <summary>
        /// действующие в компании рабочие процессы
        /// </summary>
        public static SmsEventArea MntErrInMntFactOrgIncorrectBusinessProc = new SmsEventArea(12283, "Incorrect business processes", "Company's business processes, inadequate inspections, outdated regulations", "Incorrect business processes", MntErrInMntFactOrg);
        #endregion

        #region public static SmsEventArea MntErrInMntFactOrgTradeUnionAct = new SmsEventArea(12284, "Trade union activities", "Trade union activities, which becomes a distraction", "Trade union activities", MntErrInMntFactOrg);
        /// <summary>
        /// профсоюзная деятельность, которая становится отвлекающим фактором
        /// </summary>
        public static SmsEventArea MntErrInMntFactOrgTradeUnionAct = new SmsEventArea(12284, "Trade union activities", "Trade union activities, which becomes a distraction", "Trade union activities", MntErrInMntFactOrg);
        #endregion

        #region public static SmsEventArea MntErrInMntFactOrgCorporateChanges = new SmsEventArea(12285, "Corporate changes", "Corporate changes", "Corporate changes", MntErrInMntFactOrg);
        /// <summary>
        /// корпоративные изменения
        /// </summary>
        public static SmsEventArea MntErrInMntFactOrgCorporateChanges = new SmsEventArea(12285, "Corporate changes", "Corporate changes", "Corporate changes", MntErrInMntFactOrg);
        #endregion

        #endregion

        #region public static SmsEventArea MntErrInMntMngt = new SmsEventArea(1229, "Mngt. and Suprvsn.", "Management and Supervision", "Management and Supervision", MntErrInMnt);
        /// <summary>
        /// руководство и надзор
        /// </summary>
        public static SmsEventArea MntErrInMntMngt = new SmsEventArea(1229, "Mngt. and Suprvsn.", "Management and Supervision", "Management and Supervision", MntErrInMnt);
        #endregion

        #region Элементы пункта "руководство и надзор"

        #region public static SmsEventArea MntErrInMntMngtInaccurSchedul = new SmsEventArea(12291, "Inaccurate scheduling", "Providing little guidance planning and organization of work", "Inaccurate scheduling", MntErrInMntMngt);
        /// <summary>
        /// недостаточно четкое планирование или организация работ,
        /// </summary>
        public static SmsEventArea MntErrInMntMngtInaccurSchedul = new SmsEventArea(12291, "Inaccurate scheduling", "Providing little guidance planning and organization of work", "Inaccurate scheduling", MntErrInMntMngt);
        #endregion

        #region public static SmsEventArea MntErrInMntMngtInaccurPriority = new SmsEventArea(12292, "Inaccurate prioritization", "Providing little guidance prioritization of work", "Inaccurate prioritization", MntErrInMntMngt);
        /// <summary>
        /// недостаточно четкое определение очередности работ
        /// </summary>
        public static SmsEventArea MntErrInMntMngtInaccurPriority = new SmsEventArea(12292, "Inaccurate prioritization", "Providing little guidance prioritization of work", "Inaccurate prioritization", MntErrInMntMngt);
        #endregion

        #region public static SmsEventArea MntErrInMntMngtInaccurDelegOfAuth = new SmsEventArea(12293, "Inaccurate deleg. of auth-ty.", "Providing little guidance delegation of authority and division of task", "Inaccurate deleg. of auth-ty.", MntErrInMntMngt);
        /// <summary>
        /// недостаточно четкое делегирование полномочий или распределение заданий
        /// </summary>
        public static SmsEventArea MntErrInMntMngtInaccurDelegOfAuth = new SmsEventArea(12293, "Inaccurate deleg. of auth-ty.", "Providing little guidance delegation of authority and division of task", "Inaccurate deleg. of auth-ty.", MntErrInMntMngt);
        #endregion

        #region public static SmsEventArea MntErrInMntMngtUnrealExpectations = new SmsEventArea(12294, "Unreal. expect-ns.", "Divorced from the life sentiment or expectation", "Unrealistic expectations", MntErrInMntMngt);
        /// <summary>
        /// оторванные от жизни настроения или ожидания,
        /// </summary>
        public static SmsEventArea MntErrInMntMngtUnrealExpectations = new SmsEventArea(12294, "Unreal. expect-ns.", "Divorced from the life sentiment or expectation", "Unrealistic expectations", MntErrInMntMngt);
        #endregion

        #region public static SmsEventArea MntErrInMntMngtHardMngt = new SmsEventArea(12295, "Too hard mngt. style", "Too hard or inappropriate management style", "Too hard management style", MntErrInMntMngt);
        /// <summary>
        /// излишне жесткий или неуместный стиль руководства
        /// </summary>
        public static SmsEventArea MntErrInMntMngtHardMngt = new SmsEventArea(12295, "Too hard mngt. style", "Too hard or inappropriate management style", "Too hard management style", MntErrInMntMngt);
        #endregion

        #region public static SmsEventArea MntErrInMntMngtFreqOrAimlessMeetings = new SmsEventArea(12296, "Freq. or aimless meetings", "Frequent or aimless meetings", "Frequent or aimless meetings", MntErrInMntMngt);
        /// <summary>
        /// частые или бесцельные совещания
        /// </summary>
        public static SmsEventArea MntErrInMntMngtFreqOrAimlessMeetings = new SmsEventArea(12296, "Freq. or aimless meetings", "Frequent or aimless meetings", "Frequent or aimless meetings", MntErrInMntMngt);
        #endregion

        #endregion

        #endregion

        #region public static SmsEventArea MntOrgFact = new SmsEventArea(123, "Org. factors", "Organizational factors", "Org. factors", Maintenance);
        /// <summary>
        /// Организационные факторы
        /// </summary>
        public static SmsEventArea MntOrgFact = new SmsEventArea(123, "Org. factors", "Organizational factors", "Org. factors", Maintenance);
        #endregion

        #region Элементы пункта "Организационные факторы"

        #region public static SmsEventArea MntOrgFactLackOfTime = new SmsEventArea(1231, "Lack of time", "Lack of time", "Lack of time", MntOrgFact);
        /// <summary>
        /// нехватка времени, вызванная необходимостью отправки воздушных судов по расписанию
        /// </summary>
        public static SmsEventArea MntOrgFactLackOfTime = new SmsEventArea(1231, "Lack of time", "Lack of time", "Lack of time", MntOrgFact);
        #endregion

        #region public static SmsEventArea MntOrgFactAircraftLargeBloom = new SmsEventArea(1232, "Aircr. with large bloom", "Aircraft with a large bloom, requiring thorough inspection", "Aircraft with large bloom", MntOrgFact);
        /// <summary>
        /// воздушные суда с большим налетом, требующие тщательного осмотра для выявления усталостных дефектов
        /// </summary>
        public static SmsEventArea MntOrgFactAircraftLargeBloom = new SmsEventArea(1232, "Aircr. with large bloom", "Aircraft with a large bloom, requiring thorough inspection", "Aircraft with large bloom", MntOrgFact);
        #endregion

        #region public static SmsEventArea MntOrgFactNewTechReqNewTools = new SmsEventArea(1233, "New technique, which requires new tools", "New technique, which requires the use of new tools", "New technique, which requires new tools", MntOrgFact);
        /// <summary>
        /// новая техника, требующая использования новых инструментов
        /// </summary>
        public static SmsEventArea MntOrgFactNewTechReqNewTools = new SmsEventArea(1233, "New technique, which requires new tools", "New technique, which requires the use of new tools", "New technique, which requires new tools", MntOrgFact);
        #endregion

        #region public static SmsEventArea MntOrgFactDesireToFixDefect = new SmsEventArea(1234, "Desire to 'fix' the defect", "Desire to 'fix' the defect and send the aircraft on schedule", "Desire to 'fix' the defect", MntOrgFact);
        /// <summary>
        /// стремление "исправить" дефект и отправить воздушное судно по расписанию
        /// </summary>
        public static SmsEventArea MntOrgFactDesireToFixDefect = new SmsEventArea(1234, "Desire to 'fix' the defect", "Desire to 'fix' the defect and send the aircraft on schedule", "Desire to 'fix' the defect", MntOrgFact);
        #endregion

        #region public static SmsEventArea MntOrgFactAirlinesConsolid = new SmsEventArea(1235, "Consolidation of the airlines", "Consolidation and merger of the airlines", "Consolidation of the airlines", MntOrgFact);
        /// <summary>
        /// укрупнение и слияние авиакомпаний, объединение подразделений по техническому обслуживанию с разной организацией работы и культурой обеспечения безопасности
        /// </summary>
        public static SmsEventArea MntOrgFactAirlinesConsolid = new SmsEventArea(1235, "Consolidation of the airlines", "Consolidation and merger of the airlines", "Consolidation of the airlines", MntOrgFact);
        #endregion

        #region public static SmsEventArea MntOrgFactTransfWorkToSubcont = new SmsEventArea(1236, "Transfer of the work to subcontr-s", "Transfer of the work to subcontractors", "Transfer of the work to subcontractors", MntOrgFact);
        /// <summary>
        /// передача работ субподрядчикам
        /// </summary>
        public static SmsEventArea MntOrgFactTransfWorkToSubcont = new SmsEventArea(1236, "Transfer of the work to subcontr-s", "Transfer of the work to subcontractors", "Transfer of the work to subcontractors", MntOrgFact);
        #endregion

        #region public static SmsEventArea MntOrgFactUnintSetForgedParts = new SmsEventArea(1237, "Unint. setting forged parts", "Unintentional setting forged parts", "Unint. setting forged parts", MntOrgFact);
        /// <summary>
        /// непреднамеренная установка (дешевых, некондиционных) поддельных деталей
        /// </summary>
        public static SmsEventArea MntOrgFactUnintSetForgedParts = new SmsEventArea(1237, "Unint. setting forged parts", "Unintentional setting forged parts", "Unint. setting forged parts", MntOrgFact);
        #endregion

        #region public static SmsEventArea MntOrgFactDiffAircrDocs = new SmsEventArea(1238, "Cert. to work on diff. aircraft", "Issuance of certificates of AMEs to work on different aircraft", "Certificates to work on different aircraft", MntOrgFact);
        /// <summary>
        /// выдача авиатехникам свидетельств для работы на разных воздушных судах, воздушных судах разных поколений, типов и изготовителей
        /// </summary>
        public static SmsEventArea MntOrgFactDiffAircrDocs = new SmsEventArea(1238, "Cert. to work on diff. aircraft", "Issuance of certificates of AMEs to work on different aircraft", "Certificates to work on different aircraft", MntOrgFact);
        #endregion
        
        #endregion

        #region public static SmsEventArea MaintenanceWplCond = new SmsEventArea(124, "Workpl. cond-s.", "Workplace conditions", "Workplace Conditions", Maintenance);
        /// <summary>
        /// Условия на рабочем месте
        /// </summary>
        public static SmsEventArea MaintenanceWplCond = new SmsEventArea(124, "Workpl. cond-s.", "Workplace conditions", "Workplace Conditions", Maintenance);
        #endregion

        #region Элементы пункта "Условия на рабочем месте"

        #region public static SmsEventArea MntWplCondUncomfAircrDesignForMnt = new SmsEventArea(1241, "Uncomf. for the maint. of aircraft design", "Uncomfortable for the maintenance of aircraft design", "uncomfortable for the maintenance of aircraft design", MaintenanceWplCond);
        /// <summary>
        /// неудобная для технического обслуживания конструкция воздушных судов 
        /// </summary>
        public static SmsEventArea MntWplCondUncomfAircrDesignForMnt = new SmsEventArea(1241, "Uncomf. for the maint. of aircraft design", "Uncomfortable for the maintenance of aircraft design", "uncomfortable for the maintenance of aircraft design", MaintenanceWplCond);
        #endregion

        #region public static SmsEventArea MntWplCondAircrConfigControl = new SmsEventArea(1242, "Control of the aircraft config.", "Control of the aircraft configuration", "Control of the aircraft configuration", MaintenanceWplCond);
        /// <summary>
        /// контроль за конфигурациями воздушных судов 
        /// </summary>
        public static SmsEventArea MntWplCondAircrConfigControl = new SmsEventArea(1242, "Control of the aircraft config.", "Control of the aircraft configuration", "Control of the aircraft configuration", MaintenanceWplCond);
        #endregion

        #region public static SmsEventArea MntWplCondPartsToolsDocsAvail = new SmsEventArea(1243, "Avail-ty of spare parts, tools, documentation", "Availability of spare parts, tools, documentation", "Avail-ty of spare parts, tools, documentation", MaintenanceWplCond);
        /// <summary>
        /// наличие (и готовность к использованию) запчастей, инструментов, документации
        /// </summary>
        public static SmsEventArea MntWplCondPartsToolsDocsAvail = new SmsEventArea(1243, "Avail-ty of spare parts, tools, documentation", "Availability of spare parts, tools, documentation", "Avail-ty of spare parts, tools, documentation", MaintenanceWplCond);
        #endregion

        #region public static SmsEventArea MntWplCondAccessToVolumeTechInfo = new SmsEventArea(1244, "Access to the volume of tech. info", "Access to the volume of technical information", "Access to the volume of technical information", MaintenanceWplCond);
        /// <summary>
        /// доступ к объемной технической информации
        /// </summary>
        public static SmsEventArea MntWplCondAccessToVolumeTechInfo = new SmsEventArea(1244, "Access to the volume of tech. info", "Access to the volume of technical information", "Access to the volume of technical information", MaintenanceWplCond);
        #endregion

        #region public static SmsEventArea MntWplCondEnvCondChanging = new SmsEventArea(1245, "Changing environmental conditions", "Changing environmental conditions", "Changing environmental conditions", MaintenanceWplCond);
        /// <summary>
        /// изменяющиеся экологические условия
        /// </summary>
        public static SmsEventArea MntWplCondEnvCondChanging = new SmsEventArea(1245, "Changing environmental conditions", "Changing environmental conditions", "Changing environmental conditions", MaintenanceWplCond);
        #endregion

        #region public static SmsEventArea MntWplCondUniqueCondOfWork = new SmsEventArea(1246, "Unique conditions of work", "Unique conditions of work", "Unique conditions of work", MaintenanceWplCond);
        /// <summary>
        /// уникальные условия работы
        /// </summary>
        public static SmsEventArea MntWplCondUniqueCondOfWork = new SmsEventArea(1246, "Unique conditions of work", "Unique conditions of work", "Unique conditions of work", MaintenanceWplCond);
        #endregion

        #region public static SmsEventArea MntWplCondFlightCrewBadWork = new SmsEventArea(1247, "Bad work flight crews to presentation timely report", "Bad work flight crews to presentation timely report", "Bad work flight crews to presentation timely report", MaintenanceWplCond);
        /// <summary>
        /// нечеткая работа летных экипажей по представлению своевременных донесений
        /// </summary>
        public static SmsEventArea MntWplCondFlightCrewBadWork = new SmsEventArea(1247, "Bad work flight crews to presentation timely report", "Bad work flight crews to presentation timely report", "Bad work flight crews to presentation timely report", MaintenanceWplCond);
        #endregion

        #endregion

        #region public static SmsEventArea MaintenanceHumFact = new SmsEventArea(125, "Human factors", "Human factors", "Human factors", Maintenance);
        /// <summary>
        /// Человеческий фактор
        /// </summary>
        public static SmsEventArea MaintenanceHumFact = new SmsEventArea(125, "Human factors", "Human factors", "Human factors", Maintenance);
        #endregion

        #region Элементы пункта "Человеческий фактор"

        #region public static SmsEventArea MntHumFactOrgAspects = new SmsEventArea(1251, "Org. aspects", "Organizational aspects and conditions of work", "Organizational aspects", MaintenanceHumFact);
        /// <summary>
        /// организационные аспекты
        /// </summary>
        public static SmsEventArea MntHumFactOrgAspects = new SmsEventArea(1251, "Org. aspects", "Organizational aspects and conditions of work", "Organizational aspects", MaintenanceHumFact);
        #endregion

        #region public static SmsEventArea MntHumFactEnvFactors = new SmsEventArea(1252, "Environmental factors", "Environmental factors (such as temperature, lighting, noise, etc.)", "Environmental factors", MaintenanceHumFact);
        /// <summary>
        /// экологические факторы (например, температура, освещение, шум и т. д.)
        /// </summary>
        public static SmsEventArea MntHumFactEnvFactors = new SmsEventArea(1252, "Environmental factors", "Environmental factors (such as temperature, lighting, noise, etc.)", "Environmental factors", MaintenanceHumFact);
        #endregion

        #region public static SmsEventArea MntHumFactIndFactors = new SmsEventArea(1253, "Individual factors", "individual factors (working load, and the physical requirements)", "Individual factors", MaintenanceHumFact);
        /// <summary>
        /// индивидуальные факторы (например, рабочая загрузка, физические потребности и т. д.)
        /// </summary>
        public static SmsEventArea MntHumFactIndFactors = new SmsEventArea(1253, "Individual factors", "individual factors (working load, and the physical requirements)", "Individual factors", MaintenanceHumFact);
        #endregion

        #region public static SmsEventArea MntHumFactWorkSchedules = new SmsEventArea(1254, "Work schedules", "Work schedules, time to rest", "Work schedules", MaintenanceHumFact);
        /// <summary>
        /// рабочие графики
        /// </summary>
        public static SmsEventArea MntHumFactWorkSchedules = new SmsEventArea(1254, "Work schedules", "Work schedules, time to rest", "Work schedules", MaintenanceHumFact);
        #endregion

        #region public static SmsEventArea MntHumFactAdeqOpProc = new SmsEventArea(1255, "Adequacy of the standard operating procedures", "Adequacy of the standard operating procedures", "Adequacy of the standard operating procedures", MaintenanceHumFact);
        /// <summary>
        /// адекватность стандартных эксплуатационных правил
        /// </summary>
        public static SmsEventArea MntHumFactAdeqOpProc = new SmsEventArea(1255, "Adequacy of the standard operating procedures", "Adequacy of the standard operating procedures", "Adequacy of the standard operating procedures", MaintenanceHumFact);
        #endregion

        #region public static SmsEventArea MntHumFactLdspQuality = new SmsEventArea(1256, "Quality of leadership", "Quality of leadership", "Quality of leadership", MaintenanceHumFact);
        /// <summary>
        /// качество руководства
        /// </summary>
        public static SmsEventArea MntHumFactLdspQuality = new SmsEventArea(1256, "Quality of leadership", "Quality of leadership", "Quality of leadership", MaintenanceHumFact);
        #endregion

        #region public static SmsEventArea MntHumFactProperObserOfProcessMaps = new SmsEventArea(1257, "Proper observance of process maps", "Proper observance of process maps", "Proper observance of process maps", MaintenanceHumFact);
        /// <summary>
        /// надлежащее соблюдение технологических карт 
        /// </summary>
        public static SmsEventArea MntHumFactProperObserOfProcessMaps = new SmsEventArea(1257, "Proper observance of process maps", "Proper observance of process maps", "Proper observance of process maps", MaintenanceHumFact);
        #endregion

        #region public static SmsEventArea MntHumFactAdequacyOfTraining = new SmsEventArea(1258, "Adequacy of the training", "Adequacy of the training", "Adequacy of the training", MaintenanceHumFact);
        /// <summary>
        /// достаточность уровня профессиональной подготовки
        /// </summary>
        public static SmsEventArea MntHumFactAdequacyOfTraining = new SmsEventArea(1258, "Adequacy of the training", "Adequacy of the training", "Adequacy of the training", MaintenanceHumFact);
        #endregion

        #region public static SmsEventArea MntHumFactCorrShiftTrans = new SmsEventArea(1259, "Corr. transmission shifts", "Correct transmission shifts and proper record keeping", "Correct transmission shifts", MaintenanceHumFact);
        /// <summary>
        /// правильная передача смен и надлежащее ведение записей
        /// </summary>
        public static SmsEventArea MntHumFactCorrShiftTrans = new SmsEventArea(1259, "Corr. transmission shifts", "Correct transmission shifts and proper record keeping", "Correct transmission shifts", MaintenanceHumFact);
        #endregion

        #region public static SmsEventArea MntHumFactMonotony = new SmsEventArea(12510, "Monotony", "Monotony", "Monotony", MaintenanceHumFact);
        /// <summary>
        /// однообразие
        /// </summary>
        public static SmsEventArea MntHumFactMonotony = new SmsEventArea(12510, "Monotony", "Monotony", "Monotony", MaintenanceHumFact);
        #endregion

        #region public static SmsEventArea MntHumFactLevelOfProfCulture = new SmsEventArea(12511, "Level of professional culture", "Level of professional culture", "Level of professional culture", MaintenanceHumFact);
        /// <summary>
        /// уровень профессиональной культуры
        /// </summary>
        public static SmsEventArea MntHumFactLevelOfProfCulture = new SmsEventArea(12511, "Level of professional culture", "Level of professional culture", "Level of professional culture", MaintenanceHumFact);
        #endregion

        #endregion

        #region public static SmsEventArea Unknown = new SmsEventArea(-1, "Unknown", "Unknown", "Unknown");
        /// <summary> 
        /// Неизвестный объект
        /// </summary>
        public static SmsEventArea Unknown = new SmsEventArea(-1, "Unknown", "Unknown", "Unknown");
        #endregion

        /*
         * Методы
         */

        #region public static SmsEventArea GetItemById(Int32 SmsEventAreaId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="smsEventAreaId"></param>
        /// <returns></returns>
        public static SmsEventArea GetItemById(Int32 smsEventAreaId)
        {
            foreach (SmsEventArea t in _Items)
                if (t.ItemId == smsEventAreaId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<SmsEventArea> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<SmsEventArea> Items
        {
            get { return _Items; }
        }
        #endregion

        #region static public CommonDictionaryCollection<SmsEventArea> Roots
        /// <summary>
        /// Возвращает список корневых элементов
        /// </summary>
        public static CommonDictionaryCollection<SmsEventArea> Roots
        {
            get { return _roots; }
        }
        #endregion

        #region public IDictionaryCollection Children
        /// <summary>
        /// Дочерние элементы словаря
        /// </summary>
        public new CommonDictionaryCollection<SmsEventArea> Children
        {
            get
            {
                if (_children == null)
                    _children = new CommonDictionaryCollection<SmsEventArea>();
                return (CommonDictionaryCollection<SmsEventArea>)_children;
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
            return FullName;
        }
        #endregion

        /*
         * Реализация
         */

        #region public SmsEventArea()
        /// <summary>
        /// Консруктор по умолчанию
        /// </summary>
        public SmsEventArea()
        {
            SmartCoreObjectType = SmartCoreType.SmsEventArea;
        }
        #endregion

        #region private SmsEventArea(Int32 ItemId, String shortName, String fullName, String commonName) : this(itemId, shortName, fullName, commonName, Unknown)

        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        private SmsEventArea(Int32 itemId, String shortName, String fullName, String commonName)
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

        #region private SmsEventArea(Int32 itemId, String shortName, String fullName, String commonName, SmsEventArea parent) : this()

        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        /// <param name="parent">Родительский узел</param>
        private SmsEventArea(Int32 itemId, String shortName, String fullName, String commonName, SmsEventArea parent) : this()
        {
            ItemId = itemId;
            ShortName = shortName;
            FullName = fullName;
            CommonName = commonName;
            _parent = parent;

            if (parent != null)
            {
                //Выставление пред. узла на данном уровне для тек. узла
                SmsEventArea prevNode = parent.Children.Count > 0
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
