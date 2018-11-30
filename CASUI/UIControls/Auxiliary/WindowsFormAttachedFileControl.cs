using System;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types;
using CAS.UI.Appearance;
using System.Drawing;
using Auxiliary;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Элемент управления для отображения информации о прикрепленном файле в формах редактирования чего-либо
    /// </summary>
    public class WindowsFormAttachedFileControl : UserControl
    {
        #region Fields

        private readonly PictureBox pictureBoxPDF = new PictureBox();
        private readonly Label labelDescription = new Label();
        private readonly LinkLabel linkLabelBrowse = new LinkLabel();
        private readonly LinkLabel linkLabelOpen = new LinkLabel();
        private readonly LinkLabel linkLabelRemove = new LinkLabel();

        private AttachedFile file;
        private string fileNameToRemove;
        protected string filter;
        protected string description1;
        protected string description2;
        protected Image icon;

        #endregion

        #region Constructors
        
        /// <summary>
        /// Создает элемент управления для отображения информации о прикрепленном файле в формах редактирования чего-либо
        /// </summary>
        public WindowsFormAttachedFileControl()
        {
        }

        /// <summary>
        /// Создает элемент управления для отображения информации о прикрепленном файле в формах редактирования чего-либо
        /// </summary>
        /// <param name="file">Сам файл</param>
        /// <param name="filter">Фильтр в OpenFileDialog</param>
        /// <param name="description1">Описание 1</param>
        /// <param name="description2">Описание 2</param>
        /// <param name="icon">Иконка файла</param>
        public WindowsFormAttachedFileControl(AttachedFile file, string filter, string description1, string description2, Image icon)
        {
            this.file = file;
            this.filter = filter;
            this.description1 = description1;
            this.description2 = description2;
            this.icon = icon;
            InitializeComponent();
            UpdateInfo();
        }

        #endregion

        #region Properties

        #region public AttachedFile AttachedFile

        /// <summary>
        /// Возвращает прикрепленный файл
        /// </summary>
        public AttachedFile AttachedFile
        {
            get
            {
                return file;
            }
            set
            {
                file = value;
                UpdateInfo();
            }
        }

        #endregion

        #endregion

        #region Methods

        #region protected void InitializeComponent()

        protected void InitializeComponent()
        {
            //
            // pictureBoxPDF
            //
            pictureBoxPDF.BackgroundImage = icon;
            pictureBoxPDF.BackgroundImageLayout = ImageLayout.Center;
            pictureBoxPDF.Location = new Point(0, 0);
            pictureBoxPDF.Size = Css.WindowsForm.Constants.DefaultPictureBoxSize;
            //
            // labelDescription
            //
            labelDescription.AutoSize = true;
            labelDescription.Font = Css.WindowsForm.Fonts.RegularFont;
            labelDescription.ForeColor = Css.WindowsForm.Colors.ForeColor;
            labelDescription.Location = new Point(pictureBoxPDF.Right + Css.WindowsForm.Constants.TAB_LEFT_MARGIN, 0);
            labelDescription.SizeChanged += labelDescription_SizeChanged;
            //
            // linkLabelBrowse
            //
            linkLabelBrowse.AutoSize = true;
            linkLabelBrowse.Font = Css.WindowsForm.Fonts.RegularFont;
            linkLabelBrowse.LinkColor = Css.WindowsForm.Colors.LinkLabelColor;
            linkLabelBrowse.Text = "Browse";
            linkLabelBrowse.LinkClicked += linkLabelBrowse_LinkClicked;
            //
            // linkLabelOpen
            //
            linkLabelOpen.AutoSize = true;
            linkLabelOpen.Font = Css.WindowsForm.Fonts.RegularFont;
            linkLabelOpen.LinkColor = Css.WindowsForm.Colors.LinkLabelColor;
            linkLabelOpen.Text = "Open";
            linkLabelOpen.LinkClicked += linkLabelOpen_LinkClicked;
            //
            // linkLabelRemove
            //
            linkLabelRemove.AutoSize = true;
            linkLabelRemove.Font = Css.WindowsForm.Fonts.RegularFont;
            linkLabelRemove.LinkColor = Css.WindowsForm.Colors.LinkLabelColor;
            linkLabelRemove.Text = "Remove";
            linkLabelRemove.LinkClicked += linkLabelRemove_LinkClicked;
            // 
            // WindowsFormAttachedFileControl
            // 
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Css.WindowsForm.Colors.TabBackColor;
            Controls.Add(pictureBoxPDF);
            Controls.Add(labelDescription);
            Controls.Add(linkLabelBrowse);
            Controls.Add(linkLabelOpen);
            Controls.Add(linkLabelRemove);
        }

        #endregion

        #region private void UpdateInfo()

        /// <summary>
        /// Обновляет информацию
        /// </summary>
        protected void UpdateInfo()
        {
            if (file == null || file.FileData == null)
            {
                labelDescription.Text = description1;
                linkLabelBrowse.Visible = true;
                linkLabelOpen.Visible = false;
                linkLabelRemove.Visible = false;
            }
            else
            {
                labelDescription.Text = description2 + Environment.NewLine + "File name: " + file.FileName + Environment.NewLine + "Size: " + (file.FileData.Length / 1024) + " KB";
                linkLabelBrowse.Visible = false;
                linkLabelOpen.Visible = true;
                linkLabelRemove.Visible = true;
            }
        }

        #endregion

        #region private void linkLabelBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void linkLabelBrowse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = filter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (file == null)
                    file = new AttachedFile();
                file.FileData = UsefulMethods.GetByteArrayFromFile(dialog.FileName);
                file.FileName = dialog.FileName.Substring(dialog.FileName.LastIndexOf('\\') + 1);
                UpdateInfo();
                if (FileChanged != null)
                {
                    FileChanged(file.FileName.Substring(0, file.FileName.LastIndexOf('.')));
                }

            }
        }

        #endregion

        #region private void linkLabelOpen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void linkLabelOpen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Thread thread = new Thread(OpenAttachmentData);
            thread.Start();
        }

        #endregion

        #region private void OpenAttachmentData()

        private void OpenAttachmentData()
        {
            if (SaveAttachmentData())
            {
                fileNameToRemove = TermsProvider.GetTempFolderPath() + "\\" + file.FileName;
                if (File.Exists(fileNameToRemove))
                {
                    Process tempProcess = new Process();
                    tempProcess.StartInfo.FileName = fileNameToRemove;
                    try
                    {
                        tempProcess.Start();
                        tempProcess.WaitForExit();
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while loading data", ex);
                    }
                    try
                    {
                        TryDeleteFile();
                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while deleting data", ex);
                    }
                }
            }
        }

        #endregion

        #region private bool SaveAttachmentData()

        private bool SaveAttachmentData()
        {
            try
            {
                string fileNameString = TermsProvider.GetTempFolderPath() + "\\" + file.FileName;
                FileStream fileStreamBack = new FileStream(fileNameString, FileMode.Create, FileAccess.Write);
                fileStreamBack.Write(file.FileData, 0, file.FileData.Length);
                fileStreamBack.Close();
                return true;
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex); 
                return false;
            }
        }

        #endregion

        #region private void TryDeleteFile()

        private void TryDeleteFile()
        {
            while (File.Exists(fileNameToRemove))
            {
                try
                {
                    File.Delete(fileNameToRemove);
                }
                catch
                {
                    Thread.Sleep(100);
                }
            }
            //Thread.CurrentThread.Abort();
        }

        #endregion

        #region private void linkLabelRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void linkLabelRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            file = null;
            UpdateInfo();
            if (FileChanged != null)
                FileChanged("");
        }

        #endregion

        #region private void labelDescription_SizeChanged(object sender, EventArgs e)

        private void labelDescription_SizeChanged(object sender, EventArgs e)
        {
            linkLabelBrowse.Location = 
                linkLabelOpen.Location = new Point(labelDescription.Left, labelDescription.Bottom);
            linkLabelRemove.Location = new Point(labelDescription.Left, linkLabelOpen.Bottom);
        }

        #endregion

        #region protected override void OnSizeChanged(EventArgs e)

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.SizeChanged"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            labelDescription.MinimumSize = new Size(Width - Css.WindowsForm.Constants.DefaultPictureBoxSize.Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN, 0);
            labelDescription.MaximumSize = new Size(Width - Css.WindowsForm.Constants.DefaultPictureBoxSize.Width - Css.WindowsForm.Constants.TAB_LEFT_MARGIN, 300);
            labelDescription_SizeChanged(this, e);
        }

        #endregion

        #endregion

        #region Delegates

        /// <summary>
        /// Обработчик события изменения файла
        /// </summary>
        /// <param name="fileName"></param>
        public delegate void FileChangedEventHandler(string fileName);

        #endregion

        #region Events

        /// <summary>
        /// Событие изменения файла
        /// </summary>
        public event FileChangedEventHandler FileChanged;

        #endregion

    }
}
