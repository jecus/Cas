using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using CASTerms;
using EntityCore.DTO.General;
using MetroFramework.Forms;
using SmartCore.Calculations;
using SmartCore.Entities.General.Setting;

namespace CAS.UI.UIControls.Users
{
	public partial class PurchaseSettingForm : MetroForm
	{
		#region Fields

		private Settings _setting;

		#endregion

		#region Constructor

		public PurchaseSettingForm()
		{
			InitializeComponent();
			Task.Run(() => DoWork())
				.ContinueWith(task => Completed(), TaskScheduler.FromCurrentSynchronizationContext());
		}

		#endregion

		private void Completed()
		{
			lifelengthViewerDeadlineAOG.Lifelength = _setting.PurchaseSettings.Parameters["AOG"][0];
			lifelengthViewerNotifyAOG.Lifelength = _setting.PurchaseSettings.Parameters["AOG"][1];
			lifelengthViewerDeadlineUrgent.Lifelength = _setting.PurchaseSettings.Parameters["Urgent"][0];
			lifelengthViewerNotifyUrgent.Lifelength = _setting.PurchaseSettings.Parameters["Urgent"][1];
			lifelengthViewerDeadlineRoutine.Lifelength = _setting.PurchaseSettings.Parameters["Routine"][0];
			lifelengthViewerNotifyRoutine.Lifelength = _setting.PurchaseSettings.Parameters["Routine"][1];
		}

		private void DoWork()
		{
			_setting = GlobalObjects.CasEnvironment.NewLoader.GetObject<SettingDTO, Settings>();
			if(_setting == null)
				_setting = new Settings
				{
					PurchaseSettings = new PurchaseSetting
					{
						Parameters = new Dictionary<string, List<Lifelength>>
						{
							["AOG"] = new List<Lifelength>{ Lifelength.Null , Lifelength.Null },
							["Urgent"] = new List<Lifelength> { Lifelength.Null, Lifelength.Null },
							["Routine"] = new List<Lifelength> { Lifelength.Null, Lifelength.Null },
						}
					}
				};
		}

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{
			_setting.PurchaseSettings.Parameters["AOG"][0] = lifelengthViewerDeadlineAOG.Lifelength;
			_setting.PurchaseSettings.Parameters["AOG"][1] = lifelengthViewerNotifyAOG.Lifelength;
			_setting.PurchaseSettings.Parameters["Urgent"][0] = lifelengthViewerDeadlineUrgent.Lifelength;
			 _setting.PurchaseSettings.Parameters["Urgent"][1] = lifelengthViewerNotifyUrgent.Lifelength;
			 _setting.PurchaseSettings.Parameters["Routine"][0] = lifelengthViewerDeadlineRoutine.Lifelength;
			 _setting.PurchaseSettings.Parameters["Routine"][1] = lifelengthViewerNotifyRoutine.Lifelength;

			GlobalObjects.CasEnvironment.NewKeeper.Save(_setting);

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
	}
}
