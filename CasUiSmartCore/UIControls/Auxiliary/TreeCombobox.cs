using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CAS.UI.UIControls.Auxiliary
{
    /// <summary>
    /// Древовидный комбобокс
    /// </summary>
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    [Designer(typeof(TreeComboboxDesigner))]
    public partial class TreeCombobox : ComboBox
    {
        private const int WM_USER = 0x0400,
                  WM_REFLECT = WM_USER + 0x1C00,
                  WM_COMMAND = 0x0111,
                  CBN_DROPDOWN = 7;

        private ToolStripControlHost treeViewHost;

        #region Properties

        #region public TreeNodeCollection Nodes
        /// <summary>
        /// Дерево для добавления элементов
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TreeNodeCollection Nodes
        {
            get { return treeView.Nodes; }
        }
        #endregion

        #region public new object SelectedItem
        /// <summary>
        /// Возвращает или задает выбранный элемент
        /// </summary>
        public new object SelectedItem
        {
            get
            {
                if (treeView.SelectedNode == null)
                    return null;
                if (treeView.SelectedNode.Tag == null && treeView.SelectedNode.Text == "N/A")
                    return treeView.SelectedNode.Text;
                return treeView.SelectedNode.Tag;
            }
            set
            {
                if (value == null) treeView.SelectedNode = null;
                else
                {
                    string s = value.ToString();
                    TreeNode[] findNodes = treeView.Nodes.Find(s, true);
                    TreeNode node = findNodes.FirstOrDefault(n => n.Tag != null && n.Tag.Equals(value));
                    treeView.SelectedNode = node;

                    Text = treeView.SelectedNode != null ? treeView.SelectedNode.Text : "";
                }
            }
        }
        #endregion

        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public TreeCombobox()
        {
            InitializeComponent();
            treeViewHost = new ToolStripControlHost(treeView);
            dropDown.Items.Add(treeViewHost);
        }

        #endregion

        #region Methods

        #region protected override void OnMouseWheel(MouseEventArgs e)

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (treeView.SelectedNode == null)
            {
                if (treeView.Nodes.Count != 0)
                {
                    treeView.SelectedNode = treeView.Nodes[0];
                }
            }
            else
            {
                if (e.Delta < 0)
                {
                    //прокрутка идет вниз
                    if (treeView.SelectedNode.Nodes.Count > 0)
                    {
                        //Если у выбранного узла есть подузлы - осуществляется переход на первый подузел
                        treeView.SelectedNode = treeView.SelectedNode.Nodes[0];
                    }
                    else
                    {
                        //У выбранного узла подузлов нет
                        if (treeView.SelectedNode.NextNode != null)
                        {
                            //Если есть след. узел на этом уровне - переход на него
                            treeView.SelectedNode = treeView.SelectedNode.NextNode;
                        }
                        else
                        {
                            //На данном уровне след. узла нет.
                            TreeNode parent = treeView.SelectedNode.Parent;

                            while (parent != null)
                            {
                                //Переход вверх по дереву до тех пор, пока на уровне не появится след.узел
                                //переход на след. узел на верхнем уровне
                                if (parent.NextNode != null)
                                {
                                    treeView.SelectedNode = parent.NextNode;
                                    break;
                                }
                                parent = parent.Parent;
                            }
                        }
                    }
                }
                else if (e.Delta > 0)
                {
                    //прокрутка идет вверх
                    if (treeView.SelectedNode.PrevNode != null)
                    {
                        TreeNode node = treeView.SelectedNode.PrevNode;
                        while (node != null)
                        {
                            //Переход вниз по дереву до тех пор, пока на уровне не появится пустой узел
                            //переход на след. узел на верхнем уровне
                            if (node.Nodes.Count == 0)
                            {
                                break;
                            }
                            node = node.Nodes[node.Nodes.Count - 1];
                        }
                        //Если есть пустой узел на этом уровне - переход на него
                        treeView.SelectedNode = node;
                    }
                    else
                    {
                        //На данном уровне пред. узла нет.
                        if (treeView.SelectedNode.Parent != null)
                            treeView.SelectedNode = treeView.SelectedNode.Parent;
                    }
                }
            }

            Text = treeView.SelectedNode != null ? treeView.SelectedNode.Text : "";

            base.OnMouseWheel(e);

            InvokeSelectedIndexChanged();
        }

        #endregion

        #region protected override void WndProc(ref Message m)

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (WM_REFLECT + WM_COMMAND))
            {
                if (HIWORD((int)m.WParam) == CBN_DROPDOWN)
                {
                    ShowDropDown();
                    return;
                }
            }
            base.WndProc(ref m);
        }

        #endregion

        #region private void ShowDropDown()

        private void ShowDropDown()
        {
            if (dropDown != null)
            {
                treeView.Width = DropDownWidth;
                treeView.Height = DropDownHeight;
                treeViewHost.Width = DropDownWidth;
                treeViewHost.Height = DropDownHeight;
                dropDown.Show(this, 0, Height);
                treeView.Focus();
            }
        }
        #endregion

        #region private static int HIWORD(int n)
        ///<summary>
        /// Преобразует младщее слово в старшее слово
        ///</summary>
        ///<param name="n"></param>
        ///<returns></returns>
        private static int HIWORD(int n)
        {
            return (n >> 16) & 0xffff;
        }

        #endregion

        #region private void TreeViewNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)

        private void TreeViewNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Text = treeView.SelectedNode.Text;

            dropDown.Hide();

            InvokeSelectedIndexChanged();
        }
        #endregion

        #endregion

        #region Events

        #region public new event EventHandler SelectedIndexChanged
        ///<summary>
        /// Происходит во время изменения выбранного элемента
        ///</summary>
        [Category("Value changed")]
        [Description("Возникает при изменении выбора в элементе управления")]
        public new event EventHandler SelectedIndexChanged;

        ///<summary>
        /// Сигнализирует об изменении выбора в элементе управления
        ///</summary>
        private void InvokeSelectedIndexChanged()
        {
            EventHandler handler = SelectedIndexChanged;
            if (handler != null) handler(this, new EventArgs());
        }

        #endregion

        #endregion
    }

    internal class TreeComboboxDesigner : ControlDesigner
    {
        protected override void PostFilterProperties(IDictionary properties)
        {
            base.PostFilterProperties(properties);
            properties.Remove("Items");
            properties.Remove("SelectedItem");
            properties.Remove("Text");
        }

        public override SelectionRules SelectionRules
        {
            get { return base.SelectionRules & ~(SelectionRules.BottomSizeable | SelectionRules.TopSizeable); }
        }
    }
}
