using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.BiWeekliesReportsControls;
using Controls.AvButtonT;

namespace CAS.UI.UIControls.EngineeringOrdersDirectives
{
    /// <summary>
    /// Элемент управления для отображения инструкций инженерного задания
    /// </summary>
    public class EngineeringOrderDirectiveSpecificNotesDataControl : Control
    {

        #region Fields

        private readonly EngineeringOrderDirective directive;
        private readonly ListView listView = new ListView();
        private readonly AvButtonT buttonAdd = new AvButtonT();
        private readonly AvButtonT buttonDelete = new AvButtonT();
        private readonly AvButtonT buttonEdit = new AvButtonT();
        private readonly List<EngineeringOrderTask> selectedItems = new List<EngineeringOrderTask>();
        private readonly Icons icons = new Icons();

        private readonly float[] HEADER_WIDTH = new float[] { 0.04f, 0.94f };
        //private readonly Icons icons = new Icons();
        private const int MARGIN = 10;
        private const int INTERVAL = 10;

        private readonly bool permissionForUpdate = true;
        

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения инструкций инженерного задания
        /// </summary>
        public EngineeringOrderDirectiveSpecificNotesDataControl(EngineeringOrderDirective directive)
        {
            permissionForUpdate = directive.HasPermission(Users.CurrentUser, DataEvent.Update);
            this.directive = directive;
            //
            // listViewBiWeeklies
            //
            listView.BackColor = Css.CommonAppearance.Colors.BackColor;
            listView.Font = Css.OrdinaryText.Fonts.RegularFont;
            listView.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            listView.FullRowSelect = true;
            listView.Location = new Point(MARGIN, MARGIN);
            listView.Size = new Size(1235, 250);
            listView.View = View.Details;
            listView.ItemSelectionChanged += listView_ItemSelectionChanged;
            listView.MouseDoubleClick += listView_MouseDoubleClick;
            //listViewDirectives.ColumnClick += listViewDirectives_ColumnClick;
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
            buttonEdit.Icon = icons.Edit;
            buttonEdit.IconNotEnabled = icons.EditGray;
            buttonEdit.IconLayout = ImageLayout.Center;
            buttonEdit.Location = new Point(buttonAdd.Right, listView.Bottom + INTERVAL);
            buttonEdit.PaddingSecondary = new Padding(0);
            buttonEdit.Size = new Size(100, 50);
            buttonEdit.TabIndex = 16;
            buttonEdit.TextMain = "Edit";
            buttonEdit.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonEdit.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonEdit.Click += buttonEdit_Click;
            buttonEdit.Enabled = false;
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
            buttonDelete.Size = new Size(120, 50);
            buttonDelete.TabIndex = 16;
            buttonDelete.TextAlignMain = ContentAlignment.MiddleLeft;
            buttonDelete.TextAlignSecondary = ContentAlignment.TopCenter;
            buttonDelete.TextMain = "Remove";
            buttonDelete.Click += buttonDelete_Click;
            buttonDelete.Enabled = false;

            BackColor = Css.CommonAppearance.Colors.BackColor;
            Size = new Size(listView.Width + MARGIN, listView.Height + INTERVAL + buttonAdd.Height + MARGIN);
            Controls.Add(listView);
            Controls.Add(buttonAdd);
            Controls.Add(buttonEdit);
            Controls.Add(buttonDelete);

            SetHeaders();
            //UpdateItems();
        }

        #endregion

        #region Properties

        #region public EngineeringOrderTask SelectedItem

        /// <summary>
        /// Выбранное инженерное задание
        /// </summary>
        public EngineeringOrderTask SelectedItem
        {
            get
            {
                if (listView.SelectedItems.Count == 1)
                    return (listView.SelectedItems[0].Tag as EngineeringOrderTask);
                return null;
            }
        }
        #endregion

        #region public List<EngineeringOrderTask> SelectedItems

        /// <summary>
        /// Возвращает список выбранных инженерных заданий
        /// </summary>
        public List<EngineeringOrderTask> SelectedItems
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
            return false;//todo
        }

        #endregion

        #region public void UpdateInformation()

        /// <summary>
        /// Обновляет данные в ListView
        /// </summary>
        public void UpdateInformation()
        {
            //directive.EngineeringOrderTasks;
            listView.Items.Clear();
            /* selectedItems.Clear();*/

            for (int i = 0; i < directive.EngineeringOrderTasks.Count; i++)
            {
                ListViewItem item = new ListViewItem(new string[] {(i + 1).ToString(), directive.EngineeringOrderTasks[i].Data});
                item.Tag = directive.EngineeringOrderTasks[i];
                listView.Items.Add(item);
            }
            
            //modified = false;*/
        }

        #endregion

        #region public void SaveData()

        /// <summary>
        /// Данные у директивы обновляются по введенным данным
        /// </summary>
        public void SaveData()
        {
          //  if (modified)
          //      source.SaveSource();
          //  modified = false;
        }

        #endregion

        #region public void ClearFields()

        /// <summary>
        /// Очищает все поля
        /// </summary>
        public void ClearFields()
        {
           // source.Items.Clear();
        }

        #endregion

        #region private void SetHeaders()

        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        private void SetHeaders()
        {
            ColumnHeader columnHeader;

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(listView.Width * HEADER_WIDTH[0]);
            columnHeader.Text = "#";
            listView.Columns.Add(columnHeader);

            columnHeader = new ColumnHeader();
            columnHeader.Width = (int)(listView.Width * HEADER_WIDTH[1]);
            columnHeader.Text = "Description";
            listView.Columns.Add(columnHeader);
        }

        #endregion

        #region private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)

        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EngineeringOrderTask item = (EngineeringOrderTask)e.Item.Tag;
            if (e.IsSelected)
            {
                selectedItems.Add(item);
            }
            else
            {
                if (selectedItems.Contains(item))
                    selectedItems.Remove(item);
            }
            buttonEdit.Enabled = (permissionForUpdate && listView.SelectedItems.Count == 1);
            buttonDelete.Enabled = (permissionForUpdate && listView.SelectedItems.Count > 0);
        }

        #endregion

        #region private void listView_MouseDoubleClick(object sender, MouseEventArgs e)

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            buttonEdit_Click(this, new EventArgs());
        }

        #endregion

        #region private void buttonAdd_Click(object sender, EventArgs e)

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EngineeringOrderDirectiveTaskForm form = new EngineeringOrderDirectiveTaskForm(directive);
            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateInformation();
            }
        }

        #endregion

        #region private void buttonEdit_Click(object sender, EventArgs e)

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ScreenMode mode = ScreenMode.View;
            if (permissionForUpdate)
                mode = ScreenMode.Edit;
            EngineeringOrderDirectiveTaskForm form = new EngineeringOrderDirectiveTaskForm(SelectedItem, mode);
            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateInformation();
            }
        }

        #endregion

        #region private void buttonDelete_Click(object sender, EventArgs e)

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            string message;
            if (listView.SelectedItems.Count == 1)
                message = string.Format(new TermsProvider()["DeleteQuestion"].ToString(), "task");
            else
                message = string.Format(new TermsProvider()["DeleteQuestionSeveral"].ToString(), "tasks");
            DialogResult result = MessageBox.Show(message, "Deleting confirmation", MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int count = SelectedItems.Count;
                        for (int i = 0; i < count; i++)
                            directive.RemoveEngineeringOrderTask(SelectedItems[i]);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex); 
                    return;
                }
                UpdateInformation();
            }
        }

        #endregion


        #endregion


    }
}
