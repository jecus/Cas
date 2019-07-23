using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary.Events;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Directives;

namespace CAS.UI.UIControls.DirectivesControls
{
	///<summary>
	///</summary>
	public partial class DirectiveInformationControl : UserControl, IReference
	{
		#region Fields

		private Directive _directive;
		

		#endregion

		#region Constructors

		#region public DirectiveInformationControl()

		///<summary>
		/// Создает объект для отображения информации о директиве
		///</summary>
		public DirectiveInformationControl()
		{
			InitializeComponent();
		}

		#endregion

		#region public DirectiveInformationControl(Directive currentDirective)

		///<summary>
		/// Создает экземпляр класса для отображения информации о директиве
		///</summary>
		///<param name="currentDirective"></param>
		public DirectiveInformationControl(Directive currentDirective)
		{
			if (null == currentDirective)
				throw new ArgumentNullException("currentDirective", "Argument cannot be null");
			_directive = currentDirective;
			InitializeComponent();
			ataChapterComboBox.UpdateInformation();

			AttachedFile adNofile = null;
			if (currentDirective.ADNoFile != null) adNofile = currentDirective.ADNoFile;
			fileControlADNo.UpdateInfo(adNofile, "Adobe PDF Files|*.pdf",
											 "This record does not contain a file proving the AD No. Enclose PDF file to prove the compliance.",
											 "Attached file proves the AD No.");

			AttachedFile sBfile = null;
			if (currentDirective.ServiceBulletinFile != null) sBfile = currentDirective.ServiceBulletinFile;
			fileControlSB.UpdateInfo(sBfile, "Adobe PDF Files|*.pdf",
										   "This record does not contain a file proving the Service bulletin. Enclose PDF file to prove the compliance.",
										   "Attached file proves the Service bulletin.");

			AttachedFile stcfile = null;
			if (currentDirective.STCFile != null) stcfile = currentDirective.STCFile;
			attachedFileControlSTC.UpdateInfo(stcfile, "Adobe PDF Files|*.pdf",
										   "This record does not contain a file proving the Service bulletin. Enclose PDF file to prove the compliance.",
										   "Attached file proves the Service bulletin.");
			AttachedFile eOfile = null;
			if (currentDirective.EngineeringOrderFile != null) eOfile = currentDirective.EngineeringOrderFile;
			fileControlEO.UpdateInfo(eOfile, "Adobe PDF Files|*.pdf",
										   "This record does not contain a file proving the Engineering order. Enclose PDF file to prove the compliance.",
										   "Attached file proves the Engineering order.");
		}

		#endregion

		#endregion

		#region Properties

		#region public Directive CurrentDirective
		///<summary>
		///Текущая директива
		///</summary>
		public Directive CurrentDirective
		{
			set
			{
				_directive = value;
				if (_directive != null)
				{
					ataChapterComboBox.UpdateInformation();
					UpdateInformation();
				}
			}
		}

		#endregion

		#region public ATAChapter ATAChapter
		///<summary>
		///ATAChapter текущего агрегата
		///</summary>
		public AtaChapter ATAChapter
		{
			get
			{
				return ataChapterComboBox.ATAChapter;
			}
			private set
			{
				ataChapterComboBox.ATAChapter = value;
			}
		}

		#endregion

		#region public string EngOrderNumber

		/// <summary>
		/// Engineering order no
		/// </summary>
		public string EngOrderNumber
		{
			private get
			{
				return textBoxEngOrderNo.Text;
			}
			set
			{
				textBoxEngOrderNo.Text = value;
			}
		}

		#endregion

		#region public ADType ADType

		/// <summary>
		/// Возвращает или устанавливает ADType
		/// </summary>
		public ADType ADType
		{
			get { return (ADType) adTypeComboBox.SelectedItem; }
			set { adTypeComboBox.SelectedItem = value; }
		}

		#endregion

		#region public string Title
		///<summary>
		///Имя текущей директивы
		///</summary>
		public string Title
		{
			get
			{
				return textboxTitle.Text;
			}
			set
			{
				textboxTitle.Text = value;
			}
		}

		#endregion

		#region public string ServiceBulletin
		///<summary>
		///Наименование сервисного бюллетеня
		///</summary>
		public string ServiceBulletin
		{
			private get
			{
				return textBoxServiceBulletin.Text;
			}
			set
			{
				textBoxServiceBulletin.Text = value;
			}
		}

		#endregion

		#region public string STCApplicability
		///<summary>
		///Наименование сервисного бюллетеня
		///</summary>
		public string STCApplicability
		{
			private get
			{
				return textBoxStc.Text;
			}
			set
			{
				textBoxStc.Text = value;
			}
		}

		#endregion

		#region public string Paragraph

		/// <summary>
		/// Paragraph текущей директивы
		/// </summary>
		public string Paragraph { private get; set; }

