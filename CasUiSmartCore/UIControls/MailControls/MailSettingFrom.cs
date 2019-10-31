using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using CASTerms;
using EntityCore.DTO.General;
using MetroFramework.Forms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Setting;


namespace CAS.UI.UIControls.MailControls
{
	public partial class MailSettingFrom : MetroForm
	{
		private Settings _op;

		#region Constructor

		public MailSettingFrom()
		{
			InitializeComponent();
			Task.Run(() => DoWork())
				.ContinueWith(task => UpdateInformation(), TaskScheduler.FromCurrentSynchronizationContext());
		}

		private void DoWork()
		{
			_op = GlobalObjects.CasEnvironment.NewLoader.GetObject<SettingDTO, Settings>();

			if(_op == null)
				_op = new Settings();
		}

		#endregion

		private void UpdateInformation()
		{
			textBoxHost.Text = _op.GlobalSetting?.MailSettings?.Host;
			metroTextBoxPassword.Text = _op.GlobalSetting?.MailSettings?.Password;
			metroTextBox2.Text = _op.GlobalSetting?.MailSettings?.Mail;
			metroTextBoxPort.Text = _op.GlobalSetting?.MailSettings?.Port.ToString() ?? "";
			checkBoxSSL.Checked = _op.GlobalSetting?.MailSettings?.SSl ?? false;
			
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
			_op.GlobalSetting.MailSettings = new MailSettings
			{
				Host = textBoxHost.Text,
				Password = metroTextBoxPassword.Text,
				Mail = metroTextBox2.Text,
				Port = int.Parse(metroTextBoxPort.Text),
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
