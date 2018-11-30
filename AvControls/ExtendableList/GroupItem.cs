#region

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace AvControls.ExtendableList
{
    public class GroupItem : PictureBox
    {
        private IContainer components;
        private List<IExtendableItem> listExtendableItem;

        public GroupItem()
        {
            InitializeComponent();
            listExtendableItem = new List<IExtendableItem>();
        }

        public List<IExtendableItem> ItemList
        {
            get { return listExtendableItem; }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
        }
    }
}