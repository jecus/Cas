using System;
using System.Collections.Generic;
using System.Drawing;
using CAS.UI.Properties;

namespace CAS.UI.Management
{
    /// <summary>
    /// Класс, содержащий набор иконок для данного приложения
    /// </summary>
    internal class Icons
    {
        #region Fields

        private static List<Image> animationList;
        #endregion


        #region Properties

        #region internal Image About

        /// <summary>
        /// Возвращает иконку, использующуюся для отображения информации о продукте
        /// </summary>
        internal Image About
        {
            get
            {
                return GetIcon(Resources.AboutIcon);
            }
        }

        #endregion

        #region internal Image Add

        /// <summary>
        /// Возвращает иконку, использующуюся при добавлении бизнес-объекта
        /// </summary>
        internal Image Add
        {
            get
            {
                return GetIcon(Resources.AddIcon);
            }
        }

        #endregion

        #region internal Image AddGray

        /// <summary>
        /// Возвращает черно-белую иконку, использующуюся при добавлении бизнес-объекта
        /// </summary>
        internal Image AddGray
        {
            get
            {
                return GetIcon(Resources.AddIcon_gray);
            }
        }

        #endregion

        #region internal Image Aircraft

        /// <summary>
        /// Возвращает иконку, использующуюся как отображение воздушного судна
        /// </summary>
        internal Image Aircraft
        {
            get
            {
                return GetIcon(Resources.AircraftIcon);
            }
        }

        #endregion

        #region internal Image Aircrafts

        /// <summary>
        /// Возвращает иконку, использующуюся как отображение воздушных судов
        /// </summary>
        internal Image Aircrafts
        {
            get
            {
                return GetIcon(Resources.AircraftsIcon);
            }
        }

        #endregion

        #region internal Image AirplaneStartLogo

        /// <summary>
        /// Возвращает иконку логотипа
        /// </summary>
        internal Image AirplaneStartLogo
        {
            get
            {
                return GetIcon(Resources.AirplaneStartLogo);
            }
        }

        #endregion

        #region internal Image ApplyFilter

        /// <summary>
        /// Возвращает иконку применения фильтра
        /// </summary>
        internal Image ApplyFilter
        {
            get
            {
                return GetIcon(Resources.ApplyFilterIcon);
            }
        }

        #endregion

        #region internal Image APU

        /// <summary>
        /// Возвращает иконку, использующуюся как отображение ВСУ
        /// </summary>
        internal Image APU
        {
            get
            {
                return GetIcon(Resources.APUIcon);
            }
        }

        #endregion

        #region internal Image BiWeeklyReports

        /// <summary>
        /// Возвращает иконку, для обозначения BiWeekly отчетов
        /// </summary>
        internal Image BiWeeklyReports
        {
            get
            {
                return GetIcon(Resources.BiWeeklyReportsIcon);
            }
        }

        #endregion

        #region internal Image BlueArrow
        /// <summary>
        /// Возвращает иконку, использующуюся как стрелку отображения статуса
        /// </summary>
        internal Image BlueArrow
        {
            get
            {
                return GetIcon(Resources.BlueArrow);
            }
        }
        #endregion

        #region internal Image BlueArrowBack
        /// <summary>
        /// Возвращает иконку, использующуюся как стрелку назад
        /// </summary>
        internal Image BlueArrowBack
        {
            get
            {
                return GetIcon(Resources.BlueBack);
            }
        }
        #endregion

        #region internal Image BlueArrowBackGrey
        /// <summary>
        /// Возвращает черно-белую иконку, использующуюся как стрелку назад
        /// </summary>
        internal Image BlueArrowBackGrey
        {
            get
            {
                return GetIcon(Resources.BlueBackGrey);
            }
        }
        #endregion

        #region internal Image CancelEdit

        /// <summary>
        /// Возвращает иконку, использующуюся при отмене редактирования
        /// </summary>
        internal Image CancelEdit
        {
            get
            {
                return GetIcon(Resources.CancelEdit);
            }
        }

        #endregion

        #region internal Image CancelEditGray

        /// <summary>
        /// Возвращает черно-белую иконку, использующуюся при отмене редактирования
        /// </summary>
        internal Image CancelEditGray
        {
            get
            {
                return GetIcon(Resources.CancelEdit_gray);
            }
        }

