using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.DirectivesControls;
using CASTerms;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.WorkPackage;

namespace CAS.UI.UIControls.AircraftTechnicalLogBookControls
{
    /// <summary>
    /// Класс отображает список 
    /// </summary>
    public partial class DiscrepancyControl : Interfaces.EditObjectControl
    {
	    public List<TransferRecord> _transferRecords = new List<TransferRecord>();
	    public List<Discrepancy> _discrepancies = new List<Discrepancy>();
	    public List<WorkPackage> _workPackages = new List<WorkPackage>();
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

        #region public bool EditEnabled
        ///<summary>
        /// Возвращает или задает значение возможности редактирования
        ///</summary>
        public bool EditEnabled
        {
            get { return buttonDelete.Enabled; }
            set
            {
                buttonDelete.Enabled = value;
                numericUpDownIndex.Enabled = value;
                lookupComboboxDeferred.EditEnabled = value;
                lookupComboboxFlight.EditEnabled = value;
            }
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
                panelDeferredInfo.Visible = _showDeferredInfoPanel && value;
            }
        }
        #endregion

        #region public bool FlightVisible
        ///<summary>
        /// Возвращает или задает значение видимости ссылки на полет
        ///</summary>
        public bool FlightVisible
        {
            get { return labelFlight.Visible; }
            set
            {
                labelFlight.Visible = value;
                lookupComboboxFlight.Visible = value;
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

		public bool ShowDeffects { get; set; }

		/*
         * Конструктор
         */

		#region public DiscrepancyControl()
		/// <summary>
		/// Пустой конструктор
		/// </summary>
		public DiscrepancyControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public DiscrepancyControl(Discrepancy discrepancy) : this ()
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public DiscrepancyControl(Discrepancy discrepancy, List<Discrepancy> discrepancies, List<WorkPackage> workPackages, List<TransferRecord> transferRecords) : this ()
        {
	        _discrepancies.AddRange(discrepancies);
			_workPackages.AddRange(workPackages);
	        _transferRecords.AddRange(transferRecords);
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

	            if (ShowDeffects)
	            {
		            Discrepancy.DeffeсtPhase = comboBoxPhase.SelectedItem as DeffeсtPhase;
		            Discrepancy.DeffeсtCategory = comboBoxDeffectCat.SelectedItem as DeffeсtCategory;
		            Discrepancy.DeffectConfirm = comboBoxDeffectConfirm.SelectedItem as DeffectConfirm;
		            Discrepancy.ActionType = comboBoxActinType.SelectedItem as ActionType;

		            Discrepancy.IsOccurrence = checkBoxOccurrence.Checked;
		            Discrepancy.Substruction = checkBoxSubstruction.Checked;
		            Discrepancy.EngineShutUp = checkBoxEngine.Checked;

		            Discrepancy.ConsequenceFault = comboBoxFaultConsequence.SelectedItem as ConsequenceFaults;
		            Discrepancy.ConsequenceOps = comboBoxOPSConsequence.SelectedItem as ConsequenceOPS;
		            Discrepancy.ConsequenceType = comboBoxConsequenceType.SelectedItem as IncidentType;
		            Discrepancy.InterruptionType = comboBoxInterruptionType.SelectedItem as InterruptionType;
		            Discrepancy.Occurrence = comboBoxOccurrence.SelectedItem as OccurrenceType;

					Discrepancy.Auth = comboBoxAuth.SelectedItem as Specialist;

		            var basecomponent = comboBoxEngine.SelectedItem as BaseComponent;
					if(basecomponent != null)
						Discrepancy.BaseComponentId = basecomponent.ItemId;

					Discrepancy.TimeDelay = (int) numericUpDownDelay.Value;
		            Discrepancy.Remark = textBoxRemarks.Text;
		            Discrepancy.Messages = textBoxMessages.Text;
		            Discrepancy.FDR = textBoxFDR.Text;
		            Discrepancy.EngineRemarks = textBoxEngineRemark.Text;
				}

				Discrepancy.Num = (int)numericUpDownIndex.Value;
                //Discrepancy.FilledBy = radioCrew.Checked ? DiscrepancyFilledByEnum.Crew : DiscrepancyFilledByEnum.MaintenanceStaff;
                Discrepancy.FilledBy = radioCrew.Checked ? false /*DiscrepancyFilledByEnum.Crew*/ 
                                                         : true /*DiscrepancyFilledByEnum.MaintenanceStaff*/;
                Discrepancy.Description = textDescription.Text;
                Discrepancy.IsReliability = checkBoxReliability.Checked;
                Discrepancy.DirectiveId = lookupComboboxDeferred.SelectedItemId;

				if(comboBoxWP.SelectedItem != null)
					Discrepancy.WorkPackageId = (comboBoxWP.SelectedItem as WorkPackage).ItemId;

				Discrepancy.DeferredItem = lookupComboboxDeferred.SelectedItem as DeferredItem;
                Discrepancy.ATAChapter = ataChapterComboBox.ATAChapter;

                if (Discrepancy.CorrectiveAction != null)
                {
                    Discrepancy.CorrectiveAction.AddNo = textADDNo.Text;
                    Discrepancy.CorrectiveAction.Description = textCorrectiveAction.Text;
                    Discrepancy.CorrectiveAction.PartNumberOn = textPNOn.Text;
                    Discrepancy.CorrectiveAction.PartNumberOff = textPNOff.Text;
                    Discrepancy.CorrectiveAction.SerialNumberOn = textSNOn.Text;
                    Discrepancy.CorrectiveAction.SerialNumberOff = textSNOff.Text;

					if(radioOpen.Checked)
						Discrepancy.Status = CorrectiveActionStatus.Open;
					else if(radioClose.Checked)
						Discrepancy.Status = CorrectiveActionStatus.Close;
					else if (radioButtonPublish.Checked)
						Discrepancy.Status = CorrectiveActionStatus.Publish;
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
            
            lookupComboboxDeferred.SelectedIndexChanged -= LookupComboboxDeferredSelectedIndexChanged;

	        UpdateControls();

	        _specialists.Clear();
	        try
	        {
		        _specialists.AddRange(GlobalObjects.CasEnvironment.Loader.GetObjectListAll<Specialist>(loadChild: true).Where(i => i.Specialization?.Department?.FullName == "Line Maintenance"));
	        }
	        catch (Exception ex)
	        {
		        Program.Provider.Logger.Log("Error while load Specialist fo Discrepancy", ex);
	        }


			if (ShowDeffects)
	        {
				comboBoxPhase.Items.Clear();
				comboBoxPhase.Items.AddRange(DeffeсtPhase.Items.ToArray());
		        comboBoxPhase.SelectedItem = Discrepancy.DeffeсtPhase;

				comboBoxDeffectCat.Items.Clear();
		        comboBoxDeffectCat.Items.AddRange(DeffeсtCategory.Items.ToArray());
		        comboBoxDeffectCat.SelectedItem = Discrepancy.DeffeсtCategory;

				comboBoxDeffectConfirm.Items.Clear();
		        comboBoxDeffectConfirm.Items.AddRange(DeffectConfirm.Items.ToArray());
		        comboBoxDeffectConfirm.SelectedItem = Discrepancy.DeffectConfirm;

				comboBoxActinType.Items.Clear();
		        comboBoxActinType.Items.AddRange(ActionType.Items.ToArray());
		        comboBoxActinType.SelectedItem = Discrepancy.ActionType;

		        comboBoxInterruptionType.Items.Clear();
		        comboBoxInterruptionType.Items.AddRange(InterruptionType.Items.ToArray());
		        comboBoxInterruptionType.SelectedItem = Discrepancy.InterruptionType;


		        checkBoxOccurrence.Checked = Discrepancy.IsOccurrence;
		        checkBoxSubstruction.Checked = Discrepancy.Substruction;

		        comboBoxFaultConsequence.Items.Clear();
		        comboBoxFaultConsequence.Items.AddRange(ConsequenceFaults.Items.ToArray());
		        comboBoxFaultConsequence.SelectedItem = Discrepancy.ConsequenceFault;

		        comboBoxOPSConsequence.Items.Clear();
		        comboBoxOPSConsequence.Items.AddRange(ConsequenceOPS.Items.ToArray());
		        comboBoxOPSConsequence.SelectedItem = Discrepancy.ConsequenceOps;


		        comboBoxConsequenceType.Items.Clear();
		        comboBoxConsequenceType.Items.AddRange(IncidentType.Items.ToArray());
		        comboBoxConsequenceType.SelectedItem = Discrepancy.ConsequenceType;


				comboBoxOccurrence.Items.Clear();
				comboBoxOccurrence.Items.AddRange(OccurrenceType.Items.ToArray());
				comboBoxOccurrence.SelectedItem = Discrepancy.Occurrence;


				comboBoxAuth.Items.Clear();
				comboBoxAuth.Items.AddRange(_specialists.OrderBy(i => i.LastName).ToArray());
		        comboBoxAuth.SelectedItem = Discrepancy.Auth;

				
		        var aircraftBaseDetails = GlobalObjects.ComponentCore.GetAicraftBaseComponents(Discrepancy.ParentFlight.AircraftId, BaseComponentType.Engine.ItemId).ToList();
		        if (aircraftBaseDetails.Count > 0)
		        {
			        comboBoxEngine.Items.Clear();
					comboBoxEngine.Items.AddRange(aircraftBaseDetails.ToArray());
			        
			        var selected = aircraftBaseDetails.GetItemById(Discrepancy.BaseComponentId);
					if(selected != null)
						comboBoxEngine.SelectedItem = selected;
					else comboBoxEngine.SelectedIndex = 0;
				}

				numericUpDownDelay.Value = Discrepancy.TimeDelay;
		        textBoxRemarks.Text = Discrepancy.Remark;
		        textBoxMessages.Text = Discrepancy.Messages;
		        textBoxFDR.Text = Discrepancy.FDR;
		        textBoxEngineRemark.Text = Discrepancy.EngineRemarks;
		        checkBoxEngine.Checked = Discrepancy.EngineShutUp;

	        }

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

                lookupComboboxDeferred.SetAddScreenControl<DeferredScreen>
                    (new object[] { aircraft, Discrepancy.ParentFlight },
                     displayerText + ". New Directive");

                lookupComboboxDeferred.SetEditScreenControl<DeferredScreen>(displayerText);
                lookupComboboxDeferred.SetItemsScreenControl<PrimeDirectiveListScreen>
                    (new object[] { aircraft, DirectiveType.DeferredItems, ADType.None },
                     displayerText);
                lookupComboboxDeferred.LoadObjectsFunc = GlobalObjects.DirectiveCore.GetDeferredItems;
                lookupComboboxDeferred.FilterParam1 = Discrepancy.ParentFlight;
                lookupComboboxDeferred.UpdateInformation();    
            }
            
            #endregion

            #region lookupComboboxFlight

            if(Discrepancy != null && Discrepancy.ItemId > 0 && Discrepancy.DirectiveId > 0)
            {
				var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(Discrepancy.ParentFlight.AircraftId);

				lookupComboboxFlight.SetEditScreenControl<FlightScreen>
                    (aircraft.RegistrationNumber + ". " + Discrepancy.ParentFlight.FlightNo);

                ATLB parentAtlb = null;
                try
                {
                    parentAtlb = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<ATLBDTO,ATLB>(Discrepancy.ParentFlight.ATLBId);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while load linked ATLB fo Discrepancy", ex);
                }
                if(parentAtlb != null)
                {
                    //Проверить на значение свойтсва ParentAircraft в parentAtlb
                    lookupComboboxFlight.SetItemsScreenControl<FlightsListScreen>
                        (new object[] { parentAtlb },
						 aircraft.RegistrationNumber + ". ATLB No " + parentAtlb.ATLBNo);

                    lookupComboboxFlight.LoadObjectsFunc = GlobalObjects.AircraftFlightsCore.GetFlightsByAtlb;
					lookupComboboxFlight.FilterParam1 = Discrepancy.ParentFlight.AircraftId;
					lookupComboboxFlight.FilterParam2 = parentAtlb.ItemId;
                    lookupComboboxFlight.UpdateInformation();      
                }  
            }

            #endregion

           

            if (Discrepancy != null)
            {
                comboSpecialist1.Items.AddRange(_specialists.OrderBy(i => i.LastName).ToArray());
                comboSpecialist2.Items.AddRange(_specialists.OrderBy(i => i.LastName).ToArray());
                radioCrew.Checked = Discrepancy.FilledBy == false;// DiscrepancyFilledByEnum.Crew;
                radioMaintenanceStaff.Checked = Discrepancy.FilledBy;//DiscrepancyFilledByEnum.MaintenanceStaff;
                ataChapterComboBox.ATAChapter = Discrepancy.ATAChapter;
				radioOpen.Checked = Discrepancy.Status == CorrectiveActionStatus.Open;
				radioClose.Checked = Discrepancy.Status == CorrectiveActionStatus.Close;
				radioButtonPublish.Checked = Discrepancy.Status == CorrectiveActionStatus.Publish;
                textDescription.Text = Discrepancy.Description ?? "No";
	            checkBoxReliability.Checked = Discrepancy.IsReliability;
                if(Discrepancy.Num > numericUpDownIndex.Maximum)
                    numericUpDownIndex.Value = numericUpDownIndex.Maximum;
                else if (Discrepancy.Num < numericUpDownIndex.Minimum)
                    numericUpDownIndex.Value = numericUpDownIndex.Minimum;
                else numericUpDownIndex.Value = Discrepancy.Num;

                if (Discrepancy.DirectiveId > 0)
                {
                    lookupComboboxDeferred.SelectedItemId = Discrepancy.DirectiveId;
                    lookupComboboxFlight.SelectedItemId = Discrepancy.FlightId;
                }
                if (Discrepancy.DeferredItem != null)
                {
                    ataChapterComboBox.Enabled = false;
                    ataChapterComboBox.ATAChapter = Discrepancy.DeferredItem.ATAChapter;
                    radioOpen.Enabled = false;
                    radioClose.Enabled = false;

                    if (Discrepancy.DeferredItem.Status == DirectiveStatus.Closed)
                        radioClose.Checked = true;
                    else radioOpen.Checked = true;

                    _showDeferredInfoPanel = true;
                    textBoxMelCdl.Text = Discrepancy.DeferredItem.DeferredMelCdlItem;
                    textBoxDeferredCategory.Text = Discrepancy.DeferredItem.DeferredCategory.ToString();
                    
                    Directive directive = Discrepancy.DeferredItem;
                    dateTimePickerOpenDate.Visible = true;
                    dateTimePickerOpenDate.Value = directive.Threshold.EffectiveDate;

                    if (directive.PerformanceRecords.Count > 0)
                    {
                        if (directive.IsClosed)
                        {
                            dateTimePickerClosingDate.Visible = true;
                            dateTimePickerExtension.Visible = false;
                            numericUpDownExtTimes.Visible = false;
                            dateTimePickerClosingDate.Value = directive.PerformanceRecords.GetLast().RecordDate;

                        }
                        else
                        {
                            dateTimePickerClosingDate.Visible = false;
                            dateTimePickerExtension.Visible = true;
                            numericUpDownExtTimes.Visible = true;
                            dateTimePickerExtension.Value = directive.PerformanceRecords.GetLast().RecordDate;

                            try
                            {
                                numericUpDownExtTimes.Value =
                                    GlobalObjects.CasEnvironment.Loader.GetCountPerformanceRecords<DirectiveRecord>(
                                    SmartCoreType.Directive, directive.ItemId);
                            }
                            catch (Exception ex)
                            {
                                Program.Provider.Logger.Log("Error while load count of records for directive id:" + directive.ItemId,
                                                            ex);
                            }

                            GlobalObjects.PerformanceCalculator.GetNextPerformance(directive);
                            lifelengthViewerRemains.Lifelength = directive.Remains;
                        }
                    }
                    else
                    {
                        dateTimePickerClosingDate.Visible = false;
                        dateTimePickerExtension.Visible = false;
                        numericUpDownExtTimes.Visible = false;

                        GlobalObjects.PerformanceCalculator.GetNextPerformance(directive);
                        lifelengthViewerRemains.Lifelength = directive.Remains;
                    }
                }
                else
                {
                    _showDeferredInfoPanel = false;
                }

                if (!panelExtendable.Visible)
                    panelDeferredInfo.Visible = _showDeferredInfoPanel;
                else panelDeferredInfo.Visible = _showDeferredInfoPanel && extendableRichContainer.Extended;

                if (Discrepancy.CorrectiveAction != null)
                {
                    textCorrectiveAction.Text = Discrepancy.CorrectiveAction.Description ?? "No";
                    textPNOff.Text = Discrepancy.CorrectiveAction.PartNumberOff;
                    textSNOff.Text = Discrepancy.CorrectiveAction.SerialNumberOff;
                    textPNOn.Text = Discrepancy.CorrectiveAction.PartNumberOn;
                    textSNOn.Text = Discrepancy.CorrectiveAction.SerialNumberOn;
                    textADDNo.Text = Discrepancy.CorrectiveAction.AddNo ?? "No";
                }
                else
                {
                    textCorrectiveAction.Text = "No";
                    textADDNo.Text = "No";
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
                textADDNo.Text = textDescription.Text = textCorrectiveAction.Text = textPNOff.Text =
                    textSNOff.Text = textPNOn.Text = textSNOn.Text = textStation.Text = "";
                radioOpen.Checked = radioClose.Checked = radioCrew.Checked = radioMaintenanceStaff.Checked = false;
                dateTimePickerRTSDate.Value = DateTime.Today;
                comboSpecialist1.SelectedItem = null;
                comboSpecialist2.SelectedItem = null;
                textDescription.Text = "What Where When Extent";
            }


	        comboBoxWP.Items.Clear();
	        comboBoxWP.Items.AddRange(_workPackages.ToArray());
	        comboBoxWP.SelectedItem = _workPackages.FirstOrDefault(i => i.ItemId == Discrepancy.WorkPackageId);
	        comboBoxWP.DisplayMember = "ComboBoxMember";


			comboBoxComp.Items.Clear();
			comboBoxComp.Items.AddRange(_transferRecords.ToArray());
	        comboBoxComp.SelectedItem = _transferRecords.FirstOrDefault(i => (bool)i.ParentComponent?.SerialNumber.Equals(textSNOn.Text) && (bool)i.ParentComponent?.PartNumber.Equals(textPNOn.Text) &&
	                                                                         (bool)i.ReplaceComponent?.SerialNumber.Equals(textSNOff.Text) && (bool)i.ReplaceComponent?.PartNumber.Equals(textPNOff.Text));
	        comboBoxComp.DisplayMember = "ComboBoxMember";

			SetExtendableControlCaption();

            lookupComboboxDeferred.SelectedIndexChanged += LookupComboboxDeferredSelectedIndexChanged;

			EndUpdate();

	        comboBoxPhase.Select(comboBoxPhase.Text.Length, 0);
		}

		#endregion

		private void UpdateControls()
		{
			comboBoxActinType.Visible = comboBoxDeffectCat.Visible =
				comboBoxDeffectConfirm.Visible = comboBoxPhase.Visible = labelActinType.Visible = labelDeffectCat.Visible =
					labelDeffectConfirm.Visible = labelPhase.Visible =
						checkBoxOccurrence.Visible = 
						labelDelay.Visible = numericUpDownDelay.Visible = textBoxRemarks.Visible= labelRemaks.Visible =
							checkBoxSubstruction.Visible = labelSubstitution.Visible =
								comboBoxFaultConsequence.Visible = labelFaultConsequence.Visible =
									comboBoxOPSConsequence.Visible = labelOPSConsequence.Visible =
										comboBoxConsequenceType.Visible = labelConsequenceType.Visible =
											comboBoxInterruptionType.Visible = labelInterruptionType.Visible = 
													labelFDR.Visible = textBoxFDR.Visible = textBoxMessages.Visible = labelMessages.Visible  = 
														labelAuth.Visible = comboBoxAuth.Visible = 
															labelOccurrence.Visible = comboBoxOccurrence.Visible = 
															labelEngine.Visible = checkBoxEngine.Visible = comboBoxEngine.Visible = 
															labelEngineRemark.Visible = textBoxEngineRemark.Visible =	ShowDeffects;
		}

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

            if (!radioOpen.Checked && !radioClose.Checked && !radioButtonPublish.Checked)
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
            panelDeferredInfo.Visible = _showDeferredInfoPanel && extendableRichContainer.Extended;
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
                if (lookupComboboxFlight.Visible && Discrepancy.ParentFlight != null)
                    extendableRichContainer.labelCaption.Text += " Flight:" + Discrepancy.ParentFlight;
            }

        }
        #endregion

        #region private void LookupComboboxDeferredSelectedIndexChanged(object sender, EventArgs e)
        private void LookupComboboxDeferredSelectedIndexChanged(object sender, EventArgs e)
        {
            if(lookupComboboxDeferred.SelectedItem != null)
            {
                _showDeferredInfoPanel = true;
                panelDeferredInfo.Visible = extendableRichContainer.Extended && _showDeferredInfoPanel;
                    
                ataChapterComboBox.Enabled = false;
                DeferredItem di = lookupComboboxDeferred.SelectedItem as DeferredItem;
                ataChapterComboBox.ATAChapter = di != null ? di.ATAChapter : null;
                
                radioOpen.Enabled = false;
                radioClose.Enabled = false;

                if (di != null)
                {
                    dateTimePickerOpenDate.Visible = true;
                    dateTimePickerOpenDate.Value = di.Threshold.EffectiveDate;

                    if (di.PerformanceRecords.Count > 0)
                    {
                        if (di.IsClosed)
                        {
                            dateTimePickerClosingDate.Visible = true;
                            dateTimePickerExtension.Visible = false;
                            numericUpDownExtTimes.Visible = false;
                            dateTimePickerClosingDate.Value = di.PerformanceRecords.GetLast().RecordDate;

                        }
                        else
                        {
                            dateTimePickerClosingDate.Visible = false;
                            dateTimePickerExtension.Visible = true;
                            numericUpDownExtTimes.Visible = true;
                            dateTimePickerExtension.Value = di.PerformanceRecords.GetLast().RecordDate;

                            try
                            {
                                numericUpDownExtTimes.Value =
                                    GlobalObjects.CasEnvironment.Loader.GetCountPerformanceRecords<DirectiveRecord>(
                                    SmartCoreType.Directive, di.ItemId);
                            }
                            catch (Exception ex)
                            {
                                Program.Provider.Logger.Log("Error while load count of records for directive id:" + di.ItemId,
                                                            ex);
                            }

                            GlobalObjects.PerformanceCalculator.GetNextPerformance(di);
                            lifelengthViewerRemains.Lifelength = di.Remains;
                        }
                    }
                    else
                    {
                        dateTimePickerClosingDate.Visible = false;
                        dateTimePickerExtension.Visible = false;
                        numericUpDownExtTimes.Visible = false;

                        GlobalObjects.PerformanceCalculator.GetNextPerformance(di);
                        lifelengthViewerRemains.Lifelength = di.Remains;
                    }

                    if (di.Status == DirectiveStatus.Closed)
                    {
                        textBoxMelCdl.Text = di.DeferredMelCdlItem;
                        textBoxDeferredCategory.Text = di.DeferredCategory.ToString();

                        if (di.Status == DirectiveStatus.Closed)
                            radioClose.Checked = true;
                        else radioOpen.Checked = true;   
                    }
                }
                if (di == null)
                {
                    dateTimePickerOpenDate.Visible = false;
                    dateTimePickerClosingDate.Visible = false;
                    dateTimePickerExtension.Visible = false;
                    numericUpDownExtTimes.Visible = false;
                    lifelengthViewerRemains.Lifelength = Lifelength.Null;
                }
            }
            else
            {
                _showDeferredInfoPanel = false;
                panelDeferredInfo.Visible = _showDeferredInfoPanel;

                ataChapterComboBox.Enabled = true;
                ataChapterComboBox.ATAChapter = Discrepancy.ATAChapter;
                radioOpen.Enabled = true;
                radioClose.Enabled = true;

                if (Discrepancy.CorrectiveAction != null &&
                    Discrepancy.CorrectiveAction.Status == CorrectiveActionStatus.Close)
                    radioClose.Checked = true;
                else radioOpen.Checked = true;   
            }          
        }
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

		#region private void ComboBoxWP_SelectedIndexChanged(object sender, System.EventArgs e)

		private void ComboBoxWP_SelectedIndexChanged(object sender, EventArgs e)
	    {
		    if (comboBoxWP.SelectedItem == null)
		    {
				linkLabelEditChart.Enabled = false;
				return;
		    }

		    var wp = comboBoxWP.SelectedItem as WorkPackage;

		    if (wp != null)
		    {
			    linkLabelEditChart.Enabled = true;
			    textDescription.Text = $"Perform : {wp}";
			}
		    else
		    {
			    linkLabelEditChart.Enabled = false;
		    }
	    }

	    #endregion

		#region Events
		/// <summary>
		/// </summary>
		public event EventHandler Deleted;
		public event EventHandler EditWp;
		public event EventHandler ComponentChangeReportOpen;

		

		private void linkLabelEditChart_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var wp = comboBoxWP.SelectedItem as WorkPackage;

			if (EditWp != null)
				EditWp(wp, EventArgs.Empty);
		}

	    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
	    {
		    if (ComponentChangeReportOpen != null)
			    ComponentChangeReportOpen(this, EventArgs.Empty);
	    }
		#endregion