		#endregion

		#region public DateTime EffectiveDate
		/// <summary>
		/// Дата начала использования текущей директивы
		/// </summary>
		public DateTime EffectiveDate
		{
			get
			{
				return dateTimePickerEffDate.Value;
			}
			set
			{
				dateTimePickerEffDate.Value = value;
			}
		}

		#endregion

		#region public string References

		/// <summary>
		/// References текущей директивы
		/// </summary>
		public string References { private get; set; }

		#endregion

		#region public string TLPNo
		/// <summary>
		/// TLPNo текущей директивы
		/// </summary>
		public string Applicability
		{
			private get
			{
				return textboxApplicability.Text;
			}
			set
			{
				textboxApplicability.Text = value;
			}
		}

		#endregion

		#region public string BiWeeklyReport

		/// <summary>
		/// BiWeeklyReport текущей директивы
		/// </summary>
		public string BiWeeklyReport
		{
			private get
			{
				return textboxBiWeeklyReport.Text;
			}
			set
			{
				textboxBiWeeklyReport.Text = value;
			}
		}

		#endregion

		#region public string Subject
		/// <summary>
		/// Описание текущей директивы
		/// </summary>
		public string Subject
		{
			private get { return textboxSubject.Text; }
			set
			{
				textboxSubject.Text = value;
			}
		}

		#endregion

		#region public string Remarks
		///  <summary>
		///  Заметки текущей директивы
		///  </summary>
		public string Remarks
		{
			private get
			{
				return textboxRemarks.Text;
			}
			set
			{
				textboxRemarks.Text = value;
			}
		}

		#endregion

		#region public string SB Subject 
		///  <summary>
		///  Заметки текущей директивы
		///  </summary>
		public string SBSubject
		{
			private get
			{
				return textBoxSBSubject.Text;
			}
			set
			{
				textBoxSBSubject.Text = value;
			}
		}

		#endregion

		#region public string HiddenRemarks
		/// <summary>
		/// Заметки текущей директивы
		/// </summary>
		public string HiddenRemarks
		{
			private get
			{
				return textboxHiddenRemarks.Text;
			}
			set
			{
				textboxHiddenRemarks.Text = value;
			}
		}

		#endregion

		#endregion

		#region Methods

		#region public bool GetChangeStatus(bool directiveExist)
		///<summary>
		///Возвращает значение, показывающее были ли изменения в данном элементе управления
		///</summary>
		///<param name="directiveExist">Показывает, существует ли уже директива или нет</param>
		///<returns></returns>
		public bool GetChangeStatus(bool directiveExist)
		{
			DateTime oldEffDate = _directive.Threshold.EffectiveDate;
			if (directiveExist)
				return (ATAChapter != _directive.ATAChapter ||
						HiddenRemarks != _directive.HiddenRemarks ||
						Title != _directive.Title ||
						ADType != _directive.ADType ||
						EffectiveDate != oldEffDate ||
						ServiceBulletin != _directive.ServiceBulletinNo ||
						STCApplicability != _directive.StcNo ||
						EngOrderNumber != _directive.EngineeringOrders ||
						Applicability != _directive.Applicability ||
						checkBoxIsApplicability.Checked != _directive.IsApplicability ||
						Subject != _directive.Description||
						Remarks != _directive.Remarks ||
						fileControlEO.GetChangeStatus() ||
						fileControlSB.GetChangeStatus() ||
						attachedFileControlSTC.GetChangeStatus() ||
						fileControlADNo.GetChangeStatus());
			return ((ATAChapter != null) ||
					(Paragraph != "") ||
					(ADType != ADType.Airframe) ||
					(Title != "") ||
					(EffectiveDate.Date != DateTime.Today) ||
					(ServiceBulletin != "") ||
					(STCApplicability != "") ||
					(EngOrderNumber != "") ||
					(References != "") ||
					(Applicability != "") ||
					(BiWeeklyReport != "") ||
					(Subject != "") ||
					(Remarks != ""));
		}

		#endregion

		#region private void UpdateInformation()