        #endregion

        #region internal Image Close

        /// <summary>
        /// Возвращает иконку, обозначающую закрытие вкладки
        /// </summary>
        internal Image Close
        {
            get
            {
                return GetIcon(Resources.CloseIcon);
            }
        }

        #endregion

        #region internal Image CloseGray

        /// <summary>
        /// Возвращает черно-белую иконку, обозначающую закрытие вкладки
        /// </summary>
        internal Image CloseGray
        {
            get
            {
                return GetIcon(Resources.CloseIcon_gray);
            }
        }

        #endregion

        #region internal Image ComponentStatus

        /// <summary>
        /// Возвращает иконку, обозначающую статус компонента
        /// </summary>
        internal Image ComponentStatus
        {
            get
            {
                return GetIcon(Resources.ComponentStatusIcon);
            }
        }

        #endregion

        #region internal Image IdentityUser

        /// <summary>
        /// Возвращает иконку, использующуюся для отображения информации о пользователе
        /// </summary>
        internal Image CurrentUser
        {
            get
            {
                return GetIcon(Resources.CurrentUserIcon);
            }
        }

        #endregion

        #region internal Image Delete

        /// <summary>
        /// Возвращает иконку, использующуюся при удалении бизнес-объекта
        /// </summary>
        internal Image Delete
        {
            get
            {
                return GetIcon(Resources.DeleteIcon);
            }
        }

        #endregion

        #region internal Image DeleteGray

        /// <summary>
        /// Возвращает черно-белую иконку, использующуюся при удалении бизнес-объекта
        /// </summary>
        internal Image DeleteGray
        {
            get
            {
                return GetIcon(Resources.DeleteIcon_gray);
            }
        }

        #endregion

        #region internal Image Dictionaries

        /// <summary>
        /// Возвращает иконку справочной информации
        /// </summary>
        internal Image Dictionaries
        {
            get
            {
                return GetIcon(Resources.DictionariesIcon);
            }
        }

        #endregion

        #region internal Image Discrepancies

        /// <summary>
        /// Возвращает иконку, обозначающую список несоответствий
        /// </summary>
        internal Image Discrepancies
        {
            get
            {
                return GetIcon(Resources.DiscrepanciesIcon);
            }
        }

        #endregion

        #region internal Image Edit

        /// <summary>
        /// Возвращает иконку редактирования
        /// </summary>
        internal Image Edit
        {
            get
            {
                return GetIcon(Resources.EditIcon);
            }
        }

        #endregion

        #region internal Image EditGray

        /// <summary>
        /// Возвращает черно-белую иконку редактирования
        /// </summary>
        internal Image EditGray
        {
            get
            {
                return GetIcon(Resources.EditIcon_gray);
            }
        }

        #endregion

        #region internal Image EmptyLogotype

        /// <summary>
        /// Возвращает иконку, использующуюся когда логотип (эксплуатанта) не выбран
        /// </summary>
        internal Image EmptyLogotype
        {
            get
            {
                return GetIcon(Resources.EmptyLogotypeIcon);
            }
        }

        #endregion

        #region internal Image Engine

        /// <summary>
        /// Возвращает иконку, использующуюся как отображения двигателя воздушного судна
        /// </summary>
        internal Image Engine
        {
            get
            {
                return GetIcon(Resources.EngineIcon);
            }
        }

        #endregion

        #region internal Image Exit

        /// <summary>
        /// Возвращает иконку, обозначающую выход из приложения
        /// </summary>
        internal Image Exit
        {
            get
            {
                return GetIcon(Resources.ExitIcon);
            }
        }

        #endregion

        #region internal Image Forecast

        /// <summary>
        /// Возвращает иконку, обозначающую прогноз
        /// </summary>
        internal Image Forecast
        {
            get
            {
                return GetIcon(Resources.ForecastIcon);
            }
        }

        #endregion

        #region internal Image GrayArrow
        /// <summary>
        /// Возвращает иконку, использующуюся как стрелку отображения статуса
        /// </summary>
        public Image GrayArrow
        {
            get
            {
                return GetIcon(Resources.GrayArrow);
            }
        }
        #endregion

