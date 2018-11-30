using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Auxiliary;
using CASTerms;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Элемент управления для отображения информации о прикрепленном файле в формах редактирования чего-либо
    /// </summary>
    [Designer(typeof(AttachedFileControlDesigner))]
    public partial class AttachedFileControl : UserControl
    {

        #region Fields

        private AttachedFile _file;

        private string _filePath;
        private string _fileName;
        private int? _fileSize;
        private byte[] _fileData;

        private string _fileNameToRemove;
        private string _filter;
        private string _description1;
        private string _description2;
        private Image _icon;
        private Image _iconNotEnabled;

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
                return _file;
            }
            set
            {
                _file = value;

                if(_file == null)
                {
                    _fileName = "";
                    _fileData = null;
                    _filePath = "";
                    _fileSize = null;    
                }
                else
                {
                    _fileName = _file.FileName;
                    _fileData = _file.FileData;
                    _fileSize = _file.FileData != null ? _file.FileData.Length : _file.FileSize;
                }

                UpdateInfo();
            }
        }
        #endregion

        #region public string Description1
        /// <summary>
        /// Описание 1
        /// </summary>
        public string Description1
        {
            get { return _description1; }
            set { _description1 = value; UpdateInfo(); }
        }
        #endregion

        #region public string Description2
        /// <summary>
        /// Описание 2
        /// </summary>
        public string Description2
        {
            get { return _description2; }
            set { _description2 = value; UpdateInfo(); }
        }
        #endregion

        #region public string Filter
        /// <summary>
        /// Фильтр в OpenFileDialog
        /// </summary>
        public string Filter
        {
            get { return _filter; }
            set { _filter = value; }
        }
        #endregion

        #region public bool ShowLinkLabelBrowse
        ///<summary>
        /// отображать ссылку поиска файла для прикрепления
        ///</summary>
        public bool ShowLinkLabelBrowse
        {
            get { return linkLabelBrowse.Visible; }
            set { linkLabelBrowse.Visible = value; }
        }
        #endregion

        #region public bool ShowLinkLabelRemove
        ///<summary>
        /// отображать ссылку удаления прикрепленного файла
        ///</summary>
        public bool ShowLinkLabelRemove
        {
            get { return linkLabelRemove.Visible; }
            set { linkLabelRemove.Visible = value; }
        }
        #endregion

        #region public Image Icon

        ///<summary>
        ///</summary>
        public Image Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                SetIcon();
            }
        }

        #endregion

        #region public Image IconNotEnabled
        ///<summary>
        /// Задает иконку при Enabled = false
        ///</summary>
        [Description("Иконка при Enabled = false"), Category("Appearance")]
        public Image IconNotEnabled
        {
            get { return _iconNotEnabled; }
            set
            {
                _iconNotEnabled = value;
                SetIcon();
            }
        }
        #endregion

        #endregion

        #region public AttachedFileControl()
        ///<summary>
        /// Конструктор по умолчанию
        ///</summary>
        public AttachedFileControl()
        {
            InitializeComponent();
        }
        #endregion

        #region private void SetIcon()

        private void SetIcon()
        {
            if (Enabled)
            {
                pictureBox.BackgroundImage = _icon;
            }
            else if (_icon != null)
            {
                pictureBox.BackgroundImage = _iconNotEnabled ?? _icon;
            }
        }
        #endregion

        #region private void UpdateInfo()
        /// <summary>
        /// Обновляет информацию
        /// </summary>
        private void UpdateInfo()
        {
            if (string.IsNullOrEmpty(_fileName) && 
                ((_fileData == null && (_fileSize == null ||_fileSize <= 0)) || 
                string.IsNullOrEmpty(_filePath)))
            {
                labelDescription.Text = _description1;
                linkLabelBrowse.Text = "Browse";
                linkLabelRemove.Visible = false;
            }
            else
            {
                labelDescription.Text =
                    _description2 + Environment.NewLine + "File name: " + _fileName +
                                    Environment.NewLine + "Size: " + (_fileData != null
                                    ? _fileData.Length / 1024
                                    : _fileSize != null
                                        ? _fileSize / 1024
                                        : 0) + " KB"; 
                linkLabelBrowse.Text = "Open";
                linkLabelRemove.Visible = true;
            }
        }

        #endregion

        #region public void UpdateInfo(AttachedFile file, string fil, string desc1, string desc2)
        /// <summary>
        /// Обновляет информацию
        /// </summary>
        public void UpdateInfo(AttachedFile file, string fil, string desc1, string desc2)
        {
            _file = file;
            _filter = fil;
            _description1 = desc1;
            _description2 = desc2;

            if (_file == null)
            {
                _fileName = "";
                _fileData = null;
                _filePath = "";
                _fileSize = null;
            }
            else
            {
                _fileName = _file.FileName;
                _fileData = _file.FileData;
                _fileSize = _file.FileData != null ? _file.FileData.Length : _file.FileSize;
            }

            UpdateInfo();
        }

        #endregion

        #region public bool GetChangeStatus()
        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            if (_file == null)
            {
                if (_fileName != "" && (_fileData != null || _filePath != null))
                    return true;
                return false;
            }

            if (_file.FileName != _fileName ||
                _file.FileData != _fileData ||
                _file.FileSize != _fileSize)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region public bool ValidateData(out string message)
        /// <summary>
        /// Возвращает значение, показывающее является ли значение элемента управления допустимым
        /// </summary>
        /// <returns></returns>
        public bool ValidateData(out string message)
        {
            message = "";
            return true;
        }

        #endregion

        #region public void ApplyChanges()
        /// <summary>
        /// Применить к объекту сделанные изменения на контроле. 
        /// Если не все данные удовлетворяют формату ввода (например при вводе чисел), свойства объекта не изменяются, возвращается false
        /// Вызов base.ApplyChanges() обязателен
        /// </summary>
        /// <returns></returns>
        public void ApplyChanges()
        {
            if(_file == null)
                _file = new AttachedFile();
            
            _file.FileData = null;

            _file.FileName = _fileName;
            _file.FileData = _fileData;
            _file.FileSize = _fileSize;  
        }
        #endregion

        #region public void Save()
        ///<summary>
        /// Сохраняет измненения в Базу данных
        ///</summary>
        public void Save()
        {
            try
            {
                if(_file == null)return;
                if(_file.ItemId > 0 && _file.IsDeleted)
                    GlobalObjects.CasEnvironment.NewKeeper.Delete(_file);
                else GlobalObjects.CasEnvironment.NewKeeper.Save(_file);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save attached file", ex);
            }
        }
        #endregion

        #region private void LinkLabelBrowseLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void LinkLabelBrowseLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrEmpty(_fileName) && 
                ((_fileData == null && (_fileSize == null || _fileSize <= 0)) || 
                string.IsNullOrEmpty(_filePath)))
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = _filter;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (_file != null) 
                        _file.IsDeleted = false;
                    _fileData = UsefulMethods.GetByteArrayFromFile(dialog.FileName);
                    _fileName = string.IsNullOrEmpty(dialog.SafeFileName) ? "" : dialog.SafeFileName;
                    _filePath = dialog.FileName;
                    _fileSize = _fileData.Length;
                    UpdateInfo();
                    if (FileChanged != null)
                    {
                        FileChanged(_fileName.Substring(0, _fileName.LastIndexOf('.')));
                    }
                }
            }
            else
            {
                progressBarLoad.Value = 0;
                progressBarLoad.Visible = true;
                backgroundWorker.RunWorkerAsync();
            }
        }

        #endregion

        #region private bool SaveAttachmentData()

        private bool SaveAttachmentData()
        {
            if (_file == null || _fileData == null)
                return false;
            try
            {
                string fileNameString = Path.GetTempPath() + _fileName;
                FileStream fileStreamBack = new FileStream(fileNameString, FileMode.Create, FileAccess.Write);
                fileStreamBack.Write(_fileData, 0, _fileSize ?? _fileData.Length);
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
            while (File.Exists(_fileNameToRemove))
            {
                try
                {
                    File.Delete(_fileNameToRemove);
                }
                catch
                {
                    Thread.Sleep(100);
                }
            }
            //Thread.CurrentThread.Abort();
        }

        #endregion

        #region private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            if(_file == null || _file.ItemId <= 0 || _fileData != null)
                return;

            backgroundWorker.ReportProgress(50);
            
            try
            {
	            _file = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<EFCore.DTO.General.AttachedFileDTO, AttachedFile>(_file.ItemId, true);
			}
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while set Attached File Fields", ex);
            }
            
            backgroundWorker.ReportProgress(100);
        }
        #endregion

        #region  private void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)

        private void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarLoad.Value = e.ProgressPercentage;
        }
        #endregion

        #region private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

        private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarLoad.Visible = false;
            progressBarLoad.Value = 0;

            string message;
            if(_file != null)
            {
                _fileName = _file.FileName;
                _fileData = _file.FileData;
                _fileSize = _file.FileData != null ? _file.FileData.Length : _file.FileSize;

                GlobalObjects.CasEnvironment.OpenFile(_file, out message);
            }
            else
            {
                AttachedFile temp = new AttachedFile();

                temp.FileName = _fileName;
                temp.FileData = _fileData;
                temp.FileSize = _fileSize;

                GlobalObjects.CasEnvironment.OpenFile(temp, out message);
            }
            if (message != "")
            {
                MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1);
                return;
            }
        }
        #endregion

        #region private void AvButtonTEnabledChanged(object sender, EventArgs e)
        private void AvButtonTEnabledChanged(object sender, EventArgs e)
        {
            linkLabelBrowse.Enabled = Enabled;
            linkLabelRemove.Enabled = Enabled;

            SetIcon();
        }
        #endregion

        #region private void LinkLabelRemoveLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void LinkLabelRemoveLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_file != null)
                _file.IsDeleted = true;

            _fileName = "";
            _filePath = "";
            _fileData = null;
            _fileSize = null;

            UpdateInfo();
            if (FileChanged != null)
                FileChanged("");
        }

        #endregion

        #region  private void ControlMouseHover(object sender, EventArgs e)

        private void ControlMouseHover(object sender, EventArgs e)
        {
            Control c = sender as Control;

            if(c == null)
                return;

            string toolTipText = "";
            if (sender == linkLabelBrowse)
            {
                if(string.IsNullOrEmpty(_fileName))
                    toolTipText = "Browse file...";
                else toolTipText = "Open file";
            }
            else if (sender == linkLabelRemove)
                toolTipText = "Remove link on this file";

            if(toolTipText.Trim() == "")
                return;
            
            Graphics graphics = CreateGraphics();
            SizeF ef = graphics.MeasureString(toolTipText, new Font("Tahoma", 8.25f, FontStyle.Regular));
            graphics.Dispose();
            int num = ((int)(ef.Width / 2f));
            toolTip.Show(toolTipText, c, num, c.Height - 5, 5000);
        }
        #endregion

        #region private void ControlMouseLeave(object sender, EventArgs e)

        private void ControlMouseLeave(object sender, EventArgs e)
        {
            if (toolTip.Active)
            {
                toolTip.Hide(this);
            }
        }
        #endregion

        #region private void PictureBoxPdfSizeChanged(object sender, EventArgs e)
        private void PictureBoxPdfSizeChanged(object sender, EventArgs e)
        {
            pictureBox.SizeChanged -= PictureBoxPdfSizeChanged;

            if (pictureBox.Width < 40)
                pictureBox.Width = 40;
            if (pictureBox.Height < 34)
                pictureBox.Height = 34;

            flowLayoutPanelMain.Location = new Point(pictureBox.Location.X + pictureBox.Width + 3, 0);

            pictureBox.SizeChanged += PictureBoxPdfSizeChanged;
        }
        #endregion

        #region private void FlowLayoutPanelMainSizeChanged(object sender, EventArgs e)
        private void FlowLayoutPanelMainSizeChanged(object sender, EventArgs e)
        {
            int height;
            if (linkLabelRemove.Visible)
                height = linkLabelRemove.Location.Y + linkLabelRemove.Height;
            else height = linkLabelBrowse.Location.Y + linkLabelBrowse.Height;

            if (pictureBox.Height < height)
                Height = flowLayoutPanelMain.Height = height;
            else Height = flowLayoutPanelMain.Height = pictureBox.Height;
        }
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

    #region internal class AttachedFileControlDesigner : ControlDesigner

    internal class AttachedFileControlDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("AttachedFile");
        }

        public override SelectionRules SelectionRules
        {
            get { return base.SelectionRules & ~( SelectionRules.BottomSizeable | SelectionRules.TopSizeable); }
        }
    }
    #endregion
}
