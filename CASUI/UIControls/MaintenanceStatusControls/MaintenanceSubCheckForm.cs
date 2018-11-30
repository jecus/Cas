using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Directives;
using CAS.UI.Appearance;
using CASTerms;

namespace CAS.UI.UIControls.MaintenanceStatusControls
{
    /// <summary>
    /// Форма для редактирования и добавления subcheck-а
    /// </summary>
    public partial class MaintenanceSubCheckForm : Form
    {

        #region Fields

        private readonly MaintenanceDirective directive;
        private readonly MaintenanceSubCheck subCheck;
        private readonly SubCheckFormView view;

        #endregion

        #region Constructors

        #region public MaintenanceSubCheckForm(MaintenanceLimitation directive)

        /// <summary>
        /// Создается форма добавления подчека
        /// </summary>
        /// <param name="directive">Maintenance Directive</param>
        public MaintenanceSubCheckForm(MaintenanceDirective directive)
        {
            this.directive = directive;
            this.view = SubCheckFormView.Add;
            InitializeComponent();
            Initialize();
            Text = ((Aircraft)directive.Parent).RegistrationNumber + ". Add subcheck";
        }

        #endregion

        #region public MaintenanceSubCheckForm(MaintenanceSubCheck subCheck)

        /// <summary>
        /// Создается форма редактирования подчека
        /// </summary>
        /// <param name="subCheck"></param>
        public MaintenanceSubCheckForm(MaintenanceSubCheck subCheck)
        {
            this.subCheck = subCheck;
            view = SubCheckFormView.Edit;
            InitializeComponent();
            Initialize();
            Text = ((Aircraft)subCheck.Parent.Parent.Parent).RegistrationNumber + ". " + ((MaintenanceLimitation)subCheck.Parent).CheckType + ". " + subCheck.Name + ". Edit subcheck";
            textBoxName.Text = subCheck.Name;
        }

        #endregion

        #endregion
       
        #region Methods

        #region private void Initialize()

        private void Initialize()
        {
            Css.OrdinaryText.Adjust(labelName);
            Css.OrdinaryText.Adjust(textBoxName);
            Css.OrdinaryText.Adjust(buttonCancel);
            Css.OrdinaryText.Adjust(buttonAddSubcheck);
            buttonAddSubcheck.Click += buttonAddSubcheck_Click;
            buttonCancel.Click += buttonCancel_Click;
        }

        #endregion

        #region private bool SaveData()

        /// <summary>
        /// Сохраняет данные
        /// </summary>
        private bool SaveData()
        {
            MaintenanceSubCheck subCheck = new MaintenanceSubCheck();
            subCheck.Name = textBoxName.Text.ToUpper();
            for (int i = 0; i < directive.Limitations.Length; i++)
            {
                if (SubCheckNameAccept() && GetSubCheckShortName() == directive.Limitations[i].CheckType.ShortName)
                {
                    try
                    {
                        if (!SubCheckContains(directive.Limitations[i]))
                        {
                            directive.Limitations[i].AddSubCheck(subCheck);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("This subcheck already exists", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }

                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while saving data", ex); return false;
                    }
                }
            }
            MessageBox.Show("Invalid data!" + Environment.NewLine + "A, B, C or D subchecs expected",
                            (string) new TermsProvider()["SystemName"],
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }

        #endregion

        #region private string GetSubCheckShortName()

        private string GetSubCheckShortName()
        {
            string name = textBoxName.Text.ToUpper();
            if (name.Length > 0 && Regex.IsMatch(name[0].ToString(), "[A-Z]"))
                return name[0].ToString();
            else if (name.Length > 0 && Regex.IsMatch(name[name.Length - 1].ToString(), "[A-Z]"))
                return name[name.Length - 1].ToString();
            else
                return "";
        }

        #endregion
        
        #region private bool SubCheckContains(MaintenanceLimitation limitation)

        private bool SubCheckContains(MaintenanceLimitation limitation)
        {
            for (int i = 0; i < limitation.SubChecks.Count; i++)
            {
                if (limitation.SubChecks[i].Name == textBoxName.Text.ToUpper())
                    return true;
            }
            return false;
        }

        #endregion

        #region private bool SubCheckContains()

        private bool SubCheckContains()
        {
            return SubCheckContains((MaintenanceLimitation) subCheck.Parent);
        }

        #endregion


        #region private bool SubCheckNameAccept()

        private bool SubCheckNameAccept()
        {
            return Regex.IsMatch(textBoxName.Text.ToUpper(), "^A[0-9]+$|^[0-9]+A$|^B[0-9]+$|^[0-9]+B$|^C[0-9]+$|^[0-9]+C$|^D[0-9]+$|^[0-9]+D$");
        }

        #endregion



        #region private bool EditSubCheck()

        private bool EditSubCheck()
        {
            if (SubCheckNameAccept())
            {
                if (!SubCheckContains())
                {
                    subCheck.Name = textBoxName.Text;
                    try
                    {

                        subCheck.Save();

                    }
                    catch (Exception ex)
                    {
                        Program.Provider.Logger.Log("Error while saving data", ex); return false;
                    }

                    return true;
                }
                else
                {
                    MessageBox.Show("This subcheck already exists", (string)new TermsProvider()["SystemName"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Invalid data!" + Environment.NewLine + "A, B, C or D subchecs expected",
                (string)new TermsProvider()["SystemName"],
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        #endregion

        #region private void buttonCancel_Click(object sender, EventArgs e)

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion

        #region private void buttonAddSubcheck_Click(object sender, EventArgs e)

        private void buttonAddSubcheck_Click(object sender, EventArgs e)
        {
            if ((view == SubCheckFormView.Add && SaveData()) || (view == SubCheckFormView.Edit && EditSubCheck()))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        #endregion
        
        #endregion
        
    }

}