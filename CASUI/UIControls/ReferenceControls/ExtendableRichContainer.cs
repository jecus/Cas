using System;
using System.Drawing;
using System.Windows.Forms;

namespace CAS.UI.UIControls.ReferenceControls
{
    /// <summary>
    /// Класс, опсисывающий расширяемый <see cref="RichReferenceContainer"/>
    /// </summary>
    public class ExtendableRichContainer : RichReferenceContainer
    {

        #region Fields
        /// <summary>
        /// Определяется, будет ли меняться формат отображения информации
        /// </summary>
        private bool extendable = true;
        /// <summary>
        /// Развернут ли элемент
        /// </summary>
        private bool extended = true;

        private Control mainControl;

        #endregion
        
        #region Constructors
        /// <summary>
        /// Создается экземпляр расширяемого <see cref="RichReferenceContainer"/>
        /// </summary>
        public ExtendableRichContainer()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        #region public bool Extended
        /// <summary>
        /// Развернут ли элемент
        /// </summary>
        public bool Extended
        {
            get { return extended; }
            set
            {
                extended = value;
                if (extended)
                {
                    if (mainControl != null)
                    {
                        tableLayoutPanel.Controls.Add(mainControl, 1, 1);
                        tableLayoutPanel.SetColumnSpan(mainControl, 4);
                    }
                }
                else
                {
                    tableLayoutPanel.Controls.Remove(mainControl);
                }
                if (Extending != null)
                    Extending(this, new EventArgs());
            }
        }
        #endregion

        #region public Control MainControl
        ///<summary>
        /// Объект, отображаемый как основной
        ///</summary>
        public override Control MainControl
        {
            get
            {
                return mainControl;
            }
            set
            {
                if (value == null)return;
                tableLayoutPanel.Controls.Remove(mainControl);
                mainControl = value;
                mainControl.Dock = DockStyle.Top;
                mainControl.AutoSize = true;
                if (extended)
                {
                    tableLayoutPanel.Controls.Add(value, 1, 1);
                    this.tableLayoutPanel.SetColumnSpan(value, 4);
                }
            }
        }
        #endregion

        #region public bool Extendable
        /// <summary>
        /// Определяется, будет ли меняться формат отображения информации
        /// </summary>
        public bool Extendable
        {
            get { return extendable; }
            set { extendable = value; }
        }
        #endregion

        #endregion
        
        #region Methods
        private void InitializeComponent()
        {
         //   this.SuspendLayout();
            // 
            // ExtendableRichContainer
            // \
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
           // this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.Name = "ExtendableRichContainer";
           // this.Size = new Size(248, 49);
           // this.ResumeLayout(false);
           // this.PerformLayout();
            this.LabelCaption.Cursor = Cursors.Hand;
            this.PictureBoxIcon.Cursor = Cursors.Hand;
            labelCaption.MouseClick += labelCaption_MouseClick;
            pictureBoxIcon.MouseClick += labelCaption_MouseClick;
        }

        #region void labelCaption_MouseClick(object sender, MouseEventArgs e)
        void labelCaption_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button ==  MouseButtons.Left)
            {
                if (extendable)
                {
                    Extended = !extended;
                }
            }
        }
        #endregion


        #endregion

        #region Events

        #region public event EventHandler Extending;

        /// <summary>
        /// Событие разворачивания
        /// </summary>
        public event EventHandler Extending;

        #endregion


        #endregion

    }
}
