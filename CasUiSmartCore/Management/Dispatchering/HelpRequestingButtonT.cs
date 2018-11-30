using System;
using AvControls.AvButtonT;
using CAS.UI.Events;
using CAS.UI.Interfaces;

namespace CAS.UI.Management.Dispatchering
{
    ///<summary>
    /// Класс, описывающий кнопку, запрашивающую справку
    ///</summary>
    public class HelpRequestingButtonT : AvButtonT, IHelpRequester
    {
        private string _topicId = "";


        ///<summary>
        /// Создается экземпляр кнопки, заправшивающей спарвку
        ///</summary>
        public HelpRequestingButtonT()
        {
            Click += HelpRequestingButtonClick;
        }

        void HelpRequestingButtonClick(object sender, EventArgs e)
        {
            RequestHelp();
        }

        ///<summary>
        /// Создается экземпляр кнопки, заправшивающей спарвку
        ///</summary>
        ///<param name="topicId">Раздел справки для отображения</param>
        public HelpRequestingButtonT(string topicId):this()
        {
            _topicId = topicId;
        }

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
            get
            {
                return _topicId;
            }
            set
            {
                _topicId = value;
            }
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