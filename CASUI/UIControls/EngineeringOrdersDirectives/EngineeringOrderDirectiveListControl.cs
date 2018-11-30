using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.daCore.Management;
using CAS.Core.ProjectTerms;
using CAS.UI.Appearance;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.BiWeekliesReportsControls;
using Controls.AvButtonT;

namespace CAS.UI.UIControls.EngineeringOrdersDirectives
{
    /// <summary>
    /// Элемент управления для отображения списка документов в <see cref="EngineeringOrderDirectiveScreen"/>
    /// </summary>
    public class EngineeringOrderDirectiveListControl : Control
    {

        #region Fields

        private readonly StringTableManager source;
        private readonly string[] columns;
        private readonly ListView listView = new ListView();
        private readonly AvButtonT buttonAdd = new AvButtonT();
        private readonly AvButtonT buttonDelete = new AvButtonT();
        private readonly AvButtonT buttonEdit = new AvButtonT();
        private readonly Button buttonUp = new Button();
        private readonly Button buttonDown = new Button();
        private readonly Icons icons = new Icons();
        private readonly List<List<string>> selectedItems = new List<List<string>>();
        private const int MARGIN = 10;
        private const int INTERVAL = 10;
        private const int BUTTON_WIDTH = 50;
        private const int BUTTON_HEIGHT = 25;
        private bool modified = false;
        private readonly bool permissionForUpdate = true;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения списка документов в <see cref="EngineeringOrderDirectiveScreen"/>
        /// </summary>
        /// <param name="source">Таблица значений</param>
        /// <param name="columns">Заголовки столбцов</param>
        /// <param name="columnsWidth">Ширина столбцов</param>
        /// <param name="permissionForUpdate">Права на внесение изменений в список</param>
        public EngineeringOrderDirectiveListControl(StringTableManager source, string[] columns, float[] columnsWidth, bool permissionForUpdate)
        {
            this.source = source;
            this.columns = columns;
            this.permissionForUpdate = permissionForUpdate;
            //
            // listView
            //
            listView.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            listView.Font = Css.OrdinaryText.Fonts.RegularFont;
            listView.FullRowSelect = true;
            listView.View = View.Details;
            listView.Location = new Point(MARGIN,MARGIN);
            listView.Size = new Size(1235, 250);
            listView.ItemSelectionChanged += listView_ItemSelectionChanged;
            listView.MouseDoubleClick += listView_MouseDoubleClick;
            //listView.ColumnClick += listViewJobCards_ColumnClick;
            // 
            // buttonAdd
            // 
            buttonAdd.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAdd.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonAdd.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonAdd.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonAdd.Icon = icons.Add;
            buttonAdd.IconNotEnabled = icons.AddGray;
            buttonAdd.IconLayout = ImageLayout.Center;
            buttonAdd.Location = new Point(MARGIN, listView.Bottom + INTERVAL);
            buttonAdd.PaddingSecondary = new Padding(0);
            buttonAdd.Size = new Size(100, 50);
            buttonAdd.TabIndex = 16;
            buttonAdd.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonAdd.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonAdd.TextMain = "Add";
            buttonAdd.Click += buttonAdd_Click;
            buttonAdd.Enabled = permissionForUpdate;
            // 
            // buttonEdit
            // 
            buttonEdit.BackColor = Color.Transparent;
            buttonEdit.Enabled = false;
            buttonEdit.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonEdit.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonEdit.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonEdit.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonEdit.IconLayout = ImageLayout.Center;
            buttonEdit.Location = new Point(buttonAdd.Right, listView.Bottom + INTERVAL);
            buttonEdit.PaddingSecondary = new Padding(0);
            buttonEdit.Size = new Size(100, 50);
            buttonEdit.TabIndex = 16;
            buttonEdit.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonEdit.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonEdit.Click += buttonEdit_Click;
            if (permissionForUpdate)
            {
                buttonEdit.TextMain = "Edit";
                buttonEdit.Icon = icons.Edit;
                buttonEdit.IconNotEnabled = icons.EditGray;
            }
            else
            {
                buttonEdit.TextMain = "View";
                buttonEdit.Icon = icons.View;
                buttonEdit.IconNotEnabled = icons.View;
            }
            // 
            // buttonDelete
            // 
            buttonDelete.BackColor = Color.Transparent;
            buttonDelete.Cursor = Cursors.Hand;
            buttonDelete.Enabled = false;
            buttonDelete.FontMain = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDelete.FontSecondary = Css.HeaderControl.Fonts.PrimaryFont;
            buttonDelete.ForeColorMain = Css.HeaderControl.Colors.PrimaryColor;
            buttonDelete.ForeColorSecondary = Css.HeaderControl.Colors.PrimaryColor;
            buttonDelete.Icon = icons.Delete;
            buttonDelete.IconNotEnabled = icons.DeleteGray;
            buttonDelete.IconLayout = ImageLayout.Center;
            buttonDelete.Location = new Point(buttonEdit.Right, listView.Bottom + INTERVAL);
            buttonDelete.PaddingSecondary = new Padding(0);
            buttonDelete.Size = new Size(150, 50);
            buttonDelete.TabIndex = 16;
            buttonDelete.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonDelete.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonDelete.TextMain = "Remove";
            buttonDelete.Click += buttonDelete_Click;
            //
            // buttonUp
            //
            buttonUp.Enabled = false;
            buttonUp.Location = new Point(listView.Right - 2 * BUTTON_WIDTH - INTERVAL, listView.Bottom + INTERVAL);
            buttonUp.Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT);
            buttonUp.Text = "Up";
            buttonUp.Click += buttonUp_Click;
            //
            // buttonDown
            //
            buttonDown.Enabled = false;
            buttonDown.Location = new Point(listView.Right - BUTTON_WIDTH, listView.Bottom + INTERVAL);
            buttonDown.Size = new Size(BUTTON_WIDTH, BUTTON_HEIGHT);
            buttonDown.Text = "Down";
            buttonDown.Click += buttonDown_Click;

