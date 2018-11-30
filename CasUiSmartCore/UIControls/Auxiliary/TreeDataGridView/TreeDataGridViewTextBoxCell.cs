//---------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System.Drawing;
using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary.TreeDataGridView
{
	/// <summary>
	/// Summary description for TreeGridCell.
	/// </summary>
	public class TreeDataGridViewTextBoxCell :DataGridViewTextBoxCell
    {
        #region Fields

        private const int IndentWidth = 20;
		private const int IndentMargin = 5;
		private int _glyphWidth;
		private int _calculatedLeftPadding;
	    private bool _isSited;
		private Padding _previousPadding;
		private int _imageWidth, _imageHeight, _imageHeightOffset;
		private Rectangle _lastKnownGlyphRect;

        #endregion

        #region public TreeGridCell()
        /// <summary>
		/// 
		/// </summary>
		public TreeDataGridViewTextBoxCell()
		{			
			_glyphWidth = 15;
			_calculatedLeftPadding = 0;
			_isSited = false;
		}
        #endregion

        #region public override object Clone()
        public override object Clone()
        {
			TreeDataGridViewTextBoxCell c = (TreeDataGridViewTextBoxCell)base.Clone();
			
            c._glyphWidth = _glyphWidth;
            c._calculatedLeftPadding = _calculatedLeftPadding;

            return c;
        }
        #endregion

        #region internal protected virtual void UnSited()
        internal protected virtual void UnSited()
		{
			// The row this cell is in is being removed from the grid.
			_isSited = false;
			Style.Padding = _previousPadding;
		}
        #endregion

        #region internal protected virtual void Sited()
        internal protected virtual void Sited()
		{
			// when we are added to the DGV we can realize our style
			_isSited = true;

			// remember what the previous padding size is so it can be restored when unsiting
			_previousPadding = Style.Padding;

			UpdateStyle();
		}
        #endregion

        #region internal protected virtual void UpdateStyle()
        internal protected virtual void UpdateStyle()
        {
			// styles shouldn't be modified when we are not sited.
			if (_isSited == false) 
                return;

			int level = Level;

			Padding p = _previousPadding;
			Size preferredSize;

			using (Graphics g = OwningNode.Grid.CreateGraphics()) 
            {
				preferredSize = GetPreferredSize(g, InheritedStyle, RowIndex, new Size(0, 0));
			}

			Image image = OwningNode.Image;

			if (image != null)
			{
				// calculate image size
				_imageWidth = image.Width+2;
				_imageHeight = image.Height+2;

			}
			else
			{
				_imageWidth = _glyphWidth;
				_imageHeight = 0;
			}

			// TODO: Make this cleaner
			if (preferredSize.Height < _imageHeight)
			{

				Style.Padding = new Padding(p.Left + (level * IndentWidth) + _imageWidth + IndentMargin,
										    p.Top + (_imageHeight / 2), p.Right, p.Bottom + (_imageHeight / 2));
				_imageHeightOffset = 2;// (_imageHeight - preferredSize.Height) / 2;
			}
			else
			{
				Style.Padding = new Padding(p.Left + (level * IndentWidth) + _imageWidth + IndentMargin,
											p.Top , p.Right, p.Bottom );

			}
			_calculatedLeftPadding = ((level - 1) * _glyphWidth) + _imageWidth + IndentMargin;
		}
        #endregion

        #region public int Level
        /// <summary>
        /// 
        /// </summary>
        public int Level
		{
			get
			{
				TreeDataGridViewRow row = OwningNode;
				if (row != null)
				{
					return row.Level;
				}
			    return -1;
			}
		}
        #endregion

        #region protected virtual int GlyphMargin
        /// <summary>
        /// 
        /// </summary>
        protected virtual int GlyphMargin
		{
			get
			{
				return ((Level - 1) * IndentWidth) + IndentMargin;
			}
		}
        #endregion

        #region protected virtual int GlyphOffset
        /// <summary>
        /// 
        /// </summary>
        protected virtual int GlyphOffset
		{
			get
			{
				return ((Level - 1) * IndentWidth);
			}
		}
        #endregion

        #region protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
		{
            TreeDataGridViewRow node = OwningNode;
            if (node == null) return;

            Image image = node.Image;

            if (_imageHeight == 0 && image != null) 
                UpdateStyle();

			// paint the cell normally
			base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            // TODO: Indent width needs to take image size into account
			Rectangle glyphRect = new Rectangle(cellBounds.X + GlyphMargin, cellBounds.Y, IndentWidth, cellBounds.Height - 1);
			int glyphHalf = glyphRect.Width / 2;

			//TODO: This painting code needs to be rehashed to be cleaner
			int level = Level;

            //TODO: Rehash this to take different Imagelayouts into account. This will speed up drawing
			//		for images of the same size (ImageLayout.None)
			if (image != null)
			{
				Point pp;
				if (_imageHeight > cellBounds.Height)
                    pp = new Point(glyphRect.X + _glyphWidth, cellBounds.Y + _imageHeightOffset);
				else
                    pp = new Point(glyphRect.X + _glyphWidth, (cellBounds.Height / 2 - _imageHeight / 2) + cellBounds.Y);

				// Graphics container to push/pop changes. This enables us to set clipping when painting
				// the cell's image -- keeps it from bleeding outsize of cells.
				System.Drawing.Drawing2D.GraphicsContainer gc = graphics.BeginContainer();
				{
					graphics.SetClip(cellBounds);
					graphics.DrawImageUnscaled(image, pp);
				}
				graphics.EndContainer(gc);
			}

			// Paint tree lines			
            if (node.Grid.ShowLines)
            {
                using (Pen linePen = new Pen(SystemBrushes.ControlDark, 1.0f))
                {
                    linePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    bool isLastSibling = node.IsLastSibling;
                    bool isFirstSibling = node.IsFirstSibling;
                    if (node.Level == 1)
                    {
                        // the Root nodes display their lines differently
                        if (isFirstSibling && isLastSibling)
                        {
                            // only node, both first and last. Just draw horizontal line
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.Right, cellBounds.Top + cellBounds.Height / 2);
                        }
                        else if (isLastSibling)
                        {
                            // last sibling doesn't draw the line extended below. Paint horizontal then vertical
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.Right, cellBounds.Top + cellBounds.Height / 2);
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2);
                        }
                        else if (isFirstSibling)
                        {
                            // first sibling doesn't draw the line extended above. Paint horizontal then vertical
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.Right, cellBounds.Top + cellBounds.Height / 2);
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.X + 4, cellBounds.Bottom);
                        }
                        else
                        {
                            // normal drawing draws extended from top to bottom. Paint horizontal then vertical
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.Right, cellBounds.Top + cellBounds.Height / 2);
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top, glyphRect.X + 4, cellBounds.Bottom);
                        }
                    }
                    else
                    {
                        if (isLastSibling)
                        {
                            // last sibling doesn't draw the line extended below. Paint horizontal then vertical
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.Right, cellBounds.Top + cellBounds.Height / 2);
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2);
                        }
                        else
                        {
                            // normal drawing draws extended from top to bottom. Paint horizontal then vertical
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.Right, cellBounds.Top + cellBounds.Height / 2);
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top, glyphRect.X + 4, cellBounds.Bottom);
                        }

                        // paint lines of previous levels to the root
                        TreeDataGridViewRow previousNode = node.Parent;
                        int horizontalStop = (glyphRect.X + 4) - IndentWidth;

                        while (!previousNode.IsRoot)
                        {
                            if (previousNode.HasChildren && !previousNode.IsLastSibling)
                            {
                                // paint vertical line
                                graphics.DrawLine(linePen, horizontalStop, cellBounds.Top, horizontalStop, cellBounds.Bottom);
                            }
                            previousNode = previousNode.Parent;
                            horizontalStop = horizontalStop - IndentWidth;
                        }
                    }

                }
            }

            if (node.HasChildren || node.Grid.VirtualNodes)
            {
                // Paint node glyphs				
                if (node.IsExpanded)
                    node.Grid.rOpen.DrawBackground(graphics, new Rectangle(glyphRect.X, glyphRect.Y + (glyphRect.Height / 2) - 4, 10, 10));
                else
                    node.Grid.rClosed.DrawBackground(graphics, new Rectangle(glyphRect.X, glyphRect.Y + (glyphRect.Height / 2) - 4, 10, 10));
            }


		}
        #endregion

        #region protected override void OnMouseUp(DataGridViewCellMouseEventArgs e)
        protected override void OnMouseUp(DataGridViewCellMouseEventArgs e)
        {
            base.OnMouseUp(e);

            TreeDataGridViewRow node = OwningNode;
            if (node != null)
                node.Grid._inExpandCollapseMouseCapture = false;
        }
        #endregion

        #region protected override void OnMouseDown(DataGridViewCellMouseEventArgs e)
        protected override void OnMouseDown(DataGridViewCellMouseEventArgs e)
		{
			if (e.Location.X > InheritedStyle.Padding.Left)
			{
				base.OnMouseDown(e);
			}
			else
			{
				// Expand the node
				//TODO: Calculate more precise location
				TreeDataGridViewRow node = OwningNode;
                if (node != null)
				{
                    node.Grid._inExpandCollapseMouseCapture = true;
                    if (node.IsExpanded)
                        node.Collapse();
					else
                        node.Expand();
                }
			}
		}
        #endregion

        #region public TreeGridNode OwningNode
        /// <summary>
        /// 
        /// </summary>
        public TreeDataGridViewRow OwningNode
		{
			get { return OwningRow as TreeDataGridViewRow; }
        }
        #endregion
    }


	/// <summary>
	/// ќписывает колонку с текстом древовидного DataGridView-а
	/// </summary>
	public class TreeDataGridViewTextBoxColumn : DataGridViewTextBoxColumn
	{
	    private Image _defaultNodeImage;

        #region public override DataGridViewCell CellTemplate
        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                if (value == null || !value.GetType().IsAssignableFrom(typeof (TreeDataGridViewTextBoxCell)))
                {
                    base.CellTemplate = new TreeDataGridViewTextBoxCell();
                }
                else base.CellTemplate = value;
            }
        }
        #endregion

        #region public TreeDataGridViewTextBoxColumn()
        /// <summary>
		/// 
		/// </summary>
		public TreeDataGridViewTextBoxColumn()
		{		
            base.CellTemplate = new TreeDataGridViewTextBoxCell();
		}
        #endregion

        #region public override object Clone()
        // Need to override Clone for design-time support.
		public override object Clone()
		{
			TreeDataGridViewTextBoxColumn c = (TreeDataGridViewTextBoxColumn)base.Clone();
            if(c != null)
			    c._defaultNodeImage = _defaultNodeImage;
			return c;
		}
        #endregion

        #region public Image DefaultNodeImage
        /// <summary>
		/// ¬озвращает или задает картинку по-умолчанию
		/// </summary>
		public Image DefaultNodeImage
		{
			get { return _defaultNodeImage; }
			set { _defaultNodeImage = value; }
        }
        #endregion
    }
}
