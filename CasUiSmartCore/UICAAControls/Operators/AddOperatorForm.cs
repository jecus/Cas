using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.CAA;
using SmartCore.CAA.Operators;
using SmartCore.Entities.General;

namespace CAS.UI.UICAAControls.Operators
{
    public partial class AddOperatorFrom :  MetroForm
    {
        private readonly CaaOpearatorDto _operatoDto;
        private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
        private bool _logotypeChanged;
        private bool _logotypeWhiteChanged;
        private bool _logotypeReportLargeChanged;
        private bool _logotypeReportVeryLargeChanged;
        private const string TransparentFilter = "PNG (*.png)|*.png";
        private const string WhiteBackgroundFilter = "GIF (*.gif)|*.gif";

        #region Constructors
        public AddOperatorFrom()
        {
            InitializeComponent();
        }
        
        public AddOperatorFrom(CaaOpearatorDto operatoDto) : this()
        {
            _operatoDto = operatoDto;
            UpdateControls();
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
        }
        #endregion

        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            if (_operatoDto == null) return;
        }

        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateInformation();
        }

        private void UpdateInformation()
        {
            textBoxFullName.Text = _operatoDto.FullName;
            metroTextBoxShortName.Text = _operatoDto.ShortName;
            metroTextBoxAddress.Text = _operatoDto.Address;
            metroTextBoxIcao.Text = _operatoDto.ICAOCode;
            metroTextBoxPhone.Text = _operatoDto.Phone;
            metroTextBoxFax.Text = _operatoDto.Fax;
            metroTextBoxWeb.Text = _operatoDto.Web;
            metroTextBoxEmail.Text = _operatoDto.Email;

            for (int i = 0; i < checkedListBoxTypeOfOper.Items.Count; i++)
            {
                if (_operatoDto.TypeOperation != null && _operatoDto.TypeOperation.Contains(checkedListBoxTypeOfOper.Items[i].ToString()))
                    checkedListBoxTypeOfOper.SetItemChecked(i, true);
            }
            for (int i = 0; i < checkedListBoxFleet.Items.Count; i++)
            {
                if (_operatoDto.Fleet != null && _operatoDto.Fleet.Contains(checkedListBoxFleet.Items[i].ToString()))
                    checkedListBoxFleet.SetItemChecked(i, true);
            }
            for (int i = 0; i < checkedListBoxAemcPrivilages.Items.Count; i++)
            {
                if (_operatoDto.AemcPrivilages != null && _operatoDto.AemcPrivilages.Contains(checkedListBoxAemcPrivilages.Items[i].ToString()))
                    checkedListBoxAemcPrivilages.SetItemChecked(i, true);
            }
            for (int i = 0; i < checkedListBoxTraningOrgPrivilages.Items.Count; i++)
            {
                if (_operatoDto.TraningOrgPrivilages != null && _operatoDto.TraningOrgPrivilages.Contains(checkedListBoxTraningOrgPrivilages.Items[i].ToString()))
                    checkedListBoxTraningOrgPrivilages.SetItemChecked(i, true);
            }
            for (int i = 0; i < checkedListBoxRatings.Items.Count; i++)
            {
                if (_operatoDto.Ratings != null && _operatoDto.Ratings.Contains(checkedListBoxRatings.Items[i].ToString()))
                    checkedListBoxRatings.SetItemChecked(i, true);
            }

            _pictureBoxTransparentLogotype.BackgroundImage = _operatoDto.LogoTypeImage;
            _pictureBoxWhiteBackgroundLogotype.BackgroundImage = _operatoDto.LogoTypeWhiteImage;
            pictureBoxReportLogoLarge.BackgroundImage = _operatoDto.LogotypeReportLargeImage;
            pictureBoxReportLogoVeryLarge.BackgroundImage = _operatoDto.LogotypeReportVeryLargeImage;
            _logotypeChanged = false;
            _logotypeWhiteChanged = false;
            _logotypeReportLargeChanged = false;
            _logotypeReportVeryLargeChanged = false;

            UpdateRemoveLbl(_pictureBoxTransparentLogotype, _linkDeleteTransparentLogotype);
            UpdateRemoveLbl(_pictureBoxWhiteBackgroundLogotype, _linkDeleteWhiteBackgroundLogotype);
            UpdateRemoveLbl(pictureBoxReportLogoLarge, _linkDeleteChengeReportLogoLarge);
            UpdateRemoveLbl(pictureBoxReportLogoVeryLarge, _linkDeleteReportLogoVeryLarge);
        }

        
        private void UpdateControls()
        {
            checkedListBoxTypeOfOper.Items.Clear();
            checkedListBoxTypeOfOper.Items.AddRange(TypesOfOperations.Items.ToArray());
            checkedListBoxFleet.Items.Clear();
            checkedListBoxFleet.Items.AddRange(Fleet.Items.ToArray());
            checkedListBoxAemcPrivilages.Items.Clear();
            checkedListBoxAemcPrivilages.Items.AddRange(Privileges.Items.ToArray());
            checkedListBoxTraningOrgPrivilages.Items.Clear();
            checkedListBoxTraningOrgPrivilages.Items.AddRange(Privileges.Items.ToArray());
            checkedListBoxRatings.Items.Clear();
            checkedListBoxRatings.Items.AddRange(Ratings.Items.ToArray());
        }

        private void checkBoxAemc_CheckedChanged(object sender, System.EventArgs e)
        {
            checkedListBoxAemcPrivilages.Enabled = checkBoxAemc.Checked;
        }

        private void checkBoxAmo_CheckedChanged(object sender, System.EventArgs e)
        {
            checkedListBoxRatings.Enabled = checkBoxAmo.Checked;
        }

        private void checkBoxTraningOrg_CheckedChanged(object sender, System.EventArgs e)
        {
            checkedListBoxTraningOrgPrivilages.Enabled = checkBoxTraningOrg.Checked;
        }


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

        #region  void UpdateRemoveLbl(PictureBox pictureBox,Label lbl)
        /// <summary>
        /// Обновление лэйблов после удаления
        /// </summary>
        /// <param name="pictureBox"></param>
        /// <param name="lbl"></param>
        public void UpdateRemoveLbl(PictureBox pictureBox, Label lbl)
        {
            if (pictureBox.BackgroundImage == null || pictureBox.BackgroundImage.Size == new Size(1, 1))
                lbl.Enabled = false;
            else
                lbl.Enabled = true;
        }

        #endregion

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                ApplyChanges();

                GlobalObjects.CaaEnvironment.NewKeeper.Save(_operatoDto, true);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save document", ex);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
