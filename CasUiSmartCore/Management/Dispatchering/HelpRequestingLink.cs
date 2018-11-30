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

        private string _topicId;

        #endregion
        
        #region Constructors

        #region public HelpRequestingLink()

        ///<summary>
        /// Создается экземпляр ссылки, заправшивающей спарвку
        ///</summary>
        public HelpRequestingLink()
        {
            LinkClicked += HelpRequestingLinkLinkClicked;
        }

        #endregion

        #region public HelpRequestingLink(string topicID) : this()

        ///<summary>
        /// Создается экземпляр ссылки, заправшивающей спарвку
        ///</summary>
        ///<param name="topicId">Раздел справки для отображения</param>
        public HelpRequestingLink(string topicId) : this()
        {
            _topicId = topicId;
        }

        #endregion
        
        #endregion

        #region Methods

        #region private void HelpRequestingLinkLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void HelpRequestingLinkLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RequestHelp();
        }

        #endregion

        #endregion

        #region IHelpRequester Members

        /// <summary>
        /// Occurs when help was requested by object
        /// </summary>
        public new event HelpEventHandler HelpRequested;

        ///<summary>
        /// Описание раздела помощи
        ///</summary>
        public string TopicId
        {
            get { return _topicId; }
            set { _topicId = value; }
        }

        /// <summary>
        /// Вызывается событие HelpRequested
        /// </summary>
        public void RequestHelp()
        {
            RequestHelp(_topicId);
        }

        /// <summary>
        /// Вызывается событие HelpRequested для отображения справки заданного раздела
        /// </summary>
        /// <param name="topicId">Описание раздела справки</param>
        public void RequestHelp(string topicId)
        {
            if (HelpRequested != null)
                HelpRequested.Invoke(this, new HelpEventHandlerArgs(topicId));
        }

        #endregion

    }
}
