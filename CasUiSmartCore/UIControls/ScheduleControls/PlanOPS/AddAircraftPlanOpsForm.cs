using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Schedule;

namespace CAS.UI.UIControls.ScheduleControls.PlanOPS
{
	public partial class AddAircraftPlanOpsForm : Form
	{
		#region Fields

		private readonly IEnumerable<FlightPlanOpsRecords> _records;

		#endregion

		#region Constructor

		public AddAircraftPlanOpsForm()
		{
			InitializeComponent();
		}

		public AddAircraftPlanOpsForm(IEnumerable<FlightPlanOpsRecords> records) : this()
		{
			_records = records;
			UpdateInformation();
		}

		#endregion

		#region private void UpdateInformation()

		private void UpdateInformation()
		{
			comboBoxAircrafts.Items.Clear();
			comboBoxAircrafts.Items.AddRange(GlobalObjects.AircraftsCore.GetAllAircrafts().ToArray());
		}

		#endregion

		#region public bool ValidateData(out string message)
		/// <summary>
		/// Возвращает значение, показывающее является ли значение элемента управления допустимым
		/// </summary>
		/// <returns></returns>
		public bool ValidateData(out string message)
		{
			message = "";

			if (comboBoxAircrafts.SelectedItem == null)
			{
				if (message != "")
					message += "\n";
				message += "Not set Aircraft";
				return false;
			}

			return true;
		}

		#endregion

		private void buttonOk_Click(object sender, EventArgs e)
		{
			string message;
			if (!ValidateData(out message))
			{
				message += "\nAbort operation";
				MessageBox.Show(message, (string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				var selectedAircraft = comboBoxAircrafts.SelectedItem as Aircraft;
				foreach (var record in _records)
				{
					record.AircraftId = selectedAircraft.ItemId;
					record.Aircraft = selectedAircraft;

					GlobalObjects.CasEnvironment.NewKeeper.Save(record);
				}
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save document", ex);
			}
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
