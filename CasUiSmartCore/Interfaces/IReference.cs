using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.Interfaces
{
    ///<summary>
    /// Интерфейс, описывает сущность, которая может создать запрос о предоставлении некой вклакди для некого содержимого
    ///</summary>
    public interface IReference
    {
        #region  Properties 

        #region IDisplayer Displayer

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        IDisplayer Displayer { get; set; }

        #endregion

        #region string DisplayerText { get; set;}
        /// <summary>
        /// Текст заголовка вкладки, когда на ней будет отображатся переданное содержимое
        /// </summary>
        string DisplayerText { get; set;}
        #endregion

        #region IDisplayingEntity Entity

        /// <summary>
        /// Содержимое, которое необходимо отобразить
        /// </summary>
        IDisplayingEntity Entity { get; set; }

        #endregion

        #region ReflectionTypes ReflectionType

        /// <summary>
        /// Тип предоставления вкладки (в этой, в новой, в какой-то из имеющихся, и т.д.)
        /// </summary>
        ReflectionTypes ReflectionType { get; set; }

        #endregion

        #endregion

        #region Events

        #region event EventHandler<ReferenceEventArgs> DisplayerRequested

        /// <summary>
        /// Событие, сообщающее о необходимости предоставления вкладки
        /// </summary>
        event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

        #endregion
    }

    /// <summary>
    /// класс - хранилише обектов требующихся для отбражения вкладки
    /// </summary>
    public class DisplayingObject
    {
        #region Fields

        private string displayingText;
        private IDisplayingEntity displayingEntity;

        #endregion

        #region Constructors

        #region public DisplayingObject()

        ///<summary>
        /// Создается пустой класс - хранилише обектов требующихся для отбражения вкладки
        ///</summary>
        public DisplayingObject()
        {
            
        }

        #endregion

        #region public DisplayingObject(IDisplayingEntity displayingEntity, string displayingText)

        ///<summary>
        /// Создается класс - хранилише обектов требующихся для отбражения вкладки
        ///</summary> 
        ///<param name="displayingEntity">Содержимое вкладки</param>
        ///<param name="displayingText">Название вкладки</param>               
        public DisplayingObject(IDisplayingEntity displayingEntity, string displayingText)
        {
            this.displayingEntity = displayingEntity;
            this.displayingText = displayingText;
        }

        #endregion

        #endregion

        #region Properties

        #region public string DisplayingText

        /// <summary>
        /// Text to display
        /// </summary>
        public string DisplayingText
        {
            get
            {
                return displayingText;
            }
            set
            {
                displayingText = value;
            }
        }

        #endregion

        #region public IDisplayingEntity DisplayingEntity
        /// <summary>
        /// Содержимое вкладки
        /// </summary>
        public IDisplayingEntity DisplayingEntity
        {
            get { return displayingEntity; }
            set
            {
                displayingEntity = value;
            }
        }

        #endregion

        #endregion
    }

    /// <summary>
    /// Arguments of events, occuring at requests of displaying some DisplayingEntity
    /// </summary>
    public class ReferenceEventArgs : CancelEventArgs
    {
        #region Fields

        #region private IDisplayingEntity[] RequestedEntityes

        /// <summary>
        /// Entityes to display
        /// </summary>
        private DisplayingObject[] _requestedDisplayingObjects;

        #endregion

        #region private IDisplayingEntity requestedEntity

        /// <summary>
        /// Enity to display
        /// </summary>
        private IDisplayingEntity _requestedEntity;

        #endregion

        #region private ReflectionTypes typeOfReflection

        /// <summary>
        /// Displaying parameters
        /// </summary>
        private ReflectionTypes _typeOfReflection = ReflectionTypes.DisplayInNew;

        #endregion

        #region private IDisplayer destinationDisplayer

        /// <summary>
        /// Displayer where entity must be displayed
        /// </summary>
        private IDisplayer _destinationDisplayer;

        #endregion

        #region private string displayerText

        /// <summary>
        /// Header of page that would be displaying entity
        /// </summary>
        private string _displayerText = "";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public ReferenceEventArgs()
        {
            _typeOfReflection = ReflectionTypes.DisplayInCurrent;
        }

        #region public ReferenceEventArgs(DisplayingEntity requestedEntity, ReflectionTypes typeOfReflection)

        /// <summary>
        /// Creates new instance of ReferenceEventArgs
        /// </summary>
        /// <param name="requestedEntity">Entity to display</param>
        /// <param name="typeOfReflection">Displaying parameters</param>
        /// <param name="displayerText">Text of displayer's header</param>
        
        public ReferenceEventArgs(IDisplayingEntity requestedEntity, ReflectionTypes typeOfReflection, string displayerText)
            : this(requestedEntity, typeOfReflection, null, displayerText)
        {
        }

        #endregion

        #region public ReferenceEventArgs(DisplayingEntity requestedEntity, ReflectionTypes typeOfReflection, IDisplayer destinationDisplayer)

        /// <summary>
        /// Creates new instance of ReferenceEventArgs
        /// </summary>
        /// <param name="requestedEntity">Entity to display</param>
        /// <param name="typeOfReflection">Displaying parameters</param>
        /// <param name="destinationDisplayer">Displayer where entity must be displayed</param>
        /// <param name="displayerText">Text of displayer's header</param>
        public ReferenceEventArgs(IDisplayingEntity requestedEntity, ReflectionTypes typeOfReflection, IDisplayer destinationDisplayer, string displayerText)
        {
            _requestedEntity = requestedEntity;
            _typeOfReflection = typeOfReflection;
            _destinationDisplayer = destinationDisplayer;
            _displayerText = displayerText;
        }

        #endregion

        #endregion

        #region Properties

        #region public IDisplayingEntity RequestedEntity

        /// <summary>
        /// Enity to display
        /// </summary>
        public IDisplayingEntity RequestedEntity
        {
            get { return _requestedEntity; }
            set { _requestedEntity = value; }
        }

        #endregion

        #region public DisplayingObject[] RequestedDisplayingObjects

        /// <summary>
        /// Objects to display
        /// </summary>
        public DisplayingObject[] RequestedDisplayingObject
        {
            get { return _requestedDisplayingObjects; }
            set { _requestedDisplayingObjects = value; }
        }

        #endregion


        #region public ReflectionTypes TypeOfReflection

        /// <summary>
        /// Displaying parameters
        /// </summary>
        public ReflectionTypes TypeOfReflection
        {
            get { return _typeOfReflection; }
            set {_typeOfReflection = value;}
        }

        #endregion

        #region public IDisplayer DestinationDisplayer

        /// <summary>
        /// Displayer where entity must be displayed
        /// </summary>
        public IDisplayer DestinationDisplayer
        {
            get { return _destinationDisplayer; }
        }

        #endregion

        #region public string DisplayerText
        /// <summary>
        /// Header of page that would be displaying entity
        /// </summary>
        public string DisplayerText
        {
            get { return _displayerText; }
            set { _displayerText = value; }
        }
		#endregion

		#endregion

		#region Methods

	    public void SetParameters(DisplayerParams parameters)
	    {
		    _typeOfReflection = parameters.TypeOfReflection;
		    _requestedEntity = parameters.Page;
		    _displayerText = parameters.PageCaption;
	    }

		#endregion
	}

	public class DisplayerParams
	{
		#region Constructor

		#region private DisplayerParams()

        public DisplayerParams()
		{

		}

		#endregion

		#endregion

		#region Properties

		#region public DisplayerType DisplayerType { get; set; }
		/// <summary>
		/// Тип отображателя, экран или форма
		/// </summary>
		public DisplayerType DisplayerType { get; set; }

		#endregion

		#region public Form Form { get; set; }

		public Form Form { get; set; }

		#endregion


		#region public string PageCaption { get; set; }
		/// <summary>
		/// текст заголовка вкладки для screenControl
		/// </summary>
		public string PageCaption { get; set; }

		#endregion

		#region public ReflectionTypes TypeOfReflection { get; set; }
		/// <summary>
		/// как нужно открывать новый ScreenControl
		/// </summary>
		public ReflectionTypes TypeOfReflection { get; set; }

		#endregion

		#region public ScreenControl Page { get; set; }

		public ScreenControl Page { get; set; }

		#endregion


		#endregion

		#region Methods

		#region public static DisplayerParams CreateFormParams(Form form)

		public static DisplayerParams CreateFormParams(Form form)
		{
			return new DisplayerParams() {Form = form , DisplayerType = DisplayerType.Form};
		}

		#endregion

		#region public static DisplayerParams CreateScreenParams(ReflectionTypes reflectionType, string pageCaption,ScreenControl screenControl)

		public static DisplayerParams CreateScreenParams(ReflectionTypes reflectionType, string pageCaption,ScreenControl screenControl)
		{
			return new DisplayerParams() {TypeOfReflection = reflectionType , PageCaption = pageCaption , Page = screenControl ,DisplayerType = DisplayerType.Screen};
		}

		#endregion

		#endregion
	}
}