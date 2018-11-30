using CAS.UI.Events;

namespace CAS.UI.Interfaces
{
    ///<summary>
    /// ��������� ������, ��������� ����������� �������
    ///</summary>
    public interface IHelpRequester
    {
        /// <summary>
        /// Occurs when help was requested by object
        /// </summary>
        event HelpEventHandler HelpRequested;

        ///<summary>
        /// �������� ������� ������
        ///</summary>
        string TopicID { get; set;}

        /// <summary>
        /// ���������� ������� HelpRequested
        /// </summary>
        void RequestHelp();

        /// <summary>
        /// ���������� ������� HelpRequested ��� ����������� ������� ��������� �������
        /// </summary>
        /// <param name="topicID">�������� ������� �������</param>
        void RequestHelp(string topicID);
    }
}
