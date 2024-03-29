#region

using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using CASTerms;
using SmartCore.CAA;
using SmartCore.CAA.CAAEducation;
using SmartCore.CAA.Check;
using SmartCore.CAA.StandartManual;
using SmartCore.Calculations;
using SmartCore.Calculations.MTOP;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Personnel;
using Component = SmartCore.Entities.General.Accessory.Component;
using Type = System.Type;

#endregion

namespace Auxiliary
{
    public static class UsefulMethods
    {
        #region public static void SelectAllChildControls(Control control)

        /// <summary>
        /// Этот метод подписывает для каждого внутреннего элемента управления событие MouseMove и в обработчике этого события выделяет его. 
        /// Необходим для корректной работы AutoScroll на страницах нашей любимой программы )))
        /// </summary>
        /// <param name="control"></param>
        /// <param name="exclusion"></param>
        public static void SelectAllChildControls(Control control, Type exclusion)
        {
            if (!control.GetType().IsSubclassOf(exclusion))
            {
                control.MouseMove -= UsefullMethodsMouseMove;
                control.MouseMove += UsefullMethodsMouseMove;
            }

            for (int i = 0; i < control.Controls.Count; i++)
            {
                if (!control.GetType().IsSubclassOf(exclusion))
                {
                    control.Controls[i].MouseMove -= UsefullMethodsMouseMove;
                    control.Controls[i].MouseMove += UsefullMethodsMouseMove;
                    SelectAllChildControls(control.Controls[i], exclusion);
                }
            }
        }

        #endregion

        #region private static void UsefullMethodsMouseMove(object sender, EventArgs e)

        private static void UsefullMethodsMouseMove(object sender, EventArgs e)
        {
            if (sender is Control)
                ((Control) (sender)).Select();
        }

        #endregion

        #region public static string NormalizeDate(DateTime date)

        /// <summary>
        /// Checks correctness of data and represents it in cas format
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string NormalizeDate(DateTime date)
        {
            return (date.Year < 1950) ? "" : date.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
        }

        #endregion

        #region public static byte[] GetByteArrayFromFile(string fileName)

        /// <summary>
        /// Конвертирует файл на жестком диске в массив байтов
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static byte[] GetByteArrayFromFile(string fileName)
        {
            FileInfo fileToConvert = new FileInfo(fileName);
            FileStream streamRead = fileToConvert.OpenRead();
            byte[] fileArray = new byte[streamRead.Length];
            streamRead.Read(fileArray, 0, (int) streamRead.Length);
            streamRead.Close();
            return fileArray;
        }

        #endregion

        #region public static bool SaveFileFromByteArray(byte[] contents, string fileName)

