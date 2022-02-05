using System;
using System.Data;
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

namespace CAS.UI.UICAAControls.Users
{
	public partial class CAAUserForm : MetroForm
    {
		#region Fields

		private CAAUser _user;
		private readonly CommonCollection<Specialist> _specialists;

		#endregion

		#region Constructor

		public CAAUserForm()
		{
			InitializeComponent();
		}

		public CAAUserForm(CAAUser user, CommonCollection<Specialist> specialists)
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
            this.metroComboBoxPersonnel.SelectedIndexChanged -= new System.EventHandler(this.metroComboBoxPersonnel_SelectedIndexChanged);

			textBoxSurname.Text = _user.Surname;
			textBoxName.Text = _user.Name;
			textBoxLogin.Text = _user.Login;
			textBoxPassword.Text = _user.Password;

			if (_user.Personnel.IsCAA)
            {
                metroComboBox1.Items.Clear();
                foreach (var val in Enum.GetValues(typeof(CAAUserType)).OfType<CAAUserType>().Where(i => (int)i < 10).ToList())
                    metroComboBox1.Items.Add(val);
            }
            else
            {
                metroComboBox1.Items.Clear();
                foreach (var val in Enum.GetValues(typeof(CAAUserType)).OfType<CAAUserType>().Where(i => (int)i >= 10).ToList())
                    metroComboBox1.Items.Add(val);
            }

            if (_user.ItemId <= 0)
                metroComboBox1.SelectedIndex = 0;


			metroComboBox1.SelectedItem = _user.UserType;

			foreach (var val in Enum.GetValues(typeof(UiType)).OfType<UiType>().ToArray())
            {
				metroComboBoxUiType.Items.Add(val);
                metroComboBoxUiType.SelectedItem = _user.UiType;
			}

			

			metroComboBoxPersonnel.Items.AddRange(_specialists.OrderBy(i => i.LastName).ToArray());
			metroComboBoxPersonnel.Items.Add(Specialist.Unknown);
			metroComboBoxPersonnel.SelectedItem = _user.Personnel;

            this.metroComboBoxPersonnel.SelectedIndexChanged += new System.EventHandler(this.metroComboBoxPersonnel_SelectedIndexChanged);
		}

		#endregion

		#region private void ApplyChanges()

		private void ApplyChanges()
		{
			_user.Surname = textBoxSurname.Text;
			_user.Name = textBoxName.Text;
			_user.Login = textBoxLogin.Text;
			_user.Password = textBoxPassword.Text;
			_user.UserType = (CAAUserType)metroComboBox1.SelectedItem;
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

            if (_user.ItemId <= 0)
            {
                var ds = GlobalObjects.CaaEnvironment.NewLoader.Execute(
                    $"select top 1 ItemId from [dbo].[Users] where PersonnelId = {((BaseEntityObject) metroComboBoxPersonnel.SelectedItem).ItemId} and IsDeleted = 0");


                var dt = ds.Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    var id = (int?) dr[0];
                    var res =  !(id.HasValue && id.Value > 0);

					if(!res)
                    MessageBox.Show("For this specialist already create login and password!", "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return res;
                }
            }

            var checkUser = GlobalObjects.CaaEnvironment.NewLoader.Execute($@"select * from [dbo].[Users] 
where Password = '{textBoxPassword.Text}'
and  Login = '{textBoxLogin.Text}' and ItemId != {_user.ItemId} ");

            var dt2 = checkUser.Tables[0];
            foreach (DataRow dr in dt2.Rows)
            {
                var id = (int?)dr[0];
                var res = !(id.HasValue && id.Value > 0);

                if (!res)
                    MessageBox.Show("For this combination login and password already exist!", "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                return res;
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
				GlobalObjects.CaaEnvironment.ApiProvider.AddOrUpdateUser(new UserDTO
				{
					ItemId = _user.ItemId,
					Login = _user.Login,
					Password = _user.Password,
					Surname = _user.Surname,
					Name = _user.Name,
                    CAAUserType = _user.UserType,
					UiType = _user.UiType,
					PersonnelId = _user.PersonnelId,
					OperatorId =  ((Specialist)metroComboBoxPersonnel.SelectedItem).OperatorId,
					CorrectorId = GlobalObjects.CaaEnvironment.IdentityUser.ItemId,
                }); 
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

        private void metroComboBoxPersonnel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBoxPersonnel.SelectedItem != null)
            {
                var spec = metroComboBoxPersonnel.SelectedItem as Specialist;
                if (spec.IsCAA)
                {
                    metroComboBox1.Items.Clear();
                    foreach (var val in Enum.GetValues(typeof(CAAUserType)).OfType<CAAUserType>().Where(i => (int)i < 10).ToList())
                        metroComboBox1.Items.Add(val);
                }
                else
                {
                    metroComboBox1.Items.Clear();

                    if (GlobalObjects.CaaEnvironment.IdentityUser.OperatorId > 0)
                    {
                        foreach (var val in Enum.GetValues(typeof(CAAUserType)).OfType<CAAUserType>().Where(i => (int)i > 10).ToList())
                            metroComboBox1.Items.Add(val);
					}
                    else
                    {
                        foreach (var val in Enum.GetValues(typeof(CAAUserType)).OfType<CAAUserType>().Where(i => (int)i >= 10).ToList())
                            metroComboBox1.Items.Add(val);
					}

                    
				}

                metroComboBox1.SelectedIndex = 0;


            }
        }
    }
}
