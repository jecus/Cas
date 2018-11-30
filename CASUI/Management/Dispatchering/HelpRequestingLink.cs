using System.Windows.Forms;
using CAS.UI.Events;
using CAS.UI.Interfaces;
using HelpEventHandler=CAS.UI.Events.HelpEventHandler;

namespace CAS.UI.Management.Dispatchering
{
    ///<summary>
    /// Класс, описывающий ссылку, запрашивающую справку
    ///</summary>
    public class HelpRequestingLink : LinkLabel, IHelpRequester
    {

        #region Fields

        private string topicID;

        #endregion
        
        #region Constructors

        #region public HelpRequestingLink()

        ///<summary>
        /// Создается экземпляр ссылки, заправшивающей спарвку
        ///</summary>
        public HelpRequestingLink()
        {
            LinkClicked += new LinkLabelLinkClickedEventHandler(HelpRequestingLink_LinkClicked);
        }

        #endregion

        #region public HelpRequestingLink(string topicID) : this()

        ///<summary>
        /// Создается экземпляр ссылки, заправшивающей спарвку
        ///</summary>
        ///<param name="topicID">Раздел справки для отображения</param>
        public HelpRequestingLink(string topicID) : this()
        {
            this.topicID = topicID;
        }

        #endregion
        
        #endregion

        #region Methods

        #region private void HelpRequestingLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void HelpRequestingLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RequestHelp();
        }

        #endregion

        #endregion

        #region IHelpRequester Members

        /// <summary>
        /// Occurs when help was requested by object
        /// </summary>
        public event HelpEventHandler HelpRequested;

        ///<summary>
        /// Описание раздела помощи
        ///</summary>
        public string TopicID
        {
            get { return topicID; }
            set { topicID = value; }
        }

        /// <summary>
        /// Вызывается событие HelpRequested
        /// </summary>
        public void RequestHelp()
        {
            RequestHelp(topicID);
        }

        /// <summary>
        /// Вызывается событие HelpRequested для отображения справки заданного раздела
        /// </summary>
        /// <param name="topicID">Описание раздела справки</param>
        public void RequestHelp(string topicID)
        {
            if (HelpRequested != null)
                HelpRequested.Invoke(this, new HelpEventHandlerArgs(topicID));
        }

        #endregion

    }
}
