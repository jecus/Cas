using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.CAA;
using SmartCore.CAA.Operators;

namespace CAS.UI.UICAAControls.Operators
{
    public partial class AddOperatorFrom :  MetroForm
    {
        private  AllOperators _currentOperator;
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
        
        public AddOperatorFrom(AllOperators currentOperator) : this()
        {
            _currentOperator = currentOperator;
            UpdateControls();
            _animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
            _animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
            _animatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
        {
            if (_currentOperator == null) return;

            if (_currentOperator.ItemId > 0)
                _currentOperator = GlobalObjects.CaaEnvironment.NewLoader.GetObjectById<AllOperatorsDTO, AllOperators>(_currentOperator.ItemId);
        }

        private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateInformation();
        }

        private void UpdateInformation()
        {
            textBoxFullName.Text = _currentOperator.FullName;
            metroTextBoxShortName.Text = _currentOperator.ShortName;
            metroTextBoxAddress.Text = _currentOperator.Address;
            metroTextBoxIcao.Text = _currentOperator.ICAOCode;
            metroTextBoxPhone.Text = _currentOperator.Phone;
            metroTextBoxFax.Text = _currentOperator.Fax;
            metroTextBoxWeb.Text = _currentOperator.Web;
            metroTextBoxEmail.Text = _currentOperator.Email;

            for (int i = 0; i < checkedListBoxTypeOfOper.Items.Count; i++)
            {
                if (_currentOperator.TypeOperation != null && _currentOperator.TypeOperation.Contains(checkedListBoxTypeOfOper.Items[i].ToString()))
                    checkedListBoxTypeOfOper.SetItemChecked(i, true);
            }
            for (int i = 0; i < checkedListBoxFleet.Items.Count; i++)
            {
                if (_currentOperator.Fleet != null && _currentOperator.Fleet.Contains(checkedListBoxFleet.Items[i].ToString()))
                    checkedListBoxFleet.SetItemChecked(i, true);
            }
            for (int i = 0; i < checkedListBoxAemcPrivilages.Items.Count; i++)
            {
                if (_currentOperator.AemcPrivilages != null && _currentOperator.AemcPrivilages.Contains(checkedListBoxAemcPrivilages.Items[i].ToString()))
                    checkedListBoxAemcPrivilages.SetItemChecked(i, true);
            }
            for (int i = 0; i < checkedListBoxTraningOrgPrivilages.Items.Count; i++)
            {
                if (_currentOperator.TraningOrgPrivilages != null && _currentOperator.TraningOrgPrivilages.Contains(checkedListBoxTraningOrgPrivilages.Items[i].ToString()))
                    checkedListBoxTraningOrgPrivilages.SetItemChecked(i, true);
            }
            for (int i = 0; i < checkedListBoxRatings.Items.Count; i++)
            {
                if (_currentOperator.Ratings != null && _currentOperator.Ratings.Contains(checkedListBoxRatings.Items[i].ToString()))
                    checkedListBoxRatings.SetItemChecked(i, true);
            }
            for (int i = 0; i < checkedListBoxSpecialOp.Items.Count; i++)
            {
                if (_currentOperator.SpecialOperation != null && _currentOperator.SpecialOperation.Contains(checkedListBoxSpecialOp.Items[i].ToString()))
                    checkedListBoxSpecialOp.SetItemChecked(i, true);
            }

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

            checkBoxATC.Checked = _currentOperator.IsATC;
            checkBoxFuel.Checked = _currentOperator.IsFuel;
            checkBoxTraningOrg.Checked = _currentOperator.IsTraningOperation;
            checkBoxAmo.Checked = _currentOperator.IsAMO;
            checkBoxAemc.Checked = _currentOperator.IsAEMS;
            checkBoxAirdromeOp.Checked = _currentOperator.IsAerodromOperator;
            if (_currentOperator.IsCommertial)
                radioButtonComertial.Checked = true;
            else radioButtonNotCommertial.Checked = true;
        }


        private void ApplyChanges()
        {
            _currentOperator.FullName = textBoxFullName.Text;
            _currentOperator.ShortName = metroTextBoxShortName.Text;
            _currentOperator.Address = metroTextBoxAddress.Text;
            _currentOperator.ICAOCode = metroTextBoxIcao.Text;
            _currentOperator.Phone = metroTextBoxPhone.Text;
            _currentOperator.Fax = metroTextBoxFax.Text;
            _currentOperator.Web = metroTextBoxWeb.Text;
            _currentOperator.Email = metroTextBoxEmail.Text;

            _currentOperator.IsATC = checkBoxATC.Checked;
            _currentOperator.IsFuel = checkBoxFuel.Checked;
            _currentOperator.IsTraningOperation = checkBoxTraningOrg.Checked;
            _currentOperator.IsAMO = checkBoxAmo.Checked;
            _currentOperator.IsAEMS = checkBoxAemc.Checked;
            _currentOperator.IsAerodromOperator = checkBoxAirdromeOp.Checked;

            foreach (var item in checkedListBoxTypeOfOper.CheckedItems)
                _currentOperator.TypeOperation += $"{item} ";
            foreach (var item in checkedListBoxFleet.CheckedItems)
                _currentOperator.Fleet += $"{item} ";
            foreach (var item in checkedListBoxAemcPrivilages.CheckedItems)
                _currentOperator.AemcPrivilages += $"{item} ";
            foreach (var item in checkedListBoxTraningOrgPrivilages.CheckedItems)
                _currentOperator.TraningOrgPrivilages += $"{item} ";
            foreach (var item in checkedListBoxRatings.CheckedItems)
                _currentOperator.Ratings += $"{item} ";
            foreach (var item in checkedListBoxSpecialOp.CheckedItems)
                _currentOperator.SpecialOperation += $"{item} ";


            if (_logotypeChanged)
                _currentOperator.LogoTypeImage = _pictureBoxTransparentLogotype.BackgroundImage;
            if (_logotypeWhiteChanged)
                _currentOperator.LogoTypeWhiteImage = _pictureBoxWhiteBackgroundLogotype.BackgroundImage;
            if (_logotypeReportLargeChanged)
                _currentOperator.LogotypeReportLargeImage = pictureBoxReportLogoLarge.BackgroundImage;
            if (_logotypeReportVeryLargeChanged)
                _currentOperator.LogotypeReportVeryLargeImage = pictureBoxReportLogoVeryLarge.BackgroundImage;
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
            checkedListBoxSpecialOp.Items.Clear();
            checkedListBoxSpecialOp.Items.AddRange(SpecialOperations.Items.ToArray());


            checkedListBoxAemcPrivilages.Enabled = checkBoxAemc.Checked;
            checkedListBoxRatings.Enabled = checkBoxAmo.Checked;
            checkedListBoxTraningOrgPrivilages.Enabled = checkBoxTraningOrg.Checked;
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

        #region private void buttonOk_Click(object sender, EventArgs e)

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                ApplyChanges();

                GlobalObjects.CaaEnvironment.NewKeeper.Save(_currentOperator, true, isCaa:true);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save document", ex);
            }
        }

        #endregion

        #region private void buttonCancel_Click(object sender, EventArgs e)

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

    }
}
