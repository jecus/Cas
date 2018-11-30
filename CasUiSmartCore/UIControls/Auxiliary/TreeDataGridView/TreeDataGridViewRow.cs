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
using System.Text;
using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary.TreeDataGridView
{
	/// <summary>
	/// Описывает Древовидную строку
	/// </summary>
	[ToolboxItem(false), DesignTimeVisible(false)]
    public class TreeDataGridViewRow : DataGridViewRow//, IComponent
    {
        #region Fields

        internal TreeDataGridView Grid;
	    private TreeDataGridViewRow _parent;
		internal TreeDataGridViewRowCollection Owner;
        internal bool IsExpanded;
		internal bool IsRoot;
        internal bool IsGroupRow;
	    private bool _isSited;
	    private bool _isFirstSibling;
	    private bool _isLastSibling;
	    private Image _image;
	    private int _imageIndex;
	    private DataGridViewGroup _group;

        private TreeDataGridViewTextBoxCell _treeCell;
        private TreeDataGridViewRowCollection _childrenNodes;

		private int _index;
		private int _level;
		private bool _childCellsCreated;

		// needed for IComponent
		private ISite _site;
		private EventHandler _disposed;

        #endregion

        #region internal TreeDataGridViewRow(TreeGridView owner) : this()
        internal TreeDataGridViewRow(TreeDataGridView owner) : this()
		{
			Grid = owner;
			IsExpanded = true;
		}
        #endregion

        #region public TreeDataGridViewRow()
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public TreeDataGridViewRow()
        {            
			_index = -1;
			_level = -1;            
            IsExpanded = false;
			_isSited = false;
			_isFirstSibling = false;
			_isLastSibling = false;
			_imageIndex = -1;
		}
        #endregion

        #region public override object Clone()
        public override object Clone()
		{
			TreeDataGridViewRow r = (TreeDataGridViewRow)base.Clone();

            if (r == null) 
                return null;
           
            r._level = _level;
            r.Grid = Grid;
            r._parent = Parent;

            r._imageIndex = _imageIndex;
            if (r._imageIndex == -1)
                r.Image = Image;
            r.IsExpanded = IsExpanded;

            return r;
		}
        #endregion

        #region internal protected virtual void UnSited()
        internal protected virtual void UnSited()
		{
			// This row is being removed from being displayed on the grid.
			TreeDataGridViewTextBoxCell cell;
			foreach (DataGridViewCell dgVcell in this.Cells)
			{
				cell = dgVcell as TreeDataGridViewTextBoxCell;
				if (cell != null)
				{
					cell.UnSited();
				}
			}
			_isSited = false;
		}
        #endregion

        #region internal protected virtual void Sited()
        internal protected virtual void Sited()
		{
			// This row is being added to the grid.
			_isSited = true;
			_childCellsCreated = true;
			Debug.Assert(Grid != null);

			TreeDataGridViewTextBoxCell cell;
			foreach (DataGridViewCell dgVcell in Cells)
			{
				cell = dgVcell as TreeDataGridViewTextBoxCell;
				if (cell != null)
				{
					cell.Sited();// Level = this.Level;
				}
			}

		}
        #endregion

        #region public int RowIndex
        // Represents the index of this row in the Grid
		/// <summary>
		/// 
		/// </summary>
		[Description("Represents the index of this row in the Grid. Advanced usage."),
		 EditorBrowsable(EditorBrowsableState.Advanced),
		 Browsable(false),
		 DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int RowIndex
        {
			get{ return base.Index; }
		}
        #endregion

        #region public DataGridViewGroup Group
        /// <summary>
        /// Возвращает или задает группу данной строки
        /// </summary>
        public DataGridViewGroup Group
        {
            get { return _group; }
            set { _group = value; }
        }
        #endregion

        #region public new int Index
        // Represents the index of this row based upon its position in the collection.
		/// <summary>
		/// 
		/// </summary>
		[Browsable(false),
		 DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new int Index
		{
			get
			{
				if (_index == -1)
				{
					// get the index from the collection if unknown
					_index = Owner.IndexOf(this);
				}

				return _index;
			}
			internal set
			{
				_index = value;
			}
		}
        #endregion

        #region public ImageList ImageList
        /// <summary>
        /// Возвращает коллекцию иображений родительского списка
        /// </summary>
        [Browsable(false),
         EditorBrowsable( EditorBrowsableState.Never), 
         DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden)]
        public ImageList ImageList
        {
            get
            {
                if (Grid != null)
                    return Grid.ImageList;
                return null;
            }
        }
        #endregion

        #region private bool ShouldSerializeImageIndex()
        private bool ShouldSerializeImageIndex()
		{
			return (_imageIndex != -1 && _image == null);
		}
        #endregion

        #region public int ImageIndex
        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"),
        Description("..."), DefaultValue(-1),
        TypeConverter(typeof(ImageIndexConverter)),
        Editor("System.Windows.Forms.Design.ImageIndexEditor", typeof(UITypeEditor))]
		public int ImageIndex
		{
			get { return _imageIndex; }
			set
			{
				_imageIndex = value;
				if (_imageIndex != -1)
				{
					// when a imageIndex is provided we do not store the image.
					_image = null;
				}
				if (_isSited)
				{
					// when the image changes the cell's style must be updated
                    if(_treeCell != null)
					    _treeCell.UpdateStyle();
					if (Displayed)
						Grid.InvalidateRow(RowIndex);
				}
			}
		}
        #endregion

        #region private bool ShouldSerializeImage()
        private bool ShouldSerializeImage()
		{
			return (_imageIndex == -1 && _image != null);
		}
        #endregion

        #region public Image Image
        /// <summary>
        /// Возвращает или задает изображение для данной строки
        /// </summary>
        public Image Image
		{
			get 
            {
				if (_image == null && _imageIndex != -1)
				{
				    if (ImageList != null && _imageIndex < ImageList.Images.Count)
					{
						// get image from image index
						return ImageList.Images[_imageIndex];
					}
				    return null;
				}
                // image from image property
                return _image;
			}
			set
			{
				_image = value;
				if (_image != null)
				{
					// when a image is provided we do not store the imageIndex.
					_imageIndex = -1;
				}
				if (_isSited)
				{
					// when the image changes the cell's style must be updated
                    if (_treeCell != null)
                        _treeCell.UpdateStyle();
					if (Displayed)
						Grid.InvalidateRow(RowIndex);
				}
			}
		}
        #endregion

        #region protected override DataGridViewCellCollection CreateCellsInstance()
        protected override DataGridViewCellCollection CreateCellsInstance()
		{
			DataGridViewCellCollection cells = base.CreateCellsInstance();
			cells.CollectionChanged += CellsCollectionChanged;
			return cells;
		}
        #endregion

        #region private void CellsCollectionChanged(object sender, CollectionChangeEventArgs e)
        private void CellsCollectionChanged(object sender, CollectionChangeEventArgs e)
		{
			// Exit if there already is a tree cell for this row
			if (_treeCell != null) return;

			if (e.Action == CollectionChangeAction.Add || e.Action == CollectionChangeAction.Refresh)
			{
				TreeDataGridViewTextBoxCell treeCell = null;

				if (e.Element == null)
				{
					foreach (DataGridViewCell cell in base.Cells)
					{
						if (cell.GetType().IsSubclassOf(typeof(TreeDataGridViewTextBoxCell)) ||
                            cell.GetType().Name == (typeof(TreeDataGridViewTextBoxCell)).Name)
						{
							treeCell = (TreeDataGridViewTextBoxCell)cell;
							break;
						}

					}
				}
				else
				{
					treeCell = e.Element as TreeDataGridViewTextBoxCell;
				}

				if (treeCell != null) 
				    _treeCell = treeCell;
			}
		}
        #endregion

        #region public TreeDataGridViewRowCollection Nodes
        /// <summary>
        /// Возвращает коллекцию дочерних узлов
        /// </summary>
        [Category("Data"),
		 Description("The collection of root nodes in the treelist."),
		 DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
		 Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public TreeDataGridViewRowCollection Nodes
        {
            get { return _childrenNodes ?? (_childrenNodes = new TreeDataGridViewRowCollection(this)); }
        }
        #endregion

        #region public new DataGridViewCellCollection Cells
        /// <summary>
        /// Возвращает коллекцию ячеек данной строки
        /// </summary>
        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewCellCollection Cells
		{
			get
			{
				if (!_childCellsCreated && DataGridView == null)
				{
                    if (Grid == null) return null;

					CreateCells(Grid);
					_childCellsCreated = true;
				}
				return base.Cells;
			}
		}
        #endregion

        #region public int Level
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false),
		 DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int Level
		{
			get 
            {
				if (_level == -1)
				{
					// calculate level
					int walk = 0;
					TreeDataGridViewRow walkRow = Parent;
					while (walkRow != null)
					{
						walk++;
						walkRow = walkRow.Parent;
					}
					_level = walk;
				}
				return _level; 
            }
		}
        #endregion

        #region public TreeDataGridViewRow Parent
        /// <summary>
        /// Возвращает родительскую строку для данной строки
        /// </summary>
        [Browsable(false),
		 DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public TreeDataGridViewRow Parent
		{
			get
			{
				return _parent;
			}
		}
        #endregion

        #region public virtual bool HasChildren
        /// <summary>
        /// Возвращает значение, имеет ли строка дочерние узлы
        /// </summary>
        [Browsable(false),
		 DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual bool HasChildren
		{
			get
			{
				return (_childrenNodes != null && Nodes.Count != 0);
			}
		}
        #endregion

        #region public bool IsSited
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public bool IsSited
        {
            get
            {
                return _isSited;
            }
        }
        #endregion

        #region public bool IsFirstSibling
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
		public bool IsFirstSibling
		{
			get
			{
				return (Index == 0);
			}
		}
        #endregion

        #region public bool IsLastSibling
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
		public bool IsLastSibling
		{
			get
			{
				TreeDataGridViewRow parent = Parent;
				if (parent != null && parent.HasChildren)
				{
					return (Index == parent.Nodes.Count - 1);
				}
			    return true;
			}
		}
        #endregion

        #region public virtual void Collapse()
        /// <summary>
	    /// Сворачивает данную строку
	    /// </summary>
	    /// <returns></returns>
	    public virtual void Collapse()
	    {
	        Grid.CollapseNode(this);
	    }
        #endregion

        #region public virtual void Expand()
        /// <summary>
	    /// Раскрывает данную строку
	    /// </summary>
	    /// <returns></returns>
	    public virtual void Expand()
		{
			if (Grid != null)
			{
			    Grid.ExpandNode(this);
			    return;
			}
	        IsExpanded = true;
		}
        #endregion

        #region internal protected virtual void InsertChildNode(int index, TreeDataGridViewRow node)
        internal protected virtual void InsertChildNode(int index, TreeDataGridViewRow node)
		{
			node._parent = this;
			node.Grid = Grid;

            // ensure that all children of this node has their grid set
            if (Grid != null)
                UpdateChildNodes(node);

			//TODO: do we need to use index parameter?
			if ((_isSited || IsRoot) && IsExpanded)
				Grid.SiteNode(node);
		}
        #endregion

        #region internal protected virtual bool InsertChildNodes(int index, params TreeDataGridViewRow[] nodes)
        internal protected virtual bool InsertChildNodes(int index, params TreeDataGridViewRow[] nodes)
		{
			foreach (TreeDataGridViewRow node in nodes)
			{
				InsertChildNode(index, node);
			}
			return true;
		}
        #endregion

        #region internal protected virtual void AddChildNode(TreeDataGridViewRow node)
        internal protected virtual void AddChildNode(TreeDataGridViewRow node)
		{
			node._parent = this;
			node.Grid = Grid;

            // ensure that all children of this node has their grid set
            if (Grid != null)
                UpdateChildNodes(node);

			if ((_isSited || IsRoot) && IsExpanded && !node._isSited)
				Grid.SiteNode(node);
		}
        #endregion

        #region internal protected virtual bool AddChildNodes(params TreeDataGridViewRow[] nodes)
        internal protected virtual bool AddChildNodes(params TreeDataGridViewRow[] nodes)
		{
			//TODO: Convert the final call into an SiteNodes??
			foreach (TreeDataGridViewRow node in nodes)
			{
				AddChildNode(node);
			}
			return true;

		}
        #endregion

        #region internal protected virtual void RemoveChildNode(TreeDataGridViewRow node)
        internal protected virtual void RemoveChildNode(TreeDataGridViewRow node)
		{
			if ((IsRoot || _isSited) && IsExpanded )
			{
				//We only unsite out child node if we are sited and expanded.
				Grid.UnSiteNode(node);
			
			}
            node.Grid = null;
            node.Owner = null;
            node.Index = -1;
			node._parent = null;
		}
        #endregion

        #region  internal protected virtual void ClearNodes()
        internal protected virtual void ClearNodes()
        {
            if (HasChildren)
            {
                for (int i = Nodes.Count - 1; i >= 0; i--)
                {
                    Nodes.RemoveAt(i);
                }
            }
        }

	    #endregion

        #region  public event EventHandler Disposed
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public event EventHandler Disposed
        {
            add
            {
                _disposed += value;
            }
            remove { if (_disposed != null) _disposed -= value; }
        }
        #endregion

        #region public ISite Site
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ISite Site
		{
			get
			{
				return _site;
			}
			set
			{
				_site = value;
			}
		}
        #endregion

        #region private void UpdateChildNodes(TreeDataGridViewRow node)
        private void UpdateChildNodes(TreeDataGridViewRow node)
        {
            if (node.HasChildren)
            {
                foreach (TreeDataGridViewRow childNode in node.Nodes)
                {
                    childNode.Grid = node.Grid;
                    UpdateChildNodes(childNode);
                }
            }
        }
        #endregion

        #region public override string ToString()
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(36);
            sb.Append("TreeGridNode { Index=");
            sb.Append(this.RowIndex.ToString(System.Globalization.CultureInfo.CurrentCulture));
            sb.Append(" }");
            return sb.ToString();
        }
        #endregion

        /// <summary>
        /// the main difference with a Group row and a regular row is the way it is painted on the control.
        /// the Paint method is therefore overridden and specifies how the Group row is painted.
        /// Note: this method is not implemented optimally. It is merely used for demonstration purposes
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="clipBounds"></param>
        /// <param name="rowBounds"></param>
        /// <param name="rowIndex"></param>
        /// <param name="rowState"></param>
        /// <param name="isFirstDisplayedRow"></param>
        /// <param name="isLastVisibleRow"></param>
        protected override void Paint(System.Drawing.Graphics graphics, System.Drawing.Rectangle clipBounds, System.Drawing.Rectangle rowBounds, int rowIndex, DataGridViewElementStates rowState, bool isFirstDisplayedRow, bool isLastVisibleRow)
        {
            if (IsGroupRow)
            {
                DataGridViewGroup group = Tag as DataGridViewGroup;

                TreeDataGridView grid = (TreeDataGridView)this.DataGridView;
                int rowHeadersWidth = grid.RowHeadersVisible ? grid.RowHeadersWidth : 0;

                // this can be optimized
                Brush brush = new SolidBrush(grid.DefaultCellStyle.BackColor);
                Brush brush2 = new SolidBrush(Color.FromKnownColor(KnownColor.GradientActiveCaption));

                int gridwidth = grid.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed);
                Rectangle rowBounds2 = grid.GetRowDisplayRectangle(this.Index, true);

                // draw the background
                graphics.FillRectangle(brush, rowBounds.Left + rowHeadersWidth - grid.HorizontalScrollingOffset, rowBounds.Top, gridwidth, rowBounds.Height - 1);

                // draw text, using the current grid font
                graphics.DrawString(group != null ? group.Header : "", grid.Font, Brushes.Black, rowHeadersWidth - grid.HorizontalScrollingOffset + 23, rowBounds.Bottom - 18);

                //draw bottom line
                graphics.FillRectangle(brush2, rowBounds.Left + rowHeadersWidth - grid.HorizontalScrollingOffset, rowBounds.Bottom - 2, gridwidth - 1, 2);

                // draw right vertical bar
                if (grid.CellBorderStyle == DataGridViewCellBorderStyle.SingleVertical || grid.CellBorderStyle == DataGridViewCellBorderStyle.Single)
                    graphics.FillRectangle(brush2, rowBounds.Left + rowHeadersWidth - grid.HorizontalScrollingOffset + gridwidth - 1, rowBounds.Top, 1, rowBounds.Height);

                if (!IsExpanded)
                {
                    if (grid.CollapseIcon != null)
                        graphics.DrawImage(grid.ExpandIcon, rowBounds.Left + rowHeadersWidth - grid.HorizontalScrollingOffset + 4, rowBounds.Bottom - 18, 11, 11);
                }
                else
                {
                    if (grid.CollapseIcon != null)
                        graphics.DrawImage(grid.CollapseIcon, rowBounds.Left + rowHeadersWidth - grid.HorizontalScrollingOffset + 4, rowBounds.Bottom - 18, 11, 11);
                }

                brush.Dispose();
                brush2.Dispose();
            }
            base.Paint(graphics, clipBounds, rowBounds, rowIndex, rowState, isFirstDisplayedRow, isLastVisibleRow);
        }

        protected override void PaintCells(Graphics graphics, Rectangle clipBounds, Rectangle rowBounds, int rowIndex, DataGridViewElementStates rowState, bool isFirstDisplayedRow, bool isLastVisibleRow, DataGridViewPaintParts paintParts)
        {
            if (!IsGroupRow)
                base.PaintCells(graphics, clipBounds, rowBounds, rowIndex, rowState, isFirstDisplayedRow, isLastVisibleRow, paintParts);
        }
        //protected override void Dispose(bool disposing) {
		//    if (disposing)
		//    {
		//        lock(this)
		//        {
		//            if (this.site != null && this.site.Container != null)
		//            {
		//                this.site.Container.Remove(this);
		//            }

		//            if (this.disposed != null)
		//            {
		//                this.disposed(this, EventArgs.Empty);
		//            }
		//        }
		//    }

		//    base.Dispose(disposing);
		//}
	}

}