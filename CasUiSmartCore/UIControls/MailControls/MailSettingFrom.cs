using System;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Setting;


namespace CAS.UI.UIControls.MailControls
{
	public partial class MailSettingFrom : MetroForm
	{
		private readonly GlobalSetting _op;

		#region Constructor

		public MailSettingFrom()
		{
			InitializeComponent();
		}

		public MailSettingFrom(GlobalSetting op)
		{
			_op = op;
			UpdateInformation();
		}

		#endregion

		private void UpdateInformation()
		{
			textBoxHost.Text = _op.MailSettings?.Host;
			metroTextBoxPassword.Text = _op.MailSettings?.Password;
			metroTextBox2.Text = _op.MailSettings?.Mail;
			metroLabelPort.Text = _op.MailSettings?.Port.ToString() ?? "";
			checkBoxSSL.Checked = _op.MailSettings?.SSl ?? false;
			
		}

		#region private void buttonClose_Click(object sender, EventArgs e)

		private void buttonClose_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion

		#region private void ApplyChanges()

		private void ApplyChanges()
		{
			_op.MailSettings = new MailSettings
			{
				Host = textBoxHost.Text,
				Password = metroTextBoxPassword.Text,
				Mail = metroTextBox2.Text,
				Port = int.Parse(metroLabelPort.Text),
				SSl = checkBoxSSL.Checked
			};
		}

		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{
			try
			{
				ApplyChanges();
				GlobalObjects.CasEnvironment.NewKeeper.Save(_op);

				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save document", ex);
			}
		}

		#endregion

	}
}
