using System;
using System.Drawing;
using System.Windows.Forms;

namespace CAS.UI
{
    ///<summary>
    /// Форма для просмотра структуры отображаемого контрола в время выполнения
    ///</summary>
    public partial class FindForm : Form
    {
        private Form form;

        private Control _selectItemControl;

        ///<summary>
        ///</summary>
        ///<param name="form"></param>
        public FindForm(Form form)
        {
            this.form = form;
            InitializeComponent();
        }

        private static TreeNode FillRecursive(Control control)
        {
            string name = control.Name;
            if (name=="")
            {
                name = "name is null";
            }
            TreeNode treeNode = new TreeNode(name) { Tag = control };
            foreach (Control tn in control.Controls)
            {
                treeNode.Nodes.Add(FillRecursive(tn));
            }
            return treeNode;
        }

        private void FillTreeView()
        {
            treeViewControl.Nodes.Add(FillRecursive(form));
        }

        void SetScreenControl(Control control)
        {
            if (control == null)
            {
                return;
            }

            try
            {
                Bitmap bitmap = new Bitmap(control.Width, control.Height);

                control.DrawToBitmap(bitmap, new Rectangle(0, 0, control.Width, control.Height));
                pictureBoxShowControl.Image = bitmap;
            }
            catch
            {
            }

        }

        private void FindFormLoad(object sender, EventArgs e)
        {
            FillTreeView();
        }
        
        private void TreeViewControlAfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeViewControl.SelectedNode.Tag == null)
            {
                return;
            }
            Control control = ((Control)treeViewControl.SelectedNode.Tag);
            SetScreenControl(control);
            _selectItemControl = ((Control) treeViewControl.SelectedNode.Tag);
            

            labelClass.Text= control.GetType().FullName;
            labelLocation.Text = control.Location.ToString();
            labelSize.Text = control.Size.ToString();
            textBoxName.Text=control.Name;
        }

        private void TimerRefrTick(object sender, EventArgs e)
        {
            if (checkBoxUpdate.Checked)
            {
               SetScreenControl(_selectItemControl); 
            }
            
        }

        private void Button1Click(object sender, EventArgs e)
        {
            treeViewControl.Nodes.Clear();
            FillTreeView();
        }

        private void CheckBoxZoomCheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxZoom.Checked)
            {
                pictureBoxShowControl.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                pictureBoxShowControl.SizeMode = PictureBoxSizeMode.Normal;
            }
        }
    }
}
