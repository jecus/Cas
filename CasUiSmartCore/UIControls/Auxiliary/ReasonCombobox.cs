using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Элемент управления для выбора Причины сбоя чего-либо
    /// </summary>
    [Designer(typeof(ReasonComboboxDesigner))]
    public partial class ReasonComboBox : UserControl
    {
        #region Fields

        private ReasonCollection _reasonsCollection;
        private Dictionary<string, Reason> _reasonDictionary;
        private string defaultText = "Select Reason";
        private string notApplicableText = "N/A NOT APPLICABLE";
        private int _lastSelectedItemId = -1;
        private string _reasonCategory;
        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для выбора ATA-глав
        /// </summary>
        public ReasonComboBox()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        #region public string ReasonCategory { get; set; }

        ///<summary>
        ///</summary>
        public string ReasonCategory
        {
            get { return _reasonCategory; }
            set { _reasonCategory = value; UpdateInformation(); }
        }
        #endregion

        #region public ShutDownReason SelectedReason

        /// <summary>
        /// Выбранная причина
        /// </summary>
        public Reason SelectedReason
        {
            get
            {
                if (comboBoxReason != null && comboBoxReason.SelectedItem != null 
                    && comboBoxReason.SelectedItem.ToString() != "N/A") 
                    return (Reason)comboBoxReason.SelectedItem;
                return null;
            }
            set
            {
                if (comboBoxReason != null) comboBoxReason.SelectedItem = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void ATAChapterComboBoxLostFocus(object sender, EventArgs e)

        private void ATAChapterComboBoxLostFocus(object sender, EventArgs e)
        {
            if (comboBoxReason.Text == "")
                comboBoxReason.Text = notApplicableText;
            else
                for (int i = 0; i < _reasonsCollection.Count; i++)
                {
                    string ataChapter = comboBoxReason.Text;
                    int value;
                    if (comboBoxReason.Text.Length == 1 && int.TryParse(comboBoxReason.Text, out value))
                        ataChapter = "0" + comboBoxReason.Text;
                    if (_reasonsCollection[i].FullName.ToLower() == ataChapter.ToLower())
                        Text = _reasonsCollection[i].FullName;
                }
        }

        #endregion

        #region private void ATAChapterComboBoxGotFocus(object sender, EventArgs e)

        private void ATAChapterComboBoxGotFocus(object sender, EventArgs e)
        {
            if (comboBoxReason.Text == defaultText || comboBoxReason.Text == notApplicableText)
                comboBoxReason.Text = "";
        }

        #endregion

        #region private void comboBoxReason_SelectedIndexChanged(object sender, EventArgs e)
        private void ComboBoxReasonSelectedIndexChanged(object sender, EventArgs e)
        {
            _lastSelectedItemId = 
                comboBoxReason.SelectedItem != null && comboBoxReason.SelectedItem.ToString() != "N/A" 
                ? ((Reason)comboBoxReason.SelectedItem).ItemId : -1;
        }
        #endregion

        #region private void ReasonsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)

        private void ReasonsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateInformation();
        }
        #endregion

        #region public void ClearValue()

        /// <summary>
        /// Обнуляет выбранную ATA-главу и ставит текст "Select ATA Chapter"
        /// </summary>
        public void ClearValue()
        {
            Text = defaultText;
        }

        #endregion

        #region private void ButtonEditClick(object sender, EventArgs e)
        private void ButtonEditClick(object sender, EventArgs e)
        {
            if (comboBoxReason.SelectedItem != null)
                _lastSelectedItemId = ((Reason) comboBoxReason.SelectedItem).ItemId;

            ReasonAddingForm form = new ReasonAddingForm(_reasonCategory);
            form.ShowDialog();
        }
        #endregion

        #region void UpdateInformation()
        ///<summary>
        /// Обновление информации в выпадающем списке
        ///</summary>
        public void UpdateInformation()
        {
            _reasonsCollection = !string.IsNullOrEmpty(_reasonCategory)
                ? new ReasonCollection(GlobalObjects.CasEnvironment.Reasons.GetItemsByCategory(_reasonCategory)) 
                : GlobalObjects.CasEnvironment.Reasons;
            _reasonDictionary = new Dictionary<string, Reason>();
            List<string> reasons = new List<string>();

            _reasonDictionary.Clear();
            for (int i = 0; i < _reasonsCollection.Count; i++)
            {
                reasons.Add(_reasonsCollection[i].FullName);
                _reasonDictionary.Add(reasons[i], _reasonsCollection[i]);
            }

            reasons.Sort();

            comboBoxReason.Items.Clear();
            comboBoxReason.Items.Add("N/A");
            comboBoxReason.Items.AddRange(_reasonsCollection.OrderBy(r => r.FullName).ToArray());


            if (_lastSelectedItemId > 0)
                comboBoxReason.SelectedItem =
                    _reasonsCollection.Where(r => r.ItemId == _lastSelectedItemId).FirstOrDefault();
            else comboBoxReason.Text = defaultText;
            comboBoxReason.DropDownStyle = ComboBoxStyle.DropDown;

            LostFocus += ATAChapterComboBoxLostFocus;
            GotFocus += ATAChapterComboBoxGotFocus;
            GlobalObjects.CasEnvironment.Reasons.CollectionChanged += ReasonsCollectionChanged;
        }
        #endregion
      
        #endregion
    }
}
