using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Schedule;

namespace CAS.UI.UIControls.ScheduleControls
{
	public partial class FlightNumberPeriodListControl : UserControl
	{
		#region Field

		private FlightNumber _flightNumber;
		public List<SchedulePeriods> SchedulePeriods;
		private FlightNumberScreenType _screenType;

		#endregion

		#region Constructor

		public FlightNumberPeriodListControl()
		{
			InitializeComponent();
		}

		#endregion

		#region public void UpdateControl(FlightNumber flightNumber)

		public void UpdateControl(FlightNumber flightNumber, FlightNumberScreenType screenType)
		{
			_flightNumber = flightNumber;
			_screenType = screenType;

			if (_flightNumber.FlightNumberPeriod.Count > 0)
				flowLayoutPanelPerformances.Controls.Clear();

			foreach (var period in _flightNumber.FlightNumberPeriod)
				AddPeriodControl(period);
		}

		#endregion

		#region public bool GetChangeStatus()

		public bool GetChangeStatus()
		{
			var periodControls = flowLayoutPanelPerformances.Controls.OfType<FlightNumberPeriodControl>();
			return periodControls.Any(e => e.GetChangeStatus());
		}

		#endregion

		#region public void ApplyChanges(FlightNumber currentDirective)

		public void ApplyChanges()
		{
			foreach (var control in flowLayoutPanelPerformances.Controls.OfType<FlightNumberPeriodControl>())
				control.ApplyChanges();
		}

		#endregion

		#region private void linkLabelAddNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

		private void linkLabelAddNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var newFlightNumberPeriod = new FlightNumberPeriod();
			_flightNumber.FlightNumberPeriod.Add(newFlightNumberPeriod);
			AddPeriodControl(newFlightNumberPeriod);
		}

		#endregion

		#region private void AddPeriodControl(FlightNumberPeriod flightNumberPeriod)

		private void AddPeriodControl(FlightNumberPeriod flightNumberPeriod)
		{
			var control = new FlightNumberPeriodControl(_screenType) {FlightNumberPeriod = flightNumberPeriod, SchedulePeriods = SchedulePeriods};
			control.UpdateInformation();
			control.Deleted += Control_Deleted;
			flowLayoutPanelPerformances.Controls.Remove(linkLabelAddNew);
			flowLayoutPanelPerformances.Controls.Add(control);
			flowLayoutPanelPerformances.Controls.Add(linkLabelAddNew);
		}

		#endregion

		#region private void Control_Deleted(object sender, System.EventArgs e)

		private void Control_Deleted(object sender, EventArgs e)
		{
			var control = sender as FlightNumberPeriodControl;

			var dialogResult = MessageBox.Show("Do you really want to delete Period?", "Deleting confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
			if (dialogResult == DialogResult.Yes)
			{
				if (control.FlightNumberPeriod.ItemId > 0)
				{
					try
					{
						GlobalObjects.CasEnvironment.Manipulator.Delete(control.FlightNumberPeriod, false);
					}
					catch (Exception ex)
					{
						Program.Provider.Logger.Log("Error while removing data", ex);
					}
				}
				_flightNumber.FlightNumberPeriod.Remove(control.FlightNumberPeriod);
				flowLayoutPanelPerformances.Controls.Remove(control);
				control.Deleted -= Control_Deleted;
				control.Dispose();
			}
		}

		#endregion

		#region public void Clear()

		public void Clear()
		{
			flowLayoutPanelPerformances.Controls.Clear();
			flowLayoutPanelPerformances.Controls.Add(linkLabelAddNew);
		}

		#endregion
	}
}
