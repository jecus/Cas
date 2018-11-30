using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Core.Management;
using CAS.Core.ProjectTerms;
using CAS.Core.Types;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.BiWeekliesReportsControls;
using Controls.AvButtonT;

namespace CAS.UI.UIControls.EngineeringOrdersDirectives
{
    /// <summary>
    /// Форма для отображения отдельного инженерного задания <see cref="EngineeringOrderTask"/>
    /// </summary>
    public class EngineeringOrderDirectiveTaskForm : Form
    {
        #region Fields

        private readonly EngineeringOrderTask task;
        private readonly EngineeringOrderDirective parentDirective;

        private readonly Label labelDescription = new Label();
        private readonly Label labelDocuments = new Label();
        private readonly TextBox textBoxData = new TextBox();
        private readonly ListView listView = new ListView();
        private readonly ImageList imageList = new ImageList();
        private readonly Button buttonOK = new Button();
        private readonly Button buttonCancel = new Button();
        private readonly AvButtonT buttonAdd = new AvButtonT();
        private readonly AvButtonT buttonDelete = new AvButtonT();
        private readonly AvButtonT buttonEdit = new AvButtonT();
        private readonly Icons icons = new Icons();
        private const int MARGIN = 10;
        private const int LABEL_HEIGHT = 25;
        private const int BUTTON_WIDTH = 100;
        private const int INTERVAL = 10;
        private bool permissionForUpdate = true;
        private readonly List<Document> selectedItems = new List<Document>();

        //private Document tempReport;
        private string[] tempFilePathes;
        private Process[] tempProcesses;
        protected bool[] processStartSuccessfully;
        private ScreenMode mode;
        private bool saved = false;

        #endregion

        #region Constructorы

        #region public EngineeringOrderDirectiveTaskForm()

        /// <summary>
        /// Создает форму для добавления инженерного задания <see cref="EngineeringOrderTask"/>
        /// </summary>
        /// <param name="parentDirective">Родительская директива</param>
        public EngineeringOrderDirectiveTaskForm(EngineeringOrderDirective parentDirective)
        {
            this.parentDirective = parentDirective;
            mode = ScreenMode.Add;
            task = new EngineeringOrderTask();
            InitializeComponents();
        }

        #endregion

        #region public EngineeringOrderDirectiveTaskForm(EngineeringOrderTask task, ScreenMode mode)

        /// <summary>
        /// Создает форму для отображения отдельного инженерного задания <see cref="EngineeringOrderTask"/>
        /// </summary>
        /// <param name="task">Инженерное задание</param>
        /// <param name="mode">Режим формы</param>
        public EngineeringOrderDirectiveTaskForm(EngineeringOrderTask task, ScreenMode mode)
        {
            this.mode = mode;
            this.task = task;
            permissionForUpdate = task.HasPermission(Users.CurrentUser, DataEvent.Update);
            InitializeComponents();
            UpdateInformation();
        }

        #endregion

        #endregion

        #region Properties

        #region public Document SelectedItem

        /// <summary>
        /// Выбранный документ
        /// </summary>
        public Document SelectedItem
        {
            get
            {
                if (listView.SelectedItems.Count == 1)
                    return (listView.SelectedItems[0].Tag as Document);
                return null;
            }
        }
        #endregion

        #region public List<Document> SelectedItems

        /// <summary>
        /// Возвращает список выбранных документов
        /// </summary>
        public List<Document> SelectedItems
        {
            get
            {
                return selectedItems;
            }
        }
        #endregion

        #endregion

        #region Methods

        #region private void InitializeComponents()

