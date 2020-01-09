using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary.Dialogs;
using CAS.UI.UIControls.DocumentationControls;
using CASTerms;
using EntityCore.DTO.General;
using EntityCore.Filter;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.MTOP;
using SmartCore.Entities.General.WorkPackage;
using Component = SmartCore.Entities.General.Accessory.Component;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    ///</summary>
    public partial class DirectiveComplianceDialog : ComplianceDialog
    {
        #region Fields

        private bool _needActualState;
	    private bool checkClosed;

		private IDirective _currentDirective;
        private DirectiveRecord _currentDirectiveRecord;
        private NextPerformance _nextPerformance;

        private DateTime? _prevPerfDate;
        private DateTime? _nextPerfDate;
        private Lifelength _prevPerfLifelength;
        private Lifelength _nextPerfLifelength;

		private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
	    private Document _wpClosingDocument;
		private Document _currentDocuments;
	    private List<NextPerformance> _nextPerformances;
	    private readonly AverageUtilization _averageUtilization;

	    #endregion

		#region Methods

		#region private DirectiveComplianceDialog()

		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private DirectiveComplianceDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region public DirectiveComplianceDialog(IDirective currentDirective, NextPerformance nextPerformance) : this()

        ///<summary>
        ///</summary>
        ///<param name="currentDirective"></param>
        ///<param name="nextPerformance"></param>
        public DirectiveComplianceDialog(IDirective currentDirective, NextPerformance nextPerformance) 
            : this()
        {
            _currentDirective = currentDirective;
            _currentDirectiveRecord = DirectiveRecord.CreateInstance(nextPerformance);
            _nextPerformance = nextPerformance;

			_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
			_animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
        }

		#endregion

		#region public DirectiveComplianceDialog(IDirective currentDirective, NextPerformance nextPerformance) : this()

	    /// <summary>
	    /// </summary>
	    /// <param name="currentDirective"></param>
	    /// <param name="nextPerformances"></param>
	    /// <param name="averageUtilization"></param>
	    /// <param name="nextPerformance"></param>
	    public DirectiveComplianceDialog(IDirective currentDirective, List<NextPerformance> nextPerformances,
		    AverageUtilization averageUtilization)
		    : this()
	    {
		    _currentDirective = currentDirective;
		    _currentDirectiveRecord = DirectiveRecord.CreateInstance(nextPerformances.FirstOrDefault());
		    _nextPerformance = nextPerformances.FirstOrDefault();
		    _nextPerformances = nextPerformances;
		    _averageUtilization = averageUtilization;

		    checkBox1.Visible = true;

		    _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
		    _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
	    }

	    #endregion

		#region public DirectiveComplianceDialog(IDirective currentDirective, DirectiveRecord currentRecord) : this()
		///<summary>
		///</summary>
		///<param name="currentDirective"></param>
		///<param name="currentRecord"></param>
		public DirectiveComplianceDialog(IDirective currentDirective, DirectiveRecord currentRecord) 
            : this()
        {
            _currentDirective = currentDirective;
            _currentDirectiveRecord = currentRecord;

			_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
			_animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
        }

		#endregion

		private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			UpdateInformation();
			if (_currentDirective is MaintenanceDirective || _currentDirective is Directive || _currentDirective is ComponentDirective)
			{
				this.Size = new System.Drawing.Size(789, 388);
				//this.buttonOk.Location = new System.Drawing.Point(557, 401);
				//this.buttonCancel.Location = new System.Drawing.Point(638, 401);
				//this.buttonApply.Location = new System.Drawing.Point(719, 401);
			}
		}

		private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
		{
			if (_currentDirectiveRecord.ItemId > 0)
			{
				//Грузим документ для текущей директивы
				_currentDirectiveRecord.Document = GlobalObjects.CasEnvironment.NewLoader.GetObject<DocumentDTO,Document>(new List<Filter>()
				{
					new Filter("ParentTypeId",SmartCoreType.DirectiveRecord.ItemId),
					new Filter("ParentID",_currentDirectiveRecord.ItemId),
				}, true);


				//Если директива была закрыта в рамках рабочего пакета грузим документ из раб пакета
				if (_currentDirectiveRecord.DirectivePackage != null && _currentDirectiveRecord.DirectivePackage is WorkPackage)
				{
					_wpClosingDocument = GlobalObjects.CasEnvironment.NewLoader.GetObject<DocumentDTO,Document>(new List<Filter>()
					{
						new Filter("ParentID",_currentDirectiveRecord.DirectivePackageId),
						new Filter("ParentTypeId",SmartCoreType.WorkPackage.ItemId),
					}, true);
				}
			}
		}


		#region private bool ValidateData(out string message)
		/// <summary>
		/// Возвращает значение, показывающее является ли значение элемента управления допустимым
		/// </summary>
		/// <returns></returns>
		private bool ValidateData(out string message)
        {
            message = "";

            if (dateTimePicker1.Value > DateTime.Now)
            {
                if (message != "") message += "\n ";
                message += "Performance date must be less than current date.";
                return false;
            }

            Lifelength parentLifeLenght =
                GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(_currentDirective.LifeLengthParent,
                                                                             dateTimePicker1.Value);
            //наработка родителя на след. день после введения записи
            Lifelength lifelengthTomorrow =
                GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(_currentDirective.LifeLengthParent, dateTimePicker1.Value.AddDays(1));

            if (lifelengthViewer_LastCompliance.Lifelength.Days == null)
            {
                lifelengthViewer_LastCompliance.Lifelength.Days = parentLifeLenght.Days;
            }

            Lifelength perfLifeLength = lifelengthViewer_LastCompliance.Lifelength;

            if(perfLifeLength.IsLessByAnyParameter(parentLifeLenght))
            {
                //вводимая наработка на дату выполнения меньше, чем расчитанная калькулятором
                if (message != "") message += "\n ";
                message +=
                    string.Format("Performance source on date: {0} \nmust be grather than {1}", 
                                   dateTimePicker1.Value,
                                   parentLifeLenght.ToHoursAndCyclesFormat());
                return false;  
            }
            //if (perfLifeLength.IsGreaterByAnyParameter(lifelengthTomorrow))
            //{
            //    //вводимая наработка на дату выполнения больше, 
            //    //чем расчитанная калькулятором на след. день 
            //    int lifelengthHours = Convert.ToInt32(parentLifeLenght.Hours);
            //    int lifelengthCycles = Convert.ToInt32(parentLifeLenght.Cycles);
            //    int lifelengthTomHours = Convert.ToInt32(lifelengthTomorrow.Hours);
            //    int lifelengthTomCycles = Convert.ToInt32(lifelengthTomorrow.Cycles);

            //    if (lifelengthHours < lifelengthTomHours || lifelengthCycles < lifelengthTomCycles)
            //    {
            //        //при этом наработка на след. день после вводимой даты 
            //        //больше наработки на вводимую дату
            //        //выдача сообщения о некорректности данных
            //        if (message != "") message += "\n ";
            //            message +=
            //                string.Format("Performance source on date: {0} \nmust be less than {1}",
            //                                dateTimePicker1.Value,
            //                                lifelengthTomorrow.ToHoursAndCyclesFormat());
            //        return false;
            //    }
                //if (lifelengthHours == lifelengthTomHours || lifelengthCycles == lifelengthTomCycles)
                //{
                //    //наработка на след. день после вводимой даты 
                //    //равна наработке на вводимую дату
                //    //выдача сообщения о возможности введения актуального состояния  
                //    if (message != "") message += "\n ";
                //    message += string.Format(@"Lifelength {0} for {1} is defferent" + 
                //                              "\nlifelength {2} for {3}." +
                //                              "\nRegister actual state? (date:{4} lifelength:{0})",
                //                             perfLifeLength,
                //                             _currentDirective,
                //                             parentLifeLenght,
                //                             _currentDirective.LifeLengthParent,
                //                             dateTimePicker1.Value);
                //    if (MessageBox.Show(message,
                //                        (string)new GlobalTermsProvider()["SystemName"],
                //                        MessageBoxButtons.YesNo,
                //                        MessageBoxIcon.Exclamation,
                //                        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                //    {
                //        _needActualState = true;
                //    }
                //}
            //}
            if(_prevPerfLifelength != null && perfLifeLength.IsLessByAnyParameter(_prevPerfLifelength))
            {
                if (message != "") message += "\n ";
                message += "Performance source must be grather than " + _prevPerfLifelength;
                return false;   
            }
            //if (_nextPerfLifelength != null && perfLifeLength.IsGreaterByAnyParameter(_nextPerfLifelength))
            //{
            //    if (message != "") message += "\n ";
            //    message += "Performance source must be less than " + _nextPerfLifelength;
            //    return false;
            //}

            return true;
        }

        #endregion

        #region private bool SaveData()

        /// <summary>
        /// Данные работы обновляются по введенным значениям
        /// </summary>
        private bool SaveData()
        {
	        if (_nextPerformances != null)
	        {
		        foreach (var performance in _nextPerformances)
		        {
			        var newRecord = DirectiveRecord.CreateInstance(performance);
			        newRecord.Parent = performance.Parent;
			        newRecord.RecordDate = dateTimePicker1.Value;
			        newRecord.Remarks = textBox_Remarks.Text;
			        newRecord.OnLifelength = lifelengthViewer_LastCompliance.Lifelength;
			        newRecord.PerformanceNum = performance.Group;
			        if (fileControl.GetChangeStatus())
			        {
				        fileControl.ApplyChanges();
				        newRecord.AttachedFile = fileControl.AttachedFile;
			        }
			        newRecord.Completed = true;

			        try
			        {
						GlobalObjects.PerformanceCore.RegisterPerformance(newRecord.Parent, newRecord);


						if (newRecord.Document?.ParentId <= 0)
				        {
					        newRecord.Document.ParentId = newRecord.ItemId;
					        GlobalObjects.CasEnvironment.NewKeeper.Save(newRecord.Document);
				        }

				        if (checkBox1.Checked && !checkClosed)
				        {
					        checkClosed = true;

					        var rec = performance.Parent as MaintenanceDirective;

					        var checkRecord = new MTOPCheckRecord
					        {
						        RecordDate = dateTimePicker1.Value,
						        CheckName = performance.ParentCheck.Name,
						        GroupName = performance.Group,
						        CalculatedPerformanceSource = lifelengthViewer_LastCompliance.Lifelength,
						        ParentId = performance.ParentCheck.ItemId,
						        Remarks = "Closed by Mtop Forecast",
						        AverageUtilization = _averageUtilization
							};

					        GlobalObjects.CasEnvironment.NewKeeper.Save(checkRecord);
				        }



					}
			        catch (Exception ex)
			        {
				        Program.Provider.Logger.Log("Error while saving performance for directive", ex);
				        return false;
			        }
				}

		        return true;
	        }
	        else
	        {
				_currentDirectiveRecord.RecordDate = dateTimePicker1.Value;
		        _currentDirectiveRecord.Remarks = textBox_Remarks.Text;
		        _currentDirectiveRecord.OnLifelength = lifelengthViewer_LastCompliance.Lifelength;

		        if (fileControl.GetChangeStatus())
		        {
			        fileControl.ApplyChanges();
			        _currentDirectiveRecord.AttachedFile = fileControl.AttachedFile;
		        }
		        _currentDirectiveRecord.Completed = true;

		        try
		        {
			        if (_currentDirectiveRecord.ItemId <= 0)
				        GlobalObjects.PerformanceCore.RegisterPerformance(_currentDirective, _currentDirectiveRecord);
			        else GlobalObjects.CasEnvironment.Manipulator.Save(_currentDirectiveRecord);

			        //if(_needActualState)
			        //    GlobalObjects.ComponentCore.RegisterActualState(_currentDirective.LifeLengthParent, 
			        //        dateTimePicker1.Value, 
			        //        _currentDirectiveRecord.OnLifelength);

			        if (_currentDirectiveRecord.Document?.ParentId <= 0)
			        {
				        _currentDirectiveRecord.Document.ParentId = _currentDirectiveRecord.ItemId;
				        GlobalObjects.CasEnvironment.NewKeeper.Save(_currentDirectiveRecord.Document);
			        }
		        }
		        catch (Exception ex)
		        {
			        Program.Provider.Logger.Log("Error while saving performance for directive", ex);
			        return false;
		        }

		        return true;
			}
        }

        #endregion

        #region private bool Save()
        private bool Save()
        {
            string message;
            if (!ValidateData(out message))
            {
                message += "\nAbort operation";
                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return SaveData();
        }
        #endregion

        #region private void UpdateInformation()
        /// <summary>
        /// Обновление информации ЭУ
        /// </summary>
        private void UpdateInformation()
        {
			//TODO: Со временем убрать эту проверку т.к добавим тоже самое в Mpd и Dirctive
			//TODO: Загрузка документов производится в ComponentComplianceControl(246 строка)
			if (_currentDirective is ComponentDirective || _currentDirective is Directive)
	        {
				if (_wpClosingDocument != null)
				{
					documentControl1.Visible = true;
					documentControl1.CurrentDocument = _wpClosingDocument;
					fileControl.ShowLinkLabelRemove = false;
					textBox_Remarks.Enabled = false;
					dateTimePicker1.Enabled = false;
					label4.Visible = false;
					lifelengthViewer_LastCompliance.Enabled = false;
				}
				else
				{
					documentControl1.CurrentDocument = _currentDirectiveRecord.Document;
					documentControl1.Added += linkLabelAddDocument_LinkClicked;
				}
			}
			else
			{
				documentControl1.CurrentDocument = _currentDirectiveRecord.Document;
				documentControl1.Added += linkLabelAddDocument_LinkClicked;
			}

	        
			if (_currentDirectiveRecord == null) 
                return;
            textBox_Remarks.Text = _currentDirectiveRecord.Remarks ?? "";
            dateTimePicker1.Value = _currentDirectiveRecord.RecordDate < dateTimePicker1.MinDate 
                ? DateTime.Today
                : _currentDirectiveRecord.RecordDate;

            if (_currentDirectiveRecord.OnLifelength != null)
                lifelengthViewer_LastCompliance.Lifelength = _currentDirectiveRecord.OnLifelength;

            if(_currentDirectiveRecord.DirectivePackage != null)
            {
                lifelengthViewer_LastCompliance.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
            else
            {
                lifelengthViewer_LastCompliance.Enabled = true;
                dateTimePicker1.Enabled = true;
            }

			#region Определение ограничений по ресурсу и дате выполнения
			if (_currentDirectiveRecord.ItemId > 0)
            {
                //редактируется старая запись
                int index = _currentDirective.PerformanceRecords.IndexOf(_currentDirectiveRecord);
                if(index == 0)
                {
                    //редактируется первая запись о выполнении
                    _prevPerfDate = null;
                    _prevPerfLifelength = null;
                    if(_currentDirective.PerformanceRecords.Count > 1)
                    {
                        //было сделано много записей о выполнении
                        _nextPerfDate = _currentDirective.PerformanceRecords[index + 1].RecordDate;
                        _nextPerfLifelength =
                            GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(_currentDirective.LifeLengthParent,
                                                                                  _nextPerfDate.Value);
                    }
                    else if (_currentDirective.NextPerformances.Count > 0)
                    {
                        //была сделана одна запись о выполнении и есть "след. выполнения"
                        _nextPerfDate = _currentDirective.NextPerformances[0].PerformanceDate;
                        _nextPerfLifelength = _currentDirective.NextPerformances[0].PerformanceSource;
                    }
                    else
                    {
                        _nextPerfDate = null;
                        _nextPerfLifelength = null;    
                    }
                }
                else if (index < _currentDirective.PerformanceRecords.Count - 1)
                {
                    //редактируется запись из середины списка записей о выполнении
                    _prevPerfDate = _currentDirective.PerformanceRecords[index-1].RecordDate;
                    _prevPerfLifelength = 
                        GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(_currentDirective.LifeLengthParent,
                                                                              _prevPerfDate.Value);
                    _nextPerfDate = _currentDirective.PerformanceRecords[index + 1].RecordDate;
                    _nextPerfLifelength =
                        GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(_currentDirective.LifeLengthParent,
                                                                              _nextPerfDate.Value);
                }
                else //(index == _currentDirective.PerformanceRecords.Count - 1)
                {
                    //редактируется запись из середины списка записей о выполнении
                    _prevPerfDate = _currentDirective.PerformanceRecords[index - 1].RecordDate;
                    _prevPerfLifelength =
                        GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(_currentDirective.LifeLengthParent,
                                                                              _prevPerfDate.Value);
                    if (_currentDirective.NextPerformances.Count > 0)
                    {
                        //запись о выполнении сделана последней и есть "след. выполнения"
                        _nextPerfDate = _currentDirective.NextPerformances[0].PerformanceDate;
                        _nextPerfLifelength = _currentDirective.NextPerformances[0].PerformanceSource;
                    }
                    else
                    {
                        _nextPerfDate = null;
                        _nextPerfLifelength = null;
                    }
                }
            }
            else
            {
                //редактируется новая запись
                int index = 0;

	            for (int i = 0; i < _currentDirective.NextPerformances.Count; i++)
	            {
		            if (_currentDirective.NextPerformances[i].PerformanceNum == _nextPerformance.PerformanceNum)
			            index = i;
	            }

                if (index == 0)
                {
                    //редактируется первое "след.выполнение"
                    if (_currentDirective.LastPerformance != null)
                    {
                        //была сделана запись о выполнении
                        _prevPerfDate = _currentDirective.LastPerformance.RecordDate;
                        _prevPerfLifelength =
                            GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(_currentDirective.LifeLengthParent,
                                                                                  _prevPerfDate.Value);
                    }
                    else
                    {
                        _prevPerfDate = null;
                        _prevPerfLifelength = null;
                    }
                    if (_currentDirective.NextPerformances.Count > 1)
                    {
                        //"след. выполнений" больше одного
                        _nextPerfDate = _currentDirective.NextPerformances[1].PerformanceDate;
                        _nextPerfLifelength = _currentDirective.NextPerformances[1].PerformanceSource;
                    }
                    else
                    {
                        _nextPerfDate = null;
                        _nextPerfLifelength = null;
                    }
                }
                else if (index < _currentDirective.NextPerformances.Count - 1)
                {
                    //редактируется запись из середины списка "след. выполнений"
                    _prevPerfDate = _currentDirective.NextPerformances[index - 1].PerformanceDate;
                    _prevPerfLifelength = _currentDirective.NextPerformances[index - 1].PerformanceSource;
                    
                    _nextPerfDate = _currentDirective.NextPerformances[index + 1].PerformanceDate;
                    _nextPerfLifelength = _currentDirective.NextPerformances[index + 1].PerformanceSource;
                }
                else //(index == _currentDirective.NextPerformances.Count - 1)
                {
                    //редактируется запись из середины списка записей о выполнении
                    _prevPerfDate = _currentDirective.NextPerformances[index - 1].PerformanceDate;
                    _prevPerfLifelength = _currentDirective.NextPerformances[index - 1].PerformanceSource;
                    _nextPerfDate = null;
                    _nextPerfLifelength = null;
                }
            }
            #endregion
        }
		#endregion

		#region private void linkLabelAddDocument_LinkClicked(object sender, EventArgs e)

		private void linkLabelAddDocument_LinkClicked(object sender, EventArgs e)
	    {
			var newDocument = new Document
			{
				Parent = _currentDirectiveRecord,
				ParentTypeId = _currentDirectiveRecord.SmartCoreObjectType.ItemId,
				DocType = DocumentType.TechnicalRecords,
				IsClosed = true,
				IssueDateValidFrom = _currentDirectiveRecord.RecordDate,
			};

			if (_currentDirective is ComponentDirective)
			{
				var component = _currentDirective.LifeLengthParent as Component;

				newDocument.DocumentSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Component compliance") as DocumentSubType;
				newDocument.ContractNumber = $"P/N:{component.PartNumber} S/N:{component.SerialNumber}";
				newDocument.Description = component.Description;
				newDocument.ParentAircraftId = component.ParentAircraftId;
			}
			else if (_currentDirective is Directive)
			{
				var directive = _currentDirective as Directive;
				newDocument.DocumentSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("Directive compliance") as DocumentSubType;
				newDocument.Description = directive.Description;
				newDocument.ParentAircraftId = directive.ParentBaseComponent.ParentAircraftId;

				if (directive.DirectiveType == DirectiveType.AirworthenessDirectives)
					newDocument.ContractNumber = directive.Title + "  §: " + directive.Paragraph;
				else if (directive.DirectiveType == DirectiveType.SB)
					newDocument.ContractNumber = directive.ServiceBulletinNo != "" ? directive.ServiceBulletinNo : "N/A";
				else if (directive.DirectiveType == DirectiveType.EngineeringOrders)
					newDocument.ContractNumber = directive.EngineeringOrders != "" ? directive.EngineeringOrders : "N/A";
			}
			else if (_currentDirective is MaintenanceDirective)
			{
				var directive = _currentDirective as MaintenanceDirective;
				newDocument.DocumentSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("MPD Compliance") as DocumentSubType;
				newDocument.Description = directive.Description;
				newDocument.ParentAircraftId = directive.ParentBaseComponent.ParentAircraftId;
				newDocument.ContractNumber = directive.TaskNumberCheck;
			}


			var form = new DocumentForm(newDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
			{
				_currentDirectiveRecord.Document = newDocument;
				documentControl1.CurrentDocument = newDocument;
			}
		}

	    #endregion

		#region private void ButtonCancelClick(object sender, EventArgs e)

		private void ButtonCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

        #region private void ButtonOkClick(object sender, EventArgs e)

        private void ButtonOkClick(object sender, EventArgs e)
        {
            if (Save())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        #endregion

        #region private void ButtonApplyClick(object sender, EventArgs e)

        private void ButtonApplyClick(object sender, EventArgs e)
        {
            if (Save())
            {
                DialogResult = DialogResult.Yes;
            }
        }
        #endregion

        #region private void dateTimePicker1_ValueChanged(object sender, EventArgs e)

        private void DateTimePicker1ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.ValueChanged -= DateTimePicker1ValueChanged;

            if (_prevPerfDate != null)
            {
                if (dateTimePicker1.Value < _prevPerfDate.Value) dateTimePicker1.Value = _prevPerfDate.Value;
            }
            if (_nextPerfDate != null)
            {
                if (dateTimePicker1.Value > _nextPerfDate.Value)
                    dateTimePicker1.Value = _nextPerfDate.Value;
            }
            if (_currentDirectiveRecord.ItemId <= 0)
            {
                if (dateTimePicker1.Value > DateTime.Now)
                    dateTimePicker1.Value = DateTime.Now;
            }
            else
            {
                if(dateTimePicker1.Value > DateTime.Now && dateTimePicker1.Value > _currentDirectiveRecord.RecordDate)
                    dateTimePicker1.Value = GlobalObjects.CasEnvironment.Calculator.GetMaxDate(DateTime.Now, _currentDirectiveRecord.RecordDate);
            }

            if (_currentDirective.LifeLengthParent == null) return;

            lifelengthViewer_LastCompliance.Lifelength =
                GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnStartOfDay(_currentDirective.LifeLengthParent, dateTimePicker1.Value);

			if (_currentDirective is MaintenanceDirective)
			{
				var mpd = _currentDirective as MaintenanceDirective;

				var flights = GlobalObjects.AircraftFlightsCore.GetAircraftFlightsOnDate(mpd.ParentBaseComponent.ParentAircraftId, dateTimePicker1.Value);

				checkedListBox1.Items.Clear();
				checkedListBox1.Items.AddRange(flights.ToArray());

			}
	        else if (_currentDirective is Directive)
	        {
		        var directive = _currentDirective as Directive;

		        var flights = GlobalObjects.AircraftFlightsCore.GetAircraftFlightsOnDate(directive.ParentBaseComponent.ParentAircraftId, dateTimePicker1.Value);

		        checkedListBox1.Items.Clear();
		        checkedListBox1.Items.AddRange(flights.ToArray());

	        }
			else if (_currentDirective is ComponentDirective)
			{
				var directive = _currentDirective as ComponentDirective;

				var flights = GlobalObjects.AircraftFlightsCore.GetAircraftFlightsOnDate(directive.ParentComponent.ParentAircraftId, dateTimePicker1.Value);

				checkedListBox1.Items.Clear();
				checkedListBox1.Items.AddRange(flights.ToArray());

			}

			dateTimePicker1.ValueChanged += DateTimePicker1ValueChanged;
        }
		#endregion

		#endregion

		#region Events

		#endregion

		private void DirectiveComplianceDialog_Load(object sender, EventArgs e)
		{
			_animatedThreadWorker.RunWorkerAsync();
		}

		private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			var flight = checkedListBox1.Items[e.Index] as AircraftFlight;
			if (e.NewValue == CheckState.Checked)
			{
				lifelengthViewer_LastCompliance.Lifelength += flight.FlightTimeLifelength;
			}
			else if (e.NewValue == CheckState.Unchecked)
			{
				lifelengthViewer_LastCompliance.Lifelength -= flight.FlightTimeLifelength;
			}
		}
	}
}
