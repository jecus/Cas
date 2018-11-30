using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CASTerms;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.OpepatorsControls
{
    ///<summary>
    /// ЭУ для редактирования информации об операторе
    ///</summary>
    public partial class OperatorControl : UserControl, IReference
    {
        #region Fields

        private Operator _currentOperator;

        private bool _logotypeChanged;
        private bool _logotypeWhiteChanged;
        private bool _logotypeReportLargeChanged;
        private bool _logotypeReportVeryLargeChanged;
        private const string TransparentFilter = "PNG (*.png)|*.png";
        private const string WhiteBackgroundFilter = "GIF (*.gif)|*.gif";

        #endregion

        #region IReference Members

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer { get; set; }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText { get; set; }

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity { get; set; }

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType { get; set; }

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

        #region Properties

        #region public Operator CurrentOperator
        ///<summary>
        /// получает или задает текущего оператора
        ///</summary>
        public Operator CurrentOperator
        {
            get { return _currentOperator; }
            set
            {
                _currentOperator = value;
                UpdateInformation();
            }
        }
        #endregion

        #region public string OperatorName

        /// <summary>
        /// Возвращает название эксплуатанта
        /// </summary>
        public string OperatorName
        {
            get
            {
                return _textBoxName.Text;
            }
        }

        #endregion

        #endregion

        #region Constructor

        #region private OperatorControl()
        /// <summary>
        /// Конструктор по умолчению
        /// </summary>
        private OperatorControl()
        {
            InitializeComponent();
        }
        #endregion

        #region public OperatorControl(Operator currentOperator) : this()
        /// <summary>
        /// Создает элемент управления для отображения информации о заданном эксплуатанте
        /// </summary>
        /// <param name="currentOperator">Заданный эксплуатант</param>
        public OperatorControl(Operator currentOperator) : this()
        {
            _currentOperator = currentOperator;
            UpdateInformation();
        }
        #endregion

        #endregion

        #region  void UpdateRemoveLbl(PictureBox pictureBox,Label lbl)
        /// <summary>
        /// Обновление лэйблов после удаления
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="lbl"></param>
        public void UpdateRemoveLbl(PictureBox pictureBox, Label lbl)
        {
            if (pictureBox.BackgroundImage == null || pictureBox.BackgroundImage.Size == new Size(1,1))
                lbl.Enabled = false;
            else
                lbl.Enabled = true;
        }

        #endregion

        #region public bool GetChangeStatus()

        /// <summary>
        /// Проверяет, вносились ли изменения в данные эксплуатанта
        /// </summary>
        /// <returns></returns>
        public bool GetChangeStatus()
        {
            return (_textBoxName.Text != _currentOperator.Name ||
                    _textBoxIcao.Text != _currentOperator.ICAOCode ||
                    _textBoxAddress.Text != _currentOperator.Address ||
                    _textBoxPhone.Text != _currentOperator.Phone ||
                    _textBoxFax.Text != _currentOperator.Fax ||
                    _textBoxEmail.Text != _currentOperator.Email ||
                    _logotypeChanged || _logotypeWhiteChanged || _logotypeReportLargeChanged || _logotypeReportVeryLargeChanged);
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Обновляет данные эксплуатанта
        /// </summary>
        public void UpdateInformation()
        {
            _textBoxName.Text = _currentOperator.Name;
            _textBoxIcao.Text = _currentOperator.ICAOCode;
            _textBoxAddress.Text = _currentOperator.Address;
            _textBoxPhone.Text = _currentOperator.Phone;
            _textBoxFax.Text = _currentOperator.Fax;
            _textBoxEmail.Text = _currentOperator.Email;
            _pictureBoxTransparentLogotype.BackgroundImage = _currentOperator.LogoTypeImage;
            _pictureBoxWhiteBackgroundLogotype.BackgroundImage = _currentOperator.LogoTypeWhiteImage;
            pictureBoxReportLogoLarge.BackgroundImage = _currentOperator.LogotypeReportLargeImage;
            pictureBoxReportLogoVeryLarge.BackgroundImage = _currentOperator.LogotypeReportVeryLargeImage;
            _logotypeChanged = false;
            _logotypeWhiteChanged = false;
            _logotypeReportLargeChanged = false;
            _logotypeReportVeryLargeChanged = false;

            UpdateRemoveLbl(_pictureBoxTransparentLogotype, _linkDeleteTransparentLogotype);
            UpdateRemoveLbl(_pictureBoxWhiteBackgroundLogotype, _linkDeleteWhiteBackgroundLogotype);
            UpdateRemoveLbl(pictureBoxReportLogoLarge, _linkDeleteChengeReportLogoLarge);
            UpdateRemoveLbl(pictureBoxReportLogoVeryLarge, _linkDeleteReportLogoVeryLarge);
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Сохраняет измененные данные эксплуатанта
        /// </summary>
        public void SaveData()
        {
            if (_textBoxName.Text != _currentOperator.Name)
                _currentOperator.Name = _textBoxName.Text;
            if (_textBoxIcao.Text != _currentOperator.ICAOCode)
                _currentOperator.ICAOCode = _textBoxIcao.Text;
            if (_textBoxAddress.Text != _currentOperator.Address)
                _currentOperator.Address = _textBoxAddress.Text;
            if (_textBoxPhone.Text != _currentOperator.Phone)
                _currentOperator.Phone = _textBoxPhone.Text;
            if (_textBoxFax.Text != _currentOperator.Fax)
                _currentOperator.Fax = _textBoxFax.Text;
            if (_textBoxEmail.Text != _currentOperator.Email)
                _currentOperator.Email = _textBoxEmail.Text;
            if (_logotypeChanged)
                _currentOperator.LogoTypeImage = _pictureBoxTransparentLogotype.BackgroundImage;
            if (_logotypeWhiteChanged)
                _currentOperator.LogoTypeWhiteImage = _pictureBoxWhiteBackgroundLogotype.BackgroundImage;
            if (_logotypeReportLargeChanged)
                _currentOperator.LogotypeReportLargeImage = pictureBoxReportLogoLarge.BackgroundImage;
            if (_logotypeReportVeryLargeChanged)
                _currentOperator.LogotypeReportVeryLargeImage = pictureBoxReportLogoVeryLarge.BackgroundImage;

            _logotypeChanged = false;
            _logotypeWhiteChanged = false;
            _logotypeReportLargeChanged = false;
            _logotypeReportVeryLargeChanged = false;
        }

        #endregion

        #region private void OpenFile(PictureBox pictureBox, ref bool changed, string filter)

        private void OpenFile(PictureBox pictureBox, ref bool changed, string filter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = filter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image logotype = Image.FromFile(dialog.FileName);
                Stream stream = dialog.OpenFile();
                long size = stream.Length;
                stream.Close();
                if (pictureBox != pictureBoxReportLogoLarge && pictureBox != pictureBoxReportLogoVeryLarge && 
                    (size > 200000 || logotype.Width > 500 || logotype.Height > 500))
                {
                    MessageBox.Show("Logotype shouldn't exceed 500x500 px and 200 Kb", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (pictureBox == pictureBoxReportLogoLarge && (size > 1048576 || logotype.Width > 2000 || logotype.Height > 500))
                {
                    MessageBox.Show("Logotype shouldn't exceed 2000x500 px and 1024 Kb", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (pictureBox == pictureBoxReportLogoVeryLarge && (size > 2097152 || logotype.Width > 5000 || logotype.Height > 1000))
                {
                    MessageBox.Show("Logotype shouldn't exceed 5000x1000 px and 2048 Kb", (string)new GlobalTermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                pictureBox.BackgroundImage = logotype;
                changed = true;
            }
        }

        #endregion

        #region private void RemoveFile(PictureBox pictureBox, ref bool changed)
        /// <summary>
        /// Изменения состояния для удаления картинки
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="changed"></param>
        private void RemovePicture(PictureBox pictureBox, ref bool changed)
        {
            pictureBox.BackgroundImage = null;
            changed = true;
        }

        #endregion

        #region private void PictureBoxLogotypeClick(object sender, EventArgs e)

        private void PictureBoxLogotypeClick(object sender, EventArgs e)
        {
            if (sender == _pictureBoxTransparentLogotype)
            {
                OpenFile(_pictureBoxTransparentLogotype, ref _logotypeChanged, TransparentFilter);
                UpdateRemoveLbl(_pictureBoxTransparentLogotype, _linkDeleteTransparentLogotype);
            } 
            else if (sender == _pictureBoxWhiteBackgroundLogotype)
            {
                OpenFile(_pictureBoxWhiteBackgroundLogotype, ref _logotypeWhiteChanged, WhiteBackgroundFilter);
                UpdateRemoveLbl(_pictureBoxWhiteBackgroundLogotype, _linkDeleteWhiteBackgroundLogotype);
            }
            else if (sender == pictureBoxReportLogoLarge)
            {
                OpenFile(pictureBoxReportLogoLarge, ref _logotypeReportLargeChanged, WhiteBackgroundFilter);
                UpdateRemoveLbl(pictureBoxReportLogoLarge, _linkDeleteChengeReportLogoLarge);
            }
            else
            {
                OpenFile(pictureBoxReportLogoVeryLarge, ref _logotypeReportVeryLargeChanged, WhiteBackgroundFilter);
                UpdateRemoveLbl(pictureBoxReportLogoVeryLarge, _linkDeleteReportLogoVeryLarge);
            }

        }

        #endregion

        #region private void LinkLogotypeLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

        private void LinkLogotypeLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sender == _linkChangeTransparentLogotype)
            {
                OpenFile(_pictureBoxTransparentLogotype, ref _logotypeChanged, TransparentFilter);
                UpdateRemoveLbl(_pictureBoxTransparentLogotype, _linkDeleteTransparentLogotype);
            }
            else if (sender == _linkChangeWhiteBackgroundLogotype)
            {
                OpenFile(_pictureBoxWhiteBackgroundLogotype, ref _logotypeWhiteChanged, WhiteBackgroundFilter);
                UpdateRemoveLbl(_pictureBoxWhiteBackgroundLogotype, _linkDeleteWhiteBackgroundLogotype);
            } 
            else if (sender == linkLabelChengeReportLogoLarge)
            {
                OpenFile(pictureBoxReportLogoLarge, ref _logotypeReportLargeChanged, WhiteBackgroundFilter);
                UpdateRemoveLbl(pictureBoxReportLogoLarge, _linkDeleteChengeReportLogoLarge);
            }

            else
            {
                OpenFile(pictureBoxReportLogoVeryLarge, ref _logotypeReportVeryLargeChanged, WhiteBackgroundFilter);
                UpdateRemoveLbl(pictureBoxReportLogoVeryLarge, _linkDeleteReportLogoVeryLarge);
            }
                
        }

        #endregion

        #region private void RemoveLogotypeLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //Событие remove
        private void RemoveLogotypeLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sender == _linkDeleteTransparentLogotype)
            {
                RemovePicture(_pictureBoxTransparentLogotype, ref _logotypeChanged);
                UpdateRemoveLbl(_pictureBoxTransparentLogotype, _linkDeleteTransparentLogotype);
            }
            else if (sender == _linkDeleteWhiteBackgroundLogotype)
            {
                RemovePicture(_pictureBoxWhiteBackgroundLogotype, ref _logotypeWhiteChanged);
                UpdateRemoveLbl(_pictureBoxWhiteBackgroundLogotype, _linkDeleteWhiteBackgroundLogotype);
            }
            else if (sender == _linkDeleteChengeReportLogoLarge)
            {
                RemovePicture(pictureBoxReportLogoLarge, ref _logotypeReportLargeChanged);
                UpdateRemoveLbl(pictureBoxReportLogoLarge, _linkDeleteChengeReportLogoLarge);
            }
            else
            {
                RemovePicture(pictureBoxReportLogoVeryLarge, ref _logotypeReportVeryLargeChanged);
                UpdateRemoveLbl(pictureBoxReportLogoVeryLarge, _linkDeleteReportLogoVeryLarge);
            }

        }

        #endregion
    }

}
