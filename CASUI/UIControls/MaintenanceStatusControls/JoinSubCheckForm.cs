using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CAS.UI.UIControls.BiWeekliesReportsControls;

namespace CAS.UI.UIControls.MaintenanceStatusControls
{
    /// <summary>
    /// Форма для добавления SubCheck-а в список JobCard
    /// </summary>
    public class JoinSubCheckForm : Form
    {

        #region Fields

        private readonly Label labelSubChecks = new Label();
        private readonly ComboBox comboBoxSubChecks = new ComboBox();
        private readonly Button buttonOK = new Button();
        private readonly Button buttonCancel = new Button();
        private readonly MaintenanceSubCheck subCheck;
        private readonly SubCheckFormView view;
        private const int MARGIN = 20;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает форму для добавления SubCheck-а в список JobCard
        /// </summary>
        public JoinSubCheckForm(MaintenanceSubCheck subCheck, SubCheckFormView view)
        {
            this.subCheck = subCheck;
            this.view = view;
            //
            // labelSubChecks
            //
            labelSubChecks.Font = Css.OrdinaryText.Fonts.RegularFont;
            labelSubChecks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            labelSubChecks.Location = new Point(MARGIN, MARGIN);
            labelSubChecks.Size = new Size(100, 25);
            labelSubChecks.Text = "Subchecks:";
            //
            // comboBoxSubChecks
            //
            comboBoxSubChecks.Font = Css.OrdinaryText.Fonts.RegularFont;
            comboBoxSubChecks.ForeColor = Css.OrdinaryText.Colors.ForeColor;
            comboBoxSubChecks.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSubChecks.Location = new Point(labelSubChecks.Right, MARGIN);
            comboBoxSubChecks.Size = new Size(250, 25);
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
            if (view == SubCheckFormView.Add)
                Text = subCheck.Name + ". Join subcheck";
            else if (view == SubCheckFormView.Delete)
                Text = subCheck.Name + ". Cutoff subcheck";
            ClientSize = new Size(labelSubChecks.Width + comboBoxSubChecks.Width + 2* MARGIN, comboBoxSubChecks.Height + buttonOK.Height + 2*MARGIN + 10);
            buttonOK.Location = new Point((labelSubChecks.Width + comboBoxSubChecks.Width + 2 * MARGIN)/2 - buttonOK.Width - 5, comboBoxSubChecks.Bottom + 10);
            buttonCancel.Location = new Point((labelSubChecks.Width + comboBoxSubChecks.Width + 2 * MARGIN) / 2 + 5, comboBoxSubChecks.Bottom + 10);
            Controls.Add(labelSubChecks);
            Controls.Add(comboBoxSubChecks);
            Controls.Add(buttonOK);
            Controls.Add(buttonCancel);

            FillComboBoxItems();
        }

        #endregion

        #region Methods

        #region public List<MaintenanceSubCheck> GetAvailableSubChecks()

        /// <summary>
        /// Возвращает SubCheck-и, кототые можно присоединить
        /// </summary>
        /// <returns></returns>
        public List<MaintenanceSubCheck> GetAvailableSubChecks()
        {
            MaintenanceDirective directive = (MaintenanceDirective)subCheck.Parent.Parent;
            MaintenanceLimitation limitation = (MaintenanceLimitation)subCheck.Parent;
            List<MaintenanceSubCheck> subChecks = new List<MaintenanceSubCheck>();
            for (int i = 0; i < directive.Limitations.Length; i++)
            {
                for (int j = 0; j < directive.Limitations[i].SubChecks.Count; j++)
                    if (directive.Limitations[i].CheckType.Priority >= limitation.CheckType.Priority && directive.Limitations[i].SubChecks[j] != subCheck && !directive.Limitations[i].SubChecks[j].JoinedSubChecks.Contains(subCheck))
                        subChecks.Add(directive.Limitations[i].SubChecks[j]);
            }
            return subChecks;
        }

        #endregion


        #region private void FillComboBoxItems()

        private void FillComboBoxItems()
        {
            if (view == SubCheckFormView.Add)
            {
                comboBoxSubChecks.Items.AddRange(GetAvailableSubChecks().ToArray());
            }
            else
            {
                for (int i = 0; i < subCheck.JoinedSubChecks.Count; i++)
                {
                    comboBoxSubChecks.Items.Add(subCheck.JoinedSubChecks[i]);
                }
            }
            if (comboBoxSubChecks.Items.Count != 0)
                comboBoxSubChecks.SelectedIndex = 0;            
        }

        #endregion
        
        #region private bool SaveData()

        /// <summary>
        /// Сохраняет данные
        /// </summary>
        private bool SaveData()
        {

            try
            {
                subCheck.JoinSubCheck((MaintenanceSubCheck) comboBoxSubChecks.SelectedItem);
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while saving data", ex); return false;
            }
            return true;
        }

        #endregion

        #region private bool DeleteSubCheck()

        private bool DeleteSubCheck()
        {
            DialogResult result = MessageBox.Show(new TermsProvider()["CutOffSubCheckQuestion"].ToString(), "Deleting confirmation", MessageBoxButtons.YesNoCancel,
                                                  MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {

                try
                {
                    subCheck.CutOffSubCheck((MaintenanceSubCheck)comboBoxSubChecks.SelectedItem);
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error while deleting data", ex); 
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region private void buttonOK_Click(object sender, EventArgs e)

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if ((view == SubCheckFormView.Add && SaveData()) || (view == SubCheckFormView.Delete && DeleteSubCheck()))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
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

        
    }

    #region public enum SubCheckFormView

    /// <summary>
    /// Вид формы для добаления/редактирования/удаления SubCheck-а
    /// </summary>
    public enum SubCheckFormView
    {
        /// <summary>
        /// Добавление SubCheck-а
        /// </summary>
        Add,
        /// <summary>
        /// Редактирование SubCheck-а
        /// </summary>
        Edit,
        /// <summary>
        /// Удаление SubCheck-а
        /// </summary>
        Delete
    }

    #endregion
}