		/// <summary>
		/// 3аполняет поля для редактирования директивы
		/// </summary>
		private void UpdateInformation()
		{
			if (_directive == null)
				return;

			dateTimePickerEffDate.ValueChanged -= DateTimePickerEffDateValueChanged;

			ATAChapter = _directive.ATAChapter;
			Title = _directive.Title;
			EffectiveDate = _directive.Threshold.EffectiveDate;
			ServiceBulletin = _directive.ServiceBulletinNo;
			STCApplicability = _directive.StcNo;
			EngOrderNumber = _directive.EngineeringOrders;
			checkBoxIsApplicability.Checked = _directive.IsApplicability;
			Applicability = _directive.IsApplicability ? $"APL  {_directive.Applicability}" : $"N/A  {_directive.Applicability}";
			Subject = _directive.Description;
			Remarks = _directive.Remarks;
			SBSubject = _directive.SBSubjects;
			HiddenRemarks = _directive.HiddenRemarks;
			bool permission = true; //currentDirective.HasPermission(Users.IdentityUser, DataEvent.Update);

			fileControlADNo.UpdateInfo(_directive.ADNoFile,
							"Adobe PDF Files|*.pdf",
							"This record does not contain a file proving the AD No. Enclose PDF file to prove the compliance.",
							"Attached file proves the AD No.");
			fileControlSB.UpdateInfo(_directive.ServiceBulletinFile,
							"Adobe PDF Files|*.pdf",
							"This record does not contain a file proving the Service bulletin. Enclose PDF file to prove the compliance.",
							"Attached file proves the Service bulletin.");
			attachedFileControlSTC.UpdateInfo(_directive.STCFile,
							"Adobe PDF Files|*.pdf",
							"This record does not contain a file proving the Service bulletin. Enclose PDF file to prove the compliance.",
							"Attached file proves the Service bulletin.");
			fileControlEO.UpdateInfo(_directive.EngineeringOrderFile,
							"Adobe PDF Files|*.pdf",
							"This record does not contain a file proving the Engineering order. Enclose PDF file to prove the compliance.",
							"Attached file proves the Engineering order.");

			ataChapterComboBox.Enabled = permission;
			textboxTitle.ReadOnly = !permission;
			dateTimePickerEffDate.Enabled = permission;
			textboxApplicability.ReadOnly = !permission;
			textboxSubject.ReadOnly = !permission;
			textboxRemarks.ReadOnly = !permission;
			textBoxSBSubject.ReadOnly = !permission;
			textboxHiddenRemarks.ReadOnly = !permission;
			

			adTypeComboBox.Items.Clear();
			foreach (object o in Enum.GetValues(typeof(ADType)))
				adTypeComboBox.Items.Add(o);

			ADType = _directive.ADType;

			dateTimePickerEffDate.ValueChanged += DateTimePickerEffDateValueChanged;
		}

		#endregion

		#region public bool ValidateData(out string message)
		/// <summary>
		/// Возвращает значение, показывающее является ли значение элемента управления допустимым
		/// </summary>
		/// <returns></returns>
		public bool ValidateData(out string message)
		{
			message = "";
			if (ATAChapter == null || ATAChapter.ItemId <= 0)
			{
				if (message != "") message += "\n ";
				message += "Please select ATA chapter";
			}
			if (Title == "")
			{
				message += "You should enter AD No ";
			}

			string validateFiles;
			if (!fileControlADNo.ValidateData(out validateFiles))
			{
				if (message != "") message += "\n ";
				message += "AD File: " + validateFiles;
			}

			if (!fileControlSB.ValidateData(out validateFiles))
			{
				if (message != "") message += "\n ";
				message += "SB File: " + validateFiles;
			}

			if (!fileControlEO.ValidateData(out validateFiles))
			{
				if (message != "") message += "\n ";
				message += "EO File: " + validateFiles;
			}

			if (message != "")
				return false;
			return true;
		}

		#endregion

		#region public void ApplyChanges(Directive directive, bool changePageName)

