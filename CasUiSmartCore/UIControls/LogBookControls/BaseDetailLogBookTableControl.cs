using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.UIControls.LogBookControls;

namespace CAS.UI.UIControls.LogBookControls
{
 /*   /// <summary>
    /// Элемент управления для отображения списка наработок для определенного агрегата
    /// </summary>
    public partial class BaseDetailLogBookTableControl : PictureBox
    {

        #region Fields

        private LifelengthIncrement[] lifelengthIncrements = new LifelengthIncrement[0];
        private readonly List<BaseDetailLogBookItem> baseDetailLogBookItems = new List<BaseDetailLogBookItem>();
        private BaseDetail currentDetail;
        private bool readOnly = true;
        private int activeRowID;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения списка наработок
        /// </summary>
        /// <param name="currentDetail">Текущий базовый агрегат</param>
        public BaseDetailLogBookTableControl(BaseDetail currentDetail)
        {
            this.currentDetail = currentDetail;
            InitializeComponent();
            UpdateControl();
        }

        #endregion

        #region Properties

        #region public bool ReadOnly

        /// <summary>
        /// Возвращает или устанавливает значение readOnly которое показывает, можно ли редактировать наработки
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                return readOnly;
            }
            set
            {
                readOnly = value;
                SetReadOnlyValue(value);
            }
        }

        #endregion

        #region public LifelengthIncrement[] LifelengthIncrements

        /// <summary>
        /// Возвращает или устанавливает список наработок, которые следует отображать
        /// </summary>
        public LifelengthIncrement[] LifelengthIncrements
        {
            get
            {
                return lifelengthIncrements;
            }
            set
            {
                lifelengthIncrements = value;
                UpdateControl();
            }
        }

        #endregion

        #region public BaseDetail CurrentDetail

        /// <summary>
        /// Возвращает или устанавливает текущий агрегат, к которому принадлежат наработки
        /// </summary>
        public BaseDetail CurrentDetail
        {
            get
            {
                return currentDetail;
            }
            set
            {
                currentDetail = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void SetReadOnlyValue(bool value)

        private void SetReadOnlyValue(bool value)
        {
            for (int i = 0; i < baseDetailLogBookItems.Count; i++)
            {
                baseDetailLogBookItems[i].ReadOnly = value;
            }
        }

        #endregion

        #region public void UpdateControl()

        /// <summary>
        /// Обновляет элемент управления
        /// </summary>
        public void UpdateControl()
        {
            Controls.Clear();
            baseDetailLogBookItems.Clear();
            for (int i = 0; i < lifelengthIncrements.Length; i++)
            {
                BaseDetailLogBookItem item = new BaseDetailLogBookItem(lifelengthIncrements[i], currentDetail);
                if (i == 0)
                    item.Location = new Point(0, 0);
                else
                    item.Location = new Point(0, baseDetailLogBookItems[i - 1].Bottom - 1);
                item.PageUpPressed += BaseDetailLogBookTableControl_PageUpPressed;
                item.PageDownPressed += BaseDetailLogBookTableControl_PageDownPressed;
                item.TextBoxFocused += item_TextBoxFocused;
                item.ValueChanged += item_ValueChanged;
                baseDetailLogBookItems.Add(item);
                Controls.Add(item);
            }
            if (lifelengthIncrements.Length == 0)
                Size = new Size(0,0);
            else
                Size = new Size(BaseDetailLogBookItem.DefaultItemSize.Width, BaseDetailLogBookItem.DefaultItemSize.Height * lifelengthIncrements.Length);

            SetReadOnlyValue(readOnly);
        }

        #endregion

        #region private void BaseDetailLogBookTableControl_PageUpPressed(object sender, EventArgs e)

        private void BaseDetailLogBookTableControl_PageUpPressed(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if ((activeRowID > 0) && (control != null))
            {
                activeRowID--;
                baseDetailLogBookItems[activeRowID].ActivateTextBox((int)control.Tag);
            }
        }

        #endregion

        #region private void BaseDetailLogBookTableControl_PageDownPressed(object sender, EventArgs e)

        private void BaseDetailLogBookTableControl_PageDownPressed(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if ((activeRowID < baseDetailLogBookItems.Count - 1) && (control != null))
            {
                activeRowID++;
                baseDetailLogBookItems[activeRowID].ActivateTextBox((int)control.Tag);
            }
        }

        #endregion

        #region private void item_TextBoxFocused(object sender, EventArgs e)

        private void item_TextBoxFocused(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                BaseDetailLogBookItem item = textBox.Parent as BaseDetailLogBookItem;
                if (item != null)
                    activeRowID = baseDetailLogBookItems.IndexOf(item);
            }
        }

        #endregion

        #region private void item_ValueChanged(object sender, EventArgs e)

        /// <summary>
        /// Обновляет информацию о наработках данного агрегата
        /// </summary>
        private void item_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < baseDetailLogBookItems.Count; i++)
            {
                baseDetailLogBookItems[i].UpdateInformation();
            }
        }

        #endregion

        #endregion

    }*/
}