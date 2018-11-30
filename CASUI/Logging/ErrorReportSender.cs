using System;
using System.Collections.Generic;
using System.Text;

using System.Web;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types;
using CASTerms;

namespace CAS.UI.Logging
{

    /// <summary>
    /// Отправляет отчеты об ошибках 
    /// </summary>
    public static class ErrorReportSender
    {

        /*
         * Вызов метода
         */

        /// <summary>
        /// Отправляет отчет об ошибке 
        /// </summary>
        /// <param name="ReportPath"></param>
        /// <returns></returns>
        public static bool SendReport (string ReportPath)
        {
            try
            {
                // Если файла не существует, отправлять ничего не нужно
                if (!System.IO.File.Exists(ReportPath)) return true;

                DialogResult result = MessageBox.Show(
                    "CAS information system has encountered a problem and failed." +
                    Environment.NewLine +
                    "Please help us to improve CAS information system by sending us this error message." +
                    Environment.NewLine +
                    "Click Yes to send error message to our support team.",
                    new GlobalTermsProvider()["SystemName"].ToString(),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return false;

                // Авторизация на SMTP сервере
                SmtpClient Smtp = new SmtpClient(_ServerName, _Port);
                Smtp.Credentials = new NetworkCredential(_User, _Password);

                // Формируем сообщение
                MailMessage message = PrepareMessage();

                // Прикрепляем файл
                if (message != null) EncloseErrorReport(message, ReportPath);

                // Отправляем сообщение
                if (message != null) Smtp.Send(message);

                // Лог ошибок отправлен, ошибок не возникло, удаляем файл
                if (message != null) DeleteReportFile(ReportPath);
            }
            catch
            {
                MessageBox.Show(
                    "We have failed to send error report.\r\nIt can probably be caused by no active internet connection.\r\nError report was saved to a local directory.", 
                    "Continuing Airworthiness System",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            return true;
        }


        /*
         * Реализация 
         */

        /// <summary>
        /// Возвращает информацию о компьютере, на котором вылетела ошибка
        /// </summary>
        /// <returns></returns>
        private static string GetSpecificInformation()
        {
            StringBuilder builder = new StringBuilder();

            try
            {
                Int32 count = OperatorCollection.Instance.Count;
                for (int i = 0; i < count; i++)
                    if (OperatorCollection.Instance[i].ChildObjectsLoaded)
                    {
                        builder.AppendFormat("Company : {0}", OperatorCollection.Instance[i].Name);
                        builder.AppendLine();
                        break;
                    }
            }
            catch
            {
            }

            try
            {
                GlobalTermsProvider termsProvider = new GlobalTermsProvider();
                builder.AppendFormat(
                    "Version : {0}.{1}", 
                    termsProvider["ProductVersion"], 
                    termsProvider["ProductBuild"]);
                builder.AppendLine();
            }
            catch
            {
            }

            try
            {
                builder.AppendFormat(
                    "User Name : {0}", Users.CurrentUser.FullName);
                builder.AppendLine();
            }
            catch (Exception)
            {
            }

            try
            {
                builder.AppendFormat(
                    "Machine Name : {0}", Environment.MachineName);
                builder.AppendLine();
            }
            catch (Exception)
            {
            }

            // TODO:
            // Дата установки программы CAS
            // Используется ли ключ
            return builder.ToString();
        }

        /// <summary>
        /// Подгатавливает письмо для отправки
        /// </summary>
        /// <returns></returns>
        private static MailMessage PrepareMessage()
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(_From);
                message.To.Add(new MailAddress(_To));
                message.Subject = _Subject;
                message.Body = GetSpecificInformation();
                return message;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Подгатавливает письмо для отправки
        /// </summary>
        /// <returns></returns>
        private static MailMessage PrepareMessage(String from, String to, String subject, String content)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(from);
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                message.Body = content;
                return message;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Пригладываем файл с отчетом об ошибках
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ReportPath"></param>
        private static void EncloseErrorReport(MailMessage message, string ReportPath)
        {
            try
            {
                if (!System.IO.File.Exists(ReportPath)) return;

                Attachment attachment = new Attachment(ReportPath);
                attachment.Name = "log.txt";
                ContentDisposition disposition = attachment.ContentDisposition;
                disposition.CreationDate = File.GetCreationTime(ReportPath);
                disposition.ModificationDate = File.GetLastWriteTime(ReportPath);
                disposition.ReadDate = File.GetLastAccessTime(ReportPath);
                message.Attachments.Add(attachment);
            }
            catch
            {
            }
        }

        #region private static void DeleteReportFile(string ReportPath)
        /// <summary>
        /// Удаляет файл - отчет об ошибке
        /// </summary>
        /// <param name="ReportPath"></param>
        private static void DeleteReportFile(string ReportPath)
        {
            try
            {
                FileInfo fi = new FileInfo(ReportPath);
                fi.Delete();
            }
            catch
            {
            }
        }
        #endregion

        /*
         * Контстанты
         */

        private const string _ServerName = "smtp.mail.ru";
        private const int _Port = 25;
        private const string _User = "caserrorreportsender";
        private const string _Password = "CsErR5ReRtEn4e9";
        private const string _From = "CAS Error Report <caserrorreportsender@mail.ru>";
        private const string _To = "aleksey.baryshnikov@avalonkg.com";
        private const string _Subject = "Error Report";
    }
}
