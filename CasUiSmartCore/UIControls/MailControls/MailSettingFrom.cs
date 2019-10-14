using System;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace CAS.UI.UIControls.MailControls
{
	public partial class MailSettingFrom : MetroForm
	{
		
		#region Constructor

		public MailSettingFrom()
		{
			InitializeComponent();
		}

		#endregion

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
			
		}

		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{
			try
			{
				ApplyChanges();
				//GlobalObjects.CasEnvironment.NewKeeper.Save();

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
