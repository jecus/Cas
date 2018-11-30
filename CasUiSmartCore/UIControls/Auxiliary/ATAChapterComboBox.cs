using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Элемент управления для выбора ATA-глав
    /// </summary>
    [Designer(typeof(AtaChapterComboboxDesigner))]
    public class ATAChapterComboBox : ComboBox
    {

        #region Fields

        private AtaChapterCollection _ataChapterCollection = new AtaChapterCollection();
        private Dictionary<string, AtaChapter> _ataChapterDictionaries;
        private string defaultText = "Select ATA Chapter";
        private string notApplicableText = "N/A NOT APPLICABLE";

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для выбора ATA-глав
        /// </summary>
        public ATAChapterComboBox()
        {
        }

        #endregion

        #region Properties

        #region public ATAChapter ATAChapter

        /// <summary>
        /// Выбранная ATA-глава
        /// </summary>
        public AtaChapter ATAChapter
        {
            get
            {
                AtaChapter selectedChapter;
                _ataChapterDictionaries.TryGetValue(Text, out selectedChapter);
                if (selectedChapter == null)
                    selectedChapter = _ataChapterCollection.GetItemById(-1);
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

        private void ATAChapterComboBoxLostFocus(object sender, EventArgs e)
        {
            if (Text == "")
                Text = notApplicableText;
            else
                for (int i = 0; i < _ataChapterCollection.Count; i++)
                {
                    string ataChapter = Text;
                    int value;
                    if (Text.Length == 1 && int.TryParse(Text, out value))
                        ataChapter = "0" + Text;
                    if (_ataChapterCollection[i].ShortName.ToLower() == ataChapter.ToLower())
                        Text = _ataChapterCollection[i].ShortName + " " + _ataChapterCollection[i].FullName;
                }
        }

        #endregion

        #region private void ATAChapterComboBox_GotFocus(object sender, EventArgs e)

        private void ATAChapterComboBoxGotFocus(object sender, EventArgs e)
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

        #region void UpdateInformation()
        ///<summary>
        /// Обновляет информацию, сожержащуюся в списке
        ///</summary>
        public void UpdateInformation()
        {
	        DrawItem += ATAChapterComboBox_DrawItem;
			if (_ataChapterCollection == null)
                _ataChapterCollection = new AtaChapterCollection();
            _ataChapterCollection.Clear();
            IDictionaryCollection atas = GlobalObjects.CasEnvironment.GetDictionary<AtaChapter>();
            foreach (AtaChapter ata in atas)
                _ataChapterCollection.Add(ata);
            _ataChapterDictionaries = new Dictionary<string, AtaChapter>();
            List<string> ataChapters = new List<string>();

            _ataChapterDictionaries.Clear();
            for (int i = 0; i < _ataChapterCollection.Count; i++)
            {
                ataChapters.Add(_ataChapterCollection[i].ShortName + " " + _ataChapterCollection[i].FullName);
                _ataChapterDictionaries.Add(ataChapters[i], _ataChapterCollection[i]);
            }

            ataChapters.Sort();

            Items.Clear();
            Items.AddRange(ataChapters.ToArray());
            Text = defaultText;
            DropDownStyle = ComboBoxStyle.DropDown;
			DrawMode = DrawMode.OwnerDrawFixed;
            LostFocus += ATAChapterComboBoxLostFocus;
            GotFocus += ATAChapterComboBoxGotFocus;
			

        }

		private void ATAChapterComboBox_DrawItem(object sender, DrawItemEventArgs e)
		{
			Font font = Font;
			Brush brush = Brushes.Black;
			var text = Items[e.Index] as string;

			if (_ataChapterDictionaries[text].ShortName.Length == 2)
			{
				font = new Font(font, FontStyle.Bold);
			}

			e.Graphics.DrawString(text, font, brush, e.Bounds);
		}

		#endregion

		/// <summary> 
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
        {
            if(_ataChapterCollection != null)
                _ataChapterCollection.Clear();
            base.Dispose(disposing);
        }
        #endregion

    }
}
