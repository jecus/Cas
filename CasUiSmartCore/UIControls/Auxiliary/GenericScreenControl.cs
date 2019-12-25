using System;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.Auxiliary
{
	/// <summary>
	/// Это контейнер для всех скринов
	/// </summary>
	public partial class GenericScreenControl<T> : UserControl, IReference, IDisplayingEntity where T : BaseEntityObject
	{
		#region Implementation of IReference

		private IDisplayer _displayer;

		#region public IDisplayer Displayer
		public IDisplayer Displayer
		{
			get { return _displayer; }
			set
			{        
				_displayer = value;
				aircraftHeaderControl1.CurrentDisplayer = _displayer;
				headerControl.CurrentDisplayer = _displayer;
			}
		}
		#endregion

		#region public string DisplayerText { get; set; }
		
		public string DisplayerText { get; set; }
		#endregion

		#region public IDisplayingEntity Entity{ get; set;}
		public IDisplayingEntity Entity{ get; set;}
		#endregion

		#region public ReflectionTypes ReflectionType{ get; set; }

		public ReflectionTypes ReflectionType{ get; set; }
		#endregion

		#region public event EventHandler<ReferenceEventArgs> DisplayerRequested;
		///<summary>
		///</summary>
		public event EventHandler<ReferenceEventArgs> DisplayerRequested;
		#endregion

		///<summary>
		///</summary>
		///<param name="e"></param>
		protected void InvokeDisplayerRequested(ReferenceEventArgs e)
		{
			EventHandler<ReferenceEventArgs> handler = DisplayerRequested;
			if (handler != null) handler(this, e);
		}
		#endregion

		#region IDisplayingEntity

		#region public object ContainedData
		/// <summary>
		/// Represents data being displayed
		/// </summary>
		public object ContainedData
		{
			get { return CurrentAircraft; }
			set { CurrentAircraft = (Aircraft) value; }
		}
		#endregion

		#region public bool ContainedDataEquals(IDisplayingEntity obj)
		/// <summary>
		/// Checks whether represented data equals to corresponding data of object
		/// </summary>
		/// <param name="obj">Compared object</param>
		/// <returns></returns>
		public bool ContainedDataEquals(IDisplayingEntity obj)
		{

			if (!(obj is ScreenControl)) return false;

			return ((ScreenControl) obj).DisplayerText == DisplayerText;
			//if (obj.ContainedData == null) return false;
			//if (CurrentAircraft == null) return false;

			//return
			//    ((Aircraft)obj.ContainedData).AircraftID == CurrentAircraft.AircraftID;
		}
		#endregion

		#region public void OnInitCompletion(object sender)
		/// <summary>
		/// Method call after add to IDisplayerCollectionProxy
		/// </summary>
		/// <returns></returns>
		public void OnInitCompletion(object sender)
		{
			if (InitComplition != null)
				InitComplition(sender, new EventArgs());
		}
		#endregion

		#region public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
		/// <summary>
		/// Вызывается событие удаления отображаемого объекта
		/// </summary>
		/// <param name="arguments"></param>
		public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
		{

		}
		#endregion

		#region public void OnDisplayerRemoved()
		/// <summary>
		/// Возбуждает событие после удаления отображаемого объекта
		/// </summary>
		public void OnDisplayerRemoved()
		{

		}

		#endregion

		#region public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
		/// <summary>
		/// Действия, происходящие при деактивации вкладки, содержащей данную сущность
		/// </summary>
		/// <param name="arguments"></param>
		public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
		{

		}
		#endregion

		#region public void SetEnabled(bool isEnbaled)
		/// <summary>
		/// Set page enable
		/// </summary>
		/// <param name="isEnbaled"></param>
		public void SetEnabled(bool isEnbaled)
		{
			headerControl.Enabled = isEnbaled;
			footerControl1.Enabled = isEnbaled;
			aircraftHeaderControl1.Enabled = isEnbaled;
		}
		#endregion

		#region public event EventHandler InitComplition;
		///<summary>
		///</summary>
		public event EventHandler InitComplition;
		#endregion

		#region  public event EventHandler<EntityCancelEventArgs> EntityRemoving
		/// <summary>
		/// Событие, оповещающее об удаленни содержимого (вкладку)
		/// </summary>
		public event EventHandler<EntityCancelEventArgs> EntityRemoving;

		#endregion

		#region public event EventHandler DisplayerRemoved
		/// <summary>
		/// Возникает после удаления содержимого
		/// </summary>
		public event EventHandler EntityRemoved;

		#endregion

		#region public void DisposeScreen()
		public void DisposeScreen()
		{
			Dispose();
		}
		#endregion

		#endregion

		#region BaseField

		///<summary>
		///</summary>
	 
		public string ReportText { get; set; }

		#endregion

		#region Properties

		#region CurrentAircraft
		private Aircraft _aircraft;
		/// <summary>
		/// Указывает на текущий Aircraft
		/// </summary>
		public Aircraft CurrentAircraft
		{
			get { return _aircraft; }
			set
			{
				_aircraft = value;
				aircraftHeaderControl1.Aircraft = _aircraft;
				statusControl.Aircraft = _aircraft;
			}
		}
		#endregion

		#region public bool ShowTopPanelContainer
		/// <summary>
		/// Показать/скрыть панель для кнопок, нахлдящююся под основным заголовком
		/// </summary>
		public bool ShowTopPanelContainer
		{
			get { return panelTopContainer.Visible; }
			set { panelTopContainer.Visible = value; Update(); }
		}
		#endregion

		#region public bool ShowAircraftStatusPanel
		/// <summary>
		/// Показать/Скрыть панель, показывающую текущий статус самолета
		/// </summary>
		public bool ShowAircraftStatusPanel
		{
			get { return statusControl.Visible; }
			set { statusControl.Visible = value; Update();}
		}
		#endregion

		#region public string StatusTitle
		///<summary>
		/// Текст панели статуса самолета
		///</summary>
		public string StatusTitle
		{
			get { return statusControl.Title; }
			set { statusControl.Title = value; }
		}
		#endregion

		#region public ContextMenuStrip ButtonPrintMenuStrip
		///<summary>
		/// Устанавливает или возвращает контекстное меню ButtonPrint
		///</summary>
		public ContextMenuStrip ButtonPrintMenuStrip
		{
			get { return headerControl.PrintButtonContextMenuStrip; }
			set { headerControl.PrintButtonContextMenuStrip = value; }
		}
		#endregion
		
		#endregion

		///<summary>
		///</summary>
		public GenericScreenControl()
		{
			InitializeComponent();
			Dock = DockStyle.Fill;
		}

	}
}
