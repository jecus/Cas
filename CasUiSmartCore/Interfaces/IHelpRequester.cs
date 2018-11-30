using CAS.UI.Events;

namespace CAS.UI.Interfaces
{
    ///<summary>
    /// Описывает объект, способный запрашивать справку
    ///</summary>
    public interface IHelpRequester
    {
        /// <summary>
        /// Occurs when help was requested by object
        /// </summary>
        event HelpEventHandler HelpRequested;

        ///<summary>
        /// Описание раздела помощи
        ///</summary>
        string TopicId { get; set;}

        /// <summary>
        /// Вызывается событие HelpRequested
        /// </summary>
        void RequestHelp();

        /// <summary>
        /// Вызывается событие HelpRequested для отображения справки заданного раздела
        /// </summary>
        /// <param name="topicId">Описание раздела справки</param>
        void RequestHelp(string topicId);
    }
}