        /// <summary>
        /// Сохраняет файл из массива байтов под заданным именем
        /// </summary>
        /// <param name="contents">Массив байтов</param>
        /// <param name="fileName">Имя файла для сохранения</param>
        /// <returns>Значение ,показывающее было ли сохранение успешным</returns>
        public static bool SaveFileFromByteArray(byte[] contents, string fileName)
        {
            if (contents == null)
                return false;
            try
            {
                FileStream fileStreamBack = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                fileStreamBack.Write(contents, 0, contents.Length);
                fileStreamBack.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating temp file" + Environment.NewLine + ex.Message,
                                new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region public static bool ParseTimePeriod(string s, out TimeSpan time1, out TimeSpan time2)

        /// <summary>
        /// Парсим строку, содержащую интервал времени 18:45 - 20:35
        /// </summary>
        /// <param name="s"></param>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static bool ParseTimePeriod(string s, out TimeSpan time1, out TimeSpan time2)
        {
            time1 = new TimeSpan();
            time2 = new TimeSpan();
            int p = s.IndexOf("-");
            if (p < 0) return false;

            // Разбиваем строку
            string s1 = s.Substring(0, p).Trim();
            string s2 = (p < s.Length - 1) ? s.Substring(p + 1).Trim() : "";

            // Переводим во время 
            if (!TimeSpan.TryParse(s1, out time1)) return false;
            if (!TimeSpan.TryParse(s2, out time2)) return false;

            // Все прошло хорошо
            return true;
        }

        #endregion

        #region public static string TimePeriodToString(TimeSpan time1, TimeSpan time2)

        /// <summary>
        /// Представляет период времени в строковом виде
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static string TimePeriodToString(TimeSpan time1, TimeSpan time2)
        {
            string s1 = TimeToString(time1);
            string s2 = TimeToString(time2);
            return s1 + " - " + s2;
        }

        #endregion

        #region public static TimeSpan GetDifference(TimeSpan time2, TimeSpan time1)

        /// <summary>
        /// Получает разницу между двумя временными метками 
        /// </summary>
        /// <param name="time2"></param>
        /// <param name="time1"></param>
        /// <returns></returns>
        public static TimeSpan GetDifference(TimeSpan time2, TimeSpan time1)
        {
            TimeSpan res = time2.Subtract(time1);
            if (time2 < time1) res = res.Add(new TimeSpan(24, 0, 0));
            return res;
        }

        #endregion

        #region public static string TimeToString(TimeSpan time)

        /// <summary>
        /// Представляет время в виде строки
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string TimeToString(TimeSpan time)
        {
            string s1 = IntToString(time.Hours, 2);
            string s2 = IntToString(time.Minutes, 2);
            return s1 + ":" + s2;
        }

        #endregion

        #region public static string IntToString(int i, int length)

        /// <summary>
        /// Возвращает число и дополняет число ведущими нулями до нужной длинны
        /// </summary>
        /// <param name="i"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string IntToString(int i, int length)
        {
            string s = i.ToString();

            if (s.Length < length)
            {
                s = new string('0', length - s.Length) + s;
            }
            return s;
        }

        #endregion

        #region public static bool StringToDouble(string s, out double d)

        /// <summary>
        /// Переводит строку в дробное число, в случае не успешной операции функция возвратит false
        /// Воспринимает дробные числа и с запятой и с точкой
        /// </summary>
        /// <param name="s"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool StringToDouble(string s, out double d)
        {
            //
            d = 0;

            s = s.Trim();
            if (s.Length == 0) return true;


            CultureInfo my = new CultureInfo("en-US", true) {NumberFormat = {NumberDecimalSeparator = "."}};
            s = s.Replace(",", ".");

            if (!Double.TryParse(s, NumberStyles.AllowDecimalPoint, my, out d)) return false;

            // Операция конвертирования прошла успешно
            return true;
        }

        #endregion

        #region public static double StringToDouble(string s)

        /// <summary>
        /// Переводит строку в число. Пустую строку интерпретирует как 0
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static double StringToDouble(string s)
        {
            double d;
            if (!StringToDouble(s, out d)) return 0;

            //
            return d;
        }

		#endregion

		#region public static string GetHighlight(object item)

		/// <summary>
		/// Возвращает имя цвета директивы в отчете
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		//TODO:(Evgenii Babak) пересмотреть подход с формированием conditionState
		private static Highlight GetHighlight(object item)
        {
            Highlight conditionState = Highlight.White;
            ConditionState cond;
            if (item is Directive)
            {
                Directive directive = (Directive)item;
                if (directive.NextPerformanceIsBlocked)
                {
                    conditionState = Highlight.DarkGreen;
                }
                else
                {
                    cond = directive.Condition;
	                if (cond == ConditionState.NotEstimated)
	                {
		                conditionState = Highlight.Blue;
		                if (directive.Status != DirectiveStatus.Closed && directive.IsApplicability && directive.Threshold.FirstPerformanceSinceNew.IsNullOrZero() && directive.Threshold.RepeatInterval.IsNullOrZero())
			                conditionState = Highlight.Orange;
					}
                    if (cond == ConditionState.Notify)
                        conditionState = Highlight.Yellow;
                    if (cond == ConditionState.Overdue)
                        conditionState = Highlight.Red;

	               
				}
            }
            else if (item is AircraftFlight)
            {
                if (!((AircraftFlight) item).Correct)
                    conditionState = Highlight.Blue;
            }
            else if (item is BaseComponent)
            {
                conditionState = Highlight.White;
            }
            else if (item is Component)
            {
                Component component = (Component) item;
                if (component.NextPerformanceIsBlocked)
                {
                    conditionState = Highlight.DarkGreen;
                }
                else
                {
                    cond = component.Condition;
                    if (cond == ConditionState.NotEstimated)
                        conditionState = Highlight.Blue;
                    if (cond == ConditionState.Notify)
                        conditionState = Highlight.Yellow;
                    if (cond == ConditionState.Overdue)
                        conditionState = Highlight.Red;
                }
            }
            else if (item is ComponentDirective)
            {
                ComponentDirective detDir = (ComponentDirective) item;
                if (detDir.NextPerformanceIsBlocked)
                {
                    conditionState = Highlight.DarkGreen;       
                }
                else
                {
                    cond = detDir.Condition;
                    if (cond == ConditionState.NotEstimated)
                        conditionState = Highlight.Blue;
                    if (cond == ConditionState.Notify)
                        conditionState = Highlight.Yellow;
                    if (cond == ConditionState.Overdue)
                        conditionState = Highlight.Red;    
                }
            }
            else if (item is MaintenanceDirective)
            {
                MaintenanceDirective mpd = (MaintenanceDirective)item;
                if (mpd.NextPerformanceIsBlocked)
                {
                    conditionState = Highlight.DarkGreen;
                }
                else
                {
	                cond = mpd.Condition;
	                if (cond == ConditionState.NotEstimated)
	                {
		                conditionState = Highlight.Blue;
		                if (mpd.Status != DirectiveStatus.Closed && mpd.IsApplicability && mpd.IsApplicability && mpd.Threshold.FirstPerformanceSinceNew.IsNullOrZero() && mpd.Threshold.RepeatInterval.IsNullOrZero())
			                conditionState = Highlight.Orange;
					}
                    if (cond == ConditionState.Notify)
                        conditionState = Highlight.Yellow;
                    if (cond == ConditionState.Overdue)
                        conditionState = Highlight.Red;
                    if (mpd.IsExtension)
	                    conditionState = Highlight.LightBlue;

                }
            }
            else if (item is NextPerformance performance)
            {
                conditionState = Highlight.White;
                cond = performance.Condition;
                if (cond == ConditionState.Notify)
                    conditionState = Highlight.Yellow;
                if (cond == ConditionState.Overdue)
                    conditionState = Highlight.Red;
                if (performance.BlockedByPackage != null)
                    conditionState = Highlight.DarkGreen;
                if (performance.Parent is IMtopCalc)
                {
	                if ((performance.Parent as IMtopCalc).IsExtension)
		                conditionState = Highlight.LightBlue;
                }
            }
			else if (item is Document)
			{
				var document = (Document)item;
				if (document.NextPerformanceIsBlocked)
				{
					conditionState = Highlight.DarkGreen;
				}
				else
				{
					cond = document.Condition;
					if (cond == ConditionState.NotEstimated)
						conditionState = Highlight.Blue;
					if (cond == ConditionState.Notify)
						conditionState = Highlight.Yellow;
					if (cond == ConditionState.Overdue)
						conditionState = Highlight.Red;
				}
			}
            else if (item is CheckLists)
            {
                var checkLists = (CheckLists)item;
                cond = checkLists.Condition;
                //if (cond == ConditionState.NotEstimated)
                //    conditionState = Highlight.Blue;
                //if (cond == ConditionState.Satisfactory)
                //    conditionState = Highlight.Green;
                if (cond == ConditionState.Notify)
                    conditionState = Highlight.Yellow;
                if (cond == ConditionState.Overdue)
                    conditionState = Highlight.Red;

                // if (checkLists.IsEditable)
                //     conditionState = Highlight.Green;
                // else conditionState = Highlight.Red;

            }
            else if (item is CAAEducationManagment)
            {
                var manual = (CAAEducationManagment)item;

                if (manual.Record == null)
                    return conditionState;
                
                if(manual.Record?.Settings?.NextCompliance == null)
                    return conditionState;
                
                cond = manual.Record.Settings.NextCompliance.Condition;
                //if (cond == ConditionState.NotEstimated)
                //    conditionState = Highlight.Blue;
                if (manual.Record.Settings.BlockedWpId.HasValue)
                    conditionState = Highlight.GrayLight;
                if (cond == ConditionState.Notify)
                    conditionState = Highlight.Yellow;
                if (cond == ConditionState.Overdue)
                    conditionState = Highlight.Red;
            }
            else if (item is StandartManual)
            {
                var manual = (StandartManual)item;
                cond = manual.Condition;
                //if (cond == ConditionState.NotEstimated)
                //    conditionState = Highlight.Blue;
                //if (cond == ConditionState.Satisfactory)
                //    conditionState = Highlight.Green;
                if (cond == ConditionState.Notify)
                    conditionState = Highlight.Yellow;
                if (cond == ConditionState.Overdue)
                    conditionState = Highlight.Red;
            }
            else if (item is SmartCore.CAA.ConcessionRequest)
            {
                var res = (ConcessionRequest)item;
                if (res.Status == ConcessionRequestStatus.Close)
                    conditionState = Highlight.Blue;
            }
            else if (item is Specialist)
            {
                var res = (Specialist)item;
                cond = res.Condition;
                if (cond == ConditionState.Notify)
                    conditionState = Highlight.Yellow;
                if (cond == ConditionState.Overdue)
                    conditionState = Highlight.Red;
            }
            return conditionState;
        }

        #endregion

        #region public static Color GetColor(object item)

        /// <summary>
        /// Возвращает цвет директивы в скрине
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Color GetColor(object item)
        {
            Highlight highlight = GetHighlight(item);
            return Color.FromArgb(highlight.Color);
        }

        #endregion

        #region public static string GetColorName(object item)

        /// <summary>
        /// Возвращает цвет директивы в скрине
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string GetColorName(object item)
        {
            Highlight highlight = GetHighlight(item);
            return highlight.FullName;
        }

        #endregion
    }
}