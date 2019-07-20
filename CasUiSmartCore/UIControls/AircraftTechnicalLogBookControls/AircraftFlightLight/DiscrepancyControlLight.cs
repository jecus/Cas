using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using EntityCore.DTO.General;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls.AircraftFlightLight
{
    /// <summary>
    /// Класс отображает список 
    /// </summary>
    public partial class DiscrepancyControlLight : Interfaces.EditObjectControl
    {
	    public List<Discrepancy> _discrepancies = new List<Discrepancy>();
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

        #region public DateTime RTSDate
        ///<summary>
        /// Возвращает или задает дату выпуска в сервис
        ///</summary>
        public DateTime RTSDate
        {
            get { return dateTimePickerRTSDate.Value; }
            set
            {
                if (Discrepancy == null || Discrepancy.ItemId < 0)
                    dateTimePickerRTSDate.Value = value;
            }
        }
        #endregion

        #region public DateTime Station
        ///<summary>
        /// Возвращает или задает станцию выпуска в сервис
        ///</summary>
        public string Station
        {
            get { return textStation.Text; }
            set
            {
                if (Discrepancy == null || Discrepancy.ItemId < 0)
                    textStation.Text = value;
            }
        }


		#endregion

		/*
         * Конструктор
         */

		#region public DiscrepancyControlLight()
		/// <summary>
		/// Пустой конструктор
		/// </summary>
		public DiscrepancyControlLight()
        {
            InitializeComponent();
        }
		#endregion

		#region public DiscrepancyControlLight(Discrepancy discrepancy) : this ()
		/// <summary>
		/// Пустой конструктор
		/// </summary>
		public DiscrepancyControlLight(Discrepancy discrepancy, List<Discrepancy> discrepancies) : this ()
		{
			_discrepancies.AddRange(discrepancies);
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
                Discrepancy.FilledBy = radioCrew.Checked ? false /*DiscrepancyFilledByEnum.Crew*/ 
                                                         : true /*DiscrepancyFilledByEnum.MaintenanceStaff*/;
                Discrepancy.Description = textDescription.Text;
	            Discrepancy.IsReliability = checkBoxReliability.Checked;
				Discrepancy.ATAChapter = ataChapterComboBox.ATAChapter;

                if (Discrepancy.CorrectiveAction != null)
                {
                    Discrepancy.CorrectiveAction.Description = textCorrectiveAction.Text;
                    Discrepancy.CorrectiveAction.PartNumberOn = textPNOn.Text;
                    Discrepancy.CorrectiveAction.PartNumberOff = textPNOff.Text;
                    Discrepancy.CorrectiveAction.SerialNumberOn = textSNOn.Text;
                    Discrepancy.CorrectiveAction.SerialNumberOff = textSNOff.Text;
                }

                if (Discrepancy.CertificateOfReleaseToService != null)
                {
                    Discrepancy.CertificateOfReleaseToService.Station = textStation.Text;
                    Discrepancy.CertificateOfReleaseToService.RecordDate = dateTimePickerRTSDate.Value;
                    Discrepancy.CertificateOfReleaseToService.AuthorizationB1 = comboSpecialist1.SelectedItem as Specialist;
                    Discrepancy.CertificateOfReleaseToService.AuthorizationB2 = comboSpecialist2.SelectedItem as Specialist;
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

			TemplateComboBox.Items.Clear();
			TemplateComboBox.Items.AddRange(_discrepancies.ToArray());

	        TemplateComboBox.SelectedItem = _discrepancies.FirstOrDefault(
					 d => d.ATAChapter != null && d.ATAChapter.Equals(Discrepancy.ATAChapter) &&
		             d.CertificateOfReleaseToService != null &&
		             d.CertificateOfReleaseToService.AuthorizationB1.Equals(d.CertificateOfReleaseToService.AuthorizationB1) &&
		             d.CertificateOfReleaseToService.AuthorizationB2.Equals(d.CertificateOfReleaseToService.AuthorizationB2) &&
		             d.CertificateOfReleaseToService.Station.Equals(d.CertificateOfReleaseToService.Station) &&
		             d.CorrectiveAction != null &&
		             d.CorrectiveAction.Description.Equals(d.CorrectiveAction.Description) &&
		             d.CorrectiveAction.PartNumberOff.Equals(d.CorrectiveAction.PartNumberOff) &&
		             d.CorrectiveAction.PartNumberOn.Equals(d.CorrectiveAction.PartNumberOn) &&
		             d.CorrectiveAction.SerialNumberOff.Equals(d.CorrectiveAction.SerialNumberOff) &&
		             d.CorrectiveAction.SerialNumberOn.Equals(d.CorrectiveAction.SerialNumberOn));

			#region lookupComboboxDeferred

			if (Discrepancy != null)
            {
				var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Discrepancy.ParentFlight.AircraftId);
	            
				string displayerText = 
                    aircraft.RegistrationNumber + ". " + 
                    DirectiveType.DeferredItems.CommonName; 
            }
            
            #endregion

            #region lookupComboboxFlight

            if(Discrepancy != null && Discrepancy.ItemId > 0 && Discrepancy.DirectiveId > 0)
            {
				var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Discrepancy.ParentFlight.AircraftId);

                ATLB parentAtlb = null;
                try
                {
                    parentAtlb = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<ATLBDTO, ATLB>(Discrepancy.ParentFlight.ATLBId);
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
				_specialists.AddRange(GlobalObjects.CasEnvironment.Loader.GetObjectListAll<Specialist>(loadChild: true).Where(i => i.Specialization?.Department?.FullName == "Line Maintenance"));
			}
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while load Specialist fo Discrepancy", ex);
            }

            if (Discrepancy != null)
            {
                comboSpecialist1.Items.AddRange(_specialists.ToArray());
                comboSpecialist2.Items.AddRange(_specialists.ToArray());
                radioCrew.Checked = Discrepancy.FilledBy == false;// DiscrepancyFilledByEnum.Crew;
                radioMaintenanceStaff.Checked = Discrepancy.FilledBy;//DiscrepancyFilledByEnum.MaintenanceStaff;
                ataChapterComboBox.ATAChapter = Discrepancy.ATAChapter;
              //  radioOpen.Checked = Discrepancy.correctiveAction.Status == CorrectiveActionStatus.Open;
              //  radioClose.Checked = Discrepancy.correctiveAction.Status == CorrectiveActionStatus.Close;
                textDescription.Text = Discrepancy.Description ?? "No";
	            checkBoxReliability.Checked = Discrepancy.IsReliability;
				if (Discrepancy.Num > numericUpDownIndex.Maximum)
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

                if (Discrepancy.CertificateOfReleaseToService != null)
                {
                    textStation.Text = Discrepancy.CertificateOfReleaseToService.Station;
                    dateTimePickerRTSDate.Value = Discrepancy.CertificateOfReleaseToService.RecordDate;
                    if(Discrepancy.CertificateOfReleaseToService.AuthorizationB1 != null)
                    {
                        Specialist selectedSpec = _specialists.GetItemById(Discrepancy.CertificateOfReleaseToService.AuthorizationB1.ItemId);
                        if (selectedSpec != null)
                            comboSpecialist1.SelectedItem = selectedSpec;
                        else
                        {
                            //Искомый специалист недействителен
                            comboSpecialist1.Items.Add(Discrepancy.CertificateOfReleaseToService.AuthorizationB1);
                            comboSpecialist1.SelectedItem = Discrepancy.CertificateOfReleaseToService.AuthorizationB1;
                        }
                        comboSpecialist1.BackColor =
                          ((Specialist)comboSpecialist1.SelectedItem).IsDeleted
                          ? Color.FromArgb(Highlight.Red.Color)
                          : Color.White;   
                    }
                    if (Discrepancy.CertificateOfReleaseToService.AuthorizationB2 != null)
                    {
                        Specialist selectedSpec = _specialists.GetItemById(Discrepancy.CertificateOfReleaseToService.AuthorizationB2.ItemId);
                        if (selectedSpec != null)
                            comboSpecialist2.SelectedItem = selectedSpec;
                        else
                        {
                            //Искомый специалист недействителен
                            comboSpecialist2.Items.Add(Discrepancy.CertificateOfReleaseToService.AuthorizationB2);
                            comboSpecialist2.SelectedItem = Discrepancy.CertificateOfReleaseToService.AuthorizationB2;
                        }
                        comboSpecialist2.BackColor =
                                ((Specialist)comboSpecialist2.SelectedItem).IsDeleted
                                    ? Color.FromArgb(Highlight.Red.Color)
                                    : Color.White;    
                    }
                }
                else
                {
                    textStation.Text =  "";
                    comboSpecialist1.SelectedItem = null;
                    comboSpecialist2.SelectedItem = null;
                    dateTimePickerRTSDate.Value = DateTime.Today;
                }
            }
            else
            {
                dateTimePickerRTSDate.Value = DateTime.Today;
                comboSpecialist1.SelectedItem = null;
                comboSpecialist2.SelectedItem = null;
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

        #region private void LookupComboboxDeferredSelectedIndexChanged(object sender, EventArgs e)
        private void LookupComboboxDeferredSelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        #endregion

        #region Events
        /// <summary>
        /// </summary>
        public event EventHandler Deleted;

		#endregion

		#region private void TemplateComboBox_SelectedIndexChanged(object sender, EventArgs e)

		private void TemplateComboBox_SelectedIndexChanged(object sender, EventArgs e)
	    {
		    var selecteItem = TemplateComboBox.SelectedItem as Discrepancy;

		    if (selecteItem != null)
		    {
			    radioCrew.Checked = true;
			    textDescription.Text = selecteItem.Description;
			    ataChapterComboBox.ATAChapter = selecteItem.ATAChapter;

			    if (selecteItem.CorrectiveAction != null)
			    {
				    textCorrectiveAction.Text = selecteItem.CorrectiveAction.Description;
				    textPNOn.Text = selecteItem.CorrectiveAction.PartNumberOn;
				    textPNOff.Text = selecteItem.CorrectiveAction.PartNumberOff;
				    textSNOn.Text = selecteItem.CorrectiveAction.SerialNumberOn;
				    textSNOff.Text = selecteItem.CorrectiveAction.SerialNumberOff;
			    }

			    if (selecteItem.CertificateOfReleaseToService != null)
			    {
				    textStation.Text = selecteItem.CertificateOfReleaseToService.Station;
				    dateTimePickerRTSDate.Value = selecteItem.CertificateOfReleaseToService.RecordDate;
				    comboSpecialist1.SelectedItem = selecteItem.CertificateOfReleaseToService.AuthorizationB1;
				    comboSpecialist2.SelectedItem = selecteItem.CertificateOfReleaseToService.AuthorizationB2;
			    }
		    }
	    }

		#endregion

		#region private void TemplateComboBox_TextUpdate(object sender, System.EventArgs e)

		private void TemplateComboBox_TextUpdate(object sender, EventArgs e)
	    {
		    var _filterString = TemplateComboBox.Text;

		    TemplateComboBox.Items.Clear();

		    foreach (var dic in _discrepancies.Where(i => i.ToString().ToLowerInvariant().Contains(_filterString.ToLowerInvariant())))
		    {
			    TemplateComboBox.Items.Add(dic);
		    }

		    TemplateComboBox.DropDownStyle = ComboBoxStyle.DropDown;
		    TemplateComboBox.SelectionStart = _filterString.Length;
	    }

	    #endregion
	}
}

