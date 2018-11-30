using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.Core.Types.Dictionaries;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Элемент управления для выбора ATA-глав
    /// </summary>
    public class ATAChapterComboBox : ComboBox
    {

        #region Fields

        private readonly ATAChapterCollection ataChapterCollection = ATAChapterCollection.Instance;
        private readonly Dictionary<string, ATAChapter> ataChapterDictionaries = new Dictionary<string, ATAChapter>();
        private readonly string defaultText = "Select ATA Chapter";
        private readonly string notApplicableText = "N/A NOT APPLICABLE";

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для выбора ATA-глав
        /// </summary>
        public ATAChapterComboBox()
        {
            List<string> ataChapters = new List<string>();
            ataChapterDictionaries.Clear();
            for (int i = 0; i < ataChapterCollection.Count; i++)
            {
                ataChapters.Add(ataChapterCollection[i].ShortName + " " + ataChapterCollection[i].FullName);
                ataChapterDictionaries.Add(ataChapters[i], ataChapterCollection[i]);
            }
            ataChapters.Sort();
            Items.AddRange(ataChapters.ToArray());
            Text = defaultText;
            DropDownStyle = ComboBoxStyle.DropDown;
            LostFocus += ATAChapterComboBox_LostFocus;
            GotFocus += ATAChapterComboBox_GotFocus;
        }

        #endregion

        #region Properties

        #region public ATAChapter ATAChapter

        /// <summary>
        /// Выбранная ATA-глава
        /// </summary>
        public ATAChapter ATAChapter
        {
            get
            {
                ATAChapter selectedChapter;
                ataChapterDictionaries.TryGetValue(Text, out selectedChapter);
                return selectedChapter;
            }
            set
            {
                if (value != null)
                {
                    SelectedItem = value.ShortName + " " + value.FullName;
                }
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void ATAChapterComboBox_LostFocus(object sender, EventArgs e)

        private void ATAChapterComboBox_LostFocus(object sender, EventArgs e)
        {
            if (Text == "")
                Text = notApplicableText;
            else
                for (int i = 0; i < ataChapterCollection.Count; i++)
                {
                    string ataChapter = Text;
                    int value;
                    if (Text.Length == 1 && int.TryParse(Text, out value))
                        ataChapter = "0" + Text;
                    if (ataChapterCollection[i].ShortName.ToLower() == ataChapter.ToLower())
                        Text = ataChapterCollection[i].ShortName + " " + ataChapterCollection[i].FullName;
                }
        }

        #endregion

        #region private void ATAChapterComboBox_GotFocus(object sender, EventArgs e)

        private void ATAChapterComboBox_GotFocus(object sender, EventArgs e)
        {
            if (Text == defaultText || Text == notApplicableText)
                Text = "";
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

        #endregion

    }
}