        #region internal Image GreenArrow
        /// <summary>
        /// Возвращает иконку, использующуюся как стрелку отображения статуса
        /// </summary>
        internal Image GreenArrow
        {
            get
            {
                return GetIcon(Resources.GreenArrow);
            }
        }
        #endregion

        #region internal Image HeaderBarClicked

        /// <summary>
        /// Возвращает иконку, которая отображается при наведении курсора мыши на кнопки заголовка
        /// </summary>
        internal Image HeaderBarClicked
        {
            get
            {
                return GetIcon(Resources.HeaderBarClicked);
            }
        }

        #endregion

        #region internal Image Help

        /// <summary>
        /// Возвращает иконку, использующуюся как отображение справки
        /// </summary>
        internal Image Help
        {
            get
            {
                return GetIcon(Resources.HelpIcon);
            }
        }

        #endregion

        #region internal Image HelpGray

        /// <summary>
        /// Возвращает черно-белую иконку, использующуюся как отображение справки
        /// </summary>
        internal Image HelpGray
        {
            get
            {
                return GetIcon(Resources.HelpIcon_gray);
            }
        }

        #endregion

        #region internal Image Load

        /// <summary>
        /// Возвращает иконку, использующуюся при загрузке внешних файлов
        /// </summary>
        internal Image Load
        {
            get
            {
                return GetIcon(Resources.LoadIcon);
            }
        }

        #endregion

        #region internal Image LoadGray

        /// <summary>
        /// Возвращает черно-белую иконку, использующуюся при загрузке внешних файлов
        /// </summary>
        internal Image LoadGray
        {
            get
            {
                return GetIcon(Resources.LoadIcon_gray);
            }
        }

        #endregion

        #region internal Image Logout

        /// <summary>
        /// Возвращает иконку, использующуюся при выходе из системы
        /// </summary>
        internal Image Logout
        {
            get
            {
                return GetIcon(Resources.LogoutIcon);
            }
        }

        #endregion

        #region internal Image LogoutGray

        /// <summary>
        /// Возвращает черно-белую иконку, использующуюся при выходе из системы
        /// </summary>
        internal Image LogoutGray
        {
            get
            {
                return GetIcon(Resources.LogoutIcon_gray);
            }
        }

        #endregion

        #region internal Image Menu

        /// <summary>
        /// Возвращает иконку, использующуюся как отображение меню
        /// </summary>
        internal Image Menu
        {
            get
            {
                return GetIcon(Resources.MenuIcon);
            }
        }

        #endregion

        #region internal Image NewOperator

        /// <summary>
        /// Возвращает иконку, использующуюся при добавлении нового эксплуатанта
        /// </summary>
        internal Image NewOperator
        {
            get
            {
                return GetIcon(Resources.NewOperatorIcon);
            }
        }

        #endregion

        #region internal Image OperatorCollection

        /// <summary>
        /// Возвращает иконку, для отображения списка эксплуатантов
        /// </summary>
        internal Image Operators
        {
            get
            {
                return GetIcon(Resources.OperatorsIcon);
            }
        }

        #endregion

        #region internal Image OperatorsInfo

        /// <summary>
        /// Возвращает иконку, для обозначения информации об эксплуатанте
        /// </summary>
        internal Image OperatorsInfo
        {
            get
            {
                return GetIcon(Resources.OperatorsInfoIcon);
            }
        }

        #endregion

        #region internal Image OrangeArrow
        /// <summary>
        /// Возвращает иконку, использующуюся как стрелку отображения статуса
        /// </summary>
        internal Image OrangeArrow
        {
            get
            {
                return GetIcon(Resources.OrangeArrow);
            }
        }
        #endregion

        #region internal Image PDF

        /// <summary>
        /// Возвращает иконку PDF
        /// </summary>
        internal Image PDF
        {
            get
            {
                return GetIcon(Resources.PDFIcon);
            }
        }

        #endregion

        #region internal Image PDFGray

        /// <summary>
        /// Возвращает черно-белую иконку PDF
        /// </summary>
        internal Image PDFGray
        {
            get
            {
                return GetIcon(Resources.PDFIcon_gray);
            }
        }

