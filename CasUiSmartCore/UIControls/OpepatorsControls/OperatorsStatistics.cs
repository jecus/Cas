using System;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Management;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using SmartCore.Entities.Collections;

namespace CAS.UI.UIControls.OpepatorsControls
{
    /// <summary>
    /// Элемент управления для отображения информации о списке эксплуатантов
    /// </summary>
    public class OperatorsStatistics : Control
    {
        #region Fields
        private OperatorCollection operators;
        private PictureBox pictureBoxArrow;
        private Label labelTitle;
        private Label labelOperatorsCount;
        private RichReferenceButton buttonAddOperator;
        private readonly Icons icons = new Icons();

        #endregion

        #region Constructors
        /// <summary>
        /// Создается элемент управления для отображения информации о списке эксплуатантов
        /// </summary>
        public OperatorsStatistics()
        {
            Initialize();
        }
        #endregion

        #region Methods

        #region private void Initialize()
        /// <summary>
        /// Initializes object
        /// </summary>
        private void Initialize()
        {
            pictureBoxArrow = new PictureBox();
            labelTitle = new Label();
            labelOperatorsCount = new Label();
            buttonAddOperator = new RichReferenceButton();

            Size = new Size(400, 70);

            //
            // pictureBoxArrow
            //
            pictureBoxArrow.Image = new Icons().GrayArrow;
            pictureBoxArrow.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxArrow.Location = new Point(Padding.Left, 10 + Padding.Top);
            //
            // labelTitle
            //
            labelTitle.Text = "Operators";
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(pictureBoxArrow.Width + pictureBoxArrow.Left + 5, 7 + Padding.Top);
            Css.HeaderText.Adjust(labelTitle);
            //
            // labelOperatorsCount
            //
            labelOperatorsCount.AutoSize = true;
            labelOperatorsCount.Location = new Point(pictureBoxArrow.Width + pictureBoxArrow.Left + 9, 15 + Padding.Top + labelTitle.Height); 
            Css.OrdinaryText.Adjust(labelOperatorsCount);
            //
            // buttonAddOperator
            //
            buttonAddOperator.FontMain = new System.Drawing.Font("Verdana", 12F);
            buttonAddOperator.FontSecondary = new System.Drawing.Font("Verdana", 12F);
            buttonAddOperator.ForeColorMain = System.Drawing.Color.FromArgb(125, 195, 42);
            buttonAddOperator.ForeColorSecondary = System.Drawing.Color.FromArgb(122, 122, 122);
            buttonAddOperator.Icon = icons.Add;
            buttonAddOperator.IconNotEnabled = icons.AddGray;
            buttonAddOperator.IconLayout = System.Windows.Forms.ImageLayout.Center;
            buttonAddOperator.PaddingMain = new System.Windows.Forms.Padding(0, 7, 0, 0);
            buttonAddOperator.PaddingSecondary = new System.Windows.Forms.Padding(0);
            buttonAddOperator.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            buttonAddOperator.Size = new System.Drawing.Size(131, 50);
            buttonAddOperator.TextAlignMain = System.Drawing.ContentAlignment.MiddleLeft;
            buttonAddOperator.TextAlignSecondary = System.Drawing.ContentAlignment.TopLeft;
            buttonAddOperator.TextMain = "Add new";
            buttonAddOperator.TextSecondary = "operator";
            buttonAddOperator.Location = new Point(250, 7);
            buttonAddOperator.Displayer = null;
            buttonAddOperator.DisplayerText = null;
            buttonAddOperator.Entity = null;
            buttonAddOperator.ReflectionType = CAS.UI.Management.Dispatchering.ReflectionTypes.DisplayInNew;
            buttonAddOperator.DisplayerRequested += new EventHandler<ReferenceEventArgs>(buttonAddOperator_DisplayerRequested);
            buttonAddOperator.DisplayerText = "Add operator";
            buttonAddOperator.Visible = false;


            Controls.Add(labelTitle);
            Controls.Add(labelOperatorsCount);
            Controls.Add(buttonAddOperator);
            Controls.Add(pictureBoxArrow);

            UpdateContent();
        }
        #endregion

        #region private void buttonAddOperator_DisplayerRequested(object sender, ReferenceEventArgs e)
        private void buttonAddOperator_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            e.Cancel = true;
            //e.RequestedEntity = new DispatcheredUIOperatorAdd();
        }
        #endregion

        #region public void UpdateContent()
        /// <summary>
        /// Updates content of control
        /// </summary>
        public void UpdateContent()
        {
            int count = operators.Count;
            labelOperatorsCount.Text = count + " operator" + (count == 1 ? "" : "s");
        }
        #endregion

        #endregion
    }
}
