using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.UIControls.DirectivesControls;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    /// <summary>
    /// Класс отображает список 
    /// </summary>
    public partial class DiscrepancyControlLight : Interfaces.EditObjectControl
    {
        private bool _showDeferredInfoPanel;
        private CommonCollection<Specialist> _specialists = new CommonCollection<Specialist>();
        /*
         * Свойства 
         */
        #region public Discrepancy Discrepancy
        /// <summary>
        /// Отклонение, с которым связан контрол
        /// </summary>
        public Discrepancy Discrepancy
        {
            get { return AttachedObject as Discrepancy; }
            set { AttachedObject = value; }
        }
        #endregion

        #region public bool EnableExtendedControl
        ///<summary>
        /// Возвращает или задает значение видна ли панель расширения
        ///</summary>
        public bool EnableExtendedControl
        {
            get { return panelExtendable.Visible; }
            set
            {
                panelExtendable.Visible = value;
                if (value == false)
                {
                    extendableRichContainer.Extended = true;

                    //panelMain.Visible = true;
                    //panelRelease.Visible = true;
                    //panelDeferredInfo.Visible = _showDeferredInfoPanel;
                }
            }
        }
        #endregion

        #region public bool Extended
        ///<summary>
        /// Возвращает или задает значение Показывается ли елемент развернутым
        ///</summary>
        public bool Extended
        {
            get { return panelMain.Visible; }
            set
            {
                extendableRichContainer.Extended = value;
                panelMain.Visible = value;
                panelRelease.Visible = value;
            }
        }
        #endregion

        #region public bool IsNull
        /// <summary>
        /// Свойство показывает, нужно ли сохранять отклонение или нет. 
        /// Были ли введенны данные в элемент или нет
        /// </summary>
        public bool IsNull
        {
            get
            {
                return textDescription.Text.Trim() == "";
            }
        }
        #endregion

        #region private int _index;
        /// <summary>
        /// Номер элемента
        /// </summary>
        public int Index
        {
            get { return (int)numericUpDownIndex.Value; }
            set
            {
                if (value > numericUpDownIndex.Maximum)
                    numericUpDownIndex.Value = numericUpDownIndex.Maximum;
                else if (value < numericUpDownIndex.Minimum)
                    numericUpDownIndex.Value = numericUpDownIndex.Minimum;
                else numericUpDownIndex.Value = value;
            }
        }
        #endregion

        /*
         * Конструктор
         */

        #region public DiscrepancyControl()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public DiscrepancyControlLight()
        {
            InitializeComponent();
        }
        #endregion

        #region public DiscrepancyControl(Discrepancy discrepancy) : this ()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public DiscrepancyControlLight(Discrepancy discrepancy) : this ()
        {
            AttachedObject = discrepancy;
        }
        #endregion

        /*
         * Перегруженные методы 
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
            if (Discrepancy != null)
            {
                Discrepancy.Num = (int)numericUpDownIndex.Value;
                //Discrepancy.FilledBy = radioCrew.Checked ? DiscrepancyFilledByEnum.Crew : DiscrepancyFilledByEnum.MaintenanceStaff;
                Discrepancy.FilledBy = radioCrew.Checked ? false /*DiscrepancyFilledByEnum.Crew*/ 
                                                         : true /*DiscrepancyFilledByEnum.MaintenanceStaff*/;
                Discrepancy.Description = textDescription.Text;
                Discrepancy.ATAChapter = ataChapterComboBox.ATAChapter;

                if (Discrepancy.CorrectiveAction != null)
                {
                    Discrepancy.CorrectiveAction.Description = textCorrectiveAction.Text;
                    Discrepancy.CorrectiveAction.PartNumberOn = textPNOn.Text;
                    Discrepancy.CorrectiveAction.PartNumberOff = textPNOff.Text;
                    Discrepancy.CorrectiveAction.SerialNumberOn = textSNOn.Text;
                    Discrepancy.CorrectiveAction.SerialNumberOff = textSNOff.Text;
                }

                SetExtendableControlCaption();
            }
            
            base.ApplyChanges();
        }
        #endregion

        #region public override void FillControls()
        /// <summary>
        /// Обновляет значения полей
        /// </summary>
        public override void FillControls()
        {
            BeginUpdate();
            
            ataChapterComboBox.UpdateInformation();

            #region lookupComboboxFlight

            if(Discrepancy != null && Discrepancy.ItemId > 0 && Discrepancy.DirectiveId > 0)
            {
				var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Discrepancy.ParentFlight.AircraftId);

                ATLB parentAtlb = null;
                try
                {
                    parentAtlb = GlobalObjects.CasEnvironment.Loader.GetObject<ATLB>(Discrepancy.ParentFlight.ATLBId);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while load linked ATLB fo Discrepancy", ex);
                }
            }

            #endregion

            _specialists.Clear();
            try
            {
                _specialists.AddRange(GlobalObjects.CasEnvironment.Loader.GetObjectList<Specialist>());
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while load Specialist fo Discrepancy", ex);
            }

            if (Discrepancy != null)
            {
                radioCrew.Checked = Discrepancy.FilledBy == false;// DiscrepancyFilledByEnum.Crew;
                radioMaintenanceStaff.Checked = Discrepancy.FilledBy;//DiscrepancyFilledByEnum.MaintenanceStaff;
                ataChapterComboBox.ATAChapter = Discrepancy.ATAChapter;
              //  radioOpen.Checked = Discrepancy.correctiveAction.Status == CorrectiveActionStatus.Open;
              //  radioClose.Checked = Discrepancy.correctiveAction.Status == CorrectiveActionStatus.Close;
                textDescription.Text = Discrepancy.Description ?? "No";
                if(Discrepancy.Num > numericUpDownIndex.Maximum)
                    numericUpDownIndex.Value = numericUpDownIndex.Maximum;
                else if (Discrepancy.Num < numericUpDownIndex.Minimum)
                    numericUpDownIndex.Value = numericUpDownIndex.Minimum;
                else numericUpDownIndex.Value = Discrepancy.Num;

                if (Discrepancy.DeferredItem != null)
                {
                    ataChapterComboBox.Enabled = false;
                    ataChapterComboBox.ATAChapter = Discrepancy.DeferredItem.ATAChapter;

                    _showDeferredInfoPanel = true;
                    

                    
                }
                else
                {
                    _showDeferredInfoPanel = false;
                }


                if (Discrepancy.CorrectiveAction != null)
                {
                    textCorrectiveAction.Text = Discrepancy.CorrectiveAction.Description ?? "No";
                    textPNOff.Text = Discrepancy.CorrectiveAction.PartNumberOff;
                    textSNOff.Text = Discrepancy.CorrectiveAction.SerialNumberOff;
                    textPNOn.Text = Discrepancy.CorrectiveAction.PartNumberOn;
                    textSNOn.Text = Discrepancy.CorrectiveAction.SerialNumberOn;
                }
                else
                {
                    textCorrectiveAction.Text = "No";
                    textPNOff.Text = textSNOff.Text = textPNOn.Text = textSNOn.Text = "";
                }

            }
            else
            {
                textDescription.Text = "What Where When Extent";
            }

            SetExtendableControlCaption();

            EndUpdate();
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

            // Существует ли введенная ATA глава
            // Если ATA глава не задана то берется N/A

            // Выбраны ли поля Open / Close или Crew / Maintenance Staff
            if (!radioCrew.Checked && !radioMaintenanceStaff.Checked)
            {
                MessageBox.Show ("Select one of the Crew or Maintenance Staff radio buttons.");
                return false;
            }


            // Правильность ввода даты
            if (!ValidateRTSDate()) return false;

            //
            return true;
        }
        #endregion

        /*
         * Реализация
         */

        #region private bool ValidateRTSDate()
        /// <summary>
        /// Проверяем введенную дату
        /// </summary>
        /// <returns></returns>
        private bool ValidateRTSDate()
        {
            //
            return true;
        }
        #endregion

        #region private void ButtonDeleteClick(object sender, EventArgs e)
        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            if (Deleted != null)
                Deleted(this, EventArgs.Empty);
        }
        #endregion

        #region private void ExtendableRichContainerExtending(object sender, EventArgs e)
        private void ExtendableRichContainerExtending(object sender, EventArgs e)
        {
            panelMain.Visible = panelRelease.Visible = extendableRichContainer.Extended;
        }
        #endregion

        #region private void SetExtendableControlCaption()
        private void SetExtendableControlCaption()
        {
            extendableRichContainer.labelCaption.Text = "";

            if (Discrepancy != null)
            {
                extendableRichContainer.labelCaption.Text = "" + Discrepancy.Num;

                if (Discrepancy.DeferredItem != null)
                    extendableRichContainer.labelCaption.Text += " MEL:" + Discrepancy.DeferredItem;

            }

        }
        #endregion


        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;

        #endregion

    }
}

