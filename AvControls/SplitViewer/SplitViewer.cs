using System.Drawing;
using System.Windows.Forms;

namespace AvControls.SplitViewer
{
    public partial class SplitViewer : UserControl
    {
        #region Fields
        /// <summary>
        /// Изображение, которое будет использоваться в качестве разделителя
        /// </summary>
        private Image _splitterImage;
        #endregion

        #region Properties

        #region public int ControlsAmount
        /// <summary>
        /// Возвращает или задает кол-во ЭУ в данном контроле
        /// </summary>
        public int ControlsAmount
        {
            get { return ((tableLayoutPanel1.ColumnCount + 1) / 2); }
            set
            {
                int num = (value * 2) - 1;
                for (int i = tableLayoutPanel1.ColumnStyles.Count; i < num; i++)
                {
                    tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                }
                for (int j = tableLayoutPanel1.ColumnStyles.Count - 1; j > num; j--)
                {
                    tableLayoutPanel1.ColumnStyles.RemoveAt(j);
                    tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(j, 0));
                }
                tableLayoutPanel1.ColumnCount = num;
                for (int k = 1; k < tableLayoutPanel1.ColumnCount; k += 2)
                {
                    SetSplitterAt(k);
                }
            }
        }
        #endregion

        #region  public Control this[int index]
        /// <summary>
        /// Возвращает или задает ЭУ с заданным индексом
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Control this[int index]
        {
            get { return tableLayoutPanel1.GetControlFromPosition(RealIndex(index), 0); }
            set
            {
                if (tableLayoutPanel1.GetControlFromPosition(RealIndex(index), 0) != null)
                {
                    //если в заданной позиции есть контрол - то он удаляется
                    tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(RealIndex(index), 0));
                }
                //устанавливается новый контрол
                tableLayoutPanel1.Controls.Add(value, RealIndex(index), 0);
            }
        }
        #endregion

        #region public Image SplitterImage
        /// <summary>
        /// Возвращает или задает изображение, которое будет использоваться в качестве разделителя
        /// </summary>
        public Image SplitterImage
        {
            get { return _splitterImage; }
            set
            {
                _splitterImage = value;
                for (int i = 1; i < tableLayoutPanel1.ColumnCount; i += 2)
                {
                    Button controlFromPosition = tableLayoutPanel1.GetControlFromPosition(i, 0) as Button;
                    if (controlFromPosition != null)
                    {
                        controlFromPosition.Image = _splitterImage;
                    }
                }
            }
        }
        #endregion
        
        #endregion

        #region public SplitViewer()
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public SplitViewer()
        {
            InitializeComponent();
        }
        #endregion

        #region protected override void OnControlAdded(ControlEventArgs e)
        /// <summary>
        /// переопределяется так, что бы на данный ЭУ нельзя было добавить другие ЭУ
        /// </summary>
        /// <param name="e"></param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (e.Control != tableLayoutPanel1)
            {
                Controls.Remove(e.Control);
            }
            base.OnControlAdded(e);
        }
        #endregion

        #region private static int RealIndex(int index)
        /// <summary>
        /// возвращает индекс элемента управления, так, как если бы не было разделителей
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private static int RealIndex(int index)
        {
            return (index * 2);
        }
        #endregion

        #region private void SetSplitterAt(int i)
        /// <summary>
        /// Устанавливает разделитель на заданную позицию
        /// </summary>
        /// <param name="i"></param>
        private void SetSplitterAt(int i)
        {
            if (tableLayoutPanel1.GetControlFromPosition(i, 0) == null)
            {
                Button control = new Button();
                control.Image = _splitterImage;
                control.AutoSize = true;
                control.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                control.BackColor = Color.Transparent;
                control.FlatStyle = FlatStyle.Flat;
                control.FlatAppearance.BorderSize = 0;
                control.TextImageRelation = TextImageRelation.ImageBeforeText;
                control.Dock = DockStyle.Fill;
                control.Margin = new Padding(0);
                control.Enabled = false;
                tableLayoutPanel1.Controls.Add(control, i, 0);
            }
        }
        #endregion
    }
}
