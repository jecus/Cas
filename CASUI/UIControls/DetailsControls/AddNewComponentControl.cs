using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Core.Interfaces;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.DetailsControls
{
    /// <summary>
    ///  ласс дл€ выбора базового агрегата дл€ добавлени€
    /// </summary>
    public class AddNewComponentControl : UserControl
    {

        #region Fields

        private readonly FlowLayoutPanel flowLayoutPanel1;
        private readonly Label labelBaseComponent;
        private readonly RadioButton[] radioButtonBaseDetail;

        #endregion

        #region Constructors

        /// <summary>
        /// —оздает контрол дл€ выбора базового агрегата дл€ добавлени€
        /// </summary>
        /// <param name="parentDetail"></param>
        public AddNewComponentControl(BaseDetail parentDetail)
        {
            SuspendLayout();
            flowLayoutPanel1 = new FlowLayoutPanel();
            labelBaseComponent = new Label();
            // 
            // labelBaseComponent
            // 
            labelBaseComponent.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelBaseComponent.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelBaseComponent.Location = new Point(10, 20);
            labelBaseComponent.Name = "labelBaseComponent";
            labelBaseComponent.Size = new Size(150, 26);
            labelBaseComponent.TabIndex = 0;
            labelBaseComponent.Text = "Base component:";
            labelBaseComponent.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(labelBaseComponent.Right, labelBaseComponent.Top);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Size = new Size(900, 60);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // AddNewComponentControl
            // 
            BackColor = Css.CommonAppearance.Colors.BackColor;
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelBaseComponent);
            Controls.Add(flowLayoutPanel1);
            Name = "AddNewComponentControl";
            Size = new Size(900, 140);
            ResumeLayout(false);
            PerformLayout();

            if (parentDetail != null)
            {
                Aircraft parentAircraft = null;
                //if (parentDetail is Aircraft) parentAircraft = (Aircraft) parentDetail;
                //if (parentDetail is BaseDetail) parentAircraft = ((BaseDetail) parentDetail).ParentAircraft;
                parentAircraft = parentDetail.ParentAircraft;
                if (parentAircraft != null)
                {
                    BaseDetail[] baseDetails = parentAircraft.BaseDetails;
                    radioButtonBaseDetail = new RadioButton[baseDetails.Length];
                    int length = baseDetails.Length;
                    for (int i = 0; i < length; i++)
                    {
                        BaseDetail current = baseDetails[i];
                        radioButtonBaseDetail[i] = new RadioButton();
                        radioButtonBaseDetail[i].AutoSize = true;
                        radioButtonBaseDetail[i].Cursor = Cursors.Hand;
                        radioButtonBaseDetail[i].FlatStyle = FlatStyle.Flat;
                        radioButtonBaseDetail[i].Font =
                            new Font(Css.OrdinaryText.Fonts.RegularFont, FontStyle.Underline);
                        radioButtonBaseDetail[i].ForeColor = Css.SimpleLink.Colors.LinkColor;
                        radioButtonBaseDetail[i].Location = new Point(labelBaseComponent.Location.X + labelBaseComponent.Width + 25, i*25);
                        radioButtonBaseDetail[i].Size = new Size(73, 22);
                        radioButtonBaseDetail[i].TabIndex = i;
                        radioButtonBaseDetail[i].TabStop = true;
                        radioButtonBaseDetail[i].Tag = baseDetails[i];
                        radioButtonBaseDetail[i].Text = current.DetailType.FullName +
                                                        " " +
                                                        current.SerialNumber;
                        radioButtonBaseDetail[i].UseVisualStyleBackColor = true;
                        radioButtonBaseDetail[i].CheckedChanged += CheckedChangedByAnyCheckBox;
                        if (parentDetail == current) radioButtonBaseDetail[i].Checked = true;
                        flowLayoutPanel1.Controls.Add(radioButtonBaseDetail[i]);
                    }
                }
                if (parentDetail is Aircraft) radioButtonBaseDetail[0].Checked = true;
            }
        }

        #endregion

        #region Properties

        #region public BaseDetail BaseDetailAddTo

        /// <summary>
        /// —войство возвращающее базовый агрегат, в который нужно добавить новый компонент
        /// </summary>
        public BaseDetail BaseDetailAddTo
        {
            get
            {
                for (int i = 0; i < radioButtonBaseDetail.Length; i++)
                {
                    if (radioButtonBaseDetail[i].Checked) return radioButtonBaseDetail[i].Tag as BaseDetail;
                }
                return radioButtonBaseDetail[0].Tag as BaseDetail;
            }
            set
            {
                for (int i = 0; i < radioButtonBaseDetail.Length; i++)
                {
                    if (radioButtonBaseDetail[i].Tag.Equals(value))
                    {
                        radioButtonBaseDetail[i].Checked = true;
                        return;
                    }
                }
            }
        }

        #endregion

        #endregion

        #region Methods

        #region private void CheckedChangedByAnyCheckBox(object sender, EventArgs e)

        private void CheckedChangedByAnyCheckBox(object sender, EventArgs e)
        {
            if (sender is RadioButton)
                if (((RadioButton) sender).Checked) OnCheckedChanged(new EventArgs());
        }

        #endregion

        #region protected void OnCheckedChanged(EventArgs e)

        /// <summary>
        /// ћетод, обрабатывающий событие изменени€ базового агрегата
        /// </summary>
        /// <param name="e"></param>
        protected void OnCheckedChanged(EventArgs e)
        {
            if (null != CheckedChanged) CheckedChanged.Invoke(this, e);
        }

        #endregion

        #endregion

        #region Events

        /// <summary>
        /// —обытие изменени€ базового агрегата
        /// </summary>
        public event EventHandler CheckedChanged;

        #endregion
    }
}