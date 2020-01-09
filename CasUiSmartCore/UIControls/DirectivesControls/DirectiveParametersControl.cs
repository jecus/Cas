using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using AvControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.KitControls;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Directives;
using CAS.UI.Helpers;

namespace CAS.UI.UIControls.DirectivesControls
{
	/// <summary>
	/// Класс для отображения атрибутов и дополнительной информации о директиве
	/// </summary>
	[Designer(typeof(DirectiveParametersControlDesigner))]
	public class DirectiveParametersControl : UserControl
	{
		private LookupCombobox lookupComboboxForCompnt;
		private RadioButton radio_FirstWhicheverLast;
		private RadioButton radio_FirstWhicheverFirst;
		private CheckBox checkBoxRepeat;
		private LifelengthViewer lifelengthViewer_SinceEffDate;
		private LifelengthViewer lifelengthViewer_SinceNew;
		private LifelengthViewer lifelengthViewer_Repeat;
		private LifelengthViewer lifelengthViewer_FirstNotify;
		private Label labelForComponent;
		public LinkLabel linkLabelEditKit;
		private AvControls.StatusImageLink.StatusImageLinkLabel imageLinkLabelStatus;
		private TextBox textBoxKitRequired;
		private Label labelChart;
		public LinkLabel linkLabelEditChart;
		private TextBox textBoxChart;
		private RadioButton radio_RepeatWhicheverFirst;
		private Label labelKitRequired;
		private GroupBox groupBoxClose;
		private CheckBox checkBoxClose;
		private Label labelParagraph;
		private Label labelNDT;
		private TextBox textBoxParagraph;
		private CheckBox checkBoxIsTemporary;
		private ComboBox comboBoxWorkType;
		private TextBox _textboxCost;
		private Label _labelCost;
		private Label _labelIsTemporary;
		private TextBox _textboxManHours;
		private LifelengthViewer lifelengthViewer_RepeatNotify;
		private GroupBox groupBox_Repetative;
		private RadioButton radio_RepeatWhicheverLast;
		private Label _labelManHours;
		private GroupBox groupFirstPerformance;
		private Label labelThreshold;

		#region Fields

		private Directive _currentDirective;
		private ComboBox comboBoxNdt;
		private ComboBox comboBoxSupersedes;
		private Label labelSupersedes;
		private ComboBox comboBoxSuperseded;
		private Label labelSuperseded;
		private ComboBox comboBoxOrder;
		private Label label3;
		private Label label6;
		private TextBox textBoxWorkArea;
		private Label labelZone;
		private TextBox textBoxZone;
		private Label labelAccess;
		private TextBox textBoxAccess;
		private Label labelAffectedBy;
		private TextBox textBoxAffectedBy;
		private ComboBox comboBoxAffects;
		private Label labelAffects;
		private ComboBox comboBoxReason;
		private Label labelReason;
		private DateTime _effDate = DateTimeExtend.GetCASMinDateTime();

		#endregion

		#region Constructors

		#region public DirectiveAttributesControl()

		/// <summary>
		/// Пустой конструктор
		/// </summary>
		public DirectiveParametersControl()
		{
			InitializeComponent();
		}

		#endregion

		#region public DirectiveAttributesControl(Directive currentDirective) : this()

		/// <summary>
		/// Создает объект для отображения атрибутов и дополнительной информации о директиве
		/// </summary>
		/// <param name="currentDirective"></param>
		public DirectiveParametersControl(Directive currentDirective) : this()
		{
			if (null == currentDirective)
				throw new ArgumentNullException("currentDirective", "Argument cannot be null");
			_currentDirective = currentDirective;

			UpdateInformation();

			
		}

		private void Completed()
		{
			comboBoxOrder.Items.Clear();
			comboBoxOrder.Items.AddRange(DirectiveOrder.Items.ToArray());
			comboBoxOrder.SelectedItem = _currentDirective.DirectiveOrder;

			comboBoxSuperseded.Items.Clear();
			comboBoxSuperseded.Items.AddRange(Directives.ToArray());
			comboBoxSuperseded.DisplayMember = "Title";
			if (_currentDirective.SupersededId != null)
				comboBoxSuperseded.SelectedItem = Directives.FirstOrDefault(i => i.ItemId == _currentDirective.SupersededId);

			comboBoxSupersedes.Items.Clear();
			comboBoxSupersedes.Items.AddRange(Directives.ToArray());
			comboBoxSupersedes.DisplayMember = "Title";
			if (_currentDirective.SupersedesId != null)
				comboBoxSupersedes.SelectedItem = Directives.FirstOrDefault(i => i.ItemId == _currentDirective.SupersedesId);
		}

		private void DoWork()
		{
			var aircraft =
				GlobalObjects.AircraftsCore.GetAircraftById(_currentDirective.ParentBaseComponent.ParentAircraftId);
			Directives.AddRange(GlobalObjects.DirectiveCore.GetDirectives(aircraft, DirectiveType.AirworthenessDirectives));
		}

		#endregion

		#endregion

		#region Properties

		public List<Directive> Directives = new List<Directive>();

		#region public string DamageChartLocation
		/// <summary>
		/// DamageChartLocation
		/// </summary>
		public string DamageChartLocation
		{
			get
			{
				return textBoxChart.Text;
			}
			set
			{
				textBoxChart.Text = value;
			}
		}

		#endregion

		#region public Directive CurrentDirective

		/// <summary>
		/// текущая  директива
		/// </summary>
		public Directive CurrentDirective
		{
			set
			{
				_currentDirective = value;

				if (_currentDirective.DirectiveType == DirectiveType.AirworthenessDirectives)
				{
					Task.Run(() => DoWork())
						.ContinueWith(task => Completed(), TaskScheduler.FromCurrentSynchronizationContext());
				}
				else
				{
					labelSuperseded.Visible = false;
					labelSupersedes.Visible = false;
					label3.Visible = false;
					comboBoxSuperseded.Visible = false;
					comboBoxSupersedes.Visible = false;
					comboBoxOrder.Visible = false;

				}
				
				UpdateInformation();

			}
			get
			{
				return _currentDirective;
			}
		}

		#endregion

		#region public DirectiveThreshold Threshold { get; set; }

		/// <summary>
		/// Выполнение директивы
		/// </summary>
		public DirectiveThreshold Threshold
		{
			get { return GetThreshold(); }
			set { ApplyThreshold(value); }
		}

		#endregion

		#region public bool isClosed { get; set; }

		public bool isClosed { get; set; }
	   
		#endregion

		#region public DateTime EffectiveDate
		/// <summary>
		/// Дата начала использования текущей директивы
		/// </summary>
		public DateTime EffectiveDate
		{
			set { _effDate = value; }
		}

		#endregion

		#endregion

		#region Methods

		#region private void InitializeComponent()

