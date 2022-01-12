﻿using System;
using System.Linq;
using System.Windows.Forms;
using CAS.Entity.Models.DTO.General;
using CASTerms;
using Entity.Abstractions;
using MetroFramework.Forms;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Personnel;

namespace CAS.UI.UIControls.Users
{
	public partial class UserForm : MetroForm
	{
		#region Fields

		private User _user;
		private readonly CommonCollection<Specialist> _specialists;

		#endregion

		#region Constructor

		public UserForm()
		{
			InitializeComponent();
		}

		public UserForm(User user, CommonCollection<Specialist> specialists)
		{
			InitializeComponent();
			_user = user;
			_specialists = specialists;
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

			metroComboBox1.DataSource = Enum.GetValues(typeof(UserType));
			metroComboBox1.SelectedItem = _user.UserType;

			metroComboBoxUiType.DataSource = Enum.GetValues(typeof(UiType));
			metroComboBoxUiType.SelectedItem = _user.UiType;

			metroComboBoxPersonnel.Items.AddRange(_specialists.OrderBy(i => i.LastName).ToArray());
			metroComboBoxPersonnel.Items.Add(Specialist.Unknown);
			metroComboBoxPersonnel.SelectedItem = _user.Personnel;
		}

		#endregion

		#region private void ApplyChanges()

		private void ApplyChanges()
		{
			_user.Surname = textBoxSurname.Text;
			_user.Name = textBoxName.Text;
			_user.Login = textBoxLogin.Text;
			_user.Password = textBoxPassword.Text;
			_user.UserType = (UserType)metroComboBox1.SelectedItem;
			_user.UiType = (UiType)metroComboBoxUiType.SelectedItem;
			_user.PersonnelId = ((BaseEntityObject) metroComboBoxPersonnel.SelectedItem).ItemId;
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
				ApplyChanges();

                if (GlobalObjects.CasEnvironment != null)
                {
                    GlobalObjects.CasEnvironment.ApiProvider.AddOrUpdateUser(new UserDTO()
                    {
                        ItemId = _user.ItemId,
                        Login = _user.Login,
                        Password = _user.Password,
                        Surname = _user.Surname,
                        Name = _user.Name,
                        UserType = _user.UserType,
                        UiType = _user.UiType,
                        PersonnelId = _user.PersonnelId
                    });
				}
                else
                {
                    GlobalObjects.CaaEnvironment.ApiProvider.AddOrUpdateUser(new UserDTO()
                    {
                        ItemId = _user.ItemId,
                        Login = _user.Login,
                        Password = _user.Password,
                        Surname = _user.Surname,
                        Name = _user.Name,
                        UserType = _user.UserType,
                        UiType = _user.UiType,
                        PersonnelId = _user.PersonnelId
                    });
				}
				
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