        #endregion

        #region internal Image PDF_GIF

        /// <summary>
        /// Возвращает иконку PDF в формате GIF
        /// </summary>
        internal Image PDF_GIF
        {
            get
            {
                return GetIcon(Resources.PDFIcon_gif);
            }
        }

        #endregion

        #region internal Image PDF_GIFGray

        /// <summary>
        /// Возвращает черно-белую иконку PDF в формате GIF
        /// </summary>
        internal Image PDF_GIFGray
        {
            get
            {
                return GetIcon(Resources.PDFIcon_gray_gif);
            }
        }

        #endregion

        #region internal Image PDFSmall

        /// <summary>
        /// Возвращает иконку PDF
        /// </summary>
        internal Image PDFSmall
        {
            get
            {
                return GetIcon(Resources.PDFIconSmall);
            }
        }

        #endregion

        #region internal Image Plane

        /// <summary>
        /// Возвращает икону самолета
        /// </summary>
        internal Image Plane
        {
            get
            {
                return GetIcon(Resources.Plane);
            }
        }

        #endregion

        #region internal Image PlaneGray

        /// <summary>
        /// Возвращает икону самолета
        /// </summary>
        internal Image PlaneGray
        {
            get
            {
                return GetIcon(Resources.PlaneGray);
            }
        }

        #endregion

        #region internal Image Point

        /// <summary>
        /// Возвращает серый кружочеГ
        /// </summary>
        internal Image Point
        {
            get
            {
                return GetIcon(Resources.Point);
            }
        }

        #endregion

        #region internal Image Print

        /// <summary>
        /// Возвращает иконку, использующуюся при печати
        /// </summary>
        public Image Print
        {
            get
            {
                return GetIcon(Resources.PrintIcon);
            }
        }

        #endregion

        #region public Image PrintGray

        /// <summary>
        /// Возвращает черно-белую иконку, использующуюся при печати
        /// </summary>
        public Image PrintGray
        {
            get
            {
                return GetIcon(Resources.PrintIcon_gray);
            }
        }

        #endregion

        #region internal Image RedArrow
        /// <summary>
        /// Возвращает иконку, использующуюся как стрелку отображения статуса
        /// </summary>
        internal Image RedArrow
        {
            get
            {
                return GetIcon(Resources.RedArrow);
            }
        }
        #endregion

        #region internal Image Reload

        /// <summary>
        /// Возвращает иконку, использующуюся при обновлении бизнес-объекта
        /// </summary>
        internal Image Reload
        {
            get
            {
                return GetIcon(Resources.ReloadIcon);
            }
        }

        #endregion

        #region internal Image ReloadGray

        /// <summary>
        /// Возвращает черно-белую иконку, использующуюся при обновлении бизнес-объекта
        /// </summary>
        internal Image ReloadGray
        {
            get
            {
                return GetIcon(Resources.ReloadIcon_gray);
            }
        }

        #endregion

        #region internal Image Report

        /// <summary>
        /// Возвращает иконку, использующуюся при отчетах
        /// </summary>
        internal Image Report
        {
            get
            {
                return GetIcon(Resources.ReportIcon);
            }
        }

        #endregion

        #region internal Image Save

        /// <summary>
        /// Возвращает иконку, использующуюся при сохранении бизнес-объекта
        /// </summary>
        internal Image Save
        {
            get
            {
                return GetIcon(Resources.SaveIcon);
            }
        }

        #endregion

        #region internal Image SaveGray

        /// <summary>
        /// Возвращает черно-белую иконку, использующуюся при сохранении бизнес-объекта
        /// </summary>
        internal Image SaveGray
        {
            get
            {
                return GetIcon(Resources.SaveIcon_gray);
            }
        }

        #endregion

        #region internal Image SaveAndAdd

        /// <summary>
        /// Возвращает иконку сохранения и добавления
        /// </summary>
        internal Image SaveAndAdd
        {
            get
            {
                return GetIcon(Resources.SaveAndAddIcon);
            }
        }

        #endregion

        #region internal Image SaveAndAddGray

        /// <summary>
        /// Возвращает черно-белую иконку сохранения и добавления
        /// </summary>
        internal Image SaveAndAddGray
        {
            get
            {
                return GetIcon(Resources.SaveAndAddIcon_gray);
            }
        }

