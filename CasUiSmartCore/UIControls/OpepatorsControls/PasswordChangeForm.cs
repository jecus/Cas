using System;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;

namespace CAS.UI.UIControls.OpepatorsControls
{
    public partial class PasswordChangeForm : MetroForm
    {
	    #region Constructor

	    public PasswordChangeForm()
	    {
		    InitializeComponent();
	    }

		#endregion

		#region private void ButtonOkClick(object sender, EventArgs e)

		private void ButtonOkClick(object sender, EventArgs e)
	    {
		    if (CheckPass())
		    {
				if (GlobalObjects.CasEnvironment != null)
			        GlobalObjects.CasEnvironment.UpdateUser(textBoxNewPassword.Text);
				else GlobalObjects.CaaEnvironment.UpdateUser(textBoxNewPassword.Text);
				MessageBox.Show("Password changed successful", "Information", MessageBoxButtons.OK,
				    MessageBoxIcon.Information);
			    Close();
		    }
	    }

		#endregion

		#region private bool CheckPass()

		private bool CheckPass()
	    {
		    if (!(textBoxNewPassword.Text.Trim().Length > 5) && !(textBoxConfirmPassword.Text.Trim().Length > 5))
		    {
			    MessageBox.Show("Password must be at least 5 characters long!", "Information", MessageBoxButtons.OK,
				    MessageBoxIcon.Information);
			    return false;
		    }

		    if (!textBoxNewPassword.Text.Equals(textBoxConfirmPassword.Text))
		    {
			    MessageBox.Show("Please enter valid confirm password!", "Information", MessageBoxButtons.OK,
				    MessageBoxIcon.Information);
			    return false;
		    }


		    return true;
	    }

	    #endregion

        #region private void ButtonCancelClick(object sender, EventArgs e)

		private void ButtonCancelClick(object sender, EventArgs e)
        {
	        DialogResult = DialogResult.Cancel;
	        Close();
        }

        #endregion

		#region private void checkBox1_CheckedChanged(object sender, EventArgs e)

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
	        if (checkBox1.Checked)
	        {
		        textBoxConfirmPassword.PasswordChar = '\0';
		        textBoxNewPassword.PasswordChar = '\0';
	        }
	        else
	        {
		        textBoxConfirmPassword.PasswordChar = '*';
		        textBoxNewPassword.PasswordChar = '*';
	        }
        }

        #endregion
	}
}
