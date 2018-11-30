#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace AvControls.ExtendableList
{
    [ToolboxItem(false)]
    public class ExtendableList : AvLayoutPanel
    {
        private const int PAGE_MOVE_COUNT = 5;
        private IContainer components;
        private Control controlHeaderItem;
        private List<IExtendableItem> extendableItemList;
        private IExtendableItem extendedItem;

        public ExtendableList()
        {
            InitializeComponent();
            extendableItemList = new List<IExtendableItem>();
            controlHeaderItem = new Control();
            base.SuspendLayout();
            base.ResumeLayout(false);
        }

        protected IExtendableItem ExtendedItem
        {
            get { return extendedItem; }
        }

        protected List<IExtendableItem> ItemList
        {
            get { return extendableItemList; }
        }

        protected void Add(IExtendableItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (!(item is Control))
            {
                throw new ArgumentException("Cannot add not control item", "item");
            }
            item.Extended += item_Extended;
            extendableItemList.Add(item);
            base.Controls.Add(item as Control);
            CheckChildControls(item as Control);
        }

        protected void AddGroupItem(GroupItem groupItem)
        {
            if (groupItem == null)
            {
                throw new ArgumentNullException("groupItem");
            }
            base.Controls.Add(groupItem);
            foreach (IExtendableItem item in groupItem.ItemList)
            {
                CheckChildControls(item as Control);
                extendableItemList.Add(item);
                base.Controls.Add(item as Control);
                item.Extended += item_Extended;
            }
        }

        protected void AddHeaderItem(Control headerItem)
        {
            if (headerItem == null)
            {
                throw new ArgumentNullException("headerItem");
            }
            controlHeaderItem = headerItem;
            if (base.Controls.Count != 0)
            {
                base.Controls.Clear();
                base.Controls.Add(controlHeaderItem);
            }
        }

        protected virtual void AdjustSize()
        {
            int num = 0;
            foreach (Control control in base.Controls)
            {
                control.Width = base.Width;
                num += control.Height;
            }
            base.Height = num;
        }

        private void CheckChildControls(Control control)
        {
            if (control.Controls != null)
            {
                foreach (Control control2 in control.Controls)
                {
                    control2.PreviewKeyDown -= Item_PreviewKeyDown;
                    control2.PreviewKeyDown += Item_PreviewKeyDown;
                    CheckChildControls(control2);
                }
            }
        }

        protected void Clear()
        {
            extendableItemList.Clear();
            base.Controls.Clear();
            if (controlHeaderItem != null)
            {
                base.Controls.Add(controlHeaderItem);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if ((disposing && (components != null)) && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.ResumeLayout(false);
        }

        private void item_Extended(object sender, EventArgs e)
        {
            if ((extendedItem != null) && (extendedItem != (sender as IExtendableItem)))
            {
                extendedItem.SetShortView();
            }
            extendedItem = sender as IExtendableItem;
            AdjustSize();
            if (((Control) extendedItem).Controls.Count > 1)
            {
                ((Control) extendedItem).Controls[0].Focus();
            }
        }

        private void Item_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            OnPreviewKeyDown(e);
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            int index = extendableItemList.IndexOf(extendedItem);
            e.IsInputKey = true;
            switch (e.KeyCode)
            {
                case Keys.Prior:
                    if ((index - 5) < 0)
                    {
                        extendableItemList[0].SetExtendedView();
                        break;
                    }
                    extendableItemList[index - 5].SetExtendedView();
                    break;

                case Keys.Next:
                    if ((index + 5) > (extendableItemList.Count - 2))
                    {
                        extendableItemList[extendableItemList.Count - 1].SetExtendedView();
                        break;
                    }
                    extendableItemList[index + 5].SetExtendedView();
                    break;

                case Keys.End:
                    extendableItemList[extendableItemList.Count - 1].SetExtendedView();
                    break;

                case Keys.Home:
                    extendableItemList[0].SetExtendedView();
                    break;

                case Keys.Up:
                    if (index >= 1)
                    {
                        extendableItemList[index - 1].SetExtendedView();
                    }
                    break;

                case Keys.Down:
                    if (index <= (extendableItemList.Count - 2))
                    {
                        extendableItemList[index + 1].SetExtendedView();
                    }
                    break;
            }
            base.OnPreviewKeyDown(e);
        }
    }
}