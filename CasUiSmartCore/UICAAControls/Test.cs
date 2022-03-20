using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls
{
    public partial class Test : MetroForm
    { 
        int i = 0;
        bool flag = false;
        private readonly Author _author1;
        private readonly Author _author2;

        public Test()
        {
            InitializeComponent();
            
            _author1 = new Author(Properties.Resources.runner, "Ben");
            _author2 = new Author(Properties.Resources.AddUser, "JEcus");
            this.radChat2.Author = _author1;
            this.radChat2.AutoAddUserMessages = false;
            this.radChat2.SendMessage += radChat1_SendMessage;
            this.radChat2.CardActionClicked += radChat1_CardActionClicked;

            radChat2.ChatElement.SendButtonElement.Enabled = false;
            radChat2.ChatElement.ShowToolbarButtonElement.Visibility = ElementVisibility.Hidden;

        }
        
        private void radChat1_CardActionClicked(object sender, CardActionEventArgs e)
        {
            if (e.Action.Text == "Accept")
            {
                flag = true;
                RadMessageBox.Show("IM is clicked.");
            }
            else if (e.Action.Text == "Reject")
            {
                RadMessageBox.Show("Call is clicked");
            }
        }
        
        private void radChat1_SendMessage(object sender, SendMessageEventArgs e)
        {
            ChatTextMessage textMessage = e.Message as ChatTextMessage;

            if (i % 2 == 0)
            {
                textMessage.Author = _author1;

                if (!flag)
                {
                    var actions = new List<ChatCardAction>();
                    actions.Add(new ChatCardAction("Accept"));
                    actions.Add(new ChatCardAction("Reject"));
                    ChatImageCardDataItem imageCard = new ChatImageCardDataItem(null, "Explain", "Какой то текст!!!!",textMessage.Message,
                        actions, null);
                    ChatCardMessage message = new ChatCardMessage(imageCard, _author1, DateTime.Now);
                    this.radChat2.AddMessage(message);
                }
                else this.radChat2.AddMessage(textMessage);
            }
            else
            {
                textMessage.Author = _author2;

                if (!flag)
                {
                    var actions = new List<ChatCardAction>();
                    actions.Add(new ChatCardAction("Accept"));
                    actions.Add(new ChatCardAction("Reject"));
                    ChatImageCardDataItem imageCard = new ChatImageCardDataItem(null, "Explain", "Какой то текст!!!!",textMessage.Message,
                        actions, null);
                    ChatCardMessage message = new ChatCardMessage(imageCard, _author2, DateTime.Now);
                    this.radChat2.AddMessage(message);
                }
                else this.radChat2.AddMessage(textMessage);
            }
            i++;
        }

        private void Test_Load(object sender, EventArgs e)
        {
           
        }
    }
}