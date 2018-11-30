using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.General.Atlbs;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls.AircraftFlightLight
{


    /*
     * Общий принцип - пользователю всегда отображается минимум 4 отклонения и те отклонения которые он заполнил сохраняются в базу данных
     * Если на форме отображается 4 отклонения но заполнено только одно, это означает, что во время полета было обнаружено только одно отклонение
     */

    /// <summary>
    /// Строит список отклонений воздушного судна
    /// </summary>
    public partial class DiscrepanciesListControlLight : Interfaces.EditObjectControl
    {

        #region public AircraftFlight Flight
        /// <summary>
        /// Полет, с которым связан контрол
        /// </summary>
        public AircraftFlight Flight
        {
            get { return AttachedObject as AircraftFlight; }
        }
        #endregion

        public int _discrepanciesCount;

        private string _station;

        private DateTime _rtsDate = DateTime.Today;
        /*
         * 
         */

        #region public DateTime RTSDate
        ///<summary>
        /// Возвращает или задает дату выпуска в сервис
        ///</summary>
        public DateTime RTSDate
        {
            get
            {
                foreach (Control c in panelDiscrepancies.Controls)
                {
                    if (!(c is DiscrepancyControlLight))
                        continue;

                    return ((DiscrepancyControlLight)c).RTSDate;
                }
                return DateTime.Today;
            }
            set
            {
                _rtsDate = value;
                foreach (Control c in panelDiscrepancies.Controls)
                {
                    if (!(c is DiscrepancyControlLight))
                        continue;

                    ((DiscrepancyControlLight)c).RTSDate = _rtsDate;
                }
            }
        }
        #endregion

        #region public String Station
        ///<summary>
        /// Возвращает или задает станцию выпуска в сервис
        ///</summary>
        public String Station
        {
            get
            {
                foreach (Control c in panelDiscrepancies.Controls)
                {
                    if (!(c is DiscrepancyControlLight))
                        continue;

                    return ((DiscrepancyControlLight)c).Station;
                }
                return "";
            }
            set
            {
                _station = value;
                foreach (Control c in panelDiscrepancies.Controls)
                {
                    if (!(c is DiscrepancyControl))
                        continue;

                    ((DiscrepancyControl)c).Station = _station;
                }
            }
        }

		#endregion

		#region public List<Discrepancy> Discrepancies { get; set; }

		public List<Discrepancy> Discrepancies { get; set; }

	    #endregion
		/*
         * Конструктор
         */

		#region public DiscrepanciesListControlLight()
		/// <summary>
		/// Пустой конструктор
		/// </summary>
		public DiscrepanciesListControlLight()
        {
            InitializeComponent();
            FillControls();
        }
        #endregion

        /*
         * Перегружаемые методы
         */

        #region public override void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        public override void ApplyChanges()
        {

            // Применяем сделанные изменения объектам
            for (int i = 0; i < panelDiscrepancies.Controls.Count; i++)
            {
	            var d = panelDiscrepancies.Controls[i] as DiscrepancyControlLight;
                if (d != null && !d.IsNull)
                {
                    d.ApplyChanges();

                    if (d.Discrepancy == null || d.Discrepancy.ItemId <= 0)
                    {
                        //Новый Discrepancy, добавляем его в AircraftFlight
                        Flight.Discrepancies.Add(d.Discrepancy);
                    }
                }
            }

            for (int i = 0; i < panelMEL.Controls.Count; i++)
            {
	            var d = panelMEL.Controls[i] as DiscrepancyControlLight;
                if (d != null && !d.IsNull)
                {
                    d.ApplyChanges();

                    if (d.Discrepancy == null || d.Discrepancy.ItemId <= 0)
                    {
                        //Новый Discrepancy, добавляем его в AircraftFlight
                        Flight.Discrepancies.Add(d.Discrepancy);
                    }
                }
            }
            // Теперь мы должны сохранить сам объект а потом добавить только что созданные отклонения 


            //
            base.ApplyChanges();

            #region// Освобождение панелей от контролов

            var dcs = panelDiscrepancies.Controls.OfType<DiscrepancyControlLight>().ToList();
            dcs.AddRange(panelMEL.Controls.OfType<DiscrepancyControlLight>());

            panelDiscrepancies.Controls.Clear();
            panelMEL.Controls.Clear();

            #endregion

            #region Добавление неисправностей

            var discrepancies = dcs.Where(d => d.Discrepancy != null && d.Discrepancy.DirectiveId <= 0).ToList();
            int count = discrepancies.Count;

            for (int i = 0; i < count; i++)
            {
                // Добавляем разделитель
                if (i > 0)
                {
                    var delimiter = new Delimiter
                    {
                        Style = DelimiterStyle.Solid,
                        Orientation = DelimiterOrientation.Horizontal,
                        Margin = new Padding(0, 10, 0, 10),
                        Width = 1000
                    };
                    panelDiscrepancies.Controls.Add(delimiter);
                }
                discrepancies[i].EnableExtendedControl = count >= 2;
                panelDiscrepancies.Controls.Add(discrepancies[i]);
            }
            panelDiscrepancies.Controls.Add(panelAdd);

            #endregion

            #region Добавление неисправностей MEL

            var mels = dcs.Where(d => d.Discrepancy != null && d.Discrepancy.DirectiveId > 0).ToList();
            count = mels.Count();

            for (int i = 0; i < count; i++)
            {
                // Добавляем разделитель
                if (i > 0)
                {
                    Delimiter delimiter = new Delimiter
                    {
                        Style = DelimiterStyle.Solid,
                        Orientation = DelimiterOrientation.Horizontal,
                        Margin = new Padding(0, 10, 0, 10),
                        Width = 1000
                    };
                    panelMEL.Controls.Add(delimiter);
                }
                mels[i].EnableExtendedControl = count >= 2;
                panelMEL.Controls.Add(mels[i]);
            }

            #endregion
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {
			BuildControls();
        }
        #endregion

        #region public override bool CheckData()
        /// <summary>
        /// Проверяет введенные данные.
        /// Если какое-либо поле не подходит по формату, следует сразу кидать MessageBox, ставить курсор в необходимое поле и возвращать false в качестве результата метода
        /// </summary>
        /// <returns></returns>
        public override bool CheckData()
        {
            var dcs = new List<DiscrepancyControlLight>();
            dcs.AddRange(panelDiscrepancies.Controls.OfType<DiscrepancyControlLight>());
            dcs.AddRange(panelMEL.Controls.OfType<DiscrepancyControlLight>());

            if (dcs.Any(dc => dcs.Count(c => c.Index == dc.Index) > 1))
            {
                MessageBox.Show("Do not create two or more discrepancies with one order num", 
                                (string) new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                return false;
            }
            // Проверяем введенные данные
            // Проверяем только те отклонения которые реально были вбиты пользователем (!d.IsNull));
            return dcs.Where(dc => dc != null && !dc.IsNull).All(dc => dc.CheckData());
        }
        #endregion

        /*
         * Реализация
         */

        #region private void BuildControls()
        /// <summary>
        /// Строит нужные контролы
        /// </summary>
        private void BuildControls()
        {
            #region// Освобождение панелей от контролов
            
            foreach (Control control in panelDiscrepancies.Controls)
            {
                if (control is DiscrepancyControlLight)
                {
                    ((DiscrepancyControlLight) control).Deleted -= ConditionControlDeleted;
                    control.Dispose();
                }
                else if (control != panelAdd)
                {
                    control.Dispose();
                }
            }
            panelDiscrepancies.Controls.Clear();

            foreach (Control control in panelMEL.Controls)
            {
                if (control is DiscrepancyControlLight)
                {
                    ((DiscrepancyControlLight)control).Deleted -= ConditionControlDeleted;
                    control.Dispose();
                }
            }
            panelMEL.Controls.Clear();

            foreach (Control control in panelOldMEL.Controls)
            {
                if (control is DiscrepancyControlLight)
                {
                    ((DiscrepancyControlLight)control).Deleted -= ConditionControlDeleted;
                    control.Dispose();
                }
            }
            panelOldMEL.Controls.Clear();

            #endregion

            #region Добавление неисправностей

            var discrepancies = Flight != null && Flight.Discrepancies != null
                                              ? Flight.Discrepancies.Where(d => d.DirectiveId <= 0).ToList()
                                              : new List<Discrepancy>();
            int count = discrepancies.Count;

            for (int i = 0; i < count; i++)
            {
                // Добавляем разделитель
                if (i > 0)
                {
                    Delimiter delimiter = new Delimiter
                                              {
                                                  Style = DelimiterStyle.Solid,
                                                  Orientation = DelimiterOrientation.Horizontal,
                                                  Margin = new Padding(0, 10, 0, 10),
                                                  Width = 1000
                                              };
                    panelDiscrepancies.Controls.Add(delimiter);
                }

                // Добавляем контрол - неисправность
                _discrepanciesCount++;
	            DiscrepancyControlLight d = new DiscrepancyControlLight
				{
                                               Index = _discrepanciesCount,
                                               EnableExtendedControl = count >= 2,
											   _discrepancies = Discrepancies
                                           };
                d.Deleted += ConditionControlDeleted;
                if (Flight != null && i < discrepancies.Count)
                {
                    d.Discrepancy = discrepancies[i];
                    if (discrepancies[i].Description == "")
                    {
                        d.Discrepancy.Description = "No";
                    }
                }
                else if (Flight != null) // Не будем создавать Discrepancy, если объект Flight не задан - черевато дальнейшими ошибками
                {
                    Discrepancy discrepancy = new Discrepancy();
                    d.Discrepancy = discrepancy;
                }
                _discrepanciesCount++;
                panelDiscrepancies.Controls.Add(d);
            }
            panelDiscrepancies.Controls.Add(panelAdd);
           
            #endregion

            #region Добавление неисправностей MEL

            var mels = Flight != null && Flight.Discrepancies != null
                                              ? Flight.Discrepancies.Where(d => d.DirectiveId > 0).ToList()
                                              : new List<Discrepancy>();
            count = mels.Count();

            for (int i = 0; i < count; i++)
            {
                // Добавляем разделитель
                if (i > 0)
                {
                    Delimiter delimiter = new Delimiter
                    {
                        Style = DelimiterStyle.Solid,
                        Orientation = DelimiterOrientation.Horizontal,
                        Margin = new Padding(0, 10, 0, 10),
                        Width = 1000
                    };
                    panelMEL.Controls.Add(delimiter);
                }

                // Добавляем контрол - неисправность
                _discrepanciesCount++;
	            DiscrepancyControlLight d = new DiscrepancyControlLight
				{
                                               Index = _discrepanciesCount,
                                               EnableExtendedControl = count >= 2
                                           };
                d.Deleted += ConditionControlDeleted;
                if (Flight != null && i < mels.Count())
                {
                    d.Discrepancy = mels[i];
                    if (mels[i].Description == "")
                    {
                        d.Discrepancy.Description = "No";
                    }
                }
                else if (Flight != null) // Не будем создавать Discrepancy, если объект Flight не задан - черевато дальнейшими ошибками
                {
                    Discrepancy discrepancy = new Discrepancy();
                    d.Discrepancy = discrepancy;
                }
                _discrepanciesCount++;
                panelMEL.Controls.Add(d);
            }

            #endregion

            #region Добавление неисправностей с прошлых полетов, незакрытых на тек. полет 

            count = 0;
            if (Flight != null && Flight.UnclosedDiscrepancies != null) count = Flight.UnclosedDiscrepancies.Count;

            for (int i = 0; i < count; i++)
            {
                // Добавляем разделитель
                if (i > 0)
                {
                    Delimiter delimiter = new Delimiter
                    {
                        Style = DelimiterStyle.Solid,
                        Orientation = DelimiterOrientation.Horizontal,
                        Margin = new Padding(0, 10, 0, 10),
                        Width = 1000
                    };
                    panelOldMEL.Controls.Add(delimiter);
                }

				// Добавляем контрол - неисправность
	            var d = new DiscrepancyControlLight
				{
                                               EnableExtendedControl = count >= 2
                                           };

                d.Deleted += ConditionControlDeleted;
                if (Flight != null && Flight.UnclosedDiscrepancies != null && i < Flight.UnclosedDiscrepancies.Count)
                {
                    d.Discrepancy = Flight.UnclosedDiscrepancies[i];
                    if (Flight.UnclosedDiscrepancies[i].Description == "")
                    {
                        d.Discrepancy.Description = "No";
                    }
                }
                else if (Flight != null) // Не будем создавать Discrepancy, если объект Flight не задан - черевато дальнейшими ошибками
                {
                    Discrepancy discrepancy = new Discrepancy();
                    d.Discrepancy = discrepancy;
                }
                panelOldMEL.Controls.Add(d);
            }

            #endregion
        }
        #endregion

        #region protected override void OnSizeChanged(EventArgs e)
        /// <summary>
        /// При изменении размера контрола расширяем Flow Layout Panel т.к. сама она этого делать не умеет )
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            if(panelDiscrepancies != null)panelDiscrepancies.Dock = DockStyle.Fill;
            base.OnSizeChanged(e);
        }
        #endregion

        #region private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void LinkLabelAddNewLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelDiscrepancies.Controls.Remove(panelAdd);
            // Добавляем контрол - неисправность
            _discrepanciesCount++;
            var d = new DiscrepancyControlLight(new Discrepancy{ParentFlight = Flight}, Discrepancies);
            d.Index = _discrepanciesCount;
            d.Station = _station;
            d.RTSDate = _rtsDate;
            d.Extended = true;
            d.EnableExtendedControl = false;
            d.Deleted += ConditionControlDeleted;

            panelDiscrepancies.Controls.Add(d);
            panelDiscrepancies.Controls.Add(panelAdd);

            if (panelDiscrepancies.Controls.OfType<DiscrepancyControlLight>().Count() >= 4)
                linkLabelAddNew.Enabled = false;
        }
        #endregion

        #region private void ConditionControlDeleted(object sender, EventArgs e)

        private void ConditionControlDeleted(object sender, EventArgs e)
        {
	        DiscrepancyControlLight control = (DiscrepancyControlLight)sender;
            Discrepancy cond = control.Discrepancy;

            if (cond.ItemId > 0 && MessageBox.Show("Do you really want to delete Discrepancy?", "Deleting confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //если информация о состоянии сохранена в БД 
                //и получен положительный ответ на ее удаление
                try
                {
                    GlobalObjects.CasEnvironment.NewKeeper.Delete(cond);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while removing data", ex);
                }

                if (panelDiscrepancies.Controls.Contains(control))
                    panelDiscrepancies.Controls.Remove(control);
                else if (panelMEL.Controls.Contains(control))
                    panelMEL.Controls.Remove(control);
                else if (panelOldMEL.Controls.Contains(control))
                    panelOldMEL.Controls.Remove(control);

                control.Deleted -= ConditionControlDeleted;
                control.Dispose();
            }
            else if (cond.ItemId <= 0)
            {
                if (panelDiscrepancies.Controls.Contains(control))
                    panelDiscrepancies.Controls.Remove(control);
                else if (panelMEL.Controls.Contains(control))
                    panelMEL.Controls.Remove(control);
                else if (panelOldMEL.Controls.Contains(control))
                    panelOldMEL.Controls.Remove(control);
                control.Deleted -= ConditionControlDeleted;
                control.Dispose();
            }

            if (panelDiscrepancies.Controls.OfType<DiscrepancyControlLight>().Count() < 4)
                linkLabelAddNew.Enabled = true;
        }

        #endregion

    }
}


