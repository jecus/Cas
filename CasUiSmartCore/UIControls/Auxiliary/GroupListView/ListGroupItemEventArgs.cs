using System;
using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary.GroupListView
{
    public class ListGroupItemEventArgs : EventArgs
    {
        public ListGroupItemEventArgs(ListViewItem Item)
        {
            this.Item = Item;
        }


        public ListGroupItemEventArgs(ListViewItem[] Items)
        {
            this.Items = Items;
        }


        public ListViewItem Item { get; set; }
        public ListViewItem[] Items { get; set; }
    }

    class ListGroupEventArgs : System.EventArgs
    {
        public ListGroupEventArgs(ListGroup ListGroup)
        {

        }


        public ListGroup ListGroup { get; set; }
    }

    public class ListGroupColumnEventArgs : EventArgs
    {
        public ListGroupColumnEventArgs(int Columnindex)
        {
            this.ColumnIndex = ColumnIndex;
        }

        public int ColumnIndex { get; set; }
    }
}
