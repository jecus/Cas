using System;
using System.Collections.Generic;

namespace SmartCore.Entities.Dictionaries
{
   public  class MaintenanceInterval
   {

       #region private static List<MaintenanceInterval> _Items=new List<MaintenanceInterval>();
       /// <summary>
       /// Коллекция свойств
       /// </summary>
       private static List<MaintenanceInterval> _Items = new List<MaintenanceInterval>();

       #endregion

       #region public static List<MaintenanceInterval> MaintenanceIntervals { get { return _Items; } }
       /// <summary>
       /// Возвращает список MaintenanceIntervals
       /// </summary>
       public static List<MaintenanceInterval> MaintenanceIntervals { get { return _Items; } }

       #endregion

       /*
       * Предопределенный свойсва
       */

       #region public static MaintenanceInterval Unknown = new MaintenanceInterval(-1, "", "");

       /// <summary>
       /// Интервал обслуживания не определен
       /// </summary>
       public static MaintenanceInterval Unknown = new MaintenanceInterval(-1, "", "");

       #endregion

       #region public static MaintenanceInterval A1Check = new MaintenanceInterval(1, "1A Check", "");

       public static MaintenanceInterval A1Check=new MaintenanceInterval(1,"1A Check","");

       #endregion

       #region public static MaintenanceInterval A2Check = new MaintenanceInterval(2, "2A Check", "");

       public static MaintenanceInterval A2Check = new MaintenanceInterval(2, "2A Check", "");

       #endregion

       #region public static MaintenanceInterval A3Check = new MaintenanceInterval(3, "3A Check", "");

       public static MaintenanceInterval A3Check = new MaintenanceInterval(3, "3A Check", "");

       #endregion

       #region public static MaintenanceInterval A4Check = new MaintenanceInterval(4, "4A Check", "");

       public static MaintenanceInterval A4Check = new MaintenanceInterval(4, "4A Check", "");

       #endregion

       #region public static MaintenanceInterval A5Check = new MaintenanceInterval(5, "5A Check", "");

       public static MaintenanceInterval A5Check = new MaintenanceInterval(5, "5A Check", "");

       #endregion

       #region public static MaintenanceInterval A6Check = new MaintenanceInterval(6, "6A Check", "");

       public static MaintenanceInterval A6Check = new MaintenanceInterval(6, "6A Check", "");

       #endregion

       #region public static MaintenanceInterval A7Check = new MaintenanceInterval(7, "7A Check", "");

       public static MaintenanceInterval A7Check = new MaintenanceInterval(7, "7A Check", "");

       #endregion

       #region public static MaintenanceInterval A8Check = new MaintenanceInterval(8, "8A Check", "");

       public static MaintenanceInterval A8Check = new MaintenanceInterval(8, "8A Check", "");

       #endregion

       #region public static MaintenanceInterval A9Check = new MaintenanceInterval(9, "9A Check", "");

       public static MaintenanceInterval A9Check = new MaintenanceInterval(9, "9A Check", "");

       #endregion

       #region public static MaintenanceInterval A10Check = new MaintenanceInterval(10, "10A Check", "");

       public static MaintenanceInterval A10Check = new MaintenanceInterval(10, "10A Check", "");

       #endregion

       #region public static MaintenanceInterval A11Check = new MaintenanceInterval(11, "11A Check", "");

       public static MaintenanceInterval A11Check = new MaintenanceInterval(11, "11A Check", "");

       #endregion

       #region public static MaintenanceInterval A12Check = new MaintenanceInterval(12, "12A Check", "");

       public static MaintenanceInterval A12Check = new MaintenanceInterval(12, "12A Check", "");

       #endregion

       #region public static MaintenanceInterval C1Check = new MaintenanceInterval(13, "1C Check", "");

       public static MaintenanceInterval C1Check = new MaintenanceInterval(13, "1C Check", "");

       #endregion

       #region public static MaintenanceInterval C2Check = new MaintenanceInterval(14, "2C Check", "");

       public static MaintenanceInterval C2Check = new MaintenanceInterval(14, "2C Check", "");

       #endregion

       #region public static MaintenanceInterval C3Check = new MaintenanceInterval(15, "3C Check", "");

       public static MaintenanceInterval C3Check = new MaintenanceInterval(15, "3C Check", "");

       #endregion

       #region public static MaintenanceInterval C4Check = new MaintenanceInterval(16, "4C Check", "");

       public static MaintenanceInterval C4Check = new MaintenanceInterval(16, "4C Check", "");

       #endregion

       #region public static MaintenanceInterval C5Check = new MaintenanceInterval(17, "5C Check", "");

       public static MaintenanceInterval C5Check = new MaintenanceInterval(17, "5C Check", "");

       #endregion

       #region public static MaintenanceInterval C6Check = new MaintenanceInterval(18, "6C Check", "");