		private void textDescription_TextChanged(object sender, EventArgs e)
		{
			var text = textDescription.Text.ToLower();

			if (string.IsNullOrEmpty(text) || text.Contains("perform :") || text.Equals("no"))
				comboBoxWP.Enabled = true;
			else
			{
				comboBoxWP.Enabled = false;
				comboBoxWP.SelectedItem = null;
			}
		}

		private void comboBoxComp_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxComp.SelectedItem == null)
			{
				comboBoxWP.Enabled = true;
				linkLabelEditChart.Enabled = true;
				return;
			}

			var tr = comboBoxComp.SelectedItem as TransferRecord;

			ataChapterComboBox.ATAChapter = tr.ParentComponent?.ATAChapter;

			textPNOn.Text = tr.ParentComponent?.PartNumber;
			textPNOff.Text = tr.ReplaceComponent?.PartNumber;
			textSNOn.Text = tr.ParentComponent?.SerialNumber;
			textSNOff.Text = tr.ReplaceComponent?.SerialNumber;
		}

		private void comboBoxComp_TextUpdate(object sender, EventArgs e)
		{
			var _filterString = comboBoxComp.Text;

			comboBoxComp.Items.Clear();

			foreach (var tr in _transferRecords.Where(i => i.ComboBoxMember.ToLowerInvariant().Contains(_filterString.ToLowerInvariant())))
				comboBoxComp.Items.Add(tr);



			comboBoxComp.DropDownStyle = ComboBoxStyle.DropDown;
			comboBoxComp.SelectionStart = _filterString.Length;
		}

		#region private void checkBoxReliability_CheckedChanged(object sender, EventArgs e)

		private void checkBoxReliability_CheckedChanged(object sender, EventArgs e)
	    {
		    comboBoxActinType.Enabled = comboBoxDeffectCat.Enabled =
			    comboBoxDeffectConfirm.Enabled = comboBoxPhase.Enabled = checkBoxOccurrence.Enabled =  checkBoxReliability.Checked;

		    if (!checkBoxReliability.Checked)
			    radioClose.Checked = true;
		    else if(radioClose.Checked) radioOpen.Checked = true;
	    }

		#endregion

		private void flowLayoutPanelMain_VisibleChanged(object sender, EventArgs e)
		{
			comboBoxPhase.SelectionLength = 0;
			comboBoxDeffectCat.SelectionLength = 0;
			comboBoxDeffectConfirm.SelectionLength = 0;
			comboBoxActinType.SelectionLength = 0;
			comboSpecialist1.SelectionLength = 0;
			comboSpecialist2.SelectionLength = 0;
			comboBoxFaultConsequence.SelectionLength = 0;
			comboBoxOPSConsequence.SelectionLength = 0;
			comboBoxConsequenceType.SelectionLength = 0;
			comboBoxInterruptionType.SelectionLength = 0;
			comboBoxAuth.SelectionLength = 0;
			comboBoxOccurrence.SelectionLength = 0;
			comboBoxEngine.SelectionLength = 0;
		}

		private void checkBoxOccurrence_CheckedChanged(object sender, EventArgs e)
		{
			labelDelay.Enabled = numericUpDownDelay.Enabled = textBoxRemarks.Enabled = labelRemaks.Enabled =
				checkBoxSubstruction.Enabled = labelSubstitution.Enabled =
					comboBoxFaultConsequence.Enabled = labelFaultConsequence.Enabled =
						comboBoxOPSConsequence.Enabled = labelOPSConsequence.Enabled =
							comboBoxConsequenceType.Enabled = labelConsequenceType.Enabled =
								comboBoxInterruptionType.Enabled = labelInterruptionType.Enabled =
									labelFDR.Enabled = textBoxFDR.Enabled = textBoxMessages.Enabled = labelMessages.Enabled =
										labelAuth.Enabled = comboBoxAuth.Enabled =
											labelOccurrence.Enabled = comboBoxOccurrence.Enabled =
											labelEngine.Enabled = checkBoxEngine.Enabled = comboBoxEngine.Enabled = 
												labelEngineRemark.Enabled = textBoxEngineRemark.Enabled =checkBoxOccurrence.Checked;
		}
	}
}

