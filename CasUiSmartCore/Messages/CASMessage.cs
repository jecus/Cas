using System.Windows.Forms;
using CASTerms;

namespace CAS.UI.Messages
{
    /// <summary>
    /// Класс для отпраки сообщений пользователю
    /// </summary>
    public class CASMessage
    {

        #region public static void Show(MessageType messageType)

        /// <summary>
        /// Показать сообшение системы CAS
        /// </summary>
        /// <param name="messageType">тип сообщения</param>
        public static DialogResult Show(MessageType messageType)
        {
            MessageInfoProvider messageInfoProvider = new MessageInfoProvider();

            return MessageBox.Show(messageInfoProvider[messageType.ToString()] + GetMessageEnd(messageType), messageType.ToString(),MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        #endregion


        #region public static DialogResult Show(MessageType messageType, MessageBoxButtons messageBoxButtons)

        /// <summary>
        /// Показать сообшение системы CAS
        /// </summary>
        /// <param name="messageType">тип сообщения</param>
        /// <param name="messageBoxButtons"></param>
        public static DialogResult Show(MessageType messageType, MessageBoxButtons messageBoxButtons)
        {
            MessageInfoProvider messageInfoProvider = new MessageInfoProvider();

            return MessageBox.Show(messageInfoProvider[messageType.ToString()] + GetMessageEnd(messageType), messageType.ToString(),messageBoxButtons,MessageBoxIcon.Information);

        }

        #endregion

        #region public static void Show(MessageType messageType, object[] objectsToReplace)

        /// <summary>
        /// Показать сообшение системы CAS с заменой в тексте сообшения
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="objectsToReplace"></param>
        public static DialogResult Show(MessageType messageType, object[] objectsToReplace)
        {
            MessageInfoProvider messageInfoProvider = new MessageInfoProvider();
            return MessageBox.Show(
                string.Format(messageInfoProvider[messageType.ToString()].ToString(), objectsToReplace) + GetMessageEnd(messageType) 
                , messageType.ToString());
        }

        #endregion

        #region private static string GetMessageEnd(MessageType messageType)
        private static string GetMessageEnd(MessageType messageType)
        {
            return "\n\rMessage Code: " + ((int) messageType);
        }

        #endregion


    }
}