        private void InitializeComponents()
        {
            //
            // labelDescription
            //
            labelDescription.Location = new Point(MARGIN, MARGIN);
            labelDescription.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDescription.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDescription.Text = "Description:";
            //
            // textBoxData
            //
            textBoxData.BackColor = Color.White;
            textBoxData.Font = Css.OrdinaryText.Fonts.RegularFont;
            textBoxData.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            textBoxData.Location = new Point(MARGIN, labelDescription.Bottom);
            textBoxData.Multiline = true;
            textBoxData.Size = new Size(800, 250);
            textBoxData.ReadOnly = !permissionForUpdate;
            //
            // labelDocuments
            //
            labelDocuments.Location = new Point(MARGIN, textBoxData.Bottom + INTERVAL);
            labelDocuments.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDocuments.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDocuments.Text = "Documents:";
            //
            // listView
            //
            listView.Alignment = ListViewAlignment.Left;
            listView.Location = new Point(MARGIN, labelDocuments.Bottom);
            listView.Font = Css.OrdinaryText.Fonts.RegularFont;
            listView.Size = new Size(800, 250);
            listView.SmallImageList = imageList;
            listView.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
            listView.View = View.SmallIcon;
            listView.ItemSelectionChanged += listView_ItemSelectionChanged;
            listView.MouseDoubleClick += listView_MouseDoubleClick;
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
            buttonEdit.Size = new Size(120, 50);
            buttonEdit.TabIndex = 16;
            buttonEdit.TextMain = "Rename";
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
            //
            // buttonOK
            //
            buttonOK.Font = Css.OrdinaryText.Fonts.RegularFont;
            buttonOK.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            buttonOK.Size = new Size(BUTTON_WIDTH, LABEL_HEIGHT);
            buttonOK.Text = "OK";
            buttonOK.Click += buttonOK_Click;
            //
            // buttonCancel
            //
            buttonCancel.Font = Css.OrdinaryText.Fonts.RegularFont;
            buttonCancel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            buttonCancel.Size = new Size(BUTTON_WIDTH, LABEL_HEIGHT);
            buttonCancel.Text = "Cancel";
            buttonCancel.Click += buttonCancel_Click;

            Controls.Add(labelDescription);
            Controls.Add(textBoxData);
            Controls.Add(labelDocuments);
            Controls.Add(listView);
            Controls.Add(buttonAdd);
            Controls.Add(buttonEdit);
            Controls.Add(buttonDelete);
            Controls.Add(buttonOK);
            Controls.Add(buttonCancel);

            BackColor = Css.CommonAppearance.Colors.BackColor;
            AcceptButton = buttonOK;
            CancelButton = buttonCancel;
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            if (mode == ScreenMode.Add)
            {
                Text = "Add task";
                ClientSize = new Size(textBoxData.Width + 2 * MARGIN, labelDescription.Height + textBoxData.Height + buttonOK.Height + INTERVAL + 2 * MARGIN);
                buttonOK.Location = new Point(textBoxData.Right - 2 * BUTTON_WIDTH - INTERVAL, textBoxData.Bottom + INTERVAL);
                buttonCancel.Location = new Point(textBoxData.Right - buttonCancel.Width, textBoxData.Bottom + INTERVAL);
                labelDocuments.Visible = false;
                listView.Visible = false;
                buttonAdd.Visible = false;
                buttonEdit.Visible = false;
                buttonDelete.Visible = false;
            }
            else
            {
                if (mode == ScreenMode.View)
                    Text = "View task";
                else
                    Text = "Edit task";
                buttonOK.Location = new Point(listView.Right - 2 * BUTTON_WIDTH - INTERVAL, listView.Bottom + INTERVAL);
                buttonCancel.Location = new Point(listView.Right - buttonCancel.Width, listView.Bottom + INTERVAL);
                ClientSize = new Size(textBoxData.Width + 2*MARGIN, labelDescription.Height + labelDocuments.Height + textBoxData.Height + listView.Height + buttonAdd.Height + 2*INTERVAL + 2*MARGIN);
            }
            Closing += EngineeringOrderDirectiveTaskForm_Closing;
        }

        #endregion

        #region private void UpdateInformation()

        private void UpdateInformation()
        {
            textBoxData.Text = task.Data;

            tempFilePathes = new string[task.Documents.Count];
            tempProcesses = new Process[task.Documents.Count];
            processStartSuccessfully = new bool[task.Documents.Count];
            for (int i = 0; i < task.Documents.Count; i++)
                processStartSuccessfully[i] = true;
            for (int i = 0; i < task.Documents.Count; i++)
                tempFilePathes[i] = task.Documents[i].FileName;
            
            selectedItems.Clear();
            listView.Items.Clear();
            imageList.Images.Clear();

            for (int i = 0; i < task.Documents.Count; i++)
            {
                imageList.Images.Add(task.Documents[i].Icon);
            }

            for (int i = 0; i < task.Documents.Count; i++)
            {
                ListViewItem item = new ListViewItem(task.Documents[i].FileName, GetIndexOfIcon(task.Documents[i].Icon));
                item.Tag = task.Documents[i];
                listView.Items.Add(item);
            }
        }

        #endregion

        #region private void SaveData()

        private void SaveData()
        {
            if (task.Data != textBoxData.Text)
                task.Data = textBoxData.Text;

            try
            {
                if (mode == ScreenMode.Edit)
                    task.Save();
                else if (mode == ScreenMode.Add)
                {
                    parentDirective.AddEngineeringOrderTask(task); 
                }
                saved = true;
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex); return;
            }
        }
        #endregion
        
        #region private int GetIndexOfIcon(Icon icon)

        private int GetIndexOfIcon(Icon icon)
        {
            for (int i = 0; i < task.Documents.Count; i++)
                if (task.Documents[i].Icon == icon)
                    return i;
            return -1;
        }

        #endregion
        
        #region protected void RemoveTempFiles()

