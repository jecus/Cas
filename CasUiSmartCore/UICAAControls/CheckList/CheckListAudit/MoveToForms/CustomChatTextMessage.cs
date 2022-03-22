using System;
using Telerik.WinControls.UI;

namespace CAS.UI.UICAAControls.CheckList.CheckListAudit.MoveToForms
{
    public class CustomChatTextMessage<T> : ChatTextMessage where T: class
    {
        public CustomChatTextMessage(T tag, string message, Author author, DateTime timeStamp) : base(message, author, timeStamp)
        {
            Tag = tag;
        }

        public CustomChatTextMessage(T tag, string message, Author author, DateTime timeStamp, object userData) : base(message, author, timeStamp, userData)
        {
            Tag = tag;
        }
        
        public T Tag { get; set; }
        
    }
}