            BackColor = Css.CommonAppearance.Colors.BackColor;
            Size = new Size(listView.Width + MARGIN, listView.Height + buttonAdd.Height + INTERVAL + MARGIN*2);
            Controls.Add(listView);
            Controls.Add(buttonAdd);
            Controls.Add(buttonEdit);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUp);
            Controls.Add(buttonDown);

            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(listView.Width * 0.04f);
            columnHeader.Text = "#";
            listView.Columns.Add(columnHeader);

            for (int i = 0; i < columns.Length; i++)
            {
                columnHeader = new ColumnHeader();
                columnHeader.Width = (int)(listView.Width * columnsWidth[i]);
                columnHeader.Text = columns[i];
                listView.Columns.Add(columnHeader);
            }
        }

        #endregion

        #region Properties

        #region public List<string> SelectedItem

        /// <summary>
        /// Выбранная строка
        /// </summary>
        public List<string> SelectedItem
        {
            get
            {
                if (listView.SelectedItems.Count == 1)
                    return (listView.SelectedItems[0].Tag as List<string>);
                return null;
            }
        }

        #endregion

        #region public List<List<string>> SelectedItems

        /// <summary>
        /// Возвращает список выбранных строк
        /// </summary>
        public List<List<string>> SelectedItems
        {
            get
            {
                return selectedItems;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public bool GetChangeStatus(bool directiveExist)

        /// <summary>
        /// Возвращает значение, показывающее были ли изменения в данном элементе управления
        /// </summary>
        public bool GetChangeStatus()
        {
            return modified;
        }

        #endregion

        #region public void UpdateItems()

        /// <summary>
        /// Обновляет данные в ListView
        /// </summary>
        public void UpdateItems()
        {
            listView.Items.Clear();
            selectedItems.Clear();
            for (int i = 0; i < source.Items.Count; i++)
            {
                ListViewItem item = new ListViewItem((i + 1).ToString());
                for (int j = 0; j < source.Items[i].Count; j++)
                {
                    item.SubItems.Add(source.Items[i][j]);
                }
                item.Tag = source.Items[i];
                listView.Items.Add(item);
            }
            modified = false;
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public void SaveData()
        {
            if (modified)
            {
                if (source.IsEmpty)
                    source.CreateTable(columns.Length);
                //source.Items.Add(formAdd.Row);
                source.Items.Clear();
                for (int i = 0; i < listView.Items.Count; i++)
                {
                    source.Items.Add((List<string>) listView.Items[i].Tag);
                }
                source.SaveSource();
                modified = false;
            }
        }

        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
            source.Items.Clear();
        }

        #endregion

        #region private void buttonAdd_Click(object sender, EventArgs e)

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EngineeringOrderDirectiveDocumentForm formAdd = new EngineeringOrderDirectiveDocumentForm(columns);
            if (formAdd.ShowDialog() == DialogResult.OK)
            {
                ListViewItem item = new ListViewItem((listView.Items.Count + 1).ToString());
                item.SubItems.AddRange(formAdd.Row.ToArray());
                item.Tag = formAdd.Row;
                listView.Items.Add(item);

                modified = true;
            }
        }

        #endregion

        #region private void buttonEdit_Click(object sender, EventArgs e)

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ScreenMode mode;
            if (permissionForUpdate)
                mode = ScreenMode.Edit;
            else 
                mode = ScreenMode.View;
            EngineeringOrderDirectiveDocumentForm formEdit = new EngineeringOrderDirectiveDocumentForm(columns, SelectedItem, mode);
            if (formEdit.ShowDialog() == DialogResult.OK)
            {
                //source.Items[source.Items.IndexOf(SelectedItem)] = formEdit.Row;
                ListViewItem item = new ListViewItem(listView.Items[listView.SelectedItems[0].Index].Text);
                item.SubItems.AddRange(formEdit.Row.ToArray());
                item.Tag = formEdit.Row;
                listView.Items[listView.SelectedItems[0].Index] = item;
                modified = true;
            }
        }

        #endregion

        #region private void buttonDelete_Click(object sender, EventArgs e)

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string message;
            if (SelectedItems.Count == 1)
                message = string.Format(new TermsProvider()["DeleteQuestion"].ToString(), "document");
            else
                message = string.Format(new TermsProvider()["DeleteQuestionSeveral"].ToString(), "documents");
            DialogResult result = MessageBox.Show(message, "Deleting confirmation", MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                int count = SelectedItems.Count;
                //for (int i = 0; i < SelectedItems.Count; i++)
                    //source.Items.Remove(SelectedItems[i]);
                //UpdateItems();
                while(SelectedItems.Count != 0)
                    listView.Items.Remove(listView.SelectedItems[0]);
                
                modified = true;
            }

        }

        #endregion

        #region private void buttonUp_Click(object sender, EventArgs e)

        private void buttonUp_Click(object sender, EventArgs e)
        {
            string movedID = listView.SelectedItems[0].Text;
            string replacedID = listView.Items[listView.SelectedItems[0].Index - 1].Text;

            List<string> movedRow = (List<string>) listView.SelectedItems[0].Tag;
            //movedRow.Insert(0, replacedID);
            List<string> replacedRow = (List<string>) listView.Items[listView.SelectedItems[0].Index - 1].Tag;
            //replacedRow.Insert(0, movedID);

            ListViewItem movedItem = new ListViewItem(replacedID);
            movedItem.SubItems.AddRange(movedRow.ToArray());
            movedItem.Tag = movedRow;
            ListViewItem replacedItem = new ListViewItem(movedID);
            replacedItem.SubItems.AddRange(replacedRow.ToArray());
            replacedItem.Tag = replacedRow;
           
            listView.Items[listView.SelectedItems[0].Index - 1] = movedItem;
            listView.Items[listView.SelectedItems[0].Index] = replacedItem;
            
            modified = true;
        }

        #endregion

        #region private void buttonDown_Click(object sender, EventArgs e)

        private void buttonDown_Click(object sender, EventArgs e)
        {
            List<string> movedRow = (List<string>)listView.SelectedItems[0].Tag;
            List<string> replacedRow = (List<string>)listView.Items[listView.SelectedItems[0].Index + 1].Tag;

            ListViewItem movedItem = new ListViewItem(movedRow.ToArray());
            movedItem.Tag = movedRow;
            ListViewItem replacedItem = new ListViewItem(replacedRow.ToArray());
            replacedItem.Tag = replacedRow;

            listView.Items[listView.SelectedItems[0].Index + 1] = movedItem;
            listView.Items[listView.SelectedItems[0].Index] = replacedItem;

            modified = true;
        }

        #endregion

        #region private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)

        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            List<string> item = (List<string>)e.Item.Tag;
            if (e.IsSelected)
            {
                selectedItems.Add(item);
            }
            else
            {
                if (selectedItems.Contains(item))
                    selectedItems.Remove(item);
            }
            buttonEdit.Enabled = (SelectedItems.Count == 1);
            buttonDelete.Enabled = (SelectedItems.Count > 0 && permissionForUpdate);
            buttonUp.Enabled = (SelectedItems.Count == 1 && SelectedItem != (List<string>)listView.Items[0].Tag);
            buttonDown.Enabled = (SelectedItems.Count == 1 && SelectedItem != (List<string>)listView.Items[listView.Items.Count - 1].Tag);
        }

        #endregion

        #region private void listView_MouseDoubleClick(object sender, MouseEventArgs e)

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (SelectedItem != null && e.Button == MouseButtons.Left)
                buttonEdit_Click(listView, new EventArgs());
        }

        #endregion

        #endregion

    }
}