		/// <summary>
		/// Данные у директивы обновляются по введенным данным
		/// </summary>
		/// <param name="directive">Директива</param>
		/// <param name="changePageName">Менять ли название вкладки</param>
		public void ApplyChanges(Directive directive, bool changePageName)
		{
			textboxTitle.Focus();
			if (directive == null)
				throw new ArgumentNullException("directive");
			directive.ATAChapter = ATAChapter;
			if (directive.Title != Title)
			{
				directive.Title = Title;

				if (changePageName /*&& destinationDirective.ExistAtDataBase*/)
				{
					string caption = "";
					if (directive.ParentBaseComponent != null)
					{
						var baseComponent = directive.ParentBaseComponent;

						if (baseComponent.BaseComponentTypeId == BaseComponentType.Frame.ItemId)
						{
							//у Frame всегда есть ParentAircraftId
							caption = $"{DestinationHelper.GetDestinationStringFromAircraft(baseComponent.ParentAircraftId, false, null)}. {directive.DirectiveType.CommonName}. {directive.Title}";
						}
						else
						{
							if (baseComponent.ParentAircraftId > 0)
								caption = $"{DestinationHelper.GetDestinationStringFromAircraft(baseComponent.ParentAircraftId, false, null)}. ";
							else if (baseComponent.ParentStoreId > 0)
								caption = $"{DestinationHelper.GetDestinationStringFromStore(baseComponent.ParentStoreId, null, true)}. ";

							caption += baseComponent + ". " + directive.DirectiveType.CommonName + ". " + directive.Title;
						}
					}
					if (DisplayerRequested != null)
						DisplayerRequested(this,
										   new ReferenceEventArgs(null,
																  ReflectionTypes.ChangeTextOfContainingDisplayer,
																  caption));
				}
			}

			directive.HiddenRemarks = HiddenRemarks;
			directive.Threshold.EffectiveDate = EffectiveDate;
			directive.StcNo = STCApplicability;
			directive.EngineeringOrders = EngOrderNumber;
			directive.ServiceBulletinNo = ServiceBulletin;
			directive.ADType = ADType;
			directive.Description = Subject;
			directive.Remarks = Remarks;
			directive.SBSubjects = SBSubject;
			directive.IsApplicability = checkBoxIsApplicability.Checked;
			directive.Applicability = Applicability;

			if (checkBoxIsApplicability.Checked)
				directive.Applicability = directive.Applicability.Replace("APL", "").TrimStart(); 
			else directive.Applicability = directive.Applicability.Replace("N/A", "").TrimStart();


			if (fileControlSB.GetChangeStatus())
			{
				fileControlSB.ApplyChanges();
				directive.ServiceBulletinFile = fileControlSB.AttachedFile;
			}

			if (attachedFileControlSTC.GetChangeStatus())
			{
				attachedFileControlSTC.ApplyChanges();
				directive.STCFile = attachedFileControlSTC.AttachedFile;
			}

			if (fileControlEO.GetChangeStatus())
			{
				fileControlEO.ApplyChanges();
				directive.EngineeringOrderFile = fileControlEO.AttachedFile;
			}

			if (fileControlADNo.GetChangeStatus())
			{
				fileControlADNo.ApplyChanges();
				directive.ADNoFile = fileControlADNo.AttachedFile;
			}
		}
		#endregion

		#region public void ClearFields()

		/// <summary>
		/// Очищает все поля
		/// </summary>
		public void ClearFields()
		{
			ataChapterComboBox.ClearValue();
			ADType = ADType.Airframe;
			Title = "";
			//Paragraph = "";
			dateTimePickerEffDate.Value = DateTime.Today;
			EngOrderNumber = "";
			Applicability = "";
			//SupersededBy = "";
			//Supersedes = "";
			STCApplicability = "";
			Subject = "";
			//Threshold = "";
			Remarks = "";
			HiddenRemarks = "";

			fileControlEO.AttachedFile = null;
			fileControlADNo.AttachedFile = null;
			fileControlSB.AttachedFile = null;
		}

		#endregion

		#region public void SetFieldsUnsaved()

		/// <summary>
		/// Очищает все поля
		/// </summary>
		public void SetFieldsUnsaved()
		{

			if (fileControlEO.AttachedFile != null)
				fileControlEO.AttachedFile.ItemId = -1;
			if (fileControlADNo.AttachedFile != null)
				fileControlADNo.AttachedFile.ItemId = -1;
			if (fileControlSB.AttachedFile != null)
				fileControlSB.AttachedFile.ItemId = -1;
		}

		#endregion

		#region private void DateTimePickerEffDateValueChanged(object sender, EventArgs e)
		private void DateTimePickerEffDateValueChanged(object sender, EventArgs e)
		{
			InvokeEffDateChanget(EffectiveDate);
		}
		#endregion

		#endregion

		#region IReference Members

		/// <summary>
		/// Displayer for displaying entity
		/// </summary>
		public IDisplayer Displayer { get; set; }

		/// <summary>
		/// Text of page's header that Reference lead to
		/// </summary>
		public string DisplayerText { get; set; }

		/// <summary>
		/// Entity to display
		/// </summary>
		public IDisplayingEntity Entity { get; set; }

		/// <summary>
		/// Type of reflection
		/// </summary>
		public ReflectionTypes ReflectionType { get; set; }

		/// <summary>
		/// Occurs when linked invoker requests displaying 
		/// </summary>
		public event EventHandler<ReferenceEventArgs> DisplayerRequested;

		#endregion

		#region Events
		///<summary>
		/// Возникает во время изменения эффективной даты 
		///</summary>
		[Category("Flight data")]
		[Description("Возникает во время изменения эффективной даты")]
		public event DateChangedEventHandler EffDateChanget;

		///<summary>
		/// Сигнализирует об изменени эффективной даты
		///</summary>
		///<param name="e"></param>
		private void InvokeEffDateChanget(DateTime e)
		{
			DateChangedEventHandler handler = EffDateChanget;
			if (handler != null) handler(new DateChangedEventArgs(e));
		}
		#endregion

		private void checkBoxIsApplicability_CheckedChanged(object sender, EventArgs e)
		{
			textboxApplicability.Text = checkBoxIsApplicability.Checked ? "APL" : "N/A";
		}
	}
}
