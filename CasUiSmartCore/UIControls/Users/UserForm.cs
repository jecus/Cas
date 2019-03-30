using System;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Entities;

namespace CAS.UI.UIControls.Users
{
	public partial class UserForm : MetroForm
	{
		#region Fields

		private User _user;

		#endregion

		#region Constructor

		public UserForm()
		{
			InitializeComponent();
		}

		public UserForm(User user) : base()
		{
			_user = user;
			UpdateInformation();
		}

		#endregion

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			textBoxSurname.Text = _user.Surname;
			textBoxName.Text = _user.Name;
			textBoxLogin.Text = _user.Login;
			textBoxPassword.Text = _user.Password;
		}

		#endregion

		#region private bool Check()

		private bool Check()
		{
			if (!(textBoxPassword.Text.Trim().Length > 5))
			{
				MessageBox.Show("Password must be at least 5 characters long!", "Information", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				return false;
			}

			if (string.IsNullOrEmpty(textBoxLogin.Text) || string.IsNullOrEmpty(textBoxName.Text) || string.IsNullOrEmpty(textBoxSurname.Text))
			{
				MessageBox.Show("Please enter one of row!", "Information", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				return false;
			}

			return true;
		}

		#endregion

		#region private void checkBox1_CheckedChanged(object sender, System.EventArgs e)

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			textBoxPassword.PasswordChar = checkBox1.Checked ? '\0' : '*';
		}

		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{
			if (Check())
			{
				GlobalObjects.CasEnvironment.GetSeviceUser().AddOrUpdateUser(_user);
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
	}
}