       public static MaintenanceInterval C6Check = new MaintenanceInterval(18, "6C Check", "");

       #endregion

       #region public static MaintenanceInterval C7Check = new MaintenanceInterval(19, "7C Check", "");

       public static MaintenanceInterval C7Check = new MaintenanceInterval(19, "7C Check", "");

       #endregion

       #region public static MaintenanceInterval C8Check = new MaintenanceInterval(20, "8C Check", "");

       public static MaintenanceInterval C8Check = new MaintenanceInterval(20, "8C Check", "");

       #endregion

       #region public static MaintenanceInterval Y10 = new MaintenanceInterval(21, "10Y", "");

       public static MaintenanceInterval Y10 = new MaintenanceInterval(21, "10Y", "");

       #endregion

       #region public static MaintenanceInterval Y12 = new MaintenanceInterval(22, "12Y", "");

       public static MaintenanceInterval Y12 = new MaintenanceInterval(22, "12Y", "");

       #endregion

       #region public static MaintenanceInterval OOP = new MaintenanceInterval(23, "OOP", "");

       public static MaintenanceInterval OOP = new MaintenanceInterval(23, "OOP", "");

       #endregion

       #region public static MaintenanceInterval EngineChange = new MaintenanceInterval(24, "Engine Change", "");

       public static MaintenanceInterval EngineChange = new MaintenanceInterval(24, "Engine Change", "");

       #endregion

       #region public static MaintenanceInterval APUChange = new MaintenanceInterval(25, "APU Change", "");

       public static MaintenanceInterval APUChange = new MaintenanceInterval(25, "APU Change", "");

       #endregion

       #region public static MaintenanceInterval Change = new MaintenanceInterval(26, "Change", "");

       public static MaintenanceInterval Change = new MaintenanceInterval(26, "Change", "");

       #endregion

       #region public static MaintenanceInterval Component = new MaintenanceInterval(27, "Component", "");

       public static MaintenanceInterval Component = new MaintenanceInterval(27, "Component", "");

       #endregion

       #region public static MaintenanceInterval HTC = new MaintenanceInterval(28, "HTC", "");

       public static MaintenanceInterval HTC = new MaintenanceInterval(28, "HTC", "");

       #endregion

       #region public static MaintenanceInterval LLP = new MaintenanceInterval(29, "LLP", "");

       public static MaintenanceInterval LLP = new MaintenanceInterval(29, "LLP", "");

       #endregion

       #region public static MaintenanceInterval DailyCheck = new MaintenanceInterval(30, "Daily Check", "");

       public static MaintenanceInterval DailyCheck = new MaintenanceInterval(30, "Daily Check", "");

       #endregion

       #region public static MaintenanceInterval IntermediateCheck = new MaintenanceInterval(31, "Intermediate Check", "");

       public static MaintenanceInterval IntermediateCheck = new MaintenanceInterval(31, "Intermediate Check", "");

       #endregion

       #region public static MaintenanceInterval Weekly = new MaintenanceInterval(32, "Weekly", "");

       public static MaintenanceInterval Weekly = new MaintenanceInterval(32, "Weekly", "");

       #endregion
       /*
        * Свойства
        */
       
       #region public Int32 ItemID { get; set; }
       /// <summary>
       /// Id Свойства
       /// </summary>
       public Int32 ItemID { get; set; }

       #endregion

       #region  public String Name { get; set; }
       /// <summary>
       /// Наименование
       /// </summary>
       public String Name { get; set; }

       #endregion

       #region  public String Description { get; set; }
       /// <summary>
       /// Описание
       /// </summary>
       public String Description { get; set; }

       #endregion


       /*
       * Конструкторы
       */

       #region public MaintenanceInterval(Int32 itemId,String name,String description)
       /// <summary>
       /// Конструктор создает Коллекцию MaintenanceInterval,и принимает 2 свойства для создания объекта
       /// </summary>
       /// <param name="itemId">id</param>
       /// <param name="Name">Наименование</param>
       public MaintenanceInterval(Int32 itemId,String name,String description)
       {
             ItemID = itemId;
             Name = name;
             Description = description;
             _Items.Add(this);
       }

       #endregion

       /*
        * Методы
        */

       #region public static MaintenanceInterval GetMaintenanceIntervalById(Int32 ID)
       /// <summary>
       /// Возвращает свойсва по заданному ID
       /// </summary>
       /// <param name="ID">id свойства</param>
       /// <returns></returns>
       public static MaintenanceInterval GetMaintenanceIntervalById(Int32 ID)
       {
           foreach (MaintenanceInterval item in _Items)
           {
               if (item.ItemID==ID)
               {
                   return item;
               }
           }
           return null;
       }

       #endregion

       #region public override string ToString()

       public override string ToString()
       {
           return Name;
       }

       #endregion


   }
}
