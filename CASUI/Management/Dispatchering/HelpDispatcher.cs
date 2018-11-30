using System;
using System.Diagnostics;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.UI.Events;
using CAS.UI.Interfaces;

namespace CAS.UI.Management.Dispatchering
{
    /// <summary>
    /// Класс для слежения за запросами отображения помощи, и обрабатывания их
    /// </summary>
    internal class HelpDispatcher:IDispatcher
    {
        /// <summary>
        /// Создается новый экземпляр класса
        /// </summary>
        /// <param name="proxy">Объект, за которым происходит слежение</param>
        internal HelpDispatcher(IDisplayerCollectionProxy proxy)
        {
            defaultProxy = proxy;
        }

        //private readonly string helpSource = @"..\..\..\..\LTRHelp\CASHelp.chm";
        private readonly string helpSource = "CASHelp.pdf";

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

        private void requester_HelpRequested(object sender, HelpEventHandlerArgs args)
        {
            ShowHelp(args);
        }

        private void ShowHelp(HelpEventHandlerArgs args)
        {
            try
            {
                Process.Start("Acrobat.exe", "/a nameddest=" + args.TopicId + " \"" + helpSource + "\"");
            }
            catch
            {
                try
                {
                    Process.Start(helpSource);
                }
                catch
                {
                    MessageBox.Show("An error occured while opening help file", new TermsProvider()["SystemName"].ToString(),
                                MessageBoxButtons.OK, MessageBoxIcon.Error);    
                }
            }
        }
    }
}