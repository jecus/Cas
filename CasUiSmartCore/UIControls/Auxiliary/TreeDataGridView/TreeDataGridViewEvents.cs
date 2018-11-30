//---------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

namespace CAS.UI.UIControls.Auxiliary.TreeDataGridView
{
	/// <summary>
	/// 
	/// </summary>
	public class TreeGridNodeEventBase
	{
		private TreeDataGridViewRow _row;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
		public TreeGridNodeEventBase(TreeDataGridViewRow row)
		{
			_row = row;
		}

		/// <summary>
		/// Возвращает строку, в которой произошло событие
		/// </summary>
		public TreeDataGridViewRow Row
		{
			get { return _row; }
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class CollapsingEventArgs : System.ComponentModel.CancelEventArgs
	{
		private TreeDataGridViewRow _row;

		private CollapsingEventArgs() { }
		public CollapsingEventArgs(TreeDataGridViewRow row)
		{
			_row = row;
		}

		/// <summary>
		/// Возвращает строку с которой связано событие
		/// </summary>
		public TreeDataGridViewRow Node
		{
			get { return _row; }
		}

	}

	/// <summary>
	/// 
	/// </summary>
	public class CollapsedEventArgs : TreeGridNodeEventBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
		public CollapsedEventArgs(TreeDataGridViewRow row) : base(row)
		{
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class ExpandingEventArgs:System.ComponentModel.CancelEventArgs
	{
		private TreeDataGridViewRow _row;

		private ExpandingEventArgs() { }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
		public ExpandingEventArgs(TreeDataGridViewRow row):base()
		{
			_row = row;
		}

		/// <summary>
		/// Возвращает строку с которой связано событие
		/// </summary>
		public TreeDataGridViewRow Row
		{
			get { return _row; }
		}

	}
	/// <summary>
	/// 
	/// </summary>
	public class ExpandedEventArgs : TreeGridNodeEventBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="node"></param>
		public ExpandedEventArgs(TreeDataGridViewRow node):base(node)
		{
		}
	}

	/// <summary>
	/// Делегат для события начала разворачивания строки
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public delegate void ExpandingEventHandler(object sender, ExpandingEventArgs e);
	/// <summary>
	/// Делегат для события завершения разворачивания строки
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public delegate void ExpandedEventHandler(object sender, ExpandedEventArgs e);

	/// <summary>
	/// Делегат для события начала сворачивания строки
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public delegate void CollapsingEventHandler(object sender, CollapsingEventArgs e);
	/// <summary>
	/// Делегат для события завершения сворачивания строки
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public delegate void CollapsedEventHandler(object sender, CollapsedEventArgs e);

}