        #endregion

        #region internal Image Search

        /// <summary>
        /// Возвращает иконку, использующуюся при поиске
        /// </summary>
        internal Image Search
        {
            get
            {
                return GetIcon(Resources.SearchIcon);
            }
        }

        #endregion

        #region internal Image SeparatorLine

        /// <summary>
        /// Возвращает иконку разделителя
        /// </summary>
        internal Image SeparatorLine
        {
            get
            {
                return GetIcon(Resources.SeparatorLine1);
            }
        }

        #endregion

        #region internal Image Templates

        /// <summary>
        /// Возвращает иконку, использующуюся для отображения шаблонов
        /// </summary>
        internal Image Templates
        {
            get
            {
                return GetIcon(Resources.TemplatesIcon);
            }
        }

        #endregion

        #region internal Image TransferComponentRed

        /// <summary>
        /// Возвращает икону самолета
        /// </summary>
        internal Image TransferComponentRed
        {
            get
            {
                return GetIcon(Resources.TransferComponentRed);
            }
        }
        #endregion

        #region internal Image TransferComponentGray

        /// <summary>
        /// Возвращает икону самолета
        /// </summary>
        internal Image TransferComponentGray
        {
            get
            {
                return GetIcon(Resources.TransferComponentGray);
            }
        }
        #endregion

        #region internal Image Users

        /// <summary>
        /// Возвращает иконку, использующуюся как отображение пользователей
        /// </summary>
        internal Image Users
        {
            get
            {
                return GetIcon(Resources.UsersIcon);
            }
        }

        #endregion

        #region internal Image View

        /// <summary>
        /// Возвращает иконку, использующуюся для просмотра чего-либо
        /// </summary>
        internal Image View
        {
            get
            {
                return GetIcon(Resources.ViewIcon);
            }
        }

        #endregion

        #region internal Image ViewGray

        /// <summary>
        /// Возвращает черно-белую иконку, использующуюся для просмотра чего-либо
        /// </summary>
        internal Image ViewGray
        {
            get
            {
                return GetIcon(Resources.ViewIcon);
            }
        }

        #endregion

        #region internal Image ViewLog
        /// <summary>
        /// Возвращает иконку, использующуюся как отображение лога
        /// </summary>
        internal Image ViewLog
        {
            get
            {
                return GetIcon(Resources.ViewLogIcon);
            }
        }
        #endregion

        #region internal List<Image> WaitAnimations

        /// <summary>
        /// Возвращает список изображений, использующуюся в анимации при ожидании
        /// </summary>
        internal static List<Image> WaitAnimations
        {
            get
            {
                return GetAnimtionList();
            }
        }
        #endregion
        

        #endregion

        #region Methods

        #region private Image GetIcon(Image resourcesImage)
        /// <summary>
        /// Метод, возвращающий заданное изображение из ресурсов
        /// </summary>
        /// <param name="resourcesImage">Имя изображения в ресурсах</param>
        private static Image GetIcon(Image resourcesImage)
        {
            if (resourcesImage != null)
                return resourcesImage;
            throw new NullReferenceException("This icon doesn't exist in project resources");
        }

        #endregion

        #region private static List<Image> LoadAnimtionList()

        private static List<Image> GetAnimtionList()
        {
            if (animationList!=null) return animationList;
            else
            {
                animationList = new List<Image>();
                animationList.Add(Resources.WaitAnimatio1);
                animationList.Add(Resources.WaitAnimation2);
                animationList.Add(Resources.WaitAnimation3);
                animationList.Add(Resources.WaitAnimation4);
                animationList.Add(Resources.WaitAnimation5);
                animationList.Add(Resources.WaitAnimation6);
                animationList.Add(Resources.WaitAnimation7);
                animationList.Add(Resources.WaitAnimation8);
                animationList.Add(Resources.WaitAnimation9);
                animationList.Add(Resources.WaitAnimation10);
                animationList.Add(Resources.WaitAnimation11);
                animationList.Add(Resources.WaitAnimation12);
                return animationList;
            }
        }

        #endregion
        

        #endregion

    }
}