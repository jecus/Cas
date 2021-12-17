using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Entities.General.Schedule;

namespace CAS.UI.UIControls.ScheduleControls.PlanOPS
{
	public partial class PlanOpsForm : MetroForm
	{
		#region Fields

		private readonly FlightPlanOps _flightPlanOps;
		private readonly IList<DateTime> _dates;

		#endregion

		#region Constructor

		public PlanOpsForm()
		{
			InitializeComponent();
		}


		public PlanOpsForm(FlightPlanOps flightPlanOps, IList<DateTime> dates) : this()
		{
			if(flightPlanOps == null)
				return;

			_flightPlanOps = flightPlanOps;
			_dates = dates;
		}

		#endregion

		#region private void ApplyChanges()

		private void ApplyChanges()
		{
			_flightPlanOps.To = dateTimePickerTo.Value.Date;
			_flightPlanOps.From = dateTimePickerFrom.Value.Date;
			_flightPlanOps.Remarks = textBoxRemarks.Text;
		}

		#endregion

		#region private void buttonOk_Click(object sender, EventArgs e)

		private void buttonOk_Click(object sender, EventArgs e)
		{
			try
			{
				ApplyChanges();

				if (_dates.Any(i => i.Equals(_flightPlanOps.From)))
				{
					MessageBox.Show("Plan OPS already exists on this date. You must enter a different date.", (string)new GlobalTermsProvider()["SystemName"],
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}

				if (_flightPlanOps.From.DayOfWeek == DayOfWeek.Monday)
				{
					if(_flightPlanOps.ItemId <= 0)
						GlobalObjects.NewKeeper.Save(_flightPlanOps);
					else GlobalObjects.PlanOpsCalculator.CreateCopyFromExistPlan(_flightPlanOps);

					DialogResult = DialogResult.OK;
				}
				else
				{
					MessageBox.Show("FromDate must start on Monday!", (string)new GlobalTermsProvider()["SystemName"],
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{
				Program.Provider.Logger.Log("Error while save document", ex);
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

		#region private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)

		private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
		{
			var value = dateTimePickerFrom.Value;

			if (value.DayOfWeek == DayOfWeek.Monday)
				dateTimePickerTo.Value = value.AddDays(6);
		}

		#endregion

		private void dateTimePickerFrom_KeyPress(object sender, KeyPressEventArgs e)
		{
			var value = dateTimePickerFrom.Value;

			if (value.DayOfWeek == DayOfWeek.Monday)
				dateTimePickerTo.Value = value.AddDays(6);
		}
	}
}
