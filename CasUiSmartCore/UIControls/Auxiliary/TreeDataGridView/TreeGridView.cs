//---------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CAS.UI.UIControls.Auxiliary.TreeDataGridView
{
	/// <summary>
	/// Summary description for TreeGridView.
	/// </summary>
    [DesignerCategory("code"),
     Designer(typeof(System.Windows.Forms.Design.ControlDesigner)),
	 ComplexBindingProperties,
     Docking(DockingBehavior.Ask)]
	public class TreeDataGridView: DataGridView
    {
        #region Fields

        private int _indentWidth;
	    private bool _disposing;
		private TreeDataGridViewRow _root;
		private TreeDataGridViewTextBoxColumn _expandableColumn;
	    private ImageList _imageList;
		private bool _inExpandCollapse;
        internal bool _inExpandCollapseMouseCapture;
		private Control _hideScrollBarControl;
        private bool _showLines = true;
	    private bool _showGroups;
	    private DataGridViewGroupCollection _groups;
        private ListViewGroup group = new ListViewGroup();
        private bool _virtualNodes;

		internal VisualStyleRenderer rOpen = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Opened);
		internal VisualStyleRenderer rClosed = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Closed);

        #endregion

        #region Properties

        private Image iconCollapse;
        [Category("Appearance")]
        public Image CollapseIcon
        {
            get { return iconCollapse; }
            set { iconCollapse = value; }
        }

        private Image iconExpand;
        [Category("Appearance")]
        public Image ExpandIcon
        {
            get { return iconExpand; }
            set { iconExpand = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public TreeDataGridView()
		{
            _groups = new DataGridViewGroupCollection(this);
			// Control when edit occurs because edit mode shouldn't start when expanding/collapsing
			//this.EditMode = DataGridViewEditMode.EditProgrammatically;
            RowTemplate = new TreeDataGridViewRow();
			// This sample does not support adding or deleting rows by the user.
			AllowUserToAddRows = false;
			AllowUserToDeleteRows = false;
			_root = new TreeDataGridViewRow(this);
			_root.IsRoot = true;

			// Ensures that all rows are added unshared by listening to the CollectionChanged event.
			base.Rows.CollectionChanged += delegate {};
        }
        #endregion

        #region Keyboard F2 to begin edit support
        protected override void OnKeyDown(KeyEventArgs e)
		{
			// Cause edit mode to begin since edit mode is disabled to support 
			// expanding/collapsing 
			base.OnKeyDown(e);
			if (!e.Handled)
			{
				if (e.KeyCode == Keys.F2 && CurrentCellAddress.X > -1 && CurrentCellAddress.Y >-1)
				{
					if (!CurrentCell.Displayed)
					{
						FirstDisplayedScrollingRowIndex = CurrentCellAddress.Y;
					}
					else
					{
						// TODO:calculate if the cell is partially offscreen and if so scroll into view
					}
					SelectionMode = DataGridViewSelectionMode.CellSelect;
					BeginEdit(true);
				}
				else if (e.KeyCode == Keys.Enter && !IsCurrentCellInEditMode)
				{
					SelectionMode = DataGridViewSelectionMode.FullRowSelect;
					CurrentCell.OwningRow.Selected = true;
				}
			}
        }
        #endregion

        #region Shadow and hide DGV properties

        // This sample does not support databinding
		[Browsable(false),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		EditorBrowsable(EditorBrowsableState.Never)]
		public new object DataSource
		{
			get { return null; }
			set { throw new NotSupportedException("The TreeGridView does not support databinding"); }
		}

		[Browsable(false),
	    DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		EditorBrowsable(EditorBrowsableState.Never)]
		public new object DataMember
		{
			get { return null; }
			set { throw new NotSupportedException("The TreeGridView does not support databinding"); }
		}

        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
		EditorBrowsable(EditorBrowsableState.Never)]
        public new DataGridViewRowCollection Rows
        {
            get { return base.Rows; }
        }

        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        public new bool VirtualMode
        {
            get { return false; }
            set { throw new NotSupportedException("The TreeGridView does not support virtual mode"); }
        }

        // none of the rows/nodes created use the row template, so it is hidden.
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        public new DataGridViewRow RowTemplate
        {
            get { return base.RowTemplate; }
            set { base.RowTemplate = value; }
        }

        #endregion

        #region Public methods
        [Description("Returns the TreeGridNode for the given DataGridViewRow")]
        public TreeDataGridViewRow GetNodeForRow(DataGridViewRow row)
        {
            return row as TreeDataGridViewRow;
        }

        [Description("Returns the TreeGridNode for the given DataGridViewRow")]
        public TreeDataGridViewRow GetNodeForRow(int index)
        {
            return GetNodeForRow(base.Rows[index]);
        }
        #endregion

        #region Public properties
        [Category("Data"),
		 Description("The collection of root nodes in the treelist."),
		 DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		 Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
		public TreeDataGridViewRowCollection Nodes
		{
			get
			{
				return _root.Nodes;
			}
		}

		public new TreeDataGridViewRow CurrentRow
		{
			get
			{
				return base.CurrentRow as TreeDataGridViewRow;
			}
		}

        [DefaultValue(false),
        Description("Causes nodes to always show as expandable. Use the NodeExpanding event to add nodes.")]
        public bool VirtualNodes
        {
            get { return _virtualNodes; }
            set { _virtualNodes = value; }
        }
	
		public TreeDataGridViewRow CurrentNode
		{
			get
			{
				return this.CurrentRow;
			}
		}

        #region public bool ShowLines
        /// <summary>
        /// Отображать линии сетки
        /// </summary>
        [DefaultValue(true)]
        public bool ShowLines
        {
            get { return _showLines; }
            set 
            { 
                if (value != _showLines) 
                {
                    _showLines = value;
                    Invalidate();
                } 
            }
        }
        #endregion

        #region public bool ShowGroups
        /// <summary>
        /// Отображать группы
        /// </summary>
        [DefaultValue(false)]
        public bool ShowGroups
        {
            get { return _showGroups; }
            set
            {
                if (value != _showGroups)
                {
                    _showGroups = value;
                    Invalidate();
                }
            }
        }
        #endregion

        #region public DataGridViewGroupCollection Groups
        /// <summary>
        /// Отображать группы
        /// </summary>
        [DefaultValue(false)]
        public DataGridViewGroupCollection Groups
        {
            get { return _groups ?? (_groups = new DataGridViewGroupCollection(this)); }
        }
        #endregion

        #region public ImageList ImageList
        /// <summary>
        /// Возвращает или задает коллекцию изображений данного контрола
        /// </summary>
        public ImageList ImageList
		{
			get { return this._imageList; }
			set 
            {
                _imageList = value; 
				//TODO: should we invalidate cell styles when setting the image list?
			}
		}
        #endregion

        public new int RowCount
        {
            get { return this.Nodes.Count; }
            set
            {
                for (int i = 0; i < value; i++)
                    this.Nodes.Add(new TreeDataGridViewRow());

            }
        }
        #endregion

        #region Site nodes and collapse/expand support
        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            base.OnRowsAdded(e);
            // Notify the row when it is added to the base grid 
            int count = e.RowCount - 1;
            TreeDataGridViewRow row;
            while (count >= 0)
            {
                row = base.Rows[e.RowIndex + count] as TreeDataGridViewRow;
                if (row != null)
                {
                    row.Sited();
                }
                count--;
            }
        }

		internal protected void UnSiteAll()
		{
			this.UnSiteNode(this._root);
		}

		internal protected virtual void UnSiteNode(TreeDataGridViewRow node)
		{
            if (node.IsSited || node.IsRoot)
			{
				// remove child rows first
				foreach (TreeDataGridViewRow childNode in node.Nodes)
				{
					this.UnSiteNode(childNode);
				    
                    childNode.Grid = null;
				    childNode.Owner = null;
				    childNode.Index = -1;
				}

				// now remove this row except for the root
				if (!node.IsRoot)
				{
					base.Rows.Remove(node);
					// Row isn't sited in the grid anymore after remove. Note that we cannot
					// Use the RowRemoved event since we cannot map from the row index to
					// the index of the expandable row/node.
					node.UnSited();
				}
			}
		}

        //protected override void OnCellDoubleClick(DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        TreeDataGridViewRow row = base.Rows[e.RowIndex] as TreeDataGridViewRow;
        //        if (row != null && row.IsGroupRow)
        //        {
        //            row.Grid._inExpandCollapseMouseCapture = true;
        //            if (row.IsExpanded)
        //                CollapseNode(row);
        //            else
        //                ExpandNode(row);
        //        }
        //    }
        //    base.OnCellClick(e);
        //}

        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TreeDataGridViewRow row = base.Rows[e.RowIndex] as TreeDataGridViewRow;
                if (row != null && row.IsGroupRow)
                {
                    row.Grid._inExpandCollapseMouseCapture = true;
                    if (row.IsExpanded)
                        CollapseNode(row);
                    else
                        ExpandNode(row);
                }
            }
            base.OnCellClick(e);
        }

		internal protected virtual bool CollapseNode(TreeDataGridViewRow node)
		{
			if (node.IsExpanded)
			{
				CollapsingEventArgs exp = new CollapsingEventArgs(node);
				this.OnNodeCollapsing(exp);

				if (!exp.Cancel)
				{
					this.LockVerticalScrollBarUpdate(true);
                    this.SuspendLayout();
                    _inExpandCollapse = true;
                    node.IsExpanded = false;

					foreach (TreeDataGridViewRow childNode in node.Nodes)
					{
						Debug.Assert(childNode.RowIndex != -1, "Row is NOT in the grid.");
						this.UnSiteNode(childNode);
					}

					CollapsedEventArgs exped = new CollapsedEventArgs(node);
					this.OnNodeCollapsed(exped);
					//TODO: Convert this to a specific NodeCell property
                    _inExpandCollapse = false;
                    this.LockVerticalScrollBarUpdate(false);
                    this.ResumeLayout(true);
                    this.InvalidateCell(node.Cells[0]);

				}

				return !exp.Cancel;
			}
			else
			{
				// row isn't expanded, so we didn't do anything.				
				return false;
			}
		}

		internal protected virtual void SiteNode(TreeDataGridViewRow node)
		{
			//TODO: Raise exception if parent node is not the root or is not sited.
			int rowIndex = -1;
			TreeDataGridViewRow currentRow;
			node.Grid = this;

			if (node.Parent != null && node.Parent.IsRoot == false)
			{
				// row is a child
				Debug.Assert(node.Parent != null && node.Parent.IsExpanded == true);

				if (node.Index > 0)
				{
					currentRow = node.Parent.Nodes[node.Index - 1];
				}
				else
				{
					currentRow = node.Parent;
				}
			}
			else
			{
				// row is being added to the root
				if (node.Index > 0)
				{
					currentRow = node.Parent.Nodes[node.Index - 1];
				}
				else
				{
					currentRow = null;
				}

			}

			if (currentRow != null)
			{
				while (currentRow.Level >= node.Level)
				{
					if (currentRow.RowIndex < base.Rows.Count - 1)
					{
						currentRow = base.Rows[currentRow.RowIndex + 1] as TreeDataGridViewRow;
						Debug.Assert(currentRow != null);
					}
					else
						// no more rows, site this node at the end.
						break;

				}
				if (currentRow == node.Parent)
					rowIndex = currentRow.RowIndex + 1;
				else if (currentRow.Level < node.Level)
					rowIndex = currentRow.RowIndex;
				else
					rowIndex = currentRow.RowIndex + 1;
			}
			else
				rowIndex = 0;


			Debug.Assert(rowIndex != -1);
			this.SiteNode(node, rowIndex);

			Debug.Assert(node.IsSited);
			if (node.IsExpanded)
			{
				// add all child rows to display
				foreach (TreeDataGridViewRow childNode in node.Nodes)
				{
					//TODO: could use the more efficient SiteRow with index.
					this.SiteNode(childNode);
				}
			}
		}


		internal protected virtual void SiteNode(TreeDataGridViewRow node, int index)
		{
			if (index < base.Rows.Count)
			{
				base.Rows.Insert(index, node);
			}
			else
			{
				// for the last item.
				base.Rows.Add(node);
			}
		}

		internal protected virtual bool ExpandNode(TreeDataGridViewRow node)
		{
            if (!node.IsExpanded || this._virtualNodes)
			{
				ExpandingEventArgs exp = new ExpandingEventArgs(node);
				this.OnNodeExpanding(exp);

				if (!exp.Cancel)
				{
					this.LockVerticalScrollBarUpdate(true);
                    this.SuspendLayout();
                    _inExpandCollapse = true;
                    node.IsExpanded = true;

					//TODO Convert this to a InsertRange
					foreach (TreeDataGridViewRow childNode in node.Nodes)
					{
						Debug.Assert(childNode.RowIndex == -1, "Row is already in the grid.");

						this.SiteNode(childNode);
						//this.BaseRows.Insert(rowIndex + 1, childRow);
						//TODO : remove -- just a test.
						//childNode.Cells[0].Value = "child";
					}

					ExpandedEventArgs exped = new ExpandedEventArgs(node);
					this.OnNodeExpanded(exped);
					//TODO: Convert this to a specific NodeCell property
                    _inExpandCollapse = false;
                    this.LockVerticalScrollBarUpdate(false);
                    this.ResumeLayout(true);
                    this.InvalidateCell(node.Cells[0]);
				}

				return !exp.Cancel;
			}
			else
			{
				// row is already expanded, so we didn't do anything.
				return false;
			}
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            // used to keep extra mouse moves from selecting more rows when collapsing
            base.OnMouseUp(e);
            _inExpandCollapseMouseCapture = false;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // while we are expanding and collapsing a node mouse moves are
            // supressed to keep selections from being messed up.
            if (!_inExpandCollapseMouseCapture)
                base.OnMouseMove(e);

        }
        #endregion

        #region Collapse/Expand events

        public event ExpandingEventHandler NodeExpanding;
        public event ExpandedEventHandler NodeExpanded;
        public event CollapsingEventHandler NodeCollapsing;
        public event CollapsedEventHandler NodeCollapsed;

        protected virtual void OnNodeExpanding(ExpandingEventArgs e)
        {
            if (this.NodeExpanding != null)
            {
                NodeExpanding(this, e);
            }
        }
        protected virtual void OnNodeExpanded(ExpandedEventArgs e)
        {
            if (this.NodeExpanded != null)
            {
                NodeExpanded(this, e);
            }
        }
        protected virtual void OnNodeCollapsing(CollapsingEventArgs e)
        {
            if (this.NodeCollapsing != null)
            {
                NodeCollapsing(this, e);
            }

        }
        protected virtual void OnNodeCollapsed(CollapsedEventArgs e)
        {
            if (this.NodeCollapsed != null)
            {
                NodeCollapsed(this, e);
            }
        }
        #endregion

        #region Helper methods
        protected override void Dispose(bool disposing)
        {
            this._disposing = true;
            base.Dispose(Disposing);
            this.UnSiteAll();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // this control is used to temporarly hide the vertical scroll bar
            _hideScrollBarControl = new Control();
            _hideScrollBarControl.Visible = false;
            _hideScrollBarControl.Enabled = false;
            _hideScrollBarControl.TabStop = false;
            // control is disposed automatically when the grid is disposed
            this.Controls.Add(_hideScrollBarControl);
        }

        protected override void OnRowEnter(DataGridViewCellEventArgs e)
        {
            // ensure full row select
            base.OnRowEnter(e);
            if (this.SelectionMode == DataGridViewSelectionMode.CellSelect ||
                (this.SelectionMode == DataGridViewSelectionMode.FullRowSelect &&
                base.Rows[e.RowIndex].Selected == false))
            {
                this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                base.Rows[e.RowIndex].Selected = true;
            }
        }
        
		private void LockVerticalScrollBarUpdate(bool lockUpdate/*, bool delayed*/)
		{
            // Temporarly hide/show the vertical scroll bar by changing its parent
            if (!this._inExpandCollapse)
            {
                if (lockUpdate)
                {
                    this.VerticalScrollBar.Parent = _hideScrollBarControl;
                }
                else
                {
                    this.VerticalScrollBar.Parent = this;
                }
            }
        }

        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            if (typeof(TreeDataGridViewTextBoxColumn).IsAssignableFrom(e.Column.GetType()))
            {
                if (_expandableColumn == null)
                {
                    // identify the expanding column.			
                    _expandableColumn = (TreeDataGridViewTextBoxColumn)e.Column;
                }
                else
                {
                   // this.Columns.Remove(e.Column);
                    //throw new InvalidOperationException("Only one TreeGridColumn per TreeGridView is supported.");
                }
            }

            //// Expandable Grid doesn't support sorting. This is just a limitation of the sample.
            //e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;

            base.OnColumnAdded(e);
        }

        private static class Win32Helper
        {
            public const int WM_SYSKEYDOWN = 0x0104,
                             WM_KEYDOWN = 0x0100,
                             WM_SETREDRAW = 0x000B;

            [System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern IntPtr SendMessage(System.Runtime.InteropServices.HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);

            [System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern IntPtr SendMessage(System.Runtime.InteropServices.HandleRef hWnd, int msg, int wParam, int lParam);

            [System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern bool PostMessage(System.Runtime.InteropServices.HandleRef hwnd, int msg, IntPtr wparam, IntPtr lparam);

        }
        #endregion


    }
}
