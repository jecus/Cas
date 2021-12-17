using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Auxiliary;
using CASTerms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace CAS.UI.UIControls.WorkHelper
{
    ///<summary>
    /// Форма для генерации шаблонного кода и таблиц в БД
    ///</summary>
    public partial class WorkHelperMainForm : Form
    {
        //private const string DefaultNoInputText = "не задано";
        private ColumnError[] _columnErrors;
        private List<string> _fileNames = new List<string>();

        ///<summary>
        ///</summary>
        public WorkHelperMainForm()
        {
            InitializeComponent();
        }

        #region private string GetCASDirectoryPath()

        private string GetCASDirectoryPath()
        {
            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());
            while (d != null)
            {
                DirectoryInfo dir = d.GetDirectories().Where(f => f.Name.ToLower() == "uicontrols").FirstOrDefault();
                if (dir != null)
                {
                    return dir.FullName;
                }
                d = d.Parent;
            }
            return "";
        }
        #endregion

        #region private void CodeGeneratorFormLoad(object sender, EventArgs e)
        private void CodeGeneratorFormLoad(object sender, EventArgs e)
        {
            var assembly = Assembly.GetAssembly(typeof(SmartCore.Entities.General.BaseEntityObject));

            //var groups = assembly.GetModules()
            //  .SelectMany(module => module.GetTypes().OrderBy(type => type.Name))
            //  .GroupBy(type => type.Namespace)
            //  .OrderBy(group => group.Key);

            var types = assembly.GetTypes()
                .Where(t => t.Namespace != null && t.IsClass && t.Namespace.StartsWith("SmartCore.Entities"));
            
            List<Type> baseSmartCoreTypes = types.Where(type => type.IsSubclassOf(typeof(SmartCore.Entities.General.BaseEntityObject))).ToList();

            var groups = baseSmartCoreTypes.OrderBy(type => type.Name)
              .GroupBy(type => type.Namespace)
              .OrderBy(group => group.Key);

            foreach (var group in groups)
            {
                TreeNode n = new TreeNode(group.Key) {Tag = group};
                foreach (Type type in group)
                {
                    TreeNode subN = new TreeNode(type.Name){Tag = type};
                    n.Nodes.Add(subN);
                }
                
                treeViewMain.Nodes.Add(n);
            }
        }
        #endregion

        #region private void treeViewMain_AfterSelect(object sender, TreeViewEventArgs e)
        private void TreeViewMainAfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Tag == null || !(e.Node.Tag is Type))
            {
                textBoxLIstScreenClassName.Text
                    = textBoxListScreenPath.Text
                    = textBoxListViewClassName.Text
                    = textBoxTableName.Text = "";
                return;
            }

            Type type = (Type)e.Node.Tag;
            //Определение атрибута сохраняемой таблицы
            TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();

            if (dbTable != null)
            {
                textBoxTableName.Text = dbTable.TableName;
                try
                {
                    labelStatusValue.Text = "OK";
                    checkBoxTableInstall.Enabled = false;
                    checkBoxTableInstall.Text = "...";
                }
                catch (Exception ex)
                {
                    if (ex is DbTableAttributeException)
                    {
                        labelStatusValue.Text = "NC";
                        checkBoxTableInstall.Enabled = true;
                        checkBoxTableInstall.Text = "Create";
                    }

                    if (ex is DbTableColumnsAttributeException)
                    {
                        _columnErrors = ((DbTableColumnsAttributeException) ex).Errors;
                        labelStatusValue.Text = "Err";
                        checkBoxTableInstall.Enabled = true;
                        checkBoxTableInstall.Text = "Change";
                    }
                }
            }
            else textBoxTableName.Text = "";

            string path = GetCASDirectoryPath();
            textBoxLIstScreenClassName.Text = type.Name + "ListScreen.cs";
            textBoxListViewClassName.Text = type.Name + "ListView.cs";
            textBoxListScreenPath.Text = path;
        }
        #endregion

        #region private void ButtonInstallClick(object sender, EventArgs e)

        private void ButtonInstallClick(object sender, EventArgs e)
        {
            if (treeViewMain.SelectedNode.Tag == null || !(treeViewMain.SelectedNode.Tag is Type))
            {
                return;
            }

            Type type = (Type)treeViewMain.SelectedNode.Tag;

            #region Создание - изменение таблицы
            if (checkBoxTableInstall.Checked)
            {
                //Определение атрибута сохраняемой таблицы
                TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();

                if (dbTable == null || dbTable.TableName == "")
                {
                    //Если отсутствует атрибут таблицы, в которую сохраняются 
                    //экземпляры данного типа или имя таблицы не задано, то 
                    //кидается исключение
                    MessageBox.Show("у типа " + type.GetType() +
                                    @" отсутвует атрибут TableAttribute в описании класса 
                                     или в этом атрибуте не задано имя таблицы в БД", "Ошибка", MessageBoxButtons.OK);
                    return;
                }

                try
                {
                    MessageBox.Show(
                        "Таблица " + dbTable.TableScheme + "." + dbTable.TableName + " полностью соответсввует типу "
                                   + type.Name, "Сообщение", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    if (ex is DbTableAttributeException)
                    {
                        if (MessageBox.Show(ex.Message + "\nСоздать таблицу? ", "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Error) != DialogResult.Yes)
                            return;
                    }

                    if (ex is DbTableColumnsAttributeException)
                    {
                        if (MessageBox.Show(ex.Message + "\nИзменить таблицу? ", "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Error) != DialogResult.Yes)
                            return;
                    }

                    try
                    {
                        MessageBox.Show(
                        "Таблица " + dbTable.TableScheme + "." + dbTable.TableName + " полностью соответсввует типу "
                                   + type.Name, "Сообщение", MessageBoxButtons.OK);
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.Message + "\n" + excep.InnerException, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            #endregion
            
            if(checkBoxListClassInstall.Checked)
            {
                    
            }
        }
        #endregion

        #region private void ButtonScreenPathClick(object sender, EventArgs e)
        private void ButtonScreenPathClick(object sender, EventArgs e)
        {
            if (treeViewMain.SelectedNode.Tag == null || !(treeViewMain.SelectedNode.Tag is Type))
            {
                return;
            }

            FolderBrowserDialog fbd = new FolderBrowserDialog
                                          {
                                              Description = "Выбор папки для сохранения файлов"
                                          };
            if(textBoxListScreenPath.Text != "")
            {
                fbd.SelectedPath = textBoxListScreenPath.Text;
            }

            if (fbd.ShowDialog() == DialogResult.OK) textBoxListScreenPath.Text = fbd.SelectedPath;

            
        }
        #endregion

        #region private void buttonLoad_Click(object sender, EventArgs e)

        private void ButtonLoadClick(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem listViewItem in listViewFiles.SelectedItems)
                {
                    AttachedFile file = new AttachedFile();
                    file.FileData = UsefulMethods.GetByteArrayFromFile(listViewItem.SubItems[2].Text);
                    file.FileName = listViewItem.SubItems[0].Text;
                    file.FileSize = file.FileData.Length;

                    GlobalObjects.NewKeeper.Save(file);
                }
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while save attached file", ex);
            }
        }
        #endregion

        #region private void ButtonBrowseUploadFolderClick(object sender, EventArgs e)

        private void ButtonBrowseUploadFolderClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Adobe PDF Files|*.pdf";
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _fileNames.AddRange(ofd.FileNames);

                foreach (string fullFileName in ofd.FileNames)
                {
                    string fileName = fullFileName.Substring(fullFileName.LastIndexOf('\\') + 1);
                    listViewFiles.Items.Add(new ListViewItem(new[] { fileName, "", fullFileName}) { Tag = fullFileName });
                }
            }
        }
        #endregion
    }
}
