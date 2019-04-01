using System;

namespace CAS.UI.Events
{
    ///<summary> 
    ///</summary>
    ///<param name="sender"></param>
    ///<param name="args"></param>
    public delegate void HelpEventHandler(object sender, HelpEventHandlerArgs args);

    /// <summary>
    /// Класс, содержащий свойства события
    /// </summary>
    public class HelpEventHandlerArgs : EventArgs
    {
        private readonly string topicId;

        /// <summary>
        /// Класс, содержащий свойства события
        /// </summary>
        /// <param name="topicId">Раздел в справочном документе</param>
        public HelpEventHandlerArgs(string topicId)
        {
            this.topicId = topicId;
        }

        /// <summary>
        /// Раздел в справочном документе
        /// </summary>
        public string TopicId
        {
            get { return topicId; }
        }
    }
}