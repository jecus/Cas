using System;
using System.ComponentModel;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.Interfaces
{
    ///<summary>
    /// Интерфейс, ну просто вот такой вот интерфейс =))
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
        /// Text of page's header that Reference lead to
        /// </summary>
        string DisplayerText { get; set;}
        #endregion

        #region IDisplayingEntity Entity

        /// <summary>
        /// Entity to display
        /// </summary>
        IDisplayingEntity Entity { get; set; }

        #endregion

        #region ReflectionTypes ReflectionType

        /// <summary>
        /// Type of reflection
        /// </summary>
        ReflectionTypes ReflectionType { get; set; }

        #endregion

        #endregion

        #region Events

        #region event EventHandler<ReferenceEventArgs> DisplayerRequested

        /// <summary>
        /// Occurs when linked invoker requests displaying 
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
        private DisplayingObject[] requestedDisplayingObjects;

        #endregion

        #region private IDisplayingEntity requestedEntity

        /// <summary>
        /// Enity to display
        /// </summary>
        private IDisplayingEntity requestedEntity;

        #endregion

        #region private ReflectionTypes typeOfReflection

        /// <summary>
        /// Displaying parameters
        /// </summary>
        private ReflectionTypes typeOfReflection = ReflectionTypes.DisplayInNew;

        #endregion

        #region private IDisplayer destinationDisplayer

        /// <summary>
        /// Displayer where entity must be displayed
        /// </summary>
        private IDisplayer destinationDisplayer;

        #endregion

        #region private string displayerText

        /// <summary>
        /// Header of page that would be displaying entity
        /// </summary>
        private string displayerText = "";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public ReferenceEventArgs()
        {
            typeOfReflection = ReflectionTypes.DisplayInNew;
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
            this.requestedEntity = requestedEntity;
            this.typeOfReflection = typeOfReflection;
            this.destinationDisplayer = destinationDisplayer;
            this.displayerText = displayerText;
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
            get { return requestedEntity; }
            set { requestedEntity = value; }
        }

        #endregion

        #region public DisplayingObject[] RequestedDisplayingObjects

        /// <summary>
        /// Objects to display
        /// </summary>
        public DisplayingObject[] RequestedDisplayingObject
        {
            get { return requestedDisplayingObjects; }
            set { requestedDisplayingObjects = value; }
        }

        #endregion


        #region public ReflectionTypes TypeOfReflection

        /// <summary>
        /// Displaying parameters
        /// </summary>
        public ReflectionTypes TypeOfReflection
        {
            get { return typeOfReflection; }
            set {typeOfReflection = value;}
        }

        #endregion

        #region public IDisplayer DestinationDisplayer

        /// <summary>
        /// Displayer where entity must be displayed
        /// </summary>
        public IDisplayer DestinationDisplayer
        {
            get { return destinationDisplayer; }
        }

        #endregion

        #region public string DisplayerText
        /// <summary>
        /// Header of page that would be displaying entity
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }
        #endregion

        #endregion
    }
}