using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.WorkPackages;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.DiscrepanciesControls
{
    /// <summary>
    /// Форма для создания нового рабочего пакета или для добавления элементов в существующий рабочий пакет
    /// </summary>
    public class ComposeWorkPackageForm : Form
    {
        
        #region Fields

        private readonly Aircraft parentAircraft;

        private readonly Label labelWorkPackages = new Label();
        private readonly ComboBox comboBoxWorkPackages = new ComboBox();
        private readonly Label labelDescription = new Label();
        private readonly Button buttonOK = new Button();
        private readonly Button buttonCancel = new Button();
        private const int MARGIN = 20;
        private const int HEIGHT_INTERVAL = 10;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает Форму для создания нового рабочего пакета или для добавления элементов в существующий рабочий пакет
        /// </summary>
        /// <param name="parentAircraft">ВС, которому принадлежат рабочие пакеты</param>
        public ComposeWorkPackageForm(Aircraft parentAircraft)
        {
            this.parentAircraft = parentAircraft;
            //
            // labelWorkPackages
            //
            labelWorkPackages.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelWorkPackages.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelWorkPackages.Location = new Point(MARGIN, MARGIN);
            labelWorkPackages.Size = new Size(150, 25);
            labelWorkPackages.Text = "Work packages:";
            //
            // comboBoxWorkPackages
            //
            comboBoxWorkPackages.Font = Css.OrdinaryText.Fonts.RegularFont;
            comboBoxWorkPackages.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            comboBoxWorkPackages.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxWorkPackages.Location = new Point(labelWorkPackages.Right, MARGIN);
            comboBoxWorkPackages.Size = new Size(270, 25);
            //
            // labelDescription
            //
            labelDescription.AutoSize = true;
            labelDescription.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelDescription.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelDescription.Location = new Point(MARGIN, labelWorkPackages.Bottom + HEIGHT_INTERVAL);
            labelDescription.Text = "Choose a work package where to move selected items";
            //
            // buttonOK
            //
            buttonOK.Font = Css.OrdinaryText.Fonts.RegularFont;
            buttonOK.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            buttonOK.Size = new Size(100, 25);
            buttonOK.Text = "OK";
            buttonOK.Click += buttonOK_Click;
            //
            // buttonCancel
            //
            buttonCancel.Font = Css.OrdinaryText.Fonts.RegularFont;
            buttonCancel.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            buttonCancel.Size = new Size(100, 25);
            buttonCancel.Text = "Cancel";
            buttonCancel.Click += buttonCancel_Click;

            AcceptButton = buttonOK;
            CancelButton = buttonCancel;
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Text = "Compose a work package";
            ClientSize = new Size(labelWorkPackages.Width + comboBoxWorkPackages.Width + 2* MARGIN, comboBoxWorkPackages.Height + labelDescription.Height + HEIGHT_INTERVAL + buttonOK.Height + 2*MARGIN);
            buttonOK.Location = new Point((labelWorkPackages.Width + comboBoxWorkPackages.Width + 2 * MARGIN) / 2 - buttonOK.Width - 5, labelDescription.Bottom + 10);
            buttonCancel.Location = new Point((labelWorkPackages.Width + comboBoxWorkPackages.Width + 2 * MARGIN) / 2 + 5, labelDescription.Bottom + 10);
            Controls.Add(labelWorkPackages);
            Controls.Add(comboBoxWorkPackages);
            Controls.Add(labelDescription);
            Controls.Add(buttonOK);
            Controls.Add(buttonCancel);

            FillComboBoxItems();
        }

        #endregion

        #region Methods

        #region private void FillComboBoxItems()

        private void FillComboBoxItems()
        {
            comboBoxWorkPackages.Items.Add("Compose a new work package...");
            for (int i = 0; i < parentAircraft.WorkPackages.Length; i++)
            {
                if (parentAircraft.WorkPackages[i].Status != WorkPackageStatus.Open)
                    continue;
                comboBoxWorkPackages.Items.Add(parentAircraft.WorkPackages[i]);
            }
            if (comboBoxWorkPackages.Items.Count != 0)
                comboBoxWorkPackages.SelectedIndex = 0;            
        }

        #endregion
        
        #region private void buttonOK_Click(object sender, EventArgs e)

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (WorkPackageChoosed != null)
            {
                if (comboBoxWorkPackages.SelectedItem is WorkPackage)
                    WorkPackageChoosed((WorkPackage)comboBoxWorkPackages.SelectedItem);
                else
                    WorkPackageChoosed(null);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region private void buttonCancel_Click(object sender, EventArgs e)

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        #endregion

        #region Delegates

        /// <summary>
        /// Обработчик события формирования рабочего пакета
        /// </summary>
        /// <param name="workPackage"></param>
        public delegate void ComposeWorkPackageEventHandler(WorkPackage workPackage);

        #endregion

        #region Events

        /// <summary>
        /// Событие, для формирования рабочего пакета
        /// </summary>
        public event ComposeWorkPackageEventHandler WorkPackageChoosed;

        #endregion
        
    }

}




