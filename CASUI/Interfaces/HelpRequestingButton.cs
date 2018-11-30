using System;
using System.Collections.Generic;
using System.Text;
using Controls.AvButton;
using LTR.Events;

namespace LTR.UI.Interfaces
{
    ///<summary>
    /// Класс, описывающий кнопку, запрашивающую справку
    ///</summary>
    public class HelpRequestingButton : AvButton, IHelpRequester
    {
        private string topicID;


        ///<summary>
        /// Создается экземпляр кнопки, заправшивающей спарвку
        ///</summary>
        public HelpRequestingButton()
        {
            this.Click += new EventHandler(HelpRequestingButton_Click);
        }

        void HelpRequestingButton_Click(object sender, EventArgs e)
        {
            RequestHelp();
        }

        ///<summary>
        /// Создается экземпляр кнопки, заправшивающей спарвку
        ///</summary>
        ///<param name="topicID">Раздел справки для отображения</param>
        public HelpRequestingButton(string topicID):this()
        {
            this.topicID = topicID;
        }

        #region IHelpRequester Members

        /// <summary>
        /// Occurs when help was requested by object
        /// </summary>
        public new event HelpEventHandler HelpRequested;

        ///<summary>
        /// Описание раздела помощи
        ///</summary>
        public string TopicID
        {
            get
            {
                return topicID;
            }
            set
            {
                topicID = value;
            }
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
