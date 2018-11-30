using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary.Comparers;

internal class DirectiveListViewComparer : IComparer<ListViewItem>
{

    #region Fields

    private readonly int sortMultiplier;
    private readonly int[] indexArray;

    #endregion

    #region Constructors

    #region public DirectiveListViewComparer(Queue<int> columnIndexQueue)

    /// <summary>
    /// Создает компаратор для DirectiveListView
    /// </summary>
    public DirectiveListViewComparer(Queue<int> columnIndexQueue)
    {
        indexArray = columnIndexQueue.ToArray();
    }

    #endregion

    #region public DirectiveListViewComparer(Queue<int> columnIndexQueue, int sortMultiplier) : this(columnIndexQueue)

    public DirectiveListViewComparer(Queue<int> columnIndexQueue, int sortMultiplier) : this(columnIndexQueue)
    {
        this.sortMultiplier = sortMultiplier;
    }

    #endregion

    #endregion

    #region Methods

    #region private int ColumnComparer(int columnIndex, ListViewItem x, ListViewItem y)

    private int ColumnComparer(int columnIndex, ListViewItem x, ListViewItem y)
    {
        return (0 == columnIndex)
                   ?
                       ComparerMethods.AdStatusComparer(x.Text, y.Text)
                   : string.Compare(x.SubItems[columnIndex].Text, y.SubItems[columnIndex].Text);
    }

    #endregion
    
    #region private int CheckColumnIndexQueue(int index ,ListViewItem x,ListViewItem y)

    private int CheckColumnIndexQueue(int index, ListViewItem x, ListViewItem y)
    {
        if (index < 0) return 0;
        if (0 != ColumnComparer(indexArray[index], x, y))
            return ColumnComparer(indexArray[index], x, y);
        else
            return CheckColumnIndexQueue(index - 1, x, y);

    }

    #endregion
    
    #region public int Compare(object x, object y)

    public int Compare(ListViewItem x, ListViewItem y)
    {
        return sortMultiplier * CheckColumnIndexQueue(indexArray.Length - 1, x, y);
    }

    #endregion

    #endregion


}