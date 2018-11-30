using System;
using Controls.AvButtonT;
using CAS.UI.Events;
using CAS.UI.Interfaces;

namespace CAS.UI.Management.Dispatchering
{
    ///<summary>
    /// Класс, описывающий кнопку, запрашивающую справку
    ///</summary>
    public class HelpRequestingButtonT : AvButtonT, IHelpRequester
    {
        private string topicID = "";


        ///<summary>
        /// Создается экземпляр кнопки, заправшивающей спарвку
        ///</summary>
        public HelpRequestingButtonT()
        {
            Click += HelpRequestingButton_Click;
        }

        void HelpRequestingButton_Click(object sender, EventArgs e)
        {
            RequestHelp();
        }

        ///<summary>
        /// Создается экземпляр кнопки, заправшивающей спарвку
        ///</summary>
        ///<param name="topicID">Раздел справки для отображения</param>
        public HelpRequestingButtonT(string topicID):this()
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HelpRequestingButtonT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "HelpRequestingButtonT";
            this.ResumeLayout(false);

        }
    }
}