        protected void RemoveTempFiles()
        {
            for (int i = 0; i < task.Documents.Count; i++)
            {
                if (tempFilePathes[i] != "")
                {
                    if (tempProcesses[i] != null && processStartSuccessfully[i] && !tempProcesses[i].HasExited)
                    {
                        tempProcesses[i].Kill();
                        tempProcesses[i].WaitForExit(200);
                    }
#if RELEASE
                    try
                    {

#endif
                    File.Delete(tempFilePathes[i]);
#if RELEASE
                    }
                    catch (Exception ex)
                    {
                    }

#endif
                }
            }
        }

        #endregion

        #region public bool SaveReportToFile(Document document)

        /// <summary>
        /// Сохраняет документ во временный файл
        /// </summary>
        /// <param name="document">Документ, который требуется сохранить</param>
        /// <returns>Значение ,показывающее было ли сохранение успешным</returns>
        public bool SaveReportToFile(Document document)
        {
            string fileName = TermsProvider.GetTempFolderPath() + "\\" + document.FileName;
            if (document.FileData == null)
                return false;

            try
            {
                FileStream fileStreamBack = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                fileStreamBack.Write(document.FileData, 0, document.FileData.Length);
                fileStreamBack.Close();
                return true;
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error creating temp file", ex);
                return false;
            }
        }

        #endregion

        #region private void listView_MouseDoubleClick(object sender, MouseEventArgs e)

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int documentID = task.Documents.IndexOf(SelectedItem);

            if (SelectedItem.FileData != null && tempFilePathes[documentID] != "" && tempFilePathes[documentID] != null)
            {
                if (!File.Exists(tempFilePathes[documentID]))
                    SaveReportToFile(SelectedItem);
                tempProcesses[documentID] = new Process();
                tempProcesses[documentID].StartInfo.FileName = tempFilePathes[documentID];

                try
                {

                    tempProcesses[documentID].Start();
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while opening document", ex); 
                    processStartSuccessfully[documentID] = false;
                }

            }
        }

        #endregion

        #region private void buttonAdd_Click(object sender, EventArgs e)

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = ""
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileToConvert = new FileInfo(dialog.FileName);
                FileStream streamRead = fileToConvert.OpenRead();
                byte[][] fileArray = new byte[1][];
                fileArray[0] = new byte[streamRead.Length];
                streamRead.Read(fileArray[0], 0, (int) streamRead.Length);
                streamRead.Close();

                Document document = new Document();
                document.FileName = dialog.FileName.Substring(dialog.FileName.LastIndexOf("\\") + 1);
                document.FileData = fileArray[0];
                task.AddDocument(document);

                UpdateInformation();
            }
        }

        #endregion

        #region private void buttonEdit_Click(object sender, EventArgs e)

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            EngineeringOrderDirectiveRenameDocumentForm form = new EngineeringOrderDirectiveRenameDocumentForm(SelectedItem);
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
                message = string.Format(new TermsProvider()["DeleteQuestion"].ToString(), "document");
            else
                message = string.Format(new TermsProvider()["DeleteQuestionSeveral"].ToString(), "documents");
            DialogResult result = MessageBox.Show(message, "Deleting confirmation", MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {

                try
                {
                    int count = SelectedItems.Count;
                        for (int i = 0; i < count; i++)
                            task.RemoveDocument(SelectedItems[i]);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex); return;
                }
                UpdateInformation();
            }
        }

        #endregion

        #region private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)

        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Document item = (Document)e.Item.Tag;
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

        #region private void EngineeringOrderDirectiveTaskForm_Closing(object sender, CancelEventArgs e)

        private void EngineeringOrderDirectiveTaskForm_Closing(object sender, CancelEventArgs e)
        {
            if ((mode == ScreenMode.Edit && task.Data != textBoxData.Text) || (mode == ScreenMode.Add && textBoxData.Text != "" && !saved))
            {
                switch (MessageBox.Show("Do you want to save changes?", (string)new TermsProvider()["SystemName"],
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes:
                        SaveData();
                        if (mode != ScreenMode.Add)
                            RemoveTempFiles();
                        DialogResult = DialogResult.OK;
                        break;
                    case DialogResult.No:
                        if (mode != ScreenMode.Add)
                            RemoveTempFiles();
                        DialogResult = DialogResult.Cancel;
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        #endregion

        #region private void buttonOK_Click(object sender, EventArgs e)

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (mode == ScreenMode.Add && textBoxData.Text == "")
            {
                MessageBox.Show("Please enter the task description",
                                (string) new TermsProvider()["SystemName"],
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1);
                return;
            }
                
            SaveData();
            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region private void buttonCancel_Click(object sender, EventArgs e)

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #endregion

    }
}
