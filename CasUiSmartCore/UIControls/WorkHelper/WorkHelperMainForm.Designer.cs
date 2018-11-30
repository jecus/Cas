namespace CAS.UI.UIControls.WorkHelper
{
    partial class WorkHelperMainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeViewMain = new System.Windows.Forms.TreeView();
            this.labelListScreen = new System.Windows.Forms.Label();
            this.textBoxLIstScreenClassName = new System.Windows.Forms.TextBox();
            this.textBoxListViewClassName = new System.Windows.Forms.TextBox();
            this.labelListView = new System.Windows.Forms.Label();
            this.labelListScreenClassName = new System.Windows.Forms.Label();
            this.textBoxListScreenPath = new System.Windows.Forms.TextBox();
            this.labelListScreenPath = new System.Windows.Forms.Label();
            this.labelTableName = new System.Windows.Forms.Label();
            this.textBoxTableName = new System.Windows.Forms.TextBox();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelStatusValue = new System.Windows.Forms.Label();
            this.buttonScreenPath = new System.Windows.Forms.Button();
            this.labelScreenClassStatus = new System.Windows.Forms.Label();
            this.labelListClassStatus = new System.Windows.Forms.Label();
            this.checkBoxScreenClassInstall = new System.Windows.Forms.CheckBox();
            this.checkBoxListClassInstall = new System.Windows.Forms.CheckBox();
            this.checkBoxTableInstall = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageDataBaseManager = new System.Windows.Forms.TabPage();
            this.tabPageFileUploader = new System.Windows.Forms.TabPage();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.listViewFiles = new System.Windows.Forms.ListView();
            this.columnHeaderFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFilePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonBrowseUploadFolder = new System.Windows.Forms.Button();
            this.textBoxUploadFileFolder = new System.Windows.Forms.TextBox();
            this.labelUploadFileFolder = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageDataBaseManager.SuspendLayout();
            this.tabPageFileUploader.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewMain
            // 
            this.treeViewMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewMain.Location = new System.Drawing.Point(0, 6);
            this.treeViewMain.Name = "treeViewMain";
            this.treeViewMain.Size = new System.Drawing.Size(411, 1040);
            this.treeViewMain.TabIndex = 0;
            this.treeViewMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewMainAfterSelect);
            // 
            // labelListScreen
            // 
            this.labelListScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelListScreen.AutoSize = true;
            this.labelListScreen.ForeColor = System.Drawing.Color.DimGray;
            this.labelListScreen.Location = new System.Drawing.Point(417, 29);
            this.labelListScreen.Name = "labelListScreen";
            this.labelListScreen.Size = new System.Drawing.Size(125, 17);
            this.labelListScreen.TabIndex = 1;
            this.labelListScreen.Text = "Экран со списком";
            // 
            // textBoxLIstScreenClassName
            // 
            this.textBoxLIstScreenClassName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLIstScreenClassName.Location = new System.Drawing.Point(548, 26);
            this.textBoxLIstScreenClassName.Name = "textBoxLIstScreenClassName";
            this.textBoxLIstScreenClassName.Size = new System.Drawing.Size(284, 22);
            this.textBoxLIstScreenClassName.TabIndex = 3;
            // 
            // textBoxListViewClassName
            // 
            this.textBoxListViewClassName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxListViewClassName.Location = new System.Drawing.Point(548, 54);
            this.textBoxListViewClassName.Name = "textBoxListViewClassName";
            this.textBoxListViewClassName.Size = new System.Drawing.Size(284, 22);
            this.textBoxListViewClassName.TabIndex = 4;
            // 
            // labelListView
            // 
            this.labelListView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelListView.AutoSize = true;
            this.labelListView.ForeColor = System.Drawing.Color.DimGray;
            this.labelListView.Location = new System.Drawing.Point(419, 57);
            this.labelListView.Name = "labelListView";
            this.labelListView.Size = new System.Drawing.Size(75, 17);
            this.labelListView.TabIndex = 5;
            this.labelListView.Text = "ЭУ списка";
            // 
            // labelListScreenClassName
            // 
            this.labelListScreenClassName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelListScreenClassName.AutoSize = true;
            this.labelListScreenClassName.ForeColor = System.Drawing.Color.DimGray;
            this.labelListScreenClassName.Location = new System.Drawing.Point(676, 6);
            this.labelListScreenClassName.Name = "labelListScreenClassName";
            this.labelListScreenClassName.Size = new System.Drawing.Size(121, 17);
            this.labelListScreenClassName.TabIndex = 6;
            this.labelListScreenClassName.Text = "Название класса";
            // 
            // textBoxListScreenPath
            // 
            this.textBoxListScreenPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxListScreenPath.Enabled = false;
            this.textBoxListScreenPath.Location = new System.Drawing.Point(548, 82);
            this.textBoxListScreenPath.Name = "textBoxListScreenPath";
            this.textBoxListScreenPath.Size = new System.Drawing.Size(391, 22);
            this.textBoxListScreenPath.TabIndex = 7;
            // 
            // labelListScreenPath
            // 
            this.labelListScreenPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelListScreenPath.AutoSize = true;
            this.labelListScreenPath.ForeColor = System.Drawing.Color.DimGray;
            this.labelListScreenPath.Location = new System.Drawing.Point(419, 85);
            this.labelListScreenPath.Name = "labelListScreenPath";
            this.labelListScreenPath.Size = new System.Drawing.Size(82, 17);
            this.labelListScreenPath.TabIndex = 8;
            this.labelListScreenPath.Text = "Путь папки";
            // 
            // labelTableName
            // 
            this.labelTableName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTableName.AutoSize = true;
            this.labelTableName.ForeColor = System.Drawing.Color.DimGray;
            this.labelTableName.Location = new System.Drawing.Point(419, 141);
            this.labelTableName.Name = "labelTableName";
            this.labelTableName.Size = new System.Drawing.Size(96, 17);
            this.labelTableName.TabIndex = 13;
            this.labelTableName.Text = "Имя таблицы";
            // 
            // textBoxTableName
            // 
            this.textBoxTableName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTableName.Enabled = false;
            this.textBoxTableName.Location = new System.Drawing.Point(550, 138);
            this.textBoxTableName.Name = "textBoxTableName";
            this.textBoxTableName.Size = new System.Drawing.Size(282, 22);
            this.textBoxTableName.TabIndex = 12;
            // 
            // buttonInstall
            // 
            this.buttonInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInstall.Location = new System.Drawing.Point(894, 203);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(81, 22);
            this.buttonInstall.TabIndex = 14;
            this.buttonInstall.Text = "Создать";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.ButtonInstallClick);
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.DimGray;
            this.labelStatus.Location = new System.Drawing.Point(835, 6);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(53, 17);
            this.labelStatus.TabIndex = 15;
            this.labelStatus.Text = "Статус";
            // 
            // labelStatusValue
            // 
            this.labelStatusValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatusValue.AutoSize = true;
            this.labelStatusValue.ForeColor = System.Drawing.Color.DimGray;
            this.labelStatusValue.Location = new System.Drawing.Point(835, 141);
            this.labelStatusValue.Name = "labelStatusValue";
            this.labelStatusValue.Size = new System.Drawing.Size(53, 17);
            this.labelStatusValue.TabIndex = 16;
            this.labelStatusValue.Text = "Статус";
            // 
            // buttonScreenPath
            // 
            this.buttonScreenPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonScreenPath.Location = new System.Drawing.Point(945, 82);
            this.buttonScreenPath.Name = "buttonScreenPath";
            this.buttonScreenPath.Size = new System.Drawing.Size(30, 22);
            this.buttonScreenPath.TabIndex = 18;
            this.buttonScreenPath.Text = "...";
            this.buttonScreenPath.UseVisualStyleBackColor = true;
            this.buttonScreenPath.Click += new System.EventHandler(this.ButtonScreenPathClick);
            // 
            // labelScreenClassStatus
            // 
            this.labelScreenClassStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelScreenClassStatus.AutoSize = true;
            this.labelScreenClassStatus.ForeColor = System.Drawing.Color.DimGray;
            this.labelScreenClassStatus.Location = new System.Drawing.Point(835, 29);
            this.labelScreenClassStatus.Name = "labelScreenClassStatus";
            this.labelScreenClassStatus.Size = new System.Drawing.Size(53, 17);
            this.labelScreenClassStatus.TabIndex = 19;
            this.labelScreenClassStatus.Text = "Статус";
            // 
            // labelListClassStatus
            // 
            this.labelListClassStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelListClassStatus.AutoSize = true;
            this.labelListClassStatus.ForeColor = System.Drawing.Color.DimGray;
            this.labelListClassStatus.Location = new System.Drawing.Point(835, 57);
            this.labelListClassStatus.Name = "labelListClassStatus";
            this.labelListClassStatus.Size = new System.Drawing.Size(53, 17);
            this.labelListClassStatus.TabIndex = 20;
            this.labelListClassStatus.Text = "Статус";
            // 
            // checkBoxScreenClassInstall
            // 
            this.checkBoxScreenClassInstall.Location = new System.Drawing.Point(903, 28);
            this.checkBoxScreenClassInstall.Name = "checkBoxScreenClassInstall";
            this.checkBoxScreenClassInstall.Size = new System.Drawing.Size(78, 24);
            this.checkBoxScreenClassInstall.TabIndex = 23;
            this.checkBoxScreenClassInstall.Text = "...";
            this.checkBoxScreenClassInstall.UseVisualStyleBackColor = true;
            // 
            // checkBoxListClassInstall
            // 
            this.checkBoxListClassInstall.Location = new System.Drawing.Point(903, 54);
            this.checkBoxListClassInstall.Name = "checkBoxListClassInstall";
            this.checkBoxListClassInstall.Size = new System.Drawing.Size(78, 24);
            this.checkBoxListClassInstall.TabIndex = 24;
            this.checkBoxListClassInstall.Text = "...";
            this.checkBoxListClassInstall.UseVisualStyleBackColor = true;
            // 
            // checkBoxTableInstall
            // 
            this.checkBoxTableInstall.Location = new System.Drawing.Point(900, 138);
            this.checkBoxTableInstall.Name = "checkBoxTableInstall";
            this.checkBoxTableInstall.Size = new System.Drawing.Size(78, 24);
            this.checkBoxTableInstall.TabIndex = 25;
            this.checkBoxTableInstall.Text = "...";
            this.checkBoxTableInstall.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageDataBaseManager);
            this.tabControl1.Controls.Add(this.tabPageFileUploader);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1006, 723);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPageDataBaseManager
            // 
            this.tabPageDataBaseManager.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageDataBaseManager.Controls.Add(this.treeViewMain);
            this.tabPageDataBaseManager.Controls.Add(this.checkBoxTableInstall);
            this.tabPageDataBaseManager.Controls.Add(this.labelListScreen);
            this.tabPageDataBaseManager.Controls.Add(this.checkBoxListClassInstall);
            this.tabPageDataBaseManager.Controls.Add(this.textBoxLIstScreenClassName);
            this.tabPageDataBaseManager.Controls.Add(this.checkBoxScreenClassInstall);
            this.tabPageDataBaseManager.Controls.Add(this.textBoxListViewClassName);
            this.tabPageDataBaseManager.Controls.Add(this.labelListClassStatus);
            this.tabPageDataBaseManager.Controls.Add(this.labelListView);
            this.tabPageDataBaseManager.Controls.Add(this.labelScreenClassStatus);
            this.tabPageDataBaseManager.Controls.Add(this.labelListScreenClassName);
            this.tabPageDataBaseManager.Controls.Add(this.buttonScreenPath);
            this.tabPageDataBaseManager.Controls.Add(this.textBoxListScreenPath);
            this.tabPageDataBaseManager.Controls.Add(this.labelStatusValue);
            this.tabPageDataBaseManager.Controls.Add(this.labelListScreenPath);
            this.tabPageDataBaseManager.Controls.Add(this.labelStatus);
            this.tabPageDataBaseManager.Controls.Add(this.textBoxTableName);
            this.tabPageDataBaseManager.Controls.Add(this.buttonInstall);
            this.tabPageDataBaseManager.Controls.Add(this.labelTableName);
            this.tabPageDataBaseManager.Location = new System.Drawing.Point(4, 25);
            this.tabPageDataBaseManager.Name = "tabPageDataBaseManager";
            this.tabPageDataBaseManager.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDataBaseManager.Size = new System.Drawing.Size(998, 694);
            this.tabPageDataBaseManager.TabIndex = 0;
            this.tabPageDataBaseManager.Text = "Database Manager";
            // 
            // tabPageFileUploader
            // 
            this.tabPageFileUploader.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageFileUploader.Controls.Add(this.buttonLoad);
            this.tabPageFileUploader.Controls.Add(this.listViewFiles);
            this.tabPageFileUploader.Controls.Add(this.buttonBrowseUploadFolder);
            this.tabPageFileUploader.Controls.Add(this.textBoxUploadFileFolder);
            this.tabPageFileUploader.Controls.Add(this.labelUploadFileFolder);
            this.tabPageFileUploader.Location = new System.Drawing.Point(4, 25);
            this.tabPageFileUploader.Name = "tabPageFileUploader";
            this.tabPageFileUploader.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFileUploader.Size = new System.Drawing.Size(998, 694);
            this.tabPageFileUploader.TabIndex = 1;
            this.tabPageFileUploader.Text = "File Uploader";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(892, 640);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(98, 46);
            this.buttonLoad.TabIndex = 23;
            this.buttonLoad.Text = "Загрузить выбранные";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.ButtonLoadClick);
            // 
            // listView1
            // 
            this.listViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFileName,
            this.columnHeaderFileSize,
            this.columnHeaderFilePath});
            this.listViewFiles.FullRowSelect = true;
            this.listViewFiles.Location = new System.Drawing.Point(8, 43);
            this.listViewFiles.Name = "listView1";
            this.listViewFiles.Size = new System.Drawing.Size(982, 591);
            this.listViewFiles.TabIndex = 22;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderFileName
            // 
            this.columnHeaderFileName.Text = "Имя файла";
            this.columnHeaderFileName.Width = 400;
            // 
            // columnHeaderFileSize
            // 
            this.columnHeaderFileSize.Text = "Размер КБ";
            this.columnHeaderFileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderFileSize.Width = 120;
            // 
            // columnHeaderFilePath
            // 
            this.columnHeaderFilePath.Text = "Путь";
            this.columnHeaderFilePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeaderFilePath.Width = 400;
            // 
            // buttonBrowseUploadFolder
            // 
            this.buttonBrowseUploadFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseUploadFolder.Location = new System.Drawing.Point(552, 15);
            this.buttonBrowseUploadFolder.Name = "buttonBrowseUploadFolder";
            this.buttonBrowseUploadFolder.Size = new System.Drawing.Size(30, 22);
            this.buttonBrowseUploadFolder.TabIndex = 21;
            this.buttonBrowseUploadFolder.Text = "...";
            this.buttonBrowseUploadFolder.UseVisualStyleBackColor = true;
            this.buttonBrowseUploadFolder.Click += new System.EventHandler(this.ButtonBrowseUploadFolderClick);
            // 
            // textBoxUploadFileFolder
            // 
            this.textBoxUploadFileFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUploadFileFolder.Enabled = false;
            this.textBoxUploadFileFolder.Location = new System.Drawing.Point(155, 15);
            this.textBoxUploadFileFolder.Name = "textBoxUploadFileFolder";
            this.textBoxUploadFileFolder.Size = new System.Drawing.Size(391, 22);
            this.textBoxUploadFileFolder.TabIndex = 19;
            // 
            // labelUploadFileFolder
            // 
            this.labelUploadFileFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUploadFileFolder.AutoSize = true;
            this.labelUploadFileFolder.ForeColor = System.Drawing.Color.DimGray;
            this.labelUploadFileFolder.Location = new System.Drawing.Point(26, 18);
            this.labelUploadFileFolder.Name = "labelUploadFileFolder";
            this.labelUploadFileFolder.Size = new System.Drawing.Size(82, 17);
            this.labelUploadFileFolder.TabIndex = 20;
            this.labelUploadFileFolder.Text = "Путь папки";
            // 
            // WorkHelperMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 723);
            this.Controls.Add(this.tabControl1);
            this.Name = "WorkHelperMainForm";
            this.Text = "CodeGenerator";
            this.Load += new System.EventHandler(this.CodeGeneratorFormLoad);
            this.tabControl1.ResumeLayout(false);
            this.tabPageDataBaseManager.ResumeLayout(false);
            this.tabPageDataBaseManager.PerformLayout();
            this.tabPageFileUploader.ResumeLayout(false);
            this.tabPageFileUploader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewMain;
        private System.Windows.Forms.Label labelListScreen;
        private System.Windows.Forms.TextBox textBoxLIstScreenClassName;
        private System.Windows.Forms.TextBox textBoxListViewClassName;
        private System.Windows.Forms.Label labelListView;
        private System.Windows.Forms.Label labelListScreenClassName;
        private System.Windows.Forms.TextBox textBoxListScreenPath;
        private System.Windows.Forms.Label labelListScreenPath;
        private System.Windows.Forms.Label labelTableName;
        private System.Windows.Forms.TextBox textBoxTableName;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelStatusValue;
        private System.Windows.Forms.Button buttonScreenPath;
        private System.Windows.Forms.Label labelScreenClassStatus;
        private System.Windows.Forms.Label labelListClassStatus;
        private System.Windows.Forms.CheckBox checkBoxScreenClassInstall;
        private System.Windows.Forms.CheckBox checkBoxListClassInstall;
        private System.Windows.Forms.CheckBox checkBoxTableInstall;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDataBaseManager;
        private System.Windows.Forms.TabPage tabPageFileUploader;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.ListView listViewFiles;
        private System.Windows.Forms.ColumnHeader columnHeaderFileName;
        private System.Windows.Forms.ColumnHeader columnHeaderFileSize;
        private System.Windows.Forms.ColumnHeader columnHeaderFilePath;
        private System.Windows.Forms.Button buttonBrowseUploadFolder;
        private System.Windows.Forms.TextBox textBoxUploadFileFolder;
        private System.Windows.Forms.Label labelUploadFileFolder;
    }
}

