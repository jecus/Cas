using System.Windows.Forms;
using LTR.Events;
using LTR.UI.Interfaces;

namespace LTR.UI.Management.Dispatchering
{
    /// <summary>
    /// Класс для слежения за запросами отображения помощи, и обрабатывания их
    /// </summary>
    internal class HelpDispathcer:IDispatcher
    {
        /// <summary>
        /// Создается новый экземпляр класса
        /// </summary>
        /// <param name="proxy">Объект, за которым происходит слежение</param>
        internal HelpDispathcer(IDisplayerCollectionProxy proxy)
        {
            defaultProxy = proxy;
        }

        private string helpSource = @"D:\Projects\Ltr\LTRHelp\LTRHelp.chm";

        /// <summary>
        /// Проверить, необходимо ли следить за контролом.
        /// </summary>
        /// <param name="control">Объект для проверки</param>
        internal override void ProcessControl(Control control)
        {
            if (control is IHelpRequester)
            {
                IHelpRequester requester = control as IHelpRequester;
                requester.HelpRequested -= requester_HelpRequested;
                requester.HelpRequested += requester_HelpRequested;
            }
        }

        private void requester_HelpRequested(object sender, LTR.Events.HelpEventHandlerArgs args)
        {
            ShowHelp(args);
        }

        private void ShowHelp(HelpEventHandlerArgs args)
        {
            
            Help.ShowHelp(defaultProxy as Control, helpSource,HelpNavigator.TopicId, args.TopicId);
        }
    }
}
