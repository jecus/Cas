using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CAS.UI.UIControls.DetailsControls;

namespace CAS.UI.UIControls.EngineeringOrdersDirectives
{
    /// <summary>
    /// Элемент управления для отображения условий выполнения инженерного задания
    /// </summary>
    public class EngineeringOrderDirectiveComplianceTermsControl : Control
    {

        #region Fields

        private readonly EngineeringOrderDirective directive;

        private InfoViewer complianceDataInfo;
        private readonly DateTimePicker dateTimePicker = new DateTimePicker();
        private readonly Label labelIntrodactionDate = new Label();
        private DateTime introdationDate;
        private bool introdactionDateModified = false;
        private const int MARGIN = 10;
        
        #endregion

        #region Constructors

        #region public EngineeringOrderDirectiveComplianceTermsControl()

        /// <summary>
        /// Создает элемент управления для отображения условий выполнения инженерного задания
        /// </summary>
        public EngineeringOrderDirectiveComplianceTermsControl()
        {
            InitializeComponents();
        }

        #endregion

        #region public EngineeringOrderDirectiveComplianceTermsControl(EngineeringOrderDirective directive)

        /// <summary>
        /// Создает элемент управления для отображения условий выполнения инженерного задания
        /// </summary>
        /// <param name="directive">Отображаемая директива</param>
        public EngineeringOrderDirectiveComplianceTermsControl(EngineeringOrderDirective directive)
        {
            InitializeComponents();

            this.directive = directive;
            directive.PerformSinceNew = false;
            directive.PerformSinceEffectivityDate = true;
            directive.RepeatedlyPerform = true;
            introdationDate = directive.EffectivityDate;
        }

        #endregion

        #endregion

        #region Properties

        #region private DateTime IntrodactionDate
        
        private DateTime IntrodactionDate
        {
            get { return introdationDate; }
            set
            {
                if (introdationDate != value) introdactionDateModified = true; else introdactionDateModified = false;
                introdationDate = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponents()

        private void InitializeComponents()
        {
            complianceDataInfo = new InfoViewer(4);
            //
            // labelIntrodactionDate
            //
            labelIntrodactionDate.AutoSize = true;
            Css.OrdinaryText.Adjust(labelIntrodactionDate);
            labelIntrodactionDate.Location = new Point(MARGIN+7,MARGIN);
            labelIntrodactionDate.Text = "Introdaction Date";
            //
            // dateTimePicker
            //
            dateTimePicker.Location = new Point(MARGIN+186, MARGIN);
            dateTimePicker.Width = 180;
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dd.MM.yyyy";
            dateTimePicker.ValueChanged += dateTimePicker_ValueChanged;
            Css.OrdinaryText.Adjust(dateTimePicker);

            //
            // complianceDataInfo
            //
            complianceDataInfo.LabelTitle.Height = 0;
            complianceDataInfo.LifeLengthViewers[0].ShowHeaders = true;
            complianceDataInfo.LifeLengthViewers[1].Enabled = false;
            complianceDataInfo.Location = new Point(MARGIN, dateTimePicker.Bottom + 2*MARGIN);
            complianceDataInfo.LeftHeaderWidth = 180;
            complianceDataInfo.LifeLengthViewers[0].LeftHeader = "Perfomance s/i.d";
            complianceDataInfo.LifeLengthViewers[1].LeftHeader = "Compliance Deadline";
            complianceDataInfo.LifeLengthViewers[2].LeftHeader = "Frequency";
            complianceDataInfo.LifeLengthViewers[3].LeftHeader = "Notify";
            complianceDataInfo.ReadOnly = false;
            complianceDataInfo.ShowMinutes = false;

            BackColor = Css.CommonAppearance.Colors.BackColor;
            Controls.Add(labelIntrodactionDate);
            Controls.Add(dateTimePicker);
            Controls.Add(complianceDataInfo);
            Size = new Size(complianceDataInfo.Width + MARGIN, complianceDataInfo.Height + 4 * MARGIN + dateTimePicker.Height );
        }

        
        #endregion

        #region public bool GetChangeStatus(bool directiveExist)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <param name="directiveExist">Показывает, существует ли уже директива или нет</param>
        /// <returns></returns>
        public bool GetChangeStatus(bool directiveExist)
        {
            if (directiveExist)

                return complianceDataInfo.Modified || introdactionDateModified;
            else
            {
                Lifelength emptyLifelength = new Lifelength();
                return (!(complianceDataInfo.LifeLengthViewers[0].Lifelength.Equals(emptyLifelength)) ||
                        !(complianceDataInfo.LifeLengthViewers[1].Lifelength.Equals(emptyLifelength)) ||
                        !(complianceDataInfo.LifeLengthViewers[2].Lifelength.Equals(emptyLifelength)) ||
                        !(complianceDataInfo.LifeLengthViewers[3].Lifelength.Equals(emptyLifelength)));
            }
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Заполняет поля для редактирования директивы
        /// </summary>
        public void UpdateInformation()
        {
            if (directive != null)
                UpdateInformation(directive);
        }

        #endregion

        #region public void UpdateInformation(EngineeringOrderDirective sourceDirective)

        /// <summary>
        /// 3аполняет поля для редактирования директивы
        /// </summary>
        /// <param name="sourceDirective"></param>
        public void UpdateInformation(EngineeringOrderDirective sourceDirective)
        {
            if (sourceDirective == null)
                throw new ArgumentNullException("sourceDirective");
            dateTimePicker.Value = sourceDirective.EffectivityDate;
            complianceDataInfo.LifeLengthViewers[0].Lifelength = sourceDirective.SinceEffectivityDatePerformanceLifelength;
            complianceDataInfo.LifeLengthViewers[1].Lifelength = sourceDirective.InspectedDetailLifelength;
            complianceDataInfo.LifeLengthViewers[2].Lifelength = sourceDirective.RepeatPerform;
            complianceDataInfo.LifeLengthViewers[3].Lifelength = sourceDirective.Notification;

            //bool permission = ;

            complianceDataInfo.ReadOnly = !directive.HasPermission(Users.CurrentUser, DataEvent.Update);
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public void SaveData()
        {
            if (directive != null)
            {
                SaveData(directive);
            }
        }

        #endregion

        #region public void SaveData(EngineeringOrderDirective destinationDirective)

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        /// <param name="destinationDirective">Директива</param>
        public void SaveData(EngineeringOrderDirective destinationDirective)
        {
            destinationDirective.EffectivityDate = IntrodactionDate;
            complianceDataInfo.LifeLengthViewers[0].SaveData(destinationDirective.SinceEffectivityDatePerformanceLifelength);
            complianceDataInfo.LifeLengthViewers[2].SaveData(destinationDirective.RepeatPerform);
            complianceDataInfo.LifeLengthViewers[3].SaveData(destinationDirective.Notification);
        }
        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            complianceDataInfo.LifeLengthViewers[0].Lifelength = new Lifelength();
            complianceDataInfo.LifeLengthViewers[1].Lifelength = new Lifelength();
            complianceDataInfo.LifeLengthViewers[2].Lifelength = new Lifelength();
            complianceDataInfo.LifeLengthViewers[3].Lifelength = new Lifelength();
        }

        #endregion

        #region void dateTimePicker_ValueChanged(object sender, EventArgs e)

        void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            IntrodactionDate = dateTimePicker.Value;
        }

        #endregion
        
        #endregion
    }
}