		private void InitializeComponent()
		{
			this.radio_FirstWhicheverLast = new System.Windows.Forms.RadioButton();
			this.radio_FirstWhicheverFirst = new System.Windows.Forms.RadioButton();
			this.checkBoxRepeat = new System.Windows.Forms.CheckBox();
			this.labelForComponent = new System.Windows.Forms.Label();
			this.linkLabelEditKit = new System.Windows.Forms.LinkLabel();
			this.imageLinkLabelStatus = new AvControls.StatusImageLink.StatusImageLinkLabel();
			this.textBoxKitRequired = new System.Windows.Forms.TextBox();
			this.labelChart = new System.Windows.Forms.Label();
			this.linkLabelEditChart = new System.Windows.Forms.LinkLabel();
			this.textBoxChart = new System.Windows.Forms.TextBox();
			this.radio_RepeatWhicheverFirst = new System.Windows.Forms.RadioButton();
			this.labelKitRequired = new System.Windows.Forms.Label();
			this.groupBoxClose = new System.Windows.Forms.GroupBox();
			this.checkBoxClose = new System.Windows.Forms.CheckBox();
			this.labelParagraph = new System.Windows.Forms.Label();
			this.labelNDT = new System.Windows.Forms.Label();
			this.textBoxParagraph = new System.Windows.Forms.TextBox();
			this.checkBoxIsTemporary = new System.Windows.Forms.CheckBox();
			this.comboBoxWorkType = new System.Windows.Forms.ComboBox();
			this._textboxCost = new System.Windows.Forms.TextBox();
			this._labelCost = new System.Windows.Forms.Label();
			this._labelIsTemporary = new System.Windows.Forms.Label();
			this._textboxManHours = new System.Windows.Forms.TextBox();
			this.groupBox_Repetative = new System.Windows.Forms.GroupBox();
			this.radio_RepeatWhicheverLast = new System.Windows.Forms.RadioButton();
			this.lifelengthViewer_RepeatNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewer_Repeat = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this._labelManHours = new System.Windows.Forms.Label();
			this.groupFirstPerformance = new System.Windows.Forms.GroupBox();
			this.lifelengthViewer_SinceEffDate = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewer_SinceNew = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.lifelengthViewer_FirstNotify = new CAS.UI.UIControls.Auxiliary.LifelengthViewer();
			this.labelThreshold = new System.Windows.Forms.Label();
			this.comboBoxNdt = new System.Windows.Forms.ComboBox();
			this.lookupComboboxForCompnt = new CAS.UI.UIControls.Auxiliary.LookupCombobox();
			this.comboBoxSupersedes = new System.Windows.Forms.ComboBox();
			this.labelSupersedes = new System.Windows.Forms.Label();
			this.comboBoxSuperseded = new System.Windows.Forms.ComboBox();
			this.labelSuperseded = new System.Windows.Forms.Label();
			this.comboBoxOrder = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxWorkArea = new System.Windows.Forms.TextBox();
			this.labelZone = new System.Windows.Forms.Label();
			this.textBoxZone = new System.Windows.Forms.TextBox();
			this.labelAccess = new System.Windows.Forms.Label();
			this.textBoxAccess = new System.Windows.Forms.TextBox();
			this.labelAffectedBy = new System.Windows.Forms.Label();
			this.textBoxAffectedBy = new System.Windows.Forms.TextBox();
			this.comboBoxAffects = new System.Windows.Forms.ComboBox();
			this.labelAffects = new System.Windows.Forms.Label();
			this.comboBoxReason = new System.Windows.Forms.ComboBox();
			this.labelReason = new System.Windows.Forms.Label();
			this.groupBoxClose.SuspendLayout();
			this.groupBox_Repetative.SuspendLayout();
			this.groupFirstPerformance.SuspendLayout();
			this.SuspendLayout();
			// 
			// radio_FirstWhicheverLast
			// 
			this.radio_FirstWhicheverLast.AutoSize = true;
			this.radio_FirstWhicheverLast.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.radio_FirstWhicheverLast.Location = new System.Drawing.Point(322, 176);
			this.radio_FirstWhicheverLast.Name = "radio_FirstWhicheverLast";
			this.radio_FirstWhicheverLast.Size = new System.Drawing.Size(146, 22);
			this.radio_FirstWhicheverLast.TabIndex = 22;
			this.radio_FirstWhicheverLast.Text = "Whichever Later";
			this.radio_FirstWhicheverLast.UseVisualStyleBackColor = true;
			// 
			// radio_FirstWhicheverFirst
			// 
			this.radio_FirstWhicheverFirst.AutoSize = true;
			this.radio_FirstWhicheverFirst.Checked = true;
			this.radio_FirstWhicheverFirst.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.radio_FirstWhicheverFirst.Location = new System.Drawing.Point(60, 176);
			this.radio_FirstWhicheverFirst.Name = "radio_FirstWhicheverFirst";
			this.radio_FirstWhicheverFirst.Size = new System.Drawing.Size(140, 22);
			this.radio_FirstWhicheverFirst.TabIndex = 21;
			this.radio_FirstWhicheverFirst.TabStop = true;
			this.radio_FirstWhicheverFirst.Text = "Whichever First";
			this.radio_FirstWhicheverFirst.UseVisualStyleBackColor = true;
			// 
			// checkBoxRepeat
			// 
			this.checkBoxRepeat.AutoSize = true;
			this.checkBoxRepeat.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.checkBoxRepeat.ForeColor = System.Drawing.Color.DimGray;
			this.checkBoxRepeat.Location = new System.Drawing.Point(14, 21);
			this.checkBoxRepeat.Name = "checkBoxRepeat";
			this.checkBoxRepeat.Size = new System.Drawing.Size(106, 22);
			this.checkBoxRepeat.TabIndex = 11;
			this.checkBoxRepeat.Text = "Repetative";
			this.checkBoxRepeat.UseVisualStyleBackColor = true;
			this.checkBoxRepeat.CheckedChanged += new System.EventHandler(this.CheckBoxRepeatCheckedChanged);
			// 
			// labelForComponent
			// 
			this.labelForComponent.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelForComponent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelForComponent.Location = new System.Drawing.Point(3, 186);
			this.labelForComponent.Name = "labelForComponent";
			this.labelForComponent.Size = new System.Drawing.Size(124, 22);
			this.labelForComponent.TabIndex = 203;
			this.labelForComponent.Text = "For Component";
			// 
			// linkLabelEditKit
			// 
			this.linkLabelEditKit.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelEditKit.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelEditKit.Location = new System.Drawing.Point(1057, 33);
			this.linkLabelEditKit.Name = "linkLabelEditKit";
			this.linkLabelEditKit.Size = new System.Drawing.Size(37, 23);
			this.linkLabelEditKit.TabIndex = 202;
			this.linkLabelEditKit.TabStop = true;
			this.linkLabelEditKit.Text = "Edit";
			this.linkLabelEditKit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelEditKit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelEditKitLinkClicked);
			// 
			// imageLinkLabelStatus
			// 
			this.imageLinkLabelStatus.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
			this.imageLinkLabelStatus.Enabled = false;
			this.imageLinkLabelStatus.HoveredLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(163)))), ((int)(((byte)(255)))));
			this.imageLinkLabelStatus.ImageBackColor = System.Drawing.Color.Transparent;
			this.imageLinkLabelStatus.ImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.imageLinkLabelStatus.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.imageLinkLabelStatus.LinkMouseCapturedColor = System.Drawing.Color.Empty;
			this.imageLinkLabelStatus.Location = new System.Drawing.Point(3, 2);
			this.imageLinkLabelStatus.Margin = new System.Windows.Forms.Padding(4);
			this.imageLinkLabelStatus.Name = "imageLinkLabelStatus";
			this.imageLinkLabelStatus.Size = new System.Drawing.Size(83, 25);
			this.imageLinkLabelStatus.TabIndex = 193;
			this.imageLinkLabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.imageLinkLabelStatus.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			// 
			// textBoxKitRequired
			// 
			this.textBoxKitRequired.BackColor = System.Drawing.Color.White;
			this.textBoxKitRequired.Enabled = false;
			this.textBoxKitRequired.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxKitRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxKitRequired.Location = new System.Drawing.Point(743, 35);
			this.textBoxKitRequired.MaxLength = 50;
			this.textBoxKitRequired.Name = "textBoxKitRequired";
			this.textBoxKitRequired.Size = new System.Drawing.Size(308, 22);
			this.textBoxKitRequired.TabIndex = 188;
			// 
			// labelChart
			// 
			this.labelChart.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelChart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelChart.Location = new System.Drawing.Point(593, 5);
			this.labelChart.Name = "labelChart";
			this.labelChart.Size = new System.Drawing.Size(150, 25);
			this.labelChart.TabIndex = 199;
			this.labelChart.Text = "Chart:";
			this.labelChart.Visible = false;
			// 
			// linkLabelEditChart
			// 
			this.linkLabelEditChart.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.linkLabelEditChart.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.linkLabelEditChart.Location = new System.Drawing.Point(1056, 1);
			this.linkLabelEditChart.Name = "linkLabelEditChart";
			this.linkLabelEditChart.Size = new System.Drawing.Size(37, 23);
			this.linkLabelEditChart.TabIndex = 201;
			this.linkLabelEditChart.TabStop = true;
			this.linkLabelEditChart.Text = "Edit";
			this.linkLabelEditChart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabelEditChart.Visible = false;
			this.linkLabelEditChart.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelEditChartLinkClicked);
			// 
			// textBoxChart
			// 
			this.textBoxChart.BackColor = System.Drawing.Color.White;
			this.textBoxChart.Enabled = false;
			this.textBoxChart.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxChart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxChart.Location = new System.Drawing.Point(743, 2);
			this.textBoxChart.MaxLength = 4;
			this.textBoxChart.Name = "textBoxChart";
			this.textBoxChart.Size = new System.Drawing.Size(308, 22);
			this.textBoxChart.TabIndex = 200;
			this.textBoxChart.Visible = false;
			// 
			// radio_RepeatWhicheverFirst
			// 
			this.radio_RepeatWhicheverFirst.AutoSize = true;
			this.radio_RepeatWhicheverFirst.Checked = true;
			this.radio_RepeatWhicheverFirst.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.radio_RepeatWhicheverFirst.Location = new System.Drawing.Point(73, 176);
			this.radio_RepeatWhicheverFirst.Name = "radio_RepeatWhicheverFirst";
			this.radio_RepeatWhicheverFirst.Size = new System.Drawing.Size(140, 22);
			this.radio_RepeatWhicheverFirst.TabIndex = 23;
			this.radio_RepeatWhicheverFirst.TabStop = true;
			this.radio_RepeatWhicheverFirst.Text = "Whichever First";
			this.radio_RepeatWhicheverFirst.UseVisualStyleBackColor = true;
			// 
			// labelKitRequired
			// 
			this.labelKitRequired.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelKitRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelKitRequired.Location = new System.Drawing.Point(593, 38);
			this.labelKitRequired.Name = "labelKitRequired";
			this.labelKitRequired.Size = new System.Drawing.Size(150, 25);
			this.labelKitRequired.TabIndex = 183;
			this.labelKitRequired.Text = "Part and Material:";
			// 
			// groupBoxClose
			// 
			this.groupBoxClose.Controls.Add(this.checkBoxClose);
			this.groupBoxClose.ForeColor = System.Drawing.Color.DimGray;
			this.groupBoxClose.Location = new System.Drawing.Point(1093, 275);
			this.groupBoxClose.Name = "groupBoxClose";
			this.groupBoxClose.Size = new System.Drawing.Size(86, 223);
			this.groupBoxClose.TabIndex = 195;
			this.groupBoxClose.TabStop = false;
			this.groupBoxClose.Text = "STATUS";
			// 
			// checkBoxClose
			// 
			this.checkBoxClose.AutoSize = true;
			this.checkBoxClose.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.checkBoxClose.ForeColor = System.Drawing.Color.DimGray;
			this.checkBoxClose.Location = new System.Drawing.Point(8, 21);
			this.checkBoxClose.Name = "checkBoxClose";
			this.checkBoxClose.Size = new System.Drawing.Size(68, 22);
			this.checkBoxClose.TabIndex = 25;
			this.checkBoxClose.Text = "Close";
			this.checkBoxClose.UseVisualStyleBackColor = true;
			this.checkBoxClose.CheckedChanged += new System.EventHandler(this.CheckBoxCloseCheckedChanged);
			// 
			// labelParagraph
			// 
			this.labelParagraph.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelParagraph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelParagraph.Location = new System.Drawing.Point(369, 0);
			this.labelParagraph.Name = "labelParagraph";
			this.labelParagraph.Size = new System.Drawing.Size(30, 25);
			this.labelParagraph.TabIndex = 197;
			this.labelParagraph.Text = "§:";
			this.labelParagraph.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelNDT
			// 
			this.labelNDT.Font = new System.Drawing.Font("Verdana", 9F);
			this.labelNDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelNDT.Location = new System.Drawing.Point(3, 208);
			this.labelNDT.Name = "labelNDT";
			this.labelNDT.Size = new System.Drawing.Size(106, 25);
			this.labelNDT.TabIndex = 186;
			this.labelNDT.Text = "NDT:";
			this.labelNDT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxParagraph
			// 
			this.textBoxParagraph.BackColor = System.Drawing.Color.White;
			this.textBoxParagraph.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxParagraph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxParagraph.Location = new System.Drawing.Point(405, 2);
			this.textBoxParagraph.MaxLength = 50;
			this.textBoxParagraph.Name = "textBoxParagraph";
			this.textBoxParagraph.Size = new System.Drawing.Size(98, 22);
			this.textBoxParagraph.TabIndex = 198;
			// 
			// checkBoxIsTemporary
			// 
			this.checkBoxIsTemporary.AutoSize = true;
			this.checkBoxIsTemporary.Cursor = System.Windows.Forms.Cursors.Hand;
			this.checkBoxIsTemporary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkBoxIsTemporary.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.checkBoxIsTemporary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(155)))), ((int)(((byte)(246)))));
			this.checkBoxIsTemporary.Location = new System.Drawing.Point(1053, 249);
			this.checkBoxIsTemporary.Name = "checkBoxIsTemporary";
			this.checkBoxIsTemporary.Size = new System.Drawing.Size(12, 11);
			this.checkBoxIsTemporary.TabIndex = 190;
			// 
			// comboBoxWorkType
			// 
			this.comboBoxWorkType.BackColor = System.Drawing.Color.White;
			this.comboBoxWorkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxWorkType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.comboBoxWorkType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxWorkType.Location = new System.Drawing.Point(153, 2);
			this.comboBoxWorkType.Name = "comboBoxWorkType";
			this.comboBoxWorkType.Size = new System.Drawing.Size(210, 22);
			this.comboBoxWorkType.TabIndex = 196;
			this.comboBoxWorkType.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// _textboxCost
			// 
			this._textboxCost.BackColor = System.Drawing.Color.White;
			this._textboxCost.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._textboxCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this._textboxCost.Location = new System.Drawing.Point(153, 71);
			this._textboxCost.Name = "_textboxCost";
			this._textboxCost.Size = new System.Drawing.Size(350, 22);
			this._textboxCost.TabIndex = 189;
			// 
			// _labelCost
			// 
			this._labelCost.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._labelCost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this._labelCost.Location = new System.Drawing.Point(3, 74);
			this._labelCost.Name = "_labelCost";
			this._labelCost.Size = new System.Drawing.Size(150, 25);
			this._labelCost.TabIndex = 185;
			this._labelCost.Text = "Cost (USD)";
			// 
			// _labelIsTemporary
			// 
			this._labelIsTemporary.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._labelIsTemporary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this._labelIsTemporary.Location = new System.Drawing.Point(903, 247);
			this._labelIsTemporary.Name = "_labelIsTemporary";
			this._labelIsTemporary.Size = new System.Drawing.Size(150, 25);
			this._labelIsTemporary.TabIndex = 185;
			this._labelIsTemporary.Text = "Is Temporary";
			// 
			// _textboxManHours
			// 
			this._textboxManHours.BackColor = System.Drawing.Color.White;
			this._textboxManHours.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._textboxManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this._textboxManHours.Location = new System.Drawing.Point(153, 35);
			this._textboxManHours.Name = "_textboxManHours";
			this._textboxManHours.Size = new System.Drawing.Size(350, 22);
			this._textboxManHours.TabIndex = 187;
			// 
			// groupBox_Repetative
			// 
			this.groupBox_Repetative.AutoSize = true;
			this.groupBox_Repetative.Controls.Add(this.radio_RepeatWhicheverLast);
			this.groupBox_Repetative.Controls.Add(this.lifelengthViewer_RepeatNotify);
			this.groupBox_Repetative.Controls.Add(this.radio_RepeatWhicheverFirst);
			this.groupBox_Repetative.Controls.Add(this.checkBoxRepeat);
			this.groupBox_Repetative.Controls.Add(this.lifelengthViewer_Repeat);
			this.groupBox_Repetative.ForeColor = System.Drawing.Color.DimGray;
			this.groupBox_Repetative.Location = new System.Drawing.Point(567, 275);
			this.groupBox_Repetative.Name = "groupBox_Repetative";
			this.groupBox_Repetative.Size = new System.Drawing.Size(486, 223);
			this.groupBox_Repetative.TabIndex = 192;
			this.groupBox_Repetative.TabStop = false;
			this.groupBox_Repetative.Text = "REPEAT";
			// 
			// radio_RepeatWhicheverLast
			// 
			this.radio_RepeatWhicheverLast.AutoSize = true;
			this.radio_RepeatWhicheverLast.Font = new System.Drawing.Font("Verdana", 11.25F);
			this.radio_RepeatWhicheverLast.Location = new System.Drawing.Point(334, 176);
			this.radio_RepeatWhicheverLast.Name = "radio_RepeatWhicheverLast";
			this.radio_RepeatWhicheverLast.Size = new System.Drawing.Size(146, 22);
			this.radio_RepeatWhicheverLast.TabIndex = 24;
			this.radio_RepeatWhicheverLast.Text = "Whichever Later";
			this.radio_RepeatWhicheverLast.UseVisualStyleBackColor = true;
			// 
			// lifelengthViewer_RepeatNotify
			// 
			this.lifelengthViewer_RepeatNotify.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lifelengthViewer_RepeatNotify.AutoSize = true;
			this.lifelengthViewer_RepeatNotify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer_RepeatNotify.CalendarApplicable = false;
			this.lifelengthViewer_RepeatNotify.CyclesApplicable = false;
			this.lifelengthViewer_RepeatNotify.Enabled = false;
			this.lifelengthViewer_RepeatNotify.EnabledCalendar = true;
			this.lifelengthViewer_RepeatNotify.EnabledCycle = true;
			this.lifelengthViewer_RepeatNotify.EnabledHours = true;
			this.lifelengthViewer_RepeatNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer_RepeatNotify.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer_RepeatNotify.HeaderCalendar = "Calendar";
			this.lifelengthViewer_RepeatNotify.HeaderCycles = "Cycles";
			this.lifelengthViewer_RepeatNotify.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer_RepeatNotify.HeaderHours = "Hours";
			this.lifelengthViewer_RepeatNotify.HoursApplicable = false;
			this.lifelengthViewer_RepeatNotify.LeftHeader = "Notify";
			this.lifelengthViewer_RepeatNotify.Location = new System.Drawing.Point(72, 89);
			this.lifelengthViewer_RepeatNotify.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer_RepeatNotify.Modified = false;
			this.lifelengthViewer_RepeatNotify.Name = "lifelengthViewer_RepeatNotify";
			this.lifelengthViewer_RepeatNotify.ReadOnly = false;
			this.lifelengthViewer_RepeatNotify.ShowCalendar = true;
			this.lifelengthViewer_RepeatNotify.ShowFormattedCalendar = false;
			this.lifelengthViewer_RepeatNotify.ShowHeaders = false;
			this.lifelengthViewer_RepeatNotify.ShowMinutes = true;
			this.lifelengthViewer_RepeatNotify.Size = new System.Drawing.Size(407, 35);
			this.lifelengthViewer_RepeatNotify.SystemCalculated = true;
			this.lifelengthViewer_RepeatNotify.TabIndex = 13;
			// 
			// lifelengthViewer_Repeat
			// 
			this.lifelengthViewer_Repeat.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lifelengthViewer_Repeat.AutoSize = true;
			this.lifelengthViewer_Repeat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer_Repeat.CalendarApplicable = false;
			this.lifelengthViewer_Repeat.CyclesApplicable = false;
			this.lifelengthViewer_Repeat.Enabled = false;
			this.lifelengthViewer_Repeat.EnabledCalendar = true;
			this.lifelengthViewer_Repeat.EnabledCycle = true;
			this.lifelengthViewer_Repeat.EnabledHours = true;
			this.lifelengthViewer_Repeat.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer_Repeat.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer_Repeat.HeaderCalendar = "Calendar";
			this.lifelengthViewer_Repeat.HeaderCycles = "Cycles";
			this.lifelengthViewer_Repeat.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer_Repeat.HeaderHours = "Hours";
			this.lifelengthViewer_Repeat.HoursApplicable = false;
			this.lifelengthViewer_Repeat.LeftHeader = "Repeat Interval";
			this.lifelengthViewer_Repeat.Location = new System.Drawing.Point(7, 31);
			this.lifelengthViewer_Repeat.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer_Repeat.Modified = false;
			this.lifelengthViewer_Repeat.Name = "lifelengthViewer_Repeat";
			this.lifelengthViewer_Repeat.ReadOnly = false;
			this.lifelengthViewer_Repeat.ShowCalendar = true;
			this.lifelengthViewer_Repeat.ShowFormattedCalendar = false;
			this.lifelengthViewer_Repeat.ShowMinutes = true;
			this.lifelengthViewer_Repeat.Size = new System.Drawing.Size(473, 52);
			this.lifelengthViewer_Repeat.SystemCalculated = true;
			this.lifelengthViewer_Repeat.TabIndex = 12;
			// 
			// _labelManHours
			// 
			this._labelManHours.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._labelManHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this._labelManHours.Location = new System.Drawing.Point(3, 38);
			this._labelManHours.Name = "_labelManHours";
			this._labelManHours.Size = new System.Drawing.Size(150, 25);
			this._labelManHours.TabIndex = 184;
			this._labelManHours.Text = "Man Hours";
			// 
			// groupFirstPerformance
			// 
			this.groupFirstPerformance.AutoSize = true;
			this.groupFirstPerformance.Controls.Add(this.radio_FirstWhicheverLast);
			this.groupFirstPerformance.Controls.Add(this.radio_FirstWhicheverFirst);
			this.groupFirstPerformance.Controls.Add(this.lifelengthViewer_SinceEffDate);
			this.groupFirstPerformance.Controls.Add(this.lifelengthViewer_SinceNew);
			this.groupFirstPerformance.Controls.Add(this.lifelengthViewer_FirstNotify);
			this.groupFirstPerformance.ForeColor = System.Drawing.Color.DimGray;
			this.groupFirstPerformance.Location = new System.Drawing.Point(6, 275);
			this.groupFirstPerformance.Name = "groupFirstPerformance";
			this.groupFirstPerformance.Size = new System.Drawing.Size(555, 223);
			this.groupFirstPerformance.TabIndex = 191;
			this.groupFirstPerformance.TabStop = false;
			this.groupFirstPerformance.Text = "FIRST PERFORMANCE";
			// 
			// lifelengthViewer_SinceEffDate
			// 
			this.lifelengthViewer_SinceEffDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lifelengthViewer_SinceEffDate.AutoSize = true;
			this.lifelengthViewer_SinceEffDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer_SinceEffDate.CalendarApplicable = false;
			this.lifelengthViewer_SinceEffDate.CyclesApplicable = false;
			this.lifelengthViewer_SinceEffDate.EnabledCalendar = true;
			this.lifelengthViewer_SinceEffDate.EnabledCycle = true;
			this.lifelengthViewer_SinceEffDate.EnabledHours = true;
			this.lifelengthViewer_SinceEffDate.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer_SinceEffDate.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer_SinceEffDate.HeaderCalendar = "Calendar";
			this.lifelengthViewer_SinceEffDate.HeaderCycles = "Cycles";
			this.lifelengthViewer_SinceEffDate.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer_SinceEffDate.HeaderHours = "Hours";
			this.lifelengthViewer_SinceEffDate.HoursApplicable = false;
			this.lifelengthViewer_SinceEffDate.LeftHeader = "Since Eff. Date";
			this.lifelengthViewer_SinceEffDate.Location = new System.Drawing.Point(23, 89);
			this.lifelengthViewer_SinceEffDate.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer_SinceEffDate.Modified = false;
			this.lifelengthViewer_SinceEffDate.Name = "lifelengthViewer_SinceEffDate";
			this.lifelengthViewer_SinceEffDate.ReadOnly = false;
			this.lifelengthViewer_SinceEffDate.ShowCalendar = true;
			this.lifelengthViewer_SinceEffDate.ShowFormattedCalendar = false;
			this.lifelengthViewer_SinceEffDate.ShowHeaders = false;
			this.lifelengthViewer_SinceEffDate.ShowMinutes = true;
			this.lifelengthViewer_SinceEffDate.Size = new System.Drawing.Size(469, 35);
			this.lifelengthViewer_SinceEffDate.SystemCalculated = true;
			this.lifelengthViewer_SinceEffDate.TabIndex = 20;
			// 
			// lifelengthViewer_SinceNew
			// 
			this.lifelengthViewer_SinceNew.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lifelengthViewer_SinceNew.AutoSize = true;
			this.lifelengthViewer_SinceNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer_SinceNew.CalendarApplicable = false;
			this.lifelengthViewer_SinceNew.CyclesApplicable = false;
			this.lifelengthViewer_SinceNew.EnabledCalendar = true;
			this.lifelengthViewer_SinceNew.EnabledCycle = true;
			this.lifelengthViewer_SinceNew.EnabledHours = true;
			this.lifelengthViewer_SinceNew.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer_SinceNew.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer_SinceNew.HeaderCalendar = "Calendar";
			this.lifelengthViewer_SinceNew.HeaderCycles = "Cycles";
			this.lifelengthViewer_SinceNew.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer_SinceNew.HeaderHours = "Hours";
			this.lifelengthViewer_SinceNew.HoursApplicable = false;
			this.lifelengthViewer_SinceNew.LeftHeader = "Since New";
			this.lifelengthViewer_SinceNew.Location = new System.Drawing.Point(56, 31);
			this.lifelengthViewer_SinceNew.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer_SinceNew.Modified = false;
			this.lifelengthViewer_SinceNew.Name = "lifelengthViewer_SinceNew";
			this.lifelengthViewer_SinceNew.ReadOnly = false;
			this.lifelengthViewer_SinceNew.ShowCalendar = true;
			this.lifelengthViewer_SinceNew.ShowFormattedCalendar = false;
			this.lifelengthViewer_SinceNew.ShowMinutes = true;
			this.lifelengthViewer_SinceNew.Size = new System.Drawing.Size(437, 52);
			this.lifelengthViewer_SinceNew.SystemCalculated = true;
			this.lifelengthViewer_SinceNew.TabIndex = 7;
			// 
			// lifelengthViewer_FirstNotify
			// 
			this.lifelengthViewer_FirstNotify.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lifelengthViewer_FirstNotify.AutoSize = true;
			this.lifelengthViewer_FirstNotify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.lifelengthViewer_FirstNotify.CalendarApplicable = false;
			this.lifelengthViewer_FirstNotify.CyclesApplicable = false;
			this.lifelengthViewer_FirstNotify.EnabledCalendar = true;
			this.lifelengthViewer_FirstNotify.EnabledCycle = true;
			this.lifelengthViewer_FirstNotify.EnabledHours = true;
			this.lifelengthViewer_FirstNotify.FieldsBackColor = System.Drawing.SystemColors.Window;
			this.lifelengthViewer_FirstNotify.ForeColor = System.Drawing.Color.DimGray;
			this.lifelengthViewer_FirstNotify.HeaderCalendar = "Calendar";
			this.lifelengthViewer_FirstNotify.HeaderCycles = "Cycles";
			this.lifelengthViewer_FirstNotify.HeaderFormattedCalendar = "Calendar";
			this.lifelengthViewer_FirstNotify.HeaderHours = "Hours";
			this.lifelengthViewer_FirstNotify.HoursApplicable = false;
			this.lifelengthViewer_FirstNotify.LeftHeader = "Notify";
			this.lifelengthViewer_FirstNotify.Location = new System.Drawing.Point(85, 130);
			this.lifelengthViewer_FirstNotify.Margin = new System.Windows.Forms.Padding(2);
			this.lifelengthViewer_FirstNotify.Modified = false;
			this.lifelengthViewer_FirstNotify.Name = "lifelengthViewer_FirstNotify";
			this.lifelengthViewer_FirstNotify.ReadOnly = false;
			this.lifelengthViewer_FirstNotify.ShowCalendar = true;
			this.lifelengthViewer_FirstNotify.ShowFormattedCalendar = false;
			this.lifelengthViewer_FirstNotify.ShowHeaders = false;
			this.lifelengthViewer_FirstNotify.ShowMinutes = true;
			this.lifelengthViewer_FirstNotify.Size = new System.Drawing.Size(407, 35);
			this.lifelengthViewer_FirstNotify.SystemCalculated = true;
			this.lifelengthViewer_FirstNotify.TabIndex = 8;
			// 
			// labelThreshold
			// 
			this.labelThreshold.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.labelThreshold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelThreshold.Location = new System.Drawing.Point(503, 247);
			this.labelThreshold.Name = "labelThreshold";
			this.labelThreshold.Size = new System.Drawing.Size(80, 25);
			this.labelThreshold.TabIndex = 182;
			this.labelThreshold.Text = "Threshold";
			// 
			// comboBoxNdt
			// 
			this.comboBoxNdt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxNdt.FormattingEnabled = true;
			this.comboBoxNdt.Location = new System.Drawing.Point(153, 211);
			this.comboBoxNdt.Name = "comboBoxNdt";
			this.comboBoxNdt.Size = new System.Drawing.Size(210, 21);
			this.comboBoxNdt.TabIndex = 205;
			this.comboBoxNdt.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// lookupComboboxForCompnt
			// 
			this.lookupComboboxForCompnt.Displayer = null;
			this.lookupComboboxForCompnt.DisplayerText = null;
			this.lookupComboboxForCompnt.Entity = null;
			this.lookupComboboxForCompnt.Font = new System.Drawing.Font("Verdana", 9F);
			this.lookupComboboxForCompnt.Location = new System.Drawing.Point(153, 183);
			this.lookupComboboxForCompnt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.lookupComboboxForCompnt.Name = "lookupComboboxForCompnt";
			this.lookupComboboxForCompnt.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInCurrent;
			this.lookupComboboxForCompnt.Size = new System.Drawing.Size(350, 22);
			this.lookupComboboxForCompnt.TabIndex = 204;
			this.lookupComboboxForCompnt.Type = null;
			this.lookupComboboxForCompnt.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// comboBoxSupersedes
			// 
			this.comboBoxSupersedes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxSupersedes.FormattingEnabled = true;
			this.comboBoxSupersedes.Location = new System.Drawing.Point(743, 172);
			this.comboBoxSupersedes.Name = "comboBoxSupersedes";
			this.comboBoxSupersedes.Size = new System.Drawing.Size(308, 21);
			this.comboBoxSupersedes.TabIndex = 207;
			this.comboBoxSupersedes.Visible = false;
			this.comboBoxSupersedes.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelSupersedes
			// 
			this.labelSupersedes.Font = new System.Drawing.Font("Verdana", 9F);
			this.labelSupersedes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSupersedes.Location = new System.Drawing.Point(593, 169);
			this.labelSupersedes.Name = "labelSupersedes";
			this.labelSupersedes.Size = new System.Drawing.Size(121, 25);
			this.labelSupersedes.TabIndex = 206;
			this.labelSupersedes.Text = "Supersedes:";
			this.labelSupersedes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelSupersedes.Visible = false;
			// 
			// comboBoxSuperseded
			// 
			this.comboBoxSuperseded.Enabled = false;
			this.comboBoxSuperseded.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxSuperseded.FormattingEnabled = true;
			this.comboBoxSuperseded.Location = new System.Drawing.Point(743, 199);
			this.comboBoxSuperseded.Name = "comboBoxSuperseded";
			this.comboBoxSuperseded.Size = new System.Drawing.Size(308, 21);
			this.comboBoxSuperseded.TabIndex = 209;
			this.comboBoxSuperseded.Visible = false;
			this.comboBoxSuperseded.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelSuperseded
			// 
			this.labelSuperseded.Font = new System.Drawing.Font("Verdana", 9F);
			this.labelSuperseded.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelSuperseded.Location = new System.Drawing.Point(593, 196);
			this.labelSuperseded.Name = "labelSuperseded";
			this.labelSuperseded.Size = new System.Drawing.Size(121, 25);
			this.labelSuperseded.TabIndex = 208;
			this.labelSuperseded.Text = "Superseded:";
			this.labelSuperseded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelSuperseded.Visible = false;
			// 
			// comboBoxOrder
			// 
			this.comboBoxOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxOrder.FormattingEnabled = true;
			this.comboBoxOrder.Location = new System.Drawing.Point(743, 145);
			this.comboBoxOrder.Name = "comboBoxOrder";
			this.comboBoxOrder.Size = new System.Drawing.Size(308, 21);
			this.comboBoxOrder.TabIndex = 211;
			this.comboBoxOrder.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Verdana", 9F);
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label3.Location = new System.Drawing.Point(593, 142);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 25);
			this.label3.TabIndex = 210;
			this.label3.Text = "Order:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.label6.Location = new System.Drawing.Point(3, 102);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(77, 14);
			this.label6.TabIndex = 217;
			this.label6.Text = "Work area:";
			// 
			// textBoxWorkArea
			// 
			this.textBoxWorkArea.BackColor = System.Drawing.Color.White;
			this.textBoxWorkArea.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxWorkArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxWorkArea.Location = new System.Drawing.Point(153, 99);
			this.textBoxWorkArea.MaxLength = 200;
			this.textBoxWorkArea.Name = "textBoxWorkArea";
			this.textBoxWorkArea.Size = new System.Drawing.Size(350, 22);
			this.textBoxWorkArea.TabIndex = 216;
			// 
			// labelZone
			// 
			this.labelZone.AutoSize = true;
			this.labelZone.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelZone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelZone.Location = new System.Drawing.Point(3, 130);
			this.labelZone.Name = "labelZone";
			this.labelZone.Size = new System.Drawing.Size(44, 14);
			this.labelZone.TabIndex = 215;
			this.labelZone.Text = "Zone:";
			// 
			// textBoxZone
			// 
			this.textBoxZone.BackColor = System.Drawing.Color.White;
			this.textBoxZone.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxZone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxZone.Location = new System.Drawing.Point(153, 127);
			this.textBoxZone.MaxLength = 200;
			this.textBoxZone.Name = "textBoxZone";
			this.textBoxZone.Size = new System.Drawing.Size(350, 22);
			this.textBoxZone.TabIndex = 212;
			// 
			// labelAccess
			// 
			this.labelAccess.AutoSize = true;
			this.labelAccess.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelAccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAccess.Location = new System.Drawing.Point(3, 158);
			this.labelAccess.Name = "labelAccess";
			this.labelAccess.Size = new System.Drawing.Size(54, 14);
			this.labelAccess.TabIndex = 214;
			this.labelAccess.Text = "Access:";
			// 
			// textBoxAccess
			// 
			this.textBoxAccess.BackColor = System.Drawing.Color.White;
			this.textBoxAccess.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxAccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxAccess.Location = new System.Drawing.Point(153, 155);
			this.textBoxAccess.MaxLength = 1000;
			this.textBoxAccess.Multiline = true;
			this.textBoxAccess.Name = "textBoxAccess";
			this.textBoxAccess.Size = new System.Drawing.Size(350, 22);
			this.textBoxAccess.TabIndex = 213;
			// 
			// labelAffectedBy
			// 
			this.labelAffectedBy.AutoSize = true;
			this.labelAffectedBy.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelAffectedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAffectedBy.Location = new System.Drawing.Point(593, 66);
			this.labelAffectedBy.Name = "labelAffectedBy";
			this.labelAffectedBy.Size = new System.Drawing.Size(82, 14);
			this.labelAffectedBy.TabIndex = 219;
			this.labelAffectedBy.Text = "Affected by:";
			// 
			// textBoxAffectedBy
			// 
			this.textBoxAffectedBy.BackColor = System.Drawing.Color.White;
			this.textBoxAffectedBy.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBoxAffectedBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.textBoxAffectedBy.Location = new System.Drawing.Point(743, 63);
			this.textBoxAffectedBy.MaxLength = 200;
			this.textBoxAffectedBy.Name = "textBoxAffectedBy";
			this.textBoxAffectedBy.Size = new System.Drawing.Size(308, 22);
			this.textBoxAffectedBy.TabIndex = 218;
			// 
			// comboBoxAffects
			// 
			this.comboBoxAffects.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxAffects.FormattingEnabled = true;
			this.comboBoxAffects.Location = new System.Drawing.Point(743, 91);
			this.comboBoxAffects.Name = "comboBoxAffects";
			this.comboBoxAffects.Size = new System.Drawing.Size(308, 21);
			this.comboBoxAffects.TabIndex = 221;
			this.comboBoxAffects.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelAffects
			// 
			this.labelAffects.Font = new System.Drawing.Font("Verdana", 9F);
			this.labelAffects.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelAffects.Location = new System.Drawing.Point(593, 88);
			this.labelAffects.Name = "labelAffects";
			this.labelAffects.Size = new System.Drawing.Size(121, 25);
			this.labelAffects.TabIndex = 220;
			this.labelAffects.Text = "Affects:";
			this.labelAffects.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// comboBoxReason
			// 
			this.comboBoxReason.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.comboBoxReason.FormattingEnabled = true;
			this.comboBoxReason.Location = new System.Drawing.Point(743, 118);
			this.comboBoxReason.Name = "comboBoxReason";
			this.comboBoxReason.Size = new System.Drawing.Size(308, 21);
			this.comboBoxReason.TabIndex = 223;
			this.comboBoxReason.MouseWheel += CmbScrollHelper.ComboBoxScroll_MouseWheel;
			// 
			// labelReason
			// 
			this.labelReason.Font = new System.Drawing.Font("Verdana", 9F);
			this.labelReason.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
			this.labelReason.Location = new System.Drawing.Point(593, 115);
			this.labelReason.Name = "labelReason";
			this.labelReason.Size = new System.Drawing.Size(121, 25);
			this.labelReason.TabIndex = 222;
			this.labelReason.Text = "Reason:";
			this.labelReason.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DirectiveParametersControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
			this.Controls.Add(this.comboBoxReason);
			this.Controls.Add(this.labelReason);
			this.Controls.Add(this.comboBoxAffects);
			this.Controls.Add(this.labelAffects);
			this.Controls.Add(this.labelAffectedBy);
			this.Controls.Add(this.textBoxAffectedBy);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBoxWorkArea);
			this.Controls.Add(this.labelZone);
			this.Controls.Add(this.textBoxZone);
			this.Controls.Add(this.labelAccess);
			this.Controls.Add(this.textBoxAccess);
			this.Controls.Add(this.comboBoxOrder);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.comboBoxSuperseded);
			this.Controls.Add(this.labelSuperseded);
			this.Controls.Add(this.comboBoxSupersedes);
			this.Controls.Add(this.labelSupersedes);
			this.Controls.Add(this.comboBoxNdt);
			this.Controls.Add(this.lookupComboboxForCompnt);
			this.Controls.Add(this.labelForComponent);
			this.Controls.Add(this.linkLabelEditKit);
			this.Controls.Add(this.imageLinkLabelStatus);
			this.Controls.Add(this.textBoxKitRequired);
			this.Controls.Add(this.labelChart);
			this.Controls.Add(this.linkLabelEditChart);
			this.Controls.Add(this.textBoxChart);
			this.Controls.Add(this.labelKitRequired);
			this.Controls.Add(this.groupBoxClose);
			this.Controls.Add(this.labelParagraph);
			this.Controls.Add(this.labelNDT);
			this.Controls.Add(this.textBoxParagraph);
			this.Controls.Add(this.checkBoxIsTemporary);
			this.Controls.Add(this.comboBoxWorkType);
			this.Controls.Add(this._textboxCost);
			this.Controls.Add(this._labelCost);
			this.Controls.Add(this._labelIsTemporary);
			this.Controls.Add(this._textboxManHours);
			this.Controls.Add(this.groupBox_Repetative);
			this.Controls.Add(this._labelManHours);
			this.Controls.Add(this.groupFirstPerformance);
			this.Controls.Add(this.labelThreshold);
			this.Name = "DirectiveParametersControl";
			this.Size = new System.Drawing.Size(1186, 503);
			this.groupBoxClose.ResumeLayout(false);
			this.groupBoxClose.PerformLayout();
			this.groupBox_Repetative.ResumeLayout(false);
			this.groupBox_Repetative.PerformLayout();
			this.groupFirstPerformance.ResumeLayout(false);
			this.groupFirstPerformance.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		#region private DirectiveThreshold GetThreshold()
		/// <summary>
		/// Считывает все контролы и формирует один Threshold
		/// </summary>
		private DirectiveThreshold GetThreshold()
		{
			DirectiveThreshold threshold = new DirectiveThreshold();

			// First performance
			Lifelength sinceNew = new Lifelength(lifelengthViewer_SinceNew.Lifelength);
			Lifelength sinceEffDate = new Lifelength(lifelengthViewer_SinceEffDate.Lifelength);

			threshold.FirstPerformanceSinceNew = sinceNew;
			threshold.FirstPerformanceSinceEffectiveDate = sinceEffDate;

			threshold.PerformSinceNew = sinceNew.IsNullOrZero() ? false : true;
			threshold.PerformSinceEffectiveDate = sinceEffDate.IsNullOrZero() ? false : true;

			Lifelength nfp = new Lifelength(lifelengthViewer_FirstNotify.Lifelength);
			threshold.FirstNotification = nfp;

			if (radio_FirstWhicheverFirst.Checked) threshold.FirstPerformanceConditionType = ThresholdConditionType.WhicheverFirst;
			if (radio_FirstWhicheverLast.Checked)threshold.FirstPerformanceConditionType = ThresholdConditionType.WhicheverLater;

			// Repeat interval
			if (checkBoxRepeat.Checked)
			{
				// директива выполняется повторно
				Lifelength rp = new Lifelength(lifelengthViewer_Repeat.Lifelength);
				Lifelength nrp = new Lifelength(lifelengthViewer_RepeatNotify.Lifelength);

				threshold.PerformRepeatedly = true;
				threshold.RepeatInterval = rp;
				threshold.RepeatNotification = nrp;

				if (radio_RepeatWhicheverFirst.Checked) threshold.RepeatPerformanceConditionType = ThresholdConditionType.WhicheverFirst;
				if (radio_RepeatWhicheverLast.Checked) threshold.RepeatPerformanceConditionType = ThresholdConditionType.WhicheverLater;
			}

			return threshold;
		}
		#endregion

		#region private void ApplyThreshold(DirectiveThreshold treshold)
		/// <summary>
		/// Заполняет все контролы в связи с заданным Threshold
		/// </summary>
		private void ApplyThreshold(DirectiveThreshold threshold)
		{
			// First Performance 
			radio_FirstWhicheverLast.Checked = 
				threshold.FirstPerformanceConditionType != ThresholdConditionType.WhicheverFirst;

			if (threshold.FirstPerformanceSinceNew != null)
			{
				lifelengthViewer_SinceNew.Lifelength = threshold.FirstPerformanceSinceNew;
			}

			if (threshold.FirstPerformanceSinceEffectiveDate != null)
			{
				lifelengthViewer_SinceEffDate.Lifelength = threshold.FirstPerformanceSinceEffectiveDate;
			}

			if (threshold.FirstNotification != null)
			{
				lifelengthViewer_FirstNotify.Lifelength = threshold.FirstNotification;
			}

			// Repeat Interval
			radio_RepeatWhicheverLast.Checked =
				threshold.RepeatPerformanceConditionType != ThresholdConditionType.WhicheverFirst;
			// Выбираем способ повторения директивы
			checkBoxRepeat.Checked = threshold.PerformRepeatedly;

			radio_RepeatWhicheverFirst.Enabled =  radio_RepeatWhicheverLast.Enabled = 
				lifelengthViewer_Repeat.Enabled = lifelengthViewer_RepeatNotify.Enabled = checkBoxRepeat.Checked;

			if (threshold.RepeatInterval != null)
				lifelengthViewer_Repeat.Lifelength = threshold.RepeatInterval;

			if (threshold.RepeatNotification != null)
				lifelengthViewer_RepeatNotify.Lifelength = threshold.RepeatNotification;
			
		}

		#endregion

		#region public void EnableLifelengthControls(bool isEnable)
		///<summary>
		///</summary>
		///<param name="isEnable"></param>
		public void EnableLifelengthControls(bool isEnable)
		{
			lifelengthViewer_SinceNew.Enabled = isEnable;
			lifelengthViewer_SinceEffDate.Enabled = isEnable;
			lifelengthViewer_FirstNotify.Enabled = isEnable;
			lifelengthViewer_Repeat.Enabled = isEnable;
			lifelengthViewer_RepeatNotify.Enabled = isEnable;
		}
		#endregion

		#region public void SetThresholdByCategory(DefferedCategory category)
		///<summary>
		///</summary>
		///<param name="category"></param>
		public void SetThresholdByCategory(DeferredCategory category)
		{
			char name = char.ToUpper(category.FullName.ToCharArray()[0]);
				
			if(name == 'A')EnableLifelengthControls(true);
			else
			{
				category.Threshold.FirstPerformanceConditionType = ThresholdConditionType.WhicheverFirst;
				category.Threshold.RepeatPerformanceConditionType = ThresholdConditionType.WhicheverFirst;
				category.Threshold.PerformRepeatedly = true;
				category.Threshold.PerformSinceEffectiveDate = true;
				category.Threshold.PerformSinceNew = true;
				Threshold = category.Threshold;
				EnableLifelengthControls(false);
			}
		}
		#endregion

		#region public bool ValidateData( out string message )

		public bool ValidateData( out string message )
		{
			message = "";
			double manHours;
			double cost;
			if (!CheckManHours(out manHours))
			{
				message += "Man hours. Invalid value";
			}
			if (!CheckCost(out cost))
			{
				message = "Cost. Invalid value";
			}

			if (comboBoxWorkType.SelectedItem == null)
			{
				message = "You must enter Work Type";
			}

			if (message != "")
				return false;
			return true;    
		}
		#endregion

		#region public bool GetChangeStatus()

		/// <summary>
		/// Возвращает значение, показывающее были ли изменения в данном элементе управления
		/// </summary>
		/// <returns></returns>
		public bool GetChangeStatus()
		{
			double eps = 0.00001;
			double manHours;
			double cost;
			if (!CheckManHours(out manHours))
				return true;
			if (!CheckCost(out cost))
				return true;
			DirectiveThreshold threshold = new DirectiveThreshold();
			threshold.EffectiveDate = _effDate;
			threshold.FirstPerformanceSinceNew = new Lifelength(lifelengthViewer_SinceNew.Lifelength);
			threshold.FirstPerformanceSinceEffectiveDate = new Lifelength(lifelengthViewer_SinceEffDate.Lifelength);
			threshold.FirstNotification = new Lifelength(lifelengthViewer_FirstNotify.Lifelength);
			threshold.PerformRepeatedly = checkBoxRepeat.Checked;
			threshold.RepeatInterval = new Lifelength(lifelengthViewer_Repeat.Lifelength);
			threshold.RepeatNotification = new Lifelength(lifelengthViewer_RepeatNotify.Lifelength);
			threshold.FirstPerformanceConditionType = radio_FirstWhicheverFirst.Checked
													  ? ThresholdConditionType.WhicheverFirst
													  : ThresholdConditionType.WhicheverLater;
			threshold.RepeatPerformanceConditionType = radio_RepeatWhicheverFirst.Checked
													  ? ThresholdConditionType.WhicheverFirst
													  : ThresholdConditionType.WhicheverLater; 

			if (_currentDirective != null && 
				(_currentDirective.Threshold.ToString() != threshold.ToString() || 
				 _currentDirective.IsClosed != isClosed ||
				 _currentDirective.WorkType.ItemId != ((DirectiveWorkType)comboBoxWorkType.SelectedItem).ItemId ||
				 _currentDirective.Paragraph != textBoxParagraph.Text ||
				 _currentDirective.AffectedBy != textBoxAffectedBy.Text ||
				 Math.Abs(_currentDirective.ManHours - manHours) > eps || 
				 Math.Abs(_currentDirective.Cost - cost) > eps ||
				 _currentDirective.NDTType.ItemId != ((NDTType)comboBoxNdt.SelectedItem).ItemId ||
				 _currentDirective.DirectiveOrder.ItemId != ((DirectiveOrder)comboBoxOrder.SelectedItem).ItemId ||
				 _currentDirective.Reason.ItemId != ((DirectiveReason)comboBoxReason.SelectedItem).ItemId ||
				 _currentDirective.Affects.ItemId != ((DirectiveAffects)comboBoxAffects.SelectedItem).ItemId ||
				 _currentDirective is DamageItem && ((DamageItem)_currentDirective).IsTemporary != checkBoxIsTemporary.Checked ||
				 _currentDirective.KitRequired != textBoxKitRequired.Text))
				return true;
			return false;
		}

		#endregion

		#region public void UpdateControl()
		///<summary>
		///</summary>
		public void UpdateControl()
		{
			lookupComboboxForCompnt.DisplayerText = _currentDirective.ParentBaseComponent + ". Component Status";
			lookupComboboxForCompnt.LoadObjectsFunc = GlobalObjects.DirectiveCore.GetDirectives;
			lookupComboboxForCompnt.FilterParam1 = _currentDirective.ParentBaseComponent;
			lookupComboboxForCompnt.FilterParam2 = DirectiveType.DeferredItems;
			//lookupComboboxForCompnt.UpdateInformation();
			if(_currentDirective is DeferredItem)
			{
				lifelengthViewer_SinceNew.Visible = false;
				lifelengthViewer_Repeat.Visible = false;
				lifelengthViewer_RepeatNotify.Visible = false;
				
				lifelengthViewer_SinceEffDate.LeftHeader = "Since. disc. date";
				lifelengthViewer_SinceEffDate.Location = new System.Drawing.Point(7, 31);
				lifelengthViewer_SinceEffDate.Anchor = AnchorStyles.Top | AnchorStyles.Left;
				groupFirstPerformance.Controls.Clear();
				groupFirstPerformance.Controls.Add(lifelengthViewer_SinceEffDate);
				groupFirstPerformance.Size = new System.Drawing.Size(501, 90);
				groupFirstPerformance.Text = "FIRST PERFORMANCE";
				groupFirstPerformance.ResumeLayout(false);
				groupFirstPerformance.PerformLayout();
				lifelengthViewer_SinceEffDate.Anchor = AnchorStyles.Right;
				
				lifelengthViewer_FirstNotify.Location = new System.Drawing.Point(31, 31);
				lifelengthViewer_FirstNotify.Anchor = AnchorStyles.Top | AnchorStyles.Left;
				groupBox_Repetative.Controls.Clear();
				groupBox_Repetative.Controls.Add(lifelengthViewer_FirstNotify);
				groupBox_Repetative.Size = new System.Drawing.Size(501, 90);
				groupBox_Repetative.Text = "NOTIFY";
				groupBox_Repetative.ResumeLayout(false);
				groupBox_Repetative.PerformLayout();
				lifelengthViewer_SinceEffDate.Anchor = AnchorStyles.Right;
				
				
				groupBoxClose.Size = new System.Drawing.Size(86, 90);
			}

			if (_currentDirective is DamageItem)
			{
				_labelIsTemporary.Visible = checkBoxIsTemporary.Visible = true;
				labelChart.Visible = true;
				textBoxChart.Visible = true;
				linkLabelEditChart.Visible = true;
				lookupComboboxForCompnt.Visible = false;
				labelForComponent.Visible = false;
			}
			else
			{
				_labelIsTemporary.Visible = checkBoxIsTemporary.Visible = false;   
			}
		}
		#endregion

		#region public void UpdateInformation()

		/// <summary>
		/// 3аполняет поля для редактирования директивы
		/// </summary>
		private void UpdateInformation()
		{
			UpdateControl();

			comboBoxNdt.Items.Clear();
			comboBoxNdt.Items.AddRange(NDTType.Items.ToArray());
			comboBoxNdt.SelectedItem = _currentDirective.NDTType;
			
			comboBoxOrder.Items.Clear();
			comboBoxOrder.Items.AddRange(DirectiveOrder.Items.ToArray());
			comboBoxOrder.SelectedItem = _currentDirective.DirectiveOrder;

			comboBoxReason.Items.Clear();
			comboBoxReason.Items.AddRange(DirectiveReason.Items.ToArray());
			comboBoxReason.SelectedItem = _currentDirective.Reason;

			comboBoxAffects.Items.Clear();
			comboBoxAffects.Items.AddRange(DirectiveAffects.Items.ToArray());
			comboBoxAffects.SelectedItem = _currentDirective.Affects;

			textBoxZone.Text = _currentDirective.DirectiveZone;
			textBoxAccess.Text = _currentDirective.DirectiveAccess;
			textBoxWorkArea.Text = _currentDirective.Workarea;
			textBoxAffectedBy.Text = _currentDirective.AffectedBy;
			
			comboBoxWorkType.Items.Clear();
			var directiveTypes = DirectiveWorkType.Items.OrderBy(x => x.FullName).ToList();
			for (int i = 0; i < directiveTypes.Count; i++)
			{
				comboBoxWorkType.Items.Add(directiveTypes[i]);
				if (_currentDirective.WorkType.Equals(directiveTypes[i]))
					comboBoxWorkType.SelectedItem = directiveTypes[i];
			}
			if (comboBoxWorkType.SelectedItem == null)
				comboBoxWorkType.SelectedIndex = 0;

			_effDate = _currentDirective.Threshold.EffectiveDate;

			textBoxParagraph.Text = _currentDirective.Paragraph;
			//GlobalObjects.PerformanceCalculator.GetNextPerformance(_currentDirective);

			imageLinkLabelStatus.Text = "Work type";
			if (_currentDirective.Condition == ConditionState.NotEstimated)
				imageLinkLabelStatus.Status = Statuses.NotActive;
			if (_currentDirective.Condition == ConditionState.Overdue)
				imageLinkLabelStatus.Status = Statuses.NotSatisfactory;
			if (_currentDirective.Condition == ConditionState.Notify)
				imageLinkLabelStatus.Status = Statuses.Notify;
			if (_currentDirective.Condition == ConditionState.Satisfactory)
				imageLinkLabelStatus.Status = Statuses.Satisfactory;

			if (Math.Abs(_currentDirective.ManHours) > 0.000001)
				_textboxManHours.Text = _currentDirective.ManHours.ToString();
			if (Math.Abs(_currentDirective.Cost) > 0.000001)
				_textboxCost.Text = _currentDirective.Cost.ToString();

			Threshold = _currentDirective.Threshold;
			checkBoxClose.Checked = _currentDirective.IsClosed;

			if(_currentDirective is DeferredItem)
			{
				DeferredItem defferedItem = (DeferredItem) _currentDirective;
				DeferredCategory category = defferedItem.DeferredCategory;
				if (category != null && category != DeferredCategory.Unknown)
				{
					if (char.ToUpper(category.FullName.ToCharArray()[0]) != 'A')
					{
						SetThresholdByCategory(category);   
					}
					else
					{
						Threshold = _currentDirective.Threshold;   
					}
				}
			}
			if (_currentDirective is DamageItem)
			{
				DamageItem damageItem = (DamageItem) _currentDirective;
				textBoxChart.Text = damageItem.DamageDocs.ToString();
				checkBoxIsTemporary.Checked = damageItem.IsTemporary;
			}

			textBoxKitRequired.Text = _currentDirective.Kits.Count + " EA";
			bool permission = true;//currentDirective.HasPermission(Users.IdentityUser, DataEvent.Update);

			textBoxKitRequired.ReadOnly = !permission;
		}

		#endregion

		#region public bool ApplyChanges(Directive destinationDirective)

		/// <summary>
		/// Данные у директивы обновляются по введенным данным
		/// </summary>
		public bool ApplyChanges(Directive destinationDirective)
		{
			if (destinationDirective == null)
				return false;
			double manHours;
			double cost;
			if (!CheckManHours(out manHours))
				return false;
			if (!CheckCost(out cost))
				return false;

			destinationDirective.WorkType = (DirectiveWorkType)comboBoxWorkType.SelectedItem;
			destinationDirective.Paragraph = textBoxParagraph.Text;
			destinationDirective.KitRequired = textBoxKitRequired.Text;
			destinationDirective.ManHours = manHours;
			destinationDirective.Cost = cost;
			destinationDirective.NDTType = comboBoxNdt.SelectedItem as NDTType;
			destinationDirective.DirectiveOrder = comboBoxOrder.SelectedItem as DirectiveOrder;
			destinationDirective.Reason = comboBoxReason.SelectedItem as DirectiveReason;
			destinationDirective.Affects = comboBoxAffects.SelectedItem as DirectiveAffects;
			destinationDirective.KitRequired = textBoxKitRequired.Text;
			destinationDirective.IsClosed = isClosed;
			destinationDirective.DirectiveZone = textBoxZone.Text;
			destinationDirective.DirectiveAccess = textBoxAccess.Text;
			destinationDirective.Workarea = textBoxWorkArea.Text;
			destinationDirective.AffectedBy = textBoxAffectedBy.Text;

			if (comboBoxSupersedes.SelectedItem != null)
				_currentDirective.SupersedesId = ((Directive) comboBoxSupersedes.SelectedItem).ItemId;
			var threshold = new DirectiveThreshold();
			threshold.EffectiveDate = _effDate;
			threshold.FirstPerformanceSinceNew = new Lifelength(lifelengthViewer_SinceNew.Lifelength);
			threshold.FirstPerformanceSinceEffectiveDate = new Lifelength(lifelengthViewer_SinceEffDate.Lifelength);
			threshold.FirstNotification = new Lifelength(lifelengthViewer_FirstNotify.Lifelength);
			threshold.PerformRepeatedly = checkBoxRepeat.Checked;
			threshold.RepeatInterval = new Lifelength(lifelengthViewer_Repeat.Lifelength);
			threshold.RepeatNotification = new Lifelength(lifelengthViewer_RepeatNotify.Lifelength);
			threshold.FirstPerformanceConditionType = radio_FirstWhicheverFirst.Checked
													  ? ThresholdConditionType.WhicheverFirst
													  : ThresholdConditionType.WhicheverLater;
			threshold.RepeatPerformanceConditionType = radio_RepeatWhicheverFirst.Checked
													 ? ThresholdConditionType.WhicheverFirst
													 : ThresholdConditionType.WhicheverLater;

			//if (destinationDirective.Threshold.ToString() != threshold.ToString())
				destinationDirective.Threshold = threshold;
			if (destinationDirective is DamageItem)
				((DamageItem) destinationDirective).IsTemporary = checkBoxIsTemporary.Checked;

			return true;
		}

		#endregion

		#region public void ClearFields()

		/// <summary>
		/// Очищает все поля
		/// </summary>
		public void ClearFields()
		{
			comboBoxNdt.SelectedItem = null;
			checkBoxIsTemporary.Checked = false;
			textBoxKitRequired.Text = "";
		}

		#endregion

		#region public bool CheckManHours(out double manHours)

		/// <summary>
		/// Проверяет значение ManHours
		/// </summary>
		/// <param name="manHours">Значение ManHours</param>
		/// <returns>Возвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
		public bool CheckManHours(out double manHours)
		{
			if (_textboxManHours.Text == "")
			{
				manHours = 0;
				return true;
			}
			if (double.TryParse(_textboxManHours.Text, NumberStyles.Float, new NumberFormatInfo(), out manHours) == false)
			{
				MessageBox.Show("Man Hours. Invalid value", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			return true;
		}

		#endregion

		#region public bool CheckCost(out double cost)
		/// <summary>
		/// Проверяет значение Cost
		/// </summary>
		/// <param name="cost">Значение Cost</param>
		/// <returns>Возвращает true если значение можно преобразовать в тип double, иначе возвращает false</returns>
		public bool CheckCost(out double cost)
		{
			if (_textboxCost.Text == "")
			{
				cost = 0;
				return true;
			}
			if (double.TryParse(_textboxCost.Text, NumberStyles.Float, new NumberFormatInfo(), out cost) == false)
			{
				MessageBox.Show("Cost. Invalid value", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			return true;
		}

		#endregion

		#region private void checkBoxRepeat_CheckedChanged(object sender, EventArgs e)

		private void CheckBoxRepeatCheckedChanged(object sender, EventArgs e)
		{
			radio_RepeatWhicheverFirst.Enabled = radio_RepeatWhicheverLast.Enabled = 
				lifelengthViewer_Repeat.Enabled = 
				lifelengthViewer_RepeatNotify.Enabled = checkBoxRepeat.Checked;
		}

		#endregion

		#region private void checkBoxClose_CheckedChanged(object sender, EventArgs e)
	   
		private void CheckBoxCloseCheckedChanged(object sender, EventArgs e)
		{
			isClosed = checkBoxClose.Checked;
		}
	   
		#endregion

		#region private void LinkLabelEditChartLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		private void LinkLabelEditChartLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			DamageItem damageItem = _currentDirective as DamageItem;
			if(damageItem == null)
				return;

			//DamageChartFileDialog dlg = new DamageChartFileDialog(damageItem, _currentDirective.ParentBaseDetail.ParentAircraft);
			//dlg.ShowDialog();

			var dlg = new DamageChart2DForm(damageItem, GlobalObjects.AircraftsCore.GetAircraftById(_currentDirective.ParentBaseComponent.ParentAircraftId));//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
			dlg.ShowDialog();

			textBoxChart.Text = damageItem.DamageDocs.ToString();
		}
		#endregion

		#region private void LinkLabelEditKitLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		private void LinkLabelEditKitLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			KitForm dlg = new KitForm(_currentDirective);
			if(dlg.ShowDialog() == DialogResult.OK)
				textBoxKitRequired.Text = _currentDirective.Kits.Count + " EA";
		}
		#endregion

		#endregion
	}

	#region internal class DirectiveParametersControlDesigner : ControlDesigner

	internal class DirectiveParametersControlDesigner : ControlDesigner
	{
		protected override void PostFilterProperties(IDictionary properties)
		{
			base.PostFilterProperties(properties);
			properties.Remove("CurrentDirective");
			properties.Remove("Threshold");
			properties.Remove("Type");
		}
	}
	#endregion
}